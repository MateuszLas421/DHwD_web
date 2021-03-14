using AutoMapper;
using DHwD_web.Data.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHwD_web.Controllers
{
    public class MysteryController : Controller
    {

        private readonly IMysteryRepo _repository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public MysteryController(IConfiguration config, IMysteryRepo repository, IMapper mapper)
        {
            _config = config;
            _repository = repository;
            _mapper = mapper;
        }
    }
}
