using Application.Abstractions.Data;
using Application.Features.Professional.Commands;
using Domain.Shared;
using FluentAssertions;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Professional.Commands
{
    public class CreateProfessionalCommandHandlerTests
    {
   

        [Fact]
        public async Task Handle_Should_ReturnFailureResult_WhenProfessionalPropsIsNotValid()
        {
            ////Arrange
            //var command = new CreateProfessionalCommand("Agustin", null, null, null, null, null, null, null, null, null, null, null);
            //var handler = new CreateProfessionalCommandHandler(serviceProvider.GetService<IApplicationDbContext>());

            ////Act
            //Result result = await handler.Handle(command, default);

            ////Assert
            //result.IsFailure.Should().BeTrue();
        }
    }
}
