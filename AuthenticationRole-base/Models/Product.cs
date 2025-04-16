using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AuthenticationRole_base.Models
{
    public class Product
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; } = "";
        [MaxLength(100)]
        public string Brand { get; set; } = "";
        [MaxLength(100)]
        public string Category { get; set; } = "";
        [Precision(16, 2)]
        public double Price { get; set; }
        public string Description { get; set; } = "";
        public int Quantity { get; set; }

        public string? Proberties { get; set; } = "";
        public string? Form { get; set; } = "";
        public string? binfet { get; set; } = "";
        public string? usage { get; set; } = "";
        public string? productdata { get; set; } = "";

        public string? SeoTitle { get; set; } = "";

        [MaxLength(100)] 
        public string ImageFileName { get; set; } = "";

        public DateTime CreatedAt { get; set; }
    }
}
