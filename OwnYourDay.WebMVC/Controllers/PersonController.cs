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
    public class PersonController : Controller
    {
        // GET: Person View
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PersonService(userId);
            var model = service.GetPersons();
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
        public ActionResult Create(PersonCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreatePersonService();

            if (service.CreatePerson(model))
            {
                TempData["SaveResult"] = "Your Person was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Person could not be created.");
            return View(model);

        }

        private PersonService CreatePersonService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PersonService(userId);

            return service;
        }

        public ActionResult Edit(int id)
        {
            var service = CreatePersonService();
            var detail = service.GetPersonById(id);
            var model =
                new PersonEdit
                {
                    PersonId = detail.PersonId,
                    AdultCount = detail.AdultCount,
                    ChildCount = detail.ChildCount,
                    Email = detail.Email,
                    Destination = detail.Destination,
                    TravelMode = detail.TravelMode,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PersonEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.PersonId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreatePersonService();

            if (service.UpdatePerson(model))
            {
                TempData["SaveResult"] = "Your Person was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Person could not be updated.");
            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreatePersonService();
            var model = svc.GetPersonById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreatePersonService();

            service.DeletePerson(id);

            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");
        }
    }
}