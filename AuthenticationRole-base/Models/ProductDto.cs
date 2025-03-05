using System.ComponentModel.DataAnnotations;

namespace AuthenticationRole_base.Models
{
    public class ProductDto
    {
        [Required]
        public string Name { get; set; } = "";
        [Required]
        public string Brand { get; set; } = "";
        [Required]
        public string Category { get; set; } = "";
        [Required]
        public double Price { get; set; }
        [Required]
        public string Description { get; set; } = "";
        [Required]
        public int Pages { get; set; }

        public IFormFile? ImageFile { get; set; }
    }
}
