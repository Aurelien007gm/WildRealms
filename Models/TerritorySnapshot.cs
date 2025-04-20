using System.ComponentModel.DataAnnotations;

namespace WildRealms.Models
{
    public class TerritorySnapshot
    {
        [Key]
        public int Id { get; set; }

        public int TerritoryId { get; set; }

        [Required]
        public GameSnapshot Snapshot { get; set; } = null!;

        public int OwnerId { get; set; }

        public int NumberTroopDeployed { get; set; }

        public TerritorySnapshot() { }

        public TerritorySnapshot(GameSnapshot snapshot)
        {
            Snapshot = snapshot;
        }
        public void PrintGame()
        {
            Console.WriteLine($"Printing territory{Id}");
            Console.WriteLine($"Owned by {OwnerId}");
        }
    }
}
