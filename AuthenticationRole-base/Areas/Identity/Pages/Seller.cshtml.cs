using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AuthenticationRole_base.Areas.Identity.Pages
{
    [Authorize(Roles = "seller")]

    public class SellerModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
