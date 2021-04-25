using AutoMapper;
using DHwD_web.Data.Interfaces;
using DHwD_web.Dtos;
using DHwD_web.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models.ModelsDB;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DHwD_web.Controllers
{
    [Route("api/teamMembers")]
    [ApiController]
    [Authorize]
    public class TeamMembersController : ControllerBase
    {
        private readonly ITeamMembersRepo _repository;
        private readonly IMapper _mapper;
        private readonly IUserRepo _userRepo;
        private readonly IConfiguration _config;
        public TeamMembersController(IConfiguration config, ITeamMembersRepo repository, IMapper mapper, IUserRepo userRepo)
        {
            _config = config;
            _repository = repository;
            _mapper = mapper;
            _userRepo = userRepo;
        }

        //POST api/teamMembers
        [HttpPost]
        public ActionResult<TeamMembersCreateDto> JoinToTeam(Team team)  //TODO
        {
            var httpContext = HttpContext;
            var identity = ReadUserId.Read(httpContext).Result;
            var _team = _mapper.Map<Team>(team);
            TeamMembers teammember = new TeamMembers();
            teammember.Team = _team;
            teammember.JoinTime = DateTime.UtcNow;
            teammember.User = _userRepo.GetUserById(identity).Result;
            var result = _repository.AddNewMember(teammember);
            if (result)
            {
                TeamMembersReadDto teamMembersReadDto = _mapper.Map<TeamMembersReadDto>(teammember);
                return Ok();
                //return CreatedAtRoute(nameof(TeamController.GetTeamById), new { teamread.Id }, teamread); //TODO
            }
            else
                return BadRequest();
        }

        //POST api/teamMembers/newTeam
        [HttpPost("newTeam")]
        public ActionResult<TeamMembersCreateDto> CreateNewTeam(TeamMembersCreateDto teamMembersCreateDto)  //TODO
        {
            var httpContext = HttpContext;
            var identity = ReadUserId.Read(httpContext).Result;
            var team = _mapper.Map<TeamMembers>(teamMembersCreateDto);
            team.JoinTime = DateTime.UtcNow;
            team.User = _userRepo.GetUserById(identity).Result;
            var result = _repository.AddNewMemberNewTeam(team);
            if (result)
            {
                TeamMembersReadDto teamMembersReadDto = _mapper.Map<TeamMembersReadDto>(team);
                return Ok();
                //return CreatedAtRoute(nameof(TeamController.GetTeamById), new { teamread.Id }, teamread); //TODO
            }
            else
                return BadRequest();
        }
        //get api/teamMembers/{IdGame}
        [HttpGet("{IdTeam}")]
        public ActionResult<TeamMembersReadDto> GetTeamMembers(int IdTeam)
        {
            var Items = _repository.GetTeamMembers(IdTeam);
            if (Items != null)
            {
                return Ok(_mapper.Map<IEnumerable<TeamMembersReadDto>>(Items));
            }
            return NotFound();
        }
        //get api/teamMembers/my/{IdGame}
        [HttpGet("my/{IdGame}")]
        public async Task<ActionResult<TeamMembersReadDto>> GetmyTeams(int IdGame)
        {
            var httpContext = HttpContext;
            var identity = ReadUserId.Read(httpContext).Result;
            var Items = await _repository.GetMyTeams(IdGame, identity);
            if (Items != null)
            {
                Items.User.TeamMembers = null;
                Items.Team.TeamMembers = null;
                return Ok(_mapper.Map<TeamMembersReadDto>(Items));
            }
            return NotFound();
        }

    }
}
