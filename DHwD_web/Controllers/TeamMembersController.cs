using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using AutoMapper;
using DHwD_web.Data;
using DHwD_web.Dtos;
using DHwD_web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

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
        //POST api/teamMembers/newTeam
        [HttpPost("newTeam")]
        public ActionResult<TeamMembersCreateDto> CreateNewTeam(TeamMembersCreateDto teamMembersCreateDto)
        {
            var handler = new JwtSecurityTokenHandler();
            string authHeader = Request.Headers["Authorization"];
            authHeader = authHeader.Replace("Bearer ", "");
            var jsonToken = handler.ReadToken(authHeader);
            var tokenS = handler.ReadToken(authHeader) as JwtSecurityToken;
            var team = _mapper.Map<TeamMembers>(teamMembersCreateDto);
            var identity = tokenS.Claims.First(claim => claim.Type == "jti").Value;
            team.User=_userRepo.GetUserById(int.Parse(identity));
            var result = _repository.AddNewMemberNewTeam(team);
            if (result)
            {
                TeamMembersReadDto teamMembersReadDto=_mapper.Map<TeamMembersReadDto>(team);
                return Ok(); 
                //return CreatedAtRoute(nameof(TeamController.GetTeamById), new { teamread.Id }, teamread);
            }
            else
                return BadRequest();
        }
    }
}
