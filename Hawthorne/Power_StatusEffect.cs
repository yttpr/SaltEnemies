using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Hawthorne;
using System.Reflection;
using System.Diagnostics.Contracts;

namespace THE_DEAD
{
    public class Power_StatusEffect : IStatusEffect, ITriggerEffect<IStatusEffector>
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

        public StatusEffectType EffectType => (StatusEffectType)456789;

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

        public Power_StatusEffect(int amount, int restrictors = 0)
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

            (args as DamageDealtValueChangeException).AddModifier((IntValueModifier)new PowerValueModifier(this.Amount));
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
    public class PowerValueModifier : IntValueModifier
    {
        public readonly int toPow;

        public PowerValueModifier(int toPow)
          : base(69)
        {
            this.toPow = toPow;
        }

        public override int Modify(int value)
        {
            //if (value > 0)

            return value + this.toPow;

            //return value;
        }
    }
    public class ApplyPowerEffect : EffectSO
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
            stats.statusEffectDataBase.TryGetValue((StatusEffectType)456789, out effectInfo);




            for (int index = 0; index < targets.Length; ++index)
            {
                if (targets[index].HasUnit)
                {
                    int amount = this._randomBetweenPrevious ? UnityEngine.Random.Range(this.PreviousExitValue, entryVariable + 1) : entryVariable;
                    IStatusEffect powerStatusEffect = new Power_StatusEffect(amount);

                    
                    IStatusEffector effector = targets[index].Unit as IStatusEffector;
                    bool hasItAlready = false;
                    int thisIndex = 999;
                    for (int i = 0; i < effector.StatusEffects.Count; i++)
                    {
                        if (effector.StatusEffects[i].EffectType == powerStatusEffect.EffectType)
                        {
                            thisIndex = i;
                            hasItAlready = true;
                        }
                    }
                    if (hasItAlready == true && powerStatusEffect.GetType() != effector.StatusEffects[thisIndex].GetType())
                    {
                        ConstructorInfo[] constructors = effector.StatusEffects[thisIndex].GetType().GetConstructors();
                        foreach (ConstructorInfo constructor in constructors)
                        {
                            if (constructor.GetParameters().Length == 2)
                            {
                                powerStatusEffect = (IStatusEffect)Activator.CreateInstance(effector.StatusEffects[thisIndex].GetType(), amount, 0);
                            }
                        }
                    }

                    powerStatusEffect.SetEffectInformation(effectInfo);
                    try
                    {
                        if (targets[index].Unit.ApplyStatusEffect(powerStatusEffect, amount))
                            ++exitAmount;
                    }
                    catch (Exception ex)
                    {
                        CombatManager.Instance.AddUIAction(new ShowAttackInformationUIAction(targets[index].Unit.ID, targets[index].Unit.IsUnitCharacter, "so uh Power was attempted to be applied to this character but it failed and wouldve softlocked normally. so erm. just pretend this didnt happen!"));
                        Debug.LogError(ex.ToString());
                        Debug.LogError(ex.Message + ex.StackTrace);
                    }
                }
            }

            return exitAmount > 0;
        }
    }
    public class ApplyPercentHPPowerEffect : EffectSO
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
            TargetSlotInfo hitYou = new TargetSlotInfo(caster.SlotID, false);
            exitAmount = 0;
            if (entryVariable <= 0)
                return false;

            StatusEffectInfoSO effectInfo;
            stats.statusEffectDataBase.TryGetValue((StatusEffectType)456789, out effectInfo);

            int maxHP = caster.MaximumHealth;
            decimal gap0 = (decimal)maxHP;
            gap0 /= 8;
            decimal gap10 = gap0;
            gap10 *= 2;
            decimal gap1 = Math.Ceiling(gap0);
            decimal gap11 = Math.Ceiling(gap10);
            int gap12 = (int)gap11;
            int gap2 = (int)gap1;
            entryVariable = gap2;

            for (int index = 0; index < targets.Length; ++index)
            {
                if (targets[index].HasUnit)
                {
                    IWearableEffector wearableEffector = caster as IWearableEffector;
                    CombatManager.Instance.AddUIAction(new ShowItemInformationUIAction(wearableEffector.ID, "Its Wings", false, Hawthorne.ResourceLoader.LoadSprite("itswings", 32)));
                    int amount = this._randomBetweenPrevious ? UnityEngine.Random.Range(this.PreviousExitValue, entryVariable + 1) : entryVariable;
                    int selfAmount = gap12;

                    IStatusEffect powerStatusEffect = new Power_StatusEffect(amount);
                    IStatusEffector targetEffector = targets[index].Unit as IStatusEffector;
                    bool TargetHasItAlready = false;
                    int TargetIndex = 999;
                    for (int i = 0; i < targetEffector.StatusEffects.Count; i++)
                    {
                        if (targetEffector.StatusEffects[i].EffectType == powerStatusEffect.EffectType)
                        {
                            TargetIndex = i;
                            TargetHasItAlready = true;
                        }
                    }
                    if (TargetHasItAlready == true && powerStatusEffect.GetType() != targetEffector.StatusEffects[TargetIndex].GetType())
                    {
                        ConstructorInfo[] constructors = targetEffector.StatusEffects[TargetIndex].GetType().GetConstructors();
                        foreach (ConstructorInfo constructor in constructors)
                        {
                            if (constructor.GetParameters().Length == 2)
                            {
                                powerStatusEffect = (IStatusEffect)Activator.CreateInstance(targetEffector.StatusEffects[TargetIndex].GetType(), amount, 0);
                            }
                        }
                    }



                    IStatusEffect selfPower = new Power_StatusEffect(selfAmount);
                    IStatusEffector effector = caster as IStatusEffector;
                    bool hasItAlready = false;
                    int thisIndex = 999;
                    for (int i = 0; i < effector.StatusEffects.Count; i++)
                    {
                        if (effector.StatusEffects[i].EffectType == selfPower.EffectType)
                        {
                            thisIndex = i;
                            hasItAlready = true;
                        }
                    }
                    if (hasItAlready == true && selfPower.GetType() != effector.StatusEffects[thisIndex].GetType())
                    {
                        ConstructorInfo[] constructors = effector.StatusEffects[thisIndex].GetType().GetConstructors();
                        foreach (ConstructorInfo constructor in constructors)
                        {
                            if (constructor.GetParameters().Length == 2)
                            {
                                selfPower = (IStatusEffect)Activator.CreateInstance(effector.StatusEffects[thisIndex].GetType(), selfAmount, 0);
                            }
                        }
                    }

                    powerStatusEffect.SetEffectInformation(effectInfo);
                    selfPower.SetEffectInformation(effectInfo);

                    if (targets[index].Unit.ApplyStatusEffect((IStatusEffect)powerStatusEffect, amount))
                    {
                        ++exitAmount;
                        if (caster.ApplyStatusEffect((IStatusEffect)selfPower, selfAmount))
                        {
                            ++exitAmount;
                        }
                    }
                }
            }

            return exitAmount > 0;
        }
    }
    public class ApplyPowerRangePlusOneEffect : EffectSO
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

            StatusEffectInfoSO effectInfo;
            stats.statusEffectDataBase.TryGetValue((StatusEffectType)456789, out effectInfo);
            



            for (int index = 0; index < targets.Length; ++index)
            {
                if (targets[index].HasUnit)
                {
                    int amount = entryVariable + UnityEngine.Random.Range(0, 2);
                    if (amount > 0)
                    {
                        //Debug.Log("above one");
                        IStatusEffect powerStatusEffect = new Power_StatusEffect(amount);


                        IStatusEffector effector = targets[index].Unit as IStatusEffector;
                        bool hasItAlready = false;
                        int thisIndex = 999;
                        for (int i = 0; i < effector.StatusEffects.Count; i++)
                        {
                            if (effector.StatusEffects[i].EffectType == powerStatusEffect.EffectType)
                            {
                                thisIndex = i;
                                hasItAlready = true;
                                //Debug.Log("has it already");
                            }
                        }
                        if (hasItAlready)
                        {
                            ConstructorInfo[] constructors = effector.StatusEffects[thisIndex].GetType().GetConstructors();
                            foreach (ConstructorInfo constructor in constructors)
                            {
                                if (constructor.GetParameters().Length == 2)
                                {
                                    powerStatusEffect = (IStatusEffect)Activator.CreateInstance(effector.StatusEffects[thisIndex].GetType(), amount, 0);
                                    //Debug.Log("instance set");
                                }
                            }
                        }

                        powerStatusEffect.SetEffectInformation(effectInfo);
                        //Debug.Log("info set");
                        if (targets[index].Unit.ApplyStatusEffect((IStatusEffect)powerStatusEffect, amount))
                            exitAmount += amount;
                        //Debug.Log("done");
                    }
                }
            }

            return exitAmount > 0;
        }
    }
    public class ApplyPowerRangePlusOneFirstInOrderEffect : EffectSO
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
            stats.statusEffectDataBase.TryGetValue((StatusEffectType)456789, out effectInfo);
            entryVariable += UnityEngine.Random.Range(0, 2);



            for (int index = 0; index < targets.Length; ++index)
            {
                if (targets[index].HasUnit)
                {
                    int amount = this._randomBetweenPrevious ? UnityEngine.Random.Range(this.PreviousExitValue, entryVariable + 1) : entryVariable;
                    IStatusEffect powerStatusEffect = new Power_StatusEffect(amount);


                    IStatusEffector effector = targets[index].Unit as IStatusEffector;
                    bool hasItAlready = false;
                    int thisIndex = 999;
                    for (int i = 0; i < effector.StatusEffects.Count; i++)
                    {
                        if (effector.StatusEffects[i].EffectType == powerStatusEffect.EffectType)
                        {
                            thisIndex = i;
                            hasItAlready = true;
                        }
                    }
                    if (hasItAlready == true && powerStatusEffect.GetType() != effector.StatusEffects[thisIndex].GetType())
                    {
                        ConstructorInfo[] constructors = effector.StatusEffects[thisIndex].GetType().GetConstructors();
                        foreach (ConstructorInfo constructor in constructors)
                        {
                            if (constructor.GetParameters().Length == 2)
                            {
                                powerStatusEffect = (IStatusEffect)Activator.CreateInstance(effector.StatusEffects[thisIndex].GetType(), amount, 0);
                            }
                        }
                    }

                    powerStatusEffect.SetEffectInformation(effectInfo);
                    if (targets[index].Unit.ApplyStatusEffect((IStatusEffect)powerStatusEffect, amount))
                    {
                        ++exitAmount;
                        return exitAmount > 0;
                    }
                }
            }

            return exitAmount > 0;
        }
    }
    public class ApplyPowerLowestHealthTargetEffect : EffectSO
    {
        [SerializeField]
        public bool _justOneTarget;
        [SerializeField]
        public bool _randomBetweenPrevious = false;

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
            stats.statusEffectDataBase.TryGetValue((StatusEffectType)456789, out effectInfo);
            entryVariable += UnityEngine.Random.Range(0, 2);

            List<TargetSlotInfo> list = new List<TargetSlotInfo>();
            int num = -1;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (targetSlotInfo.HasUnit && targetSlotInfo.Unit.IsAlive)
                {
                    if (num < 0)
                    {
                        list.Add(targetSlotInfo);
                        num = targetSlotInfo.Unit.CurrentHealth;
                    }
                    else if (targetSlotInfo.Unit.CurrentHealth < num)
                    {
                        list.Clear();
                        list.Add(targetSlotInfo);
                        num = targetSlotInfo.Unit.CurrentHealth;
                    }
                    else if (targetSlotInfo.Unit.CurrentHealth == num)
                    {
                        list.Add(targetSlotInfo);
                    }
                }
            }
            for (int index = 0; index < list.Count; ++index)
            {
                if (list[index].HasUnit)
                {
                    int amount = this._randomBetweenPrevious ? UnityEngine.Random.Range(this.PreviousExitValue, entryVariable + 1) : entryVariable;
                    IStatusEffect powerStatusEffect = new Power_StatusEffect(amount);


                    IStatusEffector effector = list[index].Unit as IStatusEffector;
                    bool hasItAlready = false;
                    int thisIndex = 999;
                    for (int i = 0; i < effector.StatusEffects.Count; i++)
                    {
                        if (effector.StatusEffects[i].EffectType == powerStatusEffect.EffectType)
                        {
                            thisIndex = i;
                            hasItAlready = true;
                        }
                    }
                    if (hasItAlready == true && powerStatusEffect.GetType() != effector.StatusEffects[thisIndex].GetType())
                    {
                        ConstructorInfo[] constructors = effector.StatusEffects[thisIndex].GetType().GetConstructors();
                        foreach (ConstructorInfo constructor in constructors)
                        {
                            if (constructor.GetParameters().Length == 2)
                            {
                                powerStatusEffect = (IStatusEffect)Activator.CreateInstance(effector.StatusEffects[thisIndex].GetType(), amount, 0);
                            }
                        }
                    }

                    powerStatusEffect.SetEffectInformation(effectInfo);
                    if (list[index].Unit.ApplyStatusEffect((IStatusEffect)powerStatusEffect, amount))
                        ++exitAmount;
                }
            }

            return exitAmount > 0;
        }
    }


    public class RemovePowerEffect : EffectSO
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

            entryVariable *= -1;//multiplies entry amount by -1, so putting entry amount 1 makes it remove 1 stack

            StatusEffectInfoSO effectInfo;
            stats.statusEffectDataBase.TryGetValue((StatusEffectType)456789, out effectInfo);
            //change this to your status effect type

            for (int index = 0; index < targets.Length; ++index)
            {
                if (targets[index].HasUnit)
                {
                    if (targets[index].Unit.ContainsStatusEffect(effectInfo.statusEffectType, (entryVariable * -1) + 1))//if the target has status effects at least 1 greater than the amount you intend to remove
                    {
                        int amount = this._randomBetweenPrevious ? UnityEngine.Random.Range(this.PreviousExitValue, entryVariable + 1) : entryVariable;
                        IStatusEffect status = new Power_StatusEffect(amount);
                        //change this to your status effect

                        IStatusEffector effector = targets[index].Unit as IStatusEffector;
                        bool hasItAlready = false;
                        int thisIndex = 999;
                        for (int i = 0; i < effector.StatusEffects.Count; i++)
                        {
                            if (effector.StatusEffects[i].EffectType == status.EffectType)
                            {
                                thisIndex = i;
                                hasItAlready = true;
                            }
                        }
                        if (hasItAlready == true && status.GetType() != effector.StatusEffects[thisIndex].GetType())
                        {
                            ConstructorInfo[] constructors = effector.StatusEffects[thisIndex].GetType().GetConstructors();
                            foreach (ConstructorInfo constructor in constructors)
                            {
                                if (constructor.GetParameters().Length == 2)
                                {
                                    status = (IStatusEffect)Activator.CreateInstance(effector.StatusEffects[thisIndex].GetType(), amount, 0);
                                }
                            }
                        }

                        status.SetEffectInformation(effectInfo);
                        if (targets[index].Unit.ApplyStatusEffect((IStatusEffect)status, amount))
                            exitAmount += amount;
                        //all this code does is just apply the negative amount of the status effect.
                    }
                    else //if the target has equal or less stacks of the status you're trying to remove, just fully remove it
                    {
                        exitAmount += targets[index].Unit.TryRemoveStatusEffect(effectInfo.statusEffectType);
                    }
                }
            }

            return exitAmount > 0;
        }
    }

    public class Anesthetics_StatusEffect : IStatusEffect, ITriggerEffect<IStatusEffector>
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

        public StatusEffectType EffectType => (StatusEffectType)204308;

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

        public Anesthetics_StatusEffect(int amount, int restrictors = 0)
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
            CombatManager.Instance.AddObserver(new Action<object, object>(this.OnTurnStart), TriggerCalls.OnTurnStart.ToString(), caller);
        }

        public void OnTriggerDettached(IStatusEffector caller)
        {
            CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnStatusTriggered), TriggerCalls.OnBeingDamaged.ToString(), caller);
            CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnTurnStart), TriggerCalls.OnTurnStart.ToString(), caller);
        }

        public void OnSubActionTrigger(object sender, object args, bool stateCheck)
        {
        }

        public void OnStatusTriggered(object sender, object args)
        {
            if ((args as DamageReceivedValueChangeException).amount < this.Amount)
            {
                (args as DamageReceivedValueChangeException).AddModifier((IntValueModifier)new AnestheticsValueModifier((args as DamageReceivedValueChangeException).amount));
            }
            if ((args as DamageReceivedValueChangeException).amount >= this.Amount)
            {
                (args as DamageReceivedValueChangeException).AddModifier((IntValueModifier)new AnestheticsValueModifier(this.Amount));
            }
        }

        public void OnTurnStart(object sender, object args)
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
    public class AnestheticsValueModifier : IntValueModifier
    {
        public readonly int toNumb;

        public AnestheticsValueModifier(int toNumb)
          : base(70)
        {
            this.toNumb = toNumb;
        }

        public override int Modify(int value)
        {
            if (value > 0)
            {
                return Math.Max(value - this.toNumb, 0);
            }
            return Math.Max(value, 0);
        }
    }
    public class ApplyAnestheticsEffect : EffectSO
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
            stats.statusEffectDataBase.TryGetValue((StatusEffectType)204308, out effectInfo);
            StatusEffectInfoSO scarEffectInfo;
            stats.statusEffectDataBase.TryGetValue(StatusEffectType.Scars, out scarEffectInfo);



            for (int index = 0; index < targets.Length; ++index)
            {
                if (targets[index].HasUnit)
                {
                    int amount = this._randomBetweenPrevious ? UnityEngine.Random.Range(this.PreviousExitValue, entryVariable + 1) : entryVariable;
                    IStatusEffect numbStatusEffect = new Anesthetics_StatusEffect(amount);

                    

                    IStatusEffector effector = targets[index].Unit as IStatusEffector;
                    bool hasItAlready = false;
                    int thisIndex = 999;
                    for (int i = 0; i < effector.StatusEffects.Count; i++)
                    {
                        if (effector.StatusEffects[i].EffectType == numbStatusEffect.EffectType)
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
                                numbStatusEffect = (IStatusEffect)Activator.CreateInstance(effector.StatusEffects[thisIndex].GetType(), amount, 0);
                            }
                        }
                    }

                    numbStatusEffect.SetEffectInformation(effectInfo);
                    if (targets[index].Unit.ApplyStatusEffect((IStatusEffect)numbStatusEffect, amount))
                        ++exitAmount;
                }
            }

            return exitAmount > 0;
        }
    }


    public class Determined_StatusEffect : IStatusEffect, ITriggerEffect<IStatusEffector>
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

        public StatusEffectType EffectType => (StatusEffectType)555556;

        public StatusEffectInfoSO EffectInfo { get; set; }

        public void SetEffectInformation(StatusEffectInfoSO effectInfo)
        {
            this.EffectInfo = effectInfo;
            /*
            EffectInfo.icon = ResourceLoader.LoadSprite("Anesthetics", 32);
            EffectInfo._statusName = "Anesthetics";
            EffectInfo.statusEffectType = (StatusEffectType)204308;
            EffectInfo._description = "All damage received will be decreased by 1 for each Anesthetic, this applies to both direct and indirect damage. This effect cannot decrease damage to levels below zero.";
            EffectInfo._applied_SE_Event = effectInfo._applied_SE_Event;
            EffectInfo._removed_SE_Event = effectInfo._removed_SE_Event;
            EffectInfo._updated_SE_Event = effectInfo._updated_SE_Event;
            EffectInfo._special01_SE_Event = effectInfo._special01_SE_Event;
            EffectInfo._special02_SE_Event = effectInfo._special02_SE_Event;
            //EffectInfo._locID = "";
            //EffectInfo._locAbilityData.text = "Anesthetics";
            //EffectInfo._locAbilityData.description = "All damage received will be decreased by 1 for each Anesthetic, this applies to both direct and indirect damage. This effect cannot decrease damage to levels below zero.";
            */
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

        public Determined_StatusEffect(int amount, int restrictors = 0)
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
            CombatManager.Instance.AddObserver(new Action<object, object>(this.OnStatusTriggered), TriggerCalls.CanDie.ToString(), caller);
            CombatManager.Instance.AddObserver(new Action<object, object>(this.OnTurnEnd), TriggerCalls.OnTurnStart.ToString(), caller);
        }

        public void OnTriggerDettached(IStatusEffector caller)
        {
            CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnStatusTriggered), TriggerCalls.CanDie.ToString(), caller);
            CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnTurnEnd), TriggerCalls.OnTurnStart.ToString(), caller);
        }

        public void OnSubActionTrigger(object sender, object args, bool stateCheck)
        {
            int restoreVal = this.Amount;
            if ((sender as IUnit).ContainsStatusEffect(StatusEffectType.Cursed) || (sender as IUnit).ContainsPassiveAbility(PassiveAbilityTypes.Dying) || (sender as IUnit).ContainsPassiveAbility(PassiveAbilityTypes.Inanimate))
            { (sender as IUnit).DirectDeath(null, false); }
            else { (sender as IUnit).Heal(restoreVal, HealType.Heal, true); }//THIS STUFF IS SPECIFIC TO MY STATUS EFFECT
            this.DeleteDuration(sender as IStatusEffector);//THIS IS THE DELETE DURATION LINE
        }

        public void OnStatusTriggered(object sender, object args)
        {
            BooleanReference reference = args as BooleanReference;
            if (reference == null)
                return;
            reference.value = false;//THIS SPECIFIC TO MY STATUS EFFECT; YOU DONT NEED IT
            CombatManager.Instance.AddSubAction(new PerformStatusEffectAction(this, sender, args, false));
            //PUT THE ABOVE LINE IN YOUR IF STATEMENT

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

        public void RemoveDuration(IStatusEffector effector)
        {
            if (!this.CanReduceDuration)
            {
                return;
            }
            int duration = this.Amount;
            this.Amount = 0;
            if (!this.TryRemoveStatusEffect(effector) && duration != this.Amount)
            {
                effector.StatusEffectValuesChanged(this.EffectType, this.Amount - duration);
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
    public class ApplyDeterminedEffect : EffectSO
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

            //stats.statusEffectDataBase.Add((StatusEffectType)204308, Anesthetics);
            //CombatManager.Instance._stats.statusEffectDataBase.Add((StatusEffectType)204308, anesthetics);
            StatusEffectInfoSO effectInfo;
            stats.statusEffectDataBase.TryGetValue((StatusEffectType)555556, out effectInfo);




            for (int index = 0; index < targets.Length; ++index)
            {
                if (targets[index].HasUnit)
                {
                    int amount = this._randomBetweenPrevious ? UnityEngine.Random.Range(this.PreviousExitValue, entryVariable + 1) : entryVariable;
                    IStatusEffect thisStatusEffect = new Determined_StatusEffect(amount);


                    
                    IStatusEffector effector = targets[index].Unit as IStatusEffector;
                    bool hasItAlready = false;
                    int thisIndex = 999;
                    for (int i = 0; i < effector.StatusEffects.Count; i++)
                    {
                        if (effector.StatusEffects[i].EffectType == thisStatusEffect.EffectType)
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
                                thisStatusEffect = (IStatusEffect)Activator.CreateInstance(effector.StatusEffects[thisIndex].GetType(), amount, 0);
                            }
                        }
                    }

                    thisStatusEffect.SetEffectInformation(effectInfo);
                    if (targets[index].Unit.ApplyStatusEffect((IStatusEffect)thisStatusEffect, amount))
                        ++exitAmount;
                }
            }

            return exitAmount > 0;
        }
    }

    public class HealHalfLastEffect : EffectSO
    {
        [SerializeField]
        public bool _directHeal = true;

        [SerializeField]
        public bool _onlyIfHasHealthOver0;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            float gap = base.PreviousExitValue;
            gap /= 2;
            entryVariable = (int)Math.Floor(gap); //or math.ceiling for rounding up

            exitAmount = 0;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (targetSlotInfo.HasUnit && (!_onlyIfHasHealthOver0 || targetSlotInfo.Unit.CurrentHealth > 0))
                {
                    int num = entryVariable;

                    exitAmount += targetSlotInfo.Unit.Heal(num, HealType.Heal, _directHeal);
                }
            }

            return exitAmount > 0;
        }
    }
}
