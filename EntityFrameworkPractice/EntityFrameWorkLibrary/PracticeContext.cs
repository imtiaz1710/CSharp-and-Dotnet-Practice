using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWorkLibrary
{
    public class PracticeContext : DbContext
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public PracticeContext(string connectionString, string migrationAssemblyName)
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .HasMany(c => c.Topics)
                .WithOne(t => t.Course);

            modelBuilder.Entity<CourseStudent>()
                .HasKey(cs => new { cs.CourseId, cs.StudentId });

            modelBuilder.Entity<CourseStudent>()
                .HasOne(cs => cs.Course)
                .WithMany(c => c.EnrolledStudents)
                .HasForeignKey(cs => cs.CourseId);

            modelBuilder.Entity<CourseStudent>()
                .HasOne(cs => cs.Student)
                .WithMany(s => s.EnrolledCourses)
                .HasForeignKey(cs => cs.StudentId);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Course> courses { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<Topic> Topics { get; set; }
        //public DbSet<Account> Accounts { get; set; }

    }
}
