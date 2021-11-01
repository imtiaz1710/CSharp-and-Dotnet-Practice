﻿using System;
using System.Collections.Generic;

namespace EntityFrameWorkLibrary
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        //public IList<Student> Students { get; set; }
        public IList<Topic> Topics { get; set; }
        public IList<CourseStudent> EnrolledStudents { get; set; }

    }
}
