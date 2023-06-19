namespace Application.Abstractions;

public interface IUserProvider
{
    int? GetCurrentUserId();
}
