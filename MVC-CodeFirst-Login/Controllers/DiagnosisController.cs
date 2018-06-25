using Microsoft.AspNetCore.Mvc;
using MVC_CodeFirst_Login.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_CodeFirst_Login.Controllers
{
    public class DiagnosisController : Controller
    {
        private OurDbContext _context;
        public DiagnosisController(OurDbContext context) {
            _context = context;
        }

        public IActionResult Diagnosis() {
            return View(_context.Diagnosis.ToList());
        }



    }
}
