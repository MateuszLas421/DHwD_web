using System.Collections.Generic;
using AutoMapper;
using DHwD_web.Data;
using DHwD_web.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DHwD_web.Controllers
{
    [Route("api/games")]
    [ApiController]
    [Authorize]
    public class GamesController : ControllerBase
    {
        private readonly IGamesRepo _repository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public GamesController(IConfiguration config, IGamesRepo repository, IMapper mapper)
        {
            _config = config;
            _repository = repository;
            _mapper = mapper;
        }
        //get api/games
        [HttpGet]
        public ActionResult<IEnumerable<GamesReadDto>> GetallGames()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
                return NotFound();
            var Items = _repository.GetallGames();
            if (Items != null)
            {
                return Ok(_mapper.Map<IEnumerable<GamesReadDto>>(Items));
            }
            return NotFound();
        }
    }
}
