using BrutalAPI;
using Hawthorne.NewFolder;
using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace Hawthorne
{
    public static class Favor
    {
        public static StatusEffectInfoSO favor = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
        public static void AddFavorStatusEffect(Action<CombatManager> orig, CombatManager self)
        {
            orig(self);
            favor.name = "Favor";
            favor.icon = ResourceLoader.LoadSprite("FavorIcon", 32);
            favor._statusName = "Favor";
            favor.statusEffectType = (StatusEffectType)544512;
            favor._description = "At the end of each turn, heal this unit 1-2. If this unit is healed from any source other than this status effect, remove this status, Curse them, and deal an agonizing amount of indirect damage to them. \nOnly one unit may be Favored at a time.";
            favor._applied_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.DivineProtection].AppliedSoundEvent;
            favor._updated_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.DivineProtection].UpdatedSoundEvent;
            favor._removed_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.DivineProtection].RemovedSoundEvent;
            StatusEffectInfoSO effectInfo;
            self._stats.statusEffectDataBase.TryGetValue((StatusEffectType)544512, out effectInfo);
            if (effectInfo == null)
                self._stats.statusEffectDataBase.Add((StatusEffectType)544512, favor);
        }
        public static IntentInfo favorIntent = new IntentInfoBasic();
        public static void FavorIntent(Action<IntentHandlerSO> orig, IntentHandlerSO self)
        {
            orig(self);
            favorIntent._type = (IntentType)544512;
            favorIntent._sprite = ResourceLoader.LoadSprite("FavorIcon", 32);
            favorIntent._color = UnityEngine.Color.white;
            favorIntent._sound = self._intentDB[IntentType.Status_DivineProtection]._sound;
            IntentInfo intentInfo;
            self._intentDB.TryGetValue((IntentType)544512, out intentInfo);
            if (intentInfo == null)
                self._intentDB.Add((IntentType)544512, (IntentInfo)favorIntent);
        }
        public static void Add()
        {
            IDetour addFavorEffectIDetour = (IDetour)new Hook((MethodBase)typeof(CombatManager).GetMethod("InitializeCombat", ~BindingFlags.Default), typeof(Favor).GetMethod("AddFavorStatusEffect", ~BindingFlags.Default));
            IDetour addFavorEffectIntentIDetour = (IDetour)new Hook((MethodBase)typeof(IntentHandlerSO).GetMethod("Initialize", ~BindingFlags.Default), typeof(Favor).GetMethod("FavorIntent", ~BindingFlags.Default));
        }
    }
    public class Favor_StatusEffect : IStatusEffect, ITriggerEffect<IStatusEffector>
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

        public IStatusEffector Effector { get; set; }

        public bool IsPositive => true;

        public string DisplayText
        {
            get
            {
                string text = "";
                if (Restrictor > 0)
                {
                    text = text + "(" + Restrictor + ")";
                }

                return text;
            }
        }

        public int Amount { get; set; }

        public StatusEffectType EffectType => (StatusEffectType)544512;

        public StatusEffectInfoSO EffectInfo { get; set; }

        public void SetEffectInformation(StatusEffectInfoSO effectInfo)
        {
            this.EffectInfo = effectInfo;
        }



        

        

        public bool AddContent(IStatusEffect content)
        {
            return false;
        }

        public bool TryAddContent(int amount)
        {
            return false;
        }

        public int JustRemoveAllContent()
        {
            return 0;
        }


        public void OnTriggerAttached(IStatusEffector caller)
        {
            Effector = caller;
            CombatManager.Instance.PostNotification(((TriggerCalls)544512).ToString(), null, null);
            CombatManager.Instance.AddObserver(new Action<object, object>(this.OnStatusTriggered), TriggerCalls.CanHeal.ToString(), caller);
            //CombatManager.Instance.AddObserver(new Action<object, object>(this.OnStatusSubTriggered), TriggerCalls.OnKill.ToString(), caller);
            CombatManager.Instance.AddObserver(OnStatusSubTriggered, ((TriggerCalls)544512).ToString());
            //CombatManager.Instance.AddObserver(new Action<object, object>(this.OnStatusTriggered), TriggerCalls.CanHeal.ToString(), caller);
            CombatManager.Instance.AddObserver(new Action<object, object>(this.OnTurnEnd), TriggerCalls.OnTurnFinished.ToString(), caller);
        }

        public void OnTriggerDettached(IStatusEffector caller)
        {
            CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnStatusTriggered), TriggerCalls.CanHeal.ToString(), caller);
            //CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnStatusSubTriggered), TriggerCalls.OnKill.ToString(), caller);
            CombatManager.Instance.RemoveObserver(OnStatusSubTriggered, ((TriggerCalls)544512).ToString());
            //CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnStatusTriggered), TriggerCalls.CanHeal.ToString(), caller);
            CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnTurnEnd), TriggerCalls.OnTurnFinished.ToString(), caller);
        }

        public void OnSubActionTrigger(object sender, object args, bool stateCheck)
        {

        }


        //public int timerCount = 30;
        public bool selfHealing = false;

        public void OnStatusTriggered(object sender, object args)
        {
            if (!selfHealing)
            {
                DamageEffect indirect = ScriptableObject.CreateInstance<DamageEffect>();
                indirect._indirect = true;
                Effect effort1 = new Effect(ScriptableObject.CreateInstance<ApplyCursedEffect>(), 1, null, Slots.Self);
                Effect effort2 = new Effect(indirect, UnityEngine.Random.Range(7, 11), null, Slots.Self);
                CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[2] { effort1, effort2 }), sender as IUnit));
                Effector.RemoveStatusEffect(EffectType);
            }
        }

        public void OnStatusSubTriggered(object sender, object args)
        {
            Effector.RemoveStatusEffect(EffectType);
        }



        public void OnTurnEnd(object sender, object args)
        {
            selfHealing = true;
            (sender as IUnit).Heal(UnityEngine.Random.Range(1, 3), (HealType)544512, true);
            selfHealing = false;
        }

        public void ReduceDuration(IStatusEffector effector)
        {
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
    public class ApplyFavorEffect : EffectSO
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

            StatusEffectInfoSO effectInfo;
            stats.statusEffectDataBase.TryGetValue((StatusEffectType)544512, out effectInfo);




            for (int index = 0; index < targets.Length; ++index)
            {
                if (targets[index].HasUnit)
                {
                    int amount = this._randomBetweenPrevious ? UnityEngine.Random.Range(this.PreviousExitValue, entryVariable + 1) : entryVariable;
                    Favor_StatusEffect statuseffect = new Favor_StatusEffect();

                    statuseffect.SetEffectInformation(effectInfo);
                    /*IStatusEffector effector = targets[index].Unit as IStatusEffector;
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
                        CombatManager.Instance.AddUIAction(new PlayStatusEffectPopupUIAction(targets[index].Unit.ID, targets[index].Unit.IsUnitCharacter, 0, effector.StatusEffects[thisIndex].EffectInfo, StatusFieldEffectPopUpType.Sign));
                        exitAmount ++;
                    }*/
                    try
                    {
                        if (targets[index].Unit.ApplyStatusEffect((IStatusEffect)statuseffect, 0))
                            ++exitAmount;
                    }
                    catch
                    {
                        Debug.LogError("apply favor broke");
                    }
                }
            }

            return exitAmount > 0;
        }
    }
    public class ApplyFavorSingleEffect : EffectSO
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

            StatusEffectInfoSO effectInfo;
            stats.statusEffectDataBase.TryGetValue((StatusEffectType)544512, out effectInfo);

            List<TargetSlotInfo> reTargets = new List<TargetSlotInfo>();
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    reTargets.Add(target);
                }
            }
            if (reTargets.Count <= 0)
            {
                return false;
            }
            int choosing = UnityEngine.Random.Range(0, reTargets.Count);


            if (reTargets[choosing].HasUnit)
            {
                int amount = this._randomBetweenPrevious ? UnityEngine.Random.Range(this.PreviousExitValue, entryVariable + 1) : entryVariable;
                Favor_StatusEffect statuseffect = new Favor_StatusEffect();

                statuseffect.SetEffectInformation(effectInfo);
                /*IStatusEffector effector = reTargets[choosing].Unit as IStatusEffector;
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
                    CombatManager.Instance.AddUIAction(new PlayStatusEffectPopupUIAction(reTargets[choosing].Unit.ID, reTargets[choosing].Unit.IsUnitCharacter, 0, effector.StatusEffects[thisIndex].EffectInfo, StatusFieldEffectPopUpType.Sign));
                    exitAmount++;
                }
                else */
                try 
                { 
                    if (reTargets[choosing].Unit.ApplyStatusEffect((IStatusEffect)statuseffect, 0))
                        ++exitAmount;
                }
                catch
                {
                    Debug.LogError("apply favor fail");
                }
            }
            

            return exitAmount > 0;
        }
    }
}
