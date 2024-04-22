using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Hawthorne
{
    public static class Skyloft
    {
        public static string ID = "Skyloft";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "Skyloft",
                health = 2,
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
            enemy.hurtSound = LoadedAssetsHandler.GetCharcater("Mordrake_CH").damageSound;
            enemy.deathSound = LoadedAssetsHandler.GetCharcater("Mordrake_CH").deathSound;
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passi.Evasive, Passives.Cashout, Passi.Lazy, Passi.Flithering
            };
            enemy.abilities = new Ability[] { Abili.LoseControl, Abili.Sing, Abili.TooFarGone };
            enemy.AddEnemy();
        }
    }
}
