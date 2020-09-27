using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using DHwD.Model;
using DHwD_web.Data;
using DHwD_web.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DHwD_web.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _repository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public UserController(IConfiguration config ,IUserRepo repository, IMapper mapper)
        {
            _config = config;
            _repository = repository;
            _mapper = mapper;
        }
        #region Unauthorized

        //POST api/user
        [HttpPost]
        public ActionResult<UserReadDto> CreateNewUser(UserCreateDto userCreateDto)
        {
            var userModel = _mapper.Map<User>(userCreateDto);
            userModel.DateTimeCreate = DateTime.UtcNow;
            userModel.DateTimeEdit = userModel.DateTimeCreate;
            _repository.CreateNewUser(userModel);
            _repository.SaveChanges();
            var userReadDto = _mapper.Map<UserReadDto>(userModel);
            return Ok(userReadDto);
        }
        #endregion

        //POST api/user/{NickName}/{Token}
        [HttpGet("{NickName}/{Token}")]
        public ActionResult Login(string NickName, string Token)
        {
            ActionResult response = Unauthorized();

            var user = AuthenticateUser(NickName, Token);
            if (user != null)
            {
                var tokenStr = GenerateJsonWebToken(user);
                response = Ok(new { token = tokenStr }); ;
            }
            return response;
        }


        private UserReadDto AuthenticateUser(string NickName, string Token)
        {
            var userItem = _repository.GetUserByNickName_Token(NickName, Token);
            if (userItem != null)
            {
                UserReadDto userRead = _mapper.Map<UserReadDto>(userItem);
                return userRead;
            }
            return null;
        }


        private string GenerateJsonWebToken(UserReadDto userinfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,userinfo.NickName),
                new Claim(JwtRegisteredClaimNames.Jti,userinfo.Id.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            var encodetoken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodetoken;
        }
    }
}
