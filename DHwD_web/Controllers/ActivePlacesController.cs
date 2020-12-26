using AutoMapper;
using DHwD_web.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

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
    }
}
