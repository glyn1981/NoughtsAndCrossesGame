namespace NoughtsAndCrosses.Test;
public class GridTests
{
    [Fact]
    public void Constructor_InitializesEmptyLists()
    {
        var grid = new Grid();
        Assert.NotNull(grid.Squares);
        Assert.NotNull(grid.SquareValues);
        Assert.Empty(grid.Squares);
        Assert.Empty(grid.SquareValues);
    }

    [Fact]
    public void InitializeSquares_SetsSquaresAndValuesCorrectly()
    {
        var grid = new Grid();
        grid.InitializeSquares();

        var expectedSquares = new[] { "A1", "B1", "C1", "A2", "B2", "C2", "A3", "B3", "C3" };
        Assert.Equal(expectedSquares, grid.Squares);
        Assert.Equal(9, grid.SquareValues?.Count);

        if (grid.SquareValues != null)
        {
            Assert.All(grid.SquareValues, v => Assert.Equal(" ", v));
        }
    }

    [Fact]
    public void GridSize_IsThree()
    {
        var grid = new Grid();
        Assert.Equal(3, grid.GridSize);
    }
}