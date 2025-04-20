using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WildRealms.Data;

namespace WildRealms.Pages
{
    public class GameLobbyModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public List<GamePlayer> Players { get; set; } = new();
        [BindProperty]
        public int GameSessionId { get; set; }

        public GameLobbyModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int gameSessionId)
        {
            GameSessionId = gameSessionId;
            Players = _context.GamePlayers
                        .Where(p => p.GameSessionId == gameSessionId)
                        .ToList();

            if (!Players.Any())
            {
                return RedirectToPage("/Dashboard");
            }

            return Page();
        }

        public IActionResult OnPostValider()
        {
            try
            {
                Players = _context.GamePlayers
                        .Where(p => p.GameSessionId == GameSessionId)
                        .ToList();
                GameSession session = _context.GameSessions.First(x => x.Id == GameSessionId);
                session.Players = Players;
                _context.Update(session);
                _context.SaveChanges();
                Game game = new Game(session);
                _context.Update(game);
                _context.SaveChanges();
                return RedirectToPage("/GameBoard", new { id = session.Id });
            }
            catch
            {
                return Page();
            }
            
        }
    }

}
