using System;
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
using Stripe.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.CodeAnalysis.CSharp.Syntax;

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
            var customer = _db.Customers.Where(c => c.IdentityUserId == userId).SingleOrDefault();

            if (customer == null)
            {
                return RedirectToAction(nameof(Create));
            }
            customer.Pickups = _db.Pickups.Where(p => p.CustomerId == customer.Id).ToList();
            UpdateBalanceInfo(customer);
            return View(customer.Pickups);
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
                CreateInitialPickup(customer);
                UpdateBalanceInfo(customer);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        
        public ActionResult CreateSinglePickup()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSinglePickup(Pickup pickup)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var customer = _db.Customers.Where(c => c.IdentityUserId == userId).SingleOrDefault();
                pickup.CustomerId = customer.Id;
                pickup.PickupZipCode = customer.ZipCode;
                pickup.IsActive = true;
                pickup.IsOneOff = true;
                customer.pickupDay = pickup.ScheduledPickupDate;
                _db.Pickups.Add(pickup);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
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
        public ActionResult EditPickup(int id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _db.Customers.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            return View(customer);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPickup(int id, Customer customer)
        {
            try
            {
                var customerToUpdate = _db.Customers.Find(id);
                customerToUpdate.DayOfWeek = customer.DayOfWeek;
                _db.SaveChanges();
                UpdateRegularPickups(customerToUpdate);
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
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _db.Customers.Where(c => c.IdentityUserId == userId).SingleOrDefault();
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
                var pickupsToSuspend = _db.Pickups.Where(p => p.CustomerId == customer.Id).Where(p => p.ScheduledPickupDate >= customer.stopPickup).Where(p => p.ScheduledPickupDate < customer.restartPickup).Where(p=>p.IsComplete == false);
                foreach(Pickup pickup in pickupsToSuspend)
                {
                    pickup.IsActive = false;
                }
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // GET: CustomerController/Edit/5
        public ActionResult SuspendSingle(int id)
        {
            var pickupToSuspend = _db.Pickups.Find(id);
            pickupToSuspend.IsActive = false;
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
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

        public void CreateInitialPickup(Customer customer)
        {
            DateTime today = DateTime.Today;
            // The (... + 7) % 7 ensures we end up with a value in the range [0, 6]
            int daysUntilFirstPickup = ((int)customer.DayOfWeek - (int)today.DayOfWeek + 7) % 7;
            DateTime nextPickup = today.AddDays(daysUntilFirstPickup);

            Pickup pickup = new Pickup();
            pickup.CustomerId = customer.Id;
            pickup.PickupZipCode = customer.ZipCode;
            pickup.IsActive = true;
            pickup.ScheduledPickupDate = nextPickup;
            _db.Pickups.Add(pickup);
            _db.SaveChanges();

        }

        public void UpdateRegularPickups(Customer customer)
        {
            var pickupsToUpdate = _db.Pickups.Where(p => p.CustomerId == customer.Id).Where(p => p.IsOneOff == false).Where(p => p.IsComplete == false).ToList();
            foreach(Pickup pickup in pickupsToUpdate)
            {
                int daysToAdjustPickup = ((int)customer.DayOfWeek - (int)pickup.ScheduledPickupDate.DayOfWeek + 7) % 7;
                pickup.ScheduledPickupDate = pickup.ScheduledPickupDate.AddDays(daysToAdjustPickup);
            }
            _db.SaveChanges();
        }

        public decimal GetTotalBalance(Customer customer)
        {
            var totalBalance = _db.Pickups.Where(p => p.IsComplete).Sum(p => p.AmountCharged);
            return totalBalance;
        }
        public decimal GetMonthlyBalance(Customer customer)
        {
            var monthlyBalance = _db.Pickups.Where(p => p.IsComplete).Where(p => p.ScheduledPickupDate.Month == DateTime.Now.Month).Sum(p=>p.AmountCharged);
            return monthlyBalance;
        }

        public decimal GetCurrentMonthsPayments(Customer customer)
        {
            var currentMonthsPayments = _db.Pickups.Where(p => p.IsComplete).Where(p => p.ScheduledPickupDate.Month == DateTime.Now.Month).Sum(p => p.AmountPaid);
            return currentMonthsPayments;
        }

        public decimal OpenBalance(Customer customer)
        {
            var openBalance = GetTotalBalance(customer) - GetTotalPayments(customer);
            return openBalance;
            
        }

        public decimal CurrentMonthBalance(Customer customer)
        {
            var currentMonthBalance = GetMonthlyBalance(customer) - GetCurrentMonthsPayments(customer);
            return currentMonthBalance;
        }
        public decimal GetTotalPayments(Customer customer)
        {
            var totalPayments = _db.Pickups.Where(p => p.IsComplete).Sum(p => p.AmountPaid);
            return totalPayments;
        }

        public void UpdateBalanceInfo(Customer customer)
        {
            customer.customerBalance = OpenBalance(customer);
            customer.currentMonthlyBalance = CurrentMonthBalance(customer);
            customer.currentMonthlyCharges = GetMonthlyBalance(customer);
            _db.SaveChanges();
        }

    }
}
