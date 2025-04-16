using System.ComponentModel.DataAnnotations;

namespace AuthenticationRole_base.Models
{
    public class ProductDto
    {
        public int Id { get; set; }
        
        public string Name { get; set; } 
        
        public string Brand { get; set; } 
        
        public string Category { get; set; } 
        
        public double Price { get; set; }
        
        public string Description { get; set; } 
       
        public int Quantity { get; set; }
        public string Proberties { get; set; } = "";
        public string Form { get; set; } = "";
        public string binfet { get; set; } = "";
        public string usage { get; set; } = "";
        public string productdata { get; set; } = "";

        public string SeoTitle { get; set; } = "";

        public IFormFile? ImageFile { get; set; }
    }
}
