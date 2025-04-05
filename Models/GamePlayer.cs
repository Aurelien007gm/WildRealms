public class GamePlayer
{
    public int Id { get; set; }
    public int GameSessionId { get; set; }
    public GameSession GameSession { get; set; }

    public string Username { get; set; }
}
