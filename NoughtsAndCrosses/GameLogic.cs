using NoughtsAndCrosses.Interfaces;

namespace NoughtsAndCrosses
{
    /// <summary>
    /// Encapsulates the game logic,
    /// </summary>
    /// <param name="aiOpponent">Simulates the logic of the opponent</param>
    /// <param name="winChecker">Checks if a win/loss/draw event</param>
    /// <param name="grid">the game board</param>
    /// <param name="turnManager">handles whos turn it is</param>
    /// <param name="playerTurnHandler">handles the players turn</param>
    /// <param name="gridRenderer">handles rendering board to the console window</param>
    public class GameLogic(IAiOpponent aiOpponent, IGameStatusChecker winChecker, IGrid grid, ITurnManager turnManager, IPlayerTurnHandler playerTurnHandler, IGridRenderer gridRenderer) : IGameLogic
    {
        private readonly IAiOpponent _aiOpponent = aiOpponent;
        private readonly IGameStatusChecker _winChecker = winChecker;
        private readonly IGrid _grid = grid;
        private readonly ITurnManager _turnManager = turnManager;
        private readonly IPlayerTurnHandler _playerTurnHandler = playerTurnHandler;
        private readonly IGridRenderer _gridRenderer = gridRenderer;

        /// <summary>
        /// play the game of Noughts and Crosses (Tic Tac Toe).
        /// </summary>
        public GameResult Play()
        {
            _grid.InitializeSquares();
            _gridRenderer.RenderGrid(_grid);
            _turnManager.SetupPlayers(players: ["X", "O"]);
            GameResult result = _winChecker.CheckGameStatus(_grid);

            while (!result.IsOver)
            {
                string player = _turnManager.CurrentPlayer;
                //// computers turn
                if (player == "O")
                {
                    _aiOpponent.MakeMove(_grid);
                }
                ////player turn.
                else
                {
                    _playerTurnHandler.HandlePlayersTurn(player, _grid);
                }
                //// Switch to the next player after each turn
                _turnManager.NextTurn();
                /// check the result, win, loss, draw, continue.
                result = _winChecker.CheckGameStatus(_grid);
            }

            return result;
        }
    }
}
