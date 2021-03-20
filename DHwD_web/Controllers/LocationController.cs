using AutoMapper;
using DHwD_web.Data.Interfaces;
using DHwD_web.Dtos;
using DHwD_web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DHwD_web.Controllers
{
    [Route("api/Location")]
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
        //get api/Location/team={teamid}
        [HttpGet("team={teamid}", Name = "GetActivePlacesByTeamId")]
        public async Task<ActionResult<IEnumerable<LocationReadDto>>> GetLocationByTeamIdAsync(int teamid)
        {
            int idLocation = await _placeRepo.GetID_PlaceByTeam_Id(teamid);

            Location Items = await _repository.GetLocationById(idLocation);
            if (Items != null)
            {
                return Ok(_mapper.Map<LocationReadDto>(Items));
            }
            return NotFound();
        }
    }
}
