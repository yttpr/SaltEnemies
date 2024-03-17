using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Hawthorne
{
    public static class Nameless
    {
        public static string ID = "Nameless";
        public static void Add(int entity)
        {
            try
            {
                Enemy enemy = new Enemy()
                {
                    name = "",
                    health = 6,
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
                enemy.hurtSound = LoadedAssetsHandler.GetEnemy("JumbleGuts_Hollowing_EN").damageSound;
                enemy.deathSound = LoadedAssetsHandler.GetEnemy("JumbleGuts_Hollowing_EN").deathSound;
                enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
                enemy.passives = new BasePassiveAbilitySO[]
                {
                Passives.Immortal, Passives.Withering, Passives.Anchored, Passi.Fleeting(4)
                };
                enemy.abilities = new Ability[] { Abili.Nameless, Abili.NobodyMoves };
                enemy.exitEffects = new Effect[]
                {
                new Effect(ScriptableObject.CreateInstance<SpawnCasterGibsEffect>(), 1, null, Slots.Self, ScriptableObject.CreateInstance<IsDieCondition>())
                };
                enemy.enemyID = "Nameless_EN";
                enemy.AddEnemy();
            }
            catch
            {
                Enemy enemy = new Enemy()
                {
                    name = "Nameless",
                    health = 6,
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
                enemy.hurtSound = LoadedAssetsHandler.GetEnemy("JumbleGuts_Hollowing_EN").damageSound;
                enemy.deathSound = LoadedAssetsHandler.GetEnemy("JumbleGuts_Hollowing_EN").deathSound;
                enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
                enemy.passives = new BasePassiveAbilitySO[]
                {
                Passives.Immortal, Passives.Withering, Passives.Anchored, Passi.Fleeting(4)
                };
                enemy.abilities = new Ability[] { Abili.Nameless, Abili.NobodyMoves };
                enemy.exitEffects = new Effect[]
                {
                new Effect(ScriptableObject.CreateInstance<SpawnCasterGibsEffect>(), 1, null, Slots.Self, ScriptableObject.CreateInstance<IsDieCondition>())
                };
                enemy.AddEnemy();
            }
        }
    }
}
