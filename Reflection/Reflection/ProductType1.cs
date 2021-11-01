using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    class ProductType1
    {
        public void InitMehtod()
        {
            Console.WriteLine("hello from ProductType1");
        }

        private void DemoPrivate()
        {
            Console.WriteLine("Hello from a private method");
        }
    }
}
