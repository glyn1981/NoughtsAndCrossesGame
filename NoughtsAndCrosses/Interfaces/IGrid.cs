namespace NoughtsAndCrosses.Interfaces
{
    public interface IGrid
    {
        List<string>? Squares { get; set; }
        List<string>? SquareValues { get; set; }
        int GridSize { get; }
        void InitializeSquares();
    }
}