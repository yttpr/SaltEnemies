using BrutalAPI;
using MUtility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using UnityEngine;
using UnityEngine.Profiling;

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
            try
            {
                Stamps.Add(StampID, this);
            }
            catch
            {
                Debug.LogError("Stamp Collector already contains a stamp for " + StampID);
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

        public static string Introduction;
        public static string Compilation;
        
        public StampGroup(string name, string[] ids, string intro, string comp)
        {
            Name = name;
            StampIDs = ids;
            Introduction = intro;
            Compilation = comp;
            if (Groups == null) Groups = new Dictionary<string, StampGroup>();
            Groups.Add(Name, this);
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
                if (id != "" && Stamp.Stamps != null && Stamp.Stamps.TryGetValue(id, out Stamp stamp) && stamp.GetValue() < 2) return false;
            }
            PageCollector.AddPage(Compilation);
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
                case 2: return CreatePNG.AttachTexture(true, self.Found, Endcombat);
                case 3: return CreatePNG.AttachTexture(true, self.Found, Flee);
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
            new Stamp("Angler", "A'Flower'_EN", "AnglerPage.png", "Group_1", "AnglerLock.png", "AnglerMark.png");

            new Stamp("BlueFlower", "BlueFlower_EN", "BlueFlowerPage.png", "Group_4a", "BlueFlowerLock.png", "BlueFlowerMark.png");

            new Stamp("Beak", "LittleBeak_EN", "BeakPage.png", "Group_4g", "BeakLock.png", "BeakMark.png");
        }
    }

}
