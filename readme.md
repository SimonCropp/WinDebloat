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

 * https://winget.run
 * https://github.com/valinet/ExplorerPatcher
 * [Setting a single registry entry using PowerShell](https://learn.microsoft.com/en-us/powershell/scripting/samples/working-with-registry-entries#setting-a-single-registry-entry)


## Behavior

### Teams Machine-Wide Installer <!-- include: actions. path: /src/actions.include.md -->

```ps
winget uninstall --name "Teams Machine-Wide Installer" --exact
```

### Movies & TV

```ps
winget uninstall --name "Movies & TV" --exact
```

### Microsoft Tips

```ps
winget uninstall --name "Microsoft Tips" --exact
```

### MSN Weather

```ps
winget uninstall --name "MSN Weather" --exact
```

### Windows Media Player

```ps
winget uninstall --name "Windows Media Player" --exact
```

### Mail and Calendar

```ps
winget uninstall --name "Mail and Calendar" --exact
```

### Microsoft Whiteboard

```ps
winget uninstall --name "Microsoft Whiteboard" --exact
```

### Microsoft Pay

```ps
winget uninstall --name "Microsoft Pay" --exact
```

### Skype

```ps
winget uninstall --name "Skype" --exact
```

### Windows Maps

```ps
winget uninstall --name "Windows Maps" --exact
```

### Feedback Hub

```ps
winget uninstall --name "Feedback Hub" --exact
```

### Microsoft Photos

```ps
winget uninstall --name "Microsoft Photos" --exact
```

### Windows Camera

```ps
winget uninstall --name "Windows Camera" --exact
```

### Microsoft To Do

```ps
winget uninstall --name "Microsoft To Do" --exact
```

### Microsoft People

```ps
winget uninstall --name "Microsoft People" --exact
```

### Solitaire & Casual Games

```ps
winget uninstall --name "Solitaire & Casual Games" --exact
```

### Mixed Reality Portal

```ps
winget uninstall --name "Mixed Reality Portal" --exact
```

### Microsoft Sticky Notes

```ps
winget uninstall --name "Microsoft Sticky Notes" --exact
```

### News

```ps
winget uninstall --name "News" --exact
```

### Get Help

```ps
winget uninstall --name "Get Help" --exact
```

### Cortana

```ps
winget uninstall --name "Cortana" --exact
```

### Power Automate

```ps
winget uninstall --name "Power Automate" --exact
```

### OneNote for Windows 10

```ps
winget uninstall --name "OneNote for Windows 10" --exact
```

### Clipchamp

```ps
winget uninstall --name "Clipchamp" --exact
```

### Windows Web Experience Pack

```ps
winget uninstall --name "Windows Web Experience Pack" --exact
```

### Paint 3D

```ps
winget uninstall --name "Paint 3D" --exact
```

### Xbox

#### Xbox TCUI

```ps
winget uninstall --name "Xbox TCUI" --exact
```

#### Xbox Console Companion

```ps
winget uninstall --name "Xbox Console Companion" --exact
```

#### Xbox Game Bar Plugin

```ps
winget uninstall --name "Xbox Game Bar Plugin" --exact
```

#### Xbox Identity Provider

```ps
winget uninstall --name "Xbox Identity Provider" --exact
```

#### Xbox Game Speech Window

```ps
winget uninstall --name "Xbox Game Speech Window" --exact
```

#### Xbox Game Bar

```ps
winget uninstall --name "Xbox Game Bar" --exact
```

#### Xbox Accessories

```ps
winget uninstall --name "Xbox Accessories" --exact
```

#### Xbox

```ps
winget uninstall --name "Xbox" --exact
```

### Paint

#### Paint

```ps
winget uninstall --name "Paint" --exact
```

#### paint.net

```ps
winget install --name "paint.net" --exact
```

### DisableLockScreenAds

#### RotatingLockScreenOverlayEnabled

Apply:

```ps
Set-ItemProperty -Path Registry::HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager -Name RotatingLockScreenOverlayEnabled -Type DWord -Value 0
```

Revert:

```ps
Set-ItemProperty -Path Registry::HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager -Name RotatingLockScreenOverlayEnabled -Type DWord -Value 1
```

#### SubscribedContent-338387Enabled

Apply:

```ps
Set-ItemProperty -Path Registry::HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager -Name SubscribedContent-338387Enabled -Type DWord -Value 0
```

Revert:

```ps
Set-ItemProperty -Path Registry::HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager -Name SubscribedContent-338387Enabled -Type DWord -Value 1
```

### RemoveChat

Apply:

```ps
Set-ItemProperty -Path Registry::HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced -Name TaskbarMn -Type DWord -Value 0
```

Revert:

```ps
Set-ItemProperty -Path Registry::HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced -Name TaskbarMn -Type DWord -Value 1
```

### DisableTelemetry

Apply:

```ps
Set-ItemProperty -Path Registry::HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\DataCollection -Name Allow Telemetry -Type DWord -Value 0
```

Revert:

```ps
Set-ItemProperty -Path Registry::HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\DataCollection -Name Allow Telemetry -Type DWord -Value 1
```

### DisableAdvertiserId

Apply:

```ps
Set-ItemProperty -Path Registry::HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\AdvertisingInfo -Name Enabled -Type DWord -Value 0
```

Revert:

```ps
Set-ItemProperty -Path Registry::HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\AdvertisingInfo -Name Enabled -Type DWord -Value 1
```

### RemoveWidgets

Apply:

```ps
Set-ItemProperty -Path Registry::HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced -Name TaskbarDa -Type DWord -Value 0
```

Revert:

```ps
Set-ItemProperty -Path Registry::HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced -Name TaskbarDa -Type DWord -Value 1
```

### HideStartMenuRecommendedSection

Apply:

```ps
Set-ItemProperty -Path Registry::HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Explorer -Name HideRecommendedSection -Type DWord -Value 1
```

Revert:

```ps
Set-ItemProperty -Path Registry::HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Explorer -Name HideRecommendedSection -Type DWord -Value 0
```

### DisableStartupBoost

Apply:

```ps
Set-ItemProperty -Path Registry::HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Edge -Name StartupBoostEnabled -Type DWord -Value 0
```

Revert:

```ps
Set-ItemProperty -Path Registry::HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Edge -Name StartupBoostEnabled -Type DWord -Value 1
```

### RemoveTaskView

Apply:

```ps
Set-ItemProperty -Path Registry::HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced -Name ShowTaskViewButton -Type DWord -Value 0
```

Revert:

```ps
Set-ItemProperty -Path Registry::HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced -Name ShowTaskViewButton -Type DWord -Value 1
```

### RemoveTaskBarSearch

Apply:

```ps
Set-ItemProperty -Path Registry::HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Search -Name SearchboxTaskbarMode -Type DWord -Value 0
```

Revert:

```ps
Set-ItemProperty -Path Registry::HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Search -Name SearchboxTaskbarMode -Type DWord -Value 1
```

### EnableFileExtensions

Apply:

```ps
Set-ItemProperty -Path Registry::HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced -Name HideFileExt -Type DWord -Value 0
```

Revert:

```ps
Set-ItemProperty -Path Registry::HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced -Name HideFileExt -Type DWord -Value 1
```

### EnableDeveloperMode


Notes:

 * https://learn.microsoft.com/en-us/windows/apps/get-started/enable-your-device-for-development

Apply:

```ps
Set-ItemProperty -Path Registry::HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Appx -Name AllowDevelopmentWithoutDevLicense -Type DWord -Value 1
```

Revert:

```ps
Set-ItemProperty -Path Registry::HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Appx -Name AllowDevelopmentWithoutDevLicense -Type DWord -Value 0
```

### MakePowerShelUnrestricted

Apply:

```ps
Set-ItemProperty -Path Registry::HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\PowerShell\1\ShellIds\Microsoft.PowerShell -Name ExecutionPolicy -Type DWord -Value Unrestricted
```

Revert:

```ps
Set-ItemProperty -Path Registry::HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\PowerShell\1\ShellIds\Microsoft.PowerShell -Name ExecutionPolicy -Type DWord -Value String
```

### DisableWebSearch

Apply:

```ps
Set-ItemProperty -Path Registry::HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\Windows\Explorer -Name DisableSearchBoxSuggestions -Type DWord -Value 1
```

Revert:

```ps
Set-ItemProperty -Path Registry::HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\Windows\Explorer -Name DisableSearchBoxSuggestions -Type DWord -Value 0
```

### DisableEdgeDesktopSearchBar

Apply:

```ps
Set-ItemProperty -Path Registry::HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Edge -Name WebWidgetAllowed -Type DWord -Value 0
```

Revert:

```ps
Set-ItemProperty -Path Registry::HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Edge -Name WebWidgetAllowed -Type DWord -Value 1
```
 <!-- endInclude -->


## Icons

[Elephant](https://thenounproject.com/icon/elephant-face-1557798/) designed by [Icons Producer](https://thenounproject.com/iconsproducer/) from [The Noun Project](https://thenounproject.com).

## Testing
Unit tests should be run with elevated privileges
