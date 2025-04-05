using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WildRealms.Data;
using WildRealms.Models;

namespace WildRealms.Pages
{

    public class LoginModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LoginModel(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor; // Injection du HttpContextAccessor
        }

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string PasswordHash { get; set; }

        public IActionResult OnPost()
        {

            try
            {
                if (PasswordHash == null)
                {
                    // If the username already exists, return an error
                    ModelState.AddModelError("Password", "Veuillez entrer un mot de passe");
                    return Page();
                }

                if (_context.Users.Any(u => u.Username == Username))
                {
                    if (PasswordHash == _context.Users.FirstOrDefault(u => u.Username == Username).PasswordHash)
                    {
                        HttpContext.Session.SetString("Username", Username);
                        return RedirectToPage("/Dashboard", new { user = Username });
                    }
                }
                ModelState.AddModelError("Username", "La connexion a echouer");
                return Page();

            }
            catch
            {
                ModelState.AddModelError("", "Une erreur s'est produite.");
                return Page();
            }
            
        }
    }

}

