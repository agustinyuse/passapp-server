namespace Application.Abstractions;

public interface IUserProvider
{
    Task<int> GetCurrentUserId();
}
