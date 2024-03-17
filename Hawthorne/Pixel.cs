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
using THE_DEAD;
using PYMN4;

namespace Hawthorne
{
    public static class Pixel
    {
        public static void Add()
        {
            Acid.Add();
            PerformEffectPassiveAbility superSlippery = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            superSlippery._passiveName = "Jumpy";
            superSlippery.passiveIcon = ResourceLoader.LoadSprite("SuperSkittish", 32);
            superSlippery.type = (PassiveAbilityTypes)544531;
            superSlippery._enemyDescription = "Upon being hit move to a random position. Upon performing an ability, move to a random position.";
            superSlippery._characterDescription = "Upon being hit move to a random position. Upon performing an ability, move to a random position.";
            superSlippery.doesPassiveTriggerInformationPanel = true;
            superSlippery.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1] { new Effect(ScriptableObject.CreateInstance<SwapToRandomZoneEffect>(), 1, new IntentType?(), Slots.SlotTarget(new int[9] { -4, -3, -2, -1, 0, 1, 2, 3, 4 }, true)) });
            superSlippery._triggerOn = new TriggerCalls[2] { TriggerCalls.OnDirectDamaged, TriggerCalls.OnAbilityUsed };
            superSlippery.conditions = new EffectorConditionSO[] { ScriptableObject.CreateInstance<IsAliveCondition>() };
            PerformEffectPassiveAbility numb = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            numb._passiveName = "Numb (1)";
            numb.passiveIcon = ResourceLoader.LoadSprite("anesthetics2", 32);
            numb.type = (PassiveAbilityTypes)544544;
            numb._enemyDescription = "Apply 1 Anesthetics to this enemy at the start of each turn.";
            numb._characterDescription = "Apply 1 Anesthetics to this character at the start of each turn.";
            numb.doesPassiveTriggerInformationPanel = true;
            numb.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1] { new Effect(ScriptableObject.CreateInstance<ApplyAnestheticsEffect>(), 1, new IntentType?(), Slots.Self) });
            numb._triggerOn = new TriggerCalls[] { TriggerCalls.OnTurnStart };

            Enemy pixel = new Enemy()
            {
                name = "Dead Pixel",
                health = 9,
                size = 1,
                entityID = (EntityIDs)544531,
                healthColor = Pigments.Gray,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/PissShitFartCum/Pixel_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
            };
            pixel.prefab._gibs = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/PissShitFartCum/Pixel_Gibs.prefab").GetComponent<ParticleSystem>();
            pixel.prefab.SetDefaultParams();
            pixel.combatSprite = ResourceLoader.LoadSprite("PixelIconB", 32);
            pixel.overworldAliveSprite = ResourceLoader.LoadSprite("PixelIcon", 32, new Vector2?(new Vector2(0.5f, 0.05f)));
            pixel.overworldDeadSprite = ResourceLoader.LoadSprite("PixelDead", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            pixel.hurtSound = "event:/Hawthorne/Hurt/DeadPixelHurt";
            pixel.deathSound = "event:/Hawthorne/Die/DeadPixelDie";
            pixel.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            pixel.passives = new BasePassiveAbilitySO[]
            {
                superSlippery, numb, Passives.Forgetful, Passi.Fleeting(6)
            };
            //give a passive that applies 1 anesthetics on combat start

            pixel.enterEffects = new Effect[]
            {
                new Effect(RootActionEffect.Create(new Effect[]
                {
                    new Effect(ScriptableObject.CreateInstance<NumbPassiveInfoEffect>(), 1, null, Slots.Self),
                    new Effect(ScriptableObject.CreateInstance<ApplyAnestheticsEffect>(), 1, new IntentType?(), Slots.Self)
                }), 1, null, Slots.Self)
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
            Ability theStatic = new Ability();
            theStatic.name = "Static";
            theStatic.description = "Turn a random non-grey enemy grey. If that enemy had Pure as a passive, remove it.";
            theStatic.rarity = 4;
            theStatic.effects = new Effect[1];
            theStatic.effects[0] = new Effect(ScriptableObject.CreateInstance<TurnGreyTargetRandomEffect>(), 1, IntentType.Misc, allAlly);
            theStatic.visuals = null;
            theStatic.animationTarget = Slots.Self;

            CustomChangeToRandomHealthColorEffect randomize = ScriptableObject.CreateInstance<CustomChangeToRandomHealthColorEffect>();
            randomize._healthColors = new ManaColorSO[4]
            {
            Pigments.Red,
            Pigments.Blue,
            Pigments.Yellow,
            Pigments.Purple
            };
            EnemyCombat c;
            Ability Multicolors = new Ability();
            Multicolors.name = "Multicolors";
            Multicolors.description = "Deal a Painful amount of damage to the Opposing party member. Fill the pigment bar with random pigment colors and randomize this enemy's health color.";
            Multicolors.rarity = 6;
            Multicolors.effects = new Effect[3];
            Multicolors.effects[0] = new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 4, IntentType.Damage_3_6, Slots.Front);
            Multicolors.effects[1] = new Effect(ScriptableObject.CreateInstance<GenerateFullBarManaEffect>(), 1, IntentType.Mana_Generate, Slots.Self);
            Multicolors.effects[2] = new Effect(randomize, 1, IntentType.Misc, Slots.Self);
            Multicolors.visuals = LoadedAssetsHandler.GetEnemy("UnfinishedHeir_BOSS").abilities[2].ability.visuals; ;
            Multicolors.animationTarget = Slots.Self;

            IncreaseStatusEffectsEffect increaseAllStatus = ScriptableObject.CreateInstance<IncreaseStatusEffectsEffect>();
            increaseAllStatus._increasePositives = true;
            IncreaseStatusEffectsEffect increaseAllStatus2 = ScriptableObject.CreateInstance<IncreaseStatusEffectsEffect>();
            increaseAllStatus2._increasePositives = false;
            Ability interference = new Ability();
            interference.name = "Signal Interference";
            interference.description = "Increase the status and field effects of all enemies and party members by 1. Apply 1-2 random negative status effects to all party members.";
            interference.rarity = 3;
            interference.effects = new Effect[11];
            interference.effects[0] = new Effect(increaseAllStatus, 1, IntentType.Misc, allAlly);
            interference.effects[1] = new Effect(increaseAllStatus, 1, IntentType.Misc, allEnemy);
            interference.effects[2] = new Effect(increaseAllStatus2, 1, new IntentType?(), allAlly);
            interference.effects[3] = new Effect(increaseAllStatus2, 1, new IntentType?(), allEnemy);
            interference.effects[4] = new Effect(ScriptableObject.CreateInstance<RandomStatusEffect>(), 1, IntentType.Status_OilSlicked, Targetting.AllEnemy);
            interference.effects[5] = new Effect(BasicEffects.Empty, 1, (IntentType)846738, Targetting.AllEnemy);
            interference.effects[6] = new Effect(BasicEffects.Empty, 1, IntentType.Status_Frail, Targetting.AllEnemy);
            interference.effects[7] = new Effect(BasicEffects.Empty, 1, IntentType.Status_Scars, Targetting.AllEnemy);
            interference.effects[8] = new Effect(BasicEffects.Empty, 1, IntentType.Status_Cursed, Targetting.AllEnemy);
            interference.effects[9] = new Effect(BasicEffects.Empty, 1, (IntentType)666888, Targetting.AllEnemy);
            interference.effects[10] = new Effect(BasicEffects.Empty, 1, (IntentType)846749, Targetting.AllEnemy);
            interference.visuals = LoadedAssetsHandler.GetCharacterAbility("Entwined_1_A").visuals;
            interference.animationTarget = Slots.Self;
            if (DoDebugs.GenInfo) Debug.Log("Abilities");

            pixel.abilities = new Ability[3] { theStatic, Multicolors, interference };
            pixel.AddEnemy();
        }
    }
    public class TurnGreyTargetRandomEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            bool usePreviousExitValue = this._usePreviousExitValue;
            if (usePreviousExitValue)
            {
                entryVariable *= base.PreviousExitValue;
            }
            exitAmount = 0;
            List<TargetSlotInfo> list = new List<TargetSlotInfo>();
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                bool hasUnit = targetSlotInfo.HasUnit;
                if (hasUnit)
                {
                    if (targetSlotInfo.Unit.HealthColor != Pigments.Gray)
                        list.Add(targetSlotInfo);
                }
            }
            bool flag = list.Count <= 0;
            bool result;
            if (flag)
            {
                result = false;
                return result;
                Targetting_ByUnit_Side allEnemy = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
                allEnemy.getAllUnitSlots = false;
                allEnemy.getAllies = false;
                Effect runParty = new Effect(ScriptableObject.CreateInstance<TurnGreyTargetRandomAndHitEffect>(), 1, new IntentType?(), allEnemy);
                CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { runParty }), caster));
            }
            else
            {
                int index = UnityEngine.Random.Range(0, list.Count);
                TargetSlotInfo targetSlotInfo2 = list[index];
                areTargetSlots = true;
                int targetSlotOffset = areTargetSlots ? (targetSlotInfo2.SlotID - targetSlotInfo2.Unit.SlotID) : -1;

                int hitHere = targetSlotInfo2.SlotID - caster.SlotID;
                AnimationVisualsEffect animIS = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
                animIS._animationTarget = Slots.SlotTarget(new int[1] { hitHere }, true);
                animIS._visuals = LoadedAssetsHandler.GetEnemyAbility("Wriggle_A").visuals;
                Effect animYAY = new Effect(animIS, 1, new IntentType?(), Slots.Self);

                ChangeToRandomHealthColorEffect greyYAY = ScriptableObject.CreateInstance<ChangeToRandomHealthColorEffect>();
                greyYAY._healthColors = new ManaColorSO[1] { Pigments.Gray };
                RemovePassiveEffect noPure = ScriptableObject.CreateInstance<RemovePassiveEffect>();
                noPure._passiveToRemove = PassiveAbilityTypes.Pure;

                Effect unPure = new Effect(noPure, 1, new IntentType?(), Slots.SlotTarget(new int[1] { hitHere }, true));
                Effect grayify = new Effect(greyYAY, 1, new IntentType?(), Slots.SlotTarget(new int[1] { hitHere }, true));

                
                CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[3] { animYAY, unPure, grayify }), caster));
                

                exitAmount = entryVariable;
                result = (exitAmount > 0);
            }
            return result;
        }

        // Token: 0x04000022 RID: 34
        [SerializeField]
        public bool _usePreviousExitValue;

        // Token: 0x04000023 RID: 35
        [SerializeField]
        public bool _ignoreShield;

        // Token: 0x04000024 RID: 36
        [SerializeField]
        public bool _indirect = false;

        // Token: 0x04000025 RID: 37
        public int _scars;
    }
    public class TurnGreyTargetRandomAndHitEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            bool usePreviousExitValue = this._usePreviousExitValue;
            if (usePreviousExitValue)
            {
                entryVariable *= base.PreviousExitValue;
            }
            exitAmount = 0;
            List<TargetSlotInfo> list = new List<TargetSlotInfo>();
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                bool hasUnit = targetSlotInfo.HasUnit;
                if (hasUnit)
                {
                    if (targetSlotInfo.Unit.HealthColor != Pigments.Gray)
                        list.Add(targetSlotInfo);
                }
            }
            bool flag = list.Count <= 0;
            bool result;
            if (flag)
            {
                result = false;
                Effect selfFlee = new Effect(ScriptableObject.CreateInstance<FleeTargetEffect>(), 1, new IntentType?(), Slots.Self);
                CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { selfFlee }), caster));
            }
            else
            {
                int index = UnityEngine.Random.Range(0, list.Count);
                TargetSlotInfo targetSlotInfo2 = list[index];
                areTargetSlots = true;
                int targetSlotOffset = areTargetSlots ? (targetSlotInfo2.SlotID - targetSlotInfo2.Unit.SlotID) : -1;

                int hitHere = targetSlotInfo2.SlotID - caster.SlotID;
                AnimationVisualsEffect animIS = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
                animIS._animationTarget = Slots.SlotTarget(new int[1] { hitHere }, false);
                animIS._visuals = LoadedAssetsHandler.GetEnemyAbility("Wriggle_A").visuals;
                Debug.Log(entryVariable);
                Effect animYAY = new Effect(animIS, 1, new IntentType?(), Slots.Self);

                ChangeToRandomHealthColorEffect greyYAY = ScriptableObject.CreateInstance<ChangeToRandomHealthColorEffect>();
                greyYAY._healthColors = new ManaColorSO[1] { Pigments.Gray };
                RemovePassiveEffect noPure = ScriptableObject.CreateInstance<RemovePassiveEffect>();
                noPure._passiveToRemove = PassiveAbilityTypes.Pure;

                Effect unPure = new Effect(noPure, 1, new IntentType?(), Slots.SlotTarget(new int[1] { hitHere }, false));
                Effect grayify = new Effect(greyYAY, 1, new IntentType?(), Slots.SlotTarget(new int[1] { hitHere }, false));
                int painfulAmount = UnityEngine.Random.Range(3, 7);
                Effect pain = new Effect(ScriptableObject.CreateInstance<DamageEffect>(), painfulAmount, new IntentType?(), Slots.SlotTarget(new int[1] { hitHere }, false), Conditions.Chance(70));

                CustomChangeToRandomHealthColorEffect randomize = ScriptableObject.CreateInstance<CustomChangeToRandomHealthColorEffect>();
                randomize._healthColors = new ManaColorSO[4]
                {
                    Pigments.Red,
                    Pigments.Blue,
                    Pigments.Yellow,
                    Pigments.Purple
                };
                Effect changeHPColor = new Effect(randomize, 1, IntentType.Misc, Slots.Self);

                CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[5] { animYAY, unPure, grayify, pain, changeHPColor }), caster));
                

                exitAmount = entryVariable;
                result = (exitAmount > 0);
            }
            return result;
        }

        // Token: 0x04000022 RID: 34
        [SerializeField]
        public bool _usePreviousExitValue;

        // Token: 0x04000023 RID: 35
        [SerializeField]
        public bool _ignoreShield;

        // Token: 0x04000024 RID: 36
        [SerializeField]
        public bool _indirect = false;

        // Token: 0x04000025 RID: 37
        public int _scars;
    }
    public class GenerateFullBarManaEffect : EffectSO
    {
        public bool usePreviousExitValue;

        public ManaColorSO mana = Pigments.Purple;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            if (usePreviousExitValue)
            {
                entryVariable *= base.PreviousExitValue;
            }

            exitAmount = 0;
            bool isBarFull = stats.MainManaBar.IsManaBarFull;
            while (isBarFull == false)
            {
                int choosing = UnityEngine.Random.Range(0, 100);
                if (choosing < 30)
                    mana = Pigments.Red;
                else if (choosing < 55)
                    mana = Pigments.Blue;
                else if (choosing < 75)
                    mana = Pigments.Yellow;
                else if (choosing < 95)
                    mana = Pigments.Purple;
                else if (choosing < 100)
                    mana = Pigments.Green;
                CombatManager.Instance.ProcessImmediateAction(new AddManaToManaBarAction(mana, entryVariable, caster.IsUnitCharacter, caster.ID));
                exitAmount++;
                isBarFull = stats.MainManaBar.IsManaBarFull;
            }
            return exitAmount > 0;
        }
    }
    
    public class CustomChangeToRandomHealthColorEffect : EffectSO
    {
        [SerializeField]
        public ManaColorSO[] _healthColors;

        public override bool PerformEffect(
          CombatStats stats,
          IUnit caster,
          TargetSlotInfo[] targets,
          bool areTargetSlots,
          int entryVariable,
          out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    List<ManaColorSO> manaColorSoList = new List<ManaColorSO>((IEnumerable<ManaColorSO>)this._healthColors);
                    bool flag1 = false;
                    bool flag2 = false;
                    while (!flag2 && manaColorSoList.Count > 0)
                    {
                        int index = UnityEngine.Random.Range(0, manaColorSoList.Count);
                        ManaColorSO manaColor = manaColorSoList[index];
                        manaColorSoList.RemoveAt(index);
                        if (manaColor != target.Unit.HealthColor)
                        {
                            flag1 = target.Unit.ChangeHealthColor(manaColor);
                            flag2 = true;
                        }
                    }
                    if (flag1)
                        ++exitAmount;
                }
            }
            return exitAmount > 0;
        }
    }
    public class IsAliveCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (effector is IUnit unit && unit.CurrentHealth > 0) return true;
            return false;
        }
    }


    public class NumbPassiveInfoEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(caster.ID, caster.IsUnitCharacter, "Numb (1)", ResourceLoader.LoadSprite("anesthetics2", 32)));
            return true;
        }
    }
    public class RandomStatusEffect : EffectSO
    {
        static ApplyOilSlickedEffect _oil;
        public static ApplyOilSlickedEffect Oil
        {
            get
            {
                if (_oil == null)
                {
                    _oil = ScriptableObject.CreateInstance<ApplyOilSlickedEffect>();
                }
                return _oil;
            }
        }
        static ApplyLeftEffect _left;
        public static ApplyLeftEffect Left
        {
            get
            {
                if (_left == null)
                {
                    _left = ScriptableObject.CreateInstance<ApplyLeftEffect>();
                }
                return _left;
            }
        }//moves you left once on moving
        static ApplyFrailEffect _frail;
        public static ApplyFrailEffect Frail
        {
            get
            {
                if (_frail == null)
                {
                    _frail = ScriptableObject.CreateInstance<ApplyFrailEffect>();
                }
                return _frail;
            }
        }
        static ApplyScarsEffect _scar;
        public static ApplyScarsEffect Scar
        {
            get
            {
                if (_scar == null)
                {
                    _scar = ScriptableObject.CreateInstance<ApplyScarsEffect>();
                }
                return _scar;
            }
        }
        static ApplyCursedEffect _cursed;
        public static ApplyCursedEffect Cursed
        {
            get
            {
                if (_cursed == null)
                {
                    _cursed = ScriptableObject.CreateInstance<ApplyCursedEffect>();
                }
                return _cursed;
            }
        }
        static ApplyPaleEffect _pale;
        public static ApplyPaleEffect Pale
        {
            get
            {
                if (_pale == null)
                {
                    _pale = ScriptableObject.CreateInstance<ApplyPaleEffect>();
                }
                return _pale;
            }
        }
        static ApplyInvertedEffect _inverted;
        public static ApplyInvertedEffect Inverted
        {
            get
            {
                if (_inverted == null)
                {
                    _inverted = ScriptableObject.CreateInstance<ApplyInvertedEffect>();
                }
                return _inverted;
            }
        }//direct healing --> indirect damage; direct damge --> indirect healing
        public static EffectSO[] Array => new EffectSO[] { Oil, Left, Frail, Scar, Cursed, Pale, Inverted };

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                List<EffectSO> list = new List<EffectSO>(Array);
                int picking = UnityEngine.Random.Range(0, list.Count);
                EffectSO first = list[picking];
                int choosing = UnityEngine.Random.Range(0, list.Count);
                while (choosing == picking)
                {
                    choosing = UnityEngine.Random.Range(0, list.Count);
                }
                EffectSO second = list[choosing];
                first.PerformEffect(stats, caster, target.SelfArray(), areTargetSlots, 1, out int exiting);
                exitAmount += exiting;
                if (UnityEngine.Random.Range(0, 100) < 50) continue;
                second.PerformEffect(stats, caster, target.SelfArray(), areTargetSlots, 1, out int grah);
                exitAmount += grah;
            }
            return exitAmount > 0;
        }
    }
}
