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
[HasPermission(Permission.AccessProfessional)]
public class ProfessionalController : ApiController
{
    public ProfessionalController(ISender sender)
        : base(sender)
    {
    }

    [HasPermission(Permission.ReadProfessional)]
    [HttpGet("getById/{id}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var query = new GetProfessionalByIdQuery(id);

        Result<ProfessionalResponse> response = await sender.Send(query, cancellationToken);

        return response.IsSuccess ? Ok(response.Value()) : NotFound(response.Error);
    }

    [HasPermission(Permission.ReadProfessional)]
    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var query = new GetAllQuery();

        Result<List<ProfessionalResponse>> response = await sender.Send(query, cancellationToken);

        return response.IsSuccess ? Ok(response.Value()) : NotFound(response.Error);
    }

    [HasPermission(Permission.AddProfessional)]
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
