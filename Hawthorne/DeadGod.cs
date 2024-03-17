using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
using THE_DEAD;

namespace Hawthorne
{
    public static class DeadGod
    {
        public static void Add()
        {
            UnmaskPassiveAbility unmasking = ScriptableObject.CreateInstance<UnmaskPassiveAbility>();
            unmasking._passiveName = "Unmasking (10)";
            unmasking.passiveIcon = ResourceLoader.LoadSprite("Unmasking", 32);
            unmasking.type = (PassiveAbilityTypes)544533;
            unmasking._enemyDescription = "Upon taking a certain amount of direct damage or higher, remove Confusion and Obscured as passives from this enemy.";
            unmasking._characterDescription = "Upon taking a certain amount of direct damage or higher, remove Confusion and Obscured as passives from this character.";
            unmasking.doesPassiveTriggerInformationPanel = false;
            unmasking._triggerOn = new TriggerCalls[1] { TriggerCalls.OnDirectDamaged };
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


            Enemy god = new Enemy()
            {
                name = "Embers of a Dead God",
                health = 150,
                size = 1,
                entityID = (EntityIDs)544533,
                healthColor = Pigments.Red,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/TheShitter/DeadGod_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
            };
            god.prefab._gibs = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/TheShitter/DeadGod_Gibs.prefab").GetComponent<ParticleSystem>();
            god.prefab.SetDefaultParams();
            god.combatSprite = ResourceLoader.LoadSprite("DeadGodIconB", 32);
            god.overworldAliveSprite = ResourceLoader.LoadSprite("DeadGodIcon", 32, new Vector2?(new Vector2(0.5f, 0.05f)));
            god.overworldDeadSprite = ResourceLoader.LoadSprite("DeadGodDead", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            god.hurtSound = LoadedAssetsHandler.GetEnemy("SkinningHomunculus_EN").damageSound;
            god.deathSound = LoadedAssetsHandler.GetEnemy("SkinningHomunculus_EN").deathSound;
            god.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            god.passives = new BasePassiveAbilitySO[4]
            {
        Passives.Inferno, Passives.Multiattack, unmasking, WitchSave
            };
            PreviousEffectCondition didntThat = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            didntThat.wasSuccessful = false;
            Ability faith = new Ability();
            faith.name = "Forgotten Faith";
            faith.description = "Apply 1-2 Power to this enemy.";
            faith.rarity = 8;
            faith.effects = new Effect[2];
            faith.effects[0] = new Effect(ScriptableObject.CreateInstance<ApplyPowerEffect>(), 1, new IntentType?((IntentType)987895), Slots.Self);
            faith.effects[1] = new Effect(ScriptableObject.CreateInstance<ApplyPowerEffect>(), 1, new IntentType?(), Slots.Self, Conditions.Chance(66));
            faith.visuals = LoadedAssetsHandler.GetEnemyAbility("UglyOnTheInside_A").visuals;
            faith.animationTarget = Slots.Self;

            AnimationVisualsEffect rightExtrusion = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            rightExtrusion._animationTarget = Slots.Right;
            rightExtrusion._visuals = LoadedAssetsHandler.GetEnemy("OsmanSinnoks_BOSS").abilities[0].ability.visuals;
            SwapToOneSideEffect goLeft = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            goLeft._swapRight = false;
            DamageEffect shieldPierce = ScriptableObject.CreateInstance<DamageEffect>();
            shieldPierce._ignoreShield = true;
            shieldPierce._indirect = false;
            DamageEffect directHit = ScriptableObject.CreateInstance<DamageEffect>();
            directHit._ignoreShield = false;
            directHit._indirect = false;
            directHit._returnKillAsSuccess = false;
            directHit._usePreviousExitValue = false;
            Ability left = new Ability();
            left.name = "Left Hand";
            left.description = "Apply 1 Power to self. Move left and deal a little bit of damage to the right party member.";
            left.rarity = 7;
            left.effects = new Effect[4];
            left.effects[0] = new Effect(goLeft, 1, IntentType.Swap_Left, Slots.Self);
            left.effects[1] = new Effect(rightExtrusion, 1, new IntentType?(), Slots.Self);
            left.effects[2] = new Effect(ScriptableObject.CreateInstance<ApplyPowerEffect>(), 1, new IntentType?((IntentType)987895), Slots.Self);
            left.effects[3] = new Effect(directHit, 2, new IntentType?(IntentType.Damage_1_2), Slots.Right);
            left.animationTarget = Slots.Self;

            AnimationVisualsEffect pepTalk = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            pepTalk._animationTarget = Slots.Left;
            pepTalk._visuals = LoadedAssetsHandler.GetCharacterAbility("PepTalk_1_A").visuals;
            SwapToOneSideEffect goRight = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            goRight._swapRight = true;
            PreviousEffectCondition didThat = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            didThat.wasSuccessful = true;
            Ability right = new Ability();
            right.name = "Right Hand";
            right.description = "Move right and deal a painful amount of damage to the left party member. If damage was dealt, apply 1 Power to this enemy.";
            right.rarity = 8;
            right.effects = new Effect[4];
            right.effects[0] = new Effect(goRight, 1, IntentType.Swap_Right, Slots.Self);
            right.effects[1] = new Effect(pepTalk, 1, new IntentType?(), Slots.Self);
            right.effects[2] = new Effect(directHit, 3, new IntentType?(IntentType.Damage_3_6), Slots.Left);
            right.effects[3] = new Effect(ScriptableObject.CreateInstance<ApplyPowerEffect>(), 1, (IntentType)987895, Slots.Self, didThat);
            right.animationTarget = Slots.Self;

            Ability promised = new Ability();
            promised.name = "Broken Promise";
            promised.description = "Apply 1-2 Power to self. Deal a little bit of damage to the opposing party member. This attack ignores shield. Apply 3 Ruptured to this enemy.";
            promised.rarity = 7;
            promised.effects = new Effect[4];
            promised.effects[0] = new Effect(ScriptableObject.CreateInstance<ApplyPowerEffect>(), 1, new IntentType?((IntentType)987895), Slots.Self);
            promised.effects[1] = new Effect(ScriptableObject.CreateInstance<ApplyPowerEffect>(), 1, new IntentType?(), Slots.Self, Conditions.Chance(60));
            promised.effects[2] = new Effect(shieldPierce, 2, IntentType.Damage_1_2, Slots.Front);
            promised.effects[3] = new Effect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 3, IntentType.Status_Ruptured, Slots.Self);
            promised.visuals = LoadedAssetsHandler.GetEnemyAbility("RingABell_A").visuals;
            promised.animationTarget = Slots.Front;

            Ability apparition = new Ability();
            apparition.name = "Divine Apparition";
            apparition.description = "Move to a random position. Apply 1 fire to self, and 1-10 fire to the opposing party member. 33% chance to apply 1 Frail to self.";
            apparition.rarity = 3;
            apparition.effects = new Effect[3];
            apparition.effects[0] = new Effect(ScriptableObject.CreateInstance<SwapRandomZoneEffectHideIntent>(), 1, IntentType.Swap_Mass, Slots.Self);
            apparition.effects[1] = new Effect(ScriptableObject.CreateInstance<CustomApplyFireSlotEffect>(), 1, IntentType.Field_Fire, Slots.Front);
            apparition.effects[2] = new Effect(ScriptableObject.CreateInstance<ApplyFrailEffect>(), 1, IntentType.Status_Frail, Slots.Self, Conditions.Chance(33));
            apparition.animationTarget = Slots.Self;

            Ability world = new Ability();
            world.name = "A Godless World";
            world.description = "70% chance to give this enemy an additional turn. Apply 1 Power and 1 Scar to this enemy.";
            world.rarity = 4;
            world.effects = new Effect[3];
            world.effects[0] = new Effect(ScriptableObject.CreateInstance<CustomAddTurnToTimelineEffect>(), 1, IntentType.Misc, Slots.Self);
            world.effects[1] = new Effect(ScriptableObject.CreateInstance<ApplyScarsEffect>(), 1, IntentType.Status_Scars, Slots.Self);
            world.effects[2] = new Effect(ScriptableObject.CreateInstance<ApplyPowerEffect>(), 1, new IntentType?((IntentType)987895), Slots.Self);
            world.animationTarget = Slots.Self;

            AddPassiveEffect obscureIt = ScriptableObject.CreateInstance<AddPassiveEffect>();
            obscureIt._passiveToAdd = Passives.Confusion;
            Ability blind = new Ability();
            blind.name = "Blind Trust";
            blind.description = "Apply Confusion as a passive to this enemy.";
            blind.rarity = 3;
            blind.effects = new Effect[1];
            blind.effects[0] = new Effect(obscureIt, 1, IntentType.Misc, Slots.Self);
            blind.visuals = LoadedAssetsHandler.GetCharacterAbility("Entwined_1_A").visuals;
            blind.animationTarget = Slots.Self;


            UnlockShitEffect itswings = ScriptableObject.CreateInstance<UnlockShitEffect>();
            itswings.AddThis(ItsWings.Wings);
            god.exitEffects = new Effect[1]
            {
                new Effect((EffectSO) itswings, 0, new IntentType?(), Slots.Self)
            };

            god.loot = new EnemyLootItemProbability[1]
              {
                new EnemyLootItemProbability()
                {
                  isItemTreasure = true,
                  amount = 3,
                  probability = 100
                }
              };

            god.abilities = new Ability[7] { faith, left, right, promised, apparition, world, blind };
            god.AddEnemy();
        }
    }
    public class UnmaskPassiveAbility : BasePassiveAbilitySO
    {
        [Header("Multiplier Data")]
        [SerializeField]
        [Min(0.0f)]
        private int _modifyVal = 1;
        [SerializeField]
        public int _floorVal = 10;


        public override bool IsPassiveImmediate => true;

        public override bool DoesPassiveTrigger => true;

        public override void TriggerPassive(object sender, object args)
        {
            //Debug.Log("passive started");
            IUnit unit = sender as IUnit;

            if (args is IntegerReference HitBy && HitBy.value >= _floorVal)
            {
                IPassiveEffector passiveEffector = sender as IPassiveEffector;
                if (unit.ContainsPassiveAbility(PassiveAbilityTypes.Confusion) || unit.ContainsPassiveAbility(PassiveAbilityTypes.Obscure))
                    CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(passiveEffector.ID, passiveEffector.IsUnitCharacter, GetPassiveLocData().text, this.passiveIcon));
                RemovePassiveEffect unmask = ScriptableObject.CreateInstance<RemovePassiveEffect>();
                unmask._passiveToRemove = PassiveAbilityTypes.Obscure;
                RemovePassiveEffect unmask2 = ScriptableObject.CreateInstance<RemovePassiveEffect>();
                unmask2._passiveToRemove = PassiveAbilityTypes.Confusion;
                Effect e1 = new Effect(unmask, 1, new IntentType?(), Slots.Self);
                Effect e2 = new Effect(unmask2, 1, new IntentType?(), Slots.Self);
                
                CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[2] { e1, e2 }), unit));
                if (DoDebugs.MiscInfo) Debug.Log("passives removed");
            }
        }

        public override void OnPassiveConnected(IUnit unit)
        {
        }

        public override void OnPassiveDisconnected(IUnit unit)
        {
        }
    }
    public class CustomApplyFireSlotEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (entryVariable <= 0)
            {
                return false;
            }
            stats.slotStatusEffectDataBase.TryGetValue(SlotStatusEffectType.OnFire, out var value);
            for (int i = 0; i < targets.Length; i++)
            {
                entryVariable = UnityEngine.Random.Range(1, 4);
                if (UnityEngine.Random.Range(0, 100) < 5)
                    entryVariable = UnityEngine.Random.Range(4, 10);
                if (targets[i].HasUnit)
                {
                    if (DoDebugs.MiscInfo) Debug.Log("has unit");
                    if (targets[i].Unit is CharacterCombat character)
                    {
                        if (DoDebugs.MiscInfo) Debug.Log("is a character combat");
                        if (character._currentName == "Cranes")
                        {
                            entryVariable = 10;
                            if (DoDebugs.MiscInfo) Debug.Log("heheheha");
                        }
                    }
                }
                AnimationVisualsEffect animYAY = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
                animYAY._animationTarget = Slots.Self;
                animYAY._visuals = ((AnimationVisualsEffect)((PerformEffectWearable)LoadedAssetsHandler.GetWearable("DemonCore_SW")).effects[0].effect)._visuals;
                AnimationVisualsEffect animBOO = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
                animBOO._animationTarget = Slots.Self;
                animBOO._visuals = LoadedAssetsHandler.GetCharacterAbility("Torch_1_A").visuals; ;
                Effect fire = new Effect(ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), entryVariable, IntentType.Field_Fire, Slots.Front);
                Effect selfFire = new Effect(ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), 1, IntentType.Field_Fire, Slots.Self);
                Effect animIS = new Effect(animBOO, 1, new IntentType?(), Slots.Self);
                if (entryVariable > 3)
                    animIS._effect = animYAY;
                CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[3] { animIS, fire, selfFire }), caster));
                exitAmount += entryVariable;
            }

            return exitAmount > 0;
        }
    }
    public class SwapToRandomZoneEffect : EffectSO
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
            if (stats.combatSlots.SlotContainsSlotStatusEffect(caster.SlotID, false, SlotStatusEffectType.Constricted))
            {
                return false;
            }
            if (caster.CurrentHealth < 1)
            {
                return false;
            }
            foreach (TargetSlotInfo target in targets)
            {
                int secondSlotID = UnityEngine.Random.Range(0, 5);
                if (secondSlotID == 5)
                {
                    //Debug.Log("failed, ran again");
                    //Debug.Log("second Slot was out of bounds");
                    Effect swapAgain = new Effect(ScriptableObject.CreateInstance<SwapToRandomZoneEffect>(), 1, new IntentType?(), Slots.SlotTarget(new int[9] { -4, -3, -2, -1, 0, 1, 2, 3, 4 }, true));
                    CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { swapAgain }), caster));
                    return false;
                }
                if (secondSlotID == caster.SlotID)
                {
                    //Debug.Log("effect ran but second slot ID was caster Slot ID so it didn't move");
                    return exitAmount > 0;
                }
                if (secondSlotID != caster.SlotID)
                {
                    /*if (stats.combatSlots.CanEnemiesSwap(caster.SlotID, secondSlotID, out var firstSlotSwap, out var secondSlotSwap))
                    {*/
                        //Debug.Log("caster.SlotID:");
                        //Debug.Log(caster.SlotID);
                        //Debug.Log("secondSlotID:");
                        //Debug.Log(secondSlotID);
                    /*if (caster.SlotID != secondSlotSwap || secondSlotID != firstSlotSwap)
                    {
                        Debug.Log("failed, ran again");
                        if (caster.SlotID != secondSlotSwap)
                        {
                            Debug.Log("caster slot not equal second slot target");
                        }
                        if (secondSlotID != firstSlotSwap)
                        {
                            Debug.Log("target slot not equal caster slot target");
                        }
                        Effect swapAgain = new Effect(ScriptableObject.CreateInstance<SwapToRandomZoneEffect>(), 1, new IntentType?(), Slots.Self);
                        CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { swapAgain }), caster));
                        return false;
                    }*/
                    int thisTarget = 0;
                    for (int i = 0; i < targets.Length; i++)
                    {
                        if (targets[i].SlotID == secondSlotID)
                        {
                            thisTarget = i;
                            //Debug.Log("found it");
                        }
                    }
                    TargetSlotInfo unit2 = targets[thisTarget];
                    if (unit2.HasUnit)
                    {
                        //Debug.Log(unit2.Unit.SlotID);
                    }
                    if (!unit2.HasUnit)
                    {
                        //Debug.Log("empty slot");
                    }
                    bool hasRight = false;
                    for (int i = 0; i < targets.Length; i++)
                    {
                        if (targets[i].SlotID == caster.SlotID + 1)
                        {
                            //Debug.Log("found it");
                            hasRight = targets[i].HasUnit;
                        }
                    }
                    bool hasLeft = false;
                    for (int i = 0; i < targets.Length; i++)
                    {
                        if (targets[i].SlotID == caster.SlotID - 1)
                        {
                            //Debug.Log("found it");
                            hasLeft = targets[i].HasUnit;
                        }
                    }



                    /*if (secondSlotID > 0)
                        {
                            Debug.Log("second slot id isnt 0");
                            CombatSlot checkIf2Tile = new CombatSlot(secondSlotID - 1, false);
                            if (checkIf2Tile.HasUnit)
                            {
                                Debug.Log("has unit");
                                if (checkIf2Tile.Unit.Size > 1)
                                {
                                    Debug.Log("big enemy");
                                    Debug.Log(checkIf2Tile.Unit.Size);
                                    {
                                        unit2 = checkIf2Tile;
                                    }
                                }
                            }
                            Debug.Log("should have checked if 2 or bigger tile");
                        }*/
                    /*if (!stats.combatSlots.CanEnemiesSwap(caster.SlotID, secondSlotID, out var firstSlotSwap, out var secondSlotSwap))
                    {
                        Debug.Log("they can't swap for whatever reason, run it again.");
                        Debug.Log("caster slot id");
                        Debug.Log(caster.SlotID);
                        Debug.Log("caster moves to slot");
                        Debug.Log(firstSlotSwap);
                        Debug.Log("target slot id");
                        Debug.Log(secondSlotID);
                        Debug.Log("target unit moves to slot");
                        Debug.Log(secondSlotSwap);
                        Effect swap2 = new Effect(ScriptableObject.CreateInstance<SwapToRandomZoneEffect>(), 1, new IntentType?(), Slots.SlotTarget(new int[9] {-4, -3, -2, -1, 0, 1, 2, 3, 4}, true));
                        CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { swap2 }), caster));
                        return false;
                    }*/
                    //Debug.Log("can swap");
                    if (unit2.HasUnit == false)
                    {
                        //Debug.Log("slot is empty");
                        if (stats.combatSlots.CanEnemiesSwap(caster.SlotID, secondSlotID, out var firstSlotSwapA, out var secondSlotSwapA))
                        {
                            if (stats.combatSlots.SwapEnemies(caster.SlotID, firstSlotSwapA, secondSlotID, secondSlotSwapA))
                            {
                                //Debug.Log("moved!!");
                                exitAmount++;
                                return exitAmount > 0;
                            }
                        }
                    }
                    //Debug.Log("has unit");
                    if (caster.Size == 1 && unit2.Unit.Size == 1)
                    {
                        //Debug.Log("both are size 1");
                        if (stats.combatSlots.SwapEnemies(caster.SlotID, secondSlotID, secondSlotID, caster.SlotID))
                        {
                            //Debug.Log("moved!!");
                            exitAmount++;
                            return exitAmount > 0;
                        }
                    }
                    if (caster.Size == 1 && unit2.Unit.Size == 2)
                    {
                        //Debug.Log("caster is size 1, target is size 2");
                        if (caster.SlotID + 1 == unit2.Unit.SlotID)
                        {
                            //Debug.Log("2 size target is 1 right from caster");
                            //Debug.Log("second slot id:");
                            //Debug.Log(secondSlotID);
                            //Debug.Log("unit 2 slot id:");
                            //Debug.Log(unit2.Unit.SlotID);
                            if (secondSlotID == unit2.Unit.SlotID)
                            {
                                //Debug.Log("second slot id is same as unit 2 slot id");
                                if (stats.combatSlots.SwapEnemies(caster.SlotID, secondSlotID + 1, unit2.Unit.SlotID, caster.SlotID))
                                {
                                    //Debug.Log("moved!!");
                                    exitAmount++;
                                    return exitAmount > 0;
                                }
                            }
                            if (secondSlotID - 1 == unit2.Unit.SlotID)
                            {
                                //Debug.Log("second slot id +1 to unit 2 slot id");
                                if (stats.combatSlots.SwapEnemies(caster.SlotID, secondSlotID, unit2.Unit.SlotID, caster.SlotID))
                                {
                                    //Debug.Log("moved!!");
                                    exitAmount++;
                                    return exitAmount > 0;
                                }
                            }
                        }
                        if (caster.SlotID - 2 == unit2.Unit.SlotID)
                        {
                            //Debug.Log("2 size target is 1 left from caster");
                            //Debug.Log("second slot id:");
                            //Debug.Log(secondSlotID);
                            //Debug.Log("unit 2 slot id:");
                            //Debug.Log(unit2.Unit.SlotID);
                            if (secondSlotID == unit2.Unit.SlotID)
                            {
                                //Debug.Log("second slot id is same as unit 2 slot id");
                                if (stats.combatSlots.SwapEnemies(caster.SlotID, secondSlotID, unit2.Unit.SlotID, caster.SlotID -1))
                                {
                                    //Debug.Log("moved!!");
                                    exitAmount++;
                                    return exitAmount > 0;
                                }
                            }
                            if (secondSlotID - 1 == unit2.Unit.SlotID)
                            {
                                //Debug.Log("second slot id +1 to unit 2 slot id");
                                if (stats.combatSlots.SwapEnemies(caster.SlotID, secondSlotID -1, unit2.Unit.SlotID, caster.SlotID -1))
                                {
                                    //Debug.Log("moved!!");
                                    exitAmount++;
                                    return exitAmount > 0;
                                }
                            }
                        }
                        //Debug.Log("caster is not next to 2 size target.");
                        if (caster.SlotID == 4)
                        {
                            //Debug.Log("caster is in rightmost slot");
                            //Debug.Log("second slot id:");
                            //Debug.Log(secondSlotID);
                            //Debug.Log("unit 2 slot id:");
                            //Debug.Log(unit2.Unit.SlotID);
                            if (hasLeft == false)
                            {
                                if (stats.combatSlots.SwapEnemies(caster.SlotID, unit2.Unit.SlotID + 1, unit2.Unit.SlotID, caster.SlotID - 1))
                                {
                                    if (hasLeft == true)
                                    {
                                        //Debug.Log("caster has unit to the left");
                                        stats.combatSlots.SwapEnemies(caster.SlotID - 1, unit2.Unit.SlotID, unit2.Unit.SlotID, caster.SlotID - 1);
                                    }
                                    //Debug.Log("moved!!");
                                    exitAmount++;
                                    return exitAmount > 0;
                                }
                            }
                        }
                        if (caster.SlotID == 0)
                        {
                            //Debug.Log("caster is in leftmost slot");
                            //Debug.Log("second slot id:");
                            //Debug.Log(secondSlotID);
                            //Debug.Log("unit 2 slot id:");
                            //Debug.Log(unit2.Unit.SlotID);
                            if (hasRight == false)
                            {
                                if (stats.combatSlots.SwapEnemies(caster.SlotID, unit2.Unit.SlotID, unit2.Unit.SlotID, caster.SlotID))
                                {
                                    if (hasRight == true)
                                    {
                                        //Debug.Log("caster has unit to the right");
                                        stats.combatSlots.SwapEnemies(caster.SlotID + 1, unit2.Unit.SlotID + 1, unit2.Unit.SlotID, caster.SlotID);
                                    }
                                    //Debug.Log("moved!!");
                                    exitAmount++;
                                    return exitAmount > 0;
                                }
                            }
                        }
                        if (caster.SlotID != 4 && caster.SlotID != 0)
                        {
                            //Debug.Log("caster is not in rightmost or leftmost slot.");
                            //Debug.Log("second slot id:");
                            //Debug.Log(secondSlotID);
                            //Debug.Log("unit 2 slot id:");
                            //Debug.Log(unit2.Unit.SlotID);
                            if (secondSlotID == unit2.Unit.SlotID)
                            {
                                //Debug.Log("target slot is same as unit slot");
                                if (hasRight == false)
                                {
                                    if (stats.combatSlots.SwapEnemies(caster.SlotID, secondSlotID, unit2.Unit.SlotID, caster.SlotID))
                                    {
                                        if (hasRight == true)
                                        {
                                            //Debug.Log("caster has unit to the right");
                                            stats.combatSlots.SwapEnemies(caster.SlotID + 1, secondSlotID + 1, secondSlotID, caster.SlotID);
                                        }
                                        //Debug.Log("moved!!");
                                        exitAmount++;
                                        return exitAmount > 0;
                                    }
                                }
                                else if (hasLeft == false)
                                {
                                    if (stats.combatSlots.SwapEnemies(caster.SlotID, secondSlotID, unit2.Unit.SlotID, caster.SlotID - 1))
                                    {
                                        //Debug.Log("moved!!");
                                        exitAmount++;
                                        return exitAmount > 0;
                                    }
                                }
                            }
                            if (secondSlotID + 1 == unit2.Unit.SlotID)
                            {
                                //Debug.Log("target slot is not same as unit slot");
                                if (hasLeft == false)
                                {
                                    if (stats.combatSlots.SwapEnemies(caster.SlotID, secondSlotID, secondSlotID - 1, caster.SlotID - 1))
                                    {
                                        if (hasLeft == true)
                                        {
                                            //Debug.Log("caster has unit to the left");
                                            stats.combatSlots.SwapEnemies(caster.SlotID - 1, unit2.Unit.SlotID, unit2.Unit.SlotID, caster.SlotID - 1);
                                        }
                                        //Debug.Log("moved!!");
                                        exitAmount++;
                                        return exitAmount > 0;
                                    }
                                }
                                else if (hasRight == false)
                                {
                                    if (stats.combatSlots.SwapEnemies(caster.SlotID, secondSlotID, secondSlotID - 1, caster.SlotID))
                                    {
                                        //Debug.Log("moved!!");
                                        exitAmount++;
                                        return exitAmount > 0;
                                    }
                                }
                            }
                        }
                    }
                    if (unit2.Unit.Size >= 3)
                    {
                        //Debug.Log("target unit is size 3 or greater, fuck this.");
                        //Debug.Log("Swap sides effect");
                        Effect swapSides = new Effect(ScriptableObject.CreateInstance<CustomSwapToSidesEffect>(), 1, new IntentType?(), Slots.Self);
                        CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { swapSides }), caster));
                        exitAmount++;
                        return exitAmount > 0;
                    }
                    
                    
                    //Debug.Log("failed, ran again");
                    Effect swapAgain = new Effect(ScriptableObject.CreateInstance<SwapToRandomZoneEffect>(), 1, new IntentType?(), Slots.SlotTarget(new int[9] { -4, -3, -2, -1, 0, 1, 2, 3, 4 }, true));
                    CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { swapAgain }), caster));
                    return exitAmount > 0;
                    
                }
            }
            return exitAmount > 0;
        }
    }
    public class CustomAddTurnToTimelineEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (caster.IsUnitCharacter || entryVariable <= 0)
            {
                return false;
            }

            AnimationVisualsEffect animBOO = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            animBOO._animationTarget = Slots.Self;
            animBOO._visuals = LoadedAssetsHandler.GetCharacterAbility("Insult_1_A").visuals;
            AnimationVisualsEffect animYAY = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            animYAY._animationTarget = Slots.Self;
            animYAY._visuals = LoadedAssetsHandler.GetEnemyAbility("InhumanRoar_A").visuals;
            Effect addTurn = new Effect(ScriptableObject.CreateInstance<AddTurnCasterToTimelineEffect>(), 1, IntentType.Misc, Slots.Self);
            Effect animIS = new Effect(animYAY, 1, new IntentType?(), Slots.Self);
            Effect animNOT = new Effect(animBOO, 1, new IntentType?(), Slots.Self);

            if (UnityEngine.Random.Range(0, 100) < 75)
                CombatManager.Instance.AddPrioritySubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[2] { animIS, addTurn }), caster));
            else
                CombatManager.Instance.AddPrioritySubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { animNOT }), caster));

            return true;
        }
    }
    
    public class PerformEffectImmediatePassiveAbility : BasePassiveAbilitySO
    {
        [Header("Passive Effects")]
        public EffectInfo[] effects;

        public override bool IsPassiveImmediate => true;

        public override bool DoesPassiveTrigger => true;

        public override void TriggerPassive(object sender, object args)
        {
            IUnit caster = sender as IUnit;
            CombatManager.Instance.AddPrioritySubAction(new EffectAction(effects, caster));
        }

        public override void OnPassiveConnected(IUnit unit)
        {
        }

        public override void OnPassiveDisconnected(IUnit unit)
        {
        }
    }
    public class CustomSwapToSidesEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            List<IUnit> list = new List<IUnit>();
            List<IUnit> list2 = new List<IUnit>();
            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i].HasUnit)
                {
                    IUnit unit = targets[i].Unit;
                    if (unit.IsUnitCharacter && !list.Contains(unit))
                    {
                        list.Add(unit);
                    }
                    else if (!unit.IsUnitCharacter && !list2.Contains(unit))
                    {
                        list2.Add(unit);
                    }
                }
            }

            foreach (IUnit item in list)
            {
                int num = UnityEngine.Random.Range(0, 2) * 2 - 1;
                if (item.SlotID + num >= 0 && item.SlotID + num < stats.combatSlots.CharacterSlots.Length)
                {
                    if (stats.combatSlots.SwapCharacters(item.SlotID, item.SlotID + num, isMandatory: true))
                    {
                        exitAmount++;
                        return exitAmount > 0;
                    }

                    continue;
                }

                num *= -1;
                if (item.SlotID + num >= 0 && item.SlotID + num < stats.combatSlots.CharacterSlots.Length && stats.combatSlots.SwapCharacters(item.SlotID, item.SlotID + num, isMandatory: true))
                {
                    exitAmount++;
                    return exitAmount > 0;
                }
            }

            foreach (IUnit item2 in list2)
            {
                int num = UnityEngine.Random.Range(0, 2) * (item2.Size + 1) - 1;
                if (stats.combatSlots.CanEnemiesSwap(item2.SlotID, item2.SlotID + num, out var firstSlotSwap, out var secondSlotSwap))
                {
                    if (stats.combatSlots.SwapEnemies(item2.SlotID, firstSlotSwap, item2.SlotID + num, secondSlotSwap))
                    {
                        exitAmount++;
                        return exitAmount > 0;
                    }

                    continue;
                }

                num = ((num < 0) ? item2.Size : (-1));
                if (stats.combatSlots.CanEnemiesSwap(item2.SlotID, item2.SlotID + num, out firstSlotSwap, out secondSlotSwap) && stats.combatSlots.SwapEnemies(item2.SlotID, firstSlotSwap, item2.SlotID + num, secondSlotSwap))
                {
                    exitAmount++;
                    return exitAmount > 0;
                }
            }
            if (DoDebugs.MiscInfo) Debug.Log("failed somehow");
            Effect swapAgain = new Effect(ScriptableObject.CreateInstance<SwapToRandomZoneEffect>(), 1, new IntentType?(), Slots.SlotTarget(new int[9] { -4, -3, -2, -1, 0, 1, 2, 3, 4 }, true));
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { swapAgain }), caster));
            return exitAmount > 0;
        }
    }

    public class UnlockShitEffect : EffectSO
    {
        public Item[] _unlocks;

        public void AddThis(Item item)
        {
            _unlocks = new Item[] { item };
        }

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (caster.CurrentHealth > 0) return false;
            foreach (Item item in _unlocks)
            {
                if (item is UnlockItem unlock)
                    unlock.GetItem();
                else if (item is DoubleEffectUnlockItem glock)
                    glock.GetItem();
            }
            return true;
        }
    }
}

