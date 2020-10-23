﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrashCollector.Data;
using TrashCollector.Models;
using NetTopologySuite.Geometries;
using NetTopologySuite;

namespace TrashCollector.Controllers
{
    [Authorize(Roles = "Customer")]
    public class CustomersController : Controller
    {
        private ApplicationDbContext _db;
        public CustomersController(ApplicationDbContext db)
        {
            _db = db;
        }
        // GET: CustomerController
        public ActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customerId = _db.Customers.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            var customer = _db.Customers.Where(c => c.IdentityUserId == userId).ToList();


            if (customerId == null)
            {
                return RedirectToAction(nameof(Create));
            }
            return View(customer);
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                customer.IdentityUserId = userId;
                _db.Add(customer);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // GET: CustomerController/Create
        public ActionResult CreatePickup()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePickup(Pickup pickup)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var customer = _db.Customers.Where(c => c.IdentityUserId == userId).SingleOrDefault();
                pickup.CustomerId = customer.Id;
                pickup.PickupZipCode = customer.ZipCode;
                pickup.IsActive = true;
                _db.Pickups.Add(pickup);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Customer customer)
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
        // GET: CustomerController/Edit/5
        public ActionResult Suspend(int id)
        {
            var customer = _db.Customers.Find(id);
            return View(customer);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Suspend(int id, Customer customer)
        {
            try
            {
                var customerToUpdate = _db.Customers.Find(id);
                customerToUpdate.stopPickup = customer.stopPickup;
                customerToUpdate.restartPickup = customer.restartPickup;
                if(DateTime.Now >= customer.stopPickup && DateTime.Now < customer.restartPickup)
                {
                    customerToUpdate.isActive = false;
                }

                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Customer customer)
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
