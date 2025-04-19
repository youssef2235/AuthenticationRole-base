using AuthenticationRole_base.Models;

namespace BlueGreenEG.ViewModels
{
    public class ArticleDetails
    {
        public Article Articles { get; set; } = new Article();
        public Article First { get; set; } = new Article();
        public Article Second { get; set; } = new Article();

      
    }
}
