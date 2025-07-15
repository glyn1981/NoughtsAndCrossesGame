using NoughtsAndCrosses.Interfaces;

namespace NoughtsAndCrosses
{
    /// <summary>
    /// AI Opponent for Noughts and Crosses (Tic Tac Toe).
    /// </summary>
    /// <remarks>
    /// Constructor for AiOpponent.
    /// </remarks>
    /// <param name="gridRenderer">Grid renderer interface.</param>
    public class AiOpponent(IGridRenderer gridRenderer) : IAiOpponent
    {
        private readonly IGridRenderer _gridRenderer = gridRenderer;
        private readonly string Player = "X"; // Human player symbol.
        private readonly string Opponent = "O"; // AI player symbol.
        /// <summary>
        /// Make a move for the AI opponent based on the current grid state.
        /// </summary>
        /// <param name="grid">Grid Interface</param>
        public void MakeMove(IGrid grid)
        {
            if (grid.SquareValues == null || grid.Squares == null)
                return;

            //// 1.try to win
            foreach (var combo in WinningCombinations.GetCombinations(grid.GridSize))
            {
                if (CheckWinningCombo(combo, grid))
                    return;
            }

            //// 2. try to block the player
            foreach (var combo in WinningCombinations.GetCombinations(grid.GridSize))
            {
                if (TryCompleteLine(combo, grid, Player)) //try to block player
                    return;
            }

            //// otherwise, pick the first available square  
            for (int i = 0; i < grid.SquareValues.Count; i++)
            {
               //tries to occupy the avaliable square, returns true when occupied
               if( PickFirstAvaliableSquare(grid, i))
                {
                    break;
                }
            }
        }

        // Tries to complete a line for the given symbol (either AI or player)
        private bool TryCompleteLine(List<int> combo, IGrid grid, string symbol)
        {
            if (grid == null || grid.SquareValues == null || grid.Squares == null)
                return false;

            int symbolCount = 0;
            int emptyIndex = -1;
            foreach (var idx in combo)
            {
                if (grid.SquareValues[idx] == symbol)
                    symbolCount++;
                else if (grid.SquareValues[idx] == " ")
                    emptyIndex = idx;
            }
            if (symbolCount == 2 && emptyIndex != -1)
            {
                grid.SquareValues[emptyIndex] = Opponent;
                _gridRenderer.RenderGrid(grid);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Check if the AI can win with the current move.
        /// </summary>
        /// <param name="combo">a list of the currently occupied squares.</param>
        /// <param name="grid">the grid</param>
        /// <returns>true when ai can make one move and win.</returns>
        private bool CheckWinningCombo(List<int> combo, IGrid grid)
        {
            if (grid == null || grid.SquareValues == null || grid.Squares == null)
                return false;

            int opponentCount = 0;
            int emptyIndex = -1;
            foreach (var idx in combo)
            {
                if (grid.SquareValues[idx] == Opponent)
                    opponentCount++;
                else if (grid.SquareValues[idx] == " ")
                    emptyIndex = idx;
            }
            if (opponentCount == 2 && emptyIndex != -1)
            {
                grid.SquareValues[emptyIndex] = Opponent;
                _gridRenderer.RenderGrid(grid);
                return true;
            }

            return false;
        }
        /// <summary>
        /// Pick the first available square for the AI opponent.
        /// </summary>
        /// <param name="grid">the grid</param>
        /// <param name="i">the square number </param>
        private bool PickFirstAvaliableSquare(IGrid grid, int i)
        {
            if (grid.SquareValues == null || grid.Squares == null)
                return false;

            if (grid.SquareValues[i] == " ")
            {
                grid.SquareValues[i] = Opponent;
                _gridRenderer.RenderGrid(grid);
                return true;
            }

            return false;
        }
    }
}