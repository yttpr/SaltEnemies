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
using Hawthorne.gay;
using THE_DEAD;

namespace Hawthorne.NewFolder
{
    public static class Phase2
    {
        public static bool added = false;
        public static void Add()
        {
            OnClickPassiveAbility noTouch = ScriptableObject.CreateInstance<OnClickPassiveAbility>();
            noTouch._passiveName = "Don't Touch Me";
            noTouch.passiveIcon = ResourceLoader.LoadSprite("DontTouchMe", 32);
            noTouch.type = (PassiveAbilityTypes)544522;
            noTouch._enemyDescription = "Upon being clicked, gain an additional ability on the timeline.";
            noTouch._characterDescription = "whoops";
            noTouch.doesPassiveTriggerInformationPanel = false;
            noTouch._triggerOn = new TriggerCalls[1] { (TriggerCalls)267850 };


            TimeAbominationPassiveAbility lookAtMe = ScriptableObject.CreateInstance<TimeAbominationPassiveAbility>();
            lookAtMe._passiveName = "Look At Me";
            lookAtMe.passiveIcon = ResourceLoader.LoadSprite("LookAtMe", 32);
            lookAtMe.type = (PassiveAbilityTypes)77696;
            lookAtMe._enemyDescription = "If this enemy is not hovered over for a period longer than 6 seconds, it gains another ability.";
            lookAtMe._characterDescription = "whoops";
            lookAtMe.doesPassiveTriggerInformationPanel = false;
            lookAtMe._triggerOn = new TriggerCalls[1] { (TriggerCalls)77696 };


            HideHealthEnemyCurrentCharacterAllPassiveAbility hideHP = ScriptableObject.CreateInstance<HideHealthEnemyCurrentCharacterAllPassiveAbility>();
            hideHP._passiveName = "Blinding";
            hideHP.passiveIcon = ResourceLoader.LoadSprite("HideShitIcon", 32);
            hideHP.type = (PassiveAbilityTypes)544517;
            hideHP._enemyDescription = "Hides the current health of enemies. Hide the current and maximum health of party members.";
            hideHP._characterDescription = "placeholder description";
            hideHP.doesPassiveTriggerInformationPanel = false;
            hideHP._triggerOn = new TriggerCalls[1] { TriggerCalls.Count };

            Targetting_ByUnit_Side allAlly = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            allAlly.getAllUnitSlots = false;
            allAlly.getAllies = true;

            RefreshAbilityUseEffect exhaust = ScriptableObject.CreateInstance<RefreshAbilityUseEffect>();
            exhaust._doesExhaustInstead = true;


            Targetting_ByUnit_Side allEnemy = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            allEnemy.getAllUnitSlots = false;
            allEnemy.getAllies = false;

            PerformEffectWithFalseSetterPassiveAbility fleeOnDie = ScriptableObject.CreateInstance<PerformEffectWithFalseSetterPassiveAbility>();
            fleeOnDie._passiveName = "Spared";
            fleeOnDie.passiveIcon = ResourceLoader.LoadSprite("SparedIcon", 32);
            fleeOnDie.type = (PassiveAbilityTypes)338375;
            fleeOnDie._enemyDescription = "";
            fleeOnDie._characterDescription = "Upon death, cure all status effects and set this unit at their maximum health for their level. If they are not the last character on the field, instantly flee, otherwise, end combat.";

            fleeOnDie.effects = ExtensionMethods.ToEffectInfoArray(new Effect[3]
            {
                new Effect((EffectSO) ScriptableObject.CreateInstance<RemoveAllStatusEffectsEffect>(), 1, new IntentType?(), Slots.Self),
                new Effect(ScriptableObject.CreateInstance<MaxHealthEffect>(), 1, new IntentType?(), Slots.Self),
                new Effect(ScriptableObject.CreateInstance<FleeOrEndCombatEffect>(), 1, new IntentType?(), Slots.SlotTarget(new int[8]{-4, -3, -2, -1, 1, 2, 3, 4 }, true))
            });
            fleeOnDie._triggerOn = new TriggerCalls[1]
            {
                TriggerCalls.CanDie
            };


            Enemy phase2 = new Enemy()
            {
                name = "544516",
                health = 85,
                size = 1,
                entityID = (EntityIDs)544516,
                healthColor = Pigments.Blue,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/superboss/Phase2_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
            };
            //phase1.prefab._gibs = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/superboss/Phase0_Gibs.prefab").GetComponent<ParticleSystem>();
            phase2.prefab.SetDefaultParams();
            phase2.combatSprite = ResourceLoader.LoadSprite("SupperIconB", 32);
            phase2.overworldAliveSprite = ResourceLoader.LoadSprite("SupperIcon", 32, new Vector2?(new Vector2(0.5f, 0.05f)));
            phase2.overworldDeadSprite = ResourceLoader.LoadSprite("SupperIcon", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            phase2.hurtSound = LoadedAssetsHandler.GetCharcater("Boyle_CH").damageSound;
            phase2.deathSound = LoadedAssetsHandler.GetCharcater("Boyle_CH").deathSound;
            phase2.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            phase2.passives = new BasePassiveAbilitySO[]
            {
                LoadedAssetsHandler.GetEnemy("Xiphactinus_EN").passiveAbilities[1], Passives.Slippery, Passives.Multiattack, noTouch, hideHP, lookAtMe, 
            };


            AddPhase3Effect bossItUp = ScriptableObject.CreateInstance<AddPhase3Effect>();
            //bossItUp.enemy = LoadedAssetsHandler.GetEnemy("544515_EN");

            UnlockShitEffect lootItem = ScriptableObject.CreateInstance<UnlockShitEffect>();
            lootItem.AddThis(LootItems.LobItems[0]);

            phase2.exitEffects = new Effect[4]
            {
                new Effect(ScriptableObject.CreateInstance<FleeTargetEffect>(), 1, null, allAlly),
                new Effect(exhaust, 1, null, allEnemy),
                new Effect(bossItUp, 1, null, Slots.Self),
                new Effect(lootItem, 1, null, Slots.Self)
            };
            
            AddPassiveIfNotEffect spareIt = ScriptableObject.CreateInstance<AddPassiveIfNotEffect>();
            spareIt._passiveToAdd = fleeOnDie;
            SpawnEnemyAnywhereEffect blueFuck = ScriptableObject.CreateInstance<SpawnEnemyAnywhereEffect>();
            blueFuck.enemy = LoadedAssetsHandler.GetEnemy("TheCrow_EN");
            SpawnEnemyAnywhereEffect redFuck = ScriptableObject.CreateInstance<SpawnEnemyAnywhereEffect>();
            redFuck.enemy = LoadedAssetsHandler.GetEnemy("LostSheep_EN");
            phase2.enterEffects = new Effect[4]
            {
                new Effect((EffectSO) spareIt, 1, new IntentType?(), allEnemy),
                new Effect(ScriptableObject.CreateInstance<PixelateSpritesEffect>(), 1, null, Slots.Self),
                new Effect(blueFuck, 1, new IntentType?(), Slots.Self),
                new Effect(ScriptableObject.CreateInstance<FindAndGiveClassicEffect>(), 1, null, Slots.Self),
            };


            phase2.loot = new EnemyLootItemProbability[1]
              {
                new EnemyLootItemProbability()
                {
                  isItemTreasure = false,
                  amount = 2,
                  probability = 100
                }
              };

            PreviousEffectCondition didntThat = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            didntThat.wasSuccessful = false;
            PreviousEffectCondition didThat = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            didThat.wasSuccessful = true;
            AnimationVisualsEffect homonDomin = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            homonDomin._visuals = LoadedAssetsHandler.GetEnemyAbility("Domination_A").visuals;
            homonDomin._animationTarget = Slots.Front;
            AnimationVisualsEffect talons = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            talons._visuals = LoadedAssetsHandler.GetEnemyAbility("Talons_A").visuals;
            talons._animationTarget = Slots.Front;

            CasterStoredValueChangeEffect infestationUp = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
            infestationUp._minimumValue = 0;
            infestationUp._increase = true;
            infestationUp._valueName = UnitStoredValueNames.InfestationPA;

            SwapToOneSideEffect goLeft = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            goLeft._swapRight = false;
            SwapToOneSideEffect goRight = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            goRight._swapRight = true;

            Ability hitRight = new Ability();
            hitRight.name = "Throttle Rightwards";
            hitRight.description = "Deal a painful amount of damage to the opposing party member. Apply 2 Gutted to the left party member. Move right.";
            hitRight.rarity = 10;
            hitRight.effects = new Effect[3];
            hitRight.effects[0] = new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 5, IntentType.Damage_3_6, Slots.Front);
            hitRight.effects[1] = new Effect(ScriptableObject.CreateInstance<ApplyGuttedEffect>(), 2, (IntentType)50336, Slots.Left);
            hitRight.effects[2] = new Effect(goRight, 1, IntentType.Swap_Right, Slots.Self);
            hitRight.visuals = LoadedAssetsHandler.GetCharacterAbility("Clobber_1_A").visuals;
            hitRight.animationTarget = Slots.Front;

            AddPassiveEffect leakIt = ScriptableObject.CreateInstance<AddPassiveEffect>();
            leakIt._passiveToAdd = Passives.Leaky;


            SpawnEnemyAnywhereEffect bitchass = ScriptableObject.CreateInstance<SpawnEnemyAnywhereEffect>();
            bitchass.enemy = LoadedAssetsHandler.GetEnemy("Spoggle_Ruminating_EN");

            Ability hitLeft = new Ability();
            hitLeft.name = "Choke Leftwards";
            hitLeft.description = "Deal a painful amount of damage to the opposing party member. Apply 4 Gutted to the right party member. Move left.";
            hitLeft.rarity = 5;
            hitLeft.effects = new Effect[3];
            hitLeft.effects[0] = new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 5, IntentType.Damage_3_6, Slots.Front);
            hitLeft.effects[1] = new Effect(ScriptableObject.CreateInstance<ApplyGuttedEffect>(), 4, (IntentType)50336, Slots.Right);
            hitLeft.effects[2] = new Effect(goLeft, 1, IntentType.Swap_Left, Slots.Self);
            hitLeft.visuals = LoadedAssetsHandler.GetCharacterAbility("Clobber_1_A").visuals;
            hitLeft.animationTarget = Slots.Front;

            Ability grudge = new Ability();
            grudge.name = "The Grudge of a Lifetime";
            grudge.description = "Curse the opposing party member. Inflict 10 Oil Slicked on the opposing party member.";
            grudge.rarity = 3;
            grudge.effects = new Effect[2];
            grudge.effects[0] = new Effect(ScriptableObject.CreateInstance<ApplyCursedEffect>(), 1, IntentType.Status_Cursed, Slots.Front);
            grudge.effects[1] = new Effect(ScriptableObject.CreateInstance<ApplyOilSlickedEffect>(), 10, IntentType.Status_OilSlicked, Slots.Front);
            grudge.visuals = LoadedAssetsHandler.GetEnemy("UnfinishedHeir_BOSS").abilities[2].ability.visuals;
            grudge.animationTarget = Slots.Front;

            AttackVisualsSO coinFlip = ScriptableObject.CreateInstance<AttackVisualsSO>();
            coinFlip.audioReference = "event:/Combat/Attack/G1/ATK_FingerGuns";
            coinFlip.animation = SaltEnemies.assetBundle.LoadAsset<AnimationClip>("Assets/Blunder/CoinFlipHeadAnim.anim");
            coinFlip.isAnimationFullScreen = true;

            Ability dust = new Ability();
            dust.name = "Twist Your Spine";
            dust.description = "If the left and right party members have Un-Stitched, remove it from them. Otherwise, apply Un-Stitched to them. Spawn one Lost Sheep. Apply 3-4 Left to self.";
            dust.rarity = 7;
            dust.effects = new Effect[4];
            dust.effects[0] = new Effect(ScriptableObject.CreateInstance<ApplyOrRemoveUnStitchedEffect>(), 2, (IntentType)846748, Slots.LeftRight);
            dust.effects[1] = new Effect(redFuck, 1, IntentType.Other_Spawn, Slots.Self);
            dust.effects[2] = new Effect(ScriptableObject.CreateInstance<ApplyLeftEffect>(), 3, (IntentType)846738, Slots.Self);
            dust.effects[3] = new Effect(ScriptableObject.CreateInstance<ApplyLeftEffect>(), 1, (IntentType)846738, Slots.Self, Conditions.Chance(50));
            dust.visuals = LoadedAssetsHandler.GetEnemyAbility("MinorKey_A").visuals;
            //dust.visuals = coinFlip;
            dust.animationTarget = Slots.LeftRight;
            //dust.animationTarget = Slots.Self;

            Ability trade = new Ability();
            trade.name = "Trade Bones";
            trade.description = "Apply 4 Scars to the left party member. Apply 4 Anesthetics to the right party member.";
            trade.rarity = 3;
            trade.effects = new Effect[2];
            trade.effects[0] = new Effect(ScriptableObject.CreateInstance<ApplyScarsEffect>(), 4, IntentType.Status_Scars, Slots.Left);
            trade.effects[1] = new Effect(ScriptableObject.CreateInstance<ApplyAnestheticsEffect>(), 4, (IntentType)987898, Slots.Right);
            trade.visuals = LoadedAssetsHandler.GetEnemyAbility("MinorKey_A").visuals;
            trade.animationTarget = Slots.LeftRight;

            RemoveStatusEffectEffect gutGone = ScriptableObject.CreateInstance<RemoveStatusEffectEffect>();
            gutGone._statusToRemove = StatusEffectType.Gutted;

            Ability reap = new Ability();
            reap.name = "Disembowel";
            reap.description = "Remove all Gutted from the opposing party member. Decrease their maximum health by the amount removed. Spawn a Ruminating Spoggle.";
            reap.rarity = 3;
            reap.effects = new Effect[3];
            reap.effects[0] = new Effect(gutGone, 1, (IntentType)50336, Slots.Front);
            reap.effects[1] = new Effect(ScriptableObject.CreateInstance<ChangeMaxHealthByPrevEffect>(), 1, IntentType.Other_MaxHealth, Slots.Front);
            reap.effects[2] = new Effect(bitchass, 1, IntentType.Other_Spawn, Slots.Self);
            reap.visuals = LoadedAssetsHandler.GetEnemyAbility("Talons_A").visuals;
            reap.animationTarget = Slots.Front;

            Ability distract = new Ability();
            distract.name = "Distraction";
            distract.description = "Move either left or right. Apply 1 Sin to the opposing party member.";
            distract.rarity = 3;
            distract.effects = new Effect[2];
            distract.effects[0] = new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, IntentType.Swap_Sides, Slots.Self);
            distract.effects[1] = new Effect(ScriptableObject.CreateInstance<ApplySinEffect>(), 1, (IntentType)846742, Slots.Front);
            distract.visuals = LoadedAssetsHandler.GetEnemyAbility("InhumanRoar_A").visuals;
            distract.animationTarget = Slots.Self;

            Ability torture = new Ability();
            torture.name = "Torture";
            torture.description = "Inflict 2 Fire and 1 Ruptured on the opposing party member. Move right.";
            torture.rarity = 3;
            torture.effects = new Effect[3];
            torture.effects[0] = new Effect(ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), 1, IntentType.Field_Fire, Slots.Front);
            torture.effects[1] = new Effect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 1, IntentType.Status_Ruptured, Slots.Front);
            torture.effects[2] = new Effect(goRight, 1, IntentType.Swap_Right, Slots.Self);
            torture.visuals = LoadedAssetsHandler.GetEnemyAbility("Domination_A").visuals;
            torture.animationTarget = Slots.Front;

            
            phase2.passives[0] = UnityEngine.Object.Instantiate<BasePassiveAbilitySO>(phase2.passives[0]);
            phase2.passives[0]._passiveName = "Twist Your Spine";
            phase2.passives[0]._enemyDescription = "544516 will perforn an extra ability \"Twist Your Spine\" each turn.";
            ExtraAbilityInfo extraAbil = new ExtraAbilityInfo();
            extraAbil.ability = dust.EnemyAbility().ability;
            ((ExtraAttackPassiveAbility)phase2.passives[0])._extraAbility.ability = dust.EnemyAbility().ability;



            phase2.abilities = new Ability[7] { hitRight, hitLeft, grudge, trade, reap, distract, torture };
            phase2.AddEnemy();
            added = true;
        }
    }
    public class HideHealthEnemyCurrentCharacterAllPassiveAbility : BasePassiveAbilitySO
    {
        [Header("Multiplier Data")]
        [SerializeField]
        private bool _temp = false;


        public override bool IsPassiveImmediate => true;

        public override bool DoesPassiveTrigger => true;




        public override void TriggerPassive(object sender, object args)
        {
            Debug.Log("NOTHING!!!!!!!!!!!!!!");

        }



        public override void OnPassiveConnected(IUnit unit)
        {
            //Debug.Log("hide shit passive");
            HideHealthBarsPassive.hideEN_RealHP += 1;
            HideHealthBarsPassive.hideEN_BarFill += 1;
            HideHealthBarsPassive.inCombat += 1;
            HideHealthBarsPassive.hideCH_RealHP += 1;
            HideHealthBarsPassive.hideCH_MaxHP += 1;
            //Debug.Log("hide shit");
        }

        public override void OnPassiveDisconnected(IUnit unit)
        {
            HideHealthBarsPassive.hideEN_RealHP -= 1;
            HideHealthBarsPassive.hideEN_BarFill -= 1;
            HideHealthBarsPassive.inCombat -= 1;
            HideHealthBarsPassive.hideCH_RealHP -= 1;
            HideHealthBarsPassive.hideCH_MaxHP -= 1;
        }
    }
    public class AddClassicEffect : EffectSO
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
            FragilePassiveAbility fragilePassiveAbility = ScriptableObject.CreateInstance<FragilePassiveAbility>();
            fragilePassiveAbility._passiveName = "Classic";
            fragilePassiveAbility.passiveIcon = ResourceLoader.LoadSprite("Classic", 32, null);
            fragilePassiveAbility.type = (PassiveAbilityTypes)8193;
            fragilePassiveAbility._enemyDescription = "All damage this enemy receives is reduced to 1.";
            fragilePassiveAbility._characterDescription = "Since, this is my code, it's okay to steal it, right?";
            fragilePassiveAbility.doesPassiveTriggerInformationPanel = false;
            fragilePassiveAbility._triggerOn = new TriggerCalls[]
            {
                TriggerCalls.OnBeingDamaged
            };

            AddPassiveEffect addClassic = ScriptableObject.CreateInstance<AddPassiveEffect>();
            addClassic._passiveToAdd = fragilePassiveAbility;

            for (int index1 = 0; index1 < targets.Length; ++index1)
            {
                if (targets[index1].HasUnit && targets[index1].Unit != caster)
                {
                    if (targets[index1].Unit.HealthColor == Pigments.Blue)
                    {
                        Effect PaleIt = new Effect(addClassic, 1, null, Slots.Self);
                        CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { PaleIt }), targets[index1].Unit));
                        exitAmount++;
                    }
                }
            }
            return exitAmount > 0;
        }
    }
    public class FragilePassiveAbility : BasePassiveAbilitySO
    {
        [Header("Multiplier Data")]
        [SerializeField]
        [Min(0.0f)]
        private int _modifyVal = 1;

        public override bool IsPassiveImmediate => true;

        public override bool DoesPassiveTrigger => true;

        public override void TriggerPassive(object sender, object args)
        {
            IUnit unit = sender as IUnit;
            if (args is DamageReceivedValueChangeException valueChangeException && valueChangeException.amount > 0 && args is DamageReceivedValueChangeException && !(args as DamageReceivedValueChangeException).Equals((object)null))
            {
                (args as DamageReceivedValueChangeException).AddModifier((IntValueModifier)new FragileValueModifier(this._modifyVal));
                CombatManager.Instance.AddUIAction((CombatAction)new ShowPassiveInformationUIAction((sender as IPassiveEffector).ID, (sender as IPassiveEffector).IsUnitCharacter, this.GetPassiveLocData().text, this.passiveIcon));
            }
            if (!(args is CanHealReference canHealReference))
                return;
            CombatManager.Instance.AddUIAction((CombatAction)new ShowPassiveInformationUIAction(unit.ID, unit.IsUnitCharacter, this.GetPassiveLocData().text, this.passiveIcon));
            canHealReference.value = false;
        }

        public override void OnPassiveConnected(IUnit unit)
        {
        }

        public override void OnPassiveDisconnected(IUnit unit)
        {
        }
    }
    public class FragileValueModifier : IntValueModifier
    {
        public readonly int FVAL;

        public FragileValueModifier(int exitVal)
          : base(999)
        {
            this.FVAL = exitVal;
        }

        public override int Modify(int value)
        {
            if (value > 0 && value >= this.FVAL)
                value = this.FVAL;
            return value;
        }
    }
    public class FindAndGiveClassicEffect : EffectSO
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
            
            AddClassicEffect addClassic = ScriptableObject.CreateInstance<AddClassicEffect>();

            Targetting_ByUnit_Side allAlly = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            allAlly.getAllUnitSlots = false;
            allAlly.getAllies = true;
            Effect PaleIt = new Effect(addClassic, 1, null, allAlly);
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { PaleIt }), caster));
            exitAmount++;
            return exitAmount > 0;
        }
    }
    public class ApplyOrRemoveUnStitchedEffect : EffectSO
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
            stats.statusEffectDataBase.TryGetValue((StatusEffectType)846748, out effectInfo);




            for (int index = 0; index < targets.Length; ++index)
            {
                if (targets[index].HasUnit)
                {
                    if (targets[index].Unit.ContainsStatusEffect((StatusEffectType)846748))
                    {
                        targets[index].Unit.TryRemoveStatusEffect((StatusEffectType)846748);
                    }
                    else
                    {
                        int amount = this._randomBetweenPrevious ? UnityEngine.Random.Range(this.PreviousExitValue, entryVariable + 1) : entryVariable;
                        UnStitched_StatusEffect statuseffect = new UnStitched_StatusEffect(amount);

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
                            effector.StatusEffects[thisIndex].TryAddContent(amount);
                            //effector.StatusEffectValuesChanged(effector.StatusEffects[thisIndex].EffectType, amount);
                            CombatManager.Instance.AddUIAction(new PlayStatusEffectPopupUIAction(targets[index].Unit.ID, targets[index].Unit.IsUnitCharacter, 0, effector.StatusEffects[thisIndex].EffectInfo, StatusFieldEffectPopUpType.Sign));
                            exitAmount += amount;
                        }
                        else if (targets[index].Unit.ApplyStatusEffect((IStatusEffect)statuseffect, 0))
                            ++exitAmount;
                    }
                }
            }

            return exitAmount > 0;
        }
    }
    public class ChangeMaxHealthByPrevEffect : EffectSO
    {
        [SerializeField]
        public bool _increase = false;

        [SerializeField]
        public bool _entryAsPercentage;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            entryVariable = base.PreviousExitValue;
            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i].HasUnit)
                {
                    int num = entryVariable;
                    if (_entryAsPercentage)
                    {
                        num = targets[i].Unit.CalculatePercentualAmount(num);
                    }
                    int newMaxHealth = targets[i].Unit.MaximumHealth + (_increase ? num : (-num));
                    if (targets[i].Unit.MaximizeHealth(newMaxHealth))
                    {
                        exitAmount += num;
                    }
                }
            }
            return exitAmount > 0;
        }
    }
    public class AddPassiveIfNotEffect : EffectSO
    {
        [Header("Passives To Swap Data")]
        [SerializeField]
        public BasePassiveAbilitySO _passiveToAdd;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (targetSlotInfo.HasUnit && !(targetSlotInfo.Unit.ContainsPassiveAbility(_passiveToAdd.type)))
                {
                    targetSlotInfo.Unit.AddPassiveAbility(_passiveToAdd);
                    exitAmount++;
                }
            }

            return exitAmount > 0;
        }
    }
}
