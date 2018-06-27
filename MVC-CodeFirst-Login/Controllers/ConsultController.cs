using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using MVC_CodeFirst_Login.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_CodeFirst_Login.Controllers
{
    public class ConsultController : Controller
    {
        private OurDbContext _context;
        public ConsultController(OurDbContext context)
        {
            _context = context;
        }

        public IActionResult Consult()
        {
            //var diagnosis = _context.Diagnosis
            //    .Include(pa => pa.patient)
            //    .Include(gp => gp.generalPractioner).ToList();

            return View(_context.Consult.ToList());
        }

        // GET: Consult/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Create(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diagnosis = await _context.Diagnosis.SingleOrDefaultAsync(m => m.DiagnosisId == id);
            if (diagnosis == null)
            {
                return NotFound();
            }
            return View(diagnosis);
        }

        // POST: Consult/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int diagnosisId, [Bind("ConsultId,BeginDate,EpisodeId,PrescriptionId")] Consult consult)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consult);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiagnosisExists(diagnosisId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Consult));
            }
            return View(consult);
        }

        private bool DiagnosisExists(int id)
        {
            return _context.Diagnosis.Any(e => e.DiagnosisId == id);
        }
    }
}
