using BrutalAPI;
using MonoMod.RuntimeDetour;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using THE_DEAD;
using UnityEngine;
using static Hawthorne.CustomIntentIconSystem;
using static UnityEngine.GraphicsBuffer;

namespace Hawthorne
{
    public static class Bbili
    {
        static Ability _windy;
        public static Ability Windy
        {
            get
            {
                if (_windy == null)
                {
                    _windy = new Ability()
                    {
                        name = "Windy Day",
                        description = "Move to the Left or Right. Inflict 2 Slip on the Left and Right enemy positions.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 2, IntentType.Swap_Sides, Slots.Self),
                            new Effect(ScriptableObject.CreateInstance<ApplySlipSlotEffect>(), 2, GetIntent("Slip"), Slots.Sides)
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Swirl"),
                        animationTarget = Slots.Self,
                    };
                }
                return _windy;
            }
        }
        static Ability _drift;
        public static Ability Drift
        {
            get
            {
                if (_drift == null)
                {
                    _drift = new Ability()
                    {
                        name = "Drift",
                        description = "Inflict 3 Slip on the Opposing party member position. Inflict 2 Ruptured on the Left and Right party members.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ApplySlipSlotEffect>(), 3, GetIntent("Slip"), Slots.Front),
                            new Effect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 2, IntentType.Status_Ruptured, Slots.LeftRight)
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Wheel"),
                        animationTarget = Slots.Front,
                    };
                }
                return _drift;
            }
        }
        static Ability _rush;
        public static Ability Rush
        {
            get
            {
                if (_rush == null)
                {
                    _rush = new Ability()
                    {
                        name = "Rush",
                        description = "Move to Right. Inflict 3 Left and 2 Ruptured on the Opposing party member, then move to the Left or Right.",
                        rarity = 3,
                        effects = new Effect[]
                        {
                            new Effect(BasicEffects.GoRight, 1, IntentType.Swap_Right, Slots.Self),
                            new Effect(BasicEffects.GetVisuals("Salt/Shatter", false, Slots.Front), 1, null, Slots.Front),
                            new Effect(ScriptableObject.CreateInstance<ApplyLeftEffect>(), 3, (IntentType)846738, Slots.Front),
                            new Effect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 2, IntentType.Status_Ruptured, Slots.Front),
                            new Effect(SubActionEffect.Create(new Effect[] { new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, null, Slots.Self) }), 1, IntentType.Swap_Sides, Slots.Self)
                        },
                        visuals = null,
                        animationTarget = Slots.Self,
                    };
                }
                return _rush;
            }
        }
        static Ability _check;
        public static Ability Check
        {
            get
            {
                if (_check == null)
                {
                    _check = new Ability()
                    {
                        name = "Check",
                        description = "If the Light phase is not green, shift the Light phase up by one.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(BasicEffects.GetVisuals("Salt/Notif", false, Slots.Self), 1, null, Slots.Self, ScriptableObject.CreateInstance<TrainCondition>()),
                            new Effect(ScriptableObject.CreateInstance<TrainEffect>(), 1, IntentType.Misc, Slots.Self, ScriptableObject.CreateInstance<TrainCondition>()),
                        },
                        visuals = null,
                        animationTarget = Slots.Self,
                    };
                }
                return _check;
            }
        }
        static Ability _back;
        public static Ability Back
        {
            get
            {
                if (_back == null)
                {
                    _back = new Ability()
                    {
                        name = "Back Up",
                        description = "If the Light phase is not green, shift the Light phase down by one.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(BasicEffects.GetVisuals("Salt/Rain", false, Slots.Self), 1, null, Slots.Self, ScriptableObject.CreateInstance<TrainCondition>()),
                            new Effect(ScriptableObject.CreateInstance<TrainEffect>(), -1, IntentType.Misc, Slots.Self, ScriptableObject.CreateInstance<TrainCondition>()),
                        },
                        visuals = null,
                        animationTarget = Slots.Self,
                    };
                }
                return _back;
            }
        }
        static Ability _petrify;
        public static Ability Petrify
        {
            get
            {
                if (_petrify == null)
                {
                    _petrify = new Ability()
                    {
                        name = "Petrify",
                        description = "Deal a Painful amount of damage to the Opposing party member. \nMove Left, and change the Right enemy's health color to this enemy's health color.",
                        rarity = 8,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 5, IntentType.Damage_3_6, Slots.Front),
                            new Effect(BasicEffects.GoLeft, 1, IntentType.Swap_Left, Slots.Self),
                            new Effect(ScriptableObject.CreateInstance<ChangeTargetHealthColorCasterHealthColorEffect>(), 1, IntentType.Mana_Modify, Slots.SlotTarget(new int[]{1 }, true))
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Cannon"),
                        animationTarget = Slots.Front,
                    };
                }
                return _petrify;
            }
        }
        static Ability _partition;
        public static Ability Partition
        {
            get
            {
                if (_partition == null)
                {
                    _partition = new Ability()
                    {
                        name = "Partition",
                        description = "Deal a Painful amount of damage to the Opposing party member. \nMove Right, and change the Left enemy's health color to this enemy's health color.",
                        rarity = 8,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 5, IntentType.Damage_3_6, Slots.Front),
                            new Effect(BasicEffects.GoRight, 1, IntentType.Swap_Right, Slots.Self),
                            new Effect(ScriptableObject.CreateInstance<ChangeTargetHealthColorCasterHealthColorEffect>(), 1, IntentType.Mana_Modify, Slots.SlotTarget(new int[]{-1 }, true))
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Cannon"),
                        animationTarget = Slots.Front,
                    };
                }
                return _partition;
            }
        }
        static Ability _postular;
        public static Ability Postular
        {
            get
            {
                if (_postular == null)
                {
                    _postular = new Ability()
                    {
                        name = "Postular",
                        description = "Inflict 1 Pimple on all other enemies with this enemy's health color.",
                        rarity = 3,
                        priority = -20,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ApplyPimplesEffect>(), 1, GetIntent("Pimples"), TargettingBySameHealthColor.Create(true, false, true)),
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Pop"),
                        animationTarget = TargettingBySameHealthColor.Create(true, false, true),
                    };
                }
                return _postular;
            }
        }
        static Ability _politics;
        public static Ability Politics
        {
            get
            {
                if (_politics == null)
                {
                    _politics = new Ability()
                    {
                        name = "Please the Politics",
                        description = "Inflict 1 Pimple on every party member.",
                        rarity = 3,
                        priority = 6,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ApplyPimplesEffect>(), 1, GetIntent("Pimples"), Targetting.AllEnemy),
                        },
                        visuals = LoadedAssetsHandler.GetCharacterAbility("Insult_1_A").visuals,
                        animationTarget = Targetting.AllEnemy,
                    };
                }
                return _politics;
            }
        }
        static Ability _portrait;
        public static Ability Portrait
        {
            get
            {
                if (_portrait == null)
                {
                    _portrait = new Ability()
                    {
                        name = "Please the Portrait",
                        description = "Inflict 2 Linked on all party members who used Blue pigment last turn.",
                        rarity = 5,
                        priority = 0,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ApplyLinkedEffect>(), 2, IntentType.Status_Linked, TargettingByUsedBlue.Create(false))
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Door"),
                        animationTarget = TargettingByUsedBlue.Create(false),
                    };
                }
                return _portrait;
            }
        }
        static Ability _point;
        public static Ability Point
        {
            get
            {
                if (_point == null)
                {
                    _point = new Ability()
                    {
                        name = "Please the Point",
                        description = "Apply 8 Shield to the Left and Right enemy positions. Move to the Left or Right.",
                        rarity = 8,
                        priority = 0,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 8, IntentType.Field_Shield, Slots.Sides),
                            new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, IntentType.Swap_Sides, Slots.Self)
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Keyhole"),
                        animationTarget = Slots.Self,
                    };
                }
                return _point;
            }
        }
        static Ability _plight;
        public static Ability Plight
        {
            get
            {
                if (_plight == null)
                {
                    _plight = new Ability()
                    {
                        name = "Please the Plight",
                        description = "Randomize all non-Purple pigment in the pigment tray into Purple. Randomize all Purple pigment into a random other color.",
                        rarity = 3,
                        priority = 0,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<RandomizeAllPurpleAndNonPurpleEffect>(), 1, IntentType.Mana_Randomize, Slots.Self)
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Shatter"),
                        animationTarget = Slots.Self,
                    };
                }
                return _plight;
            }
        }
        static Ability _pledge;
        public static Ability Pledge
        {
            get
            {
                if (_pledge == null)
                {
                    _pledge = new Ability()
                    {
                        name = "Please the Pledge",
                        description = "Apply 3 Haste to this enemy.",
                        rarity = 3,
                        priority = -3,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ApplyHasteEffect>(), 3, GetIntent("Haste"), Slots.Self)
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Cube"),
                        animationTarget = Slots.Self,
                    };
                }
                return _pledge;
            }
        }
        static Ability _temper;
        public static Ability Temper
        {
            get
            {
                if (_temper == null)
                {
                    ChangeMaxHealthEffect add = ScriptableObject.CreateInstance<ChangeMaxHealthEffect>();
                    add._increase = true;
                    _temper = new Ability()
                    {
                        name = "Temper the Glass",
                        description = "Randomize this enemy's health color. Increase this enemy's maximum health by 10 and heal it.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<RandomizeTargetHealthColorsNotSameEffect>(), 1, IntentType.Mana_Modify, Slots.Self),
                            new Effect(add, 10, IntentType.Other_MaxHealth, Slots.Self),
                            new Effect(ScriptableObject.CreateInstance<HealEffect>(), 10, IntentType.Heal_5_10, Slots.Self)
                            
                        },
                        visuals = LoadedAssetsHandler.GetCharacterAbility("Absolve_1_A").visuals,
                        animationTarget = Slots.Self,
                    };
                }
                return _temper;
            }
        }
    }
    public class TrainEffect : EffectSO
    {
        public static UnitStoredValueNames Value => (UnitStoredValueNames)3709472;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            int yeah = caster.GetStoredValue(Value);
            yeah += entryVariable;
            int run = 0;
            while (yeah < 0 || yeah > 2)
            {
                if (yeah > 2) yeah -= 3;
                if (yeah <0) yeah += 3;
                run++;
                if (run > 1000)
                {
                    yeah = 0;
                    break;
                }
            }
            caster.SetStoredValue(Value, yeah);
            CombatManager.Instance.AddUIAction(new AnimationParameterSetterIntUIAction(caster.ID, caster.IsUnitCharacter, "light", yeah));
            exitAmount = yeah;
            return true;
        }
    }
    public class AnimationParameterSetterIntUIAction : CombatAction
    {
        public int _id;

        public bool _isCharacter;

        public string _parameterName;

        public int _parameterValue;

        public AnimationParameterSetterIntUIAction(int id, bool isCharacter, string parameterName, int parameterValue)
        {
            _id = id;
            _isCharacter = isCharacter;
            _parameterName = parameterName;
            _parameterValue = parameterValue;
        }

        public override IEnumerator Execute(CombatStats stats)
        {
            if (_isCharacter)
            {
                stats.combatUI.TrySetCharacterAnimatorParameterInt(_id, _parameterName, _parameterValue);
            }
            else
            {
                stats.combatUI.TrySetEnemyAnimatorParameterInt(_id, _parameterName, _parameterValue);
            }

            yield break;
        }
    }
    public static class TrainEXT
    {
        public static void TrySetCharacterAnimatorParameterInt(this CombatVisualizationController self, int id, string parameterName, int parameter)
        {
            if (self._charactersInCombat.TryGetValue(id, out var value))
            {
                self._characterZone._characters[value.FieldID].FieldEntity.CH_TrySetAnimatorParameterInt(parameterName, parameter);
            }
        }
        public static void TrySetEnemyAnimatorParameterInt(this CombatVisualizationController self, int id, string parameterName, int parameter)
        {
            if (self._enemiesInCombat.TryGetValue(id, out var value))
            {
                self._enemyZone._enemies[value.FieldID].FieldEntity.EN_TrySetAnimatorParameterInt(parameterName, parameter);
            }
        }

        public static void CH_TrySetAnimatorParameterInt(this CharacterInFieldLayout self, string parameterName, int parameter)
        {
            try
            {
                self._animator.SetInteger(parameterName, parameter);
            }
            catch
            {
                Debug.LogError("failed set int parameter");
            }
            return;
            AnimatorControllerParameter[] parameters = self._animator.parameters;
            foreach (AnimatorControllerParameter animatorControllerParameter in parameters)
            {
                if (animatorControllerParameter.name == parameterName)
                {
                    if (animatorControllerParameter.type == AnimatorControllerParameterType.Int)
                    {
                        self._animator.SetInteger(parameterName, parameter);
                    }

                    break;
                }
            }
        }
        public static void EN_TrySetAnimatorParameterInt(this EnemyInFieldLayout self, string parameterName, int parameter)
        {
            //Debug.Log(self._animator);
            //Debug.Log(self._animator.parameters);
            try
            {
                if (self._animator == null)
                {
                    Debug.LogError("ANIMATOR IS NULL");
                    self._animator = self.gameObject.GetComponent<Animator>();
                }
                //self._animator.SetInteger(parameterName, parameter);
                //return;
            }
            catch
            {
                //Debug.LogError("failed set int parameter");
            }
            //return;
            
            AnimatorControllerParameter[] parameters = self._animator.parameters;
            //Debug.Log("parameter count " + parameters.Length);
            foreach (AnimatorControllerParameter animatorControllerParameter in parameters)
            {
                //Debug.Log("PARAMETER: " + animatorControllerParameter.name + " " + animatorControllerParameter.type.ToString());
                if (animatorControllerParameter.name == parameterName)
                {
                    if (animatorControllerParameter.type == AnimatorControllerParameterType.Int)
                    {
                        self._animator.SetInteger(parameterName, parameter);
                    }

                    break;
                }
            }
        }
    }
    public class TrainCondition : EffectConditionSO
    {
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            return caster.GetStoredValue(TrainEffect.Value) != 2;
        }
    }
    public class SecondTrainCondition : EffectConditionSO
    {
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            return caster.GetStoredValue(TrainEffect.Value) == 2;
        }
    }

    public class TrainTargetting : BaseCombatTargettingSO
    {
        public BaseCombatTargettingSO source = Slots.SlotTarget(new int[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 }, true);
        public static Targetting_ByUnit_Side side;
        public bool GetAll;
        public bool flipple;
        public static void Flip()
        {
            foreach (TrainTargetting t in Resources.FindObjectsOfTypeAll<TrainTargetting>()) t.flipple = !t.flipple;
        }
        public override bool AreTargetAllies
        {
            get
            {
                if (source == null)
                {
                    return false;
                }
                return flipple? !source.AreTargetAllies : source.AreTargetAllies;
            }
        }
        public override bool AreTargetSlots
        {
            get
            {
                if (source == null) return false;
                return source.AreTargetSlots;
            }
        }
        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            if (side == null)
            {
                side = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
                side.getAllUnitSlots = false;
            }
            bool found = false;
            bool getparty = false;
            if (isCasterCharacter)
            {
                foreach (CharacterCombat chara in CombatManager.Instance._stats.CharactersOnField.Values)
                {
                    if (chara.SlotID == casterSlotID)
                    {
                        getparty = chara.GetStoredValue(TrainHandler.HitParty) > 0;
                        found = true;
                        //Debug.Log("FOUND US; found " + found + " || getparty " + getparty);
                        break;
                    }
                }
            }
            else
            {
                foreach (EnemyCombat enemy in CombatManager.Instance._stats.EnemiesOnField.Values)
                {
                    if (enemy.SlotID == casterSlotID)
                    {
                        getparty = enemy.GetStoredValue(TrainHandler.HitParty) > 0;
                        found = true;
//Debug.Log("FOUND US; found " + found + " || getparty " + getparty);
                        break;
                    }
                }
            }
            if (!found) return new TargetSlotInfo[0];
            if (GetAll)
            {
                if (getparty == isCasterCharacter)
                {
                    //Debug.Log("self");
                    source = Slots.SlotTarget(new int[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 }, true);
                    flipple = false;
                    return source.GetTargets(slots, casterSlotID, isCasterCharacter);
                }
                else
                {
                    //Debug.Log("front");
                    source = Slots.SlotTarget(new int[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 }, false);
                    flipple = false;
                    return source.GetTargets(slots, casterSlotID, isCasterCharacter);
                }
                //Debug.Log("all");
                source = side;
                side.getAllies = getparty == isCasterCharacter;
                return source.GetTargets(slots, casterSlotID, isCasterCharacter);
            }
            else
            {
                if (getparty == isCasterCharacter)
                {
                    //Debug.Log("self");
                    source = Slots.Self;
                    flipple = false;
                    return Slots.Self.GetTargets(slots, casterSlotID, isCasterCharacter);
                }
                else
                {
                    //Debug.Log("front");
                    source = Slots.Front;
                    flipple = false;
                    return Slots.Front.GetTargets(slots, casterSlotID, isCasterCharacter);
                }
            }
        }
        public static TrainTargetting Create(bool GetAll)
        {
            TrainTargetting ret = ScriptableObject.CreateInstance<TrainTargetting>();
            ret.GetAll = GetAll;
            return ret;
        }
    }
    public class SigilEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = entryVariable;
            CombatManager.Instance.AddUIAction(new AnimationParameterSetterIntUIAction(caster.ID, caster.IsUnitCharacter, "color", entryVariable));
            return true;
        }
    }
    public static class PigmentUsedCollector
    {
        public static List<ManaColorSO> lastUsed;
        public static int ID;
        public static List<int> UsedBlue;
        public static void UseAbility(Action<CharacterCombat, int, FilledManaCost[]> orig, CharacterCombat self, int abilityID, FilledManaCost[] filledCost)
        {
            if (lastUsed == null)
                lastUsed = new List<ManaColorSO>();
            lastUsed.Clear();
            ID = self.ID;
            foreach (FilledManaCost filledManaCost in filledCost)
                lastUsed.Add(filledManaCost.Mana);
            if (lastUsed.Contains(Pigments.Blue))
            {
                if (UsedBlue == null) UsedBlue = new List<int>();
                UsedBlue.Add(self.ID);
            }
            orig(self, abilityID, filledCost);
        }
        public static void FinalizeAbilityActions(Action<CharacterCombat> orig, CharacterCombat self)
        {
            orig(self);
            ID = -1;
            lastUsed.Clear();
        }
        public static void ClearBlueUsers()
        {
            if (UsedBlue == null) return;
            UsedBlue.Clear();
        }
        public static void Setup()
        {
            IDetour idetour1 = new Hook(typeof(CharacterCombat).GetMethod(nameof(CharacterCombat.UseAbility), ~BindingFlags.Default), typeof(PigmentUsedCollector).GetMethod(nameof(UseAbility), ~BindingFlags.Default));
            IDetour idetour2 = new Hook(typeof(CharacterCombat).GetMethod(nameof(CharacterCombat.FinalizeAbilityActions), ~BindingFlags.Default), typeof(PigmentUsedCollector).GetMethod(nameof(FinalizeAbilityActions), ~BindingFlags.Default));
        }
    }
    public class TargettingByUsedBlue : Targetting_ByUnit_Side
    {
        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            if (PigmentUsedCollector.UsedBlue == null) return new TargetSlotInfo[0];
            TargetSlotInfo[] source = base.GetTargets(slots, casterSlotID, isCasterCharacter);
            List<TargetSlotInfo> ret = new List<TargetSlotInfo>();
            foreach (TargetSlotInfo target in source)
            {
                if (target.HasUnit && PigmentUsedCollector.UsedBlue.Contains(target.Unit.ID)) ret.Add(target);
            }
            return ret.ToArray();
        }
        public static TargettingByUsedBlue Create(bool allies, bool allslots = false, bool ignorecast = false)
        {
            TargettingByUsedBlue ret = ScriptableObject.CreateInstance<TargettingByUsedBlue>();
            ret.getAllies = allies;
            ret.getAllUnitSlots = allslots;
            ret.ignoreCastSlot = ignorecast;
            return ret;
        }
    }
    public class TargettingBySameHealthColor : Targetting_ByUnit_Side
    {
        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            CombatSlot self = null;
            if (isCasterCharacter)
            {
                foreach (CombatSlot slot in slots.CharacterSlots) if (slot.SlotID == casterSlotID)
                    {
                        self = slot;
                        break;
                    }
            }
            else
            {
                foreach (CombatSlot slot in slots.EnemySlots) if (slot.SlotID == casterSlotID)
                    {
                        self = slot;
                        break;
                    }
            }
            if (self == null) return new TargetSlotInfo[0];
            if (!self.HasUnit) return new TargetSlotInfo[0];
            TargetSlotInfo[] source = base.GetTargets(slots, casterSlotID, isCasterCharacter);
            List<TargetSlotInfo> ret = new List<TargetSlotInfo>();
            foreach (TargetSlotInfo target in source)
            {
                if (target.HasUnit && target.Unit.HealthColor == self.Unit.HealthColor) ret.Add(target);
            }
            return ret.ToArray();
        }
        public static TargettingBySameHealthColor Create(bool allies, bool allslots = false, bool ignorecast = false)
        {
            TargettingBySameHealthColor ret = ScriptableObject.CreateInstance<TargettingBySameHealthColor>();
            ret.getAllies = allies;
            ret.getAllUnitSlots = allslots;
            ret.ignoreCastSlot = ignorecast;
            return ret;
        }
    }
    public class ChangeTargetHealthColorIgnorePureEffect : ChangeHealthColorEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            color = caster.HealthColor;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    bool pure = false;
                    BasePassiveAbilitySO yeah = null;
                    if (target.Unit is EnemyCombat enemy && enemy.TryGetPassiveAbility(PassiveAbilityTypes.Pure, out BasePassiveAbilitySO pas))
                    {
                        yeah = pas;
                    }
                    else if (target.Unit is CharacterCombat chara && chara.TryGetPassiveAbility(PassiveAbilityTypes.Pure, out BasePassiveAbilitySO pis))
                    {
                        yeah = pis;
                    }
                    if (target.Unit.TryRemovePassiveAbility(PassiveAbilityTypes.Pure)) pure = true;
                    if (base.PerformEffect(stats, caster, target.SelfArray(), areTargetSlots, entryVariable, out int exi)) exitAmount += exi;
                    if (pure)
                    {
                        if (yeah == null) target.Unit.AddPassiveAbility(Passives.Pure);
                        else target.Unit.AddPassiveAbility(yeah);
                    }
                }
            }
            return exitAmount > 0;
        }
    }
    public class ChangeTargetHealthColorCasterHealthColorEffect : ChangeHealthColorEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            color = caster.HealthColor;
            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
        }
    }
    public class RandomizeAllPurpleAndNonPurpleEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            ManaColorSO[] options = new ManaColorSO[] { Pigments.Red, Pigments.Blue, Pigments.Yellow };
            List<int> list = new List<int>();
            List<ManaColorSO> list2 = new List<ManaColorSO>();
            ManaBarSlot[] manaBarSlots = stats.MainManaBar.ManaBarSlots;
            foreach (ManaBarSlot manaBarSlot in manaBarSlots)
            {
                if (!manaBarSlot.IsEmpty && manaBarSlot.ManaColor == Pigments.Purple)
                {
                    int num = UnityEngine.Random.Range(0, options.Length);
                    manaBarSlot.SetMana(options[num]);
                    list.Add(manaBarSlot.SlotIndex);
                    list2.Add(options[num]);
                }
                else if (!manaBarSlot.IsEmpty && manaBarSlot.ManaColor != Pigments.Purple)
                {
                    manaBarSlot.SetMana(Pigments.Purple);
                    list.Add(manaBarSlot.SlotIndex);
                    list2.Add(Pigments.Purple);
                }
            }

            if (list.Count > 0)
            {
                CombatManager.Instance.AddUIAction(new ModifyManaSlotsUIAction(stats.MainManaBar.ID, list.ToArray(), list2.ToArray()));
            }
            exitAmount = list.Count;
            return exitAmount > 0;
        }
    }
    public class RandomizeTargetHealthColorsNotSameEffect : EffectSO
    {
        public List<ManaColorSO> options;
        bool ignorePure;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (options == null)
            {
                options = new List<ManaColorSO>() { Pigments.Red, Pigments.Blue, Pigments.Yellow, Pigments.Purple };
            }
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit && target.Unit.SlotID != caster.SlotID && target.Unit.HealthColor == caster.HealthColor)
                {
                    List<ManaColorSO> list = new List<ManaColorSO>(options);
                    if (list.Contains(target.Unit.HealthColor)) list.Remove(target.Unit.HealthColor);
                    bool pure = false;
                    BasePassiveAbilitySO yeah = null;
                    if (target.Unit is EnemyCombat enemy && enemy.TryGetPassiveAbility(PassiveAbilityTypes.Pure, out BasePassiveAbilitySO pas))
                    {
                        yeah = pas;
                    }
                    else if (target.Unit is CharacterCombat chara && chara.TryGetPassiveAbility(PassiveAbilityTypes.Pure, out BasePassiveAbilitySO pis))
                    {
                        yeah = pis;
                    }
                    if (ignorePure && target.Unit.TryRemovePassiveAbility(PassiveAbilityTypes.Pure)) pure = true;

                    if (target.Unit.ChangeHealthColor(list.GetRandom())) exitAmount++;
                    if (pure)
                    {
                        if (yeah == null) target.Unit.AddPassiveAbility(Passives.Pure);
                        else target.Unit.AddPassiveAbility(yeah);
                    }
                }
            }
            return exitAmount > 0;
        }
        public static RandomizeTargetHealthColorsNotSameEffect Create(bool ignorepure)
        {
            RandomizeTargetHealthColorsNotSameEffect ret = ScriptableObject.CreateInstance<RandomizeTargetHealthColorsNotSameEffect>();
            ret.ignorePure = ignorepure;
            ret.options = new List<ManaColorSO>() { Pigments.Red, Pigments.Blue, Pigments.Yellow, Pigments.Purple };
            return ret;
        }
    }
    public class SunColorEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (caster.HealthColor == Pigments.Red) exitAmount = 1;
            else if (caster.HealthColor == Pigments.Blue) exitAmount = 2;
            else if (caster.HealthColor == Pigments.Yellow) exitAmount = 3;
            else if (caster.HealthColor == Pigments.Purple) exitAmount = 4;
            else if (caster.HealthColor == Pigments.Gray) exitAmount = 5;
            CombatManager.Instance.AddUIAction(new AnimationParameterSetterIntUIAction(caster.ID, caster.IsUnitCharacter, "light", exitAmount));
            return exitAmount > 0;
        }
    }
    public class SunColorCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is BooleanReference && effector is IUnit unit)
            {
                CombatManager.Instance.AddPrioritySubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[] { new Effect(ScriptableObject.CreateInstance<SunColorEffect>(), 1, null, Slots.Self) }), unit));
                return false;
            }
            return true; 
        }
    }

    public class PowerByDamageCondition : EffectorConditionSO
    {
        public static Sprite sprite;
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (effector is IUnit unit && args is IntegerReference reference)
            {
                CombatStats stats = CombatManager.Instance._stats;
                if (sprite == null) sprite = ResourceLoader.LoadSprite("SweetTooth.png");
                CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(unit.ID, unit.IsUnitCharacter, "Sweet Tooth", sprite));
                StatusEffectInfoSO effectInfo;
                stats.statusEffectDataBase.TryGetValue((StatusEffectType)456789, out effectInfo);

                int amount = reference.value;
                IStatusEffect powerStatusEffect = new Power_StatusEffect(amount);


                IStatusEffector Seffector = unit as IStatusEffector;
                bool hasItAlready = false;
                int thisIndex = 999;
                for (int i = 0; i < Seffector.StatusEffects.Count; i++)
                {
                    if (Seffector.StatusEffects[i].EffectType == powerStatusEffect.EffectType)
                    {
                        thisIndex = i;
                        hasItAlready = true;
                    }
                }
                if (hasItAlready == true && powerStatusEffect.GetType() != Seffector.StatusEffects[thisIndex].GetType())
                {
                    ConstructorInfo[] constructors = Seffector.StatusEffects[thisIndex].GetType().GetConstructors();
                    foreach (ConstructorInfo constructor in constructors)
                    {
                        if (constructor.GetParameters().Length == 2)
                        {
                            powerStatusEffect = (IStatusEffect)Activator.CreateInstance(Seffector.StatusEffects[thisIndex].GetType(), amount, 0);
                        }
                    }
                }

                powerStatusEffect.SetEffectInformation(effectInfo);
                try
                {
                    unit.ApplyStatusEffect(powerStatusEffect, amount);
                }
                catch (Exception ex)
                {
                    CombatManager.Instance.AddUIAction(new ShowAttackInformationUIAction(unit.ID, unit.IsUnitCharacter, "so uh Power was attempted to be applied to this enemy (crystaline corpse eater hi) but it failed and wouldve softlocked normally. so erm. just pretend this didnt happen!"));
                    Debug.LogError(ex.ToString());
                    Debug.LogError(ex.Message + ex.StackTrace);
                }
            }
            return false;
        }
    }
    public class DamageScarIfMissEffect : ApplyScarsEffect
    {
        [SerializeField]
        public DeathType _deathType = DeathType.Basic;

        [SerializeField]
        public bool _usePreviousExitValue;

        [SerializeField]
        public bool _ignoreShield;

        [SerializeField]
        public bool _indirect;

        [SerializeField]
        public bool _returnKillAsSuccess;

        public int IntendedTargets = 2;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            if (_usePreviousExitValue)
            {
                entryVariable *= base.PreviousExitValue;
            }

            for (int i = targets.Length; i < IntendedTargets; i++)
            {
                base.PerformEffect(stats, caster, Slots.Self.GetTargets(stats.combatSlots, caster.SlotID, caster.IsUnitCharacter), Slots.Self.AreTargetSlots, 1, out int exi);
            }

            exitAmount = 0;
            bool flag = false;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (targetSlotInfo.HasUnit)
                {
                    int targetSlotOffset = (areTargetSlots ? (targetSlotInfo.SlotID - targetSlotInfo.Unit.SlotID) : (-1));
                    int amount = entryVariable;
                    DamageInfo damageInfo;
                    if (_indirect)
                    {
                        damageInfo = targetSlotInfo.Unit.Damage(amount, null, _deathType, targetSlotOffset, addHealthMana: false, directDamage: false, ignoresShield: true);
                    }
                    else
                    {
                        amount = caster.WillApplyDamage(amount, targetSlotInfo.Unit);
                        damageInfo = targetSlotInfo.Unit.Damage(amount, caster, _deathType, targetSlotOffset, addHealthMana: true, directDamage: true, _ignoreShield);
                    }

                    flag |= damageInfo.beenKilled;
                    exitAmount += damageInfo.damageAmount;
                }
                else
                {
                    base.PerformEffect(stats, caster, Slots.Self.GetTargets(stats.combatSlots, caster.SlotID, caster.IsUnitCharacter), Slots.Self.AreTargetSlots, 1, out int exi);
                }
            }

            if (!_indirect && exitAmount > 0)
            {
                caster.DidApplyDamage(exitAmount);
            }

            if (!_returnKillAsSuccess)
            {
                return exitAmount > 0;
            }

            return flag;
        }
        public static DamageScarIfMissEffect Create(int targets)
        {
            DamageScarIfMissEffect ret = ScriptableObject.CreateInstance<DamageScarIfMissEffect>();
            ret.IntendedTargets = targets;
            return ret;
        }
    }
    public class SpawnEnemyWithPowerEffect : SpawnEnemyInSlotFromEntryStringNameEffect
    {
        public int Power;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (!Check.EnemyExist(en)) return false;
            EnemySO enemy = LoadedAssetsHandler.GetEnemy(en);
            for (int num = targets.Length - 1; num >= 0; num--)
            {
                int preferredSlot = entryVariable + targets[num].SlotID;
                CombatManager.Instance.AddSubAction(new CrystalDecayHandler.SpawnEnemyWithPowerAction(enemy, preferredSlot, givesExperience, trySpawnAnywhereIfFail, _spawnType, Power));
            }

            exitAmount = targets.Length;
            return true;
        }
        public static SpawnEnemyWithPowerEffect Create(string enemy, int power, bool anyways = false)
        {
            SpawnEnemyWithPowerEffect ret = ScriptableObject.CreateInstance<SpawnEnemyWithPowerEffect>();
            ret.en = enemy;
            ret.Power = power;
            ret.trySpawnAnywhereIfFail = anyways;
            return ret;
        }
    }
    public static class CrystalDecayHandler
    {
        public static bool AddNewEnemyWithPower(this CombatStats self, EnemySO enemy, int slot, bool givesExperience, SpawnType spawnType, int power)
        {
            int firstEmptyEnemyFieldID = self.GetFirstEmptyEnemyFieldID();
            if (firstEmptyEnemyFieldID == -1)
            {
                return false;
            }

            int count = self.Enemies.Count;
            EnemyCombat enemyCombat = new EnemyCombat(count, firstEmptyEnemyFieldID, enemy, givesExperience);
            self.Enemies.Add(count, enemyCombat);
            self.AddEnemyToField(count, firstEmptyEnemyFieldID);
            self.combatSlots.AddEnemyToSlot(enemyCombat, slot);
            self.timeline.AddEnemyToTimeline(enemyCombat);
            CombatManager.Instance.AddUIAction(new EnemySpawnUIAction(enemyCombat.ID, spawnType));
            enemyCombat.ConnectPassives();
            enemyCombat.InitializationEnd();
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[] { new Effect(ScriptableObject.CreateInstance<ApplyPowerEffect>(), power, null, Slots.Self) }), enemyCombat));
            return true;
        }
        public class SpawnEnemyWithPowerAction : CombatAction
        {
            public int _preferredSlot;

            public EnemySO _enemy;

            public bool _givesExperience;

            public bool _trySpawnAnyways;

            public SpawnType _spawnType;
            public int power;

            public SpawnEnemyWithPowerAction(EnemySO enemy, int preferredSlot, bool givesExperience, bool trySpawnAnyways, SpawnType spawnType, int power)
            {
                _preferredSlot = preferredSlot;
                _givesExperience = givesExperience;
                _enemy = enemy;
                _trySpawnAnyways = trySpawnAnyways;
                _spawnType = spawnType;
                this.power = power;
            }

            public override IEnumerator Execute(CombatStats stats)
            {
                int num;
                if (_preferredSlot >= 0)
                {
                    num = stats.combatSlots.GetEnemyFitSlot(_preferredSlot, _enemy.size);
                    if (num == -1 && _trySpawnAnyways)
                    {
                        num = stats.GetRandomEnemySlot(_enemy.size);
                    }
                }
                else
                {
                    num = stats.GetRandomEnemySlot(_enemy.size);
                }

                if (num != -1)
                {
                    stats.AddNewEnemyWithPower(_enemy, num, _givesExperience, _spawnType, power);
                }

                yield return null;
            }
        }
    }
    public class ShowDecayInfoEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(caster.ID, caster.IsUnitCharacter, "Decay", Passives.Decay.passiveIcon));
            return true;
        }
    }
    public class CrystalDecayCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (effector is IUnit unit)
            {
                int amount = 0;
                foreach (IStatusEffect status in (unit as IStatusEffector).StatusEffects)
                {
                    if (status.EffectType == (StatusEffectType)456789) amount = status.StatusContent;
                }
                if (amount <= 0) return false;
                SpawnEnemyWithPowerEffect e = SpawnEnemyWithPowerEffect.Create("CandyStone_EN", amount, true);
                CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[] { new Effect(ScriptableObject.CreateInstance<ShowDecayInfoEffect>(), 1, null, Slots.Self), new Effect(e, 0, null, Slots.Self) }), unit));
                return false;
            }
            return true;
        }
    }
}
