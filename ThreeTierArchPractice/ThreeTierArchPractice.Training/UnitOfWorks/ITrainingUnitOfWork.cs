using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeTierArchPractice.Data;
using ThreeTierArchPractice.Training.Contexts;
using ThreeTierArchPractice.Training.Repositores;

namespace ThreeTierArchPractice.Training.UnitOfWorks
{
    public interface ITrainingUnitOfWork : IUnitOfWork 
    {
        public ICourseRepository<TrainingContext> Courses { get; set; }
        public IStudentRepository<TrainingContext> Students { get; set; }
    }
}
