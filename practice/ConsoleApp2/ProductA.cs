using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice
{
    class ProductA
    {
        public int x;
        public ProductA(int x)
        {
            this.x = x;
        }
        public void DoSomething(int x)
        {
            Console.WriteLine($"Add something from producta class:::::{this.x+x}");
        }
    }
}
