using RacingCompetition.Data;
using RacingCompetition.RacingData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingCompetition.RacingData.Repositories
{
    public interface IPlayerRepository : IRepository<Player, int>
    {
    }
}
