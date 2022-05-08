#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using aspcore6_1.Data;
using System.Net.Mail;
using aspcore6_1.Models;
using aspcore6_1.Service;

namespace aspcore6_1.Controllers
{
    public class Contact_UsController : Controller
    {
        private readonly DBContext _context;

        private readonly IMail _mail;

        public Contact_UsController(DBContext context, IMail mail)
        {
            _context = context;
            _mail = mail;
        }

        // GET: Contact_Us
        public async Task<IActionResult> Index()
        {
            return View(await _context.contact_Us.ToListAsync());
        }

        // GET: Contact_Us/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact_Us = await _context.contact_Us
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contact_Us == null)
            {
                return NotFound();
            }

            return View(contact_Us);
        }

        // GET: Contact_Us/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contact_Us/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Subject,Name,Email")] Contact_Us contact_Us)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contact_Us);
                await _context.SaveChangesAsync();

                //IMail mailService = new GmailService();
                _mail.SendMail(contact_Us.Email, $"聯絡我們-{contact_Us.Subject}", $"發信者：{contact_Us.Name}<br/>{ contact_Us.Content}");

                return RedirectToAction(nameof(Index));
            }
            return View(contact_Us);
        }

        // GET: Contact_Us/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact_Us = await _context.contact_Us.FindAsync(id);
            if (contact_Us == null)
            {
                return NotFound();
            }
            return View(contact_Us);
        }

        // POST: Contact_Us/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Subject,Name,Email")] Contact_Us contact_Us)
        {
            if (id != contact_Us.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contact_Us);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Contact_UsExists(contact_Us.Id))
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
            return View(contact_Us);
        }

        // GET: Contact_Us/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact_Us = await _context.contact_Us
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contact_Us == null)
            {
                return NotFound();
            }

            return View(contact_Us);
        }

        // POST: Contact_Us/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contact_Us = await _context.contact_Us.FindAsync(id);
            _context.contact_Us.Remove(contact_Us);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Contact_UsExists(int id)
        {
            return _context.contact_Us.Any(e => e.Id == id);
        }
    }
}
