using AuthenticationRole_base.Models;

namespace BlueGreenEG.ViewModels
{
    public class ProductDetails
    {

        public Product Product { get; set; } = new Product();

        public Product First { get; set; } = new Product();
        public Product Second { get; set; } = new Product();


    }
}
