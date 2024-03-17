using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Hawthorne
{
    public static class Merced
    {
        public static string ID = "Merced";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "Merced",
                health = 1,
                size = 1,
                entityID = (EntityIDs)entity,
                healthColor = Pigments.Purple,
                priority = 3,
                prefab = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/group4/" + ID + "/" + ID + "_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
            };
            enemy.prefab._gibs = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/group4/" + ID + "/" + ID + "_Gibs.prefab").GetComponent<ParticleSystem>();
            enemy.prefab.SetDefaultParams();
            enemy.combatSprite = ResourceLoader.LoadSprite(ID + "Icon.png", 32);
            enemy.overworldAliveSprite = ResourceLoader.LoadSprite(ID + "World.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.overworldDeadSprite = ResourceLoader.LoadSprite(ID + "Dead.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.hurtSound = "event:/Hawthorne/Hurt/MercedScream";
            enemy.deathSound = "event:/Hawthorne/Die/MercedDie";
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passi.Preserved, Passives.Skittish
            };
            enemy.abilities = new Ability[] { Abili.Shredding, Abili.Binder, Abili.Engravings, Abili.Press, Abili.Descriptions, Abili.Indexing };
            enemy.AddEnemy();
        }
    }
}
