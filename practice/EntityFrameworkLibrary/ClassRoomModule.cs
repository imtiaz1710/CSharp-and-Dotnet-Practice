using System;
using Autofac;
using EntityFrameworkLibrary.contexts;
using EntityFrameworkLibrary.Services;
using Microsoft.EntityFrameworkCore.SqlServer;


namespace EntityFrameworkLibrary
{
    public class ClassRoomModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public ClassRoomModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ClassRoomDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();
            builder.RegisterType<ChairService>().As<IChairService>();

            base.Load(builder);
        }
    }
}
