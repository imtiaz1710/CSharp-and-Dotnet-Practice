using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeTierArchPractice.Training.BusinessObjects;

namespace ThreeTierArchPractice.Training.Services
{
    public interface ICourseService
    {
        public IList<Course> GetAllCourses();
        public void CreateCourse(Course course);
    }
}
