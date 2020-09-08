using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DHwD.Model;
using DHwD_web.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DHwD_web.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _repository;

        public UserController(IUserRepo repository)
        {
            _repository = repository;
        }
        //get api/user
        [HttpGet("all")]
        public ActionResult <IEnumerable<User>> GetallUser()    //TODO delete!!!
        {
            var userItems = _repository.GetallUser();
            if (userItems != null)
            {
                return Ok(userItems);
            }
            return NotFound();
        }
        //get api/user/[][]
        [HttpGet("{NickName}/{Token}")]
        public ActionResult<User> GetUserByNickName_Token(string NickName, string Token)  
        {
            var userItem = _repository.GetUserByNickName_Token(NickName, Token);
            if (userItem != null)
            {
                return Ok(userItem);
            }
            return NotFound();
        }
    }
}
