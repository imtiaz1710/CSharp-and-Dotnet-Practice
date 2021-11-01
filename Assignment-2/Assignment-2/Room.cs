using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    public class Room : IData
    {
        public int Id { get; set; }
        public int NumberOfSeat { get; set; }
        public DateTime NextAvailableDate { get; set; }
    }
}
