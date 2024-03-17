using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace ExampleNamespace
{
    public static class WitheringFix
    {
        public static void Setup()
        {
            EnemySO he = LoadedAssetsHandler.GetEnemy("InHisImage_EN");
            EnemySO sh = LoadedAssetsHandler.GetEnemy("InHerImage_EN");
            ForbiddenFruitPassiveAbility his = null;
            ForbiddenFruitPassiveAbility her = null;
            foreach (BasePassiveAbilitySO passive in he.passiveAbilities)
                if (passive is ForbiddenFruitPassiveAbility forb) his = forb;
            foreach (BasePassiveAbilitySO passive in sh.passiveAbilities)
                if (passive is ForbiddenFruitPassiveAbility forb) her = forb;
            if (his != null)
                his.TriggerEffects[0].effect = ScriptableObject.CreateInstance<NoWitherForbiddenFruitEffect>();
            if (her != null)
                her.TriggerEffects[0].effect = ScriptableObject.CreateInstance<NoWitherForbiddenFruitEffect>();
        }
    }
    public class NoWitherForbiddenFruitEffect : EffectSO
    {
        public bool SilentDeath(EnemyCombat self, IUnit killer, bool obliteration = false)
        {
            if (!self.CanBeInstaKilled)
            {
                return false;
            }

            int currentHealth = self.CurrentHealth;
            self.CurrentHealth = 0;
            CombatManager.Instance.AddUIAction(new EnemyDamagedUIAction(self.ID, self.CurrentHealth, self.MaximumHealth, currentHealth, DamageType.Weak));
            CombatManager.Instance.AddSubAction(new WitherlessEnemyDeathAction(self.ID, killer, DeathType.DirectDeath));
            return true;
        }

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i].HasUnit && targets[i].Unit is EnemyCombat enemy)
                {
                    if (SilentDeath(enemy, null, false))
                        exitAmount++;
                }
            }

            return exitAmount > 0;
        }
    }
    public class WitherlessEnemyDeathAction : CombatAction
    {
        public int _enemyID;

        public IUnit _killer;

        public DeathType _deathType;

        public WitherlessEnemyDeathAction(int enemyID, IUnit killer, DeathType deathType)
        {
            _enemyID = enemyID;
            _killer = killer;
            _deathType = deathType;
        }

        public override IEnumerator Execute(CombatStats stats)
        {
            EnemyCombat enemyCombat = stats.TryGetEnemyOnField(_enemyID);
            if (enemyCombat != null && (!enemyCombat.IsAlive || enemyCombat.CurrentHealth <= 0) && enemyCombat.CanUnitDie)
            {
                DeathReference deathReference = new DeathReference(_killer, witheringDeath: false);
                enemyCombat.EnemyDeath(deathReference, _deathType);
                CombatManager.Instance.AddUIAction(new EnemyDeathUIAction(enemyCombat.ID, playDeathSound: true));
                stats.RemoveEnemy(_enemyID);
            }

            yield break;
        }
    }
}
