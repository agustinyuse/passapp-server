using Application.Abstractions.Messaging;

namespace Application.Features.User.Commands;

public record LoginCommand(string Email, string Password): ICommand<string>;
