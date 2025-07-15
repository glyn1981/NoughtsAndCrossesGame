using NoughtsAndCrosses.Interfaces;

namespace NoughtsAndCrosses
{
    public class GridRenderer(IInputOutput inputOutput) : IGridRenderer
    {
        private readonly IInputOutput _inputOutput = inputOutput;

        public void RenderGrid(IGrid _Grid)
        {
            Console.Clear();

            // Render the grid based on SquareValues
            _inputOutput.RenderLine("   A   B   C");

            for (int row = 0; row < 3; row++)
            {
                _inputOutput.RenderOutput($"{row + 1} ");

                for (int col = 0; col < 3; col++)
                {
                    int idx = (row * 3) + col;

                    if (_Grid.SquareValues != null)
                    {
                        _inputOutput.RenderOutput($" {_Grid.SquareValues[idx]} ");
                    }

                    if (col < 2) _inputOutput.RenderOutput("|");
                }
                Console.WriteLine();
                if (row < 2) _inputOutput.RenderLine("  ---+---+---");
            }
        }
    }
}
