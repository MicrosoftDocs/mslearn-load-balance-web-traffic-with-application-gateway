using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using licenses.Models;

namespace licenses.Controllers
{
    public class LicenseRenewalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            try
            {
                var licenseId = Request.Form["LicenseID"];
                var firstName = Request.Form["FirstName"];
                var lastName = Request.Form["LastName"];
                var dateRenewed = Request.Form["DateOfRenewal"];

                LicenseRenewal renewal = new LicenseRenewal()
                {
                    LicenseID = licenseId,
                    FirstName = firstName,
                    LastName = lastName,
                    DateOfRenewal = DateTime.Parse(dateRenewed)
                };

                // TODO: Save the vehicle registration in a database

                ViewBag.Message = "License was renewed successfully.";
                ViewBag.Submitted = true;

            }
            catch
            {
                ViewBag.Message = "There was an error while renewing the license.";
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
