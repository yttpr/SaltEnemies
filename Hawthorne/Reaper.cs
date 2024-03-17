using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Hawthorne
{
    public static class Reaper
    {
        public static string ID = "Reaper";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "Death's Notice",
                health = 30,
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
            enemy.hurtSound = LoadedAssetsHandler.GetEnemy("SingingStone_EN").damageSound;
            enemy.deathSound = LoadedAssetsHandler.GetEnemy("SingingStone_EN").deathSound;
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passives.Withering
            };
            enemy.abilities = new Ability[] { Abili.LeftKill, Abili.RightKill };
            enemy.enemyID = "MiniReaper_EN";
            enemy.AddEnemy();
        }
    }
    public static class Blackstar
    {
        public static string ID = "Blackstar";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "Black Star",
                health = 16,
                size = 1,
                entityID = (EntityIDs)entity,
                healthColor = Pigments.Yellow,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/group4/" + ID + "/" + ID + "_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
            };
            enemy.prefab._gibs = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/group4/" + ID + "/" + ID + "_Gibs.prefab").GetComponent<ParticleSystem>();
            enemy.prefab.SetDefaultParams();
            enemy.combatSprite = ResourceLoader.LoadSprite(ID + "Icon.png", 32);
            enemy.overworldAliveSprite = ResourceLoader.LoadSprite(ID + "World.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.overworldDeadSprite = ResourceLoader.LoadSprite(ID + "Dead.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.hurtSound = LoadedAssetsHandler.GetEnemy("ChoirBoy_EN").damageSound;
            enemy.deathSound = LoadedAssetsHandler.GetEnemy("ChoirBoy_EN").deathSound;
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passi.DecaySingularity, Passives.Withering, Passi.Turbulent
            };
            enemy.abilities = new Ability[] { Abili.Radiation, Abili.Flare };
            enemy.enemyID = "BlackStar_EN";
            enemy.AddEnemy();
        }
    }
    public static class Singularity
    {
        public static string ID = "Singularity";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "Singularity",
                health = 50,
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
            enemy.hurtSound = LoadedAssetsHandler.GetEnemy("TaintedYolk_EN").damageSound;
            enemy.deathSound = LoadedAssetsHandler.GetEnemy("TaintedYolk_EN").deathSound;
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passi.Jumpy, Passives.Unstable, Passives.Constricting
            };
            ChangeMusicParameterEffect add = ScriptableObject.CreateInstance<ChangeMusicParameterEffect>();
            add._addition = true;
            add._parameter = MusicParameter.Ungod;
            ChangeMusicParameterEffect minu = ScriptableObject.CreateInstance<ChangeMusicParameterEffect>();
            minu._addition = false;
            minu._parameter = MusicParameter.Ungod;
            enemy.enterEffects = new Effect[]
            {
                new Effect(ScriptableObject.CreateInstance<AddTurnCasterToTimelineEffect>(), 1, null, Slots.Self, ScriptableObject.CreateInstance<IsPlayerTurnEffectCondition>()),
                new Effect(add, 1, null, Slots.Self),
            };
            enemy.exitEffects = new Effect[]
            {
                new Effect(minu, 1, null, Slots.Self)
            };
            enemy.abilities = new Ability[] { Abili.Gravity };
            enemy.enemyID = "Singularity_EN";
            enemy.AddEnemy();
        }
    }
    public static class Indicator
    {
        public static string ID = "Indicator";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "Indicator",
                health = 22,
                size = 1,
                entityID = (EntityIDs)entity,
                healthColor = Pigments.Yellow,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/group4/" + ID + "/" + ID + "_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
            };
            enemy.prefab._gibs = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/group4/" + ID + "/" + ID + "_Gibs.prefab").GetComponent<ParticleSystem>();
            enemy.prefab.SetDefaultParams();
            enemy.combatSprite = ResourceLoader.LoadSprite(ID + "Icon.png", 32);
            enemy.overworldAliveSprite = ResourceLoader.LoadSprite(ID + "World.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.overworldDeadSprite = ResourceLoader.LoadSprite(ID + "Dead.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.hurtSound = LoadedAssetsHandler.GetCharcater("Hans_CH").damageSound;
            enemy.deathSound = LoadedAssetsHandler.GetCharcater("Hans_CH").deathSound;
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passi.Compulsory, Passives.Slippery, Passives.Forgetful
            };
            enemy.abilities = new Ability[] { Abili.TransPain, Abili.TransSen, Abili.TransEmo, Abili.TransHung };
            //enemy.enemyID = "Indicator_EN";
            enemy.AddEnemy();
            LoadedAssetsHandler.GetEnemy("Indicator_EN").enemyTemplate.SetNerveParams();
        }
    }
    public static class Maw
    {
        public static string ID = "Maw";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "The Salivating",
                health = 30,
                size = 1,
                entityID = (EntityIDs)entity,
                healthColor = Pigments.Purple,
                priority = 10,
                prefab = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/group4/" + ID + "/" + ID + "_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
            };
            enemy.prefab._gibs = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/group4/" + ID + "/" + ID + "_Gibs.prefab").GetComponent<ParticleSystem>();
            enemy.prefab.SetDefaultParams();
            enemy.combatSprite = ResourceLoader.LoadSprite(ID + "Icon.png", 32);
            enemy.overworldAliveSprite = ResourceLoader.LoadSprite(ID + "World.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.overworldDeadSprite = ResourceLoader.LoadSprite(ID + "Dead.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.hurtSound = LoadedAssetsHandler.GetCharcater("LongLiver_CH").damageSound;
            enemy.deathSound = LoadedAssetsHandler.GetCharcater("Leviat_CH").deathSound;
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passi.BadDog, Passi.Multiattack(3), Passi.Fleeting(3)
            };
            enemy.abilities = new Ability[] { Abili.Hide, Abili.Seek, Abili.Stay, Abili.Salivate, Abili.Play };
            enemy.enemyID = "Maw_EN";
            enemy.AddEnemy();
        }
    }
}
