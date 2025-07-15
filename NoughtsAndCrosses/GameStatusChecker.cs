using NoughtsAndCrosses.Interfaces;

namespace NoughtsAndCrosses
{
    /// <summary>
    /// Checks whether the game is a win, draw, loss, or still in play.
    /// </summary>
    public class GameStatusChecker : IGameStatusChecker
    {
        public GameResult CheckGameStatus(IGrid grid)
        {
            grid.SquareValues ??= [];

            foreach (var combination in WinningCombinations.GetCombinations(grid.GridSize))
            {
                string first = grid.SquareValues[combination[0]];
                if (first != " " &&
                    first == grid.SquareValues[combination[1]] &&
                    first == grid.SquareValues[combination[2]])
                {
                    // Determine winner based on symbol
                    return new GameResult
                    {
                        IsOver = true,
                        Result = first == "X" ? ResultType.UserWin : ResultType.ComputerWin
                    };
                }
            }

            // Check for draw: no empty squares left
            bool isDraw = grid.SquareValues.All(s => s != " ");
            if (isDraw)
            {
                return new GameResult
                {
                    IsOver = true,
                    Result = ResultType.Draw
                };
            }

            // Game is not over
            return new GameResult
            {
                IsOver = false,
                Result = ResultType.GameInProgress
            };
        }
    }
    public class GameResult
    {
        public bool IsOver { get; set; }
        public ResultType Result { get; set; }
    }
    public enum ResultType
    {
        GameInProgress=0,
        UserWin = 1,
        ComputerWin = 2,
        Draw = 3
    }
}
