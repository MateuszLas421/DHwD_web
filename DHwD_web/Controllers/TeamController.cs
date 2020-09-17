using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DHwD_web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
    }
}
