using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        public UserController()
        {
        }

        [HttpGet("getUser")]
        public int Get()
        {
            return 0;
        }
    }
}
