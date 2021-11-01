using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionPractice
{
    public static class AddMethod
    {
        public static string FunnyString(this string me,string str)
        {
            return str+"! haha";
        }
    }
}
