using System;
using System.Collections.Generic;
using AutoMapper;
using DHwD.Model;
using DHwD_web.Data;
using DHwD_web.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace DHwD_web.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _repository;
        private readonly IMapper _mapper;

        public UserController(IUserRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //get api/user
        [HttpGet]
        public ActionResult <IEnumerable<UserReadDto>> GetallUser()    //TODO delete!!!
        {
            var userItems = _repository.GetallUser();
            if (userItems != null)
            {
                return Ok(_mapper.Map<IEnumerable<UserReadDto>>(userItems));
            }
            return NotFound();
        }
        //get api/user/{NickName}/{Token}
        [HttpGet("{NickName}/{Token}", Name="GetUserByNickName_Token")]
        public ActionResult<UserReadDto> GetUserByNickName_Token(string NickName, string Token)  
        {
            var userItem = _repository.GetUserByNickName_Token(NickName, Token);
            if (userItem != null)
            {
                return Ok(_mapper.Map<UserReadDto>(userItem));
            }
            return NotFound();
        }

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
            return CreatedAtRoute(nameof(GetUserByNickName_Token), new { userReadDto.NickName, userReadDto.Token }, userReadDto);
        }
    }
}
