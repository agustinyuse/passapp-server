using FluentValidation;

namespace Application.Features.Pase.Commands;

internal class CreateCommandValidator : AbstractValidator<CreateCommand>
{
    public CreateCommandValidator()
    {
        RuleFor(x => x.OrganizationId).NotEmpty().WithMessage("Organization is required");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
        RuleForEach(x => x.Users).SetValidator(new PaseUserPasePermissionValidator());
    }
}

internal class PaseUserPasePermissionValidator : AbstractValidator<PaseUserPermissionRequestDto>
{
    public PaseUserPasePermissionValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
        RuleFor(x => x.PasePermissionId).NotEmpty().WithMessage("Permission is required");
    }
}

