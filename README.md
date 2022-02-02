# NukeBuildAutomation

Sample [Nuke](https://github.com/nuke-build/nuke) project used for my blog post "[Automate your .NET project builds with nuke a cross-platform build automation solution]()".

## Fix TestWithCoverage target

> nuke TestWithCoverage

-> Error 💥

✅ Start in debug without dependencies from contextual menu
See exception with useful message
Copy paste first command

> nuke :add-package JetBrains.dotCover.DotNetCliTool --version 2021.3.3
> nuke TestWithCoverage

Works now!