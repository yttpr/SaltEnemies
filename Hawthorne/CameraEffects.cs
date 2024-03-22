using BrutalAPI;
using ChillyBonezMod;
using Hawthorne.gay;
using MFoolModOne;
using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.Reflection;
using TairbazFools.Effects;
using THE_DEAD;
using UnityEngine;
using static UnityEngine.UI.CanvasScaler;

namespace Hawthorne
{
    public static class CameraEffects
    {
        public class PassiveHolder
        {
            public List<PassiveAbilityTypes> types;
            CharacterCombat chara;
            public PassiveHolder(BasePassiveAbilitySO[] passi, CharacterCombat chara = null)
            {
                this.types = new List<PassiveAbilityTypes>();
                foreach (BasePassiveAbilitySO pas in passi) types.Add(pas.type);
                if (chara != null) this.chara = chara;
            }
            public bool ContainsPassiveAbility(PassiveAbilityTypes ty) => types.Contains(ty);
            public void Add(PassiveAbilityTypes ty) => types.Add(ty);
            public PassiveHolder randomOne()
            {
                if (types.Count <= 0) return this;
                PassiveAbilityTypes t = types[UnityEngine.Random.Range(0, types.Count)];
                types = new List<PassiveAbilityTypes>() { t };
                return this;
            }
            public PassiveHolder reduce(EnemyCombat to)
            {
                List<PassiveAbilityTypes> lit = new List<PassiveAbilityTypes>();
                foreach (PassiveAbilityTypes ty in types) if (!to.ContainsPassiveAbility(ty)) lit.Add(ty);
                types = lit;
                return this;
            }
        }
        public static void Ooga()
        {
            UnityEngine.Debug.Log("Booga");
        }
        public static void Add()
        {
            IDetour IDetourThingy = (IDetour)new Hook((MethodBase)typeof(EnemyCombatUIInfo).GetMethod("RemoveAttack", ~BindingFlags.Default), typeof(CameraEffects).GetMethod("RemoveAttack", ~BindingFlags.Default));
        }

        public static void AddPassives(CharacterCombat character, PassiveHolder passives, EnemyCombat enemy, bool OnlyHasnt = false, bool pickRandom = false)
        {
            if (OnlyHasnt) passives = passives.reduce(enemy);
            if (pickRandom) passives = passives.randomOne();
            
            if (passives.ContainsPassiveAbility(PassiveAbilityTypes.Focus))
            {
                enemy.AddPassiveAbility(LoadedAssetsHandler.GetCharcater("Nowak_CH").passiveAbilities[0]);
            }
            if (passives.ContainsPassiveAbility(PassiveAbilityTypes.Skittish))
            {
                enemy.AddPassiveAbility(Passives.Skittish);
            }
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)386742))
            {
                PerformEffectPassiveAbility instance1 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                instance1._passiveName = "Skittish (2)";
                instance1.passiveIcon = Passives.Skittish.passiveIcon;
                instance1.type = (PassiveAbilityTypes)386742;
                instance1._enemyDescription = "Upon performing an ability this enemy will move to the Left or Right 2 times.";
                instance1._characterDescription = "Upon performing an ability this party member will move to the Left or Right 2 times.";
                instance1.effects = ExtensionMethods.ToEffectInfoArray(new Effect[2]
                {
        new Effect((EffectSO) ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, new IntentType?(), Slots.Self),
        new Effect((EffectSO) ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, new IntentType?(), Slots.Self)
                });
                instance1._triggerOn = new TriggerCalls[1]
                {
        TriggerCalls.OnAbilityUsed
                };
                enemy.AddPassiveAbility(instance1);
            }//Skittish (2)
            if (passives.ContainsPassiveAbility(PassiveAbilityTypes.Slippery))
            {
                enemy.AddPassiveAbility(Passives.Slippery);
            }
            if (passives.ContainsPassiveAbility(PassiveAbilityTypes.Infantile))
            {
                enemy.AddPassiveAbility(LoadedAssetsHandler.GetEnemy("Flarblet_EN").passiveAbilities[0]);
            }
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)8813))
            {
                enemy.AddPassiveAbility(LoadedAssetsHandler.GetEnemy("Flarblet_EN").passiveAbilities[0]);
            }//Infantile
            if (passives.ContainsPassiveAbility(PassiveAbilityTypes.Parental))
            {
                if (Check.Half) enemy.AddPassiveAbility(LoadedAssetsHandler.GetEnemy("Flarb_EN").passiveAbilities[1]);
                else enemy.AddPassiveAbility(LoadedAssetsHandler.GetEnemy("SkinningHomunculus_EN").passiveAbilities[0]);
            }
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)9924))
            {
                if (Check.Half) enemy.AddPassiveAbility(LoadedAssetsHandler.GetEnemy("Flarb_EN").passiveAbilities[1]);
                else enemy.AddPassiveAbility(LoadedAssetsHandler.GetEnemy("SkinningHomunculus_EN").passiveAbilities[0]);
            }//Parental
            if (passives.ContainsPassiveAbility(PassiveAbilityTypes.Unstable))
            {
                enemy.AddPassiveAbility(Passives.Unstable);
            }
            if (passives.ContainsPassiveAbility(PassiveAbilityTypes.Constricting))
            {
                enemy.AddPassiveAbility(Passives.Constricting);
            }
            if (passives.ContainsPassiveAbility(PassiveAbilityTypes.Formless))
            {
                enemy.AddPassiveAbility(Passives.Formless);
            }
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)816482))
            {
                enemy.AddPassiveAbility(Passives.Formless);
            }//Formless
            if (passives.ContainsPassiveAbility(PassiveAbilityTypes.Pure))
            {
                enemy.AddPassiveAbility(Passives.Pure);
            }
            if (passives.ContainsPassiveAbility(PassiveAbilityTypes.Absorb))
            {
                enemy.AddPassiveAbility(Passives.Absorb);
            }
            if (passives.ContainsPassiveAbility(PassiveAbilityTypes.Forgetful))
            {
                enemy.AddPassiveAbility(Passives.Forgetful);
            }
            if (passives.ContainsPassiveAbility(PassiveAbilityTypes.Withering))
            {
                enemy.AddPassiveAbility(Passives.Withering);
            }
            if (passives.ContainsPassiveAbility(PassiveAbilityTypes.Overexert))
            {
                enemy.AddPassiveAbility(Passives.Overexert);
            }
            if (passives.ContainsPassiveAbility(PassiveAbilityTypes.MultiAttack))
            {
                bool cont = true;
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == PassiveAbilityTypes.MultiAttack)
                        for (int i = -1; i < 13; i++)
                        {
                            {
                                if (passive._passiveName.Contains(i.ToString()))
                                {
                                    enemy.AddPassiveAbility(Passi.Multiattack(i));
                                    cont = false;
                                    break;
                                }
                            }
                        }
                }
                if (cont) enemy.AddPassiveAbility(Passi.Multiattack(2));
            }
            if (passives.ContainsPassiveAbility(PassiveAbilityTypes.Obscure))
            {
                enemy.AddPassiveAbility(Passives.Obscured);
            }
            if (passives.ContainsPassiveAbility(PassiveAbilityTypes.Confusion))
            {
                enemy.AddPassiveAbility(Passives.Confusion);
            }
            if (passives.ContainsPassiveAbility(PassiveAbilityTypes.Fleeting))
            {
                enemy.AddPassiveAbility(LoadedAssetsHandler.GetEnemy("GigglingMinister_EN").passiveAbilities[1]);
            }
            if (passives.ContainsPassiveAbility(PassiveAbilityTypes.Dying))
            {
                enemy.AddPassiveAbility(Passives.Dying);
            }
            if (passives.ContainsPassiveAbility(PassiveAbilityTypes.Inanimate))
            {
                enemy.AddPassiveAbility(Passives.Inanimate);
            }
            if (passives.ContainsPassiveAbility(PassiveAbilityTypes.Inferno))
            {
                enemy.AddPassiveAbility(Passives.Inferno);
            }
            if (passives.ContainsPassiveAbility(PassiveAbilityTypes.Enfeebled))
            {
                enemy.AddPassiveAbility(Passives.Enfeebled);
            }
            if (passives.ContainsPassiveAbility(PassiveAbilityTypes.Immortal))
            {
                enemy.AddPassiveAbility(Passives.Immortal);
            }
            if (passives.ContainsPassiveAbility(PassiveAbilityTypes.TwoFaced))
            {
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == PassiveAbilityTypes.TwoFaced)
                    {
                        enemy.AddPassiveAbility(passive);
                    }
                }
            }
            if (passives.ContainsPassiveAbility(PassiveAbilityTypes.Catalyst))
            {
                enemy.AddPassiveAbility(Passives.Catalyst);
            }
            if (passives.ContainsPassiveAbility(PassiveAbilityTypes.Anchored))
            {
                enemy.AddPassiveAbility(Passives.Anchored);
            }
            if (passives.ContainsPassiveAbility(PassiveAbilityTypes.Delicate))
            {
                enemy.AddPassiveAbility(Passives.Delicate);
            }
            if (passives.ContainsPassiveAbility(PassiveAbilityTypes.Leaky))
            {
                enemy.AddPassiveAbility(Passives.Leaky);
            }
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)256781))
            {
                enemy.AddPassiveAbility(Passi.Leaky(3));
            }//Leaky (3)
            if (passives.ContainsPassiveAbility(PassiveAbilityTypes.PanicAttack))
            {
                enemy.AddPassiveAbility(LoadedAssetsHandler.GetCharcater("Arnold_CH").passiveAbilities[0]);
            }
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)443111))
            {
                CasterStoreValueSetterEffect sharpSet = ScriptableObject.CreateInstance<CasterStoreValueSetterEffect>();
                sharpSet._valueName = (UnitStoredValueNames)444441;
                PerformEffectPassiveAbility panicA = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                panicA._passiveName = "Panic Attack";
                panicA.passiveIcon = LoadedAssetsHandler.GetCharcater("Arnold_CH").passiveAbilities[0].passiveIcon;
                panicA.type = (PassiveAbilityTypes)443111;
                panicA._enemyDescription = "Upon receiving direct damage, lose all boosts to Sharp Step.";
                panicA._characterDescription = "Upon receiving direct damage, lose all boosts to Sharp Step.";
                panicA.doesPassiveTriggerInformationPanel = true;
                panicA._triggerOn = new TriggerCalls[] { TriggerCalls.OnDirectDamaged };
                panicA.effects = ExtensionMethods.ToEffectInfoArray(new Effect[] { new Effect(sharpSet, 0, null, Slots.Self) });
                enemy.AddPassiveAbility(panicA);
            }//Panic Attack
            if (passives.ContainsPassiveAbility(PassiveAbilityTypes.Transfusion))
            {
                enemy.AddPassiveAbility(Passives.Transfusion);
            }
            if (passives.ContainsPassiveAbility(PassiveAbilityTypes.Abomination))
            {
                enemy.AddPassiveAbility(LoadedAssetsHandler.GetEnemy("OneManBand_EN").passiveAbilities[2]);
            }
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)4444436))
            {
                BasePassiveAbilitySO instance1 = ScriptableObject.Instantiate(LoadedAssetsHandler.GetEnemy("OneManBand_EN").passiveAbilities[2]);
                instance1._passiveName = "Ballsy";
                instance1.type = (PassiveAbilityTypes)4444436;
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)4444436)
                        instance1.passiveIcon = passive.passiveIcon;
                }
                enemy.AddPassiveAbility(instance1);
            }//Ballsy
            if (passives.ContainsPassiveAbility(PassiveAbilityTypes.BoneSpurs))
            {
                enemy.AddPassiveAbility(LoadedAssetsHandler.GetCharcater("Fennec_CH").passiveAbilities[0]);
            }
            if (passives.ContainsPassiveAbility(PassiveAbilityTypes.Infestation))
            {
                enemy.AddPassiveAbility(LoadedAssetsHandler.GetEnemy("Keko_EN").passiveAbilities[0]);
            }
            if (passives.ContainsPassiveAbility(PassiveAbilityTypes.Masochism))
            {
                enemy.AddPassiveAbility(Passives.Masochism);
            }
            if (passives.ContainsPassiveAbility(PassiveAbilityTypes.Construct))
            {
                enemy.AddPassiveAbility(Passives.Construct);
            }
            if (passives.ContainsPassiveAbility(PassiveAbilityTypes.Cashout))
            {
                enemy.AddPassiveAbility(Passives.Cashout);
            }
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)9083))
            {
                PerformEffectPassiveAbility mucus = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                mucus._passiveName = "Cleansing Mucus";
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)9083)
                        mucus.passiveIcon = passive.passiveIcon;
                }
                mucus.type = (PassiveAbilityTypes)9083;
                mucus._enemyDescription = "Upon moving in any way, heal the Left and Right ally 1-2 health.";
                mucus._characterDescription = "Upon moving in any way, heal the Left and Right ally 1-2 health.";
                mucus.effects = ExtensionMethods.ToEffectInfoArray(new Effect[2]
                {
                        new Effect((EffectSO) ScriptableObject.CreateInstance<ExitValueSetterEffect>(), 1, new IntentType?(), Slots.Self),
                        new Effect((EffectSO) ScriptableObject.CreateInstance<RandomHealBetweenPreviousAndEntryEffect>(), 2, new IntentType?(), Slots.Sides)
                });
                mucus._triggerOn = new TriggerCalls[1]
                {
                        TriggerCalls.OnMoved
                };
                enemy.AddPassiveAbility(mucus);
            }//CLeansing Mucus
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)9082))
            {

                StatusEffectAplicationDetectionEffectorCondition effectorCondition = new StatusEffectAplicationDetectionEffectorCondition();
                effectorCondition._statusEffectChecks = new StatusEffectType[1]
                {
                        StatusEffectType.Ruptured
                };
                StatusEffectApplicationFalseSetterPassive skin = ScriptableObject.CreateInstance<StatusEffectApplicationFalseSetterPassive>();
                skin._passiveName = "Thick Skin";
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)9082)
                        skin.passiveIcon = passive.passiveIcon;
                }
                skin.type = (PassiveAbilityTypes)9082;
                skin._enemyDescription = "This enemy is immune to Ruptured.";
                skin._characterDescription = "This party member is immune to rupture";
                skin.conditions = new EffectorConditionSO[1]
                {
                        (EffectorConditionSO) effectorCondition
                };
                skin._triggerOn = new TriggerCalls[1]
                {
                        TriggerCalls.CanApplyStatusEffect
                };
                enemy.AddPassiveAbility(skin);
            }//Thick Skin
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)8023))
            {

                CheckIsThereOverflowEffectorCondition instance4 = ScriptableObject.CreateInstance<CheckIsThereOverflowEffectorCondition>();
                instance4._overflowAmount = 1;
                instance4._isOver = false;
                GenerateColorManaEffect instance5 = ScriptableObject.CreateInstance<GenerateColorManaEffect>();
                instance5.mana = Pigments.Yellow;
                ConsumeColorManaEffect instance6 = ScriptableObject.CreateInstance<ConsumeColorManaEffect>();
                instance6.mana = Pigments.Yellow;
                PerformDoubleEffectPassiveAbility instance7 = ScriptableObject.CreateInstance<PerformDoubleEffectPassiveAbility>();
                instance7._passiveName = "Own Supply";
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)8023)
                        instance7.passiveIcon = passive.passiveIcon;
                }
                instance7.type = (PassiveAbilityTypes)8023;
                instance7._enemyDescription = "At the start of each turn, if there is no Overflow, Produce 1 Yellow pigment.\nConsume 1 Yellow Pigment at the end of each turn";
                instance7._characterDescription = "At the start of each turn, if there is no Overflow, Produce 1 Yellow pigment.\nConsume 1 Yellow Pigment at the end of each turn";
                instance7.conditions = new EffectorConditionSO[1]
                {
                        (EffectorConditionSO) instance4
                };
                instance7.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
                {
                        new Effect((EffectSO) instance5, 1, new IntentType?(), Slots.Self)
                });
                instance7._secondEffects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
                {
                        new Effect((EffectSO) instance6, 1, new IntentType?(), Slots.Self)
                });
                instance7._triggerOn = new TriggerCalls[1]
                {
                        TriggerCalls.OnTurnStart
                };
                instance7._secondTriggerOn = new TriggerCalls[1]
                {
                        TriggerCalls.OnTurnFinished
                };
                enemy.AddPassiveAbility(instance7);
            }//Own Supply
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)1339))
            {
                PerformEffectPassiveAbility instance1 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                instance1._passiveName = "Sleeper";
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)1339)
                        instance1.passiveIcon = passive.passiveIcon;
                }
                instance1.type = (PassiveAbilityTypes)1339;
                instance1._enemyDescription = "Shields on this enemy's position now block indirect damage.";
                instance1._characterDescription = "Shields on this party member's position now block indirect damage.";
                instance1.doesPassiveTriggerInformationPanel = false;
                instance1.effects = ExtensionMethods.ToEffectInfoArray(new Effect[0]);
                instance1._triggerOn = new TriggerCalls[1]
                {
                    TriggerCalls.OnBeingDamaged
                };
                enemy.AddPassiveAbility(instance1);
            }//Sleeper
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)3383))
            {
                MaxHealthThresholdEffectorCondition instance2 = ScriptableObject.CreateInstance<MaxHealthThresholdEffectorCondition>();
                instance2.healthUnderThreshold = false;
                instance2.healthThreshold = 5;
                HalveCasterMaxHealthEffect instance3 = ScriptableObject.CreateInstance<HalveCasterMaxHealthEffect>();
                instance3._increase = false;
                PerformEffectWithFalseSetterPassiveAbility instance4 = ScriptableObject.CreateInstance<PerformEffectWithFalseSetterPassiveAbility>();
                FullHealEffect instance6 = ScriptableObject.CreateInstance<FullHealEffect>();
                instance6._directHeal = false;
                instance4._passiveName = "Life Support";
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)3383)
                        instance4.passiveIcon = passive.passiveIcon;
                }
                instance4.type = (PassiveAbilityTypes)3383;
                instance4._enemyDescription = "Upon this enemy reaching 0 health, halve their max hp, fully heal them, and cure all status effects. Does not trigger if Max health is 5 or below.";
                instance4._characterDescription = "Upon this party member reaching 0 health, halve their max hp, fully heal them, and cure all status effects. Does not trigger if Max health is 5 or below. The max health decrease does not stay in between battles";
                instance4.conditions = new EffectorConditionSO[1]
                {
                        (EffectorConditionSO) instance2
                };
                instance4.effects = ExtensionMethods.ToEffectInfoArray(new Effect[3]
                {
                        new Effect((EffectSO) ScriptableObject.CreateInstance<RemoveAllStatusEffectsEffect>(), 1, new IntentType?(), Slots.Self),
                        new Effect((EffectSO) instance6, 1, new IntentType?(), Slots.Self),
                        new Effect((EffectSO) instance3, 1, new IntentType?(), Slots.Self)
                });
                instance4._triggerOn = new TriggerCalls[1]
                {
                        TriggerCalls.CanDie
                };
                enemy.AddPassiveAbility(instance4);
            }//Life Support
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)45994))
            {
                PerformEffectPassiveAbility instance1 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                instance1._passiveName = "Bloodlust";
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)45994)
                        instance1.passiveIcon = passive.passiveIcon;
                }
                instance1.type = (PassiveAbilityTypes)45994;
                instance1._enemyDescription = "Upon this enemy receiving direct damage they will perform one of their abilities in retaliation.";
                instance1._characterDescription = "Upon this party member receiving direct damage they will perform one of their abilities in retaliation.";
                instance1.doesPassiveTriggerInformationPanel = true;
                PerformRandomAbilityEnemyEffect instance2 = ScriptableObject.CreateInstance<PerformRandomAbilityEnemyEffect>();
                instance1.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
                {
                        new Effect((EffectSO) instance2, 1, new IntentType?(), Slots.Self)
                });
                instance1._triggerOn = new TriggerCalls[1]
                {
                        TriggerCalls.OnDirectDamaged
                };
                enemy.AddPassiveAbility(instance1);
            }//Bloodlust
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)79994))
            {
                DoubleDamageInFirePassive instance1 = ScriptableObject.CreateInstance<DoubleDamageInFirePassive>();
                instance1._passiveName = "Pyrophilia";
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)79994)
                        instance1.passiveIcon = passive.passiveIcon;
                }
                instance1.type = (PassiveAbilityTypes)79994;
                instance1._enemyDescription = "All direct damage this enemy deals is doubled while standing in fire.";
                instance1._characterDescription = "All direct damage this party member deals is doubled while standing in fire.";
                instance1.doesPassiveTriggerInformationPanel = false;
                instance1._triggerOn = new TriggerCalls[1]
                {
                        TriggerCalls.OnWillApplyDamage
                };
                enemy.AddPassiveAbility(instance1);
            }//Pyrophilia
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)666555))
            {
                PerformEffectImmediatePassiveAbility WitchSave = ScriptableObject.CreateInstance<PerformEffectImmediatePassiveAbility>();
                WitchSave._passiveName = "Desperate";
                WitchSave.passiveIcon = ResourceLoader.LoadSprite("WitchPassiveDetermination", 32);
                WitchSave.type = (PassiveAbilityTypes)666555;
                WitchSave._characterDescription = "On taking any damage, 33% chance to apply 3 Determined to self.";
                WitchSave._enemyDescription = WitchSave._characterDescription;
                PercentageEffectorCondition Witch20P = ScriptableObject.CreateInstance<PercentageEffectorCondition>();
                Witch20P.triggerPercentage = 33;
                WitchSave.conditions = new EffectorConditionSO[1]
                {
                        Witch20P
                };
                WitchSave.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
                {
                        new Effect(ScriptableObject.CreateInstance<ApplyDeterminedEffect>(), 3, new IntentType?(), Slots.Self)
                });
                WitchSave._triggerOn = new TriggerCalls[1]
                {
                        TriggerCalls.OnBeingDamaged
                };
                enemy.AddPassiveAbility(WitchSave);
            }//Desperate
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)456654))
            {
                PerformEffectPassiveAbility instance8 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                instance8._passiveName = "Battle Junkie";
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)456654)
                        instance8.passiveIcon = passive.passiveIcon;
                }
                instance8.type = (PassiveAbilityTypes)456654;
                instance8._enemyDescription = "Taking or dealing any damage has a 15% chance to apply 1 Power to this enemy.";
                instance8._characterDescription = "Taking or dealing any damage has a 15% chance to apply 1 Power to this character.";
                PercentageEffectorCondition instance9 = ScriptableObject.CreateInstance<PercentageEffectorCondition>();
                instance9.triggerPercentage = 15;
                instance8.conditions = new EffectorConditionSO[1]
                {
                        (EffectorConditionSO) instance9
                };
                instance8.effects = ExtensionMethods.ToEffectInfoArray(new Effect[2]
                {
                        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyPowerEffect>(), 1, new IntentType?(), Slots.Self),
                        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyPowerEffect>(), 1, new IntentType?(), Slots.Front, (EffectConditionSO) Conditions.Chance(0))
                });
                instance8._triggerOn = new TriggerCalls[2]
                {
                        TriggerCalls.OnBeingDamaged,
                        TriggerCalls.OnWillApplyDamage
                };
                enemy.AddPassiveAbility(instance8);
            }//Battle Junkie
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)6786))
            {
                PerformEffectPassiveAbility instance2 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                instance2._passiveName = "Devoted";
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)6786)
                        instance2.passiveIcon = passive.passiveIcon;
                }
                instance2.type = (PassiveAbilityTypes)6786;
                instance2._characterDescription = "Whenever this party member is directly healed, they apply 3 Rupture to themself.";
                instance2._enemyDescription = "Whenever this enemy is directly healed, they apply 3 Rupture to themself.";
                instance2.doesPassiveTriggerInformationPanel = false;
                instance2._triggerOn = new TriggerCalls[1]
                {
                        TriggerCalls.OnDirectHealed
                };
                instance2.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
                {
                        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 3, new IntentType?(), Slots.Self)
                });
                enemy.AddPassiveAbility(instance2);
            }//Devoted
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)80003))
            {
                PerformEffectPassiveAbility instance2 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                instance2._passiveName = "Picky";
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)80003)
                        instance2.passiveIcon = passive.passiveIcon;
                }
                instance2.type = (PassiveAbilityTypes)80003;
                instance2._enemyDescription = "On using the Wrong Pigment, instantly kill this enemy.";
                instance2._characterDescription = "On using the Wrong Pigment, instantly kill this party member.";
                instance2.doesPassiveTriggerInformationPanel = true;
                DirectDeathEffect instance3 = ScriptableObject.CreateInstance<DirectDeathEffect>();
                instance2.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
                {
                        new Effect((EffectSO) instance3, 1, new IntentType?(), Slots.Self)
                });
                instance2._triggerOn = new TriggerCalls[1]
                {
                        TriggerCalls.OnWillReceiveCostDamage
                };
                enemy.AddPassiveAbility(instance2);
            }//Picky
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)78332))
            {
                PerformEffectPassiveAbility instance46 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                instance46._passiveName = "Hemochromia";
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)78332)
                        instance46.passiveIcon = passive.passiveIcon;
                }
                instance46.type = (PassiveAbilityTypes)78332;
                instance46._enemyDescription = "Upon receiving any kind of damage, randomize this enemy's health colour.";
                instance46._characterDescription = "Upon receiving any kind of damage, randomize this party member's health colour.";
                ChangeToRandomHealthColorEffect instance47 = ScriptableObject.CreateInstance<ChangeToRandomHealthColorEffect>();
                instance47._healthColors = new ManaColorSO[4]
                {
                        Pigments.Blue,
                        Pigments.Red,
                        Pigments.Yellow,
                        Pigments.Purple
                };
                instance46.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
                {
                        new Effect((EffectSO) instance47, 1, new IntentType?(), Slots.Self)
                });
                instance46._triggerOn = new TriggerCalls[1]
                {
                        TriggerCalls.OnDamaged
                };
                enemy.AddPassiveAbility(instance46);
            }//Hemochromia
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)44733))
            {
                PerformEffectPassiveAbility instance19 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                instance19._passiveName = "Ravenous";
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)44733)
                        instance19.passiveIcon = passive.passiveIcon;
                }
                instance19.type = (PassiveAbilityTypes)44733;
                instance19._enemyDescription = "Whenever this enemy takes damage, they will consume one random pigment.";
                instance19._characterDescription = "Whenever this party member takes damage, they will consume one random pigment.";
                ConsumeRandomManaEffect instance20 = ScriptableObject.CreateInstance<ConsumeRandomManaEffect>();
                instance19.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
                {
                        new Effect((EffectSO) instance20, 1, new IntentType?(), Slots.Self)
                });
                instance19._triggerOn = new TriggerCalls[1]
                {
                        TriggerCalls.OnDamaged
                };
                enemy.AddPassiveAbility(instance19);
            }//Ravenous
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)64738))
            {
                StatusEffectAplicationDetectionEffectorCondition effectorCondition = new StatusEffectAplicationDetectionEffectorCondition();
                effectorCondition._statusEffectChecks = new StatusEffectType[1]
                {
                        StatusEffectType.Gutted
                };
                StatusEffectApplicationFalseSetterPassive instance24 = ScriptableObject.CreateInstance<StatusEffectApplicationFalseSetterPassive>();
                instance24._passiveName = "Hollow";
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)64738)
                        instance24.passiveIcon = passive.passiveIcon;
                }
                instance24.type = (PassiveAbilityTypes)64738;
                instance24._enemyDescription = "This enemy is immune to Gutted.";
                instance24._characterDescription = "This party member is immune to Gutted";
                instance24.conditions = new EffectorConditionSO[1]
                {
                        (EffectorConditionSO) effectorCondition
                };
                instance24._triggerOn = new TriggerCalls[1]
                {
                        TriggerCalls.CanApplyStatusEffect
                };
                enemy.AddPassiveAbility(instance24);
            }//Hollow
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)59044))
            {
                PerformEffectPassiveAbility instance29 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                instance29._passiveName = "Reaper Touch";
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)59044)
                        instance29.passiveIcon = passive.passiveIcon;
                }
                instance29.type = (PassiveAbilityTypes)59044;
                instance29._enemyDescription = "Upon taking direct damage, this enemy will apply 1 frail to the opposing party member.";
                instance29._characterDescription = "Upon taking direct damage, this party member will apply 1 frail to the Opposing Enemy";
                ApplyFrailEffect instance30 = ScriptableObject.CreateInstance<ApplyFrailEffect>();
                instance29.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
                {
                        new Effect((EffectSO) instance30, 2, new IntentType?(), Slots.Front)
                });
                instance29._triggerOn = new TriggerCalls[1]
                {
                        TriggerCalls.OnDirectDamaged
                };
                enemy.AddPassiveAbility(instance29);
            }//Reaper Touch
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)98111))
            {
                PerformEffectPassiveAbility instance44 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                instance44._passiveName = "Purist";
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)98111)
                        instance44.passiveIcon = passive.passiveIcon;
                }
                instance44.type = (PassiveAbilityTypes)98111;
                instance44._enemyDescription = "Upon using any wrong pigment, this enemy will instantly die.";
                instance44._characterDescription = "Upon using any wrong pigment, this party member will instantly die.";
                DirectDeathEffect instance45 = ScriptableObject.CreateInstance<DirectDeathEffect>();
                instance44.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
                {
                        new Effect((EffectSO) instance45, 1, new IntentType?(), Slots.Self)
                });
                instance44._triggerOn = new TriggerCalls[1]
                {
                        TriggerCalls.OnWillReceiveCostDamage
                };
                enemy.AddPassiveAbility(instance44);
            }//Purist
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)764687))
            {
                CasterStoreValueCheckEffect instance20 = ScriptableObject.CreateInstance<CasterStoreValueCheckEffect>();
                instance20._valueName = (UnitStoredValueNames)92847;
                RupturedDamageEffect instance21 = ScriptableObject.CreateInstance<RupturedDamageEffect>();
                instance21._addPreviousExitValue = true;
                PerformEffectPassiveAbility instance22 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                instance22._passiveName = "Spikes (5)";
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)764687)
                        instance22.passiveIcon = passive.passiveIcon;
                }
                instance22.type = (PassiveAbilityTypes)764687;
                instance22._enemyDescription = "Upon this enemy taking direct damage, deal Ruptured damage to the opposing party member equal to this enemy's spikes.";
                instance22._characterDescription = "Upon this party member taking direct damage, Deal ruptured damage to the opposing enemy equal to this party member's spikes.";
                instance22.specialStoredValue = (UnitStoredValueNames)92847;
                instance22.effects = ExtensionMethods.ToEffectInfoArray(new Effect[2]
                {
                        new Effect((EffectSO) instance20, 1, new IntentType?(), Slots.Self),
                        new Effect((EffectSO) instance21, 5, new IntentType?(), Slots.Front)
                });
                instance22._triggerOn = new TriggerCalls[1]
                {
                        TriggerCalls.OnDirectDamaged
                };
                enemy.AddPassiveAbility(instance22);
            }//Spikes
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)22323))
            {
                RealFragilePassiveAbility Fragile = ScriptableObject.CreateInstance<RealFragilePassiveAbility>();
                Fragile._passiveName = "Tempered";
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)22323)
                        Fragile.passiveIcon = passive.passiveIcon;
                }
                Fragile.type = (PassiveAbilityTypes)22323;
                Fragile._enemyDescription = "All damage is reduced to 1. All healing is negated.";
                Fragile._characterDescription = "All damage is reduced to 1. All healing is negated.";
                Fragile.doesPassiveTriggerInformationPanel = false;
                Fragile._triggerOn = new TriggerCalls[] { TriggerCalls.OnBeingDamaged, TriggerCalls.CanHeal };
                enemy.AddPassiveAbility(Fragile);
            }//Tempered
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)557))
            {
                DamageEffect instance1 = ScriptableObject.CreateInstance<DamageEffect>();
                instance1._indirect = true;
                PerformEffectPassiveAbility instance13 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                instance13._passiveName = "Tortured";
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)557)
                        instance13.passiveIcon = passive.passiveIcon;
                }
                instance13.type = (PassiveAbilityTypes)557;
                instance13._enemyDescription = "At the end of the turn, deal 2 damage to this enemy.";
                instance13._characterDescription = "At the end of the turn, deal 2 damage to this party member.";
                instance13.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
                {
                        new Effect((EffectSO) instance1, 2, new IntentType?(IntentType.Damage_1_2), Slots.Self)
                });
                instance13._triggerOn = new TriggerCalls[1]
                {
                        TriggerCalls.OnTurnFinished
                };
                enemy.AddPassiveAbility(instance13);
            }//Tortured
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)562))
            {
                PerformEffectPassiveAbility instance2 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                instance2._passiveName = "Intimidating";
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)562)
                        instance2.passiveIcon = passive.passiveIcon;
                }
                instance2.type = (PassiveAbilityTypes)562;
                instance2._enemyDescription = "When performing an action or moving there's a 5% chance to apply 1 Stunned on the opposing party member.";
                instance2._characterDescription = "When performing an action or moving there's a 5% chance to cancel an action from the Opposing enemy.";
                instance2.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
                {
                        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyStunnedEffect>(), 1, new IntentType?(), Slots.Front, (EffectConditionSO) Conditions.Chance(5))
                });
                instance2._triggerOn = new TriggerCalls[]
                {
                        TriggerCalls.OnAbilityUsed
                };
                enemy.AddPassiveAbility(instance2);
            }//Intimidating
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)276251))
            {
                PerformEffectPassiveAbility instance = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                instance._passiveName = "Rosey Tears";
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)276251)
                        instance.passiveIcon = passive.passiveIcon;
                }
                instance.type = (PassiveAbilityTypes)276251;
                instance._enemyDescription = "This enemy heals 2 health and heals the left and right enemies 1 health at the start of every turn";
                instance._characterDescription = "This party member heals 2 health and heals the left and right allies 1 health at the start of every turn";
                instance.doesPassiveTriggerInformationPanel = true;
                instance.effects = ExtensionMethods.ToEffectInfoArray(new Effect[3]
                {
                        new Effect((EffectSO) ScriptableObject.CreateInstance<HealEffect>(), 2, new IntentType?(), Slots.Self),
                        new Effect((EffectSO) ScriptableObject.CreateInstance<HealEffect>(), 1, new IntentType?(), Slots.SlotTarget(new int[1]
                        {
                          -1
                        }, true)),
                        new Effect((EffectSO) ScriptableObject.CreateInstance<HealEffect>(), 1, new IntentType?(), Slots.SlotTarget(new int[1]
                        {
                          1
                        }, true))
                });
                instance._triggerOn = new TriggerCalls[1]
                {
                        TriggerCalls.OnTurnStart
                };
                enemy.AddPassiveAbility(instance);
            }//Rosey Tears
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)2233534))
            {
                Connection_PerformEffectPassiveAbility permaGut = ScriptableObject.CreateInstance<Connection_PerformEffectPassiveAbility>();
                permaGut._passiveName = "Torn Apart";
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)2233534)
                        permaGut.passiveIcon = passive.passiveIcon;
                }
                permaGut.type = (PassiveAbilityTypes)2233534;
                permaGut._enemyDescription = "Permanently applies Gutted to this character.";
                permaGut._characterDescription = "Permanently applies Gutted to this character.";
                permaGut.doesPassiveTriggerInformationPanel = true;
                permaGut.connectionEffects = ExtensionMethods.ToEffectInfoArray(new Effect[1] { new Effect(ScriptableObject.CreateInstance<ApplyPermanentGuttedEffect>(), 1, new IntentType?(), Slots.Self) });
                permaGut.disconnectionEffects = ExtensionMethods.ToEffectInfoArray(new Effect[1] { new Effect(ScriptableObject.CreateInstance<ExitValueSetterEffect>(), 1, new IntentType?(), Slots.Self) });
                permaGut._triggerOn = new TriggerCalls[1] { TriggerCalls.Count };
                enemy.AddPassiveAbility(permaGut);
            }//Torn Apart
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)24680))
            {
                PerformEffectPassiveAbility instance4 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                instance4._passiveName = "Treasure Hunter";
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)24680)
                        instance4.passiveIcon = passive.passiveIcon;
                }
                instance4.type = (PassiveAbilityTypes)24680;
                instance4._enemyDescription = "15% chance of producing a random treasure item at the end of combat.";
                instance4._characterDescription = "15% chance of producing a random treasure item at the end of combat.";
                PercentageEffectorCondition instance5 = ScriptableObject.CreateInstance<PercentageEffectorCondition>();
                instance5.triggerPercentage = 15;
                ExtraLootEffect instance6 = ScriptableObject.CreateInstance<ExtraLootEffect>();
                instance6._isTreasure = true;
                instance4.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
                {
                        new Effect((EffectSO) instance6, 1, new IntentType?(), Slots.Self)
                });
                instance4.conditions = new EffectorConditionSO[1]
                {
                        (EffectorConditionSO) instance5
                };
                instance4._triggerOn = new TriggerCalls[1]
                {
                        TriggerCalls.OnCombatEnd
                };
                enemy.AddPassiveAbility(instance4);
            }//Treasure Hunter
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)8193))
            {
                RealFragilePassiveAbility instance3 = ScriptableObject.CreateInstance<RealFragilePassiveAbility>();
                instance3._passiveName = "Classic";
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)8193)
                        instance3.passiveIcon = passive.passiveIcon;
                }
                instance3.type = (PassiveAbilityTypes)8193;
                instance3._enemyDescription = "All damage this enemy receives is reduced to 1.";
                instance3._characterDescription = "All damage this party member receives is reduced to 1.";
                instance3.doesPassiveTriggerInformationPanel = false;
                instance3._triggerOn = new TriggerCalls[1]
                {
        TriggerCalls.OnBeingDamaged
                };
                enemy.AddPassiveAbility(instance3);
            }//Classic
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)13579))
            {
                PerformEffectPassiveAbility instance7 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                instance7._passiveName = "Retribution";
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)13579)
                        instance7.passiveIcon = passive.passiveIcon;
                }
                instance7.type = (PassiveAbilityTypes)13579;
                instance7._enemyDescription = "If damaged, this party member will apply 1 random negative status effect to all party members OR 1 random positive status effect to all enemies.";
                instance7._characterDescription = "If damaged, this party member will apply 1 random negative status effect to all enemies OR 1 random positive status effect to all allies. ";
                instance7.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
                {
        new Effect((EffectSO) ScriptableObject.CreateInstance<RandomEffectsRandomSideEffect>(), 1, new IntentType?(), Slots.Self)
                });
                instance7._triggerOn = new TriggerCalls[1]
                {
        TriggerCalls.OnBeingDamaged
                };
                enemy.AddPassiveAbility(instance7);
            }//Retribution
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)13581))
            {
                PerformEffectPassiveAbility instance8 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                instance8._passiveName = "Tenacity";
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)13581)
                        instance8.passiveIcon = passive.passiveIcon;
                }
                instance8.type = (PassiveAbilityTypes)13581;
                instance8._enemyDescription = "This enemy recovers 1 health at the start of every turn.";
                instance8._characterDescription = "This party member recovers 1 health at the start of every turn.";
                instance8.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
                {
        new Effect((EffectSO) ScriptableObject.CreateInstance<HealEffect>(), 1, new IntentType?(), Slots.Self)
                });
                instance8._triggerOn = new TriggerCalls[1]
                {
        TriggerCalls.OnTurnStart
                };
                enemy.AddPassiveAbility(instance8);
            }//Tenacity
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)45454))
            {
                PerformEffectPassiveAbility instance1 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                instance1._passiveName = "Unbreakable";
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)45454)
                        instance1.passiveIcon = passive.passiveIcon;
                }
                instance1.type = (PassiveAbilityTypes)45454;
                instance1._enemyDescription = "Shields on this enemy's position do not decay over time.";
                instance1._characterDescription = "Shields on this party member's position do not decay over time.";
                instance1._triggerOn = new TriggerCalls[1]
                {
                        TriggerCalls.Count
                };
                enemy.AddPassiveAbility(instance1);
            }//Unreakable
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)7673))
            {
                Connection_PerformEffectPassiveAbility permaGut = ScriptableObject.CreateInstance<Connection_PerformEffectPassiveAbility>();
                permaGut._passiveName = "Enruptured";
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)7673)
                        permaGut.passiveIcon = passive.passiveIcon;
                }
                permaGut.type = (PassiveAbilityTypes)7673;
                permaGut._enemyDescription = "Permanently applies Ruptured to this character.";
                permaGut._characterDescription = "Permanently applies Ruptured to this character.";
                permaGut.doesPassiveTriggerInformationPanel = true;
                permaGut.connectionEffects = ExtensionMethods.ToEffectInfoArray(new Effect[1] { new Effect(ScriptableObject.CreateInstance<ApplyPermanentRupturedEffect>(), 1, new IntentType?(), Slots.Self) });
                permaGut.disconnectionEffects = new EffectInfo[0];
                permaGut._triggerOn = new TriggerCalls[1] { TriggerCalls.Count };
                enemy.AddPassiveAbility(permaGut);
            }//Enruptured
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)8773))
            {
                BasePassiveAbilitySO source = null;
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)8773)
                        source = passive;
                }
                if (source != null)
                {
                    BasePassiveAbilitySO newer = ScriptableObject.Instantiate(source);
                    newer._passiveName = "Copycat";
                    newer._enemyDescription = "When an enemy or party member gains a status effect, this enemy also gains the same amount.";
                    newer._characterDescription = "When an ally or enemy gains a status, this party member also gains the same amount.";
                    enemy.AddPassiveAbility(newer);
                }
            }//Copycat
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)444440))
            {
                PerformEffectPassiveAbility hexEd = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                hexEd._passiveName = "Hex";
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)444440)
                        hexEd.passiveIcon = passive.passiveIcon;
                }
                hexEd.type = (PassiveAbilityTypes)444440;
                hexEd._enemyDescription = "Upon killing, apply Hexed to self.";
                hexEd._characterDescription = "Upon killing, apply Hexed to self.";
                hexEd.doesPassiveTriggerInformationPanel = true;
                hexEd._triggerOn = new TriggerCalls[1] { TriggerCalls.OnKill };
                hexEd.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1] { new Effect(ScriptableObject.CreateInstance<ApplyHexedEffect>(), 1, (IntentType)444440, Slots.Self) });

                enemy.AddPassiveAbility(hexEd);
            }//Hex
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)4444444))
            {
                DirectHealLessPassiveAbility UnPicky = ScriptableObject.CreateInstance<DirectHealLessPassiveAbility>();
                UnPicky._passiveName = "Malnourished";
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)4444444)
                        UnPicky.passiveIcon = passive.passiveIcon;
                }
                UnPicky.type = (PassiveAbilityTypes)4444444;
                UnPicky._enemyDescription = "All direct healing to this enemy is quartered.";
                UnPicky._characterDescription = "All direct healing to this character is quartered.";
                UnPicky.doesPassiveTriggerInformationPanel = false;
                UnPicky._triggerOn = new TriggerCalls[2] { TriggerCalls.CanHeal, TriggerCalls.OnBeingHealed };
                enemy.AddPassiveAbility(UnPicky);
            }//Malnourished
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)444441))
            {
                DamageByStoredValueEffect sharpStepHit = ScriptableObject.CreateInstance<DamageByStoredValueEffect>();
                sharpStepHit._valueName = (UnitStoredValueNames)444441;
                sharpStepHit._indirect = true;
                PerformEffectPassiveAbility sharpStep = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                sharpStep._passiveName = "Sharp Step (2)";
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)444441)
                        sharpStep.passiveIcon = passive.passiveIcon;
                }
                sharpStep.type = (PassiveAbilityTypes)444441;
                sharpStep._enemyDescription = "Upon moving, deal a specified amount of damage to the opposing party member.";
                sharpStep._characterDescription = "Upon moving, deal a specified amount of damage to the opposing enemy.";
                sharpStep.doesPassiveTriggerInformationPanel = true;
                sharpStep.specialStoredValue = (UnitStoredValueNames)444441;
                sharpStep._triggerOn = new TriggerCalls[1] { TriggerCalls.OnMoved };
                sharpStep.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1] { new Effect(sharpStepHit, 2, new IntentType?(), Slots.Front) });
                enemy.AddPassiveAbility(sharpStep);
            }//Sharp Step
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)36820))
            {
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)36820 && passive._passiveName == "Toxic")
                    {
                        PerformEffectPassiveAbility instance1 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                        instance1._passiveName = "Toxic";
                        instance1.passiveIcon = passive.passiveIcon;
                        instance1.type = (PassiveAbilityTypes)36820;
                        instance1._enemyDescription = "Deal 5 Indirect damage to the opposing space upon performing an action";
                        instance1._characterDescription = "Deal 5 Indirect damage to the opposing space upon performing an action";
                        instance1.doesPassiveTriggerInformationPanel = true;
                        DamageEffect instance2 = ScriptableObject.CreateInstance<DamageEffect>();
                        instance2._indirect = true;
                        instance1.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
                        {
                        new Effect((EffectSO) instance2, 5, new IntentType?(), Slots.Front)
                        });
                        instance1._triggerOn = new TriggerCalls[1]
                        {
                        TriggerCalls.OnAbilityUsed
                        };
                        enemy.AddPassiveAbility(instance1);
                    }
                }
            }//Toxic
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)36822))
            {
                PerformEffectPassiveAbility instance1 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                instance1._passiveName = "Unjust";
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)36822)
                        instance1.passiveIcon = passive.passiveIcon;
                }
                instance1.type = (PassiveAbilityTypes)36822;
                instance1._enemyDescription = "When this party member is damaged, heal 3 health to Left and Right allies";
                instance1._characterDescription = "When this party member is damaged, heal 3 health to Left and Right allies";
                instance1.doesPassiveTriggerInformationPanel = true;
                instance1.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
                {
                        new Effect((EffectSO) ScriptableObject.CreateInstance<HealEffect>(), 3, new IntentType?(), Slots.Sides)
                });
                instance1._triggerOn = new TriggerCalls[1]
                {
                        TriggerCalls.OnBeingDamaged
                };
                enemy.AddPassiveAbility(instance1);
            }//Unjust
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)36823))
            {
                PerformEffectPassiveAbility instance2 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                instance2._passiveName = "Infernal";
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)36823)
                        instance2.passiveIcon = passive.passiveIcon;
                }
                instance2.type = (PassiveAbilityTypes)36823;
                instance2._enemyDescription = "At the start of the turn, apply 1 Fire to self and opposing spaces";
                instance2._characterDescription = "At the start of the turn, apply 1 Fire to self and opposing spaces";
                instance2.doesPassiveTriggerInformationPanel = true;
                instance2.effects = ExtensionMethods.ToEffectInfoArray(new Effect[2]
                {
                        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), 1, new IntentType?(), Slots.Self),
                        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), 1, new IntentType?(), Slots.Front)
                });
                instance2._triggerOn = new TriggerCalls[1]
                {
                        TriggerCalls.OnTurnStart
                };
                enemy.AddPassiveAbility(instance2);
            }//Infernal
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)36820))
            {
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)36820 && passive._passiveName == "Greased")
                    {
                        PerformEffectPassiveAbility instance1 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                        instance1._passiveName = "Greased";
                        instance1.passiveIcon = passive.passiveIcon;
                        instance1.type = (PassiveAbilityTypes)36820;
                        instance1._enemyDescription = "Upon recieving any damage, move the opposing party member Left or Right";
                        instance1._characterDescription = "Upon recieving any damage, move the opposing enemy Left or Right";
                        instance1.doesPassiveTriggerInformationPanel = true;
                        SwapToSidesEffect instance2 = ScriptableObject.CreateInstance<SwapToSidesEffect>();
                        instance1.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
                        {
                        new Effect((EffectSO) instance2, 1, new IntentType?(), Slots.Front)
                        });
                        instance1._triggerOn = new TriggerCalls[1]
                        {
                        TriggerCalls.OnBeingDamaged
                        };
                        enemy.AddPassiveAbility(instance1);
                    }
                }
            }//Greased
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)36821))
            {
                PerformEffectPassiveAbility instance3 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                instance3._passiveName = "Expulsion";
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)36821)
                        instance3.passiveIcon = passive.passiveIcon;
                }
                instance3.type = (PassiveAbilityTypes)36821;
                instance3._enemyDescription = "Upon Taking Wrong Pigment damage, apply 1 Oil-Slicked to self and opposing party member.";
                instance3._characterDescription = "Upon Taking Wrong Pigment damage, apply 1 Oil-Slicked to self and opposing enemy.";
                instance3.doesPassiveTriggerInformationPanel = true;
                instance3.effects = ExtensionMethods.ToEffectInfoArray(new Effect[2]
                {
                        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyOilSlickedEffect>(), 1, new IntentType?(), Slots.Front),
                        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyOilSlickedEffect>(), 1, new IntentType?(), Slots.Self)
                });
                instance3._triggerOn = new TriggerCalls[1]
                {
                        TriggerCalls.OnWillReceiveCostDamage
                };
                enemy.AddPassiveAbility(instance3);
            }//Expulsion
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)6669))
            {
                PerformEffectPassiveAbility instance1 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                instance1._passiveName = "Accursed Existence";
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)6669)
                        instance1.passiveIcon = passive.passiveIcon;
                }
                instance1.type = (PassiveAbilityTypes)6669;
                instance1._enemyDescription = "This enemy is eternally cursed at the start of every turn.";
                instance1._characterDescription = "This party member is eternally cursed at the start of every turn.";
                instance1.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
                {
                        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyCursedEffect>(), 1, new IntentType?(), Slots.Self)
                });
                instance1._triggerOn = new TriggerCalls[1]
                {
                        TriggerCalls.OnTurnStart
                };
                enemy.AddPassiveAbility(instance1);
            }//Accursed Existence
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)2122))
            {
                PerformEffectPassiveAbility instance1 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                instance1._passiveName = "Sporogenesis";
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)2122)
                        instance1.passiveIcon = passive.passiveIcon;
                }
                instance1.type = (PassiveAbilityTypes)2122;
                instance1._enemyDescription = "This enemy releases a cloud of questionably healthy spores at the end of every turn, healing all allies for 1-3 HP";
                instance1._characterDescription = "This party member releases a cloud of questionably healthy spores at the start of every turn, healing all allies for 1-3 HP";
                instance1.effects = ExtensionMethods.ToEffectInfoArray(new Effect[2]
                {
                        new Effect((EffectSO) ScriptableObject.CreateInstance<ExitValueSetterEffect>(), 1, new IntentType?(), Slots.Self),
                        new Effect((EffectSO) ScriptableObject.CreateInstance<RandomHealBetweenPreviousAndEntryEffect>(), 3, new IntentType?(), Slots.SlotTarget(new int[8]
                        {
                          -4,
                          -3,
                          -2,
                          -1,
                          1,
                          2,
                          3,
                          4
                        }, true))
                });
                instance1._triggerOn = new TriggerCalls[1]
                {
                        TriggerCalls.OnTurnStart
                };
                enemy.AddPassiveAbility(instance1);
            }//Sporogenesis
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)28379))
            {
                PerformEffectPassiveAbility instance1 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                instance1._passiveName = "Unfinished Business";
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)28379)
                        instance1.passiveIcon = passive.passiveIcon;
                }
                instance1.type = (PassiveAbilityTypes)28379;
                instance1._enemyDescription = "Upon death, summon the Ungod.";
                instance1._characterDescription = "Upon death, summon the Ungod. You failed your mission.";
                SpawnEnemyAnywhereEffect instance2 = ScriptableObject.CreateInstance<SpawnEnemyAnywhereEffect>();
                instance2.enemy = LoadedAssetsHandler.GetEnemy("Ungod_Friendly_EN");
                instance1.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
                {
                        new Effect((EffectSO) instance2, 1, new IntentType?(), Slots.Front)
                });
                instance1._triggerOn = new TriggerCalls[1]
                {
                        TriggerCalls.OnDeath
                };
                enemy.AddPassiveAbility(instance1);
            }//Unfinished Business
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)18735))
            {
                StatusEffectAplicationDetectionEffectorCondition instance1 = ScriptableObject.CreateInstance<StatusEffectAplicationDetectionEffectorCondition>();
                instance1._statusEffectChecks = new StatusEffectType[5]
                {
                        StatusEffectType.Scars,
                        StatusEffectType.Ruptured,
                        StatusEffectType.Cursed,
                        StatusEffectType.Frail,
                        StatusEffectType.OilSlicked
                };
                StatusEffectApplicationFalseSetterPassive instance2 = ScriptableObject.CreateInstance<StatusEffectApplicationFalseSetterPassive>();
                instance2._passiveName = "Pristine";
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)18735)
                        instance2.passiveIcon = passive.passiveIcon;
                }
                instance2.type = (PassiveAbilityTypes)18735;
                instance2._enemyDescription = "This enemy is immune to Scars, Ruptured, Curse, Frail and Oil-Slicked";
                instance2._characterDescription = "This party member is immune to Scars, Ruptured, Curse, Frail and Oil-Slicked";
                instance2.conditions = new EffectorConditionSO[1]
                {
                        (EffectorConditionSO) instance1
                };
                instance2._triggerOn = new TriggerCalls[1]
                {
                        TriggerCalls.CanApplyStatusEffect
                };
                enemy.AddPassiveAbility(instance2);
            }//Pristine
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)736548))
            {
                FullHealEffect instance3 = ScriptableObject.CreateInstance<FullHealEffect>();
                instance3._directHeal = false;
                DamageEffect instance4 = ScriptableObject.CreateInstance<DamageEffect>();
                instance4._indirect = true;
                PerformDoubleEffectPassiveAbility instance5 = ScriptableObject.CreateInstance<PerformDoubleEffectPassiveAbility>();
                instance5._passiveName = "Endless";
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)736548)
                        instance5.passiveIcon = passive.passiveIcon;
                }
                instance5.type = (PassiveAbilityTypes)736548;
                instance5._enemyDescription = "This Shouldn't Have Happened";
                instance5._characterDescription = "This party member will recieve 1 indirect damage at the end of each turn. Upon killing an enemy, fully and indirectly heal this party member.";
                instance5.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
                {
                        new Effect((EffectSO) instance3, 1, new IntentType?(), Slots.Self)
                });
                instance5._triggerOn = new TriggerCalls[1]
                {
                        TriggerCalls.OnKill
                };
                instance5._secondEffects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
                {
                        new Effect((EffectSO) instance4, 1, new IntentType?(), Slots.Self)
                });
                instance5._secondTriggerOn = new TriggerCalls[1]
                {
                        TriggerCalls.OnTurnFinished
                };
                instance5._secondDoesPerformPopUp = true;
                enemy.AddPassiveAbility(instance5);
            }//Endless
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)73848))
            {
                AscendantPassiveAbility instance6 = ScriptableObject.CreateInstance<AscendantPassiveAbility>();
                instance6._passiveName = "Ascendant";
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)73848)
                        instance6.passiveIcon = passive.passiveIcon;
                }
                instance6.type = (PassiveAbilityTypes)73848;
                instance6._enemyDescription = "This enemy can only be healed indirectly.";
                instance6._characterDescription = "This party member can only be healed indirectly.";
                instance6.doesPassiveTriggerInformationPanel = false;
                instance6._triggerOn = new TriggerCalls[1]
                {
                        TriggerCalls.CanHeal
                };
                enemy.AddPassiveAbility(instance6);
            }//Ascedant
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)327745))
            {
                PerformEffectPassiveAbility instance6 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                instance6._passiveName = "Cold-Blooded";
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)327745)
                        instance6.passiveIcon = passive.passiveIcon;
                }
                instance6.type = (PassiveAbilityTypes)327745;
                instance6._characterDescription = "All Fire damage received by this character is multiplied by -1. This damage cannot set this character's health above their maximum health. \nFire on this party member's position does not decrease.";
                instance6._enemyDescription = "All Fire damage received by this enemy is multiplied by -1. This damage cannot set this enemy's health above their maximum health. \nFire on this enemy's position does not decrease.";
                instance6.doesPassiveTriggerInformationPanel = false;
                instance6._triggerOn = new TriggerCalls[] { TriggerCalls.OnBeingDamaged };
                instance6.conditions = new EffectorConditionSO[]
                {
                        ScriptableObject.CreateInstance<ColdHealCondition>()
                };
                instance6.effects = ExtensionMethods.ToEffectInfoArray(new Effect[]
                {
                        new Effect(ScriptableObject.CreateInstance<ExitValueSetterEffect>(), 1, null, Slots.Self, Conditions.Chance(1))
                });
                enemy.AddPassiveAbility(instance6);
            }//Cold-Blooded
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)98122))
            {
                foreach (BasePassiveAbilitySO passo in character.PassiveAbilities)
                {
                    if (passo.type == (PassiveAbilityTypes)98122 && passo._passiveName.Contains("Ancient"))
                    {
                        PerformDoubleEffectPassiveAbility instance1 = ScriptableObject.CreateInstance<PerformDoubleEffectPassiveAbility>();
                        instance1._passiveName = "Ancient Degradation";
                        foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                        {
                            if (passive.type == (PassiveAbilityTypes)98122)
                                instance1.passiveIcon = passive.passiveIcon;
                        }
                        instance1.type = (PassiveAbilityTypes)98122;
                        instance1._enemyDescription = "This enemy is slowly degrading into oil. \nApplies 2 Oil-Slicked to this enemy at the start of each turn, and 1 Oil-Slicked when taking any damage.";
                        instance1._characterDescription = "This party member is slowly degrading into oil. \nApplies 2 Oil-Slicked to this party member at the start of the turn, and 1 Oil-Slicked when taking any damage.";
                        instance1.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
                        {
                        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyOilSlickedEffect>(), 2, new IntentType?(), Slots.Self)
                        });
                        instance1._triggerOn = new TriggerCalls[1]
                        {
                        TriggerCalls.OnTurnStart
                        };
                        instance1._secondEffects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
                        {
                        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyOilSlickedEffect>(), 1, new IntentType?(), Slots.Self)
                        });
                        instance1._secondTriggerOn = new TriggerCalls[1]
                        {
                        TriggerCalls.OnDamaged
                        };
                        enemy.AddPassiveAbility(instance1);
                        break;
                    }
                }
            }//Ancient Degradation
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)63946))
            {
                PerformDoubleEffectPassiveAbility instance1 = ScriptableObject.CreateInstance<PerformDoubleEffectPassiveAbility>();
                instance1._passiveName = "Dummy";
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)63946)
                        instance1.passiveIcon = passive.passiveIcon;
                }
                instance1.type = (PassiveAbilityTypes)63946;
                instance1._enemyDescription = "This enemy Stuns itself at the start of its turn. \nUpon receiving direct damage, it will perform one of its abilities in retaliation.";
                instance1._characterDescription = "This dummy Stuns itself at the start of the turn, not gaining any actions on turn start. \nUpon this dummy receiving direct damage, it will perform one of its abilities in retaliation.";
                instance1.doesPassiveTriggerInformationPanel = false;
                PerformRandomAbilityEnemyEffect instance2 = ScriptableObject.CreateInstance<PerformRandomAbilityEnemyEffect>();
                instance1.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
                {
        new Effect((EffectSO) instance2, 1, new IntentType?(), Slots.Self)
                });
                instance1._triggerOn = new TriggerCalls[1]
                {
        TriggerCalls.OnDirectDamaged
                };
                instance1.doesPassiveTriggerInformationPanel = false;
                ApplyStunnedEffect instance3 = ScriptableObject.CreateInstance<ApplyStunnedEffect>();
                instance1._secondEffects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
                {
        new Effect((EffectSO) instance3, 1, new IntentType?(), Slots.Self)
                });
                instance1._secondTriggerOn = new TriggerCalls[1]
                {
        TriggerCalls.OnTurnStart
                };
                enemy.AddPassiveAbility(instance1);
            }//Dummy
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)28469))
            {
                PerformEffectPassiveAbility instance1 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                instance1._passiveName = "Ungod's Chosen";
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)28469)
                        instance1.passiveIcon = passive.passiveIcon;
                }
                instance1.type = (PassiveAbilityTypes)28469;
                instance1._enemyDescription = "Upon death, summon the Ungod on this enemy's behalf.";
                instance1._characterDescription = "Upon death, summon the Ungod on your behalf.";
                SpawnEnemyAnywhereEffect instance2 = ScriptableObject.CreateInstance<SpawnEnemyAnywhereEffect>();
                instance2.enemy = LoadedAssetsHandler.GetEnemy("Ungod_EN");
                instance1.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
                {
        new Effect((EffectSO) instance2, 1, new IntentType?(), Slots.Front)
                });
                instance1._triggerOn = new TriggerCalls[1]
                {
        TriggerCalls.OnDeath
                };
                enemy.AddPassiveAbility(instance1);
            }//Ungod's Chosen
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)784655))
            {
                RemoveStatusEffectEffect instance7 = ScriptableObject.CreateInstance<RemoveStatusEffectEffect>();
                instance7._statusToRemove = StatusEffectType.Ruptured;
                SwapToOneSideEffect instance1 = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
                instance1._swapRight = false;
                SwapToOneSideEffect instance2 = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
                instance2._swapRight = true;

                PerformEffectPassiveAbility instance8 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                instance8._passiveName = "Astral Pull";
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)784655)
                        instance8.passiveIcon = passive.passiveIcon;
                }
                instance8.type = (PassiveAbilityTypes)784655;
                instance8._enemyDescription = "On turn start, remove Ruptured form all enemies. Then pull all enemies and party members closer to this enemy.";
                instance8._characterDescription = "On turn start, remove Ruptured from all allies. Then pull all enemies and allies closer to this party member.";
                instance8.doesPassiveTriggerInformationPanel = true;
                instance8.effects = ExtensionMethods.ToEffectInfoArray(new Effect[5]
                {
        new Effect((EffectSO) instance7, 0, new IntentType?(), Slots.SlotTarget(new int[9]
        {
          -4,
          -3,
          -2,
          -1,
          0,
          1,
          2,
          3,
          4
        }, true)),
        new Effect((EffectSO) instance2, 1, new IntentType?(), Slots.SlotTarget(new int[4]
        {
          -1,
          -2,
          -3,
          -4
        })),
        new Effect((EffectSO) instance1, 1, new IntentType?(), Slots.SlotTarget(new int[4]
        {
          1,
          2,
          3,
          4
        })),
        new Effect((EffectSO) instance2, 1, new IntentType?(), Slots.SlotTarget(new int[3]
        {
          -2,
          -3,
          -4
        }, true)),
        new Effect((EffectSO) instance1, 1, new IntentType?(), Slots.SlotTarget(new int[3]
        {
          2,
          3,
          4
        }, true))
                });
                instance8._triggerOn = new TriggerCalls[1]
                {
        TriggerCalls.OnTurnStart
                };
                enemy.AddPassiveAbility(instance8);
            }//Astral Pull
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)80002))
            {
                PerformEffectPassiveAbility instance1 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                instance1._passiveName = "Wounded";
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)80002)
                        instance1.passiveIcon = passive.passiveIcon;
                }
                instance1.type = (PassiveAbilityTypes)80002;
                instance1._enemyDescription = "Upon receiving direct damage, apply one scar to this enemy.";
                instance1._characterDescription = "Upon receiving direct damage, apply one scar to this party member.";
                ApplyScarsEffect instance2 = ScriptableObject.CreateInstance<ApplyScarsEffect>();
                instance1.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
                {
        new Effect((EffectSO) instance2, 1, new IntentType?(), Slots.Self)
                });
                instance1._triggerOn = new TriggerCalls[1]
                {
        TriggerCalls.OnDirectDamaged
                };
                enemy.AddPassiveAbility(instance1);
            }//Wounded
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)57809))
            {
                HealingCatalystPassive instance1 = ScriptableObject.CreateInstance<HealingCatalystPassive>();
                instance1._passiveName = "Impetus";
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)57809)
                        instance1.passiveIcon = passive.passiveIcon;
                }
                instance1.type = (PassiveAbilityTypes)57809;
                instance1._enemyDescription = "Whenever this enemy receives direct healing, all party members and enemies with Linked will also receive healing.";
                instance1._characterDescription = "Whenever this party member receives direct healing, all party members and enemies with linked will also receive healing.";
                instance1.doesPassiveTriggerInformationPanel = true;
                instance1._triggerOn = new TriggerCalls[1]
                {
        TriggerCalls.OnWillBeHealed
                };
                enemy.AddPassiveAbility(instance1);
            }//Impetus
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)327750))
            {
                DamageByStoredValueEffect hitbush = ScriptableObject.CreateInstance<DamageByStoredValueEffect>();
                hitbush._valueName = (UnitStoredValueNames)327750;

                PerformEffectPassiveAbility ambush = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                ambush._passiveName = "Ambush (4)";
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)327750)
                        ambush.passiveIcon = passive.passiveIcon;
                }
                ambush.type = (PassiveAbilityTypes)327750;
                ambush._enemyDescription = "When a party member moves in front of this enemy, deal a specificed amount of damage to them.";
                ambush._characterDescription = "When an enemy moves in front of this party member, deal a specified amount of damage to them.";
                ambush.doesPassiveTriggerInformationPanel = true;
                ambush.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1] { new Effect(hitbush, 4, null, Slots.Front) });
                ambush._triggerOn = new TriggerCalls[1] { (TriggerCalls)327750 };
                enemy.AddPassiveAbility(ambush);
            }//Ambush
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)8573959))
            {
                CasterStoredValueChangeEffect instance1 = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
                instance1._minimumValue = 0;
                instance1._valueName = (UnitStoredValueNames)247364;
                instance1._increase = true;
                CountdownCheckCondition instance4 = ScriptableObject.CreateInstance<CountdownCheckCondition>();
                instance4._valueName = (UnitStoredValueNames)247364;
                instance4.higherthanor = false;
                instance4.checkagainst = 10;
                PerformEffectPassiveAbility instance5 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                instance5._passiveName = "Momentum";
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)8573959)
                        instance5.passiveIcon = passive.passiveIcon;
                }
                instance5.type = (PassiveAbilityTypes)8573959;
                instance5._enemyDescription = "This enemy's Momentum will increase upon moving or being moved. Momentum caps at 10.";
                instance5._characterDescription = "This party member's momentum will increase upon moving or being moved. Momentum caps at 10.";
                instance5.specialStoredValue = (UnitStoredValueNames)247364;
                instance5.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
                {
        new Effect((EffectSO) instance1, 1, new IntentType?(), Slots.Self, (EffectConditionSO) instance4)
                });
                instance5._triggerOn = new TriggerCalls[1]
                {
        TriggerCalls.OnMoved
                };
                enemy.AddPassiveAbility(instance5);
            }//Momentum
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)345383))
            {
                PerformEffectPassiveAbility instance1 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                instance1._passiveName = "Permafrost";
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)345383)
                        instance1 = passive as PerformEffectPassiveAbility;
                }
                instance1.type = (PassiveAbilityTypes)345383;
                instance1._enemyDescription = "This enemy will inflict 1 Deep-Frozen to their current position at the beginning of each turn.";
                enemy.AddPassiveAbility(instance1);
            }//Permafrost
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)7550))
            {
                Connection_PerformEffectPassiveAbility permaGut = ScriptableObject.CreateInstance<Connection_PerformEffectPassiveAbility>();
                permaGut._passiveName = "Oiled Up";
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)7550)
                        permaGut.passiveIcon = passive.passiveIcon;
                }
                permaGut.type = (PassiveAbilityTypes)7550;
                permaGut._enemyDescription = "This enemy is permenantly Oil Slicked.";
                permaGut._characterDescription = "This party member is permenantly Oil Slicked.";
                permaGut.doesPassiveTriggerInformationPanel = true;
                permaGut.connectionEffects = ExtensionMethods.ToEffectInfoArray(new Effect[1] { new Effect(ScriptableObject.CreateInstance<ApplyOilPermanent>(), 1, new IntentType?(), Slots.Self) });
                permaGut.disconnectionEffects = ExtensionMethods.ToEffectInfoArray(new Effect[1] { new Effect(ScriptableObject.CreateInstance<ExitValueSetterEffect>(), 1, new IntentType?(), Slots.Self) });
                permaGut._triggerOn = new TriggerCalls[1] { TriggerCalls.Count };
                enemy.AddPassiveAbility(permaGut);
            }//Oiled Up
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)0) || true)
            {
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive._passiveName == "Bloodthirst")
                    {
                        CasterStoreValueCheckEffect instance1 = ScriptableObject.CreateInstance<CasterStoreValueCheckEffect>();
                        instance1._valueName = (UnitStoredValueNames)9950;
                        CasterStoreValueSetterEffect instance2 = ScriptableObject.CreateInstance<CasterStoreValueSetterEffect>();
                        instance2._valueName = (UnitStoredValueNames)9950;
                        DamageEffect instance3 = ScriptableObject.CreateInstance<DamageEffect>();
                        instance3._indirect = true;
                        PreviousEffectCondition instance4 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
                        instance4.wasSuccessful = true;
                        PerformDoubleEffectPassiveAbility instance5 = ScriptableObject.CreateInstance<PerformDoubleEffectPassiveAbility>();
                        instance5._passiveName = "Bloodthirst";
                        instance5.type = (PassiveAbilityTypes)9950;
                        instance5.passiveIcon = passive.passiveIcon;
                        instance5._enemyDescription = "If this enemy has not dealt any damage before the turn ends, damage this enemy's health indirectly by 15.";
                        instance5._characterDescription = "If this party member has not dealt any damage before the turn ends, damage this party member's health indirectly by 15.";
                        instance5.doesPassiveTriggerInformationPanel = true;
                        instance5._secondDoesPerformPopUp = false;
                        instance5.specialStoredValue = (UnitStoredValueNames)9950;
                        instance5._triggerOn = new TriggerCalls[1]
                        {
        TriggerCalls.OnTurnStart
                        };
                        instance5._secondTriggerOn = new TriggerCalls[1]
                        {
        TriggerCalls.OnDidApplyDamage
                        };
                        instance5.effects = ExtensionMethods.ToEffectInfoArray(new Effect[3]
                        {
        new Effect((EffectSO) instance1, 1, new IntentType?(), Slots.Self),
        new Effect((EffectSO) instance3, 15, new IntentType?(), Slots.Self, (EffectConditionSO) instance4),
        new Effect((EffectSO) instance2, 1, new IntentType?(), Slots.Self)
                        });
                        instance5._secondEffects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
                        {
        new Effect((EffectSO) instance2, 0, new IntentType?(), Slots.Self)
                        });
                        enemy.AddPassiveAbility(instance5);
                        break;
                    }
                }
            }//Bloodthirst
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)62411))
            {
                PerformEffectPassiveAbility instance1 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                instance1._passiveName = "Last Wish";
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)62411)
                        instance1.passiveIcon = passive.passiveIcon;
                }
                instance1.type = (PassiveAbilityTypes)62411;
                instance1._enemyDescription = "Attempt to revive another enemy without Last Wish that died this battle when this enemy dies.";
                instance1._characterDescription = "doesnt work";
                instance1._triggerOn = new TriggerCalls[1]
                {
        TriggerCalls.OnDeath
                };
                instance1.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
                {
        new Effect((EffectSO) ScriptableObject.CreateInstance<ReviveFriendEnemyEffect>(), 1, new IntentType?(), Slots.Self)
                });
                instance1.doesPassiveTriggerInformationPanel = true;
                enemy.AddPassiveAbility(instance1);
            }//Last Wish
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)49562))
            {
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)49562 && passive._passiveName.Contains("Host"))
                    {
                        enemy.AddPassiveAbility(passive);
                        break;
                    }
                }
            }//Host
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)62412))
            {
                PerformEffectPassiveAbility instance1 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                instance1._passiveName = "Sensitive";
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)62412)
                        instance1.passiveIcon = passive.passiveIcon;
                }
                instance1.type = (PassiveAbilityTypes)62412;
                instance1._enemyDescription = "When this enemy receives any form of damage, randomize their aiming.";
                instance1._characterDescription = "When this party member receives any form of damage, randomize their aiming.";
                instance1._triggerOn = new TriggerCalls[1]
                {
        TriggerCalls.OnBeingDamaged
                };
                RandomizeStoredValueEffect instance2 = ScriptableObject.CreateInstance<RandomizeStoredValueEffect>();
                instance2._valueName = (UnitStoredValueNames)8315778;
                instance1.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
                {
        new Effect((EffectSO) instance2, 69, new IntentType?(), Slots.Self)
                });
                instance1.doesPassiveTriggerInformationPanel = true;
                enemy.AddPassiveAbility(instance1);
            }//Sensitive
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)1152))
            {
                CasterStoredValueChangeEffect instance1 = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
                instance1._minimumValue = 0;
                instance1._valueName = (UnitStoredValueNames)50334;
                instance1._increase = true;
                CasterStoredValueChangeEffect instance2 = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
                instance2._minimumValue = 0;
                instance2._valueName = (UnitStoredValueNames)50334;
                instance2._increase = false;
                DirectDeathEffect instance3 = ScriptableObject.CreateInstance<DirectDeathEffect>();
                instance3._obliterationDeath = true;
                CasterCheckStoredValueCondition instance4 = ScriptableObject.CreateInstance<CasterCheckStoredValueCondition>();
                instance4._valueName = (UnitStoredValueNames)50334;
                CasterStoredValueChangeEffect instance5 = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
                instance5._minimumValue = 0;
                instance5._valueName = (UnitStoredValueNames)50334;
                instance5._increase = false;
                PerformEffectPassiveAbility instance8 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                instance8._passiveName = "Apoptosis";
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)1152)
                        instance8.passiveIcon = passive.passiveIcon;
                }
                instance8.type = (PassiveAbilityTypes)1152;
                instance8._enemyDescription = "At the end of the timeline increase Apoptosis by 1.\nUpon Apoptosis reaching 5 or more, instantly kill this enemy at the end of the timeline.";
                instance8._characterDescription = "At the end of each turn increase Apoptosis by 1.\nUpon Apoptosis reaching 5 or more, instantly kill this party member at the end of the turn.";
                instance8.specialStoredValue = (UnitStoredValueNames)50334;
                instance8.effects = ExtensionMethods.ToEffectInfoArray(new Effect[2]
                {
        new Effect((EffectSO) instance1, 1, new IntentType?(), Slots.Self),
        new Effect((EffectSO) instance3, 1, new IntentType?(), Slots.Self, (EffectConditionSO) instance4)
                });
                instance8._triggerOn = new TriggerCalls[1]
                {
        TriggerCalls.OnRoundFinished
                };
                enemy.AddPassiveAbility(instance8);
            }//Apoptosis
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)24627555))
            {
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)24627555 && passive._passiveName == "Oblivion's Blessing")
                    {
                        passive._enemyDescription = "At the start of each turn, apply 1-5 Hellfire to this enemy.";
                        enemy.AddPassiveAbility(passive);
                        break;
                    }
                }
            }//Oblivion's Blessing
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)444440))
            {
                PerformEffectPassiveAbility hexEd = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                hexEd._passiveName = "Hex";
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)444440)
                        hexEd.passiveIcon = passive.passiveIcon;
                }
                hexEd.type = (PassiveAbilityTypes)444440;
                hexEd._enemyDescription = "Upon killing, apply Hexed to self.";
                hexEd._characterDescription = "Upon killing, apply Hexed to self.";
                hexEd.doesPassiveTriggerInformationPanel = true;
                hexEd._triggerOn = new TriggerCalls[1] { TriggerCalls.OnKill };
                hexEd.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1] { new Effect(ScriptableObject.CreateInstance<ApplyHexedEffect>(), 1, (IntentType)444440, Slots.Self) });
                enemy.AddPassiveAbility(hexEd);
            }//Hex
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)4444437))
            {
                PerformEffectPassiveAbility seamless = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                seamless._passiveName = "Seamless";
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)4444437)
                        seamless.passiveIcon = passive.passiveIcon;
                }
                seamless.type = (PassiveAbilityTypes)4444437;
                seamless._enemyDescription = "On using an ability, increase the Lucky Pigment production chance by 5%.";
                seamless._characterDescription = "This party member blends in with the flow and increases the lucky pigment production percent by 5 upon performing an ability.";
                seamless.doesPassiveTriggerInformationPanel = true;
                seamless._triggerOn = new TriggerCalls[1] { TriggerCalls.OnAbilityUsed };
                seamless.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1] { new Effect(ScriptableObject.CreateInstance<IncreaseLuckyBluePercentageEffect>(), 5, new IntentType?(), Slots.Self) });
                enemy.AddPassiveAbility(seamless);
            }//Seamless
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)301279))
            {
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)301279)
                    {
                        enemy.AddPassiveAbility(passive); break;
                    }
                }
            }//Mimicry
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)7390012))
            {
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)7390012)
                    {
                        enemy.AddPassiveAbility(passive); break;
                    }
                }
            }//Escapist
            if (passives.ContainsPassiveAbility(Passi.Coward.type))
            {
                enemy.AddPassiveAbility(Passi.Coward);
            }//Cowardice
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)926001))
            {
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)926001)
                    {
                        enemy.AddPassiveAbility(passive); break;
                    }
                }
            }//Just Acting
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)8201763))
            {
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)8201763 && passive._passiveName.Contains("Biorganic"))
                    {
                        enemy.AddPassiveAbility(passive); break;
                    }
                }
            }//Biorganic
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)456765))
            {
                PerformEffectPassiveAbility AliveSerialKiller = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                AliveSerialKiller._passiveName = "Serial Killer";
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)456765)
                        AliveSerialKiller.passiveIcon = passive.passiveIcon;
                }
                AliveSerialKiller.type = (PassiveAbilityTypes)456765;
                AliveSerialKiller._enemyDescription = "Upon killing anything, give this enemy another action and take 2 damage not from self.";
                AliveSerialKiller._characterDescription = "Upon killing anything, refresh this character and take 2 damage not from self.";
                AliveSerialKiller.effects = ExtensionMethods.ToEffectInfoArray(new Effect[]
                {
                new Effect(ScriptableObject.CreateInstance<AddTurnCasterToTimelineEffect>(), 1, new IntentType?(), Slots.Self),
                new Effect(ScriptableObject.CreateInstance<DamageFromNobodyEffect>(), 2, null, Slots.Self),
                });
                AliveSerialKiller._triggerOn = new TriggerCalls[1] { TriggerCalls.OnKill };
                enemy.AddPassiveAbility(AliveSerialKiller);
            }//Serial Killer
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)245625))
            {
                PerformEffectPassiveAbility instance1 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                instance1._passiveName = "Combustible";
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)245625)
                        instance1.passiveIcon = passive.passiveIcon;
                }
                instance1.type = (PassiveAbilityTypes)245625;
                instance1._enemyDescription = "Upon taking direct damage, apply 1 oil slicked and 1-4 fire to this enemy, and apply 1 fire to the opposing space.";
                instance1._characterDescription = "Upon taking direct damage, apply 1 oil slicked and 1-4 fire to this party member. Apply 1 fire to the opposing enemy.";
                instance1.doesPassiveTriggerInformationPanel = false;
                instance1.effects = ExtensionMethods.ToEffectInfoArray(new Effect[6]
                {
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyOilSlickedEffect>(), 1, new IntentType?(), Slots.Self),
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), 1, new IntentType?(), Slots.Self),
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), 1, new IntentType?(), Slots.Self, (EffectConditionSO) Conditions.Chance(55)),
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), 1, new IntentType?(), Slots.Self, (EffectConditionSO) Conditions.Chance(30)),
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), 1, new IntentType?(), Slots.Self, (EffectConditionSO) Conditions.Chance(25)),
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), 1, new IntentType?(), Slots.Front)
                });
                instance1._triggerOn = new TriggerCalls[1]
                {
        TriggerCalls.OnDirectDamaged
                };
                enemy.AddPassiveAbility(instance1);
            }//Combustible
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)4562969))
            {
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)4562969 && passive is PerformEffectPassiveAbility)
                    {
                        PerformEffectPassiveAbility instance1 = ScriptableObject.Instantiate<PerformEffectPassiveAbility>(passive as PerformEffectPassiveAbility);
                        instance1._enemyDescription = "At the end of each turn, deal 1 indirect damage to every enemy and party member. If a party member has Elemental Resistance, remove one instead.";
                        instance1.effects = new EffectInfo[(passive as PerformEffectPassiveAbility).effects.Length];
                        for (int i = 0; i < instance1.effects.Length; i++)
                        {
                            EffectInfo orig = (passive as PerformEffectPassiveAbility).effects[i];
                            Targetting_BySlot_Index targi = ScriptableObject.Instantiate<Targetting_BySlot_Index>(orig.targets as Targetting_BySlot_Index);
                            targi.getAllies = !orig.targets.AreTargetAllies;
                            instance1.effects[i] = new EffectInfo()
                            {
                                condition = orig.condition,
                                targets = targi,
                                effect = orig.effect,
                                entryVariable = orig.entryVariable
                            };
                        }
                        enemy.AddPassiveAbility(instance1); break;
                    }
                }
            }//Blizzard
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)43991))
            {
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)43991)
                    {
                        enemy.AddPassiveAbility(passive); break;
                    }
                }
            }//Blight
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)78261))
            {
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)78261)
                    {
                        enemy.AddPassiveAbility(passive); break;
                    }
                }
            }//Sleepy Rager
            if (passives.ContainsPassiveAbility(Passi.Acceleration.type))
            {
                enemy.AddPassiveAbility(Passi.Acceleration);
            }//Acceleration
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)9878771))
            {
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)9878771)
                    {
                        passive._enemyDescription = passive._characterDescription;
                        enemy.AddPassiveAbility(passive); break;
                    }
                }
            }//Impatience
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)358016))
            {
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)358016)
                    {
                        enemy.AddPassiveAbility(passive); break;
                    }
                }
            }//Strength
            if (passives.ContainsPassiveAbility((PassiveAbilityTypes)8301354))
            {
                foreach (BasePassiveAbilitySO passive in character.PassiveAbilities)
                {
                    if (passive.type == (PassiveAbilityTypes)8301354)
                    {
                        enemy.AddPassiveAbility(passive); break;
                    }
                }
            }//Obsession
        }
        public static void RemoveAttack(Action<EnemyCombatUIInfo, int> orig, EnemyCombatUIInfo self, int attackID)
        {
            if (attackID >= self.Abilities.Count)
            {
                attackID = self.Abilities.Count - 1;
            }
            orig(self, attackID);
        }
    }
    public class MoveToClosestTargetEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;

            int distance = 999;
            List<int> targetSlots = new List<int>();
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    int checkThis = caster.SlotID - target.SlotID;
                    if (checkThis < 0)
                    {
                        checkThis *= -1;
                    }
                    if (distance > 100)
                    {
                        distance = checkThis;
                        targetSlots.Clear();
                        targetSlots.Add(target.SlotID);
                    }
                    else if (checkThis < distance)
                    {
                        distance = checkThis;
                        targetSlots.Clear();
                        targetSlots.Add(target.SlotID);
                    }
                    else if (checkThis == distance)
                    {
                        distance = checkThis;
                        targetSlots.Add(target.SlotID);
                    }
                    if (distance < 0)
                    {
                        distance *= -1;
                    }
                }
            }
            if (targetSlots.Count <= 0)
            {
                return false;
            }
            int TargetSlot = targetSlots[UnityEngine.Random.Range(0, targetSlots.Count)];
            if (TargetSlot == caster.SlotID)
            {
                return true;
            }
            else if (TargetSlot < caster.SlotID)
            {
                SwapToOneSideEffect goLeft = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
                goLeft._swapRight = false;
                Effect effort1 = new Effect(goLeft, 1, null, Slots.Self);
                List<Effect> effects = new List<Effect>();
                for (int i = 0; i < (caster.SlotID - TargetSlot); i++)
                {

                    effects.Add(effort1);

                }
                CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(effects.ToArray()), caster));
                return true;
            }
            else if (TargetSlot > caster.SlotID)
            {
                SwapToOneSideEffect goRight = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
                goRight._swapRight = true;
                Effect effort1 = new Effect(goRight, 1, null, Slots.Self);
                List<Effect> effects = new List<Effect>();
                for (int i = 0; i < (TargetSlot - caster.SlotID); i++)
                {

                    effects.Add(effort1);

                }
                CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(effects.ToArray()), caster));
                return true;
            }


            return exitAmount > 0;
        }
    }
    public class CopyFirstTargetDetailsEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (targets.Length <= 0) return false;
            if (!targets[0].HasUnit)
            {
                return false;
            }
            if (Hawthorne.Check.Half) CombatManager.Instance.AddUIAction(new ShowAttackInformationUIAction(caster.ID, caster.IsUnitCharacter, "Say \"Cheese!\""));
            else CombatManager.Instance.AddUIAction(new ShowAttackInformationUIAction(caster.ID, caster.IsUnitCharacter, "Smile for the Camera!"));
            CombatManager.Instance.AddUIAction(new WasteTimeUIAction(caster.ID, caster.IsUnitCharacter, ""));
            if (caster.MaximizeHealth(targets[0].Unit.MaximumHealth))
            {
                exitAmount++;
                CombatManager.Instance.AddUIAction(new PlayHealthColorSoundUIAction());
            }
            CombatManager.Instance.AddUIAction(new WasteTimeUIAction(caster.ID, caster.IsUnitCharacter, ""));
            CombatManager.Instance.AddUIAction(new WasteTimeUIAction(caster.ID, caster.IsUnitCharacter, ""));
            CombatManager.Instance.AddUIAction(new WasteTimeUIAction(caster.ID, caster.IsUnitCharacter, ""));
            CombatManager.Instance.AddUIAction(new WasteTimeUIAction(caster.ID, caster.IsUnitCharacter, ""));
            if (caster.ChangeHealthColor(targets[0].Unit.HealthColor))
                exitAmount++;
            CombatManager.Instance.AddUIAction(new WasteTimeUIAction(caster.ID, caster.IsUnitCharacter, ""));
            CombatManager.Instance.AddUIAction(new WasteTimeUIAction(caster.ID, caster.IsUnitCharacter, ""));
            CombatManager.Instance.AddUIAction(new WasteTimeUIAction(caster.ID, caster.IsUnitCharacter, ""));
            CombatManager.Instance.AddUIAction(new WasteTimeUIAction(caster.ID, caster.IsUnitCharacter, ""));
            if (targets[0].Unit is CharacterCombat character && caster is EnemyCombat enemy)
            {
                string namae = "Image of ";
                namae += character._currentName;
                enemy._currentName = namae;
                string descp = namae;
                descp += " will perforn an extra ability \"Lens Flash\" each turn.";
                enemy.PassiveAbilities[0]._enemyDescription = descp;
                try
                {
                    foreach (EnemyCombatUIInfo enemyInfo in stats.combatUI._enemiesInCombat.Values)
                    {
                        if (enemyInfo.SlotID == enemy.SlotID)
                        {
                            enemyInfo.Name = namae;
                            enemyInfo.Passives[0]._enemyDescription = descp;
                        }
                    }
                }
                catch
                {
                    if (DoDebugs.MiscInfo) Debug.LogError("camera name change fail");
                }


                exitAmount++;
                try
                {
                    CameraEffects.AddPassives(character, new CameraEffects.PassiveHolder(character.PassiveAbilities.ToArray()), enemy);
                }
                catch
                {
                    if (DoDebugs.MiscInfo) Debug.LogError("steal passives fail");
                }
            }
            CombatManager.Instance.AddUIAction(new PlayHealthColorSoundUIAction());
            return exitAmount > 0;
        }
    }
    public class StealRandomPassiveEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            try
            {
                if (caster is EnemyCombat enemy) foreach (TargetSlotInfo target in targets) if (target.HasUnit && target.Unit is CharacterCombat chara) CameraEffects.AddPassives(chara, new CameraEffects.PassiveHolder(chara.PassiveAbilities.ToArray(), chara), enemy, true, true);
            }
            catch
            {
                if (DoDebugs.MiscInfo) Debug.LogError("steal passive fail");
            }
            return true;
        }
    }
    public class RemoveFavoritePictureEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;


            if (caster is EnemyCombat enemy)
            {
                foreach (CombatAbility ability in enemy.Abilities)
                {
                    if (ability.ability._locAbilityData.text == "Favorite Picture")
                    {
                        enemy.Abilities.Remove(ability);
                        foreach (int enID in stats.combatUI._enemiesInCombat.Keys)
                        {
                            EnemyCombatUIInfo enemyInfo;
                            if (stats.combatUI._enemiesInCombat.TryGetValue(enID, out enemyInfo))
                            {
                                if (enemyInfo.SlotID == enemy.SlotID)
                                {
                                    enemyInfo.UpdateAttacks(enemy.Abilities.ToArray());
                                    stats.combatUI.TryUpdateEnemyIDInformation(enID);
                                }
                            }
                        }
                        exitAmount++;
                        break;
                    }
                }
                UnityEngine.Debug.Log(enemy._currentName);
                foreach (CombatAbility ability in enemy.Abilities)
                {
                    UnityEngine.Debug.Log(ability.ability._locAbilityData.text + " ; " + ability.ability._abilityName);
                }
            }


            return exitAmount > 0;
        }
    }
    public class StealAbilityEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;

            CombatManager.Instance.AddUIAction(new ShowAttackInformationUIAction(caster.ID, caster.IsUnitCharacter, "*Snap*"));

            List<CombatAbility> abilToAdd = new List<CombatAbility>();

            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    if (target.Unit is CharacterCombat character)
                    {
                        if (character.CombatAbilities.Count > 0)
                        {
                            for (int i = 0; i < entryVariable; i++)
                            {
                                CombatAbility addThis = character.CombatAbilities[UnityEngine.Random.Range(0, character.CombatAbilities.Count)];
                                while (addThis.ability == null) addThis = character.CombatAbilities[UnityEngine.Random.Range(0, character.CombatAbilities.Count)];
                                if (addThis.ability.priority == null)
                                {
                                    addThis.ability.priority = ScriptableObject.CreateInstance<PrioritySO>();
                                    addThis.ability.priority.priorityValue = 0;
                                }
                                RaritySO rarity1 = ScriptableObject.CreateInstance<RaritySO>();
                                rarity1.rarityValue = 10;
                                rarity1.canBeRerolled = true;
                                CombatAbility newThis = new CombatAbility(addThis.ability, rarity1);
                                abilToAdd.Add(newThis);
                            }
                        }
                    }
                    if (target.Unit is EnemyCombat enemy)
                    {
                        if (enemy.Abilities.Count > 0)
                        {
                            for (int i = 0; i < entryVariable; i++)
                            {
                                CombatAbility addThis = enemy.Abilities[UnityEngine.Random.Range(0, enemy.Abilities.Count)];
                                while (addThis.ability == null) addThis = enemy.Abilities[UnityEngine.Random.Range(0, enemy.Abilities.Count)];
                                if (addThis.ability.priority == null)
                                {
                                    addThis.ability.priority = ScriptableObject.CreateInstance<PrioritySO>();
                                    addThis.ability.priority.priorityValue = 0;
                                }
                                RaritySO rarity1 = ScriptableObject.CreateInstance<RaritySO>();
                                rarity1.rarityValue = 10;
                                rarity1.canBeRerolled = true;
                                CombatAbility newThis = new CombatAbility(addThis.ability, rarity1);
                                abilToAdd.Add(newThis);
                            }
                        }
                    }
                }
            }
            if (abilToAdd.Count <= 0)
            {
                return false;
            }
            if (caster is EnemyCombat unitEN)
            {

                CombatAbility lens = abilToAdd[0];
                foreach (CombatAbility ability in (caster as EnemyCombat).Abilities)
                {
                    if (ability.ability._locAbilityData.text == "Lens Flash")
                    {
                        lens = ability;
                    }
                }
                List<CombatAbility> abilities = unitEN.Abilities;
                foreach (CombatAbility removeLens in abilities)
                {
                    if (removeLens.ability._locAbilityData.text == "Lens Flash")
                    {
                        abilities.Remove(removeLens);
                        break;
                    }
                }
                foreach (CombatAbility ability in abilToAdd)
                {
                    abilities.Add(ability);
                }
                if (lens != abilToAdd[0] && abilities.Count > 0)
                {
                    List<CombatAbility> newList = new List<CombatAbility>();
                    //newList.Add(abilities[0]);
                    newList.Add(lens);
                    exitAmount++;
                    for (int i = 0; i < abilities.Count; i++)
                    {
                        newList.Add(abilities[i]);
                        exitAmount++;
                    }
                    unitEN.Abilities = newList;
                    foreach (int enID in stats.combatUI._enemiesInCombat.Keys)
                    {
                        EnemyCombatUIInfo enemyInfo;
                        if (stats.combatUI._enemiesInCombat.TryGetValue(enID, out enemyInfo))
                        {
                            if (enemyInfo.SlotID == unitEN.SlotID)
                            {
                                enemyInfo.Abilities = newList;
                                enemyInfo.UpdateAttacks(enemyInfo.Abilities.ToArray());
                                stats.combatUI.TryUpdateEnemyIDInformation(enID);
                            }
                        }
                    }
                }

                UnityEngine.Debug.Log(unitEN._currentName);
                foreach (CombatAbility ability in unitEN.Abilities)
                {
                    UnityEngine.Debug.Log(ability.ability._abilityName);
                }

            }
            if (caster is CharacterCombat unitCH)
            {
                foreach (CombatAbility ability in abilToAdd)
                {
                    unitCH.CombatAbilities.Add(ability);
                    exitAmount++;
                }
            }

            return exitAmount > 0;
        }
    }
    public class SayCheeseEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;


            PreviousEffectCondition didThat = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            didThat.wasSuccessful = true;
            Effect effort1 = new Effect(ScriptableObject.CreateInstance<CopyFirstTargetDetailsEffect>(), 1, null, Slots.Front);
            Effect effort2 = new Effect(ScriptableObject.CreateInstance<RemoveFavoritePictureEffect>(), 1, null, Slots.Self, didThat);
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[] { effort1, effort2 }), caster));


            return exitAmount > 0;
        }
    }
    public class TakePicEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;


            PreviousEffectCondition didThat = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            didThat.wasSuccessful = true;
            Effect effort1 = new Effect(ScriptableObject.CreateInstance<StealAbilityEffect>(), 1, null, Slots.Front);
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[] { effort1 }), caster));


            return exitAmount > 0;
        }
    }
    public class StatusEffectApplicationFalseSetterPassive : BasePassiveAbilitySO
    {
        public override bool IsPassiveImmediate => true;

        public override bool DoesPassiveTrigger => true;

        public override void TriggerPassive(object sender, object args)
        {
            if (!(args is StatusEffectApplication effectApplication) || effectApplication.Equals((object)null))
                return;
            effectApplication.value = false;
        }

        public override void OnPassiveConnected(IUnit unit)
        {
        }

        public override void OnPassiveDisconnected(IUnit unit)
        {
        }
    }
    public class HalveCasterMaxHealthEffect : EffectSO
    {
        [SerializeField]
        public bool _increase = true;
        [SerializeField]
        public bool _entryAsPercentage;

        public override bool PerformEffect(
          CombatStats stats,
          IUnit caster,
          TargetSlotInfo[] targets,
          bool areTargetSlots,
          int entryVariable,
          out int exitAmount)
        {
            exitAmount = 0;
            for (int index = 0; index < targets.Length; ++index)
            {
                if (targets[index].HasUnit)
                {
                    int percentage = caster.MaximumHealth / 2;
                    if (this._entryAsPercentage)
                        percentage = targets[index].Unit.CalculatePercentualAmount(percentage);
                    int newMaxHealth = targets[index].Unit.MaximumHealth + (this._increase ? percentage : -percentage);
                    if (targets[index].Unit.MaximizeHealth(newMaxHealth))
                        exitAmount += percentage;
                }
            }
            return exitAmount > 0;
        }
    }
    public class PerformRandomAbilityEnemyEffect : EffectSO
    {
        [SerializeField]
        public bool _increase = true;
        [SerializeField]
        public bool _entryAsPercentage;

        public override bool PerformEffect(
          CombatStats stats,
          IUnit caster,
          TargetSlotInfo[] targets,
          bool areTargetSlots,
          int entryVariable,
          out int exitAmount)
        {
            exitAmount = 0;


            if (caster is EnemyCombat enemy)
            {
                if (enemy.Abilities == null || enemy.Abilities.Count <= 0)
                {
                    return false;
                }

                int index = UnityEngine.Random.Range(0, enemy.Abilities.Count);
                AbilitySO ability = enemy.Abilities[index].ability;
                CombatManager.Instance.AddSubAction(new ShowAttackInformationUIAction(enemy.ID, enemy.IsUnitCharacter, ability.GetAbilityLocData().text));
                CombatManager.Instance.AddSubAction(new PlayAbilityAnimationAction(ability.visuals, ability.animationTarget, enemy));
                CombatManager.Instance.AddSubAction(new EffectAction(ability.effects, enemy));
                return true;
            }

            return exitAmount > 0;
        }
    }
    public class DoubleDamageInFirePassive : BasePassiveAbilitySO
    {
        public override bool IsPassiveImmediate => true;

        public override bool DoesPassiveTrigger => true;

        public override void TriggerPassive(object sender, object args)
        {
            IPassiveEffector passiveEffector = sender as IPassiveEffector;
            if (!CombatManager.Instance._stats.combatSlots.SlotContainsSlotStatusEffect((sender as IUnit).SlotID, true, SlotStatusEffectType.OnFire))
                return;
            CombatManager.Instance.AddUIAction((CombatAction)new ShowPassiveInformationUIAction(passiveEffector.ID, passiveEffector.IsUnitCharacter, this.GetPassiveLocData().text, this.passiveIcon));
            (args as DamageDealtValueChangeException).AddModifier((IntValueModifier)new MultiplyIntValueModifier(true, 2));
        }

        public override void OnPassiveConnected(IUnit unit)
        {
        }

        public override void OnPassiveDisconnected(IUnit unit)
        {
        }
    }
    public class RupturedDamageEffect : EffectSO
    {
        public bool _addPreviousExitValue;

        public override bool PerformEffect(
          CombatStats stats,
          IUnit caster,
          TargetSlotInfo[] targets,
          bool areTargetSlots,
          int entryVariable,
          out int exitAmount)
        {
            exitAmount = 0;
            if (this._addPreviousExitValue)
                entryVariable += this.PreviousExitValue;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    int targetSlotOffset = areTargetSlots ? target.SlotID - target.Unit.SlotID : -1;
                    DamageInfo damageInfo = target.Unit.Damage(entryVariable, caster, DeathType.Rupture, targetSlotOffset, false, false, specialDamage: DamageType.Ruptured);
                    exitAmount += damageInfo.damageAmount;
                }
            }
            if (exitAmount > 0)
                caster.DidApplyDamage(exitAmount);
            return exitAmount > 0;
        }
    }
    public class RealFragilePassiveAbility : BasePassiveAbilitySO
    {
        [Header("Multiplier Data")]
        [SerializeField]
        [Min(0.0f)]
        private int _modifyVal = 1;


        public override bool IsPassiveImmediate => true;

        public override bool DoesPassiveTrigger => true;

        public override void TriggerPassive(object sender, object args)
        {
            //Debug.Log("passive started");
            IUnit unit = sender as IUnit;
            //Debug.Log("unit got");

            //DamageReceivedValueChangeException damageReceived = args as DamageReceivedValueChangeException;
            if (args is DamageReceivedValueChangeException HitBy && HitBy.amount > 0)
            {
                if (args is DamageReceivedValueChangeException && !(args as DamageReceivedValueChangeException).Equals((object)null))
                {
                    (args as DamageReceivedValueChangeException).AddModifier((IntValueModifier)new RealFragileValueModifier(this._modifyVal));
                    CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction((sender as IPassiveEffector).ID, (sender as IPassiveEffector).IsUnitCharacter, GetPassiveLocData().text, this.passiveIcon));
                    /*
                    BooleanReference reference = args as BooleanReference;
                    if (reference != null)
                        reference.value = false;
                    DirectDeathEffect instantDeath = ScriptableObject.CreateInstance<DirectDeathEffect>();
                    int healthNow = unit.CurrentHealth;
                    healthNow--;
                    //if (healthNow > 0)
                    if (healthNow <= 0)
                        CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { new Effect(instantDeath, 1, new IntentType?(), Slots.Self) }), unit));
                    else
                    {
                        unit.SetHealthTo(healthNow);
                        if ((args as DamageReceivedValueChangeException).directDamage)
                            unit.GenerateHealthMana(1);
                    }
                    SetCasterExtraSpritesEffect JuliosSpecialSprites = ScriptableObject.CreateInstance<SetCasterExtraSpritesEffect>();
                    JuliosSpecialSprites._spriteType = (ExtraSpriteType)22332;
                    CasterCheckStoredValueCondition FragileCheck = ScriptableObject.CreateInstance<CasterCheckStoredValueCondition>();
                    FragileCheck._valueName = (UnitStoredValueNames)2233445;
                    CasterStoredValueChangeEffect FragileIncrease = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
                    FragileIncrease._minimumValue = 0;
                    FragileIncrease._valueName = (UnitStoredValueNames)2233445;
                    FragileIncrease._increase = true;
                    CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[2] { new Effect(FragileIncrease, 1, new IntentType?(), Slots.Self), new Effect(JuliosSpecialSprites, 1, new IntentType?(), Slots.Self) }), unit));
                    if (healthNow > 0)
                        CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { new Effect(instantDeath, 1, new IntentType?(), Slots.Self, FragileCheck) }), unit));
                    */
                }

            }
            //Debug.Log("damage check");
            switch (args)
            {
                case CanHealReference canHealReference:
                    CombatManager.Instance.AddUIAction((CombatAction)new ShowPassiveInformationUIAction(unit.ID, unit.IsUnitCharacter, this.GetPassiveLocData().text, this.passiveIcon));
                    canHealReference.value = false;
                    //Debug.Log("heal check");
                    break;
            }
            //Debug.Log("heal check checkpoint 2");
            //Debug.Log("finished");

        }

        public override void OnPassiveConnected(IUnit unit)
        {
        }

        public override void OnPassiveDisconnected(IUnit unit)
        {
        }
    }
    public class RealFragileValueModifier : IntValueModifier
    {
        public readonly int FVAL;

        public RealFragileValueModifier(int exitVal)
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
    public class ApplyPermanentGuttedEffect : EffectSO
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
            if (entryVariable <= 0)
                return false;
            StatusEffectInfoSO effectInfo;
            stats.statusEffectDataBase.TryGetValue(StatusEffectType.Gutted, out effectInfo);
            for (int index = 0; index < targets.Length; ++index)
            {
                if (targets[index].HasUnit)
                {
                    Gutted_StatusEffect guttedStatusEffect = new Gutted_StatusEffect(0, 1);
                    guttedStatusEffect.SetEffectInformation(effectInfo);
                    if (targets[index].Unit.ApplyStatusEffect((IStatusEffect)guttedStatusEffect, 0))
                        exitAmount += entryVariable;
                }
            }
            return exitAmount > 0;
        }
    }
    public class RandomEffectsRandomSideEffect : EffectSO
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
            int num = -4;
            if (UnityEngine.Random.Range(0, 100) < 50)
            {
                for (; num < 5 && num > -5; ++num)
                    CombatManager.Instance.AddSubAction((CombatAction)new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1]
                    {
          new Effect((EffectSO) ScriptableObject.CreateInstance<RandomNegativeStatusEffect>(), 1, new IntentType?(), Slots.SlotTarget(new int[1]
          {
            num
          }))
                    }), caster));
                return true;
            }
            for (; num < 5 && num > -5; ++num)
            {
                if (num == 0)
                    ++num;
                CombatManager.Instance.AddSubAction((CombatAction)new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1]
                {
        new Effect((EffectSO) ScriptableObject.CreateInstance<RandomPositiveStatusEffect>(), 1, new IntentType?(), Slots.SlotTarget(new int[1]
        {
          num
        }, true))
                }), caster));
            }
            return true;
        }
    }
    public class RandomNegativeStatusEffect : EffectSO
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
            int num = UnityEngine.Random.Range(0, 100);
            bool flag;
            if (entryVariable <= 0)
            {
                flag = false;
            }
            else
            {
                StatusEffectInfoSO effectInfo1;
                stats.statusEffectDataBase.TryGetValue(StatusEffectType.Ruptured, out effectInfo1);
                StatusEffectInfoSO effectInfo2;
                stats.statusEffectDataBase.TryGetValue(StatusEffectType.OilSlicked, out effectInfo2);
                StatusEffectInfoSO effectInfo3;
                stats.statusEffectDataBase.TryGetValue(StatusEffectType.Frail, out effectInfo3);
                StatusEffectInfoSO effectInfo4;
                stats.statusEffectDataBase.TryGetValue(StatusEffectType.Cursed, out effectInfo4);
                StatusEffectInfoSO effectInfo5;
                stats.statusEffectDataBase.TryGetValue(StatusEffectType.Spotlight, out effectInfo5);
                StatusEffectInfoSO effectInfo6;
                stats.statusEffectDataBase.TryGetValue(StatusEffectType.Stunned, out effectInfo6);
                StatusEffectInfoSO effectInfo7;
                stats.statusEffectDataBase.TryGetValue(StatusEffectType.Scars, out effectInfo7);
                StatusEffectInfoSO effectInfo8;
                stats.statusEffectDataBase.TryGetValue((StatusEffectType)399908, out effectInfo8);
                if (num < 12)
                {
                    for (int index = 0; index < targets.Length; ++index)
                    {
                        if (targets[index].HasUnit)
                        {
                            Ruptured_StatusEffect rupturedStatusEffect = new Ruptured_StatusEffect(entryVariable);
                            rupturedStatusEffect.SetEffectInformation(effectInfo1);
                            if (targets[index].Unit.ApplyStatusEffect((IStatusEffect)rupturedStatusEffect, entryVariable))
                                exitAmount += entryVariable;
                        }
                    }
                }
                else if (num < 24)
                {
                    for (int index = 0; index < targets.Length; ++index)
                    {
                        if (targets[index].HasUnit)
                        {
                            OilSlicked_StatusEffect slickedStatusEffect = new OilSlicked_StatusEffect(entryVariable);
                            slickedStatusEffect.SetEffectInformation(effectInfo2);
                            if (targets[index].Unit.ApplyStatusEffect((IStatusEffect)slickedStatusEffect, entryVariable))
                                exitAmount += entryVariable;
                        }
                    }
                }
                else if (num < 37)
                {
                    for (int index = 0; index < targets.Length; ++index)
                    {
                        if (targets[index].HasUnit)
                        {
                            Frail_StatusEffect frailStatusEffect = new Frail_StatusEffect(entryVariable);
                            frailStatusEffect.SetEffectInformation(effectInfo3);
                            if (targets[index].Unit.ApplyStatusEffect((IStatusEffect)frailStatusEffect, entryVariable))
                                exitAmount += entryVariable;
                        }
                    }
                }
                else if (num < 49)
                {
                    for (int index = 0; index < targets.Length; ++index)
                    {
                        if (targets[index].HasUnit)
                        {
                            Cursed_StatusEffect cursedStatusEffect = new Cursed_StatusEffect();
                            cursedStatusEffect.SetEffectInformation(effectInfo4);
                            if (targets[index].Unit.ApplyStatusEffect((IStatusEffect)cursedStatusEffect, 0))
                                ++exitAmount;
                        }
                    }
                }
                else if (num < 61)
                {
                    for (int index = 0; index < targets.Length; ++index)
                    {
                        if (targets[index].HasUnit)
                        {
                            Spotlight_StatusEffect spotlightStatusEffect = new Spotlight_StatusEffect();
                            spotlightStatusEffect.SetEffectInformation(effectInfo5);
                            if (targets[index].Unit.ApplyStatusEffect((IStatusEffect)spotlightStatusEffect, 0))
                                ++exitAmount;
                        }
                    }
                }
                else if (num < 74)
                {
                    for (int index = 0; index < targets.Length; ++index)
                    {
                        if (targets[index].HasUnit)
                        {
                            Stunned_StatusEffect stunnedStatusEffect = new Stunned_StatusEffect(entryVariable);
                            stunnedStatusEffect.SetEffectInformation(effectInfo6);
                            if (targets[index].Unit.ApplyStatusEffect((IStatusEffect)stunnedStatusEffect, entryVariable))
                                ++exitAmount;
                        }
                    }
                }
                else if (num < 87)
                {
                    for (int index = 0; index < targets.Length; ++index)
                    {
                        if (targets[index].HasUnit)
                        {
                            Marked_StatusEffect markedStatusEffect = new Marked_StatusEffect();
                            markedStatusEffect.SetEffectInformation(effectInfo8);
                            if (targets[index].Unit.ApplyStatusEffect((IStatusEffect)markedStatusEffect, 0))
                                ++exitAmount;
                        }
                    }
                }
                else
                {
                    for (int index = 0; index < targets.Length; ++index)
                    {
                        if (targets[index].HasUnit)
                        {
                            Scars_StatusEffect scarsStatusEffect = new Scars_StatusEffect(entryVariable);
                            scarsStatusEffect.SetEffectInformation(effectInfo7);
                            if (targets[index].Unit.ApplyStatusEffect((IStatusEffect)scarsStatusEffect, entryVariable))
                                ++exitAmount;
                        }
                    }
                }
                flag = exitAmount > 0;
            }
            return flag;
        }
    }
    public class RandomPositiveStatusEffect : EffectSO
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
            int num = UnityEngine.Random.Range(0, 100);
            bool flag1;
            if (entryVariable <= 0)
            {
                flag1 = false;
            }
            else
            {
                StatusEffectInfoSO effectInfo1;
                stats.statusEffectDataBase.TryGetValue(StatusEffectType.Focused, out effectInfo1);
                StatusEffectInfoSO effectInfo2;
                stats.statusEffectDataBase.TryGetValue(StatusEffectType.Spotlight, out effectInfo2);
                StatusEffectInfoSO effectInfo3;
                stats.statusEffectDataBase.TryGetValue((StatusEffectType)30512, out effectInfo3);
                StatusEffectInfoSO effectInfo4;
                stats.statusEffectDataBase.TryGetValue((StatusEffectType)666888, out effectInfo4);
                StatusEffectInfoSO effectInfo5;
                stats.statusEffectDataBase.TryGetValue((StatusEffectType)456789, out effectInfo5);
                StatusEffectInfoSO effectInfo6;
                stats.statusEffectDataBase.TryGetValue((StatusEffectType)204308, out effectInfo6);
                if (num < 16)
                {
                    for (int index = 0; index < targets.Length; ++index)
                    {
                        if (targets[index].HasUnit)
                        {
                            Focused_StatusEffect focusedStatusEffect = new Focused_StatusEffect();
                            focusedStatusEffect.SetEffectInformation(effectInfo1);
                            if (targets[index].Unit.ApplyStatusEffect((IStatusEffect)focusedStatusEffect, 0))
                                exitAmount += entryVariable;
                        }
                    }
                }
                else if (num < 33)
                {
                    for (int index = 0; index < targets.Length; ++index)
                    {
                        if (targets[index].HasUnit)
                        {
                            Spotlight_StatusEffect spotlightStatusEffect = new Spotlight_StatusEffect();
                            spotlightStatusEffect.SetEffectInformation(effectInfo2);
                            if (targets[index].Unit.ApplyStatusEffect((IStatusEffect)spotlightStatusEffect, 0))
                                exitAmount += entryVariable;
                        }
                    }
                }
                else if (num < 50)
                {
                    for (int index1 = 0; index1 < targets.Length; ++index1)
                    {
                        if (targets[index1].HasUnit)
                        {
                            IStatusEffect growthStatusEffect = new Growth_StatusEffect(entryVariable);
                            growthStatusEffect.SetEffectInformation(effectInfo3);
                            IStatusEffector unit = targets[index1].Unit as IStatusEffector;
                            bool flag = false;
                            int index2 = 999;
                            for (int index3 = 0; index3 < unit.StatusEffects.Count; ++index3)
                            {
                                if (unit.StatusEffects[index3].EffectType == growthStatusEffect.EffectType)
                                {
                                    index2 = index3;
                                    flag = true;
                                }
                            }
                            if (flag == true)
                            {
                                ConstructorInfo[] constructors = unit.StatusEffects[index2].GetType().GetConstructors();
                                foreach (ConstructorInfo constructor in constructors)
                                {
                                    if (constructor.GetParameters().Length == 2)
                                    {
                                        growthStatusEffect = (IStatusEffect)Activator.CreateInstance(unit.StatusEffects[index2].GetType(), entryVariable, 0);
                                    }
                                }
                            }

                            growthStatusEffect.SetEffectInformation(effectInfo3);
                            if (targets[index1].Unit.ApplyStatusEffect((IStatusEffect)growthStatusEffect, entryVariable))
                                ++exitAmount;
                        }
                    }
                }
                else if (num < 67)
                {
                    for (int index4 = 0; index4 < targets.Length; ++index4)
                    {
                        if (targets[index4].HasUnit)
                        {
                            IStatusEffect protectionStatusEffect = new DemonicProtection_StatusEffect(entryVariable);
                            protectionStatusEffect.SetEffectInformation(effectInfo4);

                            IStatusEffector effector = targets[index4].Unit as IStatusEffector;
                            bool hasItAlready = false;
                            int thisIndex = 999;
                            for (int i = 0; i < effector.StatusEffects.Count; i++)
                            {
                                if (effector.StatusEffects[i].EffectType == protectionStatusEffect.EffectType)
                                {
                                    thisIndex = i;
                                    hasItAlready = true;
                                }
                            }
                            if (hasItAlready == true)
                            {
                                ConstructorInfo[] constructors = effector.StatusEffects[thisIndex].GetType().GetConstructors();
                                foreach (ConstructorInfo constructor in constructors)
                                {
                                    if (constructor.GetParameters().Length == 2)
                                    {
                                        protectionStatusEffect = (IStatusEffect)Activator.CreateInstance(effector.StatusEffects[thisIndex].GetType(), entryVariable, 0);
                                    }
                                }
                            }

                            protectionStatusEffect.SetEffectInformation(effectInfo4);
                            if (targets[index4].Unit.ApplyStatusEffect((IStatusEffect)protectionStatusEffect, entryVariable))
                                ++exitAmount;
                        }
                    }
                }
                else if (num < 84)
                {
                    for (int index7 = 0; index7 < targets.Length; ++index7)
                    {
                        if (targets[index7].HasUnit)
                        {
                            int amount = entryVariable;
                            IStatusEffect powerStatusEffect = new Power_StatusEffect(amount);


                            IStatusEffector effector = targets[index7].Unit as IStatusEffector;
                            bool hasItAlready = false;
                            int thisIndex = 999;
                            for (int i = 0; i < effector.StatusEffects.Count; i++)
                            {
                                if (effector.StatusEffects[i].EffectType == powerStatusEffect.EffectType)
                                {
                                    thisIndex = i;
                                    hasItAlready = true;
                                }
                            }
                            if (hasItAlready == true && powerStatusEffect.GetType() != effector.StatusEffects[thisIndex].GetType())
                            {
                                ConstructorInfo[] constructors = effector.StatusEffects[thisIndex].GetType().GetConstructors();
                                foreach (ConstructorInfo constructor in constructors)
                                {
                                    if (constructor.GetParameters().Length == 2)
                                    {
                                        powerStatusEffect = (IStatusEffect)Activator.CreateInstance(effector.StatusEffects[thisIndex].GetType(), amount, 0);
                                    }
                                }
                            }

                            powerStatusEffect.SetEffectInformation(effectInfo5);
                            if (targets[index7].Unit.ApplyStatusEffect((IStatusEffect)powerStatusEffect, amount))
                                ++exitAmount;
                        }
                    }
                }
                else
                {
                    for (int index10 = 0; index10 < targets.Length; ++index10)
                    {
                        if (targets[index10].HasUnit)
                        {
                            int amount = entryVariable;
                            IStatusEffect numbStatusEffect = new Anesthetics_StatusEffect(amount);



                            IStatusEffector effector = targets[index10].Unit as IStatusEffector;
                            bool hasItAlready = false;
                            int thisIndex = 999;
                            for (int i = 0; i < effector.StatusEffects.Count; i++)
                            {
                                if (effector.StatusEffects[i].EffectType == numbStatusEffect.EffectType)
                                {
                                    thisIndex = i;
                                    hasItAlready = true;
                                }
                            }
                            if (hasItAlready == true)
                            {
                                ConstructorInfo[] constructors = effector.StatusEffects[thisIndex].GetType().GetConstructors();
                                foreach (ConstructorInfo constructor in constructors)
                                {
                                    if (constructor.GetParameters().Length == 2)
                                    {
                                        numbStatusEffect = (IStatusEffect)Activator.CreateInstance(effector.StatusEffects[thisIndex].GetType(), amount, 0);
                                    }
                                }
                            }

                            numbStatusEffect.SetEffectInformation(effectInfo6);
                            if (targets[index10].Unit.ApplyStatusEffect((IStatusEffect)numbStatusEffect, amount))
                                ++exitAmount;
                        }
                    }
                }
                flag1 = exitAmount > 0;
            }
            return flag1;
        }
    }
    public class ApplyPermanentRupturedEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;

            stats.statusEffectDataBase.TryGetValue(StatusEffectType.Ruptured, out var value);

            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i].HasUnit)
                {
                    Ruptured_StatusEffect ruptured_StatusEffect = new Ruptured_StatusEffect(0, 1);
                    ruptured_StatusEffect.SetEffectInformation(value);
                    if (targets[i].Unit.ApplyStatusEffect(ruptured_StatusEffect, 0))
                    {
                        exitAmount++;
                    }
                }
            }


            return exitAmount > 0;
        }
    }
    public class DirectHealLessPassiveAbility : BasePassiveAbilitySO
    {
        [Header("Multiplier Data")]
        [SerializeField]
        [Min(0.0f)]
        private int _modifyVal = 1;


        public override bool IsPassiveImmediate => true;

        public override bool DoesPassiveTrigger => true;

        public bool hasDirectHealed = false;

        public override void TriggerPassive(object sender, object args)
        {
            //Debug.Log("passive started");
            IUnit unit = sender as IUnit;
            if (args is CanHealReference HealBy && HealBy.healAmount > 0)
            {
                if (args is CanHealReference && !(args as CanHealReference).Equals((object)null))
                {
                    if (HealBy.directHeal == true)
                    {
                        hasDirectHealed = true;
                    }
                    else
                    {
                        hasDirectHealed = false;
                    }
                    //CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction((sender as IPassiveEffector).ID, (sender as IPassiveEffector).IsUnitCharacter, GetPassiveLocData().text));
                }
            }
            if (args is IntValueChangeException healIt && healIt.amount > 0)
            {

                if (args is IntValueChangeException && !(args as IntValueChangeException).Equals((object)null))
                {
                    //Debug.Log(hasDirectHealed);
                    if (hasDirectHealed)
                    {
                        healIt.AddModifier((IntValueModifier)new MalnourishedValueModifier(0.25f));
                    }
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
    public class MalnourishedValueModifier : IntValueModifier
    {
        public readonly float decimate;

        public MalnourishedValueModifier(float timesBy)
          : base(70)
        {
            this.decimate = timesBy;
        }

        public override int Modify(int value)
        {
            float thisIs = value;
            thisIs *= this.decimate;
            int gap = (int)Math.Ceiling(thisIs);
            value = gap;
            //Debug.Log("will heal:" + value.ToString());
            return value;
        }
    }
    public class AscendantPassiveAbility : BasePassiveAbilitySO
    {
        [Header("Multiplier Data")]
        [SerializeField]
        [Min(0.0f)]
        private int _modifyVal = 1;

        public override bool IsPassiveImmediate => true;

        public override bool DoesPassiveTrigger => true;

        public override void TriggerPassive(object sender, object args)
        {
            IUnit unit = sender as IUnit;
            IPassiveEffector passiveEffector = sender as IPassiveEffector;
            args = (object)(args as CanHealReference);
            if (!(args is CanHealReference canHealReference) || !canHealReference.directHeal)
                return;
            CombatManager.Instance.AddUIAction((CombatAction)new ShowPassiveInformationUIAction(passiveEffector.ID, passiveEffector.IsUnitCharacter, this.GetPassiveLocData().text, this.passiveIcon));
            canHealReference.value = false;
        }

        public override void OnPassiveConnected(IUnit unit)
        {
        }

        public override void OnPassiveDisconnected(IUnit unit)
        {
        }
    }
    public class ColdHealCondition : EffectorConditionSO
    {
        [SerializeField]
        public bool _passIfTrue = false;

        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is DamageReceivedValueChangeException hitBy)
            {
                if (hitBy.damageType == DamageType.Fire)
                {
                    hitBy.AddModifier(new ColdFireHealMod(effector as IUnit));
                    return true;
                }
            }
            return false;

        }
    }
    public class ColdFireHealMod : IntValueModifier
    {
        public readonly IUnit unit;

        public ColdFireHealMod(IUnit unit)
          : base(800)
        {
            this.unit = unit;
        }

        public override int Modify(int value)
        {
            value *= -1;
            if (this.unit.CurrentHealth - value > this.unit.MaximumHealth)
            {
                value = this.unit.CurrentHealth - this.unit.MaximumHealth;
            }
            return value;
        }
    }
    public class HealingCatalystPassive : BasePassiveAbilitySO
    {
        public override bool IsPassiveImmediate => false;

        public override bool DoesPassiveTrigger => true;

        public override void TriggerPassive(object sender, object args) => CombatManager.Instance.AddSubAction((CombatAction)new PerformLinkedEffectAction(sender as IUnit, args as IntegerReference, false));

        public override void OnPassiveConnected(IUnit unit)
        {
        }

        public override void OnPassiveDisconnected(IUnit unit)
        {
        }
    }
    public class CountdownCheckCondition : EffectConditionSO
    {
        public int checkagainst = 0;
        public bool higherthanor = false;
        public UnitStoredValueNames _valueName = UnitStoredValueNames.None;
        public int minimumAmount = 0;

        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            int storedValue = caster.GetStoredValue(this._valueName);
            return !this.higherthanor ? storedValue < this.checkagainst : storedValue >= this.checkagainst;
        }
    }
    public class ApplyOilPermanent : EffectSO
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
            if (entryVariable <= 0)
                return false;
            StatusEffectInfoSO effectInfo;
            stats.statusEffectDataBase.TryGetValue(StatusEffectType.OilSlicked, out effectInfo);
            for (int index = 0; index < targets.Length; ++index)
            {
                if (targets[index].HasUnit)
                {
                    OilSlicked_StatusEffect slickedStatusEffect = new OilSlicked_StatusEffect(0, 1);
                    slickedStatusEffect.SetEffectInformation(effectInfo);
                    if (targets[index].Unit.ApplyStatusEffect((IStatusEffect)slickedStatusEffect, 0))
                        exitAmount += entryVariable;
                }
            }
            return exitAmount > 0;
        }
    }
    public class ReviveFriendEnemyEffect : EffectSO
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
            CombatManager.Instance.AddSubAction((CombatAction)new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1]
            {
          new Effect((EffectSO) ScriptableObject.CreateInstance<ResurrectSomeoneRandomEnemyEffect>(), entryVariable, new IntentType?(), Slots.SlotTarget(new int[9]
          {
            -4,
            -3,
            -2,
            -1,
            0,
            1,
            2,
            3,
            4
          }, caster.IsUnitCharacter))
            }), caster));
            return true;
        }
    }
    public class ResurrectSomeoneRandomEnemyEffect : EffectSO
    {
        public bool IsntSuperboss(EnemyCombat enemy)
        {
            if (enemy.Name == "Strange Box")
                return false;
            if (enemy.Name == "544517")
                return false;
            if (enemy.Name == "544516")
                return false;
            if (enemy.Name == "544515")
                return false;
            if (enemy.Name == "544514")
                return false;
            if (enemy.Name == "544513")
                return false;
            return true;
        }
        public override bool PerformEffect(
          CombatStats stats,
          IUnit caster,
          TargetSlotInfo[] targets,
          bool areTargetSlots,
          int entryVariable,
          out int exitAmount)
        {
            exitAmount = 0;
            int candidatesLength = 0;
            exitAmount = 0;
            for (int index = 0; index < stats.Enemies.Count; index++)
            {
                EnemyCombat targetEnemy = stats.Enemies[index];
                if (!targetEnemy.IsAlive && !targetEnemy.HasFled && !targetEnemy.ContainsPassiveAbility((PassiveAbilityTypes)62411) && IsntSuperboss(targetEnemy))
                {
                    candidatesLength++;
                }
            }
            if (candidatesLength <= 0)
            {
                return false;
            }
            int[] candidates = new int[candidatesLength];
            int addAt = 0;
            for (int index = 0; index < stats.Enemies.Count; index++)
            {
                EnemyCombat targetEnemy = stats.Enemies[index];
                if (!targetEnemy.IsAlive && !targetEnemy.HasFled && !targetEnemy.ContainsPassiveAbility((PassiveAbilityTypes)62411) && IsntSuperboss(targetEnemy))
                {
                    if (addAt < candidates.Length)
                    {
                        candidates[addAt] = index;
                        addAt++;
                    }
                }
            }
            List<TargetSlotInfo> targetSlotInfoList = new List<TargetSlotInfo>();
            foreach (TargetSlotInfo target in targets)
            {
                if (!target.HasUnit)
                    targetSlotInfoList.Add(target);
            }

            int picking = UnityEngine.Random.Range(0, candidates.Length);
            int choosing = candidates[picking];
            EnemyCombat TargetEnemy = stats.Enemies[choosing];
            if (!TargetEnemy.IsAlive && !TargetEnemy.HasFled && !TargetEnemy.ContainsPassiveAbility((PassiveAbilityTypes)62411) && IsntSuperboss(TargetEnemy))
            {
                int num = stats.GetRandomEnemySlot(TargetEnemy.Enemy.size);
                if (num != -1)
                {
                    if (stats.AddNewEnemy(TargetEnemy.Enemy, num, false, SpawnType.Basic))
                    {
                        TargetEnemy.HasFled = true;
                        exitAmount++;
                        EnemyCombat newborn = stats.Enemies[stats.Enemies.Count - 1];
                        if (newborn is IUnit unit)
                        {
                            exitAmount++;
                        }
                    }
                }
            }
            return exitAmount > 0;
        }
    }
    public class RandomizeStoredValueEffect : EffectSO
    {
        [SerializeField]
        public bool _ignoreIfContains;
        [SerializeField]
        public UnitStoredValueNames _valueName = UnitStoredValueNames.PunchA;

        public override bool PerformEffect(
          CombatStats stats,
          IUnit caster,
          TargetSlotInfo[] targets,
          bool areTargetSlots,
          int entryVariable,
          out int exitAmount)
        {
            exitAmount = 0;
            if (this._ignoreIfContains && caster.ContainsStoredValue(this._valueName))
                return false;
            caster.SetStoredValue(this._valueName, UnityEngine.Random.Range(-4, 5));
            return true;
        }
    }
    public class CasterCheckStoredValueCondition : EffectConditionSO
    {
        public UnitStoredValueNames _valueName = UnitStoredValueNames.None;
        public int minimumAmount = 1;

        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex) => caster.GetStoredValue(this._valueName) >= 5;
    }
    public class DamageFromNobodyEffect : EffectSO
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
            if (_usePreviousExitValue)
            {
                entryVariable *= base.PreviousExitValue;
            }

            exitAmount = 0;
            bool flag = false;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (targetSlotInfo.HasUnit)
                {
                    int targetSlotOffset = (areTargetSlots ? (targetSlotInfo.SlotID - targetSlotInfo.Unit.SlotID) : (-1));
                    int amount = entryVariable;
                    DamageInfo damageInfo;
                    if (_indirect)
                    {
                        damageInfo = targetSlotInfo.Unit.Damage(amount, null, _deathType, targetSlotOffset, addHealthMana: false, directDamage: false, ignoresShield: true);
                    }
                    else
                    {
                        amount = entryVariable;
                        damageInfo = targetSlotInfo.Unit.Damage(amount, null, _deathType, targetSlotOffset, addHealthMana: true, directDamage: true, _ignoreShield);
                    }

                    flag |= damageInfo.beenKilled;
                    exitAmount += damageInfo.damageAmount;
                }
            }

            if (!_returnKillAsSuccess)
            {
                return exitAmount > 0;
            }

            return flag;
        }
    }
    public class LensFlashEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            PreviousEffectCondition didThat = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            didThat.wasSuccessful = true;
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[]
            {
                new Effect(ScriptableObject.CreateInstance<MoveToClosestTargetEffect>(), 1, IntentType.Swap_Sides, Slots.SlotTarget(new int[9] {-4, -3, -2, -1, 0, 1, 2, 3, 4}, false)),
                new Effect(ScriptableObject.CreateInstance<TakePicEffect>(), 1, IntentType.Misc, Slots.Front, didThat)
            }), caster));
            return true;
        }
    }
    public class FavoritePictureEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            PreviousEffectCondition didThat = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            didThat.wasSuccessful = true;
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[]
            {
                new Effect(ScriptableObject.CreateInstance<MoveToClosestTargetEffect>(), 1, IntentType.Swap_Sides, Slots.SlotTarget(new int[9] {-4, -3, -2, -1, 0, 1, 2, 3, 4}, false)),
                new Effect(ScriptableObject.CreateInstance<SayCheeseEffect>(), 1, IntentType.Misc, Slots.Front, didThat)
            }), caster));
            return true;
        }
    }
    public static class EnemyRefresher
    {
        public static bool RefreshAbilityUse(Func<EnemyCombat, bool> orig, EnemyCombat self)
        {
            CombatManager.Instance._stats.timeline.TryAddNewExtraEnemyTurns(self, 1);
            return true;
        }

        public static bool ExhaustAbilityUse(Func<EnemyCombat, bool> orig, EnemyCombat self)
        {
            return CombatManager.Instance._stats.timeline.TryRemoveRandomEnemyTurns(self, 1) > 0;
        }
        public static void Setup()
        {
            IDetour hook1 = new Hook(typeof(EnemyCombat).GetMethod(nameof(EnemyCombat.RefreshAbilityUse), ~BindingFlags.Default), typeof(EnemyRefresher).GetMethod(nameof(RefreshAbilityUse), ~BindingFlags.Default));
            IDetour hook2 = new Hook(typeof(EnemyCombat).GetMethod(nameof(EnemyCombat.ExhaustAbilityUse), ~BindingFlags.Default), typeof(EnemyRefresher).GetMethod(nameof(ExhaustAbilityUse), ~BindingFlags.Default));
        }
    }
}
