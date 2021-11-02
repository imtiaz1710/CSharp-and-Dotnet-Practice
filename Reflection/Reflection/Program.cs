using System;
using System.IO;
using System.Reflection;


namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            var configText = File.ReadAllText(@"G:\DevskillDotNetCourse\aspnet-b5-personal\Reflection\Reflection\configtxt.txt");
            var initClassName = configText.Split('=')[1].Trim();

            foreach (var type in types)
            {
                if(type.Name == initClassName)
                {
                    var constructor = type.GetConstructor(new Type[0]);
                    var instance = constructor.Invoke(new Type[0]);

                    MethodInfo method = type.GetMethod("InitMehtod");
                    method.Invoke(instance, new object[0]);
                    method = type.GetMethod("DemoPrivate", BindingFlags.NonPublic | BindingFlags.Instance);
                    method.Invoke(instance, new object[0]);
                }
            }
        }
    }
}
