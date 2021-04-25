using AutoMapper;
using DHwD_web.Data.Interfaces;
using DHwD_web.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DHwD_web.Controllers
{
    [Route("api/Mystery")]
    [ApiController]
    [Authorize]
    public class MysteryController : ControllerBase
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

        //get api/Mystery/location={idLocation}
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

        //get api/Mystery/{id}
        [HttpGet("{id}", Name = "GetMysterybyid")]
        public async Task<ActionResult<IEnumerable<MysteryReadDto>>> GetMysterybyid(int id)
        {
            var Items = await _repository.GetMysteryById(id);

            if (Items != null)
            {
                return Ok(_mapper.Map<MysteryReadDto>(Items));
            }
            return NotFound();
        }
    }
}
