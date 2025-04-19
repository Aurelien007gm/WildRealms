

public class GamePlayer
{
    public int Id { get; set; }

    public int IdInGame { get; set; }   
    public int GameSessionId { get; set; }
    public GameSession GameSession { get; set; }

    public required string Username { get; set; }
}
