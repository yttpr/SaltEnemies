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
    public static class Stars
    {
        public static void Add()
        {
            InvinciblePassiveAbility invinible = ScriptableObject.CreateInstance<InvinciblePassiveAbility>();
            invinible._passiveName = "Illusory";
            invinible.passiveIcon = ResourceLoader.LoadSprite("StarPassive", 32);
            invinible.type = (PassiveAbilityTypes)544521;
            invinible._enemyDescription = "This character is immune to both direct and indirect damage.";
            invinible._characterDescription = "This character is immune to both direct and indirect damage.";
            invinible.doesPassiveTriggerInformationPanel = false;
            invinible._triggerOn = new TriggerCalls[1] { TriggerCalls.OnBeingDamaged };

            Enemy stars = new Enemy()
            {
                name = "Star Gazer",
                health = 6,
                size = 1,
                entityID = (EntityIDs)544521,
                healthColor = Pigments.Purple,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/Senis3/Stars_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
            };
            stars.prefab._gibs = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/Senis3/Stars_Gibs.prefab").GetComponent<ParticleSystem>();
            stars.prefab.SetDefaultParams();
            stars.combatSprite = ResourceLoader.LoadSprite("IconBStars", 32);
            stars.overworldAliveSprite = ResourceLoader.LoadSprite("IconStars", 32, new Vector2?(new Vector2(0.5f, 0.05f)));
            stars.overworldDeadSprite = ResourceLoader.LoadSprite("IconStars", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            stars.hurtSound = LoadedAssetsHandler.GetEnemy("JumbleGuts_Hollowing_EN").damageSound;
            stars.deathSound = LoadedAssetsHandler.GetEnemy("JumbleGuts_Hollowing_EN").deathSound;
            stars.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            stars.passives = new BasePassiveAbilitySO[]
            {
                Passives.Infestation, invinible, Passives.Skittish,
            };

            AddPassiveEffect addWither = ScriptableObject.CreateInstance<AddPassiveEffect>();
            addWither._passiveToAdd = Passives.Withering;
            stars.enterEffects = new Effect[1]
            {
                new Effect(addWither, 1, new IntentType?(), Slots.Self, Conditions.Chance(70))
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

            Ability dance = new Ability();
            dance.name = "Slow Dance";
            dance.description = "Increase this character's Infestation by 1.";
            dance.rarity = 15;
            dance.effects = new Effect[1];
            dance.effects[0] = new Effect(infestationUp, 1, IntentType.Misc, Slots.Self);
            dance.visuals = LoadedAssetsHandler.GetEnemyAbility("Wriggle_A").visuals;
            dance.animationTarget = Slots.Self;
            Ability finished = new Ability();
            finished.name = "Abrupt Finish";
            finished.description = "Deal 1 damage to the opposing party member. Instantly kill self.";
            finished.rarity = 5;
            finished.effects = new Effect[2];
            finished.effects[0] = new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 1, IntentType.Damage_1_2, Slots.Front);
            finished.effects[1] = new Effect(ScriptableObject.CreateInstance<DirectDeathEffect>(), 1, IntentType.Damage_Death, Slots.Self);
            finished.visuals = LoadedAssetsHandler.GetEnemyAbility("StrikeAChord_A").visuals;
            finished.animationTarget = Slots.Front;


            stars.abilities = new Ability[2] { dance, finished };
            stars.AddEnemy();
        }
    }
}
