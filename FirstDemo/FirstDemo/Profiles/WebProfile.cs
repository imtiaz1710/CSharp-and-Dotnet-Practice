using AutoMapper;
using FirstDemo.Areas.Admin.Models;
using FirstDemo.Training.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstDemo.Profiles
{
    public class WebProfile : Profile
    {
        public WebProfile()
        {
            CreateMap<CreateCourseModel, Course>().ReverseMap();
            CreateMap<EditCourseModel, Course>().ReverseMap();
        }
    }
}
