# NoughtsAndCrosses (Tic Tac Toe)

A modular, test-driven, and extensible Tic Tac Toe game written in C# (.NET 8), featuring AI opponent, score tracking, and a clean architecture following SOLID principles.

## Features

- Play Tic Tac Toe against an AI opponent in the console.
- AI blocks, wins, or picks the best available move.
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
