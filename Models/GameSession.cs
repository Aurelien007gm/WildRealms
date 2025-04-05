public class GameSession
{
    public int Id { get; set; } // Auto-incrémenté = ID de la partie
    public string HostUsername { get; set; } // Créateur de la partie
    public List<GamePlayer> Players { get; set; } = new();
}