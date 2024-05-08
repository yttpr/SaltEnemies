using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Hawthorne
{
    public static class Crystal
    {
        public static string ID = "Crystal";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "Crystaline Corpse Eater",
                enemyID = "Crystal_EN",
                health = 35,
                size = 1,
                entityID = (EntityIDs)entity,
                healthColor = Pigments.Blue,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/16/" + ID + "_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
            };
            enemy.prefab._gibs = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/16/" + ID + "_Gibs.prefab").GetComponent<ParticleSystem>();
            enemy.prefab.SetDefaultParams();
            enemy.combatSprite = ResourceLoader.LoadSprite(ID + "Icon.png", 32);
            enemy.overworldAliveSprite = ResourceLoader.LoadSprite(ID + "World.png", 32, new Vector2?(new Vector2(0.5f, 0f)));
            enemy.overworldDeadSprite = ResourceLoader.LoadSprite(ID + "Dead.png", 32, new Vector2?(new Vector2(0.5f, 0f)));
            enemy.hurtSound = "event:/Hawthorne/Noise/CrystalHit";
            enemy.deathSound = "event:/Hawthorne/Noise/CrystalDie";
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passi.SweetTooth, Passives.Skittish, Passives.Forgetful, Passi.CrystalDecay
            };
            enemy.abilities = new Ability[] { Bbili.Mar, Bbili.Torture, Bbili.Overbite, Bbili.Sugar };
            enemy.AddEnemy();
        }
    }
    public static class Stone
    {
        public static string ID = "Stone";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "Candy Stone",
                enemyID = "CandyStone_EN",
                health = 10,
                size = 1,
                entityID = (EntityIDs)entity,
                healthColor = Pigments.Blue,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/16/" + ID + "_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
            };
            enemy.prefab._gibs = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/16/" + ID + "_Gibs.prefab").GetComponent<ParticleSystem>();
            enemy.prefab.SetDefaultParams();
            enemy.combatSprite = ResourceLoader.LoadSprite(ID + "Icon.png", 32);
            enemy.overworldAliveSprite = ResourceLoader.LoadSprite(ID + "World.png", 32, new Vector2?(new Vector2(0.5f, 0f)));
            enemy.overworldDeadSprite = ResourceLoader.LoadSprite(ID + "Dead.png", 32, new Vector2?(new Vector2(0.5f, 0f)));
            enemy.hurtSound = "event:/Hawthorne/Noise/CrystalHit";
            enemy.deathSound = "event:/Hawthorne/Noise/CrystalDie";
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passives.Withering, Passives.Inanimate
            };
            enemy.abilities = new Ability[] { Bbili.Nibble };
            enemy.AddEnemy();
        }
    }
    public static class Dragon
    {
        public static string ID = "Dragon";
        public static ParticleSystem Green;
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "The Dragon",
                enemyID = "TheDragon_EN",
                health = 60,
                size = 2,
                entityID = (EntityIDs)entity,
                healthColor = Pigments.Red,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/16/" + ID + "_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
            };
            enemy.prefab._gibs = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/16/" + ID + "_Gibs.prefab").GetComponent<ParticleSystem>();
            Green = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/16/SecondGibsDragon.prefab").GetComponent<ParticleSystem>();
            enemy.prefab.SetDefaultParams();
            enemy.combatSprite = ResourceLoader.LoadSprite(ID + "Icon.png", 32);
            enemy.overworldAliveSprite = ResourceLoader.LoadSprite(ID + "World.png", 32, new Vector2?(new Vector2(0.5f, 0f)));
            enemy.overworldDeadSprite = ResourceLoader.LoadSprite(ID + "Dead.png", 32, new Vector2?(new Vector2(0.5f, 0f)));
            enemy.hurtSound = LoadedAssetsHandler.GetEnemy("Flarb_EN").damageSound;
            enemy.deathSound = LoadedAssetsHandler.GetEnemy("Flarb_EN").deathSound;
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_Dragon>();
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passi.Fleeting(6), Passi.DragonAsleep
            };
            enemy.abilities = new Ability[] { Bbili.Sneeze, Bbili.Snore, Bbili.Drool, Bbili.Snort };
            enemy.exitEffects = new Effect[]
            {
                new Effect(ScriptableObject.CreateInstance<DragonSongEffect>(), 1, null, Slots.Self),
            };
            enemy.AddEnemy();
        }
    }
    public static class Vase
    {
        public static string ID = "Vase";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "Ode to Humanity",
                enemyID = "OdetoHumanity_EN",
                health = 40,
                size = 1,
                entityID = (EntityIDs)entity,
                healthColor = Pigments.Red,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/16/" + ID + "_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
            };
            enemy.prefab._gibs = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/16/" + ID + "_Gibs.prefab").GetComponent<ParticleSystem>();
            enemy.prefab.SetDefaultParams();
            enemy.combatSprite = ResourceLoader.LoadSprite(ID + "Icon.png", 32);
            enemy.overworldAliveSprite = ResourceLoader.LoadSprite(ID + "World.png", 32, new Vector2?(new Vector2(0.5f, 0f)));
            enemy.overworldDeadSprite = ResourceLoader.LoadSprite(ID + "Dead.png", 32, new Vector2?(new Vector2(0.5f, 0f)));
            enemy.hurtSound = SaltEnemies.CursedNoise;
            enemy.deathSound = LoadedAssetsHandler.GetEnemy("SingingStone_EN").deathSound;
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_Dragon>();
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passi.Resistance, LoadedAssetsHandler.GetEnemy("Flarblet_EN").passiveAbilities[0],
            };
            enemy.abilities = new Ability[] { Bbili.Colors, Bbili.HoldHands, Bbili.Voice };
            enemy.enterEffects = new Effect[]
            {
                new Effect(AddResistanceEffect.Create(Pigments.Red), 1, null, Slots.Self),
            };
            enemy.AddEnemy();
        }
    }
    public static class Forget
    {
        public static string ID = "Forget";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "Torture-Me-Not",
                enemyID = "TortureMeNot_EN",
                health = 3,
                size = 1,
                entityID = (EntityIDs)entity,
                healthColor = Pigments.Red,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/16/" + ID + "_Enemy.prefab").AddComponent<MultiSpriteEnemyLayout>()
            };
            enemy.prefab._gibs = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/16/" + ID + "_Gibs.prefab").GetComponent<ParticleSystem>();
            enemy.prefab.SetDefaultParams();
            (enemy.prefab as MultiSpriteEnemyLayout).OtherRenderers = new SpriteRenderer[]
            {
                enemy.prefab._locator.transform.Find("Sprite").Find("Sprite").Find("f1").GetComponent<SpriteRenderer>(),
                enemy.prefab._locator.transform.Find("Sprite").Find("Sprite").Find("f2").GetComponent<SpriteRenderer>(),
                enemy.prefab._locator.transform.Find("Sprite").Find("Sprite").Find("f3").GetComponent<SpriteRenderer>(),
                enemy.prefab._locator.transform.Find("Sprite").Find("Sprite").Find("f4").GetComponent<SpriteRenderer>(),
                enemy.prefab._locator.transform.Find("Sprite").Find("Sprite").Find("f5").GetComponent<SpriteRenderer>(),
            };
            enemy.combatSprite = ResourceLoader.LoadSprite(ID + "Icon.png", 32);
            enemy.overworldAliveSprite = ResourceLoader.LoadSprite(ID + "World.png", 32, new Vector2?(new Vector2(0.5f, 0f)));
            enemy.overworldDeadSprite = ResourceLoader.LoadSprite(ID + "World.png", 32, new Vector2?(new Vector2(0.5f, 0f)));
            enemy.hurtSound = LoadedAssetsHandler.GetEnemy("JumbleGuts_Flummoxing_EN").damageSound;
            enemy.deathSound = LoadedAssetsHandler.GetEnemy("JumbleGuts_Flummoxing_EN").deathSound;
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passi.ForgetMe, Passives.Withering
            };
            enemy.abilities = new Ability[] { Abili.Chomp, Abili.Gnaw };
            enemy.AddEnemy();
        }
    }
}
