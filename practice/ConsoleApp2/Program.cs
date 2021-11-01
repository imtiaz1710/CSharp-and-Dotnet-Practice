using System;
using System.Collections.Generic;
using practice;

namespace ConsoleApp2
{
    class Program
    {
        
        static void Main(string[] args)
        {
            /*Func<int, int, int> func = (x, y) => x + y;
            var z=func.Invoke(2,4);
            Console.WriteLine(z);*/
           
            var x = CreateCollectionWithYield();
            var y = CreateCollectionWithList();

            var zz = y.GetEnumerator();
            while (zz.MoveNext())
            {
                var ll = zz.Current;
            }

            var z=x.GetEnumerator();
            while(z.MoveNext())
            {
                var l=z.Current;
            }
        }
        public static IEnumerable<int> CreateCollectionWithList()
        {
            var list = new List<int>();
            list.Add(10);
            list.Add(0);
            list.Add(1);
            list.Add(2);
            list.Add(20);

            return list;
        }
        public static IEnumerable<int> CreateCollectionWithYield()
        {
            yield return 10;
            for (int i = 0; i < 3; i++)
            {
                yield return i;
            }

            yield return 20;
        }
        /* public static void abc(Func<ProductA,ProductB> x)
         {
             var a = new ProductA(4);
             var b = new ProductB(29);
             x(a);
         }*/
    }
}
