using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Features.Professional.Queries;
using Domain.Shared;
using Application.Features.Professional.Commands;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfessionalController : ApiController
{
    public ProfessionalController(ISender sender)
        : base(sender)
    {
    }

    [HttpGet("getProfessionalById/{id}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var query = new GetProfessionalByIdQuery(id);

        Result<ProfessionalResponse> response = await sender.Send(query, cancellationToken);

        return response.IsSuccess ? Ok(response.Value()) : NotFound(response.Error);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Save(CreateProfessionalCommand createProfessionalCommand, CancellationToken cancellationToken)
    {
        Result result = await sender.Send(createProfessionalCommand, cancellationToken);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return result.IsSuccess ? Ok(result.IsSuccess) : NotFound(result.Error);
    }
}
