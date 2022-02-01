using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotCover;
using static Nuke.Common.IO.PathConstruction;
using static Nuke.Common.Tools.DotCover.DotCoverTasks;

partial class Build
{
    const string TestResultsXmlSuffix = "_TestResults.xml";

    IEnumerable<string> TestAssemblies => GlobFiles(OutputDirectory, "*.Tests.*.dll");
    
    Target TestWithCoverage => _ => _
        .DependsOn(Compile)
        .Executes(() =>
        {
            DotCoverCover(GetDotCoverSettings, Environment.ProcessorCount);
        });
    
    IEnumerable<DotCoverCoverSettings> GetDotCoverSettings(DotCoverCoverSettings settings) =>
        TestAssemblies.Select(testAssembly => new DotCoverCoverSettings()
            .SetTargetExecutable(ToolPathResolver.GetPathExecutable("dotnet"))
            .SetTargetWorkingDirectory(OutputDirectory)
            .SetTargetArguments($"test --test-adapter-path:. {testAssembly}  --logger trx;LogFileName={testAssembly}{TestResultsXmlSuffix}")
            .SetFilters(
                "+:MyProject")
            .SetAttributeFilters(
                "System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute",
                "System.CodeDom.Compiler.GeneratedCodeAttribute")
            .SetOutputFile(GetDotCoverOutputFile(testAssembly)));
    
    AbsolutePath GetDotCoverOutputFile(string testAssembly) => OutputDirectory / $"dotCover_{Path.GetFileName(testAssembly)}.dcvr";
}