using BrutalAPI;
using FMODUnity;
using MonoMod.RuntimeDetour;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace Hawthorne
{
    public static class SlipInfo
    {
        public static int Slip => 2219931;
        public static SlotStatusEffectInfoSO SlipStatus = ScriptableObject.CreateInstance<SlotStatusEffectInfoSO>();
        public static void AddSlipSlotEffect(Action<CombatManager> orig, CombatManager self)
        {
            orig(self);
            SlipStatus.name = "Slip";
            SlipStatus.icon = ResourceLoader.LoadSprite("SlipIcon.png", 32);
            SlipStatus._fieldName = "Slip";
            SlipStatus.slotStatusEffectType = (SlotStatusEffectType)Slip;
            SlipStatus._description = "On moving into Slip, decrease Slip by 1 and move again in the same direction.";
            SlipStatus._applied_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.OilSlicked].AppliedSoundEvent;
            SlipStatus._updated_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.OilSlicked].UpdatedSoundEvent;
            SlipStatus._removed_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.OilSlicked].RemovedSoundEvent;
            SlotStatusEffectInfoSO effectInfo;
            self._stats.slotStatusEffectDataBase.TryGetValue((SlotStatusEffectType)Slip, out effectInfo);
            if (effectInfo == null)
                self._stats.slotStatusEffectDataBase.Add((SlotStatusEffectType)Slip, SlipStatus);
        }
        public static void Setup()
        {
            IDetour addMoldEffectIDetour = new Hook(typeof(CombatManager).GetMethod(nameof(CombatManager.InitializeCombat), ~BindingFlags.Default), typeof(SlipInfo).GetMethod(nameof(AddSlipSlotEffect), ~BindingFlags.Default));
            new CustomIntentInfo("Slip", (IntentType)Slip, ResourceLoader.LoadSprite("SlipIcon.png"), IntentType.Status_OilSlicked);
            SlipView.Setup();
        }
    }
    public static class SlipView
    {

        public static GameObject[][] SlipFool = new GameObject[5][];
        public static GameObject[] SlipEnemy = new GameObject[5];

        public static void Reset()
        {
            SlipFool = new GameObject[5][];
            SlipEnemy = new GameObject[5];
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
                if (effect.slotStatusEffectType == (SlotStatusEffectType)SlipInfo.Slip)
                {
                    flag = true;
                    //Debug.Log("slippy: " + self.SlotID);
                }
            }
            try
            {
                if (Fool == null)
                {
                    Fool = new GameObject[]
                    {
                    SaltEnemies.assetBundle.LoadAsset<GameObject>("Assets/train/SlipChara2.prefab").gameObject,
                    SaltEnemies.assetBundle.LoadAsset<GameObject>("Assets/train/SlipChara3.prefab").gameObject,
                    };
                }
            }
            catch
            {
                Fool = null;
                if (DoDebugs.MiscInfo) Debug.LogError("failed to grab slip from assetbundle");
            }
            GameObject[] gameObjects = Fool;
            try
            {
                if (SlipFool[self.SlotID] == null || SlipFool[self.SlotID].Length <= 0)
                {
                    SlipFool[self.SlotID] = new GameObject[2];
                    SlipFool[self.SlotID][0] = UnityEngine.Object.Instantiate<GameObject>(gameObjects[0], self.transform.localPosition, self.transform.localRotation, self._backFireEffect.transform.parent.transform);
                    SlipFool[self.SlotID][1] = UnityEngine.Object.Instantiate<GameObject>(gameObjects[1], self.transform.localPosition, self.transform.localRotation, self.transform);
                    SlipFool[self.SlotID][0].transform.localPosition = Vector3.zero;
                    SlipFool[self.SlotID][0].transform.rotation = self._shieldEffect.transform.rotation;
                    SlipFool[self.SlotID][0].GetComponent<RectTransform>().anchorMin = self._shieldEffect.GetComponent<RectTransform>().anchorMin;
                    SlipFool[self.SlotID][0].GetComponent<RectTransform>().anchorMax = self._shieldEffect.GetComponent<RectTransform>().anchorMax;
                    SlipFool[self.SlotID][0].GetComponent<RectTransform>().position = self._shieldEffect.GetComponent<RectTransform>().position;
                    SlipFool[self.SlotID][1].transform.localPosition = Vector3.zero;
                    SlipFool[self.SlotID][1].transform.rotation = self._shieldEffect.transform.rotation;
                    SlipFool[self.SlotID][1].GetComponent<RectTransform>().anchorMin = self._shieldEffect.GetComponent<RectTransform>().anchorMin;
                    SlipFool[self.SlotID][1].GetComponent<RectTransform>().anchorMax = self._shieldEffect.GetComponent<RectTransform>().anchorMax;
                    SlipFool[self.SlotID][1].GetComponent<RectTransform>().position = self._shieldEffect.GetComponent<RectTransform>().position;
                    //SlipFool[self.SlotID][1].GetComponent<RectTransform>().position = self._shieldEffect.GetComponent<RectTransform>().position;
                    //SlipFool[self.SlotID][i].GetComponent<RectTransform>().position = self._constrictedEffect.GetComponent<RectTransform>().position;
                }
            }
            catch
            {
                if (DoDebugs.MiscInfo) Debug.LogError("failed to instantiate slip");
            }
            try
            {
                foreach (GameObject obj in SlipFool[self.SlotID]) obj.SetActive(flag);
            }
            catch
            {
                if (DoDebugs.MiscInfo) Debug.LogError("failed to activate/deactivate slip");
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
                    if (enumerator.Current.slotStatusEffectType == (SlotStatusEffectType)SlipInfo.Slip)
                        flag = true;
                }
                if (Enemy == null) Enemy = SaltEnemies.assetBundle.LoadAsset<GameObject>("Assets/train/SlipEnemy.prefab");
                GameObject original = Enemy;
                if ((UnityEngine.Object)SlipEnemy[self.SlotID] == (UnityEngine.Object)null)
                {
                    SlipEnemy[self.SlotID] = UnityEngine.Object.Instantiate<GameObject>(original, self.transform.localPosition, self.transform.localRotation, self.transform);
                    SlipEnemy[self.SlotID].transform.localPosition = Vector3.zero;
                    SlipEnemy[self.SlotID].transform.localRotation = Quaternion.identity;
                }
                SlipEnemy[self.SlotID].SetActive(flag);
                orig(self, effects, icons, texts);
            }
        }

        public static void Setup()
        {
            IDetour detour10 = (IDetour)new Hook((MethodBase)typeof(EnemySlotLayout).GetMethod("UpdateFieldListLayout", ~BindingFlags.Default), typeof(SlipView).GetMethod("UpdateFieldListModdedLayout", ~BindingFlags.Default));
            IDetour detour11 = (IDetour)new Hook((MethodBase)typeof(CharacterSlotLayout).GetMethod("UpdateFieldListLayout", ~BindingFlags.Default), typeof(SlipView).GetMethod("UpdateFieldListCharacterModdedLayout", ~BindingFlags.Default));
        }


    }
    public class Slip_SlotStatusEffect : ISlotStatusEffect, ITriggerEffect<IUnit>
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

        public SlotStatusEffectType EffectType => (SlotStatusEffectType)SlipInfo.Slip;

        public SlotStatusEffectInfoSO EffectInfo { get; set; }

        public Slip_SlotStatusEffect(int slotID, int amount, bool isCharacterSlot, int restrictors = 0)
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
            Slip_SlotStatusEffect slotEffect = new Slip_SlotStatusEffect(newSlotID, Amount, IsCharacterSlot, Restrictor);
            slotEffect.SetEffectInformation(EffectInfo);
            return slotEffect;
        }

        public bool AddContent(ISlotStatusEffect content)
        {
            Amount += (content as Slip_SlotStatusEffect).Amount;
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
            try
            {
                if (this.Amount <= 0) return;
                caller.AddFieldEffect(EffectType);
                CombatManager.Instance.AddObserver(OnStatusTriggered, TriggerCalls.OnMoved.ToString(), caller);
            }
            catch
            {
                Debug.LogError("oh slip...");
            }
            //CombatManager.Instance.AddObserver(OnStatusTick, ((TriggerCalls)RootsInfo.Roots).ToString(), caller);
        }

        public void OnTriggerDettached(IUnit caller)
        {
            try
            {
                caller.RemoveFieldEffect(EffectType);
                CombatManager.Instance.RemoveObserver(OnStatusTriggered, TriggerCalls.OnMoved.ToString(), caller);
            }
            catch
            {
                Debug.LogError("oh slip...");
            }
            //CombatManager.Instance.RemoveObserver(OnStatusTick, ((TriggerCalls)RootsInfo.Roots).ToString(), caller);
        }

        public void OnEffectorTriggerAttached(ISlotStatusEffector caller)
        {
            Effector = caller;
            //if (caller is CombatSlot slot && slot.HasUnit) ignoreSet = true;
            //CombatManager.Instance.AddObserver(OnStatusTick, TriggerCalls.OnTurnFinished.ToString(), Effector);
        }

        public void OnEffectorTriggerDettached()
        {
            //CombatManager.Instance.RemoveObserver(OnStatusTick, TriggerCalls.OnTurnFinished.ToString(), Effector);
        }

        public void OnSubActionTrigger(object sender, object args)
        {
            if (sender is IUnit unit)
            {
                
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
            //if (!CanReduceDuration) return;
            int amount = Amount;
            Amount--;
            if (!TryRemoveSlotStatusEffect())
            {
                Effector.SlotStatusEffectValuesChanged(EffectType, useSpecialSound: false, Amount - amount);
            }
        }

        public void OnStatusTriggered(object sender, object args)
        {
            if (Amount <= 0) return;
            if (sender is IUnit unit && args is IntegerReference oldslot && oldslot.value != unit.SlotID)
            {
                OnStatusTick(sender, args);
                CombatStats stats = CombatManager.Instance._stats;
                /*if (oldslot.value < unit.SlotID)
                {
                    CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[] {new Effect(BasicEffects.GoRight, 1, null, Slots.Self)}), unit));
                }
                else
                {
                    CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[] { new Effect(BasicEffects.GoLeft, 1, null, Slots.Self) }), unit));
                }*/

                int num = oldslot.value < unit.SlotID ? (unit.IsUnitCharacter ? 1 : unit.Size) : (-1);
                if (unit.IsUnitCharacter)
                {
                    if (unit.SlotID + num >= 0 && unit.SlotID + num < stats.combatSlots.CharacterSlots.Length)
                    {
                        stats.combatSlots.SwapCharacters(unit.SlotID, unit.SlotID + num, isMandatory: true);
                    }
                }
                else
                {
                    if (stats.combatSlots.CanEnemiesSwap(unit.SlotID, unit.SlotID + num, out var firstSlotSwap, out var secondSlotSwap))
                    {
                        stats.combatSlots.SwapEnemies(unit.SlotID, firstSlotSwap, unit.SlotID + num, secondSlotSwap);
                    }
                }
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
    public class ApplySlipSlotEffect : EffectSO
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
            stats.slotStatusEffectDataBase.TryGetValue((SlotStatusEffectType)SlipInfo.Slip, out var value);
            //Debug.Log("grabbed");
            for (int i = 0; i < targets.Length; i++)
            {
                ISlotStatusEffect slotEffect = new Slip_SlotStatusEffect(targets[i].SlotID, entryVariable, targets[i].IsTargetCharacterSlot);


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
}
