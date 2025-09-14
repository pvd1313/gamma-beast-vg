# About
Next generation of Beef's NVG for [G.A.M.M.A.](https://discord.com/invite/stalker-gamma)

### Based on mods:
- Beef's NVG - theRealBeef
- FDDA Redone - lizzardman
- G.A.M.M.A. Massive Text Overhaul Project - SageDaHerb and Dr.Pr1nkos

### Links:
- [Beast VG git](https://github.com/pvd1313/gamma-beast-vg)

# Requirements
- [S.T.A.L.K.E.R. Anomaly v.1.5.3](https://www.moddb.com/mods/stalker-anomaly/news/stalker-anomaly-version-153-release)
- [Mod Organizer](https://github.com/ModOrganizer2/modorganizer/releases)
- [Beef's NVG](https://www.moddb.com/addons/beefs-shader-based-nvgs-v10)
- [FDDA Redone](https://www.moddb.com/mods/stalker-anomaly/addons/fdda-redone)

# Installation
1. Install `Beast VG` with `Mod Organizer`.
2. Put `Beast VG` right after `FDDA Redone`.
3. Enjoy (:

# Changes
### Features:
- Added MCM option to temporary disable NVGs when ADS with HV scopes.
- Added MCM option to temporary disable NVGs when ADS with NV scopes.
- Added MCM option to temporary disable NVGs when viewing through binocular.

### Fixes:
- Removed ability to toggle NVGs brightness when NVGs is temporary disabled, to prevent shader from turning on.

### Other:
- Removed support for 2D scopes.

# Known issues
- Turning on NVG while on ADS / binocular will turn on NVG shader without following MCM defined logic.
- Integrated weapon scopes not supported.
- NVG does not care if NV scope is turned on / off.

# TODO
- Add VG state memory during game load / level transition.
- Add VG low battery notification.
- Add Heat VG.
- Add MCM option to turn off VG when 3D PDA is fully opened only.
- Add support for integrated scopes.
- Add MCM option to tweak amount of blur in shader.
- Add MCM option to tweak max view distance in shader.
