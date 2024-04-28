using BrutalAPI;
using MonoMod.RuntimeDetour;
using MUtility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using UnityEngine;
using UnityEngine.Profiling;
using System.Reflection;

namespace Hawthorne
{
    public static class StampSaver
    {
        public const string FolderName = "SaltHawthorne";
        public const string FileName = "KillTracker";
        public const int Default = 0;

        public static void LoadAllValues()
        {
            if (SaveConfigNames == null) SaveConfigNames = new Dictionary<string, int>();
            if (!File.Exists(SavePath + FileName + ".config")) return;
            FileStream inStream = File.Open(SaveName, FileMode.Open);
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load((Stream)inStream);
            if (xmlDocument.GetElementsByTagName("config").Count > 0)
            {
                foreach (XmlAttribute node in xmlDocument.GetElementsByTagName("config")[0].Attributes)
                {
                    int val = int.TryParse(node.Value, out int res) ? res : 0;
                    string name = node.Name;
                    if (val != null & name.Length > 0)
                    {
                        if (SaveConfigNames.Keys.Contains(name))
                        {
                            SaveConfigNames[name] = val;
                        }
                        else
                        {
                            SaveConfigNames.Add(name, val);
                        }
                    }
                }
            }
            inStream.Close();
        }
        public static void TryWriteConfig() => WriteConfig(SaveName);


        public static Dictionary<string, int> SaveConfigNames;

        public static void WriteConfig(string location)
        {
            StreamWriter text = File.CreateText(location);
            XmlDocument xmlDocument = new XmlDocument();
            string xml = "<config";
            foreach (string key in SaveConfigNames.Keys)
            {
                xml += " ";
                xml += key;
                xml += "='";
                xml += SaveConfigNames[key].ToString().ToLower();
                xml += "'\n";
            }
            xml += "> </config>";
            xmlDocument.LoadXml(xml);
            xmlDocument.Save((TextWriter)text);
            text.Close();
        }

        public static int Check(string name)
        {
            if (SaveConfigNames == null)
            {
                SaveConfigNames = new Dictionary<string, int>();
            }
            string l = SaveName;
            int add = Default;
            FileStream inStream = File.Open(SaveName, FileMode.Open);
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load((Stream)inStream);
            if (xmlDocument.GetElementsByTagName("config").Count > 0)
            {

                if (xmlDocument.GetElementsByTagName("config")[0].Attributes[name] != null)
                {
                    add = int.Parse(xmlDocument.GetElementsByTagName("config")[0].Attributes[name].Value);

                }
                if (!SaveConfigNames.Keys.Contains(name))
                    SaveConfigNames.Add(name, add);
                else
                    SaveConfigNames[name] = add;
            }
            inStream.Close();
            return add;
        }

        public static void Set(string name, int value)
        {
            if (Check(name) != value)
            {
                SaveConfigNames[name] = value;
                WriteConfig(SaveName);
            }
        }

        static string baseSave
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", "LocalLow") + "\\ItsTheMaceo\\BrutalOrchestra\\";
            }
        }
        static string pathPlus
        {
            get
            {
                if (!Directory.Exists(baseSave + "Mods\\"))
                {
                    Directory.CreateDirectory(baseSave + "Mods\\");
                }
                return baseSave + "Mods\\";
            }
        }
        public static string SavePath
        {
            get
            {
                if (!Directory.Exists(pathPlus + FolderName + "\\"))
                {
                    Directory.CreateDirectory(pathPlus + FolderName + "\\");
                }
                return pathPlus + FolderName + "\\";
            }
        }
        public static string SaveName
        {
            get
            {
                if (!File.Exists(SavePath + FileName + ".config"))
                {
                    WriteConfig(SavePath + FileName + ".config");
                }
                return SavePath + FileName + ".config";
            }
        }
    }
    public class Stamp
    {
        public static Dictionary<string, Stamp> Stamps;
        static int Duplicates = 0;

        public string StampID;
        public string GroupID;

        public string EnemyID;
        public string PageName;

        public string LockedImage;
        public string UnlockedImage;
        public Stamp(string ID, string enemy, string page, string groupID, string locked, string unlocked)
        {
            StampID = ID;
            GroupID = groupID;
            EnemyID = enemy;
            PageName = page;
            LockedImage = locked;
            UnlockedImage = unlocked;
            if (Stamps == null) Stamps = new Dictionary<string, Stamp>();
            if (!Stamps.Keys.Contains(StampID)) Stamps.Add(StampID, this);
            else
            {
                if (DoDebugs.MiscInfo) 
                    Debug.LogError("Stamp Collector already contains a stamp for " + StampID);
                try
                {
                    Stamps.Add(StampID + "Duplicate" + Duplicates.ToString(), this);
                }
                catch
                {
                    Debug.LogError("Stamp Collector really fucked up " + StampID + "Duplicate" + Duplicates.ToString());
                }
                Duplicates++;
            }
            try
            {
                if (StampSaver.Check(StampID) >= 1) PageCollector.AddPage(PageName);
            }
            catch
            {
                Debug.LogWarning("failed page check");
            }
        }

        public Texture2D Hidden => ResourceLoader.LoadTexture(LockedImage);
        public Texture2D Found => ResourceLoader.LoadTexture(UnlockedImage);

        public void PageCheck(EnemyCombat self)
        {
            if (self.IsEnemy(EnemyID))
            {
                PageCollector.AddPage(PageName);
                if (StampSaver.Check(StampID) < 1) StampSaver.Set(StampID, 1);
                if (GroupID != "" && StampGroup.Groups != null && StampGroup.Groups.TryGetValue(GroupID, out StampGroup group))
                {
                    group.IntroCheck();
                    group.CompCheck();
                }
            }
        }
        public void EndcombatCheck(EnemyCombat self)
        {
            return;
            if (self.IsEnemy(EnemyID))
            {
                if (StampSaver.Check(StampID) < 2) StampSaver.Set(StampID, 2);
                if (GroupID != "" && StampGroup.Groups != null && StampGroup.Groups.TryGetValue(GroupID, out StampGroup group))
                {
                    group.IntroCheck();
                    group.CompCheck();
                }
            }
        }
        public void FleeCheck(EnemyCombat self)
        {
            return;
            if (self.IsEnemy(EnemyID))
            {
                if (StampSaver.Check(StampID) < 3) StampSaver.Set(StampID, 3);
                if (GroupID != "" && StampGroup.Groups != null && StampGroup.Groups.TryGetValue(GroupID, out StampGroup group))
                {
                    group.IntroCheck();
                    group.CompCheck();
                }
            }
        }
        public void KillCheck(EnemyCombat self)
        {
            if (self.IsEnemy(EnemyID))
            {
                if (StampSaver.Check(StampID) < 4) StampSaver.Set(StampID, 4);
                if (GroupID != "" && StampGroup.Groups != null && StampGroup.Groups.TryGetValue(GroupID, out StampGroup group))
                {
                    group.IntroCheck();
                    group.CompCheck();
                }
            }
        }
        public void NotifCheck(string notificationName, object sender, object args)
        {
            if (sender is EnemyCombat enemy)
            {
                if (notificationName == TriggerCalls.OnCombatEnd.ToString() && CombatManager.Instance._stats.CharactersAlive) EndcombatCheck(enemy);
                if (notificationName == TriggerCalls.OnFleetingEnd.ToString() && CombatManager.Instance._stats.CharactersAlive) FleeCheck(enemy);
                if (notificationName == TriggerCalls.OnDeath.ToString() && CombatManager.Instance._stats.CharactersAlive) KillCheck(enemy);

            }
        }
        public int GetValue() => StampSaver.Check(StampID);

        public void Update(string update)
        {
            if (!File.Exists(MiniBossUnlockSystem.SavePath + update))
            {
                if (!Directory.Exists(BepInEx.Paths.BepInExRootPath + "\\plugins\\" + "SaltsPages\\"))
                {
                    Directory.CreateDirectory(BepInEx.Paths.BepInExRootPath + "\\plugins\\" + "SaltsPages\\");
                }
                if (!File.Exists(BepInEx.Paths.BepInExRootPath + "\\plugins\\" + "SaltsPages\\" + PageName))
                {
                    if (StampSaver.Check(StampID) < 1) StampSaver.Set(StampID, 1);
                    if (GroupID != "" && StampGroup.Groups != null && StampGroup.Groups.TryGetValue(GroupID, out StampGroup group))
                    {
                        group.IntroCheck();
                        group.CompCheck();
                    }
                }
            }
        }
    }
    public class StampGroup
    {
        public static Dictionary<string, StampGroup> Groups;

        public string Name;
        public string[] StampIDs;

        public string Introduction;
        public string Compilation;
        public UnlockItem Item;
        
        public StampGroup(string name, string[] ids, string intro, string comp, UnlockItem item = null)
        {
            Name = name;
            StampIDs = ids;
            Introduction = intro;
            Compilation = comp;
            if (Groups == null) Groups = new Dictionary<string, StampGroup>();
            Groups.Add(Name, this);
            Item = item;
            Item?.Prepare();
            IntroCheck();
            CompCheck();
        }
        public bool IntroCheck()
        {
            foreach (string id in StampIDs)
            {
                if (id != "" && Stamp.Stamps != null && Stamp.Stamps.TryGetValue(id, out Stamp stamp) && stamp.GetValue() > 0)
                {
                    PageCollector.AddPage(Introduction);
                    return true;
                }
            }
            return false;
        }
        public bool CompCheck()
        {
            foreach (string id in StampIDs)
            {
                if (id != "" && Stamp.Stamps != null && Stamp.Stamps.TryGetValue(id, out Stamp stamp) && stamp.GetValue() < 4) return false;
            }
            PageCollector.AddPage(Compilation);
            Item?.GetItem();
            return true;
        }
        public Texture2D[] GetTextures()
        {
            List<Texture2D> list = new List<Texture2D>();
            foreach (string ID in StampIDs)
            {
                if (ID != "" && Stamp.Stamps != null && Stamp.Stamps.TryGetValue(ID, out Stamp stamp))
                {
                    list.Add(stamp.GetStamp());
                }
            }
            return list.ToArray();
        }
    }
    public static class StampHandler
    {
        public static void NotifCheck(string notificationName, object sender, object args)
        {
            if (Stamp.Stamps != null)
            {
                foreach (Stamp stamp in Stamp.Stamps.Values) stamp.NotifCheck(notificationName, sender, args);
            }
        }
        public static void PageCheck(EnemyCombat self)
        {
            if (Stamp.Stamps != null) foreach (Stamp stamp in Stamp.Stamps.Values) stamp.PageCheck(self);
        }

        public static void PrintStampsByGroup()
        {
            try
            {
                if (Stamp.Stamps == null) return;

                List<Texture2D> output = new List<Texture2D>();

                if (StampGroup.Groups != null)
                    foreach (StampGroup group in StampGroup.Groups.Values)
                        output.Add(CreatePNG.CombineTexColumn(group.GetTextures()));

                CreatePNG.WriteToPagesFolder(CreatePNG.AttachTexture(true, Background, CreatePNG.CombineTexRow(output.ToArray())), "SALT_ENEMIES_STAMP_SHEET.png");
            }
            catch (Exception ex)
            {
                Debug.LogError(ex.ToString() + ex.Message + ex.StackTrace);
            }
        }
        public static void PrintStampsAll_Basic()
        {
            try
            {
                if (Stamp.Stamps == null) return;
                List<Texture2D> output = new List<Texture2D>();
                List<Texture2D> row = new List<Texture2D>();
                foreach (string i in Stamp.Stamps.Keys)
                {
                    row.Add(Stamp.Stamps[i].GetStamp());
                    if (row.Count >= 10)
                    {
                        output.Add(CreatePNG.CombineTexRow(row.ToArray()));
                        row.Clear();
                    }
                }
                if (row.Count > 0)
                {
                    output.Add(CreatePNG.CombineTexRow(row.ToArray()));
                    row.Clear();
                }
                CreatePNG.WriteToPagesFolder(CreatePNG.AttachTexture(true, Background, CreatePNG.CombineTexColumn(output.ToArray())), "SALT_ENEMIES_STAMP_SHEET.png");
            }
            catch (Exception ex)
            {
                Debug.LogError(ex.ToString() + ex.Message + ex.StackTrace);
            }
        }
        public static Texture2D GetStamp(this Stamp self)
        {
            switch (StampSaver.Check(self.StampID))
            {
                case 0: return self.Hidden;
                case 1: return self.Found;
                case 2: goto case 1;
                case 3: goto case 1;
                //case 2: return CreatePNG.AttachTexture(true, self.Found, Endcombat);
                //case 3: return CreatePNG.AttachTexture(true, self.Found, Flee);
                case 4: return CreatePNG.AttachTexture(true, self.Found, Kill);
                default: goto case 0;
            }
        }

        static Texture2D _background;
        public static Texture2D Background
        {
            get
            {
                if (_background == null) _background = ResourceLoader.LoadTexture("bkg.png");
                return _background;
            }
        }
        static Texture2D _endcombat;
        public static Texture2D Endcombat
        {
            get
            {
                if (_endcombat == null) _endcombat = ResourceLoader.LoadTexture("mark_endcombat.png");
                return _endcombat;
            }
        }
        static Texture2D _flee;
        public static Texture2D Flee
        {
            get
            {
                if (_flee == null) _flee = ResourceLoader.LoadTexture("mark_flee.png");
                return _flee;
            }
        }
        static Texture2D _kill;
        public static Texture2D Kill
        {
            get
            {
                if (_kill == null) _kill = ResourceLoader.LoadTexture("mark_kill.png");
                return _kill;
            }
        }

        public static void DefaultSetup()
        {
            try
            {
                IDetour hook = new Hook(typeof(OverworldManagerBG).GetMethod(nameof(OverworldManagerBG.Awake), ~BindingFlags.Default), typeof(StampHandler).GetMethod(nameof(WorldAwake), ~BindingFlags.Default));
            }
            catch
            {
                if (DoDebugs.MiscInfo) Debug.LogError("stamp hook failure");
            }
            /*try
            {
                IDetour hook = new Hook(typeof(CombatStats).GetMethod(nameof(CombatStats.CombatEndTriggered), ~BindingFlags.Default), typeof(StampHandler).GetMethod(nameof(CombatEndTriggered), ~BindingFlags.Default));
            }
            catch
            {
                if (DoDebugs.MiscInfo) Debug.LogError("stamp combatendhook failure");
            }*/


            new Stamp("CNS", "LostSheep_EN", "CNSPage.png", "Group_1", "CNSLock.png", "CNSMark.png");
            new Stamp("Enigma", "Enigma_EN", "EnigmaPage.png", "Group_1", "EnigmaLock.png", "EnigmaMark.png");
            new Stamp("Pixel", "DeadPixel_EN", "DeadPixelPage.png", "Group_1", "PixelLock.png", "PixelMark.png");
            new Stamp("Pale", "LittleAngel_EN", "LittleAngelPage.png", "Group_1", "PaleLock.png", "PaleMark.png");
            new Stamp("DeadGod", "EmbersofaDeadGod_EN", "DeadGodPage.png", "Group_1", "DeadGodLock.png", "DeadGodMark.png");
            new StampGroup("Group_1", new string[] { "CNS", "Enigma", "Pixel", "Pale", "DeadGod" }, "", "");

            new Stamp("Satyr", "Satyr_EN", "SatyrPage.png", "Group_2a", "SatyrLock.png", "SatyrMark.png");
            new Stamp("Something", "Something_EN", "SomethingPage.png", "Group_2a", "SomethingLock.png", "SomethingMark.png");
            new Stamp("Derogatory", "Derogatory_EN", "SomethingPage.png", "Group_2a", "DerogatoryLock.png", "DerogatoryMark.png");
            new Stamp("Denial", "Denial_EN", "SomethingPage.png", "Group_2a", "DenialLock.png", "DenialMark.png");
            new Stamp("Unmung", "TeachaMantoFish_EN", "UnmungPage.png", "Group_2a", "UnmungLock.png", "UnmungMark.png");
            new StampGroup("Group_2a", new string[] { "Satyr", "Something", "Derogatory", "Denial", "Unmung" }, "", "");

            new Stamp("Crow", "TheCrow_EN", "CrowPage.png", "Group_2b", "CrowLock.png", "CrowMark.png");
            new Stamp("DontTouchMe", "Freud_EN", "DontTouchMePage.png", "Group_2b", "DontTouchMeLock.png", "DontTouchMeMark.png");
            new Stamp("Angler", "A'Flower'_EN", "AnglerPage.png", "Group_2b", "AnglerLock.png", "AnglerMark.png");
            new Stamp("StarGazer", "StarGazer_EN", "StarGazerPage.png", "Group_2b", "StarsLock.png", "StarsMark.png");
            new StampGroup("Group_2b", new string[] { "Crow", "DontTouchMe", "Angler", "StarGazer" }, "", "");

            new Stamp("Shiny", "CoinHunter_EN", "CoinHunterPage.png", "Group_3", "CoinLock.png", "CoinMark.png");
            new Stamp("Camera", "MechanicalLens_EN", "CameraPage.png", "Group_3", "CameraLock.png", "CameraMark.png");
            new Stamp("Gospel", "MortalSpoggle_EN", "GospelPage.png", "Group_3", "MortalLock.png", "MortalMark.png");
            new Stamp("Rustic", "RusticJumbleguts_EN", "RusticPage.png", "Group_3", "RusticLock.png", "RusticMark.png");
            new StampGroup("Group_3", new string[] { "Shiny", "Camera", "Gospel", "Rustic" }, "", "");

            new Stamp("Superboss", "544517_EN", "SuperbossPage.png", "", "BossLock.png", "BossMark.png");
            new Stamp("Superboss", "544516_EN", "SuperbossPage.png", "", "BossLock.png", "BossMark.png");
            new Stamp("Superboss", "544515_EN", "SuperbossPage.png", "", "BossLock.png", "BossMark.png");
            new Stamp("Superboss", "544514_EN", "SuperbossPage.png", "", "BossLock.png", "BossMark.png");
            new Stamp("Superboss", "544513_EN", "SuperbossPage.png", "Group_3_5", "BossLock.png", "BossMark.png");
            new StampGroup("Group_3_5", new string[] { "Superboss" }, "", "");

            new Stamp("Delusion", "Illusion_EN", "DelusionPage.png", "Group_4a", "DelusionLock.png", "DelusionMark.png");
            new Stamp("Angel", "FakeAngel_EN", "FakeAngelPage.png", "Group_4a", "AngelLock.png", "AngelMark.png");
            new Stamp("RedFlower", "RedFlower_EN", "RedFlowerPage.png", "Group_4a", "RedFlowerLock.png", "RedFlowerMark.png");
            new Stamp("BlueFlower", "BlueFlower_EN", "BlueFlowerPage.png", "Group_4a", "BlueFlowerLock.png", "BlueFlowerMark.png");
            new Stamp("YellowFlower", "YellowFlower_EN", "YellowFlowerPage.png", "Group_4a", "YellowFlowerLock.png", "YellowFlowerMark.png");
            new Stamp("PurpleFlower", "PurpleFlower_EN", "PurpleFlowerPage.png", "Group_4a", "PurpleFlowerLock.png", "PurpleFlowerMark.png");
            new StampGroup("Group_4a", new string[] { "Delusion", "Angel", "RedFlower", "BlueFlower", "YellowFlower", "PurpleFlower" }, "", "");

            new Stamp("Postmodern", "Postmodern_EN", "PostmodernPage.png", "Group_4b", "PostmodernLock.png", "PostmodernMark.png");
            new Stamp("War", "War_EN", "PostmodernPage.png", "Group_4b", "WarLock.png", "WarMark.png");
            new Stamp("Deep", "TheDeep_EN", "TheDeepPage.png", "Group_4b", "DeepLock.png", "DeepMark.png");
            new StampGroup("Group_4b", new string[] { "Postmodern", "War", "Deep" }, "", "");

            new Stamp("Sigil", "Sigil_EN", "SigilPage.png", "Group_4c", "SigilLock.png", "SigilMark.png");
            new Stamp("WindSong", "WindSong_EN", "WindSongPage.png", "Group_4c", "WindSongLock.png", "WindSongMark.png");
            new Stamp("Solvent", "LivingSolvent_EN", "SolventPage.png", "Group_4c", "SolventLock.png", "SolventMark.png");
            new Stamp("Tank", "RealisticTank_EN", "TankPage.png", "Group_4c", "TankLock.png", "TankMark.png");
            new Stamp("ClockTower", "ClockTower_EN", "ClockPage.png", "Group_4c", "ClockLock.png", "ClockMark.png");
            new StampGroup("Group_4c", new string[] { "Sigil", "WindSong", "Solvent", "Tank", "ClockTower" }, "", "");

            new Stamp("Grandfather", "Grandfather_EN", "CoffinPage.png", "Group_4d", "CoffinLock.png", "CoffinMark.png");
            new Stamp("Tortoise", "StalwartTortoise_EN", "TortoisePage.png", "Group_4d", "TortoiseLock.png", "TortoiseMark.png");
            new Stamp("GreyFlower", "GreyFlower_EN", "GreyFlowerPage.png", "Group_4d", "GreyFlowerLock.png", "GreyFlowerMark.png");
            new Stamp("Butterfly", "Butterfly_EN", "ButterflyPage.png", "Group_4d", "ButterflyLock.png", "ButterflyMark.png");
            new StampGroup("Group_4d", new string[] { "Grandfather", "Tortoise", "GreyFlower", "Butterfly" }, "", "");

            new Stamp("Reaper", "MiniReaper_EN", "ReaperPage.png", "Group_4e", "ReaperLock.png", "ReaperMark.png");
            new Stamp("Miriam", "Miriam_EN", "MiriamPage.png", "Group_4e", "MiriamLock.png", "MiriamMark.png");
            new Stamp("EyePalm", "EyePalm_EN", "MedamaudePage.png", "Group_4e", "EyePalmLock.png", "EyePalmMark.png");
            new Stamp("Skyloft", "Skyloft_EN", "SkyloftPage.png", "Group_4e", "SkyloftLock.png", "SkyloftMark.png");
            new Stamp("Merced", "Merced_EN", "MercedPage.png", "Group_4e", "MercedLock.png", "MercedMark.png");
            new Stamp("Shua", "Shua_EN", "ShuaPage.png", "Group_4e", "ShuaLock.png", "ShuaMark.png");
            new StampGroup("Group_4e", new string[] { "Reaper", "Miriam", "EyePalm", "Skyloft", "Merced", "Shua" }, "", "");

            new Stamp("Nameless", "Nameless_EN", "NamelessPage.png", "Group_4f", "NamelessLock.png", "NamelessMark.png");
            new Stamp("Tripod", "TripodFish_EN", "TripodPage.png", "Group_4f", "TripodLock.png", "TripodMark.png");
            new Stamp("Rabies", "Lyssa_EN", "RabiesPage.png", "Group_4f", "RabiesLock.png", "RabiesMark.png");
            new Stamp("Damocles", "Damocles_EN", "DamoclesPage.png", "Group_4f", "DamoclesLock.png", "DamoclesMark.png");
            new Stamp("Glass", "GlassFigurine_EN", "GlassPage.png", "Group_4f", "GlassLock.png", "GlassMark.png");
            new Stamp("SnakeGod", "SnakeGod_EN", "SnakeGodPage.png", "Group_4f", "SnakeGodLock.png", "SnakeGodMark.png");
            new StampGroup("Group_4f", new string[] { "Nameless", "Tripod", "Rabies", "Damocles", "Glass", "SnakeGod" }, "", "");

            new Stamp("Beak", "LittleBeak_EN", "BeakPage.png", "Group_4g", "BeakLock.png", "BeakMark.png");
            new Stamp("Hunter", "Hunter_EN", "HuntingPage.png", "Group_4g", "HunterLock.png", "HunterMark.png");
            new Stamp("Firebird", "Firebird_EN", "FirebirdPage.png", "Group_4g", "FirebirdLock.png", "FirebirdMark.png");
            new Stamp("Warbird", "Warbird_EN", "WarbirdPage.png", "Group_4g", "WarbirdLock.png", "WarbirdMark.png");
            new StampGroup("Group_4g", new string[] { "Beak", "Hunter", "Firebird", "Warbird" }, "", "");

            new Stamp("Windle", "Windle1_EN", "WindlePage.png", "Group_5a", "WindleLock.png", "WindleMark.png");
            new Stamp("Windle", "Windle2_EN", "WindlePage.png", "", "WindleLock.png", "WindleMark.png");
            new Stamp("Windle", "Windle3_EN", "WindlePage.png", "", "WindleLock.png", "WindleMark.png");
            new Stamp("Blackstar", "BlackStar_EN", "BlackStarPage.png", "Group_5a", "BlackstarLock.png", "BlackstarMark.png");
            new Stamp("Singularity", "Singularity_EN", "SingularityPage.png", "Group_5a", "SingularityLock.png", "SingularityMark.png");
            new Stamp("Indicator", "Indicator_EN", "IndicatorPage.png", "Group_5a", "IndicatorLock.png", "IndicatorMark.png");
            new Stamp("Maw", "Maw_EN", "MawPage.png", "Group_5a", "MawLock.png", "MawMark.png");
            new StampGroup("Group_5a", new string[] { "Windle", "Blackstar", "Singularity", "Indicator", "Maw" }, "", "");

            new Stamp("Clione", "Clione_EN", "ClionePage.png", "Group_5b", "ClioneLock.png", "ClioneMark.png");
            new Stamp("Children", "Children6_EN", "ChildrenPage.png", "Group_5b", "ChildrenLock.png", "ChildrenMark.png");
            new Stamp("Children", "Children5_EN", "ChildrenPage.png", "", "ChildrenLock.png", "ChildrenMark.png");
            new Stamp("Children", "Children4_EN", "ChildrenPage.png", "", "ChildrenLock.png", "ChildrenMark.png");
            new Stamp("Children", "Children3_EN", "ChildrenPage.png", "", "ChildrenLock.png", "ChildrenMark.png");
            new Stamp("Children", "Children2_EN", "ChildrenPage.png", "", "ChildrenLock.png", "ChildrenMark.png");
            new Stamp("Children", "Children1_EN", "ChildrenPage.png", "", "ChildrenLock.png", "ChildrenMark.png");
            new Stamp("Children", "Children0_EN", "ChildrenPage.png", "", "ChildrenLock.png", "ChildrenMark.png");
            new Stamp("YNL", "YNL_EN", "YNLPage.png", "Group_5b", "YNLLock.png", "YNLMark.png");
            new Stamp("Pinano", "Pinano_EN", "PinanoPage.png", "Group_5b", "PinanoLock.png", "PinanoMark.png");
            new Stamp("Spitato", "Spitato_EN", "PinanoPage.png", "Group_5b", "SpitatoLock.png", "SpitatoMark.png");
            new Stamp("Minana", "Minana_EN", "PinanoPage.png", "Group_5b", "MinanaLock.png", "MinanaMark.png");
            new Stamp("Boat", "Arceles_EN", "ArcelesPage.png", "Group_5b", "BoatLock.png", "BoatMark.png");
            new Stamp("Train", "Stoplight_EN", "StoplightPage.png", "Group_5b", "TrainLock.png", "TrainMark.png");
            new StampGroup("Group_5b", new string[] { "Clione", "Children", "YNL", "Pinano", "Spitato", "Minana", "Boat", "Train" }, "", "");

            new Stamp("RedBot", "RedBot_EN", "RedBotPage.png", "Group_5c", "RedBotLock.png", "RedBotMark.png");
            new Stamp("BlueBot", "BlueBot_EN", "BlueBotPage.png", "Group_5c", "BlueBotLock.png", "BlueBotMark.png");
            new Stamp("YellowBot", "YellowBot_EN", "YellowBotPage.png", "Group_5c", "YellowBotLock.png", "YellowBotMark.png");
            new Stamp("PurpleBot", "PurpleBot_EN", "PurpleBotPage.png", "Group_5c", "PurpleBotLock.png", "PurpleBotMark.png");
            new Stamp("GreyBot", "GreyBot_EN", "GreyBotPage.png", "Group_5c", "GreyBotLock.png", "GreyBotMark.png");
            new Stamp("Sun", "GlassedSun_EN", "SunPage.png", "Group_5c", "SunLock.png", "SunMark.png");
            new StampGroup("Group_5c", new string[] { "RedBot", "BlueBot", "YellowBot", "PurpleBot", "GreyBot", "Sun" }, "", "");

        }

        public static void WorldAwake(Action<OverworldManagerBG> orig, OverworldManagerBG self)
        {
            try
            {
                PrintStampsByGroup();
            }
            catch
            {
                if (DoDebugs.MiscInfo) Debug.LogError("failed print stamps");
            }
            orig(self);
        }
        public static void CombatEndTriggered(Action<CombatStats> orig, CombatStats self)
        {
            orig(self);
            foreach (EnemyCombat enemy in self.EnemiesOnField.Values)
            {
                try
                {
                    CombatManager.Instance.PostNotification(TriggerCalls.OnCombatEnd.ToString(), enemy, null);
                }
                catch
                {

                }
            }
        }
    }

}
