using Domain.Errors;
using Domain.Shared;
using Domain.ValueObjects;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Entities;

public sealed class Professional : BaseEntity
{
    private readonly List<ProfessionalAddress> _professionalAddresses = new();

    public Professional(string firstName,
        string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public IReadOnlyCollection<ProfessionalAddress> Addresses => _professionalAddresses;

    public static Result<Professional> Create(string firstName,
        string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            return Result.Failure<Professional>(DomainErrors.Professional.FirstNameRequired);
        }

        if (string.IsNullOrWhiteSpace(lastName))
        {
            return Result.Failure<Professional>(DomainErrors.Professional.LastNameRequired);
        }

        var professional = new Professional(firstName,
            lastName);

        return professional;
    }

    public Result CreateProfessionalAddress(string Street,
    string number,
    string city,
    string state,
    string country,
    string? adjacentStreet1,
    string? adjacentStreet2,
    string? floor,
    string? unit,
    string? zipCode)
    {

        var address = ProfessionalAddress.Create(
            this,
            Street,
            number,
            city,
            state,
            country,
            adjacentStreet1,
            adjacentStreet2,
            floor,
            unit,
            zipCode);

        if (address.IsFailure)
        {
            return Result.Failure(address.Error); 
        }

        _professionalAddresses.Add(address.Value());

        return Result.Success();
    }
}
