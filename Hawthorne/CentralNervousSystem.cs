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
using Hawthorne;
using THE_DEAD;

namespace Hawthorne
{
    public static class CentralNervousSystem
    {
        public static void Add()
        {
            
            Enemy CNS = new Enemy()
            {
                name = "Lost Sheep",
                health = 18,
                size = 1,
                entityID = (EntityIDs)544534,
                healthColor = Pigments.Red,
                priority = 3,
                prefab = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/PissShitFartCum/CNS_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
            };
            //Debug.Log("prefab");
            CNS.prefab._gibs = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/PissShitFartCum/CNS_Gibs_Prefab.prefab").GetComponent<ParticleSystem>();
            CNS.prefab.SetDefaultParams();
            CNS.combatSprite = ResourceLoader.LoadSprite("CNSIconB", 32);
            CNS.overworldAliveSprite = ResourceLoader.LoadSprite("CNSIcon", 32, new Vector2?(new Vector2(0.5f, 0.05f)));
            CNS.overworldDeadSprite = ResourceLoader.LoadSprite("CNSDead", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            CNS.hurtSound = LoadedAssetsHandler.GetEnemy("ShiveringHomunculus_EN").damageSound;
            CNS.deathSound = LoadedAssetsHandler.GetEnemy("ShiveringHomunculus_EN").deathSound;
            CNS.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            CNS.passives = new BasePassiveAbilitySO[]
            {
                Passi.Freak, Passives.Withering, Passives.Dying, Passives.Delicate
            };
            //Debug.Log("data");
            TargettingClosestNotLostSheep closestAlly = ScriptableObject.CreateInstance<TargettingClosestNotLostSheep>();
            closestAlly.getAllies = true;

            PreviousEffectCondition didntThat = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            didntThat.wasSuccessful = false;
            Ability adrenaline = new Ability();
            adrenaline.name = "Adrenaline Rush";
            adrenaline.description = "Apply 2-3 Power to the closest left and right enemies that aren't Lost Sheep. Apply 0-1 Scars to self. ";
            adrenaline.rarity = 5;
            adrenaline.effects = new Effect[2];
            adrenaline.effects[0] = new Effect(ScriptableObject.CreateInstance<ApplyPowerRangePlusOneEffect>(), 2, new IntentType?((IntentType)987895), closestAlly);
            adrenaline.effects[1] = new Effect(ScriptableObject.CreateInstance<ApplyScarsEffect>(), 1, new IntentType?(IntentType.Status_Scars), Slots.Self, Conditions.Chance(50));
            adrenaline.visuals = LoadedAssetsHandler.GetCharacterAbility("WholeAgain_1_A").visuals;
            adrenaline.animationTarget = closestAlly;

            UnitSideNotLostSheep allAlly = ScriptableObject.CreateInstance<UnitSideNotLostSheep>();
            allAlly.getAllUnitSlots = false;
            allAlly.getAllies = true;
            Ability reflex = new Ability();
            reflex.name = "Autonomous Reflex";
            reflex.description = "Apply 0-1 Power to all enemies that aren't Lost Sheep. Deal a little bit of damage to self.";
            reflex.rarity = 5;
            reflex.effects = new Effect[2];
            reflex.effects[0] = new Effect(ScriptableObject.CreateInstance<ApplyPowerRangePlusOneEffect>(), 0, new IntentType?((IntentType)987895), allAlly);
            reflex.effects[1] = new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 2, new IntentType?(IntentType.Damage_1_2), Slots.Self);
            reflex.visuals = LoadedAssetsHandler.GetCharacterAbility("Quills_1_A").visuals;
            reflex.animationTarget = Slots.Self;

            TargettingWeakestNotLostSheep weakest = ScriptableObject.CreateInstance<TargettingWeakestNotLostSheep>();
            weakest.getAllies = true;
            weakest.ignoreCastSlot = true;

            DoubleTargetting panicAnim = ScriptableObject.CreateInstance<DoubleTargetting>();
            panicAnim.firstTargetting = weakest;
            panicAnim.secondTargetting = Slots.Self;

            Ability panic = new Ability();
            panic.name = "Panic";
            panic.description = "Deal a little bit of damage and apply 1 Scar to self. Apply 1-4 Power to the enemy with the lowest health that isn't a Lost Sheep.";
            panic.rarity = 5;
            panic.effects = new Effect[3];
            panic.effects[0] = new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 2, new IntentType?(IntentType.Damage_1_2), Slots.Self);
            panic.effects[1] = new Effect(ScriptableObject.CreateInstance<ApplyScarsEffect>(), 1, new IntentType?(IntentType.Status_Scars), Slots.Self);
            panic.effects[2] = new Effect(ScriptableObject.CreateInstance<ApplyPowerRangePlusThreeEffect>(), 1, new IntentType?((IntentType)987895), weakest);
            panic.visuals = LoadedAssetsHandler.GetEnemy("TriggerFingers_BOSS").abilities[0].ability.visuals;
            panic.animationTarget = panicAnim;
            //Debug.Log("abilities");

            CNS.abilities = new Ability[3] { adrenaline, reflex, panic };
            CNS.AddEnemy();
        }
    }
    public class DoubleTargetting : BaseCombatTargettingSO
    {
        public BaseCombatTargettingSO firstTargetting;
        public BaseCombatTargettingSO secondTargetting;

        public override bool AreTargetAllies => false;
        public override bool AreTargetSlots => false;

        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            List<TargetSlotInfo> list = new List<TargetSlotInfo>();

            if (firstTargetting != null)
            {
                foreach (TargetSlotInfo target in firstTargetting.GetTargets(slots, casterSlotID, isCasterCharacter))
                    list.Add(target);
            }

            if (secondTargetting != null)
            {
                foreach (TargetSlotInfo target in secondTargetting.GetTargets(slots, casterSlotID, isCasterCharacter))
                    list.Add(target);
            }

            return list.ToArray();
        }
    }
    public class ApplyPowerRangePlusTwoEffect : EffectSO
    {
        public override bool PerformEffect(
          CombatStats stats,
          IUnit caster,
          TargetSlotInfo[] targets,
          bool areTargetSlots,
          int entryVariable,
          out int exitAmount)
        {
            exitAmount = 0;

            StatusEffectInfoSO effectInfo;
            stats.statusEffectDataBase.TryGetValue((StatusEffectType)456789, out effectInfo);




            for (int index = 0; index < targets.Length; ++index)
            {
                if (targets[index].HasUnit)
                {
                    int amount = entryVariable + UnityEngine.Random.Range(0, 3);
                    if (amount > 0)
                    {
                        //Debug.Log("above one");
                        IStatusEffect powerStatusEffect = new Power_StatusEffect(amount);


                        IStatusEffector effector = targets[index].Unit as IStatusEffector;
                        bool hasItAlready = false;
                        int thisIndex = 999;
                        for (int i = 0; i < effector.StatusEffects.Count; i++)
                        {
                            if (effector.StatusEffects[i].EffectType == powerStatusEffect.EffectType)
                            {
                                thisIndex = i;
                                hasItAlready = true;
                                //Debug.Log("has it already");
                            }
                        }
                        if (hasItAlready)
                        {
                            ConstructorInfo[] constructors = effector.StatusEffects[thisIndex].GetType().GetConstructors();
                            foreach (ConstructorInfo constructor in constructors)
                            {
                                if (constructor.GetParameters().Length == 2)
                                {
                                    powerStatusEffect = (IStatusEffect)Activator.CreateInstance(effector.StatusEffects[thisIndex].GetType(), amount, 0);
                                    //Debug.Log("instance set");
                                }
                            }
                        }

                        powerStatusEffect.SetEffectInformation(effectInfo);
                        //Debug.Log("info set");
                        if (targets[index].Unit.ApplyStatusEffect((IStatusEffect)powerStatusEffect, amount))
                            exitAmount += amount;
                        //Debug.Log("done");
                    }
                }
            }

            return exitAmount > 0;
        }
    }
    public class ApplyPowerRangePlusThreeEffect : EffectSO
    {
        public override bool PerformEffect(
          CombatStats stats,
          IUnit caster,
          TargetSlotInfo[] targets,
          bool areTargetSlots,
          int entryVariable,
          out int exitAmount)
        {
            exitAmount = 0;

            StatusEffectInfoSO effectInfo;
            stats.statusEffectDataBase.TryGetValue((StatusEffectType)456789, out effectInfo);




            for (int index = 0; index < targets.Length; ++index)
            {
                if (targets[index].HasUnit)
                {
                    int amount = entryVariable + UnityEngine.Random.Range(0, 4);
                    if (amount > 0)
                    {
                        //Debug.Log("above one");
                        IStatusEffect powerStatusEffect = new Power_StatusEffect(amount);


                        IStatusEffector effector = targets[index].Unit as IStatusEffector;
                        bool hasItAlready = false;
                        int thisIndex = 999;
                        for (int i = 0; i < effector.StatusEffects.Count; i++)
                        {
                            if (effector.StatusEffects[i].EffectType == powerStatusEffect.EffectType)
                            {
                                thisIndex = i;
                                hasItAlready = true;
                                //Debug.Log("has it already");
                            }
                        }
                        if (hasItAlready)
                        {
                            ConstructorInfo[] constructors = effector.StatusEffects[thisIndex].GetType().GetConstructors();
                            foreach (ConstructorInfo constructor in constructors)
                            {
                                if (constructor.GetParameters().Length == 2)
                                {
                                    powerStatusEffect = (IStatusEffect)Activator.CreateInstance(effector.StatusEffects[thisIndex].GetType(), amount, 0);
                                    //Debug.Log("instance set");
                                }
                            }
                        }

                        powerStatusEffect.SetEffectInformation(effectInfo);
                        //Debug.Log("info set");
                        if (targets[index].Unit.ApplyStatusEffect((IStatusEffect)powerStatusEffect, amount))
                            exitAmount += amount;
                        //Debug.Log("done");
                    }
                }
            }

            return exitAmount > 0;
        }
    }
}
