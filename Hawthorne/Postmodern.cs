using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Hawthorne
{
    public static class Postmodern
    {
        public static string ID = "Postmodern";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "Postmodern",
                health = 10000,
                size = 1,
                entityID = (EntityIDs)entity,
                healthColor = Pigments.Purple,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/group4/" + ID + "/" + ID + "_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
            };
            enemy.prefab._gibs = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/group4/" + ID + "/" + ID + "_Gibs.prefab").GetComponent<ParticleSystem>();
            enemy.prefab.SetDefaultParams();
            enemy.combatSprite = ResourceLoader.LoadSprite(ID + "Icon.png", 32);
            enemy.overworldAliveSprite = ResourceLoader.LoadSprite(ID + "World.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.overworldDeadSprite = ResourceLoader.LoadSprite(ID + "Dead.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.hurtSound = "event:/Hawthorne/Hurt/PhoneSound";
            enemy.deathSound = LoadedAssetsHandler.GetCharcater("Rags_CH").deathSound;
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passi.Postmodern, LoadedAssetsHandler.GetEnemy("Flarblet_EN").passiveAbilities[0], Passi.Cry, Passi.Lock
            };
            enemy.abilities = new Ability[] { Abili.SprayBlood, Abili.SplitBlood, Abili.SplatterBlood };
            enemy.loot = new EnemyLootItemProbability[]
            {
                new EnemyLootItemProbability() { isItemTreasure = true, amount = 1, probability = 100 },
                new EnemyLootItemProbability() { isItemTreasure = false, amount = 2, probability = 100 }
            };
            StartDialogueConversationEffect itsover = ScriptableObject.CreateInstance<StartDialogueConversationEffect>();
            itsover._dialogue = PostmodernHandler.AfterCombat;
            UnlockShitEffect unlock = ScriptableObject.CreateInstance<UnlockShitEffect>();
            unlock.AddThis(LootFour.Nine);
            enemy.exitEffects = new Effect[]
            {
                new Effect(itsover, 1, null, Slots.Self),
                new Effect((EffectSO) unlock, 0, new IntentType?(), Slots.Self)
            };
            enemy.AddEnemy();
        }
    }
}
