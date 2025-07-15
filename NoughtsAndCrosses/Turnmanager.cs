using NoughtsAndCrosses.Interfaces;

namespace NoughtsAndCrosses
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TurnManager"/> class with the specified players.
    /// </summary>
    /// <param name="players">The list of players participating in the game.</param>
    public class TurnManager(IEnumerable<string> players) : ITurnManager
    {
        private List<string> _players = [.. players];
        private int _currentIndex = 0;

        /// <summary>
        /// Sets up the players for the game.
        /// </summary>
        /// <param name="players">The list of players to set up.</param>
        public void SetupPlayers(List<string> players)
        {
            _players = players;
        }

        /// <summary>
        /// Gets the current player whose turn it is.
        /// </summary>
        public string CurrentPlayer => _players[_currentIndex];

        /// <summary>
        /// Advances the turn to the next player.
        /// </summary>
        public void NextTurn()
        {
            _currentIndex = (_currentIndex + 1) % _players.Count;
        }
    }
}
