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
    public class CourseRepository : Repository<Course, TrainingContext>, ICourseRepository<TrainingContext>
    {
        public CourseRepository(TrainingContext context) : base(context)
        {
        }
    }
}
