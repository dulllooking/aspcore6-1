using aspcore6_1.Data;
using aspcore6_1.Models;
using aspcore6_1.Service;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net.Mail;

namespace aspcore6_1.Controllers
{
    public class CustomerController : Controller
    {
        private readonly DBContext _context;

        private readonly IMail _mail;

        public CustomerController(DBContext context, IMail mail)
        {
            _context = context;
            _mail = mail;
        }
        public IActionResult Register()
        {
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register( Customers member)
        {
            if (ModelState.IsValid) {
                _context.Add(member);
                await _context.SaveChangesAsync();

                //IMail mailService = new GmailService();
                _mail.SendMail(member.Email, "註冊通知", "歡迎註冊");

                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }

        public IActionResult ResetPassword()
        {
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(string account)
        {
            if (ModelState.IsValid)
            {
                Customers member = _context.customers.Where(x=>x.Account==account).FirstOrDefault();
                member.Password = Guid.NewGuid().ToString().Substring(5);
                await _context.SaveChangesAsync();

                //IMail mailService = new GmailService();
                _mail.SendMail(member.Email, "重設密碼", $"你的新密碼是{member.Password}");

                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
