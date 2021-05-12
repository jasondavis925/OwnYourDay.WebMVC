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
    public class WaterCraftController : Controller
    {
        // GET: WaterCraft
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new WaterCraftService(userId);
            var model = service.GetWaterCrafts();
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
        public ActionResult Create(WaterCraftCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            WaterCraftService service = CreateWaterCraftService();

            if (service.CreateWaterCraft(model))
            {
                TempData["SaveResult"] = "Your AirCraft was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "AirCraft could not be created.");
            return View(model);
        }

        private WaterCraftService CreateWaterCraftService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new WaterCraftService(userId);
            return service;
        }

        public ActionResult Edit(int id)
        {
            var service = CreateWaterCraftService();
            var detail = service.GetWaterCraftById(id);
            var model =
                new WaterCraftEdit
                {
                    WaterCraftId = detail.WaterCraftId,
                    OccupancyCount = detail.OccupancyCount,
                    VehicleMake = detail.VehicleMake,
                    VehicleModel = detail.VehicleModel,
                    Captain = detail.Captain,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, WaterCraftEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.WaterCraftId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateWaterCraftService();

            if (service.UpdateWaterCraft(model))
            {
                TempData["SaveResult"] = "Your WaterCraft was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your WaterCraft could not be updated.");
            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateWaterCraftService();
            var model = svc.GetWaterCraftById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateWaterCraftService();

            service.DeleteWaterCraft(id);

            TempData["SaveResult"] = "Your AirCraft was deleted";

            return RedirectToAction("Index");
        }
    }
}