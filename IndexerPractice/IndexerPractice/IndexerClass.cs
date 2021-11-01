using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexerPractice
{
    class IndexerClass
    {
        private int[] indexValue = new int[199];
        public int this[int i]
        {
            get { return indexValue[i]; }  //here we should apply our conditon for i ; I use 0 for avoid complexity 
            set { indexValue[0] = value; }
        }
    }
}
