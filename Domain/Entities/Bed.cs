using Domain.Shared;

namespace Domain.Entities;

public sealed class Bed: BaseEntity
{
    public string Code { get; private set; }
    public string Name { get; private set; }
}
