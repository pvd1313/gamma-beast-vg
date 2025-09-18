# About
Next generation of Beef's NVG for DX10 / DX11 [G.A.M.M.A 0.9.4](https://discord.com/invite/stalker-gamma)

### Based on mods:
- Beef's NVG - theRealBeef
- FDDA Redone - lizzardman
- G.A.M.M.A. Massive Text Overhaul Project - SageDaHerb and Dr.Pr1nkos

### Links:
- [Github](https://github.com/pvd1313/gamma-beast-vg)
- [ModDB] (wip)
- G.A.M.M.A. Discord (wip)

# Installation

### Requirements:
- [S.T.A.L.K.E.R. Anomaly v1.5.3](https://www.moddb.com/mods/stalker-anomaly/news/stalker-anomaly-version-153-release)
- [Modded Exes: Ecolog Edition](https://github.com/ProfLander/xray-monolith/releases/)
- [Mod Organizer](https://github.com/ModOrganizer2/modorganizer/releases)
- [Beef's NVG](https://www.moddb.com/addons/beefs-shader-based-nvgs-v10)
- [FDDA Redone](https://www.moddb.com/mods/stalker-anomaly/addons/fdda-redone)

### Steps:
1. Install `Beast VG` with `Mod Organizer`.
2. Put `Beast VG` right after `FDDA Redone` or `FDDA Redone Fixes`.
3. Enjoy (:

# Changes
### Features:
- Added MCM option to block VG when ADS with HV scopes.
- Added MCM option to block VG when ADS with NV scopes.
- Added MCM option to block VG when viewing through binocular.

### Fixes:
- Removed ability to toggle VG brightness when VG is temporarily disabled, to prevent shader from turning on.

### Other:
- Major script refactoring.
- Removed support for 2D scopes.
- MCM structure changes.
- MCM FDDA NVG animation option moved to BVG MCM. FDDA option still there, but does nothing.

# Notes

### Known issues:
- Integrated weapon scopes not supported.
- Turning on VG while on ADS / binocular will turn on VG shader without following MCM defined logic.
- VG do not care if NV scope is turned on / off.
- DX8 / DX9 not supported.
- MCM settings is on applied on turned on VG.
- VG are turned on if VG is not allowed with ADS and zoom type is changed.

### Ideas:
- Gameplay
  - VG state memory during game load / level transition.
  - VG low battery notification.
  - Heat VG.
  - MCM option to turn off VG when 3D PDA is fully opened only.
  - MCM option to tweak amount of blur in shader.
  - MCM option to tweak max view distance in shader.
  - VG brightness status display (when adjusting brightness).
  - VG brightness adjust animation.
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

### Consider
- [HeatVision v1.3 [DLTX]](https://www.moddb.com/mods/stalker-anomaly/addons/heatvision-v02-extension-for-beefs-nvg-dx11engine-mod/)
- [Shader Based 2D Scopes [1.5.1][DX10+][Engine-mod] V1.3 DLTX support](https://www.moddb.com/mods/stalker-anomaly/addons/shader-based-2d-scopes-151dx11engine-mod)
- [Modded Exes: Ecolog Edition](https://discord.com/channels/912320241713958912/1417405402873729025)