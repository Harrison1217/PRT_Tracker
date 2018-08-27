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
    public class NutritionController : Controller
    {
        // GET: Nutration
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new NutritionServices(userId);
            var model = service.GetNutritions();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NutritionCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateNutritionService();

            if (service.NutritionCreate(model))
            {
                TempData["SaveResult"] = "Your entries have been saved.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateNutritionService();
            var model = svc.GetNutritionById(id);

            return View(model);
        }

        private NutritionServices CreateNutritionService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new NutritionServices(userId);
            return service;
        }
    }
}





