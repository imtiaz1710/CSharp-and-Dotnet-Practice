using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThreeTierArchPractice.Training.BusinessObjects;
using ThreeTierArchPractice.Training.Services;

namespace ThreeTierArchPractice.Models
{
    public class CreateCourseModel
    {
        /*public string Title { get; set; }
        public int Fees { get; set; }*/
        //private const int capacity = 5;
        public List<Course> CourseList { get; set; }
        //public Course[] CourseList = new Course[capacity];

        private readonly ICourseService _courseService;

        public CreateCourseModel(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public CreateCourseModel()
        {
            _courseService = Startup.AutofacContainer.Resolve<ICourseService>();   
        }

        public void CreateCourse()
        {
            foreach (var item in CourseList)
            {
                var course = new Course
                {
                    Fees = item.Fees,
                    Title = item.Title
                };
                _courseService.CreateCourse(course);
            } 
        }
    }
}
