using AuthenticationRole_base.Models;

namespace BlueGreenEG.ViewModels
{
    public class ArticleDetails
    {
        public Article Articles { get; set; } = new Article();
        public List<Article> relatedArticles { get; set; }
       

      
    }
}
