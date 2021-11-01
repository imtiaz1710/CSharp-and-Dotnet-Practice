using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var FilePath = @"G:\DevskillDotNetCourse\aspnet-b5-personal\Assignment-2\Assignment-2\MySettings.json";
            var configuartion = new ConfigurationBuilder().AddJsonFile(FilePath,false).Build();

           // Console.WriteLine(configuartion.GetConnectionString("MyDatabaseConnection"));
            var myOrm = new MyORM<Room>(configuartion.GetConnectionString("MyDatabaseConnection"));

            var room = new Room() 
                { Id = 10, NumberOfSeat = 34, NextAvailableDate =new DateTime(2021,2,12) };
            myOrm.Insert(room);
            myOrm.Delete(2);
            room= new Room() { Id = 1, NumberOfSeat = 14, NextAvailableDate = new DateTime(2033, 2, 3) };
           // myOrm.Update(room);
            var Records=myOrm.GetAll();
            foreach (var record in Records)
            {
                Console.WriteLine($"Id = {record.Id}, NumberOfSeat = {record.NumberOfSeat}," +
                    $"NextAvaiableDate = {record.NextAvailableDate.ToString()}");
            }
          
        }
    }
}
