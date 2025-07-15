using NoughtsAndCrosses.Interfaces;
namespace NoughtsAndCrosses
{
    //validate that the turn is valid
    public static class TurnValidator
    {
        public static bool IsValidTurn(IGrid grid, string reference)
        {
            //validate that Ref is a valid square in the grid   
            if (grid.Squares == null || grid.SquareValues == null)
                return false;

            //validate that the square is empty
            if (grid.Squares.IndexOf(reference) == -1)
                return false;
            //validate that the square is empty
            if (grid.SquareValues[grid.Squares.IndexOf(reference)] != " ")
                return false;
            return true;
        }
    }
}
