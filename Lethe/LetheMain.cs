using ModularSkillScripts;
using BepInEx.Unity.IL2CPP;
using BepInEx;
using Lethe;
using Lethe.Patches;
using ModularSkillScripts.Consequence;

namespace ModularCustomConsequences;

[BepInPlugin(GUID, NAME, VERSION)]
[BepInDependency("GlitchGames.ModularSkillScripts")]
public class Main : BasePlugin
{
    // Edit the below to your own plugin name, version, etc.
    public const string NAME = "ModularCustomConsequences";
    public const string VERSION = "1.0.0";
    public const string AUTHOR = "LeagueOfNine";
    public const string GUID = $"{AUTHOR}.{NAME}";

    public class myConsequenceClass : IModularConsequence // creates a class to be added to the consequence dict of modular 
    {
        public void ExecuteConsequence(ModularSA modular, string section, string circledSection, string[] circles) // put all the actual consequence code inside this execute
        {
        // The following code is taken from the "Break" consequence of Modular, staggering a unit.
        
   	    var modelList = modular.GetTargetModelList(circles[0]); // gets target from first param 
		if (modelList.Count < 1) return; 
  
		string opt2_string = circles.Length >= 2 ? circles[1] : "natural"; // if there is no 2nd argument in the param, use "natural"
		bool force = opt2_string != "natural";
		bool both = opt2_string == "both";
		bool resistancebreak = circles.Length <= 2;

		foreach (BattleUnitModel targetModel in modelList) // loop over every possible target in the list
		{
            // code to change the ability source depending on what the script is run on, a Skill or a Passive
			ABILITY_SOURCE_TYPE abilitySourceType = ABILITY_SOURCE_TYPE.SKILL;
			if (modular.abilityMode == 2) abilitySourceType = ABILITY_SOURCE_TYPE.PASSIVE;

            // possible cases based off of previous parameters
			if (force) targetModel.BreakForcely(modular.modsa_unitModel, abilitySourceType, modular.battleTiming, false, modular.modsa_selfAction);
			if (!force || both) targetModel.Break(modular.modsa_unitModel, modular.battleTiming, modular.modsa_selfAction);
			if (resistancebreak) targetModel.ChangeResistOnBreak();
        }
    }
    public override void Load()
    {
        MainClass.consequenceDict["myConsequence"] = new myConsequenceClass(); // Adds the consequence to the consequence dict in modular
        LetheHooks.LOG.LogError("THE MODULAR CONSEQUNCE HAS ARRIVED!!!"); // optional logging, feel free to remove.
    }
   
}



