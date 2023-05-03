using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProfessionalAddress : AuditableBaseEntity
    {
        public int ProfessionalAddressId { get; set; }
        public int ProfessionalId { get; set; }
        public string? Street { get; set; }
        public string? PlainStreet { get; set; }
        public string? Number { get; set; }
        public string? Floor { get; set; }
        public string? Unit { get; set; }
        public string? ZipCode { get; set; }
        public string? PlainZipCode { get; set; }
        public string? City { get; set; }
        public string? PlainCity { get; set; }
        public string? State { get; set; }
        public string? PlainState { get; set; }
        public string? Country { get; set; }
        public string? PlainCountry { get; set; }
        public string? AdjacentStreet1 { get; set; }
        public string? PlainAdjacentStreet1 { get; set; }
        public string? AdjacentStreet2 { get; set; }
        public string? PlainAdjacentStreet2 { get; set; }
        public double? Lat { get; set; }
        public double? Lng { get; set; }

    }
}
