using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var myOrm = new MyORM<House>(DatabaseConnection.getConnectionString());
            /*Console.WriteLine(Assembly.GetExecutingAssembly().FullName);
            Console.WriteLine(typeof(int).Assembly.FullName);*/
            //var AllData=myOrm.GetAll();
            //myOrm.Delete(1);
            var house = new House()
            {
                Id = 1,
                Rooms = new List<Room>()
                {
                     new Room()
                     {
                         Id=1,
                         Rent=1000,
                         HouseId=1,
                         Roof=new Roof()
                         {
                             Id=1,
                             Length=100,
                             Width=200

                         },
                         Windows=new List<Window>()
                         {
                             new Window()
                             {
                                Id=1,
                                Color="DeepYellow",
                                RoomId=1
                             },
                             new Window()
                             {
                                Id=2,
                                Color="liteBlack",
                                RoomId=1
                             }
                         }
                     }
                 }
            };
            /* myOrm.Insert(house);
             myOrm.Update(house);*/
             //myOrm.Delete(house);
        }
    }
}
