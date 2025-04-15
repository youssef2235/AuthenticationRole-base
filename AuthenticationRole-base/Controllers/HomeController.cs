using System.Diagnostics;
using AuthenticationRole_base.Models;
using AuthenticationRole_base.Services;
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

        //public List<Product> GetProducts()
        //{
          //  return new List<Product>(); // Ensure it's always initialized
        //}
        
        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
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
