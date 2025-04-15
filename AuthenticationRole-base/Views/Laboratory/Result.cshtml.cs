// Products.cshtml.cs
/*
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using AuthenticationRole_base.Models;
using Microsoft.EntityFrameworkCore;
using AuthenticationRole_base.Services;

public class ProductsModel : PageModel
{
    private readonly ApplicationDbContext _context;

    // هذا السطر مهم - يتم استخدام Model بدلًا من Products
    public new List<Product> Model { get; set; }

    public ProductsModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task OnGetAsync()
    {
        Model = await _context.Products.ToListAsync();
    }
}
*/