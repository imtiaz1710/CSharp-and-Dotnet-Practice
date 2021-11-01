using Autofac;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RacingCompetition.Areas.Admin.Models;
using RacingCompetition.Models;
using System;

namespace RacingCompetition.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PlayerController : Controller
    {
        private readonly ILogger<PlayerController> _logger;

        public PlayerController(ILogger<PlayerController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("\nFrom Index in Controller\n");
            //var model = new PlayerListModel();
            var model = Startup.AutofacContainer.Resolve<PlayerListModel>();
            return View(model);
        }

        public JsonResult GetPlayerData()
        {
            var dataTablesModel = new DataTablesAjaxRequestModel(Request);
            var model = new PlayerListModel();
            var data = model.GetPlayers(dataTablesModel);
            return Json(data);
        }

        public IActionResult Create()
        {
            var model = new CreatePlayerModel();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(CreatePlayerModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    throw new Exception();
                    model.CreatePlayer();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Failed to create player");
                    _logger.LogError(ex, "Create Player Failed!");
                }
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var model = new EditPlayerModel();
            model.LoadModelData(id);

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(EditPlayerModel model)
        {
            if (ModelState.IsValid)
            {
                model.Update();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var model = new PlayerListModel();
            model.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
