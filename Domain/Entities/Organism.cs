using Domain.Shared;

namespace Domain.Entities;

public class Organism : BaseEntity
{
    public Organism(string code, 
        string name)
    {
        Code = code;
        Name = name;
    }

    public string Code { get; private set; }
    public string Name { get; private set; }

    public static Organism Create(string code, 
        string name)
    {
        var organism = new Organism(code, 
            name);

        return organism;
    }
}
