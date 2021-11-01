using Autofac;
using RacingCompetition.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RacingCompetition
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PlayerListModel>().AsSelf();

            base.Load(builder);
        }
    }
}
