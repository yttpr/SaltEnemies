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
    public static class Phase5
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

            GainFuckingAbilitiesPassiveAbility gainFuck = ScriptableObject.CreateInstance<GainFuckingAbilitiesPassiveAbility>();
            gainFuck._passiveName = "Gain Abilities Passive Ability";
            gainFuck.passiveIcon = ResourceLoader.LoadSprite("AbominationIcon", 32);
            gainFuck.type = (PassiveAbilityTypes)77698;
            gainFuck._enemyDescription = "This enemy gains an extra move every 30 seconds.";
            gainFuck._characterDescription = "placeholder description";
            gainFuck.doesPassiveTriggerInformationPanel = false;
            gainFuck._triggerOn = new TriggerCalls[1] { TriggerCalls.AttacksPerTurn };

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


            PostModernPassiveAbility postmodern = ScriptableObject.CreateInstance<PostModernPassiveAbility>();
            postmodern._passiveName = "Post-Modern";
            postmodern.passiveIcon = ResourceLoader.LoadSprite("PostModernIcon", 32);
            postmodern.type = (PassiveAbilityTypes)8193;
            postmodern._enemyDescription = "All damage this enemy receives is set to 999.";
            postmodern._characterDescription = "why two kay";
            postmodern.doesPassiveTriggerInformationPanel = false;
            postmodern._triggerOn = new TriggerCalls[]
            {
                TriggerCalls.OnBeingDamaged
            };

            PerformEffectPassiveAbility cleanIt = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            cleanIt._passiveName = "Passive";
            cleanIt.passiveIcon = ResourceLoader.LoadSprite("PassivePlaceholder", 32);
            cleanIt.type = (PassiveAbilityTypes)819111;
            cleanIt._enemyDescription = "Does something";
            cleanIt._characterDescription = "does Something";
            cleanIt.doesPassiveTriggerInformationPanel = false;
            cleanIt._triggerOn = new TriggerCalls[] { TriggerCalls.OnCombatEnd };
            cleanIt.effects = ExtensionMethods.ToEffectInfoArray(new Effect[]
            {
                new Effect(ScriptableObject.CreateInstance<UnMurderScreenResolutionEffect>(), 1, null, Slots.Self),
                new Effect(ScriptableObject.CreateInstance<CleanItUpEffect>(), 1, null, Slots.Self),
            });


            Enemy phase5 = new Enemy()
            {
                name = "544513",
                health = 20000,
                size = 1,
                entityID = (EntityIDs)544513,
                healthColor = Pigments.Gray,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/superboss/Phase5_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
            };
            //phase1.prefab._gibs = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/superboss/Phase0_Gibs.prefab").GetComponent<ParticleSystem>();
            phase5.prefab.SetDefaultParams();
            phase5.combatSprite = ResourceLoader.LoadSprite("SupperIconB", 32);
            phase5.overworldAliveSprite = ResourceLoader.LoadSprite("SupperIcon", 32, new Vector2?(new Vector2(0.5f, 0.05f)));
            phase5.overworldDeadSprite = ResourceLoader.LoadSprite("SupperIcon", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            phase5.hurtSound = LoadedAssetsHandler.GetCharcater("Mordrake_CH").damageSound;
            phase5.deathSound = LoadedAssetsHandler.GetCharcater("Mordrake_CH").deathSound;
            phase5.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            phase5.passives = new BasePassiveAbilitySO[]
            {
                noTouch, hideHP, lookAtMe, pauseKill, abomination, postmodern, gainFuck, cleanIt
            };





            UnlockShitEffect lootItem = ScriptableObject.CreateInstance<UnlockShitEffect>();
            lootItem.AddThis(LootItems.SnowGlobe);
            
            CombatEndEffect endIt = ScriptableObject.CreateInstance<CombatEndEffect>();
            endIt._ignoreAchievements = false;
            endIt._ignoreLoot = false;


            phase5.exitEffects = new Effect[]
            {
                new Effect(ScriptableObject.CreateInstance<FreezeGameEffect>(), 3, null, Slots.Self),
                new Effect(lootItem, 1, null, Slots.Self),
                new Effect(endIt, 1, null, Slots.Self),
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
            phase5.enterEffects = new Effect[]
            {
                new Effect((EffectSO) spareIt, 1, new IntentType?(), allEnemy),
                new Effect(ScriptableObject.CreateInstance<PixelateSpritesEffect>(), 1, null, Slots.Self),
                new Effect(ScriptableObject.CreateInstance<ChangeAbilityIconsEffect>(), 1, null, Slots.Self),
                new Effect(ScriptableObject.CreateInstance<SpawnMyRandomEnemiesAnywhereEffect>(), 1, new IntentType?(), Slots.Self),
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
            move1.name = "Move";
            move1.description = "Status effect or damage to everyone,,,";
            move1.rarity = 5;
            move1.effects = new Effect[1];
            move1.effects[0] = new Effect(ScriptableObject.CreateInstance<DoShitEffect>(), 5, IntentType.Misc, Slots.Self);
            move1.visuals = null;
            move1.animationTarget = Slots.Self;

            Ability move2 = new Ability();
            move2.name = "Ability";
            move2.description = "Character Ability (not longliver fuck you)";
            move2.rarity = 5;
            move2.effects = new Effect[1];
            move2.effects[0] = new Effect(ScriptableObject.CreateInstance<PerformRandomAbilityFromCharacterExceptCertainOnesEffect>(), 5, IntentType.Misc, Slots.Self);
            move2.visuals = null;
            move2.animationTarget = Slots.Self;

            Ability move3 = new Ability();
            move3.name = "Other";
            move3.description = "spawn an enemy";
            move3.rarity = 5;
            move3.effects = new Effect[1];
            move3.effects[0] = new Effect(ScriptableObject.CreateInstance<SpawnMyRandomEnemiesAnywhereEffect>(), 1, IntentType.Other_Spawn, Slots.Self);
            move3.visuals = null;
            move3.animationTarget = Slots.Self;

            Ability move4 = new Ability();
            move4.name = "Clear Blunder";
            move4.description = "Coin flip ability!";
            move4.rarity = 4; //4
            move4.effects = new Effect[1];
            move4.effects[0] = new Effect(ScriptableObject.CreateInstance<CoinFlipDeathEffect>(), 5, IntentType.Misc_Currency, Slots.Front);
            move4.visuals = null;
            move4.animationTarget = Slots.Self;

            Ability move5 = new Ability();
            move5.name = "R_LeftEffect";
            move5.description = "Inflict 3 Oil on the left and right party members.";
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


            /*

            phase5.passives[0] = UnityEngine.Object.Instantiate<BasePassiveAbilitySO>(phase5.passives[0]);
            phase5.passives[0]._passiveName = "B_AbilityEffect";
            phase5.passives[0]._enemyDescription = "544514 will perforn an extra ability \"B_AbilityEffect\" each turn.";
            ExtraAbilityInfo extraAbil = new ExtraAbilityInfo();
            extraAbil.ability = dust.EnemyAbility().ability;
            ((ExtraAttackPassiveAbility)phase5.passives[0])._extraAbility.ability = dust.EnemyAbility().ability;
            */
            phase5.loot = new EnemyLootItemProbability[2]
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
                    amount = 2,
                    probability = 100
                }
              };

            phase5.abilities = new Ability[] { move1, move2, move3, move4 };
            phase5.AddEnemy();
            added = true;
        }
    }
    public class PostModernPassiveAbility : BasePassiveAbilitySO
    {
        [Header("Multiplier Data")]
        [SerializeField]
        [Min(0.0f)]
        private int _modifyVal = 999;

        public bool DoScreenFuck = true;

        public override bool IsPassiveImmediate => true;

        public override bool DoesPassiveTrigger => true;

        public override void TriggerPassive(object sender, object args)
        {
            IUnit unit = sender as IUnit;
            if (args is DamageReceivedValueChangeException valueChangeException && valueChangeException.amount > 0 && args is DamageReceivedValueChangeException && !(args as DamageReceivedValueChangeException).Equals((object)null))
            {
                (args as DamageReceivedValueChangeException).AddModifier((IntValueModifier)new PostmodernValueModifier(this._modifyVal, DoScreenFuck));
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
    public class PostmodernValueModifier : IntValueModifier
    {
        public readonly int FVAL;
        public readonly bool Fuck;

        public PostmodernValueModifier(int exitVal, bool DoScreenFuck = true)
          : base(15)
        {
            this.FVAL = exitVal;
            Fuck = DoScreenFuck;
        }

        public override int Modify(int value)
        {
            if (value > 0 && value != this.FVAL)
            {
                value = this.FVAL;
                if (!Fuck) return value;
                Effect doIt = new Effect(ScriptableObject.CreateInstance<MurderScreenResolutionEffect>(), 1, null, Slots.Self, Conditions.Chance(33));
                CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { doIt }), CombatManager.Instance._stats.CharactersOnField.First().Value));

            }
            return value;
        }
    }
    public class FreezeGameEffect : EffectSO
    {


        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = entryVariable;
            entryVariable *= 1000;
            Thread.Sleep(entryVariable);

            return exitAmount > 0;
        }
    }
}
