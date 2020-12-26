using AutoMapper;
using DHwD_web.Data;
using DHwD_web.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DHwD_web.Controllers
{
    [Route("api/Status")]
    [ApiController]
    [Authorize]
    public class StatusController : ControllerBase
    {
        private readonly IStatusRepo _repository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public StatusController(IConfiguration config, IStatusRepo repository, IMapper mapper)
        {
            _config = config;
            _repository = repository;
            _mapper = mapper;
        }
        //get api/Status/create
        [HttpGet("create")]
        public async Task<ActionResult<IEnumerable<StatusReadDto>>> CreateStatus() // TODO
        {

            //var Items = ;
            //if (Items != null)
            //{
            //   // return Ok(_mapper.Map<IEnumerable<GamesReadDto>>(Items));
            //}
            return NotFound();
        }
        //get api/Status/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<StatusReadDto>>> GetStatus() // TODO
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
                return NotFound();
            //var Items = ;
            //if (Items != null)
            //{
            //   // return Ok(_mapper.Map<IEnumerable<GamesReadDto>>(Items));
            //}
            return NotFound();
        }
    }
}
