using AutoMapper;
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
using System.Security.Claims;

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
        public TeamController(IConfiguration config, ITeamRepo repository, IMapper mapper)
        {
            _config = config;
            _repository = repository;
            _mapper = mapper;
        }
        //POST api/team
        [HttpPost]
        public ActionResult<TeamCreateDto> CreateNewTeam(TeamCreateDto teamReateDto)
        {
            var handler = new JwtSecurityTokenHandler();
            string authHeader = Request.Headers["Authorization"];
            authHeader = authHeader.Replace("Bearer ", "");
            var jsonToken = handler.ReadToken(authHeader);
            var tokenS = handler.ReadToken(authHeader) as JwtSecurityToken;
            var team = _mapper.Map<Team>(teamReateDto);
            var identity = tokenS.Claims.First(claim => claim.Type == "jti").Value;
            team.Id_Founder =_repository.GetUser(int.Parse(identity));
            team.DateTimeCreate = DateTime.UtcNow;
            if (team.Password != null)
                team.StatusPassword = true;
            team.DateTimeEdit = team.DateTimeCreate;
            if (!_repository.Check(team))
                return NoContent();
            _repository.CreateNewTeam(team);
            _repository.SaveChanges();
            //var userReadDto = _mapper.Map<UserReadDto>(team);                                                               //TODO
            return Ok(); //CreatedAtRoute(nameof(GetUserByNickName_Token), new { userReadDto.NickName, userReadDto.Token }, userReadDto);
        }
    }
}
