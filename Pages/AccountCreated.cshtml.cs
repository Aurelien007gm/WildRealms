using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WildRealms.Pages
{
    public class AccountCreatedModel : PageModel
    {
        public string User { get; set; }

        public void OnGet(string user)
        {
            User = user;
        }
    }
}

