using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AuthenticationRole_base.Services;
using BlueGreenEG.Models;

namespace BlueGreenEG.Controllers
{
    public class FormContactsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FormContactsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.FormContact.ToListAsync());
        }
        /*
        // GET: FormContacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formContact = await _context.FormContact
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formContact == null)
            {
                return NotFound();
            }

            return View(formContact);
        }

        */
       

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,PhoneNumber,SubMessage,Message")] FormContact formContact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formContact);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "تم إرسال رسالتك بنجاح. سنقوم بالرد عليك في أقرب وقت ممكن.";
                return RedirectToAction("Contact","Home");
            }

            return View(formContact);
        }
        /*
        // GET: FormContacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formContact = await _context.FormContact.FindAsync(id);
            if (formContact == null)
            {
                return NotFound();
            }
            return View(formContact);
        }
        */
        /*

        // POST: FormContacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,PhoneNamber,SubMessage,Message")] FormContact formContact)
        {
            if (id != formContact.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formContact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormContactExists(formContact.Id))
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
            return View(formContact);
        }
        */

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formContact = await _context.FormContact.FindAsync(id);
            if (formContact == null)
            {
                return NotFound();
            }

            _context.FormContact.Remove(formContact);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        /*
        // POST: FormContacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var formContact = await _context.FormContact.FindAsync(id);
            if (formContact != null)
            {
                _context.FormContact.Remove(formContact);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        */
        private bool FormContactExists(int id)
        {
            return _context.FormContact.Any(e => e.Id == id);
        }
    }
}
