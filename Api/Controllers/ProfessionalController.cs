using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Features.Professional.Queries;
using Domain.Shared;

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
}
