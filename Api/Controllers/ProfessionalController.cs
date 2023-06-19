using Microsoft.AspNetCore.Mvc;
using MediatR;
using Domain.Shared;
using Infrastructure.Authentication;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Application.Features.Professional.Queries.GetAll;
using Application.Features.Professional.Queries.GetById;
using Application.Features.Professional.Commands.Create;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfessionalController : ApiController
{
    public ProfessionalController(ISender sender)
        : base(sender)
    {
    }

    [HttpGet("getById/{id}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var query = new GetProfessionalByIdQuery(id);

        Result<ProfessionalResponse> response = await sender.Send(query, cancellationToken);

        return response.IsSuccess ? Ok(response.Value()) : NotFound(response.Error);
    }

    [HttpGet("getAll/{page}/{pageSize}")]
    public async Task<IActionResult> GetAll(int page, int pageSize, CancellationToken cancellationToken)
    {
        var query = new GetAllQuery(page, pageSize);

        Result<List<ProfessionalResponse>> response = await sender.Send(query, cancellationToken);

        return response.IsSuccess ? Ok(response.Value()) : NotFound(response.Error);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Save(CreateProfessionalCommand createProfessionalCommand, CancellationToken cancellationToken)
    {
        Result result = await sender.Send(createProfessionalCommand, cancellationToken);

        if (result.IsFailure)
        {
            return HandleFailure(result);
        }

        return result.IsSuccess ? Ok(result.IsSuccess) : NotFound(result.Error);
    }
}
