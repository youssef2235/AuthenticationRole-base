using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AuthenticationRole_base.Models
{
    public class Article
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } 
        [Required]
        [MaxLength(100)]
        public string Writer { get; set; } 
        [Required]
        public string Category { get; set; }
        [Required]
        public string SEO { get; set; }
        [Required]
        public string Content { get; set; }
        public string? Content2 { get; set; }
        public string? Content3 { get; set; }
        public string? Content4 { get; set; }
        [Required]
        [MaxLength(100)]
        public string ImageFileName { get; set; } 

        public DateTime CreatedAt { get; set; }

        public static implicit operator List<object>(Article v)
        {
            throw new NotImplementedException();
        }

        public static implicit operator Article(List<Article> v)
        {
            throw new NotImplementedException();
        }
    }
}
