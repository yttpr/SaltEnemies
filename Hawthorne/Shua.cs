using BrutalAPI;
using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using UnityEngine;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Hawthorne
{
    public static class Shua
    {
        public static string ID = "Shua";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "SHUA",
                health = 28,
                size = 1,
                entityID = (EntityIDs)entity,
                healthColor = Pigments.Red,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/group4/" + ID + "/" + ID + "_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
            };
            enemy.prefab._gibs = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/group4/" + ID + "/" + ID + "_Gibs.prefab").GetComponent<ParticleSystem>();
            enemy.prefab.SetDefaultParams();
            enemy.combatSprite = ResourceLoader.LoadSprite(ID+ "Icon.png", 32);
            enemy.overworldAliveSprite = ResourceLoader.LoadSprite(ID+ "World.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.overworldDeadSprite = ResourceLoader.LoadSprite(ID+"Dead.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.hurtSound = LoadedAssetsHandler.GetCharcater("Hans_CH").damageSound;
            enemy.deathSound = LoadedAssetsHandler.GetCharcater("Hans_CH").deathSound;
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_Shua>();
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passi.Incomprehensible, Passives.Skittish, Passi.Fleeting(3)
            };
            enemy.abilities = new Ability[] { Abili.Whisperings, Abili.Wanderlust, Abili.Waver };
            enemy.enemyID = "Shua_EN";
            enemy.AddEnemy();
        }
    }
    public static class CrashesYourGame
    {
        public static string ID = "CrashesYourGame";
        public static string Name = "Crashes Your Game";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = Name,
                health = 99,
                size = 1,
                entityID = (EntityIDs)entity,
                healthColor = Pigments.Gray,
                priority = 3,
                prefab = LoadedAssetsHandler.GetEnemy("Mung_EN").enemyTemplate
                //prefab = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/group4/" + ID + "/" + ID + "_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
            };
            //enemy.prefab._gibs = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/group4/" + ID + "/" + ID + "_Gibs.prefab").GetComponent<ParticleSystem>();
            //enemy.prefab.SetDefaultParams();
            enemy.combatSprite = ResourceLoader.LoadSprite(ID + "Icon.png", 32);
            enemy.overworldAliveSprite = ResourceLoader.LoadSprite(ID + "World.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.overworldDeadSprite = ResourceLoader.LoadSprite(ID + "Dead.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.hurtSound = "event:/Hawthorne/Boowomp";
            enemy.deathSound = "event:/Hawthorne/Boowomp";
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passi.Jumpy, Passi.Incomprehensible, Passi.Illusory, Passi.Armor, Passi.Unbreakable, Passi.Lock, Passi.Steel, Passi.Preserved, Passi.Coda, Passi.Survival, 
                Passi.Multiattack(6), Passives.Formless, Passives.Obscured, Passi.Acceleration, Passives.Infestation, Passives.Pure, Passives.Unstable, Passi.Violent(8), 
                Passi.Turbulent, Passi.Waves, Passi.Whimsy
            };
            enemy.abilities = new Ability[] { Abili.CrashYourGame, Abili.Throttle, Abili.Die4U, Abili.DieWithYou, Abili.Gross, Abili.DeepBreaths, Abili.Crucify, Abili.Shredding, 
                Abili.CrazyBlood, Abili.Lie4U, Abili.NobodyMoves, Abili.PsychoDreams, Abili.Presence, Abili.ScareFeeble, Abili.Seek, Abili.Hide, Abili.Swallow, Abili.Wanderlust };
            enemy.AddEnemy();
        }
    }

    public static class Wysteria
    {
        public static void AddEnemy(Action<Enemy> orig, Enemy self)
        {
            if (self.name == SaltEnemies.wysteria)
            {
                string input = ((self.enemyID == "") ? (self.name + "_EN") : self.enemyID);
                string text2 = Regex.Replace(input, "\\s+", "");
                Debug.Log("Added enemy " + text2);
                return;
            }
            orig(self);
        }
        public static void Setup()
        {
            IDetour hook = new Hook(typeof(Enemy).GetMethod(nameof(Enemy.AddEnemy), ~BindingFlags.Default), typeof(Wysteria).GetMethod(nameof(AddEnemy), ~BindingFlags.Default));
        }
    }
    public static class Lobotomy
    {
        public static string ID = "Lobotomy";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "Your New Life!",
                health = 35,
                size = 1,
                entityID = (EntityIDs)entity,
                healthColor = Pigments.Gray,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/" + ID + "/" + ID + "_Enemy.prefab").AddComponent<MultiSpriteEnemyLayout>()
            };
            enemy.prefab._gibs = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/" + ID + "/" + ID + "_Gibs.prefab").GetComponent<ParticleSystem>();
            enemy.prefab.SetDefaultParams();
            (enemy.prefab as MultiSpriteEnemyLayout).OtherRenderers = new SpriteRenderer[]
            {
                enemy.prefab._locator.transform.Find("Sprite").Find("Sprite (1)").GetComponent<SpriteRenderer>(),
                enemy.prefab._locator.transform.Find("Sprite").Find("Sprite (2)").GetComponent<SpriteRenderer>(),
                enemy.prefab._locator.transform.Find("Sprite").Find("Sprite (3)").GetComponent<SpriteRenderer>(),
                enemy.prefab._locator.transform.Find("Sprite").Find("Sprite (4)").GetComponent<SpriteRenderer>(),
                enemy.prefab._locator.transform.Find("Sprite").Find("Sprite (5)").GetComponent<SpriteRenderer>(),
                enemy.prefab._locator.transform.Find("Sprite").Find("Sprite (6)").GetComponent<SpriteRenderer>(),
                enemy.prefab._locator.transform.Find("Sprite").Find("Sprite (7)").GetComponent<SpriteRenderer>(),
                enemy.prefab._locator.transform.Find("Sprite").Find("Sprite (8)").GetComponent<SpriteRenderer>(),
                enemy.prefab._locator.transform.Find("Sprite").Find("Sprite (9)").GetComponent<SpriteRenderer>(),
                enemy.prefab._locator.transform.Find("Sprite").Find("Sprite (10)").GetComponent<SpriteRenderer>(),
            };
            enemy.combatSprite = ResourceLoader.LoadSprite(ID + "Icon.png", 32);
            enemy.overworldAliveSprite = ResourceLoader.LoadSprite(ID + "World.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.overworldDeadSprite = ResourceLoader.LoadSprite(ID + "Dead.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.hurtSound = LoadedAssetsHandler.GetEnemy("ChoirBoy_EN").damageSound;
            enemy.deathSound = LoadedAssetsHandler.GetEnemy("ChoirBoy_EN").deathSound;
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_YNL>();
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passi.Appointment
            };
            enemy.abilities = new Ability[] { Abili.ShockTherapy, Abili.Illuminate, Abili.Replacement };
            enemy.enemyID = "YNL_EN";
            enemy.AddEnemy();
        }
    }
}
