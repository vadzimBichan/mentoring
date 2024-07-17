global using NUnit.Framework;
global using TechTalk.SpecFlow;

[assembly: Parallelizable(ParallelScope.Fixtures)]  // https://docs.specflow.org/projects/specflow/en/latest/Execution/Parallel-Execution.html
[assembly: LevelOfParallelism(4)]