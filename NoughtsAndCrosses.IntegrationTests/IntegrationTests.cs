using NoughtsAndCrosses.Interfaces;
namespace NoughtsAndCrosses.IntegrationTests;
public class FakeGameLogic(IEnumerable<GameResult> results) : IGameLogic
{
    private readonly Queue<GameResult> _results = new Queue<GameResult>(results);

    public GameResult Play()
    {
        return _results.Count > 0 ? _results.Dequeue() : new GameResult { IsOver = true, Result = ResultType.Draw };
    }
}

public class FakeInputOutput(IEnumerable<string> inputs) : IInputOutput
{
    private readonly Queue<string> _inputs = new Queue<string>(inputs);

    public List<string> Outputs { get; } = [];

    public string GatherInput(string message)
    {
        Outputs.Add(message);
        return _inputs.Count > 0 ? _inputs.Dequeue() : "N";
    }

    public void RenderOutput(string output) => Outputs.Add(output);
    public void RenderLine(string output) => Outputs.Add(output);
}

public class GameSessionIntegrationTests
{
    [Fact]
    public void GameSession_TracksScoresAndRendersInfo()
    {
        // Arrange: 1 user win, 1 computer win, 1 draw, then stop  
        var results = new[]
        {
           new GameResult { IsOver = true, Result = ResultType.UserWin },
           new GameResult { IsOver = true, Result = ResultType.ComputerWin },
           new GameResult { IsOver = true, Result = ResultType.Draw }
       };
        var inputs = new[] { "Y", "Y", "N" }; // Continue twice, then stop  
        var io = new FakeInputOutput(inputs);
        var logic = new FakeGameLogic(results);
        var session = new GameSession(io, logic);

        // Act  
        session.BeginGameSession();

        // Assert: Check that scores were rendered  
        Assert.Contains("User Wins: 1", io.Outputs);
        Assert.Contains("Computer Wins: 1", io.Outputs);
        Assert.Contains("Draws: 1", io.Outputs);
        // Check that continue prompt was shown  
        Assert.Equal(3, io.Outputs.FindAll(o => o.Contains("Do you want to continue?")).Count);
    }

    [Fact]
    public void GameSession_ExitsImmediately_WhenUserSaysNo()
    {
        var results = new[] { new GameResult { IsOver = true, Result = ResultType.UserWin } };
        var inputs = new[] { "N" }; // User says no immediately
        var io = new FakeInputOutput(inputs);
        var logic = new FakeGameLogic(results);
        var session = new GameSession(io, logic);

        session.BeginGameSession();

        // Assert: No scores should be rendered
        Assert.DoesNotContain("User Wins: 1", io.Outputs);
        Assert.Contains("Do you want to continue?", io.Outputs);
    }
}
