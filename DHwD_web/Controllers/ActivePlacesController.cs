﻿using AutoMapper;
using DHwD_web.Data.Interfaces;
using DHwD_web.Dtos;
using DHwD_web.Helpers;
using DHwD_web.Operations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models.ModelsDB;
using Models.Request;
using Models.Respone;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IChatsRepo _chatsRepo;
        private readonly IMurdererMessagesRepo _murdererMessagesRepo;
        private readonly ILocationRepo _locationRepo;
        private readonly IMysteryRepo _mysteryRepo;
        private readonly IGamesRepo _gamesRepo;

        public ActivePlacesController(IConfiguration config, IActivePlacesRepo repository, IMapper mapper, IStatusRepo statusRepo, 
            ITeamRepo teamRepo, IChatsRepo chatsRepo, IMurdererMessagesRepo murdererMessagesRepo, ILocationRepo locationRepo,
            IMysteryRepo mysteryRepo, IGamesRepo gamesRepo)
        {
            _config = config;
            _repository = repository;
            _mapper = mapper;
            _statusRepo = statusRepo;
            _teamRepo = teamRepo;
            _chatsRepo = chatsRepo;
            _murdererMessagesRepo = murdererMessagesRepo;
            _locationRepo = locationRepo;
            _mysteryRepo = mysteryRepo;
            _gamesRepo = gamesRepo;
        }

        //get api/ActivePlaces/{id}
        [HttpGet("{id}", Name = "GetActivePlacebyID")]
        public async Task<ActionResult<ActivePlacesReadDto>> GetActivePlacesById(int id)
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
                return NotFound();
            var Items = await _repository.GetActivePlacebyID(id);
            if (Items != null)
            {
                return Ok(_mapper.Map<ActivePlacesReadDto>(Items));
            }
            return NotFound();
        }

        //post api/ActivePlaces/BlockedPlace
        [HttpPost("BlockedPlace")]
        public async Task<ActionResult<ActivePlacesReadDto>> BlockedPlace(BlockedPlaceRequest blockedPlaceRequest)
        {
            int typemessage = -1;
            var test = await _repository.CheckActivePlace(blockedPlaceRequest.Id_Team);
            if (test != null)
            {
                BadRequest();
            }
            var Item = await _repository.GetActivePlacebyTeamIDandPlaceID(blockedPlaceRequest.Id_Team, blockedPlaceRequest.Id_Place);
            Item.Active = true;
            var result = await _repository.Update(Item);
            if (Item.TypePlace == 1 || Item.TypePlace == 2)
                typemessage = 1;
            List<MurdererMessages> list = await _murdererMessagesRepo.GetListByPlaceID(blockedPlaceRequest.Id_Place, typemessage);
            List<Chats> chats = new List<Chats>();
            list = list.OrderBy(o => o.NumerMessage).ToList();

            for(int i=0; i<list.Count ; i++)
            {
                chats.Add(new Chats {
                    Team = _teamRepo.GetTeamById(blockedPlaceRequest.Id_Team),
                    Text = list[i].Text,
                    DateTimeCreate = DateTime.UtcNow,
                    IsSystem = true,
                    Game = await _gamesRepo.GetGame(blockedPlaceRequest.Id_Game)
                });
            }
            bool createmessagestatus = await _chatsRepo.SaveListOnTheServer(chats);

            var location = await _locationRepo.GetLocationById(blockedPlaceRequest.Id_Location);

            var Items = await _mysteryRepo.GetMysteryById(location.MysteryRef);

            Chats messageSolution = new Chats
            {
                Team = _teamRepo.GetTeamById(blockedPlaceRequest.Id_Team),
                Text = Items.Text,
                DateTimeCreate = DateTime.UtcNow,
                IsSystem = true,
                Game = await _gamesRepo.GetGame(blockedPlaceRequest.Id_Game)
            };

            bool messageSolutionstatus = await _chatsRepo.SaveOnTheServer(messageSolution);

            if (result == true) 
                return Ok(_mapper.Map<ActivePlacesReadDto>(Item));
            return BadRequest();
        }

        //post api/ActivePlaces/EndPlace
        [HttpPost("EndPlace")]
        public async Task<ActionResult<ActivePlacesReadDto>> EndPlace(BlockedPlaceRequest blockedPlaceRequest)
        {
            var Item = await _repository.GetActivePlacebyTeamIDandPlaceID(blockedPlaceRequest.Id_Team, blockedPlaceRequest.Id_Place);
            Item.IsCompleted = true;
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

        //get api/ActivePlaces/Check/Id_Team={Id_Team}
        [HttpGet("Check/Id_Team={Id_Team}")]
        public async Task<ActionResult<ActivePlace>> CheckActivePlace(int Id_Team)
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
                return NotFound();
            var Item = await _repository.CheckActivePlace(Id_Team);
            if (Item != null)
            {
                return Ok(_mapper.Map<ActivePlacesReadDto>(Item));
            }
            return NotFound();
        }

    }
}
