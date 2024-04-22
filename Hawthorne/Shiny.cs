using BrutalAPI;
using Hawthorne.NewFolder;
using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

namespace Hawthorne
{
    public static class Shiny
    {
        public static bool added = false;
        public static bool enteredCombat = false;
        public static void Add()
        {
            //Debug.Log("i");
            if (added) 
                return;
            
            PerformEffectPassiveAbility light = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            light._passiveName = "Lightweight";
            light.passiveIcon = ResourceLoader.LoadSprite("Lightweight", 32);
            light.type = (PassiveAbilityTypes)544530;
            light._enemyDescription = "Upon moving, 50% chance to move again.";
            light._characterDescription = "Upon moving, 50% chance to move again.";
            light.doesPassiveTriggerInformationPanel = true;
            light.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1] { new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, new IntentType?(), Slots.Self) });
            light._triggerOn = new TriggerCalls[1] { TriggerCalls.OnMoved };
            PercentageEffectorCondition light50P = ScriptableObject.CreateInstance<PercentageEffectorCondition>();
            light50P.triggerPercentage = 50;
            light.conditions = new EffectorConditionSO[1] { light50P };

            PerformEffectPassiveAbility revenge = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            revenge._passiveName = "Revenge";
            revenge.passiveIcon = ResourceLoader.LoadSprite("RetributionIcon", 32);
            revenge.type = (PassiveAbilityTypes)544512;
            revenge._enemyDescription = "On taking direct damage, give this enemy another ability.";
            revenge._characterDescription = "Upon moving, 50% chance to move again.";
            revenge.doesPassiveTriggerInformationPanel = true;
            revenge.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1] { new Effect(ScriptableObject.CreateInstance<AddTurnCasterToTimelineEffect>(), 1, new IntentType?(), Slots.Self) });
            revenge._triggerOn = new TriggerCalls[1] { TriggerCalls.OnDirectDamaged };

            PerformEffectPassiveAbility pocket = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            pocket._passiveName = "Pick-Pocket";
            pocket.passiveIcon = ResourceLoader.LoadSprite("PickPocketIcon", 32);
            pocket.type = (PassiveAbilityTypes)544412;
            pocket._enemyDescription = "On fleeing, steal 5 coins.";
            pocket._characterDescription = "Upon moving, 50% chance to move again.";
            pocket.doesPassiveTriggerInformationPanel = true;
            pocket.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1] { new Effect(ScriptableObject.CreateInstance<LosePlayerCurrencyEffect>(), 5, new IntentType?(), Slots.Self) });
            pocket._triggerOn = new TriggerCalls[1] { TriggerCalls.OnFleeting };

            Enemy birb = new Enemy()
            {
                name = "Coin Hunter",
                health = 65,
                size = 1,
                entityID = (EntityIDs)544512,
                healthColor = Pigments.Red,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/Blunder/Shiny_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
            };
            birb.prefab._gibs = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/Blunder/Shiny_Gibs.prefab").GetComponent<ParticleSystem>();
            birb.prefab.SetDefaultParams();
            //Debug.Log("prefabs");
            birb.combatSprite = ResourceLoader.LoadSprite("ShinyIcon.png", 32);
            birb.overworldAliveSprite = ResourceLoader.LoadSprite("ShinyIcon.png", 32, new Vector2?(new Vector2(0.5f, 0.05f)));
            birb.overworldDeadSprite = ResourceLoader.LoadSprite("ButterflyDead", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            birb.hurtSound = LoadedAssetsHandler.GetEnemy("Scrungie_EN").damageSound;
            birb.deathSound = LoadedAssetsHandler.GetEnemy("Scrungie_EN").deathSound;
            birb.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            birb.passives = new BasePassiveAbilitySO[]
            {
                Passives.Fleeting, light, revenge, Passives.Skittish, pocket
            };

            birb.passives[0] = UnityEngine.Object.Instantiate<BasePassiveAbilitySO>(birb.passives[0]);
            birb.passives[0]._passiveName = "Fleeting (2)";
            birb.passives[0]._enemyDescription = "This enemy will flee after 2 turns.";
            if (DoDebugs.MiscInfo) Debug.Log(birb.passives[0].GetType());
            ((FleetingPassiveAbility)birb.passives[0])._turnsBeforeFleeting = 2;


            UnlockShitEffect choco = ScriptableObject.CreateInstance<UnlockShitEffect>();
            choco.AddThis(Chocolate.Choco);

            birb.exitEffects = new Effect[1]
            {
                new Effect(choco, 1, new IntentType?(), Slots.Self)
            };
            birb.enterEffects = new Effect[]
            {
                new Effect(ScriptableObject.CreateInstance<AddTurnCasterToTimelineEffect>(), 1, null, Slots.Self)
            };

            Targetting_ByUnit_Side allAlly = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            allAlly.getAllUnitSlots = false;
            allAlly.getAllies = true;
            Targetting_ByUnit_Side allEnemy = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            allEnemy.getAllUnitSlots = false;
            allEnemy.getAllies = false;
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
            Ability firing = new Ability();
            firing.name = "Volatile Emission";
            firing.description = "Inflict 1 Fire on the Left, Right, and Opposing party member spaces.";
            firing.rarity = 5;
            firing.effects = new Effect[1];
            firing.effects[0] = new Effect(ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), 1, IntentType.Field_Fire, Slots.FrontLeftRight);
            firing.visuals = LoadedAssetsHandler.GetEnemyAbility("Flood_A").visuals;
            firing.animationTarget = Slots.FrontLeftRight;
            Ability wingbeat = new Ability();
            wingbeat.name = "Wingbeat";
            wingbeat.description = "Deal a painful amount of damage to the Left and Right party members. Apply Favor to one of them.";
            wingbeat.rarity = 5;
            wingbeat.effects = new Effect[2];
            wingbeat.effects[0] = new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 5, IntentType.Damage_3_6, Slots.LeftRight);
            wingbeat.effects[1] = new Effect(ScriptableObject.CreateInstance<ApplyFavorSingleEffect>(), 1, (IntentType)544512, Slots.LeftRight);
            wingbeat.visuals = LoadedAssetsHandler.GetEnemyAbility("Wriggle_A").visuals;
            wingbeat.animationTarget = Slots.LeftRight;
            Ability peck = new Ability();
            peck.name = "Peck";
            peck.description = "Flip a coin. If unsuccessful, instantly kill the Opposing party member.";
            peck.rarity = 5;
            peck.effects = new Effect[2];
            peck.effects[0] = new Effect(ScriptableObject.CreateInstance<CoinFlipDeathWithRerollEffect>(), 1, IntentType.Misc_Currency, Slots.Front);
            peck.effects[1] = new Effect(ScriptableObject.CreateInstance<ExitValueSetterEffect>(), 1, IntentType.Damage_Death, Slots.Front, didThat);
            peck.visuals = null;
            peck.animationTarget = Slots.Front;


            birb.loot = new EnemyLootItemProbability[2]
              {
                new EnemyLootItemProbability()
                {
                  isItemTreasure = true,
                  amount = 3,
                  probability = 100
                },
                new EnemyLootItemProbability()
                {
                    isItemTreasure = false,
                    amount = 3,
                    probability = 100
                }
              };


            birb.abilities = new Ability[3] { firing, wingbeat, peck };
            birb.AddEnemy();
            added = true;
        }

        public static void Hook()
        {
            IDetour ForOnTurnStartIDetour = (IDetour)new Hook((MethodBase)typeof(CombatStats).GetMethod("PlayerTurnStart", ~BindingFlags.Default), typeof(Shiny).GetMethod("ForOnTurnStart", ~BindingFlags.Default));
        }

        public static int chance()
        {
            int ret = 0;
            try
            {
                if (CombatManager.Instance._stats.TurnsPassed > 1) ret += 4;
                if (CombatManager.Instance._stats.TurnsPassed > 2) ret /= 2;
                if (CombatManager.Instance._stats.TurnsPassed > 4) ret /= 2;
                if (CombatManager.Instance._stats.TurnsPassed > 8) return 0;
            }
            catch
            {
                Debug.LogError("not in combat");
                return 0;
            }
            return Math.Max(0, ret);
        }
        public static void ForOnTurnStart(Action<CombatStats> orig, CombatStats self)
        {
            orig(self);
            //Debug.Log("entered");
            if (LetsYouIgnoreMissingEnemiesHook.IsDisabled("CoinHunter_EN")) return;
            if (UnityEngine.Random.Range(0, 100) < chance() && CombatManager.Instance._stats.PlayerCurrency >= 32 && !enteredCombat)
            {
                //Debug.Log("a");
                foreach (ItemInGameData itemData in CombatManager.Instance._informationHolder.Run.playerData._itemList)
                {
                    //Debug.Log("item");
                    if (itemData != (object)null)
                    {
                        if (itemData.Item != (object)null)
                        {
                            //Debug.Log("not null");
                            if (itemData.Item == LoadedAssetsHandler.GetWearable("ChocolateCoin_EW"))
                            {
                                enteredCombat = true;
                                return;
                            }
                        }
                    }
                }
                //Debug.Log("b");
                Targetting_ByUnit_Side allEnemy = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
                allEnemy.getAllies = false;
                allEnemy.getAllUnitSlots = true;
                Effect effort1 = new Effect(ScriptableObject.CreateInstance<SpawmShinyEffect>(), 1, null, Slots.SlotTarget(new int[9] {-4, -3, -2, -1, 0, 1, 2, 3, 4}, false));
                CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[] { effort1 }), CombatManager.Instance._stats.CharactersOnField.First().Value));
            }
        }
    }
    public class SpawmShinyEffect : EffectSO
    {
        public override bool PerformEffect(
          CombatStats stats,
          IUnit caster,
          TargetSlotInfo[] targets,
          bool areTargetSlots,
          int entryVariable,
          out int exitAmount)
        {
            exitAmount = 0;
            
            if (stats.BundleDifficulty == BundleDifficulty.Boss)
            {
                return false;
            }

            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    if (target.Unit.MaximumHealth >= 80)
                    {
                        return false;
                    }
                    if (target.Unit is EnemyCombat enemy)
                    {
                        if (enemy.Enemy == LoadedAssetsHandler.GetEnemy("Bronzo1_EN"))
                            return false;
                        if (enemy.Enemy == LoadedAssetsHandler.GetEnemy("Bronzo2_EN"))
                            return false;
                        if (enemy.Enemy == LoadedAssetsHandler.GetEnemy("Bronzo3_EN"))
                            return false;
                        if (enemy.Enemy == LoadedAssetsHandler.GetEnemy("Bronzo4_EN"))
                            return false;
                        if (enemy.Enemy == LoadedAssetsHandler.GetEnemy("Bronzo5_EN"))
                            return false;
                    }
                }
            }

                //Debug.Log("effect");
            foreach (TargetSlotInfo target in targets)
            {
                //Debug.Log("slot");
                if (!target.HasUnit)
                {
                    //Debug.Log("empty");
                    Shiny.Add();
                    CombatManager.Instance.AddSubAction(new SpawnEnemyAction(LoadedAssetsHandler.GetEnemy("CoinHunter_EN"), -1, false, trySpawnAnyways: false, SpawnType.Basic));
                    Shiny.enteredCombat = true;
                    return true;
                }
            }

            return false;
        }
    }
}
