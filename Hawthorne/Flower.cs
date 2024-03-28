using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using BepInEx;
using BepInEx.Bootstrap;
using BrutalAPI;
using UnityEngine;
using UnityEngine.UIElements;
using MonoMod.RuntimeDetour;
using JetBrains.Annotations;
using System.Text;
using System.Threading;
using System.Runtime.CompilerServices;
using Tools;
using UnityEngine.SceneManagement;
using System.Timers;
using UnityEngine.Diagnostics;
using UnityEngine.UI;
using System.Xml;
using System.Dynamic;
using static UnityEngine.EventSystems.EventTrigger;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;
using static System.Net.WebRequestMethods;
using EnemyPack;

namespace Hawthorne
{
    public static class Flower
    {
        public static void Add()
        {
            Enemy angler = new Enemy()
            {
                name = "A 'Flower'",
                health = 18,
                size = 1,
                entityID = (EntityIDs)544523,
                healthColor = Pigments.Red,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/Senis3/Angler_Enemy.prefab").AddComponent<MultiSpriteEnemyLayout>()
            };
            angler.prefab._gibs = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/Senis3/Angler_Gibs.prefab").GetComponent<ParticleSystem>();
            angler.prefab.SetDefaultParams();
            (angler.prefab as MultiSpriteEnemyLayout).OtherRenderers = new SpriteRenderer[]
            {
                angler.prefab._locator.transform.Find("Sprite").Find("body").GetChild(0).GetChild(0).GetChild(0).GetComponent<SpriteRenderer>(),
            };
            angler.combatSprite = ResourceLoader.LoadSprite("AnglerIconB", 32);
            angler.overworldAliveSprite = ResourceLoader.LoadSprite("AnglerIcon", 32, new Vector2?(new Vector2(0.5f, 0.05f)));
            angler.overworldDeadSprite = ResourceLoader.LoadSprite("AnglerDead", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            angler.hurtSound = LoadedAssetsHandler.GetEnemy("Voboola_EN").damageSound;
            angler.deathSound = LoadedAssetsHandler.GetEnemy("Voboola_EN").deathSound;
            angler.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            angler.passives = new BasePassiveAbilitySO[2]
            {
                Passives.Fleeting,
                LoadedAssetsHandler.GetEnemy("Xiphactinus_EN").passiveAbilities[1]
                
            };
            angler.unitType = UnitType.Fish;

            HealEffect putNAME = ScriptableObject.CreateInstance<HealEffect>();
            putNAME.usePreviousExitValue = true;
            AnimationVisualsEffect talons = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            talons._animationTarget = Slots.Right;
            talons._visuals = LoadedAssetsHandler.GetEnemyAbility("Talons_A").visuals;
            AnimationVisualsEffect talons2 = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            talons2._animationTarget = Slots.Left;
            talons2._visuals = LoadedAssetsHandler.GetEnemyAbility("Talons_A").visuals;
            AnimationVisualsEffect headshot = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            headshot._animationTarget = Slots.Right;
            headshot._visuals = LoadedAssetsHandler.GetEnemy("TriggerFingers_BOSS").abilities[0].ability.visuals;
            AnimationVisualsEffect headshot2 = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            headshot2._animationTarget = Slots.Left;
            headshot2._visuals = LoadedAssetsHandler.GetEnemy("TriggerFingers_BOSS").abilities[0].ability.visuals;
            PreviousEffectCondition didntThat = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            didntThat.wasSuccessful = false;
            PreviousEffectCondition didThat = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            didThat.wasSuccessful = true;
            IfConstrictingAnimationVisualsEffect chomp = ScriptableObject.CreateInstance<IfConstrictingAnimationVisualsEffect>();
            chomp._visuals = LoadedAssetsHandler.GetEnemyAbility("Chomp_A").visuals;
            chomp._animationTarget = Slots.Front;
            Ability catching = new Ability();
            catching.name = "Catch";
            catching.description = "If the opposing party member is Constricted, deal an Agonizing damage to them. \nThen, move this enemy to a random position and apply 4 Stunned to it.";
            catching.rarity = 3;
            catching.effects = new Effect[4];
            catching.effects[0] = new Effect(chomp, 1, new IntentType?(), Slots.Self);
            catching.effects[1] = new Effect(ScriptableObject.CreateInstance<DamageIfConstrictedEffect>(), 8, IntentType.Damage_7_10, Slots.Front);
            catching.effects[2] = new Effect(ScriptableObject.CreateInstance<SwapRandomZoneEffectHideIntent>(), 1, IntentType.Swap_Mass, Slots.Self, didThat);
            catching.effects[3] = new Effect(ScriptableObject.CreateInstance<ApplyStunnedEffect>(), 4, new IntentType?((IntentType)988896), Slots.Self, didThat);
            catching.visuals = null;
            catching.animationTarget = Slots.Self;

            Targetting_ByUnit_Side allAlly = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            allAlly.getAllUnitSlots = false;
            allAlly.getAllies = true;
            SwapToOneSideEffect goLeft = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            goLeft._swapRight = false;
            SwapToOneSideEffect goRight = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            goRight._swapRight = true;

            Ability baiting = new Ability();
            baiting.name = "Allure";
            baiting.description = "Move all party members closer to this enemy. Apply 3 Constricted to the opposing position if there is a party member there.";
            baiting.rarity = 3;
            baiting.effects = new Effect[11];
            baiting.effects[0] = new Effect(goRight, 1, new IntentType?(), Slots.SlotTarget(new int[1] { -1 }, false));
            baiting.effects[1] = new Effect(goRight, 1, new IntentType?(), Slots.SlotTarget(new int[1] { -2 }, false));
            baiting.effects[2] = new Effect(goRight, 1, new IntentType?(), Slots.SlotTarget(new int[1] { -3 }, false));
            baiting.effects[3] = new Effect(goRight, 1, new IntentType?(), Slots.SlotTarget(new int[1] { -4 }, false));
            baiting.effects[4] = new Effect(goLeft, 1, new IntentType?(), Slots.SlotTarget(new int[1] { 1 }, false));
            baiting.effects[5] = new Effect(goLeft, 1, new IntentType?(), Slots.SlotTarget(new int[1] { 2 }, false));
            baiting.effects[6] = new Effect(goLeft, 1, new IntentType?(), Slots.SlotTarget(new int[1] { 3 }, false));
            baiting.effects[7] = new Effect(goLeft, 1, new IntentType?(), Slots.SlotTarget(new int[1] { 4 }, false));
            baiting.effects[10] = new Effect(ScriptableObject.CreateInstance<IfTargetApplyConstrictedSlotEffect>(), 3, IntentType.Field_Constricted, Slots.Front);
            baiting.effects[8] = new Effect(ScriptableObject.CreateInstance<ExitValueSetterEffect>(), 10, IntentType.Swap_Right, Slots.SlotTarget(new int[4] { -1, -2, -3, -4 }, false));
            baiting.effects[9] = new Effect(ScriptableObject.CreateInstance<ExitValueSetterEffect>(), 10, IntentType.Swap_Left, Slots.SlotTarget(new int[4] { 1, 2, 3, 4 }, false));
            baiting.visuals = CustomVisuals.GetVisuals("Salt/Rose");
            baiting.animationTarget = Slots.Self;
            angler.passives[1] = UnityEngine.Object.Instantiate<BasePassiveAbilitySO>(angler.passives[1]);
            angler.passives[1]._passiveName = "Allure";
            angler.passives[1]._enemyDescription = "A 'Flower' will perforn an extra ability \"Allure\" each turn.";
            ((ExtraAttackPassiveAbility)angler.passives[1])._extraAbility.ability = baiting.EnemyAbility().ability;

            angler.abilities = new Ability[1] { catching };
            angler.AddEnemy();
        }
    }
    public class IfConstrictingAnimationVisualsEffect : EffectSO
    {
        [Header("Visual")]
        [SerializeField]
        public AttackVisualsSO _visuals;

        [SerializeField]
        public BaseCombatTargettingSO _animationTarget;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            if (!(stats.combatSlots.SlotContainsSlotStatusEffect(caster.SlotID, true, SlotStatusEffectType.Constricted)))
            {
                exitAmount = 0;
                return false;
            }
            CombatManager.Instance.AddUIAction(new PlayAbilityAnimationAction(_visuals, _animationTarget, caster));
            exitAmount = 0;
            return true;
        }
    }
    public class DamageIfConstrictedEffect : EffectSO
    {
        [SerializeField]
        public DeathType _deathType = DeathType.Basic;

        [SerializeField]
        public bool _usePreviousExitValue;

        [SerializeField]
        public bool _ignoreShield;

        [SerializeField]
        public bool _indirect;

        [SerializeField]
        public bool _returnKillAsSuccess;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            
            if (_usePreviousExitValue)
            {
                entryVariable *= base.PreviousExitValue;
            }

            exitAmount = 0;
            bool flag = false;
            if (!(stats.combatSlots.SlotContainsSlotStatusEffect(caster.SlotID, true, SlotStatusEffectType.Constricted)))
            {
                return flag;
            }
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (targetSlotInfo.HasUnit)
                {
                    int targetSlotOffset = (areTargetSlots ? (targetSlotInfo.SlotID - targetSlotInfo.Unit.SlotID) : (-1));
                    int amount = entryVariable;
                    DamageInfo damageInfo;
                    if (_indirect)
                    {
                        damageInfo = targetSlotInfo.Unit.Damage(amount, null, _deathType, targetSlotOffset, addHealthMana: false, directDamage: false, ignoresShield: true);
                    }
                    else
                    {
                        amount = caster.WillApplyDamage(amount, targetSlotInfo.Unit);
                        damageInfo = targetSlotInfo.Unit.Damage(amount, caster, _deathType, targetSlotOffset, addHealthMana: true, directDamage: true, _ignoreShield);
                    }

                    flag |= damageInfo.beenKilled;
                    exitAmount += damageInfo.damageAmount;
                }
            }

            if (!_indirect && exitAmount > 0)
            {
                caster.DidApplyDamage(exitAmount);
            }

            if (!_returnKillAsSuccess)
            {
                return exitAmount > 0;
            }

            return flag;
        }
    }
    public class ResetFleetingEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            caster.SetStoredValue(UnitStoredValueNames.FleetingPA, 0);
            caster.SetStoredValue(UnitStoredValueNames.FleetingPA_IgnoreFirstTurn, 0);
            exitAmount = 0;
            return true;
        }
    }
    public class SwapRandomZoneEffectHideIntent : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            Effect move = new Effect(ScriptableObject.CreateInstance<SwapToRandomZoneEffect>(), 6, IntentType.Swap_Mass, Slots.SlotTarget(new int[9] { -4, -3, -2, -1, 0, 1, 2, 3, 4 }, true));
            CombatManager.Instance.AddPrioritySubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { move }), caster));
            exitAmount = 0;
            return true;
        }
    }
    public class IfTargetApplyConstrictedSlotEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (entryVariable <= 0)
            {
                return false;
            }

            stats.slotStatusEffectDataBase.TryGetValue(SlotStatusEffectType.Constricted, out var value);
            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i].HasUnit)
                {
                    Constricted_SlotStatusEffect constricted_SlotStatusEffect = new Constricted_SlotStatusEffect(targets[i].SlotID, entryVariable);
                    constricted_SlotStatusEffect.SetEffectInformation(value);
                    if (stats.combatSlots.ApplySlotStatusEffect(targets[i].SlotID, targets[i].IsTargetCharacterSlot, entryVariable, constricted_SlotStatusEffect))
                    {
                        exitAmount += entryVariable;
                    }
                }
            }

            return exitAmount > 0;
        }
    }
    public class ExitValueSetterEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = entryVariable;
            return exitAmount > 0;
        }
    }
}
