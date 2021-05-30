using AutoMapper;
using DHwD_web.Data.Interfaces;
using DHwD_web.Dtos.Quiz;
using DHwD_web.Operations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models.ModelsDB;
using Models.Request;
using Models.Respone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHwD_web.Controllers
{
    [Route("api/Quiz")]
    [ApiController]
    [Authorize]
    public class QuizController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IQuizRepo _repository;
        private readonly IMapper _mapper;
        private readonly IChatsRepo _chatsRepo;
        private readonly IActivePlacesRepo _activePlacesRepo;
        private readonly IGamesRepo _gamesRepo;
        private readonly ITeamRepo _teamRepo;
        public QuizController(IConfiguration config, IQuizRepo repository, IMapper mapper, IChatsRepo chatsRepo, IActivePlacesRepo activePlacesRepo,
            IGamesRepo gamesRepo, ITeamRepo teamRepo)
        {
            _config = config;
            _repository = repository;
            _mapper = mapper;
            _chatsRepo = chatsRepo;
            _activePlacesRepo = activePlacesRepo;
            _gamesRepo = gamesRepo;
            _teamRepo = teamRepo;
        }

        //get api/Quiz/Id_place={Id_place}&Id_team={Id_team}
        [HttpGet("Id_place={Id_place}")]
        public async Task<ActionResult<QuizReadDto>> GetMessage(int Id_team, int Id_place)
        {
            var activeplace = await _activePlacesRepo.GetActivePlacebyTeamIDandPlaceID(Id_team, Id_place);
            int number;
            try
            { number = Int32.Parse(activeplace.QuizStatus); }
            catch 
            {
                return NoContent();
            }
            var team = _teamRepo.GetTeamById(activeplace.Team_Id);
            var game = await _gamesRepo.GetGame(team.Games.Id);
            List<Chats> chats = new List<Chats>();
            bool next = true;
            while (next)
            {
                var quiz = await _repository.GetQuizbyIdPlace_Id_Sequence(activeplace.Place.Id, number);
                if (quiz == null)
                    break;
                if (!String.IsNullOrEmpty(quiz.Message_1))
                {
                    chats.Add(new Chats
                    {
                        Team = team,
                        Text = quiz.Message_1,
                        DateTimeCreate = DateTime.UtcNow,
                        IsSystem = true,
                        Game = game
                    });
                }
                if (!String.IsNullOrEmpty(quiz.Message_2))
                {
                    chats.Add(new Chats
                    {
                        Team = team,
                        Text = quiz.Message_2,
                        DateTimeCreate = DateTime.UtcNow,
                        IsSystem = true,
                        Game = game
                    });
                }
                if (!String.IsNullOrEmpty(quiz.Message_3))
                {
                    chats.Add(new Chats
                    {
                        Team = team,
                        Text = quiz.Message_3,
                        DateTimeCreate = DateTime.UtcNow,
                        IsSystem = true,
                        Game = game
                    });
                }
                if (!String.IsNullOrEmpty(quiz.Questions))
                {
                    chats.Add(new Chats
                    {
                        Team = team,
                        Text = quiz.Questions,
                        DateTimeCreate = DateTime.UtcNow,
                        IsSystem = true,
                        Game = game
                    });
                    next = false;
                }
                else
                {
                    number++;
                    next = true;
                }
            }
            await _chatsRepo.SaveListOnTheServer(chats);
            var item = await _repository.GetQuizbyIdPlace_Id_Sequence(activeplace.Place.Id, number);
            if (item != null)
            {
                activeplace.QuizStatus = item.Id.ToString();
                await _activePlacesRepo.Update(activeplace);
                return Ok(_mapper.Map<QuizReadDto>(item));
            }
            return NoContent();
        }

        //POST api/Quiz
        [HttpPost]
        public async Task<ActionResult<BaseRespone>> PostSolutionToCheck(QuizSolution quizSolution)
        {
            BaseRespone baseRespone = new BaseRespone
            {
                Succes = true,
                Message = ""
            };
            var activeplace = await _activePlacesRepo.GetActivePlacebyTeamIDandPlaceID(quizSolution.Id_Team, quizSolution.Id_Place);
            var quiz = await _repository.GetQuizbyIdPlace_Id_Sequence(quizSolution.Id_Place, Int32.Parse(activeplace.QuizStatus));
            if (quiz == null)
            {
                baseRespone.Succes = false;
                baseRespone.Message = "null";
                return NotFound(baseRespone);
            }
            var team = _teamRepo.GetTeamById(activeplace.Team_Id);
            var game = await _gamesRepo.GetGame(team.Games.Id);
            if (quiz.Solution.ToLower().Contains(quizSolution.TextSolution.ToLower()))
            {
                await _chatsRepo.SaveOnTheServer(new Chats
                {
                    IsSystem = false,
                    DateTimeCreate = DateTime.UtcNow,
                    Game = game,
                    Team = team,
                    Text = quizSolution.TextSolution
                });
                List<Chats> chats = new List<Chats>();
                QuizOperations quizOperations = new QuizOperations();
                chats = await quizOperations.GetMessageAsync(_repository, _activePlacesRepo, Int32.Parse(activeplace.QuizStatus),
                    activeplace, team, game);
                await _chatsRepo.SaveListOnTheServer(chats);
                return Ok(baseRespone);
            }

            baseRespone.Succes = false;
            return BadRequest(baseRespone);

        }
    }
}
