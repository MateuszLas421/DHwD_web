using AutoMapper;
using DHwD_web.Data.Interfaces;
using DHwD_web.Dtos;
using DHwD_web.Helpers;
using DHwD_web.Models;
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
        private readonly ITeamRepo _teamRepo;
        private readonly ITeamMembersRepo _teamMembersRepo;
        private readonly IActivePlacesRepo _activePlacesRepo;
        private readonly IPlaceRepo _placeRepo;

        public StatusController(IConfiguration config, IStatusRepo repository, IMapper mapper, ITeamRepo teamRepo, ITeamMembersRepo teamMembersRepo, IActivePlacesRepo activePlacesRepo, IPlaceRepo placeRepo)
        {
            _config = config;
            _repository = repository;
            _mapper = mapper;
            _teamRepo = teamRepo;
            _teamMembersRepo = teamMembersRepo;
            _activePlacesRepo = activePlacesRepo;
            _placeRepo = placeRepo;
        }
        
        //get api/Status/create/{gameID}
        [HttpGet("create/{gameID}")]
        public async Task<ActionResult<IEnumerable<StatusReadDto>>> CreateStatus(int gameID)
        {
            Status status = new Status();
            var httpContext = HttpContext;
            var id = await ReadUserId.Read(httpContext);
            var teammembers = await _teamMembersRepo.GetMyTeams(gameID, id);
            var place = await _placeRepo.GetPlace(0,gameID);
            ActivePlacesCreateDto activePlacesCreateDto = new ActivePlacesCreateDto(place);
            ActivePlace activePlace = _mapper.Map<ActivePlace>(activePlacesCreateDto);
            await _activePlacesRepo.Save(activePlace);
            //activePlace = await _activePlacesRepo.GetActivePlacebyTeamIDandActive(teammembers.Team.Id);
            StatusCreateDto statusCreateDto = new StatusCreateDto(teammembers.Team);
            status = _mapper.Map<Status>(statusCreateDto);
            _repository.CreateNewStatus(status);
            if (status != null)
            {
                 return Ok(_mapper.Map<IEnumerable<StatusReadDto>>(status));
            }
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

        //get api/Status/update/{gameID}
        [HttpGet("update/{gameID}")]
        public async Task<ActionResult<IEnumerable<StatusReadDto>>> UpdateStatus(int gameID)   // TODO
        {
            Status status = new Status();
            var httpContext = HttpContext;
            var id = await ReadUserId.Read(httpContext);

            var teammembers = await _teamMembersRepo.GetMyTeams(gameID, id);
            status = _repository.GetStatusById(teammembers.Team.StatusRef);

            var place = await _placeRepo.GetPlace(0, gameID);
            ActivePlacesCreateDto activePlacesCreateDto = new ActivePlacesCreateDto(place);
            ActivePlace activePlace = _mapper.Map<ActivePlace>(activePlacesCreateDto);
            await _activePlacesRepo.Save(activePlace);
            activePlace = await _activePlacesRepo.GetActivePlacebyTeamIDandActive(teammembers.Team.Id);

            //status.ActivePlace = activePlace;   // TO Fix ?
            _repository.UpdateNewStatus(status);
            if (status != null)
            {
                return Ok(_mapper.Map<IEnumerable<StatusReadDto>>(status));
            }
            return NotFound();
        }
    }
}
