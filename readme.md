# <img src="/src/icon.png" height="30px"> WinDebloat

[![Build status](https://ci.appveyor.com/api/projects/status/0kb6mmg47arsjw3x/branch/main?svg=true)](https://ci.appveyor.com/project/SimonCropp/WinDebloat)
[![NuGet Status](https://img.shields.io/nuget/v/WinDebloat.svg)](https://www.nuget.org/packages/WinDebloat/)

A dotnet tool that removes the bloat in Windows 11


## Installation

Ensure [dotnet CLI is installed](https://docs.microsoft.com/en-us/dotnet/core/tools/).

Install [WinDebloat](https://nuget.org/packages/WinDebloat/)

```ps
dotnet tool install -g WinDebloat
```

## Behaviour


### Uninstalls:

 * Teams Machine-Wide Installer
 * Movies & TV
 * Xbox TCUI
 * Xbox Console Companion
 * Xbox Game Bar Plugin
 * Xbox Identity Provider
 * Xbox Game Speech Window
 * Xbox Game Bar
 * Xbox
 * Microsoft Tips
 * MSN Weather
 * Windows Media Player
 * Mail and Calendar
 * Microsoft Whiteboard
 * Microsoft Pay
 * Skype
 * Windows Maps
 * Feedback Hub
 * Microsoft Photos
 * Windows Camera
 * Microsoft To Do
 * Microsoft People
 * Solitaire & Casual Games
 * Mixed Reality Portal
 * Microsoft Sticky Notes
 * News
 * Get Help
 * Paint 3D
 * Paint
 * Cortana
 * Clipchamp
 * Power Automate
 * OneNote for Windows 10


### Installs
        
 * Paint.net


### Other

* Remove windows chat
  Set `"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced\TaskbarMn` to `0`
* Remove widgets by setting `HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced\TaskbarDa` to `0`
* Disable edge staup boost by setting `HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Edge\StartupBoostEnabled` to `1`
* Hide Task View Button by setting `HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced\ShowTaskViewButton` to `0`
* Remove Task Bar Search by setting `HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Search\SearchboxTaskbarMode` to `0`
* Enable [Developer Mode](https://learn.microsoft.com/en-us/windows/apps/get-started/enable-your-device-for-development) by setting `HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Appx\AllowDevelopmentWithoutDevLicense` to `1`.
* Make PowerShel Unrestricted by setting `HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\PowerShell\1\ShellIds\Microsoft.PowerShell\ExecutionPolicy` to `Unrestricted`
* Disable Web Search by setting `HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\Windows\Explorer\DisableSearchBoxSuggestions` to `1`


## Icons

[Elephant](https://thenounproject.com/icon/elephant-face-1557798/) designed by [Icons Producer](https://thenounproject.com/iconsproducer/) from [The Noun Project](https://thenounproject.com).