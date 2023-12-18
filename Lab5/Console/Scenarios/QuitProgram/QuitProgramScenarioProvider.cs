using System.Diagnostics.CodeAnalysis;

namespace Console.Scenarios.QuitProgram;

public class QuitProgramScenarioProvider : IScenarioProvider
{
    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        scenario = new QuitProgramScenario();
        return true;
    }
}