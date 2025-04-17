using System.Diagnostics;
using AuthenticationRole_base.Models;
using AuthenticationRole_base.Services;
using BlueGreenEG.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationRole_base.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        
        public HomeController(ILogger<HomeController> logger , ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
           
            var homeViewModel = new HomeViewModel
            {
                Products = _context.Products.Take(4).ToList(),
                Articles = _context.Articles.Take(4).ToList()
            };
            return View(homeViewModel);
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Articles()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
