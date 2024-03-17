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

namespace Hawthorne.NewFolder
{
    public static class Phase0
    {
        public static void Add()
        {
            OnClickPassiveAbility clickIt = ScriptableObject.CreateInstance<OnClickPassiveAbility>();
            clickIt._passiveName = "Please, Click Me";
            clickIt.passiveIcon = ResourceLoader.LoadSprite("DontTouchMe", 32);
            clickIt.type = (PassiveAbilityTypes)544522;
            clickIt._enemyDescription = "Clicking this enemy is probably not a good idea.";
            clickIt._characterDescription = "placeholder description";
            clickIt.doesPassiveTriggerInformationPanel = true;
            clickIt._triggerOn = new TriggerCalls[1] { (TriggerCalls)267850 };

            Targetting_ByUnit_Side allAlly = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            allAlly.getAllUnitSlots = false;
            allAlly.getAllies = true;

            RefreshAbilityUseEffect exhaust = ScriptableObject.CreateInstance<RefreshAbilityUseEffect>();
            exhaust._doesExhaustInstead = true;


            Targetting_ByUnit_Side allEnemy = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            allEnemy.getAllUnitSlots = false;
            allEnemy.getAllies = false;

            AddPhase1Effect bossItUp = ScriptableObject.CreateInstance<AddPhase1Effect>();
            //bossItUp.enemy = LoadedAssetsHandler.GetEnemy("544517_EN");

            PerformEffectPassiveAbility dontClick = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            dontClick._passiveName = "Container";
            dontClick.passiveIcon = ResourceLoader.LoadSprite("CageIcon", 32);
            dontClick.type = (PassiveAbilityTypes)544518;
            dontClick._enemyDescription = "There's something waiting inside...";
            dontClick._characterDescription = "placeholder description";
            dontClick.doesPassiveTriggerInformationPanel = true;
            dontClick._triggerOn = new TriggerCalls[1] { (TriggerCalls)267850 };
            dontClick.conditions = new EffectorConditionSO[1] { ScriptableObject.CreateInstance<StoredValueIsFiveTriggerOnlyOnceCondition>() };
            dontClick.effects = ExtensionMethods.ToEffectInfoArray(new Effect[4] 
            { 
                new Effect(ScriptableObject.CreateInstance<DirectDeathEffect>(), 1, null, Slots.Self),
                new Effect(ScriptableObject.CreateInstance<FleeTargetEffect>(), 1, null, allAlly),
                new Effect(exhaust, 1, null, allEnemy),
                new Effect(bossItUp, 1, null, Slots.Self)
            });


            Enemy phase0 = new Enemy()
            {
                name = "Strange Box",
                health = 8,
                size = 1,
                entityID = (EntityIDs)544518,
                healthColor = Pigments.Gray,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/superboss/Phase0_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
            };
            phase0.prefab._gibs = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/superboss/Phase0_Gibs.prefab").GetComponent<ParticleSystem>();
            phase0.prefab.SetDefaultParams();
            phase0.combatSprite = ResourceLoader.LoadSprite("CageIconB", 32);
            phase0.overworldAliveSprite = ResourceLoader.LoadSprite("SupperIcon", 32, new Vector2?(new Vector2(0.5f, 0.05f)));
            phase0.overworldDeadSprite = ResourceLoader.LoadSprite("SupperIcon", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            phase0.hurtSound = LoadedAssetsHandler.GetEnemy("Visage_MyOwn_EN").damageSound;
            phase0.deathSound = LoadedAssetsHandler.GetEnemy("Visage_MyOwn_EN").deathSound;
            phase0.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            phase0.passives = new BasePassiveAbilitySO[2]
            {
                clickIt, dontClick
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

            Ability sipppo = new Ability();
            sipppo.name = "Siphon";
            sipppo.description = "This enemy consumes 3 pigment not of this enemy's health color.";
            sipppo.rarity = 5;
            sipppo.effects = new Effect[1];
            sipppo.effects[0] = new Effect(ScriptableObject.CreateInstance<ConsumeRandomButColorManaEffect>(), 3, IntentType.Mana_Consume, Slots.Self);
            sipppo.visuals = LoadedAssetsHandler.GetEnemyAbility("Siphon_A").visuals;
            sipppo.animationTarget = Slots.Self;

            AddPassiveEffect leakIt = ScriptableObject.CreateInstance<AddPassiveEffect>();
            leakIt._passiveToAdd = Passives.Leaky;

            Ability gigoo = new Ability();
            gigoo.name = "Gnaw";
            gigoo.description = "Apply 4 damage to the left and right party members.";
            gigoo.rarity = 5;
            gigoo.effects = new Effect[1];
            gigoo.effects[0] = new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 4, IntentType.Damage_3_6, Slots.LeftRight);
            gigoo.visuals = LoadedAssetsHandler.GetEnemyAbility("Gnaw_A").visuals;
            gigoo.animationTarget = Slots.LeftRight;



            Ability dust = new Ability();
            dust.name = "Not Long for This World";
            dust.description = "Apply 3 Divine Protection to the enemies with the lowest health. Apply 2 Divine Protection to the enemies with the second lowest health. Apply 1 Divine Protection to the enemies with the third lowest health.";
            dust.rarity = 8;
            dust.effects = new Effect[1];
            dust.effects[0] = new Effect(ScriptableObject.CreateInstance<DPLowestThreeEffect>(), 1, IntentType.Status_DivineProtection, allAlly);
            dust.visuals = LoadedAssetsHandler.GetEnemyAbility("MinorKey_A").visuals;
            dust.animationTarget = allAlly;


            phase0.abilities = new Ability[0] { };
            phase0.AddEnemy();
        }
    }
    public class StoredValueIsFiveTriggerOnlyOnceCondition : EffectorConditionSO
    {
        [SerializeField]
        public UnitStoredValueNames _storeValue = (UnitStoredValueNames)267850;

        public UnitStoredValueNames _triggered = (UnitStoredValueNames)567881;

        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if ((effector as IUnit).GetStoredValue(_storeValue) < 5)
            {
                return false;
            }

            if ((effector as IUnit).GetStoredValue(_triggered) == 88)
            {
                return false;
            }

            (effector as IUnit).SetStoredValue(_triggered, 88);
            return true;
        }
    }
}
