using Microsoft.AspNetCore.Mvc;
using System;

namespace BarDg.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InitController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> ApiOnline()
        {
            return $"API Online - {DateTime.Now}";
        }
    }
}
