using System;
using System.Collections;
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
using JetBrains.Annotations;
using System.Text;
using System.Threading;
using System.Runtime.CompilerServices;
using Tools;
using UnityEngine.SceneManagement;
using System.Timers;
using UnityEngine.Diagnostics;
using UnityEngine.UI;
using System.Xml;
using System.Dynamic;
using static UnityEngine.UI.CanvasScaler;
using static System.Net.Mime.MediaTypeNames;
using static UnityEngine.GraphicsBuffer;
using Hawthorne;

namespace Hawthorne.NewFolder
{
    public class CycleSlotEffectsEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;

            foreach (TargetSlotInfo target in targets)
            {
                CombatSlot thisSlot = stats.combatSlots.EnemySlots[target.SlotID];
                if (target.IsTargetCharacterSlot)
                {
                    thisSlot = stats.combatSlots.CharacterSlots[target.SlotID];
                }
                //if (stats.combatSlots.SlotContainsSlotStatusEffect(target.SlotID, target.IsTargetCharacterSlot, (SlotStatusEffectType)862351)) Debug.Log("mold " + target.SlotID + " " + target.IsTargetCharacterSlot);
                //if (stats.combatSlots.SlotContainsSlotStatusEffect(target.SlotID, target.IsTargetCharacterSlot, SlotStatusEffectType.OnFire)) Debug.Log("fire " + target.SlotID + " " + target.IsTargetCharacterSlot);
                //if (stats.combatSlots.SlotContainsSlotStatusEffect(target.SlotID, target.IsTargetCharacterSlot, SlotStatusEffectType.Shield)) Debug.Log("shield " + target.SlotID + " " + target.IsTargetCharacterSlot);
                //if (stats.combatSlots.SlotContainsSlotStatusEffect(target.SlotID, target.IsTargetCharacterSlot, SlotStatusEffectType.Constricted)) Debug.Log("constricted " + target.SlotID + " " + target.IsTargetCharacterSlot);
                //the rest of this code cycles the status effects, i think the order is shield -> constricted -> mold -> fire
                ISlotStatusEffector effector = thisSlot as ISlotStatusEffector;
                int amountShield = 0;
                int amountFire = 0;
                int amountConstricted = 0;
                int amountMold = 0;
                amountMold = thisSlot.TryRemoveSlotStatusEffect((SlotStatusEffectType)862351);
                amountConstricted = thisSlot.TryRemoveSlotStatusEffect(SlotStatusEffectType.Constricted);
                amountFire = thisSlot.TryRemoveSlotStatusEffect(SlotStatusEffectType.OnFire);
                amountShield = thisSlot.TryRemoveSlotStatusEffect(SlotStatusEffectType.Shield);
                GenericTargetting_BySlot_Index slotTarget = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
                slotTarget.slotPointerDirections = new int[1] { thisSlot.SlotID };
                slotTarget.getAllies = thisSlot.IsCharacter;
                if (amountShield > 0)
                {
                    Effect entering = new Effect(ScriptableObject.CreateInstance<ApplyConstrictedSlotEffect>(), amountShield, new IntentType?(), slotTarget);
                    CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { entering }), CombatManager.Instance._stats.CharactersOnField.First().Value));
                }
                if (amountFire > 0)
                {
                    Effect entering = new Effect(ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), amountFire, new IntentType?(), slotTarget);
                    CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { entering }), CombatManager.Instance._stats.CharactersOnField.First().Value));
                }
                if (amountConstricted > 0)
                {
                    Effect entering = new Effect(ScriptableObject.CreateInstance<ApplyMoldSlotEffect>(), amountConstricted, new IntentType?(), slotTarget);
                    CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { entering }), CombatManager.Instance._stats.CharactersOnField.First().Value));
                }
                if (amountMold > 0)
                {
                    Effect entering = new Effect(ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), amountMold, new IntentType?(), slotTarget);
                    CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { entering }), CombatManager.Instance._stats.CharactersOnField.First().Value));
                }
            }

            return true;
        }
    }
}
