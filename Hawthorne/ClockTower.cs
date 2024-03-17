using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Hawthorne
{
    public static class ClockTower
    {
        public static string ID = "ClockTower";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "The End of Time",
                health = 44,
                size = 1,
                entityID = (EntityIDs)entity,
                healthColor = Pigments.Gray,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/group4/" + ID + "/" + ID + "_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
            };
            enemy.prefab._gibs = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/group4/" + ID + "/" + ID + "_Gibs.prefab").GetComponent<ParticleSystem>();
            enemy.prefab.SetDefaultParams();
            enemy.enemyID = "ClockTower_EN";
            enemy.combatSprite = ResourceLoader.LoadSprite(ID + "Icon.png", 32);
            enemy.overworldAliveSprite = ResourceLoader.LoadSprite(ID + "World.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.overworldDeadSprite = ResourceLoader.LoadSprite(ID + "Dead.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.hurtSound = LoadedAssetsHandler.GetCharcater("Gospel_CH").damageSound;
            enemy.deathSound = LoadedAssetsHandler.GetCharcater("Gospel_CH").deathSound;
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ClockTower>();
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passi.Overexert(12), Passi.Acceleration
            };
            enemy.abilities = new Ability[] { Abili.Cripple, Abili.Crucify, Abili.Cracking };
            enemy.exitEffects = new Effect[]
            {
                new Effect(ScriptableObject.CreateInstance<ClockTowerExitEffect>(), 1, null, Slots.Self)
            };
            enemy.AddEnemy();
        }
    }
}
