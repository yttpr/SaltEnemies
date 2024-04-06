using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Hawthorne
{
    public static class ClockTower
    {
        public static string ID = "ClockTower";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "The End of Time",
                health = 44,
                size = 1,
                entityID = (EntityIDs)entity,
                healthColor = Pigments.Gray,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/group4/" + ID + "/" + ID + "_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
            };
            enemy.prefab._gibs = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/group4/" + ID + "/" + ID + "_Gibs.prefab").GetComponent<ParticleSystem>();
            enemy.prefab.SetDefaultParams();
            enemy.enemyID = "ClockTower_EN";
            enemy.combatSprite = ResourceLoader.LoadSprite(ID + "Icon.png", 32);
            enemy.overworldAliveSprite = ResourceLoader.LoadSprite(ID + "World.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.overworldDeadSprite = ResourceLoader.LoadSprite(ID + "Dead.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.hurtSound = LoadedAssetsHandler.GetCharcater("Gospel_CH").damageSound;
            enemy.deathSound = LoadedAssetsHandler.GetCharcater("Gospel_CH").deathSound;
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ClockTower>();
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passi.Overexert(12), Passi.Acceleration
            };
            enemy.abilities = new Ability[] { Abili.Cripple, Abili.Crucify, Abili.Cracking };
            enemy.exitEffects = new Effect[]
            {
                new Effect(ScriptableObject.CreateInstance<ClockTowerExitEffect>(), 1, null, Slots.Self)
            };
            enemy.AddEnemy();
        }
    }
    public static class Boat
    {
        public static string ID = "Boat";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "Arceles",
                health = 6,
                size = 1,
                entityID = (EntityIDs)entity,
                healthColor = Pigments.Gray,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/train/" + ID + "_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
            };
            enemy.prefab._gibs = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/train/" + ID + "_Gibs.prefab").GetComponent<ParticleSystem>();
            enemy.prefab.SetDefaultParams();
            enemy.combatSprite = ResourceLoader.LoadSprite(ID + "Icon.png", 32);
            enemy.overworldAliveSprite = ResourceLoader.LoadSprite(ID + "World.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.overworldDeadSprite = ResourceLoader.LoadSprite(ID + "Dead.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.hurtSound = LoadedAssetsHandler.GetEnemy("Merced_EN").deathSound;
            enemy.deathSound = LoadedAssetsHandler.GetCharcater("Gospel_CH").deathSound;
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passi.Knock
            };
            enemy.abilities = new Ability[] { Bbili.Windy, Bbili.Drift, Bbili.Rush };
            enemy.AddEnemy();
        }
    }
    public static class Train
    {
        public static string ID = "Train";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "Midnight Traffic Light",
                health = 50,
                size = 1,
                entityID = (EntityIDs)entity,
                healthColor = Pigments.Red,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/train/" + ID + "_Enemy.prefab").AddComponent<MultiSpriteEnemyLayout>()
            };
            enemy.prefab._gibs = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/train/" + ID + "_Gibs.prefab").GetComponent<ParticleSystem>();
            enemy.prefab.SetDefaultParams();
            (enemy.prefab as MultiSpriteEnemyLayout).OtherRenderers = new SpriteRenderer[]
            {
                enemy.prefab._locator.transform.Find("Sprite").Find("Sprite").GetComponent<SpriteRenderer>(),
            };
            enemy.enemyID = "Stoplight_EN";
            enemy.combatSprite = ResourceLoader.LoadSprite(ID + "Icon.png", 32);
            enemy.overworldAliveSprite = ResourceLoader.LoadSprite(ID + "World.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.overworldDeadSprite = ResourceLoader.LoadSprite(ID + "Dead.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.deathSound = LoadedAssetsHandler.GetEnemy("ChoirBoy_EN").damageSound;
            enemy.hurtSound = LoadedAssetsHandler.GetCharcater("Gospel_CH").damageSound;
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passi.Practical, Passives.Inanimate, Passi.Trolley
            };
            enemy.abilities = new Ability[] { Bbili.Check, Bbili.Back };
            enemy.AddEnemy();
        }
    }
}
