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
    public static class LittleAngel
    {
        public static void Add()
        {
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

            Enemy angel = new Enemy()
            {
                name = "Little Angel",
                health = 10,
                size = 1,
                entityID = (EntityIDs)544530,
                healthColor = Pigments.Purple,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/PissShitFartCum/Angel_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
            };
            angel.prefab._gibs = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/PissShitFartCum/Angel_Gibs.prefab").GetComponent<ParticleSystem>();
            angel.prefab.SetDefaultParams();
            angel.combatSprite = ResourceLoader.LoadSprite("Angel_IconB", 32);
            angel.overworldAliveSprite = ResourceLoader.LoadSprite("Angel_Icon", 32, new Vector2?(new Vector2(0.5f, 0.05f)));
            angel.overworldDeadSprite = ResourceLoader.LoadSprite("Angel_Dead", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            angel.hurtSound = LoadedAssetsHandler.GetCharcater("Hans_CH").damageSound;
            angel.deathSound = LoadedAssetsHandler.GetCharcater("Hans_CH").deathSound;
            angel.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            angel.passives = new BasePassiveAbilitySO[2]
            {
                Passives.Immortal, light
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
            Ability kindness = new Ability();
            kindness.name = "Kindness";
            kindness.description = "Heal the Opposing party member 30% of their max health and apply 50 Pale and 1 Ruptured to them. \nMove Left, Right, or stay in place.";
            kindness.rarity = 5;
            kindness.effects = new Effect[4];
            kindness.effects[0] = new Effect(ScriptableObject.CreateInstance<HealHalfHealthEffect>(), 50, IntentType.Heal_11_20, Slots.Front);
            kindness.effects[1] = new Effect(ScriptableObject.CreateInstance<ApplyPaleEffect>(), 50, new IntentType?((IntentType)666888), Slots.Front);
            kindness.effects[2] = new Effect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 1, IntentType.Status_Ruptured, Slots.Front);
            kindness.effects[3] = new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, IntentType.Swap_Sides, Slots.Self, Conditions.Chance(60));
            kindness.visuals = LoadedAssetsHandler.GetEnemy("HeavensGateRed_BOSS").abilities[1].ability.visuals;
            kindness.animationTarget = Slots.Front;
            Ability tenderness = new Ability();
            tenderness.name = "Tenderness";
            tenderness.description = "Apply 10 Pale to the Opposing, Left, and Right party members. Apply 10 Pale to self and move Left or Right.";
            tenderness.rarity = 7;
            tenderness.effects = new Effect[3];
            tenderness.effects[0] = new Effect(ScriptableObject.CreateInstance<ApplyPaleEffect>(), 10, new IntentType?((IntentType)666888), Slots.FrontLeftRight);
            tenderness.effects[1] = new Effect(ScriptableObject.CreateInstance<ApplyPaleEffect>(), 10, new IntentType?((IntentType)666888), Slots.Self);
            tenderness.effects[2] = new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, IntentType.Swap_Sides, Slots.Self);
            tenderness.visuals = CustomVisuals.GetVisuals("Salt/Needle");
            tenderness.animationTarget = Slots.FrontLeftRight;
            AnimationVisualsEffect homonDomin = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            homonDomin._animationTarget = Slots.Front;
            homonDomin._visuals = LoadedAssetsHandler.GetEnemyAbility("Domination_A").visuals;
            Ability devotion = new Ability();
            devotion.name = "Devotion";
            devotion.description = "Move Left or Right. Apply 30 Pale to the Opposing party member and 30 Pale to self.";
            devotion.rarity = 6;
            devotion.effects = new Effect[4];
            devotion.effects[0] = new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, IntentType.Swap_Sides, Slots.Self);
            devotion.effects[1] = new Effect(homonDomin, 1, new IntentType?(), Slots.Self);
            devotion.effects[2] = new Effect(ScriptableObject.CreateInstance<ApplyPaleEffect>(), 30, new IntentType?((IntentType)666888), Slots.Front);
            devotion.effects[3] = new Effect(ScriptableObject.CreateInstance<ApplyPaleEffect>(), 30, new IntentType?((IntentType)666888), Slots.Self);
            devotion.visuals = null;
            devotion.animationTarget = Slots.Front;
            Ability adoration = new Ability();
            adoration.name = "Adoration";
            adoration.description = "Apply 50 Pale to the Opposing party member and 50 Pale to self. Apply 2 Ruptured to self if this enemy applied Pale to the Opposing party member.";
            adoration.rarity = 5;
            adoration.effects = new Effect[3];
            adoration.effects[0] = new Effect(ScriptableObject.CreateInstance<ApplyPaleEffect>(), 50, new IntentType?((IntentType)666888), Slots.Self);
            adoration.effects[1] = new Effect(ScriptableObject.CreateInstance<ApplyPaleEffect>(), 50, new IntentType?((IntentType)666888), Slots.Front);
            adoration.effects[2] = new Effect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 2, IntentType.Status_Ruptured, Slots.Self, didThat);
            adoration.visuals = CustomVisuals.GetVisuals("Salt/Hung");
            adoration.animationTarget = Slots.Front;


            if (DoDebugs.MiscInfo) Debug.Log("Abilities");

            angel.abilities = new Ability[4] { kindness, tenderness, devotion, adoration };
            angel.AddEnemy();
        }
    }
    public class HealHalfHealthEffect : EffectSO
    {
        public bool usePreviousExitValue;

        public bool entryAsPercentage = true;

        [SerializeField]
        public bool _directHeal = true;

        [SerializeField]
        public bool _onlyIfHasHealthOver0;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            if (usePreviousExitValue)
            {
                entryVariable *= base.PreviousExitValue;
            }

            exitAmount = 0;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (targetSlotInfo.HasUnit && (!_onlyIfHasHealthOver0 || targetSlotInfo.Unit.CurrentHealth > 0))
                {
                    int num = 30;
                    if (entryAsPercentage)
                    {
                        num = targetSlotInfo.Unit.CalculatePercentualAmount(num);
                    }

                    exitAmount += targetSlotInfo.Unit.Heal(num, HealType.Heal, _directHeal);
                }
            }

            return exitAmount > 0;
        }
    }
}
