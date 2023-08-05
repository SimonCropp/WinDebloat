# <img src="/src/icon.png" height="30px"> WinDebloat

[![Build status](https://ci.appveyor.com/api/projects/status/0kb6mmg47arsjw3x/branch/main?svg=true)](https://ci.appveyor.com/project/SimonCropp/WinDebloat)
[![NuGet Status](https://img.shields.io/nuget/v/WinDebloat.svg)](https://www.nuget.org/packages/WinDebloat/)

A dotnet tool that removes the bloat in Windows 11


## Installation

Ensure [dotnet CLI is installed](https://docs.microsoft.com/en-us/dotnet/core/tools/).


### Install [WinDebloat](https://nuget.org/packages/WinDebloat/)

```ps
dotnet tool install -g WinDebloat
```


#### Update

```ps
dotnet tool update -g WinDebloat
```


### Run

```ps
WinDebloat
```

## Notes

 * [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/)
 * https://winget.run. An online registry of winget packages.
 * [ExplorerPatcher](https://github.com/valinet/ExplorerPatcher). A helpful to use in conjunction with this project to make Windows more usable.
 * [Setting a single registry entry using PowerShell](https://learn.microsoft.com/en-us/powershell/scripting/samples/working-with-registry-entries#setting-a-single-registry-entry)


## Behavior


### Advertiser Id <!-- include: actions. path: /src/actions.include.md -->

Command to manually apply:

```ps
Set-ItemProperty -Path Registry::HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\AdvertisingInfo -Name Enabled -Type DWord -Value 0
```

Command to manually revert:

```ps
Set-ItemProperty -Path Registry::HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\AdvertisingInfo -Name Enabled -Type DWord -Value 1
```

### Camera

Uninstall `Windows Camera` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Windows Camera" --exact
```

### Chat

Command to manually apply:

```ps
Set-ItemProperty -Path Registry::HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced -Name TaskbarMn -Type DWord -Value 0
```

Command to manually revert:

```ps
Set-ItemProperty -Path Registry::HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced -Name TaskbarMn -Type DWord -Value 1
```

### Clipchamp

Uninstall `Clipchamp` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Clipchamp" --exact
```

### Cortana

Uninstall `Cortana` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Cortana" --exact
```

### DeveloperMode

Command to manually apply:

```ps
Set-ItemProperty -Path Registry::HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Appx -Name AllowDevelopmentWithoutDevLicense -Type DWord -Value 1
```

Command to manually revert:

```ps
Set-ItemProperty -Path Registry::HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Appx -Name AllowDevelopmentWithoutDevLicense -Type DWord -Value 0
```

### EdgeDesktopSearchBar

Command to manually apply:

```ps
Set-ItemProperty -Path Registry::HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Edge -Name WebWidgetAllowed -Type DWord -Value 0
```

Command to manually revert:

```ps
Set-ItemProperty -Path Registry::HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Edge -Name WebWidgetAllowed -Type DWord -Value 1
```

### Feedback Hub

Uninstall `Feedback Hub` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Feedback Hub" --exact
```

### FileExtensions

Command to manually apply:

```ps
Set-ItemProperty -Path Registry::HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced -Name HideFileExt -Type DWord -Value 0
```

Command to manually revert:

```ps
Set-ItemProperty -Path Registry::HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced -Name HideFileExt -Type DWord -Value 1
```

### Games

Uninstall `Solitaire & Casual Games` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Solitaire & Casual Games" --exact
```

### Get Help

Uninstall `Get Help` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Get Help" --exact
```

### Lock Screen Ads

#### RotatingLockScreenOverlayEnabled

Command to manually apply:

```ps
Set-ItemProperty -Path Registry::HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager -Name RotatingLockScreenOverlayEnabled -Type DWord -Value 0
```

Command to manually revert:

```ps
Set-ItemProperty -Path Registry::HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager -Name RotatingLockScreenOverlayEnabled -Type DWord -Value 1
```

#### SubscribedContent-338387Enabled

Command to manually apply:

```ps
Set-ItemProperty -Path Registry::HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager -Name SubscribedContent-338387Enabled -Type DWord -Value 0
```

Command to manually revert:

```ps
Set-ItemProperty -Path Registry::HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager -Name SubscribedContent-338387Enabled -Type DWord -Value 1
```

### Mail and Calendar

Uninstall `Mail and Calendar` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Mail and Calendar" --exact
```

### Maps

Uninstall `Windows Maps` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Windows Maps" --exact
```

### Media Player

Uninstall `Windows Media Player` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Windows Media Player" --exact
```

### Mixed Reality Portal

Uninstall `Mixed Reality Portal` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Mixed Reality Portal" --exact
```

### Movies & TV

Uninstall `Movies & TV` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Movies & TV" --exact
```

### News

Uninstall `News` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "News" --exact
```

### OneNote

Uninstall `OneNote for Windows 10` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "OneNote for Windows 10" --exact
```

### Pay

Uninstall `Microsoft Pay` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Microsoft Pay" --exact
```

### Paint

#### Paint

Uninstall `Paint` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Paint" --exact
```

#### paint.net

Install `paint.net` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

Command to manually apply:

```ps
winget install --name "paint.net" --exact
```

### People

Uninstall `Microsoft People` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Microsoft People" --exact
```

### Photos

Uninstall `Microsoft Photos` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Microsoft Photos" --exact
```

### Power Automate

Uninstall `Power Automate` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Power Automate" --exact
```

### PowerShelUnrestricted

Command to manually apply:

```ps
Set-ItemProperty -Path Registry::HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\PowerShell\1\ShellIds\Microsoft.PowerShell -Name ExecutionPolicy -Type DWord -Value Unrestricted
```

Command to manually revert:

```ps
Set-ItemProperty -Path Registry::HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\PowerShell\1\ShellIds\Microsoft.PowerShell -Name ExecutionPolicy -Type DWord -Value String
```

### Paint 3D

Uninstall `Paint 3D` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Paint 3D" --exact
```

### Skype

Uninstall `Skype` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Skype" --exact
```

### StartupBoost

Command to manually apply:

```ps
Set-ItemProperty -Path Registry::HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Edge -Name StartupBoostEnabled -Type DWord -Value 0
```

Command to manually revert:

```ps
Set-ItemProperty -Path Registry::HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Edge -Name StartupBoostEnabled -Type DWord -Value 1
```

### Start Menu Recommendations

Command to manually apply:

```ps
Set-ItemProperty -Path Registry::HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Explorer -Name HideRecommendedSection -Type DWord -Value 1
```

Command to manually revert:

```ps
Set-ItemProperty -Path Registry::HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Explorer -Name HideRecommendedSection -Type DWord -Value 0
```

### Sticky Notes

Uninstall `Microsoft Sticky Notes` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Microsoft Sticky Notes" --exact
```

### TaskBarSearch

Command to manually apply:

```ps
Set-ItemProperty -Path Registry::HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Search -Name SearchboxTaskbarMode -Type DWord -Value 0
```

Command to manually revert:

```ps
Set-ItemProperty -Path Registry::HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Search -Name SearchboxTaskbarMode -Type DWord -Value 1
```

### Task View

Command to manually apply:

```ps
Set-ItemProperty -Path Registry::HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced -Name ShowTaskViewButton -Type DWord -Value 0
```

Command to manually revert:

```ps
Set-ItemProperty -Path Registry::HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced -Name ShowTaskViewButton -Type DWord -Value 1
```

### Teams

Uninstall `Teams Machine-Wide Installer` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Teams Machine-Wide Installer" --exact
```

### Telemetry

Command to manually apply:

```ps
Set-ItemProperty -Path Registry::HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\DataCollection -Name Allow Telemetry -Type DWord -Value 0
```

Command to manually revert:

```ps
Set-ItemProperty -Path Registry::HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\DataCollection -Name Allow Telemetry -Type DWord -Value 1
```

### Tips

Uninstall `Microsoft Tips` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Microsoft Tips" --exact
```

### To Do

Uninstall `Microsoft To Do` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Microsoft To Do" --exact
```

### Weather

Uninstall `MSN Weather` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "MSN Weather" --exact
```

### Web Experience Pack

Uninstall `Windows Web Experience Pack` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Windows Web Experience Pack" --exact
```

### WebSearch

Command to manually apply:

```ps
Set-ItemProperty -Path Registry::HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\Windows\Explorer -Name DisableSearchBoxSuggestions -Type DWord -Value 1
```

Command to manually revert:

```ps
Set-ItemProperty -Path Registry::HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\Windows\Explorer -Name DisableSearchBoxSuggestions -Type DWord -Value 0
```

### Whiteboard

Uninstall `Microsoft Whiteboard` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Microsoft Whiteboard" --exact
```

### Widgets

Command to manually apply:

```ps
Set-ItemProperty -Path Registry::HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced -Name TaskbarDa -Type DWord -Value 0
```

Command to manually revert:

```ps
Set-ItemProperty -Path Registry::HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced -Name TaskbarDa -Type DWord -Value 1
```

### Xbox

#### Xbox TCUI

Uninstall `Xbox TCUI` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Xbox TCUI" --exact
```

#### Xbox Console Companion

Uninstall `Xbox Console Companion` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Xbox Console Companion" --exact
```

#### Xbox Game Bar Plugin

Uninstall `Xbox Game Bar Plugin` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Xbox Game Bar Plugin" --exact
```

#### Xbox Identity Provider

Uninstall `Xbox Identity Provider` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Xbox Identity Provider" --exact
```

#### Xbox Game Speech Window

Uninstall `Xbox Game Speech Window` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Xbox Game Speech Window" --exact
```

#### Xbox Game Bar

Uninstall `Xbox Game Bar` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Xbox Game Bar" --exact
```

#### Xbox Accessories

Uninstall `Xbox Accessories` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Xbox Accessories" --exact
```

#### Xbox

Uninstall `Xbox` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Xbox" --exact
```
 <!-- endInclude -->


## Icons

[Elephant](https://thenounproject.com/icon/elephant-face-1557798/) designed by [Icons Producer](https://thenounproject.com/iconsproducer/) from [The Noun Project](https://thenounproject.com).

## Testing
Unit tests should be run with elevated privileges
