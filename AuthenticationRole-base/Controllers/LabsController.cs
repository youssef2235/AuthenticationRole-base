using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AuthenticationRole_base.Models;
using AuthenticationRole_base.Services;
using AuthenticationRole_base.Models;

namespace AuthenticationRole_base.Controllers
{
    public class LabsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LabsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Labs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lab.ToListAsync());
        }

        // GET: Labs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lab = await _context.Lab.FirstOrDefaultAsync(m => m.Id == id);
            if (lab == null)
            {
                return NotFound();
            }

            return View(lab);
        }

        // GET: Labs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Labs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClientName,Location,SampleType,ReceivedDate,ReportDate,pH,ElectricalConductivity,OrganicMatter,TotalNitrogen,AvailablePhosphorus,ExchangePotassium,Calcium,Magnesium,Iron,Zinc,SandPercentage,ClayPercentage,SiltPercentage,ApparentDensity")] Lab lab)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lab);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lab);
        }

        // GET: Labs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lab = await _context.Lab.FindAsync(id);
            if (lab == null)
            {
                return NotFound();
            }
            return View(lab);
        }

        // POST: Labs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClientName,Location,SampleType,ReceivedDate,ReportDate,pH,ElectricalConductivity,OrganicMatter,TotalNitrogen,AvailablePhosphorus,ExchangePotassium,Calcium,Magnesium,Iron,Zinc,SandPercentage,ClayPercentage,SiltPercentage,ApparentDensity")] Lab lab)
        {
            if (id != lab.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lab);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LabExists(lab.Id))
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
            return View(lab);
        }

        // GET: Labs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lab = await _context.Lab.FirstOrDefaultAsync(m => m.Id == id);
            if (lab == null)
            {
                return NotFound();
            }

            return View(lab);
        }

        // POST: Labs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lab = await _context.Lab.FindAsync(id);
            if (lab != null)
            {
                _context.Lab.Remove(lab);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool LabExists(int id)
        {
            return _context.Lab.Any(e => e.Id == id);
        }
    }
}
