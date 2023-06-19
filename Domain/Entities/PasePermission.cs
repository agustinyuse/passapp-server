using Domain.Shared;
using Expensely.Domain.Shared;

namespace Domain.Entities;

public class PasePermission : Enumeration<PasePermission>
{
    public static readonly PasePermission Editor = new(1, "Editor");
    public static readonly PasePermission Read = new(2, "Read");
    public static readonly PasePermission Comments = new(3, "Comments");

    public PasePermission(int id, string name) : base(id, name) { }
}
