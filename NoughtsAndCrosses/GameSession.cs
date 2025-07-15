using NoughtsAndCrosses.Interfaces;

namespace NoughtsAndCrosses
{
    public class GameSession(IInputOutput io, IGameLogic gameLogic) : IGameSession
    {
        private int userWins = 0;
        private int computerWins = 0;
        private int draws = 0;
        private readonly IInputOutput _inputOutput = io;
        private readonly IGameLogic _gameLogic = gameLogic;

        public void BeginGameSession()
        {
            do
            {
                GameResult result = _gameLogic.Play();

                switch (result.Result)
                {
                    case ResultType.UserWin:
                        Console.WriteLine("Congratulations! You win!");
                        userWins++;
                        break;
                    case ResultType.ComputerWin:
                        Console.WriteLine("The AI wins! Better luck next time.");
                        computerWins++;
                        break;
                    case ResultType.Draw:
                        Console.WriteLine("It's a draw!");
                        draws++;
                        break;
                    default:
                        throw new InvalidOperationException("Unexpected game result.");
                }
                RenderGameInfo();
            }
            while (_inputOutput.GatherInput("Do you want to continue?") == "Y");
        }
        private void RenderGameInfo()
        {
            _inputOutput.RenderLine($"User Wins: {userWins}");
            _inputOutput.RenderLine($"Computer Wins: {computerWins}");
            _inputOutput.RenderLine($"Draws: {draws}");
        }
    }
}
