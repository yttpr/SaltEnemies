using BrutalAPI;
using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System.Reflection;

namespace Hawthorne
{
    public static class Coffin
    {
        public static string ID = "Coffin";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "The Grudge",
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
            enemy.hurtSound = LoadedAssetsHandler.GetEnemy("Visage_MyOwn_EN").damageSound;
            enemy.deathSound = LoadedAssetsHandler.GetEnemy("Visage_MyOwn_EN").deathSound;
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passi.Disable, Passi.Leaky(8), Passi.Rupture
            };
            enemy.abilities = new Ability[] { Abili.Sink, Abili.Rot, Abili.Writhe };
            enemy.enemyID = "Grandfather_EN";
            enemy.AddEnemy();
        }
    }
    public class MultiSpriteEnemyLayout : EnemyInFieldLayout
    {
        public SpriteRenderer[] OtherRenderers;
        public void Prepare()
        {
            if (OtherRenderers != null) foreach (SpriteRenderer rend in OtherRenderers) rend.material = _enemyMaterialInstance;
        }
        public void UpdateRends()
        {
            Color value = _basicColor;
            if (TurnSelected)
            {
                value = _turnColor;
            }
            else if (TargetSelected)
            {
                value = _targetColor;
            }
            else if (MouseSelected)
            {
                value = _hoverColor;
            }

            float value2 = ((MouseSelected || TargetSelected || TurnSelected) ? 1 : 0);
            if (OtherRenderers != null) foreach (SpriteRenderer rend in OtherRenderers)
                {
                    rend.material.SetColor("_OutlineColor", value);
                    rend.material.SetFloat("_OutlineAlpha", value2);
                }
        }
        public static void BaseIni(Action<EnemyInFieldLayout, int, Vector3> orig, EnemyInFieldLayout self, int id, Vector3 location3D)
        {
            orig(self, id, location3D);
            if (self is MultiSpriteEnemyLayout l) l.Prepare();
        }
        public static void BaseUpi(Action<EnemyInFieldLayout> orig, EnemyInFieldLayout self)
        {
            orig(self);
            if (self is MultiSpriteEnemyLayout l) l.UpdateRends();
        }
        public static void Setup()
        {
            IDetour hook0 = new Hook(typeof(MultiSpriteEnemyLayout).GetMethod(nameof(Initialization), ~BindingFlags.Default), typeof(MultiSpriteEnemyLayout).GetMethod(nameof(BaseIni), ~BindingFlags.Default));
            IDetour hook1 = new Hook(typeof(MultiSpriteEnemyLayout).GetMethod(nameof(UpdateSlotSelection), ~BindingFlags.Default), typeof(MultiSpriteEnemyLayout).GetMethod(nameof(BaseUpi), ~BindingFlags.Default));
            IDetour hook2 = new Hook(typeof(EnemyInFieldLayout).GetMethod(nameof(Initialization), ~BindingFlags.Default), typeof(MultiSpriteEnemyLayout).GetMethod(nameof(BaseIni), ~BindingFlags.Default));
            IDetour hook3 = new Hook(typeof(EnemyInFieldLayout).GetMethod(nameof(UpdateSlotSelection), ~BindingFlags.Default), typeof(MultiSpriteEnemyLayout).GetMethod(nameof(BaseUpi), ~BindingFlags.Default));
        }
    }
    public static class Children
    {
        public static void Add6(int entity, string ID)
        {
            Enemy enemy = new Enemy()
            {
                name = "Children of God",
                health = 1,
                size = 1,
                entityID = (EntityIDs)entity,
                healthColor = Pigments.Gray,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/Children/" + ID + "_Enemy.prefab").AddComponent<MultiSpriteEnemyLayout>()
            };
            enemy.prefab._gibs = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/Children/Children_Gibs.prefab").GetComponent<ParticleSystem>();
            enemy.prefab.SetDefaultParams();
            (enemy.prefab as MultiSpriteEnemyLayout).OtherRenderers = new SpriteRenderer[]
            {
                enemy.prefab._locator.transform.Find("Sprite").Find("Sprite").GetComponent<SpriteRenderer>(),
                enemy.prefab._locator.transform.Find("Sprite").Find("Sprite (1)").GetComponent<SpriteRenderer>(),
                enemy.prefab._locator.transform.Find("Sprite").Find("Sprite (2)").GetComponent<SpriteRenderer>(),
                enemy.prefab._locator.transform.Find("Sprite").Find("Sprite (3)").GetComponent<SpriteRenderer>(),
                enemy.prefab._locator.transform.Find("Sprite").Find("Sprite (4)").GetComponent<SpriteRenderer>(),
                enemy.prefab._locator.transform.Find("Sprite").Find("Sprite (5)").GetComponent<SpriteRenderer>(),
            };
            enemy.combatSprite = ResourceLoader.LoadSprite(ID + "Icon.png", 32);
            enemy.overworldAliveSprite = ResourceLoader.LoadSprite(ID + "World.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.overworldDeadSprite = ResourceLoader.LoadSprite("ChildrenDead.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.hurtSound = LoadedAssetsHandler.GetCharcater("Hans_CH").damageSound;
            enemy.deathSound = LoadedAssetsHandler.GetCharcater("Hans_CH").deathSound;
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passi.Whimsy, Passi.FakeDecay, Passives.Withering
            };
            enemy.abilities = new Ability[] { Abili.Slop, Abili.Pingo, Abili.Skitter };
            enemy.enemyID =ID + "_EN";
            enemy.AddEnemy();
        }
        public static void Add5(int entity, string ID)
        {
            Enemy enemy = new Enemy()
            {
                name = "Children of God",
                health = 1,
                size = 1,
                entityID = (EntityIDs)entity,
                healthColor = Pigments.Gray,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/Children/" + ID + "_Enemy.prefab").AddComponent<MultiSpriteEnemyLayout>()
            };
            enemy.prefab._gibs = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/Children/Children_Gibs.prefab").GetComponent<ParticleSystem>();
            enemy.prefab.SetDefaultParams();
            (enemy.prefab as MultiSpriteEnemyLayout).OtherRenderers = new SpriteRenderer[]
            {
                enemy.prefab._locator.transform.Find("Sprite").Find("Sprite").GetComponent<SpriteRenderer>(),
                enemy.prefab._locator.transform.Find("Sprite").Find("Sprite (1)").GetComponent<SpriteRenderer>(),
                enemy.prefab._locator.transform.Find("Sprite").Find("Sprite (2)").GetComponent<SpriteRenderer>(),
                enemy.prefab._locator.transform.Find("Sprite").Find("Sprite (3)").GetComponent<SpriteRenderer>(),
                enemy.prefab._locator.transform.Find("Sprite").Find("Sprite (5)").GetComponent<SpriteRenderer>(),
            };
            enemy.combatSprite = ResourceLoader.LoadSprite(ID + "Icon.png", 32);
            enemy.overworldAliveSprite = ResourceLoader.LoadSprite(ID + "World.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.overworldDeadSprite = ResourceLoader.LoadSprite("ChildrenDead.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.hurtSound = LoadedAssetsHandler.GetCharcater("Hans_CH").damageSound;
            enemy.deathSound = LoadedAssetsHandler.GetCharcater("Hans_CH").deathSound;
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passi.Whimsy, Passi.FakeDecay, Passives.Withering
            };
            enemy.abilities = new Ability[] { Abili.Slop, Abili.Pingo, Abili.Skitter };
            enemy.enemyID = ID + "_EN";
            enemy.AddEnemy();
        }
        public static void Add4(int entity, string ID)
        {
            Enemy enemy = new Enemy()
            {
                name = "Children of God",
                health = 1,
                size = 1,
                entityID = (EntityIDs)entity,
                healthColor = Pigments.Gray,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/Children/" + ID + "_Enemy.prefab").AddComponent<MultiSpriteEnemyLayout>()
            };
            enemy.prefab._gibs = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/Children/Children_Gibs.prefab").GetComponent<ParticleSystem>();
            enemy.prefab.SetDefaultParams();
            (enemy.prefab as MultiSpriteEnemyLayout).OtherRenderers = new SpriteRenderer[]
            {
                enemy.prefab._locator.transform.Find("Sprite").Find("Sprite").GetComponent<SpriteRenderer>(),
                enemy.prefab._locator.transform.Find("Sprite").Find("Sprite (1)").GetComponent<SpriteRenderer>(),
                enemy.prefab._locator.transform.Find("Sprite").Find("Sprite (3)").GetComponent<SpriteRenderer>(),
                enemy.prefab._locator.transform.Find("Sprite").Find("Sprite (5)").GetComponent<SpriteRenderer>(),
            };
            enemy.combatSprite = ResourceLoader.LoadSprite(ID + "Icon.png", 32);
            enemy.overworldAliveSprite = ResourceLoader.LoadSprite(ID + "World.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.overworldDeadSprite = ResourceLoader.LoadSprite("ChildrenDead.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.hurtSound = LoadedAssetsHandler.GetCharcater("Hans_CH").damageSound;
            enemy.deathSound = LoadedAssetsHandler.GetCharcater("Hans_CH").deathSound;
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passi.Whimsy, Passi.FakeDecay, Passives.Withering
            };
            enemy.abilities = new Ability[] { Abili.Slop, Abili.Pingo, Abili.Skitter };
            enemy.enemyID = ID + "_EN";
            enemy.AddEnemy();
        }
        public static void Add3(int entity, string ID)
        {
            Enemy enemy = new Enemy()
            {
                name = "Children of God",
                health = 1,
                size = 1,
                entityID = (EntityIDs)entity,
                healthColor = Pigments.Gray,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/Children/" + ID + "_Enemy.prefab").AddComponent<MultiSpriteEnemyLayout>()
            };
            enemy.prefab._gibs = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/Children/Children_Gibs.prefab").GetComponent<ParticleSystem>();
            enemy.prefab.SetDefaultParams();
            (enemy.prefab as MultiSpriteEnemyLayout).OtherRenderers = new SpriteRenderer[]
            {
                enemy.prefab._locator.transform.Find("Sprite").Find("Sprite").GetComponent<SpriteRenderer>(),
                enemy.prefab._locator.transform.Find("Sprite").Find("Sprite (1)").GetComponent<SpriteRenderer>(),
                enemy.prefab._locator.transform.Find("Sprite").Find("Sprite (5)").GetComponent<SpriteRenderer>(),
            };
            enemy.combatSprite = ResourceLoader.LoadSprite(ID + "Icon.png", 32);
            enemy.overworldAliveSprite = ResourceLoader.LoadSprite(ID + "World.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.overworldDeadSprite = ResourceLoader.LoadSprite("ChildrenDead.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.hurtSound = LoadedAssetsHandler.GetCharcater("Hans_CH").damageSound;
            enemy.deathSound = LoadedAssetsHandler.GetCharcater("Hans_CH").deathSound;
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passi.Whimsy, Passi.FakeDecay, Passives.Withering
            };
            enemy.abilities = new Ability[] { Abili.Slop, Abili.Pingo, Abili.Skitter };
            enemy.enemyID = ID + "_EN";
            enemy.AddEnemy();
        }
        public static void Add2(int entity, string ID)
        {
            Enemy enemy = new Enemy()
            {
                name = "Children of God",
                health = 1,
                size = 1,
                entityID = (EntityIDs)entity,
                healthColor = Pigments.Gray,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/Children/" + ID + "_Enemy.prefab").AddComponent<MultiSpriteEnemyLayout>()
            };
            enemy.prefab._gibs = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/Children/Children_Gibs.prefab").GetComponent<ParticleSystem>();
            enemy.prefab.SetDefaultParams();
            (enemy.prefab as MultiSpriteEnemyLayout).OtherRenderers = new SpriteRenderer[]
            {
                enemy.prefab._locator.transform.Find("Sprite").Find("Sprite").GetComponent<SpriteRenderer>(),
                enemy.prefab._locator.transform.Find("Sprite").Find("Sprite (5)").GetComponent<SpriteRenderer>(),
            };
            enemy.combatSprite = ResourceLoader.LoadSprite(ID + "Icon.png", 32);
            enemy.overworldAliveSprite = ResourceLoader.LoadSprite(ID + "World.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.overworldDeadSprite = ResourceLoader.LoadSprite("ChildrenDead.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.hurtSound = LoadedAssetsHandler.GetCharcater("Hans_CH").damageSound;
            enemy.deathSound = LoadedAssetsHandler.GetCharcater("Hans_CH").deathSound;
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passi.Whimsy, Passi.FakeDecay, Passives.Withering
            };
            enemy.abilities = new Ability[] { Abili.Slop, Abili.Pingo, Abili.Skitter };
            enemy.enemyID = ID + "_EN";
            enemy.AddEnemy();
        }
        public static void Add1(int entity, string ID)
        {
            Enemy enemy = new Enemy()
            {
                name = "Child of God",
                health = 1,
                size = 1,
                entityID = (EntityIDs)entity,
                healthColor = Pigments.Gray,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/Children/" + ID + "_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
            };
            enemy.prefab._gibs = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/Children/Children_Gibs.prefab").GetComponent<ParticleSystem>();
            enemy.prefab.SetDefaultParams();
            enemy.combatSprite = ResourceLoader.LoadSprite(ID + "Icon.png", 32);
            enemy.overworldAliveSprite = ResourceLoader.LoadSprite(ID + "World.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.overworldDeadSprite = ResourceLoader.LoadSprite("ChildrenDead.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.hurtSound = LoadedAssetsHandler.GetCharcater("Hans_CH").damageSound;
            enemy.deathSound = LoadedAssetsHandler.GetCharcater("Hans_CH").deathSound;
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passi.Whimsy, Passives.Withering
            };
            enemy.abilities = new Ability[] { Abili.Slop, Abili.Pingo, Abili.Skitter };
            enemy.enemyID = ID + "_EN";
            enemy.AddEnemy();
        }
        public static void Add0(int entity, string ID)
        {
            Enemy enemy = new Enemy()
            {
                name = "Ghost of Child of God",
                health = 1,
                size = 1,
                entityID = (EntityIDs)entity,
                healthColor = Pigments.Gray,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/Children/" + ID + "_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
            };
            enemy.prefab._gibs = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/Children/Children_Ghost_Gibs.prefab").GetComponent<ParticleSystem>();
            enemy.prefab.SetDefaultParams();
            enemy.combatSprite = ResourceLoader.LoadSprite(ID + "Icon.png", 32);
            enemy.overworldAliveSprite = ResourceLoader.LoadSprite(ID + "World.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.overworldDeadSprite = ResourceLoader.LoadSprite("ChildrenDead.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.hurtSound = LoadedAssetsHandler.GetCharcater("Hans_CH").damageSound;
            enemy.deathSound = LoadedAssetsHandler.GetCharcater("Hans_CH").deathSound;
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passi.Whimsy, Passives.Withering
            };
            enemy.abilities = new Ability[] { Abili.Slop, Abili.Pingo, Abili.Skitter };
            enemy.enemyID = ID + "_EN";
            enemy.AddEnemy();
        }
        public static void Add00(int entity, string ID)
        {
            Enemy enemy = new Enemy()
            {
                name = "PrayerFool_BOMOD",
                health = 1,
                size = 1,
                entityID = (EntityIDs)entity,
                healthColor = Pigments.Purple,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/Children/" + ID + "_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
            };
            enemy.prefab._gibs = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/Children/Children_Prayer_Gibs.prefab").GetComponent<ParticleSystem>();
            enemy.prefab.SetDefaultParams();
            enemy.combatSprite = ResourceLoader.LoadSprite(ID + "Icon.png", 32);
            enemy.overworldAliveSprite = ResourceLoader.LoadSprite(ID + "World.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.overworldDeadSprite = ResourceLoader.LoadSprite("ChildrenDead.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.hurtSound = LoadedAssetsHandler.GetEnemy("SkinningHomunculus_EN").damageSound;
            enemy.deathSound = LoadedAssetsHandler.GetEnemy("SkinningHomunculus_EN").deathSound;
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passi.Whimsy, Passives.Withering
            };
            enemy.abilities = new Ability[] { Abili.Slop, Abili.Pingo, Abili.Skitter };
            enemy.enemyID = "ChildrenPrayer_EN";
            enemy.AddEnemy();
        }
        public static void Add(int entity)
        {
            Add6(entity, "Children6");
            Add5(entity, "Children5");
            Add4(entity, "Children4");
            Add3(entity, "Children3");
            Add2(entity, "Children2");
            Add1(entity, "Children1");
            Add0(entity, "Children0");
            Add00(entity, "Children00");
        }
    }
}
