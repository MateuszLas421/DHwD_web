﻿using AutoMapper;
using DHwD_web.Data.Interfaces;
using DHwD_web.Dtos;
using DHwD_web.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models.ModelsDB;
using Models.ModelsMobile;
using Models.Request;
using Models.Respone;
using System;
using System.Collections.Generic;
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

        //get api/Chats/Game={gameid}
        [HttpGet("Game={gameid}", Name = "GetChat")]
        public async Task<ActionResult<IEnumerable<ChatsReadDto>>> GetChat(int gameid)
        {
            var httpContext = HttpContext;
            var userId = await ReadUserId.Read(httpContext);
            var Items = await _repository.GetChat(gameid, (await _teamMembersRepo.GetMyTeams(gameid, userId)).Team.Id);
            if (Items != null)
            {
                return Ok(_mapper.Map<IEnumerable<ChatsReadDto>>(Items));
            }
            return NotFound();
        }

        //POST api/Chats
        [HttpPost]
        public async Task<ActionResult<BaseRespone>> SaveMessage(Message message)
        {
            var httpContext = HttpContext;
            var userId = await ReadUserId.Read(httpContext);
            BaseRespone baseRespone = new BaseRespone
            {
                Succes = true,
                Message = ""
            };
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
            {
                return Ok(baseRespone);
            }
            baseRespone.Succes = false;
            baseRespone.ErrorCode = 400;
            return BadRequest(baseRespone);
        }


        //get api/Chats/Update/Game={gameid}?DateTimeCreate={dateTime}
        [HttpGet("Update/Game={gameid}", Name = "GetUpdateChat")]
        public async Task<ActionResult<IEnumerable<ChatsReadDto>>> GetUpdateChat(int gameid, DateTime DateTimeCreate)
        {
            var httpContext = HttpContext;
            var userId = await ReadUserId.Read(httpContext);
            int teamid = (await _teamMembersRepo.GetMyTeams(gameid, userId)).Team.Id;
            GetUpdateChatRequest getUpdate = new GetUpdateChatRequest { 
                Id_Game = gameid,
                dateTime = DateTimeCreate,
                Id_Team = teamid
            };
            var Items = await _repository.GetUpdateChat(getUpdate);
            if (Items != null)
            {
                return Ok(_mapper.Map<IEnumerable<ChatsReadDto>>(Items));
            }
            return NotFound();
        }
    }
}
