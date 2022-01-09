using AutoMapper;
using DHwD_web.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models.ModelsDB;
using System.Threading.Tasks;

namespace DHwD_web.Controllers
{
    [Route("api/v2/info")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private readonly IInfoRepo _repository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public InfoController(IConfiguration config, IInfoRepo repository, IMapper mapper)
        {
            _config = config;
            _repository = repository;
            _mapper = mapper;
        }

        //Get api/v2/info
        [HttpGet]
        public async Task<ActionResult> GetInfo()
        {
            Info info = new Info();
            info.ApiVersion = typeof(Program).Assembly.GetName().Version.ToString();
            info.DbVersion = _repository.GetInfo().Result.DbVersion;
            return await Task.FromResult(Ok(info));
        }
    }
}
