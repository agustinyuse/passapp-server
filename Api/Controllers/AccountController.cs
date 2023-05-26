using Application.Features.Account.Commands;
using Application.Features.Professional.Commands;
using Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ApiController
    {
        public AccountController(ISender sender)
        : base(sender)
        {
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginCommand loginCommand, CancellationToken cancellationToken)
        {
            Result<string> result = await sender.Send(loginCommand, cancellationToken);

            if (result.IsFailure)
            {
                return HandleFailure(result);
            }

            return result.IsSuccess ? Ok(result.Value()) : NotFound(result.Error);
        }
    }
}
