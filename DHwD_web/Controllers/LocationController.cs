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
            List<int> idLocations = await _placeRepo.GetID_PlacesByTeam_Id(teamid);
            List<Location> Items = new List<Location>();
            for (int i = 0; i < idLocations.Count; i++)
            {
                Items.Add(await _repository.GetLocationById(idLocations[i]));
            }
            if (Items != null)
            {
                return Ok(_mapper.Map<IEnumerable<LocationReadDto>>(Items));
            }
            return NotFound();
        }
    }
}
