using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class UWaterDbContext : DbContext
    {
        public UWaterDbContext() : base("Server=DESKTOP-JO34CC1\\SQLEXPRESS;Database=EF6;Trusted_Connection=True;")
        {

        }
       // public DbSet<Fish> Fishes { get; set; }
        public DbSet<Pond> ponds { get; set; }
    }
}
