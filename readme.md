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


## Usage

```ps
WinDebloat
```

### Excluding items

Items can be excluded by using the `--exclude` argument:

```ps
WinDebloat --exclude AdvertiserId Xbox
```

Ids are case insensitive.

Ids for each item are listed below.

## Items Removed / Disabled


### Advertiser Id <!-- include: actions. path: /src/actions.include.md -->

Id to toggle behavior: `AdvertiserId`

Command to manually apply:

```ps
Set-ItemProperty -Path "Registry::HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\AdvertisingInfo" -Name "Enabled" -Type "DWord" -Value "0"
```

Command to manually revert:

```ps
Set-ItemProperty -Path "Registry::HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\AdvertisingInfo" -Name "Enabled" -Type "DWord" -Value "1"
```

Notes:

 * [General privacy settings in Windows](https://support.microsoft.com/en-us/windows/general-privacy-settings-in-windows-7c7f6a09-cebd-5589-c376-7f505e5bf65a)


### Camera

Id to toggle behavior: `Camera`

Uninstalls `Windows Camera` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Windows Camera" --exact
```


### Chat

Id to toggle behavior: `Chat`

Command to manually apply:

```ps
Set-ItemProperty -Path "Registry::HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced" -Name "TaskbarMn" -Type "DWord" -Value "0"
```

Command to manually revert:

```ps
Set-ItemProperty -Path "Registry::HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced" -Name "TaskbarMn" -Type "DWord" -Value "1"
```


### Clipchamp

Id to toggle behavior: `Clipchamp`

Uninstalls `Clipchamp` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Clipchamp" --exact
```


### Cortana

Id to toggle behavior: `Cortana`

Uninstalls `Cortana` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Cortana" --exact
```


### DeveloperMode

Id to toggle behavior: `DeveloperMode`

Command to manually apply:

```ps
Set-ItemProperty -Path "Registry::HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Appx" -Name "AllowDevelopmentWithoutDevLicense" -Type "DWord" -Value "1"
```

Command to manually revert:

```ps
Set-ItemProperty -Path "Registry::HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Appx" -Name "AllowDevelopmentWithoutDevLicense" -Type "DWord" -Value "0"
```

Notes:

 * https://learn.microsoft.com/en-us/windows/apps/get-started/enable-your-device-for-development


### EdgeDesktopSearchBar

Id to toggle behavior: `EdgeDesktopSearchBar`

Command to manually apply:

```ps
Set-ItemProperty -Path "Registry::HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Edge" -Name "WebWidgetAllowed" -Type "DWord" -Value "0"
```

Command to manually revert:

```ps
Set-ItemProperty -Path "Registry::HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Edge" -Name "WebWidgetAllowed" -Type "DWord" -Value "1"
```


### Feedback Hub

Id to toggle behavior: `FeedbackHub`

Uninstalls `Feedback Hub` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Feedback Hub" --exact
```


### FileExtensions

Id to toggle behavior: `FileExtensions`

Command to manually apply:

```ps
Set-ItemProperty -Path "Registry::HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced" -Name "HideFileExt" -Type "DWord" -Value "0"
```

Command to manually revert:

```ps
Set-ItemProperty -Path "Registry::HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced" -Name "HideFileExt" -Type "DWord" -Value "1"
```


### Games

Id to toggle behavior: `Games`

Uninstalls `Solitaire & Casual Games` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Solitaire & Casual Games" --exact
```


### Get Help

Id to toggle behavior: `GetHelp`

Uninstalls `Get Help` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Get Help" --exact
```


### Lock Screen Ads

Id to toggle behavior: `LockScreenAds`

#### RotatingLockScreenOverlayEnabled

Command to manually apply:

```ps
Set-ItemProperty -Path "Registry::HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager" -Name "RotatingLockScreenOverlayEnabled" -Type "DWord" -Value "0"
```

Command to manually revert:

```ps
Set-ItemProperty -Path "Registry::HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager" -Name "RotatingLockScreenOverlayEnabled" -Type "DWord" -Value "1"
```


#### SubscribedContent-338387Enabled

Command to manually apply:

```ps
Set-ItemProperty -Path "Registry::HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager" -Name "SubscribedContent-338387Enabled" -Type "DWord" -Value "0"
```

Command to manually revert:

```ps
Set-ItemProperty -Path "Registry::HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager" -Name "SubscribedContent-338387Enabled" -Type "DWord" -Value "1"
```



### Mail and Calendar

Id to toggle behavior: `MailandCalendar`

Uninstalls `Mail and Calendar` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Mail and Calendar" --exact
```


### Maps

Id to toggle behavior: `Maps`

Uninstalls `Windows Maps` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Windows Maps" --exact
```


### Media Player

Id to toggle behavior: `MediaPlayer`

Uninstalls `Windows Media Player` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Windows Media Player" --exact
```


### Mixed Reality Portal

Id to toggle behavior: `MixedRealityPortal`

Uninstalls `Mixed Reality Portal` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Mixed Reality Portal" --exact
```


### Movies and TV

Id to toggle behavior: `MoviesandTV`

Uninstalls `Movies & TV` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Movies & TV" --exact
```


### News

Id to toggle behavior: `News`

Uninstalls `News` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "News" --exact
```


### OneNote

Id to toggle behavior: `OneNote`

Uninstalls `OneNote for Windows 10` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "OneNote for Windows 10" --exact
```


### Pay

Id to toggle behavior: `Pay`

Uninstalls `Microsoft Pay` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Microsoft Pay" --exact
```


### Paint

Id to toggle behavior: `Paint`

#### Paint

Uninstalls `Paint` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Paint" --exact
```


#### paint.net

Installs `paint.net` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

Command to manually apply:

```ps
winget install --name "paint.net" --exact
```



### People

Id to toggle behavior: `People`

Uninstalls `Microsoft People` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Microsoft People" --exact
```


### Photos

Id to toggle behavior: `Photos`

Uninstalls `Microsoft Photos` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Microsoft Photos" --exact
```


### Power Automate

Id to toggle behavior: `PowerAutomate`

Uninstalls `Power Automate` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Power Automate" --exact
```


### PowerShelUnrestricted

Id to toggle behavior: `PowerShelUnrestricted`

Command to manually apply:

```ps
Set-ItemProperty -Path "Registry::HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\PowerShell\1\ShellIds\Microsoft.PowerShell" -Name "ExecutionPolicy" -Type "DWord" -Value "Unrestricted"
```

Command to manually revert:

```ps
Set-ItemProperty -Path "Registry::HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\PowerShell\1\ShellIds\Microsoft.PowerShell" -Name "ExecutionPolicy" -Type "DWord" -Value "String"
```


### Paint 3D

Id to toggle behavior: `Paint3D`

Uninstalls `Paint 3D` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Paint 3D" --exact
```


### Skype

Id to toggle behavior: `Skype`

Uninstalls `Skype` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Skype" --exact
```


### StartupBoost

Id to toggle behavior: `StartupBoost`

Command to manually apply:

```ps
Set-ItemProperty -Path "Registry::HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Edge" -Name "StartupBoostEnabled" -Type "DWord" -Value "0"
```

Command to manually revert:

```ps
Set-ItemProperty -Path "Registry::HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Edge" -Name "StartupBoostEnabled" -Type "DWord" -Value "1"
```


### Start Menu Recommendations

Id to toggle behavior: `StartMenuRecommendations`

Command to manually apply:

```ps
Set-ItemProperty -Path "Registry::HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Explorer" -Name "HideRecommendedSection" -Type "DWord" -Value "1"
```

Command to manually revert:

```ps
Set-ItemProperty -Path "Registry::HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Explorer" -Name "HideRecommendedSection" -Type "DWord" -Value "0"
```


### Sticky Notes

Id to toggle behavior: `StickyNotes`

Uninstalls `Microsoft Sticky Notes` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Microsoft Sticky Notes" --exact
```


### TaskBarSearch

Id to toggle behavior: `TaskBarSearch`

Command to manually apply:

```ps
Set-ItemProperty -Path "Registry::HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Search" -Name "SearchboxTaskbarMode" -Type "DWord" -Value "0"
```

Command to manually revert:

```ps
Set-ItemProperty -Path "Registry::HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Search" -Name "SearchboxTaskbarMode" -Type "DWord" -Value "1"
```


### Task View

Id to toggle behavior: `TaskView`

Command to manually apply:

```ps
Set-ItemProperty -Path "Registry::HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced" -Name "ShowTaskViewButton" -Type "DWord" -Value "0"
```

Command to manually revert:

```ps
Set-ItemProperty -Path "Registry::HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced" -Name "ShowTaskViewButton" -Type "DWord" -Value "1"
```


### Teams

Id to toggle behavior: `Teams`

Uninstalls `Teams Machine-Wide Installer` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Teams Machine-Wide Installer" --exact
```


### Telemetry

Id to toggle behavior: `Telemetry`

Command to manually apply:

```ps
Set-ItemProperty -Path "Registry::HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\DataCollection" -Name "Allow Telemetry" -Type "DWord" -Value "0"
```

Command to manually revert:

```ps
Set-ItemProperty -Path "Registry::HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\DataCollection" -Name "Allow Telemetry" -Type "DWord" -Value "1"
```


### Tips

Id to toggle behavior: `Tips`

Uninstalls `Microsoft Tips` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Microsoft Tips" --exact
```


### To Do

Id to toggle behavior: `ToDo`

Uninstalls `Microsoft To Do` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Microsoft To Do" --exact
```


### Weather

Id to toggle behavior: `Weather`

Uninstalls `MSN Weather` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "MSN Weather" --exact
```


### Web Experience Pack

Id to toggle behavior: `WebExperiencePack`

Uninstalls `Windows Web Experience Pack` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Windows Web Experience Pack" --exact
```


### WebSearch

Id to toggle behavior: `WebSearch`

Command to manually apply:

```ps
Set-ItemProperty -Path "Registry::HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\Windows\Explorer" -Name "DisableSearchBoxSuggestions" -Type "DWord" -Value "1"
```

Command to manually revert:

```ps
Set-ItemProperty -Path "Registry::HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\Windows\Explorer" -Name "DisableSearchBoxSuggestions" -Type "DWord" -Value "0"
```


### Whiteboard

Id to toggle behavior: `Whiteboard`

Uninstalls `Microsoft Whiteboard` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Microsoft Whiteboard" --exact
```


### Widgets

Id to toggle behavior: `Widgets`

Command to manually apply:

```ps
Set-ItemProperty -Path "Registry::HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced" -Name "TaskbarDa" -Type "DWord" -Value "0"
```

Command to manually revert:

```ps
Set-ItemProperty -Path "Registry::HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced" -Name "TaskbarDa" -Type "DWord" -Value "1"
```


### Xbox

Id to toggle behavior: `Xbox`

#### Xbox TCUI

Uninstalls `Xbox TCUI` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Xbox TCUI" --exact
```


#### Xbox Console Companion

Uninstalls `Xbox Console Companion` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Xbox Console Companion" --exact
```


#### Xbox Game Bar Plugin

Uninstalls `Xbox Game Bar Plugin` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Xbox Game Bar Plugin" --exact
```


#### Xbox Identity Provider

Uninstalls `Xbox Identity Provider` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Xbox Identity Provider" --exact
```


#### Xbox Game Speech Window

Uninstalls `Xbox Game Speech Window` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Xbox Game Speech Window" --exact
```


#### Xbox Game Bar

Uninstalls `Xbox Game Bar` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Xbox Game Bar" --exact
```


#### Xbox Accessories

Uninstalls `Xbox Accessories` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Xbox Accessories" --exact
```


#### Xbox

Uninstalls `Xbox` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/). 

Command to manually apply:

```ps
winget uninstall --name "Xbox" --exact
```


 <!-- endInclude -->


## Notes

 * [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/)
 * https://winget.run. An online registry of winget packages.
 * [ExplorerPatcher](https://github.com/valinet/ExplorerPatcher). A helpful to use in conjunction with this project to make Windows more usable.
 * [Setting a single registry entry using PowerShell](https://learn.microsoft.com/en-us/powershell/scripting/samples/working-with-registry-entries#setting-a-single-registry-entry)


## Icons

[Elephant](https://thenounproject.com/icon/elephant-face-1557798/) designed by [Icons Producer](https://thenounproject.com/iconsproducer/) from [The Noun Project](https://thenounproject.com).

## Testing
Unit tests should be run with elevated privileges
