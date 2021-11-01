using System;

namespace RacingCompetition.Data
{
    public interface IEntity<T>
    {
        T Id { get; set; } 
    }
}
