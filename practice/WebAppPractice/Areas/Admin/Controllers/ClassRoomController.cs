using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppPractice.Areas.Admin.Models;

namespace WebAppPractice.Areas.Admin.Controllers
{
    public class ClassRoomController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            var model = new ChairListModel();
            model.GetChairModel();
            return View(model);
        }
    }
}
