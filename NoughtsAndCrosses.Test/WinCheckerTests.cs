using NoughtsAndCrosses.Interfaces;
namespace NoughtsAndCrosses.Test;
public class WinCheckerTests
{
    // Simple mock for IGrid
    private class TestGrid : IGrid
    {
        public List<string>? Squares { get; set; }
        public List<string>? SquareValues { get; set; }
        public int GridSize { get; set; } = 3;
        public void InitializeSquares() { }
    }

    [Fact]
    public void CheckForWin_UserWin_Row()
    {
        var grid = new TestGrid
        {
            Squares = ["A1", "B1", "C1", "A2", "B2", "C2", "A3", "B3", "C3"],
            SquareValues = [ "X", "X", "X", " ", "O", " ", "O", " ", " " ]
        };
        var checker = new GameStatusChecker();
        var result = checker.CheckGameStatus(grid);

        Assert.True(result.IsOver);
        Assert.Equal(ResultType.UserWin, result.Result);
    }

    [Fact]
    public void CheckForWin_ComputerWin_Column()
    {
        var grid = new TestGrid
        {
            Squares = ["A1", "B1", "C1", "A2", "B2", "C2", "A3", "B3", "C3"],
            SquareValues =["O", "X", "X", "O", "X", " ", "O", " ", " " ]
        };
        var checker = new GameStatusChecker();
        var result = checker.CheckGameStatus(grid);

        Assert.True(result.IsOver);
        Assert.Equal(ResultType.ComputerWin, result.Result);
    }

    [Fact]
    public void CheckForWin_Draw()
    {
        var grid = new TestGrid
        {
            Squares = ["A1", "B1", "C1", "A2", "B2", "C2", "A3", "B3", "C3"],
            SquareValues = [ "X", "O", "X", "X", "O", "O", "O", "X", "X" ]
        };
        var checker = new GameStatusChecker();
        var result = checker.CheckGameStatus(grid);

        Assert.True(result.IsOver);
        Assert.Equal(ResultType.Draw, result.Result);
    }

    [Fact]
    public void CheckForWin_GameNotOver()
    {
        var grid = new TestGrid
        {
            Squares = ["A1", "B1", "C1", "A2", "B2", "C2", "A3", "B3", "C3"],
            SquareValues = [ "X", "O", "X", " ", "O", " ", "O", " ", " " ]
        };
        var checker = new GameStatusChecker();
        var result = checker.CheckGameStatus(grid);

        Assert.False(result.IsOver);
    }
}