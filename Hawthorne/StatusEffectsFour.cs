using System;
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
using System.Collections;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using JetBrains.Annotations;
using static UnityEngine.UI.CanvasScaler;
using System.Drawing;
using static UnityEngine.EventSystems.EventTrigger;
using System.Threading;
using UnityEngine.EventSystems;

namespace Hawthorne
{
    public class AsceticQuadroupleModifier : IntValueModifier
    {


        public AsceticQuadroupleModifier()
            : base(70)
        {

        }

        public override int Modify(int value)
        {

            if (value > 0)
            {
                return value * 4;
            }
            return value;
        }
    }

    public class Doom_StatusEffect : IStatusEffect, ITriggerEffect<IStatusEffector>
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

        public StatusEffectType EffectType => (StatusEffectType)846740;

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

        public Doom_StatusEffect(int amount, int restrictors = 0)
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
            //CombatManager.Instance.AddObserver(new Action<object, object>(this.OnStatusSubTriggered), TriggerCalls.OnKill.ToString(), caller);

            //CombatManager.Instance.AddObserver(new Action<object, object>(this.OnStatusTriggered), TriggerCalls.CanHeal.ToString(), caller);
            CombatManager.Instance.AddObserver(new Action<object, object>(this.OnTurnEnd), TriggerCalls.OnTurnFinished.ToString(), caller);
        }

        public void OnTriggerDettached(IStatusEffector caller)
        {
            CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnStatusTriggered), TriggerCalls.OnBeingDamaged.ToString(), caller);
            //CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnStatusSubTriggered), TriggerCalls.OnKill.ToString(), caller);

            //CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnStatusTriggered), TriggerCalls.CanHeal.ToString(), caller);
            CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnTurnEnd), TriggerCalls.OnTurnFinished.ToString(), caller);
        }

        public void OnSubActionTrigger(object sender, object args, bool stateCheck)
        {

        }


        //public int timerCount = 30;

        public void OnStatusTriggered(object sender, object args)
        {
            if (args is DamageReceivedValueChangeException hitBy && sender is IUnit unit)
            {
                if (hitBy.damageType == (DamageType)888667)
                {
                    hitBy.AddModifier(new ImmZeroMod());
                    hitBy.AddModifier((IntValueModifier)new RemainSameTrigger(hitBy.amount));

                    RemoveStatusEffectEffect removeSelf = ScriptableObject.CreateInstance<RemoveStatusEffectEffect>();
                    removeSelf._statusToRemove = (StatusEffectType)846740;
                    Effect removeSelfEffect = new Effect(removeSelf, 1, null, Slots.Self);
                    CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { removeSelfEffect }), unit));
                    return;
                }
            }
        }

        public void OnStatusSubTriggered(object sender, object args)
        {
            this.IncreaseDuration(sender as IStatusEffector);
        }



        public void OnTurnEnd(object sender, object args)
        {
            int killP = this.Amount;
            if (sender is IStatusEffector effector)
            {
                foreach (IStatusEffect status in effector.StatusEffects)
                {
                    if (status.EffectType == (StatusEffectType)666667)
                    {
                        killP += status.StatusContent;
                    }
                }
            }
            if (sender is IUnit unit)
            {
                if (UnityEngine.Random.Range(0, 100) < killP)
                {
                    unit.Damage(999, null, DeathType.Obliteration, -1, false, false, true, (DamageType)888667);
                }
            }
            this.ReduceDuration(sender as IStatusEffector);
        }

        public void ReduceDuration(IStatusEffector effector)
        {
            if (!this.CanReduceDuration)
            {
                return;
            }
            int duration = this.Amount;
            decimal gap = this.Amount / 2;
            this.Amount = Mathf.Max(0, (int)Math.Floor(gap));
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
    public class ApplyDoomEffect : EffectSO
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
            stats.statusEffectDataBase.TryGetValue((StatusEffectType)846740, out effectInfo);




            for (int index = 0; index < targets.Length; ++index)
            {
                if (targets[index].HasUnit)
                {
                    int amount = this._randomBetweenPrevious ? UnityEngine.Random.Range(this.PreviousExitValue, entryVariable + 1) : entryVariable;
                    IStatusEffect statuseffect = new Doom_StatusEffect(amount);

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

    public class StatusEffect_StatusEffect : IStatusEffect, ITriggerEffect<IStatusEffector>
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

        public StatusEffectType EffectType => (StatusEffectType)846739;

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

        public StatusEffect_StatusEffect(int amount, int restrictors = 0)
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

            //CombatManager.Instance.AddObserver(new Action<object, object>(this.OnStatusTriggered), TriggerCalls.OnBeingDamaged.ToString(), caller);
            //CombatManager.Instance.AddObserver(new Action<object, object>(this.OnStatusSubTriggered), TriggerCalls.OnKill.ToString(), caller);

            //CombatManager.Instance.AddObserver(new Action<object, object>(this.OnStatusTriggered), TriggerCalls.CanHeal.ToString(), caller);
            CombatManager.Instance.AddObserver(new Action<object, object>(this.OnTurnEnd), TriggerCalls.OnTurnFinished.ToString(), caller);
        }

        public void OnTriggerDettached(IStatusEffector caller)
        {
            //CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnStatusTriggered), TriggerCalls.OnBeingDamaged.ToString(), caller);
            //CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnStatusSubTriggered), TriggerCalls.OnKill.ToString(), caller);

            //CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnStatusTriggered), TriggerCalls.CanHeal.ToString(), caller);
            CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnTurnEnd), TriggerCalls.OnTurnFinished.ToString(), caller);
        }

        public void OnSubActionTrigger(object sender, object args, bool stateCheck)
        {

        }


        //public int timerCount = 30;

        public void OnStatusTriggered(object sender, object args)
        {
            if (args is DamageReceivedValueChangeException hitBy && sender is IUnit unit)
            {
                if (hitBy.damageType == (DamageType)888667)
                {
                    hitBy.AddModifier(new ImmZeroMod());
                    hitBy.AddModifier((IntValueModifier)new RemainSameTrigger(hitBy.amount));

                    RemoveStatusEffectEffect removeSelf = ScriptableObject.CreateInstance<RemoveStatusEffectEffect>();
                    removeSelf._statusToRemove = (StatusEffectType)846740;
                    Effect removeSelfEffect = new Effect(removeSelf, 1, null, Slots.Self);
                    CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { removeSelfEffect }), unit));
                    return;
                }
            }
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
    public class ApplyStatusEffectStatusEffectEffect : EffectSO
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
            stats.statusEffectDataBase.TryGetValue((StatusEffectType)846739, out effectInfo);




            for (int index = 0; index < targets.Length; ++index)
            {
                if (targets[index].HasUnit)
                {
                    int amount = this._randomBetweenPrevious ? UnityEngine.Random.Range(this.PreviousExitValue, entryVariable + 1) : entryVariable;
                    IStatusEffect statuseffect = new StatusEffect_StatusEffect(amount);

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

    public class Left_StatusEffect : IStatusEffect, ITriggerEffect<IStatusEffector>
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

        public StatusEffectType EffectType => (StatusEffectType)846738;

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

        public Left_StatusEffect(int amount, int restrictors = 0)
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

            CombatManager.Instance.AddObserver(new Action<object, object>(this.OnStatusTriggered), TriggerCalls.OnMoved.ToString(), caller);
            //CombatManager.Instance.AddObserver(new Action<object, object>(this.OnStatusSubTriggered), TriggerCalls.OnKill.ToString(), caller);

            //CombatManager.Instance.AddObserver(new Action<object, object>(this.OnStatusTriggered), TriggerCalls.CanHeal.ToString(), caller);
            //CombatManager.Instance.AddObserver(new Action<object, object>(this.OnTurnEnd), TriggerCalls.OnTurnFinished.ToString(), caller);
        }

        public void OnTriggerDettached(IStatusEffector caller)
        {
            CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnStatusTriggered), TriggerCalls.OnMoved.ToString(), caller);
            //CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnStatusSubTriggered), TriggerCalls.OnKill.ToString(), caller);

            //CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnStatusTriggered), TriggerCalls.CanHeal.ToString(), caller);
            //CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnTurnEnd), TriggerCalls.OnTurnFinished.ToString(), caller);
        }

        public void OnSubActionTrigger(object sender, object args, bool stateCheck)
        {

        }


        //public int timerCount = 30;

        public void OnStatusTriggered(object sender, object args)
        {
            if (sender is IUnit unit)
            {
                SwapToOneSideEffect goLeft = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
                goLeft._swapRight = false;
                Effect left = new Effect(goLeft, 1, null, Slots.Self);
                CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { left }), unit));
                this.ReduceDuration(sender as IStatusEffector);
            }
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
    public class ApplyLeftEffect : EffectSO
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
            stats.statusEffectDataBase.TryGetValue((StatusEffectType)846738, out effectInfo);




            for (int index = 0; index < targets.Length; ++index)
            {
                if (targets[index].HasUnit)
                {
                    int amount = this._randomBetweenPrevious ? UnityEngine.Random.Range(this.PreviousExitValue, entryVariable + 1) : entryVariable;
                    IStatusEffect statuseffect = new Left_StatusEffect(amount);

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

    public class Mold_SlotStatusEffect : ISlotStatusEffect, ITriggerEffect<IUnit>, IShieldModifier
    {
        public const bool _onlyDirectDamage = true;

        public int Restrictor { get; set; }

        public bool CanBeRemoved => Restrictor <= 0;

        public bool IsPositive => true;

        public string DisplayText
        {
            get
            {
                string text = "";
                if (Amount > 0)
                {
                    text += Amount;
                }

                if (Restrictor > 0)
                {
                    text = text + "(" + Restrictor + ")";
                }

                return text;
            }
        }

        public int Amount { get; set; }

        public int SlotID { get; set; }

        public bool IsCharacterSlot { get; set; }

        public ISlotStatusEffector Effector { get; set; }

        public SlotStatusEffectType EffectType => (SlotStatusEffectType)862351;

        public SlotStatusEffectInfoSO EffectInfo { get; set; }

        public Mold_SlotStatusEffect(int slotID, int amount, bool isCharacterSlot, int restrictors = 0)
        {
            SlotID = slotID;
            Amount = amount;
            Restrictor = restrictors;
            IsCharacterSlot = isCharacterSlot;
        }

        public void SetEffectInformation(SlotStatusEffectInfoSO effectInfo)
        {
            EffectInfo = effectInfo;
        }

        public ISlotStatusEffect DeepCopy(int newSlotID)
        {
            Mold_SlotStatusEffect slotEffect = new Mold_SlotStatusEffect(newSlotID, Amount, IsCharacterSlot, Restrictor);
            slotEffect.SetEffectInformation(EffectInfo);
            return slotEffect;
        }

        public bool AddContent(ISlotStatusEffect content)
        {
            Amount += (content as Mold_SlotStatusEffect).Amount;
            Restrictor += content.Restrictor;
            return true;
        }

        public bool TryAddContent(int amount)
        {
            if (Amount <= 0)
            {
                return false;
            }

            Amount += amount;
            return true;
        }

        public int JustRemoveAllContent()
        {
            int amountGone = Amount;
            Amount = 0;
            return amountGone;
        }

        public void OnTriggerAttached(IUnit caller)
        {
            caller.AddFieldEffect(EffectType);
            CombatManager.Instance.AddObserver(OnStatusTriggered, TriggerCalls.CanHeal.ToString(), caller);
        }

        public void OnTriggerDettached(IUnit caller)
        {
            caller.RemoveFieldEffect(EffectType);
            CombatManager.Instance.RemoveObserver(OnStatusTriggered, TriggerCalls.CanHeal.ToString(), caller);
        }

        public void OnEffectorTriggerAttached(ISlotStatusEffector caller)
        {
            Effector = caller;
            CombatManager.Instance.AddObserver(OnStatusTick, TriggerCalls.OnTurnStart.ToString(), Effector);
        }

        public void OnEffectorTriggerDettached()
        {
            CombatManager.Instance.RemoveObserver(OnStatusTick, TriggerCalls.OnTurnStart.ToString(), Effector);
        }

        public void OnSubActionTrigger(object sender, object args)
        {
        }

        public void OnStatusTick(object sender, object args)
        {
            int amount = Amount;
            Amount /= 2;
            if (!TryRemoveSlotStatusEffect())
            {
                Effector.SlotStatusEffectValuesChanged(EffectType, useSpecialSound: false, Amount - amount);
            }
        }

        public void OnStatusTriggered(object sender, object args)
        {
            if (sender is IUnit unit && args is CanHealReference healBy)
            {
                healBy.value = false;
                if (healBy.healAmount > 0)
                {
                    int amount = Amount;
                    Amount += healBy.healAmount;
                    Effector.SlotStatusEffectValuesChanged(EffectType, useSpecialSound: false, Amount - amount);
                }
            }
        }

        public int CalculateShieldModifier(int amount)
        {
            int num = Mathf.Min(Amount, amount);
            Amount -= num;
            if (num < amount)
            {
                num += Mathf.Min(Restrictor, amount - num);
            }

            CombatManager.Instance.AddUIAction(new PlayShieldEffectUIAction(SlotID, IsCharacterSlot, num));
            if (!TryRemoveSlotStatusEffect())
            {
                Effector.SlotStatusEffectValuesChanged(EffectType, useSpecialSound: true, 0, justWaitForPopUpTime: true);
            }

            return num;
        }

        public void DettachRestrictor()
        {
            Restrictor--;
            if (!TryRemoveSlotStatusEffect())
            {
                Effector.SlotStatusEffectValuesChanged(EffectType, useSpecialSound: false, 0);
            }
        }

        public bool TryRemoveSlotStatusEffect()
        {
            if (Amount <= 0 && CanBeRemoved)
            {
                Effector.RemoveSlotStatusEffect(EffectType);
                return true;
            }

            return false;
        }
    }
    public class ApplyMoldSlotEffect : EffectSO
    {
        [SerializeField]
        public bool _usePreviousExitValue;

        [SerializeField]
        public int _previousExtraAddition;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            if (_usePreviousExitValue)
            {
                entryVariable = _previousExtraAddition + entryVariable * base.PreviousExitValue;
            }

            exitAmount = 0;
            if (entryVariable <= 0)
            {
                return false;
            }
            //Debug.Log("we got into it");
            stats.slotStatusEffectDataBase.TryGetValue((SlotStatusEffectType)862351, out var value);
            //Debug.Log("grabbed");
            for (int i = 0; i < targets.Length; i++)
            {
                ISlotStatusEffect slotEffect = new Mold_SlotStatusEffect(targets[i].SlotID, entryVariable, targets[i].IsTargetCharacterSlot);
                

                //Debug.Log("Set");

                ISlotStatusEffector effector = targets[i] as ISlotStatusEffector;
                if (targets[i].IsTargetCharacterSlot)
                {
                    foreach (CombatSlot slot in stats.combatSlots._characterSlots)
                    {
                        if (slot.SlotID == targets[i].SlotID)
                        {
                            effector = slot as ISlotStatusEffector;
                        }
                    }
                }
                else
                {
                    foreach (CombatSlot slot in stats.combatSlots._enemySlots)
                    {
                        if (slot.SlotID == targets[i].SlotID)
                        {
                            effector = slot as ISlotStatusEffector;
                        }
                    }
                }
                //Debug.Log("Effector found");
                bool hasItAlready = false;
                int thisIndex = 999;
                for (int index = 0; index < effector.StatusEffects.Count; index++)
                {
                    //Debug.Log("starting a check");
                    if (effector.StatusEffects[index].EffectType == slotEffect.EffectType)
                    {
                        thisIndex = index;
                        hasItAlready = true;
                        //Debug.Log("has it");
                    }
                }
                //Debug.Log("checked");
                if (hasItAlready == true)
                {
                    ConstructorInfo[] constructors = effector.StatusEffects[thisIndex].GetType().GetConstructors();
                    foreach (ConstructorInfo constructor in constructors)
                    {
                        if (constructor.GetParameters().Length == 4)
                        {
                            slotEffect = (ISlotStatusEffect)Activator.CreateInstance(effector.StatusEffects[thisIndex].GetType(), targets[i].SlotID, entryVariable, targets[i].IsTargetCharacterSlot, 0);
                        }
                    }
                }

                slotEffect.SetEffectInformation(value);
                if (stats.combatSlots.ApplySlotStatusEffect(targets[i].SlotID, targets[i].IsTargetCharacterSlot, entryVariable, slotEffect))
                {
                    exitAmount += entryVariable;
                }
            }
            //Debug.Log("done");
            return exitAmount > 0;
        }
    }
    public class PlaySlotEffectPopupUIAction : CombatAction
    {
        public int _id;

        public bool _isUnitCharacter;

        public int _amount;
        public SlotStatusEffectInfoSO _status;

        public StatusFieldEffectPopUpType _popUpType;

        public PlaySlotEffectPopupUIAction(int id, bool isUnitCharacter, int amount, SlotStatusEffectInfoSO status, StatusFieldEffectPopUpType popUpType)
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
                vector = stats.combatUI._characterZone.GetCharacterPosition(_id);
                stats.combatUI.PlaySoundOnPosition(_status.UpdatedSoundEvent, vector);
                int ppu = 32;
                Sprite sprite = Sprite.Create(_status.icon.texture, new Rect(0, 0, _status.icon.texture.width, _status.icon.texture.height), new Vector2(0.5f, 0.5f), ppu);
                yield return stats.combatUI._popUpHandler3D.StartStatusFieldShowcase(false, vector, _popUpType, _amount, sprite);
            }
            else
            {
                stats.combatUI._enemiesInCombat.TryGetValue(_id, out enemy);
                vector = stats.combatUI._enemyZone.GetEnemyPosition(_id);
                stats.combatUI.PlaySoundOnPosition(_status.UpdatedSoundEvent, vector);
                int ppu = 32;
                Sprite sprite = Sprite.Create(_status.icon.texture, new Rect(0, 0, _status.icon.texture.width, _status.icon.texture.height), new Vector2(0.5f, 0.5f), ppu);
                yield return stats.combatUI._popUpHandler3D.StartStatusFieldShowcase(true, vector, _popUpType, _amount, sprite);
            }
        }
    }
}
