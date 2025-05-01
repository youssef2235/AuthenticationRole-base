using AuthenticationRole_base.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlueGreenEG.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "admin")]
        public IActionResult Admin()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        public IActionResult TestDatabaseConnection()
        {
            try
            {
                bool canConnect = _context.Database.CanConnect();
                if (canConnect)
                {
                    ViewBag.Message = "تم الاتصال بقاعدة البيانات بنجاح!";
                    ViewBag.IsSuccess = true;
                }
                else
                {
                    ViewBag.Message = "فشل الاتصال بقاعدة البيانات!";
                    ViewBag.IsSuccess = false;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"حدث خطأ: {ex.Message}";
                ViewBag.IsSuccess = false;
            }

            return View();
        }
    }
}
