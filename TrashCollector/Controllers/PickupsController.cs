using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class PickupsController : Controller
    {
        // GET: PickupsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PickupsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PickupsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PickupsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pickup pickup)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PickupsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PickupsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Pickup pickup)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PickupsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PickupsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Pickup pickup)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
