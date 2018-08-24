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

/* TODO: Maybe add like an input box for people to contact you as well*/
/* TODO: Maybe add list/grid views for your index like Paul had.*/
/* Your background picture is cool - it really brightens up the entire site*/
/* The pictures under the table links are really cool!*/
/* Your code is very clean */
/* TODO: Maybe add edit/delete to your tables in case someone has a typo or they no longer need the data.*/
/* This app could really be useful outside of just navy as well.Version 2.0 could include just basic workout goals or even
    other branches of the military to track PT goals*/