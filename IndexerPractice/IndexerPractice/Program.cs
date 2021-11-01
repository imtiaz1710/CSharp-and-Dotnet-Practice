using System;

namespace IndexerPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            var indexerClass = new IndexerClass();
            indexerClass[0] = 3;
            Console.WriteLine(indexerClass[0]);

            var demo = new DemoClass();
            Console.WriteLine(demo[1]);
            demo[1] = "imtiaz";
            Console.WriteLine(demo[1]);

            var demo1 = new DemoClass[34];
            demo1[2] = new DemoClass();
            demo1[2][2] = "dkfas";
        }
    }
}
