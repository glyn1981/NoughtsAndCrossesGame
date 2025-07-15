using NoughtsAndCrosses.Interfaces;
namespace NoughtsAndCrosses.Test
{
    public class MockGridRenderer : IGridRenderer
    {
        public bool WasCalled { get; private set; }
        public IGrid? LastGrid { get; private set; }
        public void RenderGrid(IGrid grid)
        {
            WasCalled = true;
            LastGrid = grid;
        }
    }

    public class AiOpponentTests
    {
        private class TestGrid : IGrid
        {
            public List<string>? Squares { get; set; }
            public List<string>? SquareValues { get; set; }
            public int GridSize { get; set; } = 3;
            public void InitializeSquares() { }
        }

        [Fact]
        public void MakeMove_WinsIfPossible()
        {
            // Arrange: AI ("O") has two in a row, can win at index 2
            var grid = new TestGrid
            {
                Squares = ["A1", "B1", "C1", "A2", "B2", "C2", "A3", "B3", "C3"],
                SquareValues = ["O", "O", " ", "X", "X", " ", " ", " ", " "]
            };
            var renderer = new MockGridRenderer();
            var ai = new AiOpponent(renderer);

            // Act
            ai.MakeMove(grid);

            // Assert: AI wins at index 2
            Assert.Equal("O", grid.SquareValues[2]);
            Assert.True(renderer.WasCalled);
        }

        [Fact]
        public void MakeMove_BlocksOpponentWin()
        {
            // Arrange: Player ("X") has two in a row, AI should block at index 2
            var grid = new TestGrid
            {
                Squares = ["A1", "B1", "C1", "A2", "B2", "C2", "A3", "B3", "C3"],
                SquareValues = ["X", "X", " ", "O", " ", " ", " ", " ", " "]
            };
            var renderer = new MockGridRenderer();
            var ai = new AiOpponent(renderer);

            // Act
            ai.MakeMove(grid);

            // Assert: AI blocks at index 2
            Assert.Equal("O", grid.SquareValues[2]);
            Assert.True(renderer.WasCalled);
        }

        [Fact]
        public void MakeMove_PicksFirstAvailable_WhenNoWinOrBlock()
        {
            // Arrange: No immediate win or block, first empty is index 0
            var grid = new TestGrid
            {
                Squares = ["A1", "B1", "C1", "A2", "B2", "C2", "A3", "B3", "C3"],
                SquareValues = [" ", "X", "O", "X", "O", " ", " ", " ", " "]
            };
            var renderer = new MockGridRenderer();
            var ai = new AiOpponent(renderer);

            // Act
            ai.MakeMove(grid);

            // Assert: AI picks first available
            Assert.Equal("O", grid.SquareValues[0]);
            Assert.True(renderer.WasCalled);
        }

        [Fact]
        public void MakeMove_DoesNothing_WhenGridIsFull()
        {
            // Arrange: No empty squares
            var grid = new TestGrid
            {
                Squares = ["A1", "B1", "C1", "A2", "B2", "C2", "A3", "B3", "C3"],
                SquareValues = ["X", "O", "X", "O", "X", "O", "O", "X", "O"]
            };
            var renderer = new MockGridRenderer();
            var ai = new AiOpponent(renderer);

            // Act
            ai.MakeMove(grid);

            // Assert: No move, so no render
            Assert.False(renderer.WasCalled);
        }
    }
}