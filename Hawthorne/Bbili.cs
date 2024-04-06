using BrutalAPI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using UnityEngine;
using static Hawthorne.CustomIntentIconSystem;

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
}
