using IceCreamStore.Data.Models;
using IceCreamStore.Data.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IceCreamStore.Web.Controllers
{
    public class RestaurantsController : Controller
    {
        private IRestaurantData db;

        public RestaurantsController(IRestaurantData db)
        {
            this.db = db;

        }

        // GET: Restaurants
        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var restaurant = db.Get(id);
            if (restaurant == null)
            {
                return View("PageNotFound");
            }
            return View(restaurant);
        }

        public ActionResult Create()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Add(restaurant);
                return RedirectToAction("Details", new { id = restaurant.Id });
            }
            db.Add(restaurant);
            return View();
        }

        public ActionResult Edit(int id)
        {
            var restaurant = db.Get(id);
            if (restaurant == null)
            {
                return View("PageNotFound");
            }
            return View(restaurant);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Update(restaurant);
                return RedirectToAction("Details", new { id = restaurant.Id });
            }
            return View(restaurant);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var restaurant = db.Get(id);
            if (restaurant == null)
            {
                return View("PageNotFound");
            }
            return View(restaurant);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection form)
        {
            Debug.WriteLine(form);
            db.Delete(id);
            return RedirectToAction("Index");

        }

    }
}