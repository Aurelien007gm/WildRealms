using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WildRealms.Data;
using WildRealms.Models;

public class Game
{

    [Key]
    public int Id { get; set; } // Auto-incrémenté = ID de la partie

    [Required]
    public int GameSessionId { get; set; } // Clé étrangère vers GameSession

    [ForeignKey(nameof(GameSessionId))]
    public GameSession GameSession { get; set; } = null!;



    public List<GameSnapshot> GameSnapshots { get; set; } = new();

    [NotMapped]
    public List<TerritorySnapshot> TerritorySnapshots { get; set; } = new();

    public Game(GameSession gameSession)
    {

        GameSession = gameSession;
        gameSession.Game = this;
        GameSessionId = gameSession.Id;
    }

    public Game() { }



    public void InitiateGame()
    {
        int _nbTerritory = 45; // A revoir
        int _nbPlayer = GameSession.Players.Count; // A revoir
        GameSnapshot gameSnapshot = new GameSnapshot(this);
        for (int i = 0; i < _nbTerritory; i++)
        {
            TerritorySnapshot territory = new TerritorySnapshot(gameSnapshot);
            territory.TerritoryId = i;
            territory.OwnerId = i % _nbPlayer;
            gameSnapshot.TerritorySnapshots.Add(territory);
        }
        GameSnapshots.Add(gameSnapshot);
    }

    public void PrintGame()
    {
        Console.WriteLine($"Printing game{this.Id}");
        foreach (GameSnapshot gameSnapshot in GameSnapshots) {
            Console.WriteLine($"Printing game{this.Id}");
            gameSnapshot.PrintGame();
        }
    }
}
