using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexerPractice
{
    public class DemoClass
    {
        readonly string[] _nameList = { "AKhil", "Bob", "Shawn", "Sandra" };

        public string this[int indexerValue]
        {
            get
            {
                return _nameList[indexerValue];
            }
            set
            {
                _nameList[indexerValue] = value;
            }
        }
    }
}
