using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Hawthorne
{
    public static class WindSong
    {
        public static string ID = "WindSong";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "Wind Song",
                health = 42,
                size = 1,
                entityID = (EntityIDs)entity,
                healthColor = Pigments.Blue,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/group4/" + ID + "/" + ID + "_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
                //prefab = LoadedAssetsHandler.GetEnemy("JumbleGuts_Hollowing_EN").enemyTemplate
            };
            enemy.prefab._gibs = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/group4/" + ID + "/" + ID + "_Gibs.prefab").GetComponent<ParticleSystem>();
            enemy.prefab.SetDefaultParams();
            enemy.combatSprite = ResourceLoader.LoadSprite(ID + "Icon.png", 32);
            enemy.overworldAliveSprite = ResourceLoader.LoadSprite(ID + "World.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.overworldDeadSprite = ResourceLoader.LoadSprite(ID + "Dead.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.hurtSound = "event:/Hawthorne/Hurt/BirdSound";
            enemy.deathSound = "event:/Hawthorne/Hurt/BirdSound";
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passives.Slippery, Passi.Coda, Passives.Formless
            };
            enemy.abilities = new Ability[] { Abili.Throttle, Abili.Coda };
            enemy.AddEnemy();

            MainEffect = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/group4/" + ID + "/" + ID + "_Effect.prefab").GetComponent<ParticleSystem>();
            SideEffectOne = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/group4/" + ID + "/" + ID + "_Burst.prefab").GetComponent<ParticleSystem>();
            SideEffectTwo = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/group4/" + ID + "/" + ID + "_Blast.prefab").GetComponent<ParticleSystem>();
            WindSongManager.Setup();
        }
        public static ParticleSystem MainEffect;
        public static ParticleSystem SideEffectOne;
        public static ParticleSystem SideEffectTwo;
    }
}
