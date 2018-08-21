using Microsoft.AspNet.Identity;
using PRT.Model;
using PRT.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PRTTracker.WebMVC.Controllers
{
    [Authorize]
    public class PrtScoresController : Controller
    {
        // GET: PrtScores
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PrtScoresServices(userId);
            var model = service.GetPrtScores();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PrtScoresCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreatePrtScoresServices();

            if (service.PrtCreate(model))
            {
                TempData["SaveResult"] = "Your PRT Scores Have Been saved.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Could not Save PRT Data.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreatePrtScoresServices();
            var model = svc.GetPrtById(id);

            return View(model);
        }

        private PrtScoresServices CreatePrtScoresServices()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PrtScoresServices(userId);
            return service;
        }
    }
}