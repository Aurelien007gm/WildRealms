using Microsoft.AspNetCore.Mvc;
using WildRealms.Data;

namespace WildRealms.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Vérifie si l'utilisateur est connecté
        /// </summary>
        [HttpGet("check-session")]
        public IActionResult CheckSession()
        {
            var username = HttpContext.Session.GetString("Username");
            if (username != null)
            {
                return Ok(new { loggedIn = true, username });
            }
            return Ok(new { loggedIn = false });
        }

        /// <summary>
        /// Déconnecte l'utilisateur
        /// </summary>
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Ok(new { message = "Déconnexion réussie." });
        }
    }
}

