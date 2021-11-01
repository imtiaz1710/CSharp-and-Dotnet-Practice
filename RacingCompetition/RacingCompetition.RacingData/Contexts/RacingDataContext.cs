using Microsoft.EntityFrameworkCore;
using RacingCompetition.RacingData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingCompetition.RacingData.Contexts
{
    public class RacingDataContext : DbContext, IRacingDataContext
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public RacingDataContext(string connectionString, string migrationAssemblyName)
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

        public DbSet<Player> Players { get; set; }
    }
}
