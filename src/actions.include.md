## Default Items Removed / Disabled


### Advertiser Id

Id to exclude: `AdvertiserId`

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

Id to exclude: `Camera`

Uninstalls `Windows Camera` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

Command to manually apply:

```ps
winget uninstall --name "Windows Camera" --exact
```


### Chat

Id to exclude: `Chat`

Command to manually apply:

```ps
Set-ItemProperty -Path "Registry::HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced" -Name "TaskbarMn" -Type "DWord" -Value "0"
```

Command to manually revert:

```ps
Set-ItemProperty -Path "Registry::HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced" -Name "TaskbarMn" -Type "DWord" -Value "1"
```


### Clipchamp

Id to exclude: `Clipchamp`

Uninstalls `Clipchamp` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

Command to manually apply:

```ps
winget uninstall --name "Clipchamp" --exact
```


### Cortana

Id to exclude: `Cortana`

Uninstalls `Cortana` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

Command to manually apply:

```ps
winget uninstall --name "Cortana" --exact
```


### Edge Desktop Search Bar

Id to exclude: `EdgeDesktopSearchBar`

Command to manually apply:

```ps
Set-ItemProperty -Path "Registry::HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Edge" -Name "WebWidgetAllowed" -Type "DWord" -Value "0"
```

Command to manually revert:

```ps
Set-ItemProperty -Path "Registry::HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Edge" -Name "WebWidgetAllowed" -Type "DWord" -Value "1"
```


### Feedback Hub

Id to exclude: `FeedbackHub`

Uninstalls `Feedback Hub` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

Command to manually apply:

```ps
winget uninstall --name "Feedback Hub" --exact
```


### FileExtensions

Id to exclude: `FileExtensions`

Command to manually apply:

```ps
Set-ItemProperty -Path "Registry::HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced" -Name "HideFileExt" -Type "DWord" -Value "0"
```

Command to manually revert:

```ps
Set-ItemProperty -Path "Registry::HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced" -Name "HideFileExt" -Type "DWord" -Value "1"
```


### Games

Id to exclude: `Games`

Uninstalls `Solitaire & Casual Games` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

Command to manually apply:

```ps
winget uninstall --name "Solitaire & Casual Games" --exact
```


### Get Help

Id to exclude: `GetHelp`

Uninstalls `Get Help` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

Command to manually apply:

```ps
winget uninstall --name "Get Help" --exact
```


### Lock Screen Ads

Id to exclude: `LockScreenAds`

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

Id to exclude: `MailandCalendar`

Uninstalls `Mail and Calendar` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

Command to manually apply:

```ps
winget uninstall --name "Mail and Calendar" --exact
```


### Maps

Id to exclude: `Maps`

Uninstalls `Windows Maps` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

Command to manually apply:

```ps
winget uninstall --name "Windows Maps" --exact
```


### Media Player

Id to exclude: `MediaPlayer`

Uninstalls `Windows Media Player` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

Command to manually apply:

```ps
winget uninstall --name "Windows Media Player" --exact
```


### Mixed Reality Portal

Id to exclude: `MixedRealityPortal`

Uninstalls `Mixed Reality Portal` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

Command to manually apply:

```ps
winget uninstall --name "Mixed Reality Portal" --exact
```


### Movies and TV

Id to exclude: `MoviesandTV`

Uninstalls `Movies & TV` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

Command to manually apply:

```ps
winget uninstall --name "Movies & TV" --exact
```


### News

Id to exclude: `News`

Uninstalls `News` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

Command to manually apply:

```ps
winget uninstall --name "News" --exact
```


### OneNote

Id to exclude: `OneNote`

Uninstalls `OneNote for Windows 10` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

Command to manually apply:

```ps
winget uninstall --name "OneNote for Windows 10" --exact
```


### Paint 3D

Id to exclude: `Paint3D`

Uninstalls `Paint 3D` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

Command to manually apply:

```ps
winget uninstall --name "Paint 3D" --exact
```


### Pay

Id to exclude: `Pay`

Uninstalls `Microsoft Pay` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

Command to manually apply:

```ps
winget uninstall --name "Microsoft Pay" --exact
```


### People

Id to exclude: `People`

Uninstalls `Microsoft People` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

Command to manually apply:

```ps
winget uninstall --name "Microsoft People" --exact
```


### Photos

Id to exclude: `Photos`

Uninstalls `Microsoft Photos` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

Command to manually apply:

```ps
winget uninstall --name "Microsoft Photos" --exact
```


### Power Automate

Id to exclude: `PowerAutomate`

Uninstalls `Power Automate` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

Command to manually apply:

```ps
winget uninstall --name "Power Automate" --exact
```


### PowerShell Unrestricted

Id to exclude: `PowerShellUnrestricted`

Command to manually apply:

```ps
Set-ItemProperty -Path "Registry::HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\PowerShell\1\ShellIds\Microsoft.PowerShell" -Name "ExecutionPolicy" -Type "String" -Value "Unrestricted"
```

Command to manually revert:

```ps
Set-ItemProperty -Path "Registry::HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\PowerShell\1\ShellIds\Microsoft.PowerShell" -Name "ExecutionPolicy" -Type "String" -Value "Restricted"
```


### Skype

Id to exclude: `Skype`

Uninstalls `Skype` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

Command to manually apply:

```ps
winget uninstall --name "Skype" --exact
```


### Startup boost

Id to exclude: `Startupboost`

Command to manually apply:

```ps
Set-ItemProperty -Path "Registry::HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Edge" -Name "StartupBoostEnabled" -Type "DWord" -Value "0"
```

Command to manually revert:

```ps
Set-ItemProperty -Path "Registry::HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Edge" -Name "StartupBoostEnabled" -Type "DWord" -Value "1"
```

Notes:

 * [Microsoft Edge Startup boost](https://www.microsoft.com/en-us/edge/features/startup-boost)


### Start Menu Recommendations

Id to exclude: `StartMenuRecommendations`

Command to manually apply:

```ps
Set-ItemProperty -Path "Registry::HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Explorer" -Name "HideRecommendedSection" -Type "DWord" -Value "1"
```

Command to manually revert:

```ps
Set-ItemProperty -Path "Registry::HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Explorer" -Name "HideRecommendedSection" -Type "DWord" -Value "0"
```

Notes:

 * The parent path `HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Explorer` may need to be created if it doesn;t exist


### Sticky Notes

Id to exclude: `StickyNotes`

Uninstalls `Microsoft Sticky Notes` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

Command to manually apply:

```ps
winget uninstall --name "Microsoft Sticky Notes" --exact
```


### TaskBar Search

Id to exclude: `TaskBarSearch`

Command to manually apply:

```ps
Set-ItemProperty -Path "Registry::HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Search" -Name "SearchboxTaskbarMode" -Type "DWord" -Value "0"
```

Command to manually revert:

```ps
Set-ItemProperty -Path "Registry::HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Search" -Name "SearchboxTaskbarMode" -Type "DWord" -Value "1"
```


### Task View

Id to exclude: `TaskView`

Command to manually apply:

```ps
Set-ItemProperty -Path "Registry::HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced" -Name "ShowTaskViewButton" -Type "DWord" -Value "0"
```

Command to manually revert:

```ps
Set-ItemProperty -Path "Registry::HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced" -Name "ShowTaskViewButton" -Type "DWord" -Value "1"
```


### Teams

Id to exclude: `Teams`

Uninstalls `Teams Machine-Wide Installer` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

Command to manually apply:

```ps
winget uninstall --name "Teams Machine-Wide Installer" --exact
```


### Telemetry

Id to exclude: `Telemetry`

Command to manually apply:

```ps
Set-ItemProperty -Path "Registry::HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\DataCollection" -Name "Allow Telemetry" -Type "DWord" -Value "0"
```

Command to manually revert:

```ps
Set-ItemProperty -Path "Registry::HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\DataCollection" -Name "Allow Telemetry" -Type "DWord" -Value "1"
```


### Tips

Id to exclude: `Tips`

Uninstalls `Microsoft Tips` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

Command to manually apply:

```ps
winget uninstall --name "Microsoft Tips" --exact
```


### To Do

Id to exclude: `ToDo`

Uninstalls `Microsoft To Do` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

Command to manually apply:

```ps
winget uninstall --name "Microsoft To Do" --exact
```


### Weather

Id to exclude: `Weather`

Uninstalls `MSN Weather` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

Command to manually apply:

```ps
winget uninstall --name "MSN Weather" --exact
```


### Web Experience Pack

Id to exclude: `WebExperiencePack`

Uninstalls `Windows Web Experience Pack` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

Command to manually apply:

```ps
winget uninstall --name "Windows Web Experience Pack" --exact
```


### Start Menu Web Search

Id to exclude: `StartMenuWebSearch`

Command to manually apply:

```ps
Set-ItemProperty -Path "Registry::HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\Windows\Explorer" -Name "DisableSearchBoxSuggestions" -Type "DWord" -Value "1"
```

Command to manually revert:

```ps
Set-ItemProperty -Path "Registry::HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\Windows\Explorer" -Name "DisableSearchBoxSuggestions" -Type "DWord" -Value "0"
```


### Whiteboard

Id to exclude: `Whiteboard`

Uninstalls `Microsoft Whiteboard` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

Command to manually apply:

```ps
winget uninstall --name "Microsoft Whiteboard" --exact
```


### Widgets

Id to exclude: `Widgets`

Command to manually apply:

```ps
Set-ItemProperty -Path "Registry::HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced" -Name "TaskbarDa" -Type "DWord" -Value "0"
```

Command to manually revert:

```ps
Set-ItemProperty -Path "Registry::HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced" -Name "TaskbarDa" -Type "DWord" -Value "1"
```


### Xbox

Id to exclude: `Xbox`

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



## Optional Items Removed / Disabled


### Developer Mode

Id to include: `DeveloperMode`

Command to manually apply:

```ps
Set-ItemProperty -Path "Registry::HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Appx" -Name "AllowDevelopmentWithoutDevLicense" -Type "DWord" -Value "1"
```

Command to manually revert:

```ps
Set-ItemProperty -Path "Registry::HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Appx" -Name "AllowDevelopmentWithoutDevLicense" -Type "DWord" -Value "0"
```

Notes:

 * [Developer Mode features and debugging](https://learn.microsoft.com/en-us/windows/apps/get-started/developer-mode-features-and-debugging)


### HP

Id to include: `HP`

#### HP Desktop Support Utilities

Uninstalls `HP Desktop Support Utilities` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

Command to manually apply:

```ps
winget uninstall --name "HP Desktop Support Utilities" --exact
```


#### HP Documentation

Uninstalls `HP Documentation` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

Command to manually apply:

```ps
winget uninstall --name "HP Documentation" --exact
```


#### HP Notifications

Uninstalls `HP Notifications` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

Command to manually apply:

```ps
winget uninstall --name "HP Notifications" --exact
```


#### HPHelp

Uninstalls `HPHelp` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

Command to manually apply:

```ps
winget uninstall --name "HPHelp" --exact
```


#### HpTouchpointAnalyticsService

Command to manually apply:

```ps
Stop-Service -Name "HpTouchpointAnalyticsService"
Set-Service -Name "HpTouchpointAnalyticsService" -StartupType "Disabled"
```

Command to manually revert:

```ps
Set-Service -Name "HpTouchpointAnalyticsService" -StartupType "Automatic"
Start-Service -Name "HpTouchpointAnalyticsService"
```


#### HPAppHelperCap

Command to manually apply:

```ps
Stop-Service -Name "HPAppHelperCap"
Set-Service -Name "HPAppHelperCap" -StartupType "Disabled"
```

Command to manually revert:

```ps
Set-Service -Name "HPAppHelperCap" -StartupType "Automatic"
Start-Service -Name "HPAppHelperCap"
```


#### HPDiagsCap

Command to manually apply:

```ps
Stop-Service -Name "HPDiagsCap"
Set-Service -Name "HPDiagsCap" -StartupType "Disabled"
```

Command to manually revert:

```ps
Set-Service -Name "HPDiagsCap" -StartupType "Automatic"
Start-Service -Name "HPDiagsCap"
```


#### HPSysInfoCap

Command to manually apply:

```ps
Stop-Service -Name "HPSysInfoCap"
Set-Service -Name "HPSysInfoCap" -StartupType "Disabled"
```

Command to manually revert:

```ps
Set-Service -Name "HPSysInfoCap" -StartupType "Automatic"
Start-Service -Name "HPSysInfoCap"
```


#### hpsvcsscan

Command to manually apply:

```ps
Stop-Service -Name "hpsvcsscan"
Set-Service -Name "hpsvcsscan" -StartupType "Disabled"
```

Command to manually revert:

```ps
Set-Service -Name "hpsvcsscan" -StartupType "Automatic"
Start-Service -Name "hpsvcsscan"
```


#### HotKeyServiceDSU

Command to manually apply:

```ps
Stop-Service -Name "HotKeyServiceDSU"
Set-Service -Name "HotKeyServiceDSU" -StartupType "Disabled"
```

Command to manually revert:

```ps
Set-Service -Name "HotKeyServiceDSU" -StartupType "Automatic"
Start-Service -Name "HotKeyServiceDSU"
```



### Paint

Id to include: `Paint`

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



### Printer

Id to include: `Printer`

Command to manually apply:

```ps
Stop-Service -Name "Spooler"
Set-Service -Name "Spooler" -StartupType "Disabled"
```

Command to manually revert:

```ps
Set-Service -Name "Spooler" -StartupType "Automatic"
Start-Service -Name "Spooler"
```


