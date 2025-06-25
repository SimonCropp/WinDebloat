## Items DeBloated

 * [3D Viewer](#3d-viewer)
 * [Advertiser Id](#advertiser-id)
 * [Camera](#camera)
 * [Chat](#chat)
 * [Clock](#clock) (optional)
 * [Clipchamp](#clipchamp)
 * [Cortana](#cortana)
 * [Copilot](#copilot) (optional)
 * [Customize This Folder](#customize-this-folder) (optional)
 * [Default Browser Prompt](#default-browser-prompt) (optional)
 * [DevHome](#devhome) (optional)
 * [dotnet](#dotnet) (optional)
 * [Developer Mode](#developer-mode) (optional)
 * [Edge Bing SideBar](#edge-bing-sidebar) (optional)
 * [Edge Desktop Search Bar](#edge-desktop-search-bar)
 * [Edge Default Location To Blank](#edge-default-location-to-blank) (optional)
 * [EdgeRecommendations](#edgerecommendations)
 * [Explorer 3D Objects](#explorer-3d-objects)
 * [Explorer Classic Menu](#explorer-classic-menu) (optional)
 * [Feedback Hub](#feedback-hub)
 * [FileExtensions](#fileextensions)
 * [FilmsAndTV](#filmsandtv)
 * [Games](#games)
 * [Get Help](#get-help)
 * [Give Access To](#give-access-to) (optional)
 * [Health Check](#health-check) (optional)
 * [HP Vendorware](#hp-vendorware) (optional)
 * [Internet Connection Sharing](#internet-connection-sharing)
 * [Lock Screen Ads](#lock-screen-ads)
 * [Learn about this image](#learn-about-this-image)
 * [Mail and Calendar](#mail-and-calendar)
 * [Maps](#maps)
 * [Media Player](#media-player)
 * [Mixed Reality Portal](#mixed-reality-portal)
 * [Movies and TV](#movies-and-tv)
 * [News](#news)
 * [OneNote](#onenote)
 * [Office 365](#office-365) (optional)
 * [Office Cloud Files](#office-cloud-files) (optional)
 * [OneDrive](#onedrive) (optional)
 * [Paint 3D](#paint-3d)
 * [Paint](#paint) (optional)
 * [Pay](#pay)
 * [People](#people)
 * [Phone Link](#phone-link) (optional)
 * [Photos](#photos)
 * [Power Automate](#power-automate)
 * [PowerShell Unrestricted](#powershell-unrestricted)
 * [Printer](#printer) (optional)
 * [Print 3D](#print-3d)
 * [Program Compatibility Assistant](#program-compatibility-assistant) (optional)
 * [Quick Assist](#quick-assist) (optional)
 * [Skype](#skype)
 * [Spotify](#spotify)
 * [Startup boost](#startup-boost)
 * [Start Menu Recommendations](#start-menu-recommendations)
 * [Sticky Notes](#sticky-notes)
 * [TaskBar Search](#taskbar-search)
 * [Task View](#task-view)
 * [Teams](#teams) (optional)
 * [Teams Installer](#teams-installer)
 * [Telemetry](#telemetry)
 * [Tips](#tips)
 * [To Do](#to-do)
 * [Voice Recorder](#voice-recorder) (optional)
 * [Weather](#weather)
 * [Web Experience Pack](#web-experience-pack)
 * [Start Menu Web Search](#start-menu-web-search)
 * [Whiteboard](#whiteboard)
 * [Widgets](#widgets)
 * [Xbox](#xbox)


## Default Items Removed / Disabled


### 3D Viewer

Id to exclude: `3DViewer`

Uninstalls `3D Viewer` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

#### Command to manually apply:

```ps
winget uninstall --name "3D Viewer" --exact --all-versions
```

#### Notes:

 * [AppStore: 3D Viewer](https://apps.microsoft.com/store/detail/3d-viewer/9NBLGGH42THS)


### Advertiser Id

Id to exclude: `AdvertiserId`

#### Command to manually apply:

```ps
Set-ItemProperty -Path "Registry::HKCU\Software\Microsoft\Windows\CurrentVersion\AdvertisingInfo"`
                 -Name "Enabled"`
                 -Type "DWord"`
                 -Value "0"
```

#### Command to manually revert:

```ps
Set-ItemProperty -Path "Registry::HKCU\Software\Microsoft\Windows\CurrentVersion\AdvertisingInfo"`
                 -Name "Enabled"`
                 -Type "DWord"`
                 -Value "1"
```

#### Notes:

 * [General privacy settings in Windows](https://support.microsoft.com/en-us/windows/general-privacy-settings-in-windows-7c7f6a09-cebd-5589-c376-7f505e5bf65a)


### Camera

Id to exclude: `Camera`

Uninstalls `Windows Camera` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

#### Command to manually apply:

```ps
winget uninstall --name "Windows Camera" --exact --all-versions
```

#### Notes:

 * [AppStore: Windows Camera](https://apps.microsoft.com/store/detail/windows-camera/9WZDNCRFJBBG)


### Chat

Id to exclude: `Chat`

#### Command to manually apply:

```ps
Set-ItemProperty -Path "Registry::HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced"`
                 -Name "TaskbarMn"`
                 -Type "DWord"`
                 -Value "0"
```

#### Command to manually revert:

```ps
Set-ItemProperty -Path "Registry::HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced"`
                 -Name "TaskbarMn"`
                 -Type "DWord"`
                 -Value "1"
```

#### Notes:

 * [Managing the Teams Chat icon on Windows 11](https://learn.microsoft.com/en-us/troubleshoot/windows-client/application-management/managing-teams-chat-icon-windows-11)


### Clipchamp

Id to exclude: `Clipchamp`

Uninstalls `Clipchamp` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

#### Command to manually apply:

```ps
winget uninstall --name "Clipchamp" --exact --all-versions
```

#### Notes:

 * [AppStore: Clipchamp](https://apps.microsoft.com/store/detail/microsoft-clipchamp/9P1J8S7CCWWT)


### Cortana

Id to exclude: `Cortana`

Uninstalls `Cortana` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

#### Command to manually apply:

```ps
winget uninstall --name "Cortana" --exact --all-versions
```


### Edge Desktop Search Bar

Id to exclude: `EdgeDesktopSearchBar`

#### Command to manually apply:

```ps
Set-ItemProperty -Path "Registry::HKLM\SOFTWARE\Policies\Microsoft\Edge"`
                 -Name "WebWidgetAllowed"`
                 -Type "DWord"`
                 -Value "0"
```

#### Command to manually revert:

```ps
Set-ItemProperty -Path "Registry::HKLM\SOFTWARE\Policies\Microsoft\Edge"`
                 -Name "WebWidgetAllowed"`
                 -Type "DWord"`
                 -Value "1"
```

#### Notes:

 * [Enable the Search bar ](https://learn.microsoft.com/en-us/deployedge/microsoft-edge-policies#webwidgetallowed)


### EdgeRecommendations

Id to exclude: `EdgeRecommendations`

#### Command to manually apply:

```ps
Set-ItemProperty -Path "Registry::HKLM\SOFTWARE\Policies\Microsoft\Edge"`
                 -Name "ShowRecommendationsEnabled"`
                 -Type "DWord"`
                 -Value "0"
```

#### Command to manually revert:

```ps
Set-ItemProperty -Path "Registry::HKLM\SOFTWARE\Policies\Microsoft\Edge"`
                 -Name "ShowRecommendationsEnabled"`
                 -Type "DWord"`
                 -Value "1"
```

#### Notes:

* [Allow feature recommendations and browser assistance notifications from Microsoft Edge](https://learn.microsoft.com/en-us/deployedge/microsoft-edge-policies#showrecommendationsenabled)
* Disables "Switch default search engine Microsoft Bing in Chrome" <br><img src="/src/SwitchToBingInChrome.png" height="200px">


### Explorer 3D Objects

Id to exclude: `Explorer3DObjects`

#### Command to manually apply:

```ps
Remove-Item -Path "Registry::HKLM\Software\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{0DB7E03F-FC29-4DC6-9020-FF41B59E513A}"
```

#### Command to manually revert:

```ps
New-Item -Path "Registry::HKLM\Software\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{0DB7E03F-FC29-4DC6-9020-FF41B59E513A}" -Value ""
````


### Feedback Hub

Id to exclude: `FeedbackHub`

Uninstalls `Feedback Hub` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

#### Command to manually apply:

```ps
winget uninstall --name "Feedback Hub" --exact --all-versions
```


### FileExtensions

Id to exclude: `FileExtensions`

#### Command to manually apply:

```ps
Set-ItemProperty -Path "Registry::HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced"`
                 -Name "HideFileExt"`
                 -Type "DWord"`
                 -Value "0"
```

#### Command to manually revert:

```ps
Set-ItemProperty -Path "Registry::HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced"`
                 -Name "HideFileExt"`
                 -Type "DWord"`
                 -Value "1"
```


### FilmsAndTV

Id to exclude: `FilmsAndTV`

Uninstalls `Films & TV` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

#### Command to manually apply:

```ps
winget uninstall --name "Films & TV" --exact --all-versions
```


### Games

Id to exclude: `Games`

#### Solitaire & Casual Games

Uninstalls `Solitaire & Casual Games` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

##### Command to manually apply:

```ps
winget uninstall --name "Solitaire & Casual Games" --exact --all-versions
```


#### Microsoft Solitaire Collection

Uninstalls `Microsoft Solitaire Collection` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

##### Command to manually apply:

```ps
winget uninstall --name "Microsoft Solitaire Collection" --exact --all-versions
```



### Get Help

Id to exclude: `GetHelp`

Uninstalls `Get Help` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

#### Command to manually apply:

```ps
winget uninstall --name "Get Help" --exact --all-versions
```


### Internet Connection Sharing

Id to exclude: `InternetConnectionSharing`

Uninstalls `SharedAccess` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

#### Command to manually apply:

```ps
winget uninstall --name "SharedAccess" --exact --all-versions
```


### Lock Screen Ads

Id to exclude: `LockScreenAds`

#### RotatingLockScreenOverlayEnabled

##### Command to manually apply:

```ps
Set-ItemProperty -Path "Registry::HKCU\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"`
                 -Name "RotatingLockScreenOverlayEnabled"`
                 -Type "DWord"`
                 -Value "0"
```

##### Command to manually revert:

```ps
Set-ItemProperty -Path "Registry::HKCU\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"`
                 -Name "RotatingLockScreenOverlayEnabled"`
                 -Type "DWord"`
                 -Value "1"
```

##### Notes:

 * [Configure Windows Spotlight on the lock screen](https://learn.microsoft.com/en-us/windows/configuration/windows-spotlight)


#### SubscribedContent-338387Enabled

##### Command to manually apply:

```ps
Set-ItemProperty -Path "Registry::HKCU\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"`
                 -Name "SubscribedContent-338387Enabled"`
                 -Type "DWord"`
                 -Value "0"
```

##### Command to manually revert:

```ps
Set-ItemProperty -Path "Registry::HKCU\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager"`
                 -Name "SubscribedContent-338387Enabled"`
                 -Type "DWord"`
                 -Value "1"
```



### Learn about this image

Id to exclude: `Learnaboutthisimage`

#### Command to manually apply:

```ps
Set-ItemProperty -Path "Registry::HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\HideDesktopIcons\NewStartPanel"`
                 -Name "{2cc5ca98-6485-489a-920e-b3e88a6ccce3}"`
                 -Type "DWord"`
                 -Value "1"
```

#### Command to manually revert:

```ps
Remove-ItemProperty -Path "Registry::HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\HideDesktopIcons\NewStartPanel"`
                    -Name "{2cc5ca98-6485-489a-920e-b3e88a6ccce3}"
```

#### Notes:

* Removes "Learn about this image" from the desktop <br><img src="/src/LearnAboutThisImage.png" height="200px">
* [How to Remove the ‘Learn More About this Picture’ Icon in Windows 11](https://www.digitbin.com/remove-learn-about-this-picture-icon-windows-11/).


### Mail and Calendar

Id to exclude: `MailandCalendar`

Uninstalls `Mail and Calendar` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

#### Command to manually apply:

```ps
winget uninstall --name "Mail and Calendar" --exact --all-versions
```


### Maps

Id to exclude: `Maps`

#### Windows Maps

Uninstalls `Windows Maps` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

##### Command to manually apply:

```ps
winget uninstall --name "Windows Maps" --exact --all-versions
```


#### MapsBroker

##### Command to manually apply:

```ps
Stop-Service -Name "MapsBroker"
Set-Service -Name "MapsBroker"`
            -StartupType "Disabled"
```

##### Command to manually revert:

```ps
Set-Service -Name "MapsBroker"`
            -StartupType "Automatic"
Start-Service -Name "MapsBroker"
```



### Media Player

Id to exclude: `MediaPlayer`

Uninstalls `Windows Media Player` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

#### Command to manually apply:

```ps
winget uninstall --name "Windows Media Player" --exact --all-versions
```


### Mixed Reality Portal

Id to exclude: `MixedRealityPortal`

Uninstalls `Mixed Reality Portal` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

#### Command to manually apply:

```ps
winget uninstall --name "Mixed Reality Portal" --exact --all-versions
```


### Movies and TV

Id to exclude: `MoviesandTV`

Uninstalls `Movies & TV` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

#### Command to manually apply:

```ps
winget uninstall --name "Movies & TV" --exact --all-versions
```


### News

Id to exclude: `News`

#### Microsoft News

Uninstalls `Microsoft News` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

##### Command to manually apply:

```ps
winget uninstall --name "Microsoft News" --exact --all-versions
```


#### News

Uninstalls `News` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

##### Command to manually apply:

```ps
winget uninstall --name "News" --exact --all-versions
```



### OneNote

Id to exclude: `OneNote`

Uninstalls `OneNote for Windows 10` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

#### Command to manually apply:

```ps
winget uninstall --name "OneNote for Windows 10" --exact --all-versions
```


### Paint 3D

Id to exclude: `Paint3D`

Uninstalls `Paint 3D` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

#### Command to manually apply:

```ps
winget uninstall --name "Paint 3D" --exact --all-versions
```


### Pay

Id to exclude: `Pay`

Uninstalls `Microsoft Pay` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

#### Command to manually apply:

```ps
winget uninstall --name "Microsoft Pay" --exact --all-versions
```


### People

Id to exclude: `People`

Uninstalls `Microsoft People` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

#### Command to manually apply:

```ps
winget uninstall --name "Microsoft People" --exact --all-versions
```


### Photos

Id to exclude: `Photos`

Uninstalls `Microsoft Photos` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

#### Command to manually apply:

```ps
winget uninstall --name "Microsoft Photos" --exact --all-versions
```


### Power Automate

Id to exclude: `PowerAutomate`

Uninstalls `Power Automate` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

#### Command to manually apply:

```ps
winget uninstall --name "Power Automate" --exact --all-versions
```


### PowerShell Unrestricted

Id to exclude: `PowerShellUnrestricted`

#### Command to manually apply:

```ps
Set-ItemProperty -Path "Registry::HKLM\SOFTWARE\Microsoft\PowerShell\1\ShellIds\Microsoft.PowerShell"`
                 -Name "ExecutionPolicy"`
                 -Type "String"`
                 -Value "Unrestricted"
```

#### Command to manually revert:

```ps
Set-ItemProperty -Path "Registry::HKLM\SOFTWARE\Microsoft\PowerShell\1\ShellIds\Microsoft.PowerShell"`
                 -Name "ExecutionPolicy"`
                 -Type "String"`
                 -Value "Restricted"
```


### Print 3D

Id to exclude: `Print3D`

Uninstalls `Print 3D` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

#### Command to manually apply:

```ps
winget uninstall --name "Print 3D" --exact --all-versions
```


### Skype

Id to exclude: `Skype`

Uninstalls `Skype` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

#### Command to manually apply:

```ps
winget uninstall --name "Skype" --exact --all-versions
```

#### Notes:

 * [AppStore: Skype](https://apps.microsoft.com/store/detail/skype/9WZDNCRFJ364)


### Spotify

Id to exclude: `Spotify`

Uninstalls `Spotify Music` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

#### Command to manually apply:

```ps
winget uninstall --name "Spotify Music" --exact --all-versions
```


### Startup boost

Id to exclude: `Startupboost`

#### Command to manually apply:

```ps
Set-ItemProperty -Path "Registry::HKLM\SOFTWARE\Policies\Microsoft\Edge"`
                 -Name "StartupBoostEnabled"`
                 -Type "DWord"`
                 -Value "0"
```

#### Command to manually revert:

```ps
Set-ItemProperty -Path "Registry::HKLM\SOFTWARE\Policies\Microsoft\Edge"`
                 -Name "StartupBoostEnabled"`
                 -Type "DWord"`
                 -Value "1"
```

#### Notes:

 * [Microsoft Edge Startup boost](https://www.microsoft.com/en-us/edge/features/startup-boost)


### Start Menu Recommendations

Id to exclude: `StartMenuRecommendations`

#### Command to manually apply:

```ps
Set-ItemProperty -Path "Registry::HKLM\SOFTWARE\Policies\Microsoft\Windows\Explorer"`
                 -Name "HideRecommendedSection"`
                 -Type "DWord"`
                 -Value "1"
```

#### Command to manually revert:

```ps
Set-ItemProperty -Path "Registry::HKLM\SOFTWARE\Policies\Microsoft\Windows\Explorer"`
                 -Name "HideRecommendedSection"`
                 -Type "DWord"`
                 -Value "0"
```

#### Notes:

 * The parent path `HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Explorer` may need to be created if it doesn;t exist
 * [Policy CSP - Start / hiderecommendedsection](https://learn.microsoft.com/en-us/windows/client-management/mdm/policy-csp-start#hiderecommendedsection)


### Sticky Notes

Id to exclude: `StickyNotes`

Uninstalls `Microsoft Sticky Notes` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

#### Command to manually apply:

```ps
winget uninstall --name "Microsoft Sticky Notes" --exact --all-versions
```

#### Notes:

 * [AppStore: Sticky Notes](https://apps.microsoft.com/store/detail/microsoft-sticky-notes/9NBLGGH4QGHW)


### TaskBar Search

Id to exclude: `TaskBarSearch`

#### Command to manually apply:

```ps
Set-ItemProperty -Path "Registry::HKCU\Software\Microsoft\Windows\CurrentVersion\Search"`
                 -Name "SearchboxTaskbarMode"`
                 -Type "DWord"`
                 -Value "0"
```

#### Command to manually revert:

```ps
Set-ItemProperty -Path "Registry::HKCU\Software\Microsoft\Windows\CurrentVersion\Search"`
                 -Name "SearchboxTaskbarMode"`
                 -Type "DWord"`
                 -Value "1"
```


### Task View

Id to exclude: `TaskView`

#### Command to manually apply:

```ps
Set-ItemProperty -Path "Registry::HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced"`
                 -Name "ShowTaskViewButton"`
                 -Type "DWord"`
                 -Value "0"
```

#### Command to manually revert:

```ps
Set-ItemProperty -Path "Registry::HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced"`
                 -Name "ShowTaskViewButton"`
                 -Type "DWord"`
                 -Value "1"
```


### Teams Installer

Id to exclude: `TeamsInstaller`

Uninstalls `Teams Machine-Wide Installer` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

#### Command to manually apply:

```ps
winget uninstall --name "Teams Machine-Wide Installer" --exact --all-versions
```

#### Notes:

 * [Bulk install Teams using Windows Installer](https://learn.microsoft.com/en-us/microsoftteams/msi-deployment)


### Telemetry

Id to exclude: `Telemetry`

#### Allow Telemetry

##### Command to manually apply:

```ps
Set-ItemProperty -Path "Registry::HKLM\SOFTWARE\Policies\Microsoft\Windows\DataCollection"`
                 -Name "Allow Telemetry"`
                 -Type "DWord"`
                 -Value "0"
```

##### Command to manually revert:

```ps
Set-ItemProperty -Path "Registry::HKLM\SOFTWARE\Policies\Microsoft\Windows\DataCollection"`
                 -Name "Allow Telemetry"`
                 -Type "DWord"`
                 -Value "1"
```


#### DiagTrack

##### Command to manually apply:

```ps
Stop-Service -Name "DiagTrack"
Set-Service -Name "DiagTrack"`
            -StartupType "Disabled"
```

##### Command to manually revert:

```ps
Set-Service -Name "DiagTrack"`
            -StartupType "Automatic"
Start-Service -Name "DiagTrack"
```



### Tips

Id to exclude: `Tips`

Uninstalls `Microsoft Tips` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

#### Command to manually apply:

```ps
winget uninstall --name "Microsoft Tips" --exact --all-versions
```


### To Do

Id to exclude: `ToDo`

Uninstalls `Microsoft To Do` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

#### Command to manually apply:

```ps
winget uninstall --name "Microsoft To Do" --exact --all-versions
```

#### Notes:

 * [AppStore: To Do](https://apps.microsoft.com/store/detail/microsoft-to-do-lists-tasks-reminders/9NBLGGH5R558)


### Weather

Id to exclude: `Weather`

Uninstalls `MSN Weather` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

#### Command to manually apply:

```ps
winget uninstall --name "MSN Weather" --exact --all-versions
```


### Web Experience Pack

Id to exclude: `WebExperiencePack`

Uninstalls `Windows Web Experience Pack` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

#### Command to manually apply:

```ps
winget uninstall --name "Windows Web Experience Pack" --exact --all-versions
```


### Start Menu Web Search

Id to exclude: `StartMenuWebSearch`

#### Command to manually apply:

```ps
Set-ItemProperty -Path "Registry::HKCU\SOFTWARE\Policies\Microsoft\Windows\Explorer"`
                 -Name "DisableSearchBoxSuggestions"`
                 -Type "DWord"`
                 -Value "1"
```

#### Command to manually revert:

```ps
Set-ItemProperty -Path "Registry::HKCU\SOFTWARE\Policies\Microsoft\Windows\Explorer"`
                 -Name "DisableSearchBoxSuggestions"`
                 -Type "DWord"`
                 -Value "0"
```


### Whiteboard

Id to exclude: `Whiteboard`

Uninstalls `Microsoft Whiteboard` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

#### Command to manually apply:

```ps
winget uninstall --name "Microsoft Whiteboard" --exact --all-versions
```


### Widgets

Id to exclude: `Widgets`

#### Command to manually apply:

```ps
Set-ItemProperty -Path "Registry::HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced"`
                 -Name "TaskbarDa"`
                 -Type "DWord"`
                 -Value "0"
```

#### Command to manually revert:

```ps
Set-ItemProperty -Path "Registry::HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced"`
                 -Name "TaskbarDa"`
                 -Type "DWord"`
                 -Value "1"
```


### Xbox

Id to exclude: `Xbox`

#### Xbox TCUI

Uninstalls `Xbox TCUI` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

##### Command to manually apply:

```ps
winget uninstall --name "Xbox TCUI" --exact --all-versions
```


#### Xbox Console Companion

Uninstalls `Xbox Console Companion` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

##### Command to manually apply:

```ps
winget uninstall --name "Xbox Console Companion" --exact --all-versions
```


#### Xbox Game Bar Plugin

Uninstalls `Xbox Game Bar Plugin` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

##### Command to manually apply:

```ps
winget uninstall --name "Xbox Game Bar Plugin" --exact --all-versions
```


#### Xbox Identity Provider

Uninstalls `Xbox Identity Provider` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

##### Command to manually apply:

```ps
winget uninstall --name "Xbox Identity Provider" --exact --all-versions
```


#### Xbox Game Speech Window

Uninstalls `Xbox Game Speech Window` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

##### Command to manually apply:

```ps
winget uninstall --name "Xbox Game Speech Window" --exact --all-versions
```


#### Xbox Game Bar

Uninstalls `Xbox Game Bar` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

##### Command to manually apply:

```ps
winget uninstall --name "Xbox Game Bar" --exact --all-versions
```


#### Xbox Accessories

Uninstalls `Xbox Accessories` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

##### Command to manually apply:

```ps
winget uninstall --name "Xbox Accessories" --exact --all-versions
```


#### Xbox

Uninstalls `Xbox` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

##### Command to manually apply:

```ps
winget uninstall --name "Xbox" --exact --all-versions
```



## Optional Items Removed / Disabled


### Clock

Id to include: `Clock`

#### Windows Clock

Uninstalls `Windows Clock` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

##### Command to manually apply:

```ps
winget uninstall --name "Windows Clock" --exact --all-versions
```

##### Notes:

 * [AppStore: Windows Clock](https://apps.microsoft.com/store/detail/windows-clock/9WZDNCRFJ3PR)


#### Windows Alarms & Clock

Uninstalls `Windows Alarms & Clock` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

##### Command to manually apply:

```ps
winget uninstall --name "Windows Alarms & Clock" --exact --all-versions
```



### Copilot

Id to include: `Copilot`

#### Microsoft Copilot

Uninstalls `Microsoft Copilot` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

##### Command to manually apply:

```ps
winget uninstall --name "Microsoft Copilot" --exact --all-versions
```


#### Microsoft 365 Copilot

Uninstalls `Microsoft 365 Copilot` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

##### Command to manually apply:

```ps
winget uninstall --name "Microsoft 365 Copilot" --exact --all-versions
```



### Customize This Folder

Id to include: `CustomizeThisFolder`

#### Command to manually apply:

```ps
Set-ItemProperty -Path "Registry::HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer"`
                 -Name "NoCustomizeThisFolder"`
                 -Type "DWord"`
                 -Value "1"
```

#### Command to manually revert:

```ps
Set-ItemProperty -Path "Registry::HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer"`
                 -Name "NoCustomizeThisFolder"`
                 -Type "DWord"`
                 -Value "0"
```

#### Notes:

* Removes Explorer "Customize this folder" functionality. Both from the context menu and from the properties tab.


### Default Browser Prompt

Id to include: `DefaultBrowserPrompt`

#### DefaultBrowserSettingEnabled

##### Command to manually apply:

```ps
Set-ItemProperty -Path "Registry::HKCU\Software\Policies\Google\Chrome"`
                 -Name "DefaultBrowserSettingEnabled"`
                 -Type "DWord"`
                 -Value "0"
```

##### Command to manually revert:

```ps
Set-ItemProperty -Path "Registry::HKCU\Software\Policies\Google\Chrome"`
                 -Name "DefaultBrowserSettingEnabled"`
                 -Type "DWord"`
                 -Value "1"
```

##### Notes:

* Disables the prompt to set chrome as the default browser
* Use [Change Default Apps in Windows](https://support.microsoft.com/en-au/windows/change-default-apps-in-windows-e5d82cad-17d1-c53b-3505-f10a32e1894d) to manually control the default browser


#### DefaultBrowserSettingEnabled

##### Command to manually apply:

```ps
Set-ItemProperty -Path "Registry::HKCU\Software\Policies\Microsoft\Edge"`
                 -Name "DefaultBrowserSettingEnabled"`
                 -Type "DWord"`
                 -Value "0"
```

##### Command to manually revert:

```ps
Set-ItemProperty -Path "Registry::HKCU\Software\Policies\Microsoft\Edge"`
                 -Name "DefaultBrowserSettingEnabled"`
                 -Type "DWord"`
                 -Value "1"
```

##### Notes:

* Disables the prompt to set edge as the default browser
* Use [Change Default Apps in Windows](https://support.microsoft.com/en-au/windows/change-default-apps-in-windows-e5d82cad-17d1-c53b-3505-f10a32e1894d) to manually control the default browser



### DevHome

Id to include: `DevHome`

Uninstalls `DevHome` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

#### Command to manually apply:

```ps
winget uninstall "DevHome --all-versions"
```

#### Notes:

 * [Dev Home](https://learn.microsoft.com/en-us/windows/dev-home/)


### dotnet

Id to include: `dotnet`

Sets environment variable `DOTNET_CLI_TELEMETRY_OPTOUT` to `true`.

#### Command to manually apply:

```ps
$env:DOTNET_CLI_TELEMETRY_OPTOUT = "true";
```

#### Notes:

 * [Opt out of .NET SDK and .NET CLI telemetry](https://learn.microsoft.com/en-us/dotnet/core/tools/telemetry#how-to-opt-out)


### Developer Mode

Id to include: `DeveloperMode`

#### Command to manually apply:

```ps
Set-ItemProperty -Path "Registry::HKLM\SOFTWARE\Policies\Microsoft\Windows\Appx"`
                 -Name "AllowDevelopmentWithoutDevLicense"`
                 -Type "DWord"`
                 -Value "1"
```

#### Command to manually revert:

```ps
Set-ItemProperty -Path "Registry::HKLM\SOFTWARE\Policies\Microsoft\Windows\Appx"`
                 -Name "AllowDevelopmentWithoutDevLicense"`
                 -Type "DWord"`
                 -Value "0"
```

#### Notes:

 * [Developer Mode features and debugging](https://learn.microsoft.com/en-us/windows/apps/get-started/developer-mode-features-and-debugging)


### Edge Bing SideBar

Id to include: `EdgeBingSideBar`

#### Command to manually apply:

```ps
Set-ItemProperty -Path "Registry::HKLM\SOFTWARE\Policies\Microsoft\Edge"`
                 -Name "HubsSidebarEnabled"`
                 -Type "DWord"`
                 -Value "0"
```

#### Command to manually revert:

```ps
Set-ItemProperty -Path "Registry::HKLM\SOFTWARE\Policies\Microsoft\Edge"`
                 -Name "HubsSidebarEnabled"`
                 -Type "DWord"`
                 -Value "1"
```

#### Notes:

* [Microsoft Edge now has a Bing AI chatbot sidebar](https://www.theverge.com/2023/3/14/23639375/microsoft-edge-bing-ai-sidebar-chatbot-feature)
* Disables the Edge Bing Sidebar <br><img src="/src/edgeBingIcon.png" height="200px">


### Edge Default Location To Blank

Id to include: `EdgeDefaultLocationToBlank`

#### HomepageLocation

##### Command to manually apply:

```ps
Set-ItemProperty -Path "Registry::HKCU\SOFTWARE\Policies\Microsoft\Edge"`
                 -Name "HomepageLocation"`
                 -Type "String"`
                 -Value "about:blank"
```

##### Command to manually revert:

```ps
Remove-ItemProperty -Path "Registry::HKCU\SOFTWARE\Policies\Microsoft\Edge"`
                    -Name "HomepageLocation"
```

##### Notes:

 * [Set home page to blank](https://learn.microsoft.com/en-us/deployedge/microsoft-edge-policies#homepagelocation)


#### NewTabPageLocation

##### Command to manually apply:

```ps
Set-ItemProperty -Path "Registry::HKCU\SOFTWARE\Policies\Microsoft\Edge"`
                 -Name "NewTabPageLocation"`
                 -Type "String"`
                 -Value "about:blank"
```

##### Command to manually revert:

```ps
Remove-ItemProperty -Path "Registry::HKCU\SOFTWARE\Policies\Microsoft\Edge"`
                    -Name "NewTabPageLocation"
```

##### Notes:

 * [Set new tab to blank](https://learn.microsoft.com/en-us/deployedge/microsoft-edge-policies#newtabpagelocation)



### Explorer Classic Menu

Id to include: `ExplorerClassicMenu`

#### Command to manually apply:

```ps
New-Item -Path "Registry::HKCU\Software\Classes\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\InprocServer32" -Value ""
````

#### Command to manually revert:

```ps
Remove-Item -Path "Registry::HKCU\Software\Classes\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\InprocServer32"
```


### Give Access To

Id to include: `GiveAccessTo`

#### Command to manually apply:

```ps
Set-ItemProperty -Path "Registry::HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Shell Extensions\Blocked"`
                 -Name "{f81e9010-6ea4-11ce-a7ff-00aa003ca9f6}"`
                 -Type "String"`
                 -Value ""
```

#### Command to manually revert:

```ps
Remove-ItemProperty -Path "Registry::HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Shell Extensions\Blocked"`
                    -Name "{f81e9010-6ea4-11ce-a7ff-00aa003ca9f6}"
```

#### Notes:

* Removes Explorer "Give access to" functionality. Both from the context menu and from the properties tab.


### Health Check

Id to include: `HealthCheck`

Uninstalls `Windows PC Health Check` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

#### Command to manually apply:

```ps
winget uninstall --name "Windows PC Health Check" --exact --all-versions
```

#### Notes:

 * [How to use the PC Health Check app](https://support.microsoft.com/en-us/windows/how-to-use-the-pc-health-check-app-9c8abd9b-03ba-4e67-81ef-36f37caa7844)


### HP Vendorware

Id to include: `HP`

#### HP Desktop Support Utilities

Uninstalls `HP Desktop Support Utilities` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

##### Command to manually apply:

```ps
winget uninstall --name "HP Desktop Support Utilities" --exact --all-versions
```


#### HP Documentation

Uninstalls `HP Documentation` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

##### Command to manually apply:

```ps
winget uninstall --name "HP Documentation" --exact --all-versions
```


#### HP Notifications

Uninstalls `HP Notifications` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

##### Command to manually apply:

```ps
winget uninstall --name "HP Notifications" --exact --all-versions
```


#### HPHelp

Uninstalls `HPHelp` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

##### Command to manually apply:

```ps
winget uninstall --name "HPHelp" --exact --all-versions
```


#### HpTouchpointAnalyticsService

##### Command to manually apply:

```ps
Stop-Service -Name "HpTouchpointAnalyticsService"
Set-Service -Name "HpTouchpointAnalyticsService"`
            -StartupType "Disabled"
```

##### Command to manually revert:

```ps
Set-Service -Name "HpTouchpointAnalyticsService"`
            -StartupType "Automatic"
Start-Service -Name "HpTouchpointAnalyticsService"
```


#### HPAppHelperCap

##### Command to manually apply:

```ps
Stop-Service -Name "HPAppHelperCap"
Set-Service -Name "HPAppHelperCap"`
            -StartupType "Disabled"
```

##### Command to manually revert:

```ps
Set-Service -Name "HPAppHelperCap"`
            -StartupType "Automatic"
Start-Service -Name "HPAppHelperCap"
```


#### HPDiagsCap

##### Command to manually apply:

```ps
Stop-Service -Name "HPDiagsCap"
Set-Service -Name "HPDiagsCap"`
            -StartupType "Disabled"
```

##### Command to manually revert:

```ps
Set-Service -Name "HPDiagsCap"`
            -StartupType "Automatic"
Start-Service -Name "HPDiagsCap"
```


#### HPSysInfoCap

##### Command to manually apply:

```ps
Stop-Service -Name "HPSysInfoCap"
Set-Service -Name "HPSysInfoCap"`
            -StartupType "Disabled"
```

##### Command to manually revert:

```ps
Set-Service -Name "HPSysInfoCap"`
            -StartupType "Automatic"
Start-Service -Name "HPSysInfoCap"
```


#### hpsvcsscan

##### Command to manually apply:

```ps
Stop-Service -Name "hpsvcsscan"
Set-Service -Name "hpsvcsscan"`
            -StartupType "Disabled"
```

##### Command to manually revert:

```ps
Set-Service -Name "hpsvcsscan"`
            -StartupType "Automatic"
Start-Service -Name "hpsvcsscan"
```


#### HotKeyServiceDSU

##### Command to manually apply:

```ps
Stop-Service -Name "HotKeyServiceDSU"
Set-Service -Name "HotKeyServiceDSU"`
            -StartupType "Disabled"
```

##### Command to manually revert:

```ps
Set-Service -Name "HotKeyServiceDSU"`
            -StartupType "Automatic"
Start-Service -Name "HotKeyServiceDSU"
```



### Office 365

Id to include: `Office365`

Uninstalls `Microsoft 365 (Office)` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

#### Command to manually apply:

```ps
winget uninstall --name "Microsoft 365 (Office)" --exact --all-versions
```


### Office Cloud Files

Id to include: `OfficeCloudFiles`

#### Command to manually apply:

```ps
Set-ItemProperty -Path "Registry::HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer"`
                 -Name "ShowCloudFilesInQuickAccess"`
                 -Type "DWord"`
                 -Value "0"
```

#### Command to manually revert:

```ps
Set-ItemProperty -Path "Registry::HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer"`
                 -Name "ShowCloudFilesInQuickAccess"`
                 -Type "DWord"`
                 -Value "1"
```

#### Notes:

* Disables Office cloud files in explorer<br>
  <img src="/src/OfficeExplorer.png" height="200px"><br>
  <img src="/src/OfficeExplorerDialog.png" height="150px"><br>
  <img src="/src/OfficeExplorerOptions.png" height="300px">


### OneDrive

Id to include: `OneDrive`

#### Microsoft OneDrive

Uninstalls `Microsoft OneDrive` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

##### Command to manually apply:

```ps
winget uninstall "Microsoft OneDrive --all-versions"
```

##### Notes:

 * [OneDrive Personal Cloud Storage](https://www.microsoft.com/en-au/microsoft-365/onedrive/online-cloud-storage)


#### OneDrive

Uninstalls `OneDrive` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

##### Command to manually apply:

```ps
winget uninstall "OneDrive --all-versions"
```



### Paint

Id to include: `Paint`

#### Paint

Uninstalls `Paint` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

##### Command to manually apply:

```ps
winget uninstall --name "Paint" --exact --all-versions
```


#### paint.net

Installs `paint.net` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

##### Command to manually apply:

```ps
winget install --name "paint.net" --exact
```



### Phone Link

Id to include: `PhoneLink`

Uninstalls `Phone Link` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

#### Command to manually apply:

```ps
winget uninstall --name "Phone Link" --exact --all-versions
```

#### Notes:

 * [AppStore: Phone Link](https://apps.microsoft.com/store/detail/phone-link/9NMPJ99VJBWV)


### Printer

Id to include: `Printer`

#### Command to manually apply:

```ps
Stop-Service -Name "Spooler"
Set-Service -Name "Spooler"`
            -StartupType "Disabled"
```

#### Command to manually revert:

```ps
Set-Service -Name "Spooler"`
            -StartupType "Automatic"
Start-Service -Name "Spooler"
```


### Program Compatibility Assistant

Id to include: `ProgramCompatibilityAssistant`

#### Command to manually apply:

```ps
Stop-Service -Name "PcaSvc"
Set-Service -Name "PcaSvc"`
            -StartupType "Disabled"
```

#### Command to manually revert:

```ps
Set-Service -Name "PcaSvc"`
            -StartupType "Automatic"
Start-Service -Name "PcaSvc"
```


### Quick Assist

Id to include: `QuickAssist`

Uninstalls `Quick Assist` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

#### Command to manually apply:

```ps
winget uninstall --name "Quick Assist" --exact --all-versions
```

#### Notes:

 * [Solve PC problems over a remote connection](https://support.microsoft.com/en-us/windows/solve-pc-problems-over-a-remote-connection-b077e31a-16f4-2529-1a47-21f6a9040bf3)


### Teams

Id to include: `Teams`

#### Microsoft.Teams.Classic

Uninstalls `Microsoft.Teams.Classic` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

##### Command to manually apply:

```ps
winget uninstall --name "Microsoft.Teams.Classic" --exact --all-versions
```

##### Notes:

 * [Microsoft Teams](https://www.microsoft.com/en-au/microsoft-teams/group-chat-software)


#### Microsoft Teams (personal)

Uninstalls `Microsoft Teams (personal)` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

##### Command to manually apply:

```ps
winget uninstall --name "Microsoft Teams (personal)" --exact --all-versions
```


#### Microsoft.Teams

Uninstalls `Microsoft.Teams` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

##### Command to manually apply:

```ps
winget uninstall --name "Microsoft.Teams" --exact --all-versions
```



### Voice Recorder

Id to include: `VoiceRecorder`

Uninstalls `Windows Voice Recorder` using [winget](https://learn.microsoft.com/en-us/windows/package-manager/winget/).

#### Command to manually apply:

```ps
winget uninstall --name "Windows Voice Recorder" --exact --all-versions
```


