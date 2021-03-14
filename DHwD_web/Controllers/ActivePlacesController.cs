using AutoMapper;
using DHwD_web.Data;
using DHwD_web.Data.interfaces;
using DHwD_web.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace DHwD_web.Controllers
{
    [Route("api/ActivePlaces")]
    [ApiController]
    [Authorize]
    public class ActivePlacesController : ControllerBase
    {
        private readonly IActivePlacesRepo _repository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public ActivePlacesController(IConfiguration config, IActivePlacesRepo repository, IMapper mapper)
        {
            _config = config;
            _repository = repository;
            _mapper = mapper;
        }

        //get api/ActivePlaces/{id}
        [HttpGet("{id}", Name = "GetActivePlacebyID")]
        public ActionResult<IEnumerable<ActivePlacesReadDto>> GetActivePlacesById(int id)
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
                return NotFound();
            var Items = _repository.GetActivePlacebyID(id);
            if (Items != null)
            {
                return Ok(_mapper.Map<ActivePlacesReadDto>(Items));
            }
            return NotFound();
        }
        ////get api/ActivePlaces/team={id}
        //[HttpGet("team={id}", Name = "GetActivePlacesByTeamId")]
        //public ActionResult<IEnumerable<ActivePlacesReadDto>> GetActivePlacesByTeamId(int id)
        //{
        //    if (!HttpContext.User.Identity.IsAuthenticated)
        //        return NotFound();
        //    var Items = _repository.GetActivePlacesByTeamId(id);
        //    if (Items != null)
        //    {
        //        return Ok(_mapper.Map<ActivePlacesReadDto>(Items));
        //    }
        //    return NotFound();
        //}

    }
}
