using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;
using UnityEngine;
using THE_DEAD;
using Hawthorne.gay;

namespace Hawthorne
{
    public static class Satyr
    {
        public static EnemySO Field1 = null;
        public static bool EF1 = false;
        public static EnemySO Field2 = null;
        public static bool EF2 = false;
        public static EnemySO Field3 = null;
        public static bool EF3 = false;
        public static EnemySO Field4 = null;
        public static bool EF4 = false;
        public static EnemySO Field5 = null;
        public static bool EF5 = false;
        public static void Add()
        {
            if (DoDebugs.GenInfo) Debug.Log("add started");
            Enemy satyr = new Enemy()
            {
                name = "Satyr",
                health = 50,
                size = 1,
                entityID = (EntityIDs)54428,
                healthColor = Pigments.Red,
                priority = -1,
                prefab = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/Senis2/Satyr_Enemy.prefab").AddComponent<MultiSpriteEnemyLayout>()
            };
            if (DoDebugs.GenInfo) Debug.Log("enemy prefab");
            satyr.prefab._gibs = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/Senis2/Satyr_Giblets.prefab").GetComponent<ParticleSystem>();
            satyr.prefab.SetDefaultParams();
            (satyr.prefab as MultiSpriteEnemyLayout).OtherRenderers = new SpriteRenderer[]
            {
                satyr.prefab._locator.transform.Find("Sprite").Find("TorsoBack").GetComponent<SpriteRenderer>(),
            };
            if (DoDebugs.GenInfo) Debug.Log("prefabs");
            satyr.combatSprite = ResourceLoader.LoadSprite("Icon_Satyr_B", 32);
            satyr.overworldAliveSprite = ResourceLoader.LoadSprite("Icon_Satyr", 32, new Vector2?(new Vector2(0.5f, 0.05f)));
            satyr.overworldDeadSprite = ResourceLoader.LoadSprite("Icon_Satyr_Dead", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            if (DoDebugs.GenInfo) Debug.Log("sprites");
            satyr.hurtSound = LoadedAssetsHandler.GetEnemy("Sepulchre_EN").damageSound;
            satyr.deathSound = LoadedAssetsHandler.GetEnemy("Sepulchre_EN").deathSound;
            if (DoDebugs.GenInfo) Debug.Log("sounds");
            satyr.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_Satyr>();
            satyr.passives = new BasePassiveAbilitySO[1]
            {
                Passives.Skittish
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
            DamageEffect indirect = ScriptableObject.CreateInstance<DamageEffect>();
            indirect._indirect = true;
            Ability sweet = new Ability();
            sweet.name = "Sweet Flavour";
            if (UnityEngine.Random.Range(0, 100) < 50)
                sweet.name = "Sweet Flavor";
            sweet.description = "Attempt to revive a dead enemy with a third of its maximum health. If successful, deal a mortal amount of indirect damage to self.";
            sweet.rarity = 5;
            sweet.effects = new Effect[2];
            sweet.effects[0] = new Effect(ScriptableObject.CreateInstance<SpawnEnemyFromDeadListEffect>(), 1, IntentType.Misc, Slots.Self);
            sweet.effects[1] = new Effect(indirect, 30, IntentType.Damage_21, Slots.Self, didThat);
            sweet.visuals = LoadedAssetsHandler.GetEnemy("HeavensGateRed_BOSS").abilities[1].ability.visuals;
            sweet.animationTarget = Slots.Self;

            CustomChangeToRandomHealthColorEffect randomize = ScriptableObject.CreateInstance<CustomChangeToRandomHealthColorEffect>();
            randomize._healthColors = new ManaColorSO[4]
            {
            Pigments.Red,
            Pigments.Blue,
            Pigments.Yellow,
            Pigments.Purple
            };
            SwapToOneSideEffect moveLeft = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            moveLeft._swapRight = false;
            SwapToOneSideEffect moveRight = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            moveRight._swapRight = true;

            Ability savory = new Ability();
            savory.name = "Savory Flavour";
            if (UnityEngine.Random.Range(0, 100) < 50)
                savory.name = "Savory Flavor";
            savory.description = "Attempt to revive a dead enemy. If successful, apply 1 Divine Protection to the enemy, deal its current health as indirect damage to it, then remove all Divine Protection from it.";
            savory.rarity = 5;
            savory.effects = new Effect[1];
            savory.effects[0] = new Effect(ScriptableObject.CreateInstance<ReviveReKillEnemyEffect>(), 1, IntentType.Misc, Slots.Self);
            savory.visuals = LoadedAssetsHandler.GetCharacterAbility("OfDeath_1_A").visuals;
            savory.animationTarget = Slots.Self;

            IncreaseStatusEffectsEffect increaseAllStatus = ScriptableObject.CreateInstance<IncreaseStatusEffectsEffect>();
            increaseAllStatus._increasePositives = true;
            IncreaseStatusEffectsEffect increaseAllStatus2 = ScriptableObject.CreateInstance<IncreaseStatusEffectsEffect>();
            increaseAllStatus2._increasePositives = false;
            Ability sour = new Ability();
            sour.name = "Sour Flavour";
            if (UnityEngine.Random.Range(0, 100) < 50)
                sour.name = "Sour Flavor";
            sour.description = "Apply 7 Determined to the left and right enemies. If successful, deal a lethal amount of indirect damage to the left and right enemies.";
            sour.rarity = 5;
            sour.effects = new Effect[2];
            sour.effects[0] = new Effect(ScriptableObject.CreateInstance<ApplyDeterminedEffect>(), 7, new IntentType?((IntentType)987896), Slots.Sides);
            sour.effects[1] = new Effect(indirect, 15, IntentType.Damage_11_15, Slots.Sides, didThat);
            sour.visuals = CustomVisuals.GetVisuals("Salt/Sprout");
            sour.animationTarget = Slots.Sides;
            Extra1Or2LootOptionsEffect TApple = ScriptableObject.CreateInstance<Extra1Or2LootOptionsEffect>();
            TApple._itemName = "TaintedApple_TW";
            SatyrAnimationVisualsEffect bitterAnim = ScriptableObject.CreateInstance<SatyrAnimationVisualsEffect>();
            bitterAnim._visuals = LoadedAssetsHandler.GetEnemy("TriggerFingers_BOSS").abilities[3].ability.visuals;
            bitterAnim._visuals2 = LoadedAssetsHandler.GetEnemyAbility("Crush_A").visuals;
            bitterAnim._animationTarget = Slots.Front;
            Ability bitter = new Ability();
            bitter.name = "Bitter Flavour";
            if (UnityEngine.Random.Range(0, 100) < 50)
                bitter.name = "Bitter Flavor";
            bitter.description = "Instantly kill the opposing party member. If successful, give 1-2 Tainted Apples and instantly kill the left and right enemies.";
            bitter.rarity = 4;
            bitter.effects = new Effect[4];
            bitter.effects[0] = new Effect(bitterAnim, 1, new IntentType?(), Slots.Front);
            bitter.effects[1] = new Effect(ScriptableObject.CreateInstance<DirectDeathEffect>(), 1, IntentType.Damage_Death, Slots.Front);
            bitter.effects[2] = new Effect(TApple, 1, IntentType.Misc, Slots.Self, didThat);
            bitter.effects[3] = new Effect(ScriptableObject.CreateInstance<DirectDeathEffect>(), 1, IntentType.Damage_Death, Slots.Sides, BasicEffects.DidThat(true, 2));
            bitter.visuals = null;
            bitter.animationTarget = Slots.Self;
            //make custom tainted apples effect for bitter flavor
            if (DoDebugs.GenInfo) Debug.Log("Abilities");

            satyr.abilities = new Ability[4] { sweet, savory, sour, bitter };
            satyr.AddEnemy();
        }
    }
    public class SatyrAnimationVisualsEffect : EffectSO
    {
        [Header("Visual")]
        [SerializeField]
        public AttackVisualsSO _visuals;

        [SerializeField]
        public BaseCombatTargettingSO _animationTarget;

        [SerializeField]
        public AttackVisualsSO _visuals2;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {

            exitAmount = 0; 
            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i].HasUnit)
                {
                    CombatManager.Instance.AddUIAction(new PlayAbilityAnimationAction(_visuals, _animationTarget, caster));
                    exitAmount++;
                }
                else
                {
                    CombatManager.Instance.AddUIAction(new PlayAbilityAnimationAction(_visuals2, _animationTarget, caster));
                }
            }
            return exitAmount > 0;
        }
    }
    public class GetEnemiesEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i].HasUnit)
                {
                    if (!targets[i].Unit.ContainsPassiveAbility(PassiveAbilityTypes.Inanimate) || !targets[i].Unit.ContainsPassiveAbility(PassiveAbilityTypes.Dying))
                    {
                        if (targets[i].Unit is EnemyCombat enemy)
                        {
                            if (caster is EnemyCombat self && enemy.Enemy != self.Enemy)
                            {
                                if (Satyr.EF1 == false)
                                {
                                    Satyr.Field1 = enemy.Enemy;
                                    Satyr.EF1 = true;
                                    exitAmount++;
                                }
                                else if (Satyr.EF2 == false)
                                {
                                    Satyr.Field2 = enemy.Enemy;
                                    Satyr.EF2 = true;
                                    exitAmount++;
                                }
                                else if (Satyr.EF3 == false)
                                {
                                    Satyr.Field3 = enemy.Enemy;
                                    Satyr.EF3 = true;
                                    exitAmount++;
                                }
                                else if (Satyr.EF4 == false)
                                {
                                    Satyr.Field4 = enemy.Enemy;
                                    Satyr.EF4 = true;
                                    exitAmount++;
                                }
                                else if (Satyr.EF5 == false)
                                {
                                    Satyr.Field5 = enemy.Enemy;
                                    Satyr.EF5 = true;
                                    exitAmount++;
                                    Debug.Log("something's wrong, all 5 enemy slots got filled");
                                }
                            }
                        }
                    }
                }
            }

            return exitAmount > 0;
        }
    }
    public class ReviveOneEnemyEffect : EffectSO
    {
        public EnemySO enemy = LoadedAssetsHandler.GetEnemy("LittleAngel_EN");

        public bool givesExperience = false;

        [SerializeField]
        public SpawnType _spawnType = SpawnType.Basic;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            bool eField1 = false;
            bool eField2 = false;
            bool eField3 = false;
            bool eField4 = false;
            bool eField5 = false;
            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i].HasUnit)
                {
                    if (targets[i].Unit is EnemyCombat enemy)
                    {
                        
                        if (Satyr.EF1 == true && Satyr.Field1 == enemy.Enemy)
                        {
                            Satyr.EF1 = false;
                            eField1 = true;
                        }
                        else if (Satyr.EF2 == true && Satyr.Field2 == enemy.Enemy)
                        {
                            Satyr.EF2 = false;
                            eField2 = true;
                        }
                        else if (Satyr.EF3 == true && Satyr.Field3 == enemy.Enemy)
                        {
                            Satyr.EF3 = false;
                            eField3 = true;
                        }
                        else if (Satyr.EF4 == true && Satyr.Field4 == enemy.Enemy)
                        {
                            Satyr.EF4 = false;
                            eField4 = true;
                        }
                        else if (Satyr.EF5 == true && Satyr.Field5 == enemy.Enemy)
                        {
                            Satyr.EF5 = false;
                            eField5 = true;
                            Debug.Log("something's wrong, all 5 enemy slots were found");
                        }
                        
                    }
                }
            }
            bool addEF1 = false;
            bool addEF2 = false;
            bool addEF3 = false;
            bool addEF4 = false;
            bool addEF5 = false;
            int reviveListLength = 0;
            
            if (Satyr.EF1 == true && eField1 == false)
            {
                reviveListLength++;
                addEF1 = true;
            }
            if (Satyr.EF2 == true && eField2 == false)
            {
                reviveListLength++;
                addEF2 = true;
            }
            if (Satyr.EF3 == true && eField3 == false)
            {
                reviveListLength++;
                addEF3 = true;
            }
            if (Satyr.EF4 == true && eField4 == false)
            {
                reviveListLength++;
                addEF4 = true;
            }
            if (Satyr.EF5 == true && eField5 == false)
            {
                reviveListLength++;
                addEF5 = true;
            }
            EnemySO[] toRevive = new EnemySO[reviveListLength];
            int addingIndex = 0;
            int revived1 = 99;
            int revived2 = 99;
            int revived3 = 99;
            int revived4 = 99;
            int revived5 = 99;
            if (addEF1 == true)
            {
                toRevive[addingIndex] = Satyr.Field1;
                revived1 = addingIndex;
                addingIndex++;
            }
            if (addEF2 == true)
            {
                toRevive[addingIndex] = Satyr.Field2;
                revived2 = addingIndex;
                addingIndex++;
            }
            if (addEF3 == true)
            {
                toRevive[addingIndex] = Satyr.Field3;
                revived3 = addingIndex;
                addingIndex++;
            }
            if (addEF4 == true)
            {
                toRevive[addingIndex] = Satyr.Field4;
                revived4 = addingIndex;
                addingIndex++;
            }
            if (addEF5 == true)
            {
                toRevive[addingIndex] = Satyr.Field5;
                revived5 = addingIndex;
                addingIndex++;
            }
            int reviveThis = UnityEngine.Random.Range(0, toRevive.Length);

            if (toRevive.Length <= 0)
            {
                return false;
            }
            CombatManager.Instance.AddSubAction(new SpawnEnemyAction(toRevive[reviveThis], -1, givesExperience, trySpawnAnyways: false, _spawnType));

            if (eField1 == true)
            {
                Satyr.EF1 = true;
            }
            if (eField2 == true)
            {
                Satyr.EF2 = true;
            }
            if (eField3 == true)
            {
                Satyr.EF3 = true;
            }
            if (eField4 == true)
            {
                Satyr.EF4 = true;
            }
            if (eField5 == true)
            {
                Satyr.EF5 = true;
            }
            exitAmount++;
            return true;
        }
    }
    public class SatyrPassiveAbility : BasePassiveAbilitySO
    {
        [SerializeField]
        private int _floorVal = 0;

        public override bool IsPassiveImmediate => true;

        public override bool DoesPassiveTrigger => true;

        public override void TriggerPassive(object sender, object args)
        {
            Debug.Log("passive started");
            IUnit unit = sender as IUnit;
            CombatManager.Instance._stats.combatSlots.SlotContainsSlotStatusEffect(unit.SlotID, true, SlotStatusEffectType.OnFire);

        }

        public override void OnPassiveConnected(IUnit unit)
        {
        }

        public override void OnPassiveDisconnected(IUnit unit)
        {
        }
    }
    public class SpawnEnemyFromDeadListEffect : EffectSO
    {
        public EnemySO enemy;

        public bool givesExperience;

        [SerializeField]
        public SpawnType _spawnType = SpawnType.Basic;

        public bool IsntSuperboss(EnemyCombat enemy)
        {
            if (enemy.Enemy._enemyName == "Strange Box")
                return false;
            if (enemy.Enemy._enemyName == "544517")
                return false;
            if (enemy.Enemy._enemyName == "544516")
                return false;
            if (enemy.Enemy._enemyName == "544515")
                return false;
            if (enemy.Enemy._enemyName == "544514")
                return false;
            if (enemy.Enemy._enemyName == "544513")
                return false;
            return true;
        }

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            int candidatesLength = 0;
            exitAmount = 0;
            for (int index = 0; index < stats.Enemies.Count; index++)
            {
                EnemyCombat targetEnemy = stats.Enemies[index];
                if (!targetEnemy.IsAlive && !targetEnemy.HasFled)
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
                if (!targetEnemy.IsAlive && !targetEnemy.HasFled)
                {
                    if (addAt < candidates.Length)
                    {
                        candidates[addAt] = index;
                        addAt++;
                    }
                }
            }
            for (int i = 0; i < entryVariable; i++)
            {
                int picking = UnityEngine.Random.Range(0, candidates.Length);
                int choosing = candidates[picking];
                EnemyCombat targetEnemy = stats.Enemies[choosing];
                if (!targetEnemy.IsAlive && !targetEnemy.HasFled && IsntSuperboss(targetEnemy))
                {
                    int num = stats.GetRandomEnemySlot(targetEnemy.Enemy.size);
                    if (num != -1)
                    {
                        if (stats.AddNewEnemy(targetEnemy.Enemy, num, false, _spawnType))
                        {
                            targetEnemy.HasFled = true;
                            exitAmount++;
                            EnemyCombat newborn = stats.Enemies[stats.Enemies.Count - 1];
                            if (newborn is IUnit unit)
                            {
                                int maxHP = unit.MaximumHealth;
                                decimal gap = maxHP;
                                gap /= 3;
                                decimal gap1 = Math.Floor(gap);
                                int newMaxHP = (int)gap1;
                                unit.MaximizeHealth(newMaxHP);
                            }
                        }
                    }
                }
            }

            return exitAmount > 0;
        }
    }
    public class Extra1Or2LootOptionsEffect : EffectSO
    {
        [SerializeField]
        public bool _changeOption;

        [SerializeField]
        [WearableRef]
        public string _itemName = "";

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (_itemName == "")
            {
                return false;
            }

            if (_changeOption)
            {
                stats.AddOWItemChange(_itemName);
                exitAmount++;
            }
            else
            {
                stats.AddExtraLootAddition(_itemName);
                exitAmount++;
                if (UnityEngine.Random.Range(0, 100) < 50)
                {
                    stats.AddExtraLootAddition(_itemName);
                    exitAmount++;
                }
            }

            return exitAmount > 0;
        }
    }
    public class ReviveReKillEnemyEffect : EffectSO
    {
        public EnemySO enemy;

        public bool givesExperience;

        [SerializeField]
        public SpawnType _spawnType = SpawnType.Basic;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            int candidatesLength = 0;
            exitAmount = 0;
            for (int index = 0; index < stats.Enemies.Count; index++)
            {
                EnemyCombat targetEnemy = stats.Enemies[index];
                if (!targetEnemy.IsAlive && !targetEnemy.HasFled)
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
                if (!targetEnemy.IsAlive && !targetEnemy.HasFled)
                {
                    if (addAt < candidates.Length)
                    {
                        candidates[addAt] = index;
                        addAt++;
                    }
                }
            }
            for (int i = 0; i < entryVariable; i++)
            {
                int picking = UnityEngine.Random.Range(0, candidates.Length);
                int choosing = candidates[picking];
                EnemyCombat targetEnemy = stats.Enemies[choosing];
                if (!targetEnemy.IsAlive && !targetEnemy.HasFled)
                {
                    int num = stats.GetRandomEnemySlot(targetEnemy.Enemy.size);
                    if (num != -1)
                    {
                        if (stats.AddNewEnemy(targetEnemy.Enemy, num, false, SpawnType.Basic))
                        {
                            targetEnemy.HasFled = true;
                            exitAmount++;
                            EnemyCombat newborn = stats.Enemies[stats.Enemies.Count - 1];
                            if (newborn is IUnit unit)
                            {
                                exitAmount++;
                                Effect DP = new Effect(ScriptableObject.CreateInstance<ApplyDivineProtectionEffect>(), 1, IntentType.Status_DivineProtection, Slots.Self);
                                DamageEffect indirect = ScriptableObject.CreateInstance<DamageEffect>();
                                indirect._indirect = true;
                                int maxHP = unit.CurrentHealth;
                                //maxHP *= 2;
                                Effect hit = new Effect(indirect, maxHP, IntentType.Damage_21, Slots.Self);
                                RemoveStatusEffectEffect DPGone = ScriptableObject.CreateInstance<RemoveStatusEffectEffect>();
                                DPGone._statusToRemove = StatusEffectType.DivineProtection;
                                Effect noDP = new Effect(DPGone, 1, IntentType.Rem_Status_DivineProtection, Slots.Self);
                                CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[3] { DP, hit, noDP }), unit));
                            }
                        }
                    }
                }
            }

            return exitAmount > 0;
        }
    }
}
