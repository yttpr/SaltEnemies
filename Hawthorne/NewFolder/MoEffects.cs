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
using THE_DEAD;

namespace Hawthorne.NewFolder
{
    public static class MoEffects
    {
        public static void Add() { Debug.Log("KILL YOURSEL"); }
    }

    public class L_LeftEffect : EffectSO
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

            

            AnimationVisualsEffect anim = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            anim._visuals = LoadedAssetsHandler.GetEnemyAbility("Domination_A").visuals;
            anim._animationTarget = Slots.Front;
            SwapToOneSideEffect goLeft = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            goLeft._swapRight = false;
            SwapToOneSideEffect goRight = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            goRight._swapRight = true;

            Effect yayAnim = new Effect(anim, 1, null, Slots.Self);
            Effect effort0 = new Effect(ScriptableObject.CreateInstance<ApplyPaleEffect>(), 5, null, Slots.Front);
            Effect effort1 = new Effect(ScriptableObject.CreateInstance<ApplySinEffect>(), 3, null, Slots.Right);
            Effect movemen = new Effect(goLeft, 1, null, Slots.Self);
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[3] { yayAnim, effort0, effort1 }), caster));
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { movemen }), caster));

            return exitAmount > 0;
        }
    }
    public class L_RightEffect : EffectSO
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



            AnimationVisualsEffect anim = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            anim._visuals = LoadedAssetsHandler.GetEnemyAbility("Domination_A").visuals;
            anim._animationTarget = Slots.Front;
            SwapToOneSideEffect goLeft = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            goLeft._swapRight = false;
            SwapToOneSideEffect goRight = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            goRight._swapRight = true;

            Effect yayAnim = new Effect(anim, 1, null, Slots.Self);
            Effect effort0 = new Effect(ScriptableObject.CreateInstance<ApplyPaleEffect>(), 5, null, Slots.Front);
            Effect effort1 = new Effect(ScriptableObject.CreateInstance<ApplySinEffect>(), 3, null, Slots.Left);
            Effect movemen = new Effect(goRight, 1, null, Slots.Self);
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[3] { yayAnim, effort0, effort1 }), caster));
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { movemen }), caster));

            return exitAmount > 0;
        }
    }
    public class M_LeftEffect : EffectSO
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



            AnimationVisualsEffect anim = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            anim._visuals = LoadedAssetsHandler.GetEnemyAbility("Flood_A").visuals;
            anim._animationTarget = Slots.Front;
            SwapToOneSideEffect goLeft = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            goLeft._swapRight = false;
            SwapToOneSideEffect goRight = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            goRight._swapRight = true;

            Effect yayAnim = new Effect(anim, 1, null, Slots.Self);
            Effect effort0 = new Effect(ScriptableObject.CreateInstance<ApplySporesEffect>(), 2, null, Slots.Front);
            Effect effort1 = new Effect(ScriptableObject.CreateInstance<ApplyPaintAllergyEffect>(), 1, null, Slots.Right);
            Effect movemen = new Effect(goLeft, 1, null, Slots.Self);
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[3] { yayAnim, effort0, effort1 }), caster));
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { movemen }), caster));

            return exitAmount > 0;
        }
    }
    public class M_RightEffect : EffectSO
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



            AnimationVisualsEffect anim = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            anim._visuals = LoadedAssetsHandler.GetEnemyAbility("Flood_A").visuals;
            anim._animationTarget = Slots.Front;
            SwapToOneSideEffect goLeft = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            goLeft._swapRight = false;
            SwapToOneSideEffect goRight = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            goRight._swapRight = true;

            Effect yayAnim = new Effect(anim, 1, null, Slots.Self);
            Effect effort0 = new Effect(ScriptableObject.CreateInstance<ApplySporesEffect>(), 2, null, Slots.Front);
            Effect effort1 = new Effect(ScriptableObject.CreateInstance<ApplyPaintAllergyEffect>(), 1, null, Slots.Left);
            Effect movemen = new Effect(goRight, 1, null, Slots.Self);
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[3] { yayAnim, effort0, effort1 }), caster));
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { movemen }), caster));

            return exitAmount > 0;
        }
    }
    public class R_LeftEffect : EffectSO
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



            AnimationVisualsEffect anim = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            anim._visuals = LoadedAssetsHandler.GetEnemyAbility("Talons_A").visuals;
            anim._animationTarget = Slots.Front;
            SwapToOneSideEffect goLeft = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            goLeft._swapRight = false;
            SwapToOneSideEffect goRight = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            goRight._swapRight = true;

            Effect yayAnim = new Effect(anim, 1, null, Slots.Self);
            Effect effort0 = new Effect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 1, null, Slots.Front);
            Effect effort1 = new Effect(ScriptableObject.CreateInstance<ApplyBleedingEffect>(), 2, null, Slots.Right);
            Effect movemen = new Effect(goLeft, 1, null, Slots.Self);
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[3] { yayAnim, effort0, effort1 }), caster));
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { movemen }), caster));

            return exitAmount > 0;
        }
    }
    public class R_RightEffect : EffectSO
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



            AnimationVisualsEffect anim = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            anim._visuals = LoadedAssetsHandler.GetEnemyAbility("Talons_A").visuals;
            anim._animationTarget = Slots.Front;
            SwapToOneSideEffect goLeft = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            goLeft._swapRight = false;
            SwapToOneSideEffect goRight = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            goRight._swapRight = true;

            Effect yayAnim = new Effect(anim, 1, null, Slots.Self);
            Effect effort0 = new Effect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 1, null, Slots.Front);
            Effect effort1 = new Effect(ScriptableObject.CreateInstance<ApplyBleedingEffect>(), 2, null, Slots.Left);
            Effect movemen = new Effect(goRight, 1, null, Slots.Self);
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[3] { yayAnim, effort0, effort1 }), caster));
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { movemen }), caster));

            return exitAmount > 0;
        }
    }
    public class O_LeftEffect : EffectSO
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



            AnimationVisualsEffect anim = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            anim._visuals = LoadedAssetsHandler.GetCharacterAbility("Torch_1_A").visuals;
            anim._animationTarget = Slots.Front;
            SwapToOneSideEffect goLeft = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            goLeft._swapRight = false;
            SwapToOneSideEffect goRight = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            goRight._swapRight = true;

            Effect yayAnim = new Effect(anim, 1, null, Slots.Self);
            Effect effort0 = new Effect(ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), 1, null, Slots.Front);
            Effect effort1 = new Effect(ScriptableObject.CreateInstance<ApplyOilSlickedEffect>(), 2, null, Slots.Right);
            Effect movemen = new Effect(goLeft, 1, null, Slots.Self);
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[3] { yayAnim, effort0, effort1 }), caster));
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { movemen }), caster));

            return exitAmount > 0;
        }
    }
    public class O_RightEffect : EffectSO
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



            AnimationVisualsEffect anim = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            anim._visuals = LoadedAssetsHandler.GetCharacterAbility("Torch_1_A").visuals;
            anim._animationTarget = Slots.Front;
            SwapToOneSideEffect goLeft = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            goLeft._swapRight = false;
            SwapToOneSideEffect goRight = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            goRight._swapRight = true;

            Effect yayAnim = new Effect(anim, 1, null, Slots.Self);
            Effect effort0 = new Effect(ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), 1, null, Slots.Front);
            Effect effort1 = new Effect(ScriptableObject.CreateInstance<ApplyOilSlickedEffect>(), 2, null, Slots.Left);
            Effect movemen = new Effect(goRight, 1, null, Slots.Self);
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[3] { yayAnim, effort0, effort1 }), caster));
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { movemen }), caster));

            return exitAmount > 0;
        }
    }
    public class G_LeftEffect : EffectSO
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



            AnimationVisualsEffect anim = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            anim._visuals = LoadedAssetsHandler.GetEnemyAbility("RingABell_A").visuals;
            anim._animationTarget = Slots.Front;
            SwapToOneSideEffect goLeft = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            goLeft._swapRight = false;
            SwapToOneSideEffect goRight = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            goRight._swapRight = true;

            Effect yayAnim = new Effect(anim, 1, null, Slots.Self);
            Effect effort0 = new Effect(ScriptableObject.CreateInstance<ApplyDivineProtectionEffect>(), 2, null, Slots.Front);
            Effect effort1 = new Effect(ScriptableObject.CreateInstance<ApplyDivineSacrificeEffect>(), 1, null, Slots.Right);
            Effect movemen = new Effect(goLeft, 1, null, Slots.Self);
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[3] { yayAnim, effort0, effort1 }), caster));
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { movemen }), caster));

            return exitAmount > 0;
        }
    }
    public class G_RightEffect : EffectSO
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



            AnimationVisualsEffect anim = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            anim._visuals = LoadedAssetsHandler.GetEnemyAbility("RingABell_A").visuals;
            anim._animationTarget = Slots.Front;
            SwapToOneSideEffect goLeft = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            goLeft._swapRight = false;
            SwapToOneSideEffect goRight = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            goRight._swapRight = true;

            Effect yayAnim = new Effect(anim, 1, null, Slots.Self);
            Effect effort0 = new Effect(ScriptableObject.CreateInstance<ApplyDivineProtectionEffect>(), 2, null, Slots.Front);
            Effect effort1 = new Effect(ScriptableObject.CreateInstance<ApplyDivineSacrificeEffect>(), 1, null, Slots.Left);
            Effect movemen = new Effect(goRight, 1, null, Slots.Self);
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[3] { yayAnim, effort0, effort1 }), caster));
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { movemen }), caster));

            return exitAmount > 0;
        }
    }
    public class P_LeftEffect : EffectSO
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



            AnimationVisualsEffect anim = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            anim._visuals = LoadedAssetsHandler.GetEnemyAbility("Gnaw_A").visuals;
            anim._animationTarget = Slots.Front;
            SwapToOneSideEffect goLeft = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            goLeft._swapRight = false;
            SwapToOneSideEffect goRight = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            goRight._swapRight = true;

            Effect yayAnim = new Effect(anim, 1, null, Slots.Self);
            Effect effort0 = new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 5, null, Slots.Front);
            Effect effort1 = new Effect(ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 5, null, Slots.Right);
            Effect movemen = new Effect(goLeft, 1, null, Slots.Self);
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[3] { yayAnim, effort0, effort1 }), caster));
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { movemen }), caster));

            return exitAmount > 0;
        }
    }
    public class P_RightEffect : EffectSO
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



            AnimationVisualsEffect anim = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            anim._visuals = LoadedAssetsHandler.GetEnemyAbility("Gnaw_A").visuals;
            anim._animationTarget = Slots.Front;
            SwapToOneSideEffect goLeft = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            goLeft._swapRight = false;
            SwapToOneSideEffect goRight = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            goRight._swapRight = true;

            Effect yayAnim = new Effect(anim, 1, null, Slots.Self);
            Effect effort0 = new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 5, null, Slots.Front);
            Effect effort1 = new Effect(ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 5, null, Slots.Left);
            Effect movemen = new Effect(goRight, 1, null, Slots.Self);
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[3] { yayAnim, effort0, effort1 }), caster));
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { movemen }), caster));

            return exitAmount > 0;
        }
    }
    public class S_AbilityEffect : EffectSO
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



            AnimationVisualsEffect anim = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            anim._visuals = LoadedAssetsHandler.GetEnemy("HeavensGateRed_BOSS").abilities[1].ability.visuals;
            anim._animationTarget = Slots.FrontLeftRight;
            SwapToOneSideEffect goLeft = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            goLeft._swapRight = false;
            SwapToOneSideEffect goRight = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            goRight._swapRight = true;

            Effect yayAnim = new Effect(anim, 1, null, Slots.Self);
            Effect effort0 = new Effect(ScriptableObject.CreateInstance<ApplyFeebleEffect>(), 3, null, Slots.Front);
            Effect effort1 = new Effect(ScriptableObject.CreateInstance<ApplyFrailEffect>(), 1, null, Slots.LeftRight);
            Effect movemen = new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, null, Slots.Self);
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[3] { yayAnim, effort0, effort1 }), caster));
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { movemen }), caster));

            return exitAmount > 0;
        }
    }
    public class B_AbilityEffect : EffectSO
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



            AnimationVisualsEffect anim = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            anim._visuals = LoadedAssetsHandler.GetEnemyAbility("Repent_A").visuals;
            anim._animationTarget = Slots.Self;
            SwapToOneSideEffect goLeft = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            goLeft._swapRight = false;
            SwapToOneSideEffect goRight = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            goRight._swapRight = true;

            SpawnEnemyAnywhereEffect eyeFuck = ScriptableObject.CreateInstance<SpawnEnemyAnywhereEffect>();
            eyeFuck.enemy = LoadedAssetsHandler.GetEnemy("Enigma_EN");

            Effect yayAnim = new Effect(anim, 1, null, Slots.Self);
            Effect effort0 = new Effect(ScriptableObject.CreateInstance<CycleSlotEffectsEffect>(), 3, null, Slots.SlotTarget(new int[9] { -4, -3, -2, -1, 0, 1, 2, 3, 4 }, true));
            Effect effort1 = new Effect(ScriptableObject.CreateInstance<CycleSlotEffectsEffect>(), 1, null, Slots.SlotTarget(new int[9] { -4, -3, -2, -1, 0, 1, 2, 3, 4 }, false));
            Effect movemen = new Effect(eyeFuck, 1, null, Slots.Self);
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[4] { yayAnim, effort0, effort1, movemen }), caster));

            return exitAmount > 0;
        }
    }

    public class CycleAllSlotsEffect : EffectSO
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



            AnimationVisualsEffect anim = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            anim._visuals = LoadedAssetsHandler.GetEnemyAbility("Repent_A").visuals;
            anim._animationTarget = Slots.Self;
            SwapToOneSideEffect goLeft = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            goLeft._swapRight = false;
            SwapToOneSideEffect goRight = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            goRight._swapRight = true;

            SpawnEnemyAnywhereEffect eyeFuck = ScriptableObject.CreateInstance<SpawnEnemyAnywhereEffect>();
            eyeFuck.enemy = LoadedAssetsHandler.GetEnemy("Enigma_EN");

            Effect yayAnim = new Effect(anim, 1, null, Slots.Self);
            Effect effort0 = new Effect(ScriptableObject.CreateInstance<CycleSlotEffectsEffect>(), 3, null, Slots.SlotTarget(new int[9] { -4, -3, -2, -1, 0, 1, 2, 3, 4 }, true));
            Effect effort1 = new Effect(ScriptableObject.CreateInstance<CycleSlotEffectsEffect>(), 1, null, Slots.SlotTarget(new int[9] { -4, -3, -2, -1, 0, 1, 2, 3, 4 }, false));
            Effect movemen = new Effect(eyeFuck, 1, null, Slots.Self);
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[] { effort0, effort1 }), caster));

            return exitAmount > 0;
        }
    }
}
