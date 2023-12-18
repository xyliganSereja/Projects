using Console.Scenarios.Admin;
using Console.Scenarios.Login;
using Console.Scenarios.QuitProgram;
using Console.Scenarios.User;
using Microsoft.Extensions.DependencyInjection;

namespace Console.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();

        collection.AddScoped<IScenarioProvider, AddUserScenarioProvider>();
        collection.AddScoped<IScenarioProvider, AdminLoginScenarioProvider>();
        collection.AddScoped<IScenarioProvider, LogoutScenarioProvider>();
        collection.AddScoped<IScenarioProvider, UserLoginScenarioProvider>();
        collection.AddScoped<IScenarioProvider, QuitProgramScenarioProvider>();
        collection.AddScoped<IScenarioProvider, AddMoneyScenarioProvider>();
        collection.AddScoped<IScenarioProvider, RemoveMoneyScenarioProvider>();
        collection.AddScoped<IScenarioProvider, ShowBalanceScenarioProvider>();
        collection.AddScoped<IScenarioProvider, ShowHistoryScenarioProvider>();

        return collection;
    }
}