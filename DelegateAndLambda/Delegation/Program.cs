using System;

namespace DelegateAndLambda
{
    class Program
    {
        public delegate int Addval(int x, int y);
        public delegate T Combine<T>(T x, T y);

        static void Main(string[] args)
        {
            Combine<int> f = Add;

            TestAndCalculate(2, 2, f);
            TestAndCalculate(2, 3, Subtract);
            TestAndCalculate(2, 3, delegate(int x, int y) { return x + y; });
            TestAndCalculate(2, 3, (int x, int y) => { return x + y; });
            TestAndCalculate(2, 3, (x, y) => x + y);
        }

        public static int Add(int x, int y)
        {
            return x + y;
        }

        public static int Subtract(int x, int y)
        {
            return x - y;
        }

        public static void TestAndCalculate<T>(T x, T y, Combine<T> z)
        {
            Console.WriteLine(z(x, y));
        }
    }
}
