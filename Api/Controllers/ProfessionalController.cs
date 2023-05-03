using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Features.Professional.Queries;
using Domain.Shared;
using Application.Features.Professional.Commands;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfessionalController : ControllerBase
{
    private readonly ISender sender;
    public ProfessionalController(ISender sender)
    {
        this.sender = sender;
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
        Result response = await sender.Send(createProfessionalCommand, cancellationToken);

        return response.IsSuccess ? Ok(response.IsSuccess) : NotFound(response.Error);
    }
}
