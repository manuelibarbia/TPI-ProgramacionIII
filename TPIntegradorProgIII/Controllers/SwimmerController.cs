// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TPIntegradorProgIII.Models;
using TPIntegradorProgIII.Services.Interfaces;

namespace TPIntegradorProgIII.Controllers
{
    [Route("api/swimmer")]
    [ApiController]
    [Authorize]
    public class SwimmerController : ControllerBase
    {
        private readonly ISwimmerService _swimmerService;
        public SwimmerController(ISwimmerService swimmerService)
        {
            this._swimmerService = swimmerService;
        }

        [HttpGet("meets")]
        public ActionResult<ICollection<MeetDto>> GetMeets()  //Chequear si está bien (copiado de ConsultaAlumnos)
        {
            var user = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRole != "nadador")
                return Forbid();

            return _swimmerService.GetMeetsBySwimmer(int.Parse(user)).ToList();
        }

        public ActionResult<ICollection<TrialDto>> GetTrials()  // Chequear si está bien (copiado de ConsultaAlumnos)
        {
            var user = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRole != "nadador")
                return Forbid();

            return _swimmerService.GetTrialsBySwimmer(int.Parse(user)).ToList();
        }
    }
}
