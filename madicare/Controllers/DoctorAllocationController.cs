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
    public class DoctorAllocationController : Controller
    {
        private readonly medicareDBContext _context;

        public DoctorAllocationController(medicareDBContext context)
        {
            _context = context;
        }

        // GET: DoctorAllocation
        public async Task<IActionResult> Index()
        {
            var medicareDBContext = _context.doctors.Include(d => d.villageDetails);
            return View(await medicareDBContext.ToListAsync());
        }

        // GET: DoctorAllocation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.doctors
                .Include(d => d.villageDetails)
                .FirstOrDefaultAsync(m => m.did == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // GET: DoctorAllocation/Create
        public IActionResult Create()
        {
            ViewData["VillageId"] = new SelectList(_context.VillageDetails, "VillageId", "VillageName");
            return View();
        }

        // POST: DoctorAllocation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("did,dname,dphone,daddress,dgender,demail,dpassword,ddate_of_brith,dqualification,VillageId")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doctor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VillageId"] = new SelectList(_context.VillageDetails, "VillageId", "VillageName", doctor.VillageId);
            return View(doctor);
        }

        // GET: DoctorAllocation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.doctors.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            ViewData["VillageId"] = new SelectList(_context.VillageDetails, "VillageId", "VillageName", doctor.VillageId);
            return View(doctor);
        }

        // POST: DoctorAllocation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("did,dname,dphone,daddress,dgender,demail,dpassword,ddate_of_brith,dqualification,VillageId")] Doctor doctor)
        {
            if (id != doctor.did)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorExists(doctor.did))
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
            ViewData["VillageId"] = new SelectList(_context.VillageDetails, "VillageId", "VillageName", doctor.VillageId);
            return View(doctor);
        }

        // GET: DoctorAllocation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.doctors
                .Include(d => d.villageDetails)
                .FirstOrDefaultAsync(m => m.did == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // POST: DoctorAllocation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doctor = await _context.doctors.FindAsync(id);
            _context.doctors.Remove(doctor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorExists(int id)
        {
            return _context.doctors.Any(e => e.did == id);
        }
    }
}
