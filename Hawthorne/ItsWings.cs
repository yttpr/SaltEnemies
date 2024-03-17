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
using static UnityEngine.UI.CanvasScaler;
using THE_DEAD;

namespace Hawthorne
{
    public static class ItsWings
    {
        public static void Add()
        {
            UnlockItem effectItem = new UnlockItem();
            effectItem.name = "Its Wings";
            effectItem.flavorText = "\"As it spreads its wings for an old god, a heaven just for you burrows its way.\"";
            effectItem.description = "On combat start, apply a quarter of this character's max health as Power to themself, and half of that to the opposing enemy. This item does not trigger if there is no opposing enemy.";
            effectItem.sprite = ResourceLoader.LoadSprite("itswings", 32);
            effectItem.trigger = TriggerCalls.OnFirstTurnStart;
            effectItem.namePopup = false;
            effectItem.consumedOnUse = false;
            effectItem.itemPools = ItemPools.Treasure;
            effectItem.shopPrice = 5;
            effectItem.startsLocked = false;
            effectItem.immediate = false;
            effectItem.effects = new Effect[1]
            {
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyPercentHPPowerEffect>(), 1, new IntentType?((IntentType)987895), Slots.Front)
            };
            effectItem.unlockableID = (UnlockableID)666888;
            effectItem.Ach = new AchievementSystem.AchieveInfo((Achievement)668867, AchievementUnlockType.Comedies, "No One Cares", "Extinguish the Embers of a Dead God.", ResourceLoader.LoadSprite("DGAch.png", 32));
            effectItem.Prepare();
            Wings = effectItem;
        }

        public static Item Wings;
    }
    public static class LootFour
    {
        public static Item Water;
        public static Item Nine;
        public static Item Sign;
        public static void AddWater()
        {
            UnlockItem effectItem = new UnlockItem();
            effectItem.name = "Deep Waters";
            effectItem.flavorText = "\"So blue it's pitch black\"";
            effectItem.description = "On taking Overflow or Wrong Pigment damage, apply Anesthetics to this character for the amount of damage taken.";
            effectItem.sprite = ResourceLoader.LoadSprite("DeepWater.png", 32);
            effectItem.trigger = TriggerCalls.OnBeingDamaged;
            effectItem.namePopup = true;
            effectItem.consumedOnUse = false;
            effectItem.itemPools = ItemPools.Treasure;
            effectItem.shopPrice = 5;
            effectItem.startsLocked = false;
            effectItem.immediate = false;
            effectItem.effects = new Effect[0]
            {
            };
            effectItem.triggerConditions = new EffectorConditionSO[]
            {
                ScriptableObject.CreateInstance<DeepWaterCondition>()
            };
            effectItem.unlockableID = (UnlockableID)544484;
            effectItem.Ach = new AchievementSystem.AchieveInfo((Achievement)544484, AchievementUnlockType.Comedies, "Drink the Ocean", "Submerge The Deep.", ResourceLoader.LoadSprite("DeepAch.png", 32));
            effectItem.Prepare();
            Water = effectItem;
        }
        public static void AddNine()
        {
            UnlockItem effectItem = new UnlockItem();
            effectItem.name = "Nine Key";
            effectItem.flavorText = "\"It's all just a dream\"";
            effectItem.description = "Gives this party member the additional ability \"Awaken\" which has a chance to kill themself or random enemies. Adds \"Locked In\" as a passive to all party members at the start of combat, preventing the pause menu from being accessed.";
            effectItem.sprite = ResourceLoader.LoadSprite("NineKey.png", 32);
            effectItem.trigger = TriggerCalls.OnCombatStart;
            effectItem.namePopup = true;
            effectItem.consumedOnUse = false;
            effectItem.itemPools = ItemPools.Treasure;
            effectItem.shopPrice = 2;
            effectItem.startsLocked = false;
            effectItem.immediate = false;
            AddPassiveEffect locked = ScriptableObject.CreateInstance<AddPassiveEffect>();
            locked._passiveToAdd = Passi.Lock;
            effectItem.effects = new Effect[]
            {
                new Effect(locked, 1, null, Targetting.AllAlly)
            };
            effectItem.unlockableID = (UnlockableID)544483;
            MultiPreviousEffectOrCondition firstSecond = ScriptableObject.CreateInstance<MultiPreviousEffectOrCondition>();
            firstSecond.wasSuccessful = new bool[] { true, true };
            firstSecond.previousAmount = new int[] { 1, 2 };
            AnimationVisualsEffect visuals = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            visuals._visuals = ((LoadedAssetsHandler.GetEnemy("OsmanSinnoks_BOSS").passiveAbilities[0] as ExtraAttackPassiveAbility)._extraAbility.ability.effects[0].effect as AnimationVisualsIfUnitEffect)._visuals;
            visuals._animationTarget = Slots.Self;
            Ability awaken = new Ability();
            awaken.name = "Awaken";
            awaken.description = "15% chance to instantly kill this party member. 30% chance to instantly kill a random enemy.";
            awaken.cost = new ManaColorSO[] { Pigments.Purple };
            awaken.effects = new Effect[6];
            awaken.effects[0] = new Effect(BasicEffects.Empty, 22, null, Slots.Self, Conditions.Chance(15));
            awaken.effects[1] = new Effect(BasicEffects.Empty, 22, null, Slots.Self, Conditions.Chance(35));
            awaken.effects[2] = new Effect(visuals, 22, null, Slots.Self, firstSecond);
            awaken.effects[3] = new Effect(ScriptableObject.CreateInstance<DirectDeathEffect>(), 1, IntentType.Damage_Death, Slots.Self, BasicEffects.DidThat(true, 3));
            awaken.effects[4] = new Effect(ScriptableObject.CreateInstance<DirectDeathEffect>(), 1, null, Targetting.Random(false), BasicEffects.DidThat(true, 3));
            awaken.effects[5] = new Effect(BasicEffects.Empty, 1, IntentType.Damage_Death, Targetting.AllEnemy);
            awaken.visuals = null;
            awaken.animationTarget = Slots.Self;
            ExtraAbility_Wearable_SMS extra = ScriptableObject.CreateInstance<ExtraAbility_Wearable_SMS>();
            extra._extraAbility = awaken.CharacterAbility();
            ExtraPassiveAbility_Wearable_SMS passi = ScriptableObject.CreateInstance<ExtraPassiveAbility_Wearable_SMS>();
            passi._extraPassiveAbility = Passi.Lock;
            effectItem.equippedModifiers = new WearableStaticModifierSetterSO[] { extra, passi };
            effectItem.Ach = new AchievementSystem.AchieveInfo((Achievement)544483, AchievementUnlockType.Comedies, "2000", "Undo Postmodern.", ResourceLoader.LoadSprite("PMAch.png", 32));
            effectItem.Prepare();
            Nine = effectItem;
        }
        public static void AddSign()
        {
            UnlockItem effectItem = new UnlockItem();
            effectItem.name = "Cardboard Sign";
            effectItem.flavorText = "\"Barely fooled me.\"";
            effectItem.description = "On an enemy moving in front of this party member, apply 5 Shield to this party member's position.";
            effectItem.sprite = ResourceLoader.LoadSprite("WoodSign.png", 32);
            effectItem.trigger = (TriggerCalls)AmbushManager.Patiently;
            effectItem.namePopup = true;
            effectItem.consumedOnUse = false;
            effectItem.itemPools = ItemPools.Shop;
            effectItem.shopPrice = 8;
            effectItem.startsLocked = false;
            effectItem.immediate = true;
            effectItem.effects = new Effect[]
            {
                new Effect(ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 5, null, Slots.Self)
            };
            effectItem.unlockableID = (UnlockableID)544481;
            effectItem.Ach = new AchievementSystem.AchieveInfo((Achievement)544481, AchievementUnlockType.Comedies, "Not Scary", "Chase away Kyotlokutla.", ResourceLoader.LoadSprite("SnakeAch.png", 32));
            effectItem.Prepare();
            Sign = effectItem;
        }
        public static void Add()
        {
            AddWater();
            AddNine();
            AddSign();
        }
    }
    public class DeepWaterCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (effector is IUnit unit && args is DamageReceivedValueChangeException hitBy)
            {
                if (hitBy.damageType == DamageType.Mana && hitBy.amount > 0)
                {
                    hitBy.AddModifier(new DeepWaterMod(unit));
                    return true;
                }
            }
            return false;
        }
    }
    public class DeepWaterMod : IntValueModifier
    {
        static ApplyAnestheticsEffect _status;
        public static ApplyAnestheticsEffect Status
        {
            get
            {
                if (_status == null)
                {
                    _status = ScriptableObject.CreateInstance<ApplyAnestheticsEffect>();
                }
                return _status;
            }
        }
        public readonly IUnit Unit;
        public DeepWaterMod(IUnit unit) : base(1200)
        {
            Unit = unit;
        }
        public override int Modify(int value)
        {
            Effect run = new Effect(Status, value, null, Slots.Self);
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[] { run }), Unit));
            return value;
        }
    }
    public class MultiPreviousEffectOrCondition : EffectConditionSO
    {
        public bool[] wasSuccessful;

        [Range(1f, 20f)]
        public int[] previousAmount;

        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            for (int i = 0; i < wasSuccessful.Length && i < previousAmount.Length; i++)
            {
                int num = currentIndex - previousAmount[i];
                if (num < 0 || num > effects.Length)
                {
                    return false;
                }

                if (effects[num].EffectSuccess == wasSuccessful[i])
                {
                    return true;
                }
            }

            return false;
        }
    }
}
