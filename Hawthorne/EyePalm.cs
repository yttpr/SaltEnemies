using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Hawthorne
{
    public static class EyePalm
    {
        public static string ID = "EyePalm";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "Medamaude",
                health = 20,
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
            enemy.hurtSound = LoadedAssetsHandler.GetEnemy("ShiveringHomunculus_EN").damageSound;
            enemy.deathSound = LoadedAssetsHandler.GetEnemy("ShiveringHomunculus_EN").deathSound;
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            try
            {
                enemy.passives = new BasePassiveAbilitySO[]
                {
                    Passi.MissFaced
                };
            }
            catch
            {
                Debug.LogError("miss faced didnt work, sad!");
                enemy.passives = new BasePassiveAbilitySO[]
                {
                    Passives.TwoFaced
                };
            }
            enemy.abilities = new Ability[] { Abili.BluePigs, Abili.CrazyBlood, Abili.Pinch };
            enemy.enemyID = "EyePalm_EN";
            enemy.AddEnemy();
        }
    }
    public static class Clione
    {
        public static string ID = "Clione";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "Abyss Angel",
                health = 20,
                size = 1,
                entityID = (EntityIDs)entity,
                healthColor = Pigments.Blue,
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
                Passives.Slippery, Passi.Waves
            };
            enemy.abilities = new Ability[] { Abili.Underwater, Abili.LostLove, Abili.TailHead };
            enemy.enemyID = "Clione_EN";
            enemy.unitType = UnitType.Fish;
            enemy.AddEnemy();
        }
    }
}
