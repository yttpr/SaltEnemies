using System;
using System.Collections.Generic;
using System.Text;
using BepInEx;
/*
namespace YourNamespace
{
    [BepInPlugin("Salt.Crossovers1", "Crossovers With Example Mod", "1.0.0")]
    [BepInDependency("Bones404.BrutalAPI", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("Salt.Hawthorne", BepInDependency.DependencyFlags.HardDependency)]//YourModHere
    [BepInDependency("Example.OtherPersonsMod", BepInDependency.DependencyFlags.HardDependency)]
    public class ExampleCrossoverEncounters : BaseUnityPlugin
    {
        public void Awake()
        {
            List<RandomEnemyGroup> list4 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("EncounterNameFromTheOtherMod"))._enemyBundles);
            list4.Add(new RandomEnemyGroup()
            {
                _enemyNames = new string[]
                {
                    "YourEnemy_EN",
                    "TheirEnemy_EN"
                }
            });
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("EncounterNameFromTheOtherMod"))._enemyBundles = list4.ToArray();
        }
    }
}
*/