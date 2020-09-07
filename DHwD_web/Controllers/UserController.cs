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
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _repository;

        public UserController(IUserRepo repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public ActionResult<User> Start()
        {
            return Ok();
        }
        //get api/commands[][]
        [HttpGet("{NickName}/{Token}")]
        public ActionResult<User> GetUserByNickName_Token(string NickName, string Token)
        {
            var commandItem = _repository.GetUserByNickName_Token(NickName, Token);
            return Ok(commandItem);
        }
    }
}
