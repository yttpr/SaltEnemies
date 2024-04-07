using FMODUnity;
using MonoMod.RuntimeDetour;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;
//using Coffee.UIExtensions;

namespace Hawthorne
{
    public static class DrownInfo
    {
        public static int Drown => 29713326;
        public static StatusEffectInfoSO DrownStatus = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
        public static void AddDrowningStatusEffect(Action<CombatManager> orig, CombatManager self)
        {
            orig(self);
            DrownStatus.name = "Drowning";
            DrownStatus.icon = ResourceLoader.LoadSprite("Drowning.png", 32);
            DrownStatus._statusName = "Drowning";
            DrownStatus.statusEffectType = (StatusEffectType)Drown;
            DrownStatus._description = "All healing is reduced by the amount of Drowning. \nAt the end of each turn, if not in Deep Water decrease Drowning by 1. Afterwards, if Drowning is 10 or higher halve this unit's current health.";
            DrownStatus._applied_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Cursed].AppliedSoundEvent;
            DrownStatus._updated_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Cursed].UpdatedSoundEvent;
            DrownStatus._removed_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Cursed].RemovedSoundEvent;
            StatusEffectInfoSO effectInfo;
            self._stats.statusEffectDataBase.TryGetValue((StatusEffectType)Drown, out effectInfo);
            if (effectInfo == null)
                self._stats.statusEffectDataBase.Add((StatusEffectType)Drown, DrownStatus);
        }
        public static void Setup()
        {
            IDetour addLeftEffectIDetour = (IDetour)new Hook((MethodBase)typeof(CombatManager).GetMethod(nameof(CombatManager.InitializeCombat), ~BindingFlags.Default), typeof(DrownInfo).GetMethod(nameof(AddDrowningStatusEffect), ~BindingFlags.Default));
            new CustomIntentInfo("Drown", (IntentType)Drown, ResourceLoader.LoadSprite("Drowning.png"), IntentType.Status_Cursed);

        }
    }
    public class Drowning_StatusEffect : IStatusEffect, ITriggerEffect<IStatusEffector>
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

        public StatusEffectType EffectType => (StatusEffectType)DrownInfo.Drown;

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

        public Drowning_StatusEffect(int amount, int restrictors = 0)
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
            CombatManager.Instance.AddObserver(new Action<object, object>(this.OnStatusTriggered), TriggerCalls.OnTurnFinished.ToString(), caller);
            //CombatManager.Instance.AddObserver(new Action<object, object>(this.OnStatusSubTriggered), TriggerCalls.OnRoundFinished.ToString(), caller);
            //if (!caller.IsStatusEffectorCharacter) CombatManager.Instance.AddObserver(new Action<object, object>(this.OnTurnEnd), TriggerCalls.OnRoundFinished.ToString(), caller);
        }

        public void OnTriggerDettached(IStatusEffector caller)
        {
            CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnStatusTriggered), TriggerCalls.OnBeingHealed.ToString(), caller);
            CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnStatusTriggered), TriggerCalls.OnTurnFinished.ToString(), caller);
            //CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnStatusSubTriggered), TriggerCalls.OnRoundFinished.ToString(), caller);
            //if (!caller.IsStatusEffectorCharacter) CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnTurnEnd), TriggerCalls.OnRoundFinished.ToString(), caller);
        }

        public void OnSubActionTrigger(object sender, object args, bool stateCheck)
        {

        }


        //public int timerCount = 30;

        public void OnStatusTriggered(object sender, object args)
        {
            if (args is IntValueChangeException healBy)
            {
                healBy.AddModifier(new DrowningValueModifier(this.Amount));
                return;
            }
            this.ReduceDuration(sender as IStatusEffector);
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
            bool inc = true;
            if (!this.CanReduceDuration)
            {
                inc = false;
            }
            if (Watery.InWater(CombatManager.Instance._stats, effector as IUnit)) inc = false;
            if (inc)
            {
                int duration = this.Amount;
                this.Amount = Mathf.Max(0, this.Amount - 1);
                if (!this.TryRemoveStatusEffect(effector) && duration != this.Amount)
                {
                    effector.StatusEffectValuesChanged(this.EffectType, this.Amount - duration);
                }
            }
            if (this.Amount >= 10 && effector is IUnit unit)
            {
                float c = unit.CurrentHealth;
                c /= 2;
                int r = (int)Math.Floor(c);
                if (r > 0) unit.SetHealthTo(r);
                else unit.DirectDeath(null);
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
    public class ApplyDrowningEffect : EffectSO
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
            stats.statusEffectDataBase.TryGetValue((StatusEffectType)DrownInfo.Drown, out effectInfo);




            for (int index = 0; index < targets.Length; ++index)
            {
                if (targets[index].HasUnit)
                {
                    int amount = this._randomBetweenPrevious ? UnityEngine.Random.Range(this.PreviousExitValue, entryVariable + 1) : entryVariable;
                    IStatusEffect statuseffect = new Drowning_StatusEffect(amount);

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
    public class DrowningValueModifier : IntValueModifier
    {
        public readonly int toAdd;

        public DrowningValueModifier(int amount)
            : base(70)
        {
            this.toAdd = amount;
        }

        public override int Modify(int value)
        {
            if (value <= 0) return value;
            return Math.Max(0, value - toAdd);
        }
    }

    public static class WaterInfo
    {
        public static int Water => 4211617;
        public static SlotStatusEffectInfoSO WaterStatus = ScriptableObject.CreateInstance<SlotStatusEffectInfoSO>();
        public static void AddRootsSlotEffect(Action<CombatManager> orig, CombatManager self)
        {
            orig(self);
            WaterStatus.name = "Water";
            WaterStatus.icon = ResourceLoader.LoadSprite("DeepFieldIcon.png", 32);
            WaterStatus._fieldName = "Deep Water";
            WaterStatus.slotStatusEffectType = (SlotStatusEffectType)Water;
            WaterStatus._description = "On moving into Deep Water, inflict 1 Drowning on this unit. Double all Drowning on this unit at the end of each round. \nDecrease by 1 at the end of each turn.";
            WaterStatus._applied_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.OilSlicked].AppliedSoundEvent;
            WaterStatus._updated_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.OilSlicked].UpdatedSoundEvent;
            WaterStatus._removed_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.OilSlicked].RemovedSoundEvent;
            SlotStatusEffectInfoSO effectInfo;
            self._stats.slotStatusEffectDataBase.TryGetValue((SlotStatusEffectType)Water, out effectInfo);
            if (effectInfo == null)
                self._stats.slotStatusEffectDataBase.Add((SlotStatusEffectType)Water, WaterStatus);
        }
        public static void Setup()
        {
            IDetour addMoldEffectIDetour = new Hook(typeof(CombatManager).GetMethod(nameof(CombatManager.InitializeCombat), ~BindingFlags.Default), typeof(WaterInfo).GetMethod(nameof(AddRootsSlotEffect), ~BindingFlags.Default));
            new CustomIntentInfo("Water", (IntentType)Water, ResourceLoader.LoadSprite("DeepFieldIcon.png"), IntentType.Status_OilSlicked);
            WaterView.Setup();
            try
            {
                SlipInfo.Setup();
            }
            catch
            {
                Debug.LogError("SLIP FUCKING FAILED");
            }
        }
    }
    public static class WaterView
    {

        public static GameObject[][] WaterFool = new GameObject[5][];
        public static GameObject[] WaterEnemy = new GameObject[5];

        public static bool[] HasWaterFool = new bool[5];
        public static bool[] HasWaterEnemy = new bool[5];
        public static void Reset()
        {
            HasWaterEnemy = new bool[5];
            HasWaterFool = new bool[5];
            WaterFool = new GameObject[5][];
            WaterEnemy = new GameObject[5];
            MoldView.Reset();
            SlipView.Reset();
        }

        public static GameObject[] Fool;
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
                if (effect.slotStatusEffectType == (SlotStatusEffectType)WaterInfo.Water)
                    flag = true;
            }
            if (HasWaterFool == null || HasWaterFool.Length <= self.SlotID) HasWaterFool = new bool[5];
            HasWaterFool[self.SlotID] = flag;
            try
            {
                if (Fool == null)
                {
                    Fool = new GameObject[]
                    {
                    SaltEnemies.Group4.LoadAsset<GameObject>("Assets/Water/FishFoolBack.prefab").gameObject,
                    SaltEnemies.Group4.LoadAsset<GameObject>("Assets/Water/FishFoolJelly.prefab").gameObject,
                    SaltEnemies.Group4.LoadAsset<GameObject>("Assets/Water/FishFoolFront.prefab").gameObject,
                    SaltEnemies.Group4.LoadAsset<GameObject>("Assets/Water/FishFoolWater.prefab").gameObject,
                    };
                }
            }
            catch
            {
                Fool = null;
                if (DoDebugs.MiscInfo) Debug.LogError("failed to grab water from assetbundle");
            }
            GameObject[] gameObjects = Fool;
            try
            {
                if (WaterFool[self.SlotID] == null || WaterFool[self.SlotID].Length <= 0)
                {
                    WaterFool[self.SlotID] = new GameObject[4];
                    WaterFool[self.SlotID][0] = UnityEngine.Object.Instantiate<GameObject>(gameObjects[0], self.transform.localPosition, self.transform.localRotation, self._backFireEffect.transform.parent.transform);
                    WaterFool[self.SlotID][1] = UnityEngine.Object.Instantiate<GameObject>(gameObjects[1], self.transform.localPosition, self.transform.localRotation, self._backFireEffect.transform.parent.transform);
                    WaterFool[self.SlotID][2] = UnityEngine.Object.Instantiate<GameObject>(gameObjects[2], self.transform.localPosition, self.transform.localRotation, self._constrictedEffect.transform.parent.transform);
                    WaterFool[self.SlotID][3] = UnityEngine.Object.Instantiate<GameObject>(gameObjects[3], self.transform.localPosition, self.transform.localRotation, self._constrictedEffect.transform.parent.transform);
                    for (int i = 0; i < 4; i++)
                    {
                        WaterFool[self.SlotID][i].transform.localPosition = Vector3.zero;
                        WaterFool[self.SlotID][i].transform.rotation = self._constrictedEffect.transform.rotation;
                        WaterFool[self.SlotID][i].GetComponent<RectTransform>().anchorMin = self._shieldEffect.GetComponent<RectTransform>().anchorMin;
                        WaterFool[self.SlotID][i].GetComponent<RectTransform>().anchorMax = self._shieldEffect.GetComponent<RectTransform>().anchorMax;
                        WaterFool[self.SlotID][i].GetComponent<RectTransform>().position = self._shieldEffect.GetComponent<RectTransform>().position;
                    }
                }
            }
            catch
            {
                if (DoDebugs.MiscInfo) Debug.LogError("failed to instantiate water");
            }
            try
            {
                foreach (GameObject obj in WaterFool[self.SlotID]) obj.SetActive(flag);
            }
            catch
            {
                if (DoDebugs.MiscInfo) Debug.LogError("failed to activate/deactivate water");
            }

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
                    if (enumerator.Current.slotStatusEffectType == (SlotStatusEffectType)WaterInfo.Water)
                        flag = true;
                }
                if (HasWaterEnemy == null || HasWaterEnemy.Length <= self.SlotID) HasWaterEnemy = new bool[5]; HasWaterEnemy[self.SlotID] = flag;
                if (Enemy == null) Enemy = SaltEnemies.Group4.LoadAsset<GameObject>("Assets/Water/FishEnemy.prefab");
                GameObject original = Enemy;
                if ((UnityEngine.Object)WaterEnemy[self.SlotID] == (UnityEngine.Object)null)
                {
                    WaterEnemy[self.SlotID] = UnityEngine.Object.Instantiate<GameObject>(original, self.transform.localPosition, self.transform.localRotation, self.transform);
                    WaterEnemy[self.SlotID].transform.localPosition = Vector3.zero;
                    WaterEnemy[self.SlotID].transform.localRotation = Quaternion.identity;
                }
                if (flag)
                {
                    WaterEnemy[self.SlotID].SetActive(true);
                    WaterEnemy[self.SlotID].transform.GetChild(0).GetComponent<ParticleSystem>().Play(true);
                    WaterEnemy[self.SlotID].transform.GetChild(1).GetComponent<ParticleSystem>().Play(true);
                    WaterEnemy[self.SlotID].transform.GetChild(2).GetComponent<ParticleSystem>().Play(true);
                    WaterEnemy[self.SlotID].transform.GetChild(3).GetComponent<ParticleSystem>().Play(true);
                    WaterEnemy[self.SlotID].transform.GetChild(4).GetComponent<ParticleSystem>().Play(true);
                    WaterEnemy[self.SlotID].transform.GetChild(5).GetComponent<ParticleSystem>().Play(true);
                }
                else if (!flag)
                {
                    WaterEnemy[self.SlotID].transform.GetChild(0).GetComponent<ParticleSystem>().Stop(true);
                    WaterEnemy[self.SlotID].transform.GetChild(1).GetComponent<ParticleSystem>().Stop(true);
                    WaterEnemy[self.SlotID].transform.GetChild(2).GetComponent<ParticleSystem>().Stop(true);
                    WaterEnemy[self.SlotID].transform.GetChild(3).GetComponent<ParticleSystem>().Stop(true);
                    WaterEnemy[self.SlotID].transform.GetChild(4).GetComponent<ParticleSystem>().Stop(true);
                    WaterEnemy[self.SlotID].transform.GetChild(5).GetComponent<ParticleSystem>().Stop(true);
                }
                orig(self, effects, icons, texts);
            }
        }

        public static void Setup()
        {
            IDetour detour10 = (IDetour)new Hook((MethodBase)typeof(EnemySlotLayout).GetMethod("UpdateFieldListLayout", ~BindingFlags.Default), typeof(WaterView).GetMethod("UpdateFieldListModdedLayout", ~BindingFlags.Default));
            IDetour detour11 = (IDetour)new Hook((MethodBase)typeof(CharacterSlotLayout).GetMethod("UpdateFieldListLayout", ~BindingFlags.Default), typeof(WaterView).GetMethod("UpdateFieldListCharacterModdedLayout", ~BindingFlags.Default));
            IDetour hook0 = new Hook(typeof(CharacterSlotsHaveSwappedUIAction).GetMethod(nameof(CharacterSlotsHaveSwappedUIAction.Execute), ~BindingFlags.Default), typeof(WaterView).GetMethod(nameof(WaterView.Execute), ~BindingFlags.Default));
            IDetour hook1 = new Hook(typeof(EnemySlotsHaveSwappedUIAction).GetMethod(nameof(EnemySlotsHaveSwappedUIAction.Execute), ~BindingFlags.Default), typeof(WaterView).GetMethod(nameof(WaterView.Execute), ~BindingFlags.Default));
            MoldView.Setup();
        }

        public static IEnumerator Execute(Func<CombatAction, CombatStats, IEnumerator> orig, CombatAction self, CombatStats stats)
        {
            yield return orig(self, stats);
            
            try
            {
                if (self is CharacterSlotsHaveSwappedUIAction ch)
                {
                    foreach (int i in ch._newSlotIDs)
                    {
                        if (HasWaterFool == null || HasWaterFool.Length <= i) HasWaterFool = new bool[5];
                        foreach (CharacterSlotLayout slot in stats.combatUI._characterZone._slots)
                        {
                            if (slot.SlotID == i && slot._hasUnit && HasWaterFool[slot.SlotID])
                            {
                                if (DoDebugs.MiscInfo) Debug.Log(slot.SlotID);
                                RuntimeManager.PlayOneShot("event:/Hawthorne/Misc/Water");
                            }
                        }
                    }
                }
                else if (self is EnemySlotsHaveSwappedUIAction en)
                {
                    foreach (int i in en._newSlotIDs)
                    {
                        if (HasWaterEnemy == null || HasWaterEnemy.Length <= i) HasWaterEnemy = new bool[5];
                        foreach (EnemySlotLayout slot in stats.combatUI._enemyZone._slots)
                        {
                            bool HasUnit = false;
                            int Size = 1;
                            foreach (EnemyCombatUIInfo enUI in stats.combatUI._enemiesInCombat.Values)
                            {
                                if (enUI.SlotID <= slot.SlotID && slot.SlotID < enUI.SlotID + enUI.EnemyBase.size)
                                {
                                    HasUnit = true;
                                    Size = enUI.EnemyBase.size;
                                }
                            }
                            if (slot.SlotID == i && HasUnit)
                            {
                                if (HasWaterEnemy[slot.SlotID])
                                {
                                    if (DoDebugs.MiscInfo) Debug.Log(slot.SlotID);
                                    RuntimeManager.PlayOneShot("event:/Hawthorne/Misc/Water");
                                }
                                else if (Size > 1)
                                {
                                    for (int p = slot.SlotID; p < slot.SlotID + Size; p++)
                                    {
                                        if (HasWaterEnemy == null || HasWaterEnemy.Length <= p) HasWaterEnemy = new bool[5];
                                        bool Found = false;
                                        foreach (EnemySlotLayout plot in stats.combatUI._enemyZone._slots)
                                        {
                                            bool isUnited = false;
                                            foreach (EnemyCombatUIInfo enUI in stats.combatUI._enemiesInCombat.Values)
                                            {
                                                if (enUI.SlotID <= plot.SlotID && plot.SlotID < enUI.SlotID + enUI.EnemyBase.size)
                                                {
                                                    isUnited = true;
                                                }
                                            }
                                            if (plot.SlotID == p && isUnited && HasWaterEnemy[plot.SlotID])
                                            {
                                                RuntimeManager.PlayOneShot("event:/Hawthorne/Misc/Water");
                                                Found = true;
                                                break;
                                            }
                                        }
                                        if (Found) break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                Debug.LogError("failed to play water sound.");
            }
        }
        
    }
    public class Water_SlotStatusEffect : ISlotStatusEffect, ITriggerEffect<IUnit>
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

        public SlotStatusEffectType EffectType => (SlotStatusEffectType)WaterInfo.Water;

        public SlotStatusEffectInfoSO EffectInfo { get; set; }

        public Water_SlotStatusEffect(int slotID, int amount, bool isCharacterSlot, int restrictors = 0)
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
            Water_SlotStatusEffect slotEffect = new Water_SlotStatusEffect(newSlotID, Amount, IsCharacterSlot, Restrictor);
            slotEffect.SetEffectInformation(EffectInfo);
            return slotEffect;
        }

        public bool AddContent(ISlotStatusEffect content)
        {
            Amount += (content as Water_SlotStatusEffect).Amount;
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
            //CombatManager.Instance.AddObserver(OnStatusTriggered, TriggerCalls.OnAbilityUsed.ToString(), caller);
            //CombatManager.Instance.AddObserver(OnStatusTick, ((TriggerCalls)RootsInfo.Roots).ToString(), caller);
            if (ignoreSet)
            {
                ignoreSet = false;
                if (DoDebugs.MiscInfo) Debug.Log("does not apply");
                return;
            }
            if (DoDebugs.MiscInfo) Debug.Log("does apply");
            //RuntimeManager.PlayOneShot("event:/Hawthorne/Misc/Water");

            CombatManager.Instance.AddSubAction(new PerformSlotStatusEffectAction(this, caller, null));
            if (DoDebugs.MiscInfo) Debug.Log("done");
        }

        public void OnTriggerDettached(IUnit caller)
        {
            caller.RemoveFieldEffect(EffectType);
            //CombatManager.Instance.RemoveObserver(OnStatusTriggered, TriggerCalls.OnAbilityUsed.ToString(), caller);
            //CombatManager.Instance.RemoveObserver(OnStatusTick, ((TriggerCalls)RootsInfo.Roots).ToString(), caller);
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
            if (sender is IUnit unit)
            {
                StatusEffectInfoSO effectInfo;
                CombatManager.Instance._stats.statusEffectDataBase.TryGetValue((StatusEffectType)DrownInfo.Drown, out effectInfo);
                IStatusEffect statuseffect = new Drowning_StatusEffect(1);

                statuseffect.SetEffectInformation(effectInfo);
                IStatusEffector effector = unit as IStatusEffector;
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
                            statuseffect = (IStatusEffect)Activator.CreateInstance(effector.StatusEffects[thisIndex].GetType(), 1, 0);
                        }
                    }
                }

                statuseffect.SetEffectInformation(effectInfo);
                unit.ApplyStatusEffect((IStatusEffect)statuseffect, 1);
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
            if (sender is CombatSlot slot && slot.HasUnit && slot.Unit is IUnit unit && unit.ContainsStatusEffect((StatusEffectType)DrownInfo.Drown))
            {
                int content = 0;
                if (unit is IStatusEffector effector)
                {
                    foreach (IStatusEffect status in effector.StatusEffects)
                    {
                        if (status.EffectType == (StatusEffectType)DrownInfo.Drown) content += status.StatusContent;
                    }

                    if (content > 0)
                    {
                        StatusEffectInfoSO effectInfo;
                        CombatManager.Instance._stats.statusEffectDataBase.TryGetValue((StatusEffectType)DrownInfo.Drown, out effectInfo);
                        IStatusEffect statuseffect = new Drowning_StatusEffect(content);

                        statuseffect.SetEffectInformation(effectInfo);
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
                                    statuseffect = (IStatusEffect)Activator.CreateInstance(effector.StatusEffects[thisIndex].GetType(), content, 0);
                                }
                            }
                        }

                        statuseffect.SetEffectInformation(effectInfo);
                        unit.ApplyStatusEffect((IStatusEffect)statuseffect, content);
                    }
                }
            }
            
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
    public class SillyAction : CombatAction
    {
        public readonly Water_SlotStatusEffect _self;
        public SillyAction(Water_SlotStatusEffect self)
        {
            _self = self;
        }
        public override IEnumerator Execute(CombatStats stats)
        {
            _self.ignoreSet = false;
            yield return false;
        }
    }
    public static class Watery
    {
        public static bool InWater(CombatStats stats, IUnit unit)
        {
            bool flag = false;
            for (int slotId = unit.SlotID; slotId < unit.SlotID + unit.Size; ++slotId)
            {
                if (stats.combatSlots.SlotContainsSlotStatusEffect(slotId, unit.IsUnitCharacter, (SlotStatusEffectType)WaterInfo.Water))
                    flag = true;
            }
            return flag;
        }
    }
    public class ApplyWaterSlotEffect : EffectSO
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
            stats.slotStatusEffectDataBase.TryGetValue((SlotStatusEffectType)WaterInfo.Water, out var value);
            //Debug.Log("grabbed");
            for (int i = 0; i < targets.Length; i++)
            {
                ISlotStatusEffect slotEffect = new Water_SlotStatusEffect(targets[i].SlotID, entryVariable, targets[i].IsTargetCharacterSlot);


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



    public static class MoldView
    {

        public static GameObject[][] MoldFool = new GameObject[5][];
        public static GameObject[] MoldEnemy = new GameObject[5];
        public static void Reset()
        {
            MoldFool = new GameObject[5][];
            MoldEnemy = new GameObject[5];
        }

        public static GameObject[] Fool;
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
                if (effect.slotStatusEffectType == (SlotStatusEffectType)862351)
                    flag = true;
            }
            try
            {
                if (Fool == null)
                {
                    Fool = new GameObject[]
                    {
                    SaltEnemies.assetBundle.LoadAsset<GameObject>("Assets/Moldy/SmokeChara.prefab").gameObject,
                    SaltEnemies.assetBundle.LoadAsset<GameObject>("Assets/Moldy/MoldChara.prefab").gameObject,
                    };
                }
            }
            catch
            {
                Fool = null;
                if (DoDebugs.MiscInfo) Debug.LogError("failed to grab mold from assetbundle");
            }
            GameObject[] gameObjects = Fool;
            try
            {
                if (MoldFool[self.SlotID] == null || MoldFool[self.SlotID].Length <= 0)
                {
                    MoldFool[self.SlotID] = new GameObject[2];
                    MoldFool[self.SlotID][0] = UnityEngine.Object.Instantiate<GameObject>(gameObjects[0], self.transform.localPosition, self.transform.localRotation, self._backFireEffect.transform.parent.transform);
                    MoldFool[self.SlotID][1] = UnityEngine.Object.Instantiate<GameObject>(gameObjects[1], self.transform.localPosition, self.transform.localRotation, self._constrictedEffect.transform.parent.transform);
                    for (int i = 0; i < 2; i++)
                    {
                        MoldFool[self.SlotID][i].transform.localPosition = Vector3.zero;
                        MoldFool[self.SlotID][i].transform.rotation = self._constrictedEffect.transform.rotation;
                        MoldFool[self.SlotID][i].GetComponent<RectTransform>().anchorMin = self._shieldEffect.GetComponent<RectTransform>().anchorMin;
                        MoldFool[self.SlotID][i].GetComponent<RectTransform>().anchorMax = self._shieldEffect.GetComponent<RectTransform>().anchorMax;
                        MoldFool[self.SlotID][i].GetComponent<RectTransform>().position = self._shieldEffect.GetComponent<RectTransform>().position;
                    }
                }
            }
            catch
            {
                if (DoDebugs.MiscInfo) Debug.LogError("failed to instantiate mold");
            }
            try
            {
                foreach (GameObject obj in MoldFool[self.SlotID]) obj.SetActive(flag);
            }
            catch
            {
                if (DoDebugs.MiscInfo) Debug.LogError("failed to activate/deactivate mold");
            }

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
                    if (enumerator.Current.slotStatusEffectType == (SlotStatusEffectType)862351)
                        flag = true;
                }
                if (Enemy == null) Enemy = SaltEnemies.assetBundle.LoadAsset<GameObject>("Assets/Moldy/MoldEnemy.prefab");
                GameObject original = Enemy;
                if ((UnityEngine.Object)MoldEnemy[self.SlotID] == (UnityEngine.Object)null)
                {
                    MoldEnemy[self.SlotID] = UnityEngine.Object.Instantiate<GameObject>(original, self.transform.localPosition, self.transform.localRotation, self.transform);
                    MoldEnemy[self.SlotID].transform.localPosition = Vector3.zero;
                    MoldEnemy[self.SlotID].transform.localRotation = Quaternion.identity;
                }
                if (flag)
                {
                    MoldEnemy[self.SlotID].SetActive(true);
                    MoldEnemy[self.SlotID].transform.GetComponent<ParticleSystem>().Play(true);
                }
                else if (!flag)
                {
                    MoldEnemy[self.SlotID].transform.GetComponent<ParticleSystem>().Stop(true);
                }
                orig(self, effects, icons, texts);
            }
        }

        public static void Setup()
        {
            IDetour detour10 = (IDetour)new Hook((MethodBase)typeof(EnemySlotLayout).GetMethod("UpdateFieldListLayout", ~BindingFlags.Default), typeof(MoldView).GetMethod("UpdateFieldListModdedLayout", ~BindingFlags.Default));
            IDetour detour11 = (IDetour)new Hook((MethodBase)typeof(CharacterSlotLayout).GetMethod("UpdateFieldListLayout", ~BindingFlags.Default), typeof(MoldView).GetMethod("UpdateFieldListCharacterModdedLayout", ~BindingFlags.Default));
        }

    }
}
