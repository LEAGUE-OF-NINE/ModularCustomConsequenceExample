# ModularCustomConsequenceExample

This repository provides a template for creating a Limbus Company mod for custom modular consequences and value getters. 

# Development

1. Make sure you have installed Lethe.
2. To setup a dev environment, copy the file `Directory.Build.example.props` in `src/` and rename the copy to
   `Directory.Build.props`.
3. Modify the file as per the instructions inside.
4. Modify `BasePlugin.csproj`, change `RootNamespace` to the name of your mod.
5. Modify `main.cs`, change `BaseMod` in `namespace BaseMod;` to what you've entered in step 4.
   Change `Name`, `Version`, and `Author` as you wish.
6. Modify `AssemblyInfo.cs` and fix the line `using static BaseMod.Main;` to use the proper root namespace.
7. Whenever you build, the development build of the BepInEx plugin should automatically be copied to your game folder.

# Documentation

To implement a custom consequence and value getter, you can create your own `IModularConsequence` and `IModularAcquirer`.
Refer to [here](https://github.com/LEAGUE-OF-NINE/ModularLimbis/blob/5ff2c89d2b2e63637750eaf1cb15d33ded8c6b8b/ModularSkillScripts/ModularScripts.cs#L786)
for the meaning of the arguments. 
