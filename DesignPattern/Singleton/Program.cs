using System;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj1 = Logger.GetInstance();
            obj1.UpdateChecker();

            Console.WriteLine(obj1.Checker);

            var obj2 = Logger.GetInstance();

            Console.WriteLine(obj2.Checker);
        }
    }
}
