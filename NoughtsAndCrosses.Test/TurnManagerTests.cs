namespace NoughtsAndCrosses.Test;
public class TurnManagerTests
{
    [Fact]
    public void Constructor_SetsInitialPlayersAndCurrentPlayer()
    {
        var players = new List<string> { "X", "O" };
        var turnManager = new TurnManager(players);

        Assert.Equal("X", turnManager.CurrentPlayer);
    }

    [Fact]
    public void NextTurn_CyclesToNextPlayer()
    {
        var players = new List<string> { "X", "O" };
        var turnManager = new TurnManager(players);

        turnManager.NextTurn();
        Assert.Equal("O", turnManager.CurrentPlayer);

        turnManager.NextTurn();
        Assert.Equal("X", turnManager.CurrentPlayer); // Should wrap around
    }

    [Fact]
    public void SetupPlayers_ResetsPlayersAndCurrentIndex()
    {
        var players = new List<string> { "A", "B", "C" };
        var turnManager = new TurnManager(players);

        turnManager.SetupPlayers(players);
        Assert.Equal("A", turnManager.CurrentPlayer); // Should reset to first of new list
        turnManager.NextTurn();
        Assert.Equal("B", turnManager.CurrentPlayer);
        turnManager.NextTurn();
        Assert.Equal("C", turnManager.CurrentPlayer);
        turnManager.NextTurn();
        Assert.Equal("A", turnManager.CurrentPlayer); // Should wrap around
    }

    [Fact]
    public void NextTurn_WithSinglePlayer_AlwaysReturnsSamePlayer()
    {
        var players = new List<string> { "X" };
        var turnManager = new TurnManager(players);

        Assert.Equal("X", turnManager.CurrentPlayer);
        turnManager.NextTurn();
        Assert.Equal("X", turnManager.CurrentPlayer);
    }
}