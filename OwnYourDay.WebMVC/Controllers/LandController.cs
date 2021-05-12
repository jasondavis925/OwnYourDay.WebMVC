using Microsoft.AspNet.Identity;
using OwnYourDay.Models;
using OwnYourDay.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OwnYourDay.WebMVC.Controllers
{
    [Authorize]
    public class LandController : Controller
    {
        // GET: Land
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LandService(userId);
            var model = service.GetLands();
            //var model = new LandListView[0];
            return View(model);
        }

        // GET: Create View
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LandCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateLandService();

            if (service.CreateLand(model))
            {
                TempData["SaveResult"] = "Your Land was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Land could not be created.");
            return View(model);
        }

        private LandService CreateLandService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LandService(userId);
            return service;
        }

        public ActionResult Edit(int id)
        {
            var service = CreateLandService();
            var detail = service.GetLandById(id);
            var model =
                new LandEdit
                {
                    LandId = detail.LandId,
                    PropertyDescription = detail.PropertyDescription,
                    Location = detail.Location,
                    Activities = detail.Activities,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LandEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.LandId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateLandService();

            if (service.UpdateLand(model))
            {
                TempData["SaveResult"] = "Your Land was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Land could not be updated.");
            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateLandService();
            var model = svc.GetLandById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateLandService();

            service.DeleteLand(id);

            TempData["SaveResult"] = "Your Land was deleted";

            return RedirectToAction("Index");
        }
    }
}