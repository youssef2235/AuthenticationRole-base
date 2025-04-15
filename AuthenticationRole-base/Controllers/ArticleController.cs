using AuthenticationRole_base.Services;
using Microsoft.AspNetCore.Mvc;
using AuthenticationRole_base.Models;
using AuthenticationRole_base.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationRole_base.Controllers
{
    public class ArticleController : Controller
    {

        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment environment;

        public ArticleController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            this.context = context;
            this.environment = environment;
        }
        public IActionResult Index()
        {
            var articles = context.Articles.ToList();

            return View(articles);
        }
        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Articles()
        {
            return View();
        }

        


    }
}
