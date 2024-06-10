using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Hawthorne
{
    public static class BlueFlower
    {
        public static string ID = "BlueFlower";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "Glowing Flower",
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
            enemy.overworldAliveSprite = ResourceLoader.LoadSprite(ID + "World.png", 32, new Vector2?(new Vector2(0.5f, 0f)));
            enemy.overworldDeadSprite = ResourceLoader.LoadSprite(ID + "Dead.png", 32, new Vector2?(new Vector2(0.5f, 0f)));
            enemy.hurtSound = LoadedAssetsHandler.GetEnemy("Mung_EN").damageSound;
            enemy.deathSound = LoadedAssetsHandler.GetEnemy("Mung_EN").deathSound;
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_PigmentFlower>();
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passives.Pure, Passi.Splatter, Passi.Overgrowth
            };
            enemy.abilities = new Ability[] { Abili.Aroma, Abili.Photosynthesize, Abili.Cry4U };
            enemy.enemyID = "BlueFlower_EN";
            enemy.AddEnemy();
        }
    }
    public static class RedFlower
    {
        public static string ID = "RedFlower";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "Bloody Flower",
                health = 32,
                size = 1,
                entityID = (EntityIDs)entity,
                healthColor = Pigments.Red,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/group4/" + ID + "/" + ID + "_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
                //prefab = LoadedAssetsHandler.GetEnemy("JumbleGuts_Clotted_EN").enemyTemplate
            };
            enemy.prefab._gibs = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/group4/" + ID + "/" + ID + "_Gibs.prefab").GetComponent<ParticleSystem>();
            enemy.prefab.SetDefaultParams();
            enemy.combatSprite = ResourceLoader.LoadSprite(ID + "Icon.png", 32);
            enemy.overworldAliveSprite = ResourceLoader.LoadSprite(ID + "World.png", 32, new Vector2?(new Vector2(0.5f, 0f)));
            enemy.overworldDeadSprite = ResourceLoader.LoadSprite(ID + "Dead.png", 32, new Vector2?(new Vector2(0.5f, 0f)));
            enemy.hurtSound = LoadedAssetsHandler.GetEnemy("GigglingMinister_EN").damageSound;
            enemy.deathSound = LoadedAssetsHandler.GetEnemy("GigglingMinister_EN").deathSound;
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_PigmentFlower>();
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passives.Pure, Passi.Splatter, Passi.Overgrowth
            };
            enemy.abilities = new Ability[] { Abili.Aroma, Abili.Photosynthesize, Abili.Love4U };
            enemy.enemyID = "RedFlower_EN";
            enemy.AddEnemy();
        }
    }
    public static class PurpleFlower
    {
        public static string ID = "PurpleFlower";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "Rotten Flower",
                health = 24,
                size = 1,
                entityID = (EntityIDs)entity,
                healthColor = Pigments.Purple,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/group4/" + ID + "/" + ID + "_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
            };
            enemy.prefab._gibs = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/group4/" + ID + "/" + ID + "_Gibs.prefab").GetComponent<ParticleSystem>();
            enemy.prefab.SetDefaultParams();
            enemy.combatSprite = ResourceLoader.LoadSprite(ID + "Icon.png", 32);
            enemy.overworldAliveSprite = ResourceLoader.LoadSprite(ID + "World.png", 32, new Vector2?(new Vector2(0.5f, 0f)));
            enemy.overworldDeadSprite = ResourceLoader.LoadSprite(ID + "Dead.png", 32, new Vector2?(new Vector2(0.5f, 0f)));
            enemy.hurtSound = LoadedAssetsHandler.GetEnemy("TaintedYolk_EN").damageSound;
            enemy.deathSound = LoadedAssetsHandler.GetEnemy("TaintedYolk_EN").deathSound;
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_PigmentFlower>();
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passives.Pure, Passi.Splatter, Passi.Overgrowth
            };
            enemy.abilities = new Ability[] { Abili.Aroma, Abili.Photosynthesize, Abili.Lie4U };
            enemy.enemyID = "PurpleFlower_EN";
            enemy.AddEnemy();
        }
    }
    public static class YellowFlower
    {
        public static string ID = "YellowFlower";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "Sunny Flower",
                health = 24,
                size = 1,
                entityID = (EntityIDs)entity,
                healthColor = Pigments.Yellow,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/group4/" + ID + "/" + ID + "_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
                //prefab = LoadedAssetsHandler.GetEnemy("JumbleGuts_Waning_EN").enemyTemplate
            };
            enemy.prefab._gibs = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/group4/" + ID + "/" + ID + "_Gibs.prefab").GetComponent<ParticleSystem>();
            enemy.prefab.SetDefaultParams();
            enemy.combatSprite = ResourceLoader.LoadSprite(ID + "Icon.png", 32);
            enemy.overworldAliveSprite = ResourceLoader.LoadSprite(ID + "World.png", 32, new Vector2?(new Vector2(0.5f, 0f)));
            enemy.overworldDeadSprite = ResourceLoader.LoadSprite(ID + "Dead.png", 32, new Vector2?(new Vector2(0.5f, 0f)));
            enemy.hurtSound = LoadedAssetsHandler.GetEnemy("Spoggle_Resonant_EN").damageSound;
            enemy.deathSound = LoadedAssetsHandler.GetEnemy("Spoggle_Resonant_EN").deathSound;
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_PigmentFlower>();
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passives.Pure, Passi.Splatter, Passi.Overgrowth
            };
            enemy.abilities = new Ability[] { Abili.Aroma, Abili.Photosynthesize, Abili.Smile4U };
            enemy.enemyID = "YellowFlower_EN";
            enemy.AddEnemy();
        }
    }
    public static class GreyFlower
    {
        public static string ID = "GreyFlower";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "Ghastly Flower",
                health = 40,
                size = 1,
                entityID = (EntityIDs)entity,
                healthColor = Pigments.Gray,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/group4/" + ID + "/" + ID + "_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
                //prefab = LoadedAssetsHandler.GetEnemy("SilverSuckle_EN").enemyTemplate
            };
            enemy.prefab._gibs = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/group4/" + ID + "/" + ID + "_Gibs.prefab").GetComponent<ParticleSystem>();
            enemy.prefab.SetDefaultParams();
            enemy.combatSprite = ResourceLoader.LoadSprite(ID + "Icon.png", 32);
            enemy.overworldAliveSprite = ResourceLoader.LoadSprite(ID + "World.png", 32, new Vector2?(new Vector2(0.5f, 0f)));
            enemy.overworldDeadSprite = ResourceLoader.LoadSprite(ID + "Dead.png", 32, new Vector2?(new Vector2(0.5f, 0f)));
            enemy.hurtSound = LoadedAssetsHandler.GetEnemy("JumbleGuts_Hollowing_EN").damageSound;
            enemy.deathSound = LoadedAssetsHandler.GetEnemy("JumbleGuts_Hollowing_EN").deathSound;
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_PigmentFlower>();
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passives.Pure, Passi.Splatter, Passi.Overgrowth
            };
            enemy.abilities = new Ability[] { Abili.Aroma, Abili.Photosynthesize, Abili.Die4U };
            enemy.enemyID = "GreyFlower_EN";
            enemy.AddEnemy();
        }
    }
}
