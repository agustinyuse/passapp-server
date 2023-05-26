using Domain.Entities;
using Domain.Errors;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public sealed class ProfessionalAddress : ValueObject
    {
        public ProfessionalAddress(
        int ProfessionalId,
        string Street,
        string Number,
        string City,
        string State,
        string Country,
        string? AdjacentStreet1,
        string? AdjacentStreet2,
        string? Floor,
        string? Unit,
        string? ZipCode)
        {
            this.ProfessionalId = ProfessionalId;
            this.Street = Street;
            this.Number = Number;
            this.City = City;
            this.State = State;
            this.Country = Country;
            this.AdjacentStreet1 = AdjacentStreet1;
            this.AdjacentStreet2 = AdjacentStreet2;
            this.Floor = Floor;
            this.Unit = Unit;
            this.ZipCode = ZipCode;

            PlainAdjacentStreet1 = StringHelper.CleanForSearch(this.AdjacentStreet1);
            PlainAdjacentStreet2 = StringHelper.CleanForSearch(this.AdjacentStreet2);
            PlainCity = StringHelper.CleanForSearch(this.City);
            PlainCountry = StringHelper.CleanForSearch(this.Country);
            PlainStreet = StringHelper.CleanForSearch(this.Street);
            PlainZipCode = StringHelper.CleanForSearch(this.ZipCode);
        }

        public int ProfessionalId { get; private set; }
        public string? Street { get; private set; }
        public string? PlainStreet { get; private set; }
        public string? Number { get; private set; }
        public string? Floor { get; private set; }
        public string? Unit { get; private set; }
        public string? ZipCode { get; private set; }
        public string? PlainZipCode { get; private set; }
        public string? City { get; private set; }
        public string? PlainCity { get; private set; }
        public string? State { get; private set; }
        public string? PlainState { get; private set; }
        public string? Country { get; private set; }
        public string? PlainCountry { get; private set; }
        public string? AdjacentStreet1 { get; private set; }
        public string? PlainAdjacentStreet1 { get; private set; }
        public string? AdjacentStreet2 { get; private set; }
        public string? PlainAdjacentStreet2 { get; private set; }
        public double? Lat { get; private set; }
        public double? Lng { get; private set; }

        public static Result<ProfessionalAddress> Create(
        Professional professional,
        string street,
        string number,
        string city,
        string state,
        string country,
        string? adjacentStreet1 = null,
        string? adjacentStreet2 = null,
        string? floor = null,
        string? unit = null,
        string? zipCode = null)
        {

            if (string.IsNullOrWhiteSpace(street))
            {
                return Result.Failure<ProfessionalAddress>(DomainErrors.ProfessionalAddress.StreetRequired);
            }

            if (string.IsNullOrWhiteSpace(number))
            {
                return Result.Failure<ProfessionalAddress>(DomainErrors.ProfessionalAddress.NumberRequired);
            }

            if (string.IsNullOrWhiteSpace(city))
            {
                return Result.Failure<ProfessionalAddress>(DomainErrors.ProfessionalAddress.CityRequired);
            }

            if (string.IsNullOrWhiteSpace(state))
            {
                return Result.Failure<ProfessionalAddress>(DomainErrors.ProfessionalAddress.StateRequired);
            }

            if (string.IsNullOrWhiteSpace(country))
            {
                return Result.Failure<ProfessionalAddress>(DomainErrors.ProfessionalAddress.CountryRequired);
            }

            var professionalAddress = new ProfessionalAddress(
                professional.Id,
                street,
                number,
                city,
                state,
                country,
                adjacentStreet1,
                adjacentStreet2,
                floor,
                unit,
                zipCode);

            return professionalAddress;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Street;
            yield return Number;
            yield return City;
            yield return State;
            yield return Country;
            yield return AdjacentStreet1;
            yield return AdjacentStreet2;
            yield return Floor;
            yield return Unit;
            yield return ZipCode;
            yield return Lat;
            yield return Lng;
        }
    }
}
