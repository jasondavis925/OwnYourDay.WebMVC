﻿using Microsoft.AspNet.Identity;
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
        // GET: AirCraft
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
            if (!ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}