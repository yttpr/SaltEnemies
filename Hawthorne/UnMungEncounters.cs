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
    public static class UnMungEncounters
    {
        public static void Add()
        {
            BrutalAPI.EnemyEncounter enemyEncounter = new BrutalAPI.EnemyEncounter();
            enemyEncounter.encounterName = "UnMung_Hard";
            enemyEncounter.area = 0;
            enemyEncounter.randomPlacement = true;
            enemyEncounter.hardmodeEncounter = true;
            enemyEncounter.difficulty = EncounterDifficulty.Hard;
            enemyEncounter.rarity = 8;
            if (SaltEnemies.trolling > 65)
            {
                enemyEncounter.rarity /= 2;
            }
            if (SaltEnemies.silly < 75)
            {
                enemyEncounter.rarity /= 2;
            }
            enemyEncounter.variations = new FieldEnemy[11][];
            enemyEncounter.signType = (SignType)6559;
            enemyEncounter.musicEvent = LoadedAssetsHandler.GetEnemyBundle("Zone01_Mung_Easy_EnemyBundle")._musicEventReference;
            enemyEncounter.roarEvent = LoadedAssetsHandler.GetEnemyBundle("Zone01_Mung_Easy_EnemyBundle")._roarReference.roarEvent;
            enemyEncounter.variations[0] = new FieldEnemy[1];
            enemyEncounter.variations[0][0] = new FieldEnemy()
            {
                enemyName = "TeachaMantoFish_EN",
                enemySlot = 2
            };
            enemyEncounter.variations[1] = new FieldEnemy[2];
            enemyEncounter.variations[1][0] = new FieldEnemy()
            {
                enemyName = "Mung_EN",
                enemySlot = 3
            };
            enemyEncounter.variations[1][1] = new FieldEnemy()
            {
                enemyName = "TeachaMantoFish_EN",
                enemySlot = 4
            };
            enemyEncounter.variations[2] = new FieldEnemy[2];
            enemyEncounter.variations[2][0] = new FieldEnemy()
            {
                enemyName = "TeachaMantoFish_EN",
                enemySlot = 0
            };
            enemyEncounter.variations[2][1] = new FieldEnemy()
            {
                enemyName = "JumbleGuts_Waning_EN",
                enemySlot = 1
            };
            enemyEncounter.variations[3] = new FieldEnemy[2];
            enemyEncounter.variations[3][0] = new FieldEnemy()
            {
                enemyName = "TeachaMantoFish_EN",
                enemySlot = 0
            };
            enemyEncounter.variations[3][1] = new FieldEnemy()
            {
                enemyName = "Spoggle_Ruminating_EN",
                enemySlot = 1
            };
            enemyEncounter.variations[4] = new FieldEnemy[2];
            enemyEncounter.variations[4][0] = new FieldEnemy()
            {
                enemyName = "TeachaMantoFish_EN",
                enemySlot = 0
            };
            enemyEncounter.variations[4][1] = new FieldEnemy()
            {
                enemyName = "Spoggle_Spitfire_EN",
                enemySlot = 1
            };
            enemyEncounter.variations[5] = new FieldEnemy[2];
            enemyEncounter.variations[5][0] = new FieldEnemy()
            {
                enemyName = "TeachaMantoFish_EN",
                enemySlot = 0
            };
            enemyEncounter.variations[5][1] = new FieldEnemy()
            {
                enemyName = "MudLung_EN",
                enemySlot = 1
            };
            enemyEncounter.variations[6] = new FieldEnemy[3];
            enemyEncounter.variations[6][0] = new FieldEnemy()
            {
                enemyName = "TeachaMantoFish_EN",
                enemySlot = 0
            };
            enemyEncounter.variations[6][1] = new FieldEnemy()
            {
                enemyName = "Keko_EN",
                enemySlot = 1
            };
            enemyEncounter.variations[6][2] = new FieldEnemy()
            {
                enemyName = "Keko_EN",
                enemySlot = 2
            };
            enemyEncounter.variations[7] = new FieldEnemy[2];
            enemyEncounter.variations[7][0] = new FieldEnemy()
            {
                enemyName = "TeachaMantoFish_EN",
                enemySlot = 0
            };
            enemyEncounter.variations[7][1] = new FieldEnemy()
            {
                enemyName = "Wringle_EN",
                enemySlot = 1
            };
            enemyEncounter.variations[8] = new FieldEnemy[2];
            enemyEncounter.variations[8][0] = new FieldEnemy()
            {
                enemyName = "TeachaMantoFish_EN",
                enemySlot = 0
            };
            enemyEncounter.variations[8][1] = new FieldEnemy()
            {
                enemyName = "Flarblet_EN",
                enemySlot = 1
            };
            enemyEncounter.variations[9] = new FieldEnemy[2];
            enemyEncounter.variations[9][0] = new FieldEnemy()
            {
                enemyName = "TeachaMantoFish_EN",
                enemySlot = 0
            };
            enemyEncounter.variations[9][1] = new FieldEnemy()
            {
                enemyName = "LostSheep_EN",
                enemySlot = 1
            };
            enemyEncounter.variations[10] = new FieldEnemy[3];
            enemyEncounter.variations[10][0] = new FieldEnemy()
            {
                enemyName = "TeachaMantoFish_EN",
                enemySlot = 0
            };
            enemyEncounter.variations[10][1] = new FieldEnemy()
            {
                enemyName = "DeadPixel_EN",
                enemySlot = 1
            };
            enemyEncounter.variations[10][2] = new FieldEnemy()
            {
                enemyName = "DeadPixel_EN",
                enemySlot = 2
            };
            BrutalAPI.BrutalAPI.AddSignType(enemyEncounter.signType, ResourceLoader.LoadSprite("UnMungIcon", 64));
            enemyEncounter.AddEncounter();
            if (DoDebugs.GenInfo) Debug.Log("Far Shore Encounters Loaded!");
        }
    }
    public static class UnMungEncountersTairPeep
    {
        public static void Add()
        {
            if (MultiENExist("Flarbleft_EN", "LipBug_EN"))
            {
                List<RandomEnemyGroup> list5 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("UnMung_Hard"))._enemyBundles);
                list5.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "TeachaMantoFish_EN",
                    "Flarbleft_EN"
                    }
                });
                list5.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "TeachaMantoFish_EN",
                    "LipBug_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("UnMung_Hard"))._enemyBundles = list5.ToArray();
            }
        }
    }
    public static class UnMungEncountersTaco
    {
        public static void Add()
        {
            if (EnemyExist("Monck_EN"))
            {
                List<RandomEnemyGroup> list5 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("UnMung_Hard"))._enemyBundles);
                list5.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "TeachaMantoFish_EN",
                    "Monck_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("UnMung_Hard"))._enemyBundles = list5.ToArray();
            }
        }
    }
    public static class UnMungEncountersBoth
    {
        public static void Add()
        {
            if (DoDebugs.GenInfo) Debug.Log("there are none");
        }
    }
}

