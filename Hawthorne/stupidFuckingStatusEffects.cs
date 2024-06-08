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
using THE_DEAD;



namespace Hawthorne
{
    public static class stupidFuckingStatusEffects
    {
        public static void UseMutedAbilityChara(Action<CharacterCombat, int, FilledManaCost[]> orig, CharacterCombat self, int abilityID, FilledManaCost[] filledCost)
        {
            AbilitySO ability = self.CombatAbilities[abilityID].ability;
            if (self.ContainsStatusEffect((StatusEffectType)846750) && ability._abilityName != "Slap")
            {
                try
                {
                    Vector3 loc = default(Vector3);
                    CombatStats stats = CombatManager.Instance._stats;
                    try
                    {
                        if (!self.IsUnitCharacter)
                        {
                            loc = stats.combatUI._characterZone._characters[self.FieldID].FieldEntity.Position;
                        }
                    }
                    catch { }
                    CombatManager.Instance.AddUIAction(new PlaySoundUIAction("event:/Hawthorne/Boowomp", loc));
                }
                catch { }
                StringReference args = new StringReference(ability.GetAbilityLocData().text);
                CombatManager.Instance.PostNotification(TriggerCalls.OnAbilityWillBeUsed.ToString(), self, args);
                CombatManager.Instance.AddRootAction(new StartAbilityCostAction(self.ID, filledCost));
                Debug.Log("is muted, used not slap");
                CombatManager.Instance.AddRootAction(new AddLuckyManaAction());
                CombatManager.Instance.AddRootAction(new EndAbilityAction(self.ID, self.IsUnitCharacter));
                self.CanUseAbilities = false;
                self.HasManuallyUsedAbilityThisTurn = true;
                self.UpdatePerformAbilityCounter();
                self.SetVolatileUpdateUIAction();
                return;
            }
            orig(self, abilityID, filledCost);
        }

        public static void UseMutedAbilityEn(Action<EnemyCombat, int> orig, EnemyCombat self, int abilitySlot)
        {
            if (abilitySlot >= self.Abilities.Count)
            {
                abilitySlot = self.Abilities.Count - 1;
            }
            AbilitySO ability = self.Abilities[abilitySlot].ability;
            if (self.ContainsStatusEffect((StatusEffectType)846750) && ability._abilityName != "Slap")
            {
                try
                {
                    Vector3 loc = default(Vector3);
                    CombatStats stats = CombatManager.Instance._stats;
                    try
                    {
                        if (!self.IsUnitCharacter)
                        {
                            loc = stats.combatUI._enemyZone._enemies[self.FieldID].FieldEntity.Position;
                        }
                    }
                    catch { }
                    CombatManager.Instance.AddUIAction(new PlaySoundUIAction("event:/Hawthorne/Boowomp", loc));
                }
                catch { }
                Debug.Log("is muted, used not slap");
                StringReference args = new StringReference("Slap");
                CombatManager.Instance.PostNotification(TriggerCalls.OnAbilityWillBeUsed.ToString(), self, args);
                Effect slap = new Effect(ScriptableObject.CreateInstance<SlapEffect>(), 1, null, Slots.Self);
                CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { slap }), (self as IUnit)));
                self.EndTurn();
                return;
            }
            orig(self, abilitySlot);
        }

        public static bool UnMaximizeHealthChara(Func<CharacterCombat, int, bool> orig, CharacterCombat self, int newMaxHealth)
        {
            if (self.ContainsStatusEffect((StatusEffectType)846748))
            {
                int newer = newMaxHealth - self.MaximumHealth;
                int real = self.MaximumHealth - newer;
                return orig(self, real);
            }
            else
            {
                return orig(self, newMaxHealth);
            }
        }

        public static bool UnMaximizeHealthEn(Func<EnemyCombat, int, bool> orig, EnemyCombat self, int newMaxHealth)
        {
            if (self.ContainsStatusEffect((StatusEffectType)846748))
            {
                int newer = newMaxHealth - self.MaximumHealth;
                int real = self.MaximumHealth - newer;
                return orig(self, real);
            }
            else
            {
                return orig(self, newMaxHealth);
            }
        }

        public static StatusEffectInfoSO muted = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
        public static void AddMutedStatusEffect(Action<CombatManager> orig, CombatManager self)
        {
            orig(self);
            muted.name = "Muted";
            muted.icon = ResourceLoader.LoadSprite("MutedIcon", 32);
            muted._statusName = "Muted";
            muted.statusEffectType = (StatusEffectType)846750;
            muted._description = "If this character or enemy attempts to perform an ability other than Slap, it fails. If this character does not have Slap, adds it as an additional ability; enemies simply perform Slap instead of their listed ability. \nReduce by 1 at the end of each turn.";
            muted._applied_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.DivineProtection].AppliedSoundEvent;
            muted._updated_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.DivineProtection].UpdatedSoundEvent;
            muted._removed_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.DivineProtection].RemovedSoundEvent;
            StatusEffectInfoSO effectInfo;
            self._stats.statusEffectDataBase.TryGetValue((StatusEffectType)846750, out effectInfo);
            if (effectInfo == null)
                self._stats.statusEffectDataBase.Add((StatusEffectType)846750, muted);
        }
        public static IntentInfo mutedIntent = new IntentInfoBasic();
        public static void MutedIntent(Action<IntentHandlerSO> orig, IntentHandlerSO self)
        {
            orig(self);
            mutedIntent._type = (IntentType)846750;
            mutedIntent._sprite = ResourceLoader.LoadSprite("MutedIcon", 32);
            mutedIntent._color = UnityEngine.Color.white;
            mutedIntent._sound = self._intentDB[IntentType.Status_DivineProtection]._sound;
            IntentInfo intentInfo;
            self._intentDB.TryGetValue((IntentType)846750, out intentInfo);
            if (intentInfo == null)
                self._intentDB.Add((IntentType)846750, (IntentInfo)mutedIntent);
        }

        public static StatusEffectInfoSO inverted = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
        public static void AddInvertedStatusEffect(Action<CombatManager> orig, CombatManager self)
        {
            orig(self);
            inverted.name = "Inverted";
            inverted.icon = ResourceLoader.LoadSprite("InvertedIcon", 32);
            inverted._statusName = "Inverted";
            inverted.statusEffectType = (StatusEffectType)846749;
            inverted._description = "All direct damage dealt to this unit is converted into indirect healing. All direct healing received by this unit is converted into indirect damage. Reduce by 1 at the start of each turn.";
            inverted._applied_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Cursed].AppliedSoundEvent;
            inverted._updated_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Cursed].UpdatedSoundEvent;
            inverted._removed_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Cursed].RemovedSoundEvent;
            StatusEffectInfoSO effectInfo;
            self._stats.statusEffectDataBase.TryGetValue((StatusEffectType)846749, out effectInfo);
            if (effectInfo == null)
                self._stats.statusEffectDataBase.Add((StatusEffectType)846749, inverted);
        }
        public static IntentInfo invertedIntent = new IntentInfoBasic();
        public static void InvertedIntent(Action<IntentHandlerSO> orig, IntentHandlerSO self)
        {
            orig(self);
            invertedIntent._type = (IntentType)846749;
            invertedIntent._sprite = ResourceLoader.LoadSprite("InvertedIcon", 32);
            invertedIntent._color = UnityEngine.Color.white;
            invertedIntent._sound = self._intentDB[IntentType.Status_Cursed]._sound;
            IntentInfo intentInfo;
            self._intentDB.TryGetValue((IntentType)846749, out intentInfo);
            if (intentInfo == null)
                self._intentDB.Add((IntentType)846749, (IntentInfo)invertedIntent);
        }

        public static StatusEffectInfoSO unstitched = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
        public static void AddUnStitchedStatusEffect(Action<CombatManager> orig, CombatManager self)
        {
            orig(self);
            unstitched.name = "UnStitched";
            unstitched.icon = ResourceLoader.LoadSprite("UnStitchedIcon", 32);
            unstitched._statusName = "Un-Stitched";
            unstitched.statusEffectType = (StatusEffectType)846748;
            unstitched._description = "Decreases in max health increase max health instead. Increases in max health decrease max health instead.";
            unstitched._applied_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Gutted].AppliedSoundEvent;
            unstitched._updated_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Gutted].UpdatedSoundEvent;
            unstitched._removed_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Gutted].RemovedSoundEvent;
            StatusEffectInfoSO effectInfo;
            self._stats.statusEffectDataBase.TryGetValue((StatusEffectType)846748, out effectInfo);
            if (effectInfo == null)
                self._stats.statusEffectDataBase.Add((StatusEffectType)846748, unstitched);
        }
        public static IntentInfo unstitchedIntent = new IntentInfoBasic();
        public static void UnStitchedIntent(Action<IntentHandlerSO> orig, IntentHandlerSO self)
        {
            orig(self);
            unstitchedIntent._type = (IntentType)846748;
            unstitchedIntent._sprite = ResourceLoader.LoadSprite("UnStitchedIcon", 32);
            unstitchedIntent._color = UnityEngine.Color.white;
            unstitchedIntent._sound = self._intentDB[IntentType.Status_Gutted]._sound;
            IntentInfo intentInfo;
            self._intentDB.TryGetValue((IntentType)846748, out intentInfo);
            if (intentInfo == null)
                self._intentDB.Add((IntentType)846748, (IntentInfo)unstitchedIntent);
        }

        public static StatusEffectInfoSO entropy = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
        public static void AddEntropyStatusEffect(Action<CombatManager> orig, CombatManager self)
        {
            orig(self);
            entropy.name = "Entropy";
            entropy.icon = ResourceLoader.LoadSprite("EntropyIcon", 32);
            entropy._statusName = "Entropy";
            entropy.statusEffectType = (StatusEffectType)846747;
            entropy._description = "Every 30 seconds, this unit receives 1 indirect damage. \nUpon activation, reduce the time required by 3-9 seconds and decrease Entropy by 1. Cannot reduce below 1 second.";
            entropy._applied_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Gutted].AppliedSoundEvent;
            entropy._updated_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Gutted].UpdatedSoundEvent;
            entropy._removed_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Gutted].RemovedSoundEvent;
            StatusEffectInfoSO effectInfo;
            self._stats.statusEffectDataBase.TryGetValue((StatusEffectType)846747, out effectInfo);
            if (effectInfo == null)
                self._stats.statusEffectDataBase.Add((StatusEffectType)846747, entropy);
        }
        public static IntentInfo entropyIntent = new IntentInfoBasic();
        public static void EntropyIntent(Action<IntentHandlerSO> orig, IntentHandlerSO self)
        {
            orig(self);
            entropyIntent._type = (IntentType)846747;
            entropyIntent._sprite = ResourceLoader.LoadSprite("EntropyIcon", 32);
            entropyIntent._color = UnityEngine.Color.white;
            entropyIntent._sound = self._intentDB[IntentType.Status_Gutted]._sound;
            IntentInfo intentInfo;
            self._intentDB.TryGetValue((IntentType)846747, out intentInfo);
            if (intentInfo == null)
                self._intentDB.Add((IntentType)846747, (IntentInfo)entropyIntent);
        }

        public static StatusEffectInfoSO bleeding = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
        public static void AddBleedingStatusEffect(Action<CombatManager> orig, CombatManager self)
        {
            orig(self);
            bleeding.name = "Bleeding";
            bleeding.icon = ResourceLoader.LoadSprite("BleedingIcon", 32);
            bleeding._statusName = "Bleeding";
            bleeding.statusEffectType = (StatusEffectType)846746;
            bleeding._description = "Upon taking any Ruptured damage, increase it by 1 for each stack of this, and reduce this effect by 1. Upon dealing damage higher than half of this character's current health, take 1 Ruptured damage and reduce this effect by 1. \nReduce by 1 at the end of each turn.";
            bleeding._applied_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Ruptured].AppliedSoundEvent;
            bleeding._updated_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Ruptured].UpdatedSoundEvent;
            bleeding._removed_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Ruptured].RemovedSoundEvent;
            StatusEffectInfoSO effectInfo;
            self._stats.statusEffectDataBase.TryGetValue((StatusEffectType)846746, out effectInfo);
            if (effectInfo == null)
                self._stats.statusEffectDataBase.Add((StatusEffectType)846746, bleeding);
        }
        public static IntentInfo bleedingIntent = new IntentInfoBasic();
        public static void BleedingIntent(Action<IntentHandlerSO> orig, IntentHandlerSO self)
        {
            orig(self);
            bleedingIntent._type = (IntentType)846746;
            bleedingIntent._sprite = ResourceLoader.LoadSprite("BleedingIcon", 32);
            bleedingIntent._color = UnityEngine.Color.white;
            bleedingIntent._sound = self._intentDB[IntentType.Status_Ruptured]._sound;
            IntentInfo intentInfo;
            self._intentDB.TryGetValue((IntentType)846746, out intentInfo);
            if (intentInfo == null)
                self._intentDB.Add((IntentType)846746, (IntentInfo)bleedingIntent);
        }

        public static StatusEffectInfoSO sacrifice = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
        public static void AddDSStatusEffect(Action<CombatManager> orig, CombatManager self)
        {
            orig(self);
            sacrifice.name = "DivineSacrifice";
            sacrifice.icon = ResourceLoader.LoadSprite("SacrificeIcon", 32);
            sacrifice._statusName = "Divine Sacrifice";
            sacrifice.statusEffectType = (StatusEffectType)846745;
            sacrifice._description = "Triple all Divine Protection damage this character takes. This character is temporarily immune to Divine Protection. Reduce by 1 at the end of each turn.";
            sacrifice._applied_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Cursed].AppliedSoundEvent;
            sacrifice._updated_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Cursed].UpdatedSoundEvent;
            sacrifice._removed_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Cursed].RemovedSoundEvent;
            StatusEffectInfoSO effectInfo;
            self._stats.statusEffectDataBase.TryGetValue((StatusEffectType)846745, out effectInfo);
            if (effectInfo == null)
                self._stats.statusEffectDataBase.Add((StatusEffectType)846745, sacrifice);
        }
        public static IntentInfo sacrificeIntent = new IntentInfoBasic();
        public static void DSIntent(Action<IntentHandlerSO> orig, IntentHandlerSO self)
        {
            orig(self);
            sacrificeIntent._type = (IntentType)846745;
            sacrificeIntent._sprite = ResourceLoader.LoadSprite("SacrificeIcon", 32);
            sacrificeIntent._color = UnityEngine.Color.white;
            sacrificeIntent._sound = self._intentDB[IntentType.Status_Cursed]._sound;
            IntentInfo intentInfo;
            self._intentDB.TryGetValue((IntentType)846745, out intentInfo);
            if (intentInfo == null)
                self._intentDB.Add((IntentType)846745, (IntentInfo)sacrificeIntent);
        }

        public static StatusEffectInfoSO feeble = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
        public static void AddFeebleStatusEffect(Action<CombatManager> orig, CombatManager self)
        {
            orig(self);
            feeble.name = "Feeble";
            feeble.icon = ResourceLoader.LoadSprite("FeebleIcon", 32);
            feeble._statusName = "Feeble";
            feeble.statusEffectType = (StatusEffectType)846744;
            feeble._description = "Upon receiving indirect damage, double it and reduce this effect by 1. Remove 1 of this effect at the end of each turn.";
            feeble._applied_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Frail].AppliedSoundEvent;
            feeble._updated_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Frail].UpdatedSoundEvent;
            feeble._removed_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Frail].RemovedSoundEvent;
            StatusEffectInfoSO effectInfo;
            self._stats.statusEffectDataBase.TryGetValue((StatusEffectType)846744, out effectInfo);
            if (effectInfo == null)
                self._stats.statusEffectDataBase.Add((StatusEffectType)846744, feeble);
        }
        public static IntentInfo feebleIntent = new IntentInfoBasic();
        public static void FeebleIntent(Action<IntentHandlerSO> orig, IntentHandlerSO self)
        {
            orig(self);
            feebleIntent._type = (IntentType)846744;
            feebleIntent._sprite = ResourceLoader.LoadSprite("FeebleIcon", 32);
            feebleIntent._color = UnityEngine.Color.white;
            feebleIntent._sound = self._intentDB[IntentType.Status_Frail]._sound;
            IntentInfo intentInfo;
            self._intentDB.TryGetValue((IntentType)846744, out intentInfo);
            if (intentInfo == null)
                self._intentDB.Add((IntentType)846744, (IntentInfo)feebleIntent);
        }

        public static StatusEffectInfoSO allergy = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
        public static void AddPaintStatusEffect(Action<CombatManager> orig, CombatManager self)
        {
            orig(self);
            allergy.name = "PaintAllergy";
            allergy.icon = ResourceLoader.LoadSprite("AllergyIcon", 32);
            allergy._statusName = "Paint Allergy";
            allergy.statusEffectType = (StatusEffectType)846743;
            allergy._description = "While under Paint Allergy, all Wrong Pigment and Overflow damage is doubled. Reduce by 1 at the end of each turn.";
            allergy._applied_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Scars].AppliedSoundEvent;
            allergy._updated_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Scars].UpdatedSoundEvent;
            allergy._removed_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Scars].RemovedSoundEvent;
            StatusEffectInfoSO effectInfo;
            self._stats.statusEffectDataBase.TryGetValue((StatusEffectType)846743, out effectInfo);
            if (effectInfo == null)
                self._stats.statusEffectDataBase.Add((StatusEffectType)846743, allergy);
        }
        public static IntentInfo allergyIntent = new IntentInfoBasic();
        public static void PaintIntent(Action<IntentHandlerSO> orig, IntentHandlerSO self)
        {
            orig(self);
            allergyIntent._type = (IntentType)846743;
            allergyIntent._sprite = ResourceLoader.LoadSprite("AllergyIcon", 32);
            allergyIntent._color = UnityEngine.Color.white;
            allergyIntent._sound = self._intentDB[IntentType.Status_Scars]._sound;
            IntentInfo intentInfo;
            self._intentDB.TryGetValue((IntentType)846743, out intentInfo);
            if (intentInfo == null)
                self._intentDB.Add((IntentType)846743, (IntentInfo)allergyIntent);
        }

        public static StatusEffectInfoSO sin = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
        public static void AddSinStatusEffect(Action<CombatManager> orig, CombatManager self)
        {
            orig(self);
            sin.name = "Sin";
            sin.icon = ResourceLoader.LoadSprite("SinIcon", 32);
            sin._statusName = "Sin";
            sin.statusEffectType = (StatusEffectType)846742;
            sin._description = "Upon taking Pale damage, multiply it by the amount of Sin. increase Sin by 1 on kill.";
            sin._applied_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Linked].AppliedSoundEvent;
            sin._updated_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Linked].UpdatedSoundEvent;
            sin._removed_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Linked].RemovedSoundEvent;
            StatusEffectInfoSO effectInfo;
            self._stats.statusEffectDataBase.TryGetValue((StatusEffectType)846742, out effectInfo);
            if (effectInfo == null)
                self._stats.statusEffectDataBase.Add((StatusEffectType)846742, sin);
        }
        public static IntentInfo sinIntent = new IntentInfoBasic();
        public static void SinIntent(Action<IntentHandlerSO> orig, IntentHandlerSO self)
        {
            orig(self);
            sinIntent._type = (IntentType)846742;
            sinIntent._sprite = ResourceLoader.LoadSprite("SinIcon", 32);
            sinIntent._color = UnityEngine.Color.white;
            sinIntent._sound = self._intentDB[IntentType.Status_Linked]._sound;
            IntentInfo intentInfo;
            self._intentDB.TryGetValue((IntentType)846742, out intentInfo);
            if (intentInfo == null)
                self._intentDB.Add((IntentType)846742, (IntentInfo)sinIntent);
        }

        public static StatusEffectInfoSO ascetic = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
        public static void AddAsceticStatusEffect(Action<CombatManager> orig, CombatManager self)
        {
            orig(self);
            ascetic.name = "Ascetic";
            ascetic.icon = ResourceLoader.LoadSprite("AsceticIcon", 32);
            ascetic._statusName = "Ascetic";
            ascetic.statusEffectType = (StatusEffectType)846741;
            ascetic._description = "This character is immune to indirect damage, but receives 4 times direct damage.";
            ascetic._applied_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Frail].AppliedSoundEvent;
            ascetic._updated_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Frail].UpdatedSoundEvent;
            ascetic._removed_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Frail].RemovedSoundEvent;
            StatusEffectInfoSO effectInfo;
            self._stats.statusEffectDataBase.TryGetValue((StatusEffectType)846741, out effectInfo);
            if (effectInfo == null)
                self._stats.statusEffectDataBase.Add((StatusEffectType)846741, ascetic);
        }
        public static IntentInfo asceticIntent = new IntentInfoBasic();
        public static void AsceticIntent(Action<IntentHandlerSO> orig, IntentHandlerSO self)
        {
            orig(self);
            asceticIntent._type = (IntentType)846741;
            asceticIntent._sprite = ResourceLoader.LoadSprite("AsceticIcon", 32);
            asceticIntent._color = UnityEngine.Color.white;
            asceticIntent._sound = self._intentDB[IntentType.Status_Frail]._sound;
            IntentInfo intentInfo;
            self._intentDB.TryGetValue((IntentType)846741, out intentInfo);
            if (intentInfo == null)
                self._intentDB.Add((IntentType)846741, (IntentInfo)asceticIntent);
        }

        public static StatusEffectInfoSO doom = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
        public static void AddDoomStatusEffect(Action<CombatManager> orig, CombatManager self)
        {
            orig(self);
            doom.name = "Doom";
            doom.icon = ResourceLoader.LoadSprite("DoomIcon", 32);
            doom._statusName = "Doom";
            doom.statusEffectType = (StatusEffectType)846740;
            doom._description = "At the end of each turn, there is a percent chance equal to this status effect's amount to instantly kill this character. Reduce this effect by half at the end of each turn. Remove this effect upon activation.";
            doom._applied_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Cursed].AppliedSoundEvent;
            doom._updated_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Cursed].UpdatedSoundEvent;
            doom._removed_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Cursed].RemovedSoundEvent;
            StatusEffectInfoSO effectInfo;
            self._stats.statusEffectDataBase.TryGetValue((StatusEffectType)846740, out effectInfo);
            if (effectInfo == null)
                self._stats.statusEffectDataBase.Add((StatusEffectType)846740, doom);
        }
        public static IntentInfo doomIntent = new IntentInfoBasic();
        public static void DoomIntent(Action<IntentHandlerSO> orig, IntentHandlerSO self)
        {
            orig(self);
            doomIntent._type = (IntentType)846740;
            doomIntent._sprite = ResourceLoader.LoadSprite("DoomIcon", 32);
            doomIntent._color = UnityEngine.Color.white;
            doomIntent._sound = self._intentDB[IntentType.Status_Cursed]._sound;
            IntentInfo intentInfo;
            self._intentDB.TryGetValue((IntentType)846740, out intentInfo);
            if (intentInfo == null)
                self._intentDB.Add((IntentType)846740, (IntentInfo)doomIntent);
        }

        public static StatusEffectInfoSO status = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
        public static void AddStatusStatusEffect(Action<CombatManager> orig, CombatManager self)
        {
            orig(self);
            status.name = "StatusEffect";
            status.icon = ResourceLoader.LoadSprite("StatusEffectIcon", 32);
            status._statusName = "Status Effect";
            status.statusEffectType = (StatusEffectType)846739;
            status._description = "Does nothing. Reduce by 1 at the end of each turn.";
            status._applied_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Ruptured].AppliedSoundEvent;
            status._updated_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Ruptured].UpdatedSoundEvent;
            status._removed_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Ruptured].RemovedSoundEvent;
            StatusEffectInfoSO effectInfo;
            self._stats.statusEffectDataBase.TryGetValue((StatusEffectType)846739, out effectInfo);
            if (effectInfo == null)
                self._stats.statusEffectDataBase.Add((StatusEffectType)846739, status);
        }
        public static IntentInfo statusIntent = new IntentInfoBasic();
        public static void StatusIntent(Action<IntentHandlerSO> orig, IntentHandlerSO self)
        {
            orig(self);
            statusIntent._type = (IntentType)846739;
            statusIntent._sprite = ResourceLoader.LoadSprite("StatusEffectIcon", 32);
            statusIntent._color = UnityEngine.Color.white;
            statusIntent._sound = self._intentDB[IntentType.Status_Ruptured]._sound;
            IntentInfo intentInfo;
            self._intentDB.TryGetValue((IntentType)846739, out intentInfo);
            if (intentInfo == null)
                self._intentDB.Add((IntentType)846739, (IntentInfo)statusIntent);
        }

        public static StatusEffectInfoSO left = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
        public static void AddLeftStatusEffect(Action<CombatManager> orig, CombatManager self)
        {
            orig(self);
            left.name = "Left";
            left.icon = ResourceLoader.LoadSprite("LeftIcon", 32);
            left._statusName = "Left";
            left.statusEffectType = (StatusEffectType)846738;
            left._description = "On being moved, this character moves left, and reduces this effect by 1.";
            left._applied_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Frail].AppliedSoundEvent;
            left._updated_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Frail].UpdatedSoundEvent;
            left._removed_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Frail].RemovedSoundEvent;
            StatusEffectInfoSO effectInfo;
            self._stats.statusEffectDataBase.TryGetValue((StatusEffectType)846738, out effectInfo);
            if (effectInfo == null)
                self._stats.statusEffectDataBase.Add((StatusEffectType)846738, left);
        }
        public static IntentInfo leftIntent = new IntentInfoBasic();
        public static void LeftIntent(Action<IntentHandlerSO> orig, IntentHandlerSO self)
        {
            orig(self);
            leftIntent._type = (IntentType)846738;
            leftIntent._sprite = ResourceLoader.LoadSprite("LeftIcon", 32);
            leftIntent._color = UnityEngine.Color.white;
            leftIntent._sound = self._intentDB[IntentType.Status_Frail]._sound;
            IntentInfo intentInfo;
            self._intentDB.TryGetValue((IntentType)846738, out intentInfo);
            if (intentInfo == null)
                self._intentDB.Add((IntentType)846738, (IntentInfo)leftIntent);
        }

        public static SlotStatusEffectInfoSO mold = ScriptableObject.CreateInstance<SlotStatusEffectInfoSO>();
        public static void AddMoldSlotEffect(Action<CombatManager> orig, CombatManager self)
        {
            orig(self);
            mold.name = "Mold";
            mold.icon = ResourceLoader.LoadSprite("MoldIcon", 32);
            mold._fieldName = "Mildew";
            mold.slotStatusEffectType = (SlotStatusEffectType)862351;
            mold._description = "On being healed, prevent it and add it as more Mildew.";
            mold._applied_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Scars].AppliedSoundEvent;
            mold._updated_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Scars].UpdatedSoundEvent;
            mold._removed_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Scars].RemovedSoundEvent;
            SlotStatusEffectInfoSO effectInfo;
            self._stats.slotStatusEffectDataBase.TryGetValue((SlotStatusEffectType)862351, out effectInfo);
            if (effectInfo == null)
                self._stats.slotStatusEffectDataBase.Add((SlotStatusEffectType)862351, mold);
        }
        public static IntentInfo moldIntent = new IntentInfoBasic();
        public static void MoldIntent(Action<IntentHandlerSO> orig, IntentHandlerSO self)
        {
            orig(self);
            moldIntent._type = (IntentType)862351;
            moldIntent._sprite = ResourceLoader.LoadSprite("MoldIcon", 32);
            moldIntent._color = UnityEngine.Color.white;
            moldIntent._sound = self._intentDB[IntentType.Status_Frail]._sound;
            IntentInfo intentInfo;
            self._intentDB.TryGetValue((IntentType)862351, out intentInfo);
            if (intentInfo == null)
                self._intentDB.Add((IntentType)862351, (IntentInfo)moldIntent);
        }

        public static void Add()
        {
            IDetour MutedCharactersIDetour = (IDetour)new Hook((MethodBase)typeof(CharacterCombat).GetMethod("UseAbility", ~BindingFlags.Default), typeof(stupidFuckingStatusEffects).GetMethod("UseMutedAbilityChara", ~BindingFlags.Default));
            IDetour MutedEnemieIDetour = (IDetour)new Hook((MethodBase)typeof(EnemyCombat).GetMethod("UseAbility", ~BindingFlags.Default), typeof(stupidFuckingStatusEffects).GetMethod("UseMutedAbilityEn", ~BindingFlags.Default));
            IDetour UnStitchedCharactersIDetour = (IDetour)new Hook((MethodBase)typeof(CharacterCombat).GetMethod("MaximizeHealth", ~BindingFlags.Default), typeof(stupidFuckingStatusEffects).GetMethod("UnMaximizeHealthChara", ~BindingFlags.Default));
            IDetour UnStitchedEnemieIDetour = (IDetour)new Hook((MethodBase)typeof(EnemyCombat).GetMethod("MaximizeHealth", ~BindingFlags.Default), typeof(stupidFuckingStatusEffects).GetMethod("UnMaximizeHealthEn", ~BindingFlags.Default));

            IDetour addMutedIDetour = (IDetour)new Hook((MethodBase)typeof(CombatManager).GetMethod("InitializeCombat", ~BindingFlags.Default), typeof(stupidFuckingStatusEffects).GetMethod("AddMutedStatusEffect", ~BindingFlags.Default));
            IDetour addMutedIntentIDetour = (IDetour)new Hook((MethodBase)typeof(IntentHandlerSO).GetMethod("Initialize", ~BindingFlags.Default), typeof(stupidFuckingStatusEffects).GetMethod("MutedIntent", ~BindingFlags.Default));
            IDetour addInvertedIDetour = (IDetour)new Hook((MethodBase)typeof(CombatManager).GetMethod("InitializeCombat", ~BindingFlags.Default), typeof(stupidFuckingStatusEffects).GetMethod("AddInvertedStatusEffect", ~BindingFlags.Default));
            IDetour addInvertedIntentIDetour = (IDetour)new Hook((MethodBase)typeof(IntentHandlerSO).GetMethod("Initialize", ~BindingFlags.Default), typeof(stupidFuckingStatusEffects).GetMethod("InvertedIntent", ~BindingFlags.Default));
            IDetour addUnStitchedIDetour = (IDetour)new Hook((MethodBase)typeof(CombatManager).GetMethod("InitializeCombat", ~BindingFlags.Default), typeof(stupidFuckingStatusEffects).GetMethod("AddUnStitchedStatusEffect", ~BindingFlags.Default));
            IDetour addUnStitchedIntentIDetour = (IDetour)new Hook((MethodBase)typeof(IntentHandlerSO).GetMethod("Initialize", ~BindingFlags.Default), typeof(stupidFuckingStatusEffects).GetMethod("UnStitchedIntent", ~BindingFlags.Default));
            IDetour addEntropyIDetour = (IDetour)new Hook((MethodBase)typeof(CombatManager).GetMethod("InitializeCombat", ~BindingFlags.Default), typeof(stupidFuckingStatusEffects).GetMethod("AddEntropyStatusEffect", ~BindingFlags.Default));
            IDetour addEntropyIntentIDetour = (IDetour)new Hook((MethodBase)typeof(IntentHandlerSO).GetMethod("Initialize", ~BindingFlags.Default), typeof(stupidFuckingStatusEffects).GetMethod("EntropyIntent", ~BindingFlags.Default));
            IDetour addBleedingIDetour = (IDetour)new Hook((MethodBase)typeof(CombatManager).GetMethod("InitializeCombat", ~BindingFlags.Default), typeof(stupidFuckingStatusEffects).GetMethod("AddBleedingStatusEffect", ~BindingFlags.Default));
            IDetour addBleedingIntentIDetour = (IDetour)new Hook((MethodBase)typeof(IntentHandlerSO).GetMethod("Initialize", ~BindingFlags.Default), typeof(stupidFuckingStatusEffects).GetMethod("BleedingIntent", ~BindingFlags.Default));
            IDetour addSacrificeIDetour = (IDetour)new Hook((MethodBase)typeof(CombatManager).GetMethod("InitializeCombat", ~BindingFlags.Default), typeof(stupidFuckingStatusEffects).GetMethod("AddDSStatusEffect", ~BindingFlags.Default));
            IDetour addSacrificeIntentIDetour = (IDetour)new Hook((MethodBase)typeof(IntentHandlerSO).GetMethod("Initialize", ~BindingFlags.Default), typeof(stupidFuckingStatusEffects).GetMethod("DSIntent", ~BindingFlags.Default));
            IDetour addFeebleIDetour = (IDetour)new Hook((MethodBase)typeof(CombatManager).GetMethod("InitializeCombat", ~BindingFlags.Default), typeof(stupidFuckingStatusEffects).GetMethod("AddFeebleStatusEffect", ~BindingFlags.Default));
            IDetour addFeebleIntentIDetour = (IDetour)new Hook((MethodBase)typeof(IntentHandlerSO).GetMethod("Initialize", ~BindingFlags.Default), typeof(stupidFuckingStatusEffects).GetMethod("FeebleIntent", ~BindingFlags.Default));
            IDetour addPaintAllergyIDetour = (IDetour)new Hook((MethodBase)typeof(CombatManager).GetMethod("InitializeCombat", ~BindingFlags.Default), typeof(stupidFuckingStatusEffects).GetMethod("AddPaintStatusEffect", ~BindingFlags.Default));
            IDetour addPaintAllergyIntentIDetour = (IDetour)new Hook((MethodBase)typeof(IntentHandlerSO).GetMethod("Initialize", ~BindingFlags.Default), typeof(stupidFuckingStatusEffects).GetMethod("PaintIntent", ~BindingFlags.Default));
            IDetour addSinIDetour = (IDetour)new Hook((MethodBase)typeof(CombatManager).GetMethod("InitializeCombat", ~BindingFlags.Default), typeof(stupidFuckingStatusEffects).GetMethod("AddSinStatusEffect", ~BindingFlags.Default));
            IDetour addSinIntentIDetour = (IDetour)new Hook((MethodBase)typeof(IntentHandlerSO).GetMethod("Initialize", ~BindingFlags.Default), typeof(stupidFuckingStatusEffects).GetMethod("SinIntent", ~BindingFlags.Default));
            IDetour addAsceticIDetour = (IDetour)new Hook((MethodBase)typeof(CombatManager).GetMethod("InitializeCombat", ~BindingFlags.Default), typeof(stupidFuckingStatusEffects).GetMethod("AddAsceticStatusEffect", ~BindingFlags.Default));
            IDetour addAsceticIntentIDetour = (IDetour)new Hook((MethodBase)typeof(IntentHandlerSO).GetMethod("Initialize", ~BindingFlags.Default), typeof(stupidFuckingStatusEffects).GetMethod("AsceticIntent", ~BindingFlags.Default));
            IDetour addDoomIDetour = (IDetour)new Hook((MethodBase)typeof(CombatManager).GetMethod("InitializeCombat", ~BindingFlags.Default), typeof(stupidFuckingStatusEffects).GetMethod("AddDoomStatusEffect", ~BindingFlags.Default));
            IDetour addDoomIntentIDetour = (IDetour)new Hook((MethodBase)typeof(IntentHandlerSO).GetMethod("Initialize", ~BindingFlags.Default), typeof(stupidFuckingStatusEffects).GetMethod("DoomIntent", ~BindingFlags.Default));
            IDetour addStatusEffectIDetour = (IDetour)new Hook((MethodBase)typeof(CombatManager).GetMethod("InitializeCombat", ~BindingFlags.Default), typeof(stupidFuckingStatusEffects).GetMethod("AddStatusStatusEffect", ~BindingFlags.Default));
            IDetour addStatusEffectIntentIDetour = (IDetour)new Hook((MethodBase)typeof(IntentHandlerSO).GetMethod("Initialize", ~BindingFlags.Default), typeof(stupidFuckingStatusEffects).GetMethod("StatusIntent", ~BindingFlags.Default));
            IDetour addLeftEffectIDetour = (IDetour)new Hook((MethodBase)typeof(CombatManager).GetMethod("InitializeCombat", ~BindingFlags.Default), typeof(stupidFuckingStatusEffects).GetMethod("AddLeftStatusEffect", ~BindingFlags.Default));
            IDetour addLeftEffectIntentIDetour = (IDetour)new Hook((MethodBase)typeof(IntentHandlerSO).GetMethod("Initialize", ~BindingFlags.Default), typeof(stupidFuckingStatusEffects).GetMethod("LeftIntent", ~BindingFlags.Default));
            IDetour addMoldEffectIDetour = (IDetour)new Hook((MethodBase)typeof(CombatManager).GetMethod("InitializeCombat", ~BindingFlags.Default), typeof(stupidFuckingStatusEffects).GetMethod("AddMoldSlotEffect", ~BindingFlags.Default));
            IDetour addMoldEffectIntentIDetour = (IDetour)new Hook((MethodBase)typeof(IntentHandlerSO).GetMethod("Initialize", ~BindingFlags.Default), typeof(stupidFuckingStatusEffects).GetMethod("MoldIntent", ~BindingFlags.Default));
            Favor.Add();
            Intents.Setup();
        }
    }

    public class Muted_StatusEffect : IStatusEffect, ITriggerEffect<IStatusEffector>
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

        public StatusEffectType EffectType => (StatusEffectType)846750;

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

        public Muted_StatusEffect(int amount, int restrictors = 0)
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

        public ExtraAbilityInfo slapExtraAbil()
        {
            Ability slapAbil = new Ability();
            slapAbil.name = "Slap";
            slapAbil.description = "Deal 1 damage to the opposing enemy.";
            slapAbil.sprite = ResourceLoader.LoadSprite("SlapIcon");
            slapAbil.cost = new ManaColorSO[1] { Pigments.Yellow };
            slapAbil.effects = new Effect[1];
            slapAbil.effects[0] = new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 1, IntentType.Damage_1_2, Slots.Front);
            slapAbil.visuals = LoadedAssetsHandler.GetCharacterAbility("Slap_A").visuals;
            slapAbil.animationTarget = Slots.Front;
            ExtraAbilityInfo slapAdd = new ExtraAbilityInfo();
            slapAdd.ability = slapAbil.CharacterAbility().ability;
            slapAdd.cost = new ManaColorSO[1] { Pigments.Yellow };
            return slapAdd;
        }

        public bool hasSlap = false;

        public bool addedSlap = false;

        public void OnTriggerAttached(IStatusEffector caller)
        {
            if (caller is CharacterCombat character)
            {
                //bool hasSlap = false;
                foreach (CombatAbility ability in character.CombatAbilities)
                {
                    if (ability.ability._abilityName == "Slap")
                    {
                        hasSlap = true;
                    }
                }
                foreach (ExtraAbilityInfo ability in character.ExtraAbilities)
                {
                    if (ability.ability._abilityName == "Slap")
                    {
                        hasSlap = true;
                    }
                }
                if (!hasSlap)
                {
                    character.AddExtraAbility(slapExtraAbil());
                    //Debug.Log("added Slap");
                    addedSlap = true;
                }
            }


            //CombatManager.Instance.AddObserver(new Action<object, object>(this.OnStatusTriggered), TriggerCalls.OnWillApplyDamage.ToString(), caller);
            CombatManager.Instance.AddObserver(new Action<object, object>(this.OnTurnEnd), TriggerCalls.OnTurnFinished.ToString(), caller);
        }

        public void OnTriggerDettached(IStatusEffector caller)
        {
            //Debug.Log("removing status effect");
            //CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnStatusTriggered), TriggerCalls.OnWillApplyDamage.ToString(), caller);
            CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnTurnEnd), TriggerCalls.OnTurnFinished.ToString(), caller);

            if (caller is CharacterCombat character && addedSlap)
            {
                //Debug.Log("has receivd extra slap");
                foreach (ExtraAbilityInfo ability in character.ExtraAbilities)
                {
                    //Debug.Log("ability found");
                    if (ability.ability._abilityName == "Slap")
                    {
                        //Debug.Log("is slap");
                        character.TryRemoveExtraAbility(ability);
                        //Debug.Log("removed");
                        addedSlap = false;
                        break;
                    }
                }
            }
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
            int duration = this.Amount;
            this.Amount = Mathf.Max(0, this.Amount - 1);
            if (!this.TryRemoveStatusEffect(effector) && duration != this.Amount)
            {
                effector.StatusEffectValuesChanged(this.EffectType, this.Amount - duration);
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
    public class ApplyMutedEffect : EffectSO
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
            stats.statusEffectDataBase.TryGetValue((StatusEffectType)846750, out effectInfo);




            for (int index = 0; index < targets.Length; ++index)
            {
                if (targets[index].HasUnit)
                {
                    int amount = this._randomBetweenPrevious ? UnityEngine.Random.Range(this.PreviousExitValue, entryVariable + 1) : entryVariable;
                    IStatusEffect statuseffect = new Muted_StatusEffect(amount);

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

    public class Inverted_StatusEffect : IStatusEffect, ITriggerEffect<IStatusEffector>
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

        public StatusEffectType EffectType => (StatusEffectType)846749;

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

        public Inverted_StatusEffect(int amount, int restrictors = 0)
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
            CombatManager.Instance.AddObserver(new Action<object, object>(this.OnStatusTriggered), TriggerCalls.CanHeal.ToString(), caller);
            CombatManager.Instance.AddObserver(new Action<object, object>(this.OnTurnEnd), TriggerCalls.OnTurnStart.ToString(), caller);
        }

        public void OnTriggerDettached(IStatusEffector caller)
        {
            CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnStatusTriggered), TriggerCalls.OnBeingDamaged.ToString(), caller);
            CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnStatusTriggered), TriggerCalls.CanHeal.ToString(), caller);
            CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnTurnEnd), TriggerCalls.OnTurnStart.ToString(), caller);
        }

        public void OnSubActionTrigger(object sender, object args, bool stateCheck)
        {

        }

        public void OnStatusTriggered(object sender, object args)
        {
            if (sender is IUnit unit)
            {
                if (args is DamageReceivedValueChangeException hitBy)
                {
                    if (hitBy.directDamage == true)
                    {
                        if (unit.ContainsStatusEffect(StatusEffectType.DivineProtection))
                        {
                            hitBy.AddModifier(new ImmZeroMod());
                            unit.Heal(hitBy.amount, HealType.None, false);
                        }
                        else
                        {
                            hitBy.AddModifier(new InvertedDamageModifier(unit));
                        }
                    }
                }
                if (args is CanHealReference healing)
                {
                    if (healing.directHeal == true)
                    {
                        healing.value = false;
                        unit.Damage(healing.healAmount, null, DeathType.Basic, -1, false, false, true);
                    }
                }
            }
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
    public class InvertedDamageModifier : IntValueModifier
    {
        public readonly int amount;
        public readonly IUnit unit;
        public InvertedDamageModifier(IUnit unit)
            : base(77)
        {
            this.unit = unit;
        }

        public override int Modify(int value)
        {
            if (value > 0)
            {
                unit.Heal(value, HealType.None, false);
            }
            return 0;
        }
    }
    public class ApplyInvertedEffect : EffectSO
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
            stats.statusEffectDataBase.TryGetValue((StatusEffectType)846749, out effectInfo);




            for (int index = 0; index < targets.Length; ++index)
            {
                if (targets[index].HasUnit)
                {
                    int amount = this._randomBetweenPrevious ? UnityEngine.Random.Range(this.PreviousExitValue, entryVariable + 1) : entryVariable;
                    IStatusEffect statuseffect = new Inverted_StatusEffect(amount);

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

    public class SlapEffect : EffectSO
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

            CombatManager.Instance.AddUIAction(new ShowAttackInformationUIAction(caster.ID, caster.IsUnitCharacter, "Slap"));
            AnimationVisualsEffect slapAnim = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            slapAnim._visuals = LoadedAssetsHandler.GetCharacterAbility("Slap_A").visuals;
            slapAnim._animationTarget = Slots.Front;
            Effect anim = new Effect(slapAnim, 1, null, Slots.Front);
            Effect slap = new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 1, null, Slots.Front);
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[2] { anim, slap }), caster));
            CombatManager.Instance.AddRootAction(new EndAbilityAction(caster.ID, caster.IsUnitCharacter));
            exitAmount++;
            return exitAmount > 0;
        }
    }

}

