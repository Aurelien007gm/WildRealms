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
            if (_context.Users.Any(u => u.Username == Username))
            {
                // If the username already exists, return an error
                return RedirectToPage("/AccountCreated", new { user = "Already existing lol" });
                //ModelState.AddModelError("", "Username already exists.");
                //return Page();
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
        }
    }

}

