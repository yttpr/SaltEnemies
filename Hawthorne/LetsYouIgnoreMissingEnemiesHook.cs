using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using MonoMod.RuntimeDetour;
using System.Reflection;

namespace Hawthorne
{
    public static class LetsYouIgnoreMissingEnemiesHook
    {
        public static List<EnemySO> ExcludeEnemies;
        public static List<string> ExcludeNames;
        static bool IsGarden;
        public static void GenerateEnemyCard(Action<ZoneBGDataBaseSO, CardInfo, EnemyEncounterSelectorSO> orig, ZoneBGDataBaseSO self, CardInfo info, EnemyEncounterSelectorSO encounterSelector)
        {
            IsGarden = self.ZoneName == ZoneType.Garden;
            for (int i = 0; i < 20; i++)
            {
                try
                {
                    orig(self, info, encounterSelector);
                    return;
                }
                catch
                {
                    Debug.LogWarning("null enemy from generate enemy card (this is the ZoneBGDataBaseSO)");
                    Debug.LogWarning("we have failed " + (i + 1).ToString() + " times.");
                }
            }
            Debug.LogError("failed to generate an enemy bundle, like, 20 times, we're skipping.");
        }
        public static EnemyCombatBundle GetEnemyBundle(Func<EnemyEncounterSelectorSO, EnemyCombatBundle> orig, EnemyEncounterSelectorSO self)
        {
            EnemyCombatBundle ret = null;
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    for (int j = 0; j < 200; j++)
                    {
                        ret = orig(self);
                        if (ExcludeEnemies != null && ExcludeEnemies.Count > 0)
                        {
                            bool usable = true;
                            foreach (EnemyBundleData enemy in ret.Enemies)
                            {
                                if (ExcludeEnemies.Contains(enemy.enemy) || 
                                    (IsGarden && Check.EnemyExist("Freud_EN") && enemy.enemy == LoadedAssetsHandler.GetEnemy("Freud_EN")))
                                {

                                    if (DoDebugs.MiscInfo) Debug.LogWarning("salt enemies config disables the enemy " + enemy.enemy._enemyName + ". sorry! we are on trial " + j.ToString()); 
                                    usable = false;
                                    break;
                                }
                            }
                            if (usable) return ret;
                            if (j > 50 && DoDebugs.MiscInfo) Debug.LogWarning("ok what the fuck. trial " + j.ToString() + "!?!??!?? how....");
                            continue;
                        }
                        return ret;
                    }
                }
                catch
                {
                    Debug.LogWarning("null enemy from get enemy bundle (this is the EnemyEncounterSelectorSO)");
                    Debug.LogWarning("we have failed " + (i + 1).ToString() + " times.");
                }
            }
            if (ret == null) throw new Exception("enemy bundle failed for some reason (we are in EnemyEncounterSelectorSO.GetEnemyBundle). you will probably not see this message hopefully do to the other try catch surrounding this area.");
            return ret;
        }
        public static void Setup()
        {
            IDetour hook = new Hook(typeof(ZoneBGDataBaseSO).GetMethod(nameof(ZoneBGDataBaseSO.GenerateEnemyCard), ~BindingFlags.Default), typeof(LetsYouIgnoreMissingEnemiesHook).GetMethod(nameof(GenerateEnemyCard), ~BindingFlags.Default));
            IDetour hack = new Hook(typeof(EnemyEncounterSelectorSO).GetMethod(nameof(EnemyEncounterSelectorSO.GetEnemyBundle), ~BindingFlags.Default), typeof(LetsYouIgnoreMissingEnemiesHook).GetMethod(nameof(GetEnemyBundle), ~BindingFlags.Default));
            ExcludeEnemies = new List<EnemySO>();
            ExcludeNames = new List<string>();
            CheckEnemy("LostSheep_EN");
            CheckEnemy("Enigma_EN");
            CheckEnemy("DeadPixel_EN");
            CheckEnemy("LittleAngel_EN");
            CheckEnemy("AFlower_EN");
            CheckEnemy("Something_EN");
            CheckEnemy("Satyr_EN");
            CheckEnemy("TeachaMantoFish_EN");
            CheckEnemy("TheCrow_EN");
            CheckEnemy("Freud_EN");
            CheckEnemy("StarGazer_EN");
            CheckEnemy("RusticJumbleguts_EN");
            CheckEnemy("MortalSpoggle_EN");
            CheckEnemy("MechanicalLens_EN");
            CheckEnemy("EmbersofaDeadGod_EN");
            CheckEnemy("CoinHunter_EN");
            CheckEnemy("StrangeBox_EN");
            CheckEnemy("FakeAngel_EN");
            CheckEnemy("Illusion_EN");
            CheckEnemy("RedFlower_EN");
            CheckEnemy("BlueFlower_EN");
            CheckEnemy("YellowFlower_EN");
            CheckEnemy("PurpleFlower_EN");
            CheckEnemy("GreyFlower_EN");
            CheckEnemy("LivingSolvent_EN");
            CheckEnemy("WindSong_EN");
            CheckEnemy("Sigil_EN");
            CheckEnemy("RealisticTank_EN");
            CheckEnemy("ClockTower_EN");
            CheckEnemy("StalwartTortoise_EN");
            CheckEnemy("Grandfather_EN");
            CheckEnemy("MiniReaper_EN");
            CheckEnemy("Skyloft_EN");
            CheckEnemy("Miriam_EN");
            CheckEnemy("EyePalm_EN");
            CheckEnemy("Merced_EN");
            CheckEnemy("Butterfly_EN");
            CheckEnemy("Shua_EN");
            CheckEnemy("Nameless_EN");
            CheckEnemy("TripodFish_EN");
            CheckEnemy("Lyssa_EN");
            CheckEnemy("GlassFigurine_EN");
            CheckEnemy("Damocles_EN");
            CheckEnemy("TheDeep_EN");
            CheckEnemy("Postmodern_EN");
            CheckEnemy("SnakeGod_EN");
            CheckEnemy("Hunter_EN");
            CheckEnemy("Firebird_EN");
            CheckEnemy("LittleBeak_EN");
            CheckEnemy("Warbird_EN");
            CheckEnemy("Windle_EN");
            CheckEnemy("BlackStar_EN");
            CheckEnemy("Indicator_EN");
            CheckEnemy("Maw_EN");
            CheckEnemy("Clione_EN");
            CheckEnemy("Children_EN");
            CheckEnemy("YNL_EN");
            CheckEnemy("Spitato_EN");
            CheckEnemy("Pinano_EN");
            CheckEnemy("Minana_EN");
            CheckEnemy("Arceles_EN");
            CheckEnemy("Stoplight_EN");
            CheckEnemy("RedBot_EN");
            CheckEnemy("BlueBot_EN");
            CheckEnemy("YellowBot_EN");
            CheckEnemy("PurpleBot_EN");
            CheckEnemy("GreyBot_EN");
            CheckEnemy("GlassedSun_EN");
            CheckEnemy("Crystal_EN");
            CheckEnemy("TheDragon_EN");
            CheckEnemy("OdetoHumanity_EN");
        }
        public static void CheckEnemy(string enemy)
        {
            try
            {
                if (!Config.Check(enemy))
                {
                    Debug.Log("BOOOO YOU SUCK. Disabling enemy " + enemy);
                    Debug.LogWarning("BOOOO YOU SUCK. Disabling enemy " + enemy);
                    Debug.LogError("BOOOO YOU SUCK. Disabling enemy " + enemy);
                    if (enemy == "AFlower_EN") enemy = "A'Flower'_EN";
                    if (enemy == "Windle_EN") enemy = "Windle1_EN";
                    if (enemy == "Children_EN") enemy = "Children6_EN";
                    DisableEnemy(enemy);
                    if (enemy == "Something_EN") { DisableEnemy("Derogatory_EN"); DisableEnemy("Denial_EN"); }
                    if (enemy == "Postmodern_EN") DisableEnemy("War_EN");
                    if (enemy == "Windle1_EN") { DisableEnemy("Windle2_EN"); DisableEnemy("Windle3_EN"); }
                    if (enemy == "BlackStar_EN") DisableEnemy("Singularity_EN");
                    if (enemy == "Windle1_EN") { DisableEnemy("Children5_EN"); DisableEnemy("Children4_EN"); DisableEnemy("Children3_EN"); DisableEnemy("Children2_EN"); DisableEnemy("Children1_EN"); DisableEnemy("Children0_EN"); DisableEnemy("ChildrenPrayer_EN"); }
                    if (enemy == "Crystal_EN") DisableEnemy("CandyStone_EN");
                }
            }
            catch
            {
                if (DoDebugs.EnemyNull) Debug.LogError("config checking for enemy " + enemy + " epic failed.");
            }
        }
        public static void DisableEnemy(string enemy)
        {
            try
            {
                if (DoDebugs.GenInfo) Debug.Log("phase 1 preparing disable enemy " + enemy);
                ExcludeNames.Add(enemy);
            }
            catch
            {
                if (DoDebugs.EnemyNull) Debug.LogError("config disabling enemy " + enemy + " epic failed.");
            }
        }
        public static void FinishDisablingEnemies()
        {
            foreach (string enemy in ExcludeNames)
            {
                try
                {
                    Debug.Log("BOOOO YOU SUCK. Disabling enemy " + enemy);
                    Debug.LogWarning("BOOOO YOU SUCK. Disabling enemy " + enemy);
                    Debug.LogError("BOOOO YOU SUCK. Disabling enemy " + enemy);
                    EnemySO enemey = LoadedAssetsHandler.GetEnemy(enemy);
                    if (DoDebugs.GenInfo) Debug.Log("config disabling enemy " + enemey._enemyName);
                    if (!ExcludeEnemies.Contains(enemey)) ExcludeEnemies.Add(enemey);
                }
                catch
                {
                    if (DoDebugs.EnemyNull) Debug.LogError("config disabling enemy " + enemy + " epic failed.");
                }
            }
            ReadOutDisabled();
        }
        public static bool IsDisabled(string enemy)
        {
            try
            {
                if (ExcludeNames.Contains(enemy))
                {
                    if (DoDebugs.MiscInfo) Debug.LogWarning("Salt enemies config disables the enemy " + enemy + ". sorry!");
                    return true;
                }
            }
            catch
            {
                if (DoDebugs.EnemyNull) UnityEngine.Debug.LogError("lets you ignore missing enemies hook config exclusion failed: " + enemy);
            }
            return false;
        }
        public static void ReadOutDisabled()
        {
            if (ExcludeNames != null)
            {
                foreach (string enemy in ExcludeNames)
                {
                    Debug.Log("BOOOO YOU SUCK. Enemy " + enemy + " is disabled.");
                    Debug.LogWarning("BOOOO YOU SUCK. Enemy " + enemy + " is disabled.");
                    Debug.LogError("BOOOO YOU SUCK. Enemy " + enemy + " is disabled.");
                }
            }
        }
    }
}
