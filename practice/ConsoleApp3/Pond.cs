using System;

namespace ConsoleApp3
{
    public class Pond
    {
        public int PondId { get; set; }
        public string Name { get; set; }
        private static int X = 3;

        public Pond()
        {
        }

        public void AccessStatic()
        {
            X++;
            Console.WriteLine(X);
        }
    }
}
