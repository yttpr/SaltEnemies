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
    public static class DontTouchMe
    {
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

            Enemy cage = new Enemy()
            {
                name = "Freud",
                health = 28,
                size = 1,
                entityID = (EntityIDs)544522,
                healthColor = Pigments.Red,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/DontTouchMe/DontTouchMe_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
            };
            cage.prefab._gibs = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/DontTouchMe/DontTouchMe_Gibs.prefab").GetComponent<ParticleSystem>();
            cage.prefab.SetDefaultParams();
            cage.combatSprite = ResourceLoader.LoadSprite("TouchIconB", 32);
            cage.overworldAliveSprite = ResourceLoader.LoadSprite("TouchIcon", 32, new Vector2?(new Vector2(0.5f, 0.05f)));
            cage.overworldDeadSprite = ResourceLoader.LoadSprite("TouchDead", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            cage.hurtSound = LoadedAssetsHandler.GetCharcater("Gospel_CH").damageSound;
            cage.deathSound = LoadedAssetsHandler.GetCharcater("Gospel_CH").deathSound;
            cage.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            cage.passives = new BasePassiveAbilitySO[3]
            {
                Passives.Skittish,
                Passives.Forgetful,
                noTouch
            };


            
            
            AnimationVisualsEffect talons = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            talons._animationTarget = Slots.Right;
            talons._visuals = LoadedAssetsHandler.GetEnemyAbility("Talons_A").visuals;
            AnimationVisualsEffect talons2 = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            talons2._animationTarget = Slots.Left;
            talons2._visuals = LoadedAssetsHandler.GetEnemyAbility("Talons_A").visuals;
            AnimationVisualsEffect headshot = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            headshot._animationTarget = Slots.Right;
            headshot._visuals = LoadedAssetsHandler.GetEnemy("TriggerFingers_BOSS").abilities[0].ability.visuals;
            AnimationVisualsEffect headshot2 = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            headshot2._animationTarget = Slots.Left;
            headshot2._visuals = LoadedAssetsHandler.GetEnemy("TriggerFingers_BOSS").abilities[0].ability.visuals;
            PreviousEffectCondition didntThat = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            didntThat.wasSuccessful = false;
            PreviousEffectCondition didThat = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            didThat.wasSuccessful = true;
            Ability crusher = new Ability();
            crusher.name = "Crush";
            crusher.description = "Deal a painful amount of damage to the opposing party member.";
            crusher.rarity = 2;
            crusher.effects = new Effect[1];
            crusher.effects[0] = new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 5, IntentType.Damage_3_6, Slots.Front);
            crusher.visuals = LoadedAssetsHandler.GetEnemyAbility("Crush_A").visuals; ;
            crusher.animationTarget = Slots.Front;

            Targetting_ByUnit_Side allAlly = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            allAlly.getAllUnitSlots = false;
            allAlly.getAllies = true;
            Ability leftHit = new Ability();
            leftHit.name = "Left Scratch";
            leftHit.description = "Deal an agonizing amount of damage to the left party member.";
            leftHit.rarity = 7;
            leftHit.effects = new Effect[1];
            leftHit.effects[0] = new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 7, IntentType.Damage_7_10, Slots.Left);
            leftHit.visuals = LoadedAssetsHandler.GetEnemyAbility("Talons_A").visuals; ;
            leftHit.animationTarget = Slots.Left;

            Ability rightHit = new Ability();
            rightHit.name = "Right Cut";
            rightHit.description = "Deal an agonizing amount of damage to the right party member.";
            rightHit.rarity = 7;
            rightHit.effects = new Effect[1];
            rightHit.effects[0] = new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 7, IntentType.Damage_7_10, Slots.Right);
            rightHit.visuals = LoadedAssetsHandler.GetEnemyAbility("Talons_A").visuals; ;
            rightHit.animationTarget = Slots.Right;

            Ability wrath = new Ability();
            wrath.name = "Pure Hatred";
            wrath.description = "Apply 3 Ruptured and 1 Scar to the opposing party member.";
            wrath.rarity = 5;
            wrath.effects = new Effect[2];
            wrath.effects[0] = new Effect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 3, IntentType.Status_Ruptured, Slots.Front);
            wrath.effects[1] = new Effect(ScriptableObject.CreateInstance<ApplyScarsEffect>(), 1, IntentType.Status_Scars, Slots.Front);
            wrath.visuals = LoadedAssetsHandler.GetEnemyAbility("InhumanRoar_A").visuals;
            wrath.animationTarget = Slots.Self;

            cage.abilities = new Ability[4] { crusher, leftHit, rightHit, wrath };
            cage.AddEnemy();
        }
    }
    public class InvinciblePassiveAbility : BasePassiveAbilitySO
    {
        [Header("Multiplier Data")]
        [SerializeField]
        [Min(0.0f)]
        private int _modifyVal = 0;


        public override bool IsPassiveImmediate => true;

        public override bool DoesPassiveTrigger => true;

        public override void TriggerPassive(object sender, object args)
        {
            //Debug.Log("passive started");
            IUnit unit = sender as IUnit;
            
            if (args is DamageReceivedValueChangeException HitBy && HitBy.amount > 0)
            {
                if (args is DamageReceivedValueChangeException && !(args as DamageReceivedValueChangeException).Equals((object)null))
                {
                    (args as DamageReceivedValueChangeException).AddModifier((IntValueModifier)new InvincibleValueModifier(this._modifyVal));
                    (args as DamageReceivedValueChangeException).AddModifier((IntValueModifier)new ImmZeroMod());
                    CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction((sender as IPassiveEffector).ID, (sender as IPassiveEffector).IsUnitCharacter, GetPassiveLocData().text, this.passiveIcon));
                    
                }

            }
            

        }

        public override void OnPassiveConnected(IUnit unit)
        {
        }

        public override void OnPassiveDisconnected(IUnit unit)
        {
        }
    }
    public class InvincibleValueModifier : IntValueModifier
    {
        public readonly int FVAL;

        public InvincibleValueModifier(int exitVal)
          : base(999)
        {
            this.FVAL = exitVal;
        }

        public override int Modify(int value)
        {
            if (/*value < 999 &&*/ value > 0 && value >= this.FVAL)
            {
                value = this.FVAL;
            }
            return value;
        }
    }
}
