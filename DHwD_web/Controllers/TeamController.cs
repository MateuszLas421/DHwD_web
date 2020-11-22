﻿using AutoMapper;
using DHwD_web.Data;
using DHwD_web.Dtos;
using DHwD_web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace DHwD_web.Controllers
{
    [Route("api/team")]
    [ApiController]
    [Authorize]
    public class TeamController : ControllerBase
    {
        private readonly ITeamRepo _repository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly IStatusRepo _statusRepo;
        public TeamController(IConfiguration config, ITeamRepo repository, IMapper mapper, IStatusRepo statusRepo)
        {
            _config = config;
            _repository = repository;
            _mapper = mapper;
            _statusRepo = statusRepo;
        }
        //POST api/team
        [HttpPost]
        public ActionResult<TeamCreateDto> CreateNewTeam(TeamCreateDto teamCreateDto)
        {
            var handler = new JwtSecurityTokenHandler();
            string authHeader = Request.Headers["Authorization"];
            authHeader = authHeader.Replace("Bearer ", "");
            var jsonToken = handler.ReadToken(authHeader);
            var tokenS = handler.ReadToken(authHeader) as JwtSecurityToken;
            var team = _mapper.Map<Team>(teamCreateDto);
            var identity = tokenS.Claims.First(claim => claim.Type == "jti").Value;
            team.Id_Founder = _repository.GetUser(int.Parse(identity));
            team.DateTimeCreate = DateTime.UtcNow;
            if (team.Password != null)
                team.StatusPassword = true;
            team.DateTimeEdit = team.DateTimeCreate;
            if (!_repository.Check(team))
                return NoContent();
            var status = _statusRepo.CreateNewStatus();
            if (status == null)
                return NoContent();
            team.StatusRef = status.ID;
            _repository.CreateNewTeam(team);

            try
            {
                _repository.SaveChanges();
            }
            catch (Exception) { return NotFound(); }
            var teamread = _mapper.Map<TeamReadDto>(team);
            return CreatedAtRoute(nameof(GetTeamById), new { teamread.Id }, teamread);
            return Ok();
        }
        //get api/team/all/{IdGame}
        [HttpGet("all/{IdGame}")]
        public ActionResult<IEnumerable<TeamReadDto>> GetallTeams(int IdGame)
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
                return NotFound();
            var Items = _repository.GetTeams(IdGame);
            if (Items != null)
            {
                return Ok(_mapper.Map<IEnumerable<TeamReadDto>>(Items));
            }
            return NotFound();
        }
        //get api/team/{id}
        [HttpGet("{id}", Name = "GetTeamById")]
        public ActionResult<IEnumerable<TeamReadDto>> GetTeamById(int id)
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
                return NotFound();
            var Items = _repository.GetTeamById(id);
            if (Items != null)
            {
                return Ok(_mapper.Map<TeamReadDto>(Items));
            }
            return NotFound();
        }
        //get api/team/{idteam}/{hashpass}
        [HttpGet("{idteam}/{hashpass}", Name = "CheckPass")]
        public ActionResult CheckPass( int idteam, string hashpass)
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
                return NotFound();
            var Items = _repository.CheckPass(idteam, hashpass);
            if (Items)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
