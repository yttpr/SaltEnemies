using BrutalAPI;
using UnityEngine;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;
using static UnityEngine.GraphicsBuffer;
using THE_DEAD;
using ChillyBonezMod;
using MizerFool.Effects;
using MFoolModOne;
using TairbazFools.Effects;
using DigiMisfits;

namespace Hawthorne.NewFolder
{
    public class TotallyRandomStatusEffectEffect : EffectSO
    {
        EffectSO randomStatusEffect()
        {
            EffectSO returnIt = ScriptableObject.CreateInstance<ApplyStatusEffectStatusEffectEffect>();
            int choosing = UnityEngine.Random.Range(0, 44);
            switch (choosing)
            {
                case 0: returnIt = ScriptableObject.CreateInstance<ApplyMutedEffect>(); break;
                case 1: returnIt = ScriptableObject.CreateInstance<ApplyInvertedEffect>(); break;
                case 2: returnIt = ScriptableObject.CreateInstance<ApplyUnStitchedEffect>(); break;
                case 3: returnIt = ScriptableObject.CreateInstance<ApplyEntropyEffect>(); break;
                case 4: returnIt = ScriptableObject.CreateInstance<ApplyBleedingEffect>(); break;
                case 5: returnIt = ScriptableObject.CreateInstance<ApplyDivineSacrificeEffect>(); break;
                case 6: returnIt = ScriptableObject.CreateInstance<ApplyFeebleEffect>(); break;
                case 7: returnIt = ScriptableObject.CreateInstance<ApplyPaintAllergyEffect>(); break;
                case 8: returnIt = ScriptableObject.CreateInstance<ApplySinEffect>(); break;
                case 9: returnIt = ScriptableObject.CreateInstance<ApplyAsceticEffect>(); break;
                case 10: returnIt = ScriptableObject.CreateInstance<ApplyDoomEffect>(); break;
                case 11: returnIt = ScriptableObject.CreateInstance<ApplyStatusEffectStatusEffectEffect>(); break;
                case 12: returnIt = ScriptableObject.CreateInstance<ApplyLeftEffect>(); break;
                case 13: returnIt = ScriptableObject.CreateInstance<ApplyContagionEffect>(); break;
                case 14: returnIt = ScriptableObject.CreateInstance<ApplyGrowthEffect>(); break;
                case 15: returnIt = ScriptableObject.CreateInstance<ApplyWildCardEffect>(); break;
                case 16: returnIt = ScriptableObject.CreateInstance<ApplyDemonicProtectionEffect>(); break;
                case 17: returnIt = ScriptableObject.CreateInstance<ApplyMarkedEffect>(); break;
                case 18: returnIt = ScriptableObject.CreateInstance<ApplyInvigoratedEffect>(); break;
                case 19: returnIt = ScriptableObject.CreateInstance<ApplyAdrenalineEffect>(); break;
                case 20: returnIt = ScriptableObject.CreateInstance<ApplyHexedEffect>(); break;
                case 21: returnIt = ScriptableObject.CreateInstance<ApplyAnestheticsEffect>(); break;
                case 22: returnIt = ScriptableObject.CreateInstance<ApplyGloomEffect>(); break;
                case 23: returnIt = ScriptableObject.CreateInstance<ApplyDeterminedEffect>(); break;
                case 24: returnIt = ScriptableObject.CreateInstance<ApplyPowerEffect>(); break;
                case 25: returnIt = ScriptableObject.CreateInstance<ApplySporesEffect>(); break;
                case 26: returnIt = ScriptableObject.CreateInstance<ApplyGuttedEffect>(); break;
                case 27: returnIt = ScriptableObject.CreateInstance<ApplyStunnedEffect>(); break;
                case 28: returnIt = ScriptableObject.CreateInstance<ApplyFocusedEffect>(); break;
                case 29: returnIt = ScriptableObject.CreateInstance<ApplyRupturedEffect>(); break;
                case 30: returnIt = ScriptableObject.CreateInstance<ApplyFrailEffect>(); break;
                case 31: returnIt = ScriptableObject.CreateInstance<ApplyOilSlickedEffect>(); break;
                case 32: returnIt = ScriptableObject.CreateInstance<ApplySpotlightEffect>(); break;
                case 33: returnIt = ScriptableObject.CreateInstance<ApplyCursedEffect>(); break;
                case 34: returnIt = ScriptableObject.CreateInstance<ApplyLinkedEffect>(); break;
                case 35: returnIt = ScriptableObject.CreateInstance<ApplyDivineProtectionEffect>(); break;
                case 36: returnIt = ScriptableObject.CreateInstance<ApplyScarsEffect>(); break;
                case 37: returnIt = ScriptableObject.CreateInstance<ApplyConstrictedSlotEffect>(); break;
                case 38: returnIt = ScriptableObject.CreateInstance<ApplyFireSlotEffect>(); break;
                case 39: returnIt = ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(); break;
                case 40: returnIt = ScriptableObject.CreateInstance<ApplyMoldSlotEffect>(); break;
                case 41: returnIt = ScriptableObject.CreateInstance<RemoveAllStatusEffectsEffect>(); break;
                case 42: returnIt = ScriptableObject.CreateInstance<ApplyPaleEffect>(); break;
                case 43: returnIt = ScriptableObject.CreateInstance<ApplyFavorEffect>(); break;
            }
            return returnIt;
        }

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    int PickIt = UnityEngine.Random.Range(1, 6);
                    Effect statusIt = new Effect(randomStatusEffect(), PickIt, null, Slots.Self);
                    CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { statusIt }), target.Unit));
                }
            }
            return exitAmount > 0;
        }
    }
    public class RandomDamageOrHealEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            DeathType randomDeath()
            {
                if (UnityEngine.Random.Range(0, 10) == 0)
                {
                    return DeathType.Obliteration;
                }
                return DeathType.Basic;
            }
            bool randomBool()
            {
                if (UnityEngine.Random.Range(0, 2) == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            exitAmount = 0;
            int healAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    int targetSlotOffset = (areTargetSlots ? (target.SlotID - target.Unit.SlotID) : (-1));
                    int amount = UnityEngine.Random.Range(0, 8);
                    if (randomBool())
                    {
                        DamageInfo damageInfo;
                        amount = caster.WillApplyDamage(amount, target.Unit);
                        damageInfo = target.Unit.Damage(amount, caster, randomDeath(), targetSlotOffset, randomBool(), randomBool(), randomBool());
                        exitAmount += damageInfo.damageAmount;
                    }
                    else
                    {
                        healAmount += target.Unit.Heal(amount, HealType.Heal, randomBool());
                    }
                }
            }
            caster.DidApplyDamage(exitAmount);
            exitAmount += healAmount;
            return exitAmount > 0;
        }
    }
    public class SpawnMyRandomEnemiesAnywhereEffect : EffectSO
    {
        public EnemySO randomEnemy()
        {
            string enemy = "DeadPixel_EN";
            int choosing = UnityEngine.Random.Range(0, 51);
            switch (choosing)
            {
                case 0: enemy = "DeadPixel_EN"; break;
                case 1: enemy = "LostSheep_EN"; break;
                case 2: enemy = "Enigma_EN"; break;
                case 3: enemy = "TheCrow_EN"; break;
                case 4: enemy = "Freud_EN"; break;
                case 5: enemy = "A'Flower'_EN"; break;
                case 6: enemy = "MortalSpoggle_EN"; break;
                case 7: enemy = "RusticJumbleguts_EN"; break;
                case 8: enemy = "Bronzo_Bananas_Friendly_EN"; break;
                case 9: enemy = "HickoryFire_BOSS"; break;
                case 10: enemy = "StarGazer_EN"; break;
                case 11: enemy = "JumbleGuts_Flummoxing_EN"; break;
                case 12: enemy = "ChoirBoy_EN"; break;
                case 13: enemy = "LittleAngel_EN"; break;
                case 14: enemy = "Satyr_EN"; break;
                case 15: enemy = "Spoggle_Ruminating_EN"; break;
                case 16: enemy = "Psaltery_EN"; break;
                case 17: enemy = "Something_EN"; break;
                case 18: enemy = "Derogatory_EN"; break;
                case 19: enemy = "Denial_EN"; break;
                case 20: enemy = "MunglingMudLung_EN"; break;
                case 21: enemy = "Spoggle_Resonant_EN"; break;
                case 22: enemy = "Goa_EN"; break;
                case 23: enemy = "HeavensGateYellow_BOSS"; break;
                case 24: enemy = "Bronzo_MoneyPile_EN"; break;
                case 25: enemy = "MechanicalLens_EN"; break;
                case 26: enemy = "ClockTower_EN"; break;
                case 27: enemy = "Grandfather_EN"; break;
                case 28: enemy = "Damocles_EN"; break;
                case 29: enemy = "Firebird_EN"; break;
                case 30: enemy = "GlassFigurine_EN"; break;
                case 31: enemy = "Hunter_EN"; break;
                case 32: enemy = "Medamaude_EN"; break;
                case 33: enemy = "Merced_EN"; break;
                case 34: enemy = "Miriam_EN"; break;
                case 35: enemy = "Nameless_EN"; break;
                case 36: enemy = "RedFlower_EN"; break;
                case 37: enemy = "BlueFlower_EN"; break;
                case 38: enemy = "YellowFlower_EN"; break;
                case 39: enemy = "PurpleFlower_EN"; break;
                case 40: enemy = "GreyFlower_EN"; break;
                case 41: enemy = "Lyssa_EN"; break;
                case 42: enemy = "MiniReaper_EN"; break;
                case 43: enemy = "Shua_EN"; break;
                case 44: enemy = "Sigil_EN"; break;
                case 45: enemy = "Skyloft_EN"; break;
                case 46: enemy = "LivingSolvent_EN"; break;
                case 47: enemy = "RealisticTank_EN"; break;
                case 48: enemy = "TripodFish_EN"; break;
                case 49: enemy = "Warbird_EN"; break;
                case 50: enemy = "WindSong_EN"; break;
            }
            if (!Check.EnemyExist(enemy)) enemy = "DeadPixel_EN";
            return LoadedAssetsHandler.GetEnemy(enemy);
        }

        public bool givesExperience;

        [SerializeField]
        public SpawnType _spawnType = SpawnType.Basic;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            for (int i = 0; i < entryVariable; i++)
            {
                CombatManager.Instance.AddSubAction(new SpawnEnemyAction(randomEnemy(), -1, givesExperience, trySpawnAnyways: false, _spawnType));
            }

            exitAmount = entryVariable;
            return true;
        }
    }
    public class DoShitEffect : EffectSO
    {
        EffectSO EffectOrHit()
        {
            if (UnityEngine.Random.Range(0, 3) == 0)
            {
                return ScriptableObject.CreateInstance<RandomDamageOrHealEffect>();
            }
            return ScriptableObject.CreateInstance<TotallyRandomStatusEffectEffect>();
        }
        
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            for (int i = 0; i < 5; i++)
            {
                GenericTargetting_BySlot_Index thisFucker = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
                thisFucker.slotPointerDirections = new int[] { i };
                thisFucker.getAllies = true;
                Effect doIt = new Effect(EffectOrHit(), 1, null, thisFucker);
                CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { doIt }), caster));
                exitAmount++;
            }
            for (int i = 0; i < 5; i++)
            {
                GenericTargetting_BySlot_Index thisFucker = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
                thisFucker.slotPointerDirections = new int[] { i };
                thisFucker.getAllies = false;
                Effect doIt = new Effect(EffectOrHit(), 1, null, thisFucker);
                CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { doIt }), caster));
                exitAmount++;
            }

            return exitAmount > 0;
        }
    }
    public class PerformRandomAbilityFromCharacterExceptCertainOnesEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            AbilityDataBase abilityDB = LoadedAssetsHandler.GetAbilityDB();
            if (abilityDB == null || abilityDB.Equals(null))
            {
                return false;
            }

            AbilitySO thisAbility = abilityDB.GetRandomCharacterAbilities(1).ToArray()[0];
            int i = 0;
            while (i > -1)
            {
                if (thisAbility == LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A"))
                {
                    thisAbility = abilityDB.GetRandomCharacterAbilities(1).ToArray()[0];
                    Debug.Log("rerolled");
                }
                else if (thisAbility == LoadedAssetsHandler.GetCharacterAbility("Eviscerate_2_A"))
                {
                    thisAbility = abilityDB.GetRandomCharacterAbilities(1).ToArray()[0];
                    Debug.Log("rerolled");
                }
                else if (thisAbility == LoadedAssetsHandler.GetCharacterAbility("Eviscerate_3_A"))
                {
                    thisAbility = abilityDB.GetRandomCharacterAbilities(1).ToArray()[0];
                    Debug.Log("rerolled");
                }
                else if (thisAbility == LoadedAssetsHandler.GetCharacterAbility("Eviscerate_4_A"))
                {
                    thisAbility = abilityDB.GetRandomCharacterAbilities(1).ToArray()[0];
                    Debug.Log("rerolled");
                }
                else if (thisAbility == LoadedAssetsHandler.GetCharacterAbility("Exit_1_A"))
                {
                    thisAbility = abilityDB.GetRandomCharacterAbilities(1).ToArray()[0];
                    Debug.Log("rerolled");
                }
                else if (thisAbility == LoadedAssetsHandler.GetCharacterAbility("Exit_2_A"))
                {
                    thisAbility = abilityDB.GetRandomCharacterAbilities(1).ToArray()[0];
                    Debug.Log("rerolled");
                }
                else if (thisAbility == LoadedAssetsHandler.GetCharacterAbility("Exit_3_A"))
                {
                    thisAbility = abilityDB.GetRandomCharacterAbilities(1).ToArray()[0];
                }
                else if (thisAbility == LoadedAssetsHandler.GetCharacterAbility("Exit_4_A"))
                {
                    thisAbility = abilityDB.GetRandomCharacterAbilities(1).ToArray()[0];
                    Debug.Log("rerolled");
                }
                else if (thisAbility == LoadedAssetsHandler.GetCharacterAbility("Exit_1_A"))
                {
                    thisAbility = abilityDB.GetRandomCharacterAbilities(1).ToArray()[0];
                    Debug.Log("rerolled");
                }
                else if (thisAbility == LoadedAssetsHandler.GetCharacterAbility("OfDeath_1_A"))
                {
                    thisAbility = abilityDB.GetRandomCharacterAbilities(1).ToArray()[0];
                    Debug.Log("rerolled");
                }
                else if (thisAbility == LoadedAssetsHandler.GetCharacterAbility("OfDeath_2_A"))
                {
                    thisAbility = abilityDB.GetRandomCharacterAbilities(1).ToArray()[0];
                    Debug.Log("rerolled");
                }
                else if (thisAbility == LoadedAssetsHandler.GetCharacterAbility("OfDeath_3_A"))
                {
                    thisAbility = abilityDB.GetRandomCharacterAbilities(1).ToArray()[0];
                    Debug.Log("rerolled");
                }
                else if (thisAbility == LoadedAssetsHandler.GetCharacterAbility("OfDeath_4_A"))
                {
                    thisAbility = abilityDB.GetRandomCharacterAbilities(1).ToArray()[0];
                    Debug.Log("rerolled");
                }
                else if (thisAbility == LoadedAssetsHandler.GetCharacterAbility("Symbiosis_1_A"))
                {
                    thisAbility = abilityDB.GetRandomCharacterAbilities(1).ToArray()[0];
                    Debug.Log("rerolled");
                }
                else if (thisAbility == LoadedAssetsHandler.GetCharacterAbility("Symbiosis_2_A"))
                {
                    thisAbility = abilityDB.GetRandomCharacterAbilities(1).ToArray()[0];
                    Debug.Log("rerolled");
                }
                else if (thisAbility == LoadedAssetsHandler.GetCharacterAbility("Symbiosis_3_A"))
                {
                    thisAbility = abilityDB.GetRandomCharacterAbilities(1).ToArray()[0];
                    Debug.Log("rerolled");
                }
                else if (thisAbility == LoadedAssetsHandler.GetCharacterAbility("Symbiosis_4_A"))
                {
                    thisAbility = abilityDB.GetRandomCharacterAbilities(1).ToArray()[0];
                    Debug.Log("rerolled");
                }
                else
                {
                    i = -100;
                    Debug.Log("A Okay");
                }
            }

            if (caster.TryPerformRandomAbility(thisAbility))
                exitAmount++;

            return exitAmount > 0;
        }
    }
    public class AddPhase1Effect : EffectSO
    {
        
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (!Phase1.added)
                Phase1.Add();
            SpawnEnemyAnywhereEffect bossItUp = ScriptableObject.CreateInstance<SpawnEnemyAnywhereEffect>();
            bossItUp.enemy = LoadedAssetsHandler.GetEnemy("544517_EN");
            Effect spawnIt = new Effect(bossItUp, 1, null, Slots.Self);
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { spawnIt }), caster));
            return exitAmount > 0;
        }
    }
    public class AddPhase2Effect : EffectSO
    {

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (!Phase2.added)
                Phase2.Add();
            SpawnEnemyAnywhereEffect bossItUp = ScriptableObject.CreateInstance<SpawnEnemyAnywhereEffect>();
            bossItUp.enemy = LoadedAssetsHandler.GetEnemy("544516_EN");
            Effect spawnIt = new Effect(bossItUp, 1, null, Slots.Self);
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { spawnIt }), caster));
            return exitAmount > 0;
        }
    }
    public class AddPhase3Effect : EffectSO
    {

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (!Phase3.added)
                Phase3.Add();
            SpawnEnemyAnywhereEffect bossItUp = ScriptableObject.CreateInstance<SpawnEnemyAnywhereEffect>();
            bossItUp.enemy = LoadedAssetsHandler.GetEnemy("544515_EN");
            Effect spawnIt = new Effect(bossItUp, 1, null, Slots.Self);
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { spawnIt }), caster));
            return exitAmount > 0;
        }
    }
    public class AddPhase4Effect : EffectSO
    {

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (!Phase4.added)
                Phase4.Add();
            SpawnEnemyAnywhereEffect bossItUp = ScriptableObject.CreateInstance<SpawnEnemyAnywhereEffect>();
            bossItUp.enemy = LoadedAssetsHandler.GetEnemy("544514_EN");
            Effect spawnIt = new Effect(bossItUp, 1, null, Slots.Self);
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { spawnIt }), caster));
            return exitAmount > 0;
        }
    }
    public class AddPhase5Effect : EffectSO
    {

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (!Phase5.added)
                Phase5.Add();
            SpawnEnemyAnywhereEffect bossItUp = ScriptableObject.CreateInstance<SpawnEnemyAnywhereEffect>();
            bossItUp.enemy = LoadedAssetsHandler.GetEnemy("544513_EN");
            Effect spawnIt = new Effect(bossItUp, 1, null, Slots.Self);
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { spawnIt }), caster));
            return exitAmount > 0;
        }
    }
}
