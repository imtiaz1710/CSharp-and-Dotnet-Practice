using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    public class Email : ICloneable
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string To { get; set; }
        public string From { get; set; }

        public object Clone()
        {
            return Copy();
        }

        public Email Copy()
        {
            return new Email
            {
                Subject = Subject,
                Body = Body,
                To = To,
                From = From
            };
        }
    }
}
