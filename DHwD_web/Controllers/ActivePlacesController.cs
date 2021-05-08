using AutoMapper;
using DHwD_web.Data.Interfaces;
using DHwD_web.Dtos;
using DHwD_web.Helpers;
using DHwD_web.Operations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models.ModelsDB;
using Models.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        private readonly IStatusRepo _statusRepo;
        private readonly ITeamRepo _teamRepo;

        public ActivePlacesController(IConfiguration config, IActivePlacesRepo repository, IMapper mapper, IStatusRepo statusRepo, ITeamRepo teamRepo)
        {
            _config = config;
            _repository = repository;
            _mapper = mapper;
            _statusRepo = statusRepo;
            _teamRepo = teamRepo;
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

        //post api/ActivePlaces/BlockedPlace
        [HttpPost("/BlockedPlace")]
        public async Task<ActionResult> BlockedPlace(BlockedPlaceRequest blockedPlaceRequest)
        {
            var Item = await _repository.GetActivePlacebyTeamIDandPlaceID(blockedPlaceRequest.Id_Team, blockedPlaceRequest.Id_Place);
            Item.Active = true;
            var result = await _repository.Update(Item);
            if (result == true) 
                return Ok(_mapper.Map<ActivePlacesReadDto>(Item));
            return BadRequest();
        }

        //post api/ActivePlaces/UnblockedPlace
        [HttpPost("/UnblockedPlace")]
        public async Task<ActionResult> UnblockedPlace(BlockedPlaceRequest blockedPlaceRequest)
        {
            var Item = await _repository.GetActivePlacebyTeamIDandPlaceID(blockedPlaceRequest.Id_Team, blockedPlaceRequest.Id_Place);
            Item.Blocked = true;
            var result = await _repository.Update(Item);
            if (result != true)
                return BadRequest();
            Team team = _teamRepo.GetTeamById(blockedPlaceRequest.Id_Team);
            var status = _statusRepo.GetStatusById(team.StatusRef);
            ActivePlacesOperations aPOperations = new ActivePlacesOperations();
            if (Item.UnlockedPlace != null && Item.UnlockedPlace != "")
            {
                status = await aPOperations.Update_ActivePlace_in_Status(status, Item.UnlockedPlace);
                await _statusRepo.Update(status);
            }

            if (result == true)
                return Ok(_mapper.Map<ActivePlacesReadDto>(Item));
            return BadRequest();
        }

        //get api/ActivePlaces/Check?Id_Team={Id_Team}
        [HttpGet("Check/Id_Team={Id_Team}")]
        public ActionResult<bool> CheckActivePlace(int Id_Team)
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
                return NotFound();
            var Items = _repository.CheckActivePlace(Id_Team);
            if (Items != null)
            {
                return Ok(_mapper.Map<bool>(Items));
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
