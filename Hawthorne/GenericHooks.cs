using BrutalAPI;
using MonoMod.RuntimeDetour;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using THE_DEAD;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace Hawthorne
{
    public static class HooksGeneral
    {
        public static void Setup()
        {
            IDetour idetour1 = new Hook(typeof(CharacterCombat).GetMethod(nameof(CharacterCombat.Damage), ~BindingFlags.Default), typeof(HooksGeneral).GetMethod(nameof(Damage), ~BindingFlags.Default));
            IDetour idetour2 = new Hook(typeof(EnemyCombat).GetMethod(nameof(EnemyCombat.Damage), ~BindingFlags.Default), typeof(HooksGeneral).GetMethod(nameof(Damage), ~BindingFlags.Default));
            IDetour idetour3 = new Hook(typeof(CharacterCombat).GetMethod(nameof(CharacterCombat.WillApplyDamage), ~BindingFlags.Default), typeof(HooksGeneral).GetMethod(nameof(WillApplyDamage), ~BindingFlags.Default));
            IDetour idetour4 = new Hook(typeof(EnemyCombat).GetMethod(nameof(EnemyCombat.WillApplyDamage), ~BindingFlags.Default), typeof(HooksGeneral).GetMethod(nameof(WillApplyDamage), ~BindingFlags.Default));
            IDetour idetour5 = new Hook(typeof(MainMenuController).GetMethod(nameof(MainMenuController.Start), ~BindingFlags.Default), typeof(HooksGeneral).GetMethod(nameof(StartMenu), ~BindingFlags.Default));
            IDetour idetour6 = new Hook(typeof(CombatManager).GetMethod(nameof(CombatManager.InitializeCombat), ~BindingFlags.Default), typeof(HooksGeneral).GetMethod(nameof(InitializeCombat), ~BindingFlags.Default));
            IDetour idetour7 = new Hook(typeof(CombatStats).GetMethod(nameof(CombatStats.PlayerTurnStart), ~BindingFlags.Default), typeof(HooksGeneral).GetMethod(nameof(PlayerTurnStart), ~BindingFlags.Default));
            IDetour idetour8 = new Hook(typeof(CombatStats).GetMethod(nameof(CombatStats.PlayerTurnEnd), ~BindingFlags.Default), typeof(HooksGeneral).GetMethod(nameof(PlayerTurnEnd), ~BindingFlags.Default));
            IDetour idetour9 = new Hook(typeof(CombatManager).GetMethod(nameof(CombatManager.PostNotification), ~BindingFlags.Default), typeof(HooksGeneral).GetMethod(nameof(PostNotification), ~BindingFlags.Default));
            IDetour idetour10 = new Hook(typeof(EffectAction).GetMethod(nameof(EffectAction.Execute), ~BindingFlags.Default), typeof(HooksGeneral).GetMethod(nameof(EffectActionExecute), ~BindingFlags.Default));
            IDetour idetour11 = new Hook(typeof(TooltipTextHandlerSO).GetMethod(nameof(TooltipTextHandlerSO.ProcessStoredValue), ~BindingFlags.Default), typeof(HooksGeneral).GetMethod(nameof(AddStoredValue), ~BindingFlags.Default));
            IDetour idetour12 = new Hook(typeof(OverworldManagerBG).GetMethod(nameof(OverworldManagerBG.Awake), ~BindingFlags.Default), typeof(HooksGeneral).GetMethod(nameof(AwakeOverworld), ~BindingFlags.Default));
            IDetour idetour13 = new Hook(typeof(MainMenuController).GetMethod(nameof(MainMenuController.LoadOldRun), ~BindingFlags.Default), typeof(HooksGeneral).GetMethod(nameof(LoadRun), ~BindingFlags.Default));
            IDetour idetour14 = new Hook(typeof(MainMenuController).GetMethod(nameof(MainMenuController.OnEmbarkPressed), ~BindingFlags.Default), typeof(HooksGeneral).GetMethod(nameof(LoadRun), ~BindingFlags.Default));
            IDetour idetour15 = new Hook(typeof(CharacterCombat).GetMethod(nameof(CharacterCombat.UseAbility), ~BindingFlags.Default), typeof(HooksGeneral).GetMethod(nameof(UseAbilityChara), ~BindingFlags.Default));
            IDetour idetour16 = new Hook(typeof(EnemyCombat).GetMethod(nameof(EnemyCombat.UseAbility), ~BindingFlags.Default), typeof(HooksGeneral).GetMethod(nameof(UseAbilityEnemy), ~BindingFlags.Default));

        }

        public static DamageInfo Damage(Func<IUnit, int, IUnit, DeathType, int, bool, bool, bool, DamageType, DamageInfo> orig, IUnit self, int amount, IUnit killer, DeathType deathType, int targetSlotOffset = -1, bool addHealthMana = true, bool directDamage = true, bool ignoresShield = false, DamageType specialDamage = DamageType.None)
        {
            CombatManager.Instance.PostNotification(GlowingHatCondition.Trigger.ToString(), self, null);
            bool addDet = false;
            if (killer != null && killer.HasUsableItem && killer.HeldItem._itemName == "Silver Bullet" && !self.ContainsStatusEffect((StatusEffectType)555556))
            {
                addDet = true;
            }
            DamageInfo ret = orig(self, amount, killer, deathType, targetSlotOffset, addHealthMana, directDamage, ignoresShield, specialDamage);
            if (addDet)
            {
                CombatManager.Instance.AddUIAction(new ShowItemInformationUIAction(killer.ID, killer.HeldItem.GetItemLocData().text, false, killer.HeldItem.wearableImage));
                ScriptableObject.CreateInstance<ApplyDeterminedEffect>().PerformEffect(CombatManager.Instance._stats, self, Slots.Self.GetTargets(CombatManager.Instance._stats.combatSlots, self.SlotID, self.IsUnitCharacter), Slots.Self.AreTargetSlots, 3, out int exi);
            }
            if (killer != null && killer.HasUsableItem && killer.HeldItem._itemName == "Echo" && ret.damageAmount > 0)
            {
                try
                {
                    GenericTargetting_BySlot_Index get = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
                    get.slotPointerDirections = new int[] { targetSlotOffset > 0 ? self.SlotID + targetSlotOffset : self.SlotID };
                    get.getAllies = killer.IsUnitCharacter == self.IsUnitCharacter;

                    new DelayedAttack(ret.damageAmount, get.GetTargets(CombatManager.Instance._stats.combatSlots, killer.SlotID, killer.IsUnitCharacter)[0], killer).Add();
                    CombatManager.Instance.AddUIAction(new ShowItemInformationUIAction(killer.ID, killer.HeldItem.GetItemLocData().text, false, killer.HeldItem.wearableImage));
                }
                catch
                {
                    Debug.LogError("Echo failed");
                }
            }
            if (killer != null && self.ContainsPassiveAbility(WarpingHandler.Type) && ret.damageAmount > 0)
            {
                WarpingPassiveEffect w = ScriptableObject.CreateInstance<WarpingPassiveEffect>();
                w.ID = self.ID;
                w.IsUnitCharacter = self.IsUnitCharacter;
                CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[]
                {
                    new Effect(w, 1, null, Slots.Self),
                    new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, null, Slots.Self)
                }), killer));
            }
            return ret;
        }
        public static int WillApplyDamage(Func<IUnit, int, IUnit, int> orig, IUnit self, int amount, IUnit targetUnit)
        {
            int currentHealth = targetUnit.CurrentHealth;
            bool opponentHealthIsBigger = self.CurrentHealth <= currentHealth;
            int ret = orig(self, amount, targetUnit);
            if (self.HasUsableItem && self.HeldItem._itemName == "Silver Bullet" && targetUnit.ContainsStatusEffect((StatusEffectType)555556))
            {
                CombatManager.Instance.AddUIAction(new ShowItemInformationUIAction(self.ID, self.HeldItem.GetItemLocData().text, false, self.HeldItem.wearableImage));
                ret *= 2;
            }
            DamageDealtValueChangeException ex = new DamageDealtValueChangeException(ret, opponentHealthIsBigger, targetUnit.Size, (targetUnit is EnemyCombat enemy && SaltEnemies.OtherAvians.Contains(enemy.Enemy)) ? SaltEnemies.Avian : targetUnit.UnitType);
            CombatManager.Instance.PostNotification(SaltEnemies.FeatherGun.ToString(), self, ex);
            return ex.GetModifiedValue();
        }
        public static void StartMenu(Action<MainMenuController> orig, MainMenuController self)
        {
            orig(self);
            SaltEnemies.PCall(PerformRandomEffectsSpecificAmongEffects.GO);
        }
        public static void InitializeCombat(Action<CombatManager> orig, CombatManager self)
        {
            DragonSongEffect.WereDragons = false;
            CopyLastAbilityEffect.LastAbility = null;
            orig(self);
        }
        public static void PlayerTurnStart(Action<CombatStats> orig, CombatStats self)
        {
            orig(self);
        }
        public static void PlayerTurnEnd(Action<CombatStats> orig, CombatStats self)
        {
            orig(self);
        }
        public static void PostNotification(Action<CombatManager, string, object, object> orig, CombatManager self, string call, object sender, object args)
        {
            orig(self, call, sender, args);
        }
        public static IEnumerator EffectActionExecute(Func<EffectAction, CombatStats, IEnumerator> orig, EffectAction self, CombatStats stats)
        {
            return orig(self, stats);
        }
        public static string AddStoredValue(Func<TooltipTextHandlerSO, UnitStoredValueNames, int, string> orig, TooltipTextHandlerSO self, UnitStoredValueNames storedValue, int value)
        {
            string str1;
            if (storedValue == (UnitStoredValueNames)77889 && value > 0)
            {
                string str2 = "Multiattack" + string.Format(" +{0}", value);
                string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(self._positiveSTColor) + ">";
                string str4 = "</color>";
                str1 = str3 + str2 + str4;
            }
            else if (storedValue == ResistanceCondition.Red && value > 0)
            {
                string str2 = "Resists Red";
                string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(self._negativeSTColor) + ">";
                string str4 = "</color>";
                str1 = str3 + str2 + str4;
            }
            else if (storedValue == ResistanceCondition.Blue && value > 0)
            {
                string str2 = "Resists Blue";
                string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(self._positiveSTColor) + ">";
                string str4 = "</color>";
                str1 = str3 + str2 + str4;
            }
            else if (storedValue == ResistanceCondition.Yellow && value > 0)
            {
                string str2 = "Resists Yellow";
                string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(Color.yellow) + ">";
                string str4 = "</color>";
                str1 = str3 + str2 + str4;
            }
            else if (storedValue == ResistanceCondition.Purple && value > 0)
            {
                string str2 = "Resists Purple";
                string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(Color.magenta) + ">";
                string str4 = "</color>";
                str1 = str3 + str2 + str4;
            }
            else if (storedValue == ResistanceCondition.Grey && value > 0)
            {
                string str2 = "Resists Grey";
                string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(Color.grey) + ">";
                string str4 = "</color>";
                str1 = str3 + str2 + str4;
            }
            else
                str1 = orig(self, storedValue, value);
            return str1;
        }
        public static void AwakeOverworld(Action<OverworldManagerBG> orig, OverworldManagerBG self)
        {
            orig(self);
        }
        public static void LoadRun(Action<MainMenuController> orig, MainMenuController self)
        {
            orig(self);
        }
        public static void UseAbilityChara(Action<CharacterCombat, int, FilledManaCost[]> orig, CharacterCombat self, int abilityID, FilledManaCost[] filledCost)
        {
            if (self.CombatAbilities.Count > abilityID) if (self.CombatAbilities[abilityID].ability._abilityName != "Replicate") CopyLastAbilityEffect.LastAbility = self.CombatAbilities[abilityID].ability;
            orig(self, abilityID, filledCost);
        }
        public static void UseAbilityEnemy(Action<EnemyCombat, int> orig, EnemyCombat self, int abilityID)
        {
            if (self.Abilities.Count > abilityID) CopyLastAbilityEffect.LastAbility = self.Abilities[abilityID].ability;
            orig(self, abilityID);
        }
    }
}
