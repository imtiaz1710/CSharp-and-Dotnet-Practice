using Microsoft.EntityFrameworkCore;
using RacingCompetition.Data;
using RacingCompetition.RacingData.Contexts;
using RacingCompetition.RacingData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingCompetition.RacingData.Repositories
{
    public class PlayerRepository : Repository<Player, int>, IPlayerRepository
    {
        public PlayerRepository(IRacingDataContext context) : 
            base((DbContext)context)
        {
        }
    }
}
