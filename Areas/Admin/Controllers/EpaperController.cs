using aspcore6_1.Data;
using aspcore6_1.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net.Mail;

namespace aspcore6_1.Areas.Admin.Controllers
{
    public class EpaperController : Controller
    {
        private readonly DBContext _context;

        public EpaperController(DBContext context)
        {
            _context = context;
        }
        public async Task<IActionResult>  SendEpapers()
        {
            // 可以使用其它帳密發信
            IMail mailService = new LocalMailService();
            mailService.Account = "apple@mymail.com";
            mailService.Password = "88888888";
            foreach (var item in await _context.customers.ToListAsync()) {
                mailService.SendMailWithFile(item.Email, "寄送電子報", "電子報內容", @"D:\MCTS\MCTS2011\Practice\Practice\bin\Debug\cloud.jpg");
            }
            return Content("電子報發送完成");
        }

    }
}
