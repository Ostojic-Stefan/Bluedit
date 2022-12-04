using Microsoft.AspNetCore.Mvc;

namespace Bluedit.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
    }
}
