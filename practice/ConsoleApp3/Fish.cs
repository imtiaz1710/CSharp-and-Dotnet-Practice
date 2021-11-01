using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Solution
    {
        public static string ReverseWords(string s)
        {
            var input = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var str = new StringBuilder();

            for (var i = input.Length - 1; i >= 0; i--)
            {
                str.Append(input[i]);
                str.Append(' ');
            }

            str.Remove(str.Length - 1, 1);

            return str.ToString();
        }

     
    }
}
