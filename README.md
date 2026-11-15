# PlutoStrap

PlutoStrap is a third-party launcher for [Roblox](https://www.roblox.com) on Windows, developed by [Plutonium-Net](https://github.com/Plutonium-Net). It replaces the stock Roblox bootstrapper with one that gives you control over installation, launch behaviour, Fast Flags, client modifications and Discord integration, in a single desktop application.

PlutoStrap is built on the foundations of the open-source [Bloxstrap](https://github.com/bloxstraplabs/bloxstrap) project and retains its architecture, so existing knowledge of the launch pipeline, Fast Flags and modification system carries over.

> PlutoStrap is not affiliated with, endorsed by, or supported by Roblox Corporation or the Bloxstrap project.

## Features

- **Roblox installation management** — installs, updates and repairs the Roblox player and Studio, with background updates, forced reinstallation and channel/version selection.
- **Launch configuration** — confirm launches, choose launch behaviour, and launch either Roblox or Studio from the launcher.
- **Fast Flags** — a full editor for engine flags, plus curated presets for rendering quality, MSAA, texture quality and exclusive fullscreen.
- **Modifications** — replace cursors, sounds, fonts, emoji, and the avatar background, with the ability to restore original files.
- **Integrations** — Discord Rich Presence, game activity tracking, server location hints, and support for launching your own tools alongside Roblox.
- **Appearance** — bootstrapper styles (including classic Roblox bootstrappers), bootstrapper icons, custom themes, and light/dark application themes.
- **Shortcuts** — create desktop and Start menu shortcuts, with the option to use Roblox's historical icon set.
- **Localisation** — the interface is available in the languages inherited from the upstream Bloxstrap translations.
- **Diagnostics** — export your configuration and logs from the Advanced page when reporting a problem.

PlutoStrap does not collect telemetry. It contains no analytics, crash reporting or usage reporting, and it does not contact any Bloxstrap-owned service.

## Requirements

- Windows 10 or newer (64-bit)
- [.NET 6 Desktop Runtime](https://dotnet.microsoft.com/download/dotnet/6.0)

## Installing

Download the latest release from the [releases page](https://github.com/Plutonium-Net/plutostrap/releases) and run `PlutoStrap.exe`. It will offer to install itself to `%LOCALAPPDATA%\PlutoStrap`, register itself as the Roblox launcher, and create shortcuts. Settings can be reopened at any time from the Start menu.

## Building

PlutoStrap targets .NET 6 and WPF, so it must be built on Windows.

```
git clone --recursive https://github.com/Plutonium-Net/plutostrap.git
cd plutostrap
dotnet build PlutoStrap.sln -c Release
```

To produce the same single-file executable that the release workflow publishes:

```
dotnet publish -p:PublishSingleFile=true -r win-x64 -c Release --self-contained false .\PlutoStrap\PlutoStrap.csproj
```

The WPF UI dependency is a git submodule; a plain `git clone` without `--recursive` will not build. Release builds are produced by [`.github/workflows/ci-release.yml`](.github/workflows/ci-release.yml).

## Project structure

| Path | Purpose |
| --- | --- |
| `PlutoStrap/` | The application. |
| `PlutoStrap/Bootstrapper.cs` | Roblox installation, updating and launching. |
| `PlutoStrap/Installer.cs` | Installing, upgrading and uninstalling PlutoStrap itself. |
| `PlutoStrap/LaunchHandler.cs` | Entry-point routing for launch arguments. |
| `PlutoStrap/FastFlagManager.cs` | Fast Flag storage and presets. |
| `PlutoStrap/AppData/` | Per-product (player/Studio) installation data. |
| `PlutoStrap/Integrations/` | Activity tracking and Discord Rich Presence. |
| `PlutoStrap/UI/Elements/Settings/` | Settings window and pages. |
| `PlutoStrap/UI/Elements/Bootstrapper/` | Bootstrapper dialogs and their styles. |
| `PlutoStrap/Resources/` | Strings, icons, fonts and bundled mod files. |
| `wpfui/` | WPF UI submodule used for the interface. |

## License and attribution

PlutoStrap is licensed under the MIT License. See [LICENSE](LICENSE).

It is a derivative work of Bloxstrap, which is also MIT licensed:

> Copyright (c) 2022 pizzaboxer

The interface uses the [WPF UI](https://github.com/lepoco/wpfui) library, via Bloxstrap's fork of it. The Bloxstrap contributors and translators are credited in the About window.

## Links

- Repository: <https://github.com/Plutonium-Net/plutostrap>
- Issues: <https://github.com/Plutonium-Net/plutostrap/issues>
- Releases: <https://github.com/Plutonium-Net/plutostrap/releases>
