using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionPractice
{
    public class DemoClass
    {
        private string _myString;
        public DemoClass xyz(string str)
        {
            _myString = str;
            return this;
        }
    }
}
