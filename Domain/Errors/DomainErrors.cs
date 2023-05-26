using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Errors;

public static class DomainErrors
{
    public static class Professional
    {
        public static readonly Error FirstNameRequired = new(
         "FirstName.Required",
         "First name is required");

        public static readonly Error LastNameRequired = new(
           "LastName.Required",
           "Last name is required");
    }

    public static class ProfessionalAddress
    {
        public static readonly Error StreetRequired = new(
         "Street.Required",
         "Street is required");

        public static readonly Error NumberRequired = new(
           "Number.Required",
           "Number is required");

        public static readonly Error CityRequired = new(
            "City.Required",
            "City is required");

        public static readonly Error StateRequired = new(
            "State.Required",
            "State is required");

        public static readonly Error CountryRequired = new(
            "Country.Required",
            "Country is required");
    }
}
