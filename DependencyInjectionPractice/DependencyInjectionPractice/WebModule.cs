using Autofac;
using DependencyInjectionConsole;
using DependencyInjectionPractice.Models.AccountManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionPractice
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EmailService>().As<IEmailService>().InstancePerLifetimeScope();
            builder.RegisterType<DriverService>().As<IDriverService>().InstancePerLifetimeScope();
            base.Load(builder);
        }
    } 
}
