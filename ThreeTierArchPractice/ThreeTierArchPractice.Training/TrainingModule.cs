using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeTierArchPractice.Data;
using ThreeTierArchPractice.Training.Contexts;
using ThreeTierArchPractice.Training.Repositores;
using ThreeTierArchPractice.Training.Services;
using ThreeTierArchPractice.Training.UnitOfWorks;

namespace ThreeTierArchPractice.Training
{
    public class TrainingModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public TrainingModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TrainingContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<TrainingContext>().As<ITrainingContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<CourseRepository>().As<ICourseRepository<TrainingContext>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<StudentRepository>().As<IStudentRepository<TrainingContext>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<TrainingUnitOfWork>().As<ITrainingUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CourseService>().As<ICourseService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }

    }
}
