using AutoMapper;
using DHwD_web.Data.interfaces;
using DHwD_web.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHwD_web.Controllers
{
    [Route("api/Mystery")]
    [ApiController]
    [Authorize]
    public class MysteryController : Controller
    {

        private readonly IMysteryRepo _repository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly ILocationRepo _locationRepo;

        public MysteryController(IConfiguration config, IMysteryRepo repository, IMapper mapper, ILocationRepo locationRepo)
        {
            _config = config;
            _repository = repository;
            _mapper = mapper;
            _locationRepo = locationRepo;
        }

        //get api/Location/location={idLocation}
        [HttpGet("location={idLocation}", Name = "GetMysterybyLocation")]
        public async Task<ActionResult<IEnumerable<MysteryReadDto>>> GetMysterybyLocation(int idLocation)
        {
            var location = await _locationRepo.GetLocationById(idLocation);

            var Items = await _repository.GetMysteryById(location.MysteryRef);

            if (Items != null)
            {
                return Ok(_mapper.Map<MysteryReadDto>(Items));
            }
            return NotFound();
        }
    }
}
