using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TPIntegradorProgIII.Controllers
{
    [Route("api/meet")]
    [ApiController]
    [Authorize]
    public class MeetController : ControllerBase
    {
    }
}
