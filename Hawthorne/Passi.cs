using BrutalAPI;
using FMOD;
using FMODUnity;
using Hawthorne.NewFolder;
using MonoMod.RuntimeDetour;
using PYMN4;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using THE_DEAD;
using Tools;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn;
using Yarn.Unity;
using static UnityEngine.UI.CanvasScaler;

namespace Hawthorne
{
    public static class Passi
    {
        public static BasePassiveAbilitySO Fleeting(int amount)
        {
            FleetingPassiveAbility baseParent = Passives.Fleeting as FleetingPassiveAbility;
            FleetingPassiveAbility flee = ScriptableObject.Instantiate<FleetingPassiveAbility>(baseParent);
            flee._passiveName = "Fleeting (" + amount.ToString() + ")";
            flee._characterDescription = "After " + amount.ToString() + " rounds this party member will flee... Coward.";
            flee._enemyDescription = "After " + amount.ToString() + " rounds this enemy will flee.";
            flee._turnsBeforeFleeting = amount;
            return flee;
        }
        public static BasePassiveAbilitySO Overexert(int amount)
        {
            IntegerReferenceOverEqualValueEffectorCondition instance = ScriptableObject.CreateInstance<IntegerReferenceOverEqualValueEffectorCondition>();
            instance.compareValue = amount;
            BasePassiveAbilitySO baseParent = LoadedAssetsHandler.GetEnemy("Scrungie_EN").passiveAbilities[2];
            BasePassiveAbilitySO passive = ScriptableObject.Instantiate<BasePassiveAbilitySO>(baseParent);
            passive._passiveName = "Overexert (" + amount.ToString() + ")";
            passive._characterDescription = "Won't work with this version.";
            passive._enemyDescription = "Upon receiving " + amount.ToString() + " or more direct damage, cancel 1 of this enemy's actions.";
            passive.conditions = new EffectorConditionSO[] { instance };
            return passive;
        }
        public static BasePassiveAbilitySO Leaky(int amount)
        {
            PerformEffectPassiveAbility leaky = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            leaky._passiveName = "Leaky (" + amount.ToString() + ")";
            leaky.passiveIcon = Passives.Leaky.passiveIcon;
            leaky._enemyDescription = "Upon receiving direct damage, this enemy generates " + amount.ToString() + " extra pigment of its health color.";
            leaky._characterDescription = "Upon receiving direct damage, this character generates " + amount.ToString() + " extra pigment of its health color.";
            leaky.type = PassiveAbilityTypes.Leaky;
            leaky.doesPassiveTriggerInformationPanel = true;
            leaky._triggerOn = new TriggerCalls[] { TriggerCalls.OnDirectDamaged };
            leaky.effects = ExtensionMethods.ToEffectInfoArray(new Effect[]
            {
                    new Effect(ScriptableObject.CreateInstance<GenerateCasterHealthManaEffect>(), amount, null, Slots.Self)
            });
            return leaky;
        }
        public static BasePassiveAbilitySO Multiattack(int amount)
        {
            IntegerSetterPassiveAbility baseParent = Passives.Multiattack as IntegerSetterPassiveAbility;
            IntegerSetterPassiveAbility ret = ScriptableObject.Instantiate<IntegerSetterPassiveAbility>(baseParent);
            ret._passiveName = "Multi Attack (" + amount.ToString() + ")";
            ret._characterDescription = "won't work boowomp";
            ret._enemyDescription = "This enemy will perform " + amount.ToString() + " actions each turn.";
            ret.integerValue = amount - 1;
            return ret;
        }
        public static BasePassiveAbilitySO Inferno(int amount)
        {
            PerformEffectPassiveAbility burn = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            burn._passiveName = "Inferno (" + amount.ToString() + ")";
            burn.passiveIcon = Passives.Inferno.passiveIcon;
            burn._enemyDescription = "On turn start, this enemy inflicts " + amount.ToString() + " Fire on their position.";
            burn._characterDescription = "On turn start, this character inflicts " + amount.ToString() + " Fire on their position.";
            burn.type = PassiveAbilityTypes.Inferno;
            burn.doesPassiveTriggerInformationPanel = true;
            burn._triggerOn = new TriggerCalls[] { TriggerCalls.OnTurnStart };
            burn.effects = ExtensionMethods.ToEffectInfoArray(new Effect[]
            {
                    new Effect(ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), amount, null, Slots.Self)
            });
            return burn;
        }
        public static BasePassiveAbilitySO Violent(int amount)
        {
            PerformEffectPassiveAbility vil = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            vil._passiveName = "Violent (" + amount.ToString() + ")";
            vil.passiveIcon = ResourceLoader.LoadSprite("ViolentPassive.png");
            vil._enemyDescription = "On receiving direct damage, deal " + amount.ToString() + " damage to the Opposing position.";
            vil._characterDescription = vil._enemyDescription;
            vil.type = (PassiveAbilityTypes)27201882;
            vil.doesPassiveTriggerInformationPanel = false;
            vil._triggerOn = new TriggerCalls[] { TriggerCalls.OnDirectDamaged };
            ShowViolentPassiveEffect e = ScriptableObject.CreateInstance<ShowViolentPassiveEffect>();
            e.image = vil.passiveIcon;
            vil.effects = ExtensionMethods.ToEffectInfoArray(new Effect[]
            {
                    new Effect(CasterRootActionEffect.Create(new Effect[]
                    {
                        new Effect(e, amount, null, Slots.Self, ScriptableObject.CreateInstance<HasHealthEffectCondition>()),
                        new Effect(ScriptableObject.CreateInstance<DamageEffect>(), amount, null, Slots.Front, ScriptableObject.CreateInstance<HasHealthEffectCondition>())
                    }), 1, null, Slots.Self)
            });
            vil.conditions = new EffectorConditionSO[] {ScriptableObject.CreateInstance<IsAliveCondition>() };
            return vil;
        }

        static BasePassiveAbilitySO _jumpy;
        public static BasePassiveAbilitySO Jumpy
        {
            get
            {
                if (_jumpy == null)
                {
                    PerformEffectPassiveAbility superSlippery = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                    superSlippery._passiveName = "Jumpy";
                    superSlippery.passiveIcon = ResourceLoader.LoadSprite("SuperSkittish", 32);
                    superSlippery.type = (PassiveAbilityTypes)544531;
                    superSlippery._enemyDescription = "Upon being hit move to a random position. Upon performing an ability, move to a random position.";
                    superSlippery._characterDescription = "Upon being hit move to a random position. Upon performing an ability, move to a random position.";
                    superSlippery.doesPassiveTriggerInformationPanel = true;
                    superSlippery.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1] { new Effect(ScriptableObject.CreateInstance<SwapToRandomZoneEffect>(), 1, new IntentType?(), Slots.SlotTarget(new int[9] { -4, -3, -2, -1, 0, 1, 2, 3, 4 }, true)) });
                    superSlippery._triggerOn = new TriggerCalls[2] { TriggerCalls.OnDirectDamaged, TriggerCalls.OnAbilityUsed };
                    superSlippery.conditions = new EffectorConditionSO[] { ScriptableObject.CreateInstance<IsAliveCondition>() };
                    _jumpy = superSlippery;
                }
                return _jumpy;
            }
        }
        static BasePassiveAbilitySO _fakeGutted;
        public static BasePassiveAbilitySO FakeGutted
        {
            get
            {
                if (_fakeGutted == null)
                {
                    PerformEffectPassiveAbility gutter = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                    gutter._passiveName = "Torn Apart";
                    gutter.passiveIcon = ResourceLoader.LoadSprite("GuttedIcon");
                    gutter._enemyDescription = "Permanently applies Gutted to this enemy.";
                    gutter._characterDescription = "Permanently applies Gutted to this character. Doesn't actually though, it's an entry effect on the enemy.";
                    gutter.type = (PassiveAbilityTypes)2233534;
                    gutter.doesPassiveTriggerInformationPanel = false;
                    gutter._triggerOn = new TriggerCalls[] { TriggerCalls.OnPlayerTurnEnd_ForEnemy };
                    gutter.effects = ExtensionMethods.ToEffectInfoArray(new Effect[]
                    {
                    new Effect(BasicEffects.Empty, 0, null, Slots.Self)
                    });
                    _fakeGutted = gutter;
                }
                return _fakeGutted;
            }
        }
        static BasePassiveAbilitySO _illusion;
        public static BasePassiveAbilitySO Illusion
        {
            get
            {
                if (_illusion == null)
                {
                    IllusionStatePassiveAbility fake = ScriptableObject.CreateInstance<IllusionStatePassiveAbility>();
                    fake._passiveName = "Delirium";
                    fake.passiveIcon = ResourceLoader.LoadSprite("IllusionPassive.png");
                    fake._enemyDescription = "This enemy has an Offense and a Supportive State and randomly picks between the two on entering battle.";
                    fake._characterDescription = "yurghle";
                    fake.type = (PassiveAbilityTypes)3862780;
                    fake.doesPassiveTriggerInformationPanel = false;
                    fake._triggerOn = new TriggerCalls[] { TriggerCalls.Count };
                    _illusion = fake;
                }
                return _illusion;
            }
        }
        static BasePassiveAbilitySO _splatter;
        public static BasePassiveAbilitySO Splatter
        {
            get
            {
                if (_splatter == null)
                {
                    PerformEffectPassiveAbility splatter = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                    splatter._passiveName = "Splatter";
                    splatter.passiveIcon = ResourceLoader.LoadSprite("splatter.png");
                    splatter._enemyDescription = "On death, produce 4 pigment of this enemy's health color.";
                    splatter._characterDescription = "On death, produce 4 pigment of this character's health color.";
                    splatter.type = (PassiveAbilityTypes)2246624;
                    splatter.doesPassiveTriggerInformationPanel = true;
                    splatter._triggerOn = new TriggerCalls[] { TriggerCalls.OnDeath };
                    splatter.effects = ExtensionMethods.ToEffectInfoArray(new Effect[]
                    {
                    new Effect(ScriptableObject.CreateInstance<GenerateCasterHealthManaEffect>(), 4, null, Slots.Self)
                    });
                    _splatter = splatter;
                }
                return _splatter;
            }
        }
        static BasePassiveAbilitySO _survival;
        public static BasePassiveAbilitySO Survival
        {
            get
            {
                if (_survival == null)
                {
                    AnimationVisualsEffect core = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
                    core._visuals = ((AnimationVisualsEffect)((PerformEffectWearable)LoadedAssetsHandler.GetWearable("DemonCore_SW")).effects[0].effect)._visuals;
                    core._animationTarget = Slots.Self;
                    PerformEffectImmediatePassiveAbility survival = ScriptableObject.CreateInstance<PerformEffectImmediatePassiveAbility>();
                    survival._passiveName = "Survival Instinct";
                    survival.passiveIcon = ResourceLoader.LoadSprite("survival.png");
                    survival._enemyDescription = "On death, instantly kill the lowest health party member.";
                    survival._characterDescription = "On death, instantly kill the lowest health enemy.";
                    survival.type = (PassiveAbilityTypes)2246625;
                    survival.doesPassiveTriggerInformationPanel = true;
                    survival._triggerOn = new TriggerCalls[] { TriggerCalls.OnDeath };
                    Targetting_ByUnit_Side allEnemy = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
                    allEnemy.getAllies = false;
                    allEnemy.getAllUnitSlots = false;
                    survival.conditions = new EffectorConditionSO[]
                    {
                    };
                    survival.effects = ExtensionMethods.ToEffectInfoArray(new Effect[]
                    {
                        new Effect(core, 1, null, Slots.Self),
                        new Effect(ScriptableObject.CreateInstance<DirectDeathEffect>(), 1, null, Targetting.LowestEnemy)
                    });
                    _survival = survival;
                }
                return _survival;
            }
        }
        static BasePassiveAbilitySO _coda;
        public static BasePassiveAbilitySO Coda
        {
            get
            {
                if (_coda == null)
                {
                    Dodge.Add();
                    PerformDoubleEffectPassiveAbility coda = ScriptableObject.CreateInstance<PerformDoubleEffectPassiveAbility>();
                    coda._passiveName = "Coda";
                    coda.passiveIcon = ResourceLoader.LoadSprite("CodaIcon.png");
                    coda._enemyDescription = "On death, apply 3 Dodge and 2 Haste to every other enemy.";
                    coda._characterDescription = "On death, apply 3 Dodge and 2 Haste to every other party member.";
                    coda.type = (PassiveAbilityTypes)2246626;
                    coda.doesPassiveTriggerInformationPanel = true;
                    coda._triggerOn = new TriggerCalls[] { TriggerCalls.OnDeath };
                    Targetting_ByUnit_Side allAlly = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
                    allAlly.getAllies = true;
                    allAlly.getAllUnitSlots = false;
                    allAlly.ignoreCastSlot = true;
                    coda.effects = ExtensionMethods.ToEffectInfoArray(new Effect[]
                    {
                        new Effect(ScriptableObject.CreateInstance<WindSongEffect>(), 1, null, Slots.Self),
                        new Effect(ScriptableObject.CreateInstance<ApplyDodgeEffect>(), 3, null, allAlly),
                        new Effect(ScriptableObject.CreateInstance<ApplyHasteEffect>(), 2, null, allAlly)
                    });
                    coda._secondDoesPerformPopUp = false;
                    coda._secondTriggerOn = new TriggerCalls[] { TriggerCalls.Count };
                    coda._secondEffects = ExtensionMethods.ToEffectInfoArray(new Effect[]
                    {
                        new Effect(ScriptableObject.CreateInstance<WindSongEffect>(), 1, null, Slots.Self)
                    });
                    _coda = coda;
                }
                return _coda;
            }
        }
        static BasePassiveAbilitySO _sigil;
        public static BasePassiveAbilitySO Sigil
        {
            get
            {
                if (_sigil == null)
                {
                    SigilPassiveAbility sigil = ScriptableObject.CreateInstance<SigilPassiveAbility>();
                    sigil._passiveName = "Sigil";
                    sigil.passiveIcon = ResourceLoader.LoadSprite("sigilPassive.png");
                    sigil._enemyDescription = "At the start of each turn, reset this enemy's Sigil.";
                    sigil._characterDescription = "At the start of each turn, reset this party member's Sigil.";
                    sigil.specialStoredValue = SigilManager.Sigil;
                    sigil.type = (PassiveAbilityTypes)2246627;
                    sigil.doesPassiveTriggerInformationPanel = false;
                    sigil._triggerOn = new TriggerCalls[] { TriggerCalls.OnTurnStart };
                    sigil.specialStoredValue = SigilManager.Sigil;
                    _sigil = sigil;
                }
                return _sigil;
            }
        }
        static BasePassiveAbilitySO _steel;
        public static BasePassiveAbilitySO Steel
        {
            get
            {
                if (_steel == null)
                {
                    PerformEffectPassiveAbility steel = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                    steel._passiveName = "Steel";
                    steel.passiveIcon = ResourceLoader.LoadSprite("Steeled_passive.png");
                    steel._enemyDescription = "This enemy is immune to all status effects.";
                    steel._characterDescription = "This party member is immune to all status effects.";
                    steel.type = (PassiveAbilityTypes)2246628;
                    steel.doesPassiveTriggerInformationPanel = true;
                    steel._triggerOn = new TriggerCalls[] { TriggerCalls.CanApplyStatusEffect };
                    steel.conditions = new EffectorConditionSO[] { ScriptableObject.CreateInstance<NoStatusEffector>() };
                    steel.effects = new EffectInfo[0];
                    _steel = steel;
                }
                return _steel;
            }
        }
        static BasePassiveAbilitySO _coldBlood;
        public static BasePassiveAbilitySO ColdBlood
        {
            get
            {
                if (_coldBlood == null)
                {
                    FireNoReduce.Add();
                    PerformEffectPassiveAbility cold = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                    cold._passiveName = "Cold-Blooded";
                    cold.passiveIcon = ResourceLoader.LoadSprite("cold", 32);
                    cold.type = (PassiveAbilityTypes)327745;
                    cold._characterDescription = "All Fire damage received by this character is multiplied by -1. This damage cannot set this character's health above their maximum health. \nFire on this party member's position does not decrease.";
                    cold._enemyDescription = "All Fire damage received by this enemy is multiplied by -1. This damage cannot set this enemy's health above their maximum health. \nFire on this enemy's position does not decrease.";
                    cold.doesPassiveTriggerInformationPanel = false;
                    cold._triggerOn = new TriggerCalls[] { TriggerCalls.OnBeingDamaged };
                    cold.conditions = new EffectorConditionSO[]
                    {
                ScriptableObject.CreateInstance<ColdHealCondition>()
                    };
                    cold.effects = new EffectInfo[0];
                    _coldBlood = cold;
                }
                return _coldBlood;
            }
        }
        static BasePassiveAbilitySO _acceleration;
        public static BasePassiveAbilitySO Acceleration
        {
            get
            {
                if (_acceleration == null)
                {
                    ClockTowerManager.Setup();
                    ClockTowerPassive acceleration = ScriptableObject.CreateInstance<ClockTowerPassive>();
                    acceleration._passiveName = "Acceleration";
                    acceleration.passiveIcon = ResourceLoader.LoadSprite("ParanoidSpeed");
                    acceleration._enemyDescription = "If the player's portion of the turn takes longer than 60 seconds, apply 6 Entropy to all party members.";
                    acceleration._characterDescription = "Doesn't work. I didnt bother setting up the hooks for this.";
                    acceleration.type = (PassiveAbilityTypes)9878774;
                    acceleration.doesPassiveTriggerInformationPanel = true;
                    acceleration._triggerOn = new TriggerCalls[] { ClockTowerManager.Call };
                    Targetting_ByUnit_Side allEnemy = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
                    allEnemy.getAllies = false;
                    allEnemy.getAllUnitSlots = false;
                    acceleration.effects = ExtensionMethods.ToEffectInfoArray(new Effect[]
                    {
                        new Effect(BasicEffects.GetVisuals("Salt/Alarm", false, Slots.Self), 1, null, Slots.Self),
                    new Effect(ScriptableObject.CreateInstance<ApplyEntropyEffect>(), 6, null, allEnemy)
                    });
                    acceleration.specialStoredValue = ClockTowerManager.Acceleration;
                    _acceleration = acceleration;
                }
                return _acceleration;
            }
        }
        static BasePassiveAbilitySO _armor;
        public static BasePassiveAbilitySO Armor
        {
            get
            {
                if (_armor == null)
                {
                    ArmorManager.Setup();
                    PerformEffectPassiveAbility armor = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                    armor._passiveName = "Heavily Armored";
                    armor.passiveIcon = ResourceLoader.LoadSprite("heavily_armored");
                    armor._enemyDescription = "If any of this enemy's positions have no Shield, apply 4 Shield there.";
                    armor._characterDescription = "If this party member's position has no Shield, apply 4 Shield there.";
                    armor.type = ArmorManager.Armor;
                    armor.doesPassiveTriggerInformationPanel = false;
                    armor._triggerOn = new TriggerCalls[] { TriggerCalls.OnMoved };
                    armor.effects = ExtensionMethods.ToEffectInfoArray(new Effect[]
                    {
                        new Effect(ScriptableObject.CreateInstance<ArmorEffect>(), 1, null, Targetting.AllSelfSlots)
                    });
                    _armor = armor;
                }
                return _armor;
            }
        }
        static BasePassiveAbilitySO _painless;
        public static BasePassiveAbilitySO Painless
        {
            get
            {
                if (_painless == null)
                {
                    PainCondition.Setup();
                    PerformEffectPassiveAbility painless = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                    painless._passiveName = "Algophobia (20)";
                    painless.passiveIcon = ResourceLoader.LoadSprite("algophobia");
                    painless._enemyDescription = "Taking 20 or more damage in one turn will make this enemy instantly flee.";
                    painless._characterDescription = "Taking 20 or more damage in one turn will make this party member instantly flee. But also it wont work on party members anyway lol.";
                    painless.type = (PassiveAbilityTypes)2336628;
                    painless.doesPassiveTriggerInformationPanel = true;
                    painless._triggerOn = new TriggerCalls[] { TriggerCalls.OnDamaged, TriggerCalls.OnPlayerTurnEnd_ForEnemy };
                    painless.conditions = new EffectorConditionSO[] { ScriptableObject.CreateInstance<PainCondition>() };
                    painless.effects = ExtensionMethods.ToEffectInfoArray(new Effect[]
                    {
                        new Effect(ScriptableObject.CreateInstance<FleeTargetEffect>(), 1, null, Slots.Self)
                    });
                    painless.specialStoredValue = PainCondition.Pain;
                    _painless = painless;
                }
                return _painless;
            }
        }
        static BasePassiveAbilitySO _unbreakable;
        public static BasePassiveAbilitySO Unbreakable
        {
            get
            {
                if (_unbreakable == null)
                {
                    DishPassiveHook.Add();
                    PerformEffectPassiveAbility unbreakable = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                    unbreakable._passiveName = "Unbreakable";
                    unbreakable.passiveIcon = ResourceLoader.LoadSprite("Unbreakable_icon-", 32, null);
                    unbreakable.type = (PassiveAbilityTypes)45454;
                    unbreakable._enemyDescription = "Shields on this enemy's position do not decay over time.";
                    unbreakable._characterDescription = "Shields on this party member's position do not decay over time.";
                    unbreakable._triggerOn = new TriggerCalls[]
                    {
                        TriggerCalls.Count
                    };
                    _unbreakable = unbreakable;
                }
                return _unbreakable;
            }
        }
        static BasePassiveAbilitySO _rupture;
        public static BasePassiveAbilitySO Rupture
        {
            get
            {
                if (_rupture == null)
                {
                    Connection_PerformEffectPassiveAbility rupture = ScriptableObject.CreateInstance<Connection_PerformEffectPassiveAbility>();
                    rupture._passiveName = "Enruptured";
                    rupture.passiveIcon = ResourceLoader.LoadSprite("enrupture", 32);
                    rupture.type = (PassiveAbilityTypes)7673;
                    rupture._enemyDescription = "Permanently applies Ruptured to this enemy.";
                    rupture._characterDescription = "Permanently applies Ruptured to this character.";
                    rupture.doesPassiveTriggerInformationPanel = true;
                    rupture.connectionEffects = ExtensionMethods.ToEffectInfoArray(new Effect[1] { new Effect(CasterSubActionEffect.Create(new Effect[] { new Effect(ScriptableObject.CreateInstance<ApplyPermanentRupturedEffect>(), 1, null, Slots.Self) }), 1, null, Slots.Self) });
                    rupture.disconnectionEffects = new EffectInfo[0];
                    rupture._triggerOn = new TriggerCalls[] { TriggerCalls.Count };
                    _rupture = rupture;
                }
                return _rupture;
            }
        }
        static BasePassiveAbilitySO _disable;
        public static BasePassiveAbilitySO Disable
        {
            get
            {
                if (_disable == null)
                {
                    PerformEffectPassiveAbility disabled = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                    disabled._passiveName = "Disabled (2)";
                    disabled.passiveIcon = ResourceLoader.LoadSprite("DisabledIcon.png", 32);
                    disabled._enemyDescription = "On receiving any damage over 2, cancel one of this enemy's moves.";
                    disabled._characterDescription = "wont work, lol?";
                    disabled.type = (PassiveAbilityTypes)2246629;
                    disabled.doesPassiveTriggerInformationPanel = true;
                    disabled._triggerOn = new TriggerCalls[] { TriggerCalls.OnDamaged };
                    disabled.conditions = new EffectorConditionSO[] { ScriptableObject.CreateInstance<DisabledCondition>() };
                    disabled.effects = ExtensionMethods.ToEffectInfoArray(new Effect[]
                    {
                        new Effect(ScriptableObject.CreateInstance<RemoveTargetTimelineAbilityEffect>(), 1, null, Slots.Self)
                    });
                    _disable = disabled;
                }
                return _disable;
            }
        }
        static BasePassiveAbilitySO _megaLeaky;
        public static BasePassiveAbilitySO MegaLeaky
        {
            get
            {
                if (_megaLeaky == null)
                {

                    PerformEffectPassiveAbility leaky = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                    leaky._passiveName = "Leaky (8)";
                    leaky.passiveIcon = Passives.Leaky.passiveIcon;
                    leaky._enemyDescription = "Upon receiving direct damage, this enemy generates 8 extra pigment of its health color.";
                    leaky._characterDescription = "Upon receiving direct damage, this character generates 8 extra pigment of its health color.";
                    leaky.type = PassiveAbilityTypes.Leaky;
                    leaky.doesPassiveTriggerInformationPanel = true;
                    leaky._triggerOn = new TriggerCalls[] { TriggerCalls.OnDirectDamaged };
                    leaky.effects = ExtensionMethods.ToEffectInfoArray(new Effect[]
                    {
                    new Effect(ScriptableObject.CreateInstance<GenerateCasterHealthManaEffect>(), 8, null, Slots.Self)
                    });
                    _megaLeaky = leaky;
                }
                return _megaLeaky;
            }
        }
        static BasePassiveAbilitySO _evasive;
        public static BasePassiveAbilitySO Evasive
        {
            get
            {
                if (_evasive == null)
                {
                    Connection_PerformEffectPassiveAbility evasive = ScriptableObject.CreateInstance<Connection_PerformEffectPassiveAbility>();
                    evasive._passiveName = "Evasive";
                    evasive.passiveIcon = ResourceLoader.LoadSprite("Dodge.png", 32);
                    evasive.type = (PassiveAbilityTypes)2246630;
                    evasive._enemyDescription = "Permanently applies Dodge to this enemy.";
                    evasive._characterDescription = "Permanently applies Dodge to this character.";
                    evasive.doesPassiveTriggerInformationPanel = true;
                    evasive.connectionEffects = ExtensionMethods.ToEffectInfoArray(new Effect[] { new Effect(CasterSubActionEffect.Create(new Effect[] { new Effect(ScriptableObject.CreateInstance<ApplyPermenantDodgeEffect>(), 1, null, Slots.Self) }), 1, null, Slots.Self) });
                    evasive.disconnectionEffects = new EffectInfo[0];
                    evasive._triggerOn = new TriggerCalls[] { TriggerCalls.Count };
                    _evasive = evasive;
                }
                return _evasive;
            }
        }
        static BasePassiveAbilitySO _preserved;
        public static BasePassiveAbilitySO Preserved
        {
            get
            {
                if (_preserved == null)
                {
                    PreservedHandler.Setup();
                    PerformEffectPassiveAbility preserve = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                    preserve._passiveName = "Well Preserved";
                    preserve.passiveIcon = ResourceLoader.LoadSprite("preserve.png");
                    preserve._enemyDescription = "This enemy is immune to indirect damage and damage from other enemies.";
                    preserve._characterDescription = "This party member is immune to indirect damage.";
                    preserve.type = (PassiveAbilityTypes)2246634;
                    preserve.doesPassiveTriggerInformationPanel = true;
                    preserve._triggerOn = new TriggerCalls[] { TriggerCalls.OnBeingDamaged };
                    preserve.conditions = new EffectorConditionSO[] { ScriptableObject.CreateInstance<WellPreservedCondition>() };
                    preserve.effects = new EffectInfo[0];
                    _preserved = preserve;
                }
                return _preserved;
            }
        }
        static BasePassiveAbilitySO _ethereal;
        public static BasePassiveAbilitySO Ethereal
        {
            get
            {
                if (_ethereal == null)
                {
                    ButterflyUnboxer.Setup();
                    PerformEffectPassiveAbility ethereal = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                    ethereal._passiveName = "Ethereal";
                    ethereal.passiveIcon = ResourceLoader.LoadSprite("Ethereal.png");
                    ethereal._enemyDescription = "On taking any damage, instantly flee. When fleeing, this enemy will return at the end of the timeline if combat hasn't ended.";
                    ethereal._characterDescription = "On taking any damage, instantly flee. When fleeing, this character will return at the end of the timeline if combat hasn't ended.";
                    ethereal.type = ButterflyUnboxer.ButterflyPassive;
                    ethereal.doesPassiveTriggerInformationPanel = true;
                    ethereal._triggerOn = new TriggerCalls[] { TriggerCalls.OnDamaged };
                    ethereal.conditions = new EffectorConditionSO[] { ScriptableObject.CreateInstance<IfAliveCondition>() };
                    ethereal.effects = ExtensionMethods.ToEffectInfoArray(new Effect[]
                    {
                    new Effect(ScriptableObject.CreateInstance<FleeTargetEffect>(), 1, null, Slots.Self, ScriptableObject.CreateInstance<IfAliveEffectCondition>())
                    });
                    _ethereal = ethereal;
                }
                return _ethereal;
            }
        }
        static BasePassiveAbilitySO _tempered;
        public static BasePassiveAbilitySO Tempered
        {
            get
            {
                if (_tempered == null)
                {
                    FragilePassiveAbility Fragile = ScriptableObject.CreateInstance<FragilePassiveAbility>();
                    Fragile._passiveName = "Tempered";
                    Fragile.passiveIcon = ResourceLoader.LoadSprite("FragileIcon", 32);
                    Fragile.type = (PassiveAbilityTypes)22323;
                    Fragile._enemyDescription = "All damage is reduced to 1. All healing is negated.";
                    Fragile._characterDescription = "All damage is reduced to 1. All healing is negated.";
                    Fragile.doesPassiveTriggerInformationPanel = false;
                    Fragile._triggerOn = new TriggerCalls[] { TriggerCalls.OnBeingDamaged, TriggerCalls.CanHeal };
                    _tempered = Fragile;
                }
                return _tempered;
            }
        }
        static BasePassiveAbilitySO _illusory;
        public static BasePassiveAbilitySO Illusory
        {
            get
            {
                if (_illusory == null)
                {
                    InvinciblePassiveAbility invinible = ScriptableObject.CreateInstance<InvinciblePassiveAbility>();
                    invinible._passiveName = "Illusory";
                    invinible.passiveIcon = ResourceLoader.LoadSprite("StarPassive", 32);
                    invinible.type = (PassiveAbilityTypes)544521;
                    invinible._enemyDescription = "This enemy is immune to both direct and indirect damage.";
                    invinible._characterDescription = "This character is immune to both direct and indirect damage.";
                    invinible.doesPassiveTriggerInformationPanel = false;
                    invinible._triggerOn = new TriggerCalls[1] { TriggerCalls.OnBeingDamaged };
                    _illusory = invinible;
                }
                return _illusory;
            }
        }
        static BasePassiveAbilitySO _doubleSkit;
        public static BasePassiveAbilitySO DoubleSkit
        {
            get
            {
                if (_doubleSkit == null)
                {
                    PerformEffectPassiveAbility skitter = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                    skitter._passiveName = "Skittish (2)";
                    skitter.passiveIcon = Passives.Skittish.passiveIcon;
                    skitter._enemyDescription = "On performing an attack this enemy will attempt to move left or right twice.";
                    skitter._characterDescription = "On performing an attack this party member will attempt to move left or right twice.";
                    skitter.type = PassiveAbilityTypes.Skittish;
                    skitter.doesPassiveTriggerInformationPanel = true;
                    skitter._triggerOn = Passives.Skittish._triggerOn;
                    skitter.effects = ExtensionMethods.ToEffectInfoArray(new Effect[]
                    {
                        new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, null, Slots.Self),
                        new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, null, Slots.Self),
                    });
                    _doubleSkit = skitter;
                }
                return _doubleSkit;
            }
        }
        static BasePassiveAbilitySO _doubleSlip;
        public static BasePassiveAbilitySO DoubleSlip
        {
            get
            {
                if (_doubleSlip == null)
                {
                    PerformEffectPassiveAbility slipper = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                    slipper._passiveName = "Slippery (2)";
                    slipper.passiveIcon = Passives.Slippery.passiveIcon;
                    slipper._enemyDescription = "On taking direct damage this enemy will attempt to move left or right twice.";
                    slipper._characterDescription = "On taking direct damage this party member will attempt to move left or right twice.";
                    slipper.type = PassiveAbilityTypes.Slippery;
                    slipper.doesPassiveTriggerInformationPanel = true;
                    slipper._triggerOn = Passives.Slippery._triggerOn;
                    slipper.conditions = Passives.Slippery.conditions;
                    slipper.effects = ExtensionMethods.ToEffectInfoArray(new Effect[]
                    {
                        new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, null, Slots.Self),
                        new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, null, Slots.Self),
                    });
                    _doubleSlip = slipper;
                }
                return _doubleSlip;
            }
        }
        static BasePassiveAbilitySO _unmasking;
        public static BasePassiveAbilitySO Unmasking
        {
            get
            {
                if (_unmasking == null)
                {
                    UnmaskPassiveAbility unmasking = ScriptableObject.CreateInstance<UnmaskPassiveAbility>();
                    unmasking._passiveName = "Unmasking (6)";
                    unmasking.passiveIcon = ResourceLoader.LoadSprite("Unmasking", 32);
                    unmasking.type = (PassiveAbilityTypes)544533;
                    unmasking._enemyDescription = "Upon taking a certain amount of direct damage or higher, remove Confusion and Obscured as passives from this enemy.";
                    unmasking._characterDescription = "Upon taking a certain amount of direct damage or higher, remove Confusion and Obscured as passives from this character.";
                    unmasking.doesPassiveTriggerInformationPanel = false;
                    unmasking._floorVal = 6;
                    unmasking._triggerOn = new TriggerCalls[1] { TriggerCalls.OnDirectDamaged };
                    _unmasking = unmasking;
                }
                return _unmasking;
            }
        }
        static BasePassiveAbilitySO _theFall;
        public static BasePassiveAbilitySO TheFall
        {
            get
            {
                if (_theFall == null)
                {
                    PerformEffectPassiveAbility damocles = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                    damocles._passiveName = "The String Snaps";
                    damocles.passiveIcon = ResourceLoader.LoadSprite("snapstring.png", 32);
                    damocles.type = (PassiveAbilityTypes)7622220;
                    damocles._enemyDescription = "On taking any amount of damage, there is a 50% chance that this enemy instantly dies then deals the amount of damage taken to the Opposing party member.";
                    damocles._characterDescription = "On taking any amount of damage, there is a 50% chance that this party member instantly dies then deals the amount of damage taken to the Opposing enemy.";
                    damocles.doesPassiveTriggerInformationPanel = false;
                    damocles.conditions = new EffectorConditionSO[] { ScriptableObject.CreateInstance<DamoclesCondition>() };
                    damocles._triggerOn = new TriggerCalls[1] { TriggerCalls.OnDamaged };
                    _theFall = damocles;
                }
                return _theFall;
            }
        }
        static BasePassiveAbilitySO _asphyxiation;
        public static BasePassiveAbilitySO Asphyxiation
        {
            get
            {
                if (_asphyxiation == null)
                {
                    AsphyxiationManager.Setup();
                    AsphyxiationPassiveAbility noOver = ScriptableObject.CreateInstance<AsphyxiationPassiveAbility>();
                    noOver._passiveName = "Asphyxiation (50)";
                    noOver.passiveIcon = ResourceLoader.LoadSprite("Joeverflow.png", 32);
                    noOver.type = (PassiveAbilityTypes)2246631;
                    noOver._enemyDescription = "Overflow under 50 will not trigger.";
                    noOver._characterDescription = "Overflow under 50 will not trigger.";
                    noOver.doesPassiveTriggerInformationPanel = false;
                    noOver._triggerOn = new TriggerCalls[] { TriggerCalls.Count };
                    noOver.ManaCap = 50;
                    _asphyxiation = noOver;
                }
                return _asphyxiation;
            }
        }
        static BasePassiveAbilitySO _salinitySV;
        public static BasePassiveAbilitySO SalinitySV
        {
            get
            {
                if (_salinitySV == null)
                {
                    _salinitySV = DrowningManager._salinity;
                }
                return _salinitySV;
            }
        }
        static BasePassiveAbilitySO _leakySV;
        public static BasePassiveAbilitySO LeakySV
        {
            get
            {
                if (_leakySV == null)
                {
                    _leakySV = DrowningManager._leaky;
                }
                return _leakySV;
            }
        }
        static BasePassiveAbilitySO _pressure;
        public static BasePassiveAbilitySO Pressure
        {
            get
            {
                if (_pressure == null)
                {
                    ExtraAttackPassiveAbility baseExtra = LoadedAssetsHandler.GetEnemy("Xiphactinus_EN").passiveAbilities[1] as ExtraAttackPassiveAbility;
                    ExtraAttackPassiveAbility pressure = ScriptableObject.Instantiate<ExtraAttackPassiveAbility>(baseExtra);
                    pressure._passiveName = "Deep Pressure";
                    pressure._enemyDescription = "The Deep will perforn an extra ability \"Deep Pressure\" each turn.";
                    Ability bonus = new Ability();
                    bonus.name = "Deep Pressure";
                    bonus.description = "Produce 1 Pigment of each of the Opposing party member's health colors. Deal a Little bit of damage to each of them.";
                    bonus.effects = new Effect[2];
                    bonus.effects[0] = new Effect(ScriptableObject.CreateInstance<GenerateTargetHealthManaEffect>(), 1, IntentType.Mana_Generate, Slots.Front);
                    bonus.effects[1] = new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 2, IntentType.Damage_1_2, Slots.Front);
                    bonus.visuals = LoadedAssetsHandler.GetCharacterAbility("Entwined_1_A").visuals;
                    bonus.animationTarget = Slots.Front;
                    AbilitySO ability = bonus.CharacterAbility().ability;
                    pressure._extraAbility.ability = bonus.CharacterAbility().ability = ability;
                    _pressure = pressure;
                }
                return _pressure;
            }
        }
        static BasePassiveAbilitySO _postmodern;
        public static BasePassiveAbilitySO Postmodern
        {
            get
            {
                if (_postmodern == null)
                {
                    PostModernPassiveAbility postmodern = ScriptableObject.CreateInstance<PostModernPassiveAbility>();
                    postmodern._passiveName = "Post-Modern";
                    postmodern.passiveIcon = ResourceLoader.LoadSprite("PostModernIcon", 32);
                    postmodern.type = (PassiveAbilityTypes)8193;
                    postmodern._enemyDescription = "All damage this enemy receives is set to 999.";
                    postmodern._characterDescription = "why two kay";
                    postmodern.doesPassiveTriggerInformationPanel = false;
                    postmodern._triggerOn = new TriggerCalls[]
                    {
                TriggerCalls.OnBeingDamaged
                    };
                    postmodern.DoScreenFuck = false;
                    _postmodern = postmodern;
                }
                return _postmodern;
            }
        }
        static BasePassiveAbilitySO _cry;
        public static BasePassiveAbilitySO Cry
        {
            get
            {
                if (_cry == null)
                {
                    TargetStoredValueChangeEffect incNoise = ScriptableObject.CreateInstance<TargetStoredValueChangeEffect>();
                    incNoise._valueName = NoiseHandler.Noise;
                    ParentalPassiveAbility baseParent = LoadedAssetsHandler.GetEnemy("Flarb_EN").passiveAbilities[1] as ParentalPassiveAbility;
                    ParentalPassiveAbility pathetic = ScriptableObject.Instantiate<ParentalPassiveAbility>(baseParent);
                    pathetic._passiveName = "Parental";
                    pathetic._enemyDescription = "If an infantile enemy receives direct damage, this enemy will perform \"Pathetic Cry\" in retribution.";
                    Ability parental = new Ability();
                    parental.name = "Pathetic Cry";
                    parental.description = "Increase Noise on all party members by 1.";
                    Targetting_ByUnit_Side allEnemy = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
                    allEnemy.getAllies = false;
                    allEnemy.getAllUnitSlots = false;
                    parental.effects = new Effect[1];
                    parental.effects[0] = new Effect(incNoise, 1, IntentType.Misc, allEnemy);
                    parental.visuals = LoadedAssetsHandler.GetEnemyAbility("Weep_A").visuals;
                    parental.animationTarget = allEnemy;
                    AbilitySO ability = parental.CharacterAbility().ability;
                    pathetic._parentalAbility.ability = parental.CharacterAbility().ability = ability;
                    _cry = pathetic;
                }
                return _cry;
            }
        }
        static BasePassiveAbilitySO _lock;
        public static BasePassiveAbilitySO Lock
        {
            get
            {
                if (_lock == null)
                {
                    LockedInHandler.Setup();
                    LockedInPassiveAbility lockedIn = ScriptableObject.CreateInstance<LockedInPassiveAbility>();
                    lockedIn._passiveName = "Locked In";
                    lockedIn.passiveIcon = ResourceLoader.LoadSprite("NoMenu");
                    lockedIn._enemyDescription = "The Pause Menu can no longer be accessed.";
                    lockedIn._characterDescription = "The Pause Menu can no longer be accessed.";
                    lockedIn.type = (PassiveAbilityTypes)2246633;
                    lockedIn.doesPassiveTriggerInformationPanel = false;
                    lockedIn._triggerOn = new TriggerCalls[] { TriggerCalls.Count };
                    _lock = lockedIn;
                }
                return _lock;
            }
        }
        static BasePassiveAbilitySO _decay;
        public static BasePassiveAbilitySO Decay
        {
            get
            {
                if (_decay == null)
                {
                    PerformEffectPassiveAbility decay = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                    decay._passiveName = "Decay";
                    decay.passiveIcon = ResourceLoader.LoadSprite("DecayPassiveIcon", 32);
                    decay.type = PassiveAbilityTypes.Decay;
                    decay._enemyDescription = "Upon dying, this enemy decays into itself.";
                    decay._characterDescription = "On dying, nothing happens. This effect won't work on party members. Be glad it doesnt break the game.";
                    decay.doesPassiveTriggerInformationPanel = true;
                    decay._triggerOn = new TriggerCalls[1] { TriggerCalls.OnDeath };
                    DeathReferenceDetectionEffectorCondition detectWither = ScriptableObject.CreateInstance<DeathReferenceDetectionEffectorCondition>();
                    detectWither._witheringDeath = false;
                    detectWither._useWithering = true;
                    decay.conditions = new EffectorConditionSO[]
                    {
                        detectWither
                    };
                    DelayRespawnEffect spawn = ScriptableObject.CreateInstance<DelayRespawnEffect>();
                    decay.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
                    {
                new Effect(spawn, 1, new IntentType?(), Slots.Self)
                    });
                    _decay = decay;
                }
                return _decay;
            }
        }
        static BasePassiveAbilitySO _abandon;
        public static BasePassiveAbilitySO Abandon
        {
            get
            {
                if (_abandon == null)
                {
                    ParentalPassiveAbility baseParent = LoadedAssetsHandler.GetEnemy("Flarb_EN").passiveAbilities[1] as ParentalPassiveAbility;
                    ParentalPassiveAbility abandon = ScriptableObject.Instantiate<ParentalPassiveAbility>(baseParent);
                    abandon._passiveName = "Parental";
                    abandon._enemyDescription = "If an infantile enemy receives direct damage, this enemy will perform \"Abandonment Play\" in retribution.";
                    Ability parental = new Ability();
                    parental.name = "Abandonment Play";
                    parental.description = "Apply 1 Constricted to the Opposing party member. Move this enemy to a random position.";
                    parental.effects = new Effect[2];
                    parental.effects[0] = new Effect(ScriptableObject.CreateInstance<ApplyConstrictedSlotEffect>(), 1, IntentType.Field_Constricted, Slots.Front);
                    parental.effects[1] = new Effect(ScriptableObject.CreateInstance<SwapRandomZoneEffectHideIntent>(), 1, IntentType.Swap_Mass, Slots.Self);
                    parental.visuals = CustomVisuals.GetVisuals("Salt/Alarm");
                    parental.animationTarget = Slots.Front;
                    AbilitySO ability = parental.CharacterAbility().ability;
                    abandon._parentalAbility.ability = parental.CharacterAbility().ability = ability;
                    _abandon = abandon;
                }
                return _abandon;
            }
        }
        static BasePassiveAbilitySO _incomprehensible;
        public static BasePassiveAbilitySO Incomprehensible
        {
            get
            {
                if (_incomprehensible == null)
                {
                    PerformEffectPassiveAbility incomprehend = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                    incomprehend._passiveName = "Incomprehensible";
                    incomprehend.passiveIcon = ResourceLoader.LoadSprite("Incomprehensible.png", 32);
                    incomprehend.type = (PassiveAbilityTypes)AmbushManager.Patiently;
                    incomprehend._enemyDescription = "When a party member moves in front of this enemy, inflict 1 Muted on them.";
                    incomprehend._characterDescription = "When an enemy moves in front of this party member, inflict 1 Muted on them.";
                    incomprehend.doesPassiveTriggerInformationPanel = true;
                    incomprehend.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1] { new Effect(ScriptableObject.CreateInstance<ApplyMutedEffect>(), 1, null, Slots.Front) });
                    incomprehend._triggerOn = new TriggerCalls[1] { (TriggerCalls)AmbushManager.Patiently };
                    _incomprehensible = incomprehend;
                }
                return _incomprehensible;
            }
        }
        static BasePassiveAbilitySO _snakeGod;
        public static BasePassiveAbilitySO SnakeGod
        {
            get
            {
                if (_snakeGod == null)
                {
                    SnakeGodManager.Setup();
                    SnakeGodPassive snakegod = ScriptableObject.CreateInstance<SnakeGodPassive>();
                    snakegod._passiveName = "Vindictive";
                    snakegod.passiveIcon = ResourceLoader.LoadSprite("HateYou.png");
                    snakegod.type = (PassiveAbilityTypes)93892579;
                    snakegod._enemyDescription = "This enemy remembers its oppressors. On taking direct damage, inflict 1 Scar on the attacker.";
                    snakegod._characterDescription = "Won't work cuz i didn't set up the hook for it lol!";
                    snakegod.doesPassiveTriggerInformationPanel = false;
                    snakegod._triggerOn = new TriggerCalls[1] { TriggerCalls.Count };
                    snakegod.specialStoredValue = SnakeGodManager.Last;
                    _snakeGod = snakegod;
                }
                return _snakeGod;EnemyCombat e;
            }
        }
        static BasePassiveAbilitySO _hunter;
        public static BasePassiveAbilitySO Hunter
        {
            get
            {
                if (_hunter == null)
                {
                    Terror.Add();
                    NormalAndConnection_PerformEffectPassiveAbility hunter = ScriptableObject.CreateInstance<NormalAndConnection_PerformEffectPassiveAbility>();
                    hunter._passiveName = "Hunter";
                    hunter.passiveIcon = ResourceLoader.LoadSprite("hunterpassive.png", 32);
                    hunter.type = (PassiveAbilityTypes)Terror.terror;
                    hunter._enemyDescription = "At the start of combat, apply Terror to a random party member. At the end of each of this enemy's turns, if the Opposing party member has Terror instantly kill them.";
                    hunter._characterDescription = "At the start of combat, apply Terror to a random enemy. At the end of each turn, if the Opposing enemy has Terror instantly kill them.";
                    hunter.doesPassiveTriggerInformationPanel = false;
                    hunter.effects = ExtensionMethods.ToEffectInfoArray(new Effect[] { new Effect(ScriptableObject.CreateInstance<TerrorDeathEffect>(), 1, null, Slots.Front) });
                    hunter._triggerOn = new TriggerCalls[1] { TriggerCalls.OnTurnFinished };
                    hunter.connectionEffects = ExtensionMethods.ToEffectInfoArray(new Effect[]
                    {
                        new Effect(ScriptableObject.CreateInstance<ApplyTerrorEffect>(), 1, null, Targetting.Random(false))
                    });
                    _hunter = hunter;
                }
                return _hunter;
            }
        }
        static BasePassiveAbilitySO _rejuvination;
        public static BasePassiveAbilitySO Rejuvination
        {
            get
            {
                if (_rejuvination == null)
                {
                    RejuvinationPassiveAbility pheonix = ScriptableObject.CreateInstance<RejuvinationPassiveAbility>();
                    pheonix._passiveName = "Rejuvination";
                    pheonix.passiveIcon = ResourceLoader.LoadSprite("rejuvination.png", 32);
                    pheonix.type = (PassiveAbilityTypes)Terror.terror + 1;
                    pheonix._enemyDescription = "On death, if this enemy is above 4 maximum health, prevent it, fully heal this enemy, halve their max health, remove one of their abilities from the timeline, and apply 1 Fire to this position.";
                    pheonix._characterDescription = "On death, if this party member is above 4 maximum health, prevent it, fully heal this character, halve their max health, inflict 1 Stunned on them, and apply 1 Fire to this position.";
                    pheonix.doesPassiveTriggerInformationPanel = false;
                    pheonix._triggerOn = new TriggerCalls[] { TriggerCalls.CanDie };
                    _rejuvination = pheonix;
                }
                return _rejuvination;
            }
        }
        static BasePassiveAbilitySO _burning;
        public static BasePassiveAbilitySO Burning
        {
            get
            {
                if (_burning == null)
                {
                    PerformEffectPassiveAbility burning = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                    burning._passiveName = "Burning";
                    burning.passiveIcon = ResourceLoader.LoadSprite("burningIcon.png", 32);
                    burning.type = (PassiveAbilityTypes)Terror.terror + 2;
                    burning._enemyDescription = "On receiving direct damage, inflict 1 Fire on the Opposing position.";
                    burning._characterDescription = burning._enemyDescription;
                    burning.doesPassiveTriggerInformationPanel = true;
                    burning.effects = ExtensionMethods.ToEffectInfoArray(new Effect[] { new Effect(RootActionEffect.Create(new Effect[]
                    {
                        new Effect(ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), 1, null, Slots.Front)
                    }), 1, null, Slots.Self) });
                    burning._triggerOn = new TriggerCalls[] { TriggerCalls.OnDirectDamaged };
                    _burning = burning;
                }
                return _burning;
            }
        }
        static BasePassiveAbilitySO _nervous;
        public static BasePassiveAbilitySO Nervous
        {
            get
            {
                if (_nervous == null)
                {
                    PerformEffectPassiveAbility nervous = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                    nervous._passiveName = "Nervous";
                    nervous.passiveIcon = ResourceLoader.LoadSprite("panic.png", 32);
                    nervous.type = (PassiveAbilityTypes)Terror.terror + 3;
                    nervous._enemyDescription = "On moving, gain another action. This action cannot be \"Light Scratches.\"";
                    nervous._characterDescription = "won't work. oops!";
                    nervous.doesPassiveTriggerInformationPanel = true;
                    nervous.effects = ExtensionMethods.ToEffectInfoArray(new Effect[] 
                    { 
                        new Effect(BasicEffects.SetStoreValue(UnitStoredValueNames.DemonCoreW), 1, null, Slots.Self),
                        new Effect(ScriptableObject.CreateInstance<AddTurnCasterToTimelineEffect>(), 1, null, Slots.Self),
                        new Effect(RootActionEffect.Create(new Effect[]
                        {
                            new Effect(BasicEffects.SetStoreValue(UnitStoredValueNames.DemonCoreW), 0, null, Slots.Self)
                        }), 0, null, Slots.Self)
                    });
                    nervous._triggerOn = new TriggerCalls[] { TriggerCalls.OnMoved };
                    _nervous = nervous;
                }
                return _nervous;
            }
        }
        static BasePassiveAbilitySO _repression;
        public static BasePassiveAbilitySO Repression
        {
            get
            {
                if (_repression == null)
                {
                    RepressionPassiveAbility.Setup();
                    RepressionPassiveAbility nervous = ScriptableObject.CreateInstance<RepressionPassiveAbility>();
                    nervous._passiveName = "Repression";
                    nervous.passiveIcon = ResourceLoader.LoadSprite("repression.png", 32);
                    nervous.type = (PassiveAbilityTypes)Terror.terror + 4;
                    nervous._enemyDescription = "If this enemy took no damage of any kind last turn, this enemy gains another action per turn, permanently.";
                    nervous._characterDescription = "won't work. oops!";
                    nervous.doesPassiveTriggerInformationPanel = false;
                    nervous.specialStoredValue = RepressionPassiveAbility.bonusTurns;
                    nervous._triggerOn = Passives.Multiattack._triggerOn;
                    nervous._isItAdditive = ((IntegerSetterPassiveAbility)Passives.Multiattack)._isItAdditive;
                    nervous.integerValue = 1;
                    _repression = nervous;
                }
                return _repression;
            }
        }
        static BasePassiveAbilitySO _freak;
        public static BasePassiveAbilitySO Freak
        {
            get
            {
                UnitSideNotLostSheep allAlly = ScriptableObject.CreateInstance<UnitSideNotLostSheep>();
                allAlly.getAllies = true;
                allAlly.getAllUnitSlots = false;
                if (_freak == null)
                {
                    PerformEffectPassiveAbility burning = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                    burning._passiveName = "Freak Out";
                    burning.passiveIcon = ResourceLoader.LoadSprite("FreakOutIcon.png", 32);
                    burning.type = (PassiveAbilityTypes)Terror.terror + 5;
                    burning._enemyDescription = "Upon receiving any damage, apply 0-1 Power to all allies that aren't Lost Sheep.";
                    burning._characterDescription = burning._enemyDescription;
                    burning.doesPassiveTriggerInformationPanel = true;
                    burning.effects = ExtensionMethods.ToEffectInfoArray(new Effect[] { new Effect(ScriptableObject.CreateInstance<ApplyPowerRangePlusOneEffect>(), 0, null, allAlly) });
                    burning._triggerOn = new TriggerCalls[] { TriggerCalls.OnDamaged };
                    _freak = burning;
                }
                return _freak;
            }
        }
        static BasePassiveAbilitySO _coward;
        public static BasePassiveAbilitySO Coward
        {
            get
            {
                if (_coward == null)
                {
                    PerformEffectPassiveAbility cowardly = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                    cowardly._passiveName = "Cowardice";
                    cowardly.passiveIcon = ResourceLoader.LoadSprite("Cowardice.png", 32);
                    cowardly.type = (PassiveAbilityTypes)((int)Freak.type + 27);
                    cowardly._enemyDescription = "At the start and end of the enemies' turn, if there are no other enemies without \"Cowardice\" as a passive, instantly flee.";
                    cowardly._characterDescription = cowardly._enemyDescription;
                    cowardly.doesPassiveTriggerInformationPanel = false;
                    cowardly.effects = ExtensionMethods.ToEffectInfoArray(new Effect[] { new Effect(RootActionEffect.Create(new Effect[]
                    {
                        new Effect(ScriptableObject.CreateInstance<CowardEffect>(), 1, null, Slots.Self)
                    }), 1, null, Slots.Self) });
                    cowardly._triggerOn = new TriggerCalls[] { TriggerCalls.OnPlayerTurnEnd_ForEnemy, TriggerCalls.OnRoundFinished };
                    cowardly.conditions = new EffectorConditionSO[]
                    {
                        ScriptableObject.CreateInstance<CowardCondition>()
                    };
                    _coward = cowardly;
                }
                return _coward;
            }
        }
        static BasePassiveAbilitySO _intimidated;
        public static BasePassiveAbilitySO Intimidated
        {
            get
            {
                if (_intimidated == null)
                {
                    PerformEffectPassiveAbility fear = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                    fear._passiveName = "Intimidated";
                    fear.passiveIcon = ResourceLoader.LoadSprite("intimidated.png", 32);
                    fear.type = (PassiveAbilityTypes)(AmbushManager.Patiently - 4032);
                    fear._enemyDescription = "When a party member moves in front of this enemy, reroll one of this enemy's abilities.";
                    fear._characterDescription = "wotn workn...";
                    fear.doesPassiveTriggerInformationPanel = true;
                    fear.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1] { new Effect(ScriptableObject.CreateInstance<ReRollTargetTimelineAbilityEffect>(), 1, null, Slots.Self) });
                    fear._triggerOn = new TriggerCalls[1] { (TriggerCalls)AmbushManager.Patiently };
                    _intimidated = fear;
                }
                return _intimidated;
            }
        }
        static BasePassiveAbilitySO _blueEssence;
        public static BasePassiveAbilitySO BlueEssence
        {
            get
            {
                if (_blueEssence == null)
                {
                    Connection_PerformEffectPassiveAbility blue = ScriptableObject.CreateInstance<Connection_PerformEffectPassiveAbility>();
                    blue._passiveName = "Blue Essence";
                    blue.passiveIcon = ResourceLoader.LoadSprite("blueEssence.png", 32);
                    blue.type = PassiveAbilityTypes.Essence;
                    blue._enemyDescription = "At the start of combat allows Lucky Pigment to be toggled to Blue.";
                    blue._characterDescription = "Allows lucky pigment to be toggled to Purble.";
                    blue.doesPassiveTriggerInformationPanel = true;
                    blue.immediateEffect = false;
                    LuckyBlueColorSetEffect bluler = ScriptableObject.CreateInstance<LuckyBlueColorSetEffect>();
                    bluler._luckyColor = Pigments.Blue;
                    blue.connectionEffects = ExtensionMethods.ToEffectInfoArray(new Effect[]
                    {
                        new Effect(ScriptableObject.CreateInstance<ShowBlueEssencePassiveEffect>(), 1, null, Slots.Self),
                new Effect(bluler, 1, new IntentType?(), Slots.Self, (EffectConditionSO) null)
                    });
                    blue._triggerOn = new TriggerCalls[]
                    {
                TriggerCalls.Count
                    };
                    blue.disconnectionEffects = new EffectInfo[0];
                    _blueEssence = blue;
                }
                return _blueEssence;
            }
        }
        static BasePassiveAbilitySO _lazy;
        public static BasePassiveAbilitySO Lazy
        {
            get
            {
                if (_lazy == null)
                {
                    PerformEffectPassiveAbility ethereal = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                    ethereal._passiveName = "Lazy";
                    ethereal.passiveIcon = ResourceLoader.LoadSprite("Lazy.png");
                    ethereal._enemyDescription = "When fleeing, this enemy will return at the end of the next 2 rounds if combat hasn't ended.";
                    ethereal._characterDescription = "When fleeing, this character will return at the end of the next 2 rounds if combat hasn't ended.";
                    ethereal.type = ButterflyUnboxer.SkyloftPassive;
                    ethereal.doesPassiveTriggerInformationPanel = true;
                    ethereal._triggerOn = new TriggerCalls[] { TriggerCalls.OnFleeting };
                    ethereal.effects = new EffectInfo[0];
                    _lazy = ethereal;
                }
                return _lazy;
            }
        }
        static BasePassiveAbilitySO _automated;
        public static BasePassiveAbilitySO Automated
        {
            get
            {
                if (_automated == null)
                {
                    PerformEffectPassiveAbility auto = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                    auto._passiveName = "Automated";
                    auto.passiveIcon = ResourceLoader.LoadSprite("WindlePassive.png", 32);
                    auto.type = (PassiveAbilityTypes)8281271;
                    auto._enemyDescription = "idk";
                    auto._characterDescription = "At the end of each turn, if this party member has not manually performed an ability, perform a random ability.";
                    auto.doesPassiveTriggerInformationPanel = true;auto._triggerOn = new TriggerCalls[] { TriggerCalls.OnTurnFinished };
                    ManuallyActionDoneEffectorCondition m = ScriptableObject.CreateInstance<ManuallyActionDoneEffectorCondition>();
                    m._resultShouldBe = false;
                    m._justCheckAbility = true;
                    auto.conditions = new EffectorConditionSO[] { m };
                    auto.effects = ExtensionMethods.ToEffectInfoArray(new Effect[]
                    {
                        new Effect(ScriptableObject.CreateInstance<PerformRandomAbilityEffect>(), 1, IntentType.Misc, Slots.Self)
                    });
                    _automated = auto;
                }
                return _automated;
            }
        }
        static BasePassiveAbilitySO _missFaced;
        public static BasePassiveAbilitySO MissFaced
        {
            get
            {
                if (_missFaced == null)
                {
                    BasePassiveAbilitySO mf = ScriptableObject.Instantiate(Passives.TwoFaced);
                    mf._locID = "";
                    mf.passiveIcon = ResourceLoader.LoadSprite("MissFaced.png");
                    mf._passiveName = "Miss-Faced";
                    mf._enemyDescription = "On being direct damaged and at the end of each round, this unit's health color changes between Red and Blue.";
                    mf._characterDescription = mf._enemyDescription;
                    mf._triggerOn = new List<TriggerCalls>(Passives.TwoFaced._triggerOn) { TriggerCalls.OnRoundFinished }.ToArray();
                    _missFaced = mf;
                }
                return _missFaced;
            }
        }
        static BasePassiveAbilitySO _decaySingularity;
        public static BasePassiveAbilitySO DecaySingularity
        {
            get
            {
                if (_decaySingularity == null)
                {
                    PerformEffectPassiveAbility decay = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                    decay._passiveName = "Decay";
                    decay.passiveIcon = Passives.Decay.passiveIcon;
                    decay.type = PassiveAbilityTypes.Decay;
                    decay._enemyDescription = "On dying from Withering, spawn a Singularity.";
                    decay._characterDescription = "eh";
                    decay.doesPassiveTriggerInformationPanel = true;
                    SpawnEnemyInSlotFromEntryStringNameEffect si = ScriptableObject.CreateInstance<SpawnEnemyInSlotFromEntryStringNameEffect>();
                    si.en = "Singularity_EN";
                    si.trySpawnAnywhereIfFail = true;
                    decay.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1] { new Effect(si, 0, null, Slots.Self) });
                    decay._triggerOn = new TriggerCalls[1] { TriggerCalls.OnDeath };
                    decay.conditions = new EffectorConditionSO[] { ScriptableObject.CreateInstance<IsWitheringDeathCondition>() };
                    _decaySingularity = decay;
                }
                return _decaySingularity;
            }
        }
        static BasePassiveAbilitySO _turbulent;
        public static BasePassiveAbilitySO Turbulent
        {
            get
            {
                if (_turbulent == null)
                {
                    PerformEffectPassiveAbility turb = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                    turb._passiveName = "Turbulent";
                    turb.type = (PassiveAbilityTypes)7644013;
                    turb.passiveIcon = ResourceLoader.LoadSprite("BlackstarPassive.png", 32);
                    turb._enemyDescription = "On being directly damaged, shuffle the position of all enemies.";
                    turb._characterDescription = turb._enemyDescription;
                    turb.doesPassiveTriggerInformationPanel = true;
                    turb.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1] { new Effect(ScriptableObject.CreateInstance<MassSwapZoneEffect>(), 1, null, Slots.SlotTarget(new int[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 }, true)) });
                    turb._triggerOn = new TriggerCalls[1] { TriggerCalls.OnDirectDamaged };
                    _turbulent = turb;
                }
                return _turbulent;
            }
        }
        static BasePassiveAbilitySO _compulsory;
        public static BasePassiveAbilitySO Compulsory
        {
            get
            {
                if (_compulsory == null)
                {
                    PerformEffectPassiveAbility com = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                    com._passiveName = "Compulsory";
                    com.type = (PassiveAbilityTypes)7644213;
                    com.passiveIcon = ResourceLoader.LoadSprite("IndicatorPassive.png", 32);
                    com._enemyDescription = "On being directly damaged, force the Opposing unit to perform a random ability.";
                    com._characterDescription = com._enemyDescription;
                    com.doesPassiveTriggerInformationPanel = true;
                    com.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1] { new Effect(SubActionEffect.Create(new Effect[] { new Effect(CasterRootActionEffect.Create(new Effect[] { new Effect(ScriptableObject.CreateInstance<PerformRandomAbilityEffect>(), 1, null, Slots.Self) }), 1, null, Slots.Self) }), 1, null, Slots.Front) });
                    com._triggerOn = new TriggerCalls[1] { TriggerCalls.OnDirectDamaged };
                    _compulsory = com;
                }
                return _compulsory;
            }
        }
        static BasePassiveAbilitySO _badDog;
        public static BasePassiveAbilitySO BadDog
        {
            get
            {
                if (_badDog == null)
                {
                    BadDogPassiveAbility bad = ScriptableObject.CreateInstance<BadDogPassiveAbility>();
                    bad._passiveName = "Bad Dog";
                    bad.type = (PassiveAbilityTypes)7644513;
                    bad.passiveIcon = ResourceLoader.LoadSprite("MawPassive.png", 32);
                    bad._enemyDescription = "During the player's turn, whenever anything moves, if this enemy has an Opposing party member, remove all of its actions from the timeline. \nOtherwise, return all lost actions.";
                    bad._characterDescription = "wont work";
                    bad.doesPassiveTriggerInformationPanel = true;
                    bad.effects = new EffectInfo[0];
                    bad._triggerOn = new TriggerCalls[1] { TriggerCalls.Count };
                    _badDog = bad;
                }
                return _badDog;
            }
        }
        static BasePassiveAbilitySO _waves;
        public static BasePassiveAbilitySO Waves
        {
            get
            {
                if (_waves == null)
                {
                    PerformEffectPassiveAbility turb = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                    turb._passiveName = "Waves";
                    turb.type = (PassiveAbilityTypes)7648910;
                    turb.passiveIcon = ResourceLoader.LoadSprite("WavesPassive.png", 32);
                    turb._enemyDescription = "On moving, inflict 2 Deep Water on the Opposing position.";
                    turb._characterDescription = turb._enemyDescription;
                    turb.doesPassiveTriggerInformationPanel = true;
                    turb.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1] { new Effect(ScriptableObject.CreateInstance<ApplyWaterSlotEffect>(), 2, null, Slots.Front) });
                    turb._triggerOn = new TriggerCalls[1] { TriggerCalls.OnMoved };
                    _waves = turb;
                }
                return _waves;
            }
        }
        static BasePassiveAbilitySO _whimsy;
        public static BasePassiveAbilitySO Whimsy
        {
            get
            {
                if (_whimsy == null)
                {
                    ChildrenPassiveAbility whi = ScriptableObject.CreateInstance<ChildrenPassiveAbility>();
                    whi._passiveName = "Whimsy";
                    whi.type = (PassiveAbilityTypes)38381149;
                    whi.passiveIcon = ResourceLoader.LoadSprite("WileyPassive.png", 32);
                    whi._enemyDescription = "Most Status Effects and some Field Effects will no longer decrease while this unit is in combat.";
                    whi._characterDescription = whi._enemyDescription;
                    whi.doesPassiveTriggerInformationPanel = false;
                    whi._triggerOn = new TriggerCalls[] { TriggerCalls.OnBeingDamaged, TriggerCalls.OnRoundFinished, TriggerCalls.OnDeath };
                    _whimsy = whi;
                }
                return _whimsy;
            }
        }
        static BasePassiveAbilitySO _fakeDecay;
        public static BasePassiveAbilitySO FakeDecay
        {
            get
            {
                if (_fakeDecay == null)
                {
                    PerformEffectPassiveAbility whi = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                    whi._passiveName = "Decay";
                    whi.type = PassiveAbilityTypes.Decay;
                    whi.passiveIcon = Passives.Decay.passiveIcon;
                    whi._enemyDescription = "On death, lose a part of yourself.";
                    whi._characterDescription = whi._enemyDescription;
                    whi.doesPassiveTriggerInformationPanel = false;
                    whi._triggerOn = new TriggerCalls[] { TriggerCalls.Count};
                    whi.effects = new EffectInfo[0];
                    _fakeDecay = whi;
                }
                return _fakeDecay;
            }
        }
        static BasePassiveAbilitySO _appointment;
        public static BasePassiveAbilitySO Appointment
        {
            get
            {
                if (_appointment == null)
                {
                    ExtraAttackPassiveAbility baseExtra = LoadedAssetsHandler.GetEnemy("Xiphactinus_EN").passiveAbilities[1] as ExtraAttackPassiveAbility;
                    DoubleExtraAttackPassiveAbility point = ScriptableObject.CreateInstance<DoubleExtraAttackPassiveAbility>();
                    point.conditions = baseExtra.conditions;
                    point.passiveIcon = baseExtra.passiveIcon;
                    point.specialStoredValue = baseExtra.specialStoredValue;
                    point.doesPassiveTriggerInformationPanel = baseExtra.doesPassiveTriggerInformationPanel;
                    point.type = baseExtra.type;
                    point._extraAbility = new ExtraAbilityInfo();
                    point._extraAbility.rarity = baseExtra._extraAbility.rarity;
                    point._extraAbility.cost = baseExtra._extraAbility.cost;
                    point._secondExtraAbility = new ExtraAbilityInfo();
                    point._secondExtraAbility.rarity = point._extraAbility.rarity;
                    point._secondExtraAbility.cost = point._extraAbility.cost;
                    point._passiveName = "Appointment";
                    point._enemyDescription = "This enemy will perforn an extra ability \"Appointment\" each turn.";
                    point._characterDescription = baseExtra._characterDescription;
                    point._triggerOn = baseExtra._triggerOn;
                    PerformRandomEffectsAmongEffects posi = ScriptableObject.CreateInstance<PerformRandomEffectsAmongEffects>();
                    posi.List = new Dictionary<string, string>();
                    posi.List.Add(nameof(ApplySpotlightEffect), "");
                    posi.List.Add(nameof(ApplyFocusedEffect), "");
                    posi.List.Add(nameof(ApplyDivineProtectionEffect), "");
                    posi.List.Add(nameof(ApplyPowerEffect), nameof(THE_DEAD));
                    posi.List.Add(nameof(ApplyHasteEffect), nameof(Hawthorne));
                    posi.List.Add(nameof(ApplyAnestheticsEffect), nameof(THE_DEAD));
                    posi.List.Add(nameof(ApplyDeterminedEffect), nameof(THE_DEAD));
                    posi.List.Add(nameof(ApplyPhotoSynthesisEffect), nameof(Hawthorne));
                    posi.List.Add("ApplyInvigoratedEffect", "DigiMisfits");
                    posi.List.Add("ApplyAdrenalineEffect", "ChillyBonezMod");
                    posi.List.Add("ApplyHexedEffect", "ChillyBonezMod");
                    posi.List.Add("ApplyGrowthEffect", "MFoolModOne");
                    posi.List.Add("ApplyWildCardEffect", "MFoolModOne");
                    posi.List.Add("ApplyHellfireEffect", "Abbadon");
                    posi.List.Add("ApplyBerserkEffect", "BOSpecialItems.Content.Effects");
                    posi.List.Add("ApplyFuryEffect", "BOSpecialItems.Content.Effects");
                    posi.List.Add("ApplyPoweredUpEffect", "BOSpecialItems.Content.Effects");
                    posi.List.Add("ApplySurviveEffect", "BOSpecialItems.Content.Effects");
                    posi.List.Add("ApplyBlessEffect", "");
                    posi.List.Add("ApplySpiritualEnergyEffect", "FiendishFools");
                    posi.List.Add("ApplyBoostedEffect", "");
                    posi.Setup();
                    posi.Effects.Add(ScriptableObject.CreateInstance<ApplyDodgeEffect>());

                    Ability bonus = new Ability();
                    bonus.name = "Appointment";
                    bonus.description = "If there is no Opposing party member, queue \"Procedure\" as an additional action next turn.";
                    bonus.effects = new Effect[3];
                    bonus.effects[0] = new Effect(ScriptableObject.CreateInstance<IsUnitEffect>(), 1, IntentType.Misc_Hidden, Slots.Front);
                    bonus.effects[1] = new Effect(BasicEffects.GetVisuals("Weep_A", false, Slots.Self), 1, null, Slots.Front, BasicEffects.DidThat(false));
                    bonus.effects[2] = new Effect(BasicEffects.SetStoreValue(DoubleExtraAttackPassiveAbility.value), 1, IntentType.Misc, Slots.Self, BasicEffects.DidThat(false, 2));
                    bonus.visuals = null;
                    bonus.animationTarget = Slots.Front;
                    point._extraAbility.ability = bonus.CharacterAbility().ability;

                    Ability bins = new Ability();
                    bins.name = "Procedure";
                    bins.description = "Apply 10 random Positive Status Effects on every enemy.";
                    bins.effects = new Effect[]
                    {
                        new Effect(posi, 10, IntentType.Misc, Targetting.AllAlly),
                    };
                    bins.visuals = LoadedAssetsHandler.GetCharacterAbility("Absolve_1_A").visuals;
                    bins.animationTarget = Targetting.AllAlly;
                    point._secondExtraAbility.ability = bins.CharacterAbility().ability;
                    _appointment = point;
                }
                return _appointment;
            }
        }
        static BasePassiveAbilitySO _miinoDecay;
        public static BasePassiveAbilitySO MiinoDecay
        {
            get
            {
                if (_miinoDecay == null)
                {
                    PerformEffectPassiveAbility decay = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                    decay._passiveName = "Decay";
                    decay.type = PassiveAbilityTypes.Decay;
                    decay.passiveIcon = Passives.Decay.passiveIcon;
                    decay._enemyDescription = "On death, 40% chance to spawn a Minana.";
                    decay._characterDescription = decay._enemyDescription;
                    decay.doesPassiveTriggerInformationPanel = true;
                    PercentageEffectorCondition p40 = ScriptableObject.CreateInstance<PercentageEffectorCondition>();
                    p40.triggerPercentage = 40;
                    decay.conditions = new EffectorConditionSO[] { p40 };
                    decay._triggerOn = new TriggerCalls[] { TriggerCalls.OnDeath };
                    SpawnEnemyInSlotFromEntryStringNameEffect si = ScriptableObject.CreateInstance<SpawnEnemyInSlotFromEntryStringNameEffect>();
                    si.en = "Minana_EN";
                    si.trySpawnAnywhereIfFail = true;
                    decay.effects = ExtensionMethods.ToEffectInfoArray(new Effect(si, 0, null, Slots.Self).SelfArray());
                    _miinoDecay = decay;
                }
                return _miinoDecay;
            }
        }
        static BasePassiveAbilitySO _knock;
        public static BasePassiveAbilitySO Knock
        {
            get
            {
                if (_knock == null)
                {
                    ExtraAttackPassiveAbility baseExtra = LoadedAssetsHandler.GetEnemy("Xiphactinus_EN").passiveAbilities[1] as ExtraAttackPassiveAbility;
                    ExtraAttackPassiveAbility pressure = ScriptableObject.Instantiate<ExtraAttackPassiveAbility>(baseExtra);
                    pressure._passiveName = "Knock";
                    pressure._enemyDescription = "This enemy will perforn an extra ability \"Knock\" each turn.";
                    Ability bonus = new Ability();
                    bonus.name = "Knock";
                    bonus.description = "Deal a Little damage to the Opposing party member and move them to the Left or Right.";
                    bonus.priority = -3;
                    bonus.effects = new Effect[2];
                    bonus.effects[0] = new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 2, IntentType.Damage_1_2, Slots.Front);
                    bonus.effects[1] = new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, IntentType.Swap_Sides, Slots.Front);
                    bonus.visuals = LoadedAssetsHandler.GetEnemyAbility("Wriggle_A").visuals;
                    bonus.animationTarget = Slots.Front;
                    bonus.rarity = 0;
                    AbilitySO ability = bonus.EnemyAbility().ability;
                    pressure._extraAbility.ability = ability;
                    _knock = pressure;
                }
                return _knock;
            }
        }
        static BasePassiveAbilitySO _practical;
        public static BasePassiveAbilitySO Practical
        {
            get
            {
                if (_practical == null)
                {
                    PerformEffectPassiveAbility prac = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                    prac._passiveName = "Practical";
                    prac.type = TrainHandler.Practical;
                    prac.passiveIcon = ResourceLoader.LoadSprite("PracticalPassive.png", 32);
                    prac._enemyDescription = "On taking direct damage, shift one Light phase backwards. " +
                        "\nOn any ability being used other than by this enemy, 50% chance to toggle the Crosswalk phase.";
                    prac._characterDescription = prac._enemyDescription;
                    prac.doesPassiveTriggerInformationPanel = false;
                    prac.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1] { new Effect(ScriptableObject.CreateInstance<TrainEffect>(), -1, null, Slots.Self) });
                    prac._triggerOn = new TriggerCalls[1] { TriggerCalls.OnDirectDamaged };
                    _practical = prac;
                }
                return _practical;
            }
        }
        static BasePassiveAbilitySO _trolley;
        public static BasePassiveAbilitySO Trolley
        {
            get
            {
                if (_trolley == null)
                {
                    ExtraAttackPassiveAbility baseExtra = LoadedAssetsHandler.GetEnemy("Xiphactinus_EN").passiveAbilities[1] as ExtraAttackPassiveAbility;
                    //ExtraAttackPassiveAbility pressure = ScriptableObject.Instantiate<ExtraAttackPassiveAbility>(baseExtra);
                    //pressure._passiveName = "Trolley";
                    //pressure._enemyDescription = "This enemy will perforn an extra ability \"Trolley\" each turn.";
                    InstantiateExtraAttackPassiveAbility pressure = ScriptableObject.CreateInstance<InstantiateExtraAttackPassiveAbility>();
                    pressure.conditions = baseExtra.conditions;
                    pressure.passiveIcon = baseExtra.passiveIcon;
                    pressure.specialStoredValue = baseExtra.specialStoredValue;
                    pressure.doesPassiveTriggerInformationPanel = baseExtra.doesPassiveTriggerInformationPanel;
                    pressure.type = baseExtra.type;
                    pressure._extraAbility = new ExtraAbilityInfo();
                    pressure._extraAbility.rarity = baseExtra._extraAbility.rarity;
                    pressure._extraAbility.cost = baseExtra._extraAbility.cost;
                    pressure._passiveName = "Trolley";
                    pressure._enemyDescription = "This enemy will perforn an extra ability \"Trolley\" each turn.";
                    pressure._characterDescription = baseExtra._characterDescription;
                    pressure._triggerOn = baseExtra._triggerOn;
                    Ability bonus = new Ability();
                    bonus.name = "Trolley";
                    bonus.description = "If the Light phase is Green, deal 0-20 damage to either all enemies or all party members.";
                    bonus.effects = new Effect[7];
                    bonus.effects[0] = new Effect(BasicEffects.GetVisuals("Salt/Train", false, TrainTargetting.Create(false)), 0, IntentType.Damage_21, TrainTargetting.Create(true), ScriptableObject.CreateInstance<SecondTrainCondition>());
                    bonus.effects[1] = new Effect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 0, IntentType.Damage_1_2 , TrainTargetting.Create(true));
                    bonus.effects[2] = new Effect(ScriptableObject.CreateInstance<RandomDamageBetweenPreviousAndEntryEffect>(), 20, IntentType.Damage_3_6, TrainTargetting.Create(true), ScriptableObject.CreateInstance<SecondTrainCondition>());
                    bonus.effects[3] = new Effect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 0, IntentType.Damage_7_10, TrainTargetting.Create(true));
                    bonus.effects[4] = new Effect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 0, IntentType.Damage_11_15, TrainTargetting.Create(true));
                    bonus.effects[5] = new Effect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 0, IntentType.Damage_16_20, TrainTargetting.Create(true));
                    bonus.effects[6] = new Effect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 0, CustomIntentIconSystem.GetIntent("FallColor"), TrainTargetting.Create(true));
                    bonus.visuals = null;
                    bonus.animationTarget = Slots.Self;
                    AbilitySO ability = bonus.CharacterAbility().ability;
                    pressure._extraAbility.ability = ability;
                    _trolley = pressure;
                }
                return _trolley;
            }
        }

    }

    public class AbilitySelector_PigmentFlower : BaseAbilitySelectorSO
    {
        [Header("Special Abilities")]
        [SerializeField]
        public string photsynthesize = "Photosynthesize";

        public override bool UsesRarity => true;

        public override int GetNextAbilitySlotUsage(List<CombatAbility> abilities, IUnit unit)
        {
            int maxExclusive1 = 0;
            int maxExclusive2 = 0;
            List<int> intList1 = new List<int>();
            List<int> intList2 = new List<int>();
            bool hasFleeting = unit.ContainsPassiveAbility(PassiveAbilityTypes.Fleeting);
            for (int index = 0; index < abilities.Count; ++index)
            {
                if (this.ShouldBeIgnored(abilities[index], unit))
                {
                    maxExclusive2 += abilities[index].rarity.rarityValue;
                    intList2.Add(index);
                }
                else if (this.MustBeUsed(abilities[index], unit))
                {
                    return index;
                }
                else
                {
                    maxExclusive1 += abilities[index].rarity.rarityValue;
                    intList1.Add(index);
                }
            }
            int num1 = UnityEngine.Random.Range(0, maxExclusive1);
            int num2 = 0;
            foreach (int index in intList1)
            {
                num2 += abilities[index].rarity.rarityValue;
                if (num1 < num2)
                    return index;
            }
            int num3 = UnityEngine.Random.Range(0, maxExclusive2);
            int num4 = 0;
            foreach (int index in intList2)
            {
                num4 += abilities[index].rarity.rarityValue;
                if (num3 < num4)
                    return index;
            }
            return -1;
        }

        public bool ShouldBeIgnored(CombatAbility ability, IUnit unit)
        {
            string name = ability.ability._abilityName;
            int pigs = 0;
            foreach (ManaBarSlot mana in CombatManager.Instance._stats.MainManaBar.ManaBarSlots)
            {
                if (!mana.IsEmpty && mana.ManaColor == unit.HealthColor) pigs++;
            }
            return pigs <= 0 && name == this.photsynthesize;
        }
        public bool MustBeUsed(CombatAbility ability, IUnit unit)
        {
            string name = ability.ability._abilityName;
            int pigs = 0;
            foreach (ManaBarSlot mana in CombatManager.Instance._stats.MainManaBar.ManaBarSlots)
            {
                if (!mana.IsEmpty && mana.ManaColor == unit.HealthColor) pigs++;
            }
            return pigs > 4 && name == this.photsynthesize;
        }
    }
    public class SurvivalInstinctEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            List<TargetSlotInfo> targ = new List<TargetSlotInfo>();
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit) targ.Add(target);
            }
            if (targ.Count <= 0) return false;
            AnimationVisualsEffect showdown = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            showdown._animationTarget = Slots.Self;
            showdown._visuals = LoadedAssetsHandler.GetCharacterAbility("Showdown_1_A").visuals;
            DirectDeathEffect die = ScriptableObject.CreateInstance<DirectDeathEffect>();
            Effect[] fect = new Effect[] { new Effect(showdown, 1, null, Slots.Self), new Effect(die, 1, null, Slots.Self) };
            EffectInfo[] info = ExtensionMethods.ToEffectInfoArray(fect);
            CombatManager.Instance.AddSubAction(new EffectAction(info, targ[UnityEngine.Random.Range(0, targ.Count)].Unit));
            return true;
        }
    }

    public static class SigilManager
    {
        public static SigilPassiveAbility GetSigilPassive(IPassiveEffector unit)
        {
            foreach (BasePassiveAbilitySO passive in unit.PassiveAbilities)
            {
                if (passive is SigilPassiveAbility sigility) return sigility;
            }
            return null;
        }
        public static void PostNotification(Action<CombatManager, string, object, object> orig, CombatManager self, string notificationName, object sender, object args)
        {
            AnglerHandler.NotifCheck(notificationName, sender, args);
            orig(self, notificationName, sender, args);
            if (sender is IUnit unit)
            {
                if (unit.IsUnitCharacter)
                {
                    foreach (CharacterCombat chara in self._stats.CharactersOnField.Values)
                    {
                        if (notificationName == TriggerCalls.OnBeingDamaged.ToString() && GetSigilPassive(chara) != null && GetSigilPassive(chara)._sigil == SigilType.Defensive && args is DamageReceivedValueChangeException hitBy && hitBy.directDamage)
                        {
                            hitBy.AddModifier(new FloatMod(0.5f, false));
                        }
                        else if (notificationName == TriggerCalls.OnWillApplyDamage.ToString() && GetSigilPassive(chara) != null && GetSigilPassive(chara)._sigil == SigilType.Offensive && args is DamageDealtValueChangeException hitting)
                        {
                            hitting.AddModifier(new AdditionValueModifier(true, 3));
                        }
                    }
                    if (notificationName == TriggerCalls.OnBeingDamaged.ToString() && sender is CharacterCombat CH && GetSigilPassive(CH) != null && GetSigilPassive(CH)._sigil == SigilType.Spectral && args is DamageReceivedValueChangeException hits)
                    {
                        hits.AddModifier(new FloatMod(0f, false));
                    }
                }
                else
                {
                    foreach (EnemyCombat enemy in self._stats.EnemiesOnField.Values)
                    {
                        if (notificationName == TriggerCalls.OnBeingDamaged.ToString() && GetSigilPassive(enemy) != null && GetSigilPassive(enemy)._sigil == SigilType.Defensive && args is DamageReceivedValueChangeException hitBy && hitBy.directDamage)
                        {
                            hitBy.AddModifier(new FloatMod(0.5f, false));
                        }
                        else if (notificationName == TriggerCalls.OnWillApplyDamage.ToString() && GetSigilPassive(enemy) != null && GetSigilPassive(enemy)._sigil == SigilType.Offensive && args is DamageDealtValueChangeException hitting)
                        {
                            hitting.AddModifier(new AdditionValueModifier(true, 3));
                        }
                    }
                    if (notificationName == TriggerCalls.OnBeingDamaged.ToString() && sender is EnemyCombat EN && GetSigilPassive(EN) != null && GetSigilPassive(EN)._sigil == SigilType.Spectral && args is DamageReceivedValueChangeException hits)
                    {
                        hits.AddModifier(new FloatMod(0f, false));
                    }
                }
            }
            NobodyMoveHandler.NotifCheck(notificationName, sender, args);
            ReplacementHandler.NotifCheck(notificationName, sender, args);
            if (notificationName == TriggerCalls.OnMoved.ToString() && BadDogHandler.IsPlayerTurn()) BadDogHandler.RunCheckFunction();
            if (notificationName == TriggerCalls.OnAbilityUsed.ToString()) TrainHandler.SwitchTrainTargetting(sender);
            if (notificationName == TriggerCalls.OnDeath.ToString() && sender is ITurn) TrainHandler.CheckAll();
            SigilSongHandler.NotifCheck(notificationName, sender, args);
            StampHandler.NotifCheck(notificationName, sender, args);
        }

        public static UnitStoredValueNames Sigil = (UnitStoredValueNames)68369752;

        public static string SigilValue(
          Func<TooltipTextHandlerSO, UnitStoredValueNames, int, string> orig,
          TooltipTextHandlerSO self,
          UnitStoredValueNames storedValue,
          int value)
        {
            Color magenta = Color.magenta;
            string str1;
            if (storedValue == Sigil)
            {
                if (value <= 0)
                {
                    str1 = "";
                }
                else if (value == 1)
                {
                    string str2 = "Defensive Sigil";
                    string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(self._positiveSTColor) + ">";
                    string str4 = "</color>";
                    str1 = str3 + str2 + str4;
                }
                else if (value == 2)
                {
                    string str2 = "Offensive Sigil";
                    string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(self._negativeSTColor) + ">";
                    string str4 = "</color>";
                    str1 = str3 + str2 + str4;
                }
                else if (value == 3)
                {
                    string str2 = "Spectral Sigil";
                    string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(Color.green) + ">";
                    string str4 = "</color>";
                    str1 = str3 + str2 + str4;
                }
                else if (value == 4)
                {
                    string str2 = "Pure Sigil";
                    string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(magenta) + ">";
                    string str4 = "</color>";
                    str1 = str3 + str2 + str4;
                }
                else
                {
                    str1 = "";
                }
            }
            else
                str1 = orig(self, storedValue, value);
            return str1;
        }

        public static void Setup()
        {
            IDetour sigilValue = new Hook((MethodBase)typeof(TooltipTextHandlerSO).GetMethod(nameof(TooltipTextHandlerSO.ProcessStoredValue), ~BindingFlags.Default), typeof(SigilManager).GetMethod(nameof(SigilValue), ~BindingFlags.Default));
            IDetour hook = new Hook(typeof(CombatManager).GetMethod(nameof(CombatManager.PostNotification), ~BindingFlags.Default), typeof(SigilManager).GetMethod(nameof(PostNotification), ~BindingFlags.Default));
        }
    }
    public class SigilPassiveAbility : BasePassiveAbilitySO
    {
        public override bool DoesPassiveTrigger => true;
        public override bool IsPassiveImmediate => true;

        public IUnit Actor;

        public SigilType _sigil
        {
            get
            {
                if (Actor == null)
                {
                    if (DoDebugs.MiscInfo) UnityEngine.Debug.Log("null Actor");
                    return 0;
                }
                else
                {
                    SigilType ret = (SigilType)Actor.GetStoredValue(SigilManager.Sigil);
                    if (DoDebugs.MiscInfo) UnityEngine.Debug.Log("unit: " + Actor.ID + " slot: " + Actor.SlotID + " sigil: " + ret.ToString());
                    return ret;
                }
            }
        }

        public override void TriggerPassive(object sender, object args)
        {
            if (sender is IUnit unit)
            {
                unit.SetStoredValue(SigilManager.Sigil, 4);
            }
        }
        public bool Added = false;
        public bool ReplaceAdd = false;
        public override void OnPassiveConnected(IUnit unit)
        {
            if (Added)
            {
                CombatManager.Instance.AddPrioritySubAction(new NewSigilSubAction(unit, this));
                if (DoDebugs.MiscInfo) UnityEngine.Debug.Log("Nah bruh we skipp: unit: " + unit.ID + " slot: " + unit.SlotID + " Added: " + Added);
                if (DoDebugs.MiscInfo) UnityEngine.Debug.Log("Actor: unit: " + Actor.ID + " slot: " + Actor.SlotID);
                return;
            }
            Effect[] array = new Effect[]
            {
                new Effect(BasicEffects.SetStoreValue(SigilManager.Sigil), 4, null, Slots.Self)
            };
            Effect[] root = new Effect[]
            {
                new Effect(RootActionEffect.Create(array), 1, null, Slots.Self)
            };
            CombatManager.Instance.AddRootAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[]
            {
                new Effect(RootActionEffect.Create(root), 1, null, Slots.Self)
            }), unit));
            Actor = unit;
            if (DoDebugs.MiscInfo)
            {
                if (ReplaceAdd)
                    UnityEngine.Debug.Log("Replace Add: unit: " + unit.ID + " slot: " + unit.SlotID + " Added: " + Added);
                else
                    UnityEngine.Debug.Log("Fresh Add: unit: " + unit.ID + " slot: " + unit.SlotID + " Added: " + Added);
            }
            Added = true;
            if (DoDebugs.MiscInfo) UnityEngine.Debug.Log("Actor: unit: " + Actor.ID + " slot: " + Actor.SlotID);
        }
        public bool KeepActor = false;
        public override void OnPassiveDisconnected(IUnit unit)
        {
            unit.SetStoredValue(SigilManager.Sigil, 0);
            if (!KeepActor) Actor = null;
            else
            {
                if (DoDebugs.MiscInfo) UnityEngine.Debug.Log("keeping actor");
                KeepActor = false;
            }
            if (unit.IsUnitCharacter)
            {
                CombatManager.Instance._stats.combatUI.TrySetCharacterAnimatorParameterInt(unit.ID, "color", 0);
            }
            else
            {
                CombatManager.Instance._stats.combatUI.TrySetEnemyAnimatorParameterInt(unit.ID, "color", 0);
            }
        }
    }
    public class NewSigilSubAction : CombatAction
    {
        public IUnit unit;
        public SigilPassiveAbility pass;
        public NewSigilSubAction(IUnit unit, SigilPassiveAbility pass)
        {
            this.unit = unit;
            this.pass = pass;
        }
        public override IEnumerator Execute(CombatStats stats)
        {
            if (unit.IsAlive || unit.CurrentHealth > 0)
            {
                pass.KeepActor = true;
                unit.TryRemovePassiveAbility(pass.type);
                if (DoDebugs.MiscInfo) UnityEngine.Debug.Log("Old Passive Actor: unit: " + pass.Actor.ID + " slot: " + pass.Actor.SlotID + " Added: " + pass.Added);
                SigilPassiveAbility add = ScriptableObject.Instantiate(pass);
                add.Added = false;
                add.Actor = null;
                add.ReplaceAdd = true;
                if (DoDebugs.MiscInfo) UnityEngine.Debug.Log("Try Replace Add: unit: " + unit.ID + " slot: " + unit.SlotID + " Added: " + add.Added);
                unit.AddPassiveAbility(add);
                /*if (Check.EnemyExist("Sigil_EN"))
                {
                    if (LoadedAssetsHandler.GetEnemy("Sigil_EN").passiveAbilities[0] is SigilPassiveAbility p && p.Added)
                    {
                        SigilPassiveAbility n = ScriptableObject.Instantiate(pass);
                        n.Added = false;
                        n.Actor = null;
                        LoadedAssetsHandler.GetEnemy("Sigil_EN").passiveAbilities = new BasePassiveAbilitySO[]
                        {
                            n, Passives.Formless, Passives.Withering
                        };
                    }
                }*/
            }
            yield return null;
        }
    }
    public enum SigilType
    {
        Unavailable = 0,
        Defensive = 1,
        Offensive = 2,
        Spectral = 3,
        Pure = 4
    }
    public class FloatMod : IntValueModifier
    {
        public readonly float mod;
        public readonly bool roundUp;
        public FloatMod(float _mod, bool _RoundUp) : base(74)
        {
            this.mod = _mod;
            this.roundUp = _RoundUp;
        }

        public override int Modify(int value)
        {
            float gap = value;
            gap *= mod;
            if (roundUp)
            {
                value = (int)Math.Ceiling(gap);
            }
            else
            {
                value = (int)Math.Floor(gap);
            }
            return value;
        }
    }

    public class NoStatusEffector : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is StatusEffectApplication appli)
            {
                appli.value = false;
                return true;
            }
            return false;
        }
    }
    public static class FireNoReduce
    {
        public static void Add()
        {
            IDetour MoonIdetour = (IDetour)new Hook((MethodBase)typeof(OnFire_SlotStatusEffect).GetMethod("ReduceDuration", ~BindingFlags.Default), typeof(FireNoReduce).GetMethod("ReduceDuration", ~BindingFlags.Default));
        }
        public static void ReduceDuration(Action<OnFire_SlotStatusEffect> orig, OnFire_SlotStatusEffect self)
        {
            if (self.Effector is CombatSlot slot && slot.HasUnit)
            {
                if (slot.Unit.ContainsPassiveAbility((PassiveAbilityTypes)327745))
                {
                    return;
                }
            }
            orig(self);
        }
    }

    public static class ClockTowerManager
    {
        public static System.Threading.Thread timer;

        public static int _timeSpent;

        public static int TimeLeft
        {
            get
            {
                return 60 - _timeSpent;
            }
        }

        public static void CountTo45()
        {
            _timeSpent = 0;
            for (int i = 0; i < 61; i++)
            {
                _timeSpent = i;
                System.Threading.Thread.Sleep(1000);
                if (CombatManager.Instance._pauseMenuIsOpen) i--;
                if (!PlayerTurn || !InCombat) break;
            }
            if (!PlayerTurn || !InCombat) return;
            UnityEngine.Debug.Log("Time's Up!");
            foreach (EnemyCombat en in CombatManager.Instance._stats.EnemiesOnField.Values)
            {
                try { CombatManager.Instance.PostNotification(Call.ToString(), en, null); }
                catch (Exception ex) 
                {
                    if (DoDebugs.MiscInfo)
                    {
                        UnityEngine.Debug.LogError("Clock tower failed once");
                        UnityEngine.Debug.LogError(ex.Message);
                        UnityEngine.Debug.LogError(ex.StackTrace);
                    }
                    try { CombatManager.Instance.AddSubAction(new ClockTowerNotifAction(en, Call)); }
                    catch (Exception ex2)
                    {
                        if (DoDebugs.MiscInfo)
                        {
                            UnityEngine.Debug.LogError("Clock tower failed twice");
                            UnityEngine.Debug.LogError(ex2.Message);
                            UnityEngine.Debug.LogError(ex2.StackTrace);
                        }
                    }
                }
            }
        }

        public class ClockTowerNotifAction : CombatAction
        {
            public IUnit unit;
            public TriggerCalls call;
            public ClockTowerNotifAction(IUnit Unit, TriggerCalls Call)
            {
                this.unit = Unit;
                this.call = Call;
            }
            public override IEnumerator Execute(CombatStats stats)
            {
                try { CombatManager.Instance.PostNotification(call.ToString(), unit, null); }
                catch(Exception ex)
                {
                    if (DoDebugs.MiscInfo)
                    {
                        UnityEngine.Debug.LogError("Clock tower sub action failed");
                        UnityEngine.Debug.LogError(ex.Message);
                        UnityEngine.Debug.LogError(ex.StackTrace);
                    }
                }
                yield return null;
            }
        }

        public static bool PlayerTurn;
        public static bool InCombat;
        public static TriggerCalls Call = (TriggerCalls)3867920;

        public static void PlayerTurnStart(Action<CombatStats> orig, CombatStats self)
        {
            orig(self);
            PlayerTurn = true;
            if (timer != null) timer.Abort();
            timer = new System.Threading.Thread(CountTo45);
            timer.Start();
        }

        public static void PlayerTurnEnd(Action<CombatStats> orig, CombatStats self)
        {
            orig(self);
            PlayerTurn = false;
            if (timer != null) timer.Abort();
            _timeSpent = 0;
        }

        public static void FinalizeCombat(Action<CombatStats> orig, CombatStats self)
        {
            orig(self);
            InCombat = false;
            if (timer != null) timer.Abort();
        }

        public static void UIInitialization(Action<CombatStats> orig, CombatStats self)
        {
            orig(self);
            InCombat = true;
        }

        public static UnitStoredValueNames Acceleration = (UnitStoredValueNames)1986800;
        public static string AccelerationValue(
          Func<TooltipTextHandlerSO, UnitStoredValueNames, int, string> orig,
          TooltipTextHandlerSO self,
          UnitStoredValueNames storedValue,
          int value)
        {
            Color magenta = Color.magenta;
            string str1;
            if (storedValue == Acceleration)
            {
                if (value <= 0)
                {
                    str1 = "";
                }
                else
                {
                    string str2 = "Time Left: " + TimeLeft.ToString();
                    if (TimeLeft <= 0) str2 = "Time's up!";
                    string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(Color.green) + ">";
                    string str4 = "</color>";
                    str1 = str3 + str2 + str4;
                }
            }
            else
                str1 = orig(self, storedValue, value);
            return str1;
        }

        public static void Setup()
        {
            IDetour CombatEnd = new Hook(typeof(CombatStats).GetMethod(nameof(CombatStats.FinalizeCombat), ~BindingFlags.Default), typeof(ClockTowerManager).GetMethod(nameof(FinalizeCombat), ~BindingFlags.Default));
            IDetour CombatStart = new Hook(typeof(CombatStats).GetMethod(nameof(CombatStats.UIInitialization), ~BindingFlags.Default), typeof(ClockTowerManager).GetMethod(nameof(UIInitialization), ~BindingFlags.Default));
            IDetour TurnStart = new Hook(typeof(CombatStats).GetMethod(nameof(CombatStats.PlayerTurnStart), ~BindingFlags.Default), typeof(ClockTowerManager).GetMethod(nameof(PlayerTurnStart), ~BindingFlags.Default));
            IDetour TurnEnd = new Hook(typeof(CombatStats).GetMethod(nameof(CombatStats.PlayerTurnEnd), ~BindingFlags.Default), typeof(ClockTowerManager).GetMethod(nameof(PlayerTurnEnd), ~BindingFlags.Default));
            IDetour storeValue = new Hook((MethodBase)typeof(TooltipTextHandlerSO).GetMethod(nameof(TooltipTextHandlerSO.ProcessStoredValue), ~BindingFlags.Default), typeof(ClockTowerManager).GetMethod(nameof(AccelerationValue), ~BindingFlags.Default));
            CrackingHandler.Setup();
        }
    }
    public class ClockTowerPassive : PerformEffectPassiveAbility
    {
        public override void OnPassiveConnected(IUnit unit)
        {
            base.OnPassiveConnected(unit);
            unit.SetStoredValue(ClockTowerManager.Acceleration, 1);
        }
        public override void OnPassiveDisconnected(IUnit unit)
        {
            base.OnPassiveDisconnected(unit);
            unit.SetStoredValue(ClockTowerManager.Acceleration, 0);
        }
    }
    public static class CrackingHandler
    {
        public static Sprite Face = ResourceLoader.LoadSprite("ClockFace.png");
        public class ThreadHandler
        {
            public int ID;
            public System.Threading.Thread Timer;
            public ThreadHandler(int ID)
            {
                this.ID = ID;
                Timer = new System.Threading.Thread(CountTo75);
                Timer.Start();
            }

            public int TimeLeft
            {
                get
                {
                    return 150 - _timeSpent;
                }
            }
            public int _timeSpent;
            public void CountTo75()
            {
                _timeSpent = 0;
                for (int i = 0; i < 151; i++)
                {
                    _timeSpent = i;
                    System.Threading.Thread.Sleep(1000);
                    if (CombatManager.Instance._pauseMenuIsOpen) i--;
                    if (!ClockTowerManager.InCombat) break;
                }
                if (!ClockTowerManager.InCombat) return;
                CombatStats stats = CombatManager.Instance._stats;
                TargetSlotInfo[] targets = ScriptableObject.CreateInstance<TargettingRandomUnit>().GetTargets(stats.combatSlots, -1, false);
                List<int> IDs = new List<int>();
                List<bool> chara = new List<bool>();
                List<string> cracking = new List<string>();
                List<Sprite> face = new List<Sprite>();
                foreach (TargetSlotInfo target in targets)
                {
                    if (target.HasUnit)
                    {
                        IDs.Add(target.Unit.ID);
                        chara.Add(target.Unit.IsUnitCharacter);
                        cracking.Add("Cracking");
                        face.Add(Face);
                    }
                }
                if (IDs.Count > 0) CombatManager.Instance.AddUIAction(new ShowMultiplePassiveInformationUIAction(IDs.ToArray(), chara.ToArray(), cracking.ToArray(), face.ToArray()));
                CombatManager.Instance.AddUIAction(new PlayAbilityAnimationNoCasterAction(CustomVisuals.GetVisuals("Salt/Alarm"), targets));
                CombatManager.Instance.AddPrioritySubAction(new Apply12EntropyAction(targets));
                CrackingHandler.Threads.Remove(ID);
            }

            public void End()
            {
                if (Timer != null) Timer.Abort();
            }
        }

        public static Dictionary<int, ThreadHandler> Threads = new Dictionary<int, ThreadHandler>();

        public static void Clear()
        {
            foreach (ThreadHandler threads in Threads.Values)
            {
                threads.End();
            }
            Threads.Clear();
        }
        public static void Remove(int ID)
        {
            if (Threads.Keys.Contains(ID))
                Threads[ID].End();
        }
        public static void SetTimer(int ID)
        {
            if (Threads.Keys.Contains(ID))
            {
                Threads[ID].End();
                Threads[ID] = new ThreadHandler(ID);
            }
            else
            {
                Threads.Add(ID, new ThreadHandler(ID));
            }
        }

        public static UnitStoredValueNames Cracking = (UnitStoredValueNames)2893914;
        public static string CrackingValue(
          Func<TooltipTextHandlerSO, UnitStoredValueNames, int, string> orig,
          TooltipTextHandlerSO self,
          UnitStoredValueNames storedValue,
          int value)
        {
            Color magenta = Color.magenta;
            string str1;
            if (storedValue == Cracking)
            {
                if (value <= 0)
                {
                    str1 = "";
                }
                else if (Threads.TryGetValue(value - 1000, out ThreadHandler thread))
                {
                    string str2 = "Cracking in: " + thread.TimeLeft.ToString();
                    string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(magenta) + ">";
                    string str4 = "</color>";
                    str1 = str3 + str2 + str4;
                    if (thread.TimeLeft <= 0) str1 = "";
                }
                else
                {
                    str1 = "";
                }
            }
            else
                str1 = orig(self, storedValue, value);
            return str1;
        }

        public static void Setup()
        {
            IDetour storeValue = new Hook((MethodBase)typeof(TooltipTextHandlerSO).GetMethod(nameof(TooltipTextHandlerSO.ProcessStoredValue), ~BindingFlags.Default), typeof(CrackingHandler).GetMethod(nameof(CrackingValue), ~BindingFlags.Default));
        }
    }
    public class AbilitySelector_ClockTower : BaseAbilitySelectorSO
    {
        [Header("Special Abilities")]
        [SerializeField]
        public string cracking = "Cracking";

        public override bool UsesRarity => true;

        public override int GetNextAbilitySlotUsage(List<CombatAbility> abilities, IUnit unit)
        {
            int maxExclusive1 = 0;
            int maxExclusive2 = 0;
            List<int> intList1 = new List<int>();
            List<int> intList2 = new List<int>();
            for (int index = 0; index < abilities.Count; ++index)
            {
                if (this.ShouldBeIgnored(abilities[index], unit))
                {
                    maxExclusive2 += abilities[index].rarity.rarityValue;
                    intList2.Add(index);
                }
                else
                {
                    maxExclusive1 += abilities[index].rarity.rarityValue;
                    intList1.Add(index);
                }
            }
            int num1 = UnityEngine.Random.Range(0, maxExclusive1);
            int num2 = 0;
            foreach (int index in intList1)
            {
                num2 += abilities[index].rarity.rarityValue;
                if (num1 < num2)
                    return index;
            }
            int num3 = UnityEngine.Random.Range(0, maxExclusive2);
            int num4 = 0;
            foreach (int index in intList2)
            {
                num4 += abilities[index].rarity.rarityValue;
                if (num3 < num4)
                    return index;
            }
            return -1;
        }

        public bool ShouldBeIgnored(CombatAbility ability, IUnit unit)
        {
            string name = ability.ability._abilityName;
            return CrackingHandler.Threads.TryGetValue(unit.ID, out var variable) && name == this.cracking;
        }
    }
    public class CrackingEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            CrackingHandler.SetTimer(caster.ID);
            caster.SetStoredValue(CrackingHandler.Cracking, caster.ID + 1000);
            return true;
        }
    }
    public class ClockTowerExitEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            CrackingHandler.Remove(caster.ID);
            return true;
        }
    }
    public class PlayAbilityAnimationNoCasterAction : CombatAction
    {
        public TargetSlotInfo[] _targets;
        
        public AttackVisualsSO _visuals;

        public PlayAbilityAnimationNoCasterAction(AttackVisualsSO visuals, TargetSlotInfo[] targets)
        {
            _visuals = visuals;
            _targets = targets;
        }

        public override IEnumerator Execute(CombatStats stats)
        {
            yield return stats.combatUI.PlayAbilityAnimation(_visuals, _targets, true);
        }
    }
    public class Apply12EntropyAction : CombatAction
    {
        public TargetSlotInfo[] _targets;

        public Apply12EntropyAction(TargetSlotInfo[] targets)
        {
            _targets = targets;
        }

        public override IEnumerator Execute(CombatStats stats)
        {
            TargetSlotInfo[] targets = _targets;
            stats.statusEffectDataBase.TryGetValue((StatusEffectType)846747, out StatusEffectInfoSO effectInfo);
            for (int index = 0; index < targets.Length; ++index)
            {
                if (targets[index].HasUnit)
                {
                    int amount = 12;
                    IStatusEffect statuseffect = new Entropy_StatusEffect(amount);

                    statuseffect.SetEffectInformation(effectInfo);
                    IStatusEffector effector = targets[index].Unit as IStatusEffector;
                    bool hasItAlready = false;
                    int thisIndex = 999;
                    for (int i = 0; i < effector.StatusEffects.Count; i++)
                    {
                        if (effector.StatusEffects[i].EffectType == statuseffect.EffectType)
                        {
                            thisIndex = i;
                            hasItAlready = true;
                        }
                    }
                    if (hasItAlready == true)
                    {
                        ConstructorInfo[] constructors = effector.StatusEffects[thisIndex].GetType().GetConstructors();
                        foreach (ConstructorInfo constructor in constructors)
                        {
                            if (constructor.GetParameters().Length == 2)
                            {
                                statuseffect = (IStatusEffect)Activator.CreateInstance(effector.StatusEffects[thisIndex].GetType(), amount, 0);
                            }
                        }
                    }

                    statuseffect.SetEffectInformation(effectInfo);
                    targets[index].Unit.ApplyStatusEffect((IStatusEffect)statuseffect, amount);
                }
            }
            yield return null;
        }
    }

    public static class ArmorManager
    {
        public static PassiveAbilityTypes Armor = (PassiveAbilityTypes)296164;
        public static bool RemoveSlotStatusEffect(Func<CombatSlot, SlotStatusEffectType, bool> orig, CombatSlot self, SlotStatusEffectType type)
        {
            bool ret = orig(self, type);
            if (DoDebugs.MiscInfo) UnityEngine.Debug.Log("running on slot " + self.SlotID.ToString());
            if (type == SlotStatusEffectType.Shield && self.HasUnit && self.Unit.ContainsPassiveAbility(Armor))
            {
                CombatManager.Instance.AddRootAction(new ArmorAction(self.SlotID, self.IsCharacter, self.Unit.ID));
            }
            AnglerHandler.Check();
            return ret;
        }
        public static int TryRemoveSlotStatusEffect(Func<CombatSlot, SlotStatusEffectType, int> orig, CombatSlot self, SlotStatusEffectType type)
        {
            int ret = orig(self, type);
            if (DoDebugs.MiscInfo) UnityEngine.Debug.Log("running on slot " + self.SlotID.ToString());
            if (type == SlotStatusEffectType.Shield && self.HasUnit && self.Unit.ContainsPassiveAbility(Armor))
            {
                CombatManager.Instance.AddRootAction(new ArmorAction(self.SlotID, self.IsCharacter, self.Unit.ID));
            }
            return ret;
        }
        public static void Setup()
        {
            IDetour hook = new Hook(typeof(CombatSlot).GetMethod(nameof(CombatSlot.RemoveSlotStatusEffect), ~BindingFlags.Default), typeof(ArmorManager).GetMethod(nameof(RemoveSlotStatusEffect), ~BindingFlags.Default));
            IDetour hack = new Hook(typeof(CombatSlot).GetMethod(nameof(CombatSlot.TryRemoveSlotStatusEffect), ~BindingFlags.Default), typeof(ArmorManager).GetMethod(nameof(TryRemoveSlotStatusEffect), ~BindingFlags.Default));
        }
    }
    public class ArmorAction : CombatAction
    {
        public readonly int SlotID;
        public readonly bool character;
        public readonly int UnitID;

        public ArmorAction(int SlotID, bool character, int UnitID)
        {
            this.SlotID = SlotID;
            this.character = character;
            this.UnitID = UnitID;
        }

        public override IEnumerator Execute(CombatStats stats)
        {
            TargetSlotInfo g = stats.combatSlots.GetEnemyTargetSlot(SlotID, 0);
            if (character) g = stats.combatSlots.GetCharacterTargetSlot(SlotID, 0);
            if (g.HasUnit && g.Unit.ContainsPassiveAbility(ArmorManager.Armor))
            {
                if (!stats.combatSlots.SlotContainsSlotStatusEffect(SlotID, character, SlotStatusEffectType.Shield))
                {
                    CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(UnitID, character, Passi.Armor._passiveName, Passi.Armor.passiveIcon));
                    stats.slotStatusEffectDataBase.TryGetValue(SlotStatusEffectType.Shield, out var value);
                    Shield_SlotStatusEffect shield_SlotStatusEffect = new Shield_SlotStatusEffect(SlotID, 4, character);
                    shield_SlotStatusEffect.SetEffectInformation(value);
                    stats.combatSlots.ApplySlotStatusEffect(SlotID, character, 4, shield_SlotStatusEffect);
                }
            }
            yield return null;
        }
    }
    public class ArmorEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach(TargetSlotInfo target in targets)
            {
                if (target.HasUnit && target.Unit.ContainsPassiveAbility(ArmorManager.Armor))
                {
                    CombatManager.Instance.AddSubAction(new ArmorAction(target.SlotID, target.IsTargetCharacterSlot, caster.ID));
                    exitAmount++;
                }
            }
            return exitAmount > 0;
        }
    }

    public class DisabledCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is IntegerReference skinteger)
            {
                if (skinteger.value >= 2)
                    return true;
            }
            return false;
        }
    }

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

    public class ApplyPermenantDodgeEffect : EffectSO
    {
        [SerializeField]
        public bool _justOneTarget;
        [SerializeField]
        public bool _randomBetweenPrevious;

        public override bool PerformEffect(
          CombatStats stats,
          IUnit caster,
          TargetSlotInfo[] targets,
          bool areTargetSlots,
          int entryVariable,
          out int exitAmount)
        {
            exitAmount = 0;

            StatusEffectInfoSO effectInfo;
            stats.statusEffectDataBase.TryGetValue(Dodge.Type, out effectInfo);


            for (int index = 0; index < targets.Length; ++index)
            {
                if (targets[index].HasUnit)
                {
                    bool apply = true;
                    if (targets[index].Unit.ContainsStatusEffect(Dodge.Type))
                    {
                        IStatusEffector effector = targets[index].Unit as IStatusEffector;
                        foreach (IStatusEffect status in effector.StatusEffects)
                        {
                            if (status.EffectType == Dodge.Type)
                            {
                                if (status.Restrictor > 0) apply = false;
                            }
                        }
                    }
                    if (apply)
                    {
                        int amount = this._randomBetweenPrevious ? UnityEngine.Random.Range(this.PreviousExitValue, entryVariable + 1) : entryVariable;
                        Dodge_StatusEffect statusEffect = new Dodge_StatusEffect(0, amount);

                        statusEffect.SetEffectInformation(effectInfo);
                        if (targets[index].Unit.ApplyStatusEffect((IStatusEffect)statusEffect, 0))
                            exitAmount += amount;
                    }
                }
            }

            return exitAmount > 0;
        }
    }

    public class WellPreservedCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is DamageReceivedValueChangeException hitBy)
            {
                if (hitBy.directDamage) return false;
                hitBy.AddModifier(new ImmZeroMod());
            }
            return true;
        }
    }

    public class ButterflyUnboxer : UnboxUnitHandlerSO
    {
        public override bool CanBeUnboxed(CombatStats stats, BoxedUnit unit, object senderData)
        {
            //UnityEngine.Debug.Log("Checkig can unbox + " + ID);
            if (checkTicked)
            {
                if (!ticked)
                {
                    ticked = true;
                    return false;
                }
            }
            if (!unit.unit.IsUnitCharacter)
            {
                if (stats.EnemiesAlive)
                {
                    foreach (CombatSlot slot in stats.combatSlots._enemySlots)
                    {
                        if (!slot.HasUnit) return true;
                    }
                }
            }
            else
            {
                if (stats.CharactersAlive)
                {
                    foreach (CombatSlot slot in stats.combatSlots._characterSlots)
                    {
                        if (!slot.HasUnit) return true;
                    }
                }
            }
            return false;
        }
        public int ID;
        public bool ticked;
        public bool checkTicked;
        public static ButterflyUnboxer GetDefault(int id, bool ticking = false)
        {
            ButterflyUnboxer basic = ScriptableObject.CreateInstance<ButterflyUnboxer>();
            basic._unboxConditions = new TriggerCalls[] { (TriggerCalls)7106822 };
            basic.ID = id;
            basic.ticked = false;
            basic.checkTicked = ticking;
            return basic;
        }
        public static PassiveAbilityTypes ButterflyPassive => (PassiveAbilityTypes)2657108;
        public static PassiveAbilityTypes SkyloftPassive => (PassiveAbilityTypes)6281090;
        public static IEnumerator Execute(Func<FleetingUnitAction, CombatStats, IEnumerator> orig, FleetingUnitAction self, CombatStats stats)
        {
            bool flag = false;
            if (self._isUnitCharacter)
            {
                CharacterCombat characterCombat = stats.TryGetCharacterOnField(self._unitID);
                if (characterCombat != null && characterCombat.CurrentHealth > 0)
                {
                    if (characterCombat != null && characterCombat.ContainsPassiveAbility(ButterflyPassive))
                    {
                        flag = true;
                        stats.TryBoxCharacter(self._unitID, ButterflyUnboxer.GetDefault(self._unitID), UnitExitType.Obliterate);
                    }
                    else if (characterCombat != null && characterCombat.ContainsPassiveAbility(SkyloftPassive))
                    {
                        flag = true;
                        stats.TryBoxCharacter(self._unitID, ButterflyUnboxer.GetDefault(self._unitID, true), UnitExitType.Fleeting);
                    }
                }
            }
            else
            {
                EnemyCombat enemyCombat = stats.TryGetEnemyOnField(self._unitID);
                if (enemyCombat != null && enemyCombat.CurrentHealth > 0)
                {
                    if (enemyCombat != null && enemyCombat.ContainsPassiveAbility(ButterflyPassive))
                    {
                        flag = true;
                        stats.TryBoxEnemy(self._unitID, ButterflyUnboxer.GetDefault(enemyCombat.ID), UnitExitType.Obliterate);
                        Boxeds.Add(enemyCombat.ID);
                        if (DoDebugs.MiscInfo) UnityEngine.Debug.Log("boxed enemy ID: " + enemyCombat.ID);
                    }
                    else if (enemyCombat != null && enemyCombat.ContainsPassiveAbility(SkyloftPassive))
                    {
                        flag = true;
                        stats.TryBoxEnemy(self._unitID, ButterflyUnboxer.GetDefault(enemyCombat.ID, true), UnitExitType.Fleeting);
                        Boxeds.Add(enemyCombat.ID);
                        if (DoDebugs.MiscInfo) UnityEngine.Debug.Log("boxed enemy ID: " + enemyCombat.ID);
                    }
                }
            }
            if (flag) yield return null;
            else yield return orig(self, stats);
        }
        public static List<int> Boxeds = new List<int>();
        public override void ProcessUnbox(CombatStats stats, BoxedUnit unit, object senderData)
        {
            base.ProcessUnbox(stats, unit, senderData);
            Boxeds.Remove(ID);
            if (DoDebugs.MiscInfo) UnityEngine.Debug.Log("unboxed enemy ID: " + ID);
            AddTurnCasterToTimelineEffect blah = ScriptableObject.CreateInstance<AddTurnCasterToTimelineEffect>();
            CombatManager.Instance.AddRootAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[]
            {
                new Effect(blah, 1, null, Slots.Self)
            }), unit.unit));
            
        }
        public static void Setup()
        {
            IDetour hook = new Hook(typeof(FleetingUnitAction).GetMethod(nameof(FleetingUnitAction.Execute), ~BindingFlags.Default), typeof(ButterflyUnboxer).GetMethod(nameof(Execute), ~BindingFlags.Default));
        }
        public static void EndCombatCheck()
        {
            CombatStats stats = CombatManager.Instance._stats;
            foreach (int iD in Boxeds)
            {
                try
                {
                    if (stats.BoxedEnemies.TryGetValue(iD, out var value))
                    {
                        IUnit unit = value.unit;
                        EnemyCombat enemyCombat = stats.Enemies[unit.ID];
                        if (Stamp.Stamps != null)
                        {
                            foreach (Stamp stamp in Stamp.Stamps.Values) stamp.FleeCheck(enemyCombat);
                        }
                    }
                }
                catch
                {
                    UnityEngine.Debug.LogError("missing enemy from id: " + iD);
                }
            }
        }

    }
    public class IfAliveCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (effector is IUnit unit)
            {
                if (unit.CurrentHealth <= 0) return false;
                return unit.CurrentHealth > 0;
            }
            return false;
        }
    }
    public class IfAliveEffectCondition : EffectConditionSO
    {
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            if (caster.CurrentHealth <= 0) return false;
            return caster.CurrentHealth > 0;
        }
    }
    public class ButterflyAction : CombatAction
    {
        
        public override IEnumerator Execute(CombatStats stats)
        {
            List<int> check = new List<int>(ButterflyUnboxer.Boxeds);
            foreach (int id in check)
            {
                if (DoDebugs.MiscInfo) UnityEngine.Debug.Log("trying to unbox enemy ID: " + id);
                stats.TryUnboxEnemyRandomPosition(id, null);
            }
            yield return null;
        }
    }
    public static class StatsExtensions
    {

        public static void TryUnboxEnemyRandomPosition(this CombatStats stats, int id, object senderData)
        {
            if (!stats.BoxedEnemies.TryGetValue(id, out var value) || !value.unboxHandler.CanBeUnboxed(stats, value, senderData))
            {
                return;
            }

            int firstEmptyEnemyFieldID = stats.GetFirstEmptyEnemyFieldID();
            if (DoDebugs.MiscInfo) UnityEngine.Debug.Log("First empty enemy field id is: " + firstEmptyEnemyFieldID);
            if (firstEmptyEnemyFieldID != -1)
            {
                IUnit unit = value.unit;
                EnemyCombat enemyCombat = stats.Enemies[unit.ID];
                int slotID = enemyCombat.SlotID;
                int endSlot = slotID + enemyCombat.Size - 1;
                if (stats.combatSlots.IsEnemySpaceEmpty(slotID, endSlot))
                {
                    if (DoDebugs.MiscInfo) UnityEngine.Debug.Log("Send them to slot " + slotID + "!");
                    value.RemoveUnboxConnection();
                    enemyCombat.UnboxEnemy(firstEmptyEnemyFieldID);
                    stats.AddEnemyToField(enemyCombat.ID, firstEmptyEnemyFieldID);
                    stats.combatSlots.AddEnemyToSlot(enemyCombat, slotID);
                    stats.timeline.AddEnemyToTimeline(enemyCombat);
                    value.unboxHandler.ProcessUnbox(stats, value, senderData);
                    enemyCombat.DefaultPassiveAbilityInitialization();
                    CombatManager.Instance.AddUIAction(new UnboxEnemyUIAction(enemyCombat.ID));
                    enemyCombat.ConnectPassives();
                    enemyCombat.ReconnectAllStatusEffects();
                    CombatManager.Instance.AddUIAction(new EnemyPassiveAbilityChangeUIAction(enemyCombat.ID, enemyCombat.PassiveAbilities.ToArray()));
                    stats.BoxedEnemies.Remove(enemyCombat.ID);
                    return;
                }
                List<int> array = new List<int> { 0, 1, 2, 3, 4 };
                for (int i = 0; i < stats.combatSlots.EnemySlots.Length; i++)
                {
                    int pick = UnityEngine.Random.Range(0, array.Count);
                    slotID = array[pick];
                    endSlot = slotID + enemyCombat.Size - 1;
                    if (stats.combatSlots.IsEnemySpaceEmpty(slotID, endSlot))
                    {
                        if (DoDebugs.MiscInfo) UnityEngine.Debug.Log("Send them to slot " + slotID + "!");
                        value.RemoveUnboxConnection();
                        enemyCombat.UnboxEnemy(firstEmptyEnemyFieldID);
                        stats.AddEnemyToField(enemyCombat.ID, firstEmptyEnemyFieldID);
                        stats.combatSlots.AddEnemyToSlot(enemyCombat, slotID);
                        stats.timeline.AddEnemyToTimeline(enemyCombat);
                        value.unboxHandler.ProcessUnbox(stats, value, senderData);
                        enemyCombat.DefaultPassiveAbilityInitialization();
                        CombatManager.Instance.AddUIAction(new UnboxEnemyUIAction(enemyCombat.ID));
                        enemyCombat.ConnectPassives();
                        enemyCombat.ReconnectAllStatusEffects();
                        CombatManager.Instance.AddUIAction(new EnemyPassiveAbilityChangeUIAction(enemyCombat.ID, enemyCombat.PassiveAbilities.ToArray()));
                        stats.BoxedEnemies.Remove(enemyCombat.ID);
                        return;
                    }
                    array.RemoveAt(pick);

                }
            }
        }
    }

    public class AbilitySelector_Tripod : BaseAbilitySelectorSO
    {
        [Header("Special Abilities")]
        [SerializeField]
        public string longslice = "Slice";
        public string shortstomp = "Stomp";
        public string lens = "Lens";

        public override bool UsesRarity => true;

        public override int GetNextAbilitySlotUsage(List<CombatAbility> abilities, IUnit unit)
        {
            int maxExclusive1 = 0;
            int maxExclusive2 = 0;
            List<int> intList1 = new List<int>();
            List<int> intList2 = new List<int>();
            bool hasconfus = unit.ContainsPassiveAbility(PassiveAbilityTypes.Confusion);
            for (int index = 0; index < abilities.Count; ++index)
            {
                if (this.ShouldBeIgnored(abilities[index], unit))
                {
                    maxExclusive2 += hasconfus ? ValueWithConfuse(abilities[index], unit) : ValueWithoutConfuse(abilities[index], unit);
                    intList2.Add(index);
                }
                else
                {
                    maxExclusive1 += hasconfus ? ValueWithConfuse(abilities[index], unit) : ValueWithoutConfuse(abilities[index], unit);
                    intList1.Add(index);
                }
            }
            int num1 = UnityEngine.Random.Range(0, maxExclusive1);
            int num2 = 0;
            foreach (int index in intList1)
            {
                num2 += hasconfus ? ValueWithConfuse(abilities[index], unit) : ValueWithoutConfuse(abilities[index], unit);
                if (num1 < num2)
                    return index;
            }
            int num3 = UnityEngine.Random.Range(0, maxExclusive2);
            int num4 = 0;
            foreach (int index in intList2)
            {
                num4 += hasconfus ? ValueWithConfuse(abilities[index], unit) : ValueWithoutConfuse(abilities[index], unit);
                if (num3 < num4)
                    return index;
            }
            return -1;
        }

        public bool ShouldBeIgnored(CombatAbility ability, IUnit unit)
        {
            bool name = ability.ability._abilityName.Contains(longslice);
            bool other = ability.ability._abilityName.Contains(lens);
            return ((name && (!unit.ContainsPassiveAbility(PassiveAbilityTypes.Confusion))) || (other && unit.ContainsStatusEffect(StatusEffectType.Spotlight) && unit.ContainsPassiveAbility(PassiveAbilityTypes.Confusion)));
        }
        public int ValueWithoutConfuse(CombatAbility ability, IUnit unit)
        {
            bool name = !ability.ability._abilityName.Contains(shortstomp);
            if (name || unit.ContainsPassiveAbility(PassiveAbilityTypes.Confusion)) return ability.rarity.rarityValue;
            else return 1;
        }
        public int ValueWithConfuse(CombatAbility ability, IUnit unit)
        {
            bool name = !ability.ability._abilityName.Contains(lens);
            if (name || (!unit.ContainsPassiveAbility(PassiveAbilityTypes.Confusion))) return ability.rarity.rarityValue;
            else return 1;
        }
    }

    public class AsphyxiationPassiveAbility : BasePassiveAbilitySO
    {
        public override bool DoesPassiveTrigger => true;
        public override bool IsPassiveImmediate => true;

        public int ManaCap;

        public override void TriggerPassive(object sender, object args)
        {
        }

        public override void OnPassiveConnected(IUnit unit)
        {
        }
        public override void OnPassiveDisconnected(IUnit unit)
        {
        }
    }
    public static class AsphyxiationManager
    {
        public static AsphyxiationPassiveAbility GetPassive(IPassiveEffector effector)
        {
            foreach (BasePassiveAbilitySO passive in effector.PassiveAbilities)
                if (passive is AsphyxiationPassiveAbility pasi) return pasi;
            return null;
        }
        public static bool CheckAsphyxiations(CombatStats stats)
        {
            bool flag = true;
            if (stats.overflowMana.OverflowManaAmount <= 0) return flag;
            List<int> IDs = new List<int>();
            List<bool> IsChar = new List<bool>();
            List<string> passi = new List<string>();
            List<Sprite> images = new List<Sprite>();
            foreach (EnemyCombat enemy in stats.EnemiesOnField.Values)
            {
                AsphyxiationPassiveAbility passive = GetPassive(enemy);
                if (passive != null)
                {
                    if (stats.overflowMana.OverflowManaAmount < passive.ManaCap)
                    {
                        IDs.Add(enemy.ID);
                        IsChar.Add(enemy.IsUnitCharacter);
                        passi.Add(passive._passiveName);
                        images.Add(passive.passiveIcon);
                        flag = false;
                    }
                }
            }
            foreach (CharacterCombat chara in stats.CharactersOnField.Values)
            {
                AsphyxiationPassiveAbility passive = GetPassive(chara);
                if (passive != null)
                {
                    if (stats.overflowMana.OverflowManaAmount < passive.ManaCap)
                    {
                        IDs.Add(chara.ID);
                        IsChar.Add(chara.IsUnitCharacter);
                        passi.Add(passive._passiveName);
                        images.Add(passive.passiveIcon);
                        flag = false;
                    }
                }
            }
            CombatManager.Instance.AddUIAction(new ShowMultiplePassiveInformationUIAction(IDs.ToArray(), IsChar.ToArray(), passi.ToArray(), images.ToArray()));
            return flag;
        }
        public static void CalculateOverflow(Action<PlayerTurnEndSecondPartAction, CombatStats> orig, PlayerTurnEndSecondPartAction self, CombatStats stats)
        {
            if (CheckAsphyxiations(stats)) orig(self, stats);
        }
        public static void Setup()
        {
            IDetour hook = new Hook(typeof(PlayerTurnEndSecondPartAction).GetMethod(nameof(PlayerTurnEndSecondPartAction.CalculateOverflow), ~BindingFlags.Default), typeof(AsphyxiationManager).GetMethod(nameof(CalculateOverflow), ~BindingFlags.Default));
        }
    }

    public static class DrowningManager
    {
        public static UnitStoredValueNames Saline = (UnitStoredValueNames)282758;
        public static UnitStoredValueNames Leaky = (UnitStoredValueNames)384882;

        public static string SalinityValue(
          Func<TooltipTextHandlerSO, UnitStoredValueNames, int, string> orig,
          TooltipTextHandlerSO self,
          UnitStoredValueNames storedValue,
          int value)
        {
            string str1;
            if (storedValue == Saline)
            {
                if (value <= 0)
                {
                    str1 = "";
                }
                else
                {
                    string str2 = "Salinity " + string.Format("+{0}", (object)value);
                    string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(self._positiveSTColor) + ">";
                    string str4 = "</color>";
                    str1 = str3 + str2 + str4;
                }
            }
            else
                str1 = orig(self, storedValue, value);
            return str1;
        }
        public static string LeakyValue(
          Func<TooltipTextHandlerSO, UnitStoredValueNames, int, string> orig,
          TooltipTextHandlerSO self,
          UnitStoredValueNames storedValue,
          int value)
        {
            string str1;
            if (storedValue == Leaky)
            {
                if (value <= 0)
                {
                    str1 = "";
                }
                else
                {
                    string str2 = "Leaky " + string.Format("+{0}", (object)value);
                    string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(self._negativeSTColor) + ">";
                    string str4 = "</color>";
                    str1 = str3 + str2 + str4;
                }
            }
            else
                str1 = orig(self, storedValue, value);
            return str1;
        }

        public static BasePassiveAbilitySO _salinity
        {
            get
            {
                PerformEffectPassiveAbility salinity = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                salinity._passiveName = "Salinity (1)";
                salinity.passiveIcon = ResourceLoader.LoadSprite("saltwater.png");
                salinity._enemyDescription = "On receiving direct damage, produce 1 Blue Pigment.";
                salinity._characterDescription = "On receiving direct damage, produce 1 Blue Pigment.";
                salinity.type = (PassiveAbilityTypes)2246632;
                salinity.doesPassiveTriggerInformationPanel = true;
                salinity._triggerOn = new TriggerCalls[] { TriggerCalls.OnDirectDamaged };
                salinity.effects = ExtensionMethods.ToEffectInfoArray(new Effect[]
                {
                    new Effect(ScriptableObject.CreateInstance<GenerateColorManaStoreValueEffect>(), 1, null, Slots.Self)
                });
                salinity.specialStoredValue = Saline;
                return salinity;
            }
        }
        public static BasePassiveAbilitySO _leaky
        {
            get
            {
                PerformEffectPassiveAbility leaky = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
                leaky._passiveName = "Leaky (1)";
                leaky.passiveIcon = Passives.Leaky.passiveIcon;
                leaky._enemyDescription = "Upon receiving direct damage, this enemy generates an extra pigment of its health color.";
                leaky._characterDescription = "Upon receiving direct damage, this character generates an extra pigment of its health color.";
                leaky.type = PassiveAbilityTypes.Leaky;
                leaky.doesPassiveTriggerInformationPanel = true;
                leaky._triggerOn = new TriggerCalls[] { TriggerCalls.OnDirectDamaged };
                leaky.effects = ExtensionMethods.ToEffectInfoArray(new Effect[]
                {
                    new Effect(ScriptableObject.CreateInstance<GenerateCasterColorManaStoreValueEffect>(), 1, null, Slots.Self)
                });
                leaky.specialStoredValue = Leaky;
                return leaky;
            }
        }

        public static void Setup()
        {
            IDetour salineVale = new Hook((MethodBase)typeof(TooltipTextHandlerSO).GetMethod(nameof(TooltipTextHandlerSO.ProcessStoredValue), ~BindingFlags.Default), typeof(DrowningManager).GetMethod(nameof(SalinityValue), ~BindingFlags.Default));
            IDetour otherValue = new Hook((MethodBase)typeof(TooltipTextHandlerSO).GetMethod(nameof(TooltipTextHandlerSO.ProcessStoredValue), ~BindingFlags.Default), typeof(DrowningManager).GetMethod(nameof(LeakyValue), ~BindingFlags.Default));
        }
    }
    public class GenerateColorManaStoreValueEffect : EffectSO
    {
        public bool usePreviousExitValue;

        public ManaColorSO mana = Pigments.Blue;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            entryVariable += caster.GetStoredValue(DrowningManager.Saline);
            
            if (usePreviousExitValue)
            {
                entryVariable *= base.PreviousExitValue;
            }

            exitAmount = entryVariable;
            CombatManager.Instance.ProcessImmediateAction(new AddManaToManaBarAction(mana, entryVariable, caster.IsUnitCharacter, caster.ID));
            return true;
        }
    }
    public class GenerateCasterColorManaStoreValueEffect : EffectSO
    {
        public bool usePreviousExitValue;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            entryVariable += caster.GetStoredValue(DrowningManager.Leaky);
            ManaColorSO mana = caster.HealthColor;
            if (usePreviousExitValue)
            {
                entryVariable *= base.PreviousExitValue;
            }

            exitAmount = entryVariable;
            CombatManager.Instance.ProcessImmediateAction(new AddManaToManaBarAction(mana, entryVariable, caster.IsUnitCharacter, caster.ID));
            return true;
        }
    }

    public class GenerateTargetHealthManaEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    try
                    {
                        target.Unit.GenerateHealthMana(entryVariable);
                        exitAmount += entryVariable;
                    }
                    catch
                    {
                        UnityEngine.Debug.LogError("generate target health mana fail, prob target unit null");
                    }
                }
            }
            return exitAmount > 0;
        }
    }

    public static class NoiseHandler
    {
        public static UnitStoredValueNames Noise = (UnitStoredValueNames)59997;


        public static string AddStoredValueName1(
          Func<TooltipTextHandlerSO, UnitStoredValueNames, int, string> orig,
          TooltipTextHandlerSO self,
          UnitStoredValueNames storedValue,
          int value)
        {
            Color magenta = Color.magenta;
            string str1;
            if (storedValue == (UnitStoredValueNames)59997)
            {
                if (value <= 0)
                {
                    str1 = "";
                }
                else
                {
                    string str2 = "Noise" + string.Format(" +{0}", (object)value);
                    string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(self._negativeSTColor) + ">";
                    string str4 = "</color>";
                    str1 = str3 + str2 + str4;
                }
            }
            else
                str1 = orig(self, storedValue, value);
            return str1;
        }

        public static void Setup()
        {
            IDetour salineVale = new Hook((MethodBase)typeof(TooltipTextHandlerSO).GetMethod(nameof(TooltipTextHandlerSO.ProcessStoredValue), ~BindingFlags.Default), typeof(NoiseHandler).GetMethod(nameof(AddStoredValueName1), ~BindingFlags.Default));
        }
    }
    public class TargetStoredValueChangeEffect : EffectSO
    {
        [SerializeField]
        public bool _increase = true;

        [SerializeField]
        public int _minimumValue = 1;

        [SerializeField]
        public UnitStoredValueNames _valueName = NoiseHandler.Noise;

        [SerializeField]
        public bool _randomBetweenPrevious;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;

            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    int gap = target.Unit.GetStoredValue(_valueName);
                    int amount = entryVariable;
                    if (_randomBetweenPrevious)
                    {
                        amount = UnityEngine.Random.Range(base.PreviousExitValue, entryVariable + 1);
                    }

                    gap += (_increase ? amount : (-amount));
                    gap = Mathf.Max(_minimumValue, gap);
                    target.Unit.SetStoredValue(_valueName, gap);
                    exitAmount += amount;
                }
            }
            return exitAmount > 0;
        }
    }
    public class TargetSetValueChangeEffect : EffectSO
    {
        [SerializeField]
        public bool _increase = true;

        [SerializeField]
        public UnitStoredValueNames _valueName = NoiseHandler.Noise;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;

            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    target.Unit.SetStoredValue(_valueName, entryVariable);
                    exitAmount += target.Unit.GetStoredValue(_valueName);
                }
            }
            return exitAmount > 0;
        }
    }

    public class LockedInPassiveAbility : BasePassiveAbilitySO
    {
        public override bool DoesPassiveTrigger => false;
        public override bool IsPassiveImmediate => false;

        public override void TriggerPassive(object sender, object args)
        {
        }

        public override void OnPassiveConnected(IUnit unit)
        {
        }
        public override void OnPassiveDisconnected(IUnit unit)
        {
        }
    }
    public static class LockedInHandler
    {
        public const string Boowomp = "event:/Hawthorne/Boowomp";
        public static bool IsLocked()
        {
            try
            {
                if (CombatManager._instance == null) return false;
                if (CombatManager.Instance._stats == null) return false;
                if (!CombatManager.Instance._stats.InCombat) return false;
                foreach (EnemyCombat enemy in CombatManager.Instance._stats.EnemiesOnField.Values)
                {
                    foreach (BasePassiveAbilitySO passive in enemy.PassiveAbilities) if (passive is LockedInPassiveAbility) return true;
                }
                foreach (CharacterCombat chara in CombatManager.Instance._stats.CharactersOnField.Values)
                {
                    foreach (BasePassiveAbilitySO passive in chara.PassiveAbilities) if (passive is LockedInPassiveAbility) return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                UnityEngine.Debug.LogError("the locked in handler is fucking up again!!");
                return true;
            }
        }
        public static void OpenPauseMenu(Action<PauseUIHandler> orig, PauseUIHandler self)
        {
            try
            { if (IsLocked())
                { if (Boowomp != "") RuntimeManager.PlayOneShot(Boowomp, default(Vector3)); }
                else orig(self);
            }
            catch(Exception ex)
            {
                UnityEngine.Debug.LogError("the locked in handler is *reaally* fucking up now.");
                try
                {
                    orig(self);
                }
                catch(Exception e)
                {
                    UnityEngine.Debug.LogError("Ok what the fuck");
                }
            }
        }
        public static void Setup()
        {
            IDetour lockin = new Hook(typeof(PauseUIHandler).GetMethod(nameof(PauseUIHandler.OpenPauseMenu), ~BindingFlags.Default), typeof(LockedInHandler).GetMethod(nameof(OpenPauseMenu), ~BindingFlags.Default));
        }
    }

    public class DelayRespawnEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            CombatManager.Instance.AddRootAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[] { new Effect(ScriptableObject.CreateInstance<RespawnEffect>(), 1, null, Slots.Self) }), caster));
            return true;
        }
    }
    public class RespawnEffect : EffectSO
    {
        public bool givesExperience;

        [SerializeField]
        public SpawnType _spawnType = SpawnType.Basic;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0; if (caster.IsUnitCharacter) return false;
            EnemySO enemy = (caster as EnemyCombat).Enemy;
            for (int i = 0; i < entryVariable; i++)
            {
                CombatManager.Instance.AddSubAction(new SpawnEnemyAction(enemy, caster.SlotID, givesExperience, trySpawnAnyways: false, _spawnType));
            }

            exitAmount = entryVariable;
            return true;
        }
    }

    public class PainCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is IntegerReference skinteger)
            {
                (effector as IUnit).SetStoredValue(Pain, (effector as IUnit).GetStoredValue(Pain) + skinteger.value);
                if ((effector as IUnit).GetStoredValue(Pain) < 20) return false;
                    
            }
            else
            {
                (effector as IUnit).SetStoredValue(Pain, 0);
                return false;
            }
            if (!effector.IsAlive || effector.CurrentHealth <= 0) return false;
            return true;
        }


        public static UnitStoredValueNames Pain = (UnitStoredValueNames)357463;


        public static string AddStoredValueName1(
          Func<TooltipTextHandlerSO, UnitStoredValueNames, int, string> orig,
          TooltipTextHandlerSO self,
          UnitStoredValueNames storedValue,
          int value)
        {
            Color magenta = Color.magenta;
            string str1;
            if (storedValue == Pain)
            {
                if (value <= 0)
                {
                    str1 = "";
                }
                else
                {
                    string str2 = "Damage Taken This Turn:" + string.Format(" {0}", (object)value);
                    string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(self._negativeSTColor) + ">";
                    string str4 = "</color>";
                    str1 = str3 + str2 + str4;
                }
            }
            else
                str1 = orig(self, storedValue, value);
            return str1;
        }

        public static void Setup()
        {
            IDetour salineVale = new Hook((MethodBase)typeof(TooltipTextHandlerSO).GetMethod(nameof(TooltipTextHandlerSO.ProcessStoredValue), ~BindingFlags.Default), typeof(PainCondition).GetMethod(nameof(AddStoredValueName1), ~BindingFlags.Default));

        }
    }

    public static class DishPassiveHook
    {
        // Token: 0x0600003E RID: 62 RVA: 0x000056DC File Offset: 0x000038DC
        public static void Add()
        {
            IDetour detour = new Hook(typeof(Shield_SlotStatusEffect).GetMethod("OnStatusTick", (BindingFlags)(-1)), typeof(DishPassiveHook).GetMethod("OnStatusTick", (BindingFlags)(-1)));
        }

        // Token: 0x0600003F RID: 63 RVA: 0x0000571C File Offset: 0x0000391C
        public static void OnStatusTick(Action<Shield_SlotStatusEffect, object, object> orig, Shield_SlotStatusEffect self, object sender, object args)
        {
            CombatSlot combatSlot = sender as CombatSlot;
            bool flag = combatSlot != null && combatSlot.HasUnit;
            if (flag)
            {
                bool flag2 = combatSlot.Unit.ContainsPassiveAbility((PassiveAbilityTypes)45454);
                if (flag2)
                {
                    return;
                }
            }
            orig(self, sender, args);
        }
    }

    public class Targetting_ByUnit_SideColor : Targetting_ByUnit_Side
    {
        public ManaColorSO Color;
        
        public override bool AreTargetAllies => getAllies;

        public override bool AreTargetSlots => getAllUnitSlots;

        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            List<TargetSlotInfo> ret = new List<TargetSlotInfo>();
            TargetSlotInfo[] source = base.GetTargets(slots, casterSlotID, isCasterCharacter);
            foreach (TargetSlotInfo target in source)
            {
                if (target.HasUnit && target.Unit.HealthColor == Color) ret.Add(target);
            }
            return ret.ToArray();
        }
    }

    public static class AmbushManager
    {
        public static int Patiently = 8086792;

        public static void PostNotif(IUnit unit)
        {
            foreach (TargetSlotInfo target in Slots.Front.GetTargets(CombatManager.Instance._stats.combatSlots, unit.SlotID, unit.IsUnitCharacter))
            {
                if (target.HasUnit)
                {
                    CombatManager.Instance.PostNotification(((TriggerCalls)Patiently).ToString(), target.Unit, null);
                }
            }
        }

        public static void EnemySwap(Action<EnemyCombat, int> orig, EnemyCombat self, int slotID)
        {
            orig(self, slotID);
            PostNotif(self);

        }
        public static void CharacterSwap(Action<CharacterCombat, int> orig, CharacterCombat self, int slotID)
        {
            orig(self, slotID);
            PostNotif(self);
        }

        public static void Setup()
        {
            IDetour EnemySwapTo = new Hook((MethodBase)typeof(EnemyCombat).GetMethod(nameof(EnemyCombat.SwapTo), ~BindingFlags.Default), typeof(AmbushManager).GetMethod(nameof(EnemySwap), ~BindingFlags.Default));
            IDetour EnemySwappedTo = new Hook((MethodBase)typeof(EnemyCombat).GetMethod(nameof(EnemyCombat.SwappedTo), ~BindingFlags.Default), typeof(AmbushManager).GetMethod(nameof(EnemySwap), ~BindingFlags.Default));
            IDetour CharaSwapTo = new Hook((MethodBase)typeof(CharacterCombat).GetMethod(nameof(CharacterCombat.SwapTo), ~BindingFlags.Default), typeof(AmbushManager).GetMethod(nameof(CharacterSwap), ~BindingFlags.Default));
            IDetour CharaSwappedTo = new Hook((MethodBase)typeof(CharacterCombat).GetMethod(nameof(CharacterCombat.SwappedTo), ~BindingFlags.Default), typeof(AmbushManager).GetMethod(nameof(CharacterSwap), ~BindingFlags.Default));
        }
    }

    public class DamoclesCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (UnityEngine.Random.Range(0, 100) > 50) return false;
            if (args is IntegerReference skinteger && skinteger.value > 0 && effector is IUnit unit)
            {
                CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(effector.ID, effector.IsUnitCharacter, Passi.TheFall._passiveName, Passi.TheFall.passiveIcon));
                unit.DirectDeath(null);
                CombatManager.Instance.AddUIAction(new PlayAbilityAnimationAction(LoadedAssetsHandler.GetEnemyAbility("Domination_A").visuals, Slots.Front, unit));
                TargetSlotInfo[] targets = Slots.Front.GetTargets(CombatManager.Instance._stats.combatSlots, unit.SlotID, unit.IsUnitCharacter);
                int total = 0;
                foreach (TargetSlotInfo target in targets)
                {
                    if (target.HasUnit)
                    {
                        int amount = unit.WillApplyDamage(skinteger.value, target.Unit);
                        total += target.Unit.Damage(amount, unit, DeathType.Basic, -1, true, true, false).damageAmount;
                    }
                }
                if (total > 0) unit.DidApplyDamage(total);
                CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[]
                {
                    new Effect(ScriptableObject.CreateInstance<SpawnCasterGibsEffect>(), 1, null, Slots.Self)
                }), unit));
                return false;
            }
            return false;
        }
    }

    public class IllusionEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = entryVariable;
            if (!Check.EnemyExist("Illusion_EN")) return false;
            int g = 10;
            g *= stats.TurnsPassed;
            if (UnityEngine.Random.Range(0, 100) < g)
            {
                SpawnEnemyAnywhereEffect moreIllusion = ScriptableObject.CreateInstance<SpawnEnemyAnywhereEffect>();
                moreIllusion.enemy = LoadedAssetsHandler.GetEnemy("Illusion_EN");
                CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(caster.ID, false, Passi.Illusion._passiveName, Passi.Illusion.passiveIcon));
                CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[] { new Effect(moreIllusion, 1, null, Slots.Self) }), caster));
                return true;
            }
            return false;
        }
    }

    public class SnakeGodPassive : BasePassiveAbilitySO
    {
        public override bool DoesPassiveTrigger => true;
        public override bool IsPassiveImmediate => true;

        public override void TriggerPassive(object sender, object args)
        {
        }

        public override void OnPassiveConnected(IUnit unit)
        {
            LastAttacker = -1;
            AllAttackers = new List<int>();
            unit.SetStoredValue(SnakeGodManager.Last, 0);
        }
        public override void OnPassiveDisconnected(IUnit unit)
        {
            LastAttacker = -1;
            AllAttackers = new List<int>();
            unit.SetStoredValue(SnakeGodManager.Last, 0);
        }

        public int LastAttacker = -1;
        public List<int> AllAttackers;
    }
    public static class SnakeGodManager
    {
        public static DamageInfo Damage(Func<EnemyCombat, int, IUnit, DeathType, int, bool, bool, bool, DamageType, DamageInfo> orig, EnemyCombat self, int amount, IUnit killer, DeathType deathType, int targetSlotOffset = -1, bool addHealthMana = true, bool directDamage = true, bool ignoresShield = false, DamageType specialDamage = DamageType.None)
        {
            DamageInfo ret = orig(self, amount, killer, deathType, targetSlotOffset, addHealthMana, directDamage, ignoresShield, specialDamage);
            if (ret.damageAmount > 0 && killer != null && killer.IsUnitCharacter)
            { 
                foreach (BasePassiveAbilitySO passive in self.PassiveAbilities)
                {
                    if (passive is SnakeGodPassive snakey)
                    {
                        if (DoDebugs.MiscInfo) UnityEngine.Debug.Log("yah");
                        if (killer is CharacterCombat chara)
                        { 
                            if (DoDebugs.MiscInfo) UnityEngine.Debug.Log(chara._currentName);
                            if (DoDebugs.MiscInfo) UnityEngine.Debug.Log(chara.ID);
                            int id = chara.ID;
                            if (id == 0) id = -1;
                            snakey.LastAttacker = chara.ID;
                            self.SetStoredValue(Last, id);
                            if (!snakey.AllAttackers.Contains(chara.ID)) snakey.AllAttackers.Add(chara.ID);
                        } 
                        if (killer != null)
                        {
                            CombatManager.Instance._stats.statusEffectDataBase.TryGetValue(StatusEffectType.Scars, out StatusEffectInfoSO value);
                            Scars_StatusEffect scars_StatusEffect = new Scars_StatusEffect(1);
                            scars_StatusEffect.SetEffectInformation(value);
                            killer.ApplyStatusEffect(scars_StatusEffect, 1);
                        }
                    }
                } 
            }
            return ret;
        }
        public static UnitStoredValueNames Last = (UnitStoredValueNames)335798;

        public static string AddStoredValueName1(
          Func<TooltipTextHandlerSO, UnitStoredValueNames, int, string> orig,
          TooltipTextHandlerSO self,
          UnitStoredValueNames storedValue,
          int value)
        {
            Color magenta = Color.magenta;
            string str1;
            if (storedValue == Last)
            {
                if (value == 0)
                {
                    str1 = "";
                }
                else
                {
                    CharacterCombat chara = null;
                    int check = value;
                    if (check == -1) check = 0;
                    foreach (CharacterCombat ch in CombatManager.Instance._stats.CharactersOnField.Values)
                    {
                        if (ch.ID == check) chara = ch;
                    }
                    if (chara == null) return "";
                    string str2 = "Eyes on: " + chara._currentName;
                    string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(Color.yellow) + ">";
                    string str4 = "</color>";
                    str1 = str3 + str2 + str4;
                }
            }
            else
                str1 = orig(self, storedValue, value);
            return str1;
        }
        public static void Setup()
        {
            IDetour salineVale = new Hook((MethodBase)typeof(TooltipTextHandlerSO).GetMethod(nameof(TooltipTextHandlerSO.ProcessStoredValue), ~BindingFlags.Default), typeof(SnakeGodManager).GetMethod(nameof(AddStoredValueName1), ~BindingFlags.Default));
            IDetour hook = new Hook(typeof(EnemyCombat).GetMethod(nameof(EnemyCombat.Damage), ~BindingFlags.Default), typeof(SnakeGodManager).GetMethod(nameof(Damage), ~BindingFlags.Default));
        }
    }
    public class Targetting_BySnakeGod : BaseCombatTargettingSO
    {
        public override bool AreTargetAllies => false;

        public override bool AreTargetSlots => false;

        public bool GetAll;

        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            List<TargetSlotInfo> ret = new List<TargetSlotInfo>();
            if (isCasterCharacter) return ret.ToArray();
            TargetSlotInfo self = slots.GetEnemyTargetSlot(casterSlotID, 0);
            if (!self.HasUnit) return ret.ToArray();
            TargetSlotInfo[] all = slots.GetAllUnitTargetSlots(true, false);
            foreach (BasePassiveAbilitySO passive in (self.Unit as IPassiveEffector).PassiveAbilities)
            {
                if (passive is SnakeGodPassive snakey)
                {
                    foreach (TargetSlotInfo target in all)
                    {
                        if (target.HasUnit)
                        {
                            if (GetAll)
                            {
                                if (snakey.AllAttackers.Contains(target.Unit.ID))
                                {
                                    ret.Add(target);
                                }
                            }
                            else
                            {
                                if (target.Unit.ID == snakey.LastAttacker)
                                {
                                    ret.Add(target);
                                }
                            }
                        }
                    }
                }
            }
            return ret.ToArray();
        }

        public static Targetting_BySnakeGod Create(bool getAll)
        {
            Targetting_BySnakeGod ret = ScriptableObject.CreateInstance<Targetting_BySnakeGod>();
            ret.GetAll = getAll;
            return ret;
        }
    }
    public class AbilitySelector_SnakeGod : BaseAbilitySelectorSO
    {
        [Header("Special Abilities")]
        [SerializeField]
        public string eatTear = Abili.EatTears.name;

        public override bool UsesRarity => true;

        public override int GetNextAbilitySlotUsage(List<CombatAbility> abilities, IUnit unit)
        {
            int maxExclusive1 = 0;
            int maxExclusive2 = 0;
            List<int> intList1 = new List<int>();
            List<int> intList2 = new List<int>();
            for (int index = 0; index < abilities.Count; ++index)
            {
                if (this.ShouldBeIgnored(abilities[index], unit))
                {
                    maxExclusive2 += abilities[index].rarity.rarityValue;
                    intList2.Add(index);
                }
                else
                {
                    maxExclusive1 += abilities[index].rarity.rarityValue;
                    intList1.Add(index);
                }
            }
            int num1 = UnityEngine.Random.Range(0, maxExclusive1);
            int num2 = 0;
            foreach (int index in intList1)
            {
                num2 += abilities[index].rarity.rarityValue;
                if (num1 < num2)
                    return index;
            }
            int num3 = UnityEngine.Random.Range(0, maxExclusive2);
            int num4 = 0;
            foreach (int index in intList2)
            {
                num4 += abilities[index].rarity.rarityValue;
                if (num3 < num4)
                    return index;
            }
            return -1;
        }

        public bool ShouldBeIgnored(CombatAbility ability, IUnit unit)
        {
            string name = ability.ability._abilityName;
            int pigs = 0;
            foreach (ManaBarSlot mana in CombatManager.Instance._stats.MainManaBar.ManaBarSlots)
            {
                if (!mana.IsEmpty && mana.ManaColor == Pigments.Blue) pigs++;
            }
            if (DoDebugs.MiscInfo) UnityEngine.Debug.Log("Blue pigment: " + pigs);
            if (DoDebugs.MiscInfo) UnityEngine.Debug.Log("Ability: " + name);
            return pigs <= 2 && name == this.eatTear;
        }
    }

    public static class PostmodernHandler
    {
        public static OverworldManagerBG world;
        public static void Awake(Action<OverworldManagerBG> orig, OverworldManagerBG self)
        {
            orig(self);
            world = self;
        }
        public static void Setup()
        {
            IDetour awakening = new Hook(typeof(OverworldManagerBG).GetMethod(nameof(OverworldManagerBG.Awake), ~BindingFlags.Default), typeof(PostmodernHandler).GetMethod(nameof(Awake), ~BindingFlags.Default));
            IDetour diologo = new Hook(typeof(OverworldManagerBG).GetMethod(nameof(OverworldManagerBG.InitializeDialogueFunctions), ~BindingFlags.Default), typeof(PostmodernHandler).GetMethod(nameof(InitializeDialogueFunctions), ~BindingFlags.Default));
            IDetour hook = new Hook(typeof(InGameDataSO).GetMethod(nameof(InGameDataSO.DidCompleteQuest), ~BindingFlags.Default), typeof(PostmodernHandler).GetMethod(nameof(DidCompleteQuest), ~BindingFlags.Default));
            Add();
            Hacks.Setup();
            postmodernevent();
        }

        public static void InitializeDialogueFunctions(Action<OverworldManagerBG, DialogueRunner> orig, OverworldManagerBG self, DialogueRunner dialogueRunner)
        {
            orig(self, dialogueRunner);
            if (DoDebugs.GenInfo) UnityEngine.Debug.Log("command set");
            dialogueRunner.AddCommandHandler("SaltPostmodernity", TriggerPostmodern);
        }

        public static void TriggerPostmodern(string[] info)
        {
            world.StartCoroutine(HandlePrePostmodernEvent(world));
        }


        public static IEnumerator HandlePrePostmodernEvent(OverworldManagerBG self)
        {
            RunDataSO run = self._informationHolder.Run;
            BaseRoomHandler currentRoomInstance = run.GetCurrentRoomInstance();
            if (currentRoomInstance != null)
            {
                currentRoomInstance.LockRoom();
            }

            EnemyCombatBundle enemyBundle = PostmodernEvent;
            if (enemyBundle.PreCombatDialogueReference != "")
            {
                self.StartDialog(enemyBundle.PreCombatDialogueReference);
                while (self._inDialogue)
                {
                    yield return null;
                }
            }

            self._inputManager.SetEscapeToggle(enabled: false);
            self.SaveProgress(fullySave: false);
            run.zoneLoadingType = ZoneLoadingType.Combat;
            ZoneDataBaseSO currentZoneDB = self._informationHolder.Run.CurrentZoneDB;
            OverworldCombatSharedDataSO combatData = self._informationHolder.CombatData;
            combatData.playerCurrency = run.playerData.PlayerCurrency;
            combatData.owSceneName = SceneManager.GetActiveScene().name;
            combatData.combatAmbienceType = currentZoneDB.CombatAmbience;
            combatData.combatEnvironmentPrefabName = currentZoneDB.CombatEnvironment;
            combatData.enemyBundle = enemyBundle;
            combatData.CharactersData = run.playerData.CharactersInParty;
            combatData.SetUpRunDataForCombat(shouldSaveRunInCombat: true);
            yield return self.LoadCombatScene();
        }

        static EnemySO Postmodern => LoadedAssetsHandler.GetEnemy("Postmodern_EN");
        static EnemySO War => LoadedAssetsHandler.GetEnemy("War_EN");
        static string Music => "event:/Hawthorne/PostmodernTheme";
        static string Roar => "event:/Hawthorne/HissingNoise";
        
        public static EnemyCombatBundle PostmodernEvent
        {
            get
            {
                EnemyBundleData[] list = new EnemyBundleData[]
                {
                    new EnemyBundleData(Postmodern, 1),
                    new EnemyBundleData(War, 3)
                };
                RoarData roar = new RoarData(Roar);
                EnemyCombatBundle ret = new EnemyCombatBundle(list, "", Music, roar, BossType.None, BundleDifficulty.Boss, "", RoomPrefab, Sign);
                return ret;
            }
        }

        public static string RoomPrefab = "PostmodernRoom";
        public static string Encounter = "PostmodernEncounter";
        public static string Dialogue = "PostmodernConvo";
        public static string Finish = "PostmodernFinish";
        public static string Speaker = "Postmodern" + PathUtils.speakerDataSuffix;

        public static SignType Sign = (SignType)199999;
        public static EntityIDs Entity = (EntityIDs)199999;
        public static QuestIDs Quest = (QuestIDs)199999;

        public static Sprite World => ResourceLoader.LoadSprite("PostmodernWorld.png", 100, new Vector2(0.5f, 0));
        public static Sprite WNPivot => ResourceLoader.LoadSprite("PostmodernWorld.png", 100);
        public static Sprite Front => ResourceLoader.LoadSprite("PostmodernFace.png", 100);
        public static YarnProgram Script
        {
            get
            {
                if (scriptMinor == null)
                {
                    YarnProgram y = SaltEnemies.Group4.LoadAsset<YarnProgram>("assets/group4/Postmodern/postmodern.yarn");
                    scriptMinor = y;
                }
                return scriptMinor;
            }
        }
        static YarnProgram scriptMinor;
        public static Material SpriteMat
        {
            get
            {
                BasicEncounterSO jesus = LoadedAssetsHandler.GetBasicEncounter("PervertMessiah_Flavour");

                NPCRoomHandler hJesus = LoadedAssetsHandler.GetRoomPrefab(CardType.Flavour, jesus.encounterRoom) as NPCRoomHandler;

                BasicRoomItem hje = hJesus._npcSelectable as BasicRoomItem;

                return hje._renderers[0].material;
            }
        }

        public static DialogueSO AfterCombat;

        public static void postmodernevent()
        {
            if (LetsYouIgnoreMissingEnemiesHook.IsDisabled("Postmodern_EN")) return;
            NPCRoomHandler room = SaltEnemies.Group4.LoadAsset<GameObject>("assets/group4/Postmodern/PostmodernRoom.prefab").AddComponent<NPCRoomHandler>();

            room._npcSelectable = room.transform.GetChild(0).gameObject.AddComponent<BasicRoomItem>();
            room._npcSelectable._renderers = new SpriteRenderer[]
            {
                room._npcSelectable.transform.GetChild(0).GetComponent<SpriteRenderer>()
            };

            room._npcSelectable._renderers[0].material = SpriteMat;

            if (!LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains(PathUtils.encounterRoomsResPath + RoomPrefab)) LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + RoomPrefab, room);
            else LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + RoomPrefab] = room;

            YarnProgram prog = Script;
            DialogueSO log = ScriptableObject.CreateInstance<DialogueSO>();
            log.name = Dialogue;
            log.dialog = prog;
            log.startNode = "Salt.Postmodern.Start";
            if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains(Dialogue)) LoadedAssetsHandler.LoadedDialogues.Add(Dialogue, log);
            else LoadedAssetsHandler.LoadedDialogues[Dialogue] = log;

            DialogueSO dies = ScriptableObject.CreateInstance<DialogueSO>();
            dies.name = Finish;
            dies.dialog = prog;
            dies.startNode = "Salt.Postmodern.end";
            if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains(Finish)) LoadedAssetsHandler.LoadedDialogues.Add(Finish, dies);
            else LoadedAssetsHandler.LoadedDialogues[Finish] = dies;
            AfterCombat = dies;


            ConditionEncounterSO ret = ScriptableObject.CreateInstance<ConditionEncounterSO>();
            ret.questName = Quest;
            ret.name = Encounter;
            ret._dialogue = Dialogue;
            ret.encounterRoom = RoomPrefab;
            ret.signType = Sign;
            ret.npcEntityIDs = new EntityIDs[] { Entity };
            ret.questsCompletedNeeded = new QuestIDs[0];
            if (!LoadedAssetsHandler.LoadedBasicEncounters.Keys.Contains(Encounter)) LoadedAssetsHandler.LoadedBasicEncounters.Add(Encounter, ret);
            else LoadedAssetsHandler.LoadedBasicEncounters[Encounter] = ret;


            ZoneBGDataBaseSO gardE = LoadedAssetsHandler.GetZoneDB("ZoneDB_03") as ZoneBGDataBaseSO;
            ZoneBGDataBaseSO gardH = LoadedAssetsHandler.GetZoneDB("ZoneDB_Hard_03") as ZoneBGDataBaseSO;

            CardTypeInfo card = new CardTypeInfo();
            card._cardInfo = new CardInfo() { cardType = CardType.Flavour, pilePosition = PilePositionType.Any };
            card._percentage = 15;
            card._usePercentage = true;


            /*if (!gardE._FlavourPool.Contains(encounterName))
            {
                List<string> oldEF = new List<string>(gardE._FlavourPool);
                oldEF.Add(encounterName);
                gardE._FlavourPool = oldEF.ToArray();

                //List<CardTypeInfo> oldEC = new List<CardTypeInfo>(gardE._deckInfo._possibleCards);
                //oldEC.Add(card);
                //gardE._deckInfo._possibleCards = oldEC.ToArray();
            }*/

            if (!gardH._FlavourPool.Contains(Encounter))
            {
                List<string> oldHF = new List<string>(gardH._FlavourPool);
                oldHF.Add(Encounter);
                gardH._FlavourPool = oldHF.ToArray();
                List<CardTypeInfo> oldHC = new List<CardTypeInfo>(gardH._deckInfo._possibleCards);
                oldHC.Add(card);
                gardH._deckInfo._possibleCards = oldHC.ToArray();
            }


            SpeakerData test = ScriptableObject.CreateInstance<SpeakerData>();
            test.speakerName = Speaker;
            test.name = Speaker;

            SpeakerBundle testBund = new SpeakerBundle();
            testBund.dialogueSound = "event:/Hawthorne/HissingNoise";
            testBund.portrait = Front;
            testBund.bundleTextColor = Color.white;


            test._defaultBundle = testBund;
            test.portraitLooksLeft = true;
            test.portraitLooksCenter = false;

            if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains(Speaker)) LoadedAssetsHandler.LoadedSpeakers.Add(Speaker, test);
            else LoadedAssetsHandler.LoadedSpeakers[Speaker] = test;
            if (DoDebugs.GenInfo) UnityEngine.Debug.Log("room set");

        }
        public static void Add()
        {
            BrutalAPI.BrutalAPI.AddSignType(Sign, WNPivot);
        }

        public static bool DidCompleteQuest(Func<InGameDataSO, QuestIDs, bool> orig, InGameDataSO self, QuestIDs questName)
        {
            if (questName == Quest)
            {
                return (UnityEngine.Random.Range(0, 100) < 75);
            }
            return orig(self, questName);
        }

    }
    public static class Hacks
    {
        public static void Setup()
        {
            //DONT NEED???
            //IDetour hook = new Hook(typeof(RunDataSO).GetMethod(nameof(RunDataSO.PopulateRoomInstance), ~BindingFlags.Default), typeof(Hacks).GetMethod(nameof(PopulateRoomInstance), ~BindingFlags.Default));
            IDetour cont = new Hook(typeof(MainMenuController).GetMethod(nameof(MainMenuController.LoadOldRun), ~BindingFlags.Default), typeof(Hacks).GetMethod(nameof(LoadOldRun), ~BindingFlags.Default));
            IDetour emba = new Hook(typeof(MainMenuController).GetMethod(nameof(MainMenuController.OnEmbarkPressed), ~BindingFlags.Default), typeof(Hacks).GetMethod(nameof(LoadOldRun), ~BindingFlags.Default));
            //ScreenShake.Setup();
        }
        public static void LoadOldRun(Action<MainMenuController> orig, MainMenuController self)
        {
            orig(self);
            PostmodernHandler.postmodernevent();
        }
    }

    public static class SepulchreFix
    {
        public delegate T8 DelegateEffect<T1, T2, T3, T4, T5, T6, T7, T8>(T1 a, T2 b, T3 c, T4 d, T5 e, T6 f, out T7 g);

        public static bool PerformEffect(DelegateEffect<SpawnMassivelyEverywhereUsingHealthEffect, CombatStats, IUnit, TargetSlotInfo[], bool, int, int, bool> orig, SpawnMassivelyEverywhereUsingHealthEffect self, CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            if (self._possibleEnemies != null)
            {
                List<EnemySO> newlist = new List<EnemySO>();
                foreach (EnemySO enemy in self._possibleEnemies) if (enemy != null) newlist.Add(enemy);
                self._possibleEnemies = newlist.ToArray();
            }
            
            return orig(self, stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
        }

        public static void Setup()
        {
            IDetour hook = new Hook(typeof(SpawnMassivelyEverywhereUsingHealthEffect).GetMethod(nameof(SpawnMassivelyEverywhereUsingHealthEffect.PerformEffect), ~BindingFlags.Default), typeof(SepulchreFix).GetMethod(nameof(PerformEffect), ~BindingFlags.Default));
        }
    }

    public class AbilitySelector_Shua : BaseAbilitySelectorSO
    {
        [Header("Special Abilities")]
        [SerializeField]
        public string wanderlust = Abili.Wanderlust.name;

        public override bool UsesRarity => true;

        public override int GetNextAbilitySlotUsage(List<CombatAbility> abilities, IUnit unit)
        {
            int maxExclusive1 = 0;
            int maxExclusive2 = 0;
            List<int> intList1 = new List<int>();
            List<int> intList2 = new List<int>();
            for (int index = 0; index < abilities.Count; ++index)
            {
                if (this.ShouldBeIgnored(abilities[index], unit))
                {
                    maxExclusive2 += abilities[index].rarity.rarityValue;
                    intList2.Add(index);
                }
                else
                {
                    maxExclusive1 += abilities[index].rarity.rarityValue;
                    intList1.Add(index);
                }
            }
            int num1 = UnityEngine.Random.Range(0, maxExclusive1);
            int num2 = 0;
            foreach (int index in intList1)
            {
                num2 += abilities[index].rarity.rarityValue;
                if (num1 < num2)
                    return index;
            }
            int num3 = UnityEngine.Random.Range(0, maxExclusive2);
            int num4 = 0;
            foreach (int index in intList2)
            {
                num4 += abilities[index].rarity.rarityValue;
                if (num3 < num4)
                    return index;
            }
            return -1;
        }

        public bool ShouldBeIgnored(CombatAbility ability, IUnit unit)
        {
            string name = ability.ability._abilityName;
            return unit.GetStoredValue(UnitStoredValueNames.DemonCoreW) == 1 && name == this.wanderlust;
        }
    }

    public class NormalAndConnection_PerformEffectPassiveAbility : BasePassiveAbilitySO
    {
        [Header("Passive Effects")]
        public EffectInfo[] effects;

        public bool immediateEffect = false;

        public EffectInfo[] connectionEffects;

        public EffectInfo[] disconnectionEffects;

        public override bool IsPassiveImmediate => false;

        public override bool DoesPassiveTrigger => true;

        public override void TriggerPassive(object sender, object args)
        {
            IUnit caster = sender as IUnit;
            CombatManager.Instance.AddSubAction(new EffectAction(effects, caster));
        }

        public override void OnPassiveConnected(IUnit unit)
        {
            if (connectionEffects == null) return;
            if (immediateEffect)
            {
                CombatManager.Instance.ProcessImmediateAction(new ImmediateEffectAction(connectionEffects, unit), addToPreInit: true);
            }
            else
            {
                CombatManager.Instance.AddSubAction(new EffectAction(connectionEffects, unit));
            }
        }

        public override void OnPassiveDisconnected(IUnit unit)
        {
            if (disconnectionEffects == null) return;
            if (immediateEffect)
            {
                CombatManager.Instance.ProcessImmediateAction(new ImmediateEffectAction(disconnectionEffects, unit));
            }
            else
            {
                CombatManager.Instance.AddSubAction(new EffectAction(disconnectionEffects, unit));
            }
        }
    }
    public class AbilitySelector_Hunter : BaseAbilitySelectorSO
    {
        [Header("Special Abilities")]
        [SerializeField]
        public string trackDown = Abili.TrackDown.name;
        public string nest = Abili.Nest.name;
        public string patience = Abili.Patience.name;

        public override bool UsesRarity => true;

        public override int GetNextAbilitySlotUsage(List<CombatAbility> abilities, IUnit unit)
        {
            int maxExclusive1 = 0;
            int maxExclusive2 = 0;
            List<int> intList1 = new List<int>();
            List<int> intList2 = new List<int>();
            for (int index = 0; index < abilities.Count; ++index)
            {
                if (this.ShouldBeIgnored(abilities[index], unit) || this.AlsoBeIgnored(abilities[index], unit))
                {
                    maxExclusive2 += abilities[index].rarity.rarityValue;
                    intList2.Add(index);
                }
                else if (this.MustBeUsed(abilities[index], unit))
                {
                    return index;
                }
                else
                {
                    maxExclusive1 += abilities[index].rarity.rarityValue;
                    intList1.Add(index);
                }
            }
            int num1 = UnityEngine.Random.Range(0, maxExclusive1);
            int num2 = 0;
            foreach (int index in intList1)
            {
                num2 += abilities[index].rarity.rarityValue;
                if (num1 < num2)
                    return index;
            }
            int num3 = UnityEngine.Random.Range(0, maxExclusive2);
            int num4 = 0;
            foreach (int index in intList2)
            {
                num4 += abilities[index].rarity.rarityValue;
                if (num3 < num4)
                    return index;
            }
            return -1;
        }

        public bool ShouldBeIgnored(CombatAbility ability, IUnit unit)
        {
            string name = ability.ability._abilityName;
            return unit.GetStoredValue(UnitStoredValueNames.DemonCoreW) == 1 && name == this.trackDown;
        }
        public bool AlsoBeIgnored(CombatAbility ability, IUnit unit)
        {
            UnitStoredValueNames u = (UnitStoredValueNames)869103;
            string name = ability.ability._abilityName;
            if (name == this.nest)
            {
                if (unit.GetStoredValue(u) > 0)
                {
                    unit.SetStoredValue(u, 0);
                    return true;
                }
                else
                {
                    unit.SetStoredValue(u, unit.GetStoredValue(u) + 1);
                    return false;
                }
            }
            return false;
        }
        public bool MustBeUsed(CombatAbility ability, IUnit unit)
        {
            string name = ability.ability._abilityName;
            bool NobodyWithTerror = true;
            foreach (CharacterCombat chara in CombatManager.Instance._stats.CharactersOnField.Values)
            {
                if (chara.ContainsStatusEffect(Terror.Type)) { NobodyWithTerror = false; break; }
            }
            return NobodyWithTerror && name == this.patience;
        }
    }

    public class AbilitySelector_Firebird : BaseAbilitySelectorSO
    {
        [Header("Special Abilities")]
        [SerializeField]
        public string trackDown = Abili.FireDeath.name;

        public override bool UsesRarity => true;

        public override int GetNextAbilitySlotUsage(List<CombatAbility> abilities, IUnit unit)
        {
            int maxExclusive1 = 0;
            int maxExclusive2 = 0;
            List<int> intList1 = new List<int>();
            List<int> intList2 = new List<int>();
            for (int index = 0; index < abilities.Count; ++index)
            {
                if (this.ShouldBeIgnored(abilities[index], unit))
                {
                    maxExclusive2 += abilities[index].rarity.rarityValue;
                    intList2.Add(index);
                }
                else
                {
                    maxExclusive1 += abilities[index].rarity.rarityValue;
                    intList1.Add(index);
                }
            }
            int num1 = UnityEngine.Random.Range(0, maxExclusive1);
            int num2 = 0;
            foreach (int index in intList1)
            {
                num2 += abilities[index].rarity.rarityValue;
                if (num1 < num2)
                    return index;
            }
            int num3 = UnityEngine.Random.Range(0, maxExclusive2);
            int num4 = 0;
            foreach (int index in intList2)
            {
                num4 += abilities[index].rarity.rarityValue;
                if (num3 < num4)
                    return index;
            }
            return -1;
        }

        public bool ShouldBeIgnored(CombatAbility ability, IUnit unit)
        {
            int orig = 35;
            if (unit is EnemyCombat enemy) orig = enemy.Enemy.health;
            string name = ability.ability._abilityName;
            return unit.CurrentHealth >= orig && name == this.trackDown;
        }
    }

    public static class FleetingHandler
    {
        public static UnitStoredValueNames flee = UnitStoredValueNames.FleetingPA;


        public static string AddStoredValueName1(
          Func<TooltipTextHandlerSO, UnitStoredValueNames, int, string> orig,
          TooltipTextHandlerSO self,
          UnitStoredValueNames storedValue,
          int value)
        {
            Color magenta = Color.magenta;
            string str1;
            if (storedValue == flee)
            {
                if (value <= 0)
                {
                    str1 = "";
                }
                else
                {
                    string str2 = "Fleeting Count:" + string.Format(" {0}", (object)value);
                    string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(self._positiveSTColor) + ">";
                    string str4 = "</color>";
                    str1 = str3 + str2 + str4;
                }
            }
            else
                str1 = orig(self, storedValue, value);
            return str1;
        }

        public static void Setup()
        {
            IDetour salineVale = new Hook((MethodBase)typeof(TooltipTextHandlerSO).GetMethod(nameof(TooltipTextHandlerSO.ProcessStoredValue), ~BindingFlags.Default), typeof(FleetingHandler).GetMethod(nameof(AddStoredValueName1), ~BindingFlags.Default));
            //FleetingP2Handler.Setup();
            LoadedAssetsHandler.GetEnemy("Keko_EN").passiveAbilities[2].specialStoredValue = flee;
            LoadedAssetsHandler.GetEnemy("Scrungie_EN").passiveAbilities[0].specialStoredValue = flee;
            LoadedAssetsHandler.GetEnemy("GigglingMinister_EN").passiveAbilities[1].specialStoredValue = flee;
        }
    }
    public static class FleetingP2Handler
    {
        public static UnitStoredValueNames flee = UnitStoredValueNames.FleetingPA_IgnoreFirstTurn;


        public static string AddStoredValueName1(
          Func<TooltipTextHandlerSO, UnitStoredValueNames, int, string> orig,
          TooltipTextHandlerSO self,
          UnitStoredValueNames storedValue,
          int value)
        {
            Color magenta = Color.magenta;
            string str1;
            if (storedValue == flee)
            {
                if (value <= 0)
                {
                    str1 = "";
                }
                else
                {
                    string str2 = "Fleeting Count:" + string.Format(" +{0}", (object)value);
                    string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(self._positiveSTColor) + ">";
                    string str4 = "</color>";
                    str1 = str3 + str2 + str4;
                }
            }
            else
                str1 = orig(self, storedValue, value);
            return str1;
        }

        public static void Setup()
        {
            IDetour salineVale = new Hook((MethodBase)typeof(TooltipTextHandlerSO).GetMethod(nameof(TooltipTextHandlerSO.ProcessStoredValue), ~BindingFlags.Default), typeof(FleetingP2Handler).GetMethod(nameof(AddStoredValueName1), ~BindingFlags.Default));
            LoadedAssetsHandler.GetEnemy("Bronzo_Bananas_Friendly_EN").passiveAbilities[1].specialStoredValue = flee;
        }
    }


    public class AbilitySelector_Nervous : BaseAbilitySelectorSO
    {
        [Header("Special Abilities")]
        [SerializeField]
        public string lightscratches = Abili.LightScratch.name;

        public override bool UsesRarity => true;

        public override int GetNextAbilitySlotUsage(List<CombatAbility> abilities, IUnit unit)
        {
            int maxExclusive1 = 0;
            int maxExclusive2 = 0;
            List<int> intList1 = new List<int>();
            List<int> intList2 = new List<int>();
            for (int index = 0; index < abilities.Count; ++index)
            {
                if (this.ShouldBeIgnored(abilities[index], unit))
                {
                    maxExclusive2 += abilities[index].rarity.rarityValue;
                    intList2.Add(index);
                }
                else
                {
                    maxExclusive1 += abilities[index].rarity.rarityValue;
                    intList1.Add(index);
                }
            }
            int num1 = UnityEngine.Random.Range(0, maxExclusive1);
            int num2 = 0;
            foreach (int index in intList1)
            {
                num2 += abilities[index].rarity.rarityValue;
                if (num1 < num2)
                    return index;
            }
            int num3 = UnityEngine.Random.Range(0, maxExclusive2);
            int num4 = 0;
            foreach (int index in intList2)
            {
                num4 += abilities[index].rarity.rarityValue;
                if (num3 < num4)
                    return index;
            }
            return -1;
        }

        public bool ShouldBeIgnored(CombatAbility ability, IUnit unit)
        {
            string name = ability.ability._abilityName;
            return unit.GetStoredValue(UnitStoredValueNames.DemonCoreW) == 1 && name == this.lightscratches;
        }
    }

    public static class CorpseOfGospelHiring
    {
        public static void Setup()
        {
            IDetour diologo = new Hook(typeof(RunInGameData).GetMethod(nameof(RunInGameData.InitializeDialogueFunctions), ~BindingFlags.Default), typeof(CorpseOfGospelHiring).GetMethod(nameof(InitializeDialogueFunctions), ~BindingFlags.Default));
            UnityEngine.Debug.Log("HT E HOOK SETUP YEAHHHAH");
        }
        public static RunDataSO Run;
        public static void InitializeDialogueFunctions(Action<RunInGameData, DialogueRunner, IRunDialogueData> orig, RunInGameData self, DialogueRunner dialogueRunner, IRunDialogueData runData)
        {
            orig(self, dialogueRunner, runData);
            dialogueRunner.AddCommandHandler("CorpseOfGospel", HireCorpseOfGospel);
            if (runData is RunDataSO run)
            {
                Run = run;
            }
            UnityEngine.Debug.Log("THE COMMAND SETUP YEAHHAHH");
        }
        public static void HireCorpseOfGospel(string[] info)
        {
            //if (Run == null) UnityEngine.Debug.LogError("Run is null!????");
            UnityEngine.Debug.Log("hhihih");
            CharacterSO charcater = LoadedAssetsHandler.GetCharcater("Corpse Of Gospel_CH");
            if (charcater == null || charcater.Equals(null))
            {
                UnityEngine.Debug.LogError("Jospel dead body" + " does not exists.");
                throw new NullReferenceException("JOE WARI DAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
            }

            List<int> list = new List<int>(new int[3] { 0, 1, 2 });
            int encounterLevelRank = Run.CurrentZoneDB.EncounterLevelRank;
            int index = UnityEngine.Random.Range(0, list.Count);
            list.RemoveAt(index);
            BrutalAPI.BrutalAPI.mainMenuController._informationHolder.Run.playerData.AddNewCharacter(charcater, 0, list[0], list[1]);
            NtfUtils.notifications.PostNotification(Utils.updateCharacterVisuals);
            UnityEngine.Debug.Log("GOOOOOOOOOOOOOOOOOOOOOSSSSSSSSSSSSSSSSSSSSSPPPPPPPPPPPPPPPPPPPPPPPEEEEEEEEEEEEEEEEEELLLLLLLLLLLLLLLLLLLLLLLL");
        }
    }

    public class IllusionStatePassiveAbility : BasePassiveAbilitySO
    {
        public override bool IsPassiveImmediate => false;

        public override bool DoesPassiveTrigger => true;

        public override void TriggerPassive(object sender, object args)
        {
        }

        public override void OnPassiveConnected(IUnit unit)
        {
            if (unit.GetStoredValue(UnitStoredValueNames.DemonCoreW) > 0) return;
            unit.SetStoredValue(UnitStoredValueNames.DemonCoreW, 1);
            IllusionHandler.Setup();
            if (UnityEngine.Random.Range(0, 100) < 50)
            {
                Effect[] ee = new Effect[]
                {
                    Abili.ResetDefault.effects[2]
                };
                Effect[] aa = new Effect[]
                {
                    new Effect(RootActionEffect.Create(ee), 1, null, Slots.Self)
                };
                CombatManager.Instance.AddRootAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[]
                {
                    new Effect(RootActionEffect.Create(aa), 1, null, Slots.Self)
                }), unit));
                return;
            }
            Effect[] ef = new Effect[]
            {
                Abili.SwapSupport.effects[0],
                Abili.SwapSupport.effects[1],
                Abili.SwapSupport.effects[2],
                //new Effect(ScriptableObject.CreateInstance<AddTurnCasterToTimelineEffect>(), 1, null, Slots.Self)
            };
            Effect[] af = new Effect[]
            {
                    new Effect(RootActionEffect.Create(ef), 1, null, Slots.Self)
            };
            CombatManager.Instance.AddRootAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[]
            {
                new Effect(RootActionEffect.Create(af), 1, null, Slots.Self)
            }), unit));
        }

        public override void OnPassiveDisconnected(IUnit unit)
        {
        }
    }

    public class CowardCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            CombatStats stats = CombatManager.Instance._stats;
            int amount = 0;
            if (effector.IsUnitCharacter)
            {
                foreach (CharacterCombat chara in stats.CharactersOnField.Values)
                {
                    if (chara.IsAlive && !chara.ContainsPassiveAbility(Passi.Coward.type)) amount++;
                }
            }
            else
            {
                foreach (EnemyCombat enemy in stats.EnemiesOnField.Values)
                {
                    if (enemy.IsAlive && !enemy.ContainsPassiveAbility(Passi.Coward.type)) amount++;
                }
            }
            return amount <= 0;
        }
    }
    public class CowardEffect : EffectSO
    {
        public static FleeTargetEffect flee = CreateInstance<FleeTargetEffect>();

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            if (flee == null) flee = CreateInstance<FleeTargetEffect>();
            List<int> list = new List<int>();
            List<bool> list2 = new List<bool>();
            List<string> list3 = new List<string>();
            List<Sprite> list4 = new List<Sprite>();
            List<EnemyCombat> list5 = new List<EnemyCombat>();
            foreach (EnemyCombat value in stats.EnemiesOnField.Values)
            {
                if (value.IsAlive && value.ContainsPassiveAbility(Passi.Coward.type))
                {
                    list2.Add(value.IsUnitCharacter);
                    list.Add(value.ID);
                    list3.Add(Passi.Coward._passiveName);
                    list4.Add(Passi.Coward.passiveIcon);
                    list5.Add(value);
                }
            }
            if (list5.Count >= 0)
                CombatManager.Instance.AddUIAction(new ShowMultiplePassiveInformationUIAction(list.ToArray(), list2.ToArray(), list3.ToArray(), list4.ToArray()));
            exitAmount = 0;
            foreach (EnemyCombat enemy in list5)
            {
                enemy.UnitWillFlee();
                CombatManager.Instance.AddSubAction(new FleetingUnitAction(enemy.ID, enemy.IsUnitCharacter));
                exitAmount++;
            }
            return exitAmount > 0;
        }
    }
    public class WindSongEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (caster.IsUnitCharacter)
            {
                return false;
            }

            TrySpawnWindSongEffect(stats.combatUI, caster.ID);
            return true;
        }

        public void TrySpawnWindSongEffect(CombatVisualizationController UI, int id)
        {
            if (UI._enemiesInCombat.TryGetValue(id, out var value))
            {
                TrySpawnEffectInEnemy(UI._enemyZone, value.FieldID);
            }
        }
        public void TrySpawnEffectInEnemy(EnemyZoneHandler zone, int fieldID)
        {
            SpawnEffect(zone._enemies[fieldID].FieldEntity);
        }
        public void SpawnEffect(EnemyInFieldLayout field)
        {
            //RuntimeManager.PlayOneShot(field._gibsEvent, field.Position);
            UnityEngine.Object.Instantiate(WindSong.MainEffect, field.transform.position, field.transform.rotation);
            if (CombatManager.Instance._stats.combatUI._enemiesInCombat.TryGetValue(field.EnemyID, out var value))
            {
                Quaternion randomRot = new Quaternion(field.transform.rotation.x, UnityEngine.Random.Range(0, 360), field.transform.rotation.z, field.transform.rotation.w);
                if (Hawthorne.Check.EnemyExist("WindSong_EN") && value.EnemyBase == LoadedAssetsHandler.GetEnemy("WindSong_EN") && value.CurrentHealth <= 0)
                {
                    UnityEngine.Object.Instantiate(WindSong.SideEffectOne, field.transform.position, randomRot);
                    UnityEngine.Object.Instantiate(WindSong.SideEffectTwo, field.transform.position, randomRot);
                }
            }
        }
    }
    public class WindSongEffectUIAction : CombatAction
    {
        public int _enemyID;

        public WindSongEffectUIAction(int enemyID)
        {
            _enemyID = enemyID;
        }

        public override IEnumerator Execute(CombatStats stats)
        {
            TrySpawnWindSongEffect(stats.combatUI, _enemyID);
            yield break;
        }

        public void TrySpawnWindSongEffect(CombatVisualizationController UI, int id)
        {
            if (UI._enemiesInCombat.TryGetValue(id, out var value))
            {
                TrySpawnEffectInEnemy(UI._enemyZone, value.FieldID);
            }
        }

        public void TrySpawnEffectInEnemy(EnemyZoneHandler zone, int fieldID)
        {
            SpawnEffect(zone._enemies[fieldID].FieldEntity);
        }

        public void SpawnEffect(EnemyInFieldLayout field)
        {
            //RuntimeManager.PlayOneShot(field._gibsEvent, field.Position);
            UnityEngine.Object.Instantiate(WindSong.MainEffect, field.transform.position, field.transform.rotation);
            if (CombatManager.Instance._stats.combatUI._enemiesInCombat.TryGetValue(field.EnemyID, out var value))
            {
                Quaternion randomRot = new Quaternion(field.transform.rotation.x, UnityEngine.Random.Range(0, 360), field.transform.rotation.z, field.transform.rotation.w);
                if (Hawthorne.Check.EnemyExist("WindSong_EN") && value.EnemyBase == LoadedAssetsHandler.GetEnemy("WindSong_EN") && value.CurrentHealth <= 0)
                {
                    UnityEngine.Object.Instantiate(WindSong.SideEffectOne, field.transform.position, randomRot);
                    UnityEngine.Object.Instantiate(WindSong.SideEffectTwo, field.transform.position, randomRot);
                }
            }
        }
    }

    public class CodaPerformDoubleEffectPassiveAbility : BasePassiveAbilitySO
    {
        [Header("Passive Effects")]
        public EffectInfo[] effects;

        [Header("Passive Secondary data")]
        [SerializeField]
        public TriggerCalls[] _secondTriggerOn;

        [SerializeField]
        public EffectorConditionSO[] _secondPerformConditions;

        [SerializeField]
        public bool _secondDoesPerformPopUp = true;

        [SerializeField]
        public EffectInfo[] _secondEffects;

        public override bool IsPassiveImmediate => true;

        public override bool DoesPassiveTrigger => true;

        public override void TriggerPassive(object sender, object args)
        {
            IUnit caster = sender as IUnit;
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[]
            {
                new Effect(EffectInfoSubEffect.Create(effects), 1, null, Slots.Self)
            }), caster));
        }

        public override void OnPassiveConnected(IUnit unit)
        {
        }

        public override void OnPassiveDisconnected(IUnit unit)
        {
        }

        public override void CustomOnTriggerAttached(IPassiveEffector caller)
        {
            TriggerCalls[] secondTriggerOn = _secondTriggerOn;
            for (int i = 0; i < secondTriggerOn.Length; i++)
            {
                TriggerCalls triggerCalls = secondTriggerOn[i];
                if (triggerCalls != TriggerCalls.Count)
                {
                    CombatManager.Instance.AddObserver(CustomTryTriggerPassive, triggerCalls.ToString(), caller);
                }
            }
        }

        public override void CustomOnTriggerDettached(IPassiveEffector caller)
        {
            TriggerCalls[] secondTriggerOn = _secondTriggerOn;
            for (int i = 0; i < secondTriggerOn.Length; i++)
            {
                TriggerCalls triggerCalls = secondTriggerOn[i];
                if (triggerCalls != TriggerCalls.Count)
                {
                    CombatManager.Instance.RemoveObserver(CustomTryTriggerPassive, triggerCalls.ToString(), caller);
                }
            }
        }

        public override void FinalizeCustomTriggerPassive(object sender, object args, int triggerID)
        {
            if (sender is IPassiveEffector passiveEffector && !passiveEffector.Equals(null))
            {
                if (_secondDoesPerformPopUp)
                {
                    CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(passiveEffector.ID, passiveEffector.IsUnitCharacter, GetPassiveLocData().text, passiveIcon));
                }

                IUnit caster = sender as IUnit;
                CombatManager.Instance.AddSubAction(new EffectAction(_secondEffects, caster));
            }
        }

        public void CustomTryTriggerPassive(object sender, object args)
        {
            if (!(sender is IPassiveEffector passiveEffector) || passiveEffector.Equals(null) || !passiveEffector.CanPassiveTrigger(type))
            {
                return;
            }

            if (_secondPerformConditions != null && !_secondPerformConditions.Equals(null))
            {
                EffectorConditionSO[] secondPerformConditions = _secondPerformConditions;
                for (int i = 0; i < secondPerformConditions.Length; i++)
                {
                    if (!secondPerformConditions[i].MeetCondition(passiveEffector, args))
                    {
                        return;
                    }
                }
            }

            if ((sender as IUnit).IsUnitCharacter) return;
            return;
            TrySpawnWindSongEffect(CombatManager.Instance._stats.combatUI, (sender as IUnit).ID);
        }

        public void TrySpawnWindSongEffect(CombatVisualizationController UI, int id)
        {
            if (UI._enemiesInCombat.TryGetValue(id, out var value))
            {
                TrySpawnEffectInEnemy(UI._enemyZone, value.FieldID);
            }
        }
        public void TrySpawnEffectInEnemy(EnemyZoneHandler zone, int fieldID)
        {
            SpawnEffect(zone._enemies[fieldID].FieldEntity);
        }
        public void SpawnEffect(EnemyInFieldLayout field)
        {
            //RuntimeManager.PlayOneShot(field._gibsEvent, field.Position);
            UnityEngine.Object.Instantiate(WindSong.MainEffect, field.transform.position, field.transform.rotation);
            if (CombatManager.Instance._stats.combatUI._enemiesInCombat.TryGetValue(field.EnemyID, out var value))
            {
                Quaternion randomRot = new Quaternion(field.transform.rotation.x, UnityEngine.Random.Range(0, 360), field.transform.rotation.z, field.transform.rotation.w);
                if (Hawthorne.Check.EnemyExist("WindSong_EN") && value.EnemyBase == LoadedAssetsHandler.GetEnemy("WindSong_EN") && value.CurrentHealth <= 0)
                {
                    UnityEngine.Object.Instantiate(WindSong.SideEffectOne, field.transform.position, randomRot);
                    UnityEngine.Object.Instantiate(WindSong.SideEffectTwo, field.transform.position, randomRot);
                }
            }
        }
    }

    public class EffectInfoSubEffect : EffectSO
    {
        public EffectInfo[] effects;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            EffectInfo[] info = effects;
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    CombatManager.Instance.AddSubAction(new EffectAction(info, target.Unit));
                    exitAmount++;
                }
            }
            return exitAmount > 0;
        }

        public static EffectInfoSubEffect Create(EffectInfo[] e)
        {
            EffectInfoSubEffect ret = ScriptableObject.CreateInstance<EffectInfoSubEffect>();
            ret.effects = e;
            return ret;
        }
    }

    public static class WindSongManager
    {
        public static DamageInfo Damage(Func<EnemyCombat, int, IUnit, DeathType, int, bool, bool, bool, DamageType, DamageInfo> orig, EnemyCombat self, int amount, IUnit killer, DeathType deathType, int targetSlotOffset = -1, bool addHealthMana = true, bool directDamage = true, bool ignoresShield = false, DamageType specialDamage = DamageType.None)
        {
            if (Hawthorne.Check.EnemyExist("WindSong_EN") && self.Enemy == LoadedAssetsHandler.GetEnemy("WindSong_EN"))
            {
                int num = self.SlotID;
                int num2 = self.SlotID + self.Size - 1;
                if (targetSlotOffset >= 0)
                {
                    targetSlotOffset = Mathf.Clamp(self.SlotID + targetSlotOffset, num, num2);
                    num = targetSlotOffset;
                    num2 = targetSlotOffset;
                }

                DamageReceivedValueChangeException ex = new DamageReceivedValueChangeException(amount, specialDamage, directDamage, ignoresShield, num, num2);
                CombatManager.Instance.PostNotification(TriggerCalls.OnBeingDamaged.ToString(), self, ex);
                int modifiedValue = ex.GetModifiedValue();
                if (killer != null && !killer.Equals(null))
                {
                    CombatManager.Instance.ProcessImmediateAction(new UnitDamagedImmediateAction(modifiedValue, killer.IsUnitCharacter));
                }

                int num3 = Mathf.Max(self.CurrentHealth - modifiedValue, 0);
                int num4 = self.CurrentHealth - num3;
                if (num4 != 0)
                {
                    self.CurrentHealth = num3;
                    if (specialDamage == DamageType.None)
                    {
                        specialDamage = Utils.GetBasicDamageTypeFromAmount(modifiedValue);
                    }

                    CombatManager.Instance.AddUIAction(new EnemyDamagedUIAction(self.ID, self.CurrentHealth, self.MaximumHealth, modifiedValue, specialDamage));
                    TrySpawnWindSongEffect(CombatManager.Instance._stats.combatUI, self.ID, num3 == 0);
                    if (addHealthMana)
                    {
                        CombatManager.Instance.ProcessImmediateAction(new AddManaToManaBarAction(self.HealthColor, Utils.enemyManaAmount, self.IsUnitCharacter, self.ID));
                    }

                    CombatManager.Instance.PostNotification(TriggerCalls.OnDamaged.ToString(), self, new IntegerReference(num4));
                    if (directDamage)
                    {
                        CombatManager.Instance.PostNotification(TriggerCalls.OnDirectDamaged.ToString(), self, new IntegerReference(num4));
                    }
                }
                else if (!ex.ShouldIgnoreUI)
                {
                    CombatManager.Instance.AddUIAction(new EnemyNotDamagedUIAction(self.ID));
                }

                bool flag = self.CurrentHealth == 0 && num4 != 0;
                if (flag)
                {
                    CombatManager.Instance.AddSubAction(new EnemyDeathAction(self.ID, killer, deathType));
                }

                return new DamageInfo(num4, flag);
            }
            return orig(self, amount, killer, deathType, targetSlotOffset, addHealthMana, directDamage, ignoresShield, specialDamage);
        }
        public static void TrySpawnWindSongEffect(CombatVisualizationController UI, int id, bool extra = false)
        {
            if (UI._enemiesInCombat.TryGetValue(id, out var value))
            {
                TrySpawnEffectInEnemy(UI._enemyZone, value.FieldID, extra);
            }
        }
        public static void TrySpawnEffectInEnemy(EnemyZoneHandler zone, int fieldID, bool extra)
        {
            SpawnEffect(zone._enemies[fieldID].FieldEntity, extra);
        }
        public static void SpawnEffect(EnemyInFieldLayout field, bool extra)
        {
            //RuntimeManager.PlayOneShot(field._gibsEvent, field.Position);
            UnityEngine.Object.Instantiate(WindSong.MainEffect, field.transform.position, field.transform.rotation);
            if (!extra) return;
            //Quaternion randomRot = new Quaternion(field.transform.rotation.x, UnityEngine.Random.Range(0, 360), field.transform.rotation.z, field.transform.rotation.w);
            UnityEngine.Object.Instantiate(WindSong.SideEffectOne, field.transform.position, field.transform.rotation);
            UnityEngine.Object.Instantiate(WindSong.SideEffectTwo, field.transform.position, field.transform.rotation);
        }
        public static void Setup()
        {
            IDetour hook = new Hook(typeof(EnemyCombat).GetMethod(nameof(EnemyCombat.Damage), ~BindingFlags.Default), typeof(WindSongManager).GetMethod(nameof(Damage), ~BindingFlags.Default));
        }
    }

    public class ShowBlueEssencePassiveEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(caster.ID, false, Passi.BlueEssence._passiveName, Passi.BlueEssence.passiveIcon));
            exitAmount = 0;
            return true;
        }
    }

    public static class PreservedHandler
    {
        public static int WillApplyDamage(Func<EnemyCombat, int, IUnit, int> orig, EnemyCombat self, int amount, IUnit targetUnit)
        {
            int ret = orig(self, amount, targetUnit);
            if (targetUnit.ContainsPassiveAbility(Passi.Preserved.type) && !targetUnit.IsUnitCharacter)
            {
                CombatManager.Instance.AddSubAction(new ShowPassiveInformationUIAction(targetUnit.ID, targetUnit.IsUnitCharacter, Passi.Preserved._passiveName, Passi.Preserved.passiveIcon));
                return 0;
            }
            return ret;
        }
        public static void Setup()
        {
            IDetour hook = new Hook(typeof(EnemyCombat).GetMethod(nameof(EnemyCombat.WillApplyDamage), ~BindingFlags.Default), typeof(PreservedHandler).GetMethod(nameof(WillApplyDamage), ~BindingFlags.Default));
        }
    }

    public class GeneratePigmentAllEnemies : GenerateColorManaEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (EnemyCombat enemy in CombatManager.Instance._stats.EnemiesOnField.Values)
            {
                mana = enemy.HealthColor;
                if (base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out int exi)) exitAmount += exi;
            }
            return exitAmount > 0;
        }
    }
    public class ApplyPermenantRupturedCustomEffect : EffectSO
    {

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;

            stats.statusEffectDataBase.TryGetValue(StatusEffectType.Ruptured, out var value);
            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i].HasUnit)
                {
                    Ruptured_StatusEffect ruptured_StatusEffect = new Ruptured_StatusEffect(0, 1);
                    ruptured_StatusEffect.SetEffectInformation(value);
                    if (targets[i].Unit.ContainsStatusEffect(StatusEffectType.Ruptured))
                    {
                        targets[i].Unit.ApplyStatusEffect(ruptured_StatusEffect, 0);
                    }
                    else if (targets[i].Unit.ApplyStatusEffect(ruptured_StatusEffect, 0))
                    {
                        exitAmount ++;
                    }
                }
            }

            return exitAmount > 0;
        }
    }
    public class IsPlayerTurnEffectCondition : EffectConditionSO
    {
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            return CombatManager.Instance._stats.IsPlayerTurn;
        }
    }
    public class LinkedDamageEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (caster.ContainsStatusEffect(StatusEffectType.Linked)) caster.Damage(entryVariable, null, DeathType.Linked, -1, false, false, true, DamageType.Linked);
            CombatManager.Instance.AddSubAction(new PerformLinkedEffectAction(caster, new IntegerReference(entryVariable), true));
            return true;
        }
    }
    public class GenerateRandomPigmentEffect : GenerateColorManaEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            mana = new ManaColorSO[] { Pigments.Red, Pigments.Blue, Pigments.Yellow, Pigments.Purple }.GetRandom();
            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
        }
    }
    public static class BadDogHandler
    {
        public static UnitStoredValueNames Turns => (UnitStoredValueNames)282971;
        public static bool HasBadDog(this IPassiveEffector unit)
        {
            foreach (BasePassiveAbilitySO passive in unit.PassiveAbilities) if (passive is BadDogPassiveAbility dog) { return true; }
            return false;
        }
        public static bool IsFacing(this IUnit unit)
        {
            foreach (CombatSlot slot in unit.IsUnitCharacter ? CombatManager.Instance._stats.combatSlots.EnemySlots : CombatManager.Instance._stats.combatSlots.CharacterSlots)
            {
                if (slot.SlotID >= unit.SlotID && slot.SlotID < unit.SlotID + unit.Size) if (slot.HasUnit) return true;
            }
            return false;
        }
        public static Dictionary<int, string[]> Actions;
        public static void TurnStartFunction()
        {
            Actions = new Dictionary<int, string[]>();
            Actions.Clear();
            CombatStats stats = CombatManager.Instance._stats;
            foreach (EnemyCombat enemy in stats.EnemiesOnField.Values)
            {
                enemy.SetStoredValue(Turns, 0);
                if (enemy.HasBadDog() && enemy.IsFacing())
                {
                    List<string> turns = Actions.Keys.Contains(enemy.ID) ? new List<string>(Actions[enemy.ID]) : new List<string>();
                    int amount = 0;
                    foreach (TurnInfo turn in stats.timeline.Round)
                    {
                        if (!turn.isPlayer && (turn.turnUnit == enemy || (turn.turnUnit.ID == enemy.ID && turn.turnUnit.SlotID == enemy.SlotID)))
                        {
                            if (turn.abilitySlot < enemy.AbilityCount)
                            {
                                amount++;
                                turns.Add(enemy.Abilities[turn.abilitySlot].ability._abilityName);
                            }
                            else
                            {
                                amount++;
                                turns.Add("");
                            }
                        }
                    }
                    stats.timeline.TryRemoveAllNextEnemyTurns(enemy);
                    enemy.SetStoredValue(Turns, amount);
                    if (Actions.Keys.Contains(enemy.ID)) Actions[enemy.ID] = turns.ToArray();
                    else Actions.Add(enemy.ID, turns.ToArray());
                }
            }
        }
        public static void RunCheckFunction()
        {
            CombatStats stats = CombatManager.Instance._stats;
            foreach (EnemyCombat enemy in stats.EnemiesOnField.Values)
            {
                if (enemy.HasBadDog())
                {
                    if (enemy.IsFacing())
                    {
                        List<string> turns = Actions.Keys.Contains(enemy.ID) ? new List<string>(Actions[enemy.ID]) : new List<string>();
                        int amount = 0;
                        foreach (TurnInfo turn in stats.timeline.Round)
                        {
                            if (!turn.isPlayer && (turn.turnUnit == enemy || (turn.turnUnit.ID == enemy.ID && turn.turnUnit.SlotID == enemy.SlotID)))
                            {
                                if (turn.abilitySlot < enemy.AbilityCount)
                                {
                                    amount++;
                                    turns.Add(enemy.Abilities[turn.abilitySlot].ability._abilityName);
                                }
                                else
                                {
                                    amount++;
                                    turns.Add("");
                                }
                            }
                        }
                        stats.timeline.TryRemoveAllNextEnemyTurns(enemy);
                        if (Actions.Keys.Contains(enemy.ID)) Actions[enemy.ID] = turns.ToArray();
                        else Actions.Add(enemy.ID, turns.ToArray());
                        enemy.SetStoredValue(Turns, enemy.GetStoredValue(Turns) + amount);
                    }
                    else if (enemy.GetStoredValue(Turns) > 0)
                    {
                        int num = enemy.GetStoredValue(Turns);
                        List<EnemyCombat> en = new List<EnemyCombat>();
                        List<int> turns = new List<int>();
                        
                        if (!Actions.Keys.Contains(enemy.ID))
                        {
                            try
                            {
                                stats.timeline.TryAddNewFrontExtraEnemyTurns(enemy, num);
                                enemy.SetStoredValue(Turns, 0);
                            }
                            catch
                            {
                                UnityEngine.Debug.LogError("adding front enemy turns failed, adding normally ");
                                stats.timeline.TryAddNewExtraEnemyTurns(enemy, num);
                                enemy.SetStoredValue(Turns, 0);
                            }
                        }
                        else
                        {
                            string[] array = Actions[enemy.ID];
                            //array.Reverse();
                            foreach (string name in array)
                            {
                                en.Add(enemy);
                                int add = enemy.GetLastAbilityIDFromNameUsingAbilityName(name);
                                if (add < 0) add = enemy.GetSingleAbilitySlotUsage(add);
                                turns.Add(add);
                            }
                            if (en.Count < num)
                            {
                                for (int i = en.Count; i < num && en.Count < num; i++)
                                {
                                    en.Add(enemy);
                                    turns.Add(enemy.GetSingleAbilitySlotUsage(-1));
                                }
                            }
                            List<int> newer = new List<int>();
                            for (int i = turns.Count - 1; i >= 0; i--) newer.Add(turns[i]);
                            try
                            {
                                stats.timeline.AddFrontExtraEnemyTurns(en, newer);
                                enemy.SetStoredValue(Turns, 0);
                                Actions[enemy.ID] = new string[0];
                            }
                            catch
                            {
                                UnityEngine.Debug.LogError("adding front enemy turns failed, adding normally ");
                                stats.timeline.AddExtraEnemyTurns(en, turns);
                                enemy.SetStoredValue(Turns, 0);
                                Actions[enemy.ID] = new string[0];
                            }
                        }
                    }
                }
            }
        }
        public static bool IsPlayerTurn() => CombatManager.Instance._stats.IsPlayerTurn;
    }
    public class BadDogPassiveAbility : PerformEffectPassiveAbility
    {
        
    }
    public static class GilbStensionsTwo
    {
        public static List<T> Firsten<T>(this List<T> list, T add)
        {
            List<T> newer = new List<T>() { add };
            foreach (T og in list) newer.Add(og);
            return newer;
        }
        public static void MoveToFirst(this TimelineSlotGroup self)
        {
            //Debug.Log(self + " move to first");
            self.slot.transform.SetSiblingIndex(2);
            self.intent.transform.SetSiblingIndex(2);
        }
        public static TimelineSlotGroup PrepareFrontUnusedSlot(this TimelineZoneLayout self, Sprite enemy, Sprite[] intents, Color[] intentColors)
        {
            //Debug.Log(self + " prepare front unused slot");
            if (self._unusedSlots.Count <= 0)
            {
                self.GenerateUnusedSlot();
            }

            TimelineSlotGroup timelineSlotGroup = self._unusedSlots.Dequeue();
            timelineSlotGroup.MoveToFirst();
            timelineSlotGroup.SetInformation(self._slotsInUse.Count, enemy, intents, intentColors);
            timelineSlotGroup.SetActivation(enable: true);
            self._slotsInUse = self._slotsInUse.Firsten(timelineSlotGroup);
            //self._slotsInUse.Add(timelineSlotGroup);
            self._pointerRect.SetAsLastSibling();
            return timelineSlotGroup;
        }
        public static IEnumerator AddFrontTimelineSlots(this TimelineZoneLayout self, Sprite[] turnSprites, AbilitySO[] abilities)
        {
            //Debug.Log(self + " add front timeline slots");
            int count = self._slotsInUse.Count;
            count = 0;
            for (int i = 0; i < turnSprites.Length; i++)
            {
                Sprite enemy;
                Sprite[] intents;
                Color[] spriteColors;
                if (turnSprites[i] == null)
                {
                    enemy = self._blindTimelineIcon;
                    intents = new Sprite[0];
                    spriteColors = new Color[0];
                }
                else
                {
                    enemy = turnSprites[i];
                    intents = self.IntentHandler.GenerateSpritesFromAbility(abilities[i], casterIsCharacter: false, out spriteColors);
                }

                TimelineSlotGroup timelineSlotGroup = self.PrepareFrontUnusedSlot(enemy, intents, spriteColors);
                timelineSlotGroup.SetSlotScale(grow: false);
                timelineSlotGroup.SetActivation(enable: false);
            }

            for (int j = count; j < self._slotsInUse.Count && j < turnSprites.Length; j++)
            {
                self._slotsInUse[j].GenerateTweenScale(grow: true, self._timelineMoveTime);
                self._slotsInUse[j].SetActivation(enable: true);
            }

            self.UpdateTimelineContentSize(self._slotsInUse.Count + 1);
            yield return self.UpdateTimelineBackgroundSize(self._slotsInUse.Count + 1);
        }
        public static void AddTimelineFrontTurn(this EnemyCombatUIInfo self, TurnUIInfo turn)
        {
            //Debug.Log(self + " add tiemline front turn");
            if (!turn.isSecret && turn.abilitySlotID >= 0 && turn.abilitySlotID < self.AbilityTimelineSlots.Count)
            {
                self.AbilityTimelineSlots[turn.abilitySlotID].Add(0);//turn.timeSlotID
            }
        }
        public static IEnumerator AddFrontTimelineSlots(this CombatVisualizationController self, TurnUIInfo[] enemyTurns)
        {
            //Debug.Log(self + " add front timeline slots");
            Sprite[] array = new Sprite[enemyTurns.Length];
            AbilitySO[] array2 = new AbilitySO[enemyTurns.Length];
            for (int i = 0; i < enemyTurns.Length; i++)
            {
                TurnUIInfo turnUIInfo = enemyTurns[i];
                //List<TimelineInfo> gap = new List<TimelineInfo>(self._timelineSlotInfo);
                //self._timelineSlotInfo.Clear();
                //self._timelineSlotInfo.Add(new TimelineInfo(turnUIInfo));
                //for (int b = 0; b < gap.Count; b++) self._timelineSlotInfo.Add(gap[b]);
                self._timelineSlotInfo.Add(new TimelineInfo(turnUIInfo));
                foreach (EnemyCombatUIInfo uiin in self._enemiesInCombat.Values)
                {
                    foreach (List<int> dual in uiin.AbilityTimelineSlots)
                    {
                        List<int> newer = new List<int>(dual);
                        dual.Clear();
                        foreach (int inni in newer) dual.Add(inni + 1);
                    }
                }
                EnemyCombatUIInfo enemyCombatUIInfo = self._enemiesInCombat[turnUIInfo.enemyID];
                enemyCombatUIInfo.AddTimelineFrontTurn(turnUIInfo);
                array[i] = (turnUIInfo.isSecret ? null : enemyCombatUIInfo.Portrait);
                array2[i] = enemyCombatUIInfo.Abilities[turnUIInfo.abilitySlotID].ability;
            }
            //self.ReadOutUI(self._timelineSlotInfo);
            yield return self._timeline.AddFrontTimelineSlots(array, array2);
            if (!self._isInfoFromCharacter && self._unitInfoID != -1)
            {
                self.TryUpdateEnemyIDInformation(self._unitInfoID);
            }
        }
        public static void AddFrontExtraEnemyTurns(this Timeline self, List<EnemyCombat> units, List<int> abilitySlots)
        {
            //Debug.Log(self + " add front extra enemy turns");
            TurnUIInfo[] list = new TurnUIInfo[units.Count];
            for (int i = 0; i < units.Count; i++)
            {
                if (self.Enemies.Contains(units[i]))
                {
                    TurnInfo item = new TurnInfo(units[i], abilitySlots[i], player: false);
                    List<TurnInfo> gap = new List<TurnInfo>(self.Round);
                    self.Round.Clear();
                    self.Round.Add(gap[0]);
                    self.Round.Add(item);
                    for (int w = 1; w < gap.Count; w++) self.Round.Add(gap[w]);
                    list[i] = item.GenerateTurnUIInfo(1, self.IsConfused);//units.Count - (i + 1)
                }
            }
            //ReadOutRound(self.Round);
            CombatManager.Instance.AddUIAction(new AddedSlotsFrontTimelineUIAction(list.ToArray()));
        }
        public static void TryAddNewFrontExtraEnemyTurns(this Timeline self, ITurn unit, int turnsToAdd)
        {
            //Debug.Log(self + " try add new front extra enemy turns");
            if (self.Enemies.Contains(unit))
            {
                TurnUIInfo[] list = new TurnUIInfo[turnsToAdd];
                for (int i = 0; i < turnsToAdd; i++)
                {
                    int singleAbilitySlotUsage = unit.GetSingleAbilitySlotUsage(-1);
                    TurnInfo item = new TurnInfo(unit, singleAbilitySlotUsage, player: false);
                    List<TurnInfo> gap = new List<TurnInfo>(self.Round);
                    self.Round.Clear();
                    self.Round.Add(gap[0]);
                    self.Round.Add(item);
                    for (int w = 1; w < gap.Count; w++) self.Round.Add(gap[w]);
                    list[i] = item.GenerateTurnUIInfo(1, self.IsConfused);
                }
                //ReadOutRound(self.Round);
                CombatManager.Instance.AddUIAction(new AddedSlotsFrontTimelineUIAction(list.ToArray()));
            }
        }
        public static int GetLastAbilityIDFromNameUsingAbilityName(this EnemyCombat enemy, string abilityName)
        {
            for (int num = enemy.Abilities.Count - 1; num >= 0; num--)
            {
                if (enemy.Abilities[num].ability._abilityName == abilityName)
                {
                    return num;
                }
            }

            return -1;
        }

    }
    public class AddedSlotsFrontTimelineUIAction : CombatAction
    {
        public TurnUIInfo[] _enemyTurns;

        public AddedSlotsFrontTimelineUIAction(TurnUIInfo[] enemyTurns)
        {
            _enemyTurns = enemyTurns;
        }

        public override IEnumerator Execute(CombatStats stats)
        {
            //Debug.Log("Added slots front timeline ui action");
            yield return stats.combatUI.AddFrontTimelineSlots(_enemyTurns);
        }
    }
    public class BadDogTurnStartAction : CombatAction
    {
        public override IEnumerator Execute(CombatStats stats)
        {
            BadDogHandler.TurnStartFunction();
            yield return null;
        }
    }
    public class IsWitheringDeathCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is DeathReference reffe && reffe.witheringDeath == true) return true;
            return false;
        }
    }
    public class SpawnEnemyInSlotFromEntryStringNameEffect : EffectSO
    {
        public string en;

        public bool givesExperience;

        public bool trySpawnAnywhereIfFail;

        [SerializeField]
        public SpawnType _spawnType = SpawnType.Basic;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (!Check.EnemyExist(en)) return false;
            EnemySO enemy = LoadedAssetsHandler.GetEnemy(en);
            for (int num = targets.Length - 1; num >= 0; num--)
            {
                int preferredSlot = entryVariable + targets[num].SlotID;
                CombatManager.Instance.AddSubAction(new SpawnEnemyAction(enemy, preferredSlot, givesExperience, trySpawnAnywhereIfFail, _spawnType));
            }

            exitAmount = targets.Length;
            return true;
        }
    }
    public class ChildrenPassiveAbility : BasePassiveAbilitySO
    {
        public static UnitStoredValueNames value => (UnitStoredValueNames)3838114;
        public override bool DoesPassiveTrigger => true;
        public override bool IsPassiveImmediate => false;
        public override void TriggerPassive(object sender, object args)
        {
            if (sender is EnemyCombat enemy && args is DeathReference refff)
            {
                if (CombatManager.Instance._stats.LockedPassives.Contains(PassiveAbilityTypes.Decay)) return;
                if (!CombatManager.Instance._stats.IsPlayerTurn && enemy.GetStoredValue(value) > 0) return;
                if (refff.witheringDeath) return;
                Effect[] array = new Effect[1];
                if (PageCollector.IsEnemy(enemy, "Children6_EN"))
                {
                    SpawnEnemyInSlotFromEntryStringNameEffect ef = ScriptableObject.CreateInstance<SpawnEnemyInSlotFromEntryStringNameEffect>();
                    ef.en = "Children5_EN";
                    ef.trySpawnAnywhereIfFail = true;
                    array[0] = new Effect(ef, 0, null, Slots.Self);
                }
                else if (PageCollector.IsEnemy(enemy, "Children5_EN"))
                {
                    SpawnEnemyInSlotFromEntryStringNameEffect ef = ScriptableObject.CreateInstance<SpawnEnemyInSlotFromEntryStringNameEffect>();
                    ef.en = "Children4_EN";
                    ef.trySpawnAnywhereIfFail = true;
                    array[0] = new Effect(ef, 0, null, Slots.Self);
                }
                else if (PageCollector.IsEnemy(enemy, "Children4_EN"))
                {
                    SpawnEnemyInSlotFromEntryStringNameEffect ef = ScriptableObject.CreateInstance<SpawnEnemyInSlotFromEntryStringNameEffect>();
                    ef.en = "Children3_EN";
                    ef.trySpawnAnywhereIfFail = true;
                    array[0] = new Effect(ef, 0, null, Slots.Self);
                }
                else if (PageCollector.IsEnemy(enemy, "Children3_EN"))
                {
                    SpawnEnemyInSlotFromEntryStringNameEffect ef = ScriptableObject.CreateInstance<SpawnEnemyInSlotFromEntryStringNameEffect>();
                    ef.en = "Children2_EN";
                    ef.trySpawnAnywhereIfFail = true;
                    array[0] = new Effect(ef, 0, null, Slots.Self);
                }
                else if (PageCollector.IsEnemy(enemy, "Children2_EN"))
                {
                    SpawnEnemyInSlotFromEntryStringNameEffect ef = ScriptableObject.CreateInstance<SpawnEnemyInSlotFromEntryStringNameEffect>();
                    ef.en = "Children1_EN";
                    ef.trySpawnAnywhereIfFail = true;
                    array[0] = new Effect(ef, 0, null, Slots.Self);
                }
                else if (PageCollector.IsEnemy(enemy, "Children1_EN"))
                {
                    if (UnityEngine.Random.Range(0, 100) < 90) return;
                    SpawnEnemyInSlotFromEntryStringNameEffect ef = ScriptableObject.CreateInstance<SpawnEnemyInSlotFromEntryStringNameEffect>();
                    ef.en = "Children0_EN";
                    ef.trySpawnAnywhereIfFail = true;
                    array[0] = new Effect(ef, 0, null, Slots.Self);
                }
                else if (PageCollector.IsEnemy(enemy, "Children0_EN"))
                {
                    if (UnityEngine.Random.Range(0, 100) < 99) return;
                    SpawnEnemyInSlotFromEntryStringNameEffect ef = ScriptableObject.CreateInstance<SpawnEnemyInSlotFromEntryStringNameEffect>();
                    ef.en = "ChildrenPrayer_EN";
                    ef.trySpawnAnywhereIfFail = true;
                    array[0] = new Effect(ef, 0, null, Slots.Self);
                }
                CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(enemy.ID, enemy.IsUnitCharacter, Passives.Decay.GetPassiveLocData().text, Passives.Decay.passiveIcon));
                CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(array), enemy));
            }
            else if (args is DamageReceivedValueChangeException hitBy && sender is IUnit unit)
            {
                if (!CombatManager.Instance._stats.IsPlayerTurn && !hitBy.directDamage && hitBy.amount > 500) unit.SetStoredValue(value, 1);
            }
            else if (sender is IUnit unor)
            {
                unor.SetStoredValue(value, 0);
            }
        }
        public override void OnPassiveConnected(IUnit unit)
        {
            CombatManager.Instance._stats.AddStatusEffectReductionBlockedSource();
        }
        public override void OnPassiveDisconnected(IUnit unit)
        {
            CombatManager.Instance._stats.RemoveStatusEffectReductionBlockedSource();
        }
    }
    public static class AnExtension
    {
        public static Type[] GetAllDerived(Type baze)
        {
            List<Type> typeList = new List<Type>();
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (Type type in assembly.GetTypes())
                {
                    if (baze.IsAssignableFrom(type) && !typeList.Contains(type) && type != baze)
                        typeList.Add(type);
                }
            }
            return typeList.ToArray();
        }
    }
    public class PerformRandomEffectsAmongEffects : EffectSO
    {
        public Dictionary<string, string> List;
        public bool UsePreviousExitValueForNewEntry;
        public List<EffectSO> Effects;
        public static List<PerformRandomEffectsAmongEffects> Selves = new List<PerformRandomEffectsAmongEffects>();
        public static void GO()
        {
            //foreach (PerformRandomEffectsAmongEffects self in Selves) self.Actually();
        }
        public void Setup()
        {
            //Selves.Add(this);
            Actually();
        }
        public void Actually()
        {
            if (List == null) return;
            if (Effects == null) Effects = new List<EffectSO>();
            Type[] types = AnExtension.GetAllDerived(typeof(EffectSO));
            if (DoDebugs.MiscInfo)
            {
                UnityEngine.Debug.LogWarning("WILL READ OUT TYPES NOW");
                foreach (Type t in types)
                {
                    if (t.Name.Contains("Apply")) UnityEngine.Debug.Log(t.Name);
                }
            }
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
                    if (type.Name == name)
                    {
                        test.Add(type);
                        if (List[name] == "") break;
                        else if (List[name] == type.Namespace) break;
                    }
                }
                if (test.Count > 0) { Effects.Add(ScriptableObject.CreateInstance(test[test.Count - 1]) as EffectSO); remove.Add(name); if (DoDebugs.MiscInfo) UnityEngine.Debug.Log("added " + name); }
                else if (DoDebugs.MiscInfo) UnityEngine.Debug.LogWarning(name + " not found");
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
                    EffectSO run = GrabRand();
                    if (run != null)
                    {
                        if (run.PerformEffect(stats, caster, new TargetSlotInfo[] { target }, areTargetSlots, UsePreviousExitValueForNewEntry ? PreviousExitValue : 1, out int exi))
                            exitAmount += exi;
                        effectsRan++;
                    }
                }
            }
            return effectsRan > 0;
        }
    }
    public class AbilitySelector_Satyr : BaseAbilitySelectorSO
    {
        [Header("Special Abilities")]
        [SerializeField]
        public string flavor = "Bitter Flavor";
        public string flavour = "Bitter Flavour";

        public override bool UsesRarity => true;

        public override int GetNextAbilitySlotUsage(List<CombatAbility> abilities, IUnit unit)
        {
            int maxExclusive1 = 0;
            int maxExclusive2 = 0;
            List<int> intList1 = new List<int>();
            List<int> intList2 = new List<int>();
            for (int index = 0; index < abilities.Count; ++index)
            {
                if (this.ShouldBeIgnored(abilities[index], unit))
                {
                    maxExclusive2 += abilities[index].rarity.rarityValue;
                    intList2.Add(index);
                }
                else
                {
                    maxExclusive1 += abilities[index].rarity.rarityValue;
                    intList1.Add(index);
                }
            }
            int num1 = UnityEngine.Random.Range(0, maxExclusive1);
            int num2 = 0;
            foreach (int index in intList1)
            {
                num2 += abilities[index].rarity.rarityValue;
                if (num1 < num2)
                    return index;
            }
            int num3 = UnityEngine.Random.Range(0, maxExclusive2);
            int num4 = 0;
            foreach (int index in intList2)
            {
                num4 += abilities[index].rarity.rarityValue;
                if (num3 < num4)
                    return index;
            }
            return -1;
        }

        public bool ShouldBeIgnored(CombatAbility ability, IUnit unit)
        {
            string name = ability.ability._abilityName;
            return CombatManager.Instance._stats.TurnsPassed < 2 && (name == this.flavor || name == this.flavour);
        }
    }
    public class DoubleExtraAttackPassiveAbility : ExtraAttackPassiveAbility
    {
        [Header("ExtraAttack Data")]
        [SerializeField]
        public ExtraAbilityInfo _secondExtraAbility;
        public static UnitStoredValueNames value => (UnitStoredValueNames)21007348;

        public override void TriggerPassive(object sender, object args)
        {
            if (args is List<string> list && sender is IUnit unit && unit.GetStoredValue(value) > 0)
            {
                list.Add(_secondExtraAbility.ability?.name);
                unit.SetStoredValue(value, 0);
            }
            base.TriggerPassive(sender, args);
        }

        public override void OnPassiveConnected(IUnit unit)
        {
            base.OnPassiveConnected(unit);
            unit.AddExtraAbility(_secondExtraAbility);
        }

        public override void OnPassiveDisconnected(IUnit unit)
        {
            base.OnPassiveDisconnected(unit);
            unit.TryRemoveExtraAbility(_secondExtraAbility);
        }
    }
    public class AbilitySelector_YNL : BaseAbilitySelectorSO
    {
        [Header("Special Abilities")]
        [SerializeField]
        public string replace = Abili.Replacement.name;

        public override bool UsesRarity => true;

        public override int GetNextAbilitySlotUsage(List<CombatAbility> abilities, IUnit unit)
        {
            int maxExclusive1 = 0;
            int maxExclusive2 = 0;
            List<int> intList1 = new List<int>();
            List<int> intList2 = new List<int>();
            for (int index = 0; index < abilities.Count; ++index)
            {
                if (this.ShouldBeIgnored(abilities[index], unit))
                {
                    maxExclusive2 += abilities[index].rarity.rarityValue;
                    intList2.Add(index);
                }
                else
                {
                    maxExclusive1 += abilities[index].rarity.rarityValue;
                    intList1.Add(index);
                }
            }
            int num1 = UnityEngine.Random.Range(0, maxExclusive1);
            int num2 = 0;
            foreach (int index in intList1)
            {
                num2 += abilities[index].rarity.rarityValue;
                if (num1 < num2)
                    return index;
            }
            int num3 = UnityEngine.Random.Range(0, maxExclusive2);
            int num4 = 0;
            foreach (int index in intList2)
            {
                num4 += abilities[index].rarity.rarityValue;
                if (num3 < num4)
                    return index;
            }
            return -1;
        }

        public bool ShouldBeIgnored(CombatAbility ability, IUnit unit)
        {
            string name = ability.ability._abilityName;
            return CombatManager.Instance._stats.TurnsPassed < 1 && (name == this.replace);
        }
    }
    public static class AnglerHandler
    {
        public static bool Awaken;
        public static UnitStoredValueNames value => (UnitStoredValueNames)8282494;
        public static void Check()
        {
            bool newAwake = false;
            if (!Hawthorne.Check.EnemyExist("A'Flower'_EN")) return;
            foreach (CombatSlot slot in CombatManager.Instance._stats.combatSlots.EnemySlots)
            {
                if (slot.HasUnit && slot.Unit.CurrentHealth > 0 && slot.Unit is EnemyCombat enemy && enemy.Enemy == LoadedAssetsHandler.GetEnemy("A'Flower'_EN"))
                {
                    bool Personal = false;
                    foreach (CombatSlot plot in CombatManager.Instance._stats.combatSlots.CharacterSlots)
                    {
                        if (plot.SlotID == slot.SlotID)
                        {
                            if (plot.ContainsStatusEffect(SlotStatusEffectType.Constricted) && plot.HasUnit && plot.Unit.CurrentHealth > 0)
                            {
                                newAwake = true;
                                Personal = true;
                            }
                            break;
                        }
                    }
                    if (Personal)
                    {
                        if (enemy.GetStoredValue(value) == 0)
                        {
                            CombatManager.Instance._stats.combatUI.TrySetEnemyAnimatorParameter(enemy.ID, "HasFacing", true);
                            TrySpawnSandEffect(CombatManager.Instance._stats.combatUI, enemy.ID);
                        }
                        enemy.SetStoredValue(value, 1);
                    }
                    else
                    {
                        if (enemy.GetStoredValue(value) != 0)
                        {
                            CombatManager.Instance._stats.combatUI.TrySetEnemyAnimatorParameter(enemy.ID, "HasFacing", false);
                            TrySpawnSandEffect(CombatManager.Instance._stats.combatUI, enemy.ID);
                        }
                        enemy.SetStoredValue(value, 0);
                    }
                }
            }
            if (newAwake != Awaken)
            {
                Awaken = newAwake;
                CombatManager.Instance._stats.audioController.MusicCombatEvent.setParameterByName("HasFront", Awaken ? 1 : 0);
            }
        }
        public static void NotifCheck(string notificationName, object sender, object args)
        {
            if (notificationName == TriggerCalls.OnMoved.ToString() || notificationName == TriggerCalls.OnDeath.ToString()) Check();
        }
        public static void TrySpawnSandEffect(CombatVisualizationController UI, int id)
        {
            if (UI._enemiesInCombat.TryGetValue(id, out var value))
            {
                TrySpawnEffectInEnemy(UI._enemyZone, value.FieldID);
            }
        }
        public static void TrySpawnEffectInEnemy(EnemyZoneHandler zone, int fieldID)
        {
            SpawnEffect(zone._enemies[fieldID].FieldEntity);
        }
        public static void SpawnEffect(EnemyInFieldLayout field)
        {
            //RuntimeManager.PlayOneShot(field._gibsEvent, field.Position);
            UnityEngine.Object.Instantiate(Sand, field.transform.position, field.transform.rotation);
        }
        static ParticleSystem _sand;
        public static ParticleSystem Sand
        {
            get
            {
                if (_sand == null)
                {
                    _sand = SaltEnemies.assetBundle.LoadAsset<GameObject>("Assets/Senis3/0FuckFolder/Sand.prefab").GetComponent<ParticleSystem>();
                }
                return _sand;
            }
        }
    }
    public class ChangeAnglerMusicUIAction : CombatAction
    {
        public bool Awake;
        public ChangeAnglerMusicUIAction(bool awake)
        {
            Awake = awake;
        }
        public override IEnumerator Execute(CombatStats stats)
        {
            CombatManager.Instance._stats.audioController.MusicCombatEvent.setParameterByName("HasFront", Awake ? 1 : 0);
            yield return null;
        }
    }
    public class SetAnglerAnimationParameterUIAction : CombatAction
    {
        public int _id;

        public bool _isCharacter;

        public string _parameterName;

        public bool _parameterValue;

        public SetAnglerAnimationParameterUIAction(int id, bool isCharacter, string parameterName, bool parameterValue)
        {
            _id = id;
            _isCharacter = isCharacter;
            _parameterName = parameterName;
            _parameterValue = parameterValue;
        }

        public override IEnumerator Execute(CombatStats stats)
        {
            if (_isCharacter)
            {
                stats.combatUI.TrySetCharacterAnimatorParameter(_id, _parameterName, _parameterValue);
            }
            else
            {
                stats.combatUI.TrySetEnemyAnimatorParameter(_id, _parameterName, _parameterValue);
                AnglerHandler.TrySpawnSandEffect(stats.combatUI, _id);
            }

            yield break;
        }
    }
    public class AnglerCheckEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            AnglerHandler.Check();
            return true;
        }
    }
    public static class ShuaHandler
    {
        static ParticleSystem hits;
        public static ParticleSystem Hits
        {
            get
            {
                if (hits == null)
                {
                    hits = SaltEnemies.Group4.LoadAsset<GameObject>("Assets/group4/Shua/Shua_HitEffect.prefab").GetComponent<ParticleSystem>();
                }
                return hits;
            }
        }
        public static void DamageEnemy(Action<EnemyInFieldLayout> orig, EnemyInFieldLayout self)
        {
            if (CombatManager.Instance._stats.combatUI._enemiesInCombat.TryGetValue(self.EnemyID, out var value))
            {
                if (Check.EnemyExist("Shua_EN") && value.EnemyBase == LoadedAssetsHandler.GetEnemy("Shua_EN"))
                {
                    UnityEngine.Object.Instantiate(Hits, self.transform.position, self.transform.rotation);
                }
            }
            orig(self);
        }
        public static IEnumerator PlayEnemyDeathAnimation(Func<EnemyInFieldLayout, string, IEnumerator> orig, EnemyInFieldLayout self, string deathSound)
        {
            bool IS = false;
            if (CombatManager.Instance._stats.combatUI._enemiesInCombat.TryGetValue(self.EnemyID, out var value))
            {
                if (Check.EnemyExist("BlackStar_EN") && value.EnemyBase == LoadedAssetsHandler.GetEnemy("BlackStar_EN"))
                {
                    IS = true;
                }
                else if (Check.EnemyExist("Singularity_EN") && value.EnemyBase == LoadedAssetsHandler.GetEnemy("Singularity_EN"))
                {
                    IS = true;
                }
            }
            if (!IS)
            {
                yield return orig(self, deathSound);
            }
            else
            {
                self.FinishedAnimation = false;
                self._animator.SetTrigger("Dying");
                if (deathSound != "")
                {
                    RuntimeManager.PlayOneShot(deathSound, self.Position);
                    RuntimeManager.PlayOneShot("event:/Hawthorne/Misc/RingingSound", self.Position);
                }

                float saveCounter = self.saveAnimationTime;
                while (!self.FinishedAnimation)
                {
                    yield return null;
                    saveCounter -= Time.deltaTime;
                    if (saveCounter <= 0f)
                    {
                        break;
                    }
                }

                self.FinishedAnimation = true;
            }
        }
        public static void Setup()
        {
            IDetour hook = new Hook(typeof(EnemyInFieldLayout).GetMethod(nameof(EnemyInFieldLayout.DamageEnemy), ~BindingFlags.Default), typeof(ShuaHandler).GetMethod(nameof(DamageEnemy), ~BindingFlags.Default));
            IDetour hack = new Hook(typeof(EnemyInFieldLayout).GetMethod(nameof(EnemyInFieldLayout.PlayEnemyDeathAnimation), ~BindingFlags.Default), typeof(ShuaHandler).GetMethod(nameof(PlayEnemyDeathAnimation), ~BindingFlags.Default));
        }
    }
    public class BlackHoleEffect : EffectSO
    {
        public static int Amount = 0;
        public static void Reset() => Amount = 0;
        public bool Add = true;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            bool GOING = Amount > 0;
            if (Add) Amount++;
            else Amount--;
            if ((Amount > 0) == GOING) return Amount > 0;
            if (Amount > 0)
            {
                if (changeMusic != null)
                {
                    try { changeMusic.Abort(); } catch { UnityEngine.Debug.LogWarning("black star thread failed to shut down."); }
                }
                changeMusic = new System.Threading.Thread(GO);
                changeMusic.Start();
            }
            else
            {
                if (changeMusic != null)
                {
                    try { changeMusic.Abort(); } catch { UnityEngine.Debug.LogWarning("black star thread failed to shut down."); }
                }
                changeMusic = new System.Threading.Thread(STOP);
                changeMusic.Start();
            }
            return Amount > 0;
        }

        public static System.Threading.Thread changeMusic;
        public static void GO()
        {
            int start = 0;
            if (CombatManager.Instance._stats.audioController.MusicCombatEvent.getParameterByName("BlackHole", out float num) == RESULT.OK) start = (int)num;
            //UnityEngine.Debug.Log("going: " + start);
            for (int i = start; i <= 100 && Amount > 0; i++)
            {
                CombatManager.Instance._stats.audioController.MusicCombatEvent.setParameterByName("BlackHole", i);
                System.Threading.Thread.Sleep(20);
                //if (i > 95) UnityEngine.Debug.Log("we;re getting there properly");
            }
            //UnityEngine.Debug.Log("done");
        }
        public static void STOP()
        {
            int start = 0;
            if (CombatManager.Instance._stats.audioController.MusicCombatEvent.getParameterByName("BlackHole", out float num) == RESULT.OK) start = (int)num;
            //UnityEngine.Debug.Log("going: " + start);
            for (int i = start; i >= 0 && Amount <= 0; i--)
            {
                CombatManager.Instance._stats.audioController.MusicCombatEvent.setParameterByName("BlackHole", i);
                System.Threading.Thread.Sleep(20);
                //if (i < 5) UnityEngine.Debug.Log("we;re getting there properly");
            }
            //UnityEngine.Debug.Log("done");
        }
    }
    public class HasHealthEffectCondition : EffectConditionSO
    {
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            return caster.CurrentHealth > 0;
        }
    }
    public class ShowViolentPassiveEffect : EffectSO
    {
        public Sprite image;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(caster.ID, caster.IsUnitCharacter, "Violent (" + entryVariable.ToString() + ")", image));
            return true;
        }
    }
    public class InstantiateExtraAttackPassiveAbility : ExtraAttackPassiveAbility
    {
        public Dictionary<IUnit, ExtraAbilityInfo> units;
        public override void TriggerPassive(object sender, object args)
        {
            if (args is List<string> list && units != null)
            {
                try
                {
                    if (units.TryGetValue(sender as IUnit, out var val))
                    {
                        list.Add(val.ability?.name);
                    }
                }
                catch
                {
                    UnityEngine.Debug.LogError("failed to add extra abilitu lo");
                }
            }
        }
        public override void OnPassiveConnected(IUnit unit)
        {
            try
            {
                AbilitySO abil = ScriptableObject.Instantiate(_extraAbility.ability);
                abil.intents[0].targets = ScriptableObject.Instantiate(_extraAbility.ability.intents[0].targets);
                ExtraAbilityInfo add = new ExtraAbilityInfo()
                {
                    rarity = _extraAbility.rarity,
                    cost = _extraAbility.cost,
                    ability = abil
                };
                unit.AddExtraAbility(add);
                if (units == null) units = new Dictionary<IUnit, ExtraAbilityInfo>();
                units.Add(unit, add);
            }
            catch
            {
                UnityEngine.Debug.LogError("womp womp instantiateextraattackPA failed connect");
            }
        }

        public override void OnPassiveDisconnected(IUnit unit)
        {
            try
            {
                if (units != null)
                {
                    if (units.TryGetValue(unit, out var add))
                    {
                        unit.TryRemoveExtraAbility(add);
                    }
                }
            }
            catch
            {
                UnityEngine.Debug.LogError("womp womp instantiateextraattackPA failed disconnec");
            }
        }
    }
    public static class SigilSongHandler
    {
        public static int Spectre = 0;
        public static void Check()
        {
            int news = 0;
            if (!Hawthorne.Check.EnemyExist("Sigil_EN")) return;
            foreach (EnemyCombat EN in CombatManager.Instance._stats.EnemiesOnField.Values)
            {
                if (SigilManager.GetSigilPassive(EN) != null && SigilManager.GetSigilPassive(EN)._sigil == SigilType.Spectral && EN.CurrentHealth > 0)
                {
                    news++;
                }
            }
            foreach (CharacterCombat CH in CombatManager.Instance._stats.CharactersOnField.Values)
            {
                if (SigilManager.GetSigilPassive(CH) != null && SigilManager.GetSigilPassive(CH)._sigil == SigilType.Spectral && CH.CurrentHealth > 0)
                {
                    news++;
                }
            }
            if (news != Spectre)
            {
                Spectre = news;
                CombatManager.Instance._stats.audioController.MusicCombatEvent.setParameterByName("Spectral", Spectre > 0 ? 1 : 0);
            }
        }
        public static void NotifCheck(string notificationName, object sender, object args)
        {
            if (notificationName == TriggerCalls.OnFleetingEnd.ToString() || notificationName == TriggerCalls.OnDeath.ToString()) Check();
        }
    }
    public class SigilSongCheckUIAction : CombatAction
    {
        public override IEnumerator Execute(CombatStats stats)
        {
            SigilSongHandler.Check();
            yield return null;
        }
    }
    public class SigilSongCheckEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            CombatManager.Instance.AddUIAction(new SigilSongCheckUIAction());
            return true;
        }
    }
}
