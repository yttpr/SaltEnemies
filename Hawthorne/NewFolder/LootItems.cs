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
using Hawthorne;
using System.Collections.Generic;
using static Hawthorne.AchievementSystem;

namespace Hawthorne.NewFolder
{
    public static class LootItems
    {
        public static List<Item> Bullets = new List<Item>();
        public static Item[] LobItems = new Item[3];
        public static Item SnowGlobe;
        
        public static void Add()
        {
            DamageEffect indirect = ScriptableObject.CreateInstance<DamageEffect>();
            indirect._indirect = true;
            Targetting_ByUnit_Side allEnemy = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            allEnemy.getAllies = false;
            allEnemy.getAllUnitSlots = false;

            ExtraLootOptionsEffect gun6 = ScriptableObject.CreateInstance<ExtraLootOptionsEffect>();
            gun6._itemName = "LoadedGun_EW";
            ExtraLootOptionsEffect gun5 = ScriptableObject.CreateInstance<ExtraLootOptionsEffect>();
            gun5._itemName = "5/6LoadedGun_EW";
            ExtraLootOptionsEffect gun4 = ScriptableObject.CreateInstance<ExtraLootOptionsEffect>();
            gun4._itemName = "4/6LoadedGun_EW";
            ExtraLootOptionsEffect gun3 = ScriptableObject.CreateInstance<ExtraLootOptionsEffect>();
            gun3._itemName = "3/6LoadedGun_EW";
            ExtraLootOptionsEffect gun2 = ScriptableObject.CreateInstance<ExtraLootOptionsEffect>();
            gun2._itemName = "2/6LoadedGun_EW";
            ExtraLootOptionsEffect gun1 = ScriptableObject.CreateInstance<ExtraLootOptionsEffect>();
            gun1._itemName = "1/6LoadedGun_EW";
            ExtraLootOptionsEffect gun0 = ScriptableObject.CreateInstance<ExtraLootOptionsEffect>();
            gun0._itemName = "UnloadedGun_EW";


            Ability bloodBullet6 = new Ability();
            bloodBullet6.name = "Blood Bullet";
            bloodBullet6.description = "Deal 20 damage to the opposing enemy. Consume 1 bullet from the current held item. This ability can only be used once per combat.";
            bloodBullet6.cost = new ManaColorSO[2] { Pigments.Red, Pigments.Red };
            bloodBullet6.sprite = ResourceLoader.LoadSprite("BloodBullet");
            bloodBullet6.effects = new Effect[4];
            bloodBullet6.effects[0] = new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 20, IntentType.Damage_16_20, Slots.Front);
            bloodBullet6.effects[1] = new Effect(ScriptableObject.CreateInstance<ConsumeItemEffect>(), 1, IntentType.Misc, Slots.Self);
            bloodBullet6.effects[2] = new Effect(gun5, 1, null, Slots.Self);
            bloodBullet6.effects[3] = new Effect(ScriptableObject.CreateInstance<RemoveBloodBulletAndTrueBulletEffect>(), 1, null, Slots.Self);
            bloodBullet6.visuals = LoadedAssetsHandler.GetEnemyAbility("Crush_A").visuals;
            bloodBullet6.animationTarget = Slots.Front;
            Ability bloodBullet5 = new Ability();
            bloodBullet5.name = "Blood Bullet";
            bloodBullet5.description = "Deal 20 damage to the opposing enemy. Consume 1 bullet from the current held item. This ability can only be used once per combat.";
            bloodBullet5.cost = new ManaColorSO[2] { Pigments.Red, Pigments.Red };
            bloodBullet5.sprite = ResourceLoader.LoadSprite("BloodBullet");
            bloodBullet5.effects = new Effect[4];
            bloodBullet5.effects[0] = new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 20, IntentType.Damage_16_20, Slots.Front);
            bloodBullet5.effects[1] = new Effect(ScriptableObject.CreateInstance<ConsumeItemEffect>(), 1, IntentType.Misc, Slots.Self);
            bloodBullet5.effects[2] = new Effect(gun4, 1, null, Slots.Self);
            bloodBullet5.effects[3] = new Effect(ScriptableObject.CreateInstance<RemoveBloodBulletAndTrueBulletEffect>(), 1, null, Slots.Self);
            bloodBullet5.visuals = LoadedAssetsHandler.GetEnemyAbility("Crush_A").visuals;
            bloodBullet5.animationTarget = Slots.Front;
            Ability bloodBullet4 = new Ability();
            bloodBullet4.name = "Blood Bullet";
            bloodBullet4.description = "Deal 20 damage to the opposing enemy. Consume 1 bullet from the current held item. This ability can only be used once per combat.";
            bloodBullet4.cost = new ManaColorSO[2] { Pigments.Red, Pigments.Red };
            bloodBullet4.sprite = ResourceLoader.LoadSprite("BloodBullet");
            bloodBullet4.effects = new Effect[4];
            bloodBullet4.effects[0] = new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 20, IntentType.Damage_16_20, Slots.Front);
            bloodBullet4.effects[1] = new Effect(ScriptableObject.CreateInstance<ConsumeItemEffect>(), 1, IntentType.Misc, Slots.Self);
            bloodBullet4.effects[2] = new Effect(gun3, 1, null, Slots.Self);
            bloodBullet4.effects[3] = new Effect(ScriptableObject.CreateInstance<RemoveBloodBulletAndTrueBulletEffect>(), 1, null, Slots.Self);
            bloodBullet4.visuals = LoadedAssetsHandler.GetEnemyAbility("Crush_A").visuals;
            bloodBullet4.animationTarget = Slots.Front;
            Ability bloodBullet3 = new Ability();
            bloodBullet3.name = "Blood Bullet";
            bloodBullet3.description = "Deal 20 damage to the opposing enemy. Consume 1 bullet from the current held item. This ability can only be used once per combat.";
            bloodBullet3.cost = new ManaColorSO[2] { Pigments.Red, Pigments.Red };
            bloodBullet3.sprite = ResourceLoader.LoadSprite("BloodBullet");
            bloodBullet3.effects = new Effect[4];
            bloodBullet3.effects[0] = new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 20, IntentType.Damage_16_20, Slots.Front);
            bloodBullet3.effects[1] = new Effect(ScriptableObject.CreateInstance<ConsumeItemEffect>(), 1, IntentType.Misc, Slots.Self);
            bloodBullet3.effects[2] = new Effect(gun2, 1, null, Slots.Self);
            bloodBullet3.effects[3] = new Effect(ScriptableObject.CreateInstance<RemoveBloodBulletAndTrueBulletEffect>(), 1, null, Slots.Self);
            bloodBullet3.visuals = LoadedAssetsHandler.GetEnemyAbility("Crush_A").visuals;
            bloodBullet3.animationTarget = Slots.Front;
            Ability bloodBullet2 = new Ability();
            bloodBullet2.name = "Blood Bullet";
            bloodBullet2.description = "Deal 20 damage to the opposing enemy. Consume 1 bullet from the current held item. This ability can only be used once per combat.";
            bloodBullet2.cost = new ManaColorSO[2] { Pigments.Red, Pigments.Red };
            bloodBullet2.sprite = ResourceLoader.LoadSprite("BloodBullet");
            bloodBullet2.effects = new Effect[4];
            bloodBullet2.effects[0] = new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 20, IntentType.Damage_16_20, Slots.Front);
            bloodBullet2.effects[1] = new Effect(ScriptableObject.CreateInstance<ConsumeItemEffect>(), 1, IntentType.Misc, Slots.Self);
            bloodBullet2.effects[2] = new Effect(gun1, 1, null, Slots.Self);
            bloodBullet2.effects[3] = new Effect(ScriptableObject.CreateInstance<RemoveBloodBulletAndTrueBulletEffect>(), 1, null, Slots.Self);
            bloodBullet2.visuals = LoadedAssetsHandler.GetEnemyAbility("Crush_A").visuals;
            bloodBullet2.animationTarget = Slots.Front;
            Ability bloodBullet1 = new Ability();
            bloodBullet1.name = "Blood Bullet";
            bloodBullet1.description = "Deal 20 damage to the opposing enemy. Consume 1 bullet from the current held item. This ability can only be used once per combat.";
            bloodBullet1.cost = new ManaColorSO[2] { Pigments.Red, Pigments.Red };
            bloodBullet1.sprite = ResourceLoader.LoadSprite("BloodBullet");
            bloodBullet1.effects = new Effect[4];
            bloodBullet1.effects[0] = new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 20, IntentType.Damage_16_20, Slots.Front);
            bloodBullet1.effects[1] = new Effect(ScriptableObject.CreateInstance<ConsumeItemEffect>(), 1, IntentType.Misc, Slots.Self);
            bloodBullet1.effects[2] = new Effect(gun0, 1, null, Slots.Self);
            bloodBullet1.effects[3] = new Effect(ScriptableObject.CreateInstance<RemoveBloodBulletAndTrueBulletEffect>(), 1, null, Slots.Self);
            bloodBullet1.visuals = LoadedAssetsHandler.GetEnemyAbility("Crush_A").visuals;
            bloodBullet1.animationTarget = Slots.Front;
            Ability trueBullet = new Ability();
            trueBullet.name = "True Bullet";
            trueBullet.description = "Kill this character. Load the gun. This ability can only be used once per combat.";
            trueBullet.cost = new ManaColorSO[0] { };
            trueBullet.sprite = ResourceLoader.LoadSprite("TrueBullet");
            trueBullet.effects = new Effect[4];
            trueBullet.effects[0] = new Effect(ScriptableObject.CreateInstance<DirectDeathEffect>(), 1, IntentType.Damage_Death, Slots.Self);
            trueBullet.effects[1] = new Effect(ScriptableObject.CreateInstance<ConsumeItemEffect>(), 1, IntentType.Misc, Slots.Self);
            trueBullet.effects[2] = new Effect(gun6, 1, null, Slots.Self);
            trueBullet.effects[3] = new Effect(ScriptableObject.CreateInstance<RemoveBloodBulletAndTrueBulletEffect>(), 1, null, Slots.Self);
            trueBullet.visuals = LoadedAssetsHandler.GetEnemy("TriggerFingers_BOSS").abilities[3].ability.visuals;
            trueBullet.animationTarget = Slots.Self;


            AddCasterExtraAbilityEffect sixth = ScriptableObject.CreateInstance<AddCasterExtraAbilityEffect>();
            sixth.thisAbility = bloodBullet6;
            AddCasterExtraAbilityEffect fifth = ScriptableObject.CreateInstance<AddCasterExtraAbilityEffect>();
            fifth.thisAbility = bloodBullet5;
            AddCasterExtraAbilityEffect fourth = ScriptableObject.CreateInstance<AddCasterExtraAbilityEffect>();
            fourth.thisAbility = bloodBullet4;
            AddCasterExtraAbilityEffect third = ScriptableObject.CreateInstance<AddCasterExtraAbilityEffect>();
            third.thisAbility = bloodBullet3;
            AddCasterExtraAbilityEffect second = ScriptableObject.CreateInstance<AddCasterExtraAbilityEffect>();
            second.thisAbility = bloodBullet2;
            AddCasterExtraAbilityEffect first = ScriptableObject.CreateInstance<AddCasterExtraAbilityEffect>();
            first.thisAbility = bloodBullet1;
            AddCasterExtraAbilityEffect zero = ScriptableObject.CreateInstance<AddCasterExtraAbilityEffect>();
            zero.thisAbility = trueBullet;


            UnlockItem bullets6 = new UnlockItem();
            bullets6.name = "Loaded Gun";
            bullets6.flavorText = "\"For whom does the bell toll?\"";
            bullets6.description = "Adds \"Blood Bullet\" as an extra ability.";
            bullets6.sprite = ResourceLoader.LoadSprite("SixBullet", 32);
            bullets6.trigger = TriggerCalls.OnCombatStart;
            /*bullets6.triggerConditions = new EffectorConditionSO[1]
            {
                firball15P
            };*/
            bullets6.consumeTrigger = TriggerCalls.Count;
            bullets6.unlockableID = (UnlockableID)544517;
            bullets6.namePopup = false;
            bullets6.consumedOnUse = false;
            bullets6.itemPools = ItemPools.Treasure;
            bullets6.shopPrice = 5;
            bullets6.startsLocked = false;
            bullets6.immediate = false;
            
            bullets6.effects = new Effect[1]
            {
                new Effect(sixth, 1, IntentType.Misc, Slots.Self)
            };

            bullets6.Ach = new AchieveInfo((Achievement)544517, AchievementUnlockType.Comedies, "Loaded Gun", "Clear 544517.", ResourceLoader.LoadSprite("GunAch", 32), true, "Unlocked a new item.");

            //bullets6.Prepare();
            UnlockItem bullets5 = new UnlockItem();
            bullets5.name = "5/6 Loaded Gun";
            bullets5.flavorText = "\"For whom does the bell toll?\"";
            bullets5.description = "Adds \"Blood Bullet\" as an extra ability.";
            bullets5.sprite = ResourceLoader.LoadSprite("FiveBullet", 32);
            bullets5.trigger = TriggerCalls.OnCombatStart;
            /*bullets6.triggerConditions = new EffectorConditionSO[1]
            {
                firball15P
            };*/
            bullets5.consumeTrigger = TriggerCalls.Count;
            bullets5.unlockableID = (UnlockableID)544518;
            bullets5.namePopup = false;
            bullets5.consumedOnUse = false;
            bullets5.itemPools = ItemPools.Extra;
            bullets5.shopPrice = 5;
            bullets5.startsLocked = false;
            bullets5.immediate = false;

            bullets5.effects = new Effect[1]
            {
                new Effect(fifth, 1, IntentType.Misc, Slots.Self)
            };
            //bullets5.Prepare();

            UnlockItem bullets4 = new UnlockItem();
            bullets4.name = "4/6 Loaded Gun";
            bullets4.flavorText = "\"For whom does the bell toll?\"";
            bullets4.description = "Adds \"Blood Bullet\" as an extra ability.";
            bullets4.sprite = ResourceLoader.LoadSprite("FourBullet", 32);
            bullets4.trigger = TriggerCalls.OnCombatStart;
            /*bullets6.triggerConditions = new EffectorConditionSO[1]
            {
                firball15P
            };*/
            bullets4.consumeTrigger = TriggerCalls.Count;
            bullets4.unlockableID = (UnlockableID)544519;
            bullets4.namePopup = false;
            bullets4.consumedOnUse = false;
            bullets4.itemPools = ItemPools.Extra;
            bullets4.shopPrice = 5;
            bullets4.startsLocked = false;
            bullets4.immediate = false;

            bullets4.effects = new Effect[1]
            {
                new Effect(fourth, 1, IntentType.Misc, Slots.Self)
            };
            //bullets4.Prepare();

            UnlockItem bullets3 = new UnlockItem();
            bullets3.name = "3/6 Loaded Gun";
            bullets3.flavorText = "\"For whom does the bell toll?\"";
            bullets3.description = "Adds \"Blood Bullet\" as an extra ability.";
            bullets3.sprite = ResourceLoader.LoadSprite("ThreeBullet", 32);
            bullets3.trigger = TriggerCalls.OnCombatStart;
            /*bullets6.triggerConditions = new EffectorConditionSO[1]
            {
                firball15P
            };*/
            bullets3.consumeTrigger = TriggerCalls.Count;
            bullets3.unlockableID = (UnlockableID)544520;
            bullets3.namePopup = false;
            bullets3.consumedOnUse = false;
            bullets3.itemPools = ItemPools.Extra;
            bullets3.shopPrice = 5;
            bullets3.startsLocked = false;
            bullets3.immediate = false;

            bullets3.effects = new Effect[1]
            {
                new Effect(third, 1, IntentType.Misc, Slots.Self)
            };
            //bullets3.Prepare();

            UnlockItem bullets2 = new UnlockItem();
            bullets2.name = "2/6 Loaded Gun";
            bullets2.flavorText = "\"For whom does the bell toll?\"";
            bullets2.description = "Adds \"Blood Bullet\" as an extra ability.";
            bullets2.sprite = ResourceLoader.LoadSprite("TwoBullet", 32);
            bullets2.trigger = TriggerCalls.OnCombatStart;
            /*bullets6.triggerConditions = new EffectorConditionSO[1]
            {
                firball15P
            };*/
            bullets2.consumeTrigger = TriggerCalls.Count;
            bullets2.unlockableID = (UnlockableID)544521;
            bullets2.namePopup = false;
            bullets2.consumedOnUse = false;
            bullets2.itemPools = ItemPools.Extra;
            bullets2.shopPrice = 5;
            bullets2.startsLocked = false;
            bullets2.immediate = false;

            bullets2.effects = new Effect[1]
            {
                new Effect(second, 1, IntentType.Misc, Slots.Self)
            };
            //bullets2.Prepare();

            UnlockItem bullets1 = new UnlockItem();
            bullets1.name = "1/6 Loaded Gun";
            bullets1.flavorText = "\"For whom does the bell toll?\"";
            bullets1.description = "Adds \"Blood Bullet\" as an extra ability.";
            bullets1.sprite = ResourceLoader.LoadSprite("OneBullet", 32);
            bullets1.trigger = TriggerCalls.OnCombatStart;
            /*bullets6.triggerConditions = new EffectorConditionSO[1]
            {
                firball15P
            };*/
            bullets1.consumeTrigger = TriggerCalls.Count;
            bullets1.unlockableID = (UnlockableID)544522;
            bullets1.namePopup = false;
            bullets1.consumedOnUse = false;
            bullets1.itemPools = ItemPools.Extra;
            bullets1.shopPrice = 5;
            bullets1.startsLocked = false;
            bullets1.immediate = false;

            bullets1.effects = new Effect[1]
            {
                new Effect(first, 1, IntentType.Misc, Slots.Self)
            };
            //bullets1.Prepare();

            UnlockItem bullets0 = new UnlockItem();
            bullets0.name = "Unloaded Gun";
            bullets0.flavorText = "\"The bell tolls for THEE!\"";
            bullets0.description = "Adds \"True Bullet\" as an extra ability.";
            bullets0.sprite = ResourceLoader.LoadSprite("NoBullet", 32);
            bullets0.trigger = TriggerCalls.OnCombatStart;
            /*bullets6.triggerConditions = new EffectorConditionSO[1]
            {
                firball15P
            };*/
            bullets0.consumeTrigger = TriggerCalls.Count;
            bullets0.unlockableID = (UnlockableID)544523;
            bullets0.namePopup = false;
            bullets0.consumedOnUse = false;
            bullets0.itemPools = ItemPools.Extra;
            bullets0.shopPrice = 5;
            bullets0.startsLocked = false;
            bullets0.immediate = false;

            bullets0.effects = new Effect[1]
            {
                new Effect(zero, 1, IntentType.Misc, Slots.Self)
            };
            //bullets0.Prepare();

            Bullets.Add(bullets0); Bullets.Add(bullets1); Bullets.Add(bullets2); Bullets.Add(bullets3); Bullets.Add(bullets4); Bullets.Add(bullets5); Bullets.Add(bullets6);
            bullets0.Hide = true; bullets1.Hide = true; bullets2.Hide = true; bullets3.Hide = true; bullets4.Hide = true; bullets5.Hide = true;
            bullets0.Gun = true; bullets1.Gun = true; bullets2.Gun = true; bullets3.Gun = true; bullets4.Gun = true; bullets5.Gun = true;
            bullets6.firstBullet = true;
            bullets6.Prepare();
            bullets5.Prepare();
            bullets4.Prepare();
            bullets3.Prepare();
            bullets2.Prepare();
            bullets1.Prepare();
            bullets0.Prepare();

            UnlockItem silence = new UnlockItem();
            silence.name = "The Value of Silence";
            silence.flavorText = "\"The most beautiful performance begins.\"";
            silence.description = "Apply 1 Muted to every enemy and 2 Muted to every other ally on combat start.";
            silence.sprite = ResourceLoader.LoadSprite("Silence", 32);
            silence.trigger = TriggerCalls.OnCombatStart;
            /*silence.triggerConditions = new EffectorConditionSO[1]
            {
                firball15P
            };*/
            silence.consumeTrigger = TriggerCalls.Count;
            silence.unlockableID = (UnlockableID)544516;
            silence.namePopup = true;
            silence.consumedOnUse = false;
            silence.itemPools = ItemPools.Treasure;
            silence.shopPrice = 5;
            silence.startsLocked = false;
            silence.immediate = false;
            silence.effects = new Effect[2]
            {
                new Effect(ScriptableObject.CreateInstance<ApplyMutedEffect>(), 1, (IntentType)846750, allEnemy),
                new Effect(ScriptableObject.CreateInstance<ApplyMutedEffect>(), 2, (IntentType)846750, Slots.SlotTarget(new int[8]{-4, -3, -2, -1, 1, 2, 3, 4 }, true))
            };

            silence.Ach = new AchieveInfo((Achievement)544516, AchievementUnlockType.Comedies, "The Value of Silence", "Clear 544516.", ResourceLoader.LoadSprite("SilentAch.png", 32), true, "Unlocked a new item.");

            silence.Prepare();

            FastClockPassiveAbility pauseKill = ScriptableObject.CreateInstance<FastClockPassiveAbility>();
            pauseKill._passiveName = "Fast Clock";
            pauseKill.passiveIcon = ResourceLoader.LoadSprite("ParanoidEscape", 32);
            pauseKill.type = (PassiveAbilityTypes)987883;
            pauseKill._enemyDescription = "On Pause, 30% chance to deal 10 indirect damage to a random enemy. 40% chance to destroy item on activation.";
            pauseKill._characterDescription = "On Pause, 30% chance to deal 10 indirect damage to a random enemy. 40% chance to destroy item on activation.";
            pauseKill.doesPassiveTriggerInformationPanel = false;
            pauseKill._triggerOn = new TriggerCalls[1] { TriggerCalls.Count };


            UnlockItem fastClock = new UnlockItem();
            fastClock.name = "Fast Clock";
            fastClock.flavorText = "\"Time flows like life. Life flows like time.\"";
            fastClock.description = "On pausing, 40% chance to deal 10 indirect damage to a random enemy. 30% chance to be destroyed on activation.";
            fastClock.sprite = ResourceLoader.LoadSprite("FastClock", 32);
            fastClock.trigger = TriggerCalls.Count;
            /*silence.triggerConditions = new EffectorConditionSO[1]
            {
                firball15P
            };*/
            fastClock.consumeTrigger = TriggerCalls.Count;
            fastClock.unlockableID = (UnlockableID)544515;
            fastClock.namePopup = true;
            fastClock.consumedOnUse = false;
            fastClock.itemPools = ItemPools.Treasure;
            fastClock.shopPrice = 5;
            fastClock.startsLocked = false;
            fastClock.immediate = false;
            fastClock.effects = new Effect[2]
            {
                new Effect(ScriptableObject.CreateInstance<ApplyMutedEffect>(), 1, (IntentType)846750, allEnemy),
                new Effect(ScriptableObject.CreateInstance<ApplyMutedEffect>(), 2, (IntentType)846750, Slots.SlotTarget(new int[8]{-4, -3, -2, -1, 1, 2, 3, 4 }, true))
            };
            ExtraPassiveAbility_Wearable_SMS thisPassiving = ScriptableObject.CreateInstance<ExtraPassiveAbility_Wearable_SMS>();
            thisPassiving._extraPassiveAbility = (BasePassiveAbilitySO)pauseKill;
            fastClock.equippedModifiers = new WearableStaticModifierSetterSO[1]
            {
                (WearableStaticModifierSetterSO)thisPassiving
            };
            fastClock.Ach = new AchieveInfo((Achievement)544515, AchievementUnlockType.Comedies, "Fast Clock", "Clear 544515.", ResourceLoader.LoadSprite("ClockAch.png", 32), true, "Unlocked a new item.");

            fastClock.Prepare();

            UnlockItem starFrag = new UnlockItem();
            starFrag.name = "Fragment of a Star";
            starFrag.flavorText = "\"*It's a little bit blue.*\"";
            starFrag.description = "Apply Ascetic to this party member on combat start.";
            starFrag.sprite = ResourceLoader.LoadSprite("StarPiece", 32);
            starFrag.trigger = TriggerCalls.OnCombatStart;
            /*starFrag.triggerConditions = new EffectorConditionSO[1]
            {
                firball15P
            };*/
            starFrag.consumeTrigger = TriggerCalls.Count;
            starFrag.unlockableID = (UnlockableID)544514;
            starFrag.namePopup = true;
            starFrag.consumedOnUse = false;
            starFrag.itemPools = ItemPools.Treasure;
            starFrag.shopPrice = 5;
            starFrag.startsLocked = false;
            starFrag.immediate = false;
            starFrag.effects = new Effect[1]
            {
                new Effect(ScriptableObject.CreateInstance<ApplyAsceticEffect>(), 1, (IntentType)846741, Slots.Self),
            };

            starFrag.Ach = new AchieveInfo((Achievement)544514, AchievementUnlockType.Comedies, "Fragment of a Star", "Clear 544514.", ResourceLoader.LoadSprite("StarAch.png", 32), true, "Unlocked a new item.");
            starFrag.Prepare();

            LobItems[0] = silence;
            LobItems[1] = fastClock;
            LobItems[2] = starFrag;

            DoubleEffectUnlockItem snowglobe = new DoubleEffectUnlockItem();
            snowglobe.name = "Snow Globe of an Insane Asylum";
            snowglobe.flavorText = "\"Paranoid Schizophrenic Paranoid Schizophrenic Paranoid Schizophrenic Paranoid Schizophrenic Paranoid Schizophrenic Paranoid Schizophrenic Paranoid Schizophrenic\"";
            snowglobe.description = "At the start of each turn, apply 1 Stunned to this character and have them perform a random ability. \nOn death, attempt to consume 3 coins. If successful, prevent death, set this character's health to 1, and have them instantly flee.";
            snowglobe.sprite = ResourceLoader.LoadSprite("Globe", 32);
            snowglobe.trigger = TriggerCalls.OnTurnStart;
            /*snowglobe.triggerConditions = new EffectorConditionSO[1]
            {
                firball15P
            };*/
            snowglobe.consumeTrigger = TriggerCalls.Count;
            snowglobe.unlockableID = (UnlockableID)544513;
            snowglobe.firstPopUp = true;
            snowglobe.consumedOnUse = false;
            snowglobe.itemPools = ItemPools.Treasure;
            snowglobe.shopPrice = 5;
            snowglobe.startsLocked = false;
            snowglobe._firsteEffectImmediat = false;
            snowglobe.firstEffects = new Effect[2]
            {
                new Effect(ScriptableObject.CreateInstance<PerformRandomAbilityEffect>(), 1,  null, Slots.Self),
                new Effect(ScriptableObject.CreateInstance<ApplyStunnedEffect>(), 1,  null, Slots.Self),
            };
            snowglobe.SecondTrigger = new TriggerCalls[1] { TriggerCalls.CanDie };
            snowglobe.secondTriggerConditions = new EffectorConditionSO[1]
            {
                ScriptableObject.CreateInstance<CustomCheckPlayerCurrencyPreventDeathEffectorCondition>()
            };
            snowglobe.secondEffects = new Effect[2]
            {
                new Effect(ScriptableObject.CreateInstance<SetHealthEffect>(), 1, null, Slots.Self),
                new Effect(ScriptableObject.CreateInstance<FleeTargetEffect>(), 1, null, Slots.Self)
            };
            snowglobe._secondImmediateEffect = true;
            snowglobe.Ach = new AchieveInfo((Achievement)544513, AchievementUnlockType.Comedies, "Snow Globe of an Insane Asylum", "Clear 544513.", ResourceLoader.LoadSprite("SchizoAch.png", 32), true, "Unlocked a new item.");
            snowglobe.Prepare();

            SnowGlobe = snowglobe;
        }
    }
    public class RemoveBloodBulletAndTrueBulletEffect : EffectSO
    {
        [SerializeField]
        public bool _justOneTarget;
        [SerializeField]
        public bool _randomBetweenPrevious;

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

            if (caster is CharacterCombat character)
            {
                foreach (ExtraAbilityInfo ability in character.ExtraAbilities)
                {
                    //Debug.Log("ability found");
                    if (ability.ability._abilityName == "Blood Bullet")
                    {
                        //Debug.Log("is slap");
                        character.TryRemoveExtraAbility(ability);
                        //Debug.Log("removed");
                        break;
                    }
                    else if (ability.ability._abilityName == "True Bullet")
                    {
                        //Debug.Log("is slap");
                        character.TryRemoveExtraAbility(ability);
                        //Debug.Log("removed");
                        break;
                    }
                }
            }
            return exitAmount > 0;
        }
    }
    public class DoubleEffectItem : Item
    {
        public Effect[] firstEffects = new Effect[0];
        public Effect[] secondEffects = new Effect[0];
        public bool _firsteEffectImmediat = false;
        public bool _secondImmediateEffect = false;
        public TriggerCalls[] SecondTrigger = new TriggerCalls[0];
        public TriggerCalls[] FirstTrigger = new TriggerCalls[0];
        public bool firstPopUp = true;
        public bool secondPopUp = true;
        public EffectorConditionSO[] secondTriggerConditions = new EffectorConditionSO[0];

        public override BaseWearableSO Wearable()
        {
            CustomDoublePerformEffectWearable instance = ScriptableObject.CreateInstance<CustomDoublePerformEffectWearable>();
            instance.BaseWearable((Item)this);
            instance._firstEffects = ExtensionMethods.ToEffectInfoArray(this.firstEffects);
            instance._firstImmediateEffect = this._firsteEffectImmediat;
            instance.triggerOn = this.trigger;
            instance.doesItemPopUp = this.firstPopUp;
            instance._secondEffects = ExtensionMethods.ToEffectInfoArray(this.secondEffects);
            instance._secondImmediateEffect = this._firsteEffectImmediat;
            instance._secondPerformTriggersOn = this.SecondTrigger;
            instance._secondDoesPerformItemPopUp = this.secondPopUp;
            instance._secondPerformConditions = this.secondTriggerConditions;
            return (BaseWearableSO)instance;
        }
    }
    public class FastClockPassiveAbility : BasePassiveAbilitySO
    {
        public override bool IsPassiveImmediate => true;

        public override bool DoesPassiveTrigger => true;

        public override void TriggerPassive(object sender, object args)
        {

        }
        public override void OnPassiveConnected(IUnit unit)
        {
            CombatManager.Instance.AddObserver(OnPauseTriggered, Tools.Utils.pauseTriggerNtf.ToString());
            
            PauseUIHandler handler = GameObject.FindObjectOfType<PauseUIHandler>(true);
            Transform buttonsZone = handler.transform.GetChild(1).GetChild(1).GetChild(0);
            Transform mainMenuTransform = buttonsZone.GetChild(3);
            Transform exitGameTransform = buttonsZone.GetChild(4);
            Button mainMenuButton = mainMenuTransform.GetComponent<Button>();
            Button exitGameButton = exitGameTransform.GetComponent<Button>();
            //mainMenuButton.onClick.AddListener(delegate () { killThreads(); });
            //exitGameButton.onClick.AddListener(delegate () { killThreads(); });
            

        }
        public void OnPauseTriggered(object sender, object args)
        {
            //Debug.Log("yeet");
            BooleanReference reference = args as BooleanReference;
            if (reference == null)
                return;
            //Here you add any check you want, reference.value contains if the game is paused (true) or not (false)
            //Debug.Log("yote");
            if (reference.value == true)
            {
                //Debug.Log("yite");
                if (UnityEngine.Random.Range(0, 100) < 40)
                {
                    Targetting_ByUnit_Side allEnemy = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
                    allEnemy.getAllies = false;
                    allEnemy.getAllUnitSlots = false;
                    Targetting_ByUnit_Side allAlly = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
                    allAlly.getAllies = true;
                    allAlly.getAllUnitSlots = false;
                    Effect PaleIt = new Effect(ScriptableObject.CreateInstance<FastClockDamageRandomTargetEffect>(), 10, null, allEnemy);
                    Effect consumption = new Effect(ScriptableObject.CreateInstance<DestroyFastClockEffect>(), 1, null, allAlly, Conditions.Chance(30));
                    //CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction((sender as IPassiveEffector).ID, (sender as IPassiveEffector).IsUnitCharacter, GetPassiveLocData().text));
                    CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[2] { PaleIt, consumption }), CombatManager.Instance._stats.CharactersOnField.First().Value));
                    //Debug.Log("yrute");
                }
            }
        }
        public override void OnPassiveDisconnected(IUnit unit)
        {
            CombatManager.Instance.RemoveObserver(OnPauseTriggered, Tools.Utils.pauseTriggerNtf.ToString());
        }
    }
    public class FastClockDamageRandomTargetEffect : EffectSO
    {
        [SerializeField]
        public bool _usePreviousExitValue;
        [SerializeField]
        public bool _ignoreShield;
        [SerializeField]
        public bool _indirect;
        public int _scars;

        public override bool PerformEffect(
          CombatStats stats,
          IUnit caster,
          TargetSlotInfo[] targets,
          bool areTargetSlots,
          int entryVariable,
          out int exitAmount)
        {
            if (this._usePreviousExitValue)
                entryVariable *= this.PreviousExitValue;
            exitAmount = 0;
            List<TargetSlotInfo> targetSlotInfoList = new List<TargetSlotInfo>();
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                    targetSlotInfoList.Add(target);
            }
            if (targetSlotInfoList.Count <= 0)
                return false;
            int index = UnityEngine.Random.Range(0, targetSlotInfoList.Count);
            TargetSlotInfo targetSlotInfo = targetSlotInfoList[index];

            if (targetSlotInfo.HasUnit)
            {
                targetSlotInfo.Unit.Damage(10, null, DeathType.Basic, -1, false, false, true, (DamageType)888666);
                exitAmount += 10;
            }

            /*
            Effect PaleIt = new Effect(ScriptableObject.CreateInstance<ApplyPaleEffect>(), 25, null, Slots.Self);
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { PaleIt }), targetSlotInfo.Unit));
            */

            return exitAmount > 0;
        }
    }
    public class DestroyFastClockEffect : EffectSO
    {
        [SerializeField]
        public bool _usePreviousExitValue;
        [SerializeField]
        public bool _ignoreShield;
        [SerializeField]
        public bool _indirect;
        public int _scars;

        public override bool PerformEffect(
          CombatStats stats,
          IUnit caster,
          TargetSlotInfo[] targets,
          bool areTargetSlots,
          int entryVariable,
          out int exitAmount)
        {
            if (this._usePreviousExitValue)
                entryVariable *= this.PreviousExitValue;
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit && target.Unit.ContainsPassiveAbility((PassiveAbilityTypes)987883) && target.Unit.HasUsableItem)
                {
                    target.Unit.TryConsumeWearable();
                    target.Unit.TryRemovePassiveAbility((PassiveAbilityTypes)987883);
                    exitAmount++;
                    return true;
                }
            }

            return exitAmount > 0;
        }
    }
    public class CustomCheckPlayerCurrencyPreventDeathEffectorCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (CombatManager.Instance._stats.PlayerCurrency >= 3)
            {
                CombatManager.Instance._stats.PlayerCurrency -= 3;
                (args as BooleanReference).value = false;
                return true;
            }
            return false;
        }
    }
    public class SetHealthEffect : EffectSO
    {


        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (targetSlotInfo.HasUnit && targetSlotInfo.Unit.IsAlive)
                {
                    int healthTo = entryVariable;
                    if (targetSlotInfo.Unit.SetHealthTo(healthTo))
                    {
                        exitAmount++;
                    }
                }
            }

            return exitAmount > 0;
        }
    }
    public class AddCasterExtraAbilityEffect : EffectSO
    {
        [SerializeField]
        public Ability thisAbility;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (caster is CharacterCombat character) 
            {
                ExtraAbilityInfo bulletAbil = new ExtraAbilityInfo();
                bulletAbil.ability = thisAbility.CharacterAbility().ability;
                bulletAbil.cost = thisAbility.cost;
                character.AddExtraAbility(bulletAbil);
            }
            return exitAmount > 0;
        }
    }
}
