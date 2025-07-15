using NoughtsAndCrosses.Interfaces;
namespace NoughtsAndCrosses.Test
{
    public class TurnValidatorTests
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
        public void IsValidTurn_ReturnsTrue_ForValidEmptySquare()
        {
            var grid = new TestGrid
            {
                Squares = ["A1", "B1", "C1"],
                SquareValues = [" ", "X", "O"]
            };

            Assert.True(TurnValidator.IsValidTurn(grid, "A1"));
        }

        [Fact]
        public void IsValidTurn_ReturnsFalse_ForOccupiedSquare()
        {
           var grid = new TestGrid
           {
               Squares = ["A1", "B1", "C1"],
               SquareValues = ["X", " ", "O"]
           };

            Assert.False(TurnValidator.IsValidTurn(grid, "A1"));
        }

        [Fact]
        public void IsValidTurn_ReturnsFalse_ForNonExistentSquare()
        {
            var grid = new TestGrid
            {
                Squares = ["A1", "B1", "C1"],
                SquareValues = [" ", " ", " "]
            };

            Assert.False(TurnValidator.IsValidTurn(grid, "D1"));
        }

        [Fact]
        public void IsValidTurn_ReturnsFalse_IfSquaresIsNull()
        {
            var grid = new TestGrid
            {
                Squares = null,
                SquareValues = [" ", " ", " "]
            };

            Assert.False(TurnValidator.IsValidTurn(grid, "A1"));
        }

        [Fact]
        public void IsValidTurn_ReturnsFalse_IfSquareValuesIsNull()
        {
            var grid = new TestGrid
            {
                Squares = ["A1", "B1", "C1"],
                SquareValues =null
            };

            Assert.False(TurnValidator.IsValidTurn(grid, "A1"));
        }
    }
}