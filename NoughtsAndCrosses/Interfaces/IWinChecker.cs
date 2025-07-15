namespace NoughtsAndCrosses.Interfaces
{
    public interface IGameStatusChecker
    {
        GameResult CheckGameStatus(IGrid grid);
    }
}