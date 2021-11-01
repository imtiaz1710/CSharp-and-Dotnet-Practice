using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    public class House : IData
    {
        public int Id { get; set; }
        public IList<Room> Rooms { get; set; }
    }
}
