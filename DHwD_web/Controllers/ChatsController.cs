﻿using AutoMapper;
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
        private readonly IConfiguration _config;

        public ChatsController(IConfiguration config, IMapper mapper, IChatsRepo repository, IUserRepo userRepo, IGamesRepo gamesRepo)
        {
            _config = config;
            _repository = repository;
            _mapper = mapper;
            _userRepo = userRepo;
            _gamesRepo = gamesRepo;
        }

        //get api/Chats/Team={gameid}
        [HttpGet("Team={gameid}", Name = "GetChat")]
        public async Task<ActionResult<IEnumerable<ChatsReadDto>>> GetChat(int gameid)
        {
            var httpContext = HttpContext;
            var userId = await ReadUserId.Read(httpContext);
            var Items = _repository.GetChat(gameid, userId);
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
                User = new User()
                };
            chatsCreateDto.Game = await _gamesRepo.GetGame(message.gameid);
            chatsCreateDto.User = await _userRepo.GetUserById(userId);
            var result = await _repository.SaveOnTheServer(_mapper.Map<Chats>(chatsCreateDto));
            if (result == true)
                return Ok();
            return BadRequest();
        }
    }
}
