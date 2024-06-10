using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Hawthorne
{
    public static class Tortoise
    {
        public static string ID = "Tortoise";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "Stalwart Tortoise",
                health = 66,
                size = 2,
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
            enemy.hurtSound = LoadedAssetsHandler.GetEnemy("Flarb_EN").damageSound;
            enemy.deathSound = LoadedAssetsHandler.GetEnemy("Flarb_EN").deathSound;
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passi.Armor, Passi.Painless, Passives.Forgetful, Passi.Fleeting(9)
            };
            enemy.enterEffects = new Effect[] { new Effect(ScriptableObject.CreateInstance<ArmorEffect>(), 1, null, Targetting.AllSelfSlots) };
            enemy.abilities = new Ability[] { Abili.DeepBreaths, Abili.Hurdle, Abili.Disembowel };
            enemy.AddEnemy();
        }
    }
}
