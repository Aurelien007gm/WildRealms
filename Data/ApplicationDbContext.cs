using Microsoft.EntityFrameworkCore;
using WildRealms.Models;

namespace WildRealms.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<GameSession> GameSessions { get; set; }
        public DbSet<GamePlayer> GamePlayers { get; set; }

    }
}

