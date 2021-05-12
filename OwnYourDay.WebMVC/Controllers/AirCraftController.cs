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
    public class AirCraftController : Controller
    {
        // GET: AirCraft View
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AirCraftService(userId);
            var model = service.GetAirCrafts();
            //var model = new PersonListView[0];
            return View(model);
        }

        // GET: Create View
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AirCraftCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateAirCraftService();
            //var service = CreateAirCraftService();

            if (service.CreateAirCraft(model))
            {
                TempData["SaveResult"] = "Your AirCraft was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "AirCraft could not be created.");
            return View(model);
        }

        private AirCraftService CreateAirCraftService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AirCraftService(userId);
            //var service = CreateAirCraftService();
            return service;
        }

        public ActionResult Edit(int id)
        {
            var service = CreateAirCraftService();
            var detail = service.GetAirCraftById(id);
            var model =
                new AirCraftEdit
                {
                    AirCraftId = detail.AirCraftId,
                    OccupancyCount = detail.OccupancyCount,
                    VehicleMake = detail.VehicleMake,
                    VehicleModel = detail.VehicleModel,
                    Pilot = detail.Pilot,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AirCraftEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.AirCraftId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateAirCraftService();

            if (service.UpdateAirCraft(model))
            {
                TempData["SaveResult"] = "Your AirCraft was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your AirCraft could not be updated.");
            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateAirCraftService();
            var model = svc.GetAirCraftById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateAirCraftService();

            service.DeleteAirCraft(id);

            TempData["SaveResult"] = "Your AirCraft was deleted";

            return RedirectToAction("Index");
        }
    }
}