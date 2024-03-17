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
    public static class UnMung
    {
        public static void Add()
        {
            UnmungPassiveAbility fishing = ScriptableObject.CreateInstance<UnmungPassiveAbility>();
            fishing._passiveName = "Fishing";
            fishing.passiveIcon = ResourceLoader.LoadSprite("unmungPassive", 32);
            fishing.type = (PassiveAbilityTypes)544529;
            fishing._enemyDescription = "Upon taking direct damage, spawn a \"Fish.\" The weight of the fish spawned increases upon taking more damage.";
            fishing._characterDescription = "shouldnt be on a character";
            fishing.doesPassiveTriggerInformationPanel = false;
            fishing._triggerOn = new TriggerCalls[1] { TriggerCalls.OnBeingDamaged };

            Enemy unmung = new Enemy()
            {
                name = "Teach a Man to Fish",
                health = 20,
                size = 1,
                entityID = (EntityIDs)544529,
                healthColor = Pigments.Purple,
                priority = -1,
                prefab = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/Senis2/Fish_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
            };
            unmung.prefab._gibs = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/Senis2/Fish_Gibs.prefab").GetComponent<ParticleSystem>();
            unmung.prefab.SetDefaultParams();
            unmung.combatSprite = ResourceLoader.LoadSprite("UnMungIconB", 32);
            unmung.overworldAliveSprite = ResourceLoader.LoadSprite("UnMungIcon", 32, new Vector2?(new Vector2(0.5f, 0.05f)));
            unmung.overworldDeadSprite = ResourceLoader.LoadSprite("UnMungDead", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            unmung.hurtSound = LoadedAssetsHandler.GetCharcater("Nowak_CH").damageSound;
            unmung.deathSound = LoadedAssetsHandler.GetCharcater("Nowak_CH").deathSound;
            unmung.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            unmung.passives = new BasePassiveAbilitySO[1]
            {
                fishing
            };
            unmung.unitType = UnitType.Fish;

            Ability slap = new Ability();
            slap.name = "Slap";
            slap.description = "Deal 1 damage to the opposing party member.";
            slap.rarity = 8;
            slap.effects = new Effect[1];
            slap.effects[0] = new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 1, IntentType.Damage_1_2, Slots.Front);
            slap.visuals = LoadedAssetsHandler.GetCharacterAbility("Slap_A").visuals;
            slap.animationTarget = Slots.Front;

            Ability nibble = new Ability();
            nibble.name = "Nibble";
            nibble.description = "Deals a little bit of damage to the opposing party member.";
            nibble.rarity = 5;
            nibble.effects = new Effect[1];
            nibble.effects[0] = new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 1, IntentType.Damage_1_2, Slots.Front);
            nibble.visuals = LoadedAssetsHandler.GetEnemyAbility("Nibble_A").visuals;
            nibble.animationTarget = Slots.Front;

            GenerateColorManaEffect blueMana = ScriptableObject.CreateInstance<GenerateColorManaEffect>();
            blueMana.mana = Pigments.Blue;
            Ability weep = new Ability();
            weep.name = "Weep";
            weep.description = "Produces 3 Blue Pigment.";
            weep.rarity = 5;
            weep.effects = new Effect[1];
            weep.effects[0] = new Effect(blueMana, 3, IntentType.Mana_Generate, Slots.Self);
            weep.visuals = LoadedAssetsHandler.GetEnemyAbility("Weep_A").visuals;
            weep.animationTarget = Slots.Self;

            Ability struggle = new Ability();
            struggle.name = "Blissful Agony";
            struggle.description = "Clumsily deals a little of damage to this enemy. Inflicts 1 scar to this enemy.";
            struggle.rarity = 6;
            struggle.effects = new Effect[2];
            struggle.effects[0] = new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 2, IntentType.Damage_1_2, Slots.Self);
            struggle.effects[1] = new Effect(ScriptableObject.CreateInstance<ApplyScarsEffect>(), 1, IntentType.Status_Scars, Slots.Self);
            struggle.visuals = LoadedAssetsHandler.GetEnemyAbility("Struggle_A").visuals;
            struggle.animationTarget = Slots.Self;

            unmung.abilities = new Ability[4] { slap, nibble, weep, struggle };
            unmung.AddEnemy();
        }
    }
    public class UnmungPassiveAbility : BasePassiveAbilitySO
    {
        [SerializeField]
        private int _floorVal = 0;

        public override bool IsPassiveImmediate => true;

        public override bool DoesPassiveTrigger => true;

        public override void TriggerPassive(object sender, object args)
        {
            //Debug.Log("passive started");
            IUnit unit = sender as IUnit;

            if (args is DamageReceivedValueChangeException HitBy && HitBy.directDamage == true && HitBy.amount > _floorVal)
            {
                IPassiveEffector passiveEffector = sender as IPassiveEffector;
                HitBy.AddModifier((IntValueModifier)new UnmungTrigger(unit, passiveEffector));
            }
        }

        public override void OnPassiveConnected(IUnit unit)
        {
        }

        public override void OnPassiveDisconnected(IUnit unit)
        {
        }
    }
    public class UnmungTrigger : IntValueModifier
    {
        public readonly IUnit unit;
        public readonly IPassiveEffector effector;

        public UnmungTrigger( IUnit thisUnit, IPassiveEffector thisEffector)
          : base(1000)
        {
            this.unit = thisUnit;
            this.effector = thisEffector;
        }

        public override int Modify(int value)
        {
            if (value > 0)
            {
                AnimationVisualsEffect animIs = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
                animIs._visuals = LoadedAssetsHandler.GetEnemyAbility("Mungle_A").visuals;
                animIs._animationTarget = Slots.Self;
                Effect animYAY = new Effect(animIs, 1, new IntentType?(), Slots.Self);
                SpawnRandomEnemyAnywhereEffect selector = ScriptableObject.CreateInstance<SpawnRandomEnemyAnywhereEffect>();
                string fishQuote = "\"Feed Him for a Day\"";
                selector._enemies = new EnemySO[1] { LoadedAssetsHandler.GetEnemy("Mung_EN") };
                if (value >= 16)
                {
                    selector._enemies[0] = LoadedAssetsHandler.GetEnemy("TeachaMantoFish_EN");
                    fishQuote = "\"As He Enters a Whole New World of Misery\"";
                }
                else if (value >= 11 && value < 16)
                {
                    selector._enemies[0] = LoadedAssetsHandler.GetEnemy("MunglingMudLung_EN");
                    fishQuote = "\"Put Him out of His Current Suffering\"";
                }
                else if (value >= 7 && value < 11)
                {
                    selector._enemies[0] = LoadedAssetsHandler.GetEnemy("MudLung_EN");
                    fishQuote = "\"Teach a Man to Fish\"";
                }
                else if (value >= 3 && value < 7)
                {
                    selector._enemies[0] = LoadedAssetsHandler.GetEnemy("Mung_EN");
                    fishQuote = "\"Feed Him for a Day\"";
                }
                else if (value >= 1 && value < 3)
                {
                    selector._enemies[0] = LoadedAssetsHandler.GetEnemy("Mungie_EN");
                    fishQuote = "\"Give a Man a Fish\"";
                }
                Effect fishSpawn = new Effect(selector, 1, new IntentType?(), Slots.Self);
                CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(this.effector.ID, this.effector.IsUnitCharacter, fishQuote, ResourceLoader.LoadSprite("unmungPassive", 32)));
                CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[2] { animYAY, fishSpawn }), this.unit));
            }
            return value;
        }
    }
}
