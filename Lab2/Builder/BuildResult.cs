using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builder;

public abstract record BuildResult
{
    private BuildResult() { }

    internal sealed record Success(PersonalComputer Computer) : BuildResult;

    internal sealed record Warning(PersonalComputer Computer, List<string> Comments) : BuildResult;

    internal sealed record WithoutGuarantees(PersonalComputer Computer, List<string> Comments) : BuildResult;

    internal sealed record Failure(string Comment) : BuildResult;
}