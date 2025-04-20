using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WildRealms.Data;

namespace WildRealms.Pages
{
    public class GameBoardModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public List<GamePlayer> Players { get; set; } = new();
        public int GameSessionId { get; set; }

        public GameBoardModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int id)
        {
            GameSessionId = id;
            Players = _context.GamePlayers
                        .Where(p => p.GameSessionId == id)
                        .ToList();

            if (!Players.Any())
            {
                return RedirectToPage("/Dashboard");
            }

            return Page();
        }

        public IActionResult Valider()
        {
            Players = _context.GamePlayers
                        .Where(p => p.GameSessionId == GameSessionId)
                        .ToList();
            GameSession session = new GameSession();
            foreach (GamePlayer player in Players)
            {
                session.Players.Add(player);
            }
            _context.Update(session);
            _context.SaveChanges();
            Game game = new Game(session);
            _context.Update(game);
            _context.SaveChanges();
            return RedirectToPage("/Gameboard");
        }
    }

}
