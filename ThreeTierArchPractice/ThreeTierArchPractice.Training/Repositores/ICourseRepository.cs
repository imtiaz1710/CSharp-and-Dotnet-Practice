using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeTierArchPractice.Data;
using ThreeTierArchPractice.Training.Contexts;
using ThreeTierArchPractice.Training.Entities;

namespace ThreeTierArchPractice.Training.Repositores
{
    public interface ICourseRepository<TContext> : IRepository<Course , TContext>
    {
    }
}
