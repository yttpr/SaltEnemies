using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Hawthorne
{
    public static class Pinano
    {
        public static string ID = "Pinano";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "Pinano",
                health = 12,
                size = 1,
                entityID = (EntityIDs)entity,
                healthColor = Pigments.Red,
                priority = 0,
                prefab = SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/pinano/" + ID + "_Enemy.prefab").AddComponent<MultiSpriteEnemyLayout>()
            };
            enemy.prefab._gibs = SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/pinano/" + ID + "_Gibs.prefab").GetComponent<ParticleSystem>();
            enemy.prefab.SetDefaultParams();
            (enemy.prefab as MultiSpriteEnemyLayout).OtherRenderers = new SpriteRenderer[]
            {
                enemy.prefab._locator.transform.Find("Sprite").Find("Sprite (1)").GetComponent<SpriteRenderer>(),
                enemy.prefab._locator.transform.Find("Sprite").Find("Sprite (2)").GetComponent<SpriteRenderer>(),
            };
            enemy.combatSprite = ResourceLoader.LoadSprite(ID + "Icon.png", 32);
            enemy.overworldAliveSprite = ResourceLoader.LoadSprite(ID + "World.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.overworldDeadSprite = ResourceLoader.LoadSprite(ID + "Dead.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.hurtSound = LoadedAssetsHandler.GetEnemy("MudLung_EN").damageSound;
            enemy.deathSound = LoadedAssetsHandler.GetEnemy("MudLung_EN").deathSound;
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passives.Slippery, Passi.Violent(3), Passi.MiinoDecay
            };
            enemy.abilities = new Ability[] { Abili.Chomp, Abili.Burp, Abili.Flail };
            enemy.AddEnemy();
        }
    }
    public static class Spitato
    {
        public static string ID = "Spitato";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "Spitato",
                health = 24,
                size = 1,
                entityID = (EntityIDs)entity,
                healthColor = Pigments.Red,
                priority = 0,
                prefab = SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/pinano/" + ID + "_Enemy.prefab").AddComponent<MultiSpriteEnemyLayout>()
            };
            enemy.prefab._gibs = SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/pinano/" + ID + "_Gibs.prefab").GetComponent<ParticleSystem>();
            enemy.prefab.SetDefaultParams();
            (enemy.prefab as MultiSpriteEnemyLayout).OtherRenderers = new SpriteRenderer[]
            {
                enemy.prefab._locator.transform.Find("Sprite").Find("Sprite (1)").GetComponent<SpriteRenderer>(),
                enemy.prefab._locator.transform.Find("Sprite").Find("Sprite (2)").GetComponent<SpriteRenderer>(),
            };
            enemy.combatSprite = ResourceLoader.LoadSprite(ID + "Icon.png", 32);
            enemy.overworldAliveSprite = ResourceLoader.LoadSprite(ID + "World.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.overworldDeadSprite = ResourceLoader.LoadSprite(ID + "Dead.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.hurtSound = LoadedAssetsHandler.GetEnemy("MudLung_EN").damageSound;
            enemy.deathSound = LoadedAssetsHandler.GetEnemy("MudLung_EN").deathSound;
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passives.Slippery, Passi.Violent(5), Passives.TwoFaced, Passi.MiinoDecay
            };
            enemy.abilities = new Ability[] { Abili.Swallow, Abili.Lubricate, Abili.Suffocate };
            enemy.AddEnemy();
        }
    }
    public static class Minana
    {
        public static string ID = "Minana";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "Minana",
                health = 6,
                size = 1,
                entityID = (EntityIDs)entity,
                healthColor = Pigments.Blue,
                priority = 0,
                prefab = SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/pinano/" + ID + "_Enemy.prefab").AddComponent<MultiSpriteEnemyLayout>()
            };
            enemy.prefab._gibs = SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/pinano/" + ID + "_Gibs.prefab").GetComponent<ParticleSystem>();
            enemy.prefab.SetDefaultParams();
            (enemy.prefab as MultiSpriteEnemyLayout).OtherRenderers = new SpriteRenderer[]
            {
                enemy.prefab._locator.transform.Find("Sprite").Find("Sprite (1)").GetComponent<SpriteRenderer>(),
                enemy.prefab._locator.transform.Find("Sprite").Find("body").GetComponent<SpriteRenderer>(),
            };
            enemy.combatSprite = ResourceLoader.LoadSprite(ID + "Icon.png", 32);
            enemy.overworldAliveSprite = ResourceLoader.LoadSprite(ID + "World.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.overworldDeadSprite = ResourceLoader.LoadSprite(ID + "Dead.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.hurtSound = LoadedAssetsHandler.GetEnemy("Mung_EN").damageSound;
            enemy.deathSound = LoadedAssetsHandler.GetEnemy("Mung_EN").deathSound;
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passives.Slippery, Passi.Violent(1)
            };
            enemy.abilities = new Ability[] { Abili.Thrash, Abili.Burp };
            enemy.AddEnemy();
        }
    }
}
