using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeTierArchPractice.Training.BusinessObjects;
using ThreeTierArchPractice.Training.UnitOfWorks;

namespace ThreeTierArchPractice.Training.Services
{
    public class CourseService : ICourseService
    {
        private readonly ITrainingUnitOfWork _trainingUnitOfWork;

        public CourseService(ITrainingUnitOfWork trainingUnitOfWork)
        {
            _trainingUnitOfWork = trainingUnitOfWork;
        }

        public void CreateCourse(Course course)
        {
            _trainingUnitOfWork.Courses.Add(new Entities.Course {
                Title=course.Title,
                Fees=course.Fees
            });
            _trainingUnitOfWork.Save();
        }

        public IList<Course> GetAllCourses()
        {
            var courseEntities =_trainingUnitOfWork.Courses.GetAll();
            var courses = new List<Course>();

            foreach (var item in courseEntities)
            {
                courses.Add(new Course()
                {
                    Id = item.Id,
                    Title = item.Title,
                    Fees = item.Fees
                });
            }

            return courses;
        }
    }
}
