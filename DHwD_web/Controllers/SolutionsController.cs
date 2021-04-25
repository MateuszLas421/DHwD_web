using AutoMapper;
using DHwD_web.Data.Interfaces;
using DHwD_web.Helpers;
using DHwD_web.Operations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models.ModelsMobile;
using System;
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

        public SolutionsController(IConfiguration config, ISolutionsRepo repository, IMapper mapper, IMysteryRepo mysteryRepo, IChatsRepo chatsRepo, IUserRepo userRepo, IGamesRepo gamesRepo, ITeamMembersRepo teamMembersRepo)
        {
            _config = config;
            _repository = repository;
            _mapper = mapper;
            _mysteryRepo = mysteryRepo;
            _chatsRepo = chatsRepo;
            _userRepo = userRepo;
            _gamesRepo = gamesRepo;
            _teamMembersRepo = teamMembersRepo;
        }

        //POST api/Solutions
        [HttpPost]
        public async Task<ActionResult<string>> PostSolutionToCheck(SolutionRequest solutionRequest)
        {
            var game = await _gamesRepo.GetGame(solutionRequest.gameid);
            var solution = await _repository.GetSolutionsByid(_mysteryRepo.GetMysteryById(solutionRequest.IdMystery).Result.SolutionsRef);
            var httpContext = HttpContext;
            var userId = await ReadUserId.Read(httpContext);
            SolutionsOperations solutionsOperations = new SolutionsOperations();
            try
            {
                if (solution.Text.ToLower().Equals(solutionRequest.TextSolution.ToLower()))
                {

                    if (await solutionsOperations.SaveOnServer(_chatsRepo, _teamMembersRepo, solution.MysterySolutionPozitive, userId, game))
                        return Ok(); //await Task.FromResult<string>(solution.MysterySolutionPozitive); 
                    else
                        return BadRequest();
                }
                else
                {
                    if (await solutionsOperations.SaveOnServer(_chatsRepo, _teamMembersRepo, solution.MysterySolutionNegative, userId, game))
                        return Ok(); //await Task.FromResult<string>(solution.MysterySolutionNegative);
                    else
                        return BadRequest();
                }

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
