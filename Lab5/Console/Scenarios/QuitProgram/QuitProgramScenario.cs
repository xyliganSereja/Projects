namespace Console.Scenarios.QuitProgram;

public class QuitProgramScenario : IScenario
{
    public string Name => "Quit program";

    public void Run()
    {
        Environment.Exit(0);
    }
}