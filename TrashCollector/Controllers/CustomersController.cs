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
using Stripe;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TrashCollector.Controllers
{
    //[Authorize(Roles = "Customer")]
    public class CustomersController : Controller
    {
        private ApplicationDbContext _db;
        private static readonly HttpClient httpClient;
        static CustomersController()
        {
            httpClient = new HttpClient();
        }
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
            CreateAdditionalPickups(customer);
            return View(customer.Pickups);
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            var customerToView = _db.Customers.Find(id);
            return View(customerToView);
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Models.Customer customer)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                customer.IdentityUserId = userId;
                await GetGeoCode(customer);
                _db.Add(customer);
                _db.SaveChanges();
                CreateInitialPickup(customer);
                CreateAdditionalPickups(customer);
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
        public ActionResult Edit(int id, Models.Customer customer)
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
        public ActionResult EditPickup(int id, Models.Customer customer)
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
        public ActionResult Suspend(int id, Models.Customer customer)
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

        public ActionResult Reactivate(int id)
        {
            var pickupToActivate = _db.Pickups.Find(id);
            pickupToActivate.IsActive = true;
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
        public ActionResult Delete(int id, Models.Customer customer)
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

        public void CreateInitialPickup(Models.Customer customer)
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

        private string AddressParser(Models.Customer customer)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < customer.Address1.Length; i++)
            {
                if (customer.Address1[i] == ' ')
                {
                    sb.Append("+");
                }
                else
                {
                    sb.Append(customer.Address1[i]);
                }
            }
            sb.Append(",+");
            for (int i = 0; i < customer.City.Length; i++)
            {
                if (customer.City[i] == ' ')
                {
                    sb.Append("+");
                }
                else
                {
                    sb.Append(customer.City[i]);
                }
            }
            sb.Append(",+");
            for (int i = 0; i < customer.State.Length; i++)
            {
                if (customer.State[i] == ' ')
                {
                    sb.Append("+");
                }
                else
                {
                    sb.Append(customer.State[i]);
                }
            }
            return sb.ToString();
        }

        private async Task<Models.Customer> GetGeoCode(Models.Customer customer)
        {
            string address = AddressParser(customer);
            Uri geocodeURL = new Uri("https://maps.googleapis.com/maps/api/geocode/json?address=" + address + "&key=" + APIKey.googleMapsApi);
            var response = await httpClient.GetAsync(geocodeURL);

            if (response.IsSuccessStatusCode)
            {
                var task = response.Content.ReadAsStringAsync().Result;
                JObject mapsData = JsonConvert.DeserializeObject<JObject>(task);
                customer.Latitude = Convert.ToDecimal(mapsData["results"][0]["geometry"]["location"]["lat"]);
                customer.Longitude = Convert.ToDecimal(mapsData["results"][0]["geometry"]["location"]["lng"]);
            }

            return customer;
        }
        public void UpdateRegularPickups(Models.Customer customer)
        {
            var pickupsToUpdate = _db.Pickups.Where(p => p.CustomerId == customer.Id).Where(p => p.IsOneOff == false).Where(p => p.IsComplete == false).ToList();
            foreach(Pickup pickup in pickupsToUpdate)
            {
                int daysToAdjustPickup = ((int)customer.DayOfWeek - (int)pickup.ScheduledPickupDate.DayOfWeek + 7) % 7;
                pickup.ScheduledPickupDate = pickup.ScheduledPickupDate.AddDays(daysToAdjustPickup);
            }
            _db.SaveChanges();
        }

        public decimal GetTotalBalance(Models.Customer customer)
        {
            var totalBalance = _db.Pickups.Where(p => p.IsComplete).Sum(p => p.AmountCharged);
            return totalBalance;
        }
        public decimal GetMonthlyBalance(Models.Customer customer)
        {
            var monthlyBalance = _db.Pickups.Where(p => p.IsComplete).Where(p => p.ScheduledPickupDate.Month == DateTime.Now.Month).Sum(p=>p.AmountCharged);
            return monthlyBalance;
        }

        public decimal GetCurrentMonthsPayments(Models.Customer customer)
        {
            var currentMonthsPayments = _db.Pickups.Where(p => p.IsComplete).Where(p => p.ScheduledPickupDate.Month == DateTime.Now.Month).Sum(p => p.AmountPaid);
            return currentMonthsPayments;
        }

        public decimal OpenBalance()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _db.Customers.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            var openBalance = GetTotalBalance(customer) - GetTotalPayments(customer);
            return openBalance;
            
        }

        public decimal CurrentMonthBalance(Models.Customer customer)
        {
            var currentMonthBalance = GetMonthlyBalance(customer) - GetCurrentMonthsPayments(customer);
            return currentMonthBalance;
        }
        public decimal GetTotalPayments(Models.Customer customer)
        {
            var totalPayments = _db.Pickups.Where(p => p.IsComplete).Sum(p => p.AmountPaid);
            return totalPayments;
        }

        public void UpdateBalanceInfo(Models.Customer customer)
        {
            customer.customerBalance = OpenBalance();
            customer.currentMonthlyBalance = CurrentMonthBalance(customer);
            customer.currentMonthlyCharges = GetMonthlyBalance(customer);
            _db.SaveChanges();
        }
        public void CreateAdditionalPickups(Models.Customer customer)
        {
            var pickups = _db.Pickups.Where(p => p.CustomerId == customer.Id).Where(p=>p.IsOneOff == false).ToList();
            int pickupsCount = pickups.Count();
            int pickupsToSchedule = 4;
            int pickupsNeeded = pickupsToSchedule - pickupsCount;
            if(pickupsNeeded > 0)
            {
                for (int i = 0; i < pickupsNeeded; i++)
                {
                    pickups = _db.Pickups.Where(p => p.CustomerId == customer.Id).Where(p => p.IsOneOff == false).ToList();
                    Pickup pickup = new Pickup();
                    pickup.CustomerId = customer.Id;
                    pickup.PickupZipCode = customer.ZipCode;
                    pickup.IsActive = true;
                    pickup.ScheduledPickupDate = pickups[pickups.Count - 1].ScheduledPickupDate.AddDays(7);
                    _db.Pickups.Add(pickup);
                    _db.SaveChanges();
                }
            }
        }


    }
}
