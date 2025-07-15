# Noughts And Crosses (OXO)

A modular, test-driven, and extensible Tic Tac Toe game written in C# (.NET 8), featuring AI opponent, score tracking, and a clean architecture following SOLID principles.

## Features

- Play Noughts and Crosses against an computer opponent in the console.
- Computer blocks, wins, or picks the best available move.
- Score tracking for user wins, AI wins, and draws.
- Retry loop: play multiple games in a session.
- Clean separation of concerns using interfaces and dependency injection.
- Comprehensive unit and integration tests.

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Visual Studio 2022 or later (recommended)

### Running the Game

1. Clone the repository.
2. Open the solution in Visual Studio or your preferred IDE.
3. Set `NoughtsAndCrosses` as the startup project.
4. Build and run the application.

You will be prompted to play as "X" against the AI ("O"). After each game, you can choose to play again or exit. Scores are displayed after each round.

### Running Tests

To run all unit and integration tests:

## Project Structure

- `NoughtsAndCrosses/` - Main game logic and classes
- `NoughtsAndCrosses.Test/` - Unit tests for core components
- `NoughtsAndCrosses.IntegrationTests/` - Integration tests for game sessions

## Key Classes

- `GameSession` - Manages game sessions, score tracking, and retry loop
- `GameLogic` - Orchestrates a single game
- `AiOpponent` - AI logic for the computer player
- `PlayerTurnHandler` - Handles user input and move validation
- `Grid` - Represents the game board
- `GridRenderer` - Handles board display in the console
- `TurnManager` - Manages player turns

## Extending the Game

- To add new AI strategies, implement `IAiOpponent`.
- To support different UIs, implement `IInputOutput` and/or `IGridRenderer`.
- To change win conditions or grid size, modify `WinningCombinations` and `Grid`.

## License

MIT

---

*Built with C# 12 and .NET 8. Contributions and suggestions welcome!*
