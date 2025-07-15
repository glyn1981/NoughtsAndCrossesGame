namespace NoughtsAndCrosses.Interfaces
{
    public interface ITurnManager
    {
        string CurrentPlayer { get; }

        void NextTurn();
        void SetupPlayers(List<string> players);
    }
}