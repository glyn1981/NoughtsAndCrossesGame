using NoughtsAndCrosses.Interfaces;
namespace NoughtsAndCrosses;
public class Grid : IGrid
{
    public List<string>? Squares { get; set; }
    public List<string>? SquareValues { get; set; }
    public int GridSize { get;} = 3; // Default grid size for Tic Tac Toe
    public Grid()
    {
        Squares = [];
        SquareValues = [];
    }

    public void InitializeSquares()
    {
        // Initialize the Squares and SquareValues properties
        Squares =  [ "A1", "B1", "C1", "A2", "B2", "C2", "A3", "B3", "C3" ];
        SquareValues = [.. Enumerable.Repeat(" ", 9)];
    }
}
