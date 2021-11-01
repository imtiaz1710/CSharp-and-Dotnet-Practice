using Autofac;
using FirstDemo.Areas.Admin.Models;
using FirstDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstDemo
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SimpleDatabaseService>().As<IDatabaseService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CourseListModel>().AsSelf();

            base.Load(builder);
        }
    }
}
