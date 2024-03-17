using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace Hawthorne
{
    public static class MyStatusEffects
    {
        public static void Add()
        {
            IDetour addGloomIDetour = (IDetour)new Hook((MethodBase)typeof(CombatManager).GetMethod("InitializeCombat", ~BindingFlags.Default), typeof(MyStatusEffects).GetMethod("AddGloomStatusEffect", ~BindingFlags.Default));
            IDetour addSporesIDetour = (IDetour)new Hook((MethodBase)typeof(CombatManager).GetMethod("InitializeCombat", ~BindingFlags.Default), typeof(MyStatusEffects).GetMethod("AddSporesStatusEffect", ~BindingFlags.Default));
            IDetour addGloomIntentIDetour = (IDetour)new Hook((MethodBase)typeof(IntentHandlerSO).GetMethod("Initialize", ~BindingFlags.Default), typeof(MyStatusEffects).GetMethod("GloomIntent", ~BindingFlags.Default));
            IDetour addSporesIntentIDetour = (IDetour)new Hook((MethodBase)typeof(IntentHandlerSO).GetMethod("Initialize", ~BindingFlags.Default), typeof(MyStatusEffects).GetMethod("SporesIntent", ~BindingFlags.Default));

        }

        public static StatusEffectInfoSO gloom = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
        private static void AddGloomStatusEffect(Action<CombatManager> orig, CombatManager self)
        {
            orig(self);
            //StatusEffectInfoSO anesthetics;
            gloom.name = "Gloom";
            gloom.icon = ResourceLoader.LoadSprite("GloomSprite", 32);
            gloom._statusName = "Gloom";
            gloom.statusEffectType = (StatusEffectType)666667;
            gloom._description = "Increase direct damage taken by 1% for each stack of gloom. Increase stacks by 1 for each direct damage taken. If gloom is 7 or higher and if cursed, recieve 7-13 indirect damage after taking direct damage. Reduce by half at the end of turn.";
            gloom._applied_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Cursed].AppliedSoundEvent;
            gloom._updated_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Ruptured].UpdatedSoundEvent;
            gloom._removed_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Ruptured].RemovedSoundEvent;
            StatusEffectInfoSO effectInfo;
            self._stats.statusEffectDataBase.TryGetValue((StatusEffectType)666667, out effectInfo);
            if (effectInfo == null)
                self._stats.statusEffectDataBase.Add((StatusEffectType)666667, gloom);
        }
        public static StatusEffectInfoSO spores = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
        private static void AddSporesStatusEffect(Action<CombatManager> orig, CombatManager self)
        {
            orig(self);
            spores.name = "Spores";
            spores.icon = ResourceLoader.LoadSprite("VenusSpores", 32);
            spores._statusName = "Spores";
            spores.statusEffectType = (StatusEffectType)202303;
            spores._description = "Deal 1-3 indirect pigment damage for every 3 stacks of this effect at the end of each turn and decrease by half.";
            spores._applied_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Ruptured].AppliedSoundEvent;
            spores._updated_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Ruptured].UpdatedSoundEvent;
            spores._removed_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Ruptured].RemovedSoundEvent;
            StatusEffectInfoSO effectInfo;
            self._stats.statusEffectDataBase.TryGetValue((StatusEffectType)202303, out effectInfo);
            if (effectInfo == null)
                self._stats.statusEffectDataBase.Add((StatusEffectType)202303, spores);
        }

        public static IntentInfo gloomIntent = new IntentInfoBasic();
        private static void GloomIntent(Action<IntentHandlerSO> orig, IntentHandlerSO self)
        {
            orig(self);
            gloomIntent._type = (IntentType)987897;
            gloomIntent._sprite = ResourceLoader.LoadSprite("GloomSprite", 32);
            gloomIntent._color = Color.white;
            gloomIntent._sound = self._intentDB[IntentType.Status_Scars]._sound;
            IntentInfo intentInfo;
            self._intentDB.TryGetValue((IntentType)987897, out intentInfo);
            if (intentInfo == null)
                self._intentDB.Add((IntentType)987897, (IntentInfo)gloomIntent);
        }
        public static IntentInfo sporesIntent = new IntentInfoBasic();
        private static void SporesIntent(Action<IntentHandlerSO> orig, IntentHandlerSO self)
        {
            orig(self);
            sporesIntent._type = (IntentType)987892;
            sporesIntent._sprite = ResourceLoader.LoadSprite("VenusSpores", 32);
            sporesIntent._color = Color.white;
            sporesIntent._sound = self._intentDB[IntentType.Status_Ruptured]._sound;
            IntentInfo intentInfo;
            self._intentDB.TryGetValue((IntentType)987892, out intentInfo);
            if (intentInfo == null)
                self._intentDB.Add((IntentType)987892, (IntentInfo)sporesIntent);
        }
    }
}
namespace THE_DEAD
{
    public class Gloom_StatusEffect : IStatusEffect, ITriggerEffect<IStatusEffector>
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

        public StatusEffectType EffectType => (StatusEffectType)666667;

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

        public Gloom_StatusEffect(int amount, int restrictors = 0)
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
            CombatManager.Instance.AddObserver(new Action<object, object>(this.OnTurnEnd), TriggerCalls.OnTurnFinished.ToString(), caller);
        }

        public void OnTriggerDettached(IStatusEffector caller)
        {
            CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnStatusTriggered), TriggerCalls.OnBeingDamaged.ToString(), caller);
            CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnTurnEnd), TriggerCalls.OnTurnFinished.ToString(), caller);
        }

        public void OnSubActionTrigger(object sender, object args, bool stateCheck)
        {
            if ((sender as IUnit).ContainsStatusEffect(StatusEffectType.Cursed))
            {
                int hitAmount = UnityEngine.Random.Range(7, 14);
                (sender as IUnit).Damage(hitAmount, null, DeathType.Basic, -1, false, false, true);
            }
        }

        public void OnStatusTriggered(object sender, object args)
        {
            DamageReceivedValueChangeException valueChangeException = args as DamageReceivedValueChangeException;
            if (!valueChangeException.directDamage)
                return;
            //if (valueChangeException.directDamage)
            //{
            int hittedBy = (args as DamageReceivedValueChangeException).amount;
            (args as DamageReceivedValueChangeException).AddModifier((IntValueModifier)new GloomValueModifier(this.Amount));
            this.IncreaseDuration(sender as IStatusEffector, hittedBy);
            if (this.Amount > 6)
            {
                CombatManager.Instance.AddSubAction(new PerformStatusEffectAction(this, sender, args, false));
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
            int duration = this.Amount;
            this.Amount /= 2;
            if (!this.TryRemoveStatusEffect(effector) && duration != this.Amount)
            {
                effector.StatusEffectValuesChanged(this.EffectType, this.Amount - duration);
            }
        }

        public void IncreaseDuration(IStatusEffector effector, int amount)
        {

            int duration = this.Amount;
            this.Amount += amount;
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
    public class GloomValueModifier : IntValueModifier
    {
        public readonly int toNumb;

        public GloomValueModifier(int toNumb)
          : base(70)
        {
            this.toNumb = toNumb;
        }

        public override int Modify(int value)
        {
            if (value > 0)
            {
                decimal hitBoost = this.toNumb;
                decimal valueX = value;
                hitBoost *= valueX;
                valueX *= 100;
                valueX += hitBoost;
                valueX /= 100; ;
                value = (int)Math.Ceiling(valueX);
                return value;
            }
            return value;
        }
    }
    public class ApplyGloomEffect : EffectSO
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
            stats.statusEffectDataBase.TryGetValue((StatusEffectType)666667, out effectInfo);




            for (int index = 0; index < targets.Length; ++index)
            {
                if (targets[index].HasUnit)
                {
                    int amount = this._randomBetweenPrevious ? UnityEngine.Random.Range(this.PreviousExitValue, entryVariable + 1) : entryVariable;
                    IStatusEffect gloomStatusEffect = new Gloom_StatusEffect(amount);
                    
                    IStatusEffector effector = targets[index].Unit as IStatusEffector;
                    bool hasItAlready = false;
                    int thisIndex = 999;
                    for (int i = 0; i < effector.StatusEffects.Count; i++)
                    {
                        if (effector.StatusEffects[i].EffectType == gloomStatusEffect.EffectType)
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
                                gloomStatusEffect = (IStatusEffect)Activator.CreateInstance(effector.StatusEffects[thisIndex].GetType(), amount, 0);
                            }
                        }
                    }

                    gloomStatusEffect.SetEffectInformation(effectInfo);
                    if (targets[index].Unit.ApplyStatusEffect((IStatusEffect)gloomStatusEffect, amount))
                        ++exitAmount;
                }
            }

            return exitAmount > 0;
        }
    }

    public class Spores_StatusEffect : IStatusEffect, ITriggerEffect<IStatusEffector>
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

        public StatusEffectType EffectType => (StatusEffectType)202303;

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

        public Spores_StatusEffect(int amount, int restrictors = 0)
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
            CombatManager.Instance.AddObserver(new Action<object, object>(this.OnStatusTriggered), TriggerCalls.OnTurnFinished.ToString(), caller);
            //CombatManager.Instance.AddObserver(new Action<object, object>(this.OnTurnStart), TriggerCalls.OnTurnFinished.ToString(), caller);
        }

        public void OnTriggerDettached(IStatusEffector caller)
        {
            CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnStatusTriggered), TriggerCalls.OnTurnFinished.ToString(), caller);
            //CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnTurnStart), TriggerCalls.OnTurnFinished.ToString(), caller);
        }

        public void OnSubActionTrigger(object sender, object args, bool stateCheck)
        {
            int amount = UnityEngine.Random.Range(1, 4);
            IUnit unit = sender as IUnit;
            unit.Damage(amount, (IUnit)null, DeathType.Obliteration, 0, false, false, true, DamageType.Mana);
        }

        public void OnStatusTriggered(object sender, object args)
        {
            decimal aamount = (decimal)this.Amount;
            int runIt = (int)Math.Ceiling(aamount / 3);
            int runnIng = 0;
            while (runnIng < runIt)
            {
                CombatManager.Instance.AddSubAction((CombatAction)new PerformStatusEffectAction((IStatusEffect)this, sender, args, false));
                runnIng++;
            }
            this.ReduceDuration(sender as IStatusEffector);
        }

        public void OnTurnStart(object sender, object args)
        {

        }

        public void ReduceDuration(IStatusEffector effector)
        {
            if (!this.CanReduceDuration)
            {
                return;
            }
            int duration = this.Amount;
            this.Amount /= 2;
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
    public class ApplySporesEffect : EffectSO
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
            stats.statusEffectDataBase.TryGetValue((StatusEffectType)202303, out effectInfo);



            for (int index = 0; index < targets.Length; ++index)
            {
                if (targets[index].HasUnit)
                {
                    int amount = this._randomBetweenPrevious ? UnityEngine.Random.Range(this.PreviousExitValue, entryVariable + 1) : entryVariable;
                    IStatusEffect numbStatusEffect = new Spores_StatusEffect(amount);

                    

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
}
