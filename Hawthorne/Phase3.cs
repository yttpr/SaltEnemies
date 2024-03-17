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
    public static class Phase3
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

            SwitchUnStitchedAndInvertedOnPausePassiveAbility pauseKill = ScriptableObject.CreateInstance<SwitchUnStitchedAndInvertedOnPausePassiveAbility>();
            pauseKill._passiveName = "No Escape";
            pauseKill.passiveIcon = ResourceLoader.LoadSprite("ParanoidEscape", 32);
            pauseKill.type = (PassiveAbilityTypes)9878773;
            pauseKill._enemyDescription = "Pausing switches Inverted and Un-Stitched on party members and enemies.";
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


            Enemy phase3 = new Enemy()
            {
                name = "544515",
                health = 100,
                size = 1,
                entityID = (EntityIDs)544515,
                healthColor = Pigments.Yellow,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/superboss/Phase3_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
            };
            //phase1.prefab._gibs = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/superboss/Phase0_Gibs.prefab").GetComponent<ParticleSystem>();
            phase3.prefab.SetDefaultParams();
            phase3.combatSprite = ResourceLoader.LoadSprite("SupperIconB", 32);
            phase3.overworldAliveSprite = ResourceLoader.LoadSprite("SupperIcon", 32, new Vector2?(new Vector2(0.5f, 0.05f)));
            phase3.overworldDeadSprite = ResourceLoader.LoadSprite("SupperIcon", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            phase3.hurtSound = LoadedAssetsHandler.GetCharcater("Hans_CH").damageSound;
            phase3.deathSound = LoadedAssetsHandler.GetCharcater("Hans_CH").deathSound;
            phase3.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            phase3.passives = new BasePassiveAbilitySO[]
            {
                LoadedAssetsHandler.GetEnemy("Xiphactinus_EN").passiveAbilities[1], Passives.Skittish, Passives.Multiattack, 
                noTouch, hideHP, lookAtMe, pauseKill
            };


            AddPhase4Effect bossItUp = ScriptableObject.CreateInstance<AddPhase4Effect>();
            //bossItUp.enemy = LoadedAssetsHandler.GetEnemy("544514_EN");

            UnlockShitEffect lootItem = ScriptableObject.CreateInstance<UnlockShitEffect>();
            lootItem.AddThis(LootItems.LobItems[1]);

            phase3.exitEffects = new Effect[4]
            {
                new Effect(ScriptableObject.CreateInstance<FleeTargetEffect>(), 1, null, allAlly),
                new Effect(exhaust, 1, null, allEnemy),
                new Effect(bossItUp, 1, null, Slots.Self),
                new Effect(lootItem, 1, null, Slots.Self)
            };

            AddPassiveIfNotEffect spareIt = ScriptableObject.CreateInstance<AddPassiveIfNotEffect>();
            spareIt._passiveToAdd = fleeOnDie;
            SpawnEnemyAnywhereEffect fireFuck = ScriptableObject.CreateInstance<SpawnEnemyAnywhereEffect>();
            fireFuck.enemy = LoadedAssetsHandler.GetEnemy("HickoryFire_BOSS");
            SpawnEnemyAnywhereEffect purpleFuck = ScriptableObject.CreateInstance<SpawnEnemyAnywhereEffect>();
            purpleFuck.enemy = LoadedAssetsHandler.GetEnemy("JumbleGuts_Flummoxing_EN");
            SpawnEnemyAnywhereEffect motherFuck = ScriptableObject.CreateInstance<SpawnEnemyAnywhereEffect>();
            motherFuck.enemy = LoadedAssetsHandler.GetEnemy("ChoirBoy_EN");
            SpawnEnemyAnywhereEffect redFuck = ScriptableObject.CreateInstance<SpawnEnemyAnywhereEffect>();
            redFuck.enemy = LoadedAssetsHandler.GetEnemy("LostSheep_EN");
            phase3.enterEffects = new Effect[6]
            {
                new Effect((EffectSO) spareIt, 1, new IntentType?(), allEnemy),
                new Effect(ScriptableObject.CreateInstance<PixelateSpritesEffect>(), 1, null, Slots.Self),
                new Effect(ScriptableObject.CreateInstance<ChangeAbilityIconsEffect>(), 1, null, Slots.Self),
                new Effect(fireFuck, 1, new IntentType?(), Slots.Self),
                new Effect(purpleFuck, 1, new IntentType?(), Slots.Self),
                new Effect(motherFuck, 1, new IntentType?(), Slots.Self),
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

            Ability rupLeft = new Ability();
            rupLeft.name = "Ruptured Bleeding Left Effect";
            rupLeft.description = "Apply 2 Ruptured to the absolute center party member position, and apply 3 Bleeding to the absolute left and far left party member positions.";
            rupLeft.rarity = 5;
            rupLeft.effects = new Effect[1];
            rupLeft.effects[0] = new Effect(ScriptableObject.CreateInstance<RupturedBleedingLeftEffect>(), 5, IntentType.Misc, Slots.Self);
            rupLeft.visuals = null;
            rupLeft.animationTarget = Slots.Self;

            Ability rupRight = new Ability();
            rupRight.name = "Ruptured Bleeding Right Effect";
            rupRight.description = "Apply 2 Ruptured to the absolute center party member position, and apply 3 Bleeding to the absolute right and far right party member positions.";
            rupRight.rarity = 5;
            rupRight.effects = new Effect[1];
            rupRight.effects[0] = new Effect(ScriptableObject.CreateInstance<RupturedBleedingRightEffect>(), 5, IntentType.Misc, Slots.Self);
            rupRight.visuals = null;
            rupRight.animationTarget = Slots.Self;

            Ability DSDP = new Ability();
            DSDP.name = "Divine Sacrifice Divine Protection Effect";
            DSDP.description = "Apply 3 Divine Sacrifice to the absolute center party member position, and 3 Divine Sacrifice to the absolute far right and far left party member positions.";
            DSDP.rarity = 5;
            DSDP.effects = new Effect[1];
            DSDP.effects[0] = new Effect(ScriptableObject.CreateInstance<DPDSEffect>(), 5, IntentType.Misc, Slots.Self);
            DSDP.visuals = null;
            DSDP.animationTarget = Slots.Self;

            Ability sinAll = new Ability();
            sinAll.name = "Sin All Effect";
            sinAll.description = "Apply 1 Sin to all party members.";
            sinAll.rarity = 5;
            sinAll.effects = new Effect[1];
            sinAll.effects[0] = new Effect(ScriptableObject.CreateInstance<SinAllEffect>(), 5, IntentType.Misc, Slots.Self);
            sinAll.visuals = null;
            sinAll.animationTarget = Slots.Self;

            Ability oilLR = new Ability();
            oilLR.name = "Oil Left Right Effect";
            oilLR.description = "Inflict 3 Oil on the left and right party members.";
            oilLR.rarity = 5;
            oilLR.effects = new Effect[1];
            oilLR.effects[0] = new Effect(ScriptableObject.CreateInstance<OilLeftRightEffect>(), 5, IntentType.Misc, Slots.Self);
            oilLR.visuals = null;
            oilLR.animationTarget = Slots.Self;

            Ability oilFLR = new Ability();
            oilFLR.name = "Oil Front Left Right Effect";
            oilFLR.description = "Inflict 1 Oil on the front, left, and right party members.";
            oilFLR.rarity = 5;
            oilFLR.effects = new Effect[1];
            oilFLR.effects[0] = new Effect(ScriptableObject.CreateInstance<OilFrontLeftRightEffect>(), 5, IntentType.Misc, Slots.Self);
            oilFLR.visuals = null;
            oilFLR.animationTarget = Slots.Self;

            Ability fireFront = new Ability();
            fireFront.name = "Fire Front Effect";
            fireFront.description = "Inflict 1-3 Fire on the opposing party member position.";
            fireFront.rarity = 5;
            fireFront.effects = new Effect[1];
            fireFront.effects[0] = new Effect(ScriptableObject.CreateInstance<FireFrontEffect>(), 5, IntentType.Misc, Slots.Self);
            fireFront.visuals = null;
            fireFront.animationTarget = Slots.Self;

            Ability allergy = new Ability();
            allergy.name = "Allergy Far Leaky Random Effect";
            allergy.description = "Inflict 4 Paint Allergy to the far left and far right party members. Apply Leaky (1) as a passive to a random other enemy.";
            allergy.rarity = 5;
            allergy.effects = new Effect[1];
            allergy.effects[0] = new Effect(ScriptableObject.CreateInstance<AllergyFarLeakyRandomEffect>(), 5, IntentType.Misc, Slots.Self);
            allergy.visuals = null;
            allergy.animationTarget = Slots.Self;

            Ability wepp = new Ability();
            wepp.name = "Weep";
            wepp.description = "Produce 3 blue pigment.";
            wepp.rarity = 5;
            wepp.effects = new Effect[1];
            wepp.effects[0] = new Effect(ScriptableObject.CreateInstance<WeepEffect>(), 5, IntentType.Misc, Slots.Self);
            wepp.visuals = null;
            wepp.animationTarget = Slots.Self;

            Ability dust = new Ability();
            dust.name = "Bonus Attack";
            dust.description = "If the absolute center party member does not have Un-Stitched, apply 30 Inverted. Decrease their max health by 5. Remove all status effects other than Un-Stitched and Inverted. Do some other things also.";
            dust.rarity = 5;
            dust.effects = new Effect[1];
            dust.effects[0] = new Effect(ScriptableObject.CreateInstance<Phase3BonusAttackEffect>(), 5, IntentType.Misc, Slots.Self);
            dust.visuals = null;
            dust.animationTarget = Slots.Self;

            AddPassiveEffect leakIt = ScriptableObject.CreateInstance<AddPassiveEffect>();
            leakIt._passiveToAdd = Passives.Leaky;


            SpawnEnemyAnywhereEffect bitchass = ScriptableObject.CreateInstance<SpawnEnemyAnywhereEffect>();
            bitchass.enemy = LoadedAssetsHandler.GetEnemy("Spoggle_Ruminating_EN");

            phase3.loot = new EnemyLootItemProbability[2]
              {
                new EnemyLootItemProbability()
                {
                  isItemTreasure = true,
                  amount = 1,
                  probability = 100
                },
                new EnemyLootItemProbability()
                {
                    isItemTreasure = false,
                    amount = 1,
                    probability = 100
                }
              };


            phase3.passives[0] = UnityEngine.Object.Instantiate<BasePassiveAbilitySO>(phase3.passives[0]);
            phase3.passives[0]._passiveName = "Bonus Attack";
            phase3.passives[0]._enemyDescription = "544515 will perforn an extra ability \"Bonus Attack\" each turn.";
            ExtraAbilityInfo extraAbil = new ExtraAbilityInfo();
            extraAbil.ability = dust.EnemyAbility().ability;
            ((ExtraAttackPassiveAbility)phase3.passives[0])._extraAbility.ability = dust.EnemyAbility().ability;



            phase3.abilities = new Ability[] { rupLeft, rupRight, DSDP, sinAll, oilLR, oilFLR, fireFront, allergy, wepp };
            phase3.AddEnemy();
            added = true;
        }
    }
    public class HideFuckingEverythingPassiveAbility : BasePassiveAbilitySO
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
            HideHealthBarsPassive.hideEN_MaxHP += 1;
            HideHealthBarsPassive.hideCH_BarFill += 1;
            HideDamageValuesHook.HideDamage += 1;
            HideDamageValuesHook.HideHeal += 1;
            //Debug.Log("hide shit");
        }

        public override void OnPassiveDisconnected(IUnit unit)
        {
            HideHealthBarsPassive.hideEN_RealHP -= 1;
            HideHealthBarsPassive.hideEN_BarFill -= 1;
            HideHealthBarsPassive.inCombat -= 1;
            HideHealthBarsPassive.hideCH_RealHP -= 1;
            HideHealthBarsPassive.hideCH_MaxHP -= 1;
            HideHealthBarsPassive.hideEN_MaxHP -= 1;
            HideHealthBarsPassive.hideCH_BarFill -= 1;
            HideDamageValuesHook.HideDamage -= 1;
            HideDamageValuesHook.HideHeal -= 1;
        }
    }
}
