﻿using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Hawthorne
{
    public static class Deep
    {
        public static string ID = "Deep";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "The Deep",
                health = 300,
                size = 3,
                entityID = (EntityIDs)entity,
                healthColor = Pigments.Red,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/group4/" + ID + "/" + ID + "_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
            };
            enemy.prefab._gibs = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/group4/" + ID + "/" + ID + "_Gibs.prefab").GetComponent<ParticleSystem>();
            enemy.prefab.SetDefaultParams();
            enemy.combatSprite = ResourceLoader.LoadSprite(ID + "Icon.png", 32);
            enemy.overworldAliveSprite = ResourceLoader.LoadSprite(ID + "World.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.overworldDeadSprite = ResourceLoader.LoadSprite(ID + "Dead.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.hurtSound = LoadedAssetsHandler.GetEnemy("Flarb_EN").damageSound;
            enemy.deathSound = LoadedAssetsHandler.GetEnemy("Flarb_EN").deathSound;
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passi.SalinitySV, Passi.Asphyxiation, Passi.Pressure
            };
            enemy.abilities = new Ability[] { Abili.Descent, Abili.Presence, Abili.BloodAttract, Abili.Abyss };
            enemy.unitType = UnitType.Fish;
            enemy.loot = new EnemyLootItemProbability[]
            {
                new EnemyLootItemProbability() { isItemTreasure = false, amount = 3, probability = 100 }
            };
            UnlockShitEffect unlock = ScriptableObject.CreateInstance<UnlockShitEffect>();
            unlock.AddThis(LootFour.Water);
            enemy.exitEffects = new Effect[1]
            {
                new Effect((EffectSO) unlock, 0, new IntentType?(), Slots.Self)
            };
            enemy.AddEnemy();
        }
    }
}
