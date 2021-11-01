using Autofac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationPractice
{
    public class WebModule : Module
    {
        public WebModule(string connectionString,string migrationAssemblyName)
        {

        }
    }
}
