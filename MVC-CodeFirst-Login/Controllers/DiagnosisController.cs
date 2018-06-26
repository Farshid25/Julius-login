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

        public IActionResult GeefDiagnosis() {

            var diagnosisWithNames = _context.Diagnosis
               .GroupJoin(_context.Patient, d => d.DiagnosisId, p => p.PatientId, (d, f) => new {
                   Diagnosis = d,
                   Patient = f.Join(_context.Diagnosis, dl => dl.TheirFriends, pl => pl.PatientId,
                       (dl, pl) => pl)
               })
               .ToList();

        }
        
        }
}
