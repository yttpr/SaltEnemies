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

namespace Hawthorne
{
    public static class StarsEncounters
    {
        public static void Add()
        {
            BrutalAPI.EnemyEncounter enemyEncounter = new BrutalAPI.EnemyEncounter();
            enemyEncounter.encounterName = "StarGazers_Hard";
            enemyEncounter.area = 2;
            enemyEncounter.randomPlacement = true;
            enemyEncounter.hardmodeEncounter = true;
            enemyEncounter.difficulty = EncounterDifficulty.Hard;
            enemyEncounter.rarity = 2;
            if (SaltEnemies.trolling == 99)
            {
                enemyEncounter.rarity = 99;
            }
            if (SaltEnemies.silly == 99)
            {
                enemyEncounter.rarity *= 11;
            }
            enemyEncounter.signType = (SignType)6331;
            enemyEncounter.musicEvent = LoadedAssetsHandler.GetEnemyBundle("Zone02_JumbleGuts_Hollowing_Medium_EnemyBundle")._musicEventReference;
            enemyEncounter.roarEvent = LoadedAssetsHandler.GetEnemyBundle("Zone02_JumbleGuts_Hollowing_Medium_EnemyBundle")._roarReference.roarEvent;
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){ enemyName = "StarGazer_EN", enemySlot = 0 },
                new FieldEnemy(){ enemyName = "StarGazer_EN", enemySlot = 1 },
                new FieldEnemy(){ enemyName = "StarGazer_EN", enemySlot = 2 },
                new FieldEnemy(){ enemyName = "StarGazer_EN", enemySlot = 3 },
                new FieldEnemy(){ enemyName = "StarGazer_EN", enemySlot = 4 },
            });
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){ enemyName = "StarGazer_EN", enemySlot = 0 },
                new FieldEnemy(){ enemyName = "StarGazer_EN", enemySlot = 1 },
                new FieldEnemy(){ enemyName = "StarGazer_EN", enemySlot = 2 },
                new FieldEnemy(){ enemyName = "StarGazer_EN", enemySlot = 3 },
            });
            if (SaltEnemies.silly < 38 && SaltEnemies.silly < 88)
            {
                fields.Add(new FieldEnemy[]
                {
                    new FieldEnemy(){ enemyName = "StarGazer_EN", enemySlot = 0 },
                    new FieldEnemy(){ enemyName = "StarGazer_EN", enemySlot = 1 },
                    new FieldEnemy(){ enemyName = "StarGazer_EN", enemySlot = 2 },
                    new FieldEnemy(){ enemyName = "StarGazer_EN", enemySlot = 3 },
                    new FieldEnemy(){ enemyName = "StarGazer_EN", enemySlot = 4 },
                });
            }
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){ enemyName = "StarGazer_EN", enemySlot = 0 },
                new FieldEnemy(){ enemyName = "StarGazer_EN", enemySlot = 1 },
                new FieldEnemy(){ enemyName = "StarGazer_EN", enemySlot = 2 },
                new FieldEnemy(){ enemyName = "StarGazer_EN", enemySlot = 3 },
                new FieldEnemy(){ enemyName = "StarGazer_EN", enemySlot = 4 },
            });
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){ enemyName = "StarGazer_EN", enemySlot = 0 },
                new FieldEnemy(){ enemyName = "StarGazer_EN", enemySlot = 1 },
                new FieldEnemy(){ enemyName = "StarGazer_EN", enemySlot = 2 },
                new FieldEnemy(){ enemyName = "StarGazer_EN", enemySlot = 3 },
            });
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){ enemyName = "StarGazer_EN", enemySlot = 0 },
                new FieldEnemy(){ enemyName = "StarGazer_EN", enemySlot = 1 },
                new FieldEnemy(){ enemyName = "StarGazer_EN", enemySlot = 2 },
                new FieldEnemy(){ enemyName = "StarGazer_EN", enemySlot = 3 },
                new FieldEnemy(){ enemyName = "StarGazer_EN", enemySlot = 4 },
            });
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){ enemyName = "StarGazer_EN", enemySlot = 0 },
                new FieldEnemy(){ enemyName = "StarGazer_EN", enemySlot = 1 },
                new FieldEnemy(){ enemyName = "StarGazer_EN", enemySlot = 2 },
                new FieldEnemy(){ enemyName = "StarGazer_EN", enemySlot = 3 },
                new FieldEnemy(){ enemyName = "StarGazer_EN", enemySlot = 4 },
            });
            if (SaltEnemies.trolling == 97)
            {
                fields.Add(new FieldEnemy[]
                {
                    new FieldEnemy(){ enemyName = "StarGazer_EN", enemySlot = 0 },
                });
            }
            enemyEncounter.variations = fields.ToArray();
            BrutalAPI.BrutalAPI.AddSignType(enemyEncounter.signType, ResourceLoader.LoadSprite("IconStars", 64));
            enemyEncounter.CheckEncounters();
            enemyEncounter.AddEncounter();
            if (DoDebugs.GenInfo) Debug.Log("Garden Encounters Loaded!");
        }
    }
}
