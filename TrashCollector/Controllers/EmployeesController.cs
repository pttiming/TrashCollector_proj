using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TrashCollector.Data;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    [Authorize(Roles = "Employee")]
    public class EmployeesController : Controller
    {
        private ApplicationDbContext _db;
        private static readonly HttpClient httpClient;

        static EmployeesController()
        {
            httpClient = new HttpClient();
        }

        public EmployeesController(ApplicationDbContext db)
        {
            _db = db;
        }
        // GET: EmployeeController
        public ActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employeeId = _db.Employees.Where(e => e.IdentityUserId == userId).SingleOrDefault();
            //var employee = _db.Employees.Find(employeeId);
            

            if (employeeId == null)
            {
                return RedirectToAction(nameof(Create));
            }
            var pickups = _db.Pickups.Where(p => p.PickupZipCode == employeeId.RouteZipCode).Include(p => p.Customer).ToList();
            return View(pickups);
        }
        public ActionResult IndexAll()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employeeId = _db.Employees.Where(e => e.IdentityUserId == userId).SingleOrDefault();
            var customers = _db.Customers.Where(c => c.ZipCode == employeeId.RouteZipCode).ToList();
            return View(customers);
        }

        public ActionResult IndexDay(int id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employeeId = _db.Employees.Where(e => e.IdentityUserId == userId).SingleOrDefault();
            var customers = _db.Customers.Where(c => c.ZipCode == employeeId.RouteZipCode).Where(c => (int)c.DayOfWeek == id).ToList();
            return View(customers);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            var customer = _db.Customers.Find(id);
            return View(customer);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Employee employee)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                employee.IdentityUserId = userId;
                await GetRouteGeoCode(employee);
                _db.Add(employee);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
        private async Task<Models.Employee> GetRouteGeoCode(Models.Employee employee)
        {
            Uri geocodeURL = new Uri("https://maps.googleapis.com/maps/api/geocode/json?address=" + employee.RouteZipCode.ToString() + "&key=" + APIKey.googleMapsApi);
            var response = await httpClient.GetAsync(geocodeURL);

            if (response.IsSuccessStatusCode)
            {
                var task = response.Content.ReadAsStringAsync().Result;
                JObject mapsData = JsonConvert.DeserializeObject<JObject>(task);
                employee.Latitude = Convert.ToDecimal(mapsData["results"][0]["geometry"]["location"]["lat"]);
                employee.Longitude = Convert.ToDecimal(mapsData["results"][0]["geometry"]["location"]["lng"]);
            }

            return employee;
        }

        // GET: CustomerController/Edit/5
        public ActionResult CompletePickup(int id)
        {
            var pickupToComplete = _db.Pickups.Find(id);
            pickupToComplete.IsComplete = true;
            if (pickupToComplete.IsOneOff)
            {
                pickupToComplete.AmountCharged = 20;
            }
            else
            {
                pickupToComplete.AmountCharged = 10;
            }
            pickupToComplete.ActualPickupDate = DateTime.Now;
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
