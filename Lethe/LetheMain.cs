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
    public const string NAME = "ModularCustomConsequences";
    public const string VERSION = "1.0.0";
    public const string AUTHOR = "LeagueOfNine";
    public const string GUID = $"{AUTHOR}.{NAME}";

    public class myConsequenceClass : IModularConsequence
    {
        public void ExecuteConsequence(ModularSA modular, string section, string circledSection, string[] circles)
        {
   
        }
    }
    public override void Load()
    {
        MainClass.consequenceDict["myConsequence"] = new myConsequenceClass();
        LetheHooks.LOG.LogError("THE MODULAR CONSEQUNCE HAS ARRIVED!!!");
    }
   
}



