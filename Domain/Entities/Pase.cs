using Domain.Errors;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Pase : BaseEntity
{
    private readonly ICollection<Internment> _internations;
    public Pase(string description, int organismId)
    {
        Description = description;
        OrganismId = organismId;
    }

    public string Description { get; private set; }
    public int OrganismId { get; set; }

    public ICollection<Internment> Internments => _internations;

    public static Result<Pase> Create(int organismId,
        string description)
    {
        var pase = new Pase(description,
            organismId);

        if (organismId == 0)
        {
            return Result.Failure<Pase>(DomainErrors.Pase.OrganismRequired);
        }

        if (string.IsNullOrWhiteSpace(description))
        {
            return Result.Failure<Pase>(DomainErrors.Pase.DescriptionRequired);
        }

        return pase;
    }
}
