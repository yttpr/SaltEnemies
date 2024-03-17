using BrutalAPI;
using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace Hawthorne
{
    //imagine this is like your main class
    public static class Chocolate
    {
        public static bool priceDecreased = false;
        public static Dictionary<string, int> realPrices = new Dictionary<string, int>();
        public static void SetInformation(Action<ShopMenuUIHandler, int> orig, ShopMenuUIHandler self, int ShopID)
        {
            //Debug.Log("yay");
            foreach (ItemInGameData itemData in BrutalAPI.BrutalAPI.mainMenuController._informationHolder.Run.playerData._itemList)
            {
                //Debug.Log("b");
                if (itemData != (object)null)
                {
                    //Debug.Log("a item");
                    if (itemData.Item == LoadedAssetsHandler.GetWearable("ChocolateCoin_TW") && !priceDecreased)
                    {
                        //Debug.Log("c");
                        //Debug.Log("has");
                        realPrices.Clear();
                        foreach (RunZoneData zone in BrutalAPI.BrutalAPI.mainMenuController._informationHolder.Run.zoneData)
                        {
                            foreach (ShopContentData shopData in zone._zoneShopData)
                            {
                                //Debug.Log("a shop");
                                foreach (ShopItemData shopItem in shopData.shopItems)
                                {
                                    realPrices.Add(shopItem.item._itemName, shopItem.item.shopPrice);
                                    //Debug.Log("Orig: " + shopItem.item._itemName + ": " + shopItem.item.shopPrice);
                                    float newPrice = shopItem.item.shopPrice;
                                    newPrice *= 0.8f;
                                    int gap = (int)Math.Floor(newPrice);
                                    shopItem.item.shopPrice = gap;
                                    //Debug.Log("New: " + shopItem.item._itemName + ": " + shopItem.item.shopPrice);
                                }
                            }
                        }
                        priceDecreased = true;
                    }
                    
                }
            }
            orig(self, ShopID);
        }
        public static void HideMenu(Action<ShopMenuUIHandler> orig, ShopMenuUIHandler self)
        {
            orig(self);
            //Debug.Log("closed");
            if (priceDecreased)
            {
                foreach (RunZoneData zone in BrutalAPI.BrutalAPI.mainMenuController._informationHolder.Run.zoneData)
                {
                    foreach (ShopContentData shopData in zone._zoneShopData)
                    {
                        foreach (ShopItemData shopItem in shopData.shopItems)
                        {
                            if (realPrices.ContainsKey(shopItem.item._itemName))
                            {
                                shopItem.item.shopPrice = realPrices[shopItem.item._itemName];
                            }
                        }
                    }
                }
                priceDecreased = false;
                //Debug.Log("yep");
            }
        }
        public static void Hook()
        {
            IDetour shopOpenedIDetour = (IDetour)new Hook((MethodBase)typeof(ShopMenuUIHandler).GetMethod("SetInformation", ~BindingFlags.Default), typeof(Chocolate).GetMethod("SetInformation", ~BindingFlags.Default));
            IDetour shopClosedIDetour = (IDetour)new Hook((MethodBase)typeof(ShopMenuUIHandler).GetMethod("HideMenu", ~BindingFlags.Default), typeof(Chocolate).GetMethod("HideMenu", ~BindingFlags.Default));
        }
        public static bool added = false;
        public static void Add()
        {
            UnlockItem chocolate = new UnlockItem();
            chocolate.name = "Chocolate Coin";
            chocolate.flavorText = "\"Reduced value\"";
            chocolate.description = "While this item is in your inventory, decrease the price of all items in the shop by 20%.";
            chocolate.sprite = ResourceLoader.LoadSprite("ChocolateCoin", 32);
            chocolate.trigger = TriggerCalls.Count;
            chocolate.consumeTrigger = TriggerCalls.Count;
            chocolate.unlockableID = (UnlockableID)544512;
            chocolate.namePopup = true;
            chocolate.consumedOnUse = false;
            chocolate.itemPools = ItemPools.Treasure;
            chocolate.shopPrice = 5;
            chocolate.startsLocked = false;
            chocolate.immediate = false;
            chocolate.effects = new Effect[]
            {
                new Effect(ScriptableObject.CreateInstance<ExitValueSetterEffect>(), 1, null, Slots.Self)
            };
            chocolate.Ach = new AchievementSystem.AchieveInfo((Achievement)544512, AchievementUnlockType.Comedies, "Wealthy Surprise", "Hunt the Coin Hunter.", ResourceLoader.LoadSprite("CoinAch.png", 32), true, "Holding too many coins for too long might land you a nasty surprise.");
            chocolate.Prepare();
            Hook();
            added = true;
            Choco = chocolate;
        }

        public static Item Choco;
    }
    //to make a separate class you just add it below outside of the paranthesis
    public class Vanilla
    {
        public void lol()
        {
            Debug.Log("lmao");
        }
    }

    //resource loader would go like here
    public static class PretendResourceLoader
    {
        //the code that's inside Resource Loader would go here.
    }


}//<-- the important part is that it's all within the namespace, meaning above this bracket 
//if you do make a separate .cs file, make sure it's inside the same namespace.
//also, avoid putting a class inside another class, as it could cause errors
