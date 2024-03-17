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
using Hawthorne;

namespace Hawthorne.NewFolder
{
    public static class Phase4
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
            lookAtMe.seconds = 3;
            lookAtMe.type = (PassiveAbilityTypes)77696;
            lookAtMe._enemyDescription = "If this enemy is not hovered over for a period longer than 3 seconds, it gains another ability.";
            lookAtMe._characterDescription = "whoops";
            lookAtMe.doesPassiveTriggerInformationPanel = false;
            lookAtMe._triggerOn = new TriggerCalls[1] { (TriggerCalls)77696 };

            MurderPeopleOnPausePassiveAbility pauseKill = ScriptableObject.CreateInstance<MurderPeopleOnPausePassiveAbility>();
            pauseKill._passiveName = "No Escape";
            pauseKill.passiveIcon = ResourceLoader.LoadSprite("ParanoidEscape", 32);
            pauseKill.type = (PassiveAbilityTypes)9878773;
            pauseKill._enemyDescription = "On Pause, apply 25 Pale to a random party member.";
            pauseKill._characterDescription = "whoops";
            pauseKill.doesPassiveTriggerInformationPanel = false;
            pauseKill._triggerOn = new TriggerCalls[1] { TriggerCalls.Count };


            HideFuckingEverythingPassiveAbility hideHP = ScriptableObject.CreateInstance<HideFuckingEverythingPassiveAbility>();
            hideHP._passiveName = "Blinding";
            hideHP.passiveIcon = ResourceLoader.LoadSprite("HideShitIcon", 32);
            hideHP.type = (PassiveAbilityTypes)544517;
            hideHP._enemyDescription = "Hides the health and max heath of enemies and party members. Hides the amount of damage or healing dealt to units.";
            hideHP._characterDescription = "placeholder description";
            hideHP.doesPassiveTriggerInformationPanel = false;
            hideHP._triggerOn = new TriggerCalls[1] { TriggerCalls.Count };

            IntegerSetterBasedOnStoredValuePassiveAbility abomination = ScriptableObject.CreateInstance<IntegerSetterBasedOnStoredValuePassiveAbility>();
            abomination._passiveName = "Abomination";
            abomination.passiveIcon = ResourceLoader.LoadSprite("AbominationIcon", 32);
            abomination.type = PassiveAbilityTypes.Abomination;
            abomination._enemyDescription = "This enemy increases its attacks per turn every 60 seconds.";
            abomination._characterDescription = "placeholder description";
            abomination.doesPassiveTriggerInformationPanel = false;
            abomination._triggerOn = new TriggerCalls[1] { TriggerCalls.AttacksPerTurn };

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


            Enemy phase4 = new Enemy()
            {
                name = "544514",
                health = 120,
                size = 1,
                entityID = (EntityIDs)544514,
                healthColor = Pigments.Purple,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/superboss/Phase4_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
            };
            //phase1.prefab._gibs = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/superboss/Phase0_Gibs.prefab").GetComponent<ParticleSystem>();
            phase4.prefab.SetDefaultParams();
            phase4.combatSprite = ResourceLoader.LoadSprite("SupperIconB", 32);
            phase4.overworldAliveSprite = ResourceLoader.LoadSprite("SupperIcon", 32, new Vector2?(new Vector2(0.5f, 0.05f)));
            phase4.overworldDeadSprite = ResourceLoader.LoadSprite("SupperIcon", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            phase4.hurtSound = LoadedAssetsHandler.GetCharcater("Mordrake_CH").damageSound;
            phase4.deathSound = LoadedAssetsHandler.GetCharcater("Mordrake_CH").deathSound;
            phase4.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            phase4.passives = new BasePassiveAbilitySO[]
            {
                LoadedAssetsHandler.GetEnemy("Xiphactinus_EN").passiveAbilities[1],
                noTouch, hideHP, lookAtMe, pauseKill, abomination
            };


            AddPhase5Effect bossItUp = ScriptableObject.CreateInstance<AddPhase5Effect>();
            //bossItUp.enemy = LoadedAssetsHandler.GetEnemy("544513_EN");


            UnlockShitEffect lootItem = ScriptableObject.CreateInstance<UnlockShitEffect>();
            lootItem.AddThis(LootItems.LobItems[2]);

            phase4.exitEffects = new Effect[4]
            {
                new Effect(ScriptableObject.CreateInstance<FleeTargetEffect>(), 1, null, allAlly),
                new Effect(exhaust, 1, null, allEnemy),
                new Effect(bossItUp, 1, null, Slots.Self),
                new Effect(lootItem, 1, null, Slots.Self),
            };

            AddPassiveIfNotEffect spareIt = ScriptableObject.CreateInstance<AddPassiveIfNotEffect>();
            spareIt._passiveToAdd = fleeOnDie;
            SpawnEnemyAnywhereEffect lobFuck = ScriptableObject.CreateInstance<SpawnEnemyAnywhereEffect>();
            lobFuck.enemy = LoadedAssetsHandler.GetEnemy("Freud_EN");
            SpawnEnemyAnywhereEffect flowerFuck = ScriptableObject.CreateInstance<SpawnEnemyAnywhereEffect>();
            flowerFuck.enemy = LoadedAssetsHandler.GetEnemy("A'Flower'_EN");
            SpawnEnemyAnywhereEffect motherFuck = ScriptableObject.CreateInstance<SpawnEnemyAnywhereEffect>();
            motherFuck.enemy = LoadedAssetsHandler.GetEnemy("ChoirBoy_EN");
            SpawnEnemyAnywhereEffect redFuck = ScriptableObject.CreateInstance<SpawnEnemyAnywhereEffect>();
            redFuck.enemy = LoadedAssetsHandler.GetEnemy("Psaltery_EN");
            phase4.enterEffects = new Effect[6]
            {
                new Effect((EffectSO) spareIt, 1, new IntentType?(), allEnemy),
                new Effect(ScriptableObject.CreateInstance<PixelateSpritesEffect>(), 1, null, Slots.Self),
                new Effect(ScriptableObject.CreateInstance<ChangeAbilityIconsEffect>(), 1, null, Slots.Self),
                new Effect(lobFuck, 1, new IntentType?(), Slots.Self),
                new Effect(flowerFuck, 1, new IntentType?(), Slots.Self),
                new Effect(redFuck, 1, new IntentType?(), Slots.Self),
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



            SwapToOneSideEffect goLeft = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            goLeft._swapRight = false;
            SwapToOneSideEffect goRight = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            goRight._swapRight = true;

            Ability move1 = new Ability();
            move1.name = "L_LeftEffect";
            move1.description = "*^%v8O";
            move1.rarity = 5;
            move1.effects = new Effect[1];
            move1.effects[0] = new Effect(ScriptableObject.CreateInstance<L_LeftEffect>(), 5, (IntentType)666888, Slots.Front);
            move1.visuals = null;
            move1.animationTarget = Slots.Self;

            Ability move2 = new Ability();
            move2.name = "L_RightEffect";
            move2.description = "OOWOIIWIO";
            move2.rarity = 5;
            move2.effects = new Effect[1];
            move2.effects[0] = new Effect(ScriptableObject.CreateInstance<L_RightEffect>(), 5, (IntentType)666888, Slots.Front);
            move2.visuals = null;
            move2.animationTarget = Slots.Self;

            Ability move3 = new Ability();
            move3.name = "M_LeftEffect";
            move3.description = "7685429w26";
            move3.rarity = 5;
            move3.effects = new Effect[1];
            move3.effects[0] = new Effect(ScriptableObject.CreateInstance<M_LeftEffect>(), 5, (IntentType)987892, Slots.Front);
            move3.visuals = null;
            move3.animationTarget = Slots.Self;

            Ability move4 = new Ability();
            move4.name = "M_RightEffect";
            move4.description = "&&&&&&&&&&&&&";
            move4.rarity = 5;
            move4.effects = new Effect[1];
            move4.effects[0] = new Effect(ScriptableObject.CreateInstance<M_RightEffect>(), 5, (IntentType)987892, Slots.Front);
            move4.visuals = null;
            move4.animationTarget = Slots.Self;

            Ability move5 = new Ability();
            move5.name = "R_LeftEffect";
            move5.description = "Igskyhfrrs.";
            move5.rarity = 5;
            move5.effects = new Effect[1];
            move5.effects[0] = new Effect(ScriptableObject.CreateInstance<R_LeftEffect>(), 5, IntentType.Status_Ruptured, Slots.Front);
            move5.visuals = null;
            move5.animationTarget = Slots.Self;

            Ability move6 = new Ability();
            move6.name = "R_RightEffect";
            move6.description = "[]{}{{[}{][}";
            move6.rarity = 5;
            move6.effects = new Effect[1];
            move6.effects[0] = new Effect(ScriptableObject.CreateInstance<R_RightEffect>(), 5, IntentType.Status_Ruptured, Slots.Front);
            move6.visuals = null;
            move6.animationTarget = Slots.Self;

            Ability move7 = new Ability();
            move7.name = "O_LeftEffect";
            move7.description = "wthatwhhha";
            move7.rarity = 5;
            move7.effects = new Effect[1];
            move7.effects[0] = new Effect(ScriptableObject.CreateInstance<O_LeftEffect>(), 5, IntentType.Field_Fire, Slots.Front);
            move7.visuals = null;
            move7.animationTarget = Slots.Self;

            Ability move8 = new Ability();
            move8.name = "O_RightEffect";
            move8.description = "Inflict 4 Paint Allergy to the far left and far right party members. Apply Leaky (1) as a passive to a random other enemy.";
            move8.rarity = 5;
            move8.effects = new Effect[1];
            move8.effects[0] = new Effect(ScriptableObject.CreateInstance<O_RightEffect>(), 5, IntentType.Field_Fire, Slots.Front);
            move8.visuals = null;
            move8.animationTarget = Slots.Self;

            Ability move9 = new Ability();
            move9.name = "G_LeftEffect";
            move9.description = ">iu^(9`";
            move9.rarity = 5;
            move9.effects = new Effect[1];
            move9.effects[0] = new Effect(ScriptableObject.CreateInstance<G_LeftEffect>(), 5, IntentType.Status_DivineProtection, Slots.Front);
            move9.visuals = null;
            move9.animationTarget = Slots.Self;

            Ability move10 = new Ability();
            move10.name = "G_RightEffect";
            move10.description = ">iu^(9`";
            move10.rarity = 5;
            move10.effects = new Effect[1];
            move10.effects[0] = new Effect(ScriptableObject.CreateInstance<G_RightEffect>(), 5, IntentType.Status_DivineProtection, Slots.Front);
            move10.visuals = null;
            move10.animationTarget = Slots.Self;

            Ability move11 = new Ability();
            move11.name = "P_LeftEffect";
            move11.description = "xxY7k^00|";
            move11.rarity = 5;
            move11.effects = new Effect[1];
            move11.effects[0] = new Effect(ScriptableObject.CreateInstance<P_LeftEffect>(), 5, IntentType.Damage_3_6, Slots.Front);
            move11.visuals = null;
            move11.animationTarget = Slots.Self;

            Ability move12 = new Ability();
            move12.name = "P_RightEffect";
            move12.description = "35U$EJR";
            move12.rarity = 5;
            move12.effects = new Effect[1];
            move12.effects[0] = new Effect(ScriptableObject.CreateInstance<P_RightEffect>(), 5, IntentType.Damage_3_6, Slots.Front);
            move12.visuals = null;
            move12.animationTarget = Slots.Self;

            Ability move13 = new Ability();
            move13.name = "S_AbilityEffect";
            move13.description = ":::::::::::::";
            move13.rarity = 5;
            move13.effects = new Effect[1];
            move13.effects[0] = new Effect(ScriptableObject.CreateInstance<S_AbilityEffect>(), 5, IntentType.Status_Frail, Slots.Front);
            move13.visuals = null;
            move13.animationTarget = Slots.Self;

            Ability dust = new Ability();
            dust.name = "B_AbilityEffect";
            dust.description = "why would you need this?";
            dust.rarity = 5;
            dust.effects = new Effect[1];
            dust.effects[0] = new Effect(ScriptableObject.CreateInstance<B_AbilityEffect>(), 5, IntentType.Other_Spawn, Slots.Self);
            dust.visuals = null;
            dust.animationTarget = Slots.Self;

            AddPassiveEffect leakIt = ScriptableObject.CreateInstance<AddPassiveEffect>();
            leakIt._passiveToAdd = Passives.Leaky;


            SpawnEnemyAnywhereEffect bitchass = ScriptableObject.CreateInstance<SpawnEnemyAnywhereEffect>();
            bitchass.enemy = LoadedAssetsHandler.GetEnemy("Spoggle_Ruminating_EN");

            phase4.loot = new EnemyLootItemProbability[2]
              {
                new EnemyLootItemProbability()
                {
                  isItemTreasure = true,
                  amount = 2,
                  probability = 100
                },
                new EnemyLootItemProbability()
                {
                    isItemTreasure = false,
                    amount = 1,
                    probability = 100
                }
              };


            phase4.passives[0] = UnityEngine.Object.Instantiate<BasePassiveAbilitySO>(phase4.passives[0]);
            phase4.passives[0]._passiveName = "B_AbilityEffect";
            phase4.passives[0]._enemyDescription = "544514 will perforn an extra ability \"B_AbilityEffect\" each turn.";
            ExtraAbilityInfo extraAbil = new ExtraAbilityInfo();
            extraAbil.ability = dust.EnemyAbility().ability;
            ((ExtraAttackPassiveAbility)phase4.passives[0])._extraAbility.ability = dust.EnemyAbility().ability;



            phase4.abilities = new Ability[] { move1, move2, move3, move4, move5, move6, move7, move8, move9, move10, move11, move12, move13 };
            phase4.AddEnemy();
            LoadedAssetsHandler.LoadedEnemies["544514_EN"].damageSound = "event:/Characters/NPC/Mordrake/CHR_NPC_Mordrake_Cracked_Dx";
            added = true;
        }
    }
}
