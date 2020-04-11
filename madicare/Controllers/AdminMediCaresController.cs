using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using madicare.Controllers;
using madicare.Data;

namespace madicare.Models
{
    public class AdminMediCaresController : Controller
    {
        private readonly medicareDBContext _context;

        public AdminMediCaresController(medicareDBContext context)
        {
            _context = context;
        }

        // GET: AdminMediCares
        public async Task<IActionResult> Index()
        {
             Doctor doctor  = await _context.doctors.FirstOrDefaultAsync(m => m.did == 1);
            
            
            ViewData["totalDoctor"]= _context.doctors.Count();
            ViewData["totalPatient"] = _context.patient.Count();
            //calculate AVG BMI
            int totalpatient = _context.patient.Count();
            var test = _context.patient.Include(i => i.pbmi);
            //int avg = int.Parse(i=>i.pbmi);
            int totalBMI = (_context.patient.Sum(s=>s.pid)) ;



            int totalChild = 0;
            int lowWeight = 0;
            var bloodDoner = _context.patient.ToList();
            List<Patient> Patientlist = new List<Patient>();
            foreach (var donor in bloodDoner)
            {
                string date = donor.pdate_of_brith;
                int BMI = int.Parse(donor.pbmr);
                int Bweight = int.Parse(donor.pweight);


                DateTime myDate = DateTime.ParseExact(date, "dd-MM-yyyy",
                                       System.Globalization.CultureInfo.InvariantCulture);
                //TimeSpan differ = DateTime.Now.Subtract(myDate);
                TimeSpan differ = DateTime.Now.Subtract(myDate);

                double days = differ.TotalDays;
                double age = (days / 356);

                //DateTime presantTime = DateTime.Now;

                if (age <= 17)
                {
                    totalChild = totalChild + 1;

                    if (Bweight >= 40)
                    {

                        lowWeight = lowWeight + 1;
                    }


                }
            }
            ViewData["totalChild"] = totalChild;
            ViewData["totalDoner"] = totalpatient-lowWeight;





            //AVG BMI Caculation
            var patients = _context.patient.ToList();
            int sumBMI=0;
            
            foreach (var p in patients)
            {
             
                int patientBMI=int.Parse(p.pbmi);
                sumBMI = sumBMI + patientBMI;
                
            }
            int AvgBMI = sumBMI / totalpatient;
            ViewData["AvgBMI"] = AvgBMI;



            //AVG BMR Caculation
            var patientsBMR = _context.patient.ToList();
            int sumBMR = 0;

            foreach (var p in patientsBMR)
            {

                int BMR = int.Parse(p.pbmr);
                sumBMR = sumBMR + BMR;

            }
            int AvgBMR = sumBMR / totalpatient;
            ViewData["AvgBMR"] = AvgBMR;
                                                                  
            
            
            //ViewData["bloodDoner"] = AvgBMI;

            var maleGenderner = _context.patient.Count(s => s.pgender== "Male");
            ViewData["totalmaleGenderner"] = maleGenderner;
            ViewData["maleGenderner%"] = (maleGenderner*100)/totalpatient;

            var femaleGenderner = _context.patient.Count(s => s.pgender == "Female");
            ViewData["totalfemaleGenderner"] = femaleGenderner;
            ViewData["femaleGenderner%"] = (femaleGenderner * 100) / totalpatient;






            return View(await _context.admin_medi_care.ToListAsync());
        }


      













        // GET: AdminMediCares/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminMediCare = await _context.admin_medi_care
                .FirstOrDefaultAsync(m => m.aid == id);
            if (adminMediCare == null)
            {
                return NotFound();
            }

            return View(adminMediCare);
        }

        // GET: AdminMediCares/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminMediCares/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("aid,aname,aphone,aaddress,agender,aemail,apassword,adate_of_brith")] AdminMediCare adminMediCare)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adminMediCare);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adminMediCare);
        }

        // GET: AdminMediCares/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminMediCare = await _context.admin_medi_care.FindAsync(id);
            if (adminMediCare == null)
            {
                return NotFound();
            }
            return View(adminMediCare);
        }

        // POST: AdminMediCares/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("aid,aname,aphone,aaddress,agender,aemail,apassword,adate_of_brith")] AdminMediCare adminMediCare)
        {
            if (id != adminMediCare.aid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adminMediCare);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminMediCareExists(adminMediCare.aid))
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
            return View(adminMediCare);
        }

        // GET: AdminMediCares/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminMediCare = await _context.admin_medi_care
                .FirstOrDefaultAsync(m => m.aid == id);
            if (adminMediCare == null)
            {
                return NotFound();
            }

            return View(adminMediCare);
        }

        // POST: AdminMediCares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adminMediCare = await _context.admin_medi_care.FindAsync(id);
            _context.admin_medi_care.Remove(adminMediCare);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminMediCareExists(int id)
        {
            return _context.admin_medi_care.Any(e => e.aid == id);
        }
    }
}
