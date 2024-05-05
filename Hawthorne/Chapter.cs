using BrutalAPI;
using Hawthorne.NewFolder;
using System;
using System.Collections.Generic;
using System.Text;
using THE_DEAD;
using UnityEngine;

namespace Hawthorne
{
    public static class Chapter
    {
        static UnlockItem _one;
        public static UnlockItem One
        {
            get
            {
                if (_one == null)
                {
                    UnlockItem effectItem = new UnlockItem();
                    effectItem.name = "Pom Poms";
                    effectItem.flavorText = "\"It's the thought that counts.\"";
                    effectItem.description = "On dealing damage, apply 1 Power to the Left and Right allies.";
                    effectItem.sprite = ResourceLoader.LoadSprite("PomPom.png");
                    effectItem.trigger = TriggerCalls.OnDidApplyDamage;
                    effectItem.namePopup = true;
                    effectItem.consumedOnUse = false;
                    effectItem.itemPools = ItemPools.Shop;
                    effectItem.shopPrice = 5;
                    effectItem.startsLocked = false;
                    effectItem.immediate = false;
                    effectItem.effects = new Effect[1]
                    {
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyPowerEffect>(), 1, new IntentType?((IntentType)987895), Slots.Sides)
                    };
                    effectItem.unlockableID = (UnlockableID)18482901;
                    effectItem.Ach = new AchievementSystem.AchieveInfo((Achievement)18482901, AchievementUnlockType.Strangers, "Salt's Enemies Chapter One", "Defeat all enemies in Chapter 1 of Salt's Enemy Mod.", ResourceLoader.LoadSprite("Chapter01Achi.png", 32));
                    effectItem.Prepare();
                    _one = effectItem;
                }
                return _one;
            }
        }
        static UnlockItem _two;
        public static UnlockItem Two
        {
            get
            {
                if (_two == null)
                {
                    UnlockItem effectItem = new UnlockItem();
                    effectItem.name = "Silver Bullet";
                    effectItem.flavorText = "\"Blessed death.\"";
                    effectItem.description = "On dealing damage to an enemy without Determined, Apply 3 Determined to them. Deal double damage to enemies with Determined.";
                    effectItem.sprite = ResourceLoader.LoadSprite("SilverBullet.png");
                    effectItem.trigger = TriggerCalls.Count;
                    effectItem.namePopup = true;
                    effectItem.consumedOnUse = false;
                    effectItem.itemPools = ItemPools.Treasure;
                    effectItem.shopPrice = 5;
                    effectItem.startsLocked = false;
                    effectItem.immediate = false;
                    effectItem.effects = new Effect[0];
                    effectItem.unlockableID = (UnlockableID)18482902;
                    effectItem.Ach = new AchievementSystem.AchieveInfo((Achievement)18482902, AchievementUnlockType.Strangers, "Salt's Enemies Chapter Two", "Defeat all enemies in Chapter 2 of Salt's Enemy Mod.", ResourceLoader.LoadSprite("Chapter02Achi.png", 32));
                    effectItem.Prepare();
                    _two = effectItem;
                }
                return _two;
            }
        }
        static UnlockItem _three;
        public static UnlockItem Three
        {
            get
            {
                if (_three == null)
                {
                    UnlockItem effectItem = new UnlockItem();
                    effectItem.name = "Dues";
                    effectItem.flavorText = "\"You'll never catch me!.\"";
                    effectItem.description = "At the start of the third turn, cancel all enemy abilities.";
                    effectItem.sprite = ResourceLoader.LoadSprite("Dues.png");
                    effectItem.trigger = TriggerCalls.OnTurnStart;
                    effectItem.namePopup = true;
                    effectItem.consumedOnUse = false;
                    effectItem.itemPools = ItemPools.Shop;
                    effectItem.shopPrice = 4;
                    effectItem.startsLocked = false;
                    effectItem.immediate = false;
                    effectItem.triggerConditions = new EffectorConditionSO[] { ScriptableObject.CreateInstance<ThirdTurnPassedCondition>() };
                    effectItem.effects = new Effect[] { new Effect(ScriptableObject.CreateInstance<TimelineClearEffect>(), 1, null, Slots.Self) };
                    effectItem.unlockableID = (UnlockableID)18482903;
                    effectItem.Ach = new AchievementSystem.AchieveInfo((Achievement)18482903, AchievementUnlockType.Strangers, "Salt's Enemies Chapter Three", "Defeat all enemies in Chapter 3 of Salt's Enemy Mod.", ResourceLoader.LoadSprite("Chapter03Achi.png", 32));
                    effectItem.Prepare();
                    _three = effectItem;
                }
                return _three;
            }
        }
        static UnlockItem _four;
        public static UnlockItem Four
        {
            get
            {
                if (_four == null)
                {
                    UnlockItem effectItem = new UnlockItem();
                    effectItem.name = "Cheating Materials";
                    effectItem.flavorText = "\"Probably not that helpful in the long run.\"";
                    effectItem.description = "Adds the extra ability \"Replicate\" which copies the last ability used.";
                    effectItem.sprite = ResourceLoader.LoadSprite("CheatingMaterials.png");
                    effectItem.trigger = TriggerCalls.Count;
                    effectItem.namePopup = true;
                    effectItem.consumedOnUse = false;
                    effectItem.itemPools = ItemPools.Treasure;
                    effectItem.shopPrice = 5;
                    effectItem.startsLocked = false;
                    effectItem.immediate = false;
                    effectItem.effects = new Effect[0];
                    effectItem.unlockableID = (UnlockableID)18482904;
                    effectItem.Ach = new AchievementSystem.AchieveInfo((Achievement)18482904, AchievementUnlockType.Strangers, "Salt's Enemies Chapter Four", "Defeat all enemies in Chapter 4 of Salt's Enemy Mod.", ResourceLoader.LoadSprite("Chapter04Achi.png", 32));
                    Ability replicate = new Ability();
                    replicate.name = "Replicate";
                    replicate.description = "Perform the last ability used.";
                    replicate.cost = new ManaColorSO[] { Pigments.Purple };
                    replicate.visuals = null;
                    replicate.animationTarget = null;
                    replicate.effects = new Effect[1];
                    replicate.effects[0] = new Effect(ScriptableObject.CreateInstance<CopyLastAbilityEffect>(), 1, IntentType.Misc, Slots.Self);
                    ExtraAbility_Wearable_SMS abil = ScriptableObject.CreateInstance<ExtraAbility_Wearable_SMS>();
                    abil._extraAbility = replicate.CharacterAbility();
                    effectItem.equippedModifiers = new WearableStaticModifierSetterSO[] { abil };
                    effectItem.Prepare();
                    _four = effectItem;
                }
                return _four;
            }
        }
        static UnlockItem _five;
        public static UnlockItem Five
        {
            get
            {
                if (_five == null)
                {
                    UnlockItem effectItem = new UnlockItem();
                    effectItem.name = "Passivefruit";
                    effectItem.flavorText = "\"Scary !\"";
                    effectItem.description = "At the start of combat, add \"Whimsy\" as a passive to the Opposing enemy.";
                    effectItem.sprite = ResourceLoader.LoadSprite("PassiveFruit.png");
                    effectItem.trigger = TriggerCalls.OnCombatStart;
                    effectItem.namePopup = true;
                    effectItem.consumedOnUse = false;
                    effectItem.itemPools = ItemPools.Treasure;
                    effectItem.shopPrice = 4;
                    effectItem.startsLocked = false;
                    effectItem.immediate = false;
                    AddPassiveEffect whim = ScriptableObject.CreateInstance<AddPassiveEffect>();
                    whim._passiveToAdd = Passi.Whimsy;
                    effectItem.effects = new Effect[] { new Effect(whim, 1, null, Slots.Front) };
                    effectItem.unlockableID = (UnlockableID)18482905;
                    effectItem.Ach = new AchievementSystem.AchieveInfo((Achievement)18482905, AchievementUnlockType.Strangers, "Salt's Enemies Chapter Five", "Defeat all enemies in Chapter 5 of Salt's Enemy Mod.", ResourceLoader.LoadSprite("Chapter05Achi.png", 32));
                    effectItem.Prepare();
                    _five = effectItem;
                }
                return _five;
            }
        }
        static UnlockItem _six;
        public static UnlockItem Six
        {
            get
            {
                if (_six == null)
                {
                    UnlockItem effectItem = new UnlockItem();
                    effectItem.name = "Unknown Fossil";
                    effectItem.flavorText = "\"Relic of meaningless value.\"";
                    effectItem.description = "Every other turn, inflict 3 Roots on every enemy position.";
                    effectItem.sprite = ResourceLoader.LoadSprite("UnknownFossil.png");
                    effectItem.trigger = TriggerCalls.OnTurnStart;
                    effectItem.namePopup = true;
                    effectItem.consumedOnUse = false;
                    effectItem.itemPools = ItemPools.Treasure;
                    effectItem.shopPrice = 4;
                    effectItem.startsLocked = false;
                    effectItem.immediate = false;
                    effectItem.triggerConditions = new EffectorConditionSO[] { ScriptableObject.CreateInstance<EveryOtherTurnPassedCondition>() };
                    effectItem.effects = new Effect[] { new Effect(ScriptableObject.CreateInstance<ApplyRootsSlotEffect>(), 3, null, Slots.SlotTarget(new int[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 }, false)) };
                    effectItem.unlockableID = (UnlockableID)18482906;
                    effectItem.Ach = new AchievementSystem.AchieveInfo((Achievement)18482906, AchievementUnlockType.Strangers, "Salt's Enemies Chapter Six", "Defeat all enemies in Chapter 6 of Salt's Enemy Mod.", ResourceLoader.LoadSprite("Chapter06Achi.png", 32));
                    effectItem.Prepare();
                    _six = effectItem;
                }
                return _six;
            }
        }
        static UnlockItem _seven;
        public static UnlockItem Seven
        {
            get
            {
                if (_seven == null)
                {
                    UnlockItem effectItem = new UnlockItem();
                    effectItem.name = "Tin Can";
                    effectItem.flavorText = "\"You caught a... tin can!\"";
                    effectItem.description = "On death, prevent it and heal 1 health. This item is destroyed upon activation and at the end of combat.";
                    effectItem.sprite = ResourceLoader.LoadSprite("TinCan.png");
                    effectItem.trigger = TriggerCalls.CanDie;
                    effectItem.namePopup = true;
                    effectItem.consumedOnUse = false;
                    effectItem.itemPools = ItemPools.Fish;
                    effectItem.Fish = 3;
                    effectItem.shopPrice = 4;
                    effectItem.startsLocked = false;
                    effectItem.immediate = false;
                    effectItem.consumeTrigger = TriggerCalls.OnCombatEnd;
                    effectItem.triggerConditions = new EffectorConditionSO[] { ScriptableObject.CreateInstance<TinCanCondition>() };
                    effectItem.effects = new Effect[0];
                    effectItem.unlockableID = (UnlockableID)18482907;
                    effectItem.Ach = new AchievementSystem.AchieveInfo((Achievement)18482907, AchievementUnlockType.Strangers, "Salt's Enemies Chapter Seven", "Defeat all enemies in Chapter 7 of Salt's Enemy Mod.", ResourceLoader.LoadSprite("Chapter07Achi.png", 32));
                    effectItem.Prepare();
                    _seven = effectItem;
                }
                return _seven;
            }
        }
        static UnlockItem _eight;
        public static UnlockItem Eight
        {
            get
            {
                if (_eight == null)
                {
                    UnlockItem effectItem = new UnlockItem();
                    effectItem.name = "Feeding Frenzy";
                    effectItem.flavorText = "\"Blood excitement\"";
                    effectItem.description = "On killing anything, apply 1 Haste on every party member and enemy.";
                    effectItem.sprite = ResourceLoader.LoadSprite("FeedingFrenzy.png");
                    effectItem.trigger = TriggerCalls.OnKill;
                    effectItem.namePopup = true;
                    effectItem.consumedOnUse = false;
                    effectItem.itemPools = ItemPools.Treasure;
                    effectItem.shopPrice = 8;
                    effectItem.startsLocked = false;
                    effectItem.immediate = false;
                    effectItem.effects = new Effect[] { new Effect(ScriptableObject.CreateInstance<ApplyHasteEffect>(), 1, null, MultiTargetting.Create(Targetting.AllAlly, Targetting.AllEnemy)) };
                    effectItem.unlockableID = (UnlockableID)18482908;
                    effectItem.Ach = new AchievementSystem.AchieveInfo((Achievement)18482908, AchievementUnlockType.Strangers, "Salt's Enemies Chapter Eight", "Defeat all enemies in Chapter 8 of Salt's Enemy Mod.", ResourceLoader.LoadSprite("Chapter08Achi.png", 32));
                    effectItem.Prepare();
                    _eight = effectItem;
                }
                return _eight;
            }
        }
        static UnlockItem _nine;
        public static UnlockItem Nine
        {
            get
            {
                if (_nine == null)
                {
                    UnlockItem effectItem = new UnlockItem();
                    effectItem.name = "Spare Ear";
                    effectItem.flavorText = "\"Too old to be reattached.\"";
                    effectItem.description = "On taking any damage, produce 2 Red Pigment and apply 6 Shield to this position.";
                    effectItem.sprite = ResourceLoader.LoadSprite("SpareEar.png");
                    effectItem.trigger = TriggerCalls.OnDamaged;
                    effectItem.namePopup = true;
                    effectItem.consumedOnUse = false;
                    effectItem.itemPools = ItemPools.Shop;
                    effectItem.shopPrice = 1;
                    effectItem.startsLocked = false;
                    effectItem.immediate = false;
                    effectItem.effects = new Effect[] { new Effect(BasicEffects.GenPigment(Pigments.Red), 2, null, Slots.Self), new Effect(ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 6, null, Slots.Self) };
                    effectItem.unlockableID = (UnlockableID)18482909;
                    effectItem.Ach = new AchievementSystem.AchieveInfo((Achievement)18482909, AchievementUnlockType.Strangers, "Salt's Enemies Chapter Nine", "Defeat all enemies in Chapter 9 of Salt's Enemy Mod.", ResourceLoader.LoadSprite("Chapter09Achi.png", 32));
                    effectItem.Prepare();
                    _nine = effectItem;
                }
                return _nine;
            }
        }
        static UnlockItem _ten;
        public static UnlockItem Ten
        {
            get
            {
                if (_ten == null)
                {
                    UnlockItem effectItem = new UnlockItem();
                    effectItem.name = "Echo";
                    effectItem.flavorText = "\"Mediocre shot\"";
                    effectItem.description = "On dealing any damage, deal it again to the same position at the start of the next turn.";
                    effectItem.sprite = ResourceLoader.LoadSprite("Echo.png");
                    effectItem.trigger = TriggerCalls.Count;
                    effectItem.namePopup = true;
                    effectItem.consumedOnUse = false;
                    effectItem.itemPools = ItemPools.Shop;
                    effectItem.shopPrice = 8;
                    effectItem.startsLocked = false;
                    effectItem.immediate = false;
                    effectItem.effects = new Effect[0];
                    effectItem.unlockableID = (UnlockableID)18482910;
                    effectItem.Ach = new AchievementSystem.AchieveInfo((Achievement)18482910, AchievementUnlockType.Strangers, "Salt's Enemies Chapter Ten", "Defeat all enemies in Chapter 10 of Salt's Enemy Mod.", ResourceLoader.LoadSprite("Chapter10Achi.png", 32));
                    effectItem.Prepare();
                    _ten = effectItem;
                }
                return _ten;
            }
        }
        static UnlockItem _eleven;
        public static UnlockItem Eleven
        {
            get
            {
                if (_eleven == null)
                {
                    UnlockItem effectItem = new UnlockItem();
                    effectItem.name = "Little Bell";
                    effectItem.flavorText = "\"When it rings we all go to hell.\"";
                    effectItem.description = "At the start of each turn inflict 10 Pale on the highest health enemy and party member.";
                    effectItem.sprite = ResourceLoader.LoadSprite("LittleBell.png");
                    effectItem.trigger = TriggerCalls.OnTurnStart;
                    effectItem.namePopup = true;
                    effectItem.consumedOnUse = false;
                    effectItem.itemPools = ItemPools.Treasure;
                    effectItem.shopPrice = 6;
                    effectItem.startsLocked = false;
                    effectItem.immediate = false;
                    effectItem.effects = new Effect[] { new Effect(ScriptableObject.CreateInstance<ApplyPaleEffect>(), 10, null, MultiTargetting.Create(Targetting.HighestEnemy, Targetting.HighestAlly)) };
                    effectItem.unlockableID = (UnlockableID)18482911;
                    effectItem.Ach = new AchievementSystem.AchieveInfo((Achievement)18482911, AchievementUnlockType.Strangers, "Salt's Enemies Chapter Eleven", "Defeat all enemies in Chapter 11 of Salt's Enemy Mod.", ResourceLoader.LoadSprite("Chapter11Achi.png", 32));
                    effectItem.Prepare();
                    _eleven = effectItem;
                }
                return _eleven;
            }
        }
        static UnlockItem _twelve;
        public static UnlockItem Twelve
        {
            get
            {
                if (_twelve == null)
                {
                    UnlockItem effectItem = new UnlockItem();
                    effectItem.name = "Feather Gun";
                    effectItem.flavorText = "\"Bizarre fetish\"";
                    effectItem.description = "Deal 15% more damage. Deal 100% more damage if the target is an Avian.";
                    effectItem.sprite = ResourceLoader.LoadSprite("FeatherGun.png");
                    effectItem.trigger = SaltEnemies.FeatherGun;
                    effectItem.namePopup = true;
                    effectItem.consumedOnUse = false;
                    effectItem.itemPools = ItemPools.Treasure;
                    effectItem.shopPrice = 10;
                    effectItem.startsLocked = false;
                    effectItem.immediate = false;
                    effectItem.effects = new Effect[0];
                    effectItem.triggerConditions = new EffectorConditionSO[] { ScriptableObject.CreateInstance<FeatherGunCondition>() };
                    effectItem.unlockableID = (UnlockableID)18482912;
                    effectItem.Ach = new AchievementSystem.AchieveInfo((Achievement)18482912, AchievementUnlockType.Strangers, "Salt's Enemies Chapter Twelve", "Defeat all enemies in Chapter 12 of Salt's Enemy Mod.", ResourceLoader.LoadSprite("Chapter12Achi.png", 32));
                    effectItem.Prepare();
                    _twelve = effectItem;
                }
                return _twelve;
            }
        }
        static UnlockItem _thirteen;
        public static UnlockItem Thirteen
        {
            get
            {
                if (_thirteen == null)
                {
                    UnlockItem effectItem = new UnlockItem();
                    effectItem.name = "Stage Fright";
                    effectItem.flavorText = "\"Imagine them all as potatoes.\"";
                    effectItem.description = "If there is no Opposing enemy deal 30% more damage.";
                    effectItem.sprite = ResourceLoader.LoadSprite("StageFreight.png");
                    effectItem.trigger = TriggerCalls.OnWillApplyDamage;
                    effectItem.namePopup = true;
                    effectItem.consumedOnUse = false;
                    effectItem.itemPools = ItemPools.Shop;
                    effectItem.shopPrice = 5;
                    effectItem.startsLocked = false;
                    effectItem.immediate = false;
                    effectItem.effects = new Effect[0];
                    effectItem.triggerConditions = new EffectorConditionSO[] { ScriptableObject.CreateInstance<StageFrightCondition>() };
                    effectItem.unlockableID = (UnlockableID)18482913;
                    effectItem.Ach = new AchievementSystem.AchieveInfo((Achievement)18482913, AchievementUnlockType.Strangers, "Salt's Enemies Chapter Thirteen", "Defeat all enemies in Chapter 13 of Salt's Enemy Mod.", ResourceLoader.LoadSprite("Chapter13Achi.png", 32));
                    effectItem.Prepare();
                    _thirteen = effectItem;
                }
                return _thirteen;
            }
        }
        static UnlockItem _fourteen;
        public static UnlockItem Fourteen
        {
            get
            {
                if (_fourteen == null)
                {
                    UnlockItem effectItem = new UnlockItem();
                    effectItem.name = "Coelacanth";
                    effectItem.flavorText = "\"You caught a... coelacanth! 150 cm\"";
                    effectItem.description = "On taking any damage, heal 2 health and inflict 1 Deep Water on the Opposing position. 10% chance to be destroyed on activation.";
                    effectItem.sprite = ResourceLoader.LoadSprite("Coelocanth.png");
                    effectItem.trigger = TriggerCalls.OnDamaged;
                    effectItem.namePopup = true;
                    effectItem.consumedOnUse = false;
                    effectItem.itemPools = ItemPools.Fish;
                    effectItem.shopPrice = 3;
                    effectItem.Fish = 1;
                    effectItem.startsLocked = false;
                    effectItem.immediate = false;
                    effectItem.effects = new Effect[] { new Effect(ScriptableObject.CreateInstance<HealEffect>(), 2, null, Slots.Self), new Effect(ScriptableObject.CreateInstance<ApplyWaterSlotEffect>(), 1, null, Slots.Front), new Effect(ScriptableObject.CreateInstance<ConsumeItemEffect>(), 1, null, Slots.Self, Conditions.Chance(10)) };
                    effectItem.unlockableID = (UnlockableID)18482914;
                    effectItem.Ach = new AchievementSystem.AchieveInfo((Achievement)18482914, AchievementUnlockType.Strangers, "Salt's Enemies Chapter Fourteen", "Defeat all enemies in Chapter 14 of Salt's Enemy Mod.", ResourceLoader.LoadSprite("Chapter14Achi.png", 32));
                    effectItem.Prepare();
                    _fourteen = effectItem;
                }
                return _fourteen;
            }
        }
        static UnlockItem _fifteen;
        public static UnlockItem Fifteen
        {
            get
            {
                if (_fifteen == null)
                {
                    UnlockItem effectItem = new UnlockItem();
                    effectItem.name = "Hormone Gasses";
                    effectItem.flavorText = "\"Untested for side effects\"";
                    effectItem.description = "On using an ability, inflict 2-3 Pimples on the Opposing enemy.";
                    effectItem.sprite = ResourceLoader.LoadSprite("HormoneGasses.png");
                    effectItem.trigger = TriggerCalls.OnAbilityUsed;
                    effectItem.namePopup = true;
                    effectItem.consumedOnUse = false;
                    effectItem.itemPools = ItemPools.Shop;
                    effectItem.shopPrice = 2;
                    effectItem.startsLocked = false;
                    effectItem.immediate = false;
                    effectItem.effects = new Effect[] { new Effect(ScriptableObject.CreateInstance<ApplyPimplesEffect>(), 2, null, Slots.Front), new Effect(ScriptableObject.CreateInstance<ApplyPimplesEffect>(), 1, null, Slots.Front, Conditions.Chance(50)) };
                    effectItem.unlockableID = (UnlockableID)18482915;
                    effectItem.Ach = new AchievementSystem.AchieveInfo((Achievement)18482915, AchievementUnlockType.Strangers, "Salt's Enemies Chapter Fifteen", "Defeat all enemies in Chapter 15 of Salt's Enemy Mod.", ResourceLoader.LoadSprite("Chapter15Achi.png", 32));
                    effectItem.Prepare();
                    _fifteen = effectItem;
                }
                return _fifteen;
            }
        }
        static UnlockItem _sixteen;
        public static UnlockItem Sixteen
        {
            get
            {
                if (_sixteen == null)
                {
                    UnlockItem effectItem = new UnlockItem();
                    effectItem.name = "Glowing Hat";
                    effectItem.flavorText = "\"Makes you visible to those in the dark.\"";
                    effectItem.description = "Before taking any damage, gain Spotlight.";
                    effectItem.sprite = ResourceLoader.LoadSprite("GlowingHat.png");
                    effectItem.trigger = GlowingHatCondition.Trigger;
                    effectItem.namePopup = true;
                    effectItem.consumedOnUse = false;
                    effectItem.itemPools = ItemPools.Shop;
                    effectItem.shopPrice = 4;
                    effectItem.startsLocked = false;
                    effectItem.immediate = false;
                    effectItem.effects = new Effect[0];
                    effectItem.triggerConditions = new EffectorConditionSO[] { ScriptableObject.CreateInstance<GlowingHatCondition>() };
                    effectItem.unlockableID = (UnlockableID)18482916;
                    effectItem.Ach = new AchievementSystem.AchieveInfo((Achievement)18482916, AchievementUnlockType.Strangers, "Salt's Enemies Chapter Sixteen", "Defeat all enemies in Chapter 16 of Salt's Enemy Mod.", ResourceLoader.LoadSprite("Chapter16Achi.png", 32));
                    effectItem.Prepare();
                    _sixteen = effectItem;
                }
                return _sixteen;
            }
        }
    }

    public class ThirdTurnPassedCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            return CombatManager.Instance._stats.TurnsPassed == 2;
        }
    }
    public class CopyLastAbilityEffect : EffectSO
    {
        public static AbilitySO LastAbility;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (LastAbility == null) return false;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (targetSlotInfo.HasUnit && targetSlotInfo.Unit.TryPerformRandomAbility(LastAbility))
                {
                    exitAmount++;
                }
            }

            return exitAmount > 0;
        }
    }
    public class EveryOtherTurnPassedCondition : EffectorConditionSO
    {
        static UnitStoredValueNames value => (UnitStoredValueNames)2720884;
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (effector is IUnit unit)
            {
                if (unit.GetStoredValue(value) <= 0)
                {
                    unit.SetStoredValue(value, 1);
                    return false;
                }
                else
                {
                    unit.SetStoredValue(value, 0);
                    return true;
                }
            }
            return true;
        }
    }
    public class TinCanCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is BooleanReference reference && effector is IUnit unit)
            {
                if (reference.value == true)
                {
                    unit.TryConsumeWearable();
                    if (unit.Heal(1, HealType.Heal, true) > 0) reference.value = false;
                    return false;
                }
            }
            return false;
        }
    }
    public class FeatherGunCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is DamageDealtValueChangeException hitting)
            {
                if (effector is IUnit unit && unit.HasUsableItem) CombatManager.Instance.AddUIAction(new ShowItemInformationUIAction(unit.ID, unit.HeldItem._itemName, false, unit.HeldItem.wearableImage));
                if (hitting.opponentUnitType == SaltEnemies.Avian) hitting.AddModifier(new FloatMod(2.0f, true));
                else hitting.AddModifier(new FloatMod(1.15f, true));
            }
            return false;
        }
    }
    public class StageFrightCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (effector is IUnit unit && args is DamageDealtValueChangeException change)
            {
                foreach (TargetSlotInfo target in Slots.Front.GetTargets(CombatManager.Instance._stats.combatSlots, unit.SlotID, unit.IsUnitCharacter))
                {
                    if (target.HasUnit) return false;
                }
                if (unit.HasUsableItem) CombatManager.Instance.AddUIAction(new ShowItemInformationUIAction(unit.ID, unit.HeldItem._itemName, false, unit.HeldItem.wearableImage));
                change.AddModifier(new FloatMod(1.3f, true));
            }
            return false;
        }
    }
    public class GlowingHatCondition : EffectorConditionSO
    {
        public static TriggerCalls Trigger => (TriggerCalls)3739912;
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (effector is IUnit unit)
            {
                if (unit.HasUsableItem) CombatManager.Instance.AddUIAction(new ShowItemInformationUIAction(unit.ID, unit.HeldItem.GetItemLocData().text, false, unit.HeldItem.wearableImage));
                Spotlight_StatusEffect spotlight_StatusEffect = new Spotlight_StatusEffect();
                CombatManager.Instance._stats.statusEffectDataBase.TryGetValue(StatusEffectType.Spotlight, out var value);
                spotlight_StatusEffect.SetEffectInformation(value);
                unit.ApplyStatusEffect(spotlight_StatusEffect, 0);
            }
            return false;
        }
    }
}
