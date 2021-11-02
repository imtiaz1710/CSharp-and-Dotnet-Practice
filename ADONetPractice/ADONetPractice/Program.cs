using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace ADONetPractice
{
    class Program
    {
        private const string connectionString= 
            "Server=DESKTOP-JO34CC1\\SQLEXPRESS;Database=Practice;User Id=demo;Password=123456;";

        static void Main(string[] args)
        {
            var connection = new SqlConnection(connectionString);
            InsertOperationRun();
        }

        public static void InsertOperationRun()
        {
            Console.WriteLine("Insert the number of rows you want to insert in table: ");
            int numberOfRows = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfRows; i++)
            {
                Console.WriteLine("Insert Name and age in separate line:");
                var insert = "insert into student([name],[age]) values(@name , @age)";
                var name = Console.ReadLine();
                var age = int.Parse(Console.ReadLine());
                var connection = new SqlConnection(connectionString);

                InsertExecution(insert, connection, new Dictionary<string, object>
                {
                    { "@name",name },
                    {"@age",age }
                });
            }
        }

        public static void InsertExecution(string insert,SqlConnection connection,
            IDictionary<string,object> keyValuePairs)
        {
            connection.Open();
            SqlCommand command = new SqlCommand(insert, connection);
            foreach (var item in keyValuePairs)
            {
                command.Parameters.AddWithValue(item.Key, item.Value);
            }

            command.ExecuteNonQuery();
            connection.Close();
            command.Dispose();
            connection.Dispose();
        }
    }
}

  
