using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo.Training
{
    public class DerivedDemo : BaseDemo
    {
        public DerivedDemo(string value) : base(value)
        {
        }
        public void print()
        {
            Console.WriteLine("ki print krbo?");
        }
    }
}
