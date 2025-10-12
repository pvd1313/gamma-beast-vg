![Image](image.png)

# About
Yet another remake of Beef's NVG for **DX10 / DX11** [G.A.M.M.A 0.9.4](https://discord.com/invite/stalker-gamma)

### Based on:
- Beef's NVG - theRealBeef
- FDDA Redone - lizzardman
- FDDA Redone Fixes - Kute
- G.A.M.M.A. Massive Text Overhaul Project - SageDaHerb and Dr.Pr1nkos
- G.A.M.M.A. Mod Organizer Profile (DX10 / DX11) - Grokitach

### Links:
- [Github](https://github.com/pvd1313/gamma-beast-vg)
- [G.A.M.M.A. Discord] (wip)

# Installation

### Dependencies:
- [G.A.M.M.A 0.9.4](https://discord.com/invite/stalker-gamma)
- [Mod Organizer](https://github.com/ModOrganizer2/modorganizer/releases) (included in G.A.M.M.A. 0.9.4)
- [Beef's NVG](https://www.moddb.com/addons/beefs-shader-based-nvgs-v10) (included in G.A.M.M.A. 0.9.4)
- [FDDA Redone](https://www.moddb.com/mods/stalker-anomaly/addons/fdda-redone) (included in G.A.M.M.A. 0.9.4)
- [FDDA Redone Fixes](https://www.moddb.com/addons/fdda-redone-fixes) (included in G.A.M.M.A. 0.9.4)
- [Oleh's Miscellaneous Sound Improvements]() (included in G.A.M.M.A. 0.9.4)

### G.A.M.M.A. 0.9.4 DX10 / DX11:
1. Install `Beast VG` with `Mod Organizer`.
2. Put `Beast VG` right after `FDDA Redone Fixes`.

# Changes vs Beef's NVG

### Features:
- Added MCM option to block VG when ADS with HV scopes.
- Added MCM option to block VG when ADS with NV scopes.
- Added MCM option to block VG when viewing through binocular.
- Added MCM option to remember VG state / brightness setup between levels / game loads.
- Added MCM option to change amount of brightness levels.

### Fixes:

- Fixed VG shader not following MCM logic if player tried to adjust brightness during ADS / PDA. Player can no longer adjust brightness when VG blocked.
- Fixed VG shader not following MCM logic If VG is turned on during ADS / PDA.
- Fixed changes in MCM settings are not applied to turned-on VG.

### Other:
- In-game VG brightness level control will follow "repeat" logic, instead of "ping-pong". When brightness level goes over max, it will go straight back to min, instead on max - 1.
- Major script refactoring.
- MCM structure changes.
- MCM FDDA NVG animation option moved to BVG MCM. FDDA option still there, but does nothing.

# Notes
- `Beast VG` mod is not tested on vanilla [Anomaly v1.5.3](https://www.moddb.com/mods/stalker-anomaly/news/stalker-anomaly-version-153-release)
- DX8 / DX9 are not supported.
- 2D scopes are not supported.

### Known issues:
- Integrated weapon scopes not supported.
- VG do not care if NV scope is turned on / off.

### Ideas:
- Gameplay
  - VG low battery notification.
  - Heat VG.
  - Brightness switching animation (shader gain lerp).
  - MCM option to change glitch power.
  - MCM option to change NVG color.
  - MCM option to turn off fade animation (vignette / latch).
  - MCM option to turn off VG when 3D PDA is fully opened only.
  - MCM option to tweak amount of blur in shader.
  - MCM option to tweak max view distance in shader.
  - VG brightness status display (when adjusting brightness).
  - VG brightness adjust animation (hand)
  - VG MCM better key bind config for brightness.
  - VG / torch enabled status icons.
  - VG in-game calibration (like color correction).
  - VG block animation for turn on / off (sound?).
  - VG components / upgrades / maintenance (like weapons).
    - VG zoom upgrade. (like binocular).
    - VG recognition upgrade. (like binocular).
- Youtrack / any other tracker for mod development.
- HLSL for XRay.

### Other VG mods:
- [Beef's Shader Based NVGs v1.1.1](https://www.moddb.com/addons/beefs-shader-based-nvgs-v10)
- ["Better" Beef's NVG - indiesunpraiser](https://www.moddb.com/mods/stalker-anomaly/addons/better-beefs-nvg-indiesunpraiser)
- [Gen23 NVG no distance cap](https://discord.com/channels/912320241713958912/1363252560668004522)
- [NVG Consistency](https://discord.com/channels/912320241713958912/1035900566687195159)
- [[0.9] PDA NVG Automation by G_FLAT](https://discord.com/channels/912320241713958912/1252395415958065172)
- [Beef's NVG blur removal](https://www.moddb.com/mods/stalker-anomaly/addons/beefs-nvg-blur-removal)
- [NVG Eyecups - GAMMA](https://www.moddb.com/mods/stalker-anomaly/addons/beefs-nvg-blur-removal)
- [Beef's NVG with smooth edges](https://www.moddb.com/mods/stalker-anomaly/addons/beefs-nvg-with-smooth-edges)
- [T-7 Thermal Goggles based on HeatVision v1.1 mod for Anomaly](https://discord.com/channels/912320241713958912/1168998049113178122)
- [Beefs NVGs/ Improved alt aim fix and BAS NV Scopes](https://discord.com/channels/912320241713958912/1205458333100671027)
- [Beef's NVG, Improved](https://www.moddb.com/mods/stalker-anomaly/addons/beefs-nvg-improved)

### Consider
- [HeatVision v1.3 [DLTX]](https://www.moddb.com/mods/stalker-anomaly/addons/heatvision-v02-extension-for-beefs-nvg-dx11engine-mod/)
- [Shader Based 2D Scopes [1.5.1][DX10+][Engine-mod] V1.3 DLTX support](https://www.moddb.com/mods/stalker-anomaly/addons/shader-based-2d-scopes-151dx11engine-mod)
- [Modded Exes: Ecolog Edition](https://discord.com/channels/912320241713958912/1417405402873729025)
- [Modular Attachment System](https://www.moddb.com/mods/stalker-anomaly/addons/modular-attachment-system)

# [Modding](modding.md)