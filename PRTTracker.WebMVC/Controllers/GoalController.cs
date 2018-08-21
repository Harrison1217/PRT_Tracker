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
    public class GoalController : Controller
    {
        // GET: Goal
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GoalServices(userId);
            var model = service.GetGoals();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Goal_Create model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateGoalServices();

            if (service.GoalCreate(model))
            {
                TempData["SaveResult"] = "Your Goal Has Been Saved.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Goal Could not be Created.");

            return View(model);

        }

        public ActionResult Details(int id)
        {
            var svc = CreateGoalServices();
            var model = svc.GetGoalById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateGoalServices();
            var detail = service.GetGoalById(id);
            var model =
                new GoalEdit
                {
                    GoalId = detail.GoalId,
                    Title = detail.Title,
                    Content = detail.Content
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GoalEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.GoalId != id)
            {
                ModelState.AddModelError("", "IdMismatch");
                return View(model);
            }

            var service = CreateGoalServices();

            if (service.UpdateGoal(model))
            {
                TempData["SaveResult"] = "Your Goal Was Updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your Goal could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateGoalServices();
            var model = svc.GetGoalById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateGoalServices();
            service.DeleteGoal(id);
            TempData["SaveResult"] = "Your Goal has been Deleted";
            return RedirectToAction("Index");
        }

        private GoalServices CreateGoalServices()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GoalServices(userId);
            return service;
        }
    }
}