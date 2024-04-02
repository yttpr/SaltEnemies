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
using MonoMod.RuntimeDetour;
using UnityEngine.UIElements;
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
using UnityEngine.EventSystems;
using TMPro;
using Hawthorne.NewFolder;
using System.Xml.Linq;
using PYMN4;
using MonoMod.RuntimeDetour.HookGen;
using static Hawthorne.MiniBossUnlockSystem;
using static UnityEngine.EventSystems.EventTrigger;
using EnemyPack;
using static UnityEngine.GraphicsBuffer;
using THE_DEAD;
using static Hawthorne.Check;
using HarmonyLib;
using MonoMod.Cil;

namespace Hawthorne
{
    [BepInPlugin("Salt.Hawthorne", "Salt Enemies \"TM\"", "1.4.0")]
    [BepInDependency("Bones404.BrutalAPI", BepInDependency.DependencyFlags.HardDependency)]
    public class SaltEnemies : BaseUnityPlugin
    {
        public static bool bogwah = false;
        public static int trolling = UnityEngine.Random.Range(0, 100);
        public static int silly = UnityEngine.Random.Range(0, 100);
        public static int rando => UnityEngine.Random.Range(0, 100);

        public static AssetBundle assetBundle;

        public static AssetBundle Group4;
        public static List<CharacterSO> BaseChara = new List<CharacterSO>();
        public static int Numbah = 0;
        public static void increaseCostMod(int newNum)
        {
            Numbah += newNum;
            Directory.CreateDirectory(SavePath);
            StreamWriter text = File.CreateText(SavePath + "Hawthorne.config");
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml("<config Numbah = '" + Numbah.ToString() + "'> </config>");
            xmlDocument.Save((TextWriter)text);
            text.Close();
            text.Dispose();
        }
        public void Awake()
        {
            Hawthorne.SaltEnemies.assetBundle = AssetBundle.LoadFromMemory(ResourceLoader.ResourceBinary("hawthorne"));

            Group4 = AssetBundle.LoadFromMemory(ResourceLoader.ResourceBinary("group4"));
            SoundClass.Setup();

            try
            {
                CustomVisuals.Setup();
            }
            catch
            {
                Debug.LogError("custom attack animations failed.");
            }

            foreach (CharacterSO vanillaChar in BrutalAPI.BrutalAPI.vanillaChars)
                BaseChara.Add(vanillaChar);
            if (!Directory.Exists(SavePath) || !File.Exists(SavePath + "Hawthorne.config"))
            {
                StreamWriter text = File.CreateText(SavePath + "Hawthorne.config");
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml("<config Numbah = '9'> </config>");
                xmlDocument.Save((TextWriter)text);
                text.Close();
                text.Dispose();
            }
            if (File.Exists(SavePath + "Hawthorne.config"))
            {
                FileStream inStream = File.Open(SavePath + "Hawthorne.config", FileMode.Open);
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load((Stream)inStream);
                Numbah = int.Parse(xmlDocument.GetElementsByTagName("config")[0].Attributes["Numbah"].Value);
                inStream.Close();
                inStream.Dispose();
            }
            Hawthorne.NewFolder.SecondChance.costMod = Numbah;

            IDetour addThingsToSepulchreAndBronzoIDetour = (IDetour)new Hook((MethodBase)typeof(MainMenuController).GetMethod("FinalizeMainMenuSounds", ~BindingFlags.Default), typeof(SaltEnemies).GetMethod("ProcessGameStart", ~BindingFlags.Default));
            AbilityNameFix.Setup();
            Wysteria.Setup();
            LetsYouIgnoreMissingEnemiesHook.Setup();
            Hawthorne.Config.TryWriteConfig();
            Hawthorne.SaltEnemies.Add();
            Hawthorne.Hooks.Add();
            Hawthorne.MiniBossUnlockSystem.Setup();
            Hawthorne.NewFolder.LootItems.Add();
            Hawthorne.ItsWings.Add();
            Hawthorne.Chocolate.Add();
            Hawthorne.LootFour.Add();
            Hawthorne.stupidFuckingStatusEffects.Add();
            Hawthorne.OtherStatusEffects.Add();
            Hawthorne.MyStatusEffects.Add();
            Hawthorne.CentralNervousSystem.Add();
            Hawthorne.FalseTruth.Add();
            Hawthorne.Pixel.Add();
            Hawthorne.LittleAngel.Add();
            Hawthorne.Flower.Add();
            Hawthorne.Denial.Add();
            Hawthorne.Derogatory.Add();
            Hawthorne.Something.Add();
            Hawthorne.Satyr.Add();
            Hawthorne.UnMung.Add();
            Hawthorne.Crow.Add();
            Hawthorne.DontTouchMe.Add();
            Hawthorne.Stars.Add();
            Hawthorne.gay.Rustic.Add();
            Hawthorne.gay.gopel.Add();
            Hawthorne.CameraEffects.Add();
            Hawthorne.Camera.Add();
            Hawthorne.CameraEncounters.Add();
            Hawthorne.DeadGod.Add();
            Hawthorne.NewFolder.Phase0.Add();
            Hawthorne.Shiny.Hook();
            Hawthorne.Shiny.Add();
            Hawthorne.CNSEncounters.Add();
            Hawthorne.FalseTruthEncounters.Add();
            Hawthorne.PixelEncounters.Add();
            Hawthorne.AngelEncounters.Add();
            Hawthorne.DeadGodEncounter.Add();
            Hawthorne.SatyrEncounters.Add();
            Hawthorne.UnMungEncounters.Add();
            Hawthorne.SomethingEncounters.Add();
            Hawthorne.CrowEncounters.Add();
            Hawthorne.FlowerEncounters.Add();
            Hawthorne.GreyEncounters.Add();
            Hawthorne.RustEncounters.Add();
            Hawthorne.DontTouchMeEncounters.Add();
            Hawthorne.StarsEncounters.Add();
            if (DoDebugs.GenInfo) Logger.LogInfo("Beginning Group 4");
            Hawthorne.Rework.Setup();
            Hawthorne.DrownInfo.Setup();
            Hawthorne.WaterInfo.Setup();
            Hawthorne.GroupFour.Setup();
            Hawthorne.GroupFour.AddEnemies();
            TellsYouToInstallSaltAdjustments.TellYou();
            Hawthorne.PageCollector.Setup();

            new Harmony("What.How.WhatTheFuck").PatchAll();
            Hawthorne.Shittary.Setup();
            try { EnemyRefresher.Setup(); }
            catch { Debug.LogError("enemy refreshser failed to set up :("); }
            Hawthorne.MultiSpriteEnemyLayout.Setup();
            Hawthorne.FieldEffectFixHook.Setup();
            try { ShuaHandler.Setup(); } catch { Debug.LogError("SHUA HANDLER EPIC FAILURE"); }

            Logger.LogInfo("Salt.Hawthorne loaded successfully!");
            return;
            assetBundle.Unload(false);
            Group4 = AssetBundle.LoadFromMemory(ResourceLoader.ResourceBinary("group4"));
            if (Group4 != null) Debug.Log("IT FUCKING WORKED WHOOOOOOO");

            Debug.Log(ResourceLoader.ResourceBinary("hawthorne").Length);
            Debug.Log(ResourceLoader.ResourceBinary("group4").Length);
            //Prayer.Add();
        }

        public static void Add()
        {
            if (DoDebugs.GenInfo) Debug.Log("status effect started");
            IDetour addStunIntentIDetour = (IDetour)new Hook((MethodBase)typeof(IntentHandlerSO).GetMethod("Initialize", ~BindingFlags.Default), typeof(SaltEnemies).GetMethod("StunnedIntent", ~BindingFlags.Default));
            IDetour addPowerIDetour = (IDetour)new Hook((MethodBase)typeof(CombatManager).GetMethod("InitializeCombat", ~BindingFlags.Default), typeof(SaltEnemies).GetMethod("AddPowerStatusEffect", ~BindingFlags.Default));
            IDetour addPowerIntentIDetour = (IDetour)new Hook((MethodBase)typeof(IntentHandlerSO).GetMethod("Initialize", ~BindingFlags.Default), typeof(SaltEnemies).GetMethod("PowerIntent", ~BindingFlags.Default));
            IDetour addAnestheticsIDetour = (IDetour)new Hook((MethodBase)typeof(CombatManager).GetMethod("InitializeCombat", ~BindingFlags.Default), typeof(SaltEnemies).GetMethod("AddAnestheticsStatusEffect", ~BindingFlags.Default));
            IDetour addAnestheticsIntentIDetour = (IDetour)new Hook((MethodBase)typeof(IntentHandlerSO).GetMethod("Initialize", ~BindingFlags.Default), typeof(SaltEnemies).GetMethod("AnestheticsIntent", ~BindingFlags.Default));
            IDetour addPaleIDetour = (IDetour)new Hook((MethodBase)typeof(CombatManager).GetMethod("InitializeCombat", ~BindingFlags.Default), typeof(SaltEnemies).GetMethod("AddPaleStatusEffect", ~BindingFlags.Default));
            IDetour addPaleIntentIDetour = (IDetour)new Hook((MethodBase)typeof(IntentHandlerSO).GetMethod("Initialize", ~BindingFlags.Default), typeof(SaltEnemies).GetMethod("PaleIntent", ~BindingFlags.Default));
            IDetour addDeterminedIDetour = (IDetour)new Hook((MethodBase)typeof(CombatManager).GetMethod("InitializeCombat", ~BindingFlags.Default), typeof(SaltEnemies).GetMethod("AddDeterminedStatusEffect", ~BindingFlags.Default));
            IDetour addDeterminedIntentIDetour = (IDetour)new Hook((MethodBase)typeof(IntentHandlerSO).GetMethod("Initialize", ~BindingFlags.Default), typeof(SaltEnemies).GetMethod("DeterminedIntent", ~BindingFlags.Default));

            if (DoDebugs.GenInfo) Debug.Log("status effect");

            IDetour addOnClickedIDetour = (IDetour)new Hook((MethodBase)typeof(EnemyInFieldLayout).GetMethod("OnSlotClicked", ~BindingFlags.Default), typeof(SaltEnemies).GetMethod("OnClicked", ~BindingFlags.Default));
            IDetour addTimelineClickedIDetour = (IDetour)new Hook((MethodBase)typeof(TimelineSlotLayout).GetMethod("OnSlotClicked", ~BindingFlags.Default), typeof(SaltEnemies).GetMethod("OnTimelineSelected", ~BindingFlags.Default));

            if (DoDebugs.GenInfo) Debug.Log("on click detour");

            IDetour CountIDetour = new Hook((MethodBase)typeof(TooltipTextHandlerSO).GetMethod("ProcessStoredValue", ~BindingFlags.Default), typeof(SaltEnemies).GetMethod("CountStoredValue", ~BindingFlags.Default));
            IDetour WaitIDetour = new Hook((MethodBase)typeof(TooltipTextHandlerSO).GetMethod("ProcessStoredValue", ~BindingFlags.Default), typeof(SaltEnemies).GetMethod("WaitStoredValue", ~BindingFlags.Default));

            IDetour MainStart = new Hook(typeof(MainMenuController).GetMethod(nameof(MainMenuController.Start), ~BindingFlags.Default), typeof(SaltEnemies).GetMethod(nameof(Start), ~BindingFlags.Default));
        }
        public static bool inCombat = false;
        public static int inCombatClicking = 0;
        public static void OnClicked(Action<EnemyInFieldLayout> orig, EnemyInFieldLayout enemyOfField)
        {
            //CombatManager.Instance.ProcessImmediateAction(new OnEnemyClickedImmediateAction(enemyOfField.EnemyID), false);
            orig(enemyOfField);
            if (inCombatClicking <= 0)
            {
                return;
            }
            else
            {
                if (enemyOfField == null)
                {
                    Debug.Log("layout was null, quitting");
                    return;
                }
                if (enemyOfField.EnemyID == null)
                {
                    Debug.Log("ID was null, quitting");
                    return;
                }
                Targetting_ByUnit_Side target = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
                target.getAllUnitSlots = false;
                target.getAllies = false;

                TryTriggerOnClickEffect runIt = ScriptableObject.CreateInstance<TryTriggerOnClickEffect>();
                runIt.thisOne = enemyOfField.EnemyID;
                //Debug.Log("target field layout ID");
                //Debug.Log(runIt.thisOne);
                if (runIt.thisOne == null)
                {
                    Debug.Log("it's null");
                    CombatManager c;
                    TimelineSlotUI t;
                }

                Effect killdmg = new Effect(runIt, 1, IntentType.Misc, target);

                CombatManager.Instance.AddPrioritySubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { killdmg }),
                    CombatManager.Instance._stats.CharactersOnField.First().Value));
            }
        }
        public static void OnTimelineSelected(Action<TimelineSlotLayout> orig, TimelineSlotLayout self)
        {
            orig(self);
            if (DoDebugs.MiscInfo) Debug.Log("timeline clicked");
            if (inCombatClicking <= 0)
            {
                return;
            }
            if (DoDebugs.MiscInfo) Debug.Log("timeline click grahgrahgrah");
            CombatStats stats = CombatManager.Instance._stats;
            TimelineInfo timelineInfo = stats.combatUI._timelineSlotInfo[self.TimelineSlotID];
            if (timelineInfo.isSecret)
            {
                return;
            }
            int enemyID = timelineInfo.enemyID;
            int num = -1;
            if (stats.combatUI._enemiesInCombat.TryGetValue(enemyID, out EnemyCombatUIInfo value))
            {
                num = value.ID;
            }
            //int iD = CombatManager.Instance._stats.timeline.Round[self.TimelineSlotID].turnUnit.ID;
            //EnemyCombat enemyCombat = CombatManager.Instance._stats.TryGetEnemyOnField(iD);
            TryTriggerOnClickEffect runIt = ScriptableObject.CreateInstance<TryTriggerOnClickEffect>();
            runIt.thisOne = enemyID;
            Effect killdmg = new Effect(runIt, 1, IntentType.Misc, Targetting.AllEnemy);
            CombatManager.Instance.AddPrioritySubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { killdmg }),
                    CombatManager.Instance._stats.CharactersOnField.First().Value));
            TimelineSlotLayout t;
        }


        public static string CursedNoise => "event:/Combat/StatusEffects/SE_Cursed_Apl";

        public static IntentInfo stunIntent = new IntentInfoBasic();
        public static void StunnedIntent(Action<IntentHandlerSO> orig, IntentHandlerSO self)
        {
            orig(self);
            stunIntent._type = (IntentType)988896;
            stunIntent._sprite = ResourceLoader.LoadSprite("StunIcon", 32);
            stunIntent._color = Color.white;
            stunIntent._sound = self._intentDB[IntentType.Status_Frail]._sound;
            IntentInfo intentInfo;
            self._intentDB.TryGetValue((IntentType)988896, out intentInfo);
            if (intentInfo == null)
                self._intentDB.Add((IntentType)988896, (IntentInfo)stunIntent);
        }
        public static StatusEffectInfoSO power = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
        public static void AddPowerStatusEffect(Action<CombatManager> orig, CombatManager self)
        {
            orig(self);
            //StatusEffectInfoSO anesthetics;
            power.name = "Power";
            power.icon = ResourceLoader.LoadSprite("StatusPower", 32);
            power._statusName = "Power";
            power.statusEffectType = (StatusEffectType)456789;
            power._description = "Increase damage dealt by this character by 1 for each stack. Upon dealing damage, 50% chance to reduce Power by 1. If Power reduces, 33% chance to reduce Power by 1 again.";
            power._applied_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Focused].AppliedSoundEvent;
            power._updated_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Focused].UpdatedSoundEvent;
            power._removed_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Focused].RemovedSoundEvent;
            StatusEffectInfoSO effectInfo;
            self._stats.statusEffectDataBase.TryGetValue((StatusEffectType)456789, out effectInfo);
            if (effectInfo == null)
                self._stats.statusEffectDataBase.Add((StatusEffectType)456789, power);
            else
                self._stats.statusEffectDataBase[(StatusEffectType)456789] = power;
        }
        public static IntentInfo powerIntent = new IntentInfoBasic();
        public static void PowerIntent(Action<IntentHandlerSO> orig, IntentHandlerSO self)
        {
            orig(self);
            powerIntent._type = (IntentType)987895;
            powerIntent._sprite = ResourceLoader.LoadSprite("StatusPower", 32);
            powerIntent._color = Color.white;
            powerIntent._sound = self._intentDB[IntentType.Status_Scars]._sound;
            IntentInfo intentInfo;
            self._intentDB.TryGetValue((IntentType)987895, out intentInfo);
            if (intentInfo == null)
                self._intentDB.Add((IntentType)987895, powerIntent);
            else
                self._intentDB[(IntentType)987895] = powerIntent;
        }
        public static StatusEffectInfoSO anesthetics = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
        public static void AddAnestheticsStatusEffect(Action<CombatManager> orig, CombatManager self)
        {
            orig(self);
            anesthetics.name = "Anesthetics";
            anesthetics.icon = ResourceLoader.LoadSprite("anesthetics2", 32);
            anesthetics._statusName = "Anesthetics";
            anesthetics.statusEffectType = (StatusEffectType)204308;
            anesthetics._description = "All damage received will be decreased by 1 for each Anesthetic, this applies to both direct and indirect damage. This effect cannot decrease damage to levels below zero. Decreases by 1 at the start of each turn.";
            anesthetics._applied_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Scars].AppliedSoundEvent;
            anesthetics._updated_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Scars].UpdatedSoundEvent;
            anesthetics._removed_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Scars].RemovedSoundEvent;
            StatusEffectInfoSO effectInfo;
            self._stats.statusEffectDataBase.TryGetValue((StatusEffectType)204308, out effectInfo);
            if (effectInfo == null)
                self._stats.statusEffectDataBase.Add((StatusEffectType)204308, anesthetics);
        }
        public static IntentInfo anestheticsIntent = new IntentInfoBasic();
        public static void AnestheticsIntent(Action<IntentHandlerSO> orig, IntentHandlerSO self)
        {
            orig(self);
            anestheticsIntent._type = (IntentType)987898;
            anestheticsIntent._sprite = ResourceLoader.LoadSprite("anesthetics2", 32);
            anestheticsIntent._color = Color.white;
            anestheticsIntent._sound = self._intentDB[IntentType.Status_Scars]._sound;
            IntentInfo intentInfo;
            self._intentDB.TryGetValue((IntentType)987898, out intentInfo);
            if (intentInfo == null)
                self._intentDB.Add((IntentType)987898, (IntentInfo)anestheticsIntent);
        }
        public static StatusEffectInfoSO pale = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
        public static void AddPaleStatusEffect(Action<CombatManager> orig, CombatManager self)
        {
            orig(self);
            pale.name = "Pale";
            pale.icon = ResourceLoader.LoadSprite("PaleStatus", 32);
            pale._statusName = "Pale";
            pale.statusEffectType = (StatusEffectType)888666;
            pale._description = "Upon taking indirect damage, deal all stacks of Pale as a percent of maximum health damage. This damage ignores damage modifiers. \nThis status is prevented from activating on character's if they take no damage. This is not the same for enemies.";
            pale._applied_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Linked].AppliedSoundEvent;
            pale._updated_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Linked].UpdatedSoundEvent;
            pale._removed_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Linked].RemovedSoundEvent;
            StatusEffectInfoSO effectInfo;
            self._stats.statusEffectDataBase.TryGetValue((StatusEffectType)888666, out effectInfo);
            if (effectInfo == null)
                self._stats.statusEffectDataBase.Add((StatusEffectType)888666, pale);
        }
        public static IntentInfo paleIntent = new IntentInfoBasic();
        public static void PaleIntent(Action<IntentHandlerSO> orig, IntentHandlerSO self)
        {
            orig(self);
            paleIntent._type = (IntentType)666888;
            paleIntent._sprite = ResourceLoader.LoadSprite("PaleStatus", 32);
            paleIntent._color = Color.white;
            paleIntent._sound = self._intentDB[IntentType.Status_Linked]._sound;
            IntentInfo intentInfo;
            self._intentDB.TryGetValue((IntentType)666888, out intentInfo);
            if (intentInfo == null)
                self._intentDB.Add((IntentType)666888, (IntentInfo)paleIntent);
        }
        public static StatusEffectInfoSO determined = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
        public static void AddDeterminedStatusEffect(Action<CombatManager> orig, CombatManager self)
        {
            orig(self);
            //StatusEffectInfoSO anesthetics;
            determined.name = "Determined";
            determined.icon = ResourceLoader.LoadSprite("Determined", 32);
            determined._statusName = "Determined";
            determined.statusEffectType = (StatusEffectType)555556;
            determined._description = "Upon dying, prevent death and heal this character however many stacks of Determined they have. Remove all Determined. Decreases by 1 at the start of each turn. Does not work on Cursed, Dying, or Inanimate units.";
            determined._applied_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Linked].AppliedSoundEvent;
            determined._updated_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Linked].UpdatedSoundEvent;
            determined._removed_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Linked].RemovedSoundEvent;
            StatusEffectInfoSO effectInfo;
            self._stats.statusEffectDataBase.TryGetValue((StatusEffectType)555556, out effectInfo);
            if (effectInfo == null)
                self._stats.statusEffectDataBase.Add((StatusEffectType)555556, determined);
        }
        public static IntentInfo determinedIntent = new IntentInfoBasic();
        public static void DeterminedIntent(Action<IntentHandlerSO> orig, IntentHandlerSO self)
        {
            orig(self);
            determinedIntent._type = (IntentType)987896;
            determinedIntent._sprite = ResourceLoader.LoadSprite("Determined", 32);
            determinedIntent._color = Color.white;
            determinedIntent._sound = self._intentDB[IntentType.Status_Scars]._sound;
            IntentInfo intentInfo;
            self._intentDB.TryGetValue((IntentType)987896, out intentInfo);
            if (intentInfo == null)
                self._intentDB.Add((IntentType)987896, (IntentInfo)determinedIntent);
        }

        public static string CountStoredValue(Func<TooltipTextHandlerSO, UnitStoredValueNames, int, string> orig, TooltipTextHandlerSO self, UnitStoredValueNames storedValue, int value)
        {
            Color red = Color.red;
            string str1;
            if (storedValue == (UnitStoredValueNames)544524)
            {
                if (value <= 0)
                {
                    str1 = "";
                }
                else
                {
                    string str2 = "Count" + string.Format(" {0}", (object)value);
                    string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(self._negativeSTColor) + ">";
                    string str4 = "</color>";
                    str1 = str3 + str2 + str4;
                }
            }
            else
                str1 = orig(self, storedValue, value);
            return str1;
        }
        public static string WaitStoredValue(Func<TooltipTextHandlerSO, UnitStoredValueNames, int, string> orig, TooltipTextHandlerSO self, UnitStoredValueNames storedValue, int value)
        {
            Color red = Color.red;
            string str1;
            if (storedValue == (UnitStoredValueNames)544525)
            {
                if (value <= 0)
                {
                    str1 = "";
                }
                else
                {
                    string str2 = "Wait" + string.Format(" {0}", (object)value);
                    string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(self._positiveSTColor) + ">";
                    string str4 = "</color>";
                    str1 = str3 + str2 + str4;
                }
            }
            else
                str1 = orig(self, storedValue, value);
            return str1;
        }


        const BindingFlags AllFlags = (BindingFlags)(-1);

        static public Button optionsbutton;
        //static public GameObject origoptionsbutton = new GameObject();
        static public TMP_FontAsset swordfont;
        static public ColorBlock colorblock;
        static public Vector2 resMod;

        static ColorBlock defButton;
        static ColorBlock unselectButton;

        public static string wysteria => CrashesYourGame.Name;

        public static void increaseChastityRate()
        {
            EnemySO sepulchre = LoadedAssetsHandler.GetEnemy("Sepulchre_EN");
            RaritySO higher = ScriptableObject.CreateInstance<RaritySO>();
            higher.canBeRerolled = true;//I think?
            higher.rarityValue = 15;//or something.
            sepulchre.abilities[0].rarity = higher;
        }


        /*
        public static void MainMenuStart(Action<MainMenuController> orig, MainMenuController self)
        {
            orig(self);
            GameObject modmenubuttongo = new GameObject();
            GameObject origoptionsbutton = new GameObject();
            Button modmenubutton = null;
            TextMeshProUGUI modmenutext = null;
            foreach (Button button in FindObjectsOfType(typeof(Button)))
            {
                if (button.gameObject.name == "OptionsButton")
                {
                Debug.Log("found");
                origoptionsbutton = button.gameObject;
                optionsbutton = button;
                button.targetGraphic = origoptionsbutton.GetComponentInChildren<TextMeshProUGUI>();
                modmenubuttongo = Instantiate(origoptionsbutton, origoptionsbutton.transform.parent);
                modmenubutton = modmenubuttongo.GetComponent<Button>();
                modmenutext = modmenubuttongo.GetComponentInChildren<TextMeshProUGUI>();
                swordfont = modmenutext.font;
                colorblock = button.colors;
                break;
                }
            }
        }*/

        public static void addSepulchrePool(string name)
        {
            if (LetsYouIgnoreMissingEnemiesHook.IsDisabled(name)) return;
            EnemySO enemy;
            if (LoadedAssetsHandler.LoadedEnemies.TryGetValue(name, out enemy))
            {
                if (enemy == null) { if (DoDebugs.EnemyNull) Debug.LogError(name + " failed to add to the Bronzo pool."); return; }
                if (!((LoadedAssetsHandler.GetEnemy("Sepulchre_EN").abilities[0].ability.effects[2].effect as SpawnMassivelyEverywhereUsingHealthEffect)._possibleEnemies.Contains(enemy)))
                {
                    List<EnemySO> enemies = new List<EnemySO>((LoadedAssetsHandler.GetEnemy("Sepulchre_EN").abilities[0].ability.effects[2].effect as SpawnMassivelyEverywhereUsingHealthEffect)._possibleEnemies);
                    enemies.Add(enemy);
                    (LoadedAssetsHandler.GetEnemy("Sepulchre_EN").abilities[0].ability.effects[2].effect as SpawnMassivelyEverywhereUsingHealthEffect)._possibleEnemies = enemies.ToArray();
                    //Debug.Log(name + " has been added to the Sepulchre pool.");
                }
            }
            else
            {
                if (DoDebugs.EnemyNull) Debug.LogError(name + " failed to add to the Sepulchre pool.");
            }
        }
        public static void addBronzoPool(string name)
        {
            if (LetsYouIgnoreMissingEnemiesHook.IsDisabled(name)) return;
            EnemySO enemy;
            if (LoadedAssetsHandler.LoadedEnemies.TryGetValue(name, out enemy))
            {
                if (enemy == null) { if (DoDebugs.EnemyNull) Debug.LogError(name + " failed to add to the Bronzo pool."); return; }
                if (!((LoadedAssetsHandler.GetEnemy("Bronzo5_EN").abilities[0].ability.effects[0].effect as SpawnRandomEnemyAnywhereEffect)._enemies.Contains(enemy)))
                {
                    List<EnemySO> enemies = new List<EnemySO>((LoadedAssetsHandler.GetEnemy("Bronzo5_EN").abilities[0].ability.effects[0].effect as SpawnRandomEnemyAnywhereEffect)._enemies);
                    enemies.Add(enemy);
                    (LoadedAssetsHandler.GetEnemy("Bronzo5_EN").abilities[0].ability.effects[0].effect as SpawnRandomEnemyAnywhereEffect)._enemies = enemies.ToArray();
                    //Debug.Log(name + " has been added to the Bronzo pool.");
                }
            }
            else
            {
                if (DoDebugs.EnemyNull) Debug.LogError(name + " failed to add to the Bronzo pool.");
            }
        }
        public static void AddScrungiePool(string enemy)
        {
            if (LetsYouIgnoreMissingEnemiesHook.IsDisabled(enemy)) return;
            if (!Check.EnemyExist("Scrungie_EN"))
            {
                if (DoDebugs.EnemyNull) Debug.LogError("Why is the scrungie null");
                return;
            }
            if (!Check.EnemyExist(enemy))
            {
                if (DoDebugs.EnemyNull) Debug.LogWarning("target enemy to throw into scrung pool is null");
                return;
            }
            EnemySO scrung = LoadedAssetsHandler.GetEnemy("Scrungie_EN");
            AbilitySO gurg = scrung.abilities[3].ability;
            SpawnRandomEnemyAnywhereEffect babi = gurg.effects[0].effect as SpawnRandomEnemyAnywhereEffect;
            List<EnemySO> enemies = new List<EnemySO>(babi._enemies);
            enemies.Add(LoadedAssetsHandler.GetEnemy(enemy));
            babi._enemies = enemies.ToArray();
        }
        public static void addFountainPool(string name)
        {
            if (LetsYouIgnoreMissingEnemiesHook.IsDisabled(name)) return;
            if (LoadedAssetsHandler.LoadedEnemies.TryGetValue("TheFountainofYouth_EN", out EnemySO fountin))
            {
                EnemySO enemy;
                if (LoadedAssetsHandler.LoadedEnemies.TryGetValue(name, out enemy))
                {
                    if (enemy == null) { if (DoDebugs.EnemyNull) Debug.LogError(name + " failed to add to the Bronzo pool."); return; }
                    if (!(fountin.abilities[0].ability.effects[0].effect as SpawnRandomEnemyAnywhereEffect)._enemies.Contains(enemy))
                    {
                        List<EnemySO> enemies = new List<EnemySO>((fountin.abilities[0].ability.effects[0].effect as SpawnRandomEnemyAnywhereEffect)._enemies);
                        enemies.Add(enemy);
                        (fountin.abilities[0].ability.effects[0].effect as SpawnRandomEnemyAnywhereEffect)._enemies = enemies.ToArray();
                        //Debug.Log(name + " has been added to the Bronzo pool.");
                    }
                }
                else
                {
                    if (DoDebugs.EnemyNull) Debug.LogError(name + " failed to add to the Fountain pool.");
                }
            }
            else
            {
                if (DoDebugs.EnemyNull) Debug.LogError("The fountain doesnt exist....");
            }
        }
        public static void DontAddPool(string enemy)
        {
            if (LetsYouIgnoreMissingEnemiesHook.IsDisabled(enemy)) return;
            enemy = enemy;
            return;
        }

        public static void ProcessGameStart(Action<MainMenuController> orig, MainMenuController self)
        {
            orig(self);
            //Taco
            addSepulchrePool("Monck_EN");
            addSepulchrePool("Iconoclast_EN");
            addBronzoPool("Monck_EN");//Monck_Primary_Easy Monck_Primary_Medium Monck_Primary_Hard Monck_KillMe_Hard
            addBronzoPool("Iconoclast_EN");//Iconoclast_Hard
            addBronzoPool("TheFatman_EN");//TheFatman_Hard_Miniboss
            addBronzoPool("Disembodied_EN");//Disembodied_Primary_Medium Disembodied_Primary_Hard Disembodied_Diva_Hard
            addBronzoPool("BarnacleQueen_EN");//BarnacleQueen_Hard_Miniboss
            addFountainPool("Monck_EN");

            //TairPeep
            AddScrungiePool("Flarbleft_EN");
            AddScrungiePool("LipBug_EN");
            DontAddPool("DrySimian_EN");
            DontAddPool("Unflarb_EN");
            DontAddPool("DavyFlarb_EN");
            DontAddPool("Flarbleft_EN");
            DontAddPool("LipBug_EN");
            DontAddPool("SandBank_EN");
            DontAddPool("YellowSandBank_EN");
            DontAddPool("DesiccatingJumbleguts_EN");
            DontAddPool("PerforatedSpoggle_EN");
            DontAddPool("NakedGizo_EN");
            DontAddPool("Gizo_EN");
            DontAddPool("Chapman_EN");
            DontAddPool("RoadieCase_EN");
            DontAddPool("GoldRoadieCase_EN");
            DontAddPool("SingingMountain_EN");
            DontAddPool("Maestro_EN");
            DontAddPool("TitteringPeon_EN");
            DontAddPool("Unterling_EN");
            DontAddPool("ScreamingHomunculus_EN");
            DontAddPool("SterileBud_EN");
            DontAddPool("Psychopomp_EN");
            DontAddPool("ImpenetrableAngler_EN");
            DontAddPool("MalformedUnicorn_EN");
            DontAddPool("HumanElement_EN");
            DontAddPool("FamiliarSpoggle_EN");
            DontAddPool("Chapbull_EN");
            DontAddPool("RevoltingRevola_EN");
            DontAddPool("Ophanim_EN");
            DontAddPool("Nephilim_EN");
            DontAddPool("Seraphim_EN");
            DontAddPool("Metatron_EN");
            //bosses
            DontAddPool("Deer_EN");
            DontAddPool("Stag_EN");
            DontAddPool("Doula_EN");
            DontAddPool("HeinousHighness_EN");
            DontAddPool("GigglingUsurper_EN");
            DontAddPool("SelfishRock_EN");
            DontAddPool("\"Divine\"Rock_EN");
            DontAddPool("TrappingRock_EN");
            DontAddPool("PouringRock_EN");
            DontAddPool("Intijar_EN");
            //Fuck the zygotes
            DontAddPool("DepressionSquid_EN");
            DontAddPool("GrippingTentacle_EN");
            DontAddPool("CarefulTentacle_EN");
            DontAddPool("SqueezingTentacle_EN");
            DontAddPool("DesperateTentacle_EN");
            DontAddPool("CopperCougher_EN");
            DontAddPool("TheGoblin_EN");
            DontAddPool("Cherubim_EN");
            /*Far Shore
            unflarb1
            Sandbank1 IGNORE
            Sandbank2 IGNORE
            Simiann
            Simianh
            Fuck the zygotes
            NephNormal
            NephHardl
             */
            /*Orpheum
            Sgizo1
            Sgizo2
            GjumbleN
            GSpoggleN
            Roadie2 IGNORE
            Roadie1 IGNORE
            ChapManMed
            Mountain IGNORE
            NSpoggleN
            RevoltingHard IGNORE
            ChapBullHard IGNORE
            OphanimHard
             */
            /*Garden
            Peonm
            Peone
            PompM
            PompH
            SterileBudNormal
            SterileBudHard
            AnglerH
            MetatronH
             */

            //Salt
            addSepulchrePool("LostSheep_EN");
            addSepulchrePool("Enigma_EN");
            addSepulchrePool("DeadPixel_EN");
            addSepulchrePool("A'Flower'_EN");
            addSepulchrePool("Denial_EN");
            addSepulchrePool("Derogatory_EN");
            addSepulchrePool("Something_EN");
            addSepulchrePool("Satyr_EN");
            addSepulchrePool("TheCrow_EN");
            addSepulchrePool("Freud_EN");
            addSepulchrePool("RusticJumbleguts_EN");
            addSepulchrePool("FakeAngel_EN");
            addSepulchrePool("Illusion_EN");
            addSepulchrePool("RedFlower_EN");
            addSepulchrePool("BlueFlower_EN");
            addSepulchrePool("YellowFlower_EN");
            addSepulchrePool("PurpleFlower_EN");
            addSepulchrePool("GreyFlower_EN");
            addSepulchrePool("RealisticTank_EN");
            addSepulchrePool("ClockTower_EN");
            addSepulchrePool("StalwartTortoise_EN");
            addSepulchrePool("Grandfather_EN");
            addSepulchrePool("MiniReaper_EN");
            addSepulchrePool("Skyloft_EN");
            addSepulchrePool("Miriam_EN");
            addSepulchrePool("EyePalm_EN");
            addSepulchrePool("Merced_EN");
            addSepulchrePool("Shua_EN");
            addSepulchrePool("TripodFish_EN");
            addSepulchrePool("Lyssa_EN");
            addSepulchrePool("GlassFigurine_EN");
            addSepulchrePool("Hunter_EN");
            //addSepulchrePool("Firebird_EN");
            addSepulchrePool("LittleBeak_EN");
            addSepulchrePool("Warbird_EN");
            addSepulchrePool("Windle3_EN");
            addSepulchrePool("BlackStar_EN");
            addSepulchrePool("Indicator_EN");
            addSepulchrePool("Maw_EN");
            addSepulchrePool("Clione_EN");
            addSepulchrePool("Children6_EN");
            addSepulchrePool("YNL_EN");
            addSepulchrePool("Spitato_EN");
            addSepulchrePool("Pinano_EN");
            addSepulchrePool("Minana_EN");
            AddScrungiePool("LostSheep_EN");
            AddScrungiePool("Derogatory_EN");
            AddScrungiePool("Denial_EN");
            AddScrungiePool("DeadPixel_EN");
            AddScrungiePool("LittleAngel_EN");
            AddScrungiePool("StarGazer_EN");
            AddScrungiePool("Windle1_EN");
            AddScrungiePool("BlackStar_EN");
            AddScrungiePool("Children6_EN");
            AddScrungiePool("Minana_EN");
            addFountainPool("LostSheep_EN");
            addFountainPool("Enigma_EN");
            addFountainPool("A'Flower'_EN");
            addFountainPool("Denial_EN");
            addFountainPool("Something_EN");
            addFountainPool("TheCrow_EN");
            addFountainPool("Freud_EN");
            addFountainPool("RusticJumbleguts_EN");
            addFountainPool("FakeAngel_EN");
            addFountainPool("Illusion_EN");
            addFountainPool("RedFlower_EN");
            addFountainPool("BlueFlower_EN");
            addFountainPool("YellowFlower_EN");
            addFountainPool("PurpleFlower_EN");
            addFountainPool("GreyFlower_EN");
            addFountainPool("WindSong_EN");
            addFountainPool("Sigil_EN");
            addFountainPool("RealisticTank_EN");
            addFountainPool("StalwartTortoise_EN");
            //addFountainPool("Firebird_EN");
            addFountainPool("LittleBeak_EN");
            addFountainPool("Warbird_EN");
            addFountainPool("MiniReaper_EN");
            addFountainPool("Miriam_EN");
            addFountainPool("EyePalm_EN");
            //addFountainPool("Skyloft_EN");
            addFountainPool("Shua_EN");
            addFountainPool("TripodFish_EN");
            addFountainPool("Lyssa_EN");
            addFountainPool("GlassFigurine_EN");
            addFountainPool("Windle2_EN");
            addFountainPool("BlackStar_EN");
            addFountainPool("Indicator_EN");
            addFountainPool("Clione_EN");
            addFountainPool("Children1_EN");
            addFountainPool("YNL_EN");
            addFountainPool("Spitato_EN");
            addFountainPool("Pinano_EN");
            addFountainPool("Minana_EN");
            addBronzoPool("LostSheep_EN");
            addBronzoPool("Enigma_EN");
            addBronzoPool("DeadPixel_EN");
            addBronzoPool("LittleAngel_EN");
            addBronzoPool("A'Flower'_EN");
            addBronzoPool("Denial_EN");
            addBronzoPool("Derogatory_EN");
            addBronzoPool("Something_EN");
            addBronzoPool("Satyr_EN");
            addBronzoPool("TeachaMantoFish_EN");
            addBronzoPool("TheCrow_EN");
            addBronzoPool("Freud_EN");
            addBronzoPool("StarGazer_EN");
            addBronzoPool("RusticJumbleguts_EN");
            addBronzoPool("MortalSpoggle_EN");
            addBronzoPool("MechanicalLens_EN");
            addBronzoPool("EmbersofaDeadGod_EN");
            //addBronzoPool("CoinHunter_EN");
            addBronzoPool("FakeAngel_EN");
            addBronzoPool("Illusion_EN");
            addBronzoPool("RedFlower_EN");
            addBronzoPool("BlueFlower_EN");
            addBronzoPool("YellowFlower_EN");
            addBronzoPool("PurpleFlower_EN");
            addBronzoPool("GreyFlower_EN");
            addBronzoPool("LivingSolvent_EN");
            addBronzoPool("WindSong_EN");
            addBronzoPool("Sigil_EN");
            addBronzoPool("RealisticTank_EN");
            addBronzoPool("ClockTower_EN");
            addBronzoPool("StalwartTortoise_EN");
            addBronzoPool("Grandfather_EN");
            addBronzoPool("MiniReaper_EN");
            addBronzoPool("Skyloft_EN");
            addBronzoPool("Miriam_EN");
            addBronzoPool("EyePalm_EN");
            addBronzoPool("Merced_EN");
            addBronzoPool("Butterfly_EN");
            addBronzoPool("Shua_EN");
            addBronzoPool("Nameless_EN");
            addBronzoPool("TripodFish_EN");
            addBronzoPool("Lyssa_EN");
            addBronzoPool("GlassFigurine_EN");
            addBronzoPool("Damocles_EN");
            addBronzoPool("TheDeep_EN");
            addBronzoPool("Postmodern_EN");
            addBronzoPool("War_EN");
            addBronzoPool("SnakeGod_EN");
            addBronzoPool("Hunter_EN");
            addBronzoPool("Firebird_EN");
            addBronzoPool("LittleBeak_EN");
            addBronzoPool("Warbird_EN");
            addBronzoPool("Windle1_EN");
            addBronzoPool("Windle2_EN");
            addBronzoPool("Windle3_EN");
            addBronzoPool("BlackStar_EN");
            addBronzoPool("Singularity_EN");
            addBronzoPool("Indicator_EN");
            addBronzoPool("Maw_EN");
            addBronzoPool("Clione_EN");
            addBronzoPool("Children6_EN");
            addBronzoPool("YNL_EN");
            addBronzoPool("Spitato_EN");
            addBronzoPool("Pinano_EN");
            addBronzoPool("Minana_EN");
            //Salt Fools 2
            addSepulchrePool("Delusion_EN");
            addFountainPool("Delusion_EN");
            addBronzoPool("Delusion_EN");

            //Rainbow
            addSepulchrePool("BondedJumbleGuts_EN");
            addSepulchrePool("AnnoyingJumbleGuts_EN");
            addSepulchrePool("ParasiticJumbleGuts_EN");
            addSepulchrePool("AmphibiousSpoggle_EN");
            addSepulchrePool("IchtyosatedSpoggle_EN");
            addSepulchrePool("EclipsedSpoggle_EN");
            addSepulchrePool("MalignantJumbleGuts_EN");
            addSepulchrePool("ArtisticJumbleGuts_EN");
            addSepulchrePool("WaxingJumbleGuts_EN");
            addSepulchrePool("FoamingSpoggle_EN");
            addSepulchrePool("NecromanticSpoggle_EN");
            addSepulchrePool("PoolingSpoggle_EN");
            addFountainPool("BondedJumbleGuts_EN");
            addFountainPool("AnnoyingJumbleGuts_EN");
            addFountainPool("ParasiticJumbleGuts_EN");
            addFountainPool("AmphibiousSpoggle_EN");
            addFountainPool("IchtyosatedSpoggle_EN");
            addFountainPool("EclipsedSpoggle_EN");
            addFountainPool("MalignantJumbleGuts_EN");
            addFountainPool("ArtisticJumbleGuts_EN");
            addFountainPool("WaxingJumbleGuts_EN");
            addFountainPool("FoamingSpoggle_EN");
            addFountainPool("NecromanticSpoggle_EN");
            addFountainPool("PoolingSpoggle_EN");
            addBronzoPool("BondedJumbleGuts_EN");
            addBronzoPool("AnnoyingJumbleGuts_EN");
            addBronzoPool("ParasiticJumbleGuts_EN");
            addBronzoPool("AmphibiousSpoggle_EN");
            addBronzoPool("IchtyosatedSpoggle_EN");
            addBronzoPool("EclipsedSpoggle_EN");
            addBronzoPool("MalignantJumbleGuts_EN");
            addBronzoPool("ArtisticJumbleGuts_EN");
            addBronzoPool("WaxingJumbleGuts_EN");
            addBronzoPool("FoamingSpoggle_EN");
            addBronzoPool("NecromanticSpoggle_EN");
            addBronzoPool("PoolingSpoggle_EN");
            //Far Shore
            //Zone01_JumbleGuts_Bonded_Easy_EnemyBundle
            //1AnnEasy
            //Zone01_JumbleGuts_Prasitic_Easy_EnemyBundle
            //BondedM
            //AnnoyingM
            //ParasiticM
            //EclipsedM
            //IchtyosatedM
            //Amph

            //Orpheum
            //ArtisticM
            //MalignantM
            //WaxingM
            //FoamingM
            //NecroM
            //PoolingM

            //Artist
            //Garden
            addSepulchrePool("InfernalDrummer_EN");//DrummerMedium DrummerHard
            addSepulchrePool("Harbinger_EN");//HarbingerMed HarbingerHard
            addSepulchrePool("HowlingAvian_EN");//AvianMed AvianHard
            addSepulchrePool("Scuttlerunt_EN");//ScuttleruntMed RuntHard
            //Far Shore
            addSepulchrePool("Lurchin_EN");//LurchinMedium LurchinHard
            addSepulchrePool("FesteringFaction_EN");//FactionMedium FactionHard
            //Orpheum
            addSepulchrePool("Pacemaker_EN");//PulserMed PulserHard
            addSepulchrePool("Gordo_EN");//GordoMed GordoHard
            addFountainPool("InfernalDrummer_EN");
            addFountainPool("Harbinger_EN");
            addFountainPool("HowlingAvian_EN");
            addFountainPool("Scuttlerunt_EN");
            addFountainPool("Lurchin_EN");
            addFountainPool("FesteringFaction_EN");
            addFountainPool("Pacemaker_EN");
            addBronzoPool("Goliath_EN");//GoliathGordoHard GoliathMusicManMed GoliathMusicManHard
            addBronzoPool("Mungod_EN");
            addBronzoPool("Scrundreigon_EN");
            addBronzoPool("LostChild_EN");
            addBronzoPool("VoyagerofWar_EN");
            addBronzoPool("InfernalDrummer_EN");
            addBronzoPool("Harbinger_EN");
            addBronzoPool("HowlingAvian_EN");
            addBronzoPool("Scuttlerunt_EN");
            addBronzoPool("Offspring_EN");
            addBronzoPool("Saturn_EN");
            addBronzoPool("Lurchin_EN");
            addBronzoPool("FesteringFaction_EN");
            addBronzoPool("Billion_EN");
            addBronzoPool("Billionth_EN");
            addBronzoPool("Pacemaker_EN");
            addBronzoPool("Gordo_EN");
            addBronzoPool("Sergeant_EN");
            addBronzoPool("AmmunitionsCrate_EN");

            //Colophon
            addSepulchrePool("MaladjustedColophon_EN");//MaladjustedFarShoreHard MaladjustedMedium
            addSepulchrePool("DelightedColophon_EN");//DelightedFarShoreHard DelighteddMedium
            addSepulchrePool("DefeatedColophon_EN");//DefeatedEasy DefeatedMedium
            addSepulchrePool("ComposedColophon_EN");//ComposedEasy ComposedMedium
            addFountainPool("MaladjustedColophon_EN");
            addFountainPool("DelightedColophon_EN");
            addFountainPool("DefeatedColophon_EN");
            addFountainPool("ComposedColophon_EN");
            addBronzoPool("MaladjustedColophon_EN");
            addBronzoPool("DelightedColophon_EN");
            addBronzoPool("DefeatedColophon_EN");
            addBronzoPool("ComposedColophon_EN");

            //ZLD1
            addSepulchrePool("Boulder_EN");//Rock_Farshore
            addSepulchrePool("BoulderBuddy_EN");//RockBuddy_Farshore
            addSepulchrePool("Teto_EN");//TetoNormal
            addSepulchrePool("ReflectedHound_EN");//RefHound_Orpheum
            //addFountainPool("Boulder_EN");
            addFountainPool("BoulderBuddy_EN");
            addFountainPool("Teto_EN");
            addFountainPool("ReflectedHound_EN");
            addBronzoPool("Boulder_EN");
            addBronzoPool("BoulderBuddy_EN");
            addBronzoPool("Teto_EN");
            addBronzoPool("ReflectedHound_EN");

            //Whimsical
            addSepulchrePool("OsseousClad_EN");
            addSepulchrePool("Lymphropod_EN");
            addSepulchrePool("ColossalSheo_EN");
            addSepulchrePool("RougeWailingSplugling_EN");
            addSepulchrePool("RougeBellowingSplugling_EN");
            addSepulchrePool("RougeFesteringSplugling_EN");
            addSepulchrePool("RougeWeepingSplugling_EN");
            addSepulchrePool("RogueWailingSplugling_EN");
            addSepulchrePool("RogueBellowingSplugling_EN");
            addSepulchrePool("RogueFesteringSplugling_EN");
            addSepulchrePool("RogueWeepingSplugling_EN");
            addSepulchrePool("FumeFactory_EN");
            addSepulchrePool("FesteringMusicMan_EN");
            addSepulchrePool("Evangelists_EN");
            addFountainPool("OsseousClad_EN");
            addFountainPool("Lymphropod_EN");
            addFountainPool("ColossalSheo_EN");
            addFountainPool("RougeWailingSplugling_EN");
            addFountainPool("RougeBellowingSplugling_EN");
            addFountainPool("RougeFesteringSplugling_EN");
            addFountainPool("RougeWeepingSplugling_EN");
            addFountainPool("RogueWailingSplugling_EN");
            addFountainPool("RogueBellowingSplugling_EN");
            addFountainPool("RogueFesteringSplugling_EN");
            addFountainPool("RogueWeepingSplugling_EN");
            addFountainPool("FumeFactory_EN");
            addFountainPool("FesteringMusicMan_EN");
            addBronzoPool("Stalactite_EN");
            //addBronzoPool("Convict_EN");
            addBronzoPool("Spligis_EN");
            addBronzoPool("OsseousClad_EN");
            addBronzoPool("Lymphropod_EN");
            addBronzoPool("ColossalSheo_EN");
            addBronzoPool("RougeWailingSplugling_EN");//yellow red
            addBronzoPool("RougeBellowingSplugling_EN");//red purple
            addBronzoPool("RougeFesteringSplugling_EN");//blue yellow
            addBronzoPool("RougeWeepingSplugling_EN");//purple blue
            addBronzoPool("RogueWailingSplugling_EN");//yellow red
            addBronzoPool("RogueBellowingSplugling_EN");//red purple
            addBronzoPool("RogueFesteringSplugling_EN");//blue yellow
            addBronzoPool("RogueWeepingSplugling_EN");//purple blue
            addBronzoPool("FumeFactory_EN");
            addBronzoPool("FesteringMusicMan_EN");
            addBronzoPool("Evangelists_EN");
            /*Far Shore
            BluePurpleCrayolaFarShoreEasy
            RedYellowCrayolaFarShoreEasy
            BlueYellowCrayolaFarShoreEasy
            RedPurpleCrayolaFarShoreEasy
            PurpleRedCrayolaFarShoreMedium
            BluePurpleCrayolaFarShoreMedium
            RedYellowCrayolaFarShoreHard
            CladEasyFarShour
            CladMediumFarShour
            CladMediumNoRandomFarShour
            CladHardFarShour
            BugEasyFarShore
            BugMeduimFarShore
            BugHardFarShore
            BigBirdFarShore
            BigBirdFarShoreMedium

            BugHardFarShore
            BigBirdFarShoreMediumTheThird
             */
            /*Orpheum
            BluePurpleCrayolaOprheumMedium
            YellowRedCrayolaOprheumMedium
            CladMediumOprheum
            CladHardOprheum
            BigBirdOrpheum

            FesteringMusicManMediumOprheum
            FumeFactoryMediumOprheum
            CustomeSpoggleHardEncounters
            *//*
            EvangelistMedium
             */

            //Minichibis
            addSepulchrePool("EggKeeper_EN");//Choirboy Medium - Eggkeeper
            addFountainPool("EggKeeper_EN");
            addBronzoPool("EggKeeper_EN");

            //Marmo
            DontAddPool("Romantic_EN");
            DontAddPool("Mungbert_EN");
            DontAddPool("Errant_EN");
            addFountainPool("Romantic_EN");
            addFountainPool("Errant_EN");
            //H_M_Zone02_Errant_Hard_EnemyBundle
            //H_M_Zone02_Errant_Medium_EnemyBundle

            //wogwo
            addSepulchrePool("RolliUngbun_EN");
            addFountainPool("RolliUngbun_EN");
            addBronzoPool("RolliUngbun_EN");

            //AG
            addSepulchrePool("MarbleMaw_EN");
            addSepulchrePool("UnculturedSwine_EN");
            addSepulchrePool("FrowningChancellor_EN");
            addSepulchrePool("Jansuli_EN");
            addFountainPool("MarbleMaw_EN");
            addFountainPool("UnculturedSwine_EN");
            addFountainPool("FrowningChancellor_EN");
            addFountainPool("Jansuli_EN");
            addBronzoPool("MarbleMaw_EN");
            addBronzoPool("UnculturedSwine_EN");
            addBronzoPool("FrowningChancellor_EN");
            addBronzoPool("Jansuli_EN");

            /*
            Marble Maw and the lads
            Minister and his pet kidney stone
            Added The children yern for the mines
            What? No, no
            Who up mining they craft rn?
            They are friends :]
            Added meat flesh encounter

            crankin' my hog
            me n' the lads
            penis joke
            penis joke part 2: electric boogaloo
            Family BBQ
            worm squared
            I'm running out of \"funny\" names for these
            */

            //((LoadedAssetsHandler.GetEnemy("Sepulchre_EN").abilities[0].ability.effects[2].effect) as SpawnMassivelyEverywhereUsingHealthEffect)._possibleEnemies
            //(LoadedAssetsHandler.GetEnemy("Bronzo5_EN").abilities[0].ability.effects[0].effect as SpawnRandomEnemyAnywhereEffect)._enemies

            LetsYouIgnoreMissingEnemiesHook.ReadOutDisabled();
            PerformRandomEffectsAmongEffects.GO();

        }
        public static bool Crossed = false;
        public static void Crossover()
        {
            if (Crossed) return; Crossed = true;
            //TairPeep
            Hawthorne.CNSEncountersTairPeep.Add();//FS, O
            Hawthorne.FalseTruthEncountersTairPeep.Add();//O
            Hawthorne.PixelEncountersTairPeep.Add();//FS, G?
            Hawthorne.AngelEncountersTairPeep.Add();//G
            Hawthorne.SatyrEncountersTairPeep.Add();//G
            Hawthorne.UnMungEncountersTairPeep.Add();//FS
            Hawthorne.SomethingEncountersTairPeep.Add();//O
            Hawthorne.CrowEncountersTairPeep.Add();//O
            Hawthorne.GreyEncountersTairPeep.Add();//G
            Hawthorne.FlowerEncountersTairPeep.Add();//FS
            Hawthorne.DontTouchMeEncountersTairPeep.Add();//O
            Hawthorne.RainbowEncounters.Add();//FS, O
            Hawthorne.ColoEncounters.Add();//FS, O
            //Artist
            Hawthorne.SinnersEncounters.Add();//FS, O, G
            //Minichibis
            Hawthorne.MinichibisEncounters.Add();//G
            //Taco
            Hawthorne.CNSEncountersTaco.Add();//FS, O
            Hawthorne.FalseTruthEncountersTaco.Add();//O
            Hawthorne.PixelEncountersTaco.Add();//FS
            Hawthorne.AngelEncountersTaco.Add();//G
            Hawthorne.SatyrEncountersTaco.Add();//G
            Hawthorne.UnMungEncountersTaco.Add();//FS
            Hawthorne.SomethingEncountersTaco.Add();//O
            Hawthorne.CrowEncountersTaco.Add();//O
            Hawthorne.FlowerEncountersTaco.Add();//FS
            Hawthorne.DontTouchMeEncountersTaco.Add();//O
            //ZLD1
            Hawthorne.ZLD1_Encounters.Add();//FS, O
            //Childeater
            Hawthorne.WhimsicalEncounters.Add();//FS, O
            //TairPeepTaco
            Hawthorne.CNSEncountersBoth.Add();//FS
            Hawthorne.FalseTruthEncountersBoth.Add();//O
            Hawthorne.PixelEncountersBoth.Add();//FS
            Hawthorne.AngelEncountersBoth.Add();//G
            Hawthorne.SatyrEncountersBoth.Add();//G
            Hawthorne.UnMungEncountersBoth.Add();//?
            Hawthorne.SomethingEncountersBoth.Add();//O
            Hawthorne.CrowEncountersBoth.Add();//O
            Hawthorne.FlowerEncountersBoth.Add();//FS
            Hawthorne.DontTouchMeEncountersBoth.Add();//?
            //TairPeepZLD1
            Hawthorne.ZLD1TairEncounters.Add();//FS, O
        }

        public static void Start(Action<MainMenuController> orig, MainMenuController self)
        {
            LetsYouIgnoreMissingEnemiesHook.FinishDisablingEnemies();
            orig(self);
            if (Crossed) return;
            GroupFour.AddEncounters();
            GroupFour.ModifyEncounters();
            Crossover();
            GroupFour.ModifyMods();
            FindMH();
            Updater.Update();
        }

        public static void FindMH()
        {
            if (!DoDebugs.MiscInfo) return;
            EnemySO osman = LoadedAssetsHandler.GetEnemy("OsmanSinnoks_BOSS");
            foreach (BasePassiveAbilitySO passive in osman.passiveAbilities)
            {
                Debug.Log(passive);
                if (passive is ExtraAttackPassiveAbility extra)
                {
                    AbilitySO ability = extra._extraAbility.ability;
                    Debug.Log("ability: " + ability._abilityName);
                    foreach (EffectInfo effect in ability.effects)
                    {
                        Debug.Log(effect.effect);
                    }
                }
            }
            AttackVisualsSO MH = ((LoadedAssetsHandler.GetEnemy("OsmanSinnoks_BOSS").passiveAbilities[0] as ExtraAttackPassiveAbility)._extraAbility.ability.effects[0].effect as AnimationVisualsIfUnitEffect)._visuals;
            return;
            foreach (EnemyAbilityInfo abili in osman.abilities)
            {
                AbilitySO ability = abili.ability;
                Debug.Log("ability: " + ability._abilityName);
                foreach (EffectInfo effect in ability.effects)
                {
                    Debug.Log(effect.effect);
                }
                Debug.Log("--------------------");
            }
        }
    }


    public class Pale_StatusEffect : IStatusEffect, ITriggerEffect<IStatusEffector>
    {
        public int StatusContent => this.Amount;

        public int Restrictor { get; set; }

        public bool CanBeRemoved => this.Restrictor <= 0;

        public bool IsPositive => false;

        public string DisplayText
        {
            get
            {
                string displayText = "";
                if (this.Amount > 0)
                    displayText += this.Amount.ToString();
                if (this.Restrictor > 0)
                    displayText = displayText + "(" + this.Restrictor.ToString() + ")";
                return displayText;
            }
        }

        public int Amount { get; set; }

        public StatusEffectType EffectType => (StatusEffectType)888666;

        public StatusEffectInfoSO EffectInfo { get; set; }

        public void SetEffectInformation(StatusEffectInfoSO effectInfo)
        {
            this.EffectInfo = effectInfo;
        }



        public bool CanReduceDuration
        {
            get
            {
                BooleanReference booleanReference = new BooleanReference(true);
                CombatManager.Instance.ProcessImmediateAction(new CheckHasStatusFieldReductionBlockIAction(booleanReference), false);
                return !booleanReference.value;
            }
        }

        public Pale_StatusEffect(int amount, int restrictors = 0)
        {
            this.Amount = amount;
            this.Restrictor = restrictors;
        }

        public bool AddContent(IStatusEffect content)
        {
            this.Amount += content.StatusContent;
            this.Restrictor += content.Restrictor;
            return true;
        }

        public bool TryAddContent(int amount)
        {
            if (this.Amount <= 0)
                return false;
            this.Amount += amount;
            return true;
        }

        public int JustRemoveAllContent()
        {
            int amount = this.Amount;
            this.Amount = 0;
            return amount;
        }

        public void OnTriggerAttached(IStatusEffector caller)
        {
            CombatManager.Instance.AddObserver(new Action<object, object>(this.OnStatusTriggered), TriggerCalls.OnBeingDamaged.ToString(), caller);
            //CombatManager.Instance.AddObserver(new Action<object, object>(this.OnTurnEnd), TriggerCalls.OnTurnFinished.ToString(), caller);
        }

        public void OnTriggerDettached(IStatusEffector caller)
        {
            CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnStatusTriggered), TriggerCalls.OnBeingDamaged.ToString(), caller);
            //CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnTurnEnd), TriggerCalls.OnTurnFinished.ToString(), caller);
        }

        public void OnSubActionTrigger(object sender, object args, bool stateCheck)
        {

        }

        public void OnStatusTriggered(object sender, object args)
        {

            if (args is DamageReceivedValueChangeException hitBy && hitBy.directDamage == false)
            {
                if (sender is IUnit unit)
                {
                    if (hitBy.damageType == (DamageType)888666)
                    {
                        hitBy.AddModifier(new ImmZeroMod());
                        hitBy.AddModifier((IntValueModifier)new RemainSameTrigger(hitBy.amount));

                        RemoveStatusEffectEffect removeSelf = ScriptableObject.CreateInstance<RemoveStatusEffectEffect>();
                        removeSelf._statusToRemove = (StatusEffectType)888666;
                        Effect removeSelfEffect = new Effect(removeSelf, 1, null, Slots.Self);
                        CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { removeSelfEffect }), unit));
                        return;
                    }



                    int maxHP = unit.MaximumHealth;
                    int currentHP = unit.CurrentHealth;
                    decimal gapMax = (decimal)maxHP;
                    int amount = this.Amount;
                    decimal gapThis = (decimal)amount;
                    gapMax *= gapThis;
                    gapMax /= 100;
                    decimal gapCeiling = Math.Ceiling(gapMax);
                    int hitting = (int)gapCeiling;
                    int newHP = currentHP - hitting;
                    IStatusEffector effector = sender as IStatusEffector;
                    if (unit is CharacterCombat)
                        hitBy.AddModifier((IntValueModifier)new PaleTrigger(newHP, this, effector, this.Amount));
                    else
                    {
                        Effect soulHit = new Effect(ScriptableObject.CreateInstance<PaleHarmEffect>(), this.Amount, new IntentType?(), Slots.Self);
                        CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { soulHit }), unit));
                    }

                }
            }

            //}
        }

        public void OnTurnEnd(object sender, object args)
        {
            this.ReduceDuration(sender as IStatusEffector);
        }

        public void ReduceDuration(IStatusEffector effector)
        {
            if (!this.CanReduceDuration)
            {
                return;
            }
            int runningP = UnityEngine.Random.Range(0, 100);
            if (runningP > 50)
            {
                return;
            }
            int duration = this.Amount;
            this.Amount = Mathf.Max(0, this.Amount - 1);
            if (!this.TryRemoveStatusEffect(effector) && duration != this.Amount)
            {
                effector.StatusEffectValuesChanged(this.EffectType, this.Amount - duration);
                this.ReduceDurationAgain(effector);
            }
        }

        public void ReduceDurationAgain(IStatusEffector effector)
        {
            if (!this.CanReduceDuration)
            {
                return;
            }
            int runningP = UnityEngine.Random.Range(0, 100);
            if (runningP > 33)
            {
                return;
            }
            int duration = this.Amount;
            this.Amount = Mathf.Max(0, this.Amount - 1);
            if (!this.TryRemoveStatusEffect(effector) && duration != this.Amount)
            {
                effector.StatusEffectValuesChanged(this.EffectType, this.Amount - duration);
                this.ReduceDurationAgain(effector);
            }
        }

        public void IncreaseDuration(IStatusEffector effector, int amount)
        {

        }

        public void DettachRestrictor(IStatusEffector effector)
        {
            --this.Restrictor;
            if (this.TryRemoveStatusEffect(effector))
                return;
            effector.StatusEffectValuesChanged(this.EffectType, 0);
        }

        public bool TryRemoveStatusEffect(IStatusEffector effector)
        {
            if (this.Amount > 0 || !this.CanBeRemoved)
                return false;
            effector.RemoveStatusEffect(this.EffectType);
            return true;
        }


    }
    public class PaleTrigger : IntValueModifier
    {
        public readonly int newHP;
        public readonly Pale_StatusEffect paleSE;
        public readonly IStatusEffector effector;
        public readonly int amount;

        public PaleTrigger(
            int newHP,
            Pale_StatusEffect paleSE,
            IStatusEffector effector,
            int amount)
            : base(888)
        {
            this.newHP = newHP;
            this.paleSE = paleSE;
            this.effector = effector;
            this.amount = amount;
        }

        public override int Modify(int value)
        {
            if (value > 0 && this.effector is IUnit unit)
            {
                Effect soulHit = new Effect(ScriptableObject.CreateInstance<PaleHarmEffect>(), this.amount, new IntentType?(), Slots.Self);
                CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { soulHit }), unit));
            }
            return value;
        }
    }
    public class RemainSameTrigger : IntValueModifier
    {
        public readonly int amount;

        public RemainSameTrigger(
            int amount)
            : base(1000)
        {
            this.amount = amount;
        }

        public override int Modify(int value)
        {
            return amount;
        }
    }
    public class ImmZeroMod : IntValueModifier
    {
        public readonly int amount;

        public ImmZeroMod()
            : base(5)
        {

        }

        public override int Modify(int value)
        {
            return 0;
        }
    }
    public class ApplyPaleEffect : EffectSO
    {
        [SerializeField]
        public bool _justOneTarget;
        [SerializeField]
        public bool _randomBetweenPrevious;

        public override bool PerformEffect(
            CombatStats stats,
            IUnit caster,
            TargetSlotInfo[] targets,
            bool areTargetSlots,
            int entryVariable,
            out int exitAmount)
        {
            exitAmount = 0;
            if (entryVariable <= 0)
                return false;

            StatusEffectInfoSO effectInfo;
            stats.statusEffectDataBase.TryGetValue((StatusEffectType)888666, out effectInfo);




            for (int index = 0; index < targets.Length; ++index)
            {
                if (targets[index].HasUnit)
                {
                    int amount = this._randomBetweenPrevious ? UnityEngine.Random.Range(this.PreviousExitValue, entryVariable + 1) : entryVariable;
                    IStatusEffect statusEffect = new Pale_StatusEffect(amount);

                    statusEffect.SetEffectInformation(effectInfo);
                    IStatusEffector effector = targets[index].Unit as IStatusEffector;
                    bool hasItAlready = false;
                    int thisIndex = 999;
                    for (int i = 0; i < effector.StatusEffects.Count; i++)
                    {
                        if (effector.StatusEffects[i].EffectType == statusEffect.EffectType)
                        {
                            thisIndex = i;
                            hasItAlready = true;
                        }
                    }
                    if (hasItAlready == true)
                    {
                        ConstructorInfo[] constructors = effector.StatusEffects[thisIndex].GetType().GetConstructors();
                        foreach (ConstructorInfo constructor in constructors)
                        {
                            if (constructor.GetParameters().Length == 2)
                            {
                                statusEffect = (IStatusEffect)Activator.CreateInstance(effector.StatusEffects[thisIndex].GetType(), amount, 0);
                            }
                        }
                    }

                    statusEffect.SetEffectInformation(effectInfo);
                    if (targets[index].Unit.ApplyStatusEffect((IStatusEffect)statusEffect, amount))
                        ++exitAmount;
                }
            }

            return exitAmount > 0;
        }
    }
    public class PaleHarmEffect : EffectSO
    {
        [SerializeField]
        public bool _justOneTarget;
        [SerializeField]
        public bool _randomBetweenPrevious;

        public override bool PerformEffect(
            CombatStats stats,
            IUnit caster,
            TargetSlotInfo[] targets,
            bool areTargetSlots,
            int entryVariable,
            out int exitAmount)
        {
            exitAmount = 0;

            int maxHP = caster.MaximumHealth;
            int currentHP = caster.CurrentHealth;
            decimal gapMax = (decimal)maxHP;
            int amount = entryVariable;
            decimal gapThis = (decimal)amount;
            gapMax *= gapThis;
            gapMax /= 100;
            decimal gapCeiling = Math.Ceiling(gapMax);
            decimal gapFloor = Math.Floor(gapMax);
            int hitMax = (int)gapCeiling;
            int hitMin = (int)gapFloor;
            int hitting = UnityEngine.Random.Range(hitMin, hitMax + 1);
            exitAmount += hitting;
            int newHP = currentHP - hitting;
            if (hitting > currentHP)
            {
                hitting = currentHP;
            }
            caster.Damage(hitting, null, DeathType.Basic, -1, false, false, true, (DamageType)888666);


            return exitAmount > 0;
        }
    }
    public class PlayStatusEffectPopupUIAction : CombatAction
    {
        public int _id;

        public bool _isUnitCharacter;

        public int _amount;
        public StatusEffectInfoSO _status;

        public StatusFieldEffectPopUpType _popUpType;

        public PlayStatusEffectPopupUIAction(int id, bool isUnitCharacter, int amount, StatusEffectInfoSO status, StatusFieldEffectPopUpType popUpType)
        {
            _id = id;
            _isUnitCharacter = isUnitCharacter;
            _amount = amount;
            _status = status;
            _popUpType = popUpType;
        }

        public override IEnumerator Execute(CombatStats stats)
        {
            CharacterCombatUIInfo character;
            EnemyCombatUIInfo enemy;
            Vector3 vector;
            if (_isUnitCharacter)
            {
                stats.combatUI._charactersInCombat.TryGetValue(_id, out character);
                vector = stats.combatUI._characterZone.GetCharacterPosition(character.FieldID);
                stats.combatUI.PlaySoundOnPosition(_status.UpdatedSoundEvent, vector);
                int ppu = 32;
                Sprite sprite = Sprite.Create(_status.icon.texture, new Rect(0, 0, _status.icon.texture.width, _status.icon.texture.height), new Vector2(0.5f, 0.5f), ppu);
                yield return stats.combatUI._popUpHandler3D.StartStatusFieldShowcase(false, vector, _popUpType, _amount, sprite);
            }
            else
            {
                stats.combatUI._enemiesInCombat.TryGetValue(_id, out enemy);
                vector = stats.combatUI._enemyZone.GetEnemyPosition(enemy.FieldID);
                stats.combatUI.PlaySoundOnPosition(_status.UpdatedSoundEvent, vector);
                int ppu = 32;
                Sprite sprite = Sprite.Create(_status.icon.texture, new Rect(0, 0, _status.icon.texture.width, _status.icon.texture.height), new Vector2(0.5f, 0.5f), ppu);
                yield return stats.combatUI._popUpHandler3D.StartStatusFieldShowcase(true, vector, _popUpType, _amount, sprite);
            }
        }
    }

    public static class Check
    {
        public static bool EnemyExist(string name)
        {
            if (!LoadedAssetsHandler.LoadedEnemies.Keys.Contains(name) && LoadedAssetsHandler.LoadEnemy(name) == null) { if (DoDebugs.EnemyNull) Debug.LogWarning("Enemy: " + name + " is null"); return false; }
            return LoadedAssetsHandler.GetEnemy(name) != null;
        }
        public static bool BundleExist(string name)
        {
            if (!LoadedAssetsHandler.LoadedEnemyBundles.Keys.Contains(name) && LoadedAssetsHandler.LoadEnemyBundle(name) == null) { if (DoDebugs.EnemyNull) Debug.LogWarning("Bundle: " + name + " is null"); return false; }
            return LoadedAssetsHandler.GetEnemyBundle(name) != null;
        }
        public static bool BundleRandom(string name, bool DoDebug = true)
        {
            if (!BundleExist(name)) return false;
            if (!(LoadedAssetsHandler.GetEnemyBundle(name) is RandomEnemyBundleSO) && DoDebug) if (DoDebugs.EnemyNull) Debug.LogWarning("Bundle: " + name + " is not random, checked for random");
            return LoadedAssetsHandler.GetEnemyBundle(name) is RandomEnemyBundleSO;
        }
        public static bool BundleStatic(string name)
        {
            if (!BundleExist(name)) return false;
            if (BundleRandom(name, false)) if (DoDebugs.EnemyNull) Debug.LogWarning("Bundle: " + name + "is random, checked for static");
            return !BundleRandom(name, false);
        }
        public static bool MultiENExistInternal(string[] names)
        {
            foreach (string name in names)
            {
                if (!EnemyExist(name)) return false;
            }
            return true;
        }
        public static bool MultiENExist(string name1 = "", string name2 = "", string name3 = "", string name4 = "", string name5 = "", string name6 = "", string name7 = "", string name8 = "", string name9 = "", string name10 = "")
        {
            List<string> ret = new List<string>();
            if (name1 != "") ret.Add(name1);
            if (name2 != "") ret.Add(name2);
            if (name3 != "") ret.Add(name3);
            if (name4 != "") ret.Add(name4);
            if (name5 != "") ret.Add(name5);
            if (name6 != "") ret.Add(name6);
            if (name7 != "") ret.Add(name7);
            if (name8 != "") ret.Add(name8);
            if (name9 != "") ret.Add(name9);
            if (name10 != "") ret.Add(name10);
            return MultiENExistInternal(ret.ToArray());
        }

        public static bool Gizos => MultiENExist("Gizo_EN", "NakedGizo_EN");
        public static bool Chap => EnemyExist("Chapman_EN");
        public static string[] Support => new string[] { "LostSheep_EN", "Enigma_EN", "DeadPixel_EN" };
        public static string[] NoPixel => new string[] { "LostSheep_EN", "Enigma_EN" };
        public static bool Supporting => MultiENExistInternal(Support);
        public static string[] Colophon => new string[] { "DefeatedColophon_EN", "ComposedColophon_EN", "MaladjustedColophon_EN", "DelightedColophon_EN" };
        public static bool Colophoning => MultiENExistInternal(Colophon);
        public static string[] Spligs => EnemyExist("RougeWailingSplugling_EN") ? new string[] { "RougeWailingSplugling_EN", "RougeBellowingSplugling_EN", "RougeFesteringSplugling_EN", "RougeWeepingSplugling_EN" } : new string[] { "RogueWailingSplugling_EN", "RogueBellowingSplugling_EN", "RogueFesteringSplugling_EN", "RogueWeepingSplugling_EN" };
        public static bool Spligging => MultiENExistInternal(Spligs);
        public static string[] Flowers => new string[] { "YellowFlower_EN", "PurpleFlower_EN", "RedFlower_EN", "BlueFlower_EN", "GreyFlower_EN" };
        public static bool Flowering => MultiENExistInternal(Flowers);
        public static string[] BowGuts => new string[] { "BondedJumbleGuts_EN", "AnnoyingJumbleGuts_EN", "ParasiticJumbleGuts_EN", "MalignantJumbleGuts_EN", "ArtisticJumbleGuts_EN", "WaxingJumbleGuts_EN" };
        public static bool BowGutsing => MultiENExistInternal(BowGuts);
        public static string[] BowSpogs => new string[] { "AmphibiousSpoggle_EN", "IchtyosatedSpoggle_EN", "EclipsedSpoggle_EN", "FoamingSpoggle_EN", "NecromanticSpoggle_EN", "PoolingSpoggle_EN" };
        public static bool BowSpogging => MultiENExistInternal(BowSpogs);
        public static bool GreyScale => MultiENExist("Illusion_EN", "FakeAngel_EN");
        public static bool BirdScale => MultiENExist("LittleBeak_EN", "Warbird_EN", "TheCrow_EN", "Hunter_EN", "Firebird_EN");

        public static string RandomOrph
        {
            get
            {
                List<string> list = new List<string>();
                list.Add("MusicMan_EN");
                list.Add("Scrungie_EN");
                if (Gizos && UnityEngine.Random.Range(0, 100) < 50) list.Add("Gizo_EN");
                if (Chap) list.Add("Chapman_EN");
                if (UnityEngine.Random.Range(0, 100) < 50 && EnemyExist("Lyssa_EN")) list.Add("Lyssa_EN");
                else if (EnemyExist("OsseousClad_EN")) list.Add("OsseousClad_EN");
                if (UnityEngine.Random.Range(0, 100) < 50 && EnemyExist("Something_EN")) list.Add("Something_EN");
                if (UnityEngine.Random.Range(0, 100) < 50 && EnemyExist("LittleBeak_EN")) list.Add("LittleBeak_EN");
                if (UnityEngine.Random.Range(0, 100) < 50 && EnemyExist("FesteringMusicMan_EN")) list.Add("FesteringMusicMan_EN");
                else if (UnityEngine.Random.Range(0, 100) < 50 && EnemyExist("Jansuli_EN")) list.Add("Jansuli_EN");
                return list[UnityEngine.Random.Range(0, list.Count)];
            }
        }
        public static string RandomColor(int zone, bool killable = false)
        {
            List<string> list = new List<string>();
            list.Add("JumbleGuts_Clotted_EN");
            list.Add("JumbleGuts_Waning_EN");
            list.Add("Spoggle_Spitfire_EN");
            list.Add("Spoggle_Ruminating_EN");
            if (Spligging) foreach (string name in Spligs) list.Add(name);
            if (BowGutsing) for (int i = 0; i < 3; i++) list.Add(BowGuts[i]);
            if (BowSpogging) for (int i = 0; i < 3; i++) list.Add(BowSpogs[i]);
            if (Colophoning) { list.Add(Colophon[0]); list.Add(Colophon[1]); };
            if (zone == 1)
            {
                list.Add("JumbleGuts_Hollowing_EN");
                list.Add("JumbleGuts_Flummoxing_EN");
                list.Add("Spoggle_Writhing_EN");
                list.Add("Spoggle_Ruminating_EN");
                if (BowGutsing) for (int i = 3; i < 6; i++) list.Add(BowGuts[i]);
                if (BowSpogging) for (int i = 3; i < 6; i++) list.Add(BowSpogs[i]);
                if (Colophoning) { list.Add(Colophon[2]); list.Add(Colophon[3]); };
                if (UnityEngine.Random.Range(0, 100) < 50 && EnemyExist("DesiccatingJumbleguts_EN")) list.Add("DesiccatingJumbleguts_EN");
                if (UnityEngine.Random.Range(0, 100) < 50 && EnemyExist("PerforatedSpoggle_EN")) list.Add("PerforatedSpoggle_EN");
                if (UnityEngine.Random.Range(0, 100) < 10 && EnemyExist("FamiliarSpoggle_EN")) list.Add("FamiliarSpoggle_EN");
                if (UnityEngine.Random.Range(0, 100) < 20 && EnemyExist("RusticJumbleguts_EN")) list.Add("RusticJumbleguts_EN");
                if (Flowering) { list.Add("YellowFlower_EN"); list.Add("PurpleFlower_EN"); };
            }
            if (zone == 2)
            {
                list.Clear();
                list = new List<string>(Flowers);
                if (EnemyExist("RusticJumbleguts_EN")) list.Add("RusticJumbleguts_EN");
                if (!killable && EnemyExist("MortalSpoggle_EN")) list.Add("MortalSpoggle_EN");
                if (list.Count <= 0 || UnityEngine.Random.Range(0, 100) == 0) list.Add("JumbleGuts_Flummoxing_EN");
            }
            return list[UnityEngine.Random.Range(0, list.Count)];
        }
        public static string BaseColor(bool jumble, bool harder = true, string exc = "")
        {
            List<string> list = new List<string>();
            if (jumble)
            {
                list.Add("JumbleGuts_Clotted_EN");
                list.Add("JumbleGuts_Waning_EN");
                if (harder)
                {
                    list.Add("JumbleGuts_Hollowing_EN");
                    list.Add("JumbleGuts_Flummoxing_EN");
                }
            }
            else
            {
                list.Add("Spoggle_Spitfire_EN");
                list.Add("Spoggle_Ruminating_EN");
                if (harder)
                {
                    list.Add("Spoggle_Writhing_EN");
                    list.Add("Spoggle_Resonant_EN");
                }
            }
            if (exc != "" && list.ToArray().Exclude(exc).Length > 0) return list.ToArray().Exclude(exc).GetRandom();
            return list.ToArray().GetRandom();
        }
        public static string RainBaseColor(bool jumble, bool harder = true, bool gray = true, string exc = "")
        {
            int gap = 6; if (!harder) gap = 3;
            List<string> list = new List<string>();
            if (jumble)
            {
                if (!BowGutsing) return BaseColor(jumble, harder);
                list = new List<string>(BowGuts.UpTo(gap));
                list.Add("JumbleGuts_Clotted_EN");
                list.Add("JumbleGuts_Waning_EN");
                if (harder)
                {
                    list.Add("JumbleGuts_Hollowing_EN");
                    list.Add("JumbleGuts_Flummoxing_EN");
                    if (gray && EnemyExist("DesiccatingJumbleguts_EN")) list.Add("DesiccatingJumbleguts_EN");
                }
            }
            else
            {
                if (!BowSpogging) return BaseColor(jumble, harder);
                list = new List<string>(BowSpogs.UpTo(gap));
                list.Add("Spoggle_Spitfire_EN");
                list.Add("Spoggle_Ruminating_EN");
                if (harder)
                {
                    list.Add("Spoggle_Writhing_EN");
                    list.Add("Spoggle_Resonant_EN");
                    if (gray && EnemyExist("PerforatedSpoggle_EN")) list.Add("PerforatedSpoggle_EN");
                    if (Rando(20) && EnemyExist("FamiliarSpoggle_EN")) list.Add("FamiliarSpoggle_EN");
                }
            }
            if (exc != "" && list.ToArray().Exclude(exc).Length > 0) return list.ToArray().Exclude(exc).GetRandom();
            return list.ToArray().GetRandom();
        }
        public static string RainBaseWeighted(bool jumble, bool harder = true, bool gray = true, string exc = "") => SaltEnemies.rando.CheckIfWithinRangeRandom(50) ? BaseColor(jumble, harder, exc) : RainBaseColor(jumble, harder, gray, exc);
        public static string RandomRedColor(bool jumble, bool totalRandom = false, bool harder = true, bool harderOnly = false, string exc = "")
        {
            int gap = 6; if (!harder) gap = 3;
            List<string> list = new List<string>();
            if (jumble || totalRandom)
            {
                if (!harderOnly) list.Add("JumbleGuts_Clotted_EN");
                if (BowGutsing)
                {
                    if (!harderOnly) list.Add("BondedJumbleGuts_EN");
                    if (harder)
                    {
                        list.Add("MalignantJumbleGuts_EN");
                        list.Add("WaxingJumbleGuts_EN");
                    }
                }
            }
            if (!jumble || totalRandom)
            {
                if (BowSpogging && !harderOnly) list.Add("AmphibiousSpoggle_EN");
                if (harder)
                {
                    list.Add("Spoggle_Writhing_EN");
                    if (BowSpogging)
                    {
                        list.Add("FoamingSpoggle_EN");
                        list.Add("NecromanticSpoggle_EN");
                    }
                }
            }
            if (totalRandom)
            {
                if (!harderOnly && Spligging)
                {
                    if (EnemyExist("RougeWailingSplugling_EN")) 
                    {
                        list.Add("RougeWailingSplugling_EN");
                        list.Add("RougeBellowingSplugling_EN");
                    }
                    else
                    {
                        list.Add("RogueWailingSplugling_EN");
                        list.Add("RogueBellowingSplugling_EN");
                    }
                }
                if (Colophoning && !harderOnly) list.Add("DefeatedColophon_EN");
            }
            if (list.Count <= 0)
            {
                if (DoDebugs.GenInfo) Debug.LogError("random red color has NOTHING IN IT you FUCKING SUCK you PIECE OF SHIT");
                list.Add("Enigma_EN");
                list.Add("FakeAngel_EN");
            }
            if (exc != "" && list.ToArray().Exclude(exc).Length > 0) return list.ToArray().Exclude(exc).GetRandom();
            return list.ToArray().GetRandom();
        }
        public static string RandomSupport(int zone, bool red = false, bool mustSmall = true, bool movable = false, bool killable = false)
        {
            List<string> list = new List<string>();
            if (zone == 0)
            {
                list.Add("Mung_EN");
                if (!red) list.Add("Flarblet_EN");
                if (!red && EnemyExist("Flarbleft_EN")) list.Add("Flarbleft_EN");
                if (EnemyExist("Minana_EN")) list.Add("Minana_EN");
                if (!red && EnemyExist("LipBug_EN")) list.Add("LipBug_EN");
                if (Supporting) list.Add("LostSheep_EN");
                if (!red && !movable && UnityEngine.Random.Range(0, 100) < 10 && EnemyExist("Boulder_EN")) list.Add("Boulder_EN");
                if (!red && UnityEngine.Random.Range(0, 100) < 15 && EnemyExist("Skyloft_EN")) list.Add("Skyloft_EN");
                if (!mustSmall && UnityEngine.Random.Range(0, 100) < 10) list.Add("Wringle_EN");
                if (!mustSmall && !red && !movable && UnityEngine.Random.Range(0, 100) < 35 && EnemyExist("Monck_EN")) list.Add("Monck_EN");
                if (!mustSmall && !red && UnityEngine.Random.Range(0, 100) < 50 && EnemyExist("Windle1_EN")) list.Add("Windle1_EN");
            }
            if (zone == 1)
            {
                list.Add("SingingStone_EN");
                if (!red) list.Add("SilverSuckle_EN");
                if (Gizos) list.Add("NakedGizo_EN");
                if (Supporting) { list.Add("LostSheep_EN"); if (UnityEngine.Random.Range(0, 100) < 33) list.Add("Enigma_EN"); };
                if (EnemyExist("Pacemaker_EN")) list.Add("Pacemaker_EN");
                if (!red && UnityEngine.Random.Range(0, 100) < 15 && EnemyExist("Skyloft_EN")) list.Add("Skyloft_EN");
                if (!mustSmall && EnemyExist("Seraphim_EN") && UnityEngine.Random.Range(0, 100) < 50) list.Add("Seraphim_EN");
                if (!red && !mustSmall && UnityEngine.Random.Range(0, 100) < 33 && EnemyExist("WindSong_EN")) list.Add("WindSong_EN");
                if (!mustSmall && UnityEngine.Random.Range(0, 100) < 25 && EnemyExist("LivingSolvent_EN")) list.Add("LivingSolvent_EN");
                if (!red && !mustSmall && UnityEngine.Random.Range(0, 100) < 33 && EnemyExist("Sigil_EN")) list.Add("Sigil_EN");
                if (!mustSmall && UnityEngine.Random.Range(0, 100) < 25 && EnemyExist("Grandfather_EN")) list.Add("Grandfather_EN");
                if (UnityEngine.Random.Range(0, 100) < 40 && EnemyExist("EyePalm_EN")) list.Add("EyePalm_EN");
                if (!red && UnityEngine.Random.Range(0, 100) < 15 && EnemyExist("Merced_EN")) list.Add("Merced_EN");
                if (!mustSmall && UnityEngine.Random.Range(0, 100) < 15 && EnemyExist("Butterfly_EN")) list.Add("Butterfly_EN");
                if (!mustSmall && UnityEngine.Random.Range(0, 100) < 25 && EnemyExist("Shua_EN")) list.Add("Shua_EN");
                if (!red && !mustSmall && UnityEngine.Random.Range(0, 100) < 15 && EnemyExist("Nameless_EN")) list.Add("Nameless_EN");
                if (!red && !mustSmall && EnemyExist("Romantic_EN")) list.Add("Romantic_EN");
                if (!mustSmall && UnityEngine.Random.Range(0, 100) < 40 && EnemyExist("LittleBeak_EN")) list.Add("LittleBeak_EN");
                if (!red && !mustSmall && UnityEngine.Random.Range(0, 100) < 33 && EnemyExist("Warbird_EN")) list.Add("Warbird_EN");
                if (!mustSmall && !red && UnityEngine.Random.Range(0, 100) < 5 && EnemyExist("Windle2_EN")) list.Add("Windle2_EN");
                if (!mustSmall && !red && UnityEngine.Random.Range(0, 100) < 20 && EnemyExist("Clione_EN")) list.Add("Clione_EN");
                if (!red && !killable && UnityEngine.Random.Range(0, 100) < 20 && EnemyExist("Children6_EN")) list.Add("Children6_EN");
            }
            if (zone == 2)
            {
                list.Add("NextOfKin_EN");
                list.Add("ShiveringHomunculus_EN");
                if (Supporting) { list.Add("LostSheep_EN"); if (UnityEngine.Random.Range(0, 100) < 66) list.Add("Enigma_EN"); };
                if (!red && EnemyExist("TitteringPeon_EN")) list.Add("TitteringPeon_EN");
                if (EnemyExist("Unterling_EN")) list.Add("Unterling_EN");
                if (!red && !killable && EnemyExist("Children6_EN")) list.Add("Children6_EN");
                if (!mustSmall && EnemyExist("ScreamingHomunculus_EN")) list.Add("ScreamingHomunculus_EN");
                if (!killable && !red && EnemyExist("LittleAngel_EN")) list.Add("LittleAngel_EN");
                if (!red && UnityEngine.Random.Range(0, 100) < 5 && EnemyExist("StarGazer_EN")) list.Add("StarGazer_EN");
                if (!red && !mustSmall && UnityEngine.Random.Range(0, 100) < 65 && EnemyExist("WindSong_EN")) list.Add("WindSong_EN");
                if (!mustSmall && UnityEngine.Random.Range(0, 100) < 45 && EnemyExist("LivingSolvent_EN")) list.Add("LivingSolvent_EN");
                if (!red && !mustSmall && UnityEngine.Random.Range(0, 100) < 65 && EnemyExist("Sigil_EN")) list.Add("Sigil_EN");
                if (!mustSmall && UnityEngine.Random.Range(0, 100) < 33 && EnemyExist("Grandfather_EN")) list.Add("Grandfather_EN");
                if (!red && !mustSmall && UnityEngine.Random.Range(0, 100) < 50 && EnemyExist("MiniReaper_EN")) list.Add("MiniReaper_EN");
                if (EnemyExist("EyePalm_EN")) list.Add("EyePalm_EN");
                if (!red && UnityEngine.Random.Range(0, 100) < 25 && EnemyExist("Merced_EN")) list.Add("Merced_EN");
                if (UnityEngine.Random.Range(0, 100) < 50 && EnemyExist("Butterfly_EN")) list.Add("Butterfly_EN");
                if (!mustSmall && UnityEngine.Random.Range(0, 100) < 65 && EnemyExist("Shua_EN")) list.Add("Shua_EN");
                if (!red && UnityEngine.Random.Range(0, 100) < 25 && EnemyExist("Nameless_EN")) list.Add("Nameless_EN");
                if (!red && !mustSmall && UnityEngine.Random.Range(0, 100) < 20 && EnemyExist("GlassFigurine_EN")) list.Add("GlassFigurine_EN");
                if (EnemyExist("InfernalDrummer_EN")) list.Add("InfernalDrummer_EN");
                if (!red && EnemyExist("EggKeeper_EN")) list.Add("EggKeeper_EN");
                if (!red && EnemyExist("Damocles_EN")) list.Add("Damocles_EN");
                if (!red && EnemyExist("Romantic_EN")) list.Add("Romantic_EN");
                if (!red && !mustSmall && UnityEngine.Random.Range(0, 100) < 65 && EnemyExist("Evangelists_EN")) list.Add("Evangelists_EN");
                if (!mustSmall && !red && UnityEngine.Random.Range(0, 100) < 75 && EnemyExist("Windle3_EN")) list.Add("Windle3_EN");
                if (!red && EnemyExist("BlackStar_EN")) list.Add("BlackStar_EN");
                if (!mustSmall && !red && UnityEngine.Random.Range(0, 100) < 50 && EnemyExist("Indicator_EN")) list.Add("Indicator_EN");
                if (!mustSmall && !red && UnityEngine.Random.Range(0, 100) < 40 && EnemyExist("Clione_EN")) list.Add("Clione_EN");
                if (!mustSmall && !red && UnityEngine.Random.Range(0, 100) < 50 && EnemyExist("YNL_EN")) list.Add("YNL_EN");
            }
            return list[UnityEngine.Random.Range(0, list.Count)];
        }
        public static string RandomShoreMidget(bool flarbOnly = true)
        {
            List<string> list = new List<string>();
            if (!flarbOnly && SaltEnemies.rando < 10) list.Add("Mung_EN");
            list.Add("Flarblet_EN");
            if (EnemyExist("Flarbleft_EN")) list.Add("Flarbleft_EN");
            if (!flarbOnly && EnemyExist("LipBug_EN")) list.Add("LipBug_EN");
            return list[UnityEngine.Random.Range(0, list.Count)];
        }

        public static FieldEnemy[] RandomizeShore(string who, Weight power, bool canLucky = true) => RandomEncounters.Shore.RandomizeShore(who, power, canLucky);
        public static string ShoreSlop(bool twin = false, bool red = false) => RandomEncounters.Shore.FarShoreSlop(twin, red);
        public static string GreyScaleSupport(bool harder = false)
        {
            List<string> list = new List<string>();
            if (EnemyExist("WindSong_EN")) for (int i = 0; i < 10; i++) list.Add("WindSong_EN");
            if (EnemyExist("LivingSolvent_EN")) for (int i = 0; i < 1; i++) list.Add("LivingSolvent_EN");
            if (EnemyExist("LivingSolvent_EN") && harder) for (int i = 0; i < 2; i++) list.Add("LivingSolvent_EN");
            if (EnemyExist("Windle2_EN") && !harder) for (int i = 0; i < 5; i++) list.Add("Windle2_EN");
            if (EnemyExist("Windle3_EN") && harder) for (int i = 0; i < 5; i++) list.Add("Windle3_EN");
            if (EnemyExist("Sigil_EN")) for (int i = 0; i < 5; i++) list.Add("Sigil_EN");
            if (harder && EnemyExist("ClockTower_EN")) for (int i = 0; i < 5; i++) list.Add("ClockTower_EN");
            if (harder && EnemyExist("StarGazer_EN")) for (int i = 0; i < 1; i++) list.Add("StarGazer_EN");
            if (EnemyExist("MechanicalLens_EN")) for (int i = 0; i < 1; i++) list.Add("MechanicalLens_EN");
            if (EnemyExist("MechanicalLens_EN") && harder) for (int i = 0; i < 4; i++) list.Add("MechanicalLens_EN");
            if (EnemyExist("Grandfather_EN")) for (int i = 0; i < 1; i++) list.Add("Grandfather_EN");
            if (EnemyExist("Grandfather_EN") && harder) for (int i = 0; i < 2; i++) list.Add("Grandfather_EN");
            if (EnemyExist("PurpleFlower_EN")) for (int i = 0; i < 4; i++) list.Add("PurpleFlower_EN");
            if (EnemyExist("YellowFlower_EN")) for (int i = 0; i < 4; i++) list.Add("YellowFlower_EN");
            if (harder && EnemyExist("RedFlower_EN")) for (int i = 0; i < 6; i++) list.Add("PurpleFlower_EN");
            if (harder && EnemyExist("BlueFlower_EN")) for (int i = 0; i < 6; i++) list.Add("YellowFlower_EN");
            for (int j = 0; j < 4; j++) if (!harder && EnemyExist(Colophon[j])) for (int i = 0; i < 2; i++) list.Add(Colophon[j]);
            if (EnemyExist("Skyloft_EN")) for (int i = 0; i < 3; i++) list.Add("Skyloft_EN");
            if (EnemyExist("Merced_EN")) for (int i = 0; i < 3; i++) list.Add("Merced_EN");
            if (harder && EnemyExist("Shua_EN")) for (int i = 0; i < 3; i++) list.Add("Shua_EN");
            if (harder && EnemyExist("Nameless_EN")) for (int i = 0; i < 1; i++) list.Add("Nameless_EN");
            if (harder && EnemyExist("GlassFigurine_EN")) for (int i = 0; i < 3; i++) list.Add("GlassFigurine_EN");
            if (!harder) for (int i = 0; i < 2; i++) list.Add("SilverSuckle_EN");
            if (EnemyExist("Enigma_EN")) for (int i = 0; i < 5; i++) list.Add("Enigma_EN");
            if (EnemyExist("Damocles_EN")) for (int i = 0; i < 3; i++) list.Add("Damocles_EN");
            if (EnemyExist("Romantic_EN")) for (int i = 0; i < 3; i++) list.Add("Romantic_EN");
            if (harder && EnemyExist("Romantic_EN")) for (int i = 0; i < 3; i++) list.Add("Romantic_EN");
            if (!harder && Colophoning) foreach (string enemy in Colophon) if (EnemyExist(enemy)) for (int i = 0; i < 2; i++) list.Add(enemy);
            if (!harder && BirdScale) list.Add("Warbird_EN");
            if (!harder && BirdScale && Half) list.Add("LittleBeak_EN");
            if (BirdScale) list.Add("TheCrow_EN");
            if (BirdScale) list.Add("Hunter_EN");
            if (harder && Third) list.Add("Firebird_EN");
            if (!harder && EnemyExist("FumeFactory_EN")) for (int i = 0; i < 5; i++) list.Add("FumeFactory_EN");
            if (harder && EnemyExist("Evangelists_EN")) for (int i = 0; i < 3; i++) list.Add("Evangelists_EN");
            if (harder && EnemyExist("BlackStar_EN")) for (int i = 0; i < 7; i++) list.Add("BlackStar_EN");
            if (harder && EnemyExist("Indicator_EN")) for (int i = 0; i < 5; i++) list.Add("Indicator_EN");
            if (EnemyExist("Clione_EN")) for (int i = 0; i < 7; i++) list.Add("Clione_EN");
            if (harder && EnemyExist("Children6_EN")) for (int i = 0; i < 3; i++) list.Add("Children6_EN");
            if (EnemyExist("Children6_EN")) for (int i = 0; i < 2; i++) list.Add("Children6_EN");
            if (harder && EnemyExist("MarbleMaw_EN")) for (int i = 0; i < 5; i++) list.Add("MarbleMaw_EN");
            if (harder && EnemyExist("YNL_EN")) for (int i = 0; i < 4; i++) list.Add("YNL_EN");
            return list.GetRandom();
        }
        public static string GreyScaleRedSource(bool harder = false)
        {
            List<string> ret = new List<string>();
            if (EnemyExist("FakeAngel_EN")) for (int i = 0; i < 50; i++) ret.Add("FakeAngel_EN");
            if (EnemyExist("LivingSolvent_EN")) for (int i = 0; i < 2; i++) ret.Add("LivingSolvent_EN");
            if (EnemyExist("Grandfather_EN")) for (int i = 0; i < 2; i++) ret.Add("Grandfather_EN");
            if (harder && EnemyExist("RedFlower_EN")) for (int i = 0; i < 5; i++) ret.Add("RedFlower_EN");
            if (EnemyExist("Butterfly_EN")) for (int i = 0; i < 1; i++) ret.Add("Butterfly_EN");
            if (harder && EnemyExist("Shua_EN")) for (int i = 0; i < 2; i++) ret.Add("Shua_EN");
            if (!harder && EnemyExist("Lyssa_EN")) for (int i = 0; i < 1; i++) ret.Add("Lyssa_EN");
            if (EnemyExist("Enigma_EN")) for (int i = 0; i < 1; i++) ret.Add("Enigma_EN");
            if (harder && EnemyExist("Enigma_EN")) for (int i = 0; i < 2; i++) ret.Add("Enigma_EN");
            if (EnemyExist("LostSheep_EN")) for (int i = 0; i < 1; i++) ret.Add("LostSheep_EN");
            if (!harder && Colophoning) for (int i = 0; i < 2; i++) ret.Add(Colophon[0]);
            return ret.GetRandom();
        }

        public static void CheckEncounters(this BrutalAPI.EnemyEncounter enc)
        {
            if (enc == null) { if (DoDebugs.EnemyNull) Debug.LogError("encounter is null"); return; }
            if (enc.variations == null) { if (DoDebugs.EnemyNull) Debug.LogError("encounter variations are null"); return; }
            for (int i = 0; i < enc.variations.Length; i++)
            {
                FieldEnemy[] variation = enc.variations[i];
                for (int j = 0; j < variation.Length; j++)
                {
                    FieldEnemy enemy = variation[j];
                    if (!EnemyExist(enemy.enemyName))
                    {
                        if (DoDebugs.EnemyNull) Debug.LogError("Missing enemy in " + enc.encounterName + " at variation: " + i + " at enemy: " + j);
                    }
                }
            }
        }
        public static void CheckEncounters(this List<RandomEnemyGroup> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                RandomEnemyGroup group = list[i];
                string Full = "Full group: ";
                bool missing = false;
                for (int j = 0; j < group.EnemyNames.Length; j++)
                {
                    string enemy = group.EnemyNames[j];
                    Full += enemy + " , ";
                    if (!EnemyExist(enemy))
                    {
                        if (DoDebugs.EnemyNull) Debug.LogError("Missing enemy in random group " + i + " in position " + j + " : " + enemy);
                        missing = true;
                    }
                }
                if (missing) if (DoDebugs.EnemyNull) Debug.LogError(Full);
            }
        }
        public static void CheckEncounters(this List<SpecificEnemyGroup> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                SpecificEnemyGroup group = list[i];
                string Full = "Full group: ";
                bool missing = false;
                for (int j = 0; j < group.EnemyGroup.Length; j++)
                {
                    SpecificEnemyInfo info = group.EnemyGroup[j];
                    string enemy = info.enemyName;
                    Full += enemy + " , ";
                    if (!EnemyExist(enemy))
                    {
                        if (DoDebugs.EnemyNull) Debug.LogError("Missing enemy in specific group " + i + " in position " + j + " : " + enemy + " at slot position: " + info.enemySlot);
                        missing = true;
                    }
                }
                if (missing) if (DoDebugs.EnemyNull) Debug.LogError(Full);
            }
        }

        public static bool Trolling(int num) => SaltEnemies.trolling == num;
        public static bool Silly(int num) => SaltEnemies.silly == num;
        public static bool Rando(int num) => SaltEnemies.rando == num;
        public static bool Fifth
        {
            get
            {
                int test = SaltEnemies.rando;
                if (test > 50) return SaltEnemies.rando.CheckIfWithinRangeRandom(20);
                else if (test > 25) return SaltEnemies.silly.CheckIfWithinRangeRandom(20);
                else return SaltEnemies.trolling.CheckIfWithinRangeRandom(20);
            }
        }
        public static bool Quarter
        {
            get
            {
                int test = SaltEnemies.rando;
                if (test > 50) return SaltEnemies.rando.CheckIfWithinRangeRandom(25);
                else if (test > 25) return SaltEnemies.silly.CheckIfWithinRangeRandom(25);
                else return SaltEnemies.trolling.CheckIfWithinRangeRandom(25);
            }
        }
        public static bool Third
        {
            get
            {
                int test = SaltEnemies.rando;
                if (test > 50) return SaltEnemies.rando.CheckIfWithinRangeRandom(33);
                else if (test > 25) return SaltEnemies.silly.CheckIfWithinRangeRandom(33);
                else return SaltEnemies.trolling.CheckIfWithinRangeRandom(33);
            }
        }
        public static bool Half
        {
            get
            {
                int test = SaltEnemies.rando;
                if (test > 50) return SaltEnemies.rando.CheckIfWithinRangeRandom(50);
                else if (test > 25) return SaltEnemies.silly.CheckIfWithinRangeRandom(50);
                else return SaltEnemies.trolling.CheckIfWithinRangeRandom(50);
            }
        }

        public static bool CheckIfWithinRangeRandom(this int num, int range)
        {
            bool loopsaround = false;
            int init = UnityEngine.Random.Range(0, 100);
            int endpoint = init + range;
            if (endpoint > 99) loopsaround = true;
            if (loopsaround)
            {
                return (num > init || num < (endpoint - 100));
            }
            else return (num > init && num < endpoint);
        }

        public static string SmartColor(int area, bool doubleAble = false, bool forceRed = false) => RandomEncounters.Shore.RandomIntelligentColor(area, doubleAble, forceRed);
        public static void ResetColor() => RandomEncounters.Shore.ResetIntelligentColor();

        public static List<RandomEnemyGroup> ToRandomGroup(this List<SpecificEnemyGroup> g)
        {
            List<RandomEnemyGroup> ret = new List<RandomEnemyGroup>();
            foreach (SpecificEnemyGroup group in g)
            {
                List<string> names = new List<string>();
                foreach (SpecificEnemyInfo enemy in group.EnemyGroup)
                {
                    names.Add(enemy.enemyName);
                }
                ret.Add(new RandomEnemyGroup()
                {
                    _enemyNames = names.ToArray()
                });
            }
            return ret;
        }
        public static List<SpecificEnemyGroup> ToSpecificGroup(this List<RandomEnemyGroup> g)
        {
            List<SpecificEnemyGroup> ret = new List<SpecificEnemyGroup>();
            foreach (RandomEnemyGroup group in g)
            {
                List<SpecificEnemyInfo> names = new List<SpecificEnemyInfo>();
                List<int> slots = new List<int>();
                for (int i = 5; i > 0; i--)
                {
                    foreach (string enemy in group.EnemyNames)
                    {
                        if (!EnemyExist(enemy) || slots.Count >= 5) continue;
                        int size = LoadedAssetsHandler.GetEnemy(enemy).size;
                        if (size == i)
                        {
                            int slot = GenerateSlots(size, slots).GetRandom();
                            for (int k = 0; k < size; k++) slots.Add(slot + k);
                            SpecificEnemyInfo info = new SpecificEnemyInfo()
                            {
                                enemySlot = slot,
                                enemyName = enemy
                            };
                            names.Add(info);
                        }
                    }
                }
                ret.Add(new SpecificEnemyGroup()
                {
                    _enemyGroup = names.ToArray()
                });
            }
            return ret;
        }
        public static List<int> GenerateSlots(int size, List<int> used)
        {
            List<int> ret = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                if (i + size <= 5 && !used.Contains(i))
                {
                    bool okay = true;
                    if (size > 1)
                    {
                        for (int j = i; j < i + size; j++) if (used.Contains(j)) okay = false;
                    }
                    if (okay) ret.Add(i);
                }
            }
            return ret;
        }
    }

    public static class RandomEncounters
    {
        public static class Shore
        {
            public static string RandomShoreMidget(bool flarbOnly = true)
            {
                List<string> list = new List<string>();
                if (!flarbOnly && SaltEnemies.rando < 10) list.Add("Mung_EN");
                list.Add("Flarblet_EN");
                if (EnemyExist("Flarbleft_EN")) list.Add("Flarbleft_EN");
                if (!flarbOnly && EnemyExist("LipBug_EN") && Half) list.Add("LipBug_EN");
                if (!flarbOnly && EnemyExist("LostSheep_EN") && Third) list.Add("LostSheep_EN");
                if (EnemyExist("Boulder_EN") && !flarbOnly && Rando(0)) list.Add("Boulder_EN");
                if (EnemyExist("Skyloft_EN") && !flarbOnly && Fifth) list.Add("Skyloft_EN");
                if (EnemyExist("Minana_EN") && !flarbOnly && Half) list.Add("Minana_EN");
                return list[UnityEngine.Random.Range(0, list.Count)];
            }
            public static string FarShoreSlop(bool doubleAble = false, bool red = false)
            {
                if (SlopWasDoubled && SlopLastDouble != null && SlopLastDouble != "")
                {
                    SlopWasDoubled = false;
                    string rar = SlopLastDouble;
                    SlopLastDouble = "";
                    return rar;
                }
                List<string> ret = new List<string>();
                for (int i = 0; i < 15; i++) ret.Add("MudLung_EN");
                for (int i = 0; i < 3; i++) ret.Add("Pinano_EN");
                if (Rando(22)) ret.Add("Wringle_EN");
                if (EnemyExist("Monck_EN") && !red) for (int i = 0; i < 2; i++) ret.Add("Monck_EN");
                if (EnemyExist("Lymphropod_EN")) for (int i = 0; i < 3; i++) ret.Add("Lymphropod_EN");
                if (doubleAble && SaltEnemies.rando < 60)
                {
                    SlopWasDoubled = true;
                    ret.Clear();
                    for (int i = 0; i < 5; i++) ret.Add("Keko_EN");
                    if (EnemyExist("Teto_EN")) for (int i = 0; i < 5; i++) ret.Add("Teto_EN");
                    if (EnemyExist("DeadPixel_EN") && !red) for (int i = 0; i < 4; i++) ret.Add("DeadPixel_EN");
                    if (EnemyExist("Lymphropod_EN")) for (int i = 0; i < 2; i++) ret.Add("Lymphropod_EN");
                    SlopLastDouble = ret.GetRandom();
                    return SlopLastDouble;
                }
                if (ret.Count <= 0) ret.Add("MudLung_EN");
                return ret.GetRandom();
            }
            public static string RandomIntelligentColor(int area, bool doubleAble = false, bool forceRed = false, int reroll = 0)
            {
                if (ColorWasDoubled && Coloring != ColorType.None && ColorLastDouble != null)
                {
                    string ret = "";
                    if (Coloring == ColorType.Jumble)
                    {
                        if (area == 2)
                        {
                            if (SaltEnemies.rando < 99) ret = "RusticJumbleguts_EN";
                            else ret = "JumbleGuts_Flummoxing_EN";
                        }
                        else
                        {
                            ret = RainBaseWeighted(true, area > 0);
                        }
                        if (forceRed) ret = RandomRedColor(true, false, area > 0);
                    }
                    else if (Coloring == ColorType.Spoggle)
                    {
                        if (area == 2) ret = "MortalSpoggle_EN";
                        else ret = RainBaseWeighted(false, area > 0);
                        if (forceRed) ret = RandomRedColor(false, false, area > 0);
                    }
                    else if (Coloring == ColorType.Colophon)
                    {
                        int limiter = 2;
                        if (area > 0) limiter = 4;
                        ret = Colophon.UpTo(limiter).GetRandom();
                        if (forceRed) ret = "DefeatedColophon_EN";
                    }
                    else if (Coloring == ColorType.Splig)
                    {
                        ret = Spligs.GetRandom();
                        if (forceRed)
                        {
                            List<string> lost = new List<string>();
                            if (EnemyExist("RougeWailingSplugling_EN"))
                            {
                                lost.Add("RougeWailingSplugling_EN");
                                lost.Add("RougeBellowingSplugling_EN");
                            }
                            else
                            {
                                lost.Add("RogueWailingSplugling_EN");
                                lost.Add("RogueBellowingSplugling_EN");
                            }
                            ret = lost.GetRandom();
                        }
                    }
                    else if (Coloring == ColorType.Flower)
                    {
                        int limiter = 2;
                        if (area > 1) limiter = 5;
                        ret = Flowers.UpTo(limiter).GetRandom();
                        if (forceRed) ret = "RedFlower_EN";
                    }
                    else ret = RandomColor(area);
                    if (reroll > 5 || forceRed)
                    {
                        PreviousColors.Add(ret);
                        return ret;
                    }
                    if (ret == ColorLastDouble || PreviousColors.Contains(ret)) ret = RandomIntelligentColor(area, doubleAble, forceRed, reroll + 1);
                    PreviousColors.Add(ret);
                    return ret;

                }
                if (!doubleAble && forceRed) return RandomRedColor(false, true, area > 0);
                if (!doubleAble) return RandomColor(area);
                else
                {
                    ColorWasDoubled = true;
                    List<ColorType> picking = new List<ColorType>();
                    picking.Add(ColorType.Jumble);
                    if (area > 0 || !forceRed) picking.Add(ColorType.Spoggle);
                    if (area < 2)
                    {
                        if (Colophoning) picking.Add(ColorType.Colophon);
                        if (Spligging) picking.Add(ColorType.Splig);
                    }
                    if (area > 0 && Flowering && (area > 1 || !forceRed)) picking.Add(ColorType.Flower);
                    ColorType picked = picking[UnityEngine.Random.Range(0, picking.Count)];
                    Coloring = picked;
                    if (picked == ColorType.Jumble)
                    {
                        if (area == 2)
                        {
                            if (SaltEnemies.rando < 99) ColorLastDouble = "RusticJumbleguts_EN";
                            else ColorLastDouble = "JumbleGuts_Flummoxing_EN";
                        }
                        else
                        {
                            ColorLastDouble = RainBaseWeighted(true, area > 0);
                        }
                        if (forceRed) ColorLastDouble = RandomRedColor(true, false, area > 0);
                    }
                    else if (picked == ColorType.Spoggle)
                    {
                        if (area == 2) ColorLastDouble = "MortalSpoggle_EN";
                        else ColorLastDouble = RainBaseWeighted(false, area > 0);
                        if (forceRed) ColorLastDouble = RandomRedColor(false, false, area > 0);
                    }
                    else if (picked == ColorType.Colophon)
                    {
                        int limiter = 2;
                        if (area > 0) limiter = 4;
                        ColorLastDouble = Colophon.UpTo(limiter).GetRandom();
                        if (forceRed) ColorLastDouble = "DefeatedColophon_EN";
                    }
                    else if (picked == ColorType.Splig)
                    {
                        ColorLastDouble = Spligs.GetRandom();
                        if (forceRed)
                        {
                            List<string> lost = new List<string>();
                            if (EnemyExist("RougeWailingSplugling_EN"))
                            {
                                lost.Add("RougeWailingSplugling_EN");
                                lost.Add("RougeBellowingSplugling_EN");
                            }
                            else
                            {
                                lost.Add("RogueWailingSplugling_EN");
                                lost.Add("RogueBellowingSplugling_EN");
                            }
                            ColorLastDouble = lost.GetRandom();
                        }
                    }
                    else if (picked == ColorType.Flower)
                    {
                        int limiter = 2;
                        if (area > 1) limiter = 5;
                        ColorLastDouble = Flowers.UpTo(limiter).GetRandom();
                        if (forceRed) ColorLastDouble = "RedFlower_EN";
                    }
                    else
                    {
                        Coloring = ColorType.Jumble;
                        ColorLastDouble = "JumbleGuts_Flummoxing_EN";
                    }
                    return ColorLastDouble;
                }
            }
            public static void ResetIntelligentColor()
            {
                ColorWasDoubled = false;
                Coloring = ColorType.None;
                ColorLastDouble = "";
                PreviousColors = new List<string>();
                PreviousColors.Clear();
            }
            public static string RandomShoreWhore()
            {
                List<string> list = new List<string>();
                list.Add("MunglingMudLung_EN");
                list.Add("FlaMinGoa_EN");
                if (EnemyExist("A'Flower'_EN") && Half) list.Add("A'Flower'_EN");
                if (EnemyExist("Disembodied_EN") && Third) list.Add("Disembodied_EN");
                if (EnemyExist("DrySimian_EN") && Half) list.Add("DrySimian_EN");
                if (EnemyExist("Seraphim_EN") && Half) list.Add("Seraphim_EN");
                if (EnemyExist("LittleBeak_EN")) list.Add("LittleBeak_EN");
                if (EnemyExist("Warbird_EN") && Third) list.Add("Warbird_EN");
                if (EnemyExist("Lurchin_EN") && Third) list.Add("Lurchin_EN");
                if (EnemyExist("FesteringFaction_EN") && Fifth) list.Add("FesteringFaction_EN");
                if (EnemyExist("OsseousClad_EN") && Half) list.Add("OsseousClad_EN");
                if (EnemyExist("MechanicalLens_EN") && Third) list.Add("MechanicalLens_EN");
                if (EnemyExist("Windle1_EN") && Quarter) list.Add("Windle1_EN");
                if (EnemyExist("Clione_EN") && Half) list.Add("Clione_EN");
                if (EnemyExist("UnculturedSwine_EN") && Half) list.Add("UnculturedSwine_EN");
                if (EnemyExist("Pinano_EN")) list.Add("UnculturedSwine_EN");
                return list.GetRandom();
            }
            public static string RandomShoreTwoSize()
            {
                List<string> list = new List<string>();
                list.Add("Flarb_EN");
                list.Add("Voboola_EN");
                if (EnemyExist("Unflarb_EN")) list.Add("Unflarb_EN");
                return list.GetRandom();
            }
            public static string RandomShoreBigGuy()
            {
                List<string> list = new List<string>();
                if (EnemyExist("Nephilim_EN")) list.Add("Nephilim_EN");
                if (EnemyExist("TripodFish_EN")) list.Add("TripodFish_EN");
                if (EnemyExist("BoulderBuddy_EN")) list.Add("BoulderBuddy_EN");
                if (EnemyExist("ColossalSheo_EN")) list.Add("ColossalSheo_EN");
                if (EnemyExist("MechanicalLens_EN") && Half) list.Add("MechanicalLens_EN");
                if (list.Count <= 0) list.Add("Mung_EN");
                return list.GetRandom();
            }
            public static string RandomShoreTwoSizeBigGuy()
            {
                List<string> list = new List<string>();
                list.Add("Kekastle_EN");
                return list.GetRandom();
            }
            static bool SlopWasDoubled;
            static string SlopLastDouble;
            static bool ColorWasDoubled;
            static string ColorLastDouble;
            static List<string> PreviousColors;
            static ColorType Coloring;

            public static FieldEnemy[] RandomizeShore(string who, Weight power, bool canLucky = true)
            {
                ResetIntelligentColor();
                if (!EnemyExist(who)) who = "Mung_EN";
                int size = LoadedAssetsHandler.GetEnemy(who).size;
                int Positions = 5;
                if (UnityEngine.Random.Range(0, 100) < 50) Positions--;
                if (UnityEngine.Random.Range(0, 100) < 15) Positions--;
                if (power == Weight.Normal) Positions--;
                if (power == Weight.Baby) Positions -= 2;
                List<FieldEnemy> ret = new List<FieldEnemy>() { new FieldEnemy() { enemyName = who, enemySlot = 0 } };
                bool full = false;
                int index = size;
                bool tooFull = false;
                bool lucky = canLucky ? Third : false;
                bool BigGuy = false;
                while (!full && index < Positions)
                {
                    if (Quarter & (int)power > 3 && Half && index < Positions - 1 && !BigGuy)
                    {
                        if (Half || index > 3)
                        {
                            ret.Add(new FieldEnemy() { enemyName = RandomShoreBigGuy(), enemySlot = index });
                            index++;
                            full = true;
                            BigGuy = true;
                        }
                        else
                        {
                            ret.Add(new FieldEnemy() { enemyName = RandomShoreTwoSizeBigGuy(), enemySlot = index });
                            index += 2;
                            full = true;
                            BigGuy = true;
                        }
                        if (full) break;
                    }
                    if (Quarter && ((int)power > 2 || (lucky && (int)power > 1)) && !BigGuy)
                    {
                        int selector = SaltEnemies.rando;
                        if (selector < 33 || index > 3)
                        {
                            ret.Add(new FieldEnemy() { enemyName = RandomShoreWhore(), enemySlot = index });
                            index++;
                            full = lucky ? true : Third;
                            BigGuy = true;
                        }
                        else if (selector < 66)
                        {
                            ret.Add(new FieldEnemy() { enemyName = RandomShoreTwoSize(), enemySlot = index });
                            index += 2;
                            full = lucky ? true : Third;
                            BigGuy = true;
                        }
                        else
                        {
                            ret.Add(new FieldEnemy() { enemyName = RandomIntelligentColor(0, true), enemySlot = index });
                            index++;
                            ret.Add(new FieldEnemy() { enemyName = RandomIntelligentColor(0, true), enemySlot = index });
                            index++;
                            full = lucky ? true : Third;
                            BigGuy = true;
                        }
                        if (full) break;
                    }
                    if (Quarter)
                    {
                        int cap = index >= 4 ? 67 : 100;
                        int skeletor = UnityEngine.Random.Range(0, cap);
                        if (skeletor > 66)
                        {
                            ret.Add(new FieldEnemy() { enemyName = FarShoreSlop(true), enemySlot = index });
                            index++;
                            ret.Add(new FieldEnemy() { enemyName = FarShoreSlop(), enemySlot = index });
                            index++;
                            full = SaltEnemies.rando > (Positions - (index + 1)) * 25;
                        }
                        else if (skeletor > 33)
                        {
                            ret.Add(new FieldEnemy() { enemyName = RandomIntelligentColor(0, true), enemySlot = index });
                            index++;
                            full = SaltEnemies.rando > (Positions - (index + 1)) * 25;
                        }
                        else
                        {
                            ret.Add(new FieldEnemy() { enemyName = FarShoreSlop(), enemySlot = index });
                            index++;
                            full = SaltEnemies.rando > (Positions - (index + 1)) * 25;
                        }
                        if (full) break;
                    }
                    if (Quarter)
                    {
                        ret.Add(new FieldEnemy() { enemyName = RandomShoreMidget(false), enemySlot = index });
                        index++;
                        full = (int)power < 2 ? SaltEnemies.rando > (Positions - (index + 1)) * 15 : false;
                        if (full) break;
                    }
                }
                for (int i = index; index < Positions && !tooFull; i++)
                {
                    ret.Add(new FieldEnemy() { enemyName = RandomShoreMidget(false), enemySlot = index });
                    index++;
                    tooFull = SaltEnemies.rando > (Positions - (index + 1)) * 25;
                }
                ResetIntelligentColor();
                return ret.ToArray();
            }
        }
        public static class Garden
        {
            static bool ChunkDoubleable;
            public static string RandomChunk(bool Red = false, bool tryDouble = false)
            {
                List<string> list = new List<string>();
                list.Add("InHisImage_EN");
                list.Add("InHerImage_EN");
                if (tryDouble && ChunkDoubleable)
                {
                    ChunkDoubleable = false;
                    return list.GetRandom();
                }
                if (EnemyExist("Spitato_EN")) list.Add("Spitato_EN");
                if (EnemyExist("SterileBud_EN")) list.Add("SterileBud_EN");
                if (EnemyExist("Harbinger_EN")) list.Add("Harbinger_EN");
                if (EnemyExist("HowlingAvian_EN") && Half) list.Add("HowlingAvian_EN");
                if (!Red && EnemyExist("TripodFish_EN") && Quarter) list.Add("TripodFish_EN");
                if (!Red && EnemyExist("MarbleMaw_EN") && Half) list.Add("MarbleMaw_EN");
                if (!Red && EnemyExist("YNL_EN") && Half) list.Add("YNL_EN");
                string ret = list.GetRandom();
                if (ret == "InHisImage_EN" || ret == "InHerImage_EN") ChunkDoubleable = true;
                else ChunkDoubleable = false;
                return ret;
            }
            public static string RandomWhore(bool Red = false)
            {
                List<string> list = new List<string>();
                list.Add("SkinningHomunculus_EN");
                list.Add("GigglingMinister_EN");
                if (!Red && Half) list.Add("ChoirBoy_EN");
                if (EnemyExist("Satyr_EN")) list.Add("Satyr_EN");
                if (EnemyExist("Firebird_EN") && Half) list.Add("Firebird_EN");
                if (!Red && EnemyExist("Maw_EN") && Half) list.Add("Maw_EN");
                if (!Red && EnemyExist("TheCrow_EN") && Half) list.Add("TheCrow_EN");
                if (!Red && EnemyExist("Hunter_EN") && Half) list.Add("Hunter_EN");
                if (EnemyExist("FrowningChancellor_EN") && Half) list.Add("FrowningChancellor_EN");
                return list.GetRandom();
            }
        }
    }

    public static class SaltExtensionMethods
    {
        public static T GetRandom<T>(this T[] array)
        {
            return array[UnityEngine.Random.Range(0, array.Length)];
        }
        public static T GetRandom<T>(this List<T> list)
        {
            return list.ToArray().GetRandom();
        }
        public static T[] UpTo<T>(this T[] array, int index)
        {
            List<T> ret = new List<T>();
            for (int i = 0; i < index && i < array.Length; i++)
            {
                ret.Add(array[i]);
            }
            return ret.ToArray();
        }
        public static T[] Exclude<T>(this T[] array, T exclude)
        {
            List<T> ret = new List<T>();
            foreach (T str in array)
            {
                if (exclude != null && str.Equals(exclude)) continue;
                ret.Add(str);
            }
            return ret.ToArray();
        }
        public static T[] SelfArray<T>(this T target)
        {
            return new T[] { target };
        }
    }

    public static class TellsYouToInstallSaltAdjustments
    {
        public static void TellYou()
        {
            if (File.Exists(NamelessHandler.RootPath + "/Plascencia.dll"))
            {
                File.WriteAllText(NamelessHandler.RootPath + "/READ_ME.txt/", "This mod was designed with having the mod \"Plascencia.dll\" installed, specifically with the special interaction between scars and divine protection removed, and giggling ministers not having trauma bond. \nAs such, to put it lightly Shit Might Be Fucked Up if you dont have the salt adjustments mod installed and dont have it removing trauma bond. \nTLDR DWONLOAD SALT'S ADJUSTMENT MOD OR SUFFER ENCOUNTERS NOT DESIGNED AROUND TRAUMA BOND");
            }
        }
    }

    public static class DoDebugs
    {
        public static bool All => false;
        public static bool EnemyNull => true && All;
        public static bool SpriteNull => false && All;
        public static bool GenInfo => true && All;
        public static bool MiscInfo => false && All;
    }

    public enum ColorType
    {
        None = 0,
        Jumble = 1,
        Spoggle = 2,
        Colophon = 3,
        Splig = 4,
        Flower = 5,
    }
    public enum Weight
    {
        Baby = 1,
        Normal = 2,
        Big = 3,
        Super = 4
    }

    public static class Updater
    {
        public static void Update()
        {
            U1_3_27();
            U1_3_29();
            U1_3_29_2();
            U1_3_30();
        }
        public static void U1_3_27()
        {
            if (!File.Exists(SavePath + "Update_1_3_27.txt"))
            {
                File.WriteAllText(SavePath + "Update_1_3_27.txt", "Updatd pages !");
                PageCollector.UpdatePage("AnglerPage.png");
                PageCollector.UpdatePage("BeakPage.png");
                PageCollector.UpdatePage("BlackStarPage.png");
                PageCollector.UpdatePage("BlueFlowerPage.png");
                PageCollector.UpdatePage("ButterflyPage.png");
                PageCollector.UpdatePage("CameraPage.png");
                PageCollector.UpdatePage("ChildrenPage.png");
                PageCollector.UpdatePage("ClionePage.png");
                PageCollector.UpdatePage("ClockPage.png");
                PageCollector.UpdatePage("CNSPage.png");
                PageCollector.UpdatePage("CoffinPage.png");
                PageCollector.UpdatePage("CoinHunterPage.png");
                PageCollector.UpdatePage("CrowPage.png");
                PageCollector.UpdatePage("DamoclesPage.png");
                PageCollector.UpdatePage("DeadGodPage.png");
                PageCollector.UpdatePage("DeadPixelPage.png");
                PageCollector.UpdatePage("DelusionPage.png");
                PageCollector.UpdatePage("DontTouchMePage.png");
                PageCollector.UpdatePage("EnigmaPage.png");
                PageCollector.UpdatePage("FakeAngelPage.png");
                PageCollector.UpdatePage("FirebirdPage.png");
                PageCollector.UpdatePage("GlassPage.png");
                PageCollector.UpdatePage("GospelPage.png");
                PageCollector.UpdatePage("GreyFlowerPage.png");
                PageCollector.UpdatePage("HuntingPage.png");
                PageCollector.UpdatePage("IndicatorPage.png");
                PageCollector.UpdatePage("LittleAngelPage.png");
                PageCollector.UpdatePage("MawPage.png");
                PageCollector.UpdatePage("MedamaudePage.png");
                PageCollector.UpdatePage("MercedPage.png");
                PageCollector.UpdatePage("MiriamPage.png");
                PageCollector.UpdatePage("NamelessPage.png");
                PageCollector.UpdatePage("PostmodernPage.png");
                PageCollector.UpdatePage("PurpleFlowerPage.png");
                PageCollector.UpdatePage("RabiesPage.png");
                PageCollector.UpdatePage("ReaperPage.png");
                PageCollector.UpdatePage("RedFlowerPage.png");
                PageCollector.UpdatePage("RusticPage.png");
                PageCollector.UpdatePage("SatyrPage.png");
                PageCollector.UpdatePage("ShuaPage.png");
                PageCollector.UpdatePage("SigilPage.png");
                PageCollector.UpdatePage("SingularityPage.png");
                PageCollector.UpdatePage("SkyloftPage.png");
                PageCollector.UpdatePage("SnakeGodPage.png");
                PageCollector.UpdatePage("SolventPage.png");
                PageCollector.UpdatePage("SomethingPage.png");
                PageCollector.UpdatePage("StarGazerPage.png");
                PageCollector.UpdatePage("SuperbossPage.png");
                PageCollector.UpdatePage("TankPage.png");
                PageCollector.UpdatePage("TheDeepPage.png");
                PageCollector.UpdatePage("TortoisePage.png");
                PageCollector.UpdatePage("TripodPage.png");
                PageCollector.UpdatePage("UnmungPage.png");
                PageCollector.UpdatePage("WarbirdPage.png");
                PageCollector.UpdatePage("WindlePage.png");
                PageCollector.UpdatePage("WindSongPage.png");
                PageCollector.UpdatePage("YellowFlowerPage.png");
            }
        }
        public static void U1_3_29()
        {
            if (!File.Exists(SavePath + "Update_1_3_29.txt"))
            {
                File.WriteAllText(SavePath + "Update_1_3_29.txt", "Updatd pages !");
                PageCollector.UpdatePage("DelusionPage.png");
                PageCollector.UpdatePage("MedamaudePage.png");
            }
        }
        public static void U1_3_29_2()
        {
            if (!File.Exists(SavePath + "Update_1_3_29_2.txt"))
            {
                File.WriteAllText(SavePath + "Update_1_3_29_2.txt", "Updatd pages !");
                PageCollector.UpdatePage("ClionePage.png");
            }
        }
        public static void U1_3_30()
        {
            if (!File.Exists(SavePath + "Update_1_3_30.txt"))
            {
                File.WriteAllText(SavePath + "Update_1_3_30.txt", "Updatd pages !");
                PageCollector.UpdatePage("DontTouchMePage.png");
            }
        }
        public static void U1_4_0()
        {
            if (!File.Exists(SavePath + "Update_1_4_0.txt"))
            {
                File.WriteAllText(SavePath + "Update_1_4_0.txt", "Updatd pages !");
                PageCollector.UpdatePage("UnmungPage.png");
                PageCollector.UpdatePage("SkyloftPage.png");
                PageCollector.UpdatePage("SnakeGodPage.png");
                PageCollector.UpdatePage("AnglerPage.png");
            }
        }
    }
}
