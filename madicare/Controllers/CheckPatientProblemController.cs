using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using madicare.Data;
using madicare.Models;

namespace madicare.Controllers
{
    public class CheckPatientProblemController : Controller
    {
        private readonly medicareDBContext _context;

        public CheckPatientProblemController(medicareDBContext context)
        {
            _context = context;
        }

        // GET: CheckPatientProblem
        public async Task<IActionResult> Index()
        {
            return View(await _context.patient.ToListAsync());
        }

        // GET: CheckPatientProblem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.patient
                .FirstOrDefaultAsync(m => m.pid == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // GET: CheckPatientProblem/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CheckPatientProblem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("pid,pname,pphone,paddress,pgender,pweight,phight,pbmi,pbmr,pbp,pdate_of_brith,ppassword,pdisease,pdiseaseSlove")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patient);
        }

        // GET: CheckPatientProblem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.patient.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        // POST: CheckPatientProblem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("pid,pname,pphone,paddress,pgender,pweight,phight,pbmi,pbmr,pbp,pdate_of_brith,ppassword,pdisease,pdiseaseSlove")] Patient patient)
        {
            if (id != patient.pid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientExists(patient.pid))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(patient);
        }

        // GET: CheckPatientProblem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.patient
                .FirstOrDefaultAsync(m => m.pid == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // POST: CheckPatientProblem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patient = await _context.patient.FindAsync(id);
            _context.patient.Remove(patient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientExists(int id)
        {
            return _context.patient.Any(e => e.pid == id);
        }
    }
}
