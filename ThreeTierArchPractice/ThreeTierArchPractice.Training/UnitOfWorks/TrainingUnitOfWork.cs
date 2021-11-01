using Microsoft.EntityFrameworkCore;
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
    public class TrainingUnitOfWork : UnitOfWork , ITrainingUnitOfWork
    {
        public  ICourseRepository<TrainingContext> Courses { get; set; }
        public  IStudentRepository<TrainingContext> Students { get; set; }

        public TrainingUnitOfWork(TrainingContext context , ICourseRepository<TrainingContext> courseRepository , 
            IStudentRepository<TrainingContext> studentRepository) : base((DbContext)context)
        {
            Courses = courseRepository;
            Students = studentRepository;
        }
    }
}
