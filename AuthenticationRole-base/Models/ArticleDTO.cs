using System.ComponentModel.DataAnnotations;

namespace BlueGreenEG.Models
{
    public class ArticleDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Writer { get; set; }
        public string WriterJob { get; set; }
        public string Category { get; set; }
        public string SEO { get; set; }
        public string Content { get; set; }
       
        public IFormFile? ImageFile { get; set; }

    }
}
