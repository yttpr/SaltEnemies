using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Hawthorne
{
    public static class Tank
    {
        public static string ID = "Tank";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "Semi-Realistic Tank",
                health = 42,
                size = 2,
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
            enemy.hurtSound = "event:/Hawthorne/Hurt/TankHit";
            enemy.deathSound = "event:/Hawthorne/Die/TankDie";
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passives.Skittish, Passives.Forgetful, Passi.Steel, Passi.ColdBlood, Passi.Warning
            };
            enemy.abilities = new Ability[] { Abili.Bloat, Abili.Gross, Abili.Coarse };
            enemy.enemyID = "RealisticTank_EN";
            enemy.AddEnemy();
        }
    }
    public static class TankHandler
    {
        public static PerformRandomEffectsSpecificAmongEffects BadStatus;
        public static void Setup()
        {
            BadStatus = ScriptableObject.CreateInstance<PerformRandomEffectsSpecificAmongEffects>();
            BadStatus.List = new Dictionary<string, string[]>();
            BadStatus.List.Add(nameof(ApplyScarsEffect), new string[0]);
            BadStatus.List.Add(nameof(ApplyFrailEffect), new string[0]);
            BadStatus.List.Add(nameof(ApplyRupturedEffect), new string[0]);
            BadStatus.List.Add(nameof(ApplyOilSlickedEffect), new string[0]);
            BadStatus.List.Add(nameof(ApplyCursedEffect), new string[0]);
            BadStatus.List.Add(nameof(ApplyGuttedEffect), new string[0]);
            BadStatus.List.Add(nameof(ApplyDivineProtectionEffect), new string[0]);
            BadStatus.List.Add(nameof(ApplyLinkedEffect), new string[0]);
            BadStatus.List.Add("ApplyContagionEffect", new string[] { "MizerFool.Effects" });
            BadStatus.List.Add("ApplyMarkedEffect", new string[] { "TairbazFools.Effects" });
            BadStatus.List.Add("ApplyGloomEffect", new string[] { "THE_DEAD" });
            BadStatus.List.Add("ApplyPaleByTenEffect", new string[] { "Hawthorne" });
            BadStatus.List.Add("ApplyMutedEffect", new string[] { "Hawthorne" });
            BadStatus.List.Add("ApplyInvertedEffect", new string[] { "Hawthorne" });
            BadStatus.List.Add("ApplyLeftEffect", new string[] { "Hawthorne" });
            BadStatus.List.Add("ApplyDrowningEffect", new string[] { "Hawthorne" });
            BadStatus.List.Add("ApplyPimplesEffect", new string[] { "Hawthorne" });
            BadStatus.List.Add("ApplyAcidEffect", new string[] { "PYMN4", "Unstoppable_Force" });
            BadStatus.List.Add("ApplyTargetSwapEffect", new string[] { "BOSpecialItems.Content.Effects" });
            BadStatus.List.Add("ApplyWeakenedEffect", new string[] { "BOSpecialItems.Content.Effects" });
            BadStatus.List.Add("ApplyRemorseEffect", new string[] { "MarmoEnemies" });
            BadStatus.List.Add("ApplySpottedEffect", new string[] { "Cast_of_Fools.Effects" });
            BadStatus.Specific = true;
            BadStatus.Setup();
        }
    }

    public class PerformRandomEffectsSpecificAmongEffects : EffectSO
    {
        public Dictionary<string, string[]> List;
        public bool UsePreviousExitValueForNewEntry;
        public List<EffectSO> Effects;
        public static List<PerformRandomEffectsSpecificAmongEffects> Selves = new List<PerformRandomEffectsSpecificAmongEffects>();
        public bool Specific;
        public static void GO()
        {
            foreach (PerformRandomEffectsSpecificAmongEffects effect in Selves) effect.Actually();
        }
        public void Setup()
        {
            Selves.Add(this);
            Actually();
        }
        public void Actually()
        {
            if (List == null) return;
            if (Effects == null) Effects = new List<EffectSO>();
            Type[] types = AnExtension.GetAllDerived(typeof(EffectSO));
            List<string> remove = new List<string>();
            foreach (string name in List.Keys)
            {
                bool skip = false;
                foreach (EffectSO e in Effects) if (e.GetType().Name == name) { skip = true; break; }
                if (skip)
                {
                    UnityEngine.Debug.LogWarning("already has " + name);
                    continue;
                }
                List<Type> test = new List<Type>();
                foreach (Type type in types)
                {
                    /*if (type.Name.Contains(name) || name.Contains(type.Name))
                    {
                        Debug.Log("found near : " + type.Name + " , " + type.Namespace); 
                    }*/
                    if (type.Name == name)
                    {
                        //Debug.Log(type.Namespace);
                        if (Specific)
                        {
                            if (List[name].Contains(type.Namespace)) test.Add(type);
                            if (List[name].Length <= 0)
                            {
                                test.Add(type);
                                break;
                            }
                        }
                        else
                        {
                            if (List[name].Contains("PrayerFool_BOMOD") || type.Namespace != "PrayerFool_BOMOD") test.Add(type);
                            if (List[name].Length <= 0) break;
                            else if (List[name].Contains(type.Namespace)) break;
                        }
                    }
                }
                if (test.Count > 0)
                {
                    Effects.Add(ScriptableObject.CreateInstance(test[test.Count - 1]) as EffectSO);
                    remove.Add(name);
                    Debug.Log("added effectSO " + name + " from " + test[test.Count - 1].Namespace);
                }
            }
            foreach (string g in remove) List.Remove(g);
        }
        public EffectSO GrabRand()
        {
            if (Effects == null || Effects.Count <= 0) return null;
            return Effects[UnityEngine.Random.Range(0, Effects.Count)];
        }
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            int effectsRan = 0;
            if (Effects == null || Effects.Count <= 0) return false;
            foreach (TargetSlotInfo target in targets)
            {
                for (int i = 0; i < entryVariable; i++)
                {
                    try
                    {
                        EffectSO run = GrabRand();
                        if (run != null)
                        {
                            if (run.PerformEffect(stats, caster, new TargetSlotInfo[] { target }, areTargetSlots, UsePreviousExitValueForNewEntry ? PreviousExitValue : 1, out int exi))
                                exitAmount += exi;
                            effectsRan++;
                        }
                    }
                    catch
                    {
                        Debug.LogError("of course its fucking this");
                    }
                }
            }
            return effectsRan > 0;
        }
    }
}
