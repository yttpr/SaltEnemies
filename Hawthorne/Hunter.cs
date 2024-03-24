using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Hawthorne
{
    public static class Hunter
    {
        public static string ID = "Hunter";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "Hunting Bird",
                health = 28,
                size = 1,
                entityID = (EntityIDs)entity,
                healthColor = Pigments.Purple,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/group4/" + ID + "/" + ID + "_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
            };
            enemy.prefab._gibs = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/group4/" + ID + "/" + ID + "_Gibs.prefab").GetComponent<ParticleSystem>();
            enemy.prefab.SetDefaultParams();
            enemy.combatSprite = ResourceLoader.LoadSprite(ID + "Icon.png", 32);
            enemy.overworldAliveSprite = ResourceLoader.LoadSprite(ID + "World.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.overworldDeadSprite = ResourceLoader.LoadSprite(ID + "Dead.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.hurtSound = "event:/Hawthorne/Hurt/HunterHurt";
            enemy.deathSound = "event:/Hawthorne/Die/HunterDie";
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_Hunter>();
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passi.Hunter, Passi.Rupture, Passives.Constricting, Passi.Fleeting(4)
            };
            enemy.abilities = new Ability[] { Abili.Nest, Abili.Patience, Abili.TrackDown };
            enemy.enemyID = "Hunter_EN";
            enemy.AddEnemy();
        }
    }
    public static class Firebird
    {
        public static string ID = "Firebird";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "The Phoenix",
                health = 35,
                size = 1,
                entityID = (EntityIDs)entity,
                healthColor = Pigments.Red,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/group4/" + ID + "/" + ID + "_Enemy.prefab").AddComponent<MultiSpriteEnemyLayout>()
            };
            enemy.prefab._gibs = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/group4/" + ID + "/" + ID + "_Gibs.prefab").GetComponent<ParticleSystem>();
            enemy.prefab.SetDefaultParams();
            (enemy.prefab as MultiSpriteEnemyLayout).OtherRenderers = new SpriteRenderer[]
            {
                enemy.prefab._locator.transform.Find("Sprite").Find("Sprite").GetComponent<SpriteRenderer>(),
                enemy.prefab._locator.transform.Find("Sprite").Find("Sprite").GetChild(0).GetComponent<SpriteRenderer>(),
                enemy.prefab._locator.transform.Find("Sprite").Find("Sprite").GetChild(1).GetComponent<SpriteRenderer>(),
                enemy.prefab._locator.transform.Find("Sprite").Find("Sprite").GetChild(2).GetComponent<SpriteRenderer>(),
                enemy.prefab._locator.transform.Find("Sprite").Find("Sprite").GetChild(3).GetComponent<SpriteRenderer>(),
                enemy.prefab._locator.transform.Find("Sprite").Find("Sprite").GetChild(4).GetComponent<SpriteRenderer>(),
            };
            enemy.combatSprite = ResourceLoader.LoadSprite(ID + "Icon.png", 32);
            enemy.overworldAliveSprite = ResourceLoader.LoadSprite(ID + "World.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.overworldDeadSprite = ResourceLoader.LoadSprite(ID + "Dead.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.hurtSound = LoadedAssetsHandler.GetEnemy("GigglingMinister_EN").damageSound;
            enemy.deathSound = LoadedAssetsHandler.GetEnemy("GigglingMinister_EN").deathSound;
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_Firebird>();
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passi.Rejuvination, Passi.Burning, Passi.Inferno(2), Passives.Skittish
            };
            enemy.abilities = new Ability[] { Abili.SingeClaws, Abili.FireVeins, Abili.FireDeath };
            enemy.enemyID = "Firebird_EN";
            enemy.AddEnemy();
        }
    }
    public static class Beak
    {
        public static string ID = "Beak";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "Little Beak",
                health = 16,
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
            enemy.hurtSound = LoadedAssetsHandler.GetEnemy("Keko_EN").damageSound;
            enemy.deathSound = LoadedAssetsHandler.GetEnemy("Keko_EN").deathSound;
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_Nervous>();
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passi.Nervous
            };
            enemy.abilities = new Ability[] { Abili.PointyBeak, Abili.Scry, Abili.Stare, Abili.LightScratch };
            //enemy.enemyID = "Firebird_EN";
            enemy.AddEnemy();
            LoadedAssetsHandler.GetEnemy("LittleBeak_EN").enemyTemplate.SetBeakParams();
        }
    }
    public static class Scarecrow
    {
        public static string ID = "Scarecrow";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "Warbird",
                health = 20,
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
            enemy.hurtSound = LoadedAssetsHandler.GetEnemy("RealisticTank_EN").damageSound;
            enemy.deathSound = LoadedAssetsHandler.GetEnemy("RealisticTank_EN").deathSound;
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passives.Formless, Passi.Repression
            };
            enemy.abilities = new Ability[] { Abili.Statue, Abili.HellScreech };
            //enemy.enemyID = "Firebird_EN";
            enemy.AddEnemy();
        }
    }
}
