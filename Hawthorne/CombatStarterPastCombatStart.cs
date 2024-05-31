using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using MonoMod.RuntimeDetour;
using System.Reflection;
using System.Collections;

namespace Hawthorne
{
    public static class CombatStarterPastCombatStart
    {
        public static void ConnectPassives(Action<EnemyCombat> orig, EnemyCombat self)
        {
            orig(self);
            if (CombatStarted)
            {
                if (self.GetStoredValue((UnitStoredValueNames)98412002) > 0) return;
                else self.SetStoredValue((UnitStoredValueNames)98412002, 1);
                try
                {
                    self.StartCombat();
                    foreach (BasePassiveAbilitySO passive in self.Enemy.passiveAbilities)
                        if (passive.type == (PassiveAbilityTypes)85676)
                        {
                            CombatManager.Instance.AddRootAction(new SubActionAction(new Rem_DivineProt_IfOtherImmortal_Action(self)));
                            break;
                        }
                }
                catch
                {
                    Debug.LogError("posting notif combat start past combat start eppic failure Sad!");
                }
            }
        }
        public static void Setup()
        {
            IDetour hook = new Hook(typeof(EnemyCombat).GetMethod(nameof(EnemyCombat.ConnectPassives), ~BindingFlags.Default), typeof(CombatStarterPastCombatStart).GetMethod(nameof(ConnectPassives), ~BindingFlags.Default));
        }
        public static bool CombatStarted = false;
        public static void Reset() => CombatStarted = false;
        public static void Start() => CombatStarted = true;
    }
    public class Rem_DivineProt_IfOtherImmortal_Action : CombatAction
    {
        public IUnit unit;
        public Rem_DivineProt_IfOtherImmortal_Action(IUnit unit)
        {
            this.unit = unit;
        }
        public override IEnumerator Execute(CombatStats stats)
        {
            if (!unit.IsUnitCharacter && unit.IsAlive)
            {
                foreach (EnemyCombat enemy in stats.EnemiesOnField.Values)
                {
                    if (enemy.ID != unit.ID && enemy.ContainsPassiveAbility(PassiveAbilityTypes.Immortal))
                    {
                        unit.TryRemovePassiveAbility(PassiveAbilityTypes.Immortal);
                        break;
                    }
                }
            }
            yield return null;
        }
    }
}
