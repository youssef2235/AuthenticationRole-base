using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AuthenticationRole_base.Models
{
    public class Article
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } 
        [MaxLength(100)]
        public string? Writer { get; set; } 
        public string? Category { get; set; }
        public string? SEO { get; set; }
        public string? Content { get; set; }

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
