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
using static System.Net.WebRequestMethods;
using System.Security.Cryptography;

namespace Hawthorne
{
    public static class Denial
    {
        public static void Add()
        {
            Enemy denial = new Enemy()
            {
                name = "Denial",
                health = 3,
                size = 1,
                entityID = (EntityIDs)544525,
                healthColor = Pigments.Purple,
                priority = -1,
                prefab = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/Senis2/Something_Denial_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
            };
            denial.prefab._gibs = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/Senis2/Something_Denial_Gibs.prefab").GetComponent<ParticleSystem>();
            denial.prefab.SetDefaultParams();
            denial.combatSprite = ResourceLoader.LoadSprite("DenialIconB", 32);
            denial.overworldAliveSprite = ResourceLoader.LoadSprite("DenialIcon", 32, new Vector2?(new Vector2(0.5f, 0.05f)));
            denial.overworldDeadSprite = ResourceLoader.LoadSprite("SomethingDead", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            denial.hurtSound = LoadedAssetsHandler.GetEnemy("MusicMan_EN").damageSound;
            denial.deathSound = LoadedAssetsHandler.GetEnemy("MusicMan_EN").deathSound;
            denial.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            denial.passives = new BasePassiveAbilitySO[2]
            {
                Passives.Skittish, Passives.Withering
            };
            PreviousEffectCondition didThat = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            didThat.wasSuccessful = true;
            Ability liar = new Ability();
            liar.name = "A Lie";
            liar.description = "Deal a painful amount of damage to the left and right party members.";
            liar.rarity = 10;
            liar.effects = new Effect[1];
            liar.effects[0] = new Effect(ScriptableObject.CreateInstance<LyingDamageEffect>(), 4, IntentType.Damage_3_6, Slots.LeftRight);
            liar.visuals = LoadedAssetsHandler.GetEnemyAbility("Bash_A").visuals;
            liar.animationTarget = Slots.Front;

            Ability danger = new Ability();
            danger.name = "This Is A Very Dangerous Ability";
            danger.description = "This is a very dangerous ability.";
            danger.rarity = 12;
            danger.effects = new Effect[1];
            danger.effects[0] = new Effect(ScriptableObject.CreateInstance<RandomAnimEffect>(), 1, IntentType.Misc, Slots.Self);
            danger.visuals = null;
            danger.animationTarget = Slots.Front;

            denial.abilities = new Ability[2] { liar, danger };
            denial.AddEnemy();
        }
    }
    public static class Derogatory
    {
        public static void Add()
        {
            PerformEffectPassiveAbility decay = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            decay._passiveName = "Decay";
            decay.passiveIcon = ResourceLoader.LoadSprite("DecayPassiveIcon", 32);
            decay.type = PassiveAbilityTypes.Decay;
            decay._enemyDescription = "Upon dying, this enemy has a 33% chance to decay into a Denial.";
            decay._characterDescription = "shouldnt be on a character. idk what it'd do. fuck you up, maybe?";
            decay.doesPassiveTriggerInformationPanel = true;
            decay._triggerOn = new TriggerCalls[1] { TriggerCalls.OnDeath };
            PercentageEffectorCondition decay25P = ScriptableObject.CreateInstance<PercentageEffectorCondition>();
            decay25P.triggerPercentage = 33;
            DeathReferenceDetectionEffectorCondition detectWither = ScriptableObject.CreateInstance<DeathReferenceDetectionEffectorCondition>();
            detectWither._witheringDeath = false;
            detectWither._useWithering = true;
            decay.conditions = new EffectorConditionSO[2]
            {
                decay25P, detectWither
            };
            SpawnEnemyAnywhereEffect spawnDenial = ScriptableObject.CreateInstance<SpawnEnemyAnywhereEffect>();
            spawnDenial.enemy = LoadedAssetsHandler.GetEnemy("Denial_EN");
            decay.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
            {
                new Effect(spawnDenial, 1, new IntentType?(), Slots.Self)
            });
            if (DoDebugs.GenInfo) Debug.Log("passive");

            Enemy derogatory = new Enemy()
            {
                name = "Derogatory",
                health = 3,
                size = 1,
                entityID = (EntityIDs)544526,
                healthColor = Pigments.Yellow,
                priority = -1,
                prefab = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/Senis2/Something_Derogatory_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
            };
            derogatory.prefab._gibs = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/Senis2/Something_Derogatory_Gibs.prefab").GetComponent<ParticleSystem>();
            derogatory.prefab.SetDefaultParams();
            if (DoDebugs.GenInfo) Debug.Log("prefab");
            derogatory.combatSprite = ResourceLoader.LoadSprite("DerogatoryIconB", 32);
            derogatory.overworldAliveSprite = ResourceLoader.LoadSprite("DerogatoryIcon", 32, new Vector2?(new Vector2(0.5f, 0.05f)));
            derogatory.overworldDeadSprite = ResourceLoader.LoadSprite("SomethingDead", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            derogatory.hurtSound = LoadedAssetsHandler.GetEnemy("MusicMan_EN").damageSound;
            derogatory.deathSound = LoadedAssetsHandler.GetEnemy("MusicMan_EN").deathSound;
            derogatory.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            derogatory.passives = new BasePassiveAbilitySO[3]
            {
                decay, Passives.Slippery, Passives.Withering
            };
            if (DoDebugs.GenInfo) Debug.Log("data");
            PreviousEffectCondition didThat = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            didThat.wasSuccessful = true;
            Ability convo = new Ability();
            convo.name = "Conversation";
            convo.description = "Apply 1 Stunned to the opposing party member. If successful, apply 2 Stunned to self.";
            convo.rarity = 10;
            convo.effects = new Effect[3];
            convo.effects[0] = new Effect(ScriptableObject.CreateInstance<WasteTimeEffect>(), 1, new IntentType?(), Slots.Self);
            convo.effects[1] = new Effect(ScriptableObject.CreateInstance<ApplyStunnedEffect>(), 1, new IntentType?((IntentType)988896), Slots.Front);
            convo.effects[2] = new Effect(ScriptableObject.CreateInstance<ApplyStunnedEffect>(), 2, new IntentType?((IntentType)988896), Slots.Self, didThat);
            convo.visuals = null;
            convo.animationTarget = Slots.Self;

            derogatory.abilities = new Ability[1] { convo };
            derogatory.AddEnemy();
        }
    }
    public static class Something
    {
        public static void Add()
        {
            PerformEffectPassiveAbility decay = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            decay._passiveName = "Decay";
            decay.passiveIcon = ResourceLoader.LoadSprite("DecayPassiveIcon", 32);
            decay.type = PassiveAbilityTypes.Decay;
            decay._enemyDescription = "Upon dying, this enemy decays into 3-5 Derogatories.";
            decay._characterDescription = "shouldnt be on a character. idk what it'd do. fuck you up, maybe?";
            decay.doesPassiveTriggerInformationPanel = true;
            decay._triggerOn = new TriggerCalls[1] { TriggerCalls.OnDeath };
            SpawnEnemyAnywhereEffect spawnDerogatory = ScriptableObject.CreateInstance<SpawnEnemyAnywhereEffect>();
            spawnDerogatory.enemy = LoadedAssetsHandler.GetEnemy("Derogatory_EN");
            decay.effects = ExtensionMethods.ToEffectInfoArray(new Effect[3]
            {
                new Effect(spawnDerogatory, 3, new IntentType?(), Slots.Self),
                new Effect(spawnDerogatory, 1, new IntentType?(), Slots.Self, Conditions.Chance(50)),
                new Effect(spawnDerogatory, 1, new IntentType?(), Slots.Self, Conditions.Chance(33))
            });

            Enemy something = new Enemy()
            {
                name = "Something",
                health = 35,
                size = 1,
                entityID = (EntityIDs)544527,
                healthColor = Pigments.Red,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/Senis2/Something_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
            };
            if (DoDebugs.GenInfo) Debug.Log("main prefab");
            something.prefab._gibs = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/Senis2/Something_Gibs.prefab").GetComponent<ParticleSystem>();
            something.prefab.SetDefaultParams();
            something.combatSprite = ResourceLoader.LoadSprite("SomethingIconB", 32);
            something.overworldAliveSprite = ResourceLoader.LoadSprite("SomethingIcon", 32, new Vector2?(new Vector2(0.5f, 0.05f)));
            something.overworldDeadSprite = ResourceLoader.LoadSprite("SomethingDead", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            something.hurtSound = LoadedAssetsHandler.GetCharcater("Gospel_CH").damageSound;
            something.deathSound = LoadedAssetsHandler.GetCharcater("Gospel_CH").deathSound;
            something.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            something.passives = new BasePassiveAbilitySO[2]
            {
                decay, Passives.Forgetful
            };

            DamageEffect indirect = ScriptableObject.CreateInstance<DamageEffect>();
            indirect._indirect = true;
            WasteTimeEffect boreTalk = ScriptableObject.CreateInstance<WasteTimeEffect>();
            boreTalk._text = new string[3] { "...", "...", "..." };
            Ability bore = new Ability();
            bore.name = "Bore";
            bore.description = "Deal a painful amount of indirect damage to the opposing party member.";
            bore.rarity = 10;
            bore.effects = new Effect[2];
            bore.effects[0] = new Effect(boreTalk, 3, new IntentType?(), Slots.Front);
            bore.effects[1] = new Effect(indirect, 5, IntentType.Damage_3_6, Slots.Front);
            bore.visuals = null;
            bore.animationTarget = Slots.Front;

            Ability spawn = new Ability();
            spawn.name = "Affectionate";
            spawn.description = "Attempt to spawn a Derogatory.";
            spawn.rarity = 5;
            spawn.effects = new Effect[1];
            spawn.effects[0] = new Effect(spawnDerogatory, 1, IntentType.Other_Spawn, Slots.Self);
            spawn.visuals = LoadedAssetsHandler.GetCharacterAbility("Wrath_1_A").visuals;
            spawn.animationTarget = Slots.Self;

            something.abilities = new Ability[2] { bore, spawn };
            something.AddEnemy();
        }
    }
    public class WasteTimeEffect : EffectSO
    {
        [SerializeField]
        public string[] _text = new string[1] { "..." };

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;

            for (int i = 0; i < entryVariable && i < _text.Length; i++)
            {
                CombatManager.Instance.AddUIAction(new ShowAttackInformationUIAction(caster.ID, caster.IsUnitCharacter, _text[i]));
                CombatManager.Instance.AddUIAction(new WasteTimeUIAction(caster.ID, caster.IsUnitCharacter, _text[i]));
                CombatManager.Instance.AddUIAction(new WasteTimeUIAction(caster.ID, caster.IsUnitCharacter, _text[i]));
                CombatManager.Instance.AddUIAction(new WasteTimeUIAction(caster.ID, caster.IsUnitCharacter, _text[i]));
                CombatManager.Instance.AddUIAction(new WasteTimeUIAction(caster.ID, caster.IsUnitCharacter, _text[i]));
                exitAmount++;
            }

            return exitAmount > 0;
        }
    }
    public class LyingDamageEffect : EffectSO
    {
        [SerializeField]
        public DeathType _deathType = DeathType.Basic;

        [SerializeField]
        public bool _usePreviousExitValue;

        [SerializeField]
        public bool _ignoreShield;

        [SerializeField]
        public bool _indirect;

        [SerializeField]
        public bool _returnKillAsSuccess;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            int picking = UnityEngine.Random.Range(0, 3);
            int hitWith = 0;
            if (picking == 0)
                hitWith = 1;
            if (picking == 1)
                hitWith = 2;
            if (picking == 2)
                hitWith = 7;

            Effect thisEffect = new Effect(ScriptableObject.CreateInstance<DamageEffect>(), hitWith, new IntentType?(), Slots.Front);
            DamageEffect previousExit = ScriptableObject.CreateInstance<DamageEffect>();
            previousExit._usePreviousExitValue = true;
            PreviousEffectCondition didThat = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            didThat.wasSuccessful = true;
            Effect selfHit = new Effect(previousExit, 1, new IntentType?(), Slots.Self, didThat);
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[2] { thisEffect, selfHit }), caster));
            exitAmount = hitWith;
            return true;
        }
    }
    public class RandomAnimEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            AnimationVisualsEffect anim = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            int picking = UnityEngine.Random.Range(0, 15);
            if (picking == 0)
            {
                anim._visuals = LoadedAssetsHandler.GetEnemy("TriggerFingers_BOSS").abilities[3].ability.visuals;
                anim._animationTarget = Slots.Self;
            }
            if (picking == 1)
            {
                anim._visuals = LoadedAssetsHandler.GetEnemyAbility("Talons_A").visuals;
                anim._animationTarget = Slots.FrontLeftRight;
            }
            if (picking == 2)
            {
                anim._visuals = LoadedAssetsHandler.GetEnemyAbility("Crush_A").visuals;
                anim._animationTarget = Slots.FrontLeftRight;
            }
            if (picking == 3)
            {
                anim._visuals = LoadedAssetsHandler.GetEnemy("Ouroborus_Tail_BOSS").abilities[0].ability.visuals;
                anim._animationTarget = Slots.Front;
            }
            if (picking == 4)
            {
                anim._visuals = LoadedAssetsHandler.GetEnemy("TriggerFingers_BOSS").abilities[0].ability.visuals;
                anim._animationTarget = Slots.FrontLeftRight;
            }
            if (picking == 5)
            {
                anim._visuals = LoadedAssetsHandler.GetEnemyAbility("RingABell_A").visuals;
                anim._animationTarget = Slots.Front;
            }
            Targetting_ByUnit_Side allAlly = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            allAlly.getAllUnitSlots = false;
            allAlly.getAllies = true;
            if (picking == 6)
            {
                anim._visuals = LoadedAssetsHandler.GetEnemy("Sepulchre_EN").abilities[0].ability.visuals;
                anim._animationTarget = allAlly;
            }
            if (picking == 7)
            {
                anim._visuals = LoadedAssetsHandler.GetEnemyAbility("Domination_A").visuals;
                anim._animationTarget = Slots.Front;
            }
            if (picking == 8)
            {
                anim._visuals = LoadedAssetsHandler.GetCharacterAbility("Conversion_1_A").visuals;
                anim._animationTarget = Slots.Self;
            }
            Targetting_ByUnit_Side allEnemy = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            allEnemy.getAllUnitSlots = false;
            allEnemy.getAllies = false;
            if (picking == 9)
            {
                anim._visuals = LoadedAssetsHandler.GetEnemy("HeavensGateRed_BOSS").abilities[1].ability.visuals;
                anim._animationTarget = allEnemy;
            }
            if (picking == 10)
            {
                anim._visuals = LoadedAssetsHandler.GetEnemy("SmoothSkin_BOSS").abilities[0].ability.visuals;
                anim._animationTarget = Slots.Front;
            }
            if (picking == 11)
            {
                anim._visuals = LoadedAssetsHandler.GetEnemyAbility("Crescendo_A").visuals;
                anim._animationTarget = Slots.Front;
            }
            if (picking == 12)
            {
                anim._visuals = LoadedAssetsHandler.GetEnemyAbility("FallingSkies_A").visuals;
                anim._animationTarget = allEnemy;
            }
            if (picking == 13)
            {
                anim._visuals = LoadedAssetsHandler.GetCharacterAbility("Parry_1_A").visuals;
                anim._animationTarget = Slots.Front;
            }
            if (picking == 14)
            {
                anim._visuals = LoadedAssetsHandler.GetCharacterAbility("Takedown_1_A").visuals;
                anim._animationTarget = Slots.Front;
            }
            Effect animYay = new Effect(anim, 1, new IntentType?(), Slots.Self);

            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { animYay }), caster));
            exitAmount = 0;
            return true;
        }
    }
    public class WasteTimeUIAction : CombatAction
    {
        public int _id;

        public bool _isUnitCharacter;

        public string _attackName;
        public int _miliseconds;

        public WasteTimeUIAction(int id, bool isUnitCharacter, string attackName/*, int miliseconds*/)
        {
            _id = id;
            _isUnitCharacter = isUnitCharacter;
            _attackName = attackName;
            //_miliseconds = miliseconds;
        }

        public override IEnumerator Execute(CombatStats stats)
        {
            yield return stats.combatUI.ShowAttackInformation(_id, _isUnitCharacter, "", "");
        }


    }
}
