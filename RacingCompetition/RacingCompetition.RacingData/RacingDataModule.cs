using Autofac;
using RacingCompetition.RacingData.Contexts;
using RacingCompetition.RacingData.Repositories;
using RacingCompetition.RacingData.Services;
using RacingCompetition.RacingData.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingCompetition.RacingData
{
    public class RacingDataModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public RacingDataModule(string connectionStringName, string migrationAssemblyName)
        {
            _connectionString = connectionStringName;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<RacingDataContext>().AsSelf()
               .WithParameter("connectionString", _connectionString)
               .WithParameter("migrationAssemblyName", _migrationAssemblyName)
               .InstancePerLifetimeScope();

            builder.RegisterType<RacingDataContext>().As<IRacingDataContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<PlayerRepository>().As<IPlayerRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<RacingDataUnitOfWork>().As<IRacingDataUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<PlayerService>().As<IPlayerService>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
