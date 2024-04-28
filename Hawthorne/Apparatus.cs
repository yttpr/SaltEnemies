using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Hawthorne
{
    public static class RedBot
    {
        public static string ID = "RedBot";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "Virile Apparatus",
                health = 17,
                size = 1,
                entityID = (EntityIDs)entity,
                healthColor = Pigments.Red,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/bot/" + ID + "_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
            };
            enemy.prefab._gibs = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/bot/" + ID + "_Gibs.prefab").GetComponent<ParticleSystem>();
            enemy.prefab.SetDefaultParams();
            enemy.combatSprite = ResourceLoader.LoadSprite(ID + "Icon.png", 32);
            enemy.overworldAliveSprite = ResourceLoader.LoadSprite(ID + "World.png", 32, new Vector2?(new Vector2(0.5f, 0f)));
            enemy.overworldDeadSprite = ResourceLoader.LoadSprite(ID + "Dead.png", 32, new Vector2?(new Vector2(0.5f, 0f)));
            enemy.hurtSound = "event:/Hawthorne/Noise/ApparatusHit";
            enemy.deathSound = "event:/Hawthorne/Noise/ApparatusDie";
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passi.Pillar, Passi.Multiattack(2)
            };
            enemy.abilities = new Ability[] { Bbili.Petrify, Bbili.Partition, Bbili.Postular, Bbili.Politics };
            enemy.enemyID = "RedBot_EN";
            enemy.AddEnemy();
        }
    }
    public static class BlueBot
    {
        public static string ID = "BlueBot";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "Mirrored Apparatus",
                health = 21,
                size = 1,
                entityID = (EntityIDs)entity,
                healthColor = Pigments.Blue,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/bot/" + ID + "_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
            };
            enemy.prefab._gibs = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/bot/" + ID + "_Gibs.prefab").GetComponent<ParticleSystem>();
            enemy.prefab.SetDefaultParams();
            enemy.combatSprite = ResourceLoader.LoadSprite(ID + "Icon.png", 32);
            enemy.overworldAliveSprite = ResourceLoader.LoadSprite(ID + "World.png", 32, new Vector2?(new Vector2(0.5f, 0f)));
            enemy.overworldDeadSprite = ResourceLoader.LoadSprite(ID + "Dead.png", 32, new Vector2?(new Vector2(0.5f, 0f)));
            enemy.hurtSound = "event:/Hawthorne/Noise/ApparatusHit";
            enemy.deathSound = "event:/Hawthorne/Noise/ApparatusDie";
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passi.Pillar, Passi.Multiattack(2)
            };
            enemy.abilities = new Ability[] { Bbili.Petrify, Bbili.Partition, Bbili.Postular, Bbili.Portrait };
            enemy.enemyID = "BlueBot_EN";
            enemy.AddEnemy();
        }
    }
    public static class YellowBot
    {
        public static string ID = "YellowBot";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "Projecting Apparatus",
                health = 21,
                size = 1,
                entityID = (EntityIDs)entity,
                healthColor = Pigments.Yellow,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/bot/" + ID + "_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
            };
            enemy.prefab._gibs = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/bot/" + ID + "_Gibs.prefab").GetComponent<ParticleSystem>();
            enemy.prefab.SetDefaultParams();
            enemy.combatSprite = ResourceLoader.LoadSprite(ID + "Icon.png", 32);
            enemy.overworldAliveSprite = ResourceLoader.LoadSprite(ID + "World.png", 32, new Vector2?(new Vector2(0.5f, 0f)));
            enemy.overworldDeadSprite = ResourceLoader.LoadSprite(ID + "Dead.png", 32, new Vector2?(new Vector2(0.5f, 0f)));
            enemy.hurtSound = "event:/Hawthorne/Noise/ApparatusHit";
            enemy.deathSound = "event:/Hawthorne/Noise/ApparatusDie";
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passi.Pillar, Passi.Multiattack(2)
            };
            enemy.abilities = new Ability[] { Bbili.Petrify, Bbili.Partition, Bbili.Postular, Bbili.Point };
            enemy.enemyID = "YellowBot_EN";
            enemy.AddEnemy();
        }
    }
    public static class PurpleBot
    {
        public static string ID = "PurpleBot";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "Magnificent Apparatus",
                health = 26,
                size = 1,
                entityID = (EntityIDs)entity,
                healthColor = Pigments.Purple,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/bot/" + ID + "_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
            };
            enemy.prefab._gibs = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/bot/" + ID + "_Gibs.prefab").GetComponent<ParticleSystem>();
            enemy.prefab.SetDefaultParams();
            enemy.combatSprite = ResourceLoader.LoadSprite(ID + "Icon.png", 32);
            enemy.overworldAliveSprite = ResourceLoader.LoadSprite(ID + "World.png", 32, new Vector2?(new Vector2(0.5f, 0f)));
            enemy.overworldDeadSprite = ResourceLoader.LoadSprite(ID + "Dead.png", 32, new Vector2?(new Vector2(0.5f, 0f)));
            enemy.hurtSound = "event:/Hawthorne/Noise/ApparatusHit";
            enemy.deathSound = "event:/Hawthorne/Noise/ApparatusDie";
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passi.Pillar, Passi.Multiattack(2)
            };
            enemy.abilities = new Ability[] { Bbili.Petrify, Bbili.Partition, Bbili.Postular, Bbili.Plight };
            enemy.enemyID = "PurpleBot_EN";
            enemy.AddEnemy();
        }
    }
    public static class GreyBot
    {
        public static string ID = "GreyBot";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "Audible Apparatus",
                health = 26,
                size = 1,
                entityID = (EntityIDs)entity,
                healthColor = Pigments.Gray,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/bot/" + ID + "_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
            };
            enemy.prefab._gibs = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/bot/" + ID + "_Gibs.prefab").GetComponent<ParticleSystem>();
            enemy.prefab.SetDefaultParams();
            enemy.combatSprite = ResourceLoader.LoadSprite(ID + "Icon.png", 32);
            enemy.overworldAliveSprite = ResourceLoader.LoadSprite(ID + "World.png", 32, new Vector2?(new Vector2(0.5f, 0f)));
            enemy.overworldDeadSprite = ResourceLoader.LoadSprite(ID + "Dead.png", 32, new Vector2?(new Vector2(0.5f, 0f)));
            enemy.hurtSound = "event:/Hawthorne/Noise/ApparatusHit";
            enemy.deathSound = "event:/Hawthorne/Noise/ApparatusDie";
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passi.Pillar, Passi.Multiattack(3)
            };
            enemy.abilities = new Ability[] { Bbili.Petrify, Bbili.Partition, Bbili.Postular, Bbili.Pledge };
            enemy.enemyID = "GreyBot_EN";
            enemy.AddEnemy();
        }
    }
    public static class GlassedSun
    {
        public static string ID = "Sun";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "Glassed Sun",
                health = 60,
                size = 1,
                entityID = (EntityIDs)entity,
                healthColor = Pigments.Yellow,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/sun/" + ID + "_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
            };
            enemy.prefab._gibs = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/sun/" + ID + "_Gibs.prefab").GetComponent<ParticleSystem>();
            enemy.prefab.SetDefaultParams();
            enemy.combatSprite = ResourceLoader.LoadSprite(ID + "Icon.png", 32);
            enemy.overworldAliveSprite = ResourceLoader.LoadSprite(ID + "World.png", 32, new Vector2?(new Vector2(0.5f, 0f)));
            enemy.overworldDeadSprite = ResourceLoader.LoadSprite(ID + "Dead.png", 32, new Vector2?(new Vector2(0.5f, 0f)));
            enemy.hurtSound = LoadedAssetsHandler.GetEnemy("JumbleGuts_Hollowing_EN").damageSound;
            enemy.deathSound = LoadedAssetsHandler.GetEnemy("JumbleGuts_Hollowing_EN").deathSound;
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passi.Hemochromia, Passi.Stained
            };
            enemy.abilities = new Ability[] { Abili.Flare, Bbili.Temper };
            ChangeToRandomHealthColorEffect instance47 = ScriptableObject.CreateInstance<ChangeToRandomHealthColorEffect>();
            instance47._healthColors = new ManaColorSO[]
            {
                        Pigments.Blue,
                        Pigments.Red,
                        Pigments.Yellow,
                        Pigments.Purple,
            };
            enemy.enterEffects = new Effect[]
            {
                new Effect(instance47, 1, null, Slots.Self),
                new Effect(ScriptableObject.CreateInstance<SunColorEffect>(), 1, null, Slots.Self),
            };
            enemy.AddEnemy();
        }
    }
}
