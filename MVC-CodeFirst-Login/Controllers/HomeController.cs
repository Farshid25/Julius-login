using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_CodeFirst_Login.Models;

namespace MVC_CodeFirst_Login.Controllers
{
    public class HomeController : Controller
    {
        private OurDbContext _context;
        public HomeController(OurDbContext context) {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Patient.ToList());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

     

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //IAction??
        public IActionResult Register() {
            return View();
        }

        //Action?
        [HttpPost]
        public ActionResult Register(Patient patient) {
            if (ModelState.IsValid) {
                _context.Patient.Add(patient);
                _context.SaveChanges();

                ModelState.Clear();
                ViewBag.message = patient.FirstName + " " + patient.LastName + " is successful registered";
            }
            return View();
        }

        public ActionResult Login() {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Patient patient) {
            var account = _context.Patient.Where(u => u.UserName == patient.UserName &&
            u.Password == patient.Password).First();
            if(account != null) {
                HttpContext.Session.SetString("PatientId", account.PatientId.ToString());
                HttpContext.Session.SetString("UserName", account.UserName); 
                return View("Welcome", patient);
            }
            else {
                ModelState.AddModelError("", "username or pass is wrong");
            }
            return View();
        }
        public ActionResult Welcome() {
            if(HttpContext.Session.GetString("UserId") != null) {
                ViewBag.UserName = HttpContext.Session.GetString("UserName");
                return View();
            }
            else {
                return RedirectToAction("Login");
            }
        }
        public ActionResult Logout() {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

    }
}
