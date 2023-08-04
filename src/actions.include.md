### Teams Machine-Wide Installer

```ps
winget uninstall --name "Teams Machine-Wide Installer" --disable-interactivity --exact --silent --accept-source-agreements
```

### Movies & TV

```ps
winget uninstall --name "Movies & TV" --disable-interactivity --exact --silent --accept-source-agreements
```

### Microsoft Tips

```ps
winget uninstall --name "Microsoft Tips" --disable-interactivity --exact --silent --accept-source-agreements
```

### MSN Weather

```ps
winget uninstall --name "MSN Weather" --disable-interactivity --exact --silent --accept-source-agreements
```

### Windows Media Player

```ps
winget uninstall --name "Windows Media Player" --disable-interactivity --exact --silent --accept-source-agreements
```

### Mail and Calendar

```ps
winget uninstall --name "Mail and Calendar" --disable-interactivity --exact --silent --accept-source-agreements
```

### Microsoft Whiteboard

```ps
winget uninstall --name "Microsoft Whiteboard" --disable-interactivity --exact --silent --accept-source-agreements
```

### Microsoft Pay

```ps
winget uninstall --name "Microsoft Pay" --disable-interactivity --exact --silent --accept-source-agreements
```

### Skype

```ps
winget uninstall --name "Skype" --disable-interactivity --exact --silent --accept-source-agreements
```

### Windows Maps

```ps
winget uninstall --name "Windows Maps" --disable-interactivity --exact --silent --accept-source-agreements
```

### Feedback Hub

```ps
winget uninstall --name "Feedback Hub" --disable-interactivity --exact --silent --accept-source-agreements
```

### Microsoft Photos

```ps
winget uninstall --name "Microsoft Photos" --disable-interactivity --exact --silent --accept-source-agreements
```

### Windows Camera

```ps
winget uninstall --name "Windows Camera" --disable-interactivity --exact --silent --accept-source-agreements
```

### Microsoft To Do

```ps
winget uninstall --name "Microsoft To Do" --disable-interactivity --exact --silent --accept-source-agreements
```

### Microsoft People

```ps
winget uninstall --name "Microsoft People" --disable-interactivity --exact --silent --accept-source-agreements
```

### Solitaire & Casual Games

```ps
winget uninstall --name "Solitaire & Casual Games" --disable-interactivity --exact --silent --accept-source-agreements
```

### Mixed Reality Portal

```ps
winget uninstall --name "Mixed Reality Portal" --disable-interactivity --exact --silent --accept-source-agreements
```

### Microsoft Sticky Notes

```ps
winget uninstall --name "Microsoft Sticky Notes" --disable-interactivity --exact --silent --accept-source-agreements
```

### News

```ps
winget uninstall --name "News" --disable-interactivity --exact --silent --accept-source-agreements
```

### Get Help

```ps
winget uninstall --name "Get Help" --disable-interactivity --exact --silent --accept-source-agreements
```

### Cortana

```ps
winget uninstall --name "Cortana" --disable-interactivity --exact --silent --accept-source-agreements
```

### Power Automate

```ps
winget uninstall --name "Power Automate" --disable-interactivity --exact --silent --accept-source-agreements
```

### OneNote for Windows 10

```ps
winget uninstall --name "OneNote for Windows 10" --disable-interactivity --exact --silent --accept-source-agreements
```

### Clipchamp

```ps
winget uninstall --name "Clipchamp" --disable-interactivity --exact --silent --accept-source-agreements
```

### Windows Web Experience Pack

```ps
winget uninstall --name "Windows Web Experience Pack" --disable-interactivity --exact --silent --accept-source-agreements
```

### Paint 3D

```ps
winget uninstall --name "Paint 3D" --disable-interactivity --exact --silent --accept-source-agreements
```

### Xbox

#### Xbox TCUI

```ps
winget uninstall --name "Xbox TCUI" --disable-interactivity --exact --silent --accept-source-agreements
```

#### Xbox Console Companion

```ps
winget uninstall --name "Xbox Console Companion" --disable-interactivity --exact --silent --accept-source-agreements
```

#### Xbox Game Bar Plugin

```ps
winget uninstall --name "Xbox Game Bar Plugin" --disable-interactivity --exact --silent --accept-source-agreements
```

#### Xbox Identity Provider

```ps
winget uninstall --name "Xbox Identity Provider" --disable-interactivity --exact --silent --accept-source-agreements
```

#### Xbox Game Speech Window

```ps
winget uninstall --name "Xbox Game Speech Window" --disable-interactivity --exact --silent --accept-source-agreements
```

#### Xbox Game Bar

```ps
winget uninstall --name "Xbox Game Bar" --disable-interactivity --exact --silent --accept-source-agreements
```

#### Xbox Accessories

```ps
winget uninstall --name "Xbox Accessories" --disable-interactivity --exact --silent --accept-source-agreements
```

#### Xbox

```ps
winget uninstall --name "Xbox" --disable-interactivity --exact --silent --accept-source-agreements
```

### Paint

#### Paint

```ps
winget uninstall --name "Paint" --disable-interactivity --exact --silent --accept-source-agreements
```

#### paint.net

```ps
winget install --name "paint.net" --disable-interactivity --exact --no-upgrade --silent --accept-source-agreements --accept-package-agreements
```

### DisableLockScreenAds

#### RotatingLockScreenOverlayEnabled

```ps
Set-ItemProperty -Path Registry::HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager -Name RotatingLockScreenOverlayEnabled -Type DWord -Value 0
```

#### SubscribedContent-338387Enabled

```ps
Set-ItemProperty -Path Registry::HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager -Name SubscribedContent-338387Enabled -Type DWord -Value 0
```

### RemoveChat

```ps
Set-ItemProperty -Path Registry::HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced -Name TaskbarMn -Type DWord -Value 0
```

### DisableTelemetry

```ps
Set-ItemProperty -Path Registry::HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\DataCollection -Name Allow Telemetry -Type DWord -Value 0
```

### DisableAdvertiserId

```ps
Set-ItemProperty -Path Registry::HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\AdvertisingInfo -Name Enabled -Type DWord -Value 0
```

### RemoveWidgets

```ps
Set-ItemProperty -Path Registry::HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced -Name TaskbarDa -Type DWord -Value 0
```

### HideStartMenuRecommendedSection

```ps
Set-ItemProperty -Path Registry::HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Explorer -Name HideRecommendedSection -Type DWord -Value 1
```

### DisableStartupBoost

```ps
Set-ItemProperty -Path Registry::HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Edge -Name StartupBoostEnabled -Type DWord -Value 0
```

### RemoveTaskView

```ps
Set-ItemProperty -Path Registry::HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced -Name ShowTaskViewButton -Type DWord -Value 0
```

### RemoveTaskBarSearch

```ps
Set-ItemProperty -Path Registry::HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Search -Name SearchboxTaskbarMode -Type DWord -Value 0
```

### EnableFileExtensions

```ps
Set-ItemProperty -Path Registry::HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced -Name HideFileExt -Type DWord -Value 0
```

### EnableDeveloperMode

```ps
Set-ItemProperty -Path Registry::HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Appx -Name AllowDevelopmentWithoutDevLicense -Type DWord -Value 1
```

### MakePowerShelUnrestricted

```ps
Set-ItemProperty -Path Registry::HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\PowerShell\1\ShellIds\Microsoft.PowerShell -Name ExecutionPolicy -Type String -Value Unrestricted
```

### DisableWebSearch

```ps
Set-ItemProperty -Path Registry::HKEY_CURRENT_USER\SOFTWARE\Policies\Microsoft\Windows\Explorer -Name DisableSearchBoxSuggestions -Type DWord -Value 1
```

### DisableEdgeDesktopSearchBar

```ps
Set-ItemProperty -Path Registry::HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Edge -Name WebWidgetAllowed -Type DWord -Value 0
```

