using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TPIntegradorProgIII.Controllers
{
    [Route("api/trial")]
    [ApiController]
    [Authorize]
    public class TrialController : ControllerBase
    {
    }
}