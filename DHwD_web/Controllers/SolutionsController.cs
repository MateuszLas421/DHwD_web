using AutoMapper;
using DHwD_web.Data.interfaces;
using DHwD_web.Dtos;
using DHwD_web.Models.Mobile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
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
        private readonly IConfiguration _config;

        public SolutionsController(IConfiguration config, ISolutionsRepo repository, IMapper mapper, IMysteryRepo mysteryRepo)
        {
            _config = config;
            _repository = repository;
            _mapper = mapper;
            _mysteryRepo = mysteryRepo;
        }

        //POST api/Solutions
        [HttpPost]
        public async Task<ActionResult<string>> PostSolutionToCheck(SolutionRequest solutionRequest)
        {
            var solution = await _repository.GetSolutionsByid(_mysteryRepo.GetMysteryById(solutionRequest.idMystery).Result.SolutionsRef);
            try
            {
                if (solution.Text.ToLower().Equals(solutionRequest.TextSolution.ToLower()))
                    return await Task.FromResult<string>(solution.MysterySolutionPozitive);     //TODO
                else
                    return await Task.FromResult<string>(solution.MysterySolutionNegative);     //TODO
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
