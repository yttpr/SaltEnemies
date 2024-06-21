using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Hawthorne
{

    public static class YellowAngel
    {
        public static string ID = "YellowAngel";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "Yellow Angel",
                health = 42,
                size = 1,
                entityID = (EntityIDs)entity,
                healthColor = Pigments.Yellow,
                priority = 1,
                prefab = Hawthorne.SaltEnemies.Meow.LoadAsset<GameObject>("assets/enemie/" + ID + "_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
            };
            enemy.prefab._gibs = Hawthorne.SaltEnemies.Meow.LoadAsset<GameObject>("assets/giblets/" + ID + "_Gibs.prefab").GetComponent<ParticleSystem>();
            enemy.prefab.SetDefaultParams();
            ID = "Harpoon";
            enemy.combatSprite = ResourceLoader.LoadSprite(ID + "Icon.png", 32);
            enemy.overworldAliveSprite = ResourceLoader.LoadSprite(ID + "World.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.overworldDeadSprite = ResourceLoader.LoadSprite(ID + "Dead.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.hurtSound = LoadedAssetsHandler.GetEnemy("ChoirBoy_EN").damageSound;
            enemy.deathSound = LoadedAssetsHandler.GetEnemy("ChoirBoy_EN").deathSound;
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passi.Fluttery, Passi.Rupture
            };
            enemy.abilities = new Ability[] { Bbili.OnSight, Bbili.TrackPrints, Bbili.MarkThem };
            enemy.AddEnemy();
        }
    }
    public static class EvilDog
    {
        public static string ID = "EvilDog";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "Chien Tindalou",
                health = 30,
                size = 1,
                entityID = (EntityIDs)entity,
                healthColor = Pigments.Red,
                priority = 1,
                prefab = Hawthorne.SaltEnemies.Meow.LoadAsset<GameObject>("assets/enemie/" + ID + "_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
            };
            enemy.prefab._gibs = Hawthorne.SaltEnemies.Meow.LoadAsset<GameObject>("assets/giblets/" + ID + "_Gibs.prefab").GetComponent<ParticleSystem>();
            enemy.prefab.SetDefaultParams();
            enemy.combatSprite = ResourceLoader.LoadSprite(ID + "Icon.png", 32);
            enemy.overworldAliveSprite = ResourceLoader.LoadSprite(ID + "World.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.overworldDeadSprite = ResourceLoader.LoadSprite(ID + "Dead.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.hurtSound = LoadedAssetsHandler.GetCharcater("LongLiver_CH").damageSound;
            enemy.deathSound = LoadedAssetsHandler.GetCharcater("LongLiver_CH").deathSound;
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            enemy.enemyID = "EvilDog_EN";
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passives.TwoFaced, Passives.Skittish, Passi.Warping
            };
            enemy.abilities = new Ability[] { Bbili.RingingNoise, Bbili.Bash, Bbili.StingingPain };
            enemy.AddEnemy();
        }
    }
    public static class Eyeball
    {
        public static string ID = "Eyeball";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "Evileye",
                health = 30,
                size = 1,
                entityID = (EntityIDs)entity,
                healthColor = Pigments.Red,
                priority = 1,
                prefab = Hawthorne.SaltEnemies.Meow.LoadAsset<GameObject>("assets/enemie/" + ID + "_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
            };
            enemy.prefab._gibs = Hawthorne.SaltEnemies.Meow.LoadAsset<GameObject>("assets/giblets/" + ID + "_Gibs.prefab").GetComponent<ParticleSystem>();
            enemy.prefab.SetDefaultParams();
            enemy.combatSprite = ResourceLoader.LoadSprite(ID + "Icon.png", 32);
            enemy.overworldAliveSprite = ResourceLoader.LoadSprite(ID + "World.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.overworldDeadSprite = ResourceLoader.LoadSprite(ID + "Dead.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.hurtSound = LoadedAssetsHandler.GetEnemy("MusicMan_EN").damageSound;
            enemy.deathSound = LoadedAssetsHandler.GetEnemy("MusicMan_EN").deathSound;
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_EvilEye>();
            enemy.enemyID = "EvilEyeball_EN";
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passives.Leaky, Passi.Jumpy
            };
            enemy.abilities = new Ability[] { Bbili.EyeOne, Bbili.EyeTwo, Bbili.EyeThree, Bbili.EyeFour, Bbili.EyeFive };
            enemy.AddEnemy();
        }
    }
    public static class Grave
    {
        public static string ID = "Grave";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "Nobody's Grave",
                health = 20,
                size = 1,
                entityID = (EntityIDs)entity,
                healthColor = Pigments.Gray,
                priority = 1,
                prefab = Hawthorne.SaltEnemies.Meow.LoadAsset<GameObject>("assets/enemie/" + ID + "_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
            };
            enemy.prefab._gibs = Hawthorne.SaltEnemies.Meow.LoadAsset<GameObject>("assets/giblets/" + ID + "_Gibs.prefab").GetComponent<ParticleSystem>();
            enemy.prefab.SetDefaultParams();
            enemy.combatSprite = ResourceLoader.LoadSprite(ID + "Icon.png", 32);
            enemy.overworldAliveSprite = ResourceLoader.LoadSprite(ID + "World.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.overworldDeadSprite = ResourceLoader.LoadSprite(ID + "Dead.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.hurtSound = LoadedAssetsHandler.GetCharcater("Gospel_CH").damageSound;
            enemy.deathSound = LoadedAssetsHandler.GetCharcater("Gospel_CH").deathSound;
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            enemy.enemyID = "NobodyGrave_EN";
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passives.Inanimate, Passives.Withering, Passi.Desecration
            };
            enemy.abilities = new Ability[] { Bbili.Weathering, Bbili.Putrification, Bbili.BuriedUnder };
            enemy.AddEnemy();
        }
    }
    public static class Defender
    {
        public static string ID = "Defender";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "Defender",
                health = 16,
                size = 1,
                entityID = (EntityIDs)entity,
                healthColor = Pigments.Red,
                priority = 1,
                prefab = Hawthorne.SaltEnemies.Meow.LoadAsset<GameObject>("assets/enemie/" + ID + "_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
            };
            enemy.prefab._gibs = Hawthorne.SaltEnemies.Meow.LoadAsset<GameObject>("assets/giblets/" + ID + "_Gibs.prefab").GetComponent<ParticleSystem>();
            enemy.prefab.SetDefaultParams();
            enemy.combatSprite = ResourceLoader.LoadSprite(ID + "Icon.png", 32);
            enemy.overworldAliveSprite = ResourceLoader.LoadSprite(ID + "World.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.overworldDeadSprite = ResourceLoader.LoadSprite(ID + "Dead.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.hurtSound = LoadedAssetsHandler.GetCharcater("Gospel_CH").damageSound;
            enemy.deathSound = LoadedAssetsHandler.GetCharcater("Gospel_CH").deathSound;
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            enemy.enemyID = "Defender_EN";
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passives.Forgetful
            };
            enemy.abilities = new Ability[] { Bbili.FrontCannon, Bbili.FarCannon, Bbili.WheelingHigh, Bbili.Encampment, Bbili.GrandBlast };
            enemy.AddEnemy();
        }
    }
    public static class UFO
    {
        public static string ID = "UFO";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "Toy UFO",
                health = 13,
                size = 1,
                entityID = (EntityIDs)entity,
                healthColor = Pigments.Red,
                priority = 1,
                prefab = Hawthorne.SaltEnemies.Meow.LoadAsset<GameObject>("assets/enemie/" + ID + "_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
            };
            enemy.prefab._gibs = Hawthorne.SaltEnemies.Meow.LoadAsset<GameObject>("assets/giblets/" + ID + "_Gibs.prefab").GetComponent<ParticleSystem>();
            enemy.prefab.SetDefaultParams();
            enemy.combatSprite = ResourceLoader.LoadSprite(ID + "Icon.png", 32);
            enemy.overworldAliveSprite = ResourceLoader.LoadSprite(ID + "World.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.overworldDeadSprite = ResourceLoader.LoadSprite(ID + "Dead.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.hurtSound = LoadedAssetsHandler.GetEnemy("DeadPixel_EN").damageSound;
            enemy.deathSound = LoadedAssetsHandler.GetEnemy("DeadPixel_EN").deathSound;
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            enemy.enemyID = "ToyUfo_EN";
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passi.Jittery
            };
            enemy.abilities = new Ability[] { Bbili.Laser, Bbili.WheelingLow, Bbili.Trappings };
            enemy.AddEnemy();
        }
    }
}
