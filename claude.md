# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

WinDebloat is a Windows 11 debloating tool distributed as a .NET global tool (`dotnet tool install -g WinDebloat`). It removes unwanted apps, disables telemetry, modifies registry settings, and disables services using WinGet and Windows APIs. Requires administrator privileges.

## Build & Test Commands

```shell
# Build
dotnet build src/WinDebloat/WinDebloat.csproj

# Run all tests
dotnet test src/Tests/Tests.csproj

# Run a specific test class
dotnet test src/Tests/Tests.csproj --filter CliTests

# Run a specific test method
dotnet test src/Tests/Tests.csproj --filter "CliTests.ExcludeNonDefault"
```

**Note:** Some tests require administrator privileges (registry/service tests). Tests marked `[Explicit]` or wrapped in `#if DEBUG` need manual invocation or a Debug build. The test project targets `net8.0-windows`.

## Architecture

**Job-based design:** All debloat operations implement `IJob` (a marker interface with `Name` and `Notes`). Job types are records:

- `RegistryValueJob` / `RegistryKeyJob` — modify Windows registry
- `UninstallByNameJob` / `UninstallByIdJob` — remove apps via WinGet
- `InstallByNameJob` / `InstallByIdJob` — install apps via WinGet
- `DisableServiceJob` — stop and disable Windows services
- `EnvironmentVariableJob` — set machine-level environment variables

**Groups:** Jobs are organized into `Group` records (Name, Id, IsDefault, Jobs). Default groups run automatically; non-default groups require `--include`. Groups are defined in `Program_Groups.cs` as a static list.

**Execution flow:** `Main` → `ArgumentParser.Invoke()` (System.CommandLine) → `Program.Inner()` which iterates groups, checks include/exclude logic, and dispatches each job via `HandleJob()` pattern matching.

**Partial class split:** `Program.cs` contains execution logic; `Program_Groups.cs` contains the group definitions.

**WinGet wrapper:** `WinGet.cs` wraps the WinGet CLI using CliWrap. Minimum version: 1.10.340.

## Testing

- **Framework:** NUnit 4 with Verify (approval testing)
- **Approval files:** `*.verified.txt` files in `src/Tests/` — update these when output changes using Verify's accept workflow
- **DocsTests.cs** auto-generates documentation (`actions.include.md`) from the group definitions — run tests after modifying groups to regenerate docs
- **Non-parallelizable:** Tests modify system state (registry, services)

## Code Style

- `TreatWarningsAsErrors: true` and `EnforceCodeStyleInBuild: true`
- Strict `.editorconfig` with many Roslyn analyzer rules as errors
- File-scoped namespaces, implicit usings, C# preview features
- Records for data types, expression-bodied members preferred
- Central package versioning in `src/Directory.Packages.props`
