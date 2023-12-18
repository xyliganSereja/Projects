// See https://aka.ms/new-console-template for more information

using Application.Extensions;
using Console;
using Console.Extensions;
using DataAccess.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;

var collection = new ServiceCollection();

collection
    .AddApplication()
    .AddInfrastructureDataAccess()
    .AddPresentationConsole();

ServiceProvider provider = collection.BuildServiceProvider();
using IServiceScope scope = provider.CreateScope();

ScenarioRunner scenarioRunner = scope.ServiceProvider
    .GetRequiredService<ScenarioRunner>();

while (true)
{
    scenarioRunner.Run();
    AnsiConsole.Clear();
}