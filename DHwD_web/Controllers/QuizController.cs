using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHwD_web.Controllers
{
    [Route("api/Quiz")]
    [ApiController]
    [Authorize]
    public class QuizController : ControllerBase
    {
    }
}
