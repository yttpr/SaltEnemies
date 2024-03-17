using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Hawthorne
{
    public static class Solvent
    {
        public static string ID = "Solvent";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "Living Solvent",
                health = 12,
                size = 1,
                entityID = (EntityIDs)entity,
                healthColor = Pigments.Red,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/group4/" + ID + "/" + ID + "_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
                //prefab = LoadedAssetsHandler.GetEnemy("WrigglingSacrifice_EN").enemyTemplate
            };
            enemy.prefab._gibs = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/group4/" + ID + "/" + ID + "_Gibs.prefab").GetComponent<ParticleSystem>();
            enemy.prefab.SetDefaultParams();
            enemy.combatSprite = ResourceLoader.LoadSprite(ID + "Icon.png", 32);
            enemy.overworldAliveSprite = ResourceLoader.LoadSprite(ID + "World.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.overworldDeadSprite = ResourceLoader.LoadSprite(ID + "Dead.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.hurtSound = LoadedAssetsHandler.GetEnemy("WrigglingSacrifice_EN").damageSound;
            enemy.deathSound = LoadedAssetsHandler.GetEnemy("WrigglingSacrifice_EN").deathSound;
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passi.Survival, Passi.Intimidated, Passi.Fleeting(5), Passi.Coward, Passives.Dying
            };
            enemy.abilities = new Ability[] { Abili.Bloodletting, Abili.Camouflage, Abili.Runaway };
            enemy.AddEnemy();
        }
    }
}
