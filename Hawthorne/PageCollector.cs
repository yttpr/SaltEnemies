using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using MonoMod.RuntimeDetour;
using System.Reflection;
using static Hawthorne.Check;
using UnityEngine.PlayerLoop;

namespace Hawthorne
{
    public static class PageCollector
    {
        public static void Setup()
        {
            IDetour hook = new Hook(typeof(EnemyCombat).GetMethod(nameof(EnemyCombat.DefaultPassiveAbilityInitialization), ~BindingFlags.Default), typeof(PageCollector).GetMethod(nameof(DefaultPassiveAbilityInitialization), ~BindingFlags.Default));
            SaltEnemies.PCall(CombatManagerCrashHandler.Setup);
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
                    Debug.LogError("(Paging) Whoopsies!" + self._currentName);
                    Debug.LogError(e + e.Message + e.StackTrace);
                }
            }
            try
            {
                self.Naming();
            }
            catch (Exception e)
            {
                if (DoDebugs.GenInfo)
                {
                    Debug.LogError("(Naming) Whoopsies!" + self._currentName);
                    Debug.LogError(e + e.Message + e.StackTrace);
                }
            }
        }
        
        public static void Paging(this EnemyCombat self)
        {
            StampHandler.PageCheck(self);
            return;
            /*
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
            if (self.IsEnemy("Clione_EN")) AddPage("ClionePage.png");
            if (self.IsEnemy("Children6_EN")) AddPage("ChildrenPage.png");
            if (self.IsEnemy("Children5_EN")) AddPage("ChildrenPage.png");
            if (self.IsEnemy("Children4_EN")) AddPage("ChildrenPage.png");
            if (self.IsEnemy("Children3_EN")) AddPage("ChildrenPage.png");
            if (self.IsEnemy("Children2_EN")) AddPage("ChildrenPage.png");
            if (self.IsEnemy("Children1_EN")) AddPage("ChildrenPage.png");
            if (self.IsEnemy("Children0_EN")) AddPage("ChildrenPage.png");
            if (self.IsEnemy("YNL_EN")) AddPage("YNLPage.png");
            if (self.IsEnemy("Pinano_EN")) AddPage("PinanoPage.png");
            if (self.IsEnemy("Spitato_EN")) AddPage("PinanoPage.png");
            if (self.IsEnemy("Minana_EN")) AddPage("PinanoPage.png");
            if (self.IsEnemy("Arceles_EN")) AddPage("ArcelesPage.png");
            if (self.IsEnemy("Stoplight_EN")) AddPage("StoplightPage.png");
            */
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
            if (pageName == "") return;
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
            if (pageName == "") return;
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

    public static class NameChanger
    {
        public static void Naming(this EnemyCombat self)
        {
            self.DeadPixel(self.Enemy);
            self.Illusion(self.Enemy);
            self.Minana(self.Enemy);
            self.ClockTower(self.Enemy);
            //self.Nameless(self.Enemy);
            self.GlassFigurine(self.Enemy);
        }

        public static void DeadPixel(this EnemyCombat enemy, EnemySO self)
        {
            if (EnemyExist("DeadPixel_EN") && self == LoadedAssetsHandler.GetEnemy("DeadPixel_EN"))
            {
                if (Third)
                {
                    if (Third)
                    {
                        string[] names = new string[]
                        {
                            "FFF740+9C983D",
                            "01000100 01100101 01100001 01100100 00100000 01010000 01101001 01111000 01100101 01101100",
                            "???? ?????"
                        };
                        enemy.Name = names.GetRandom();
                    }
                    else
                    {
                        string[] names = new string[]
                        {
                            "DEAD PIXEL",
                            "dead pixel"
                        };
                        enemy.Name = names.GetRandom();
                    }
                }
            }
        }
        public static void Illusion(this EnemyCombat enemy, EnemySO self)
        {
            if (EnemyExist("Illusion_EN") && self == LoadedAssetsHandler.GetEnemy("Illusion_EN"))
            {
                if (Third)
                {
                    string[] names = new string[]
                    {
                        "Ddelusion",
                        "Deelusion",
                        "Dellusion",
                        "Deluusion",
                        "Delussion",
                        "Delusiion",
                        "Delusioon",
                        "Delusionn"
                    };
                    enemy.Name = names.GetRandom();
                }
            }
        }
        public static void Minana(this EnemyCombat enemy, EnemySO self)
        {
            if (EnemyExist("Minana_EN") && self == LoadedAssetsHandler.GetEnemy("Minana_EN"))
            {
                if (Trolling(22))
                {
                    enemy.Name = "Miino";
                }
                else if (Trolling(63))
                {
                    enemy.Name = "Princess";
                }
            }
        }
        public static void ClockTower(this EnemyCombat enemy, EnemySO self)
        {
            if (EnemyExist("ClockTower_EN") && self == LoadedAssetsHandler.GetEnemy("ClockTower_EN"))
            {
                if (Trolling(32))
                {
                    enemy.Name = "- .... .   . -. -..   --- ..-.   - .. -- .";
                }
            }
        }
        public static void Nameless(this EnemyCombat enemy, EnemySO self)
        {
            if (EnemyExist("Nameless_EN") && self == LoadedAssetsHandler.GetEnemy("Nameless_EN"))
            {
                if (Trolling(82))
                {
                    enemy.Name = "Nameless";
                }
            }
        }
        public static void GlassFigurine(this EnemyCombat enemy, EnemySO self)
        {
            if (EnemyExist("GlassFigurine_EN") && self == LoadedAssetsHandler.GetEnemy("GlassFigurine_EN"))
            {
                if (Half)
                {
                    string[] names = new string[]
                    {
                        "Glass Figurine",
                        "How You Move About The Scene",
                        "How You Twist, How You Bend",
                        "To A Song With No Beginning Or End",
                        "Pulled By The Strings",
                        "Color Absent From The Scene",
                        "But I Hear A Small Cry",
                        "\"Just Let Me Die\"",
                        "In A Dream State",
                        "They're Rearranging Your Face",
                        "Lingering, Warm And Sweet",
                        "Fingers Feeling Where Your Eyes Used To Be",
                        "Once, We Were Friends",
                        "Now We'll Never Meet Again",
                        "So Adieu, So Adieu",
                        "I Still Love You",
                        "Comely Puppet Oh Comely Puppet",
                        "I'm Searching For That Smile Of Yours",
                        "But Your Head Is Filled Up With Cotton",
                        "All Your Pleasant Features Have Been Forgotten",
                        "Comely Puppet Oh Comely Puppet",
                        "I'm Wating For The Big Encore",
                        "While The Ash Builds Up In The Ash Tray",
                        "You Can Run Away, It All Stays In Place",
                        "Hey, Mom And Dad",
                        "I Can See I Made You Mad",
                        "Run Away, Run Away",
                        "I Can Feel The Cracks Spread Across My Face",
                        "I'm Right On Time",
                        "A Doll Enters At Stage Right",
                        "Lines I've Learned, Songs I've Heard",
                        "So Familiar"
                    };
                    enemy.Name = names.GetRandom();
                }
            }
        }
    }
    public static class CombatManagerCrashHandler
    {
        public static void Setup()
        {
            IDetour other = new Hook(typeof(CombatManager).GetMethod(nameof(CombatManager.Update), ~BindingFlags.Default), typeof(CombatManagerCrashHandler).GetMethod(nameof(Update), ~BindingFlags.Default));
        }
        public static void Update(Action<CombatManager> orig, CombatManager self)
        {
            if (self._informationHolder == null) self._informationHolder = Resources.FindObjectsOfTypeAll<GameInformationHolder>()[0];
            //if (self != null && self._informationHolder != null && self._informationHolder.Run != null && self._stats != null && self._combatUI != null)
                orig(self);
            //else
            //{
            //    CombatManager._instance = null;
            //    UnityEngine.Object.Destroy(self);
            //    Debug.LogWarning("buncha stuff in combat manager was null so i destroyed it - salt");
            //}
        }
    }
}
