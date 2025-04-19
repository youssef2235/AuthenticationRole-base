using AuthenticationRole_base.Models;
using AuthenticationRole_base.Services;
using BlueGreenEG.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationRole_base.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment environment;

        public ProductController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            this.context = context;
            this.environment = environment;
        }

        public IActionResult Products ()
        {
            var products = context.Products.ToList();
            return View(products);
        }
        public IActionResult Index()
        {
            var products = context.Products.ToList();
            return View(products);
        }

        [Authorize(Roles ="admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductDto productDto)
        {
            if (productDto.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "Please select a file");
            }

            if (!ModelState.IsValid)
            {
                return View(productDto);
            }

            string nameFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            string extension = Path.GetExtension(productDto.ImageFile!.FileName);
            string uploadFolder = Path.Combine(environment.WebRootPath, "Products");

            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            string imageFullPath = Path.Combine(uploadFolder, nameFileName + extension);
            using (var fileStream = new FileStream(imageFullPath, FileMode.Create))
            {
                productDto.ImageFile.CopyTo(fileStream);
            }

            Product product = new Product()
            {
                Name = productDto.Name,
                Brand = productDto.Brand,
                Category = productDto.Category,
                Price = productDto.Price,
                Description = productDto.Description,
                Quantity = productDto.Quantity,
                Proberties = productDto.Proberties,
                Form = productDto.Form,
                binfet = productDto.binfet,
                usage = productDto.usage,
                productdata = productDto.productdata,
                SeoTitle = productDto.SeoTitle,

                ImageFileName = nameFileName + extension,
                CreatedAt = DateTime.Now,
            };

            context.Products.Add(product);
            context.SaveChanges();

            return RedirectToAction("Index", "Product");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var product = context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            // المنتجات اللي ليها نفس اسم الفئة (Category) و مختلفة عن المنتج الحالي
            var sameCategoryProducts = context.Products
                .Where(p => p.Category == product.Category && p.Id != product.Id)
                .ToList();

            // نختار 2 عشوائيين من نفس الفئة
            var random = new Random();
            var randomProducts = sameCategoryProducts
                .OrderBy(x => random.Next())
                .Take(2)
                .ToList();

            var viewmodel = new ProductDetails
            {
                Product = product,
                First = randomProducts.ElementAtOrDefault(0) ?? new Product(),
                Second = randomProducts.ElementAtOrDefault(1) ?? new Product()
            };

            return View(viewmodel);
        }


        [Authorize(Roles="admin")]
        public IActionResult Edit(int id)
        {
            Product product = context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            var productDto = new ProductDto()
            {
                Name = product.Name,
                Brand = product.Brand,
                Category = product.Category,
                Price = product.Price,
                Description = product.Description,
                Quantity = product.Quantity,
                Proberties = product.Proberties,
                Form = product.Form,
                binfet = product.binfet,
                usage = product.usage,
                productdata = product.productdata,
                SeoTitle = product.SeoTitle,

            };

            ViewData["ProductId"] = product.Id;
            ViewData["ImageFileName"] = product.ImageFileName;
            ViewData["DateTime"] = product.CreatedAt.ToString("MM/dd/yyyy");

            return View(productDto);
        }

        [HttpPost]

        public IActionResult Edit(int id, ProductDto productDto)
        {
            var product = context.Products.Find(id);
            if (product == null)
            {
                return RedirectToAction("Index", "Product");
            }

            if (!ModelState.IsValid)
            {
                ViewData["ProductId"] = product.Id;
                ViewData["ImageFileName"] = product.ImageFileName;
                ViewData["DateTime"] = product.CreatedAt.ToString("MM/dd/yyyy");
                return View(productDto);
            }

            if (productDto.ImageFile != null)
            {
                string nameFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                string extension = Path.GetExtension(productDto.ImageFile.FileName);
                string uploadFolder = Path.Combine(environment.WebRootPath, "Products");

                if (!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }

                string imageFullPath = Path.Combine(uploadFolder, nameFileName + extension);
                using (var fileStream = new FileStream(imageFullPath, FileMode.Create))
                {
                    productDto.ImageFile.CopyTo(fileStream);
                }

                string oldImageFullPath = Path.Combine(uploadFolder, product.ImageFileName);
                if (System.IO.File.Exists(oldImageFullPath))
                {
                    System.IO.File.Delete(oldImageFullPath);
                }

                product.ImageFileName = nameFileName + extension;
            }

            product.Name = productDto.Name;
            product.Brand = productDto.Brand;
            product.Category = productDto.Category;
            product.Price = productDto.Price;
            product.Description = productDto.Description;
            product.Quantity = productDto.Quantity;
            product.Proberties = productDto.Proberties;
            product.Form = productDto.Form;
            product.binfet = productDto.binfet;
            product.usage = productDto.usage;
            product.productdata = productDto.productdata;
            product.SeoTitle = productDto.SeoTitle;

            context.SaveChanges();

            return RedirectToAction("Index", "Product");
        }

        [Authorize(Roles ="admin")]
        public IActionResult Delete(int id)
        {
            var product = context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            string imageFullPath = Path.Combine(environment.WebRootPath, "Products", product.ImageFileName);
            if (System.IO.File.Exists(imageFullPath))
            {
                System.IO.File.Delete(imageFullPath);
            }

            context.Products.Remove(product);
            context.SaveChanges();

            return RedirectToAction("Index", "Product");
        }


       
       
    }
}
