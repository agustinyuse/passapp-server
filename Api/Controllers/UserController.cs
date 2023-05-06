using Application.Features.Professional.Commands;
using Application.Features.User.Commands;
using Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ApiController
    {
        public UserController(ISender sender)
        : base(sender)
        {
        }

        [HttpPost("login")]
        public async Task<IActionResult> Save(LoginCommand loginCommand, CancellationToken cancellationToken)
        {
            Result result = await sender.Send(loginCommand, cancellationToken);

            if (result.IsFailure)
            {
                return HandleFailure(result);
            }

            return result.IsSuccess ? Ok(result.IsSuccess) : NotFound(result.Error);
        }
    }
}
