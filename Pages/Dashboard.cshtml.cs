using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WildRealms.Data;

namespace WildRealms.Pages
{
    public class DashboardModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public string Username { get; set; }

        [BindProperty]
        public int GameId { get; set; }

        public DashboardModel(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult OnGet()
        {
            Username = _httpContextAccessor.HttpContext?.Session.GetString("Username");

            if (string.IsNullOrEmpty(Username))
            {
                return RedirectToPage("/Login");
            }

            return Page();
        }

        public IActionResult OnPostCreate()
        {
            Username = _httpContextAccessor.HttpContext?.Session.GetString("Username");

            if (string.IsNullOrEmpty(Username))
                return RedirectToPage("/Login");

            var session = new GameSession { HostUsername = Username };
            _context.GameSessions.Add(session);
            _context.SaveChanges();

            var player = new GamePlayer { Username = Username, GameSessionId = session.Id };
            _context.GamePlayers.Add(player);
            _context.SaveChanges();

            return RedirectToPage("/GameLobby", new { id = session.Id });
        }

        public IActionResult OnPostJoin()
        {
            Username = _httpContextAccessor.HttpContext?.Session.GetString("Username");

            var session = _context.GameSessions.FirstOrDefault(g => g.Id == GameId);
            if (session == null)
            {
                TempData["Error"] = "Partie introuvable.";
                return RedirectToPage();
            }

            bool alreadyJoined = _context.GamePlayers.Any(p => p.GameSessionId == GameId && p.Username == Username);
            if (!alreadyJoined)
            {
                _context.GamePlayers.Add(new GamePlayer
                {
                    Username = Username,
                    GameSessionId = GameId
                });
                _context.SaveChanges();
            }

            return RedirectToPage("/GameLobby", new { id = GameId });
        }
    }
}


