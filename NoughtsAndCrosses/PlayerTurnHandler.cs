using NoughtsAndCrosses.Interfaces;
using System.Security.Cryptography;

namespace NoughtsAndCrosses
{
    public class PlayerTurnHandler(IInputOutput io,  IGridRenderer gridRenderer) : IPlayerTurnHandler
    {
        private readonly IInputOutput _io = io;

        public void HandlePlayersTurn(string player, IGrid grid)
        {
            string? input;
            while (true)
            {
                input = _io.GatherInput($"Player {player}, enter your move (e.g., A1): ");
                if (TurnValidator.IsValidTurn(grid, input))
                {
                    break;
                }
                _io.RenderOutput("Invalid move, try again.");
            }

            if ((grid.Squares, grid.SquareValues) is (not null, not null))
            {
                if (grid.Squares.Contains(input) && grid.SquareValues[grid.Squares.IndexOf(input)] == " ")
                {
                    grid.SquareValues[grid.Squares.IndexOf(input)] = player;
                    gridRenderer.RenderGrid(grid);
                }
                else
                {
                    _io.RenderOutput("Invalid move, try again.");
                }
            }
        }
    }
}
