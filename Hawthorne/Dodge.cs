using MonoMod.RuntimeDetour;
using System;
using System.Reflection;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using System.Collections;
using MonoMod.RuntimeDetour.HookGen;
using System.Collections.Generic;
using Hawthorne;
using static UnityEngine.UI.CanvasScaler;

namespace PYMN4
{
    public static class Dodge
    {
        public static int dodge = 588489;

        public static StatusEffectType Type = (StatusEffectType)dodge;
        
        public static TriggerCalls Call = (TriggerCalls)dodge;

        public static SwapToSidesEffect swap = ScriptableObject.CreateInstance<SwapToSidesEffect>();

        public static void SwapUnitToSides(TargetSlotInfo slot, IUnit unit)
        {
            swap.PerformEffect(CombatManager.Instance._stats, unit, new TargetSlotInfo[] { slot }, true, 1, out var exit);
        }

        public static TargetSlotInfo[] GetTargets(Func<BaseCombatTargettingSO, SlotsCombat, int, bool, TargetSlotInfo[]> orig, BaseCombatTargettingSO self, SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            TargetSlotInfo[] targets = orig(self, slots, casterSlotID, isCasterCharacter);
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit && target.Unit.ContainsStatusEffect(Type))
                {
                    if (UnityEngine.Random.Range(0, 100) < chance && (target.Unit.IsUnitCharacter != isCasterCharacter)) 
                    { 
                        SwapUnitToSides(target, target.Unit);
                        CombatManager.Instance.PostNotification(Dodge.Call.ToString(), target.Unit, null);
                    }
                }
            }
            return orig(self, slots, casterSlotID, isCasterCharacter);
        }

        public static ApplyDodgeEffect dodgeApply = ScriptableObject.CreateInstance<ApplyDodgeEffect>();

        public static void TickDodge(IUnit unit, TargetSlotInfo slot)
        {
            if (unit.ContainsStatusEffect(Type, 2))
            {
                dodgeApply.PerformEffect(CombatManager.Instance._stats, slot.Unit, new TargetSlotInfo[] { slot }, true, -1, out var exit);
            }
            else
            {
                unit.TryRemoveStatusEffect(Type);
            }
        }
        
        public static int StartEffect(Func<EffectInfo, CombatStats, IUnit, TargetSlotInfo[], bool, int, int> orig, EffectInfo self, CombatStats stats, IUnit caster, TargetSlotInfo[] possibleTargets, bool areTargetSlots, int previousExitValue)
        {
            bool allSlotsSelected = false;
            List<int> slots = new List<int>();
            foreach (TargetSlotInfo slot in possibleTargets)
            {
                if (!slots.Contains(slot.SlotID))
                    slots.Add(slot.SlotID);
            }
            if (slots.Count >= 5) allSlotsSelected = true;
            if ((areTargetSlots) && (!allSlotsSelected))
            {
                bool redoTarget = false;
                foreach (TargetSlotInfo target in possibleTargets)
                {
                    if (target.HasUnit && target.Unit.ContainsStatusEffect(Type))
                    {
                        if (UnityEngine.Random.Range(0, 100) < chance && (target.Unit.IsUnitCharacter != caster.IsUnitCharacter))
                        {
                            //TickDodge(target.Unit, target);
                            CombatManager.Instance.PostNotification(Dodge.Call.ToString(), target.Unit, null);
                            SwapUnitToSides(target, target.Unit);
                            redoTarget = true;
                        }
                    }
                }
                if (redoTarget)
                {
                    possibleTargets = ((self.targets != null) ? self.targets.GetTargets(stats.combatSlots, caster.SlotID, caster.IsUnitCharacter) : new TargetSlotInfo[0]);
                    areTargetSlots = !(self.targets != null) || self.targets.AreTargetSlots;
                }
            }
            return orig(self, stats, caster, possibleTargets, areTargetSlots, previousExitValue);
        }

        public static Sprite dodgeSprite = Hawthorne.ResourceLoader.LoadSprite("Dodge.png", 32);

        public static string name = "Dodge";

        public static int chance = 100;

        public static string description = "On being targetted by an ability by an opponent, " + chance.ToString() + "% chance to move left or right to avoid it. " + name + " decreases by 1 at the start of each turn and on activation.";

        public static IntentInfo dodgeIntent = new IntentInfoBasic();

        public static void AddDodgeIntent(Action<IntentHandlerSO> orig, IntentHandlerSO self)
        {
            orig(self);
            dodgeIntent._type = (IntentType)dodge;
            dodgeIntent._sprite = dodgeSprite;
            dodgeIntent._color = Color.white;
            dodgeIntent._sound = self._intentDB[IntentType.Field_Shield]._sound;
            IntentInfo intentInfo;
            self._intentDB.TryGetValue((IntentType)dodge, out intentInfo);
            if (intentInfo == null)
                self._intentDB.Add((IntentType)dodge, (IntentInfo)dodgeIntent);
        }

        public static StatusEffectInfoSO dodgeInfo = ScriptableObject.CreateInstance<StatusEffectInfoSO>();

        public static void AddDodgeStatus(Action<CombatManager> orig, CombatManager self)
        {
            orig(self);
            dodgeInfo.name = name;
            dodgeInfo.icon = dodgeSprite;
            dodgeInfo._statusName = name;
            dodgeInfo.statusEffectType = Type;
            dodgeInfo._description = description;
            dodgeInfo._applied_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Ruptured].UpdatedSoundEvent;
            dodgeInfo._updated_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Ruptured].UpdatedSoundEvent;
            dodgeInfo._removed_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Ruptured].RemovedSoundEvent;
            StatusEffectInfoSO effectInfo;
            self._stats.statusEffectDataBase.TryGetValue(Type, out effectInfo);
            if (effectInfo == null)
            { 
                self._stats.statusEffectDataBase.Add(Type, dodgeInfo);
                Setup();
            }
            else
            {
                Set = true;
            }
        }

        public static bool ApplyStatusEffectCH(Func<CharacterCombat, IStatusEffect, int, bool> orig, CharacterCombat self, IStatusEffect statusEffect, int amount)
        {
            for (int i = 0; i < self.StatusEffects.Count; i++)
            {
                IStatusEffect statusEffect2 = self.StatusEffects[i];
                if (statusEffect2.EffectType == statusEffect.EffectType)
                {
                    if (statusEffect.GetType() == statusEffect2.GetType())
                    {
                        return orig(self, statusEffect, amount);
                    }
                    IStatusEffect getThis = statusEffect2;
                    ConstructorInfo[] constructors = statusEffect2.GetType().GetConstructors();
                    foreach (ConstructorInfo construct in constructors)
                    {
                        if (construct.GetParameters().Length == 2)
                        {
                            getThis = (IStatusEffect)Activator.CreateInstance(statusEffect2.GetType(), statusEffect.StatusContent, statusEffect.Restrictor);
                        }
                        else if (construct.GetParameters().Length == 0)
                        {
                            getThis = (IStatusEffect)Activator.CreateInstance(statusEffect2.GetType());
                        }
                        else if (construct.GetParameters().Length == 1)
                        {
                            getThis = (IStatusEffect)Activator.CreateInstance(statusEffect2.GetType(), statusEffect.Restrictor);
                        }
                        else
                        {
                            return false;
                        }
                    }
                    getThis.SetEffectInformation(statusEffect.EffectInfo);
                    return orig(self, getThis, amount);
                }
            }

            return orig(self, statusEffect, amount);
        }

        public static bool ApplyStatusEffectEN(Func<EnemyCombat, IStatusEffect, int, bool> orig, EnemyCombat self, IStatusEffect statusEffect, int amount)
        {
            for (int i = 0; i < self.StatusEffects.Count; i++)
            {
                IStatusEffect statusEffect2 = self.StatusEffects[i];
                if (statusEffect2.EffectType == statusEffect.EffectType)
                {
                    if (statusEffect.GetType() == statusEffect2.GetType())
                    {
                        return orig(self, statusEffect, amount);
                    }
                    IStatusEffect getThis = statusEffect2;
                    ConstructorInfo[] constructors = statusEffect2.GetType().GetConstructors();
                    foreach (ConstructorInfo construct in constructors)
                    {
                        if (construct.GetParameters().Length == 2)
                        {
                            getThis = (IStatusEffect)Activator.CreateInstance(statusEffect2.GetType(), statusEffect.StatusContent, statusEffect.Restrictor);
                        }
                        else if (construct.GetParameters().Length == 0)
                        {
                            getThis = (IStatusEffect)Activator.CreateInstance(statusEffect2.GetType());
                        }
                        else if (construct.GetParameters().Length == 1)
                        {
                            getThis = (IStatusEffect)Activator.CreateInstance(statusEffect2.GetType(), statusEffect.Restrictor);
                        }
                        else
                        {
                            return false;
                        }
                    }
                    getThis.SetEffectInformation(statusEffect.EffectInfo);
                    return orig(self, getThis, amount);
                }
            }

            return orig(self, statusEffect, amount);
        }

        //call this in awake
        public static void Add()
        {
            
            IDetour addDodgeIDetour = (IDetour)new Hook((MethodBase)typeof(CombatManager).GetMethod(nameof(CombatManager.InitializeCombat), ~BindingFlags.Default), typeof(Dodge).GetMethod(nameof(Dodge.AddDodgeStatus), ~BindingFlags.Default));
            IDetour addDodgeIntentIDetour = (IDetour)new Hook((MethodBase)typeof(IntentHandlerSO).GetMethod(nameof(IntentHandlerSO.Initialize), ~BindingFlags.Default), typeof(Dodge).GetMethod(nameof(Dodge.AddDodgeIntent), ~BindingFlags.Default));
            IDetour CharacterIDetour = (IDetour)new Hook((MethodBase)typeof(CharacterCombat).GetMethod(nameof(CharacterCombat.ApplyStatusEffect), ~BindingFlags.Default), typeof(Dodge).GetMethod(nameof(Dodge.ApplyStatusEffectCH), ~BindingFlags.Default));
            IDetour EnemyIDetour = (IDetour)new Hook((MethodBase)typeof(EnemyCombat).GetMethod(nameof(EnemyCombat.ApplyStatusEffect), ~BindingFlags.Default), typeof(Dodge).GetMethod(nameof(Dodge.ApplyStatusEffectEN), ~BindingFlags.Default));
        }

        public static bool Set = false;
        public static void Setup()
        {
            if (Set) return; Set = true;
            IDetour dodgeHook = new Hook(typeof(EffectInfo).GetMethod(nameof(EffectInfo.StartEffect), ~BindingFlags.Default), typeof(Dodge).GetMethod(nameof(Dodge.StartEffect), ~BindingFlags.Default));
        }
    }

    public class Dodge_StatusEffect : IStatusEffect, ITriggerEffect<IStatusEffector>
    {
        public int StatusContent => Duration;

        public int Restrictor { get; set; }

        public bool CanBeRemoved => Restrictor <= 0;

        public bool IsPositive => true;

        public string DisplayText
        {
            get
            {
                string text = "";
                if (Duration > 0)
                {
                    text += Duration;
                }

                if (Restrictor > 0)
                {
                    text = text + "(" + Restrictor + ")";
                }

                return text;
            }
        }

        public int Duration { get; set; }

        public StatusEffectType EffectType => Dodge.Type;

        public StatusEffectInfoSO EffectInfo { get; set; }

        public bool CanReduceDuration
        {
            get
            {
                BooleanReference booleanReference = new BooleanReference(entryValue: true);
                CombatManager.Instance.ProcessImmediateAction(new CheckHasStatusFieldReductionBlockIAction(booleanReference));
                return !booleanReference.value;
            }
        }

        public void SetEffectInformation(StatusEffectInfoSO effectInfo)
        {
            EffectInfo = effectInfo;
        }

        public Dodge_StatusEffect(int duration, int restrictors = 0)
        {
            Duration = duration;
            Restrictor = restrictors;
        }

        public bool AddContent(IStatusEffect content)
        {
            Duration += content.StatusContent;
            Restrictor += content.Restrictor;
            return true;
        }

        public bool TryAddContent(int amount)
        {
            if (Duration <= 0)
            {
                return false;
            }

            Duration += amount;
            return true;
        }

        public int JustRemoveAllContent()
        {
            int duration = Duration;
            Duration = 0;
            return duration;
        }

        public void OnTriggerAttached(IStatusEffector caller)
        {
            CombatManager.Instance.AddObserver(OnStatusTick, Dodge.Call.ToString(), caller);
            CombatManager.Instance.AddObserver(OnStatusTick, TriggerCalls.OnTurnStart.ToString(), caller);
        }

        public void OnTriggerDettached(IStatusEffector caller)
        {
            CombatManager.Instance.RemoveObserver(OnStatusTick, Dodge.Call.ToString(), caller);
            CombatManager.Instance.RemoveObserver(OnStatusTick, TriggerCalls.OnTurnStart.ToString(), caller);
        }

        public void OnSubActionTrigger(object sender, object args, bool stateCheck)
        {
        }

        public void OnStatusTriggered(object sender, object args)
        {
        }

        public void OnStatusTick(object sender, object args)
        {
            ReduceDuration(sender as IStatusEffector);
            //Debug.Log("blah");
        }

        public void ReduceDuration(IStatusEffector effector)
        {
            if (CanReduceDuration)
            {
                int duration = Duration;
                Duration = Mathf.Max(0, Duration - 1);
                if (!TryRemoveStatusEffect(effector) && duration != Duration)
                {
                    effector.StatusEffectValuesChanged(EffectType, Duration - duration);
                }
            }
        }

        public void DettachRestrictor(IStatusEffector effector)
        {
            Restrictor--;
            if (!TryRemoveStatusEffect(effector))
            {
                effector.StatusEffectValuesChanged(EffectType, 0);
            }
        }

        public bool TryRemoveStatusEffect(IStatusEffector effector)
        {
            if (Duration <= 0 && CanBeRemoved)
            {
                effector.RemoveStatusEffect(EffectType);
                return true;
            }

            return false;
        }
    }

    public class ApplyDodgeEffect : EffectSO
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
            stats.statusEffectDataBase.TryGetValue(Dodge.Type, out effectInfo);


            for (int index = 0; index < targets.Length; ++index)
            {
                if (targets[index].HasUnit)
                {
                    int amount = this._randomBetweenPrevious ? UnityEngine.Random.Range(this.PreviousExitValue, entryVariable + 1) : entryVariable;
                    Dodge_StatusEffect statusEffect = new Dodge_StatusEffect(amount);

                    statusEffect.SetEffectInformation(effectInfo);
                    if (targets[index].Unit.ApplyStatusEffect((IStatusEffect)statusEffect, amount))
                        exitAmount += amount;
                }
            }

            return exitAmount > 0;
        }
    }
}

namespace Hawthorne
{
    public static class Terror
    {
        public static int terror = 308236;

        public static StatusEffectType Type = (StatusEffectType)terror;

        public static IntentType Intent = (IntentType)terror;

        public static Sprite terrorSprite = Hawthorne.ResourceLoader.LoadSprite("terror.png", 32);

        public static string name = "Terror";

        public static string description = "This unit lives its life in fear.";

        public static IntentInfo terrorIntent = new IntentInfoBasic();

        public static void AddTerrorIntent(Action<IntentHandlerSO> orig, IntentHandlerSO self)
        {
            orig(self);
            terrorIntent._type = (IntentType)terror;
            terrorIntent._sprite = terrorSprite;
            terrorIntent._color = Color.white;
            terrorIntent._sound = self._intentDB[IntentType.Status_Cursed]._sound;
            IntentInfo intentInfo;
            self._intentDB.TryGetValue((IntentType)terror, out intentInfo);
            if (intentInfo == null)
                self._intentDB.Add((IntentType)terror, (IntentInfo)terrorIntent);
        }

        public static StatusEffectInfoSO terrorInfo = ScriptableObject.CreateInstance<StatusEffectInfoSO>();

        public static void AddTerrorStatus(Action<CombatManager> orig, CombatManager self)
        {
            orig(self);
            terrorInfo.name = name;
            terrorInfo.icon = terrorSprite;
            terrorInfo._statusName = name;
            terrorInfo.statusEffectType = Type;
            terrorInfo._description = description;
            terrorInfo._applied_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Cursed].UpdatedSoundEvent;
            terrorInfo._updated_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Cursed].UpdatedSoundEvent;
            terrorInfo._removed_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Cursed].RemovedSoundEvent;
            StatusEffectInfoSO effectInfo;
            self._stats.statusEffectDataBase.TryGetValue(Type, out effectInfo);
            if (effectInfo == null)
            {
                self._stats.statusEffectDataBase.Add(Type, terrorInfo);
            }
        }
        
        public static void Add()
        {

            IDetour addDodgeIDetour = (IDetour)new Hook((MethodBase)typeof(CombatManager).GetMethod(nameof(CombatManager.InitializeCombat), ~BindingFlags.Default), typeof(Terror).GetMethod(nameof(AddTerrorStatus), ~BindingFlags.Default));
            IDetour addDodgeIntentIDetour = (IDetour)new Hook((MethodBase)typeof(IntentHandlerSO).GetMethod(nameof(IntentHandlerSO.Initialize), ~BindingFlags.Default), typeof(Terror).GetMethod(nameof(AddTerrorIntent), ~BindingFlags.Default));
        }
    }

    public class Terror_StatusEffect : IStatusEffect, ITriggerEffect<IStatusEffector>
    {
        public int StatusContent => Duration;

        public int Restrictor { get; set; }

        public bool CanBeRemoved => Restrictor <= 0;

        public bool IsPositive => false;

        public string DisplayText
        {
            get
            {
                string text = "";
                if (Duration > 0)
                {
                    //text += Duration;
                }

                if (Restrictor > 0)
                {
                    text = text + "(" + Restrictor + ")";
                }

                return text;
            }
        }

        public int Duration { get; set; }

        public StatusEffectType EffectType => Terror.Type;

        public StatusEffectInfoSO EffectInfo { get; set; }

        public bool CanReduceDuration
        {
            get
            {
                BooleanReference booleanReference = new BooleanReference(entryValue: true);
                CombatManager.Instance.ProcessImmediateAction(new CheckHasStatusFieldReductionBlockIAction(booleanReference));
                return !booleanReference.value;
            }
        }

        public void SetEffectInformation(StatusEffectInfoSO effectInfo)
        {
            EffectInfo = effectInfo;
        }

        public Terror_StatusEffect(int duration, int restrictors = 0)
        {
            Duration = duration;
            Restrictor = restrictors;
        }

        public bool AddContent(IStatusEffect content)
        {
            Duration += content.StatusContent;
            Restrictor += content.Restrictor;
            return true;
        }

        public bool TryAddContent(int amount)
        {
            if (Duration <= 0)
            {
                return false;
            }

            Duration += amount;
            return true;
        }

        public int JustRemoveAllContent()
        {
            int duration = Duration;
            Duration = 0;
            return duration;
        }

        public void OnTriggerAttached(IStatusEffector caller)
        {
        }

        public void OnTriggerDettached(IStatusEffector caller)
        {
        }

        public void OnSubActionTrigger(object sender, object args, bool stateCheck)
        {
        }

        public void OnStatusTriggered(object sender, object args)
        {
        }

        public void OnStatusTick(object sender, object args)
        {
            ReduceDuration(sender as IStatusEffector);
            //Debug.Log("blah");
        }

        public void ReduceDuration(IStatusEffector effector)
        {
            if (CanReduceDuration)
            {
                int duration = Duration;
                Duration = Mathf.Max(0, Duration - 1);
                if (!TryRemoveStatusEffect(effector) && duration != Duration)
                {
                    effector.StatusEffectValuesChanged(EffectType, Duration - duration);
                }
            }
        }

        public void DettachRestrictor(IStatusEffector effector)
        {
            Restrictor--;
            if (!TryRemoveStatusEffect(effector))
            {
                effector.StatusEffectValuesChanged(EffectType, 0);
            }
        }

        public bool TryRemoveStatusEffect(IStatusEffector effector)
        {
            if (Duration <= 0 && CanBeRemoved)
            {
                effector.RemoveStatusEffect(EffectType);
                return true;
            }

            return false;
        }
    }

    public class ApplyTerrorEffect : EffectSO
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
            stats.statusEffectDataBase.TryGetValue(Terror.Type, out effectInfo);


            for (int index = 0; index < targets.Length; ++index)
            {
                if (targets[index].HasUnit)
                {
                    int amount = this._randomBetweenPrevious ? UnityEngine.Random.Range(this.PreviousExitValue, entryVariable + 1) : entryVariable;
                    Terror_StatusEffect statusEffect = new Terror_StatusEffect(amount);

                    statusEffect.SetEffectInformation(effectInfo);
                    if (targets[index].Unit.ApplyStatusEffect((IStatusEffect)statusEffect, 0))
                        exitAmount += amount;
                }
            }

            return exitAmount > 0;
        }
    }

    public class TerrorDeathEffect : EffectSO
    {
        [Header("Visual")]
        [SerializeField]
        public AttackVisualsSO _visuals = LoadedAssetsHandler.GetEnemyAbility("Chomp_A").visuals;

        [SerializeField]
        public BaseCombatTargettingSO _animationTarget = BrutalAPI.Slots.Self;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach(TargetSlotInfo target in targets)
            {
                if (target.HasUnit && target.Unit.ContainsStatusEffect(Terror.Type))
                {
                    CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(caster.ID, caster.IsUnitCharacter, Passi.Hunter._passiveName, Passi.Hunter.passiveIcon));
                    CombatManager.Instance.AddUIAction(new TerrorAction(_visuals, target, caster));
                    exitAmount++;
                }
            }
            return exitAmount > 0;
        }
    }
    public class TerrorAction : CombatAction
    {
        public TargetSlotInfo _targetting;

        public AttackVisualsSO _visuals;

        public IUnit _caster;

        public TerrorAction(AttackVisualsSO visuals, TargetSlotInfo targetting, IUnit caster)
        {
            _visuals = visuals;
            _targetting = targetting;
            _caster = caster;
        }

        public override IEnumerator Execute(CombatStats stats)
        {
            yield return stats.combatUI.PlayAbilityAnimation(_visuals, new TargetSlotInfo[] { _targetting }, true);
            if (_targetting.HasUnit) _targetting.Unit.DirectDeath(_caster);
        }
    }

    public class ApplyTerrorIfNoneEffect : EffectSO
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

            bool anybody = false;
            if (caster.IsUnitCharacter)
            {
                foreach (EnemyCombat enemy in stats.EnemiesOnField.Values)
                {
                    if (enemy.ContainsStatusEffect(Terror.Type)) anybody = true;
                }
            }
            else
            {
                foreach (CharacterCombat chara in stats.CharactersOnField.Values)
                {
                    if (chara.ContainsStatusEffect(Terror.Type)) anybody = true;
                }
            }
            if (anybody) return false;

            StatusEffectInfoSO effectInfo;
            stats.statusEffectDataBase.TryGetValue(Terror.Type, out effectInfo);


            for (int index = 0; index < targets.Length; ++index)
            {
                if (targets[index].HasUnit)
                {
                    int amount = this._randomBetweenPrevious ? UnityEngine.Random.Range(this.PreviousExitValue, entryVariable + 1) : entryVariable;
                    Terror_StatusEffect statusEffect = new Terror_StatusEffect(amount);

                    statusEffect.SetEffectInformation(effectInfo);
                    if (targets[index].Unit.ApplyStatusEffect((IStatusEffect)statusEffect, 0))
                        exitAmount += amount;
                }
            }

            return exitAmount > 0;
        }
    }

    public class RejuvinationPassiveAbility : BasePassiveAbilitySO
    {
        public override bool IsPassiveImmediate => true;

        public override bool DoesPassiveTrigger => true;

        public override void TriggerPassive(object sender, object args)
        {
            if (args is BooleanReference booleanReference && sender is IUnit unit)
            {
                if (booleanReference.value == false) return;
                if (unit.MaximumHealth > 4)
                {
                    CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(unit.ID, unit.IsUnitCharacter, _passiveName, passiveIcon));
                    if (GibsWithHeal(unit, unit.MaximumHealth - unit.CurrentHealth, HealType.Heal, true) > 0)
                    {
                        booleanReference.value = false;
                        float gap = unit.MaximumHealth;
                        gap /= 2;
                        unit.MaximizeHealth((int)Math.Floor(gap));
                        if (unit.IsUnitCharacter)
                        {
                            ScriptableObject.CreateInstance<ApplyStunnedEffect>().PerformEffect(CombatManager.Instance._stats, unit, BrutalAPI.Slots.Self.GetTargets(CombatManager.Instance._stats.combatSlots, unit.SlotID, unit.IsUnitCharacter), BrutalAPI.Slots.Self.AreTargetSlots, 1, out int graggler);
                        }
                        else
                        {
                            CombatManager.Instance.ProcessImmediateAction(new OverexertTriggeredAction(unit.ID, unit.IsUnitCharacter));
                        }
                    }
                }
                ScriptableObject.CreateInstance<ApplyFireSlotEffect>().PerformEffect(CombatManager.Instance._stats, unit, BrutalAPI.Slots.Self.GetTargets(CombatManager.Instance._stats.combatSlots, unit.SlotID, unit.IsUnitCharacter), BrutalAPI.Slots.Self.AreTargetSlots, 1, out int exit);
            }
        }

        public override void OnPassiveConnected(IUnit unit)
        {
        }

        public override void OnPassiveDisconnected(IUnit unit)
        {
        }

        public static int GibsWithHeal(IUnit unit, int amount, HealType healType, bool directHeal)
        {
            if (!unit.IsUnitCharacter)
            {
                if (!unit.CanHeal(directHeal, amount))
                {
                    return 0;
                }

                if (!unit.IsUnitCharacter) CombatManager.Instance.AddUIAction(new SpawnEnemyGibsUIAction(unit.ID));

                IntValueChangeException ex = new IntValueChangeException(amount);
                CombatManager.Instance.PostNotification(TriggerCalls.OnBeingHealed.ToString(), unit, ex);
                int modifiedValue = ex.GetModifiedValue();
                IntegerReference args = new IntegerReference(modifiedValue);
                CombatManager.Instance.PostNotification(TriggerCalls.OnWillBeHealed.ToString(), unit, args);
                int num = Mathf.Min(unit.CurrentHealth + modifiedValue, unit.MaximumHealth);
                int num2 = num - unit.CurrentHealth;
                if (num2 != 0)
                {
                    if (unit is EnemyCombat enemy) enemy.CurrentHealth = num;
                    if (!unit.IsUnitCharacter) CombatManager.Instance.AddUIAction(new EnemyHealedUIAction(unit.ID, unit.CurrentHealth, unit.MaximumHealth, modifiedValue, healType));
                    IntegerReference args2 = new IntegerReference(num2);
                    CombatManager.Instance.PostNotification(TriggerCalls.OnHealed.ToString(), unit, args2);
                    if (directHeal)
                    {
                        CombatManager.Instance.PostNotification(TriggerCalls.OnDirectHealed.ToString(), unit, args2);
                    }
                }
                else
                {
                    CombatManager.Instance.AddUIAction(new EnemyNotHealedUIAction(unit.ID, modifiedValue, healType));
                }

                return num2;
            }
            else
            {
                return unit.Heal(amount, healType, directHeal);
            }
        }

    }

    public class RepressionPassiveAbility : BasePassiveAbilitySO
    {
        [Header("IntegerSetter Data")]
        [SerializeField]
        public bool _isItAdditive;

        [SerializeField]
        public int integerValue;

        public override bool IsPassiveImmediate => true;

        public override bool DoesPassiveTrigger => true;

        public override void TriggerPassive(object sender, object args)
        {
            IUnit caster = null;
            if (sender is IUnit unit) caster = unit;
            else
            {
                if (DoDebugs.MiscInfo) Debug.LogError("sender not iunit");
                return;
            }
            int extraTurns = caster.GetStoredValue(bonusTurns);
            if (caster.GetStoredValue(store) <= 0) 
            {
                extraTurns++;
                caster.SetStoredValue(bonusTurns, extraTurns);
            }
            caster.SetStoredValue(store, 0);
            if (args is IntegerReference integerReference)
            {
                if (_isItAdditive)
                {
                    integerReference.value += extraTurns;
                }
                else
                {
                    integerReference.value = extraTurns;
                }
            }
        }

        public static UnitStoredValueNames bonusTurns => (UnitStoredValueNames)276219;
        public UnitStoredValueNames store => PainCondition.Pain;

        public override void OnPassiveConnected(IUnit unit)
        {
            unit.SetStoredValue(bonusTurns,0);
            unit.SetStoredValue(store, 1);
            CombatManager.Instance.AddObserver(OnStatusTriggered, TriggerCalls.OnDamaged.ToString(), unit);
        }

        public override void OnPassiveDisconnected(IUnit unit)
        {
            CombatManager.Instance.RemoveObserver(OnStatusTriggered, TriggerCalls.OnDamaged.ToString(), unit);
            unit.SetStoredValue(bonusTurns, 0);
            unit.SetStoredValue(store, 0);
        }

        public void OnStatusTriggered(object sender, object args)
        {
            if (args is IntegerReference reff && reff.value > 0 && sender is IUnit unit) unit.SetStoredValue(store, unit.GetStoredValue(store) + reff.value);
        }
        public void OnStatusTick(object sender, object args)
        {
            if (sender is IUnit unit) unit.SetStoredValue(store, 0);
        }

        public static string AddStoredValueName1(
          Func<TooltipTextHandlerSO, UnitStoredValueNames, int, string> orig,
          TooltipTextHandlerSO self,
          UnitStoredValueNames storedValue,
          int value)
        {
            Color magenta = Color.magenta;
            string str1;
            if (storedValue == bonusTurns)
            {
                if (value <= 0)
                {
                    str1 = "";
                }
                else
                {
                    string str2 = "Repression" + string.Format(" x{0}", (object)(value + 1));
                    string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(new Color32(63, 205, 189, 255)) + ">";
                    string str4 = "</color>";
                    str1 = str3 + str2 + str4;
                }
            }
            else
                str1 = orig(self, storedValue, value);
            return str1;
        }

        public static void Setup()
        {
            IDetour salineVale = new Hook((MethodBase)typeof(TooltipTextHandlerSO).GetMethod(nameof(TooltipTextHandlerSO.ProcessStoredValue), ~BindingFlags.Default), typeof(RepressionPassiveAbility).GetMethod(nameof(AddStoredValueName1), ~BindingFlags.Default));
        }
    }

    public class HuntDownEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            int rightMod = 1;
            int leftMod = 1;
            if (!caster.IsUnitCharacter)
            {
                foreach (EnemyCombat enemy in stats.EnemiesOnField.Values)
                {
                    if (enemy.SlotID == caster.SlotID + caster.Size) rightMod = enemy.Size;
                    if (enemy.SlotID == caster.SlotID - enemy.Size) leftMod = enemy.Size;
                }
            }
            TargetSlotInfo Left = null;
            TargetSlotInfo Right = null;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.SlotID == caster.SlotID - leftMod) Left = target;
                else if (target.SlotID == caster.SlotID + rightMod) Right = target;
            }
            bool Lefting = (Left != null && Left.HasUnit && Left.Unit.ContainsStatusEffect(Terror.Type));
            bool righting = (Right != null && Right.HasUnit && Right.Unit.ContainsStatusEffect(Terror.Type));
            if (Lefting && righting)
            {
                ScriptableObject.CreateInstance<SwapToSidesEffect>().PerformEffect(stats, caster, BrutalAPI.Slots.Self.GetTargets(stats.combatSlots, caster.SlotID, caster.IsUnitCharacter), BrutalAPI.Slots.Self.AreTargetSlots, 1, out int grag);
                return true;
            }
            else if (Lefting)
            {
                BasicEffects.GoLeft.PerformEffect(stats, caster, BrutalAPI.Slots.Self.GetTargets(stats.combatSlots, caster.SlotID, caster.IsUnitCharacter), BrutalAPI.Slots.Self.AreTargetSlots, 1, out int grag);
                return true;
            }
            else if (righting)
            {
                BasicEffects.GoRight.PerformEffect(stats, caster, BrutalAPI.Slots.Self.GetTargets(stats.combatSlots, caster.SlotID, caster.IsUnitCharacter), BrutalAPI.Slots.Self.AreTargetSlots, 1, out int grag);
                return true;
            }
            else
            {
                ScriptableObject.CreateInstance<SwapToSidesEffect>().PerformEffect(stats, caster, BrutalAPI.Slots.Self.GetTargets(stats.combatSlots, caster.SlotID, caster.IsUnitCharacter), BrutalAPI.Slots.Self.AreTargetSlots, 1, out int grag);
                return false;
            }
        }
    }
}
