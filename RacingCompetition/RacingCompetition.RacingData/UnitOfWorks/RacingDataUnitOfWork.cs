using Microsoft.EntityFrameworkCore;
using RacingCompetition.Data;
using RacingCompetition.RacingData.Contexts;
using RacingCompetition.RacingData.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingCompetition.RacingData.UnitOfWorks
{
    public class RacingDataUnitOfWork : UnitOfWork, IRacingDataUnitOfWork
    {
        public IPlayerRepository Players { get; private set; }

        public RacingDataUnitOfWork(IRacingDataContext context, IPlayerRepository players) : 
            base((DbContext)context)
        {
            Players = players;
        }
    }
}
