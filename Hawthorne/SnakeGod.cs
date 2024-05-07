using BrutalAPI;
using FMODUnity;
using MonoMod.RuntimeDetour;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using static Hawthorne.Check;
using System.Reflection;

namespace Hawthorne
{
    public static class SnakeGod
    {
        public static string ID = "SnakeGod";
        public static void Add(int entity)
        {
            GibsFix.Setup();
            Enemy enemy = new Enemy()
            {
                name = "Kyotlokutla",
                health = 144,
                size = 1,
                entityID = (EntityIDs)entity,
                healthColor = Pigments.Yellow,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/group4/" + ID + "/" + ID + "_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
            };
            enemy.prefab.SetDefaultParams();
            enemy.prefab._gibs = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/group4/" + ID + "/" + ID + "_Gibs.prefab").GetComponent<ParticleSystem>();
            enemy.enemyID = "SnakeGod_EN";
            enemy.combatSprite = ResourceLoader.LoadSprite(ID + "Icon.png", 32);
            enemy.overworldAliveSprite = ResourceLoader.LoadSprite(ID + "World.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.overworldDeadSprite = ResourceLoader.LoadSprite(ID + "Dead.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.hurtSound = "event:/Hawthorne/Hurt/XylophoneHit";
            enemy.deathSound = "event:/Hawthorne/Die/XylophoneDie";
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_SnakeGod>();
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passi.SnakeGod, Passives.Formless
            };
            enemy.abilities = new Ability[] { Abili.SilenceFools, Abili.HangWeak, Abili.SuffocatePoor, Abili.ScareFeeble };
            enemy.loot = new EnemyLootItemProbability[]
            {
                new EnemyLootItemProbability() { isItemTreasure = true, amount = 3, probability = 100 }
            };
            UnlockShitEffect unlock = ScriptableObject.CreateInstance<UnlockShitEffect>();
            unlock.AddThis(LootFour.Sign);
            enemy.exitEffects = new Effect[]
            {
                new Effect((EffectSO) unlock, 0, new IntentType?(), Slots.Self)
            };
            enemy.AddEnemy();
        }
    }

    public static class GibsFix
    {
        public static IEnumerator PlayEnemyDeathAnimation(Func<EnemyInFieldLayout, string, IEnumerator> orig, EnemyInFieldLayout self, string deathSound)
        {
            IEnumerator ret = orig(self, deathSound);
            if (CombatManager.Instance._stats.combatUI._enemiesInCombat.TryGetValue(self.EnemyID, out var value))
            {
                if (EnemyExist("SnakeGod_EN") && value.EnemyBase == LoadedAssetsHandler.GetEnemy("SnakeGod_EN"))
                {
                    self.StartCoroutine(self.PlayGibs(0.2f));
                }
                else if (EnemyExist("Skyloft_EN") && value.EnemyBase == LoadedAssetsHandler.GetEnemy("Skyloft_EN"))
                {
                    self.StartCoroutine(self.PlayGibs(0.5f));
                }
                else if (EnemyExist("GreyFlower_EN") && value.EnemyBase == LoadedAssetsHandler.GetEnemy("GreyFlower_EN"))
                {
                    self.StartCoroutine(self.PlayGibs(0.2f));
                }
                else if (EnemyExist("MortalSpoggle_EN") && value.EnemyBase == LoadedAssetsHandler.GetEnemy("MortalSpoggle_EN"))
                {
                    self.StartCoroutine(self.PlayGibs(0.2f));
                }
            }
            return ret;
        }
        public static IEnumerator PlayGibs(this EnemyInFieldLayout layout, float time)
        {
            float gap = time;
            while (gap > 0)
            {
                yield return null;
                gap -= Time.deltaTime;
            }
            layout.SpawnGibs();
            yield return null;
        }

        public static void SpawnGibs(Action<EnemyInFieldLayout> orig, EnemyInFieldLayout self)
        {
            if (CombatManager.Instance._stats.combatUI._enemiesInCombat.TryGetValue(self.EnemyID, out var value))
            {
                if (EnemyExist("WindSong_EN") && value.EnemyBase == LoadedAssetsHandler.GetEnemy("WindSong_EN") && value.CurrentHealth > 0)
                {
                    if (self._gibs != null)
                    {
                        UnityEngine.Object.Instantiate(self._gibs, self.transform.position, self.transform.rotation);
                        return;
                    }
                }
                if (EnemyExist("TheDragon_EN") && value.EnemyBase == LoadedAssetsHandler.GetEnemy("TheDragon_EN"))
                {
                    if (self._gibs != null && self._animator.GetBool("Awake"))
                    {
                        UnityEngine.Object.Instantiate(self._gibs, self.transform.position, self.transform.rotation);
                        return;
                    }
                    else
                    {
                        UnityEngine.Object.Instantiate(Dragon.Green, self.transform.position, self.transform.rotation);
                        return;
                    }
                }
            }
            orig(self);
        }

        public static IEnumerator PlayEnemyFleetingAnimation(Func<EnemyZoneHandler, int, string, UnitExitType, IEnumerator> orig, EnemyZoneHandler self, int fieldID, string enemySound, UnitExitType exitType)
        {
            if (CombatManager.Instance._stats.combatUI._enemiesInCombat.TryGetValue(self._enemies[fieldID].FieldEntity.EnemyID, out var value))
            {
                if (EnemyExist("Butterfly_EN") && value.EnemyBase == LoadedAssetsHandler.GetEnemy("Butterfly_EN"))
                {
                    Vector3 fieldPosition = self._enemies[fieldID].FieldPosition;
                    self._unitSoundsHandler.PlayExitEvent(fieldPosition, exitType);

                    yield return self._enemies[fieldID].FieldEntity.PlayFleeting();
                }
                else yield return orig(self, fieldID, enemySound, exitType);
            }
            else yield return orig(self, fieldID, enemySound, exitType);
        }

        public static void Setup()
        {
            IDetour hook = new Hook(typeof(EnemyInFieldLayout).GetMethod(nameof(EnemyInFieldLayout.PlayEnemyDeathAnimation), ~BindingFlags.Default), typeof(GibsFix).GetMethod(nameof(PlayEnemyDeathAnimation), ~BindingFlags.Default));
            IDetour hack = new Hook(typeof(EnemyInFieldLayout).GetMethod(nameof(EnemyInFieldLayout.SpawnGibs), ~BindingFlags.Default), typeof(GibsFix).GetMethod(nameof(SpawnGibs), ~BindingFlags.Default));
            IDetour rock = new Hook(typeof(EnemyZoneHandler).GetMethod(nameof(EnemyZoneHandler.PlayEnemyFleetingAnimation), ~BindingFlags.Default), typeof(GibsFix).GetMethod(nameof(PlayEnemyFleetingAnimation), ~BindingFlags.Default));
        }
    }
}
