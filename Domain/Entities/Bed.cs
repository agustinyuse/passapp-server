using Domain.Shared;

namespace Domain.Entities;

public class Bed: BaseEntity
{
    public string Code { get; private set; }
    public string Description { get; private set; }
}
