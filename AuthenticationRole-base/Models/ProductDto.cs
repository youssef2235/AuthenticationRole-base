﻿using System.ComponentModel.DataAnnotations;

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
       
        public int Pages { get; set; }

        public IFormFile? ImageFile { get; set; }
    }
}
