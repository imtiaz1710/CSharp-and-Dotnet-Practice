using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ThreeTierArchPractice.Models;

namespace ThreeTierArchPractice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new CourseListModel();
            model.CourseList();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult CreateCourse()
        { 
            var model = new CreateCourseModel();
            return View(model);
        }

        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult CreateCourse(CreateCourseModel model)
        {
           if(ModelState.IsValid)
            {
                try
                {
                    model.CreateCourse();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Can't Create Course");
                }
            }
            return View(model);
        }
    }
}
