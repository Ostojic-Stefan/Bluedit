using Microsoft.AspNetCore.Mvc;

namespace Bluedit.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
    }
}
