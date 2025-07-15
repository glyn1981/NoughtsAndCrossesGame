using Microsoft.Extensions.DependencyInjection;
using NoughtsAndCrosses.Interfaces;
namespace NoughtsAndCrosses;
static class Program
{
    private static void Main()
    {
        var services = new ServiceCollection();

        // Register services and implementations
        services.AddTransient<IInputOutput, InputOutput>();
        services.AddTransient<IAiOpponent, AiOpponent>();
        services.AddTransient<IGameStatusChecker, GameStatusChecker>();
        services.AddTransient<IGrid, Grid>();
        services.AddTransient<IGameLogic,GameLogic>();
        services.AddTransient<ITurnManager, TurnManager>();
        services.AddTransient<IPlayerTurnHandler, PlayerTurnHandler>();
        services.AddTransient<IGridRenderer, GridRenderer>();
        services.AddTransient<IGameSession, GameSession>();

        var serviceProvider = services.BuildServiceProvider();

        try
        {
            var game = serviceProvider.GetRequiredService<IGameSession>();
            game.BeginGameSession();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}