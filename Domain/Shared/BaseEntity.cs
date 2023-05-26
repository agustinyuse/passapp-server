using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shared
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int CreatedUserId { get; set; }
        public int? UpdatedUserId { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
