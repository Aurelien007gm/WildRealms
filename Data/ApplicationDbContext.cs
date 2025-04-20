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

        public DbSet<Game> Games { get; set; }

        public DbSet<GameSnapshot> GameSnapshot { get; set; }

        public DbSet<TerritorySnapshot> TerritorySnapshot { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Game>()
                .HasOne(g => g.GameSession)
                .WithOne(gs => gs.Game)
                .HasForeignKey<Game>(g => g.GameSessionId);

            modelBuilder.Entity<GameSession>()
                .HasOne(gs => gs.Game)
                .WithOne(g=>g.GameSession)
                .HasForeignKey<GameSession>(gs => gs.GameId)
                .IsRequired(false);
        }

    }
}

