using AutoMapper;
using DHwD_web.Data.Interfaces;
using DHwD_web.Dtos;
using DHwD_web.Models;
using DHwD_web.Models.Mobile;
using DHwD_web.Operations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace DHwD_web.Controllers
{
    [Route("api/Solutions")]
    [ApiController]
    [Authorize]
    public class SolutionsController : ControllerBase
    {
        private readonly ISolutionsRepo _repository;
        private readonly IMapper _mapper;
        private readonly IMysteryRepo _mysteryRepo;
        private readonly IChatsRepo _chatsRepo;
        private readonly IUserRepo _userRepo;
        private readonly IConfiguration _config;

        public SolutionsController(IConfiguration config, ISolutionsRepo repository, IMapper mapper, IMysteryRepo mysteryRepo, IChatsRepo chatsRepo, IUserRepo userRepo)
        {
            _config = config;
            _repository = repository;
            _mapper = mapper;
            _mysteryRepo = mysteryRepo;
            _chatsRepo = chatsRepo;
            _userRepo = userRepo;
        }

        //POST api/Solutions
        [HttpPost]
        public async Task<ActionResult<string>> PostSolutionToCheck(SolutionRequest solutionRequest)
        {
            var solution = await _repository.GetSolutionsByid(_mysteryRepo.GetMysteryById(solutionRequest.IdMystery).Result.SolutionsRef);
            var handler = new JwtSecurityTokenHandler();
            string authHeader = Request.Headers["Authorization"];
            authHeader = authHeader.Replace("Bearer ", "");
            var jsonToken = handler.ReadToken(authHeader);
            var tokenS = handler.ReadToken(authHeader) as JwtSecurityToken;
            var userId = Int32.Parse(tokenS.Claims.First(claim => claim.Type == "jti").Value);
            SolutionsOperations solutionsOperations = new SolutionsOperations();
            try
            {
                if (solution.Text.ToLower().Equals(solutionRequest.TextSolution.ToLower()))
                {

                    if (await solutionsOperations.SaveOnServer(_chatsRepo, _userRepo, solution.MysterySolutionPozitive, userId))
                        return await Task.FromResult<string>(solution.MysterySolutionPozitive); 
                    else
                        return BadRequest();
                }
                else 
                {
                    if (await solutionsOperations.SaveOnServer(_chatsRepo, _userRepo, solution.MysterySolutionNegative, userId))
                        return await Task.FromResult<string>(solution.MysterySolutionNegative);
                    else
                        return BadRequest();
                }
                    
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
