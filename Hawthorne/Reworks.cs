using BrutalAPI;
using MonoMod.RuntimeDetour;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UI.CanvasScaler;

namespace Hawthorne
{
    public static class Rework
    {
        public static void Setup()
        {
            HasteInfo.Setup();
            PhotoInfo.Setup();
            RootsInfo.Setup();
        }
    }

    public static class HasteInfo
    {
        public static int Haste => 26209926;
        public static StatusEffectInfoSO PhotoStatus = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
        public static void AddPhotoStatusEffect(Action<CombatManager> orig, CombatManager self)
        {
            orig(self);
            PhotoStatus.name = "Haste";
            PhotoStatus.icon = ResourceLoader.LoadSprite("HasteIcon.png", 32);
            PhotoStatus._statusName = "Haste";
            PhotoStatus.statusEffectType = (StatusEffectType)Haste;
            PhotoStatus._description = "On enemies: Give this enemy an extra action per turn. Decreases by 1 at the start of each round.\nOn Party Members: On performing an ability, refresh this party member and decrease Haste by 1.";
            PhotoStatus._applied_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Focused].AppliedSoundEvent;
            PhotoStatus._updated_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Focused].UpdatedSoundEvent;
            PhotoStatus._removed_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Focused].RemovedSoundEvent;
            StatusEffectInfoSO effectInfo;
            self._stats.statusEffectDataBase.TryGetValue((StatusEffectType)Haste, out effectInfo);
            if (effectInfo == null)
                self._stats.statusEffectDataBase.Add((StatusEffectType)Haste, PhotoStatus);
        }
        public static void Setup()
        {
            IDetour addLeftEffectIDetour = (IDetour)new Hook((MethodBase)typeof(CombatManager).GetMethod(nameof(CombatManager.InitializeCombat), ~BindingFlags.Default), typeof(HasteInfo).GetMethod(nameof(AddPhotoStatusEffect), ~BindingFlags.Default));
            new CustomIntentInfo("Haste", (IntentType)Haste, ResourceLoader.LoadSprite("HasteIcon"), IntentType.Status_Focused);

        }
    }
    public class Haste_StatusEffect : IStatusEffect, ITriggerEffect<IStatusEffector>
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

        public StatusEffectType EffectType => (StatusEffectType)HasteInfo.Haste;

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

        public Haste_StatusEffect(int amount, int restrictors = 0)
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
            if (caller.IsStatusEffectorCharacter) CombatManager.Instance.AddObserver(new Action<object, object>(this.CharacterTrigger), TriggerCalls.OnAbilityUsed.ToString(), caller);
            CombatManager.Instance.AddObserver(new Action<object, object>(this.OnStatusTriggered), TriggerCalls.AttacksPerTurn.ToString(), caller);
            //if (!caller.IsStatusEffectorCharacter) CombatManager.Instance.AddObserver(new Action<object, object>(this.OnTurnEnd), TriggerCalls.OnRoundFinished.ToString(), caller);
        }

        public void OnTriggerDettached(IStatusEffector caller)
        {
            if (caller.IsStatusEffectorCharacter) CombatManager.Instance.RemoveObserver(new Action<object, object>(this.CharacterTrigger), TriggerCalls.OnAbilityUsed.ToString(), caller);
            CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnStatusTriggered), TriggerCalls.AttacksPerTurn.ToString(), caller);
            //if (!caller.IsStatusEffectorCharacter) CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnTurnEnd), TriggerCalls.OnRoundFinished.ToString(), caller);
        }

        public void OnSubActionTrigger(object sender, object args, bool stateCheck)
        {
            
        }


        //public int timerCount = 30;

        public void OnStatusTriggered(object sender, object args)
        {
            if (args is IntegerReference integerReference)
            {
                integerReference.value += 1;
            }
            this.ReduceDuration(sender as IStatusEffector);
        }

        public void CharacterTrigger(object sender, object args)
        {
            if (sender is CharacterCombat chara)
            {
                chara.RefreshAbilityUse();
                DefiniteReduce(sender as IStatusEffector);
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
    public class ApplyHasteEffect : EffectSO
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
            stats.statusEffectDataBase.TryGetValue((StatusEffectType)HasteInfo.Haste, out effectInfo);




            for (int index = 0; index < targets.Length; ++index)
            {
                if (targets[index].HasUnit)
                {
                    int amount = this._randomBetweenPrevious ? UnityEngine.Random.Range(this.PreviousExitValue, entryVariable + 1) : entryVariable;
                    IStatusEffect statuseffect = new Haste_StatusEffect(amount);

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

    public static class PhotoInfo
    {
        public static int Photo => 27086124;
        public static StatusEffectInfoSO PhotoStatus = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
        public static void AddPhotoStatusEffect(Action<CombatManager> orig, CombatManager self)
        {
            orig(self);
            PhotoStatus.name = "Photo";
            PhotoStatus.icon = ResourceLoader.LoadSprite("PhotoIcon", 32);
            PhotoStatus._statusName = "Photosynthesis";
            PhotoStatus.statusEffectType = (StatusEffectType)Photo;
            PhotoStatus._description = "Multiply all healing received by this unit by the amount of Photosynthesis.";
            PhotoStatus._applied_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Focused].AppliedSoundEvent;
            PhotoStatus._updated_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Focused].UpdatedSoundEvent;
            PhotoStatus._removed_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Focused].RemovedSoundEvent;
            StatusEffectInfoSO effectInfo;
            self._stats.statusEffectDataBase.TryGetValue((StatusEffectType)Photo, out effectInfo);
            if (effectInfo == null)
                self._stats.statusEffectDataBase.Add((StatusEffectType)Photo, PhotoStatus);
        }
        public static void Setup()
        {
            IDetour addLeftEffectIDetour = (IDetour)new Hook((MethodBase)typeof(CombatManager).GetMethod(nameof(CombatManager.InitializeCombat), ~BindingFlags.Default), typeof(PhotoInfo).GetMethod(nameof(AddPhotoStatusEffect), ~BindingFlags.Default));
            new CustomIntentInfo("Photo", (IntentType)Photo, ResourceLoader.LoadSprite("PhotoIcon"), IntentType.Status_Focused);

        }
    }
    public class PhotoSynthesis_StatusEffect : IStatusEffect, ITriggerEffect<IStatusEffector>
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

        public StatusEffectType EffectType => (StatusEffectType)PhotoInfo.Photo;

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

        public PhotoSynthesis_StatusEffect(int amount, int restrictors = 0)
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

            CombatManager.Instance.AddObserver(new Action<object, object>(this.OnStatusTriggered), TriggerCalls.OnBeingHealed.ToString(), caller);
            //CombatManager.Instance.AddObserver(new Action<object, object>(this.OnTurnEnd), TriggerCalls.OnTurnFinished.ToString(), caller);
        }

        public void OnTriggerDettached(IStatusEffector caller)
        {
            CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnStatusTriggered), TriggerCalls.OnBeingHealed.ToString(), caller);
            //CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnTurnEnd), TriggerCalls.OnTurnFinished.ToString(), caller);
        }

        public void OnSubActionTrigger(object sender, object args, bool stateCheck)
        {

        }


        //public int timerCount = 30;

        public void OnStatusTriggered(object sender, object args)
        {
            if (args is IntValueChangeException healIt && healIt.amount > 0)
            {
                healIt.AddModifier(new MultiplyIntValueModifier(false, this.Amount));
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
    public class ApplyPhotoSynthesisEffect : EffectSO
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
            stats.statusEffectDataBase.TryGetValue((StatusEffectType)PhotoInfo.Photo, out effectInfo);




            for (int index = 0; index < targets.Length; ++index)
            {
                if (targets[index].HasUnit)
                {
                    int amount = this._randomBetweenPrevious ? UnityEngine.Random.Range(this.PreviousExitValue, entryVariable + 1) : entryVariable;
                    IStatusEffect statuseffect = new PhotoSynthesis_StatusEffect(amount);

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
    
    public static class RootsInfo
    {
        public static int Roots => 39370613;
        public static SlotStatusEffectInfoSO RootInfo = ScriptableObject.CreateInstance<SlotStatusEffectInfoSO>();
        public static void AddRootsSlotEffect(Action<CombatManager> orig, CombatManager self)
        {
            orig(self);
            RootInfo.name = "Roots";
            RootInfo.icon = ResourceLoader.LoadSprite("RootsIcon", 32);
            RootInfo._fieldName = "Roots";
            RootInfo.slotStatusEffectType = (SlotStatusEffectType)Roots;
            RootInfo._description = "On using an ability, deal 2-3 indirect damage to this unit, and heal all enemies with Photosynthesis the amount of damage dealt. \nReduce by 1 at the end of each turn, on a unit moving into this position, and on activation.";
            RootInfo._applied_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Scars].AppliedSoundEvent;
            RootInfo._updated_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Scars].UpdatedSoundEvent;
            RootInfo._removed_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Scars].RemovedSoundEvent;
            SlotStatusEffectInfoSO effectInfo;
            self._stats.slotStatusEffectDataBase.TryGetValue((SlotStatusEffectType)Roots, out effectInfo);
            if (effectInfo == null)
                self._stats.slotStatusEffectDataBase.Add((SlotStatusEffectType)Roots, RootInfo);
        }
        public static void Setup()
        {
            IDetour addMoldEffectIDetour = new Hook(typeof(CombatManager).GetMethod(nameof(CombatManager.InitializeCombat), ~BindingFlags.Default), typeof(RootsInfo).GetMethod(nameof(AddRootsSlotEffect), ~BindingFlags.Default));
            new CustomIntentInfo("Roots", (IntentType)Roots, ResourceLoader.LoadSprite("RootsIcon"), IntentType.Status_Ruptured);
            RootsView.Setup();
        }
    }
    public static class RootsView
    {

        public static GameObject[] RootsFool = new GameObject[5];
        public static GameObject[] RootsEnemy = new GameObject[5];

        public static GameObject Fool;
        public static GameObject Enemy;

        public static void UpdateFieldListCharacterModdedLayout(
          Action<CharacterSlotLayout, List<SlotStatusEffectInfoSO>, Sprite[], string[]> orig,
          CharacterSlotLayout self,
          List<SlotStatusEffectInfoSO> effects,
          Sprite[] icons,
          string[] texts)
        {
            self._fieldListLayout.SetInformation(self.SlotID, icons, texts, true);
            bool flag = false;
            foreach (SlotStatusEffectInfoSO effect in effects)
            {
                if (effect.slotStatusEffectType == (SlotStatusEffectType)RootsInfo.Roots)
                    flag = true;
            }
            if (Fool == null) Fool = SaltEnemies.Group4.LoadAsset<GameObject>("Assets/Roots/RootsCharacter.prefab").gameObject;
            GameObject gameObject = Fool;
            if ((UnityEngine.Object)RootsFool[self.SlotID] == (UnityEngine.Object)null)
            {
                RootsFool[self.SlotID] = UnityEngine.Object.Instantiate<GameObject>(gameObject, self.transform.localPosition, self.transform.localRotation, self._constrictedEffect.transform.parent.transform);
                RootsFool[self.SlotID].transform.localPosition = Vector3.zero;
                RootsFool[self.SlotID].transform.rotation = self._constrictedEffect.transform.rotation;
                RootsFool[self.SlotID].GetComponent<RectTransform>().anchorMin = self._shieldEffect.GetComponent<RectTransform>().anchorMin;
                RootsFool[self.SlotID].GetComponent<RectTransform>().anchorMax = self._shieldEffect.GetComponent<RectTransform>().anchorMax;
                RootsFool[self.SlotID].GetComponent<RectTransform>().position = self._shieldEffect.GetComponent<RectTransform>().position;
            }
            RootsFool[self.SlotID].SetActive(flag);
            orig(self, effects, icons, texts);
        }

        public static void UpdateFieldListModdedLayout(
          Action<EnemySlotLayout, List<SlotStatusEffectInfoSO>, Sprite[], string[]> orig,
          EnemySlotLayout self,
          List<SlotStatusEffectInfoSO> effects,
          Sprite[] icons,
          string[] texts)
        {
            self.SlotUI.UpdateFieldListLayout(self.SlotID, icons, texts);
            bool flag = false;
            using (List<SlotStatusEffectInfoSO>.Enumerator enumerator = effects.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    if (enumerator.Current.slotStatusEffectType == (SlotStatusEffectType)RootsInfo.Roots)
                        flag = true;
                }
                if (Enemy == null) Enemy = SaltEnemies.Group4.LoadAsset<GameObject>("Assets/Roots/RootsEnemy.prefab");
                GameObject original = Enemy;
                if ((UnityEngine.Object)RootsEnemy[self.SlotID] == (UnityEngine.Object)null)
                {
                    RootsEnemy[self.SlotID] = UnityEngine.Object.Instantiate<GameObject>(original, self.transform.localPosition, self.transform.localRotation, self.transform);
                    RootsEnemy[self.SlotID].transform.localPosition = Vector3.zero;
                    RootsEnemy[self.SlotID].transform.localRotation = Quaternion.identity;
                }
                RootsEnemy[self.SlotID].SetActive(flag);
                orig(self, effects, icons, texts);
            }
        }

        public static void Setup()
        {
            IDetour detour10 = (IDetour)new Hook((MethodBase)typeof(EnemySlotLayout).GetMethod("UpdateFieldListLayout", ~BindingFlags.Default), typeof(RootsView).GetMethod("UpdateFieldListModdedLayout", ~BindingFlags.Default));
            IDetour detour11 = (IDetour)new Hook((MethodBase)typeof(CharacterSlotLayout).GetMethod("UpdateFieldListLayout", ~BindingFlags.Default), typeof(RootsView).GetMethod("UpdateFieldListCharacterModdedLayout", ~BindingFlags.Default));
        }
    }
    public class Roots_SlotStatusEffect : ISlotStatusEffect, ITriggerEffect<IUnit>
    {
        public int Restrictor { get; set; }

        public bool CanBeRemoved => Restrictor <= 0;

        public bool IsPositive => false;

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

        public SlotStatusEffectType EffectType => (SlotStatusEffectType)RootsInfo.Roots;

        public SlotStatusEffectInfoSO EffectInfo { get; set; }

        public Roots_SlotStatusEffect(int slotID, int amount, bool isCharacterSlot, int restrictors = 0)
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
            Roots_SlotStatusEffect slotEffect = new Roots_SlotStatusEffect(newSlotID, Amount, IsCharacterSlot, Restrictor);
            slotEffect.SetEffectInformation(EffectInfo);
            return slotEffect;
        }

        public bool AddContent(ISlotStatusEffect content)
        {
            Amount += (content as Roots_SlotStatusEffect).Amount;
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

        public bool ignoreSet;

        public void OnTriggerAttached(IUnit caller)
        {
            if (DoDebugs.MiscInfo) Debug.Log("Swaps in");
            caller.AddFieldEffect(EffectType);
            CombatManager.Instance.AddObserver(OnStatusTriggered, TriggerCalls.OnAbilityUsed.ToString(), caller);
            CombatManager.Instance.AddObserver(OnStatusTick, ((TriggerCalls)RootsInfo.Roots).ToString(), caller);
            if (ignoreSet)
            {
                ignoreSet = false;
                if (DoDebugs.MiscInfo) Debug.Log("does not decrease");
                return;
            }
            if (DoDebugs.MiscInfo) Debug.Log("does decrease");
            CombatManager.Instance.AddSubAction(new PerformSlotStatusEffectAction(this, caller, null));
            if (DoDebugs.MiscInfo) Debug.Log("done");
        }

        public void OnTriggerDettached(IUnit caller)
        {
            caller.RemoveFieldEffect(EffectType);
            CombatManager.Instance.RemoveObserver(OnStatusTriggered, TriggerCalls.OnAbilityUsed.ToString(), caller);
            CombatManager.Instance.RemoveObserver(OnStatusTick, ((TriggerCalls)RootsInfo.Roots).ToString(), caller);
        }

        public void OnEffectorTriggerAttached(ISlotStatusEffector caller)
        {
            Effector = caller;
            if (caller is CombatSlot slot && slot.HasUnit) ignoreSet = true;
            CombatManager.Instance.AddObserver(OnStatusTick, TriggerCalls.OnTurnFinished.ToString(), Effector);
        }

        public void OnEffectorTriggerDettached()
        {
            CombatManager.Instance.RemoveObserver(OnStatusTick, TriggerCalls.OnTurnFinished.ToString(), Effector);
        }

        public void OnSubActionTrigger(object sender, object args)
        {
            int amount = Amount;
            Amount--;
            if (!TryRemoveSlotStatusEffect())
            {
                Effector.SlotStatusEffectValuesChanged(EffectType, useSpecialSound: false, Amount - amount);
            }
        }

        public bool CanReduceDuration
        {
            get
            {
                BooleanReference booleanReference = new BooleanReference(entryValue: true);
                CombatManager.Instance.ProcessImmediateAction(new CheckHasStatusFieldReductionBlockIAction(booleanReference));
                return !booleanReference.value;
            }
        }

        public void OnStatusTick(object sender, object args)
        {
            if (!CanReduceDuration) return;
            int amount = Amount;
            Amount--;
            if (!TryRemoveSlotStatusEffect())
            {
                Effector.SlotStatusEffectValuesChanged(EffectType, useSpecialSound: false, Amount - amount);
            }
        }

        public void OnStatusTriggered(object sender, object args)
        {
            if (sender is IUnit unit)
            {
                CombatManager.Instance.AddSubAction(new RootsDamageAction(UnityEngine.Random.Range(2, 4), unit));
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
    public class ApplyRootsSlotEffect : EffectSO
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
            stats.slotStatusEffectDataBase.TryGetValue((SlotStatusEffectType)RootsInfo.Roots, out var value);
            //Debug.Log("grabbed");
            for (int i = 0; i < targets.Length; i++)
            {
                ISlotStatusEffect slotEffect = new Roots_SlotStatusEffect(targets[i].SlotID, entryVariable, targets[i].IsTargetCharacterSlot);


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
    public class DistributeRootsEffect : EffectSO
    {
        static ApplyRootsSlotEffect effect;
        public static ApplyRootsSlotEffect Effect
        {
            get
            {
                if (effect == null)
                {
                    effect = ScriptableObject.CreateInstance<ApplyRootsSlotEffect>();
                }
                return effect;
            }
        }

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            int exit = 2 * base.PreviousExitValue;
            exitAmount = 0;
            float divide = targets.Length;
            int slots = (int)divide;
            float gap = exit;
            gap /= divide;
            int max = (int)Math.Ceiling(gap);
            int min = (int)Math.Floor(gap);
            foreach (TargetSlotInfo target in targets)
            {
                int amount = UnityEngine.Random.Range(min, max + 1);
                int final = Math.Min(amount, exit);
                Effect.PerformEffect(stats, caster, target.SelfArray(), areTargetSlots, final, out int ret);
                exit -= ret;
                exitAmount += ret;
                slots--;
                if (slots <= 0) break;
                divide = slots;
                gap = exit;
                gap /= divide;
                max = (int)Math.Ceiling(gap);
                min = (int)Math.Floor(gap);
            }
            return exitAmount > 0;
        }
    }
    public class IfRootsDamageEffect : EffectSO
    {
        static DamageEffect effect;
        public static DamageEffect Effect
        {
            get
            {
                if (effect == null)
                {
                    effect = ScriptableObject.CreateInstance<DamageEffect>();
                }
                return effect;
            }
        }
        
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach(TargetSlotInfo target in targets)
            {
                if (stats.combatSlots.SlotContainsSlotStatusEffect(target.SlotID, target.IsTargetCharacterSlot, (SlotStatusEffectType)RootsInfo.Roots))
                {
                    Effect.PerformEffect(stats, caster, target.SelfArray(), areTargetSlots, entryVariable, out int exit);
                    exitAmount += exit;
                }
            }
            return exitAmount > 0;
        }
    }
    public class RootsDamageAction : CombatAction
    {
        public int Amount;
        public IUnit Target;
        public RootsDamageAction(int amount, IUnit target)
        {
            Amount = amount;
            Target = target;
        }
        public override IEnumerator Execute(CombatStats stats)
        {
            int gruh = Target.Damage(UnityEngine.Random.Range(2, 4), null, DeathType.Basic, -1, false, false, true, (DamageType)RootsInfo.Roots).damageAmount;
            CombatManager.Instance.AddSubAction(new RootsHealAction(gruh));
            CombatManager.Instance.PostNotification(((TriggerCalls)RootsInfo.Roots).ToString(), Target, null);
            yield return null;
        }
    }
    public class RootsHealAction : CombatAction
    {
        public int Amount;
        public RootsHealAction(int amount)
        {
            Amount = amount;
        }
        public override IEnumerator Execute(CombatStats stats)
        {
            foreach (CharacterCombat chara in stats.CharactersOnField.Values)
            {
                if (chara.ContainsStatusEffect((StatusEffectType)PhotoInfo.Photo)) chara.Heal(Amount, HealType.Linked, true);
            }
            foreach (EnemyCombat enemy in stats.EnemiesOnField.Values)
            {
                if (enemy.ContainsStatusEffect((StatusEffectType)PhotoInfo.Photo)) enemy.Heal(Amount, HealType.Linked, true);
            }
            yield return null;
        }
    }
}
