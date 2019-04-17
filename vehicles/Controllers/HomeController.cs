using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using vehicles.Models;

namespace vehicles.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            try
            {
                var id = Request.Form["OwnerID"];
                var email = Request.Form["EmailAddress"];
                var vehicle = Request.Form["Vehicle"];
                var dateRegistered = Request.Form["DateOfRegistration"];

                VehicleRegistration registration = new VehicleRegistration()
                {
                    OwnerID = id,
                    EmailAddress = email,
                    Vehicle = vehicle,
                    DateOfRegistration = DateTime.Parse(dateRegistered)
                };

                // TODO: Save the vehicle registration in a database

                ViewBag.Message = "Vehicle was registered successfully.";
                ViewBag.Submitted = true;

            }
            catch
            {
                ViewBag.Message = "There was an error while registering the vehicle.";
                ViewBag.Submitted = false;
            }
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Motor Vehicle Department";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
