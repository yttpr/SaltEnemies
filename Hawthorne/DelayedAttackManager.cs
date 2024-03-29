using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Rendering;
using BrutalAPI;
using PYMN4;
using MonoMod.RuntimeDetour;
using System.Reflection;
using FMODUnity;
using Tools;

namespace Hawthorne
{
    public static class DelayedAttackManager
    {
        public static List<DelayedAttack> Attacks = new List<DelayedAttack>();
        public static AttackVisualsSO CrushAnim => CustomVisuals.GetVisuals("Salt/Cannon");
        public static TargetSlotInfo[] Targets(bool playerTurn)
        {
            List<TargetSlotInfo> targets = new List<TargetSlotInfo>();
            foreach (DelayedAttack attack in Attacks)
            {
                if (!targets.Contains(attack.Target) && (playerTurn == attack.caster.IsUnitCharacter || attack.caster == null)) targets.Add(attack.Target);
            }
            return targets.ToArray();
        }
        public static IUnit[] Attackers
        {
            get
            {
                List<IUnit> casters = new List<IUnit>();
                foreach (DelayedAttack attack in Attacks)
                {
                    if (attack.caster != null && !casters.Contains(attack.caster)) casters.Add(attack.caster);
                }
                return casters.ToArray();
            }
        }
        public static TargetSlotInfo[] TargetsForUnit(IUnit unit)
        {
            List<TargetSlotInfo> targets = new List<TargetSlotInfo>();
            foreach (DelayedAttack attack in Attacks)
            {
                if (!targets.Contains(attack.Target) && attack.caster != null && attack.caster == unit) targets.Add(attack.Target);
            }
            return targets.ToArray();
        }
        public static DelayedAttack[] AttacksForUnit(IUnit unit)
        {
            List<DelayedAttack> targets = new List<DelayedAttack>();
            foreach (DelayedAttack attack in Attacks)
            {
                if (attack.caster != null && attack.caster == unit) targets.Add(attack);
            }
            return targets.ToArray();
        }

        public static void CleanList(bool playerTurn)
        {
            List<DelayedAttack> ret = new List<DelayedAttack>();
            foreach (DelayedAttack attack in Attacks)
            {
                if (attack.caster != null && attack.caster.IsUnitCharacter != playerTurn) ret.Add(attack);
            }
            Attacks = ret;
        }

        public static void PlayerTurnStart(Action<CombatStats> orig, CombatStats self)
        {
            orig(self);
            NamelessHandler.CreateFile();
            NobodyMoveHandler.Clear();
            CombatManager.Instance.AddRootAction(new BadDogTurnStartAction());
            CombatManager.Instance.AddRootAction(new PerformDelayedAttacksAction(true));
            CombatManager.Instance.AddRootAction(new ButterflyAction());
        }

        public static void PlayerTurnEnd(Action<CombatStats> orig, CombatStats self)
        {
            orig(self);
            CombatManager.Instance.AddSubAction(new PerformDelayedAttacksAction(false));
        }

        public static void FinalizeCombat(Action<CombatStats> orig, CombatStats self)
        {
            orig(self);
            Attacks.Clear();
            ThreadCleaner.CleanThreads();
            ButterflyUnboxer.Boxeds.Clear();
            BlackHoleEffect.Reset();
            WaterView.Reset();
        }

        public static void UIInitialization(Action<CombatStats> orig, CombatStats self)
        {
            WaterView.Reset();
            orig(self);
            Attacks.Clear();
            if (DoDebugs.MiscInfo) Debug.Log("Clearing");
            ButterflyUnboxer.Boxeds.Clear();
            BlackHoleEffect.Reset();
        }

        public static void Setup()
        {
            AmbushManager.Setup();
            ThreadCleaner.Setup();
            IDetour CombatEnd = new Hook(typeof(CombatStats).GetMethod(nameof(CombatStats.FinalizeCombat), ~BindingFlags.Default), typeof(DelayedAttackManager).GetMethod(nameof(FinalizeCombat), ~BindingFlags.Default));
            IDetour CombatStart = new Hook(typeof(CombatStats).GetMethod(nameof(CombatStats.UIInitialization), ~BindingFlags.Default), typeof(DelayedAttackManager).GetMethod(nameof(UIInitialization), ~BindingFlags.Default));
            IDetour TurnStart = new Hook(typeof(CombatStats).GetMethod(nameof(CombatStats.PlayerTurnStart), ~BindingFlags.Default), typeof(DelayedAttackManager).GetMethod(nameof(PlayerTurnStart), ~BindingFlags.Default));
            IDetour TurnEnd = new Hook(typeof(CombatStats).GetMethod(nameof(CombatStats.PlayerTurnEnd), ~BindingFlags.Default), typeof(DelayedAttackManager).GetMethod(nameof(PlayerTurnEnd), ~BindingFlags.Default));
        }

    }

    public class DelayedAttack
    {
        public int Damage;
        public TargetSlotInfo Target;
        public IUnit caster;

        public DelayedAttack(int damage, TargetSlotInfo target, IUnit caster)
        {
            Damage = damage;
            Target = target;
            this.caster = caster;
        }

        public void Add()
        {
            DelayedAttackManager.Attacks.Add(this);
        }

        public int Perform()
        {
            if (caster != null && caster.IsAlive)
            {
                if (Target.HasUnit)
                {
                    int amount = caster.WillApplyDamage(Damage, Target.Unit);
                    DamageInfo hit = Target.Unit.Damage(amount, caster, DeathType.Basic, -1, true, true, false);
                    return hit.damageAmount;
                }

            }
            else
            {
                if (Target.HasUnit)
                {
                    Target.Unit.Damage(Damage, null, DeathType.Basic, -1, true, true, false);
                    return 0;
                }
            }
            return 0;
        }
    }

    public class PlayAnimationAnywhereAction : CombatAction
    {
        public AttackVisualsSO _visuals;

        public TargetSlotInfo[] _targets;

        public PlayAnimationAnywhereAction(AttackVisualsSO visuals, TargetSlotInfo[] targets)
        {
            _visuals = visuals;
            _targets = targets;
        }

        public override IEnumerator Execute(CombatStats stats)
        {
            if (_targets.Length > 0)
                yield return stats.combatUI.PlayAbilityAnimation(_visuals, _targets, true);
        }
    }

    public class PerformDelayedAttacksAction : CombatAction
    {
        public PerformDelayedAttacksAction(bool playerTurn)
        {
            PlayerTurn = playerTurn;
        }

        public bool PlayerTurn;

        public override IEnumerator Execute(CombatStats stats)
        {
            CombatManager.Instance.AddSubAction(new PlayAnimationAnywhereAction(DelayedAttackManager.CrushAnim, DelayedAttackManager.Targets(PlayerTurn)));
            foreach (IUnit unit in DelayedAttackManager.Attackers)
            {
                if (PlayerTurn == unit.IsUnitCharacter)
                {
                    ReturnMultiTargets targets = ScriptableObject.CreateInstance<ReturnMultiTargets>();
                    targets.Targets = DelayedAttackManager.TargetsForUnit(unit);
                    PerformDelayedAttackEffect attack = ScriptableObject.CreateInstance<PerformDelayedAttackEffect>();
                    attack.Attacks = DelayedAttackManager.AttacksForUnit(unit);
                    Effect effect = new Effect(attack, 0, null, targets);
                    EffectInfo[] info = ExtensionMethods.ToEffectInfoArray(new Effect[] { effect });
                    CombatManager.Instance.AddSubAction(new EffectAction(info, unit));
                }
            }
            CombatManager.Instance.AddSubAction(new PerformCasterlessDelayedAttacksAction(DelayedAttackManager.Attacks.ToArray()));
            DelayedAttackManager.CleanList(PlayerTurn);
            yield return null;
        }
    }

    public class PerformCasterlessDelayedAttacksAction : CombatAction
    {
        public PerformCasterlessDelayedAttacksAction(DelayedAttack[] attacks)
        {
            List<DelayedAttack> ret = new List<DelayedAttack>();
            foreach(DelayedAttack hit in attacks)
            {
                if (hit.caster == null) ret.Add(hit);
            }
            Attacks = ret.ToArray();
        }
        public DelayedAttack[] Attacks;

        public override IEnumerator Execute(CombatStats stats)
        {
            foreach (DelayedAttack hit in Attacks) hit.Perform();
            yield return null;
        }
    }

    public class ReturnSingleTarget : BaseCombatTargettingSO
    {
        public TargetSlotInfo Target;
        
        public override bool AreTargetAllies => false;

        public override bool AreTargetSlots => true;

        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            return new TargetSlotInfo[] {Target };
        }
    }
    public class ReturnMultiTargets : BaseCombatTargettingSO
    {
        public TargetSlotInfo[] Targets;

        public override bool AreTargetAllies => false;

        public override bool AreTargetSlots => true;

        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            return Targets;
        }
    }

    public class PerformDelayedAttackEffect : EffectSO
    {
        public DelayedAttack[] Attacks;
        
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach(DelayedAttack attack in Attacks)
            {
                exitAmount += attack.Perform();
            }
            if (exitAmount > 0)
                caster.DidApplyDamage(exitAmount);
            return exitAmount > 0;
        }
    }
    public class AddDelayedAttackEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach(TargetSlotInfo target in targets)
            {
                new DelayedAttack(entryVariable, target, caster).Add();
                exitAmount+= entryVariable;
            }
            return exitAmount > 0;
        }
    }

    public static class ThreadCleaner
    {
        public static void CleanThreads()
        {
            if (ClockTowerManager.timer != null) ClockTowerManager.timer.Abort();
            CrackingHandler.Clear();
            FallImageryHandler.Clear();
        }
        
        public static void OnMainMenuPressed(Action<PauseUIHandler> orig, PauseUIHandler self)
        {
            CleanThreads();
            orig(self);
        }

        public static void Setup()
        {
            IDetour hook1 = new Hook(typeof(PauseUIHandler).GetMethod(nameof(PauseUIHandler.OnExitGamePressed), ~BindingFlags.Default), typeof(ThreadCleaner).GetMethod(nameof(OnMainMenuPressed), ~BindingFlags.Default));
            IDetour hook2 = new Hook(typeof(PauseUIHandler).GetMethod(nameof(PauseUIHandler.OnMainMenuPressed), ~BindingFlags.Default), typeof(ThreadCleaner).GetMethod(nameof(OnMainMenuPressed), ~BindingFlags.Default));
        }
    }
}
