using System;
using System.IO;
using System.Reflection;
using System.Threading;

namespace practice
{
    class Program
    {

        public  delegate void Notify();
        public event Notify Notification;


        static void Main(string[] args)
        {

            /*
            var path = @"D:\DevskillDotNetCourse\aspnet-b5-personal\practice\practice\ConfigFile.txt";
            var initClass = 
                File.ReadAllText(path).Split('=')[1].Trim();
            var types = Assembly.GetExecutingAssembly().GetTypes();
            foreach (var type in types)
            {
                if(type.Name==initClass)
                {
                    var constructor = type.GetConstructor(new Type[] { typeof(int) });
                    var instance = constructor.Invoke(new Object[] { 3 });

    *//*                var method = type.GetMethod("DoSomething");
                    method.Invoke(instance, new object[] { 3 });
                }
            }*//*

            var instance = new Program();
            var thread1 = new Thread(instance.DoCount);
            var thread2 = new Thread(instance.DoCount);

            thread1.Start();
            thread2.Start();*/
            var instance = new Program();
            instance.Notification += DoCount;
            instance.Notification += DoCount;
            instance.Notification();
            var x =new Notify(DoCount);
            x();
        }

        public static void DoCount()
        {
                for (int i = 0; i < 50; i++)
                {
                    Console.WriteLine(i);
                    Thread.Sleep(100);
                }
        }
    }
}
