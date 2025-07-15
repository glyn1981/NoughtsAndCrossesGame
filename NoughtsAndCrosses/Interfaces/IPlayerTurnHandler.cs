namespace NoughtsAndCrosses.Interfaces
{
    public interface IPlayerTurnHandler
    {
        void HandlePlayersTurn(string player, IGrid grid);
    }
}