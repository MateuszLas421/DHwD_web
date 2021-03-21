using AutoMapper;
using DHwD_web.Data.Interfaces;
using DHwD_web.Dtos;
using DHwD_web.Helpers;
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
        private readonly ITeamMembersRepo _teamMembersRepo;
        private readonly IActivePlacesRepo _activePlacesRepo;
        private readonly IPlaceRepo _placeRepo;

        public TeamController(IConfiguration config, ITeamRepo repository, IMapper mapper, IStatusRepo statusRepo, ITeamMembersRepo teamMembersRepo,
            IActivePlacesRepo activePlacesRepo, IPlaceRepo placeRepo)
        {
            _config = config;
            _repository = repository;
            _mapper = mapper;
            _statusRepo = statusRepo;
            _teamMembersRepo = teamMembersRepo;
            _activePlacesRepo= activePlacesRepo;
            _placeRepo = placeRepo;
        }
        //POST api/team
        [HttpPost]
        public ActionResult<TeamCreateDto> CreateNewTeam(TeamCreateDto teamCreateDto)
        {
            var httpContext = HttpContext;
            var identity = ReadUserId.Read(httpContext).Result;
            var team = _mapper.Map<Team>(teamCreateDto);
            team.Id_Founder = _repository.GetUser(identity);
            team.DateTimeCreate = DateTime.UtcNow;
            if (team.Password != null)
                team.StatusPassword = true;
            team.DateTimeEdit = team.DateTimeCreate;
            if (!_repository.Check(team))
                return NoContent();
            Status status = new Status();
            status = _statusRepo.CreateNewStatus(status);
            if (status == null)
                return NoContent();
            team.StatusRef = status.ID;
            _repository.CreateNewTeam(team);
            try
            {
                _repository.SaveChanges();
            }
            catch (Exception) { return NotFound(); }
            var place= _placeRepo.GetPlaceById(0, team.Games.Id);
            if (place == null)
                return NoContent();
            status.ActivePlace = _activePlacesRepo.CreativeActivePlace(team.Id, place).Result;
            status.Game_Status = true;
            _statusRepo.UpdateNewStatus(status);
            var teamread = _mapper.Map<TeamReadDto>(team);
            return CreatedAtRoute(nameof(GetTeamById), new { teamread.Id }, teamread);
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
