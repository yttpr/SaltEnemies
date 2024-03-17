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


namespace Hawthorne
{
    public static class Crow
    {
        public static void Add()
        {
            new CustomIntentInfo("CrowCount", (IntentType)3753891, ResourceLoader.LoadSprite("counticon.png"), IntentType.Misc);
            new CustomIntentInfo("CrowWait", (IntentType)3759391, ResourceLoader.LoadSprite("waiticon.png"), IntentType.Misc);

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

            Enemy birb = new Enemy()
            {
                name = "The Crow",
                health = 28,
                size = 1,
                entityID = (EntityIDs)544524,
                healthColor = Pigments.Blue,
                priority = 0,
                prefab = SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/Senis3/Crow_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
            };
            birb.prefab._gibs = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/Senis3/Crow_Gibs.prefab").GetComponent<ParticleSystem>();
            birb.prefab.SetDefaultParams();
            if (DoDebugs.GenInfo) Debug.Log("prefabs");
            birb.combatSprite = ResourceLoader.LoadSprite("CrowIconB", 32);
            birb.overworldAliveSprite = ResourceLoader.LoadSprite("CrowIcon", 32, new Vector2?(new Vector2(0.5f, 0.05f)));
            birb.overworldDeadSprite = ResourceLoader.LoadSprite("CrowDead", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            birb.hurtSound = LoadedAssetsHandler.GetEnemy("Scrungie_EN").damageSound;
            birb.deathSound = LoadedAssetsHandler.GetEnemy("Scrungie_EN").deathSound;
            birb.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            birb.passives = new BasePassiveAbilitySO[2]
            {
                light,
                LoadedAssetsHandler.GetEnemy("OneManBand_EN").passiveAbilities[1],
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
            Ability counting = new Ability();
            counting.name = "Count";
            counting.description = "Increase \"Count\" by 1. If this counter reaches 3 or higher, reset the counter and deal a Deadly amount of damage to the opposing party member.";
            counting.rarity = 5;
            counting.effects = new Effect[3];
            counting.effects[0] = new Effect(ScriptableObject.CreateInstance<CountCountEffect>(), 1, CustomIntentIconSystem.GetIntent("CrowCount"), Slots.Self);
            counting.effects[2] = new Effect(CasterSubActionEffect.Create(new Effect[]
            {
                new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 12, null, Slots.Front),
            }), 12, null, Slots.Front, didThat);
            counting.effects[1] = new Effect(homonDomin, 1, IntentType.Damage_11_15, Slots.Front, didThat);
            counting.visuals = null;
            counting.animationTarget = Slots.Self;
            Ability waiting = new Ability();
            waiting.name = "Wait";
            waiting.description = "Increase \"Wait\" by 1. If this counter reaches 2 or higher, reset the counter, Curse the opposing party member, and inflict 3 Frail on all Cursed party members.";
            waiting.rarity = 4;
            waiting.effects = new Effect[6];
            waiting.effects[0] = new Effect(ScriptableObject.CreateInstance<WaitCountEffect>(), 1, CustomIntentIconSystem.GetIntent("CrowWait"), Slots.Self);
            waiting.effects[1] = new Effect(talons, 1, new IntentType?(), Slots.Front, didThat);
            waiting.effects[3] = new Effect(ScriptableObject.CreateInstance<ExitValueSetterEffect>(), 1, null, Slots.Self, didThat);
            waiting.effects[2] = new Effect(CasterSubActionEffect.Create(new Effect[]
            {
                new Effect(ScriptableObject.CreateInstance<ApplyCursedEffect>(), 1, null, Slots.Front),
                new Effect(ScriptableObject.CreateInstance<ApplyFrailEffect>(), 3, null, TargettingByStatusEffect.Create(Targetting.AllEnemy, StatusEffectType.Cursed)),
            }), 1, IntentType.Status_Cursed, Slots.Front, didThat);
            waiting.effects[4] = new Effect(BasicEffects.Empty, 0, IntentType.Status_Frail, TargettingByStatusEffect.Create(Targetting.AllEnemy, StatusEffectType.Cursed));
            waiting.effects[5] = new Effect(BasicEffects.Empty, 0, IntentType.Status_Frail, TargettingByStatusEffect.Create(Slots.Front, StatusEffectType.Cursed, false));
            waiting.visuals = null;
            waiting.animationTarget = Slots.Self;
            Ability serenity = new Ability();
            serenity.name = "Serenity";
            serenity.description = "Increase both \"Count\" and \"Wait\" by 1. Move left or right.";
            serenity.rarity = 3;
            serenity.effects = new Effect[3];
            serenity.effects[0] = new Effect(ScriptableObject.CreateInstance<SerenityEffect>(), 1, CustomIntentIconSystem.GetIntent("CrowCount"), Slots.Self);
            serenity.effects[2] = new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, IntentType.Swap_Sides, Slots.Self);
            serenity.effects[1] = new Effect(BasicEffects.Empty, 1, CustomIntentIconSystem.GetIntent("CrowWait"), Slots.Self);
            serenity.visuals = null;
            serenity.animationTarget = Slots.Self;


            birb.abilities = new Ability[3] { counting, waiting, serenity };
            birb.AddEnemy();
            LoadedAssetsHandler.GetEnemy("TheCrow_EN").enemyTemplate.SetCrowParams();
        }
    }
    public class CountCountEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            int checkThis = caster.GetStoredValue((UnitStoredValueNames)544524);
            checkThis++;
            if (checkThis >= 3)
            {
                caster.SetStoredValue((UnitStoredValueNames)544524, 0);
                return true;
            }
            caster.SetStoredValue((UnitStoredValueNames)544524, checkThis);
            return false;
        }
    }
    public class CountCountNoResetEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            int checkThis = caster.GetStoredValue((UnitStoredValueNames)544524);
            checkThis++;
            caster.SetStoredValue((UnitStoredValueNames)544524, checkThis);
            return true;
        }
    }
    public class WaitCountEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            int checkThis = caster.GetStoredValue((UnitStoredValueNames)544525);
            checkThis++;
            if (checkThis >= 2)
            {
                caster.SetStoredValue((UnitStoredValueNames)544525, 0);
                return true;
            }
            caster.SetStoredValue((UnitStoredValueNames)544525, checkThis);
            return false;
        }
    }
    public class SerenityEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            int gap = caster.GetStoredValue((UnitStoredValueNames)544525);
            gap++;
            caster.SetStoredValue((UnitStoredValueNames)544525, gap);
            int gap1 = caster.GetStoredValue((UnitStoredValueNames)544524);
            gap1++;
            caster.SetStoredValue((UnitStoredValueNames)544524, gap1);
            CombatManager.Instance.AddUIAction(new WasteTimeUIAction(caster.ID, caster.IsUnitCharacter, ""));
            CombatManager.Instance.AddUIAction(new WasteTimeUIAction(caster.ID, caster.IsUnitCharacter, ""));
            CombatManager.Instance.AddUIAction(new WasteTimeUIAction(caster.ID, caster.IsUnitCharacter, ""));
            CombatManager.Instance.AddUIAction(new WasteTimeUIAction(caster.ID, caster.IsUnitCharacter, ""));
            return true;
        }
    }

    public static class PrefabFixes
    {
        public static void SetCrowParams(this EnemyInFieldLayout e)
        {
            e._rootTransform = e.gameObject.GetComponent<Transform>();
            e._locator = e.gameObject.transform.Find("Locator").gameObject;
            e._renderer = e._locator.transform.Find("Sprite").Find("Head").GetComponent<SpriteRenderer>();
            e._animator = e.gameObject.GetComponent<Animator>();
            e._UI3DLocation = e.gameObject.transform.Find("3DUILocation").transform;
            e._moveTime = 0.6f;
            e._gibsEvent = "event:/Combat/Gibs/CBT_Gibs";
            e.saveAnimationTime = 2f;
            e._extraSounds = new string[0];
            e._basicColor = Color.black;
            e._hoverColor = Color.red;
            e._turnColor = Color.yellow;
            e._targetColor = Color.yellow;
        }
        public static void SetBeakParams(this EnemyInFieldLayout e)
        {
            e._rootTransform = e.gameObject.GetComponent<Transform>();
            e._locator = e.gameObject.transform.Find("Locator").gameObject;
            e._renderer = e._locator.transform.Find("Sprite").Find("Sprite").GetComponent<SpriteRenderer>();
            e._animator = e.gameObject.GetComponent<Animator>();
            e._UI3DLocation = e.gameObject.transform.Find("3DUILocation").transform;
            e._moveTime = 0.6f;
            e._gibsEvent = "event:/Combat/Gibs/CBT_Gibs";
            e.saveAnimationTime = 2f;
            e._extraSounds = new string[0];
            e._basicColor = Color.black;
            e._hoverColor = Color.red;
            e._turnColor = Color.yellow;
            e._targetColor = Color.yellow;
        }
        public static void SetGlassParams(this EnemyInFieldLayout e)
        {
            e._rootTransform = e.gameObject.GetComponent<Transform>();
            e._locator = e.gameObject.transform.Find("Locator").gameObject;
            e._renderer = e._locator.transform.Find("Sprite").Find("Sprite").GetComponent<SpriteRenderer>();
            e._animator = e.gameObject.GetComponent<Animator>();
            e._UI3DLocation = e.gameObject.transform.Find("3DUILocation").transform;
            e._moveTime = 0.6f;
            e._gibsEvent = "event:/Combat/Gibs/CBT_Gibs";
            e.saveAnimationTime = 2f;
            e._extraSounds = new string[0];
            e._basicColor = Color.black;
            e._hoverColor = Color.red;
            e._turnColor = Color.yellow;
            e._targetColor = Color.yellow;
        }
        public static void SetRustParams(this EnemyInFieldLayout e)
        {
            e._rootTransform = e.gameObject.GetComponent<Transform>();
            e._locator = e.gameObject.transform.Find("Locator").gameObject;
            e._renderer = e._locator.transform.Find("Sprite").Find("skullFront").GetComponent<SpriteRenderer>();
            e._animator = e.gameObject.GetComponent<Animator>();
            e._UI3DLocation = e.gameObject.transform.Find("3DUILocation").transform;
            e._moveTime = 0.6f;
            e._gibsEvent = "event:/Combat/Gibs/CBT_Gibs";
            e.saveAnimationTime = 2f;
            e._extraSounds = new string[0];
            e._basicColor = Color.black;
            e._hoverColor = Color.red;
            e._turnColor = Color.yellow;
            e._targetColor = Color.yellow;
        }
        public static void SetNerveParams(this EnemyInFieldLayout e)
        {
            e._rootTransform = e.gameObject.GetComponent<Transform>();
            e._locator = e.gameObject.transform.Find("Locator").gameObject;
            e._renderer = e._locator.transform.Find("Sprite").Find("Sprite").Find("Sprite").Find("Sprite").Find("Sprite").GetComponent<SpriteRenderer>();
            e._animator = e.gameObject.GetComponent<Animator>();
            e._UI3DLocation = e.gameObject.transform.Find("3DUILocation").transform;
            e._moveTime = 0.6f;
            e._gibsEvent = "event:/Combat/Gibs/CBT_Gibs";
            e.saveAnimationTime = 2f;
            e._extraSounds = new string[0];
            e._basicColor = Color.black;
            e._hoverColor = Color.red;
            e._turnColor = Color.yellow;
            e._targetColor = Color.yellow;
        }
    }
}
