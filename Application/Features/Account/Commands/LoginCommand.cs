using Application.Abstractions.Messaging;

namespace Application.Features.Account.Commands;

public record LoginCommand(string Email, string Password) : ICommand<string>;
