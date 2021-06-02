using AutoMapper;
using DHwD_web.Data.Interfaces;
using DHwD_web.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace DHwD_web.Controllers
{
    [Route("api/Places")]
    [ApiController]
    [Authorize]
    public class PlaceController : ControllerBase
    {
        private readonly IPlaceRepo _repository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public PlaceController(IConfiguration config, IPlaceRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _config = config;
        }

        //get api/Places/Location/{id}
        [HttpGet("Location/{id}", Name = "GetPlaceByLocationId")]
        public async Task<ActionResult<PlaceReadDto>> GetPlacesByLocationId(int id)
        {
            var result = await _repository.GetPlaceByLocationId(id);
            if (result != null)
                return Ok(_mapper.Map<PlaceReadDto>(result));
            return BadRequest();
        }
    }
}
