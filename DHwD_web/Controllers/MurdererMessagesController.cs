using AutoMapper;
using DHwD_web.Data.Interfaces;
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
    [Route("api/MurdererMessages")]
    [ApiController]
    [Authorize]
    public class MurdererMessagesController : ControllerBase
    {
        private readonly IMurdererMessagesRepo _repository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public MurdererMessagesController(IConfiguration config, IMurdererMessagesRepo repository, IMapper mapper)
        {
            _config = config;
            _repository = repository;
            _mapper = mapper;
        }
    }
}
