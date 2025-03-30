using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WildRealms.Data;
using WildRealms.Models;

namespace WildRealms.Pages
{

    public class CreateAccountModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateAccountModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string PasswordHash { get; set; }

        public IActionResult OnPost()
        {

            try {
                if (_context.Users.Any(u => u.Username == Username))
                {
                    // If the username already exists, return an error
                    ModelState.AddModelError("Username", "Un utilisateur avec ce login existe d�ja.");
                    return Page();
                }

                var user = new User
                {
                    Username = Username,
                    PasswordHash = PasswordHash // Save the hashed password
                };

                _context.Users.Add(user);
                _context.SaveChanges();

                // Redirect to a success page
                return RedirectToPage("/AccountCreated", new { user = Username });
            }catch
            {
                ModelState.AddModelError("", "Une erreur s'est produite.");
                return Page();
            }
            
        }
    }

}

