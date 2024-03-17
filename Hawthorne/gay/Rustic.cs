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

namespace Hawthorne.gay
{
    public static class Rustic
    {
        public static void Add()
        {
            

            Enemy jumboo = new Enemy()
            {
                name = "Rustic Jumbleguts",
                health = 6,
                size = 1,
                entityID = (EntityIDs)544520,
                healthColor = Pigments.Gray,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/greyShit/GreyGuts_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
            };
            jumboo.prefab._gibs = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/greyShit/GreyGuts_Gibs.prefab").GetComponent<ParticleSystem>();
            jumboo.prefab.SetDefaultParams();
            jumboo.combatSprite = ResourceLoader.LoadSprite("GJumbIconB", 32);
            jumboo.overworldAliveSprite = ResourceLoader.LoadSprite("GJumbIcon", 32, new Vector2?(new Vector2(0.5f, 0.05f)));
            jumboo.overworldDeadSprite = ResourceLoader.LoadSprite("GJumbDead", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            jumboo.hurtSound = LoadedAssetsHandler.GetEnemy("ChoirBoy_EN").damageSound;
            jumboo.deathSound = LoadedAssetsHandler.GetEnemy("ChoirBoy_EN").deathSound;
            jumboo.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            jumboo.passives = new BasePassiveAbilitySO[4]
            {
                Passives.Dying, Passives.Transfusion, Passives.Slippery, Passives.Pure
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

            CasterStoredValueChangeEffect infestationUp = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
            infestationUp._minimumValue = 0;
            infestationUp._increase = true;
            infestationUp._valueName = UnitStoredValueNames.InfestationPA;

            Ability melt = new Ability();
            melt.name = "Melting Point";
            melt.description = "Deal 11 damage to the opposing enemy.";
            melt.rarity = 5;
            melt.effects = new Effect[1];
            melt.effects[0] = new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 11, IntentType.Damage_11_15, Slots.Front);
            melt.visuals = LoadedAssetsHandler.GetEnemyAbility("Boil_A").visuals;
            melt.animationTarget = Slots.Front;

            AddPassiveEffect leakIt = ScriptableObject.CreateInstance<AddPassiveEffect>();
            leakIt._passiveToAdd = Passives.Leaky;

            Ability flood = new Ability();
            flood.name = "Monsoon Season";
            flood.description = "Increase the Lucky Pigment Percentage by 30%.";
            flood.rarity = 5;
            flood.effects = new Effect[1];
            flood.effects[0] = new Effect(ScriptableObject.CreateInstance<IncreaseLuckyBluePercentageEffect>(), 30, IntentType.Misc, Slots.Self);
            flood.visuals = LoadedAssetsHandler.GetEnemyAbility("Flood_A").visuals;
            flood.animationTarget = Slots.Self;

            Ability dust = new Ability();
            dust.name = "Dust to Dust";
            dust.description = "Deal 1 direct damage to this enemy. Give this enemy another action.";
            dust.rarity = 3;
            dust.effects = new Effect[2];
            dust.effects[0] = new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 1, IntentType.Damage_1_2, Slots.Self);
            dust.effects[1] = new Effect(ScriptableObject.CreateInstance<AddTurnTargetToTimelineEffect>(), 1, IntentType.Misc, Slots.Self);
            dust.visuals = LoadedAssetsHandler.GetEnemyAbility("MinorKey_A").visuals;
            dust.animationTarget = Slots.Self;


            jumboo.abilities = new Ability[3] { melt, flood, dust };
            jumboo.AddEnemy();
            LoadedAssetsHandler.GetEnemy("RusticJumbleguts_EN").enemyTemplate.SetRustParams();
        }
    }
    public class IncreaseLuckyBluePercentageEffect : EffectSO
    {
        public override bool PerformEffect(
          CombatStats stats,
          IUnit caster,
          TargetSlotInfo[] targets,
          bool areTargetSlots,
          int entryVariable,
          out int exitAmount)
        {
            exitAmount = entryVariable;
            stats.SetLuckyBluePercentage(entryVariable + stats.LuckyManaPercentage);
            return exitAmount > 0;
        }
    }
}
