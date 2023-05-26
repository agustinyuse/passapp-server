using Application.Behaviors;
using Application.Features.Professional.Commands;
using Application.Features.Professional.Commands.Create;
using Domain.Shared;
using FluentAssertions;
using FluentValidation;
using MediatR;
using Moq;

namespace Test.Professional.Commands;

public class CreateProfessionalCommandHandlerTests : TestBase
{
    [Fact]
    public async Task Handle_Should_ReturnFailureResult_WhenProfessionalPropsIsNotValid()
    {
        //Arrange
        CreateProfessionalCommand createProfessionalCommand =
            new CreateProfessionalCommand(
                "Agustin",
                null);
        var nextHandlerMock = new Mock<RequestHandlerDelegate<Result>>();

        var validators = new IValidator<CreateProfessionalCommand>[] { new CreateProfessionalCommandValidator() };
        var behavior = new ValidationPipelineBehavior<CreateProfessionalCommand, Result>(validators);

        //Act
        Result result = await behavior.Handle(createProfessionalCommand, () => nextHandlerMock.Object(), default);

        //Assert
        result.IsFailure.Should().BeTrue();
    }
}
