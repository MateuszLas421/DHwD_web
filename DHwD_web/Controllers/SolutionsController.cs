using AutoMapper;
using DHwD_web.Data.Interfaces;
using DHwD_web.Helpers;
using DHwD_web.Operations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models.ModelsDB;
using Models.ModelsMobile;
using Models.Respone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHwD_web.Controllers
{
    [Route("api/Solutions")]
    [ApiController]
    [Authorize]
    public class SolutionsController : ControllerBase
    {
        private readonly ISolutionsRepo _repository;
        private readonly IMapper _mapper;
        private readonly IMysteryRepo _mysteryRepo;
        private readonly IChatsRepo _chatsRepo;
        private readonly IUserRepo _userRepo;
        private readonly IGamesRepo _gamesRepo;
        private readonly ITeamMembersRepo _teamMembersRepo;
        private readonly IConfiguration _config;
        private readonly IActivePlacesRepo _activePlacesRepo;
        private readonly ITeamRepo _teamRepo;
        private readonly IStatusRepo _statusRepo;
        private readonly IMurdererMessagesRepo _murdererMessagesRepo;

        public SolutionsController(IConfiguration config, ISolutionsRepo repository, IMapper mapper, IMysteryRepo mysteryRepo,
            IChatsRepo chatsRepo, IUserRepo userRepo, IGamesRepo gamesRepo, ITeamMembersRepo teamMembersRepo,
            IActivePlacesRepo activePlacesRepo, ITeamRepo teamRepo, IStatusRepo statusRepo, IMurdererMessagesRepo murdererMessagesRepo)
        {
            _config = config;
            _repository = repository;
            _mapper = mapper;
            _mysteryRepo = mysteryRepo;
            _chatsRepo = chatsRepo;
            _userRepo = userRepo;
            _gamesRepo = gamesRepo;
            _teamMembersRepo = teamMembersRepo;
            _activePlacesRepo = activePlacesRepo;
            _teamRepo = teamRepo;
            _statusRepo = statusRepo;
            _murdererMessagesRepo = murdererMessagesRepo;
        }

        //POST api/Solutions
        [HttpPost]
        public async Task<ActionResult<BaseRespone>> PostSolutionToCheck(SolutionRequest solutionRequest)
        {
            BaseRespone baseRespone = new BaseRespone
            {
                Succes = true,
                Message = ""
            };
            var game = await _gamesRepo.GetGame(solutionRequest.Id_Game);
            var solution = await _repository.GetSolutionsByid(_mysteryRepo.GetMysteryById(solutionRequest.IdMystery).Result.SolutionsRef);
            var httpContext = HttpContext;
            ActivePlace activePlace = new ActivePlace();
            var userId = await ReadUserId.Read(httpContext);
            SolutionsOperations solutionsOperations = new SolutionsOperations();
            try
            {
                bool checker = false;
                if (String.IsNullOrEmpty(solutionRequest.TextSolution))
                {
                    baseRespone.Succes = false;
                    baseRespone.ErrorCode = 400;
                    baseRespone.Message = "TextSolution is null or Empty";
                    return BadRequest(baseRespone);
                }
                if (solution.Text.ToLower().Contains(solutionRequest.TextSolution.ToLower()))
                {

                    checker = true;
                }
                else
                {
                    if (solution.Text.ToLower().Equals(solutionRequest.TextSolution.ToLower()))  // TO delete?
                        checker = true;
                }

                if (checker)
                {
                    if
                    (
                        await _chatsRepo.SaveOnTheServer(new Chats
                        {
                            IsSystem = false,
                            DateTimeCreate = DateTime.UtcNow,
                            Game = game,
                            Team = _teamRepo.GetTeamById(solutionRequest.Id_Team),
                            Text = solutionRequest.TextSolution
                        }) == false
                    )
                    {
                        baseRespone.Succes = false;
                        baseRespone.ErrorCode = 400;
                        return BadRequest(baseRespone);
                    }
                    if ((activePlace = await _activePlacesRepo.CheckActivePlace(solutionRequest.Id_Team)).Place == null)
                    {
                        baseRespone.Succes = false;
                        baseRespone.Message = "No found active place";
                        baseRespone.ErrorCode = 400;
                        return BadRequest(baseRespone);
                    }
                    if (await solutionsOperations.SaveOnServer(_chatsRepo, _teamMembersRepo, solution.MysterySolutionPozitive, userId, game)) //Pozitive
                    {
                        if (activePlace.TypePlace == 1 || activePlace.TypePlace == 2)
                        {
                            List<MurdererMessages> list = await _murdererMessagesRepo.GetListByPlaceID(solutionRequest.Id_Place, 2);
                            List<Chats> chats = new List<Chats>();
                            list = list.OrderBy(o => o.NumerMessage).ToList();

                            for (int i = 0; i < list.Count; i++)
                            {
                                chats.Add(new Chats
                                {
                                    Team = _teamRepo.GetTeamById(solutionRequest.Id_Team),
                                    Text = list[i].Text,
                                    DateTimeCreate = DateTime.UtcNow,
                                    IsSystem = true,
                                    Game = await _gamesRepo.GetGame(solutionRequest.Id_Game)
                                });
                            }
                            bool createmessagestatus = await _chatsRepo.SaveListOnTheServer(chats);
                        }
                        baseRespone.Message = "Solved";
                        if (activePlace.TypePlace == 2)
                        {
                            activePlace.QuizStatus = "0";
                            baseRespone.Message = "SolvedChat";
                            if (await _activePlacesRepo.Update(activePlace))
                                return Ok(baseRespone);
                            else
                            {
                                baseRespone.Succes = false;
                                baseRespone.ErrorCode = 400;
                                return BadRequest(baseRespone);
                            }
                        }
                        if (await solutionsOperations.EndPlace(_activePlacesRepo, _teamRepo, _statusRepo, solutionRequest) == true)
                        {
                            return Ok(baseRespone);
                        }
                        else
                        {
                            baseRespone.Succes = false;
                            baseRespone.ErrorCode = 400;
                            return BadRequest(baseRespone);
                        }
                    }
                    else
                    {
                        baseRespone.Succes = false;
                        baseRespone.ErrorCode = 400;
                        return BadRequest(baseRespone);
                    }
                }
                else  //Negative
                {
                    if
                    (
                        await _chatsRepo.SaveOnTheServer(new Chats
                        {
                            IsSystem = false,
                            DateTimeCreate = DateTime.UtcNow,
                            Game = game,
                            Team = _teamRepo.GetTeamById(solutionRequest.Id_Team),
                            Text = solutionRequest.TextSolution
                        }) == false
                    )
                    {
                        baseRespone.Succes = false;
                        baseRespone.ErrorCode = 400;
                        return BadRequest(baseRespone);
                    }
                    if (await solutionsOperations.SaveOnServer(_chatsRepo, _teamMembersRepo, solution.MysterySolutionNegative, userId, game))
                    {
                        baseRespone.Message = "Unresolved";
                        return Ok(baseRespone);
                    }
                    else
                    {
                        baseRespone.Succes = false;
                        baseRespone.ErrorCode = 400;
                        return BadRequest(baseRespone);
                    }
                }

            }
            catch (Exception ex)
            {
                {
                    baseRespone.Succes = false;
                    baseRespone.ErrorCode = 400;
                    baseRespone.Message = "Fail";
                    return BadRequest(baseRespone);
                }
            }
        }
    }
}
