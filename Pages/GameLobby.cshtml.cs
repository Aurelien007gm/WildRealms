using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WildRealms.Data;

namespace WildRealms.Pages
{
    public class GameLobbyModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public List<GamePlayer> Players { get; set; } = new();
        public int GameId { get; set; }

        public GameLobbyModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int id)
        {
            GameId = id;
            Players = _context.GamePlayers
                        .Where(p => p.GameSessionId == id)
                        .ToList();

            if (!Players.Any())
            {
                return RedirectToPage("/Dashboard");
            }

            return Page();
        }
    }

}
