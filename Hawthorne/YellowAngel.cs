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
            enemy.hurtSound = "event:/Hawthorne/Noisy/YA_Hit";
            enemy.deathSound = "event:/Hawthorne/Noisy/YA_Death";
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
            enemy.hurtSound = "event:/Hawthorne/Noisy/Eye_Hit";
            enemy.deathSound = "event:/Hawthorne/Noisy/Eye_Die";
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
            enemy.hurtSound = "event:/Hawthorne/Noisy/UFO_Hit";
            enemy.deathSound = "event:/Hawthorne/Noisy/UFO_Death";
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
    public static class Personal
    {
        public static string ID = "Personal";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "Personal Angel",
                health = 42,
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
            enemy.hurtSound = "event:/Hawthorne/Noisy/PA_Hit";
            enemy.deathSound = "event:/Hawthorne/Noisy/PA_Die";
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            enemy.enemyID = "PersonalAngel_EN";
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passi.Slippery2, Passi.Punisher, Passi.Judgement
            };
            enemy.abilities = new Ability[] { Bbili.GatesHeaven, Bbili.CirclesHell };
            enemy.AddEnemy();
        }
    }
    public static class Sinker
    {
        public static string ID = "Sinker";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "Sinker",
                health = 18,
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
            enemy.hurtSound = LoadedAssetsHandler.GetCharcater("Clive_CH").damageSound;
            enemy.deathSound = LoadedAssetsHandler.GetCharcater("Clive_CH").deathSound;
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            enemy.enemyID = "Sinker_EN";
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passi.Lonely, Passives.Dying
            };
            enemy.abilities = new Ability[] { Bbili.Nailing, Bbili.Gulp, Bbili.Alarm };
            enemy.AddEnemy();
        }
    }
    public static class Complimentary
    {
        public static string ID = "Complimentary";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "Complimentary",
                health = 60,
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
            enemy.hurtSound = LoadedAssetsHandler.GetCharcater("Hans_CH").damageSound;
            enemy.deathSound = LoadedAssetsHandler.GetCharcater("Hans_CH").deathSound;
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            //enemy.enemyID = "Sinker_EN";
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passi.Divisible, Passives.Skittish
            };
            enemy.abilities = new Ability[] { Abili.Chomp, Bbili.Temper, Abili.Skitter };
            enemy.AddEnemy();
        }
    }
    public static class Shooter
    {
        public static string ID = "Shooter";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "Skeleton Shooter",
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
            enemy.hurtSound = "event:/Hawthorne/Noisy/Bone_Hit";
            enemy.deathSound = "event:/Hawthorne/Noisy/Bone_Death";
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            //enemy.enemyID = "Sinker_EN";
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passi.Sniper
            };
            enemy.abilities = new Ability[] { Bbili.Coward, Bbili.Opportunist, Bbili.Bash };
            enemy.AddEnemy();
        }
    }
    public static class Head
    {
        public static string ID = "Head";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "Skeleton Head",
                health = 20,
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
            enemy.hurtSound = "event:/Hawthorne/Noisy/Bone_Hit";
            enemy.deathSound = "event:/Hawthorne/Noisy/Bone_Death";
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            //enemy.enemyID = "Sinker_EN";
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passives.Forgetful, Passives.Enfeebled
            };
            enemy.abilities = new Ability[] { Bbili.Obliterate, Bbili.Wobble };
            enemy.AddEnemy();
        }
    }
}
