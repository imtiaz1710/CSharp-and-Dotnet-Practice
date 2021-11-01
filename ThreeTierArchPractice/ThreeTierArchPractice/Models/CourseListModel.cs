using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThreeTierArchPractice.Training.BusinessObjects;
using ThreeTierArchPractice.Training.Services;

namespace ThreeTierArchPractice.Models
{
    public class CourseListModel
    {
        private ICourseService _courseService;
        public IList<Course> Courses { get; private set; }
        public CourseListModel()
        {
            _courseService = Startup.AutofacContainer.Resolve<ICourseService>();
        }
        public CourseListModel(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public void CourseList()
        {
            Courses = _courseService.GetAllCourses();
        }

    }
}
