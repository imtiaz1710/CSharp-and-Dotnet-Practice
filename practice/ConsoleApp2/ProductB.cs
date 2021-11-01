using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice
{

    class ProductB
    {
        public int x;
        public ProductB(int x)
        {
            this.x = x;
        }
        public void DoSomething(int x)
        {
            Console.WriteLine($"ADD something from productb class::::{this.x+x} ");
        }
    }
}
