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
    public class VillageDetailsController : Controller
    {
        private readonly medicareDBContext _context;

        public VillageDetailsController(medicareDBContext context)
        {
            _context = context;
        }

        // GET: VillageDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.VillageDetails.ToListAsync());
        }

        // GET: VillageDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var villageDetails = await _context.VillageDetails
                .FirstOrDefaultAsync(m => m.VillageId == id);
            if (villageDetails == null)
            {
                return NotFound();
            }

            return View(villageDetails);
        }

        // GET: VillageDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VillageDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VillageId,VillageName,District")] VillageDetails villageDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(villageDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(villageDetails);
        }

        // GET: VillageDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var villageDetails = await _context.VillageDetails.FindAsync(id);
            if (villageDetails == null)
            {
                return NotFound();
            }
            return View(villageDetails);
        }

        // POST: VillageDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VillageId,VillageName,District")] VillageDetails villageDetails)
        {
            if (id != villageDetails.VillageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(villageDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VillageDetailsExists(villageDetails.VillageId))
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
            return View(villageDetails);
        }

        // GET: VillageDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var villageDetails = await _context.VillageDetails
                .FirstOrDefaultAsync(m => m.VillageId == id);
            if (villageDetails == null)
            {
                return NotFound();
            }

            return View(villageDetails);
        }

        // POST: VillageDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var villageDetails = await _context.VillageDetails.FindAsync(id);
            _context.VillageDetails.Remove(villageDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VillageDetailsExists(int id)
        {
            return _context.VillageDetails.Any(e => e.VillageId == id);
        }
    }
}
