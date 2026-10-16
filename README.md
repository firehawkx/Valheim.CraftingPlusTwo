# CraftingPlusTwo
A Valheim mod that adds 2 levels to the Black Forge and Galdr Table, so gear can be upgraded all the way to quality 4.

Since 1.0 a crafting station's level is derived from the extension pieces attached to it (`1 + extensions`), which dropped these two to a starting level of 1 and a ceiling of 6 (Black Forge) / 5 (Galdr Table). The final quality-4 upgrade asks for level 7, so it cannot be reached at all without this mod. The bonus keeps the pre-1.0 feel: 3 when you build the station, climbing with every extension you attach, up to 7 once the Galdr Table is fully extended.

# How to build
Requires the [.NET Framework 4.8 developer pack](https://dotnet.microsoft.com/download/dotnet-framework) and a local Valheim install with [BepInEx 5](https://github.com/BepInEx/BepInEx/releases).

```powershell
dotnet build CraftingPlusTwo.csproj -c Release
```

The build reads `BepInEx.dll` and `0Harmony.dll` from `BepInEx\core` and the game assemblies from `valheim_Data\Managed`, then copies the result into `BepInEx\plugins`. If your game lives elsewhere, point the build at it:

```powershell
dotnet build CraftingPlusTwo.csproj -c Release -p:ValheimDir=C:\Steam\steamapps\common\Valheim
```

Built for Valheim 1.0.
