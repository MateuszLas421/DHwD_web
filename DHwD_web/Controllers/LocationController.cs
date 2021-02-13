using AutoMapper;
using AutoMapper.Configuration;
using DHwD_web.Data;
using DHwD_web.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHwD_web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LocationController : ControllerBase
    {
        private readonly ILocationRepo _repository;
        private readonly IMapper _mapper;
        private readonly IPlaceRepo _placeRepo;
        private readonly IConfiguration _config;

        public LocationController(IConfiguration config, ILocationRepo repository, IMapper mapper, IPlaceRepo placeRepo)
        {
            _config = config;
            _repository = repository;
            _mapper = mapper;
            _placeRepo = placeRepo;
        }
        //get api/Location/team={id}
        [HttpGet("team={id}", Name = "GetActivePlacesByTeamId")]
        public async Task<ActionResult<IEnumerable<LocationReadDto>>> GetLocationByTeamIdAsync(int teamid)
        {
            int idLocation = await _placeRepo.GetID_PlaceByTeam_Id(teamid);

            var Items = _repository.GetLocationById(idLocation);
            if (Items != null)
            {
                return Ok(_mapper.Map<LocationReadDto>(Items));
            }
            return NotFound();
        }
    }
}
