using AutoMapper;
using DHwD_web.Data.Interfaces;
using DHwD_web.Dtos;
using DHwD_web.Helpers;
using DHwD_web.Models;
using DHwD_web.Models.Mobile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHwD_web.Controllers
{
    [Route("api/Chats")]
    [ApiController]
    [Authorize]
    public class ChatsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IChatsRepo _repository;
        private readonly IUserRepo _userRepo;
        private readonly IGamesRepo _gamesRepo;
        private readonly ITeamMembersRepo _teamMembersRepo;
        private readonly IConfiguration _config;

        public ChatsController(IConfiguration config, IMapper mapper, IChatsRepo repository, IUserRepo userRepo, IGamesRepo gamesRepo, ITeamMembersRepo teamMembersRepo)
        {
            _config = config;
            _repository = repository;
            _mapper = mapper;
            _userRepo = userRepo;
            _gamesRepo = gamesRepo;
            _teamMembersRepo = teamMembersRepo;
        }

        //get api/Chats/Team={gameid}
        [HttpGet("Team={gameid}", Name = "GetChat")]
        public async Task<ActionResult<IEnumerable<ChatsReadDto>>> GetChat(int gameid)
        {
            var httpContext = HttpContext;
            var userId = await ReadUserId.Read(httpContext);
            var Items = _repository.GetChat(gameid, (await _teamMembersRepo.GetMyTeams(gameid, userId)).Team.Id);
            if (Items != null)
            {
                return Ok(_mapper.Map<IEnumerable<ChatsReadDto>>(Items));
            }
            return NotFound();
        }

        //POST api/Solutions
        [HttpPost]
        public async Task<ActionResult> SaveMessage(Message message)
        {
            var httpContext = HttpContext;
            var userId = await ReadUserId.Read(httpContext);
            ChatsCreateDto chatsCreateDto = new ChatsCreateDto
                {
                DateTimeCreate = DateTime.UtcNow,
                Game = new Games(),
                IsSystem = false,
                Text = message.Text,
                Team = new Team()
                };
            chatsCreateDto.Game = await _gamesRepo.GetGame(message.gameid);
            chatsCreateDto.Team = (await _teamMembersRepo.GetMyTeams(message.gameid, userId)).Team;
            var result = await _repository.SaveOnTheServer(_mapper.Map<Chats>(chatsCreateDto));
            if (result == true)
                return Ok();
            return BadRequest();
        }
    }
}
