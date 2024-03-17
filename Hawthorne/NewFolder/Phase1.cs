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
    public static class Phase1
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

            HideHealthEnemyCurrentPassiveAbility hideHP = ScriptableObject.CreateInstance<HideHealthEnemyCurrentPassiveAbility>();
            hideHP._passiveName = "Blinding";
            hideHP.passiveIcon = ResourceLoader.LoadSprite("HideShitIcon", 32);
            hideHP.type = (PassiveAbilityTypes)544517;
            hideHP._enemyDescription = "Hides the current health of enemies.";
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


            Enemy phase1 = new Enemy()
            {
                name = "544517",
                health = 60,
                size = 1,
                entityID = (EntityIDs)544517,
                healthColor = Pigments.Red,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/superboss/Phase1_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
            };
            //phase1.prefab._gibs = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/superboss/Phase0_Gibs.prefab").GetComponent<ParticleSystem>();
            phase1.prefab.SetDefaultParams();
            phase1.combatSprite = ResourceLoader.LoadSprite("SupperIconB", 32);
            phase1.overworldAliveSprite = ResourceLoader.LoadSprite("SupperIcon", 32, new Vector2?(new Vector2(0.5f, 0.05f)));
            phase1.overworldDeadSprite = ResourceLoader.LoadSprite("SupperIcon", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            phase1.hurtSound = LoadedAssetsHandler.GetCharcater("Nowak_CH").damageSound;
            phase1.deathSound = LoadedAssetsHandler.GetCharcater("Nowak_CH").deathSound;
            phase1.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            phase1.passives = new BasePassiveAbilitySO[6]
            {
                Passives.Skittish, Passives.Slippery, Passives.Masochism, Passives.Multiattack, noTouch, hideHP
            };

            AddPhase2Effect bossItUp = ScriptableObject.CreateInstance<AddPhase2Effect>();
            //bossItUp.enemy = LoadedAssetsHandler.GetEnemy("544516_EN");

            UnlockShitEffect gun6 = ScriptableObject.CreateInstance<UnlockShitEffect>();
            gun6._unlocks = LootItems.Bullets.ToArray();

            phase1.exitEffects = new Effect[4]
            {
                new Effect(ScriptableObject.CreateInstance<FleeTargetEffect>(), 1, null, allAlly),
                new Effect(exhaust, 1, null, allEnemy),
                new Effect(bossItUp, 1, null, Slots.Self),
                new Effect(gun6, 1, null, Slots.Self)
            };

            phase1.loot = new EnemyLootItemProbability[1]
              {
                new EnemyLootItemProbability()
                {
                  isItemTreasure = false,
                  amount = 1,
                  probability = 100
                }
              };

            AddPassiveIfNotEffect spareIt = ScriptableObject.CreateInstance<AddPassiveIfNotEffect>();
            spareIt._passiveToAdd = fleeOnDie;
            SpawnEnemyAnywhereEffect addBanana = ScriptableObject.CreateInstance<SpawnEnemyAnywhereEffect>();
            addBanana.enemy = LoadedAssetsHandler.GetEnemy("Bronzo_Bananas_Friendly_EN");
            SpawnEnemyAnywhereEffect greyFuck = ScriptableObject.CreateInstance<SpawnEnemyAnywhereEffect>();
            greyFuck.enemy = LoadedAssetsHandler.GetEnemy("RusticJumbleguts_EN");
            phase1.enterEffects = new Effect[3]
            {
                new Effect((EffectSO) spareIt, 1, new IntentType?(), allEnemy),
                new Effect(addBanana, 1, new IntentType?(), Slots.Self),
                new Effect(greyFuck, 1, new IntentType?(), Slots.Self),
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

            Ability healFront = new Ability();
            healFront.name = "Kiss of Death";
            healFront.description = "Heal the opposing party member 25 health.";
            healFront.rarity = 2;
            healFront.effects = new Effect[1];
            healFront.effects[0] = new Effect(ScriptableObject.CreateInstance<HealEffect>(), 25, IntentType.Heal_11_20, Slots.Front);
            healFront.visuals = LoadedAssetsHandler.GetEnemyAbility("Blush_A").visuals;
            healFront.animationTarget = Slots.Front;

            AddPassiveEffect leakIt = ScriptableObject.CreateInstance<AddPassiveEffect>();
            leakIt._passiveToAdd = Passives.Leaky;


            SpawnEnemyAnywhereEffect pixel = ScriptableObject.CreateInstance<SpawnEnemyAnywhereEffect>();
            pixel.enemy = LoadedAssetsHandler.GetEnemy("DeadPixel_EN");

            Ability punch = new Ability();
            punch.name = "Tongue and Cheeck";
            punch.description = "Deal a painful amount of damage to the opposing party member.";
            punch.rarity = 8;
            punch.effects = new Effect[1];
            punch.effects[0] = new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 5, IntentType.Damage_3_6, Slots.Front);
            punch.visuals = LoadedAssetsHandler.GetEnemyAbility("Chomp_A").visuals;
            punch.animationTarget = Slots.Front;

            Ability pixelize = new Ability();
            pixelize.name = "Behind Us";
            pixelize.description = "Spawn a Dead Pixel.";
            pixelize.rarity = 3;
            pixelize.effects = new Effect[1];
            pixelize.effects[0] = new Effect(pixel, 1, IntentType.Other_Spawn, Slots.Self);
            pixelize.visuals = LoadedAssetsHandler.GetEnemy("UnfinishedHeir_BOSS").abilities[2].ability.visuals;
            pixelize.animationTarget = Slots.Self;

            Ability dust = new Ability();
            dust.name = "Twist their Spine";
            dust.description = "Apply 2 Inverted and 1 Muted to the opposing party member.";
            dust.rarity = 7;
            dust.effects = new Effect[2];
            dust.effects[0] = new Effect(ScriptableObject.CreateInstance<ApplyInvertedEffect>(), 2, (IntentType)846749, Slots.Front);
            dust.effects[1] = new Effect(ScriptableObject.CreateInstance<ApplyMutedEffect>(), 1, (IntentType)846750, Slots.Front);
            dust.visuals = LoadedAssetsHandler.GetEnemyAbility("MinorKey_A").visuals;
            dust.animationTarget = Slots.Front;


            Ability trade = new Ability();
            trade.name = "Trade Flesh";
            trade.description = "Apply 2 Scars to the left party member. Apply 2 Anesthetics to the right party member.";
            trade.rarity = 4;
            trade.effects = new Effect[2];
            trade.effects[0] = new Effect(ScriptableObject.CreateInstance<ApplyScarsEffect>(), 2, IntentType.Status_Scars, Slots.Left);
            trade.effects[1] = new Effect(ScriptableObject.CreateInstance<ApplyAnestheticsEffect>(), 2, (IntentType)987898, Slots.Right);
            trade.visuals = LoadedAssetsHandler.GetEnemyAbility("MinorKey_A").visuals;
            trade.animationTarget = Slots.LeftRight;

            phase1.abilities = new Ability[] { healFront, punch, pixelize, dust, trade };
            phase1.AddEnemy();
            added = true;
        }
    }
    public class MaxHealthEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i].HasUnit)
                {
                    if (targets[i].Unit is CharacterCombat character)
                    {
                        targets[i].Unit.MaximizeHealth(character.Character.GetMaxHealth(character.Rank));
                        targets[i].Unit.SetHealthTo(character.Character.GetMaxHealth(character.Rank));
                    }
                }
            }

            return exitAmount > 0;
        }
    }
    public class FleeOrEndCombatEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i].HasUnit && targets[i].Unit != caster)
                {
                    caster.UnitWillFlee();
                    CombatManager.Instance.AddSubAction(new FleetingUnitAction(caster.ID, caster.IsUnitCharacter));
                    return false;
                }
            }

            HideHealthBarsPassive.inCombat = 0;
            HideHealthBarsPassive.hideCH_RealHP = 0;
            HideHealthBarsPassive.hideEN_RealHP = 0;
            HideHealthBarsPassive.hideCH_MaxHP = 0;
            HideHealthBarsPassive.hideEN_MaxHP = 0;
            HideHealthBarsPassive.hideCH_BarFill = 0;
            HideHealthBarsPassive.hideEN_BarFill = 0;
            HideDamageValuesHook.HideDamage = 0;
            HideDamageValuesHook.HideHeal = 0;
            PixelateSpritesHook.CH_PPU = 1;
            PixelateIconsHook.A_PPU = 1;
            SaltEnemies.inCombat = false;
            SaltEnemies.inCombatClicking = 0;
            if (RealScreen.isCrushed)
            {
                Screen.SetResolution(RealScreen.realWidth, RealScreen.realHeight, RealScreen.realIsFullscreen, RealScreen.realRefreshRate);
                RealScreen.isCrushed = false;
                RealScreen.isDoubleCrushed = false;
                RealScreen.isTripleCrushed = false;
            }
            stats.TriggerPrematureFinalization();
            return exitAmount > 0;
        }
    }
    public class HideHealthEnemyCurrentPassiveAbility : BasePassiveAbilitySO
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
            HideHealthBarsPassive.hideEN_RealHP += 1;
            HideHealthBarsPassive.hideEN_BarFill += 1;
            HideHealthBarsPassive.inCombat += 1;
        }

        public override void OnPassiveDisconnected(IUnit unit)
        {
            HideHealthBarsPassive.hideEN_RealHP -= 1;
            HideHealthBarsPassive.hideEN_BarFill -= 1;
            HideHealthBarsPassive.inCombat -= 1;
        }
    }
}
