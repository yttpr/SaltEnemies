using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using BepInEx;
using BepInEx.Bootstrap;
using BrutalAPI;
using UnityEngine;
using UnityEngine.UIElements;
using MonoMod.RuntimeDetour;
using JetBrains.Annotations;
using System.Text;
using System.Threading;
using System.Runtime.CompilerServices;
using Tools;
using UnityEngine.SceneManagement;
using System.Timers;
using UnityEngine.Diagnostics;
using UnityEngine.UI;
using System.Xml;
using System.Dynamic;
using static UnityEngine.UI.CanvasScaler;
using static Hawthorne.Check;

namespace Hawthorne
{
    public static class ZLD1_Encounters
    {
        public static void Add()
        {
            if (EnemyExist("ReflectedHound_EN") && BundleStatic("RefHound_Orpheum"))
            {
                List<SpecificEnemyGroup> list4 = new List<SpecificEnemyGroup>(((SpecificEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("RefHound_Orpheum"))._enemyBundles);
                list4.Add(new SpecificEnemyGroup
                {
                    _enemyGroup = new SpecificEnemyInfo[]
                    {
                    new SpecificEnemyInfo
                    { enemyName = "ReflectedHound_EN",
                    enemySlot = 2 },
                    new SpecificEnemyInfo
                    { enemyName = "TheCrow_EN",
                    enemySlot = 4 }
                    }
                });
                list4.Add(new SpecificEnemyGroup
                {
                    _enemyGroup = new SpecificEnemyInfo[]
                    {
                    new SpecificEnemyInfo
                    { enemyName = "ReflectedHound_EN",
                    enemySlot = 1 },
                    new SpecificEnemyInfo
                    { enemyName = "Enigma_EN",
                    enemySlot = 3 },
                    new SpecificEnemyInfo
                    { enemyName = "JumbleGuts_Hollowing_EN",
                    enemySlot = 0 },
                    }
                });
                ((SpecificEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("RefHound_Orpheum"))._enemyBundles = list4.ToArray();
            }
            if (EnemyExist("Teto_EN") && BundleStatic("TetoNormal"))
            {
                List<SpecificEnemyGroup> list8 = new List<SpecificEnemyGroup>(((SpecificEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("TetoNormal"))._enemyBundles);
                list8.Add(new SpecificEnemyGroup
                {
                    _enemyGroup = new SpecificEnemyInfo[]
                    {
                    new SpecificEnemyInfo
                    { enemyName = "Teto_EN",
                    enemySlot = 1 },
                    new SpecificEnemyInfo
                    { enemyName = "Teto_EN",
                    enemySlot = 0 },
                    new SpecificEnemyInfo
                    { enemyName = "LostSheep_EN",
                    enemySlot = 3 }
                    }
                });
                ((SpecificEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("TetoNormal"))._enemyBundles = list8.ToArray();
            }
            if (EnemyExist("BoulderBuddy_EN") && BundleStatic("RockBuddy_Farshore"))
            {
                List<SpecificEnemyGroup> list0 = new List<SpecificEnemyGroup>(((SpecificEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("RockBuddy_Farshore"))._enemyBundles);
                list0.Add(new SpecificEnemyGroup
                {
                    _enemyGroup = new SpecificEnemyInfo[]
                    {
                    new SpecificEnemyInfo
                    { enemyName = "BoulderBuddy_EN",
                    enemySlot = 1 },
                    new SpecificEnemyInfo
                    { enemyName = "LostSheep_EN",
                    enemySlot = 3 }
                    }
                });
                list0.Add(new SpecificEnemyGroup
                {
                    _enemyGroup = new SpecificEnemyInfo[]
                    {
                    new SpecificEnemyInfo
                    { enemyName = "BoulderBuddy_EN",
                    enemySlot = 3 },
                    new SpecificEnemyInfo
                    { enemyName = "LostSheep_EN",
                    enemySlot = 2 },
                    new SpecificEnemyInfo
                    { enemyName = "MudLung_EN",
                    enemySlot = 0 }
                    }
                });
                list0.Add(new SpecificEnemyGroup
                {
                    _enemyGroup = new SpecificEnemyInfo[]
                    {
                    new SpecificEnemyInfo
                    { enemyName = "BoulderBuddy_EN",
                    enemySlot = 2 },
                    new SpecificEnemyInfo
                    { enemyName = "DeadPixel_EN",
                    enemySlot = 3 },
                    new SpecificEnemyInfo
                    { enemyName = "DeadPixel_EN",
                    enemySlot = 4 }
                    }
                });
                ((SpecificEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("RockBuddy_Farshore"))._enemyBundles = list0.ToArray();
            }
            if (EnemyExist("Boulder_EN") && BundleStatic("Rock_Farshore"))
            {
                List<SpecificEnemyGroup> list2 = new List<SpecificEnemyGroup>(((SpecificEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Rock_Farshore"))._enemyBundles);
                list2.Add(new SpecificEnemyGroup
                {
                    _enemyGroup = new SpecificEnemyInfo[]
                    {
                    new SpecificEnemyInfo
                    { enemyName = "Boulder_EN",
                    enemySlot = 2 },
                    new SpecificEnemyInfo
                    { enemyName = "DeadPixel_EN",
                    enemySlot = 0 },
                    new SpecificEnemyInfo
                    { enemyName = "DeadPixel_EN",
                    enemySlot = 3 }
                    }
                });
                list2.Add(new SpecificEnemyGroup
                {
                    _enemyGroup = new SpecificEnemyInfo[]
                    {
                    new SpecificEnemyInfo
                    { enemyName = "Boulder_EN",
                    enemySlot = 1 },
                    new SpecificEnemyInfo
                    { enemyName = "FlaMinGoa_EN",
                    enemySlot = 3 },
                    new SpecificEnemyInfo
                    { enemyName = "LostSheep_EN",
                    enemySlot = 0 }
                    }
                });
                list2.Add(new SpecificEnemyGroup
                {
                    _enemyGroup = new SpecificEnemyInfo[]
                    {
                    new SpecificEnemyInfo
                    { enemyName = "Boulder_EN",
                    enemySlot = 2 },
                    new SpecificEnemyInfo
                    { enemyName = "Voboola_EN",
                    enemySlot = 0 },
                    new SpecificEnemyInfo
                    { enemyName = "LostSheep_EN",
                    enemySlot = 3 }
                    }
                });
                ((SpecificEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Rock_Farshore"))._enemyBundles = list2.ToArray();
                if (DoDebugs.MiscInfo) Debug.Log("rockjak");
            }
        }
    }
    public static class ZLD1TairEncounters
    {
        public static void Add()
        {
            if (MultiENExist("ReflectedHound_EN", "Gizo_EN") && BundleStatic("RefHound_Orpheum"))
            {
                List<SpecificEnemyGroup> list4 = new List<SpecificEnemyGroup>(((SpecificEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("RefHound_Orpheum"))._enemyBundles);
                list4.Add(new SpecificEnemyGroup
                {
                    _enemyGroup = new SpecificEnemyInfo[]
                    {
                    new SpecificEnemyInfo
                    { enemyName = "ReflectedHound_EN",
                    enemySlot = 3 },
                    new SpecificEnemyInfo
                    { enemyName = "LostSheep_EN",
                    enemySlot = 2 },
                    new SpecificEnemyInfo
                    { enemyName = "Gizo_EN",
                    enemySlot = 0 }
                    }
                });
                ((SpecificEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("RefHound_Orpheum"))._enemyBundles = list4.ToArray();
            }
            if (MultiENExist("Unflarb_EN", "BoulderBuddy_EN") && BundleStatic("RockBuddy_Farshore"))
            {
                List<SpecificEnemyGroup> list0 = new List<SpecificEnemyGroup>(((SpecificEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("RockBuddy_Farshore"))._enemyBundles);
                list0.Add(new SpecificEnemyGroup
                {
                    _enemyGroup = new SpecificEnemyInfo[]
                    {
                    new SpecificEnemyInfo
                    { enemyName = "BoulderBuddy_EN",
                    enemySlot = 3 },
                    new SpecificEnemyInfo
                    { enemyName = "LostSheep_EN",
                    enemySlot = 2 },
                    new SpecificEnemyInfo
                    { enemyName = "Unflarb_EN",
                    enemySlot = 0 }
                    }
                });
                ((SpecificEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("RockBuddy_Farshore"))._enemyBundles = list0.ToArray();
            }
            if (MultiENExist("Boulder_EN", "DrySimian_EN") && BundleStatic("Rock_Farshore"))
            {
                List<SpecificEnemyGroup> list2 = new List<SpecificEnemyGroup>(((SpecificEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Rock_Farshore"))._enemyBundles);
                list2.Add(new SpecificEnemyGroup
                {
                    _enemyGroup = new SpecificEnemyInfo[]
                    {
                    new SpecificEnemyInfo
                    { enemyName = "Boulder_EN",
                    enemySlot = 4 },
                    new SpecificEnemyInfo
                    { enemyName = "DrySimian_EN",
                    enemySlot = 3 },
                    new SpecificEnemyInfo
                    { enemyName = "LostSheep_EN",
                    enemySlot = 0 }
                    }
                });
                ((SpecificEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Rock_Farshore"))._enemyBundles = list2.ToArray();
                if (DoDebugs.MiscInfo) Debug.Log("ROCK");
            }
        }
    }
}
