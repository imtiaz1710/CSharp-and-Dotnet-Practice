using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    public class DatabaseConnection
    {
        public static string getConnectionString()
        {
            String FilePath = @"G:\DevskillDotNetCourse\aspnet-b5-personal\Assignment-2\Assignment-2.1\MySettings.json";
            IConfigurationRoot configuartion = new ConfigurationBuilder().AddJsonFile(FilePath, false).Build();
            return configuartion.GetConnectionString("MyDatabaseConnection");
        }
    }
}
