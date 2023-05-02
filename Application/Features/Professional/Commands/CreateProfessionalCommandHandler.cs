using Application.Abstractions.Messaging;
using Domain.Shared;
using MediatR;

namespace Application.Features.Professional.Commands;

internal sealed class CreateProfessionalCommandHandler : ICommandHandler<CreateProfessionalCommand>
{
    public Task<Result> Handle(CreateProfessionalCommand request, CancellationToken cancellationToken)
    {
        //TODO: Se invoca al repositorio o servicio para guardar el Professional
        throw new NotImplementedException();
    }
}
