using RacingCompetition.Data;
using RacingCompetition.RacingData.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingCompetition.RacingData.UnitOfWorks
{
    public interface IRacingDataUnitOfWork : IUnitOfWork
    {
        IPlayerRepository Players { get; }
    }
}
