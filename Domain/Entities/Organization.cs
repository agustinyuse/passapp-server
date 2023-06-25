using Domain.Shared;

namespace Domain.Entities;

public sealed class Organization : BaseEntity
{
    private Organization(string code, 
        string name)
    {
        Code = code;
        Name = name;
    }

    public string Code { get; private set; }
    public string Name { get; private set; }

    public static Organization Create(string code, 
        string name)
    {
        var Organization = new Organization(code, 
            name);

        return Organization;
    }
}
