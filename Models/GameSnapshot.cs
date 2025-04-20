using System;
using System.ComponentModel.DataAnnotations;

namespace WildRealms.Models
{
    public class GameSnapshot
    {
        [Key]
        public int Id { get; set; }

        public int Turn { get; set; }

        public int GameId { get; set; }

        [Required]
        public Game Game { get; set; } = null!;

        [Required]
        public List<TerritorySnapshot> TerritorySnapshots { get; set; } = new();

        public GameSnapshot() { }

        public GameSnapshot(Game game)
        {
            Game = game;
        }

        public void PrintGame()
        {
            Console.WriteLine($"Printing game snapshot{Id}");
            Console.WriteLine($"Turn : {Turn}");
            foreach( TerritorySnapshot t in TerritorySnapshots)
            {
                t.PrintGame();
            }
        }
        
    }
}