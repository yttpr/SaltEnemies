using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using UnityEngine;
using BrutalAPI;

namespace Hawthorne
{
    public static class NPCModHook
    {
        //public static void Setup() => SaltEnemies.PCall(Set);
        public static UnlockItem Item;
        public static void Setup()
        {
            IDetour hook = new Hook(typeof(Cat_sCradle.SavePerRun).GetMethod(nameof(Cat_sCradle.SavePerRun.Set), ~BindingFlags.Default), typeof(NPCModHook).GetMethod(nameof(Set), ~BindingFlags.Default));
            UnlockItem effectItem = new UnlockItem();
            effectItem.name = "Abandoned Artifact";
            effectItem.flavorText = "\"give AbandonedArtifact_TW\"";
            effectItem.description = "Adds the extra ability \"Reconfigure,\" an unpredictable transformation.";
            effectItem.sprite = ResourceLoader.LoadSprite("AbandonedArtifact.png", 32);
            effectItem.trigger = TriggerCalls.Count;
            effectItem.namePopup = true;
            effectItem.consumedOnUse = false;
            effectItem.itemPools = ItemPools.Treasure;
            effectItem.shopPrice = 3;
            effectItem.startsLocked = false;
            effectItem.immediate = false;
            effectItem.effects = new Effect[0];
            effectItem.unlockableID = (UnlockableID)547283;
            Ability awaken = new Ability();
            awaken.name = "Reconfigure";
            awaken.description = "Transform into a random party member of the same level.";
            awaken.cost = new ManaColorSO[] { Pigments.Purple };
            awaken.effects = new Effect[1];
            awaken.effects[0] = new Effect(ScriptableObject.CreateInstance<AbandonedArtifactEffect>(), 1, IntentType.Misc_Hidden, Slots.Self);
            awaken.visuals = null;
            awaken.animationTarget = Slots.Self;
            ExtraAbility_Wearable_SMS extra = ScriptableObject.CreateInstance<ExtraAbility_Wearable_SMS>();
            extra._extraAbility = awaken.CharacterAbility();
            effectItem.equippedModifiers = new WearableStaticModifierSetterSO[] { extra };
            effectItem.Ach = new AchievementSystem.AchieveInfo((Achievement)547283, AchievementUnlockType.Strangers, "Helpme", "Find Help.", ResourceLoader.LoadSprite("ItsMe.png", 32), true, "...");
            effectItem.Prepare();
            Item = effectItem;
        }
        public static void Set(Action<string, bool> orig, string name, bool value)
        {
            orig(name, value);
            if (name == "Help" && value == true) Do();
            else Debug.Log("not this one");
        }
        public static void Do()
        {
            Debug.Log("this one");
            Item?.GetItem();
        }
    }
}
