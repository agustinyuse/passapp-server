using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public sealed class User
    {
        public int UserId { get; set; }

        public ICollection<Role> Roles { get; set; }
    }
}
