using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeTierArchPractice.Training.Entities;

namespace ThreeTierArchPractice.Training.Contexts
{
    public class TrainingContext : DbContext , ITrainingContext
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public TrainingContext(string connectionString, string migrationAssemblyName)
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

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
