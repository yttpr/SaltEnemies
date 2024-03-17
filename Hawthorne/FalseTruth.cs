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
using static UnityEngine.EventSystems.EventTrigger;
using Hawthorne.NewFolder;

namespace Hawthorne
{
    public static class FalseTruth
    {
        public static void Add()
        {
            PerformEffectPassiveAbility noTouch = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            noTouch._passiveName = "Don't Touch Me";
            noTouch.passiveIcon = ResourceLoader.LoadSprite("Lightweight", 32);
            noTouch.type = (PassiveAbilityTypes)544522;
            noTouch._enemyDescription = "Upon being clicked, gain an additional ability on the timeline.";
            noTouch._characterDescription = "whoops";
            noTouch.doesPassiveTriggerInformationPanel = true;
            noTouch.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1] { new Effect(ScriptableObject.CreateInstance<TurnOffOnClickTriggerEffect>(), 1, new IntentType?(), Slots.Self) });
            noTouch._triggerOn = new TriggerCalls[2] { TriggerCalls.OnDeath, TriggerCalls.OnCombatEnd };

            Enemy gone = new Enemy()
            {
                name = "Enigma",
                health = 13,
                size = 1,
                entityID = (EntityIDs)544532,
                healthColor = Pigments.Purple,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/PissShitFartCum/FalseTruth_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
            };
            gone.prefab._gibs = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/PissShitFartCum/FalseTruth_Gibs.prefab").GetComponent<ParticleSystem>();
            gone.prefab.SetDefaultParams();
            gone.combatSprite = ResourceLoader.LoadSprite("FalseTruthIconB", 32);
            gone.overworldAliveSprite = ResourceLoader.LoadSprite("FalseTruthIcon", 32, new Vector2?(new Vector2(0.5f, 0.05f)));
            gone.overworldDeadSprite = ResourceLoader.LoadSprite("FalseTruthDead", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            gone.hurtSound = LoadedAssetsHandler.GetEnemy("ChoirBoy_EN").damageSound;
            gone.deathSound = LoadedAssetsHandler.GetEnemy("ChoirBoy_EN").deathSound;
            gone.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            gone.passives = new BasePassiveAbilitySO[3]
            {
                Passives.Skittish,
                Passives.Unstable,
                LoadedAssetsHandler.GetEnemy("Xiphactinus_EN").passiveAbilities[1]
                //noTouch
            };

            
            gone.exitEffects = new Effect[1]
            {
                new Effect(ScriptableObject.CreateInstance<LockedBoxEffect>(), 1, new IntentType?(), Slots.Self, Conditions.Chance(4))
            };
            
            AnimationVisualsEffect talons = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            talons._animationTarget = Slots.Right;
            talons._visuals = LoadedAssetsHandler.GetEnemyAbility("Talons_A").visuals;
            AnimationVisualsEffect talons2 = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            talons2._animationTarget = Slots.Left;
            talons2._visuals = LoadedAssetsHandler.GetEnemyAbility("Talons_A").visuals;
            AnimationVisualsEffect headshot = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            headshot._animationTarget = Slots.Right;
            headshot._visuals = LoadedAssetsHandler.GetEnemy("TriggerFingers_BOSS").abilities[0].ability.visuals;
            AnimationVisualsEffect headshot2 = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            headshot2._animationTarget = Slots.Left;
            headshot2._visuals = LoadedAssetsHandler.GetEnemy("TriggerFingers_BOSS").abilities[0].ability.visuals;
            PreviousEffectCondition didntThat = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            didntThat.wasSuccessful = false;
            PreviousEffectCondition didThat = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            didThat.wasSuccessful = true;
            PreviousEffectCondition didnt2That = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            didnt2That.wasSuccessful = false;
            didnt2That.previousAmount = 2;
            Ability terrorize = new Ability();
            terrorize.name = "Terrorize";
            terrorize.description = "Deal a painful amount of damage to either the left or right party members.";
            terrorize.rarity = 3;
            terrorize.effects = new Effect[4];
            terrorize.effects[0] = new Effect(talons, 1, new IntentType?(), Slots.Right, Conditions.Chance(50));
            terrorize.effects[1] = new Effect(ScriptableObject.CreateInstance<DamageAlwaysTrueEffect>(), 6, IntentType.Damage_3_6, Slots.Right, didThat);
            terrorize.effects[2] = new Effect(talons2, 1, new IntentType?(), Slots.Left, didnt2That);
            terrorize.effects[3] = new Effect(ScriptableObject.CreateInstance<DamageAlwaysTrueEffect>(), 6, IntentType.Damage_3_6, Slots.Left, didThat);
            terrorize.visuals = null;
            terrorize.animationTarget = Slots.Self;

            Targetting_ByUnit_Side allAlly = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            allAlly.getAllUnitSlots = false;
            allAlly.getAllies = true;
            Ability paranoia = new Ability();
            paranoia.name = "Paranoia";
            paranoia.description = "Apply 6 Frail to either the left or right party members.";
            paranoia.rarity = 6;
            paranoia.effects = new Effect[4];
            paranoia.effects[0] = new Effect(headshot, 1, new IntentType?(), Slots.Right, Conditions.Chance(50));
            paranoia.effects[1] = new Effect(ScriptableObject.CreateInstance<ApplyFrailEffect>(), 6, IntentType.Status_Frail, Slots.Right, didThat);
            paranoia.effects[2] = new Effect(headshot2, 1, new IntentType?(), Slots.Left, didnt2That);
            paranoia.effects[3] = new Effect(ScriptableObject.CreateInstance<ApplyFrailEffect>(), 6, IntentType.Status_Frail, Slots.Left, didThat);
            paranoia.visuals = null;
            paranoia.animationTarget = Slots.Self;

            Ability paradox = new Ability();
            paradox.name = "Paradox";
            paradox.description = "If both the left and right party members are frailed, deal an agonizing amount of damage to the opposing party member. \nThis ability assumes the grid loops around.";
            paradox.rarity = 10;
            paradox.effects = new Effect[2];
            paradox.effects[0] = new Effect(ScriptableObject.CreateInstance<IsFrailEffect>(), 2, IntentType.Misc, Slots.SlotTarget(new int[4] {-4, -1, 1, 4}, false));
            paradox.effects[1] = new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 10, IntentType.Damage_7_10, Slots.Front, didThat);
            paradox.visuals = LoadedAssetsHandler.GetEnemy("TriggerFingers_BOSS").abilities[0].ability.visuals;
            paradox.animationTarget = Slots.Self;
            gone.passives[2] = UnityEngine.Object.Instantiate<BasePassiveAbilitySO>(gone.passives[2]);
            gone.passives[2]._passiveName = "Paradox";
            gone.passives[2]._enemyDescription = "False Truth will perforn an extra ability \"Paradox\" each turn.";
            ((ExtraAttackPassiveAbility)gone.passives[2])._extraAbility.ability = paradox.EnemyAbility().ability;

            gone.abilities = new Ability[2] { terrorize, paranoia };
            gone.AddEnemy();
        }
    }
    public class DamageAlwaysTrueEffect : EffectSO
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
        public bool _returnKillAsSuccess = false;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            if (_usePreviousExitValue)
            {
                entryVariable *= base.PreviousExitValue;
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
            }

            if (!_indirect && exitAmount > 0)
            {
                caster.DidApplyDamage(exitAmount);
            }

            if (!_returnKillAsSuccess)
            {
                return exitAmount > 0;
            }

            return true;
        }
    }
    public class IsFrailEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            int length = 0;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (targetSlotInfo.HasUnit)
                {
                    if (targetSlotInfo.Unit.ContainsStatusEffect(StatusEffectType.Frail))
                    {
                        exitAmount++;
                    }
                }
                length++;
            }
            return exitAmount >= length;
        }
    }
}
