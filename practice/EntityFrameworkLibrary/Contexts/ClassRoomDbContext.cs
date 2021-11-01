using EntityFrameworkLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkLibrary.contexts
{
    public class ClassRoomDbContext : DbContext
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public ClassRoomDbContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(
                    _connectionString,
                    m => m.MigrationsAssembly(_migrationAssemblyName));
            }

            base.OnConfiguring(dbContextOptionsBuilder);
        }

        public DbSet<Clock> Clocks { get; set; }
        public DbSet<Chair> Chairs { get; set; }
    }
}
