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
using static UnityEngine.EventSystems.EventTrigger;

namespace Hawthorne.NewFolder
{
    public class Effects
    {
        public static void Add() { Debug.Log("is"); Debug.Log("MOTHER FUCK !"); }
    }
    public class LeakyRandomEffect : EffectSO
    {
        [SerializeField]
        public bool _usePreviousExitValue;
        [SerializeField]
        public bool _ignoreShield;
        [SerializeField]
        public bool _indirect;
        public int _scars;

        public override bool PerformEffect(
          CombatStats stats,
          IUnit caster,
          TargetSlotInfo[] targets,
          bool areTargetSlots,
          int entryVariable,
          out int exitAmount)
        {
            if (this._usePreviousExitValue)
                entryVariable *= this.PreviousExitValue;
            exitAmount = 0;
            List<TargetSlotInfo> targetSlotInfoList = new List<TargetSlotInfo>();
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit && target.Unit != caster)
                    targetSlotInfoList.Add(target);
            }
            if (targetSlotInfoList.Count <= 0)
                return false;
            int index = UnityEngine.Random.Range(0, targetSlotInfoList.Count);
            TargetSlotInfo targetSlotInfo = targetSlotInfoList[index];


            AddPassiveEffect leakIt = ScriptableObject.CreateInstance<AddPassiveEffect>();
            leakIt._passiveToAdd = Passives.Leaky;

            Effect PaleIt = new Effect(leakIt, 1, null, Slots.Self);
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { PaleIt }), targetSlotInfo.Unit));


            return exitAmount > 0;
        }
    }
    public class ApplyInvertedIfNotUnStitchedEffect : EffectSO
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
            stats.statusEffectDataBase.TryGetValue((StatusEffectType)846749, out effectInfo);




            for (int index = 0; index < targets.Length; ++index)
            {
                if (targets[index].HasUnit && !(targets[index].Unit.ContainsStatusEffect((StatusEffectType)846748)))
                {
                    int amount = this._randomBetweenPrevious ? UnityEngine.Random.Range(this.PreviousExitValue, entryVariable + 1) : entryVariable;
                    Inverted_StatusEffect statuseffect = new Inverted_StatusEffect(amount);

                    statuseffect.SetEffectInformation(effectInfo);
                    IStatusEffector effector = targets[index].Unit as IStatusEffector;
                    bool hasItAlready = false;
                    int thisIndex = 999;
                    for (int i = 0; i < effector.StatusEffects.Count; i++)
                    {
                        if (effector.StatusEffects[i].EffectType == statuseffect.EffectType)
                        {
                            thisIndex = i;
                            hasItAlready = true;
                        }
                    }
                    if (hasItAlready == true)
                    {
                        effector.StatusEffects[thisIndex].TryAddContent(amount);
                        effector.StatusEffectValuesChanged(effector.StatusEffects[thisIndex].EffectType, amount);
                        CombatManager.Instance.AddUIAction(new PlayStatusEffectPopupUIAction(targets[index].Unit.ID, targets[index].Unit.IsUnitCharacter, amount, effector.StatusEffects[thisIndex].EffectInfo, StatusFieldEffectPopUpType.Number));
                        exitAmount += amount;
                    }
                    else if (targets[index].Unit.ApplyStatusEffect((IStatusEffect)statuseffect, amount))
                        ++exitAmount;
                }
            }

            return exitAmount > 0;
        }
    }
    public class RemoveAllStatusEffectsExceptInvertedAndUnstitchedEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i].HasUnit)
                {
                    List<StatusEffectType> statuses = new List<StatusEffectType>();
                    foreach (IStatusEffect status in (targets[i].Unit as IStatusEffector).StatusEffects)
                    {
                        if (status.EffectType != (StatusEffectType)846748 && status.EffectType != (StatusEffectType)846749)
                        {
                            statuses.Add(status.EffectType);
                        }
                    }
                    if (statuses.Count > 0)
                    {
                        foreach (StatusEffectType type in statuses)
                        {

                            targets[i].Unit.TryRemoveStatusEffect(type);
                        }
                    }
                }
            }

            return exitAmount > 0;
        }
    }

    //moves
    public class RupturedBleedingLeftEffect : EffectSO
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


            GenericTargetting_BySlot_Index positional = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
            positional.getAllies = false;
            positional.slotPointerDirections = new int[] { 2 };


            GenericTargetting_BySlot_Index EXpositional = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
            EXpositional.getAllies = false;
            EXpositional.slotPointerDirections = new int[] { 0, 1 };

            GenericTargetting_BySlot_Index AnimPositional = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
            AnimPositional.getAllies = false;
            AnimPositional.slotPointerDirections = new int[] { 0, 1, 2 };

            AnimationVisualsEffect anim = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            anim._visuals = LoadedAssetsHandler.GetEnemyAbility("FlayTheFlesh_A").visuals;
            anim._animationTarget = AnimPositional;

            Effect yayAnim = new Effect(anim, 1, null, Slots.Self);
            Effect effort0 = new Effect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 2, null, positional);
            Effect effort1 = new Effect(ScriptableObject.CreateInstance<ApplyBleedingEffect>(), 3, null, EXpositional);
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[3] { yayAnim, effort0, effort1 }), caster));

            return exitAmount > 0;
        }
    }
    public class RupturedBleedingRightEffect : EffectSO
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

            GenericTargetting_BySlot_Index positional = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
            positional.getAllies = false;
            positional.slotPointerDirections = new int[] { 2 };


            GenericTargetting_BySlot_Index EXpositional = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
            EXpositional.getAllies = false;
            EXpositional.slotPointerDirections = new int[] { 3, 4 };

            GenericTargetting_BySlot_Index AnimPositional = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
            AnimPositional.getAllies = false;
            AnimPositional.slotPointerDirections = new int[] { 2, 3, 4 };

            AnimationVisualsEffect anim = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            anim._visuals = LoadedAssetsHandler.GetEnemyAbility("FlayTheFlesh_A").visuals;
            anim._animationTarget = AnimPositional;

            Effect yayAnim = new Effect(anim, 1, null, Slots.Self);
            Effect effort0 = new Effect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 2, null, positional);
            Effect effort1 = new Effect(ScriptableObject.CreateInstance<ApplyBleedingEffect>(), 3, null, EXpositional);
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[3] { yayAnim, effort0, effort1 }), caster));

            return exitAmount > 0;
        }
    }
    public class DPDSEffect : EffectSO
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

            GenericTargetting_BySlot_Index positional = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
            positional.getAllies = false;
            positional.slotPointerDirections = new int[] { 2 };


            GenericTargetting_BySlot_Index EXpositional = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
            EXpositional.getAllies = false;
            EXpositional.slotPointerDirections = new int[] { 0, 4 };

            GenericTargetting_BySlot_Index AnimPositional = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
            AnimPositional.getAllies = false;
            AnimPositional.slotPointerDirections = new int[] { 0, 2, 4 };

            AnimationVisualsEffect anim = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            anim._visuals = LoadedAssetsHandler.GetEnemy("HeavensGateRed_BOSS").abilities[1].ability.visuals;
            anim._animationTarget = AnimPositional;

            Effect yayAnim = new Effect(anim, 1, null, Slots.Self);
            Effect effort0 = new Effect(ScriptableObject.CreateInstance<ApplyDivineSacrificeEffect>(), 3, null, positional);
            Effect effort1 = new Effect(ScriptableObject.CreateInstance<ApplyDivineProtectionEffect>(), 3, null, EXpositional);
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[3] { yayAnim, effort0, effort1 }), caster));

            return exitAmount > 0;
        }
    }
    public class SinAllEffect : EffectSO
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

            GenericTargetting_BySlot_Index positional = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
            positional.getAllies = false;
            positional.slotPointerDirections = new int[] { 2 };


            GenericTargetting_BySlot_Index EXpositional = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
            EXpositional.getAllies = false;
            EXpositional.slotPointerDirections = new int[] { 0, 4 };

            Targetting_ByUnit_Side allEnemy = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            allEnemy.getAllies = false;
            allEnemy.getAllUnitSlots = false;

            GenericTargetting_BySlot_Index AnimPositional = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
            AnimPositional.getAllies = false;
            AnimPositional.slotPointerDirections = new int[] { 0, 2, 4 };

            AnimationVisualsEffect anim = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            anim._visuals = LoadedAssetsHandler.GetEnemy("HeavensGateRed_BOSS").abilities[1].ability.visuals;
            anim._animationTarget = allEnemy;

            Effect yayAnim = new Effect(anim, 1, null, Slots.Self);
            Effect effort0 = new Effect(ScriptableObject.CreateInstance<ApplySinEffect>(), 1, null, allEnemy);
            Effect effort1 = new Effect(ScriptableObject.CreateInstance<ApplyDivineProtectionEffect>(), 3, null, EXpositional);
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[2] { yayAnim, effort0 }), caster));

            return exitAmount > 0;
        }
    }
    public class OilLeftRightEffect : EffectSO
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

            GenericTargetting_BySlot_Index positional = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
            positional.getAllies = false;
            positional.slotPointerDirections = new int[] { 2 };


            GenericTargetting_BySlot_Index EXpositional = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
            EXpositional.getAllies = false;
            EXpositional.slotPointerDirections = new int[] { 0, 4 };

            Targetting_ByUnit_Side allEnemy = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            allEnemy.getAllies = false;
            allEnemy.getAllUnitSlots = false;

            GenericTargetting_BySlot_Index AnimPositional = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
            AnimPositional.getAllies = false;
            AnimPositional.slotPointerDirections = new int[] { 0, 2, 4 };

            AnimationVisualsEffect anim = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            anim._visuals = LoadedAssetsHandler.GetEnemyAbility("Weep_A").visuals;
            anim._animationTarget = Slots.LeftRight;

            Effect yayAnim = new Effect(anim, 1, null, Slots.Self);
            Effect effort0 = new Effect(ScriptableObject.CreateInstance<ApplyOilSlickedEffect>(), 3, null, Slots.LeftRight);
            Effect effort1 = new Effect(ScriptableObject.CreateInstance<ApplyDivineProtectionEffect>(), 3, null, EXpositional);
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[2] { yayAnim, effort0 }), caster));

            return exitAmount > 0;
        }
    }
    public class OilFrontLeftRightEffect : EffectSO
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

            GenericTargetting_BySlot_Index positional = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
            positional.getAllies = false;
            positional.slotPointerDirections = new int[] { 2 };


            GenericTargetting_BySlot_Index EXpositional = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
            EXpositional.getAllies = false;
            EXpositional.slotPointerDirections = new int[] { 0, 4 };

            Targetting_ByUnit_Side allEnemy = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            allEnemy.getAllies = false;
            allEnemy.getAllUnitSlots = false;

            GenericTargetting_BySlot_Index AnimPositional = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
            AnimPositional.getAllies = false;
            AnimPositional.slotPointerDirections = new int[] { 0, 2, 4 };

            AnimationVisualsEffect anim = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            anim._visuals = LoadedAssetsHandler.GetEnemyAbility("Weep_A").visuals;
            anim._animationTarget = Slots.FrontLeftRight;

            Effect yayAnim = new Effect(anim, 1, null, Slots.Self);
            Effect effort0 = new Effect(ScriptableObject.CreateInstance<ApplyOilSlickedEffect>(), 1, null, Slots.FrontLeftRight);
            Effect effort1 = new Effect(ScriptableObject.CreateInstance<ApplyDivineProtectionEffect>(), 3, null, EXpositional);
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[2] { yayAnim, effort0 }), caster));

            return exitAmount > 0;
        }
    }
    public class FireFrontEffect : EffectSO
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

            GenericTargetting_BySlot_Index positional = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
            positional.getAllies = false;
            positional.slotPointerDirections = new int[] { 2 };


            GenericTargetting_BySlot_Index EXpositional = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
            EXpositional.getAllies = false;
            EXpositional.slotPointerDirections = new int[] { 0, 4 };

            Targetting_ByUnit_Side allEnemy = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            allEnemy.getAllies = false;
            allEnemy.getAllUnitSlots = false;

            int rando = UnityEngine.Random.Range(1, 4);


            GenericTargetting_BySlot_Index AnimPositional = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
            AnimPositional.getAllies = false;
            AnimPositional.slotPointerDirections = new int[] { 0, 2, 4 };

            AnimationVisualsEffect anim = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            anim._visuals = LoadedAssetsHandler.GetCharacterAbility("Torch_1_A").visuals;
            anim._animationTarget = Slots.Front;

            Effect yayAnim = new Effect(anim, 1, null, Slots.Self);
            Effect effort0 = new Effect(ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), rando, null, Slots.Front);
            Effect effort1 = new Effect(ScriptableObject.CreateInstance<ApplyDivineProtectionEffect>(), 3, null, EXpositional);
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[2] { yayAnim, effort0 }), caster));

            return exitAmount > 0;
        }
    }
    public class AllergyFarLeakyRandomEffect : EffectSO
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

            GenericTargetting_BySlot_Index positional = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
            positional.getAllies = false;
            positional.slotPointerDirections = new int[] { 2 };


            GenericTargetting_BySlot_Index EXpositional = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
            EXpositional.getAllies = false;
            EXpositional.slotPointerDirections = new int[] { 0, 4 };

            Targetting_ByUnit_Side allEnemy = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            allEnemy.getAllies = false;
            allEnemy.getAllUnitSlots = false;

            Targetting_ByUnit_Side allAlly = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            allAlly.getAllies = true;
            allAlly.getAllUnitSlots = false;

            int rando = UnityEngine.Random.Range(1, 3);

            GenericTargetting_BySlot_Index AnimPositional = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
            AnimPositional.getAllies = false;
            AnimPositional.slotPointerDirections = new int[] { 0, 2, 4 };

            AnimationVisualsEffect anim = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            anim._visuals = LoadedAssetsHandler.GetEnemyAbility("UglyOnTheInside_A").visuals;
            anim._animationTarget = Slots.SlotTarget(new int[2] { 2, -2 }, false);

            Effect yayAnim = new Effect(anim, 1, null, Slots.Self);
            Effect effort0 = new Effect(ScriptableObject.CreateInstance<ApplyPaintAllergyEffect>(), 4, null, Slots.SlotTarget(new int[2] {2, -2}, false));
            Effect effort1 = new Effect(ScriptableObject.CreateInstance<LeakyRandomEffect>(), 1, null, allAlly);
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[3] { yayAnim, effort0, effort1 }), caster));

            return exitAmount > 0;
        }
    }
    public class WeepEffect : EffectSO
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

            GenericTargetting_BySlot_Index positional = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
            positional.getAllies = false;
            positional.slotPointerDirections = new int[] { 2 };


            GenericTargetting_BySlot_Index EXpositional = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
            EXpositional.getAllies = false;
            EXpositional.slotPointerDirections = new int[] { 0, 4 };

            Targetting_ByUnit_Side allEnemy = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            allEnemy.getAllies = false;
            allEnemy.getAllUnitSlots = false;

            Targetting_ByUnit_Side allAlly = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            allEnemy.getAllies = true;
            allEnemy.getAllUnitSlots = false;

            int rando = UnityEngine.Random.Range(1, 3);

            GenerateColorManaEffect weep = ScriptableObject.CreateInstance<GenerateColorManaEffect>();
            weep.mana = Pigments.Blue;

            GenericTargetting_BySlot_Index AnimPositional = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
            EXpositional.getAllies = false;
            EXpositional.slotPointerDirections = new int[] { 0, 2, 4 };

            AnimationVisualsEffect anim = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            anim._visuals = LoadedAssetsHandler.GetEnemyAbility("Weep_A").visuals;
            anim._animationTarget = Slots.Self;

            Effect yayAnim = new Effect(anim, 1, null, Slots.Self);
            Effect effort0 = new Effect(weep, 3, null, Slots.Self);
            Effect effort1 = new Effect(ScriptableObject.CreateInstance<LeakyRandomEffect>(), 1, null, allAlly);
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[2] { yayAnim, effort0 }), caster));

            return exitAmount > 0;
        }
    }
    public class Phase3BonusAttackEffect : EffectSO
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

            GenericTargetting_BySlot_Index positional = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
            positional.getAllies = false;
            positional.slotPointerDirections = new int[] { 2 };


            GenericTargetting_BySlot_Index EXpositional = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
            EXpositional.getAllies = false;
            EXpositional.slotPointerDirections = new int[] { 0, 4 };

            Targetting_ByUnit_Side allEnemy = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            allEnemy.getAllies = false;
            allEnemy.getAllUnitSlots = false;

            Targetting_ByUnit_Side allAlly = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            allEnemy.getAllies = true;
            allEnemy.getAllUnitSlots = false;

            int rando = UnityEngine.Random.Range(1, 3);

            GenerateColorManaEffect weep = ScriptableObject.CreateInstance<GenerateColorManaEffect>();
            weep.mana = Pigments.Blue;

            ChangeMaxHealthEffect decMax = ScriptableObject.CreateInstance<ChangeMaxHealthEffect>();
            decMax._increase = false;

            GenericTargetting_BySlot_Index AnimPositional = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
            EXpositional.getAllies = false;
            EXpositional.slotPointerDirections = new int[] { 0, 2, 4 };

            AnimationVisualsEffect anim = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            anim._visuals = LoadedAssetsHandler.GetEnemyAbility("DrippingsOfTheGarden_A").visuals;
            anim._animationTarget = positional;

            Effect yayAnim = new Effect(anim, 1, null, Slots.Self);
            Effect effort0 = new Effect(ScriptableObject.CreateInstance<ApplyInvertedIfNotUnStitchedEffect>(), 30, null, positional);
            Effect effort1 = new Effect(ScriptableObject.CreateInstance<RemoveAllStatusEffectsExceptInvertedAndUnstitchedEffect>(), 1, null, positional);
            Effect effort2 = new Effect(decMax, 5, null, positional);
            Effect effort3 = new Effect(ScriptableObject.CreateInstance<SpawnPhase3EnemiesEffect>(), 3, null, Slots.Self);
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[5] { yayAnim, effort0, effort1, effort2, effort3 }), caster));

            return exitAmount > 0;
        }
    }

    //sannes under tall e
    public class SpawnPhase3EnemiesEffect : EffectSO
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

            GenericTargetting_BySlot_Index positional = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
            positional.getAllies = false;
            positional.slotPointerDirections = new int[] { 2 };


            GenericTargetting_BySlot_Index EXpositional = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
            EXpositional.getAllies = false;
            EXpositional.slotPointerDirections = new int[] { 0, 4 };

            Targetting_ByUnit_Side allEnemy = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            allEnemy.getAllies = false;
            allEnemy.getAllUnitSlots = false;

            Targetting_ByUnit_Side allAlly = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            allEnemy.getAllies = true;
            allEnemy.getAllUnitSlots = false;

            int rando = UnityEngine.Random.Range(1, 3);

            string[] enemies = new string[] { "LittleAngel_EN", "Woodwind_EN", "HickoryFire_BOSS", "ChoirBoy_EN", "JumbleGuts_Flummoxing_EN" };

            for (int i = 0; i < entryVariable; i++)
            {
                int runThis = UnityEngine.Random.Range(0, enemies.Length);

                SpawnEnemyAnywhereEffect spawnIt = ScriptableObject.CreateInstance<SpawnEnemyAnywhereEffect>();
                spawnIt.enemy = LoadedAssetsHandler.GetEnemy(enemies[runThis]);

                Effect effort0 = new Effect(spawnIt, 1, null, Slots.Self);
                //Effect effort1 = new Effect(ScriptableObject.CreateInstance<LeakyRandomEffect>(), 1, null, allAlly);
                CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { effort0 }), caster));
            }
            return exitAmount > 0;
        }
    }
}
