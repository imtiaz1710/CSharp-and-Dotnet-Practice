using FirstDemo.Membership.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo.Membership.Seeds
{
    public static class DataSeed
    {
        public static Role[] Roles
        {
            get
            {
                return new Role[]
                {
                    new Role { Id = Guid.NewGuid(), Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = Guid.NewGuid().ToString() },
                    new Role { Id = Guid.NewGuid(), Name = "Teacher", NormalizedName = "TEACHER", ConcurrencyStamp = Guid.NewGuid().ToString() },
                    new Role { Id = Guid.NewGuid(), Name = "Student", NormalizedName = "STUDENT", ConcurrencyStamp = Guid.NewGuid().ToString() }
                };
            }
        }
    }
}
