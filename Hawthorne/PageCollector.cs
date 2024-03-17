using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using MonoMod.RuntimeDetour;
using System.Reflection;

namespace Hawthorne
{
    public static class PageCollector
    {
        public static void Setup()
        {
            IDetour hook = new Hook(typeof(EnemyCombat).GetMethod(nameof(EnemyCombat.DefaultPassiveAbilityInitialization), ~BindingFlags.Default), typeof(PageCollector).GetMethod(nameof(DefaultPassiveAbilityInitialization), ~BindingFlags.Default));
        }
        
        public static void DefaultPassiveAbilityInitialization(Action<EnemyCombat> orig, EnemyCombat self)
        {
            orig(self);
            try
            {
                self.Paging();
            }
            catch (Exception e)
            {
                if (DoDebugs.GenInfo)
                {
                    Debug.LogError("Whoopsies!" + self._currentName);
                    Debug.LogError(e + e.Message + e.StackTrace);
                }
            }
        }

        public static void Paging(this EnemyCombat self)
        {
            if (self.IsEnemy("A'Flower'_EN")) AddPage("AnglerPage.png");
            if (self.IsEnemy("LittleBeak_EN")) AddPage("BeakPage.png");
            if (self.IsEnemy("BlueFlower_EN")) AddPage("BlueFlowerPage.png");
            if (self.IsEnemy("Butterfly_EN")) AddPage("ButterflyPage.png");
            if (self.IsEnemy("MechanicalLens_EN")) AddPage("CameraPage.png");
            if (self.IsEnemy("ClockTower_EN")) AddPage("ClockPage.png");
            if (self.IsEnemy("LostSheep_EN")) AddPage("CNSPage.png");
            if (self.IsEnemy("Grandfather_EN")) AddPage("CoffinPage.png");
            if (self.IsEnemy("CoinHunter_EN")) AddPage("CoinHunterPage.png");
            if (self.IsEnemy("TheCrow_EN")) AddPage("CrowPage.png");
            if (self.IsEnemy("Damocles_EN")) AddPage("DamoclesPage.png");
            if (self.IsEnemy("EmbersofaDeadGod_EN")) AddPage("DeadGodPage.png");
            if (self.IsEnemy("DeadPixel_EN")) AddPage("DeadPixelPage.png");
            if (self.IsEnemy("Illusion_EN")) AddPage("DelusionPage.png");
            if (self.IsEnemy("Freud_EN")) AddPage("DontTouchMePage.png");
            if (self.IsEnemy("Enigma_EN")) AddPage("EnigmaPage.png");
            if (self.IsEnemy("FakeAngel_EN")) AddPage("FakeAngelPage.png");
            if (self.IsEnemy("Firebird_EN")) AddPage("FirebirdPage.png");
            if (self.IsEnemy("GlassFigurine_EN")) AddPage("GlassPage.png");
            if (self.IsEnemy("MortalSpoggle_EN")) AddPage("GospelPage.png");
            if (self.IsEnemy("GreyFlower_EN")) AddPage("GreyFlowerPage.png");
            if (self.IsEnemy("Hunter_EN")) AddPage("HuntingPage.png");
            if (self.IsEnemy("LittleAngel_EN")) AddPage("LittleAngelPage.png");
            if (self.IsEnemy("EyePalm_EN")) AddPage("MedamaudePage.png");
            if (self.IsEnemy("Merced_EN")) AddPage("MercedPage.png");
            if (self.IsEnemy("Miriam_EN")) AddPage("MiriamPage.png");
            if (self.IsEnemy("Nameless_EN")) AddPage("NamelessPage.png");
            if (self.IsEnemy("Postmodern_EN")) AddPage("PostmodernPage.png");
            if (self.IsEnemy("War_EN")) AddPage("PostmodernPage.png");
            if (self.IsEnemy("PurpleFlower_EN")) AddPage("PurpleFlowerPage.png");
            if (self.IsEnemy("Lyssa_EN")) AddPage("RabiesPage.png");
            if (self.IsEnemy("MiniReaper_EN")) AddPage("ReaperPage.png");
            if (self.IsEnemy("RedFlower_EN")) AddPage("RedFlowerPage.png");
            if (self.IsEnemy("RusticJumbleguts_EN")) AddPage("RusticPage.png");
            if (self.IsEnemy("Satyr_EN")) AddPage("SatyrPage.png");
            if (self.IsEnemy("Shua_EN")) AddPage("ShuaPage.png");
            if (self.IsEnemy("Sigil_EN")) AddPage("SigilPage.png");
            if (self.IsEnemy("Skyloft_EN")) AddPage("SkyloftPage.png");
            if (self.IsEnemy("SnakeGod_EN")) AddPage("SnakeGodPage.png");
            if (self.IsEnemy("LivingSolvent_EN")) AddPage("SolventPage.png");
            if (self.IsEnemy("Something_EN")) AddPage("SomethingPage.png");
            if (self.IsEnemy("Derogatory_EN")) AddPage("SomethingPage.png");
            if (self.IsEnemy("Denial_EN")) AddPage("SomethingPage.png");
            if (self.IsEnemy("StarGazer_EN")) AddPage("StarGazerPage.png");
            if (self.IsEnemy("544517_EN")) AddPage("SuperbossPage.png");
            if (self.IsEnemy("544516_EN")) AddPage("SuperbossPage.png");
            if (self.IsEnemy("544515_EN")) AddPage("SuperbossPage.png");
            if (self.IsEnemy("544514_EN")) AddPage("SuperbossPage.png");
            if (self.IsEnemy("544513_EN")) AddPage("SuperbossPage.png");
            if (self.IsEnemy("RealisticTank_EN")) AddPage("TankPage.png");
            if (self.IsEnemy("TheDeep_EN")) AddPage("TheDeepPage.png");
            if (self.IsEnemy("StalwartTortoise_EN")) AddPage("TortoisePage.png");
            if (self.IsEnemy("TripodFish_EN")) AddPage("TripodPage.png");
            if (self.IsEnemy("TeachaMantoFish_EN")) AddPage("UnmungPage.png");
            if (self.IsEnemy("Warbird_EN")) AddPage("WarbirdPage.png");
            if (self.IsEnemy("WindSong_EN")) AddPage("WindSongPage.png");
            if (self.IsEnemy("YellowFlower_EN")) AddPage("YellowFlowerPage.png");
            if (self.IsEnemy("Windle1_EN")) AddPage("WindlePage.png");
            if (self.IsEnemy("Windle2_EN")) AddPage("WindlePage.png");
            if (self.IsEnemy("Windle3_EN")) AddPage("WindlePage.png");
            if (self.IsEnemy("BlackStar_EN")) AddPage("BlackStarPage.png");
            if (self.IsEnemy("Singularity_EN")) AddPage("SingularityPage.png");
            if (self.IsEnemy("Indicator_EN")) AddPage("IndicatorPage.png");
            if (self.IsEnemy("Maw_EN")) AddPage("MawPage.png");
        }

        public static bool IsEnemy(this EnemyCombat self, string enemy)
        {
            if (Check.EnemyExist(enemy))
            {
                return self.Enemy == LoadedAssetsHandler.GetEnemy(enemy);
            }
            return false;
        }

        public static void AddPage(string pageName, bool overwrite = false)
        {
            try
            {
                if (!Directory.Exists(BepInEx.Paths.BepInExRootPath + "\\plugins\\" + "SaltsPages\\"))
                {
                    Directory.CreateDirectory(BepInEx.Paths.BepInExRootPath + "\\plugins\\" + "SaltsPages\\");
                }
                if (!File.Exists(BepInEx.Paths.BepInExRootPath + "\\plugins\\" + "SaltsPages\\" + pageName) || overwrite)
                {
                    byte[] file = ResourceLoader.ResourceBinary(pageName);
                    File.WriteAllBytes(BepInEx.Paths.BepInExRootPath + "\\plugins\\" + "SaltsPages\\" + pageName, file);
                }
            }
            catch (Exception e)
            {
                if (DoDebugs.GenInfo)
                {
                    Debug.LogError("Epic File Failure " + pageName);
                    Debug.LogError(e + e.Message + e.StackTrace);
                }
            }
        }
        public static void UpdatePage(string pageName)
        {
            try
            {
                if (!Directory.Exists(BepInEx.Paths.BepInExRootPath + "\\plugins\\" + "SaltsPages\\"))
                {
                    Directory.CreateDirectory(BepInEx.Paths.BepInExRootPath + "\\plugins\\" + "SaltsPages\\");
                }
                if (File.Exists(BepInEx.Paths.BepInExRootPath + "\\plugins\\" + "SaltsPages\\" + pageName))
                {
                    byte[] file = ResourceLoader.ResourceBinary(pageName);
                    File.WriteAllBytes(BepInEx.Paths.BepInExRootPath + "\\plugins\\" + "SaltsPages\\" + pageName, file);
                }
            }
            catch (Exception e)
            {
                if (DoDebugs.GenInfo)
                {
                    Debug.LogError("Epic File Failure " + pageName);
                    Debug.LogError(e + e.Message + e.StackTrace);
                }
            }
        }
    }
}
