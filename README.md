# NukeBuildAutomation

Sample [Nuke](https://github.com/nuke-build/nuke) project used for my blog post "[Automate your .NET project builds with nuke a cross-platform build automation solution](https://laurentkempe.com/2022/02/02/automate-your-dotnet-project-builds-with-nuke-a-cross-platform-build-automation-solution/)".

# Online presentation

[Online presentation](https://user-images.githubusercontent.com/272612/152285009-b82d7298-9a68-4b7f-8a48-6c242dbef81e.png)

# Online Meetup DevApps S06 Ep04

https://youtu.be/o0XLGRObd4E?t=293

# Presentation scenario

## Project code

1. source code
2. tests

## Build code step 1

3. build code
Nuke build is a console application
ts entry point is `Main` which by default execute the target `Compile`

## Build code step 2

4. Parameter which we can pass to the build
✅ Navigate to the source code IsLocalBuild
✅ Show usage of Configuration

5. Solution
✅ Navigate to Solution attribute to show the options

6. AbsolutePath
Nice easy way to compose path

7. Target
A Target defines a task for your build pipeline and is put in relationship with other targets. For example, Clean runs before Restore and Compile depends on Restore.

✅ Show contextual menu on Clean
✅ Show how to run a Target from context menu with/without dependencies

## CLI / Auto-completion in PowerShell

✅> Code $PROFILE

✅Uncomment 
# Nuke build
#Register-ArgumentCompleter -Native -CommandName nuke -ScriptBlock {
#    param($commandName, $wordToComplete, $cursorPosition)
#        nuke :complete "$wordToComplete" | ForEach-Object {
#           [System.Management.Automation.CompletionResult]::new($_, $_, 'ParameterValue', $_)
#        }
#}

✅>. $PROFILE
✅ Show auto completion with tab 

## Adding a test target

✅ ntarget

    Target Test => _ => _
        .DependsOn(Compile)
        .Executes(() =>
        {
            DotNetTest(s => s
                .SetProjectFile(Solution)
                .SetConfiguration(Configuration)
                .EnableNoRestore());
        });

✅ > nuke tab tab

## CLI

nuke --plan

## DotCover

8. dotcover

Code coverage tool for tests

partial class Build

GetDotCoverSettings: Fluent API with possibility to specify more arguments with SetTargetArguments

### Fix TestWithCoverage target

> nuke TestWithCoverage

-> Error 💥

✅ Start in debug without dependencies from contextual menu. See exception with useful message. Copy paste first command

> nuke :add-package JetBrains.dotCover.DotNetCliTool --version 2021.3.3
> nuke TestWithCoverage

Works now!
