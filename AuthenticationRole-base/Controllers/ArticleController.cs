using AuthenticationRole_base.Services;
using Microsoft.AspNetCore.Mvc;
using AuthenticationRole_base.Models;
using AuthenticationRole_base.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BlueGreenEG.Models;
using BlueGreenEG.ViewModels;

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
        public IActionResult Articles()
        {
            var articles = context.Articles.ToList();
            return View(articles);
        }

        public IActionResult Index()
        {
            var articles = context.Articles.ToList();

            return View(articles);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ArticleDTO articleDTO)
        {
            if (articleDTO.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "Please select a file");
            }

            if (!ModelState.IsValid)
            {
                return View(articleDTO);
            }

            string nameFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            string extension = Path.GetExtension(articleDTO.ImageFile!.FileName);
            string uploadFolder = Path.Combine(environment.WebRootPath, "Articles");

            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            string imageFullPath = Path.Combine(uploadFolder, nameFileName + extension);
            using (var fileStream = new FileStream(imageFullPath, FileMode.Create))
            {
                articleDTO.ImageFile.CopyTo(fileStream);
            }

            Article article = new Article()
            {
                Title = articleDTO.Title,
                Writer = articleDTO.Writer,
                WriterJob = articleDTO.WriterJob,
                Category = articleDTO.Category,
                SEO = articleDTO.SEO,
                Content = articleDTO.Content,
                

                ImageFileName = nameFileName + extension,
                CreatedAt = DateTime.Now,
            };

            context.Articles.Add(article);
            context.SaveChanges();

            return RedirectToAction("Index", "Article");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var article = context.Articles.FirstOrDefault(p => p.Id == id);
            if (article == null)
            {
                return NotFound();
            }

            // المنتجات اللي ليها نفس اسم الفئة (Category) و مختلفة عن المنتج الحالي
            var sameCategoryArticles = context.Articles
                .Where(p => p.Category == article.Category && p.Id != article.Id)
                .ToList();

            // نختار 2 عشوائيين من نفس الفئة
            var random = new Random();
            var randomArticles = sameCategoryArticles
                .OrderBy(x => random.Next())
                .Take(2)
                .ToList();

            var viewmodel = new ArticleDetails
            {
                Articles = article,
                First = randomArticles.ElementAtOrDefault(0) ?? new Article(),
                Second = randomArticles.ElementAtOrDefault(1) ?? new Article()
            };

            return View(viewmodel);
        }


        [Authorize(Roles = "admin")]
        public IActionResult Edit(int id)
        {
            var article = context.Articles.Find(id);
            if (article == null)
            {
                return NotFound();
            }

            var articleDto = new ArticleDTO
            {
                Title = article.Title,
                Writer = article.Writer,
                WriterJob = article.WriterJob,
                Category = article.Category,
                SEO = article.SEO,
                Content = article.Content
            };

            ViewData["ArticleId"] = article.Id;
            ViewData["ImageFileName"] = article.ImageFileName;
            ViewData["DateTime"] = article.CreatedAt.ToString("MM/dd/yyyy");

            return View(articleDto);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Edit(int id, ArticleDTO articleDto)
        {
            var article = context.Articles.Find(id);
            if (article == null)
            {
                return RedirectToAction("Index", "Article");
            }

            if (!ModelState.IsValid)
            {
                ViewData["ArticleId"] = article.Id;
                ViewData["ImageFileName"] = article.ImageFileName;
                ViewData["DateTime"] = article.CreatedAt.ToString("MM/dd/yyyy");
                return View(articleDto);
            }

            if (articleDto.ImageFile != null)
            {
                string nameFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                string extension = Path.GetExtension(articleDto.ImageFile.FileName);
                string uploadFolder = Path.Combine(environment.WebRootPath, "Articles");

                if (!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }

                string imageFullPath = Path.Combine(uploadFolder, nameFileName + extension);
                using (var fileStream = new FileStream(imageFullPath, FileMode.Create))
                {
                    articleDto.ImageFile.CopyTo(fileStream);
                }

                string oldImageFullPath = Path.Combine(uploadFolder, article.ImageFileName);
                if (System.IO.File.Exists(oldImageFullPath))
                {
                    System.IO.File.Delete(oldImageFullPath);
                }

                article.ImageFileName = nameFileName + extension;
            }

            article.Title = articleDto.Title;
            article.Writer = articleDto.Writer;
            article.WriterJob = articleDto.WriterJob;
            article.Category = articleDto.Category;
            article.SEO = articleDto.SEO;
            article.Content = articleDto.Content;

            context.SaveChanges();

            return RedirectToAction("Index", "Article");
        }


        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            var article = context.Articles.Find(id);
            if (article == null)
            {
                return NotFound();
            }

            string imageFullPath = Path.Combine(environment.WebRootPath, "Articles", article.ImageFileName);
            if (System.IO.File.Exists(imageFullPath))
            {
                System.IO.File.Delete(imageFullPath);
            }

            context.Articles.Remove(article);
            context.SaveChanges();

            return RedirectToAction("Index", "Article");
        }


    }
}
