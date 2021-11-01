using Microsoft.EntityFrameworkCore;
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
    public class StudentRepository : Repository<Student, TrainingContext>, IStudentRepository<TrainingContext>
    {
        public StudentRepository(TrainingContext context) : base(context)
        {
        }
    }
}
