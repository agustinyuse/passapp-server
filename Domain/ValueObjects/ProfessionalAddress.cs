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
        int professionalId,
        string address,
        string city,
        string state,
        string country,
        string? zipCode)
        {
            this.ProfessionalId = professionalId;
            this.City = city;
            this.State = state;
            this.Country = country;
            this.ZipCode = zipCode;
            this.Address = address;

            PlainAddress = StringHelper.CleanForSearch(this.Address);
            PlainCity = StringHelper.CleanForSearch(this.City);
            PlainCountry = StringHelper.CleanForSearch(this.Country);
            PlainZipCode = StringHelper.CleanForSearch(this.ZipCode);
        }

        public int ProfessionalId { get; private set; }
        public string Address { get; set; }
        public string PlainAddress { get; set; }
        public string State { get; set; }
        public string PlainState { get; set; }
        public string City { get; set; }
        public string PlainCity { get; set; }
        public string? ZipCode { get; set; }
        public string PlainZipCode { get; set; }
        public string Country { get; set; }
        public string PlainCountry { get; set; }
        public double? Lat { get; private set; }
        public double? Lng { get; private set; }

        public static Result<ProfessionalAddress> Create(
        Professional professional,
        string address,
        string city,
        string state,
        string country,
        string? zipCode = null)
        {

            if (string.IsNullOrWhiteSpace(address))
            {
                return Result.Failure<ProfessionalAddress>(DomainErrors.ProfessionalAddress.StreetRequired);
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
                address,
                city,
                state,
                country,
                zipCode);

            return professionalAddress;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return City;
            yield return State;
            yield return Country;
            yield return ZipCode;
            yield return Address;
            yield return Lat;
            yield return Lng;
        }
    }
}
