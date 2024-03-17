using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Hawthorne
{
    public static class Tripod
    {
        public static string ID = "Tripod";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "Ipnopidae",
                health = 32,
                size = 1,
                entityID = (EntityIDs)entity,
                healthColor = Pigments.Blue,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/group4/" + ID + "/" + ID + "_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
            };
            enemy.prefab._gibs = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/group4/" + ID + "/" + ID + "_Gibs.prefab").GetComponent<ParticleSystem>();
            enemy.prefab.SetDefaultParams();
            enemy.combatSprite = ResourceLoader.LoadSprite(ID + "Icon.png", 32);
            enemy.overworldAliveSprite = ResourceLoader.LoadSprite(ID + "World.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.overworldDeadSprite = ResourceLoader.LoadSprite(ID + "Dead.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.hurtSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").damageSound;
            enemy.deathSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").deathSound;
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_Tripod>();
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passi.Unmasking
            };
            enemy.abilities = new Ability[] { Abili.LongSlice, Abili.FoggyLens, Abili.ShortStomp };
            enemy.enemyID = "TripodFish_EN";
            enemy.unitType = UnitType.Fish;
            enemy.AddEnemy();
        }
    }
    public static class Rabies
    {
        public static string ID = "Rabies";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "Lyssarabhas",
                health = 18,
                size = 1,
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
            enemy.hurtSound = LoadedAssetsHandler.GetCharcater("Pearl_CH").damageSound;
            enemy.deathSound = LoadedAssetsHandler.GetCharcater("Pearl_CH").deathSound;
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passi.DoubleSkit, Passi.DoubleSlip, Passi.Multiattack(2),
            };
            enemy.abilities = new Ability[] { Abili.Chomp };
            enemy.enemyID = "Lyssa_EN";
            enemy.AddEnemy();
        }
    }
    public static class Glass
    {
        public static string ID = "Glass";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "Glass Figurine",
                health = 17,
                size = 1,
                entityID = (EntityIDs)entity,
                healthColor = Pigments.Gray,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/group4/" + ID + "/" + ID + "_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
            };
            enemy.prefab._gibs = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/group4/" + ID + "/" + ID + "_Gibs.prefab").GetComponent<ParticleSystem>();
            enemy.prefab.SetDefaultParams();
            enemy.combatSprite = ResourceLoader.LoadSprite(ID + "Icon.png", 32);
            enemy.overworldAliveSprite = ResourceLoader.LoadSprite(ID + "World.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.overworldDeadSprite = ResourceLoader.LoadSprite(ID + "Dead.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.hurtSound = LoadedAssetsHandler.GetEnemy("JumbleGuts_Hollowing_EN").damageSound;
            enemy.deathSound = LoadedAssetsHandler.GetEnemy("JumbleGuts_Hollowing_EN").deathSound;
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passives.Confusion, Passives.Forgetful
            };
            enemy.abilities = new Ability[] { Abili.PsychoDreams, Abili.GlassWaves, Abili.WoodChips, Abili.PainStar };
            enemy.unitType = UnitType.Fish;
            enemy.AddEnemy();
            LoadedAssetsHandler.GetEnemy("GlassFigurine_EN").enemyTemplate.SetGlassParams();
        }
    }
}
