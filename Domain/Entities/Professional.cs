using Domain.Errors;
using Domain.Shared;
using Domain.ValueObjects;

namespace Domain.Entities;

public sealed class Professional : BaseEntity
{
    private readonly List<ProfessionalAddress> _professionalAddresses = new();

    private Professional(string firstName,
        string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public int OrganizationId { get; set; }

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

    public Result CreateProfessionalAddress(string address,
    string city,
    string state,
    string country,
    string? zipCode)
    {

        var addressCreated = ProfessionalAddress.Create(
            this,
            address,
            city,
            state,
            country,
            zipCode);

        if (addressCreated.IsFailure)
        {
            return Result.Failure(addressCreated.Error);
        }

        _professionalAddresses.Add(addressCreated.Value());

        return Result.Success();
    }
}
