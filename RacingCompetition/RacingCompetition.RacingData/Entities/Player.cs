using RacingCompetition.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingCompetition.RacingData.Entities
{
    public class Player : IEntity<int>
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
    }
}
