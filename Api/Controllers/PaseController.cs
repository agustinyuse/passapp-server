using Application.Features.Pase.Commands;
using Application.Features.Pase.Queries.GetAll;
using Domain.Enums;
using Infrastructure.Authentication;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaseController : ApiController
    {
        public PaseController(ISender sender) : base(sender) { }


        [HasPermission(PermissionEnum.AccessPase)]
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll(GetAllQuery query)
        {
            var result = await sender.Send(query);

            return result.IsSuccess ? Ok(result.Value()) : NotFound(result.Error);
        }

        [HasPermission(PermissionEnum.AccessPase)]
        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateCommand command)
        {
            var result = await sender.Send(command);

            return result.IsSuccess ? Ok(result) : NotFound(result.Error);
        }
    }
}
