# General
- Please do not refer to old `z_beefs_nvg`. Check `bvg_api` for all implemented public VG api.
- All resolved BVG mod conflicts are in `bvg_monkey`.
- Consider contributing to this repo if you are willing to change VG, instead of creating new mod.
- Consider contributing to this repo if you are resolved yet another mod conflict.

# Deploy
- Mod structure is not following Stalker games structure.
- You can copy all required files manually or use `mod_pipe_deploy.sh` in project root.
- Deploying is done with virtual machine, check `./pipe/Pipe.sln`
- You will need `.Net` installed, `.sh` files use `dotnet run` command to compile and run project.
- You will need to tweak paths in `./mod/pipe/*.pipe` files.

# Pipe
- Simple virtual machine that executes instructions from `.pipe` files.
- To run machine you need to provide initial `.pipe` file path.
- Explore existing `.pipe` files to understand how it works.
- Check `Binder.cs` for all built-in instructions and procedures.
- You can extend existing operations pool to suit your demands.