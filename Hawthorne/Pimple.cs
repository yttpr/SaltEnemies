using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace Hawthorne
{
    public static class PimplesInfo
    {
        public static int Pimples => 2931527;
        public static StatusEffectInfoSO PimpleStatus = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
        public static void AddPimpleStatus(Action<CombatManager> orig, CombatManager self)
        {
            orig(self);
            PimpleStatus.name = "Pimples";
            PimpleStatus.icon = ResourceLoader.LoadSprite("PimplesIcon.png", 32);
            PimpleStatus._statusName = "Pimples";
            PimpleStatus.statusEffectType = (StatusEffectType)Pimples;
            PimpleStatus._description = "On anything moving in front of this unit, produce 1 pigment of its health color. Reduce Pimples by 1 at the end of each turn.";
            PimpleStatus._applied_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Ruptured].AppliedSoundEvent;
            PimpleStatus._updated_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Ruptured].UpdatedSoundEvent;
            PimpleStatus._removed_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Ruptured].RemovedSoundEvent;
            StatusEffectInfoSO effectInfo;
            self._stats.statusEffectDataBase.TryGetValue((StatusEffectType)Pimples, out effectInfo);
            if (effectInfo == null)
                self._stats.statusEffectDataBase.Add((StatusEffectType)Pimples, PimpleStatus);
        }
        public static void Setup()
        {
            IDetour addLeftEffectIDetour = (IDetour)new Hook((MethodBase)typeof(CombatManager).GetMethod(nameof(CombatManager.InitializeCombat), ~BindingFlags.Default), typeof(PimplesInfo).GetMethod(nameof(AddPimpleStatus), ~BindingFlags.Default));
            new CustomIntentInfo("Pimples", (IntentType)Pimples, ResourceLoader.LoadSprite("PimplesIcon.png"), IntentType.Status_Scars);

        }
    }
    public class Pimples_StatusEffect : IStatusEffect, ITriggerEffect<IStatusEffector>
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

        public StatusEffectType EffectType => (StatusEffectType)PimplesInfo.Pimples;

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

        public Pimples_StatusEffect(int amount, int restrictors = 0)
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
            CombatManager.Instance.AddObserver(new Action<object, object>(this.OnStatusTriggered), ((TriggerCalls)AmbushManager.Patiently).ToString(), caller);
            CombatManager.Instance.AddObserver(new Action<object, object>(this.OnTurnEnd), TriggerCalls.OnTurnFinished.ToString(), caller);
            //CombatManager.Instance.AddObserver(new Action<object, object>(this.OnStatusSubTriggered), TriggerCalls.OnRoundFinished.ToString(), caller);
            //if (!caller.IsStatusEffectorCharacter) CombatManager.Instance.AddObserver(new Action<object, object>(this.OnTurnEnd), TriggerCalls.OnRoundFinished.ToString(), caller);
        }

        public void OnTriggerDettached(IStatusEffector caller)
        {
            CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnStatusTriggered), ((TriggerCalls)AmbushManager.Patiently).ToString(), caller);
            CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnTurnEnd), TriggerCalls.OnTurnFinished.ToString(), caller);
            //CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnStatusSubTriggered), TriggerCalls.OnRoundFinished.ToString(), caller);
            //if (!caller.IsStatusEffectorCharacter) CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnTurnEnd), TriggerCalls.OnRoundFinished.ToString(), caller);
        }

        public void OnSubActionTrigger(object sender, object args, bool stateCheck)
        {

        }


        //public int timerCount = 30;

        public void OnStatusTriggered(object sender, object args)
        {
            if (sender is IUnit unit) unit.GenerateHealthMana(1);
        }

        public void OnStatusSubTriggered(object sender, object args)
        {
            this.IncreaseDuration(sender as IStatusEffector);
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
        public void DefiniteReduce(IStatusEffector effector)
        {
            int duration = this.Amount;
            this.Amount = Mathf.Max(0, this.Amount - 1);
            if (!this.TryRemoveStatusEffect(effector) && duration != this.Amount)
            {
                effector.StatusEffectValuesChanged(this.EffectType, this.Amount - duration);
            }
        }

        public void IncreaseDuration(IStatusEffector effector)
        {
            int duration = this.Amount;
            this.Amount = Mathf.Max(0, this.Amount + 1);
            if (duration != this.Amount)
            {
                effector.StatusEffectValuesChanged(this.EffectType, this.Amount - duration);
            }
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
    public class ApplyPimplesEffect : EffectSO
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
            stats.statusEffectDataBase.TryGetValue((StatusEffectType)PimplesInfo.Pimples, out effectInfo);




            for (int index = 0; index < targets.Length; ++index)
            {
                if (targets[index].HasUnit)
                {
                    int amount = this._randomBetweenPrevious ? UnityEngine.Random.Range(this.PreviousExitValue, entryVariable + 1) : entryVariable;
                    IStatusEffect statuseffect = new Pimples_StatusEffect(amount);

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
                        ConstructorInfo[] constructors = effector.StatusEffects[thisIndex].GetType().GetConstructors();
                        foreach (ConstructorInfo constructor in constructors)
                        {
                            if (constructor.GetParameters().Length == 2)
                            {
                                statuseffect = (IStatusEffect)Activator.CreateInstance(effector.StatusEffects[thisIndex].GetType(), amount, 0);
                            }
                        }
                    }

                    statuseffect.SetEffectInformation(effectInfo);
                    if (targets[index].Unit.ApplyStatusEffect((IStatusEffect)statuseffect, amount))
                        ++exitAmount;
                }
            }

            return exitAmount > 0;
        }
    }
}
