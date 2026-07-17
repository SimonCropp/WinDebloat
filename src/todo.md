# WinDebloat — candidate additions

Gap analysis of WinDebloat's current groups vs. mature debloaters (privacy.sexy, Win11Debloat).
All registry keys below were verified against Microsoft Learn / admx.help (not copied blindly — see the
Recall note for why that matters). Each maps to an existing `RegistryValueJob` / `DisableServiceJob` pattern.

Job signature for reference:
`RegistryValueJob(Hive, Key, KeyName/*value name*/, ApplyValue, RevertValue, Name, Kind = DWord, Notes = null)`

After adding groups, run `dotnet test src/Tests/Tests.csproj` so `DocsTests` regenerates `actions.include.md`.

---

## Tier 1 — recommended

### 1. Disable Windows Consumer Features  *(biggest gap for a debloater)* — ✅ DONE (opt-in)
Implemented as opt-in group `Consumer Features` (Id `ConsumerFeatures`, `IsDefault = false`) in Program_Groups.cs.
Stops Windows silently (re)installing promoted/suggested apps (Candy Crush, TikTok, etc.) — the exact
bloat WinDebloat spends its time removing. Today WinDebloat uninstalls apps but nothing stops them returning.

- Key: `HKLM\SOFTWARE\Policies\Microsoft\Windows\CloudContent`
- Value: `DisableWindowsConsumerFeatures` = `1` (DWORD), revert `0`
- Source: https://admx.help/?Category=Windows_10_2016&Policy=Microsoft.Policies.CloudContent::DisableWindowsConsumerFeatures
- Caveat (put in Notes): fully effective on Pro/Enterprise/Education; Microsoft has curtailed its effect on Home in recent builds.
- Suggested group: new `Consumer Features`, default `true`.

```csharp
new(
    "Consumer Features",
    true,
    new RegistryValueJob(
        RegistryHive.LocalMachine,
        @"SOFTWARE\Policies\Microsoft\Windows\CloudContent",
        "DisableWindowsConsumerFeatures",
        1,
        0,
        "DisableWindowsConsumerFeatures",
        Notes:
        """
        * Stops Windows silently installing promoted/suggested apps (e.g. Candy Crush, TikTok)
        * Fully effective on Pro/Enterprise/Education; effect on Home is limited in recent builds
        * [admx.help: DisableWindowsConsumerFeatures](https://admx.help/?Category=Windows_10_2016&Policy=Microsoft.Policies.CloudContent::DisableWindowsConsumerFeatures)
        """)),
```

### 2. Disable Recall (AI snapshot analysis) — ✅ DONE (opt-in)
Implemented as opt-in group `Recall` (Id `Recall`, `IsDefault = false`) in Program_Groups.cs.
Non-default for consistency with the existing `Copilot` group — see the open question below, now resolved.

- Key: `HKLM\SOFTWARE\Policies\Microsoft\Windows\WindowsAI`
- Value: `DisableAIDataAnalysis` = `1` (DWORD), revert `0`
- Source: https://learn.microsoft.com/en-us/windows/client-management/mdm/policy-csp-windowsai#disableaidataanalysis
- Applies to Windows 11 24H2+ (KB5055627, build 26100.3915+). Current dev machine is 26200 → qualifies.
- ⚠️ NOTE: privacy.sexy ships this under an **outdated `WindowsCopilot` path**. Microsoft's official key is
  `WindowsAI` (verified on MS Learn). Use `WindowsAI`.
- Suggested group: new `Recall` (or fold into `Copilot`). Default is a convention call — see open question below.

```csharp
new(
    "Recall",
    false, // see open question re: default vs non-default for AI features
    new RegistryValueJob(
        RegistryHive.LocalMachine,
        @"SOFTWARE\Policies\Microsoft\Windows\WindowsAI",
        "DisableAIDataAnalysis",
        1,
        0,
        "DisableAIDataAnalysis",
        Notes:
        """
        * Disables saving snapshots for Windows Recall (AI screen-capture/analysis)
        * Official key is `WindowsAI` (not `WindowsCopilot`, which some tools use)
        * [Microsoft Learn: WindowsAI CSP - DisableAIDataAnalysis](https://learn.microsoft.com/en-us/windows/client-management/mdm/policy-csp-windowsai#disableaidataanalysis)
        """)),
```

### 3. Strengthen the existing `Telemetry` group
Today `Telemetry` is only `AllowTelemetry` + DiagTrack service. Add three well-sourced jobs to the existing group:

**Activity History / Timeline** — `HKLM\SOFTWARE\Policies\Microsoft\Windows\System`
- `EnableActivityFeed` = `0` (revert `1`)
- `PublishUserActivities` = `0` (revert `1`)
- `UploadUserActivities` = `0` (revert `1`)
- Source: https://admx.help/?Category=Windows_10_2016&Policy=Microsoft.Policies.OSPolicies::EnableActivityFeed

**Feedback nag prompts** — `HKLM\SOFTWARE\Policies\Microsoft\Windows\DataCollection`
- `DoNotShowFeedbackNotifications` = `1` (revert `0`)
- Source: https://learn.microsoft.com/en-us/windows/privacy/manage-connections-from-windows-operating-system-components-to-microsoft-services#1816-feedback--diagnostics

**App-launch tracking ("most used apps")** — `HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced`
- `Start_TrackProgs` = `0` (revert `1`)
- Same `Explorer\Advanced` key WinDebloat already uses for FileExtensions/TaskView/etc.

```csharp
// add into the existing "Telemetry" group Jobs list:
new RegistryValueJob(
    RegistryHive.LocalMachine, @"SOFTWARE\Policies\Microsoft\Windows\System",
    "EnableActivityFeed", 0, 1, "EnableActivityFeed"),
new RegistryValueJob(
    RegistryHive.LocalMachine, @"SOFTWARE\Policies\Microsoft\Windows\System",
    "PublishUserActivities", 0, 1, "PublishUserActivities"),
new RegistryValueJob(
    RegistryHive.LocalMachine, @"SOFTWARE\Policies\Microsoft\Windows\System",
    "UploadUserActivities", 0, 1, "UploadUserActivities"),
new RegistryValueJob(
    RegistryHive.LocalMachine, @"SOFTWARE\Policies\Microsoft\Windows\DataCollection",
    "DoNotShowFeedbackNotifications", 1, 0, "DoNotShowFeedbackNotifications"),
new RegistryValueJob(
    RegistryHive.CurrentUser, @"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
    "Start_TrackProgs", 0, 1, "Start_TrackProgs"),
```

---

## Tier 2 — reasonable, extends existing groups

### 4. Disable Click to Do (Recall-adjacent AI) — ✅ DONE (opt-in)
Implemented as opt-in group `Click to Do` (Id `ClickToDo`, `IsDefault = false`) in Program_Groups.cs.
Kept as its own group rather than folded into `Recall`: Click to Do is a separate Windows feature with its
own Settings toggle and works independently of Recall, so bundling would remove the ability to pick one.

- Key: `HKLM\SOFTWARE\Policies\Microsoft\Windows\WindowsAI`
- Value: `DisableClickToDo` = `1` (DWORD), revert `0`
- Source: https://learn.microsoft.com/en-us/windows/client-management/mdm/policy-csp-windowsai#disableclicktodo
- ⚠️ Unlike `DisableAIDataAnalysis` (GA on 24H2 + KB5055627), MS Learn lists `DisableClickToDo` applicability
  as **Windows Insider Preview only**, under the page-level "under development / subject to change" banner.
  Shipped anyway — the value is inert on builds that don't honour it, and forward-compatible when they do.
  Worth re-checking the page later to see if applicability has widened to retail; if so, drop the caveat
  from the group's Notes.

### 5. Suggested content in the Settings app
Extends the existing `Lock Screen Ads` group's ContentDeliveryManager usage.
- Key: `HKCU\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager`
- `SubscribedContent-338393Enabled` = `0` (revert `1`)
- `SubscribedContent-353694Enabled` = `0` (revert `1`)
- Source: privacy.sexy "Disable suggested content in Settings app" (admx.help / MS Learn RDS recommendations)

---

## Tier 3 — deliberately skipped

- **Location, Find My Device, Snap Layouts, mouse acceleration, Sticky Keys, Storage Sense, fast startup**
  (Win11Debloat includes these) — UX/feature *preferences*, not bloat or telemetry. Off-brand for WinDebloat
  and they invite "why did it change my mouse?" complaints.
- **Telemetry scheduled tasks** (Microsoft Compatibility Appraiser, Consolidator, UsbCeip) — high value, but
  WinDebloat has **no scheduled-task job type**. Would require a new `DisableScheduledTaskJob`. Possible future
  enhancement, not a quick add.

---

## Open question — group defaults

`default vs non-default` is a project-convention call:
- Consumer Features + Telemetry additions → clean defaults (pure anti-bloat/telemetry).
- Recall + Click to Do (AI) → `Copilot` is currently **non-default**; for consistency these AI items are
  probably non-default too. Decide before wiring in.

**Resolved for AI items:** `Recall` shipped as **non-default** (opt-in), matching `Copilot`. Apply the same
to `Click to Do` (#4) when wired in.

---

## Investigated & rejected

- **"Windows Update is committed to helping reduce carbon emissions" banner** — no durable registry toggle.
  Empirically tested on 26200: the only carbon/sustainability flag in the Update registry,
  `HKLM\...\WindowsUpdate\Orchestrator\Settings!LEGACYUOPROVIDERACTION_SUSTAINABLEDEFERRALALLOWED`, set to `0`
  + UsoSvc restart + Settings reopen → **banner persisted**. That value also lives in the Orchestrator's
  server-pushed config blob (refreshed ~daily), so it wouldn't be durable even if it worked. Banner is gated by
  online carbon-intensity data availability, not a local flag. Don't add a job for it.
