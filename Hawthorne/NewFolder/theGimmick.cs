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
using static UnityEngine.EventSystems.EventTrigger;
using Hawthorne;
using System.Collections.Generic;

namespace Hawthorne.NewFolder
{
    public static class theGimmick
    {
        public static bool isAdded = false;
        public static void Add()
        {
            SpawnEnemyAnywhereEffect theBox = ScriptableObject.CreateInstance<SpawnEnemyAnywhereEffect>();
            theBox.enemy = LoadedAssetsHandler.GetEnemy("StrangeBox_EN");
            
            EffectItem lockedBox = new EffectItem();
            lockedBox.name = "Locked Box";
            lockedBox.flavorText = "\"Someone's persistent gaze can be felt from the keyhole...\"";
            lockedBox.description = "Spawns an enemy on combat start. This item is destroyed upon activation. This item does not work in boss encounters.";
            lockedBox.sprite = ResourceLoader.LoadSprite("StrangeBox", 32);
            lockedBox.trigger = TriggerCalls.OnCombatStart;
            CheckBundleDifficultyEffectorCondition isntBoss = ScriptableObject.CreateInstance<CheckBundleDifficultyEffectorCondition>();
            isntBoss._isEqual = false;
            lockedBox.triggerConditions = new EffectorConditionSO[1]
            {
                isntBoss
            };
            lockedBox.consumeTrigger = TriggerCalls.Count;
            lockedBox.unlockableID = (UnlockableID)20051511;
            lockedBox.namePopup = true;
            lockedBox.consumedOnUse = true;
            lockedBox.itemPools = ItemPools.Extra;
            lockedBox.shopPrice = 5;
            lockedBox.startsLocked = false;
            lockedBox.immediate = false;
            
            lockedBox.effects = new Effect[]
            {
                
                new Effect(theBox, 1, null, Slots.Self)
            };
            lockedBox.AddItem();
            //CombatManager c;
            isAdded = true;
        }
    }
    public class LockedBoxEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (LetsYouIgnoreMissingEnemiesHook.IsDisabled("StrangeBox_EN")) return false;
            if (!theGimmick.isAdded)
            {
                theGimmick.Add();
            }
            stats.AddExtraLootAddition("LockedBox_EW");
            return exitAmount > 0;
        }
    }
    public class ChocolateCoinEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (caster.CurrentHealth > 0)
            {
                return false;
            }
            Chocolate.Add();
            stats.AddExtraLootAddition("ChocolateCoin_EW");
            return true;
        }
    }
    public class OverrideMusicEffect : EffectSO
    {
        public string newsong;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            //return true;
            CombatManager.Instance._musicEventHandler.OnWillStopCombatMusic(CombatManager.Instance._soundManager.MusicCombatEvent);
            CombatManager.Instance._soundManager.StopCombatMusicTrack();
            CombatManager.Instance._musicEventHandler.OnStopCombatMusic();
            CombatManager.Instance._soundManager.PlayCombatMusicTrack(newsong);
            CombatManager.Instance._musicEventHandler = new MusicTimelineEventHandler();
            CombatManager.Instance._musicEventHandler.SetUpCombatMusicCallbacks(CombatManager.Instance._soundManager.MusicCombatEvent);
            return true;
        }
    }
}
