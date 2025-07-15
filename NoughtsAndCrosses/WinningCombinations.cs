namespace NoughtsAndCrosses
{
    public static class WinningCombinations
    {
        public static List<List<int>> GetCombinations(int gridSize)
        {
            ////returns a list of the possible combinations, based on the grid size.
            List<List<int>> combinations = [];

            ////rows
            for (int row = 0; row < gridSize; row++)
            {
                var rowCombo = new List<int>();
                for (int col = 0; col < gridSize; col++)
                {
                    rowCombo.Add((row * gridSize) + col);
                }
                combinations.Add(rowCombo);
            }

            ////columns
            for (int col = 0; col < gridSize; col++)
            {
                var colCombo = new List<int>();
                for (int row = 0; row < gridSize; row++)
                {
                    colCombo.Add((row * gridSize) + col);
                }
                combinations.Add(colCombo);
            }

            ////main diagonal
            var mainDiagonal = new List<int>();
            for (int i = 0; i < gridSize; i++)
            {
                mainDiagonal.Add((i * gridSize) + i);
            }
            combinations.Add(mainDiagonal);

            ////anti-diagonal
            var antiDiagonal = new List<int>();
            for (int i = 0; i < gridSize; i++)
            {
                antiDiagonal.Add((i * gridSize) + (gridSize - 1 - i));
            }
            combinations.Add(antiDiagonal);

            return combinations;
        }
    }
}
