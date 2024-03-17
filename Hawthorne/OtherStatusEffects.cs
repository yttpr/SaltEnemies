using BrutalAPI;
using Hawthorne.NewFolder;
using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using THE_DEAD;
using UnityEngine;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;
using static UnityEngine.TouchScreenKeyboard;

namespace Hawthorne
{
    public static class OtherStatusEffects
    {
        public static void Add()
        {
            IDetour addContagionEffectIDetour = (IDetour)new Hook((MethodBase)typeof(CombatManager).GetMethod("InitializeCombat", ~BindingFlags.Default), typeof(OtherStatusEffects).GetMethod("AddContagionStatusEffect", ~BindingFlags.Default));
            IDetour addContagionEffectIntentIDetour = (IDetour)new Hook((MethodBase)typeof(IntentHandlerSO).GetMethod("Initialize", ~BindingFlags.Default), typeof(OtherStatusEffects).GetMethod("ContagionIntent", ~BindingFlags.Default));
            IDetour addGrowthEffectIDetour = (IDetour)new Hook((MethodBase)typeof(CombatManager).GetMethod("InitializeCombat", ~BindingFlags.Default), typeof(OtherStatusEffects).GetMethod("AddGrowStatusEffect", ~BindingFlags.Default));
            IDetour addGrowthEffectIntentIDetour = (IDetour)new Hook((MethodBase)typeof(IntentHandlerSO).GetMethod("Initialize", ~BindingFlags.Default), typeof(OtherStatusEffects).GetMethod("addGrowthIntent", ~BindingFlags.Default));
            IDetour addGuttedEffectIntentIDetour = (IDetour)new Hook((MethodBase)typeof(IntentHandlerSO).GetMethod("Initialize", ~BindingFlags.Default), typeof(OtherStatusEffects).GetMethod("addGuttedIntent", ~BindingFlags.Default));
            IDetour addWildCardEffectIDetour = (IDetour)new Hook((MethodBase)typeof(CombatManager).GetMethod("InitializeCombat", ~BindingFlags.Default), typeof(OtherStatusEffects).GetMethod("AddWildCardStatusEffect", ~BindingFlags.Default));
            IDetour addWildCardEffectIntentIDetour = (IDetour)new Hook((MethodBase)typeof(IntentHandlerSO).GetMethod("Initialize", ~BindingFlags.Default), typeof(OtherStatusEffects).GetMethod("addWildIntent", ~BindingFlags.Default));
            IDetour DemonicProtectionIDetour = (IDetour)new Hook((MethodBase)typeof(CombatManager).GetMethod("InitializeCombat", ~BindingFlags.Default), typeof(OtherStatusEffects).GetMethod("AddDemonicProtectionStatusEffect", ~BindingFlags.Default));
            IDetour DemonicProtectionIntentIDetour = (IDetour)new Hook((MethodBase)typeof(IntentHandlerSO).GetMethod("Initialize", ~BindingFlags.Default), typeof(OtherStatusEffects).GetMethod("DemonicProtectionIntent", ~BindingFlags.Default));
            IDetour MarkedIDetour = (IDetour)new Hook((MethodBase)typeof(CombatManager).GetMethod("InitializeCombat", ~BindingFlags.Default), typeof(OtherStatusEffects).GetMethod("AddMarkedStatusEffect", ~BindingFlags.Default));
            IDetour MarkedIntentIDetour = (IDetour)new Hook((MethodBase)typeof(IntentHandlerSO).GetMethod("Initialize", ~BindingFlags.Default), typeof(OtherStatusEffects).GetMethod("MarkedIntent", ~BindingFlags.Default));
            IDetour InvigoratedIDetour = (IDetour)new Hook((MethodBase)typeof(CombatManager).GetMethod("InitializeCombat", ~BindingFlags.Default), typeof(OtherStatusEffects).GetMethod("AddInvigoratedStatusEffect", ~BindingFlags.Default));
            IDetour InvigoratedIntentIDetour = (IDetour)new Hook((MethodBase)typeof(IntentHandlerSO).GetMethod("Initialize", ~BindingFlags.Default), typeof(OtherStatusEffects).GetMethod("InvigoratedIntent", ~BindingFlags.Default));
            IDetour AdrenalineIDetour = (IDetour)new Hook((MethodBase)typeof(CombatManager).GetMethod("InitializeCombat", ~BindingFlags.Default), typeof(OtherStatusEffects).GetMethod("AddAdrenalineStatusEffect", ~BindingFlags.Default));
            IDetour AdrenalineIntentIDetour = (IDetour)new Hook((MethodBase)typeof(IntentHandlerSO).GetMethod("Initialize", ~BindingFlags.Default), typeof(OtherStatusEffects).GetMethod("AdrenalineIntent", ~BindingFlags.Default));
            IDetour addHexedIDetour = (IDetour)new Hook((MethodBase)typeof(CombatManager).GetMethod("InitializeCombat", ~BindingFlags.Default), typeof(OtherStatusEffects).GetMethod("AddHexedStatusEffect", ~BindingFlags.Default));
            IDetour addHexedIntentIDetour = (IDetour)new Hook((MethodBase)typeof(IntentHandlerSO).GetMethod("Initialize", ~BindingFlags.Default), typeof(OtherStatusEffects).GetMethod("HexedIntent", ~BindingFlags.Default));
            IDetour SharpHexedValueDisplay = new Hook((MethodBase)typeof(TooltipTextHandlerSO).GetMethod("ProcessStoredValue", ~BindingFlags.Default), typeof(OtherStatusEffects).GetMethod("HexedDisplay", ~BindingFlags.Default));

        }

        public static IntentInfo contagionIntent = (IntentInfo)new IntentInfoBasic();
        public static StatusEffectInfoSO contagion = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
        public static void AddContagionStatusEffect(Action<CombatManager> orig, CombatManager self)
        {
            orig(self);
            contagion.name = "Contagion";
            contagion.icon = ResourceLoader.LoadSprite("Contagion", 32);
            contagion._statusName = "Contagion";
            contagion.statusEffectType = (StatusEffectType)305308;
            contagion._description = "Upon receiving damage, deal 2-3 Indirect damage to the left or right unit.\n70% chance to remove 1 Contagion upon taking indirect damage.\n1 stack of Contagion is removed at the end of each turn.";
            contagion._applied_SE_Event = self._stats.slotStatusEffectDataBase[SlotStatusEffectType.Constricted]._applied_SE_Event;
            contagion._removed_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Scars].RemovedSoundEvent;
            contagion._updated_SE_Event = self._stats.slotStatusEffectDataBase[SlotStatusEffectType.Constricted]._updated_SE_Event;
            contagion._special01_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Ruptured].AppliedSoundEvent;
            contagion._special02_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Ruptured].AppliedSoundEvent;
            StatusEffectInfoSO statusEffectInfoSo;
            self._stats.statusEffectDataBase.TryGetValue((StatusEffectType)305308, out statusEffectInfoSo);
            if (!((UnityEngine.Object)statusEffectInfoSo == (UnityEngine.Object)null))
                return;
            self._stats.statusEffectDataBase.Add((StatusEffectType)305308, contagion);
        }
        public static void ContagionIntent(Action<IntentHandlerSO> orig, IntentHandlerSO self)
        {
            orig(self);
            contagionIntent._type = (IntentType)32333;
            contagionIntent._sprite = ResourceLoader.LoadSprite("Contagion", 32);
            contagionIntent._color = Color.white;
            contagionIntent._sound = self._intentDB[IntentType.Field_Constricted]._sound;
            IntentInfo intentInfo;
            self._intentDB.TryGetValue((IntentType)32333, out intentInfo);
            if (intentInfo != null)
                return;
            self._intentDB.Add((IntentType)32333, contagionIntent);
        }

        public static StatusEffectInfoSO Growth = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
        public static IntentInfoBasic GuttedIntent = new IntentInfoBasic();
        public static IntentInfoBasic GrowthIntent = new IntentInfoBasic();
        public static void AddGrowStatusEffect(Action<CombatManager> orig, CombatManager self)
        {
            orig(self);
            Growth.name = "Growth";
            Growth.icon = ResourceLoader.LoadSprite("GrowthIcon.png", 32);
            Growth._statusName = "Growth";
            Growth.statusEffectType = (StatusEffectType)30512;
            Growth._description = "At the start of each turn heal this party member equal to the amount of Growth and cut the amount of Growth in half.\nTaking any damage will reduce the amount of Growth by the damage taken.";
            Growth._applied_SE_Event = self._stats.slotStatusEffectDataBase[SlotStatusEffectType.Constricted]._applied_SE_Event;
            Growth._removed_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Ruptured].RemovedSoundEvent;
            Growth._updated_SE_Event = self._stats.slotStatusEffectDataBase[SlotStatusEffectType.Constricted]._updated_SE_Event;
            Growth._special01_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Scars].AppliedSoundEvent;
            Growth._special02_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Scars].AppliedSoundEvent;
            StatusEffectInfoSO statusEffectInfoSo;
            self._stats.statusEffectDataBase.TryGetValue((StatusEffectType)30512, out statusEffectInfoSo);
            if (!((UnityEngine.Object)statusEffectInfoSo == (UnityEngine.Object)null))
                return;
            self._stats.statusEffectDataBase.Add((StatusEffectType)30512, Growth);
        }
        public static void addGuttedIntent(Action<IntentHandlerSO> orig, IntentHandlerSO self)
        {
            orig(self);
            GuttedIntent._type = (IntentType)50336;
            GuttedIntent._sprite = ResourceLoader.LoadSprite("GuttedIcon.png", 32);
            GuttedIntent._color = Color.white;
            GuttedIntent._sound = self._intentDB[IntentType.Status_Ruptured]._sound;
            IntentInfo intentInfo;
            self._intentDB.TryGetValue((IntentType)50336, out intentInfo);
            if (intentInfo != null)
                return;
            self._intentDB.Add((IntentType)50336, (IntentInfo)GuttedIntent);
        }
        public static void addGrowthIntent(Action<IntentHandlerSO> orig, IntentHandlerSO self)
        {
            orig(self);
            GrowthIntent._type = (IntentType)50337;
            GrowthIntent._sprite = ResourceLoader.LoadSprite("GrowthIcon.png", 32);
            GrowthIntent._color = Color.white;
            GrowthIntent._sound = self._intentDB[IntentType.Field_Constricted]._sound;
            GuttedIntent._sound = self._intentDB[IntentType.Status_Ruptured]._sound;
            IntentInfo intentInfo;
            self._intentDB.TryGetValue((IntentType)50337, out intentInfo);
            if (intentInfo != null)
                return;
            self._intentDB.Add((IntentType)50337, (IntentInfo)GrowthIntent);
        }


        public static StatusEffectInfoSO Wild = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
        public static IntentInfoBasic WildIntent = new IntentInfoBasic();
        public static void AddWildCardStatusEffect(Action<CombatManager> orig, CombatManager self)
        {
            orig(self);
            Wild.name = "Wild Card";
            Wild.icon = ResourceLoader.LoadSprite("WildCardIcon.png", 32);
            Wild._statusName = "Wild Card";
            Wild.statusEffectType = (StatusEffectType)30513;
            Wild._description = "All direct damage this party member deals is increased or decreased between 0 and the amount of Wild Card.\nDamage can not be lowered past 1.";
            Wild._applied_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Focused]._applied_SE_Event;
            Wild._removed_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Ruptured].RemovedSoundEvent;
            Wild._updated_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Focused]._applied_SE_Event;
            Wild._special01_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Spotlight]._special01_SE_Event;
            Wild._special02_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Spotlight]._special02_SE_Event;
            StatusEffectInfoSO statusEffectInfoSo;
            self._stats.statusEffectDataBase.TryGetValue((StatusEffectType)30513, out statusEffectInfoSo);
            if (!((UnityEngine.Object)statusEffectInfoSo == (UnityEngine.Object)null))
                return;
            self._stats.statusEffectDataBase.Add((StatusEffectType)30513, Wild);
        }
        public static void addWildIntent(Action<IntentHandlerSO> orig, IntentHandlerSO self)
        {
            orig(self);
            WildIntent._type = (IntentType)50338;
            WildIntent._sprite = ResourceLoader.LoadSprite("WildCardIcon.png", 32);
            WildIntent._color = Color.white;
            WildIntent._sound = self._intentDB[IntentType.Field_Constricted]._sound;
            IntentInfo intentInfo;
            self._intentDB.TryGetValue((IntentType)50338, out intentInfo);
            if (intentInfo != null)
                return;
            self._intentDB.Add((IntentType)50338, (IntentInfo)WildIntent);
        }

        public static StatusEffectInfoSO demonicprotection = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
        public static void AddDemonicProtectionStatusEffect(Action<CombatManager> orig, CombatManager self)
        {
            orig(self);
            demonicprotection.name = "Demonic Protection";
            demonicprotection.icon = ResourceLoader.LoadSprite("DemonicProtectionIcon", 32);
            demonicprotection._statusName = "Demonic Protection";
            demonicprotection.statusEffectType = (StatusEffectType)666888;
            demonicprotection._description = "Protection from forces above and below.\nUpon taking damage, health cannot be reduced below the amount of demonic protection.\nRemove all stacks of Demonic Protection if Damage is blocked.";
            demonicprotection._applied_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Cursed]._applied_SE_Event;
            demonicprotection._removed_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Scars].RemovedSoundEvent;
            demonicprotection._updated_SE_Event = self._stats.slotStatusEffectDataBase[SlotStatusEffectType.Constricted]._updated_SE_Event;
            demonicprotection._special01_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Ruptured].AppliedSoundEvent;
            demonicprotection._special02_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Ruptured].AppliedSoundEvent;
            StatusEffectInfoSO statusEffectInfoSo;
            self._stats.statusEffectDataBase.TryGetValue((StatusEffectType)666888, out statusEffectInfoSo);
            if (!((UnityEngine.Object)statusEffectInfoSo == (UnityEngine.Object)null))
                return;
            self._stats.statusEffectDataBase.Add((StatusEffectType)666888, demonicprotection);
        }
        public static IntentInfo demonicprotectionintent = (IntentInfo)new IntentInfoBasic();
        public static void DemonicProtectionIntent(Action<IntentHandlerSO> orig, IntentHandlerSO self)
        {
            orig(self);
            demonicprotectionintent._type = (IntentType)95533;
            demonicprotectionintent._sprite = ResourceLoader.LoadSprite("DemonicProtectionIcon", 32);
            demonicprotectionintent._color = Color.white;
            demonicprotectionintent._sound = self._intentDB[IntentType.Status_Linked]._sound;
            IntentInfo intentInfo;
            self._intentDB.TryGetValue((IntentType)95533, out intentInfo);
            if (intentInfo != null)
                return;
            self._intentDB.Add((IntentType)95533, demonicprotectionintent);
        }

        public static IntentInfo markedIntent = (IntentInfo)new IntentInfoBasic();
        public static StatusEffectInfoSO marked = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
        public static void MarkedIntent(Action<IntentHandlerSO> orig, IntentHandlerSO self)
        {
            orig(self);
            markedIntent._type = (IntentType)94433;
            markedIntent._sprite = ResourceLoader.LoadSprite("MarkedIcon", 32);
            markedIntent._color = Color.white;
            markedIntent._sound = self._intentDB[IntentType.Status_Linked]._sound;
            IntentInfo intentInfo;
            self._intentDB.TryGetValue((IntentType)94433, out intentInfo);
            if (intentInfo != null)
                return;
            self._intentDB.Add((IntentType)94433, markedIntent);
        }
        public static void AddMarkedStatusEffect(Action<CombatManager> orig, CombatManager self)
        {
            orig(self);
            marked.name = "Marked";
            marked.icon = ResourceLoader.LoadSprite("MarkedIcon", 32);
            marked._statusName = "Marked";
            marked.statusEffectType = (StatusEffectType)399908;
            marked._description = "Receives 30% more damage.\nOnly one entity can be Marked at any given time.";
            marked._applied_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Linked]._applied_SE_Event;
            marked._removed_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Scars].RemovedSoundEvent;
            marked._updated_SE_Event = self._stats.slotStatusEffectDataBase[SlotStatusEffectType.Constricted]._updated_SE_Event;
            marked._special01_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Ruptured].AppliedSoundEvent;
            marked._special02_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Ruptured].AppliedSoundEvent;
            StatusEffectInfoSO statusEffectInfoSo;
            self._stats.statusEffectDataBase.TryGetValue((StatusEffectType)399908, out statusEffectInfoSo);
            if (!((UnityEngine.Object)statusEffectInfoSo == (UnityEngine.Object)null))
                return;
            self._stats.statusEffectDataBase.Add((StatusEffectType)399908, marked);
        }

        public static StatusEffectInfoSO invigorated = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
        public static IntentInfo invigoratedIntent = (IntentInfo)new IntentInfoBasic();
        public static void AddInvigoratedStatusEffect(Action<CombatManager> orig, CombatManager self)
        {
            orig(self);
            invigorated.name = "Invigorated";
            invigorated.icon = ResourceLoader.LoadSprite("InvigoratedStatus", 32);
            invigorated._statusName = "Invigorated";
            invigorated.statusEffectType = (StatusEffectType)84951260;
            invigorated._description = "While Invigorated, 2 health is healed upon moving. 1 point of Invigorated is lost at the end of each turn.";
            invigorated._applied_SE_Event = self._stats.slotStatusEffectDataBase[SlotStatusEffectType.Constricted]._applied_SE_Event;
            invigorated._removed_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Ruptured].RemovedSoundEvent;
            invigorated._updated_SE_Event = self._stats.slotStatusEffectDataBase[SlotStatusEffectType.Constricted]._updated_SE_Event;
            StatusEffectInfoSO statusEffectInfoSo;
            self._stats.statusEffectDataBase.TryGetValue((StatusEffectType)84951260, out statusEffectInfoSo);
            if (!((UnityEngine.Object)statusEffectInfoSo == (UnityEngine.Object)null))
                return;
            self._stats.statusEffectDataBase.Add((StatusEffectType)84951260, invigorated);
        }
        public static void InvigoratedIntent(Action<IntentHandlerSO> orig, IntentHandlerSO self)
        {
            orig(self);
            invigoratedIntent._type = (IntentType)84951261;
            invigoratedIntent._sprite = ResourceLoader.LoadSprite("InvigoratedStatus", 32);
            invigoratedIntent._color = Color.white;
            invigoratedIntent._sound = self._intentDB[IntentType.Status_Scars]._sound;
            IntentInfo intentInfo;
            self._intentDB.TryGetValue((IntentType)84951261, out intentInfo);
            if (intentInfo != null)
                return;
            self._intentDB.Add((IntentType)84951261, invigoratedIntent);
        }

        public static StatusEffectInfoSO adrenaline = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
        public static void AddAdrenalineStatusEffect(Action<CombatManager> orig, CombatManager self)
        {
            orig(self);
            adrenaline.name = "Adrenaline";
            adrenaline.icon = ResourceLoader.LoadSprite("aderlineIcon", 32);
            adrenaline._statusName = "Adrenaline";
            adrenaline.statusEffectType = (StatusEffectType)444442;
            adrenaline._description = "Increase damage dealt by this character by 30%. Upon dealing damage, decrease Adrenaline by 1.";
            adrenaline._applied_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Focused].AppliedSoundEvent;
            adrenaline._removed_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Focused].UpdatedSoundEvent;
            adrenaline._updated_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Focused].RemovedSoundEvent;
            StatusEffectInfoSO effectInfo;
            self._stats.statusEffectDataBase.TryGetValue((StatusEffectType)444442, out effectInfo);
            if (effectInfo == null)
                self._stats.statusEffectDataBase.Add((StatusEffectType)444442, adrenaline);
        }
        public static IntentInfo adrenalineIntent = new IntentInfoBasic();
        public static void AdrenalineIntent(Action<IntentHandlerSO> orig, IntentHandlerSO self)
        {
            orig(self);
            adrenalineIntent._type = (IntentType)444442;
            adrenalineIntent._sprite = ResourceLoader.LoadSprite("aderlineIcon", 32);
            adrenalineIntent._color = Color.white;
            adrenalineIntent._sound = self._intentDB[IntentType.Status_Scars]._sound;
            IntentInfo intentInfo;
            self._intentDB.TryGetValue((IntentType)444442, out intentInfo);
            if (intentInfo == null)
                self._intentDB.Add((IntentType)444442, (IntentInfo)adrenalineIntent);
        }

        public static StatusEffectInfoSO hexed = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
        public static void AddHexedStatusEffect(Action<CombatManager> orig, CombatManager self)
        {
            orig(self);
            hexed.name = "Hexed";
            hexed.icon = ResourceLoader.LoadSprite("hexedIcon", 32);
            hexed._statusName = "Hexed";
            hexed.statusEffectType = (StatusEffectType)444440;
            hexed._description = "This character gains a +3 damage boost, and an additional +3 every time they deal damage, but have maxmimum health decreased by 1 every time they perform an ability. \nThis status is lost upon taking direct damage. \nIf this unit did not perform an ability this turn, remove this status at the end of the turn.";
            hexed._applied_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Focused].AppliedSoundEvent;
            hexed._removed_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Focused].UpdatedSoundEvent;
            hexed._updated_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Focused].RemovedSoundEvent;
            StatusEffectInfoSO effectInfo;
            self._stats.statusEffectDataBase.TryGetValue((StatusEffectType)444440, out effectInfo);
            if (effectInfo == null)
                self._stats.statusEffectDataBase.Add((StatusEffectType)444440, hexed);
        }
        public static IntentInfo hexedIntent = new IntentInfoBasic();
        public static void HexedIntent(Action<IntentHandlerSO> orig, IntentHandlerSO self)
        {
            orig(self);
            hexedIntent._type = (IntentType)444440;
            hexedIntent._sprite = ResourceLoader.LoadSprite("hexedIcon", 32);
            hexedIntent._color = Color.white;
            hexedIntent._sound = self._intentDB[IntentType.Status_Cursed]._sound;
            IntentInfo intentInfo;
            self._intentDB.TryGetValue((IntentType)444440, out intentInfo);
            if (intentInfo == null)
                self._intentDB.Add((IntentType)444440, (IntentInfo)hexedIntent);
        }
        public static string HexedDisplay(
          Func<TooltipTextHandlerSO, UnitStoredValueNames, int, string> orig,
          TooltipTextHandlerSO self,
          UnitStoredValueNames storedValue,
          int value)
        {
            Color magenta = Color.magenta;
            string str1;
            if (storedValue == (UnitStoredValueNames)444440)
            {
                if (value <= 0)
                {
                    str1 = "";
                }
                else
                {
                    string str2 = "Hexed" + string.Format(" +{0}", (object)value);
                    string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(Color.cyan) + ">";
                    string str4 = "</color>";
                    str1 = str3 + str2 + str4;
                }
            }
            else
                str1 = orig(self, storedValue, value);
            return str1;
        }
    }

}
namespace MizerFool.Effects
{
    public class Contagion_StatusEffect : IStatusEffect, ITriggerEffect<IStatusEffector>
    {
        private bool _NextDamageIsDirect = false;
        public const int _ruptureDamage = 2;

        public int StatusContent => this.Duration;

        public int Restrictor { get; set; }

        public bool CanBeRemoved => this.Restrictor <= 0;

        public bool IsPositive => false;

        public string DisplayText
        {
            get
            {
                string displayText = "";
                if (this.Duration > 0)
                    displayText += this.Duration.ToString();
                if (this.Restrictor > 0)
                    displayText = displayText + "(" + this.Restrictor.ToString() + ")";
                return displayText;
            }
        }

        public int Duration { get; set; }

        public StatusEffectType EffectType => (StatusEffectType)305308;

        public StatusEffectInfoSO EffectInfo { get; set; }

        public void SetEffectInformation(StatusEffectInfoSO effectInfo) => this.EffectInfo = effectInfo;

        public bool CanReduceDuration
        {
            get
            {
                BooleanReference result = new BooleanReference(true);
                CombatManager.Instance.ProcessImmediateAction((IImmediateAction)new CheckHasStatusFieldReductionBlockIAction(result));
                return !result.value;
            }
        }

        public Contagion_StatusEffect(int duration, int restrictors = 0)
        {
            this.Duration = duration;
            this.Restrictor = restrictors;
        }

        public bool AddContent(IStatusEffect content)
        {
            this.Duration += content.StatusContent;
            this.Restrictor += content.Restrictor;
            return true;
        }

        public bool TryAddContent(int amount)
        {
            if (this.Duration <= 0)
                return false;
            this.Duration += amount;
            return true;
        }

        public int JustRemoveAllContent()
        {
            int duration = this.Duration;
            this.Duration = 0;
            return duration;
        }

        public void OnTriggerAttached(IStatusEffector caller)
        {
            CombatManager.Instance.AddObserver(new Action<object, object>(this.OnBeingDamageReceived), TriggerCalls.OnBeingDamaged.ToString(), (object)caller);
            CombatManager.Instance.AddObserver(new Action<object, object>(this.OnStatusTriggered), TriggerCalls.OnDamaged.ToString(), (object)caller);
            CombatManager.Instance.AddObserver(new Action<object, object>(this.OnStatusTick), TriggerCalls.OnTurnFinished.ToString(), (object)caller);
        }

        public void OnTriggerDettached(IStatusEffector caller)
        {
            CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnBeingDamageReceived), TriggerCalls.OnBeingDamaged.ToString(), (object)caller);
            CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnStatusTriggered), TriggerCalls.OnDamaged.ToString(), (object)caller);
            CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnStatusTick), TriggerCalls.OnTurnFinished.ToString(), (object)caller);
        }

        private void OnBeingDamageReceived(object sender, object args) => this._NextDamageIsDirect = (args as DamageReceivedValueChangeException).directDamage;

        public void OnSubActionTrigger(object sender, object args, bool stateCheck) => (sender as IUnit).Damage(2, (IUnit)null, DeathType.Rupture, -1, false, false, true, DamageType.Ruptured);

        public void OnStatusTriggered(object sender, object args)
        {
            if (!this._NextDamageIsDirect && UnityEngine.Random.Range(0, 100) < 70)
                this.ReduceDuration(sender as IStatusEffector);
            RandomDamageBetweenTwoAndEntryEffect instance = ScriptableObject.CreateInstance<RandomDamageBetweenTwoAndEntryEffect>();
            instance._indirect = true;
            CombatManager.Instance.AddSubAction((CombatAction)new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1]
            {
        new Effect((EffectSO) instance, 3, new IntentType?(IntentType.Damage_Death), Slots.SlotTarget(new int[2]
        {
          -1,
          1
        }, true))
            }), sender as IUnit));
        }

        public void OnStatusTick(object sender, object args) => this.ReduceDuration(sender as IStatusEffector);

        public void ReduceDuration(IStatusEffector effector)
        {
            if (!this.CanReduceDuration)
                return;
            int duration = this.Duration;
            this.Duration = Mathf.Max(0, this.Duration - 1);
            if (this.TryRemoveStatusEffect(effector) || duration == this.Duration)
                return;
            effector.StatusEffectValuesChanged(this.EffectType, this.Duration - duration);
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
            if (this.Duration > 0 || !this.CanBeRemoved)
                return false;
            effector.RemoveStatusEffect(this.EffectType);
            return true;
        }
    }
    public class ApplyContagionEffect : EffectSO
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
            stats.statusEffectDataBase.TryGetValue((StatusEffectType)305308, out effectInfo);
            for (int index1 = 0; index1 < targets.Length; ++index1)
            {
                if (targets[index1].HasUnit)
                {
                    int num = this._randomBetweenPrevious ? UnityEngine.Random.Range(this.PreviousExitValue, entryVariable + 1) : entryVariable;
                    IStatusEffect contagionStatusEffect = new Contagion_StatusEffect(num);
                    contagionStatusEffect.SetEffectInformation(effectInfo);
                    IStatusEffector unit = targets[index1].Unit as IStatusEffector;
                    bool flag = false;
                    int index2 = 999;
                    for (int index3 = 0; index3 < unit.StatusEffects.Count; ++index3)
                    {
                        if (unit.StatusEffects[index3].EffectType == contagionStatusEffect.EffectType)
                        {
                            index2 = index3;
                            flag = true;
                        }
                    }
                    if (flag == true)
                    {
                        ConstructorInfo[] constructors = unit.StatusEffects[index2].GetType().GetConstructors();
                        foreach (ConstructorInfo constructor in constructors)
                        {
                            if (constructor.GetParameters().Length == 2)
                            {
                                contagionStatusEffect = (IStatusEffect)Activator.CreateInstance(unit.StatusEffects[index2].GetType(), num, 0);
                            }
                        }
                    }

                    contagionStatusEffect.SetEffectInformation(effectInfo);
                    if (targets[index1].Unit.ApplyStatusEffect((IStatusEffect)contagionStatusEffect, num))
                        ++exitAmount;
                }
            }
            return exitAmount > 0;
        }
    }
    public class RandomDamageBetweenTwoAndEntryEffect : EffectSO
    {
        [SerializeField]
        public DeathType _deathType = DeathType.Basic;
        [SerializeField]
        public bool _ignoreShield;
        [SerializeField]
        public bool _indirect;

        public override bool PerformEffect(
          CombatStats stats,
          IUnit caster,
          TargetSlotInfo[] targets,
          bool areTargetSlots,
          int entryVariable,
          out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    int targetSlotOffset = areTargetSlots ? target.SlotID - target.Unit.SlotID : -1;
                    int amount1 = UnityEngine.Random.Range(2, entryVariable + 1);
                    DamageInfo damageInfo;
                    if (this._indirect)
                    {
                        damageInfo = target.Unit.Damage(amount1, (IUnit)null, this._deathType, targetSlotOffset, false, false, true);
                    }
                    else
                    {
                        int amount2 = caster.WillApplyDamage(amount1, target.Unit);
                        damageInfo = target.Unit.Damage(amount2, caster, this._deathType, targetSlotOffset, ignoresShield: this._ignoreShield);
                    }
                    exitAmount += damageInfo.damageAmount;
                }
            }
            if (!this._indirect && exitAmount > 0)
                caster.DidApplyDamage(exitAmount);
            return exitAmount > 0;
        }
    }

}
namespace MFoolModOne
{
    public class Growth_StatusEffect : IStatusEffect, ITriggerEffect<IStatusEffector>
    {
        public int StatusContent => this.Amount;

        public int Restrictor { get; set; }

        public bool CanBeRemoved => this.Restrictor <= 0;

        public bool IsPositive => true;

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

        public StatusEffectType EffectType => (StatusEffectType)30512;

        public StatusEffectInfoSO EffectInfo { get; set; }

        public void SetEffectInformation(StatusEffectInfoSO effectInfo) => this.EffectInfo = effectInfo;

        public bool CanReduceDuration
        {
            get
            {
                BooleanReference result = new BooleanReference(true);
                CombatManager.Instance.ProcessImmediateAction((IImmediateAction)new CheckHasStatusFieldReductionBlockIAction(result));
                return !result.value;
            }
        }

        public Growth_StatusEffect(int amount, int restrictors = 0)
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
            bool flag;
            if (this.Amount <= 0)
            {
                flag = false;
            }
            else
            {
                this.Amount += amount;
                flag = true;
            }
            return flag;
        }

        public int JustRemoveAllContent()
        {
            int amount = this.Amount;
            this.Amount = 0;
            return amount;
        }

        public void OnTriggerAttached(IStatusEffector caller)
        {
            CombatManager.Instance.AddObserver(new Action<object, object>(this.OnDamaged), TriggerCalls.OnDamaged.ToString(), (object)caller);
            CombatManager.Instance.AddObserver(new Action<object, object>(this.Heal), TriggerCalls.OnTurnStart.ToString(), (object)caller);
        }

        public void OnTriggerDettached(IStatusEffector caller)
        {
            CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnDamaged), TriggerCalls.OnDamaged.ToString(), (object)caller);
            CombatManager.Instance.RemoveObserver(new Action<object, object>(this.Heal), TriggerCalls.OnTurnStart.ToString(), (object)caller);
        }

        public void OnSubActionTrigger(object sender, object args, bool stateCheck)
        {
        }

        public void OnDamaged(object sender, object args)
        {
            IntegerReference integerReference = args as IntegerReference;
            this.ReduceDurationHit(sender as IStatusEffector, integerReference.value);
        }

        public void ReduceDurationHit(IStatusEffector effector, int decrease = 0)
        {
            int amount = this.Amount;
            this.Amount -= decrease;
            if (this.TryRemoveStatusEffect(effector) || amount == this.Amount)
                return;
            effector.StatusEffectValuesChanged(this.EffectType, this.Amount - amount);
        }

        public void Heal(object sender, object args)
        {
            (sender as IUnit).Heal(this.Amount, HealType.Heal, true);
            this.ReduceDuration(sender as IStatusEffector);
        }

        public void ReduceDuration(IStatusEffector effector)
        {
            if (!this.CanReduceDuration)
                return;
            int amount = this.Amount;
            this.Amount /= 2;
            if (!this.TryRemoveStatusEffect(effector) && amount != this.Amount)
                effector.StatusEffectValuesChanged(this.EffectType, this.Amount - amount);
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
            bool flag;
            if (this.Amount > 0 || !this.CanBeRemoved)
            {
                flag = false;
            }
            else
            {
                effector.RemoveStatusEffect(this.EffectType);
                flag = true;
            }
            return flag;
        }
    }
    public class ApplyGrowthEffect : EffectSO
    {
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
            stats.statusEffectDataBase.TryGetValue((StatusEffectType)30512, out effectInfo);

            for (int index1 = 0; index1 < targets.Length; ++index1)
            {
                if (targets[index1].HasUnit)
                {
                    IStatusEffect growthStatusEffect = new Growth_StatusEffect(entryVariable);
                    growthStatusEffect.SetEffectInformation(effectInfo);
                    IStatusEffector unit = targets[index1].Unit as IStatusEffector;
                    bool flag = false;
                    int index2 = 999;
                    for (int index3 = 0; index3 < unit.StatusEffects.Count; ++index3)
                    {
                        if (unit.StatusEffects[index3].EffectType == growthStatusEffect.EffectType)
                        {
                            index2 = index3;
                            flag = true;
                        }
                    }
                    if (flag == true)
                    {
                        ConstructorInfo[] constructors = unit.StatusEffects[index2].GetType().GetConstructors();
                        foreach (ConstructorInfo constructor in constructors)
                        {
                            if (constructor.GetParameters().Length == 2)
                            {
                                growthStatusEffect = (IStatusEffect)Activator.CreateInstance(unit.StatusEffects[index2].GetType(), entryVariable, 0);
                            }
                        }
                    }

                    growthStatusEffect.SetEffectInformation(effectInfo);
                    if (targets[index1].Unit.ApplyStatusEffect((IStatusEffect)growthStatusEffect, entryVariable))
                        ++exitAmount;
                }
            }
            return exitAmount > 0;
        }
    }

    public class WildCardModifier : IntValueModifier
    {
        public readonly int WildCardAmount;

        public WildCardModifier(int WildCardAmount)
          : base(69)
        {
            this.WildCardAmount = WildCardAmount;
        }

        public override int Modify(int value)
        {
            int num1 = UnityEngine.Random.Range((this.WildCardAmount - 1) * -1, this.WildCardAmount + 1);
            int num2 = value + num1;
            if (num2 < 1)
                num2 = 1;
            return num2;
        }
    }
    public class WildCard_StatusEffect : IStatusEffect, ITriggerEffect<IStatusEffector>
    {
        public int StatusContent => this.Amount;

        public int Restrictor { get; set; }

        public bool CanBeRemoved => this.Restrictor <= 0;

        public bool IsPositive => true;

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

        public StatusEffectType EffectType => (StatusEffectType)30513;

        public StatusEffectInfoSO EffectInfo { get; set; }

        public void SetEffectInformation(StatusEffectInfoSO effectInfo) => this.EffectInfo = effectInfo;

        public bool CanReduceDuration
        {
            get
            {
                BooleanReference result = new BooleanReference(true);
                CombatManager.Instance.ProcessImmediateAction((IImmediateAction)new CheckHasStatusFieldReductionBlockIAction(result));
                return !result.value;
            }
        }

        public WildCard_StatusEffect(int amount, int restrictors = 0)
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
            bool flag;
            if (this.Amount <= 0)
            {
                flag = false;
            }
            else
            {
                this.Amount += amount;
                flag = true;
            }
            return flag;
        }

        public int JustRemoveAllContent()
        {
            int amount = this.Amount;
            this.Amount = 0;
            return amount;
        }

        public void OnTriggerAttached(IStatusEffector caller) => CombatManager.Instance.AddObserver(new Action<object, object>(this.ChangeDamage), TriggerCalls.OnWillApplyDamage.ToString(), (object)caller);

        public void OnTriggerDettached(IStatusEffector caller) => CombatManager.Instance.RemoveObserver(new Action<object, object>(this.ChangeDamage), TriggerCalls.OnWillApplyDamage.ToString(), (object)caller);

        public void OnSubActionTrigger(object sender, object args, bool stateCheck)
        {
        }

        public void ChangeDamage(object sender, object args) => (args as DamageDealtValueChangeException).AddModifier((IntValueModifier)new WildCardModifier(this.Amount));

        public void BeenHit(object sender, object args) => this.ReduceDurationHit(sender as IStatusEffector);

        public void ReduceDurationHit(IStatusEffector effector, int decrease = 0)
        {
            int amount = this.Amount;
            this.Amount -= UnityEngine.Random.Range(1, this.Amount / 2 + 1);
            if (this.TryRemoveStatusEffect(effector) || amount == this.Amount)
                return;
            effector.StatusEffectValuesChanged(this.EffectType, this.Amount - amount);
        }

        public void LowerAmount(IStatusEffector effector)
        {
            if (!this.CanReduceDuration)
                return;
            int amount = this.Amount;
            this.Amount /= 2;
            if (!this.TryRemoveStatusEffect(effector) && amount != this.Amount)
                effector.StatusEffectValuesChanged(this.EffectType, this.Amount - amount);
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
            bool flag;
            if (this.Amount > 0 || !this.CanBeRemoved)
            {
                flag = false;
            }
            else
            {
                effector.RemoveStatusEffect(this.EffectType);
                flag = true;
            }
            return flag;
        }
    }
    public class ApplyWildCardEffect : EffectSO
    {
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
            stats.statusEffectDataBase.TryGetValue((StatusEffectType)30513, out effectInfo);
            IStatusEffect cardStatusEffect = new WildCard_StatusEffect(entryVariable);
            for (int index1 = 0; index1 < targets.Length; ++index1)
            {
                if (targets[index1].HasUnit)
                {
                    cardStatusEffect.SetEffectInformation(effectInfo);
                    IStatusEffector unit = targets[index1].Unit as IStatusEffector;
                    bool flag = false;
                    int index2 = 999;
                    for (int index3 = 0; index3 < unit.StatusEffects.Count; ++index3)
                    {
                        if (unit.StatusEffects[index3].EffectType == cardStatusEffect.EffectType)
                        {
                            index2 = index3;
                            flag = true;
                        }
                    }
                    if (flag == true)
                    {
                        ConstructorInfo[] constructors = unit.StatusEffects[index2].GetType().GetConstructors();
                        foreach (ConstructorInfo constructor in constructors)
                        {
                            if (constructor.GetParameters().Length == 2)
                            {
                                cardStatusEffect = (IStatusEffect)Activator.CreateInstance(unit.StatusEffects[index2].GetType(), entryVariable, 0);
                            }
                        }
                    }

                    cardStatusEffect.SetEffectInformation(effectInfo);
                    if (targets[index1].Unit.ApplyStatusEffect((IStatusEffect)cardStatusEffect, entryVariable))
                        ++exitAmount;
                }
            }
            return exitAmount > 0;
        }
    }

}
namespace TairbazFools.Effects 
{
    public class DemonicProtection_StatusEffect : IStatusEffect, ITriggerEffect<IStatusEffector>
    {
        public const bool _onlyDirectDamage = true;

        public int StatusContent => this.Duration;

        public int Restrictor { get; set; }

        public bool CanBeRemoved => this.Restrictor <= 0;

        public bool IsPositive => true;

        public string DisplayText
        {
            get
            {
                string displayText = "";
                if (this.Duration > 0)
                    displayText += this.Duration.ToString();
                if (this.Restrictor > 0)
                    displayText = displayText + "(" + this.Restrictor.ToString() + ")";
                return displayText;
            }
        }

        public int Duration { get; set; }

        public StatusEffectType EffectType => (StatusEffectType)666888;

        public StatusEffectInfoSO EffectInfo { get; set; }

        public void SetEffectInformation(StatusEffectInfoSO effectInfo) => this.EffectInfo = effectInfo;

        public bool CanReduceDuration
        {
            get
            {
                BooleanReference result = new BooleanReference(true);
                CombatManager.Instance.ProcessImmediateAction((IImmediateAction)new CheckHasStatusFieldReductionBlockIAction(result));
                return !result.value;
            }
        }

        public DemonicProtection_StatusEffect(int duration, int restrictors = 0)
        {
            this.Duration = duration;
            this.Restrictor = restrictors;
        }

        public bool AddContent(IStatusEffect content)
        {
            this.Duration += content.StatusContent;
            this.Restrictor += content.Restrictor;
            return true;
        }

        public bool TryAddContent(int amount)
        {
            if (this.Duration <= 0)
                return false;
            this.Duration += amount;
            return true;
        }

        public int JustRemoveAllContent()
        {
            int duration = this.Duration;
            this.Duration = 0;
            return duration;
        }

        public void OnTriggerAttached(IStatusEffector caller)
        {
            CombatManager.Instance.AddObserver(new Action<object, object>(this.OnStatusTriggered), TriggerCalls.OnBeingDamaged.ToString(), (object)caller);
            CombatManager.Instance.AddObserver(new Action<object, object>(this.OnStatusTick), TriggerCalls.OnTurnStart.ToString(), (object)caller);
        }

        public void OnTriggerDettached(IStatusEffector caller)
        {
            CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnStatusTriggered), TriggerCalls.OnBeingDamaged.ToString(), (object)caller);
            CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnStatusTick), TriggerCalls.OnTurnStart.ToString(), (object)caller);
        }

        public void DeleteDuration(IStatusEffector effector)
        {
            int duration = this.Duration;
            this.Duration = 0;
            if (this.TryRemoveStatusEffect(effector) || duration == this.Duration)
                return;
            effector.StatusEffectValuesChanged(this.EffectType, this.Duration - duration);
        }

        public void OnSubActionTrigger(object sender, object args, bool stateCheck) => this.DeleteDuration(sender as IStatusEffector);

        public void OnStatusTriggered(object sender, object args)
        {
            (args as DamageReceivedValueChangeException).AddModifier((IntValueModifier)new DemonicProtectionMultiplyIntValueModifier(this.Duration, (sender as IUnit).CurrentHealth));
            if ((sender as IUnit).CurrentHealth - (args as DamageReceivedValueChangeException).amount >= this.Duration)
                return;
            CombatManager.Instance.AddSubAction((CombatAction)new PerformStatusEffectAction((IStatusEffect)this, sender, args, false));
        }

        public void OnStatusTick(object sender, object args) => this.ReduceDuration(sender as IStatusEffector);

        public void ReduceDuration(IStatusEffector effector)
        {
            if (!this.CanReduceDuration)
                return;
            int duration = this.Duration;
            this.Duration = Mathf.Max(0, this.Duration);
            if (this.TryRemoveStatusEffect(effector) || duration == this.Duration)
                return;
            effector.StatusEffectValuesChanged(this.EffectType, this.Duration - duration);
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
            if (this.Duration > 0 || !this.CanBeRemoved)
                return false;
            effector.RemoveStatusEffect(this.EffectType);
            return true;
        }
    }
    public class DemonicProtectionMultiplyIntValueModifier : IntValueModifier
    {
        public readonly int Amount;
        public readonly int Health;

        public DemonicProtectionMultiplyIntValueModifier(int stacksAmount, int unitCurrentHealth)
          : base(70)
        {
            this.Amount = stacksAmount;
            this.Health = unitCurrentHealth;
        }

        public override int Modify(int value)
        {
            if (value > 0 && this.Health - value < this.Amount)
            {
                value = this.Health - this.Amount;
                if (value < 0)
                    value = 0;
            }
            return value;
        }
    }
    public class ApplyDemonicProtectionEffect : EffectSO
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
            bool flag;
            if (entryVariable <= 0)
            {
                flag = false;
            }
            else
            {
                StatusEffectInfoSO effectInfo;
                stats.statusEffectDataBase.TryGetValue((StatusEffectType)666888, out effectInfo);
                stats.statusEffectDataBase.TryGetValue(StatusEffectType.Scars, out StatusEffectInfoSO _);

                for (int index = 0; index < targets.Length; ++index)
                {
                    if (targets[index].HasUnit)
                    {
                        int num = this._randomBetweenPrevious ? UnityEngine.Random.Range(this.PreviousExitValue, entryVariable + 1) : entryVariable;
                        IStatusEffect protectionStatusEffect = new DemonicProtection_StatusEffect(num);
                        protectionStatusEffect.SetEffectInformation(effectInfo);

                        IStatusEffector effector = targets[index].Unit as IStatusEffector;
                        bool hasItAlready = false;
                        int thisIndex = 999;
                        for (int i = 0; i < effector.StatusEffects.Count; i++)
                        {
                            if (effector.StatusEffects[i].EffectType == protectionStatusEffect.EffectType)
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
                                    protectionStatusEffect = (IStatusEffect)Activator.CreateInstance(effector.StatusEffects[thisIndex].GetType(), num, 0);
                                }
                            }
                        }

                        protectionStatusEffect.SetEffectInformation(effectInfo);
                        if (targets[index].Unit.ApplyStatusEffect((IStatusEffect)protectionStatusEffect, num))
                            ++exitAmount;
                    }
                }

                flag = exitAmount > 0;
            }
            return flag;
        }
    }

    public class Marked_StatusEffect : IStatusEffect, ITriggerEffect<IStatusEffector>
    {
        public const int _spotLightMultiplier = 1;
        public const float _postSoundDelay = 0.4f;
        public const bool _onlyDirectDamage = true;

        public int StatusContent => 1;

        public IStatusEffector Effector { get; set; }

        public int Restrictor { get; set; }

        public bool CanBeRemoved => true;

        public bool IsPositive => false;

        public string DisplayText
        {
            get
            {
                string displayText = "";
                if (this.Restrictor > 0)
                    displayText = displayText + "(" + this.Restrictor.ToString() + ")";
                return displayText;
            }
        }

        public StatusEffectType EffectType => (StatusEffectType)399908;

        public StatusEffectInfoSO EffectInfo { get; set; }

        public void SetEffectInformation(StatusEffectInfoSO effectInfo) => this.EffectInfo = effectInfo;

        public bool AddContent(IStatusEffect content) => false;

        public bool TryAddContent(int amount) => false;

        public int JustRemoveAllContent() => 0;

        public void OnTriggerAttached(IStatusEffector caller)
        {
            this.Effector = caller;
            CombatManager.Instance.PostNotification(TriggerCalls.Count.ToString(), (object)null, (object)null);
            CombatManager.Instance.AddObserver(new Action<object, object>(this.OnBeingDamagedTriggered), TriggerCalls.OnBeingDamaged.ToString(), (object)caller);
            CombatManager.Instance.AddObserver(new Action<object, object>(this.OnMarkedTrigered), TriggerCalls.Count.ToString());
        }

        public void OnTriggerDettached(IStatusEffector caller)
        {
            CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnBeingDamagedTriggered), TriggerCalls.OnBeingDamaged.ToString(), (object)caller);
            CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnMarkedTrigered), TriggerCalls.Count.ToString());
        }

        public void OnSubActionTrigger(object sender, object args, bool stateCheck)
        {
        }

        public void OnBeingDamagedTriggered(object sender, object args)
        {
            DamageReceivedValueChangeException valueChangeException = args as DamageReceivedValueChangeException;
            if (!valueChangeException.directDamage)
                return;
            valueChangeException.AddModifier((IntValueModifier)new MarkedReceivedMultiplyIntValueModifier(1, this));
        }

        public void OnMarkedTrigered(object sender, object args) => this.Effector.RemoveStatusEffect(this.EffectType);

        public void DettachRestrictor(IStatusEffector effector)
        {
        }

        public bool TryRemoveStatusEffect(IStatusEffector effector) => false;
    }
    public class MarkedReceivedMultiplyIntValueModifier : IntValueModifier
    {
        private float num = 1.3f;
        public readonly int toMultiply;

        public MarkedReceivedMultiplyIntValueModifier(int toMultiply, Marked_StatusEffect spotLightSE)
          : base(72)
        {
            this.toMultiply = toMultiply;
        }

        public override int Modify(int value) => (int)Math.Ceiling((double)value * (double)this.num);
    }
    public class ApplyMarkedEffect : EffectSO
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
            bool flag;
            if (entryVariable <= 0)
            {
                flag = false;
            }
            else
            {
                StatusEffectInfoSO effectInfo;
                stats.statusEffectDataBase.TryGetValue((StatusEffectType)399908, out effectInfo);
                stats.statusEffectDataBase.TryGetValue(StatusEffectType.Scars, out StatusEffectInfoSO _);
                if (this._justOneTarget)
                {
                    List<TargetSlotInfo> targetSlotInfoList = new List<TargetSlotInfo>((IEnumerable<TargetSlotInfo>)targets);
                    for (int index = targetSlotInfoList.Count - 1; index >= 0; --index)
                    {
                        if (!targetSlotInfoList[index].HasUnit)
                            targetSlotInfoList.RemoveAt(index);
                    }
                    if (targetSlotInfoList.Count > 0)
                    {
                        int index = UnityEngine.Random.Range(0, targetSlotInfoList.Count);
                        int amount = this._randomBetweenPrevious ? UnityEngine.Random.Range(this.PreviousExitValue, entryVariable + 1) : entryVariable;
                        Marked_StatusEffect markedStatusEffect = new Marked_StatusEffect();
                        markedStatusEffect.SetEffectInformation(effectInfo);
                        if (targetSlotInfoList[index].Unit.ApplyStatusEffect((IStatusEffect)markedStatusEffect, amount))
                            exitAmount += amount;
                    }
                }
                else
                {
                    for (int index = 0; index < targets.Length; ++index)
                    {
                        if (targets[index].HasUnit)
                        {
                            int amount = this._randomBetweenPrevious ? UnityEngine.Random.Range(this.PreviousExitValue, entryVariable + 1) : entryVariable;
                            Marked_StatusEffect markedStatusEffect = new Marked_StatusEffect();
                            markedStatusEffect.SetEffectInformation(effectInfo);
                            if (targets[index].Unit.ApplyStatusEffect((IStatusEffect)markedStatusEffect, amount))
                                ++exitAmount;
                        }
                    }
                }
                flag = exitAmount > 0;
            }
            return flag;
        }
    }

}
namespace DigiMisfits
{

    public class Invigorated_StatusEffect : IStatusEffect, ITriggerEffect<IStatusEffector>
    {
        public int StatusContent => this.Amount;

        public int Restrictor { get; set; }

        public bool CanBeRemoved => this.Restrictor <= 0;

        public bool IsPositive => true;

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

        public StatusEffectType EffectType => (StatusEffectType)84951260;

        public StatusEffectInfoSO EffectInfo { get; set; }

        public void SetEffectInformation(StatusEffectInfoSO effectInfo) => this.EffectInfo = effectInfo;

        public bool CanReduceDuration
        {
            get
            {
                BooleanReference result = new BooleanReference(true);
                CombatManager.Instance.ProcessImmediateAction((IImmediateAction)new CheckHasStatusFieldReductionBlockIAction(result));
                return !result.value;
            }
        }

        public Invigorated_StatusEffect(int amount, int restrictors = 0)
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
            bool flag;
            if (this.Amount <= 0)
            {
                flag = false;
            }
            else
            {
                this.Amount += amount;
                flag = true;
            }
            return flag;
        }

        public int JustRemoveAllContent()
        {
            int amount = this.Amount;
            this.Amount = 0;
            return amount;
        }

        public void OnTriggerAttached(IStatusEffector caller)
        {
            CombatManager.Instance.AddObserver(new Action<object, object>(this.OnStatusTriggered), TriggerCalls.OnMoved.ToString(), (object)caller);
            CombatManager.Instance.AddObserver(new Action<object, object>(this.OnStatusTick), TriggerCalls.OnTurnFinished.ToString(), (object)caller);
        }

        public void OnTriggerDettached(IStatusEffector caller)
        {
            CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnStatusTriggered), TriggerCalls.OnMoved.ToString(), (object)caller);
            CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnStatusTick), TriggerCalls.OnTurnFinished.ToString(), (object)caller);
        }

        public void OnSubActionTrigger(object sender, object args, bool stateCheck) => (sender as IUnit).Heal(2, HealType.Heal, true);

        public void OnStatusTriggered(object sender, object args) => CombatManager.Instance.AddSubAction((CombatAction)new PerformStatusEffectAction((IStatusEffect)this, sender, args, false));

        public void OnStatusTick(object sender, object args) => this.ReduceDuration(sender as IStatusEffector);

        public void ReduceDuration(IStatusEffector effector)
        {
            if (!this.CanReduceDuration)
                return;
            int amount = this.Amount;
            this.Amount = Mathf.Max(0, this.Amount - 1);
            if (this.TryRemoveStatusEffect(effector) || amount == this.Amount)
                return;
            effector.StatusEffectValuesChanged(this.EffectType, this.Amount - amount);
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
    public class ApplyInvigoratedEffect : EffectSO
    {
        public override bool PerformEffect(
          CombatStats stats,
          IUnit caster,
          TargetSlotInfo[] targets,
          bool areTargetSlots,
          int entryVariable,
          out int exitAmount)
        {
            exitAmount = 0;
            bool flag1;
            if (entryVariable <= 0)
            {
                flag1 = false;
            }
            else
            {
                StatusEffectInfoSO effectInfo;
                stats.statusEffectDataBase.TryGetValue((StatusEffectType)84951260, out effectInfo);
                IStatusEffect invigoratedStatusEffect = new Invigorated_StatusEffect(entryVariable);
                for (int index1 = 0; index1 < targets.Length; ++index1)
                {
                    if (targets[index1].HasUnit)
                    {
                        invigoratedStatusEffect.SetEffectInformation(effectInfo);
                        IStatusEffector unit = targets[index1].Unit as IStatusEffector;
                        bool flag2 = false;
                        int index2 = 999;
                        for (int index3 = 0; index3 < unit.StatusEffects.Count; ++index3)
                        {
                            if (unit.StatusEffects[index3].EffectType == invigoratedStatusEffect.EffectType)
                            {
                                index2 = index3;
                                flag2 = true;
                            }
                        }
                        if (flag2 == true)
                        {
                            ConstructorInfo[] constructors = unit.StatusEffects[index2].GetType().GetConstructors();
                            foreach (ConstructorInfo constructor in constructors)
                            {
                                if (constructor.GetParameters().Length == 2)
                                {
                                    invigoratedStatusEffect = (IStatusEffect)Activator.CreateInstance(unit.StatusEffects[index2].GetType(), entryVariable, 0);
                                }
                            }
                        }

                        invigoratedStatusEffect.SetEffectInformation(effectInfo);
                        if (targets[index1].Unit.ApplyStatusEffect((IStatusEffect)invigoratedStatusEffect, entryVariable))
                            ++exitAmount;
                    }
                }
                flag1 = exitAmount > 0;
            }
            return flag1;
        }
    }

}
namespace ChillyBonezMod
{
    public class Adrenaline_StatusEffect : IStatusEffect, ITriggerEffect<IStatusEffector>
    {
        /*[CompilerGenerated]
        public int \u003CRestrictor\u003Ek__BackingField;
        [CompilerGenerated]
        public int \u003CAmount\u003Ek__BackingField;
        [CompilerGenerated]*/
        //public StatusEffectInfoSO \u003CEffectInfo\u003Ek__BackingField;

        public int StatusContent => this.Amount;

        public int Restrictor { get; set; }

        public bool CanBeRemoved => this.Restrictor <= 0;

        public bool IsPositive => true;

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

        public StatusEffectType EffectType => (StatusEffectType)444442;

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

        public Adrenaline_StatusEffect(int amount, int restrictors = 0)
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
            CombatManager.Instance.AddObserver(new Action<object, object>(this.OnStatusTriggered), TriggerCalls.OnWillApplyDamage.ToString(), caller);
            //CombatManager.Instance.AddObserver(new Action<object, object>(this.OnTurnEnd), TriggerCalls.OnTurnFinished.ToString(), caller);
        }

        public void OnTriggerDettached(IStatusEffector caller)
        {
            CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnStatusTriggered), TriggerCalls.OnWillApplyDamage.ToString(), caller);
            //CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnTurnEnd), TriggerCalls.OnTurnFinished.ToString(), caller);
        }

        public void OnSubActionTrigger(object sender, object args, bool stateCheck)
        {

        }

        public void OnStatusTriggered(object sender, object args)
        {

            (args as DamageDealtValueChangeException).AddModifier((IntValueModifier)new AdrenalineValueModifier());
            this.ReduceDuration(sender as IStatusEffector);

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
            int duration = this.Amount;
            this.Amount = Mathf.Max(0, this.Amount - 1);
            if (!this.TryRemoveStatusEffect(effector) && duration != this.Amount)
            {
                effector.StatusEffectValuesChanged(this.EffectType, this.Amount - duration);
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
    public class AdrenalineValueModifier : IntValueModifier
    {
        public readonly decimal toPow;

        public AdrenalineValueModifier()
          : base(70)
        {
            this.toPow = 3;
            this.toPow /= 10;
            Debug.Log(this.toPow);
            this.toPow += 1;
            Debug.Log(this.toPow);
        }

        public override int Modify(int value)
        {
            decimal hitVal = (decimal)value;
            hitVal *= toPow;
            Debug.Log(hitVal);
            decimal gap = Math.Ceiling(hitVal);
            Debug.Log(gap);
            value = (int)gap;
            return value;
        }
    }
    public class ApplyAdrenalineEffect : EffectSO
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
            stats.statusEffectDataBase.TryGetValue((StatusEffectType)444442, out effectInfo);




            for (int index = 0; index < targets.Length; ++index)
            {
                if (targets[index].HasUnit)
                {
                    int amount = this._randomBetweenPrevious ? UnityEngine.Random.Range(this.PreviousExitValue, entryVariable + 1) : entryVariable;
                    IStatusEffect adrenaline = new Adrenaline_StatusEffect(amount);

                    adrenaline.SetEffectInformation(effectInfo);
                    IStatusEffector effector = targets[index].Unit as IStatusEffector;
                    bool hasItAlready = false;
                    int thisIndex = 999;
                    for (int i = 0; i < effector.StatusEffects.Count; i++)
                    {
                        if (effector.StatusEffects[i].EffectType == adrenaline.EffectType)
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
                                adrenaline = (IStatusEffect)Activator.CreateInstance(effector.StatusEffects[thisIndex].GetType(), amount, 0);
                            }
                        }
                    }

                    adrenaline.SetEffectInformation(effectInfo);
                    if (targets[index].Unit.ApplyStatusEffect((IStatusEffect)adrenaline, amount))
                        ++exitAmount;
                }
            }

            return exitAmount > 0;
        }
    }

    public class Hexed_StatusEffect : IStatusEffect, ITriggerEffect<IStatusEffector>
    {
        /*[CompilerGenerated]
        public int \u003CRestrictor\u003Ek__BackingField;
        [CompilerGenerated]
        public int \u003CAmount\u003Ek__BackingField;
        [CompilerGenerated]*/
        //public StatusEffectInfoSO \u003CEffectInfo\u003Ek__BackingField;

        public int StatusContent => this.Amount;

        public int Restrictor { get; set; }

        public bool CanBeRemoved => this.Restrictor <= 0;

        public bool IsPositive => true;

        public bool hasActed = false;

        public string DisplayText
        {
            get
            {
                string displayText = "";
                if (this.Amount > 0)
                    displayText = displayText;
                if (this.Restrictor > 0)
                    displayText = displayText + "(" + this.Restrictor.ToString() + ")";
                return displayText;
            }
        }

        public int Amount { get; set; }

        public StatusEffectType EffectType => (StatusEffectType)444440;

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

        public Hexed_StatusEffect(int amount, int restrictors = 0)
        {
            this.Amount = amount;
            this.Restrictor = restrictors;
        }

        public bool AddContent(IStatusEffect content)
        {
            this.Amount += (content as Hexed_StatusEffect).Amount;
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
            CombatManager.Instance.AddObserver(new Action<object, object>(this.OnStatusTriggered), TriggerCalls.OnWillApplyDamage.ToString(), caller);
            CombatManager.Instance.AddObserver(new Action<object, object>(this.OnStatusFinished), TriggerCalls.OnDidApplyDamage.ToString(), caller);
            //CombatManager.Instance.AddObserver(new Action<object, object>(this.OnCanHeal), TriggerCalls.CanHeal.ToString(), caller);
            CombatManager.Instance.AddObserver(new Action<object, object>(this.OnActionDone), TriggerCalls.OnWillApplyDamage.ToString(), caller);
            CombatManager.Instance.AddObserver(new Action<object, object>(this.OnBeingHit), TriggerCalls.OnDirectDamaged.ToString(), caller);
            CombatManager.Instance.AddObserver(new Action<object, object>(this.HasActedBool), TriggerCalls.OnAbilityUsed.ToString(), caller);
            CombatManager.Instance.AddObserver(new Action<object, object>(this.TurnFinished), TriggerCalls.OnTurnFinished.ToString(), caller);
            //CombatManager.Instance.AddObserver(new Action<object, object>(this.OnTurnEnd), TriggerCalls.OnTurnFinished.ToString(), caller);
            (caller as IUnit).SetStoredValue((UnitStoredValueNames)444440, 3);
        }

        public void OnTriggerDettached(IStatusEffector caller)
        {
            CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnStatusTriggered), TriggerCalls.OnWillApplyDamage.ToString(), caller);
            CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnStatusFinished), TriggerCalls.OnDidApplyDamage.ToString(), caller);
            //CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnCanHeal), TriggerCalls.CanHeal.ToString(), caller);
            CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnActionDone), TriggerCalls.OnWillApplyDamage.ToString(), caller);
            CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnBeingHit), TriggerCalls.OnDirectDamaged.ToString(), caller);
            CombatManager.Instance.RemoveObserver(new Action<object, object>(this.HasActedBool), TriggerCalls.OnAbilityUsed.ToString(), caller);
            CombatManager.Instance.RemoveObserver(new Action<object, object>(this.TurnFinished), TriggerCalls.OnTurnFinished.ToString(), caller);
            //CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnTurnEnd), TriggerCalls.OnTurnFinished.ToString(), caller);
            (caller as IUnit).SetStoredValue((UnitStoredValueNames)444440, 0);
        }

        public void OnSubActionTrigger(object sender, object args, bool stateCheck)
        {

        }

        public void OnBeingHit(object sender, object args)
        {
            this.DeleteDuration(sender as IStatusEffector);
        }

        public void HasActedBool(object sender, object args)
        {
            this.hasActed = true;
        }

        public void TurnFinished(object sender, object args)
        {
            if (this.hasActed != true)
            {
                this.DeleteDuration(sender as IStatusEffector);
            }
            else
            {
                this.hasActed = false;
            }
        }

        public void DeleteDuration(IStatusEffector effector)
        {

            int duration = this.Amount;
            this.Amount = 0;
            if (!this.TryRemoveStatusEffect(effector) && duration != this.Amount)
            {
                effector.StatusEffectValuesChanged(this.EffectType, this.Amount - duration);
            }
        }

        public void OnActionDone(object sender, object args)
        {
            if (sender is IUnit unit)
            {
                ChangeMaxHealthEffect maxDec = ScriptableObject.CreateInstance<ChangeMaxHealthEffect>();
                maxDec._increase = false;
                Effect decMHP = new Effect(maxDec, 3, new IntentType?(), Slots.Self);
                CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { decMHP }), unit));
            }
        }

        public void OnStatusFinished(object sender, object args)
        {
            if (sender is IUnit unit)
            {
                int value = unit.GetStoredValue((UnitStoredValueNames)444440);
                value += 3;
                unit.SetStoredValue((UnitStoredValueNames)444440, value);
            }
        }

        public void OnCanHeal(object sender, object args)
        {
            if (sender is IUnit unit)
            {
                if (args is CanHealReference canHealReference)
                {
                    CombatManager.Instance.AddUIAction((CombatAction)new ShowPassiveInformationUIAction(unit.ID, unit.IsUnitCharacter, "Hexed"));
                    canHealReference.value = false;
                }

            }
        }

        public void OnStatusTriggered(object sender, object args)
        {

            if (sender is IUnit unit)
            {
                int damageBoost = unit.GetStoredValue((UnitStoredValueNames)444440);
                //damageBoost += 3;
                (args as DamageDealtValueChangeException).AddModifier((IntValueModifier)new HexedValueModifier(damageBoost));

            }
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
            int duration = this.Amount;
            this.Amount = Mathf.Max(0, this.Amount - 1);
            if (!this.TryRemoveStatusEffect(effector) && duration != this.Amount)
            {
                effector.StatusEffectValuesChanged(this.EffectType, this.Amount - duration);
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
    public class HexedValueModifier : IntValueModifier
    {
        public readonly int toPow;

        public HexedValueModifier(int ToPow)
          : base(70)
        {
            this.toPow = ToPow;
        }

        public override int Modify(int value)
        {
            value += this.toPow;
            return value;
        }
    }
    public class ApplyHexedEffect : EffectSO
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
            stats.statusEffectDataBase.TryGetValue((StatusEffectType)444440, out effectInfo);




            for (int index = 0; index < targets.Length; ++index)
            {
                if (targets[index].HasUnit)
                {
                    int amount = this._randomBetweenPrevious ? UnityEngine.Random.Range(this.PreviousExitValue, entryVariable + 1) : entryVariable;
                    IStatusEffect statusEffect = new Hexed_StatusEffect(amount);

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
}
