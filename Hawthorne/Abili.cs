using BrutalAPI;
using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using UnityEngine;
using static UnityEngine.UI.CanvasScaler;
using THE_DEAD;
using FMODUnity;
using PYMN4;
using System.Runtime.CompilerServices;
using static UnityEngine.GraphicsBuffer;
using JetBrains.Annotations;
using System.IO;
using System.Data.Common;
using Hawthorne.gay;
using static UnityEngine.EventSystems.EventTrigger;
using System.Collections;
using System.Linq;
using UnityEngine.UI;
using System.Threading;
using UnityEngine.Diagnostics;
using BepInEx;
using Hawthorne.NewFolder;
using Yarn;
using System.Collections.ObjectModel;
using EnemyPack.Effects;
using static Hawthorne.CustomIntentIconSystem;
using Tools;
using FMOD.Studio;
using System.Xml.Linq;
using MUtility;
using System.Net.Http.Headers;

namespace Hawthorne
{
    public static class Abili
    {
        static Ability _weep;
        public static Ability Weep
        {
            get
            {
                if (_weep == null)
                {
                    GenerateColorManaEffect blue = ScriptableObject.CreateInstance<GenerateColorManaEffect>();
                    blue.mana = Pigments.Blue;
                    _weep = new Ability()
                    {
                        name = "Weep",
                        description = "Cries harder and produces 3 Blue Pigment.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(blue , 3, IntentType.Mana_Generate, Slots.Self)
                        },
                        visuals = LoadedAssetsHandler.GetEnemyAbility("Weep_A").visuals,
                        animationTarget = Slots.Self
                    };
                }
                return _weep;
            }
        }
        static Ability _pray;
        public static Ability Pray
        {
            get
            {
                if (_pray == null)
                {
                    _pray = new Ability()
                    {
                        name = "Pray",
                        description = "Apply Favor on the Opposing Party Member and generate 3 pigment of their health color.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ApplyFavorEffect>() , 1, (IntentType)544512, Slots.Front),
                            new Effect(ScriptableObject.CreateInstance<GenerateTargetHealthManaEffect>(), 3, IntentType.Mana_Generate, Slots.Front)
                        },
                        visuals = LoadedAssetsHandler.GetCharacterAbility("Malpractice_1_A").visuals,
                        animationTarget = Slots.Front
                    };
                }
                return _pray;
            }
        }
        static Ability _drain;
        public static Ability Drain
        {
            get
            {
                if (_drain == null)
                {
                    HealEffect healPrev = ScriptableObject.CreateInstance<HealEffect>();
                    healPrev.usePreviousExitValue = true;
                    _drain = new Ability()
                    {
                        name = "Drowse",
                        description = "Deal a Little bit damage to the Left and Right party members. Heal this enemy twice the amount of damage dealt.",
                        rarity = 6,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 2, IntentType.Damage_1_2, Slots.LeftRight),
                            new Effect(healPrev, 2, IntentType.Heal_1_4, Slots.Self, BasicEffects.DidThat(true)),
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Pop"),
                        animationTarget = Slots.LeftRight
                    };
                }
                return _drain;
            }
        }
        static Ability _haunt;
        public static Ability Haunt
        {
            get
            {
                if (_haunt == null)
                {
                    _haunt = new Ability()
                    {
                        name = "Haunting",
                        description = "Apply 3 Muted to the Opposing party member. Apply Favor on this enemy.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ApplyMutedEffect>(), 3, (IntentType)846750, Slots.Front),
                            new Effect(ScriptableObject.CreateInstance<ApplyFavorEffect>(), 1, (IntentType)544512, Slots.Self)
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Claws"),
                        animationTarget = Slots.Front
                    };
                }
                return _haunt;
            }
        }
        static Ability _gnaw;
        public static Ability Gnaw
        {
            get
            {
                if (_gnaw == null)
                {
                    _gnaw = new Ability()
                    {
                        name = "Gnaw",
                        description = "Deal a Painful amount of damage to the Left and Right party members. \nThis enemy consumes 2 Pigment not of this enemy's health colour.",
                        rarity = 8,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 4, IntentType.Damage_3_6, Slots.LeftRight),
                            new Effect(ScriptableObject.CreateInstance<ConsumeRandomButCasterHealthManaEffect>(), 2, IntentType.Mana_Consume, Slots.Self)
                        },
                        visuals = LoadedAssetsHandler.GetEnemyAbility("Gnaw_A").visuals,
                        animationTarget = Slots.LeftRight
                    };
                }
                return _gnaw;
            }
        }
        static Ability _mast;
        public static Ability Mast
        {
            get
            {
                if (_mast == null)
                {
                    _mast = new Ability()
                    {
                        name = "Masticate",
                        description = "Deal a Painful amount of damage to the Left and Right party members. \nThis enemy consumes 2 Pigment not of this enemy's health colour and heals 2 heath for each Pigment consumed.",
                        rarity = 8,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 4, IntentType.Damage_3_6, Slots.LeftRight),
                            new Effect(ScriptableObject.CreateInstance<ConsumeRandomButCasterHealthManaEffect>(), 2, IntentType.Mana_Consume, Slots.Self),
                            new Effect(BasicEffects.ExitHeal, 2, IntentType.Heal_1_4, Slots.Self)
                        },
                        visuals = LoadedAssetsHandler.GetEnemyAbility("Gnaw_A").visuals,
                        animationTarget = Slots.LeftRight
                    };
                }
                return _mast;
            }
        }
        static Ability _insight;
        public static Ability Insight
        {
            get
            {
                if (_insight == null)
                {
                    GenerateRandomManaBetweenEffect random = ScriptableObject.CreateInstance<GenerateRandomManaBetweenEffect>();
                    random.possibleMana = new ManaColorSO[] { Pigments.Red, Pigments.Blue, Pigments.Yellow, Pigments.Purple };
                    _insight = new Ability()
                    {
                        name = "Divination",
                        description = "Apply Focused to this enemy. Generate 3 random pigment and apply 5 Shield to the Left and Right enemy positions.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ApplyFocusedEffect>(), 1, IntentType.Status_Focused, Slots.Self),
                            new Effect(random, 3, IntentType.Mana_Generate, Slots.Self),
                            new Effect(ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 5, IntentType.Field_Shield, Slots.Sides)
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Think"),
                        animationTarget = Slots.Self,
                    };
                }
                return _insight;
            }
        }
        static Ability _swapSupport;
        public static Ability SwapSupport
        {
            get
            {
                if (_swapSupport == null)
                {
                    RerollSwapCasterAbilitiesEffect abili = ScriptableObject.CreateInstance<RerollSwapCasterAbilitiesEffect>();
                    EnemyAbilityInfo haunt = Haunt.EnemyAbility();
                    EnemyAbilityInfo ins = Insight.EnemyAbility();
                    EnemyAbilityInfo rage = ResetDefault.EnemyAbility();
                    abili._abilitiesToSwap = new ExtraAbilityInfo[]
                    {
                        new ExtraAbilityInfo() { ability = haunt.ability, rarity = haunt.rarity },
                        new ExtraAbilityInfo() { ability = ins.ability, rarity = ins.rarity },
                        new ExtraAbilityInfo() { ability = rage.ability, rarity = rage.rarity }
                    };
                    SwapCasterPassivesEffect passi = ScriptableObject.CreateInstance<SwapCasterPassivesEffect>();
                    passi._passivesToSwap = new BasePassiveAbilitySO[]
                    {
                        Passi.FakeGutted, Passives.Skittish, Passi.Illusion, Passives.Forgetful
                    };
                    _swapSupport = new Ability()
                    {
                        name = "Lucidity",
                        description = "Swap this enemy to a Supportive State and spawn a copy of this enemy.",
                        rarity = 4,
                        effects = new Effect[]
                        {
                            new Effect(abili, 1, IntentType.Misc, Slots.Self),
                            new Effect(passi, 1, null, Slots.Self),
                            new Effect(BasicEffects.SetStoreValue(IllusionHandler.State), 2, null, Slots.Self),
                            new Effect(ScriptableObject.CreateInstance<SpawnEnemyCopySelfEffect>(), 1, IntentType.Other_Spawn, Slots.Self)
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Cube"),
                        animationTarget = Slots.Self,
                    };
                }
                return _swapSupport;
            }
        }
        static Ability _resetDefault;
        public static Ability ResetDefault
        {
            get
            {
                if (_resetDefault == null)
                {
                    _resetDefault = new Ability()
                    {
                        name = "Enrage",
                        description = "Swap this enemy to an Offense State and spawn a copy of this enemy.",
                        rarity = 1,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ResetCasterAbilitiesToDefaultEffect>(), 1, IntentType.Misc, Slots.Self),
                            new Effect(ScriptableObject.CreateInstance<ResetCasterPassivesToDefaultEffect>(), 1, null, Slots.Self),
                            new Effect(BasicEffects.SetStoreValue(IllusionHandler.State), 1, null, Slots.Self),
                            new Effect(ScriptableObject.CreateInstance<SpawnEnemyCopySelfEffect>(), 1, IntentType.Other_Spawn, Slots.Self)
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Notif"),
                        animationTarget = Slots.Self,
                    };
                }
                return _resetDefault;
            }
        }
        static Ability _aroma;
        public static Ability Aroma
        {
            get
            {
                if (_aroma == null)
                {
                    TargettingUnitsEitherSide left = ScriptableObject.CreateInstance<TargettingUnitsEitherSide>();
                    left.right = false;
                    left.getAllies = true;
                    TargettingUnitsEitherSide right = ScriptableObject.CreateInstance<TargettingUnitsEitherSide>();
                    right.right = true;
                    right.getAllies = true;
                    SwapToOneSideEffect goLeft = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
                    goLeft._swapRight = false;
                    SwapToOneSideEffect goRight = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
                    goRight._swapRight = true;
                    _aroma = new Ability()
                    {
                        name = "Aroma",
                        description = "Move the Left and Right party members closer to this enemy. \nIf the Opposing position has Roots, deal a Painful amount of damage to the Opposing party member. \nApply 3 Roots to the Opposing position.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(BasicEffects.GoRight, 1, IntentType.Swap_Right, Slots.Left),
                            new Effect(BasicEffects.GoLeft, 1, IntentType.Swap_Left, Slots.Right),
                            new Effect(CasterRootActionEffect.Create(new Effect[]
                            {
                                new Effect(BasicEffects.GetVisuals("Thorns_1_A", true, Slots.Front), 1, null, Slots.Front),
                                new Effect(ScriptableObject.CreateInstance<IfRootsDamageEffect>(), 5, IntentType.Damage_3_6, Slots.Front),
                                new Effect(ScriptableObject.CreateInstance<ApplyRootsSlotEffect>(), 3, GetIntent("Roots"), Slots.Front)
                            }), 1, IntentType.Damage_3_6, Slots.Front),
                            new Effect(BasicEffects.Empty, 1, GetIntent("Roots"), Slots.Front)
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Rose"),
                        animationTarget = Slots.Self
                    };
                }
                return _aroma;
            }
        }
        static Ability _photosynthesize;
        public static Ability Photosynthesize
        {
            get
            {
                if (_photosynthesize == null)
                {
                    HealEffect prevExit = ScriptableObject.CreateInstance<HealEffect>();
                    prevExit.usePreviousExitValue = true;
                    _photosynthesize = new Ability()
                    {
                        name = "Photosynthesize",
                        description = "Consume all Pigment of this enemy's health color and apply double the amount of Pigment consumed as Roots, distributed among all occupied party member positions. \nApply 1 Photosynthesis to this enemy. \nThis ability cannot be selected if there is no Pigment of this enemy's health color in the tray, and must be selected if there is over 5 Pigment of the health color.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ConsumeAllCasterHealthManaEffect>(), 1, IntentType.Mana_Consume, Slots.Self),
                            new Effect(ScriptableObject.CreateInstance<DistributeRootsEffect>(), 1, GetIntent("Roots"), Targetting.AllEnemy),
                            new Effect(ScriptableObject.CreateInstance<ApplyPhotoSynthesisEffect>(), 1, GetIntent("Photo"), Slots.Self)
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Sprout"),
                        animationTarget = Slots.Self
                    };
                }
                return _photosynthesize;
            }
        }
        static Ability _love4U;
        public static Ability Love4U
        {
            get
            {
                if (_love4U == null)
                {
                    _love4U = new Ability()
                    {
                        name = "Love for You",
                        description = "Apply 4 Power on the Opposing party member. Apply 20 Shield to this enemy's position, and 5 to it's left and right. \nApply 1 Photosynthesis to this enemy.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ApplyPowerEffect>(), 4, (IntentType)987895, Slots.Front),
                            new Effect(ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 20, IntentType.Field_Shield, Slots.Self),
                            new Effect(ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 5, IntentType.Field_Shield, Slots.Sides),
                            new Effect(ScriptableObject.CreateInstance<ApplyPhotoSynthesisEffect>(), 1, GetIntent("Photo"), Slots.Self)
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Snap"),
                        animationTarget = Slots.Front
                    };
                }
                return _love4U;
            }
        }
        static Ability _cry4U;
        public static Ability Cry4U
        {
            get
            {
                if (_cry4U == null)
                {
                    ChangeHealthColorByCasterColorEffect allBlue = ScriptableObject.CreateInstance<ChangeHealthColorByCasterColorEffect>();
                    Targetting_ByUnit_Side allAlly = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
                    allAlly.getAllUnitSlots = false;
                    allAlly.getAllies = true;
                    allAlly.ignoreCastSlot = true;
                    _cry4U = new Ability()
                    {
                        name = "Cry for You",
                        description = "Heal the Opposing party member 3 health. Attempt to change the closest Left and Right enemies' health color to Blue and heal them a Moderate amount of health. \nApply 1 Photosynthesis to this enemy.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<HealEffect>(), 3, IntentType.Heal_1_4, Slots.Front),
                            new Effect(allBlue, 1, IntentType.Mana_Randomize, Targetting.Closer(true, true)),
                            new Effect(ScriptableObject.CreateInstance<HealEffect>(), 5, IntentType.Heal_5_10, Targetting.Closer(true, true)),
                            new Effect(ScriptableObject.CreateInstance<ApplyPhotoSynthesisEffect>(), 1, GetIntent("Photo"), Slots.Self)
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Rain"),
                        animationTarget = MultiTargetting.Create(Slots.Front, Targetting.Closer(true, true))
                    };
                }
                return _cry4U;
            }
        }
        static Ability _smile4U;
        public static Ability Smile4U
        {
            get
            {
                if (_smile4U == null)
                {
                    TargettingRandomUnit randoEnemy = ScriptableObject.CreateInstance<TargettingRandomUnit>();
                    randoEnemy.getAllies = false;
                    Targetting_ByUnit_Side allEnemy = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
                    allEnemy.getAllies = false;
                    allEnemy.getAllUnitSlots = false;
                    _smile4U = new Ability()
                    {
                        name = "Smile for You",
                        description = "Apply Spotlight on the Opposing party member. Apply 1 Stunned to a random party member. \nApply 1 Photosynthesis to this enemy.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ApplySpotlightEffect>(), 1, IntentType.Status_Spotlight, Slots.Front),
                            new Effect(ScriptableObject.CreateInstance<ApplyStunnedEffect>(), 1, null, randoEnemy),
                            new Effect(ScriptableObject.CreateInstance<ExitValueSetterEffect>(), 1, (IntentType)988896, allEnemy),
                            new Effect(ScriptableObject.CreateInstance<ApplyPhotoSynthesisEffect>(), 1, GetIntent("Photo"), Slots.Self)
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Smile"),
                        animationTarget = Slots.Front
                    };
                }
                return _smile4U;
            }
        }
        static Ability _lie4U;
        public static Ability Lie4U
        {
            get
            {
                if (_lie4U == null)
                {
                    AddPassiveEffect confuse = ScriptableObject.CreateInstance<AddPassiveEffect>();
                    confuse._passiveToAdd = Passives.Confusion;
                    PreviousEffectCondition didThat = ScriptableObject.CreateInstance<PreviousEffectCondition>();
                    didThat.wasSuccessful = true;
                    _lie4U = new Ability()
                    {
                        name = "Lie for You",
                        description = "Apply Confusion as a passive on the Opposing party member. If Confusion was applied, apply 12 Shield to all party member positions, otherwise, produce 4 Purple Pigment. \nApply 1 Photosynthesis to this enemy.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(confuse, 1, IntentType.Misc_Hidden, Slots.Front),
                            new Effect(ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 12, IntentType.Field_Shield, Slots.SlotTarget(new int[]{-4, -3, -2, -1, 0, 1, 2, 3, 4 }, false), didThat),
                            new Effect(BasicEffects.GenPigment(Pigments.Purple), 4, IntentType.Mana_Generate, Slots.Self, BasicEffects.DidThat(false, 2)),
                            new Effect(ScriptableObject.CreateInstance<ApplyPhotoSynthesisEffect>(), 1, GetIntent("Photo"), Slots.Self)
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Whisper"),
                        animationTarget = Slots.Front
                    };
                }
                return _lie4U;
            }
        }
        static Ability _die4U;
        public static Ability Die4U
        {
            get
            {
                if (_die4U == null)
                {
                    GenerateRandomManaBetweenEffect allpig = ScriptableObject.CreateInstance<GenerateRandomManaBetweenEffect>();
                    allpig.possibleMana = new ManaColorSO[] { Pigments.Red, Pigments.Blue, Pigments.Yellow, Pigments.Purple, Pigments.Red, Pigments.Blue, Pigments.Yellow, Pigments.Purple, Pigments.Red, Pigments.Blue, Pigments.Yellow, 
                        Pigments.Purple, Pigments.Red, Pigments.Blue, Pigments.Yellow, Pigments.Purple, Pigments.Red, Pigments.Blue, Pigments.Yellow, Pigments.Purple, Pigments.Red, Pigments.Blue, Pigments.Yellow, Pigments.Purple, Pigments.Green, 
                        Pigments.Red, Pigments.Blue, Pigments.Yellow, Pigments.Purple, Pigments.Red, Pigments.Blue, Pigments.Yellow, Pigments.Purple, Pigments.Red, Pigments.Blue, Pigments.Yellow, Pigments.Purple, Pigments.Red, Pigments.Blue, 
                        Pigments.Yellow, Pigments.Purple, Pigments.Red, Pigments.Blue, Pigments.Yellow, Pigments.Purple, Pigments.Red, Pigments.Blue, Pigments.Yellow, Pigments.Purple, Pigments.Red, Pigments.Blue, Pigments.Yellow, Pigments.Purple, };
                    RandomizeAllManaEffect alltray = ScriptableObject.CreateInstance<RandomizeAllManaEffect>();
                    alltray.manaRandomOptions = new ManaColorSO[] { Pigments.Gray };
                    RandomizeAllOverflowEffect allflow = ScriptableObject.CreateInstance<RandomizeAllOverflowEffect>();
                    allflow.manaRandomOptions = new ManaColorSO[] { Pigments.Gray };
                    _die4U = new Ability()
                    {
                        name = "Die for You",
                        description = "Deal a Lethal amount of damage to this enemy and generate 12 random pigment. Turn all pigment in the tray and in overflow grey. \nApply 1 Photosynthesis to this enemy.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 16, IntentType.Damage_16_20, Slots.Self),
                            new Effect(allpig, 12, IntentType.Mana_Generate, Slots.Self),
                            new Effect(RootActionEffect.Create(new Effect[]
                            {
                                new Effect(alltray, 1, IntentType.Mana_Randomize, Slots.Self),
                                new Effect(allflow, 1, null, Slots.Self),
                            }), 1, IntentType.Mana_Randomize, Slots.Self),
                            new Effect(ScriptableObject.CreateInstance<ApplyPhotoSynthesisEffect>(), 1, GetIntent("Photo"), Slots.Self)
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Hung"),
                        animationTarget = Slots.Self
                    };
                }
                return _die4U;
            }
        }
        static Ability _struggle;
        public static Ability Struggle
        {
            get
            {
                if (_struggle == null)
                {
                    _struggle = new Ability()
                    {
                        name = "Struggle",
                        description = "Clumsily deals a Little damage to this enemy.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 2, IntentType.Damage_1_2, Slots.Self)
                        },
                        visuals = LoadedAssetsHandler.GetEnemyAbility("Struggle_A").visuals,
                        animationTarget = Slots.Self
                    };
                }
                return _struggle;
            }
        }
        static Ability _bloodletting;
        public static Ability Bloodletting
        {
            get
            {
                if (_bloodletting == null)
                {
                    _bloodletting = new Ability()
                    {
                        name = "Bloodletting",
                        description = "Clumsily deals a Little damage and inflict 1 Ruptured to this enemy.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 2, IntentType.Damage_1_2, Slots.Self),
                            new Effect(ScriptableObject.CreateInstance<FakeOneRupturedEffect>(), 2, IntentType.Status_Ruptured, Slots.Self)
                        },
                        visuals = LoadedAssetsHandler.GetEnemyAbility("Struggle_A").visuals,
                        animationTarget = Slots.Self
                    };
                }
                return _bloodletting;
            }
        }
        static Ability _runaway;
        public static Ability Runaway
        {
            get
            {
                if (_runaway == null)
                {
                    IsFrontTargetCondition front = ScriptableObject.CreateInstance<IsFrontTargetCondition>();
                    front.returnTrue = true;
                    _runaway = new Ability()
                    {
                        name = "Runaway",
                        description = "Move to the Left or Right. If there is an Opposing party member, inflict one Frail to this enemy then move Left or Right again.",
                        rarity = 5,
                        priority = 3,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, IntentType.Swap_Sides, Slots.Self),
                            new Effect(CasterSubActionEffect.Create(new Effect[]
                            {
                                new Effect(BasicEffects.PlaySound(LoadedAssetsHandler.GetEnemyAbility("Weep_A").visuals.audioReference), 1, IntentType.Misc_Hidden, Slots.Self),
                                new Effect(ScriptableObject.CreateInstance<FakeOneFrailEffect>(), 2, IntentType.Status_Frail, Slots.Self),
                                new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, IntentType.Swap_Sides, Slots.Self)
                            }), 1, IntentType.Misc_Hidden, Slots.Front, front),
                            new Effect(BasicEffects.Empty, 1, IntentType.Status_Frail, Slots.Self),
                            new Effect(BasicEffects.Empty, 1, IntentType.Swap_Sides, Slots.Self)
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Door"),
                        animationTarget = Slots.Self
                    };
                }
                return _runaway;
            }
        }
        static Ability _camouflage;
        public static Ability Camouflage
        {
            get
            {
                if (_camouflage == null)
                {
                    _camouflage = new Ability()
                    {
                        name = "Camouflage",
                        description = "Copy the Status Effects from the Left and Right enemies onto this enemy.",
                        rarity = 5,
                        priority = -3,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<CopyStatusOntoCasterEffect>(), 1, IntentType.Misc_Hidden, Slots.Sides),
                            new Effect(BasicEffects.Empty, 1, IntentType.Misc, Slots.Self)
                        },
                        visuals = LoadedAssetsHandler.GetCharacterAbility("Entwined_1_A").visuals,
                        animationTarget = Slots.SlotTarget(new int[] { -1, 0, 1 }, true)
                    };
                }
                return _camouflage;
            }
        }
        static Ability _indluge;
        public static Ability Indluge
        {
            get
            {
                if (_indluge == null)
                {
                    _indluge = new Ability()
                    {
                        name = "Indulgence",
                        description = "Deals a little Shield-Ignoring damage to the Left and Right enemies.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(BasicEffects.ShieldPierce, 2, IntentType.Damage_1_2, Slots.Sides)
                        },
                        visuals = LoadedAssetsHandler.GetEnemyAbility("Indulgence_A").visuals,
                        animationTarget = Slots.Sides
                    };
                }
                return _indluge;
            }
        }
        static Ability _agony;
        public static Ability Agony
        {
            get
            {
                if (_agony == null)
                {
                    _agony = new Ability()
                    {
                        name = "Blissful Agony",
                        description = "Clumsily deals a Little Shield-Ignoring damage to this enemy. Inflicts 1 Scar to this enemy.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(BasicEffects.ShieldPierce, 2, IntentType.Damage_1_2, Slots.Self),
                            new Effect(ScriptableObject.CreateInstance<ApplyScarsEffect>(), 1, IntentType.Status_Scars, Slots.Self)
                        },
                        visuals = LoadedAssetsHandler.GetEnemyAbility("BlissfulAgony_A").visuals,
                        animationTarget = Slots.Self
                    };
                }
                return _agony;
            }
        }
        static Ability _terrify;
        public static Ability Terrify
        {
            get
            {
                if (_terrify == null)
                {
                    GenerateColorManaEffect purp = ScriptableObject.CreateInstance<GenerateColorManaEffect>();
                    purp.mana = Pigments.Purple;
                    _terrify = new Ability()
                    {
                        name = "Terrify",
                        description = "Produce 1 Purple pigment out of fear.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(purp, 1, IntentType.Mana_Generate, Slots.Self)
                        },
                        visuals = LoadedAssetsHandler.GetEnemyAbility("Weep_A").visuals,
                        animationTarget = Slots.Self
                    };
                }
                return _terrify;
            }
        }
        static Ability _throttle;
        public static Ability Throttle
        {
            get
            {
                if (_throttle == null)
                {
                    DamageEffect OnKill = ScriptableObject.CreateInstance<DamageEffect>();
                    OnKill._returnKillAsSuccess = true;
                    _throttle = new Ability()
                    {
                        name = "Throttle",
                        description = "Deal a Deadly amount of damage to the Opposing party member and heals them a moderate amount of health. If this attack kills, it doesn't, and applies Focused and Cursed on them.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(OnKill, 13, IntentType.Damage_11_15, Slots.Front),
                            new Effect(ScriptableObject.CreateInstance<WindSongEffect>(), 1, null, Slots.Front),
                            new Effect(ScriptableObject.CreateInstance<HealEffect>(), 5, IntentType.Heal_5_10, Slots.Front),
                            new Effect(ScriptableObject.CreateInstance<ApplyFocusedEffect>(), 1, IntentType.Status_Focused, Slots.Front, BasicEffects.DidThat(true, 3)),
                            new Effect(ScriptableObject.CreateInstance<ApplyCursedEffect>(), 1, IntentType.Status_Cursed, Slots.Front, BasicEffects.DidThat(true, 4))
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Piano"),
                        animationTarget = Slots.Front
                    };
                }
                return _throttle;
            }
        }
        static Ability _coda;
        public static Ability Coda
        {
            get
            {
                if (_coda == null)
                {
                    new CustomIntentInfo("Coda", (IntentType)1020201, ResourceLoader.LoadSprite("intentcoda.png"), IntentType.Damage_Death, true);
                    _coda = new Ability()
                    {
                        name = "Coda",
                        description = "The closing is near.",
                        rarity = 999,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<DirectDeathEffect>(), 1, CustomIntentIconSystem.GetIntent("Coda"), Slots.Self),
                            new Effect(ScriptableObject.CreateInstance<WindSongEffect>(), 1, null, Slots.Self)
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Coda"),
                        animationTarget = Slots.Self
                    };
                }
                return _coda;
            }
        }
        static Ability _defense;
        public static Ability Defense
        {
            get
            {
                if (_defense == null)
                {
                    Targetting_ByUnit_Side allAlly = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
                    allAlly.getAllies = true;
                    allAlly.getAllUnitSlots = false;
                    CasterStoredValueSetEffect sigil = ScriptableObject.CreateInstance<CasterStoredValueSetEffect>();
                    sigil._valueName = SigilManager.Sigil;
                    new CustomIntentInfo("DefTxt", (IntentType)7736012, ResourceLoader.LoadSprite("defenseicon.png"), IntentType.Field_Shield);
                    new CustomIntentInfo("UpArrow", (IntentType)7736282, ResourceLoader.LoadSprite("blueUpIcon.png"), IntentType.Misc);
                    new CustomIntentInfo("DownArrow", (IntentType)12556780, ResourceLoader.LoadSprite("downicon.png"), IntentType.Misc);
                    _defense = new Ability()
                    {
                        name = "Defensive Sigil",
                        description = "All enemies will take 50% less direct damage this turn, until this enemy's next turn.",
                        rarity = 10,
                        effects = new Effect[]
                        {
                            new Effect(sigil, 1, CustomIntentIconSystem.GetIntent("DefTxt"), allAlly),
                            new Effect(BasicEffects.Empty, 1, CustomIntentIconSystem.GetIntent("UpArrow"), allAlly)
                        },
                        visuals = LoadedAssetsHandler.GetCharacterAbility("Resolve_1_A").visuals,
                        animationTarget = allAlly,
                    };
                }
                return _defense;
            }
        }
        static Ability _offense;
        public static Ability Offense
        {
            get
            {
                if (_offense == null)
                {
                    new CustomIntentInfo("AtkTxt", (IntentType)77399012, ResourceLoader.LoadSprite("atkicon.png"), IntentType.Field_Shield);
                    new CustomIntentInfo("OtherUpAlt", (IntentType)3821282, ResourceLoader.LoadSprite("upicon.png"), IntentType.Misc);
                    Targetting_ByUnit_Side allAlly = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
                    allAlly.getAllies = true;
                    allAlly.getAllUnitSlots = false;
                    CasterStoredValueSetEffect sigil = ScriptableObject.CreateInstance<CasterStoredValueSetEffect>();
                    sigil._valueName = SigilManager.Sigil;
                    _offense = new Ability()
                    {
                        name = "Offensive Sigil",
                        description = "All enemies will deal 3 more damage this turn, until this enemy's next turn.",
                        rarity = 10,
                        effects = new Effect[]
                        {
                            new Effect(sigil, 2, CustomIntentIconSystem.GetIntent("AtkTxt"), allAlly),
                            new Effect(BasicEffects.Empty, 1, CustomIntentIconSystem.GetIntent("OtherUpAlt"), allAlly)
                        },
                        visuals = LoadedAssetsHandler.GetCharacterAbility("Wrath_1_A").visuals,
                        animationTarget = allAlly,
                    };
                }
                return _offense;
            }
        }
        static Ability _spectral;
        public static Ability Spectral
        {
            get
            {
                if (_spectral == null)
                {
                    new CustomIntentInfo("Spectral", (IntentType)2262680, ResourceLoader.LoadSprite("spectralicon.png"), IntentType.Status_Cursed);
                    CasterStoredValueSetEffect sigil = ScriptableObject.CreateInstance<CasterStoredValueSetEffect>();
                    sigil._valueName = SigilManager.Sigil;
                    _spectral = new Ability()
                    {
                        name = "Spectral Sigil",
                        description = "This enemy is immune to damage until its next turn.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(sigil, 3, CustomIntentIconSystem.GetIntent("Spectral"), Slots.Self)
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Pop"),
                        animationTarget = Slots.Self,
                    };
                }
                return _spectral;
            }
        }
        static Ability _pure;
        public static Ability Pure
        {
            get
            {
                
                if (_pure == null)
                {
                    CasterStoredValueSetEffect sigil = ScriptableObject.CreateInstance<CasterStoredValueSetEffect>();
                    sigil._valueName = SigilManager.Sigil;
                    _pure = new Ability()
                    {
                        name = "Pure Sigil",
                        description = "This enemy does nothing.",
                        rarity = 1,
                        effects = new Effect[]
                        {
                            new Effect(sigil, 4, IntentType.Misc, Slots.Self)
                        },
                        visuals = null,
                        animationTarget = Slots.Self,
                    };
                }
                return _pure;
            }
        }
        static Ability _bloat;
        public static Ability Bloat
        {
            get
            {
                if (_bloat == null)
                {
                    _bloat = new Ability()
                    {
                        name = "Bloat",
                        description = "Apply 10 Shield and 2 Fire to this enemy's position.",
                        rarity = 10,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 10, IntentType.Field_Shield, Targetting.AllSelfSlots),
                            new Effect(ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), 2, IntentType.Field_Fire, Targetting.AllSelfSlots)
                        },
                        visuals = LoadedAssetsHandler.GetCharacterAbility("Entrenched_1_A").visuals,
                        animationTarget = Targetting.AllSelfSlots,
                    };
                }
                return _bloat;
            }
        }
        static Ability _gross;
        public static Ability Gross
        {
            get
            {
                if (_gross == null)
                {
                    _gross = new Ability()
                    {
                        name = "Gross",
                        description = "Deal an Agonizing amount of damage and apply 1 Fire to the left and right party member positions.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 7, IntentType.Damage_7_10, Slots.LeftRight),
                            new Effect(ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), 1, IntentType.Field_Fire, Slots.LeftRight)
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Cannon"),
                        animationTarget = Slots.LeftRight,
                    };
                }
                return _gross;
            }
        }
        static Ability _coarse;
        public static Ability Coarse
        {
            get
            {
                if (_coarse == null)
                {
                    DamageEffect ignore = ScriptableObject.CreateInstance<DamageEffect>();
                    ignore._ignoreShield = true;
                    Targetting_ByUnit_Side allEnemy = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
                    allEnemy.getAllies = false;
                    allEnemy.getAllUnitSlots = false;
                    _coarse = new Ability()
                    {
                        name = "Coarse",
                        description = "Deal a Painful amount of Shield-Piercing damage to this enemy. Apply 6 Oil-Slicked on all party members.",
                        rarity = 1,
                        effects = new Effect[]
                        {
                            new Effect(ignore, 6, IntentType.Damage_3_6, Slots.Self),
                            new Effect(ScriptableObject.CreateInstance<ApplyOilSlickedEffect>(), 6, IntentType.Status_OilSlicked, allEnemy)
                        },
                        visuals = LoadedAssetsHandler.GetEnemyAbility("Flood_A").visuals,
                        animationTarget = Slots.Self,
                    };
                }
                return _coarse;
            }
        }
        static Ability _cripple;
        public static Ability Cripple
        {
            get
            {
                if (_cripple == null)
                {
                    TargettingByHealthUnits lowest = ScriptableObject.CreateInstance<TargettingByHealthUnits>();
                    lowest.Lowest = true;
                    lowest.getAllies = false;
                    _cripple = new Ability()
                    {
                        name = "Cripple",
                        description = "Inflict 3 Frail and 1 Scar on the lowest health party member.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ApplyFrailEffect>(), 3, IntentType.Status_Frail, lowest),
                            new Effect(ScriptableObject.CreateInstance<ApplyScarsEffect>(), 1, IntentType.Status_Scars, lowest)
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Needle"),
                        animationTarget = lowest,
                    };
                }
                return _cripple;
            }
        }
        static Ability _crucify;
        public static Ability Crucify
        {
            get
            {
                if (_crucify == null)
                {
                    TargettingByHealthUnits highest = ScriptableObject.CreateInstance<TargettingByHealthUnits>();
                    highest.Lowest = false;
                    highest.getAllies = false;
                    _crucify = new Ability()
                    {
                        name = "Crucify",
                        description = "Inflict 4 Ruptured on the highest health party member.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 4, IntentType.Status_Ruptured, highest),
                        },
                        visuals = LoadedAssetsHandler.GetEnemyAbility("RapturousReverberation_A").visuals,
                        animationTarget = highest,
                    };
                }
                return _crucify;
            }
        }
        static Ability _cracking;
        public static Ability Cracking
        {
            get
            {
                if (_cracking == null)
                {
                    Targetting_ByUnit_Side allEnemy = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
                    allEnemy.getAllies = false;
                    allEnemy.getAllUnitSlots = false;
                    _cracking = new Ability()
                    {
                        name = "Cracking",
                        description = "Start a 150 second timer. If this enemy is still alive at the end of the timer, apply 12 Entropy on a random party member.",
                        rarity = 10,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<CrackingEffect>(), 12, (IntentType)846747, allEnemy),
                        },
                        visuals = LoadedAssetsHandler.GetCharacterAbility("Wrath_1_A").visuals,
                        animationTarget = Slots.Self,
                    };
                }
                return _cracking;
            }
        }
        static Ability _deepBreaths;
        public static Ability DeepBreaths
        {
            get
            {
                if (_deepBreaths == null)
                {
                    _deepBreaths = new Ability()
                    {
                        name = "Deep Breaths",
                        description = "Apply 4 Shield to this enemy's positions. Inflict 2-3 Scars on this enemy.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 4, IntentType.Field_Shield, Targetting.AllSelfSlots),
                            new Effect(ScriptableObject.CreateInstance<ApplyScarsEffect>(), 2, IntentType.Status_Scars, Slots.Self),
                            new Effect(ScriptableObject.CreateInstance<ApplyScarsEffect>(), 1, null, Slots.Self, Conditions.Chance(50))
                        },
                        visuals = LoadedAssetsHandler.GetCharacterAbility("Entrenched_1_A").visuals,
                        animationTarget = Targetting.AllSelfSlots,
                    };
                }
                return _deepBreaths;
            }
        }
        static Ability _hurdle;
        public static Ability Hurdle
        {
            get
            {
                if (_hurdle == null)
                {
                    _hurdle = new Ability()
                    {
                        name = "Hurdle",
                        description = "Deal a Painful amount of damage to the Opposing party members. Move this enemy to the Left or Right.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 6, IntentType.Damage_3_6, Slots.Front),
                            new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, IntentType.Swap_Sides, Slots.Self),
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Crush"),
                        animationTarget = Slots.Front,
                    };
                }
                return _hurdle;
            }
        }
        static Ability _disembowel;
        public static Ability Disembowel
        {
            get
            {
                if (_disembowel == null)
                {
                    _disembowel = new Ability()
                    {
                        name = "Disemboweling",
                        description = "Apply 6 Shield to the Left and Right enemy positions. Inflict 3 Ruptured on this enemy.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 6, IntentType.Field_Shield, Slots.Sides),
                            new Effect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 3, IntentType.Status_Ruptured, Slots.Self),
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Shatter"),
                        animationTarget = Targetting.AllSelfSlots,
                    };
                }
                return _disembowel;
            }
        }
        static Ability _crush;
        public static Ability Crush
        {
            get
            {
                if (_crush == null)
                {
                    _crush = new Ability()
                    {
                        name = "Crush",
                        description = "Deals a Painful amount of damage to the Opposing party members.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 5, IntentType.Damage_3_6, Slots.Front),
                        },
                        visuals = LoadedAssetsHandler.GetEnemyAbility("Crush_A").visuals,
                        animationTarget = Slots.Front,
                    };
                }
                return _crush;
            }
        }
        static Ability _sink;
        public static Ability Sink
        {
            get
            {
                if (_sink == null)
                {
                    _sink = new Ability()
                    {
                        name = "Sink",
                        description = "Apply 1 Constricted to the position of the lowest health party member(s) and move all enemies towards that party member(s).",
                        rarity = 8,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ApplyConstrictedSlotEffect>(), 1, IntentType.Field_Constricted, Targetting.LowestEnemy),
                            new Effect(ScriptableObject.CreateInstance<SinkMovementEffect>(), 1, null, Targetting.LowestEnemy),
                            new Effect(ScriptableObject.CreateInstance<ExitValueSetterEffect>(), 1, IntentType.Swap_Sides, Targetting.AllAlly)
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Claws"),
                        animationTarget = Targetting.LowestEnemy,
                    };
                }
                return _sink;
            }
        }
        static Ability _rot;
        public static Ability Rot
        {
            get
            {
                if (_rot == null)
                {
                    _rot = new Ability()
                    {
                        name = "Rot",
                        description = "Apply 2 Constricted to this enemy's position. Consume all pigment in the tray.",
                        rarity = 6,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ApplyConstrictedSlotEffect>(), 2, IntentType.Field_Constricted, Slots.Self),
                            new Effect(ScriptableObject.CreateInstance<ConsumeAllManaEffect>(), 1, IntentType.Mana_Consume, Slots.Self),
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Claws"),
                        animationTarget = Slots.Self,
                    };
                }
                return _rot;
            }
        }
        static Ability _writhe;
        public static Ability Writhe
        {
            get
            {
                if (_writhe == null)
                {
                    _writhe = new Ability()
                    {
                        name = "Writhe",
                        description = "Deal a Little bit of Shield-Piercing damage to this enemy.",
                        rarity = 4,
                        effects = new Effect[]
                        {
                            new Effect(BasicEffects.ShieldPierce, 1, IntentType.Damage_1_2, Slots.Self),
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Zap"),
                        animationTarget = Slots.Self,
                    };
                }
                return _writhe;
            }
        }
        static Ability _rightKill;
        public static Ability RightKill
        {
            get
            {
                if (_rightKill == null)
                {
                    AnimationVisualsIfUnitEffect play = ScriptableObject.CreateInstance<AnimationVisualsIfUnitEffect>();
                    play._animationTarget = Slots.Front;
                    play._visuals = CustomVisuals.GetVisuals("Salt/Hung");
                    play._noUnitAnimationTarget = Slots.Front;
                    play._noUnitVisuals = LoadedAssetsHandler.GetEnemyAbility("Domination_A").visuals;
                    _rightKill = new Ability()
                    {
                        name = "Righteous Execution",
                        description = "Move right. Instantly kill the Opposing party member.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(BasicEffects.GoRight, 1, IntentType.Swap_Right, Slots.Self),
                            new Effect(play, 1, null, Slots.Front),
                            new Effect(ScriptableObject.CreateInstance<DirectDeathEffect>(), 1, IntentType.Damage_Death, Slots.Front),
                        },
                        visuals = null,
                        animationTarget = Slots.Self,
                    };
                }
                return _rightKill;
            }
        }
        static Ability _leftKill;
        public static Ability LeftKill
        {
            get
            {
                if (_leftKill == null)
                {
                    AnimationVisualsIfUnitEffect play = ScriptableObject.CreateInstance<AnimationVisualsIfUnitEffect>();
                    play._animationTarget = Slots.Front;
                    play._visuals = CustomVisuals.GetVisuals("Salt/Hung");
                    play._noUnitAnimationTarget = Slots.Front;
                    play._noUnitVisuals = LoadedAssetsHandler.GetEnemyAbility("Talons_A").visuals;
                    _leftKill = new Ability()
                    {
                        name = "Left to Die",
                        description = "Move left. Instantly kill the Opposing party member.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(BasicEffects.GoLeft, 1, IntentType.Swap_Left, Slots.Self),
                            new Effect(play, 1, null, Slots.Front),
                            new Effect(ScriptableObject.CreateInstance<DirectDeathEffect>(), 1, IntentType.Damage_Death, Slots.Front),
                        },
                        visuals = null,
                        animationTarget = Slots.Self,
                    };
                }
                return _leftKill;
            }
        }
        static Ability _loseControl;
        public static Ability LoseControl
        {
            get
            {
                if (_loseControl == null)
                {
                    new CustomIntentInfo("Wheel", (IntentType)38305973, LoadedAssetsHandler.GetWearable("WheelOfFortune_TW").wearableImage, IntentType.Misc);
                    _loseControl = new Ability()
                    {
                        name = "Lose Control",
                        description = "Make the Opposing party member perform a random ability.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<PerformRandomAbilityEffect>(), 1, GetIntent("Wheel"), Slots.Front),
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Wheel"),
                        animationTarget = Slots.Front,
                    };
                }
                return _loseControl;
            }
        }
        static Ability _sing;
        public static Ability Sing
        {
            get
            {
                if (_sing == null)
                {
                    TargettingByHealthNotSkyloft lowest = ScriptableObject.CreateInstance<TargettingByHealthNotSkyloft>();
                    lowest.Lowest = true;
                    lowest.getAllies = true;
                    lowest.ignoreCastSlot = true;
                    _sing = new Ability()
                    {
                        name = "Sing for Me",
                        description = "Apply Spotlight and 1 Haste to the enemy with the lowest health that isn't a Skyloft. \n\"Just so I know you're near\"",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ApplySpotlightEffect>(), 1, IntentType.Status_Spotlight, lowest),
                            //new Effect(BasicEffects.PlaySound("event:/Hawthorne/Hurt/BirdSound"), 1, null, lowest),
                            new Effect(ScriptableObject.CreateInstance<ApplyHasteEffect>(), 1, GetIntent("Haste"), lowest)
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Skyloft/Stars"),
                        animationTarget = lowest,
                    };
                }
                return _sing;
            }
        }
        static Ability _tooFarGone;
        public static Ability TooFarGone
        {
            get
            {
                if (_tooFarGone == null)
                {
                    _tooFarGone = new Ability()
                    {
                        name = "Too Far Gone",
                        description = "Instantly flee.",
                        rarity = 3,
                        priority = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<FleeTargetEffect>(), 1, Intents.Flee, Slots.Self),
                        },
                        visuals = null,
                        animationTarget = Slots.Self,
                    };
                }
                return _tooFarGone;
            }
        }
        static Ability _seeDreams;
        public static Ability SeeDreams
        {
            get
            {
                if (_seeDreams == null)
                {
                    _seeDreams = new Ability()
                    {
                        name = "See What I Dream",
                        description = "Inflict 2 Ruptured and apply 3 Dodge on the Opposing party member. Move this enemy to the left or right.",
                        rarity = 4,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 2, IntentType.Status_Ruptured, Slots.Front),
                            new Effect(ScriptableObject.CreateInstance<ApplyDodgeEffect>(), 3, (IntentType)Dodge.dodge, Slots.Front),
                            new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, IntentType.Swap_Sides, Slots.Self)
                        },
                        visuals = LoadedAssetsHandler.GetEnemyAbility("RapturousReverberation_A").visuals,
                        animationTarget = Slots.Front,
                    };
                }
                return _seeDreams;
            }
        }
        static Ability _takeBones;
        public static Ability TakeBones
        {
            get
            {
                if (_takeBones == null)
                {
                    _takeBones = new Ability()
                    {
                        name = "Take My Bones",
                        description = "At the start of the next turn, deal a Painful amount of damage to this enemy's current Left and Right party member positions. Deal a Painful amount of Shield-Piercing damage to this enemy.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<AddDelayedAttackEffect>(), 5, IntentType.Damage_3_6, Slots.LeftRight),
                            new Effect(BasicEffects.ShieldPierce, 3, IntentType.Damage_3_6, Slots.Self)
                        },
                        visuals = LoadedAssetsHandler.GetCharacterAbility("Wrath_1_A").visuals,
                        animationTarget = MultiTargetting.Create(Slots.LeftRight, Slots.Self),
                    };
                }
                return _takeBones;
            }
        }
        static Ability _beyondLies;
        public static Ability BeyondLies
        {
            get
            {
                if (_beyondLies == null)
                {
                    _beyondLies = new Ability()
                    {
                        name = "Beyond the Lies",
                        description = "At the start of the next turn, deal an Agonizing amount of damage to all party member positions not currently facing an enemy. \n\"All things live and all things die\"",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<AddDelayedAttackEffect>(), 7, IntentType.Damage_7_10, ScriptableObject.CreateInstance<TargettingByFacingTarget>()),
                        },
                        visuals = LoadedAssetsHandler.GetEnemyAbility("Wriggle_A").visuals,
                        animationTarget = ScriptableObject.CreateInstance<TargettingByFacingTarget>(),
                    };
                }
                return _beyondLies;
            }
        }
        static Ability _dieWithYou;
        public static Ability DieWithYou
        {
            get
            {
                if (_dieWithYou == null)
                {
                    _dieWithYou = new Ability()
                    {
                        name = "I Want to Die with You",
                        description = "Move to a random position. At the start of the next turn, deal a Mortal amount of damage to the current Opposing party member position. \n\"As I want to live with you\"",
                        rarity = 3,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<SwapRandomZoneEffectHideIntent>(), 1, IntentType.Swap_Mass, Slots.Self),
                            new Effect(SubActionEffect.Create(new Effect[]
                            {
                                new Effect(BasicEffects.GetVisuals("Salt/Bullet", false, Slots.Front), 1, null, Slots.Self),
                                new Effect(ScriptableObject.CreateInstance<AddDelayedAttackEffect>(), 99, null, Slots.Front)
                            }), 1, null, Slots.Self),
                            new Effect(BasicEffects.Empty, 0, IntentType.Damage_Death, Slots.Front)
                        },
                        visuals = null,
                        animationTarget = Slots.Self,
                    };
                }
                return _dieWithYou;
            }
        }
        static Ability _bluePigs;
        public static Ability BluePigs
        {
            get
            {
                if (_bluePigs == null)
                {
                    _bluePigs = new Ability()
                    {
                        name = "Pigs in Blue",
                        description = "If any enemies have Blue health, apply 1 Constricted to their Opposing positions. \nOtherwise, change the closest left and right enemies' health color to Blue.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(BasicEffects.GetVisuals("Salt/Gaze", false, Targetting.Reverse(Targetting.GetColors(Pigments.Blue, true))), 1, IntentType.Field_Constricted, Targetting.Reverse(Targetting.GetColors(Pigments.Blue, true)), HasHealthColorCondition.Create(Pigments.Blue, false)),
                            new Effect(ScriptableObject.CreateInstance<ApplyConstrictedSlotEffect>(), 1, null, Targetting.Reverse(Targetting.GetColors(Pigments.Blue, true)), HasHealthColorCondition.Create(Pigments.Blue, false)),
                            new Effect(BasicEffects.GetVisuals("Wriggle_A", false, Targetting.Closer(true, true)), 1, null, Targetting.Closer(true, true), BasicEffects.DidThat(false)),
                            new Effect(ChangeHealthColorEffect.Create(Pigments.Blue), 1, IntentType.Mana_Modify, Targetting.Closer(true, true), BasicEffects.DidThat(false, 2))
                        },
                        visuals = null,
                        animationTarget = Slots.Self,
                    };
                }
                return _bluePigs;
            }
        }
        static Ability _crazyBlood;
        public static Ability CrazyBlood
        {
            get
            {
                if (_crazyBlood == null)
                {
                    _crazyBlood = new Ability()
                    {
                        name = "Blood in Crazy",
                        description = "If any enemies have Red health, apply 1 Constricted to their Opposing positions. \nOtherwise, give this enemy another action.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(BasicEffects.GetVisuals("Oil_1_A", true, Targetting.Reverse(Targetting.GetColors(Pigments.Red, true))), 1, IntentType.Field_Constricted, Targetting.Reverse(Targetting.GetColors(Pigments.Red, true)), HasHealthColorCondition.Create(Pigments.Red, false)),
                            new Effect(ScriptableObject.CreateInstance<ApplyConstrictedSlotEffect>(), 1, null, Targetting.Reverse(Targetting.GetColors(Pigments.Red, true)), HasHealthColorCondition.Create(Pigments.Red, false)),
                            new Effect(BasicEffects.GetVisuals("WholeAgain_1_A", true, Slots.Self), 1, null, Slots.Self, BasicEffects.DidThat(false)),
                            new Effect(ScriptableObject.CreateInstance<AddTurnCasterToTimelineEffect>(), 1, IntentType.Misc, Slots.Self, BasicEffects.DidThat(false, 2))
                        },
                        visuals = null,
                        animationTarget = Slots.Self,
                    };
                }
                return _crazyBlood;
            }
        }
        static Ability _pinch;
        public static Ability Pinch
        {
            get
            {
                if (_pinch == null)
                {
                    ChangeCasterHealthColorBetweenColorsEffect effect = ScriptableObject.CreateInstance<ChangeCasterHealthColorBetweenColorsEffect>();
                    effect._color1 = Pigments.Red;
                    effect._color2 = Pigments.Blue;
                    _pinch = new Ability()
                    {
                        name = "Pinch",
                        description = "Deal a Painful amount of damage to the Opposing party member. Change this enemy's health color between Red and Blue.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 4, IntentType.Damage_3_6, Slots.Front),
                            new Effect(effect, 1, IntentType.Mana_Modify, Slots.Self)
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Class"),
                        animationTarget = Slots.Front,
                    };
                }
                return _pinch;
            }
        }
        static Ability _shredding;
        public static Ability Shredding
        {
            get
            {
                if (_shredding == null)
                {
                    _shredding = new Ability()
                    {
                        name = "Shreddings",
                        description = "Deal a Painful amount of damage to the Opposing party member. \nDeal damage to the Left and Right party members based on the amount of damage dealt to the Opposing party member. \nDeal damage to the Far Left and Far Right party members based on the amount of damage dealt to the Left and Right party members. \nContinue this pattern as long as possible.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 6, IntentType.Damage_3_6, Slots.Front),
                            new Effect(BasicEffects.ExitDamage, 1, IntentType.Damage_3_6, Slots.LeftRight),
                            new Effect(BasicEffects.ExitDamage, 1, IntentType.Damage_3_6, Slots.SlotTarget(new int[]{-2, 2 }, false)),
                            new Effect(BasicEffects.ExitDamage, 1, IntentType.Damage_3_6, Slots.SlotTarget(new int[]{-3, 3 }, false)),
                            new Effect(BasicEffects.ExitDamage, 1, IntentType.Damage_3_6, Slots.SlotTarget(new int[]{-4, 4 }, false)),
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Four"),
                        animationTarget = Targetting.Everything(false),
                    };
                }
                return _shredding;
            }
        }
        static Ability _binder;
        public static Ability Binder
        {
            get
            {
                if (_binder == null)
                {
                    DamageByMissingHealthEffect hit = ScriptableObject.CreateInstance<DamageByMissingHealthEffect>();
                    _binder = new Ability()
                    {
                        name = "Binder",
                        description = "Deal damage to the Opposing party member based on their missing health. \nDeal damage to the Left and Right party members based on the lesser of their missing healths, ignoring empty positions. \nDeal damage to the Far Left and Far Right party members based on the lesser of their missing healths, ignoring empty positions. \nContinue this pattern as long as possible.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(hit, 1, IntentType.Damage_16_20, Slots.Front),
                            new Effect(hit, 1, IntentType.Damage_16_20, Slots.LeftRight),
                            new Effect(hit, 1, IntentType.Damage_16_20, Slots.SlotTarget(new int[]{-2, 2 }, false)),
                            new Effect(hit, 1, IntentType.Damage_16_20, Slots.SlotTarget(new int[]{-3, 3 }, false)),
                            new Effect(hit, 1, IntentType.Damage_16_20, Slots.SlotTarget(new int[]{-4, 4 }, false)),
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Ribbon"),
                        animationTarget = Targetting.Everything(false),
                    };
                }
                return _binder;
            }
        }
        static Ability _engravings;
        public static Ability Engravings
        {
            get
            {
                if (_engravings == null)
                {
                    _engravings = new Ability()
                    {
                        name = "Blood Engravings",
                        description = "Deal a Little bit of damage and apply Focused to the Opposing party member. \nIf damage was dealt and the Opposing party member survives, force the Opposing party member to use this ability on their Left and Right allies.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<EngravingsEffect>(), 2, IntentType.Damage_1_2, Slots.Front),
                            new Effect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, IntentType.Status_Focused, Slots.Front)
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Claws"),
                        animationTarget = Slots.Front,
                    };
                }
                return _engravings;
            }
        }
        static Ability _press;
        public static Ability Press
        {
            get
            {
                if (_press == null)
                {
                    _press = new Ability()
                    {
                        name = "Weighted Press",
                        description = "Deal damage equal to the total health of all enemies divided amongst all party members connected to the Opposing party member.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<AllEnemyMaxHealthExitCollectEffect>(), 1, IntentType.Misc, Targetting.AllAlly),
                            new Effect(ScriptableObject.CreateInstance<DivideUpDamageExitValueEffect>(), 1, IntentType.Damage_16_20, ScriptableObject.CreateInstance<AllTargetsTouchingFrontSingleSizeOnly>())
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Crush"),
                        animationTarget = ScriptableObject.CreateInstance<AllTargetsTouchingFrontSingleSizeOnly>(),
                    };
                }
                return _press;
            }
        }
        static Ability _descriptions;
        public static Ability Descriptions
        {
            get
            {
                if (_descriptions == null)
                {
                    _descriptions = new Ability()
                    {
                        name = "Depiction",
                        description = "Copy all Status Effects from all enemies and party members onto this enemy. \nThen, copy all Status Effects from all enemies and party members onto the Opposing party member. \nThen, deal damage to the Opposing party member for the amount of Status Effects on all enemies and party members. \n1 Restrictor of a Status counts as 4 stacks.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(BasicEffects.Empty, 1, IntentType.Misc_Hidden, Targetting.AllEnemy),
                            new Effect(BasicEffects.Empty, 1, IntentType.Misc_Hidden, Targetting.AllAlly),
                            new Effect(ScriptableObject.CreateInstance<CopyStatusOntoCasterEffect>(), 1, null, MultiTargetting.Create(Targetting.AllEnemy, Targetting.AllAlly)),
                            new Effect(SubActionEffect.Create(new Effect[]
                            {
                                new Effect(ScriptableObject.CreateInstance<CopyStatusOntoCasterEffect>(), 1, null, MultiTargetting.Create(Targetting.AllEnemy, Targetting.AllAlly))
                            }), 1, null, Slots.Front),
                            new Effect(CasterSubActionEffect.Create(new Effect[]
                            {
                                new Effect(BasicEffects.GetVisuals("Salt/Bullet", false, Slots.Front), 1, null, Slots.Front),
                                new Effect(ScriptableObject.CreateInstance<CountAllStatusEffect>(), 1, null, MultiTargetting.Create(Targetting.AllEnemy, Targetting.AllAlly)),
                                new Effect(BasicEffects.ExitDamage, 1, null, Slots.Front)
                            }), 1, IntentType.Damage_21, Slots.Front)
                        },
                        visuals = null,
                        animationTarget = Slots.Self,
                    };
                }
                return _descriptions;
            }
        }
        static Ability _indexing;
        public static Ability Indexing
        {
            get
            {
                if (_indexing == null)
                {
                    _indexing = new Ability()
                    {
                        name = "Indexing",
                        description = "Deal " + CountFibonacci.Get(42) + " damage to the Opposing party member. \nIf this would cause an error, crash the game.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<DamageIfFailDeal1Effect>(), CountFibonacci.Get(42), IntentType.Damage_Death, Slots.Front),
                        },
                        visuals = null,
                        animationTarget = Slots.Front,
                    };
                }
                return _indexing;
            }
        }
        static Ability _dissolver;
        public static Ability Dissolver
        {
            get
            {
                if (_dissolver == null)
                {
                    _dissolver = new Ability()
                    {
                        name = "Dissolver",
                        description = "Deal an Agonizing amount of damage to the Left and Right party members and apply 3 Anesthetics to them.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 10, IntentType.Damage_7_10, Slots.LeftRight),
                            new Effect(ScriptableObject.CreateInstance<ApplyAnestheticsEffect>(), 3, (IntentType)987898, Slots.LeftRight)
                        },
                        visuals = LoadedAssetsHandler.GetEnemyAbility("Boil_A").visuals,
                        animationTarget = Slots.LeftRight,
                    };
                }
                return _dissolver;
            }
        }
        static Ability _fadeOut;
        public static Ability FadeOut
        {
            get
            {
                if (_fadeOut == null)
                {
                    _fadeOut = new Ability()
                    {
                        name = "Fade Out",
                        description = "Make the Opposing party member instantly flee. This enemy flees as well.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<FleeTargetEffect>(), 1, Intents.Flee, Slots.Front),
                            new Effect(ScriptableObject.CreateInstance<FleeTargetEffect>(), 1, Intents.Flee, Slots.Self)
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Class"),
                        animationTarget = MultiTargetting.Create(Slots.Self, Slots.Front),
                    };
                }
                return _fadeOut;
            }
        }
        static Ability _phaseIn;
        public static Ability PhaseIn
        {
            get
            {
                if (_phaseIn == null)
                {
                    _phaseIn = new Ability()
                    {
                        name = "Phase In",
                        description = "Instanty flee this enemy and spawn a copy of it.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<FleeTargetEffect>(), 1, Intents.Flee, Slots.Self),
                            new Effect(CasterSubActionEffect.Create(new Effect[]
                            {
                                new Effect(CasterSubActionEffect.Create(new Effect[]
                                {
                                    new Effect(ScriptableObject.CreateInstance<SpawnSelfEnemyAnywhereEffect>(), 1, null, Slots.Self)
                                }), 1, null, Slots.Self)
                            }), 1, IntentType.Other_Spawn, Slots.Self)
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Door"),
                        animationTarget = Slots.Self,
                    };
                }
                return _phaseIn;
            }
        }
        static Ability _waver;
        public static Ability Waver
        {
            get
            {
                if (_waver == null)
                {
                    EffectSO ads = BasicEffects.GetVisuals("Salt/Ads", false, Slots.Front);
                    IsFrontTargetCondition yeah = ScriptableObject.CreateInstance<IsFrontTargetCondition>();
                    yeah.returnTrue = true;
                    _waver = new Ability()
                    {
                        name = "Waver",
                        description = "Move the Opposing party member to the Left or Right. Repeat this.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, IntentType.Swap_Sides, Slots.Front),
                            new Effect(CasterSubActionEffect.Create(new Effect[]
                            {
                                new Effect(ads, 1, null, Slots.Front, yeah),
                                new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, IntentType.Swap_Sides, Slots.Front),
                            }), 1, IntentType.Swap_Sides, Slots.Front),
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Ads"),
                        animationTarget = Slots.Front,
                    };
                }
                return _waver;
            }
        }
        static Ability _wanderlust;
        public static Ability Wanderlust
        {
            get
            {
                if (_wanderlust == null)
                {
                    _wanderlust = new Ability()
                    {
                        name = "Wanderlust",
                        description = "Deal a Painful amount of damage to the Opposing party member. If there is no Opposing party member, give this enemy another action, this ability cannot give this enemy \"Wanderlust\" again.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<IsUnitEffect>(), 1, null, Slots.Front),
                            new Effect(BasicEffects.GetVisuals("Salt/Door", false, Slots.Front), 1, null, Slots.Front, BasicEffects.DidThat(true)),
                            new Effect(BasicEffects.GetVisuals("Salt/Door", false, Slots.Self), 1, null, Slots.Front, BasicEffects.DidThat(false, 2)),
                            new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 5, IntentType.Damage_3_6, Slots.Front),
                            new Effect(BasicEffects.SetStoreValue(UnitStoredValueNames.DemonCoreW), 1, null, Slots.Self),
                            new Effect(ScriptableObject.CreateInstance<AddTurnCasterToTimelineEffect>(), 1, IntentType.Misc, Slots.Self, ScriptableObject.CreateInstance<IsFrontTargetCondition>()),
                            new Effect(RootActionEffect.Create(new Effect[]
                            {
                                new Effect(BasicEffects.SetStoreValue(UnitStoredValueNames.DemonCoreW), 0, null, Slots.Self),
                            }), 1, null, Slots.Self)
                        },
                        visuals = null,
                        animationTarget = Slots.Self,
                    };
                }
                return _wanderlust;
            }
        }
        static Ability _whisperings;
        public static Ability Whisperings
        {
            get
            {
                if (_whisperings == null)
                {
                    _whisperings = new Ability()
                    {
                        name = "Whisperings",
                        description = "Apply 1 Constricted on the Opposing party member position. Deal a Painful amount of damage to the Opposing party member.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ApplyConstrictedSlotEffect>(), 1, IntentType.Field_Constricted, Slots.Front),
                            new Effect(BasicEffects.PlaySound(SaltEnemies.CursedNoise), 1, null, Slots.Front),
                            new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 3, IntentType.Damage_3_6, Slots.Front),
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Whisper"),
                        animationTarget = Slots.Self,
                    };
                }
                return _whisperings;
            }
        }
        static Ability _nameless;
        public static Ability Nameless
        {
            get
            {
                if (_nameless == null)
                {
                    NamelessHandler.Setup();
                    _nameless = new Ability()
                    {
                        name = "The Volume of a Beating Heart",
                        description = "If the file Brutal Orchestra/Nameless/Nameless.txt exists, this enemy will apply 50 Pale to all party members. Otherwise, they will do nothing. \nYou can manually delete that file to disable this ability.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(SubActionEffect.Create(new Effect[]
                            {
                                new Effect(BasicEffects.GetVisuals("DrippingsOfTheGarden_A", false, Targetting_By_NamelessFile.Create(MultiTargetting.Create(Slots.Self, Targetting.AllEnemy))), 1, null, Slots.Self),
                                new Effect(ScriptableObject.CreateInstance<ApplyPaleEffect>(), 50, null, Targetting_By_NamelessFile.Create(Targetting.AllEnemy))
                            }), 1, IntentType.Misc_Hidden, Targetting_By_NamelessFile.Create(Slots.Self)),
                            new Effect(BasicEffects.Empty, 0, (IntentType)666888, Targetting_By_NamelessFile.Create(Targetting.AllEnemy))
                        },
                        visuals = null,
                        animationTarget = Slots.Self,
                    };
                }
                return _nameless;
            }
        }
        static Ability _nobodyMoves;
        public static Ability NobodyMoves
        {
            get
            {
                if (_nobodyMoves == null)
                {
                    NobodyMoveHandler.Setup();
                    _nobodyMoves = new Ability()
                    {
                        name = "If Nobody Moves",
                        description = "Inflict 1 Ruptured on every party member who moved since the start of the last turn.\n\"Nobody will get hurt\"",
                        rarity = 3,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 1, IntentType.Status_Ruptured, Targetting_By_Moved.Create(false)),
                        },
                        visuals = LoadedAssetsHandler.GetEnemyAbility("ThePact_A").visuals,
                        animationTarget = Targetting_By_Moved.Create(false),
                    };
                }
                return _nobodyMoves;
            }
        }
        static Ability _longSlice;
        public static Ability LongSlice
        {
            get
            {
                if (_longSlice == null)
                {
                    _longSlice = new Ability()
                    {
                        name = "Long Slice",
                        description = "If this enemy has Confusion as a passive, deal an Agonizing amount of damage to the far far Left and far far Right party members. This attack is fully blocked by Shield. \nOtherwise, give this enemy another action.",
                        rarity = 10,
                        effects = new Effect[]
                        {
                            new Effect(BasicEffects.GetVisuals("Salt/Decapitate", false, Slots.SlotTarget(new int[] {-3, 3}, false)), 1, null, Slots.SlotTarget(new int[] {-3, 3 }, false), HasConfusionCondition.Create(true)),
                            new Effect(ScriptableObject.CreateInstance<DamageShieldBlockedEffect>(), 10, IntentType.Damage_7_10, Slots.SlotTarget(new int[] {-3, 3}, false), HasConfusionCondition.Create(true)),
                            new Effect(ScriptableObject.CreateInstance<AddTurnCasterToTimelineEffect>(), 1, IntentType.Misc, Slots.Self, HasConfusionCondition.Create(false)),
                        },
                        visuals = null,
                        animationTarget = Slots.Self,
                    };
                }
                return _longSlice;
            }
        }
        static Ability _foggyLens;
        public static Ability FoggyLens
        {
            get
            {
                if (_foggyLens == null)
                {
                    _foggyLens = new Ability()
                    {
                        name = "Foggy Lens",
                        description = "Apply Confusion as a passive to this enemy. \nIf this enemy already had Confusion, give this enemy Spotlight.",
                        rarity = 3,
                        priority = -5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ApplySpotlightEffect>(), 1, IntentType.Status_Spotlight, Slots.Self, HasConfusionCondition.Create(true)),
                            new Effect(BasicEffects.AddPassive(Passives.Confusion), 1, IntentType.Misc_Hidden, Slots.Self, HasConfusionCondition.Create(false))
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Fog"),
                        animationTarget = Slots.Self,
                    };
                }
                return _foggyLens;
            }
        }
        static Ability _shortStomp;
        public static Ability ShortStomp
        {
            get
            {
                if (_shortStomp == null)
                {
                    _shortStomp = new Ability()
                    {
                        name = "Short Stomp",
                        description = "If this enemy does not Confusion as a Passive, heal it a Moderate amount health. \nOtherwise, deal a Painful amount of damage to the Opposing party member and inflict 2 Ruptured upon them. Move this enemy 3 spaces Left or Right.",
                        rarity = 8,
                        effects = new Effect[]
                        {
                            new Effect(BasicEffects.GetVisuals("FallingSkies_A", false, Slots.Self), 1, null, Slots.Self, HasConfusionCondition.Create(false)),
                            new Effect(ScriptableObject.CreateInstance<HealEffect>(), 10, IntentType.Heal_5_10, Slots.Self, HasConfusionCondition.Create(false)),
                            new Effect(BasicEffects.GetVisuals("FallingSkies_A", false, Slots.Front), 0, null, Slots.Front, HasConfusionCondition.Create(true)),
                            new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 4, IntentType.Damage_3_6, Slots.Front, HasConfusionCondition.Create(true)),
                            new Effect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 2, IntentType.Status_Ruptured, Slots.Front, HasConfusionCondition.Create(true)),
                            new Effect(ScriptableObject.CreateInstance<ShortStompEffect>(), 1, IntentType.Swap_Sides, Slots.Self, HasConfusionCondition.Create(true)),
                        },
                        visuals = null,
                        animationTarget = Slots.Self,
                    };
                }
                return _shortStomp;
            }
        }
        static Ability _chomp;
        public static Ability Chomp
        {
            get
            {
                if (_chomp == null)
                {
                    _chomp = new Ability()
                    {
                        name = "Chomp",
                        description = "Deal a Painful amount of damage to the Opposing party members.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 4, IntentType.Damage_3_6, Slots.Front),
                        },
                        visuals = LoadedAssetsHandler.GetEnemyAbility("Chomp_A").visuals,
                        animationTarget = Slots.Front,
                    };
                }
                return _chomp;
            }
        }
        static Ability _psychoDreams;
        public static Ability PsychoDreams
        {
            get
            {
                if (_psychoDreams == null)
                {
                    _psychoDreams = new Ability()
                    {
                        name = "Psychokinetic Dreams",
                        description = "Apply 2 Linked to this enemy and heal it a Little health.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ApplyLinkedEffect>(), 2, IntentType.Status_Linked, Slots.Self),
                            new Effect(ScriptableObject.CreateInstance<HealEffect>(), 4, IntentType.Heal_1_4, Slots.Self)
                        },
                        visuals = LoadedAssetsHandler.GetCharacterAbility("Entwined_1_A").visuals,
                        animationTarget = Slots.Self,
                    };
                }
                return _psychoDreams;
            }
        }
        static Ability _glassWaves;
        public static Ability GlassWaves
        {
            get
            {
                if (_glassWaves == null)
                {
                    _glassWaves = new Ability()
                    {
                        name = "Glass Waves",
                        description = "Remove all status effects from the closest Left and Right enemies.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<RemoveAllStatusEffectsEffect>(), 1, IntentType.Misc, Targetting.Closer(true, true)),
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Swirl"),
                        animationTarget = Targetting.Closer(true, true),
                    };
                }
                return _glassWaves;
            }
        }
        static Ability _woodChips;
        public static Ability WoodChips
        {
            get
            {
                if (_woodChips == null)
                {
                    _woodChips = new Ability()
                    {
                        name = "Wood Chips",
                        description = "\"The closer to death, the closer to god\"",
                        rarity = 4,
                        effects = new Effect[]
                         {
                            new Effect(ScriptableObject.CreateInstance<WoodChipsEffect>(), 1, IntentType.Misc, Targetting.AllEnemy),
                            new Effect(BasicEffects.Empty, 1, IntentType.Other_Spawn, Slots.Self)
                         },
                        visuals = CustomVisuals.GetVisuals("Salt/Shatter"),
                        animationTarget = TargettingUnitsUnderHealth.Create(5, false),
                    };
                }
                return _woodChips;
            }
        }
        static Ability _painStar;
        public static Ability PainStar
        {
            get
            {
                if (_painStar == null)
                {
                   _painStar = new Ability()
                    {
                        name = "Pain Star",
                        description = "Transform this enemy into another random 1 tile enemy currently in combat. \n(Not all enemies are applicable transformation targets, like the Sepulchre for example)",
                        rarity = 3,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<PainStarEffect>(), 1, IntentType.Other_Transform_Instument, Slots.Self),
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Coda"),
                        animationTarget = Slots.Self,
                    };
                }
                return _painStar;
            }
        }
        static Ability _dangle;
        public static Ability Dangle
        {
            get
            {
                if (_dangle == null)
                {
                    _dangle = new Ability()
                    {
                        name = "Dangle",
                        description = "Inflict 2-3 Scars on this enemy.",
                        rarity = 10,
                        effects = new Effect[]
                         {
                            new Effect(ScriptableObject.CreateInstance<ApplyScarsEffect>(), 2, IntentType.Status_Scars, Slots.Self),
                            new Effect(ScriptableObject.CreateInstance<ApplyScarsEffect>(), 1, null, Slots.Self, Conditions.Chance(50)),
                         },
                        visuals = LoadedAssetsHandler.GetEnemyAbility("Wriggle_A").visuals,
                        animationTarget = Slots.Self,
                    };
                }
                return _dangle;
            }
        }
        static Ability _fall;
        public static Ability Fall
        {
            get
            {
                if (_fall == null)
                {
                    new CustomIntentInfo("FallColor", (IntentType)2091863, ResourceLoader.LoadSprite("placeholdit"), IntentType.Damage_Death, new Color(28f, 78f, 128f));
                    FallImageryHandler.Setup();
                    _fall = new Ability()
                    {
                        name = "Inevitable Fall",
                        description = "Deal 0-20 damage to this enemy.",
                        rarity = 2,
                        effects = new Effect[]
                         {
                            new Effect(BasicEffects.Empty, 0, IntentType.Damage_1_2, Slots.Self),
                            new Effect(ScriptableObject.CreateInstance<RandomDamageBetweenPreviousAndEntryEffect>(), 20, IntentType.Damage_3_6, Slots.Self),
                            new Effect(BasicEffects.Empty, 0, IntentType.Damage_7_10, Slots.Self),
                            new Effect(BasicEffects.Empty, 0, IntentType.Damage_11_15, Slots.Self),
                            new Effect(BasicEffects.Empty, 0, IntentType.Damage_16_20, Slots.Self),
                            new Effect(BasicEffects.Empty, 0, IntentType.Damage_21, Slots.Self),
                            new Effect(BasicEffects.Empty, 0, CustomIntentIconSystem.GetIntent("FallColor"), Slots.Self),
                         },
                        visuals = null,
                        animationTarget = Slots.Self,
                    };
                }
                return _fall;
            }
        }
        static Ability _descent;
        public static Ability Descent
        {
            get
            {
                if (_descent == null)
                {
                    _descent = new Ability()
                    {
                        name = "Bloating Descent",
                        description = "Produce 2 Blue Pigment and increase Saline by 1. Increase the Lucky Pigment percent by 15.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(BasicEffects.GenPigment(Pigments.Blue), 2, IntentType.Mana_Generate, Slots.Self),
                            new Effect(BasicEffects.ChangeValue(DrowningManager.Saline, true), 1, IntentType.Misc, Slots.Self),
                            new Effect(ScriptableObject.CreateInstance<IncreaseLuckyBluePercentageEffect>(), 15, IntentType.Misc, Slots.Self)
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Swirl"),
                        animationTarget = Slots.Self,
                    };
                }
                return _descent;
            }
        }
        static Ability _presence;
        public static Ability Presence
        {
            get
            {
                if (_presence == null)
                {
                    _presence = new Ability()
                    {
                        name = "Unnerving Presence",
                        description = "Inflict 1 Frail on all party members. Increase Saline by 1.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ApplyFrailEffect>(), 1, IntentType.Status_Frail, Targetting.AllEnemy),
                            new Effect(BasicEffects.ChangeValue(DrowningManager.Saline, true), 1, IntentType.Misc, Slots.Self)
                        },
                        visuals = LoadedAssetsHandler.GetEnemy("Ouroborus_Tail_BOSS").abilities[0].ability.visuals,
                        animationTarget = LoadedAssetsHandler.GetEnemy("Ouroborus_Tail_BOSS").abilities[0].ability.animationTarget,
                    };
                }
                return _presence;
            }
        }
        static Ability _bloodAttract;
        public static Ability BloodAttract
        {
            get
            {
                if (_bloodAttract == null)
                {
                    _bloodAttract = new Ability()
                    {
                        name = "Blood Attraction",
                        description = "Give this enemy Leaky as a passive. If this enemy already had Leaky, increase it by 1. \nIncrease Saline by 1.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(BasicEffects.AddPassive(Passi.LeakySV), 1, IntentType.Misc, Slots.Self),
                            new Effect(BasicEffects.ChangeValue(DrowningManager.Leaky, true), 1, null, Slots.Self, BasicEffects.DidThat(false)),
                            new Effect(BasicEffects.ChangeValue(DrowningManager.Saline, true), 1, IntentType.Misc, Slots.Self)
                        },
                        visuals = LoadedAssetsHandler.GetEnemyAbility("WrigglingWrath_A").visuals,
                        animationTarget = Targetting.AllSelfSlots,
                    };
                }
                return _bloodAttract;
            }
        }
        static Ability _abyss;
        public static Ability Abyss
        {
            get
            {
                if (_abyss == null)
                {
                    _abyss = new Ability()
                    {
                        name = "Dark Abyss",
                        description = "Inflict 1 Stunned on all party members not in front of an enemy. Increase Saline by 1.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ApplyStunnedEffect>(), 1, (IntentType)988896, ScriptableObject.CreateInstance<TargettingByFacingTarget>()),
                            new Effect(BasicEffects.ChangeValue(DrowningManager.Saline, true), 1, IntentType.Misc, Slots.Self)
                        },
                        visuals = LoadedAssetsHandler.GetEnemyAbility("Boil_A").visuals,
                        animationTarget = ScriptableObject.CreateInstance<TargettingByFacingTarget>(),
                    };
                }
                return _abyss;
            }
        }
        static Ability _sprayBlood;
        public static Ability SprayBlood
        {
            get
            {
                if (_sprayBlood == null)
                {
                    _sprayBlood = new Ability()
                    {
                        name = "Spray Blood",
                        description = "Deal a Painful amount of damage to the Left and Right party members. Increase Noise on the Opposing party member by 2.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 4, IntentType.Damage_3_6, Slots.LeftRight),
                            new Effect(ScriptableObject.CreateInstance<TargetStoredValueChangeEffect>(), 2, IntentType.Misc, Slots.Front)
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Alarm"),
                        animationTarget = Slots.LeftRight,
                    };
                }
                return _sprayBlood;
            }
        }
        static Ability _splitBlood;
        public static Ability SplitBlood
        {
            get
            {
                if (_splitBlood == null)
                {
                    _splitBlood = new Ability()
                    {
                        name = "Split Blood",
                        description = "Move this enemy to the left or right, then increase the Noise on the Left and Right party members by 3.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, IntentType.Swap_Sides, Slots.Self),
                            new Effect(BasicEffects.GetVisuals("InhumanRoar_A", false, Slots.LeftRight), 1, null, Slots.Self),
                            new Effect(ScriptableObject.CreateInstance<TargetStoredValueChangeEffect>(), 3, IntentType.Misc, Slots.LeftRight)
                        },
                        visuals = null,
                        animationTarget = Slots.Self,
                    };
                }
                return _splitBlood;
            }
        }
        static Ability _splatterBlood;
        public static Ability SplatterBlood
        {
            get
            {
                if (_splatterBlood == null)
                {
                    _splatterBlood = new Ability()
                    {
                        name = "Splatter Blood",
                        description = "Inflict 2 Ruptured on the Left, Right, and Opposing party members and increase their Noise by 1. Move this enemy to the left or right.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 1, IntentType.Status_Ruptured, Slots.FrontLeftRight),
                            new Effect(ScriptableObject.CreateInstance<TargetStoredValueChangeEffect>(), 1, IntentType.Misc, Slots.FrontLeftRight),
                            new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, IntentType.Swap_Sides, Slots.Self)
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Class"),
                        animationTarget = Slots.FrontLeftRight,
                    };
                }
                return _splatterBlood;
            }
        }
        static Ability _librarium;
        public static Ability Librarium
        {
            get
            {
                if (_librarium == null)
                {
                    _librarium = new Ability()
                    {
                        name = "Librarium",
                        description = "Kill all party members with a Noise level of 5 or higher. Reset the Noise of the Opposing, Far Left, and Far Right party members.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(BasicEffects.GetVisuals("Salt/Static", false, Slots.Self), 1, null, NoiseTargetting.Default(), ScriptableObject.CreateInstance<IsNoiseCondition>()),
                            new Effect(BasicEffects.Die(true), 1, IntentType.Damage_Death, NoiseTargetting.Default()),
                            new Effect(BasicEffects.GetVisuals("Wriggle_A", false, Slots.SlotTarget(new int[] {-2, 0, 2 }, false)), 1, null, NoiseTargetting.Default(), BasicEffects.DidThat(false)),
                            new Effect(ScriptableObject.CreateInstance<TargetSetValueChangeEffect>(), 0, IntentType.Misc, Slots.SlotTarget(new int[] {-2, 0, 2 }, false))
                        },
                        visuals = null,
                        animationTarget = Slots.Self,
                    };
                }
                return _librarium;
            }
        }
        static Ability _silenceFools;
        public static Ability SilenceFools
        {
            get
            {
                if (_silenceFools == null)
                {
                    _silenceFools = new Ability()
                    {
                        name = "Silence the Foolish",
                        description = "Apply 2 Muted and 2 Fire to the last party member who dealt damage to this enemy. Produce 2 Red Pigment.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ApplyMutedEffect>(), 2, (IntentType)846750, Targetting_BySnakeGod.Create(false)),
                            new Effect(ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), 2, IntentType.Field_Fire, Targetting_BySnakeGod.Create(false)),
                            new Effect(BasicEffects.GenPigment(Pigments.Red), 2, IntentType.Mana_Generate, Slots.Self)
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Shush"),
                        animationTarget = Targetting_BySnakeGod.Create(false),
                    };
                }
                return _silenceFools;
            }
        }
        static Ability _hangWeak;
        public static Ability HangWeak
        {
            get
            {
                if (_hangWeak == null)
                {
                    _hangWeak = new Ability()
                    {
                        name = "Hang the Weak",
                        description = "Inflict 1 Constricted and 3 Oil-Slicked on every party member who dealt damage to this enemy. Produce 1 Red Pigment.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ApplyConstrictedSlotEffect>(), 1, IntentType.Field_Constricted, Targetting_BySnakeGod.Create(true)),
                            new Effect(ScriptableObject.CreateInstance<ApplyOilSlickedEffect>(), 3, IntentType.Status_OilSlicked, Targetting_BySnakeGod.Create(true)),
                            new Effect(BasicEffects.GenPigment(Pigments.Red), 1, IntentType.Mana_Generate, Slots.Self)
                        },
                        visuals = LoadedAssetsHandler.GetEnemyAbility("FallingSkies_A").visuals,
                        animationTarget = Targetting_BySnakeGod.Create(true),
                    };
                }
                return _hangWeak;
            }
        }
        static Ability _suffocatePoor;
        public static Ability SuffocatePoor
        {
            get
            {
                if (_suffocatePoor == null)
                {
                    _suffocatePoor = new Ability()
                    {
                        name = "Suffocate the Pitiful",
                        description = "Apply 1 Muted to all party members. Produce 2 Red Pigment.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ApplyMutedEffect>(), 1, (IntentType)846750, Targetting.AllEnemy),
                            new Effect(BasicEffects.GenPigment(Pigments.Red), 2, IntentType.Mana_Generate, Slots.Self)
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Shush"),
                        animationTarget = Targetting.AllEnemy,
                    };
                }
                return _suffocatePoor;
            }
        }
        static Ability _eatTears;
        public static Ability EatTears
        {
            get
            {
                if (_eatTears == null)
                {
                    _eatTears = new Ability()
                    {
                        name = "Devour their Tears",
                        description = "Consume all Blue pigment and deal an equivalent amount of damage to the party member who last dealt damage to this enemy. \nProduce 3 Red pigment.",
                        rarity = 10,
                        effects = new Effect[]
                        {
                            new Effect(BasicEffects.RemPigment(Pigments.Blue), 1, IntentType.Mana_Consume, Slots.Self),
                            new Effect(BasicEffects.ExitDamage, 1, IntentType.Damage_7_10, Targetting_BySnakeGod.Create(false)),
                            new Effect(BasicEffects.GenPigment(Pigments.Red), 3, IntentType.Mana_Generate, Slots.Self)
                        },
                        visuals = LoadedAssetsHandler.GetEnemyAbility("Devour_A").visuals,
                        animationTarget = MultiTargetting.Create(Targetting_BySnakeGod.Create(false), Slots.Self),
                    };
                }
                return _eatTears;
            }
        }
        static Ability _scareFeeble;
        public static Ability ScareFeeble
        {
            get
            {
                if (_scareFeeble == null)
                {
                    _scareFeeble = new Ability()
                    {
                        name = "Terrify the Feeble",
                        description = "Make the party member with the lowest health instantly flee. Produce 4 Red pigment.",
                        rarity = 15,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<FleeTargetEffect>(), 1, Intents.Flee, Targetting.LowestEnemy),
                            new Effect(BasicEffects.GenPigment(Pigments.Red), 4, IntentType.Mana_Generate, Slots.Self)
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Forest"),
                        animationTarget = Targetting.LowestEnemy,
                    };
                }
                return _scareFeeble;
            }
        }
        static Ability _crashYourGame;
        public static Ability CrashYourGame
        {
            get
            {
                if (_crashYourGame == null)
                {
                    _crashYourGame = new Ability()
                    {
                        name = "Crashes Your Game",
                        description = "I'm done messing around.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<CrashesYourGameEffect>(), 5, IntentType.Misc, Slots.Self),
                        },
                        visuals = null,
                        animationTarget = Slots.Front,
                    };
                }
                return _crashYourGame;
            }
        }
        static Ability _nest;
        public static Ability Nest
        {
            get
            {
                if (_nest == null)
                {
                    _nest = new Ability()
                    {
                        name = "Nest",
                        description = "Apply 1 Constricted on the Left and Right party member positions. Reduce this enemy's Fleeting by 1 and inflict 2 Frail upon this enemy. \nThis ability cannot be selected twice in a row.",
                        rarity = 5,
                        effects = new Effect[]
                         {
                            new Effect(ScriptableObject.CreateInstance<ApplyConstrictedSlotEffect>(), 1, IntentType.Field_Constricted, Slots.LeftRight),
                            new Effect(BasicEffects.ChangeValue(UnitStoredValueNames.FleetingPA, false), 1, IntentType.Misc, Slots.Self),
                            new Effect(ScriptableObject.CreateInstance<ApplyFrailEffect>(), 2, IntentType.Status_Frail, Slots.Self)
                         },
                        visuals = CustomVisuals.GetVisuals("Salt/Ribbon"),
                        animationTarget = MultiTargetting.Create(Slots.Self, Slots.LeftRight),
                    };
                }
                return _nest;
            }
        }
        static Ability _patience;
        public static Ability Patience
        {
            get
            {
                if (_patience == null)
                {
                    _patience = new Ability()
                    {
                        name = "Patience",
                        description = "Move all party members with Terror closer to this enemy. \nIf there are no party members with Terror, apply it to the party member farthest from this enemy. \nThis ability will always be selected if there are no party members with Terror.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<WasteTimeEffect>(), 1, null, Targetting.AllEnemy),
                            new Effect(BasicEffects.GoLeft, 1, IntentType.Swap_Left, TargettingUnitsEitherSideWithStatus.Create(Terror.Type, false, true)),
                            new Effect(BasicEffects.GoRight, 1, IntentType.Swap_Right, TargettingUnitsEitherSideWithStatus.Create(Terror.Type, false, false)),
                            new Effect(ScriptableObject.CreateInstance<ApplyTerrorIfNoneEffect>(), 1, null, Targetting.Closer(false, false)),
                            new Effect(BasicEffects.Empty, 1, Terror.Intent, Targetting.AllEnemy)
                        },
                        visuals = null,
                        animationTarget = Slots.Self,
                    };
                }
                return _patience;
            }
        }
        static Ability _trackDown;
        public static Ability TrackDown
        {
            get
            {
                if (_trackDown == null)
                {
                    _trackDown = new Ability()
                    {
                        name = "Track Down",
                        description = "This enemy moves to the Left or Right, and will always attempt to move in front of a target with Terror if possible.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<HuntDownEffect>(), 1, IntentType.Misc_Hidden, LeftRightTargetting.Create(false, true)),
                            new Effect(BasicEffects.Empty, 1, IntentType.Swap_Sides, Slots.Self)
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Gaze"),
                        animationTarget = MultiTargetting.Create(Slots.Self, Slots.LeftRight),
                    };
                }
                return _trackDown;
            }
        }
        static Ability _singeClaws;
        public static Ability SingeClaws
        {
            get
            {
                if (_singeClaws == null)
                {
                    _singeClaws = new Ability()
                    {
                        name = "Singeing Claws",
                        description = "Deal a Painful amount of damage to the Opposing party member. Apply Fire to the Opposing position for the amount of damage not dealt (cannot apply negative Fire).",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<SingeClawsEffect>(), 3, IntentType.Damage_3_6, Slots.Front),
                            new Effect(BasicEffects.Empty, 1, IntentType.Field_Fire, Slots.Front)
                        },
                        visuals = LoadedAssetsHandler.GetEnemyAbility("Talons_A").visuals,
                        animationTarget = Slots.Front,
                    };
                }
                return _singeClaws;
            }
        }
        static Ability _fireVeins;
        public static Ability FireVeins
        {
            get
            {
                if (_fireVeins == null)
                {
                    _fireVeins = new Ability()
                    {
                        name = "Fiery Veins",
                        description = "Remove all Fire from the Opposing, Left, and Right party member positions and heal this enemy twice the amount.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<RemoveAllFireEffect>(), 1, IntentType.Rem_Field_Fire, Slots.FrontLeftRight),
                            new Effect(BasicEffects.ExitHeal, 2, IntentType.Heal_11_20, Slots.Self)
                        },
                        visuals = LoadedAssetsHandler.GetCharacterAbility("Malpractice_1_A").visuals,
                        animationTarget = Slots.Self,
                    };
                }
                return _fireVeins;
            }
        }
        static Ability _fireDeath;
        public static Ability FireDeath
        {
            get
            {
                if (_fireDeath == null)
                {
                    _fireDeath = new Ability()
                    {
                        name = "Flaming Death",
                        description = "Instantly kill this enemy. Inflict 1-2 Fire on every party member position. This ability can only be selected if this enemy is below it's original health value.",
                        priority = 10,
                        rarity = 10,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<DirectDeathEffect>(), 1, IntentType.Damage_Death, Slots.Self),
                            new Effect(ScriptableObject.CreateInstance<FireUpToPlusOneEffect>(), 1, IntentType.Field_Fire, Slots.SlotTarget(new int[]{-4, -3, -2, -1, 0, 1, 2, 3, 4 }, false)),
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Ash"),
                        animationTarget = Slots.Self,
                    };
                }
                return _fireDeath;
            }
        }
        static Ability _pointyBeak;
        public static Ability PointyBeak
        {
            get
            {
                if (_pointyBeak == null)
                {
                    _pointyBeak = new Ability()
                    {
                        name = "Pointed Beak",
                        description = "Deal a Painful amount of damage to the Opposing party member, this attack is fully blocked by Shields.",
                        rarity = 6,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<DamageShieldBlockedEffect>(), 4, IntentType.Damage_3_6, Slots.Front),
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Needle"),
                        animationTarget = Slots.Front,
                    };
                }
                return _pointyBeak;
            }
        }
        static Ability _scry;
        public static Ability Scry
        {
            get
            {
                if (_scry == null)
                {
                    _scry = new Ability()
                    {
                        name = "Scry",
                        description = "Inflict 2 Frail on the Left and Right party members.",
                        rarity = 3,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ApplyFrailEffect>(), 2, IntentType.Status_Frail, Slots.LeftRight),
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Gaze"),
                        animationTarget = Slots.LeftRight,
                    };
                }
                return _scry;
            }
        }
        static Ability _lightScratch;
        public static Ability LightScratch
        {
            get
            {
                if (_lightScratch == null)
                {
                    _lightScratch = new Ability()
                    {
                        name = "Light Scratches",
                        description = "Remove all Shield from the Opposing position, then move to the Left or Right.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<RemoveAllShieldsEffect>(), 1, IntentType.Rem_Field_Shield, Slots.Front),
                            new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, IntentType.Swap_Sides, Slots.Self)
                        },
                        visuals = LoadedAssetsHandler.GetEnemyAbility("Talons_A").visuals,
                        animationTarget = Slots.Front,
                    };
                }
                return _lightScratch;
            }
        }
        static Ability _stare;
        public static Ability Stare
        {
            get
            {
                if (_stare == null)
                {
                    _stare = new Ability()
                    {
                        name = "Hollow Gaze",
                        description = "This enemy wastes its turn staring at you. 50% chance to produce 1 Yellow Pigment.",
                        rarity = 1,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<WasteTimeEffect>(), 2, IntentType.Misc, Slots.Self),
                            new Effect(BasicEffects.GenPigment(Pigments.Yellow), 1, IntentType.Mana_Generate, Slots.Self, Conditions.Chance(50))
                        },
                        visuals = null,
                        animationTarget = Slots.Self,
                    };
                }
                return _stare;
            }
        }
        static Ability _statue;
        public static Ability Statue
        {
            get
            {
                if (_statue == null)
                {
                    _statue = new Ability()
                    {
                        name = "Statue",
                        description = "Apply 1 Constricted to this position. Apply 1 Shield to this position.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ApplyConstrictedSlotEffect>(), 1, IntentType.Field_Constricted, Slots.Self),
                            new Effect(ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 1, IntentType.Field_Shield, Slots.Self)
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Cube"),
                        animationTarget = Slots.Self,
                    };
                }
                return _statue;
            }
        }
        static Ability _hellScreech;
        public static Ability HellScreech
        {
            get
            {
                if (_hellScreech == null)
                {
                    _hellScreech = new Ability()
                    {
                        name = "Hell Screech",
                        description = "Deal a Little bit of damage and inflict 2 Ruptured on every party member.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 2, IntentType.Damage_1_2, Targetting.AllEnemy),
                            new Effect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 2, IntentType.Status_Ruptured, Targetting.AllEnemy)
                        },
                        visuals = LoadedAssetsHandler.GetEnemyAbility("Rupture_A").visuals,
                        animationTarget = Targetting.AllEnemy,
                    };
                }
                return _hellScreech;
            }
        }
        static Ability _windle1;
        public static Ability Windle1
        {
            get
            {
                if (_windle1 == null)
                {
                    CopyAndSpawnCustomCharacterAnywhereLikeCasterEffect win = ScriptableObject.CreateInstance<CopyAndSpawnCustomCharacterAnywhereLikeCasterEffect>();
                    win._characterCopy = "Windle_CH";
                    win._rank = 0;
                    win._permanentSpawn = true;
                    win._extraModifiers = new WearableStaticModifierSetterSO[0];
                    win._usePreviousAsHealth = true;
                    _windle1 = new Ability()
                    {
                        name = "Whime",
                        description = "If there is space, this enemy joins the party. Otherwise, this enemy does nothing. \n(This enemy does not intend to help.)",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(win, 1, IntentType.Other_Spawn, Slots.Self, ScriptableObject.CreateInstance<HasSpaceCondition>()),
                            new Effect(ScriptableObject.CreateInstance<FleeTargetEffect>(), 1, Intents.Flee, Slots.Self, BasicEffects.DidThat(true))
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Keyhole"),
                        animationTarget = Slots.Self,
                    };
                }
                return _windle1;
            }
        }
        static Ability _windle2;
        public static Ability Windle2
        {
            get
            {
                if (_windle2 == null)
                {
                    CopyAndSpawnCustomCharacterAnywhereLikeCasterEffect win = ScriptableObject.CreateInstance<CopyAndSpawnCustomCharacterAnywhereLikeCasterEffect>();
                    win._characterCopy = "Windle_CH";
                    win._rank = 1;
                    win._permanentSpawn = true;
                    win._extraModifiers = new WearableStaticModifierSetterSO[0];
                    _windle2 = new Ability()
                    {
                        name = "Whime",
                        description = "If there is space, this enemy joins the party. Otherwise, this enemy does nothing. \n(This enemy does not intend to help.)",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(win, 1, IntentType.Other_Spawn, Slots.Self, ScriptableObject.CreateInstance<HasSpaceCondition>()),
                            new Effect(ScriptableObject.CreateInstance<FleeTargetEffect>(), 1, Intents.Flee, Slots.Self, BasicEffects.DidThat(true))
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Keyhole"),
                        animationTarget = Slots.Self,
                    };
                }
                return _windle2;
            }
        }
        static Ability _windle3;
        public static Ability Windle3
        {
            get
            {
                if (_windle3 == null)
                {
                    CopyAndSpawnCustomCharacterAnywhereLikeCasterEffect win = ScriptableObject.CreateInstance<CopyAndSpawnCustomCharacterAnywhereLikeCasterEffect>();
                    win._characterCopy = "Windle_CH";
                    win._rank = 2;
                    win._permanentSpawn = true;
                    win._extraModifiers = new WearableStaticModifierSetterSO[0];
                    _windle3 = new Ability()
                    {
                        name = "Whime",
                        description = "If there is space, this enemy joins the party. Otherwise, this enemy does nothing. \n(This enemy does not intend to help.)",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(win, 1, IntentType.Other_Spawn, Slots.Self, ScriptableObject.CreateInstance<HasSpaceCondition>()),
                            new Effect(ScriptableObject.CreateInstance<FleeTargetEffect>(), 1, Intents.Flee, Slots.Self, BasicEffects.DidThat(true))
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Keyhole"),
                        animationTarget = Slots.Self,
                    };
                }
                return _windle3;
            }
        }
        static Ability _radiation;
        public static Ability Radiation
        {
            get
            {
                if (_radiation == null)
                {
                    _radiation = new Ability()
                    {
                        name = "Radiation",
                        description = "Inflict 1 Scar on every party member.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ApplyScarsEffect>(), 1, IntentType.Status_Scars, Targetting.AllEnemy),
                        },
                        visuals = LoadedAssetsHandler.GetEnemyAbility("Crush_A").visuals,
                        animationTarget = Slots.Self,
                    };
                }
                return _radiation;
            }
        }
        static Ability _flare;
        public static Ability Flare
        {
            get
            {
                if (_flare == null)
                {
                    _flare = new Ability()
                    {
                        name = "Solar Flare",
                        description = "Generate 1 pigment of every enemy's health color.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(BasicEffects.Empty, 1, IntentType.Misc, Targetting.AllAlly),
                            new Effect(ScriptableObject.CreateInstance<GeneratePigmentAllEnemies>(), 1, IntentType.Mana_Generate, Slots.Self),
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Wheel"),
                        animationTarget = Slots.Self,
                    };
                }
                return _flare;
            }
        }
        static Ability _gravity;
        public static Ability Gravity
        {
            get
            {
                if (_gravity == null)
                {
                    _gravity = new Ability()
                    {
                        name = "Gravity",
                        description = "Move All party members towards this enemy. Permenantly Rupture the Opposing party member.\nIf the Opposing party member already had Ruptured, Curse them.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(BasicEffects.GoRight, 1, IntentType.Swap_Right, Slots.SlotTarget(new int[]{-1, -2, -3, -4}, false)),
                            new Effect(BasicEffects.GoLeft, 1, IntentType.Swap_Left, Slots.SlotTarget(new int[]{1, 2, 3, 4}, false)),
                            new Effect(ScriptableObject.CreateInstance<ApplyPermenantRupturedCustomEffect>(), 1, IntentType.Status_Ruptured, Slots.Front),
                            new Effect(ScriptableObject.CreateInstance<ApplyCursedEffect>(), 1, IntentType.Status_Cursed, Slots.Front, BasicEffects.DidThat(false))
                        },
                        visuals = LoadedAssetsHandler.GetEnemyAbility("Crush_A").visuals,
                        animationTarget = Slots.Self,
                    };
                }
                return _gravity;
            }
        }
        static Ability _transPain;
        public static Ability TransPain
        {
            get
            {
                if (_transPain == null)
                {
                    _transPain = new Ability()
                    {
                        name = "Transmit Pain",
                        description = "Trigger the Linked damage action for 3 damage.",
                        rarity = 1,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<LinkedDamageEffect>(), 3, IntentType.Status_Linked, Slots.Self)
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Ribbon"),
                        animationTarget = Slots.Self,
                    };
                }
                return _transPain;
            }
        }
        static Ability _transSen;
        public static Ability TransSen
        {
            get
            {
                if (_transSen == null)
                {
                    new CustomIntentInfo("WitheringIcon", (IntentType)3399787, Passives.Withering.passiveIcon, IntentType.Misc);
                    _transSen = new Ability()
                    {
                        name = "Transmit Sensory",
                        description = "Attempt to spawn a copy of this enemy. If successful, add Withering as a passive to this enemy. \nThis move does nothing if this enemy has Withering as a passive.",
                        rarity = 100,
                        effects = new Effect[]
                        {
                            new Effect(BasicEffects.Empty, 0, IntentType.Other_Spawn, Slots.Self),
                            new Effect(BasicEffects.AddPassive(Passives.Withering), 1, CustomIntentIconSystem.GetIntent("WitheringIcon"), Slots.Self, ScriptableObject.CreateInstance<EmptyEnemySpaceNoWitheringEffectCondition>()),
                            new Effect(ScriptableObject.CreateInstance<SpawnEnemyCopySelfEffect>(), 1, null, Slots.Self, BasicEffects.DidThat(true))
                        },
                        visuals = LoadedAssetsHandler.GetEnemyAbility("Sob_A").visuals,
                        animationTarget = Slots.Self,
                    };
                }
                return _transSen;
            }
        }
        static Ability _transEmo;
        public static Ability TransEmo
        {
            get
            {
                if (_transEmo == null)
                {
                    _transEmo = new Ability()
                    {
                        name = "Transmit Emotion",
                        description = "Deal a Little bit of Shield-Ignoring damage to this enemy.",
                        rarity = 200,
                        effects = new Effect[]
                        {
                            new Effect(BasicEffects.ShieldPierce, 2, IntentType.Damage_1_2, Slots.Self)
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Rose"),
                        animationTarget = Slots.Self,
                    };
                }
                return _transEmo;
            }
        }
        static Ability _transHung;
        public static Ability TransHung
        {
            get
            {
                if (_transHung == null)
                {
                    _transHung = new Ability()
                    {
                        name = "Transmit Hunger",
                        description = "Deal a Painful amount of damage and inflict 6 Linked to the Left and Right party members.",
                        rarity = 100,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 3, IntentType.Damage_3_6, Slots.LeftRight),
                            new Effect(ScriptableObject.CreateInstance<ApplyLinkedEffect>(), 6, IntentType.Status_Linked, Slots.LeftRight)
                        },
                        visuals = LoadedAssetsHandler.GetEnemyAbility("Chomp_A").visuals,
                        animationTarget = Slots.LeftRight,
                    };
                }
                return _transHung;
            }
        }
        static Ability _hide;
        public static Ability Hide
        {
            get
            {
                if (_hide == null)
                {
                    MultiPreviousEffectCondition m = ScriptableObject.CreateInstance<MultiPreviousEffectCondition>();
                    m.previousAmount = new int[] { 2, 5 };
                    m.wasSuccessful = new bool[] { false, false };
                    _hide = new Ability()
                    {
                        name = "Hide",
                        description = "Move to the Left or Right, and deal a Little damage to the Left or Right enemy, respectively. \nDeal a Painful amount of damage to the Opposing party member and move them to the Left or Right.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(BasicEffects.Empty, 1, IntentType.Swap_Sides, Slots.Self),
                            new Effect(BasicEffects.Empty, 1, IntentType.Damage_1_2, Slots.Sides, Conditions.Chance(50)),
                            new Effect(BasicEffects.GoLeft, 1, null, Slots.Self, BasicEffects.DidThat(true)),
                            new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 2, null, Slots.SlotTarget(new int[]{-1}, true), BasicEffects.DidThat(true)),
                            new Effect(BasicEffects.GoRight, 1, null, Slots.Self, BasicEffects.DidThat(false, 2)),
                            new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 2, null, Slots.SlotTarget(new int[]{1 }, true), BasicEffects.DidThat(true)),
                            new Effect(BasicEffects.GoLeft, 1, null, Slots.Self, m),
                            new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 2, null, Slots.SlotTarget(new int[]{-1 }, true), BasicEffects.DidThat(true)),
                            new Effect(BasicEffects.GetVisuals("Salt/Four", true, Slots.Front), 1, null, Slots.Self),
                            new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 6, IntentType.Damage_3_6, Slots.Front),
                            new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, IntentType.Swap_Sides, Slots.Front),
                        },
                        visuals = null,
                        animationTarget = Slots.Self,
                    };
                }
                return _hide;
            }
        }
        static Ability _seek;
        public static Ability Seek
        {
            get
            {
                if (_seek == null)
                {
                    AnimationVisualsEffect a = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
                    a._animationTarget = Slots.Front;
                    a._visuals = LoadedAssetsHandler.GetEnemy("UnfinishedHeir_BOSS").abilities[2].ability.visuals;
                    _seek = new Ability()
                    {
                        name = "Seek",
                        description = "Move to the Left or Right 3 times. Deal an Agonizing amount of damage to the Opposing party member and inflict 3 Ruptured on them.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, IntentType.Swap_Sides, Slots.Self),
                            new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, IntentType.Swap_Sides, Slots.Self),
                            new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, IntentType.Swap_Sides, Slots.Self),
                            new Effect(a, 1, null, Slots.Self),
                            new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 10, IntentType.Damage_7_10, Slots.Front),
                            new Effect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 3, IntentType.Status_Ruptured, Slots.Front)
                        },
                        visuals = null,
                        animationTarget = Slots.Self,
                    };
                }
                return _seek;
            }
        }
        static Ability _stay;
        public static Ability Stay
        {
            get
            {
                if (_stay == null)
                {
                    AnimationVisualsEffect a = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
                    a._animationTarget = Slots.Front;
                    a._visuals = LoadedAssetsHandler.GetEnemy("OsmanSinnoks_BOSS").abilities[0].ability.visuals;
                    _stay = new Ability()
                    {
                        name = "Stay",
                        description = "Move to the Left or Right. Inflict 3 Ruptured, 3 Constricted, and deal a Painful amount of damage to the Opposing party member. \nMove to the Left or Right again.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, IntentType.Swap_Sides, Slots.Self),
                            new Effect(a, 1, null, Slots.Self),
                            new Effect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 3, IntentType.Status_Ruptured, Slots.Front),
                            new Effect(ScriptableObject.CreateInstance<ApplyConstrictedSlotEffect>(), 3, IntentType.Field_Constricted, Slots.Front),
                            new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 5, IntentType.Damage_3_6, Slots.Front),
                            new Effect(CasterSubActionEffect.Create(new Effect[]
                            {
                                new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, IntentType.Swap_Sides, Slots.Self),
                            }), 1, IntentType.Swap_Sides, Slots.Self),
                        },
                        visuals = null,
                        animationTarget = Slots.Self,
                    };
                }
                return _stay;
            }
        }
        static Ability _play;
        public static Ability Play
        {
            get
            {
                if (_play == null)
                {
                    _play = new Ability()
                    {
                        name = "Play!!",
                        description = "Move to the Left or Right. Deal a Painful amount of damage to the Opposing party member and a Little damage to the Left and Right enemies. \nMove to the Left or Right again. Deal a Painful amount of damage to the Opposing party member again and deal a Little damage to the Left and Right enemies again.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, IntentType.Swap_Sides, Slots.Self),
                            new Effect(BasicEffects.GetVisuals("Chomp_A", false, Slots.Front), 1, null, Slots.Self),
                            new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 4, IntentType.Damage_3_6, Slots.Front),
                            new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 2, IntentType.Damage_1_2, Slots.Sides),
                            new Effect(CasterSubActionEffect.Create(new Effect[]
                            {
                                new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, IntentType.Swap_Sides, Slots.Self),
                                new Effect(BasicEffects.GetVisuals("Chomp_A", false, Slots.Front), 1, null, Slots.Self),
                                new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 4, IntentType.Damage_3_6, Slots.Front),
                                new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 2, IntentType.Damage_1_2, Slots.Sides),
                            }), 1, IntentType.Swap_Sides, Slots.Self),
                            new Effect(BasicEffects.Empty, 1, IntentType.Damage_3_6, Slots.Front),
                            new Effect(BasicEffects.Empty, 1, IntentType.Damage_1_2, Slots.Sides)
                        },
                        visuals = null,
                        animationTarget = Slots.Self,
                    };
                }
                return _play;
            }
        }
        static Ability _salivate;
        public static Ability Salivate
        {
            get
            {
                if (_salivate == null)
                {
                    _salivate = new Ability()
                    {
                        name = "Salivate",
                        description = "Inflict 3 Oil-Slicked on the Left, Right, and Opposing party members,",
                        rarity = 1,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ApplyOilSlickedEffect>(), 3, IntentType.Status_OilSlicked, Slots.FrontLeftRight)
                        },
                        visuals = LoadedAssetsHandler.GetEnemyAbility("Flood_A").visuals,
                        animationTarget = Slots.FrontLeftRight,
                    };
                }
                return _salivate;
            }
        }
        static Ability _underwater;
        public static Ability Underwater
        {
            get
            {
                if (_underwater == null)
                {
                    _underwater = new Ability()
                    {
                        name = "Hold Me Underwater",
                        description = "Inflict 2 Constricted and 3 Deep Water on the Opposing position.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ApplyConstrictedSlotEffect>(), 2, IntentType.Field_Constricted, Slots.Front),
                            new Effect(ScriptableObject.CreateInstance<ApplyWaterSlotEffect>(), 3, CustomIntentIconSystem.GetIntent("Water"), Slots.Front)
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Claws"),
                        animationTarget = Slots.Front,
                    };
                }
                return _underwater;
            }
        }
        static Ability _lostLove;
        public static Ability LostLove
        {
            get
            {
                if (_lostLove == null)
                {
                    _lostLove = new Ability()
                    {
                        name = "Lost without Your Love",
                        description = "Inflict 4 Deep Water on the Opposing position. \nIf there is no Opposing party member, move to the Left or Right, then apply 3 Deep Water on self.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<IsUnitEffect>(), 0, CustomIntentIconSystem.GetIntent("Water"), Slots.Front),
                            new Effect(BasicEffects.GetVisuals("Mend_1_A", true, Slots.Front), 2, IntentType.Misc_Hidden, Slots.Front, BasicEffects.DidThat(true)),
                            new Effect(ScriptableObject.CreateInstance<ApplyWaterSlotEffect>(), 4, null, Slots.Front),
                            new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, IntentType.Swap_Sides, Slots.Self, BasicEffects.DidThat(false, 3)),
                            new Effect(BasicEffects.GetVisuals("Salt/Wheel", true, Slots.Self), 2, null, Slots.Self, BasicEffects.DidThat(false, 4)),
                            new Effect(ScriptableObject.CreateInstance<ApplyWaterSlotEffect>(), 3, GetIntent("Water"), Slots.Self, BasicEffects.DidThat(false, 5))
                        },
                        visuals = null,
                        animationTarget = Slots.Self,
                    };
                }
                return _lostLove;
            }
        }
        static Ability _tailHead;
        public static Ability TailHead
        {
            get
            {
                if (_tailHead == null)
                {
                    new CustomIntentInfo("RemWater", (IntentType)7378610, ResourceLoader.LoadSprite("WaterRemove.png"), IntentType.Rem_Status_OilSlicked);
                    _tailHead = new Ability()
                    {
                        name = "Tail to Head",
                        description = "Remove all Deep Water from the Opposing position. Inflict half the amount to every other party member tile.\nMove the Opposing party member to the Left or Right.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<RemoveAllWaterEffect>(), 1, GetIntent("RemWater"), Slots.Front),
                            new Effect(ScriptableObject.CreateInstance<ApplyWaterLastExitEffect>(), 2, CustomIntentIconSystem.GetIntent("Water"), Slots.SlotTarget(new int[]{4, 3, 2, 1, -1, -2, -3, -4}, false)),
                            new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, IntentType.Swap_Sides, Slots.Front)
                        },
                        visuals = LoadedAssetsHandler.GetEnemy("Ouroborus_Tail_BOSS").abilities[0].ability.visuals,
                        animationTarget = Slots.Front,
                    };
                }
                return _tailHead;
            }
        }
        static Ability _slop;
        public static Ability Slop
        {
            get
            {
                if (_slop == null)
                {
                    PerformRandomEffectsAmongEffects e = ScriptableObject.CreateInstance<PerformRandomEffectsAmongEffects>();
                    e.List = new Dictionary<string, string>();
                    e.List.Add(nameof(ApplyShieldSlotEffect), "");
                    e.List.Add(nameof(ApplyFireSlotEffect), "");
                    e.List.Add(nameof(ApplyConstrictedSlotEffect), "");
                    e.List.Add(nameof(ApplyMoldSlotEffect), nameof(Hawthorne));
                    e.List.Add(nameof(ApplyRootsSlotEffect), nameof(Hawthorne));
                    e.List.Add(nameof(ApplyWaterSlotEffect), nameof(Hawthorne));
                    e.List.Add(nameof(ApplySlipSlotEffect), nameof(Hawthorne));
                    e.List.Add("ApplyBubblesEffect", "TevlevsRapscallions");
                    e.List.Add("ApplyAbsField", "ZLDCHPak");
                    e.List.Add("ApplyDeepFrozenSlotEffect", "MizerFool.VladEffects");
                    e.List.Add("ApplySpikesSlotEffect", "MFoolModOne");
                    e.List.Add("ApplyFumesSlotEffect", "CrayolapedeModinreallife.AbilityEffects");
                    e.Setup();
                    e.UsePreviousExitValueForNewEntry = true;
                    _slop = new Ability()
                    {
                        name = "Slop",
                        description = "Inflict 2 stacks of a completely random Field Effect on the Opposing position and on self. Move to the Left or Right.",
                        rarity = 12,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 2, null, Slots.Self),
                            new Effect(e, 1, IntentType.Misc_Hidden, Slots.Front),
                            new Effect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 2, null, Slots.Self),
                            new Effect(e, 1, IntentType.Misc_Hidden, Slots.Self),
                            new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, IntentType.Swap_Sides, Slots.Self)
                        },
                        visuals = LoadedAssetsHandler.GetEnemyAbility("Flood_A").visuals,
                        animationTarget = Slots.Front,
                    };
                }
                return _slop;
            }
        }
        static Ability _pingo;
        public static Ability Pingo
        {
            get
            {
                if (_pingo == null)
                {
                    _pingo = new Ability()
                    {
                        name = "Pingo",
                        description = "Inflict 1 Parasitism on the Opposing party member. If successful, instantly kill this enemy.",
                        rarity = 2,
                        priority = -5,
                        effects = new Effect[]
                        {
                            new Effect(ParasiteEffection.apply, 1, IntentType.Misc_Additional, Slots.Front),
                            new Effect(ScriptableObject.CreateInstance<DirectDeathEffect>(), 1, IntentType.Damage_Death, Slots.Self, BasicEffects.DidThat(true))
                        },
                        visuals = LoadedAssetsHandler.GetCharacterAbility("Weave_1_A").visuals,
                        animationTarget = Slots.Front,
                    };
                }
                return _pingo;
            }
        }
        static Ability _skitter;
        public static Ability Skitter
        {
            get
            {
                if (_skitter == null)
                {
                    _skitter = new Ability()
                    {
                        name = "Skitter",
                        description = "Move to the Left or Right 5 times.",
                        rarity = 2,
                        priority = 5,
                        effects = new Effect[]
                        {
                            new Effect(BasicEffects.PlaySound(LoadedAssetsHandler.GetEnemyBundle("H_Zone03_SkinningHomunculus_Medium_EnemyBundle")._roarReference.roarEvent), 1, null, Slots.Self),
                            new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, IntentType.Swap_Sides, Slots.Self),
                            new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, IntentType.Swap_Sides, Slots.Self),
                            new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, IntentType.Swap_Sides, Slots.Self),
                            new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, IntentType.Swap_Sides, Slots.Self),
                            new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, IntentType.Swap_Sides, Slots.Self),
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Notif"),
                        animationTarget = Slots.Self,
                    };
                }
                return _skitter;
            }
        }
        static Ability _shockTherapy;
        public static Ability ShockTherapy
        {
            get
            {
                if (_shockTherapy == null)
                {
                    _shockTherapy = new Ability()
                    {
                        name = "Shock Therapy",
                        description = "Transform the Opposing party member into a random party member. \nIf the Opposing party member has already been transformed by this ability, lower their level and deal a Painful amount of damage to them.",
                        rarity = 10,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ShockTherapyEffect>(), 3, IntentType.Misc, Slots.Front),
                            new Effect(BasicEffects.Empty, 3, IntentType.Damage_3_6, Slots.Front)
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Zap"),
                        animationTarget = Slots.Front,
                    };
                }
                return _shockTherapy;
            }
        }
        static Ability _illuminate;
        public static Ability Illuminate
        {
            get
            {
                if (_illuminate == null)
                {
                    _illuminate = new Ability()
                    {
                        name = "Illuminate",
                        description = "Remove all Status Effects from the Opposing party member. If no Status Effects were removed, inflict 3 Stunned and deal a Painful amount of damage to them.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<RemoveAllStatusEffectsEffect>(), 3, IntentType.Misc, Slots.Front),
                            new Effect(ScriptableObject.CreateInstance<ApplyStunnedEffect>(), 3, (IntentType)988896, Slots.Front, BasicEffects.DidThat(false)),
                            new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 6, IntentType.Damage_3_6, Slots.Front, BasicEffects.DidThat(false, 2))
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Gaze"),
                        animationTarget = Slots.Front,
                    };
                }
                return _illuminate;
            }
        }
        static Ability _replacement;
        public static Ability Replacement
        {
            get
            {
                if (_replacement == null)
                {
                    _replacement = new Ability()
                    {
                        name = "Replacement",
                        description = "Apply 3 Power on the Opposing party member. \nIf the Opposing party member has killed during this combat, deal an Agonizing amount of damage to them.",
                        rarity = 3,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ApplyPowerEffect>(), 3, (IntentType)987895, Slots.Front),
                            new Effect(ScriptableObject.CreateInstance<ReplacementDamageEffect>(), 8, IntentType.Damage_7_10, Slots.Front)
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Crush"),
                        animationTarget = Slots.Front,
                    };
                }
                return _replacement;
            }
        }
        static Ability _burp;
        public static Ability Burp
        {
            get
            {
                if (_burp == null)
                {
                    _burp = new Ability()
                    {
                        name = "Burp",
                        description = "Produce 2 Yellow Pigment.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(BasicEffects.GenPigment(Pigments.Yellow), 2, IntentType.Mana_Generate, Slots.Self)
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Pop"),
                        animationTarget = Slots.Self,
                    };
                }
                return _burp;
            }
        }
        static Ability _flail;
        public static Ability Flail
        {
            get
            {
                if (_flail == null)
                {
                    _flail = new Ability()
                    {
                        name = "Flail",
                        description = "Move to the Left or Right.\nMove the Opposing party member to the Left or Right.",
                        rarity = 5,
                        priority = -3,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, IntentType.Swap_Sides, Slots.Self),
                            new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, IntentType.Swap_Sides, Slots.Front)
                        },
                        visuals = LoadedAssetsHandler.GetEnemyAbility("Wriggle_A").visuals,
                        animationTarget = Slots.Self,
                    };
                }
                return _flail;
            }
        }
        static Ability _swallow;
        public static Ability Swallow
        {
            get
            {
                if (_swallow == null)
                {
                    _swallow = new Ability()
                    {
                        name = "Swallow",
                        description = "Deal a Painful amount of damage and inflict 4 Deep Water on the Opposing position.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 6, IntentType.Damage_3_6, Slots.Front),
                            new Effect(ScriptableObject.CreateInstance<ApplyWaterSlotEffect>(), 4, GetIntent("Water"), Slots.Front)
                        },
                        visuals = LoadedAssetsHandler.GetEnemyAbility("Devour_A").visuals,
                        animationTarget = Slots.Front,
                    };
                }
                return _swallow;
            }
        }
        static Ability _lubricate;
        public static Ability Lubricate
        {
            get
            {
                if (_lubricate == null)
                {
                    _lubricate = new Ability()
                    {
                        name = "Lubricate",
                        description = "Inflict 4 Oil-Slicked and 1 Scar on this enemy. Apply 10 Shield to self.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ApplyOilSlickedEffect>(), 4, IntentType.Status_OilSlicked, Slots.Self),
                            new Effect(ScriptableObject.CreateInstance<ApplyScarsEffect>(), 1, IntentType.Status_Scars, Slots.Self),
                            new Effect(ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 10, IntentType.Field_Shield, Slots.Self)
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Swirl"),
                        animationTarget = Slots.Self,
                    };
                }
                return _lubricate;
            }
        }
        static Ability _suffocate;
        public static Ability Suffocate
        {
            get
            {
                if (_suffocate == null)
                {
                    _suffocate = new Ability()
                    {
                        name = "Suffocate",
                        description = "Inflict 1 Scar on this enemy. Deal a Little damage to this enemy, this damage ignores Shield.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ApplyScarsEffect>(), 1, IntentType.Status_Scars, Slots.Self),
                            new Effect(BasicEffects.ShieldPierce, 2, IntentType.Damage_1_2, Slots.Self)
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Ribbon"),
                        animationTarget = Slots.Self,
                    };
                }
                return _suffocate;
            }
        }
        static Ability _thrash;
        public static Ability Thrash
        {
            get
            {
                if (_thrash == null)
                {
                    _thrash = new Ability()
                    {
                        name = "Thrash",
                        description = "Deal a Little damage to the Opposing party member and a Little damage to this enemy.",
                        rarity = 12,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 2, IntentType.Damage_1_2, Slots.Front),
                            new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 2, IntentType.Damage_1_2, Slots.Self)
                        },
                        visuals = LoadedAssetsHandler.GetEnemyAbility("Crush_A").visuals,
                        animationTarget = Slots.Self,
                    };
                }
                return _thrash;
            }
        }

    }

    public static class BasicEffects
    {
        public static DamageEffect Indirect
        {
            get
            {
                DamageEffect ret = ScriptableObject.CreateInstance<DamageEffect>();
                ret._indirect = true;
                return ret;
            }
        }
        public static DamageEffect ShieldPierce
        {
            get
            {
                DamageEffect ret = ScriptableObject.CreateInstance<DamageEffect>();
                ret._ignoreShield = true;
                return ret;
            }
        }
        public static DamageEffect ExitDamage
        {
            get
            {
                DamageEffect ret = ScriptableObject.CreateInstance<DamageEffect>();
                ret._usePreviousExitValue = true;
                return ret;
            }
        }
        public static HealEffect ExitHeal
        {
            get
            {
                HealEffect ret = ScriptableObject.CreateInstance<HealEffect>();
                ret.usePreviousExitValue = true;
                return ret;
            }
        }
        public static SwapToOneSideEffect GoLeft
        {
            get
            {
                SwapToOneSideEffect goLeft = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
                goLeft._swapRight = false;
                return goLeft;
            }
        }
        public static SwapToOneSideEffect GoRight
        {
            get
            {
                SwapToOneSideEffect goLeft = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
                goLeft._swapRight = true;
                return goLeft;
            }
        }
        public static ExitValueSetterEffect Empty
        {
            get
            {
                return ScriptableObject.CreateInstance<ExitValueSetterEffect>();
            }
        }
        public static AnimationVisualsEffect GetVisuals(string name, bool characterAbil, BaseCombatTargettingSO target)
        {
            AnimationVisualsEffect ret = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            ret._animationTarget = target;
            if (CustomVisuals.Visuals != null && CustomVisuals.Visuals.ContainsKey(name))
            {
                ret._visuals = CustomVisuals.GetVisuals(name);
                return ret;
            }
            if (characterAbil) ret._visuals = LoadedAssetsHandler.GetCharacterAbility(name).visuals;
            else ret._visuals = LoadedAssetsHandler.GetEnemyAbility(name).visuals;
            return ret;
        }
        public static PlaySoundEffect PlaySound(string sound)
        {
            PlaySoundEffect ret = ScriptableObject.CreateInstance<PlaySoundEffect>();
            ret.Audio = sound;
            return ret;
        }
        public static PreviousEffectCondition DidThat(bool didit, int prev = 1)
        {
            PreviousEffectCondition ret = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            ret.previousAmount = prev;
            ret.wasSuccessful = didit;
            return ret;
        }
        public static DirectDeathEffect Die(bool obliterate = false)
        {
            DirectDeathEffect ret = ScriptableObject.CreateInstance<DirectDeathEffect>();
            ret._obliterationDeath = obliterate;
            return ret;
        }
        public static CasterStoredValueChangeEffect ChangeValue(UnitStoredValueNames value, bool increase)
        {
            CasterStoredValueChangeEffect ret = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
            ret._valueName = value;
            ret._increase = increase;
            ret._minimumValue = 0;
            return ret;
        }
        public static GenerateColorManaEffect GenPigment(ManaColorSO color)
        {
            GenerateColorManaEffect ret = ScriptableObject.CreateInstance<GenerateColorManaEffect>();
            ret.mana = color;
            return ret;
        }
        public static ConsumeAllColorManaEffect RemPigment(ManaColorSO color)
        {
            ConsumeAllColorManaEffect ret = ScriptableObject.CreateInstance<ConsumeAllColorManaEffect>();
            ret._consumeMana = color;
            return ret;
        }
        public static AddPassiveEffect AddPassive(BasePassiveAbilitySO passive)
        {
            AddPassiveEffect ret = ScriptableObject.CreateInstance<AddPassiveEffect>();
            ret._passiveToAdd = passive;
            return ret;
        }
        public static CasterStoredValueSetEffect SetStoreValue(UnitStoredValueNames value)
        {
            CasterStoredValueSetEffect ret = ScriptableObject.CreateInstance<CasterStoredValueSetEffect>();
            ret._valueName = value;
            return ret;
        }
    }
    public static class Targetting
    {
        public static Targetting_ByUnit_Side AllEnemy
        {
            get
            {
                Targetting_ByUnit_Side allEnemy = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
                allEnemy.getAllies = false;
                allEnemy.getAllUnitSlots = false;
                return allEnemy;
            }
        }
        public static Targetting_ByUnit_Side AllAlly
        {
            get
            {
                Targetting_ByUnit_Side allEnemy = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
                allEnemy.getAllies = true;
                allEnemy.getAllUnitSlots = false;
                return allEnemy;
            }
        }
        public static Targetting_ByUnit_Side AllOtherAlly
        {
            get
            {
                Targetting_ByUnit_Side allEnemy = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
                allEnemy.getAllies = true;
                allEnemy.ignoreCastSlot = true;
                allEnemy.getAllUnitSlots = false;
                return allEnemy;
            }
        }
        public static TargettingByHealthUnits HighestEnemy
        {
            get
            {
                TargettingByHealthUnits highest = ScriptableObject.CreateInstance<TargettingByHealthUnits>();
                highest.Lowest = false;
                highest.getAllies = false;
                return highest;
            }
        }
        public static TargettingByHealthUnits LowestEnemy
        {
            get
            {
                TargettingByHealthUnits highest = ScriptableObject.CreateInstance<TargettingByHealthUnits>();
                highest.Lowest = true;
                highest.getAllies = false;
                return highest;
            }
        }
        public static TargettingByHealthUnits LowestOtherAlly
        {
            get
            {
                TargettingByHealthUnits highest = ScriptableObject.CreateInstance<TargettingByHealthUnits>();
                highest.Lowest = true;
                highest.getAllies = true;
                highest.ignoreCastSlot = true;
                return highest;
            }
        }
        public static Targetting_BySlot_Index AllSelfSlots
        {
            get
            {
                Targetting_BySlot_Index instance2 = ScriptableObject.CreateInstance<Targetting_BySlot_Index>();
                instance2.getAllies = true;
                instance2.allSelfSlots = true;
                instance2.slotPointerDirections = new int[1];
                return instance2;
            }
        }

        public static BaseCombatTargettingSO Closer(bool near, bool allies)
        {
            if (near)
            {
                TargettingClosestUnits closestAlly = ScriptableObject.CreateInstance<TargettingClosestUnits>();
                closestAlly.getAllies = allies;
                return closestAlly;
            }
            else
            {
                TargettingFarthestUnits closestAlly = ScriptableObject.CreateInstance<TargettingFarthestUnits>();
                closestAlly.getAllies = allies;
                return closestAlly;
            }
        }
        public static TargettingRandomUnit Random(bool getAlly)
        {
            TargettingRandomUnit ret = ScriptableObject.CreateInstance<TargettingRandomUnit>();
            ret.getAllies = getAlly;
            return ret;
        }
        public static Targetting_ByUnit_SideColor GetColors(ManaColorSO color, bool getAlly)
        {
            Targetting_ByUnit_SideColor ret = ScriptableObject.CreateInstance<Targetting_ByUnit_SideColor>();
            ret.getAllies = getAlly;
            ret.getAllUnitSlots = false;
            ret.Color = color;
            return ret;
        }
        public static ReverseTargetting Reverse(BaseCombatTargettingSO source)
        {
            ReverseTargetting ret = ScriptableObject.CreateInstance<ReverseTargetting>();
            ret.source = source;
            return ret;
        }
        public static BaseCombatTargettingSO Everything(bool allies)
        {
            return Slots.SlotTarget(new int[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 }, allies);
        }
    }
    public static class AbilityNameFix
    {
        public static CharacterAbility CharacterAbility(Func<Ability, CharacterAbility> orig, Ability self)
        {
            CharacterAbility ability = orig(self);
            ability.ability._abilityName = self.name;
            ability.ability._description = self.description;
            ability.ability.name = self.name;

            if (self.name == "Trolley")
            {
                List<IntentType> intents = new List<IntentType>();
                foreach (IntentTargetInfo info in ability.ability.intents)
                {
                    foreach (IntentType type in info.targetIntents) intents.Add(type);
                }
                IntentTargetInfo keep = ability.ability.intents[0];
                keep.targetIntents = intents.ToArray();
                ability.ability.intents = new IntentTargetInfo[] { keep };
            }

            AbilitySO storeval = AddStoredValue(ability.ability, self.name);
            ability.ability = storeval;
            return ability;
        }
        public static EnemyAbilityInfo EnemyAbility(Func<Ability, EnemyAbilityInfo> orig, Ability self)
        {
            EnemyAbilityInfo ability = orig(self);
            ability.ability._abilityName = self.name;
            ability.ability._description = self.description;
            ability.ability.name = self.name;

            if (self.name == Abili.Fall.name)
            {
                List<IntentType> intents = new List<IntentType>();
                foreach (IntentTargetInfo info in ability.ability.intents)
                {
                    foreach (IntentType type in info.targetIntents) intents.Add(type);
                }
                IntentTargetInfo keep = ability.ability.intents[0];
                keep.targetIntents = intents.ToArray();
                ability.ability.intents = new IntentTargetInfo[] { keep };
            }
            AbilitySO storeval = AddStoredValue(ability.ability, self.name);
            ability.ability = storeval;

            return ability;
        }
        public static AbilitySO AddStoredValue(AbilitySO ret, string name)
        {
            if (name == "Count") ret.specialStoredValue = (UnitStoredValueNames)544524;
            if (name == "Wait") ret.specialStoredValue = (UnitStoredValueNames)544525;
            return ret;
        }
        public static void Setup()
        {
            IDetour chara = new Hook(typeof(Ability).GetMethod(nameof(Ability.CharacterAbility), ~BindingFlags.Default), typeof(AbilityNameFix).GetMethod(nameof(CharacterAbility), ~BindingFlags.Default));
            IDetour enemy = new Hook(typeof(Ability).GetMethod(nameof(Ability.EnemyAbility), ~BindingFlags.Default), typeof(AbilityNameFix).GetMethod(nameof(EnemyAbility), ~BindingFlags.Default));
        }
    }
    
    public class TargettingUnitsEitherSide : BaseCombatTargettingSO
    {
        public bool getAllies;

        public bool right;

        public bool ignoreDirectNextAllyOnly = true;

        public override bool AreTargetAllies => getAllies;

        public override bool AreTargetSlots => false;

        Targetting_ByUnit_Side source = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();

        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            List<TargetSlotInfo> targets = new List<TargetSlotInfo>();
            source.getAllies = getAllies;
            source.getAllUnitSlots = false;
            source.ignoreCastSlot = true;
            TargetSlotInfo[] chumby = source.GetTargets(slots, casterSlotID, isCasterCharacter);
            foreach (TargetSlotInfo target in chumby)
            {
                if (right)
                {
                    if (target.SlotID <= casterSlotID || !target.HasUnit) continue;
                    if (getAllies)
                    {
                        if (!ignoreDirectNextAllyOnly || target.SlotID != casterSlotID + 1)
                        {
                            targets.Add(target);
                        }
                    }
                    else
                    {
                        targets.Add(target);
                    }
                }
                else
                {
                    if (target.SlotID >= casterSlotID || !target.HasUnit) continue;
                    if (getAllies)
                    {
                        if (!ignoreDirectNextAllyOnly || target.SlotID != casterSlotID - target.Unit.Size)
                        {
                            targets.Add(target);
                        }
                    }
                    else
                    {
                        targets.Add(target);
                    }
                }
            }
            if (!right) targets.Reverse();
            return targets.ToArray();
        }
    }
    public class CheckTargetHealthThenHealEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;

            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    if (target.Unit.HealthColor == caster.HealthColor)
                    {
                        exitAmount += caster.Heal(entryVariable, HealType.Heal, true);
                    }
                }
            }
            return exitAmount > 0;
        }
    }

    public class ConsumeCasterManaEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            ManaColorSO mana = caster.HealthColor;
            JumpAnimationInformation jumpInfo = stats.GenerateUnitJumpInformation(caster.ID, caster.IsUnitCharacter);
            string manaConsumedSound = stats.audioController.manaConsumedSound;
            exitAmount = stats.MainManaBar.ConsumeAmountMana(mana, entryVariable, jumpInfo, manaConsumedSound);
            return exitAmount > 0;
        }
    }
    public class StillCasterColorManaCondition : EffectConditionSO
    {
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            foreach (ManaBarSlot mana in CombatManager.Instance._stats.MainManaBar.ManaBarSlots)
            {
                if (!mana.IsEmpty && mana.ManaColor == caster.HealthColor) return true;
            }
            return false;
        }
    }

    public class RandomizeAllOverflowEffect : EffectSO
    {
        public ManaColorSO[] manaRandomOptions;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (manaRandomOptions == null || manaRandomOptions.Length <= 0) return false;
            if (stats.overflowMana.StoredSlots == null || stats.overflowMana.StoredSlots.Count <= 0) return false;
            List<ManaColorSO> ret = new List<ManaColorSO>();
            for (int i = 0; i < stats.overflowMana.StoredSlots.Count; i++)
            {
                ManaColorSO mana = stats.overflowMana.StoredSlots[i];
                ManaColorSO pick = manaRandomOptions[UnityEngine.Random.Range(0, manaRandomOptions.Length)];
                if (mana == pick)
                {
                    ret.Add(mana);
                    exitAmount++;
                    continue;
                }
                ret.Add(pick);
                exitAmount++;
            }
            stats.overflowMana.StoredSlots = ret;
            stats.combatUI._manaOverflow.StoredSlots = stats.overflowMana.StoredSlots;
            stats.combatUI._manaOverflow.UpdateExposedSlots();
            return exitAmount > 0;
        }
    }

    public class TargettingByHealthUnits : BaseCombatTargettingSO
    {
        public bool getAllies;

        public bool ignoreCastSlot = false;

        public override bool AreTargetAllies => getAllies;

        public override bool AreTargetSlots => false;

        public bool Lowest;

        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            List<TargetSlotInfo> targets = new List<TargetSlotInfo>();
            List<CombatSlot> opinion = new List<CombatSlot>();
            if ((isCasterCharacter && getAllies) || (!isCasterCharacter && !getAllies))
            {
                foreach (CombatSlot slot in slots.CharacterSlots)
                {
                    if ((slot.HasUnit) && (!ignoreCastSlot || casterSlotID != slot.SlotID))
                    {
                        if (opinion.Count <= 0)
                        {
                            opinion.Add(slot);
                        }
                        else if ((Lowest && slot.Unit.CurrentHealth < opinion[0].Unit.CurrentHealth) || (!Lowest && slot.Unit.CurrentHealth > opinion[0].Unit.CurrentHealth))
                        {
                            opinion.Clear();
                            opinion.Add(slot);
                        }
                        else if (slot.Unit.CurrentHealth == opinion[0].Unit.CurrentHealth)
                        {
                            bool flag = true;
                            foreach (CombatSlot slur in opinion) if (slur.Unit == slot.Unit) flag = false;
                            if (flag) opinion.Add(slot);
                        }
                    }
                }
            }
            else
            {
                foreach (CombatSlot slot in slots.EnemySlots)
                {
                    if ((slot.HasUnit) && (!ignoreCastSlot || casterSlotID != slot.Unit.SlotID))
                    {
                        if (opinion.Count <= 0)
                        {
                            opinion.Add(slot);
                        }
                        else if ((Lowest && slot.Unit.CurrentHealth < opinion[0].Unit.CurrentHealth) || (!Lowest && slot.Unit.CurrentHealth > opinion[0].Unit.CurrentHealth))
                        {
                            opinion.Clear();
                            opinion.Add(slot);
                        }
                        else if (slot.Unit.CurrentHealth == opinion[0].Unit.CurrentHealth)
                        {
                            bool flag = true;
                            foreach (CombatSlot slur in opinion) if (slur.Unit == slot.Unit) flag = false;
                            if (flag) opinion.Add(slot);
                        }
                    }
                }
            }
            foreach (CombatSlot slot in opinion)
            {
                targets.Add(slot.TargetSlotInformation);
            }
            return targets.ToArray();
        }
    }
    public class TargettingByHealthNotSkyloft : TargettingByHealthUnits
    {
        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            List<TargetSlotInfo> targets = new List<TargetSlotInfo>();
            List<CombatSlot> opinion = new List<CombatSlot>();
            if ((isCasterCharacter && getAllies) || (!isCasterCharacter && !getAllies))
            {
                foreach (CombatSlot slot in slots.CharacterSlots)
                {
                    if ((slot.HasUnit) && (!ignoreCastSlot || casterSlotID != slot.SlotID))
                    {
                        if (opinion.Count <= 0)
                        {
                            opinion.Add(slot);
                        }
                        else if ((Lowest && slot.Unit.CurrentHealth < opinion[0].Unit.CurrentHealth) || (!Lowest && slot.Unit.CurrentHealth > opinion[0].Unit.CurrentHealth))
                        {
                            opinion.Clear();
                            opinion.Add(slot);
                        }
                        else if (slot.Unit.CurrentHealth == opinion[0].Unit.CurrentHealth)
                        {
                            bool flag = true;
                            foreach (CombatSlot slur in opinion) if (slur.Unit == slot.Unit) flag = false;
                            if (flag) opinion.Add(slot);
                        }
                    }
                }
            }
            else
            {
                foreach (CombatSlot slot in slots.EnemySlots)
                {
                    if ((slot.HasUnit) && (!ignoreCastSlot || casterSlotID != slot.Unit.SlotID) && slot.Unit is EnemyCombat Enemy && Check.EnemyExist("Skyloft_EN") && Enemy.Enemy != LoadedAssetsHandler.GetEnemy("Skyloft_EN"))
                    {
                        if (opinion.Count <= 0)
                        {
                            opinion.Add(slot);
                        }
                        else if ((Lowest && slot.Unit.CurrentHealth < opinion[0].Unit.CurrentHealth) || (!Lowest && slot.Unit.CurrentHealth > opinion[0].Unit.CurrentHealth))
                        {
                            opinion.Clear();
                            opinion.Add(slot);
                        }
                        else if (slot.Unit.CurrentHealth == opinion[0].Unit.CurrentHealth)
                        {
                            bool flag = true;
                            foreach (CombatSlot slur in opinion) if (slur.Unit == slot.Unit) flag = false;
                            if (flag) opinion.Add(slot);
                        }
                    }
                }
            }
            foreach (CombatSlot slot in opinion)
            {
                targets.Add(slot.TargetSlotInformation);
            }
            return targets.ToArray();
        }
    }

    public class SinkMovementEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            TargettingUnitsEitherSide left = ScriptableObject.CreateInstance<TargettingUnitsEitherSide>();
            left.right = false;
            left.getAllies = false;
            TargettingUnitsEitherSide right = ScriptableObject.CreateInstance<TargettingUnitsEitherSide>();
            right.right = true;
            right.getAllies = false;
            SwapToOneSideEffect goLeft = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            goLeft._swapRight = false;
            SwapToOneSideEffect goRight = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            goRight._swapRight = true;
            Effect[] effects = new Effect[]
            {
                new Effect(goLeft, 1, IntentType.Swap_Left, right),
                new Effect(goRight, 1, IntentType.Swap_Right, left),
            };
            EffectInfo[] info = ExtensionMethods.ToEffectInfoArray(effects);

            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    CombatManager.Instance.AddSubAction(new EffectAction(info, target.Unit));
                }
            }
            return exitAmount > 0;
        }
    }

    public class PlaySoundEffect : EffectSO
    {
        public string Audio;
        
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            Vector3 loc = default(Vector3);
            try
            {
                if (!caster.IsUnitCharacter)
                {
                    loc = stats.combatUI._enemyZone._enemies[caster.FieldID].FieldEntity.Position;
                }
            }
            catch { }
            RuntimeManager.PlayOneShot(Audio, loc);

            return true;
        }
    }

    public static class Intents
    {
        public static IntentInfo fleeIntent = new IntentInfoBasic();
        public static IntentType Flee => (IntentType)8592201;
        public static void FleeIntent(Action<IntentHandlerSO> orig, IntentHandlerSO self)
        {
            orig(self);
            fleeIntent._type = Flee;
            fleeIntent._sprite = Passives.Fleeting.passiveIcon;
            fleeIntent._color = UnityEngine.Color.white;
            fleeIntent._sound = self._intentDB[IntentType.Misc]._sound;
            IntentInfo intentInfo;
            self._intentDB.TryGetValue(Flee, out intentInfo);
            if (intentInfo == null)
                self._intentDB.Add(Flee, (IntentInfo)fleeIntent);
        }
        public static void Setup()
        {
            IDetour FleeType = (IDetour)new Hook((MethodBase)typeof(IntentHandlerSO).GetMethod("Initialize", ~BindingFlags.Default), typeof(Intents).GetMethod(nameof(FleeIntent), ~BindingFlags.Default));

        }
    }

    public class SubActionEffect : EffectSO
    {
        public Effect[] effects;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            EffectInfo[] info = ExtensionMethods.ToEffectInfoArray(effects);
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

        public static SubActionEffect Create(Effect[] e)
        {
            SubActionEffect ret = ScriptableObject.CreateInstance<SubActionEffect>();
            ret.effects = e;
            return ret;
        }
    }
    
    public class MultiTargetting : BaseCombatTargettingSO
    {
        public BaseCombatTargettingSO first;
        public BaseCombatTargettingSO second;
        public override bool AreTargetAllies => first.AreTargetAllies && second.AreTargetAllies;
        public override bool AreTargetSlots => first.AreTargetSlots && second.AreTargetSlots;
        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            TargetSlotInfo[] one = first.GetTargets(slots, casterSlotID, isCasterCharacter);
            TargetSlotInfo[] two = second.GetTargets(slots, casterSlotID, isCasterCharacter);
            TargetSlotInfo[] ret = new TargetSlotInfo[one.Length + two.Length];
            Array.Copy(one, ret, one.Length);
            Array.Copy(two, 0, ret, one.Length, two.Length);
            return ret;
        }

        public static MultiTargetting Create(BaseCombatTargettingSO first, BaseCombatTargettingSO second)
        {
            MultiTargetting ret = ScriptableObject.CreateInstance<MultiTargetting>();
            ret.first = first;
            ret.second = second;
            return ret;
        }
    }

    public class TargettingByFacingTarget : BaseCombatTargettingSO
    {
        public bool GetAllies = false;
        public bool FacingUnit = false;
        public override bool AreTargetAllies => GetAllies;
        public override bool AreTargetSlots => true;
        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            List<TargetSlotInfo> ret = new List<TargetSlotInfo>();
            if ((isCasterCharacter && AreTargetAllies) || ((!isCasterCharacter && !AreTargetAllies)))
            {
                foreach (CombatSlot slot in slots.CharacterSlots)
                {
                    foreach (CombatSlot opposer in slots.EnemySlots)
                    {
                        if (opposer.SlotID == slot.SlotID)
                        {
                            if (FacingUnit && opposer.HasUnit)
                            {
                                ret.Add(slot.TargetSlotInformation);
                            }
                            else if (!FacingUnit && !opposer.HasUnit)
                            {
                                ret.Add(slot.TargetSlotInformation);
                            }
                            break;
                        }
                    }
                }
            }
            else
            {
                foreach (CombatSlot slot in slots.EnemySlots)
                {
                    foreach (CombatSlot opposer in slots.CharacterSlots)
                    {
                        if (opposer.SlotID == slot.SlotID)
                        {
                            if (FacingUnit && opposer.HasUnit)
                            {
                                ret.Add(slot.TargetSlotInformation);
                            }
                            else if (!FacingUnit && !opposer.HasUnit)
                            {
                                ret.Add(slot.TargetSlotInformation);
                            }
                            break;
                        }
                    }
                }
            }
            return ret.ToArray();
        }
    }
    
    public class ReverseTargetting : BaseCombatTargettingSO
    {
        public BaseCombatTargettingSO source;
        public override bool AreTargetAllies => !source.AreTargetAllies;
        public override bool AreTargetSlots => true;
        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            TargetSlotInfo[] orig = source.GetTargets(slots, casterSlotID, isCasterCharacter);
            if (orig.Length <= 0) return new TargetSlotInfo[0];
            List<TargetSlotInfo> ret = new List<TargetSlotInfo>();
            foreach (TargetSlotInfo target in orig)
            {
                foreach (TargetSlotInfo add in Slots.Front.GetTargets(slots, target.SlotID, target.IsTargetCharacterSlot))
                {
                    ret.Add(add);
                }
            }
            return ret.ToArray();
        }
    }

    public class CasterSubActionEffect : EffectSO
    {
        public Effect[] effects;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            EffectInfo[] info = ExtensionMethods.ToEffectInfoArray(effects);
            exitAmount = 0;
            CombatManager.Instance.AddSubAction(new EffectAction(info, caster));
            return true;
        }

        public static CasterSubActionEffect Create(Effect[] e)
        {
            CasterSubActionEffect ret = ScriptableObject.CreateInstance<CasterSubActionEffect>();
            ret.effects = e;
            return ret;
        }
    }
    public class ChangeHealthColorEffect : EffectSO
    {
        public ManaColorSO color;
        
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i].HasUnit && targets[i].Unit.ChangeHealthColor(color))
                {
                    exitAmount++;
                }
            }

            return exitAmount > 0;
        }

        public static ChangeHealthColorEffect Create(ManaColorSO color)
        {
            ChangeHealthColorEffect ret = ScriptableObject.CreateInstance<ChangeHealthColorEffect>();
            ret.color = color;
            return ret;
        }
    }

    public class SpawnSelfEnemyAnywhereEffect : EffectSO
    {
        public bool givesExperience;

        [SerializeField]
        public SpawnType _spawnType = SpawnType.Basic;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (!(caster is EnemyCombat)) return false;
            EnemySO enemy = (caster as EnemyCombat).Enemy;
            
            for (int i = 0; i < entryVariable; i++)
            {
                CombatManager.Instance.AddSubAction(new SpawnEnemyAction(enemy, -1, givesExperience, trySpawnAnyways: false, _spawnType));
            }

            exitAmount = entryVariable;
            return true;
        }
    }

    public class NoiseDeathEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i].HasUnit && targets[i].Unit.GetStoredValue(NoiseHandler.Noise) >= 5)
                {
                    targets[i].Unit.DirectDeath(caster, true);
                    exitAmount++;
                }
            }

            return exitAmount > 0;
        }
    }
    public class NoiseTargetting : Targetting_ByUnit_Side
    {
        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            TargetSlotInfo[] source = base.GetTargets(slots, casterSlotID, isCasterCharacter);
            List<TargetSlotInfo> ret = new List<TargetSlotInfo>();
            foreach(TargetSlotInfo target in source)
            {
                if (target.HasUnit && target.Unit.GetStoredValue(NoiseHandler.Noise) >= 5)
                {
                    ret.Add(target);
                }
            }
            return ret.ToArray();
        }

        public static NoiseTargetting Default()
        {
            NoiseTargetting ret = ScriptableObject.CreateInstance<NoiseTargetting>();
            ret.getAllies = false;
            ret.getAllUnitSlots = false;
            return ret;
        }
    }
    public class IsNoiseCondition : EffectConditionSO
    {
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            foreach (CharacterCombat chara in CombatManager.Instance._stats.CharactersOnField.Values)
            {
                if (chara.GetStoredValue(NoiseHandler.Noise) >= 5)
                {
                    return true;
                }
            }

            return false;
        }
    }

    public class ShadowHealEffect : EffectSO
    {
        public bool usePreviousExitValue;

        public bool entryAsPercentage;

        [SerializeField]
        public bool _directHeal = true;

        [SerializeField]
        public bool _onlyIfHasHealthOver0;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            entryVariable = UnityEngine.Random.Range(5, 16);

            int minimize = 5;
            if (caster is EnemyCombat enemy)
            {
                foreach (EnemyCombat guy in stats.EnemiesOnField.Values)
                {
                    if (guy.Enemy == enemy.Enemy) minimize--;
                }
                for (int i = 0; i < minimize; i++)
                {
                    entryVariable += UnityEngine.Random.Range(3, 5);
                }
            }
            int second = 0;
            for (int i = 0; i < stats.TurnsPassed; i++)
            {
                second += UnityEngine.Random.Range(2, 3);
                if (UnityEngine.Random.Range(0, 100) < 45) second++;
                if (UnityEngine.Random.Range(0, 100) < 15) second++;
            }
            entryVariable = Math.Max(0, entryVariable - second);

            exitAmount = 0;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (targetSlotInfo.HasUnit && (!_onlyIfHasHealthOver0 || targetSlotInfo.Unit.CurrentHealth > 0))
                {
                    int num = entryVariable;
                    if (entryAsPercentage)
                    {
                        num = targetSlotInfo.Unit.CalculatePercentualAmount(num);
                    }

                    exitAmount += targetSlotInfo.Unit.Heal(num, HealType.Heal, _directHeal);
                }
            }

            return exitAmount > 0;
        }
    }
    public class ShadowEnterEffect : EffectSO
    {
        public bool usePreviousExitValue;

        public bool entryAsPercentage;

        [SerializeField]
        public bool _directHeal = true;

        [SerializeField]
        public bool _onlyIfHasHealthOver0;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = entryVariable;
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[] {
                new Effect(ScriptableObject.CreateInstance<ApplyPermanentGuttedEffect>(), 1, null, Slots.Self),
                new Effect(ScriptableObject.CreateInstance<ShadowHealEffect>(), 1, null, Slots.Self)
            }), caster));
            return true;
        }
    }

    public static class NamelessHandler
    {
        public static string RootPath => Paths.GameRootPath;
        public static string PluginPath => Paths.PluginPath;
        public static void CreateFile()
        {
            try
            {
                if (!FileExists)
                {
                    if (!Directory.Exists(RootPath + "/Nameless/"))
                    {
                        Directory.CreateDirectory(RootPath + "/Nameless/");
                    }
                    if (!File.Exists(RootPath + "/Nameless/Nameless.txt"))
                    {
                        File.WriteAllText(RootPath + "/Nameless/Nameless.txt", "This file is necessary to allow the enemy \"Nameless\" to perform the ability \"" + Abili.Nameless.name + "\".");
                        FileGenerates = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.LogError("NAMELESS FILE CREATION FAILED; " + ex);
                try
                {
                    if (!FileExists)
                    {
                        if (!Directory.Exists(PluginPath + "/Nameless/"))
                        {
                            Directory.CreateDirectory(PluginPath + "/Nameless/");
                        }
                        if (!File.Exists(PluginPath + "/Nameless/Nameless.txt"))
                        {
                            File.WriteAllText(PluginPath + "/Nameless/Nameless.txt", "This file is necessary to allow the enemy \"Nameless\" to perform the ability \"" + Abili.Nameless.name + "\".");
                            FileGenerates = true;
                        }
                    }
                }
                catch (Exception e2x)
                {
                    Debug.LogError("NAMELESS FILE CREATION FAILED TWICE; " + e2x);
                    FileGenerates = false;
                }
            }
        }
        public static bool FileGenerates;
        public static bool FileExists
        {
            get
            {
                if (Directory.Exists(RootPath + "/Nameless/") && File.Exists(RootPath + "/Nameless/Nameless.txt"))
                {
                    return true;
                }
                else if (Directory.Exists(PluginPath + "/Nameless/"))
                {
                    return File.Exists(PluginPath + "/Nameless/Nameless.txt");
                }
                return false;
            }
        }
        public static string FileAbility
        {
            get
            {
                return Abili.Nameless.name;
            }
        }
        public static void ShowcaseTimelineTooltip(Action<CombatVisualizationController, int> orig, CombatVisualizationController self, int timelineID)
        {
            if (timelineID < 0 || timelineID >= self._timelineSlotInfo.Count)
            {
                orig(self, timelineID);
                return;
            }

            TimelineInfo timelineInfo = self._timelineSlotInfo[timelineID];
            string header = "?";
            string content = "";
            if (!timelineInfo.isSecret)
            {
                int enemyID = timelineInfo.enemyID;
                if (self._enemiesInCombat.TryGetValue(enemyID, out var value))
                {
                    AbilitySO abilityBySlotID = value.GetAbilityBySlotID(timelineInfo.abilitySlotID);
                    if (!(abilityBySlotID == null) && !abilityBySlotID.Equals(null))
                    {
                        if (abilityBySlotID._abilityName == FileAbility)
                        {
                            StringPairData abilityLocData = abilityBySlotID.GetAbilityLocData();
                            header = abilityLocData.text;
                            content = abilityLocData.description;
                            if (FileExists) content = "Apply 50 Pale to all party members.";
                            //else if (FileGenerates) content = "This ability is unable to be performed due to lacking file information.";
                            //else content = "For some reason, this enemy's gimmick isnt working. This ability will do nothing.";
                            else content = "This ability is unable to be performed due to lacking file information.";
                            self._tooltip.DelayShow(content, header, "");
                            return;
                        }
                        if (abilityBySlotID._abilityName == Abili.Photosynthesize.name)
                        {
                            StringPairData abilityLocData = abilityBySlotID.GetAbilityLocData();
                            header = abilityLocData.text;
                            content = "Consume all Pigment of this enemy's health color and apply double the amount of Pigment consumed as Roots, distributed among all occupied party member positions. \nApply 1 Photosynthesis to this enemy.";
                            self._tooltip.DelayShow(content, header, "");
                            return;
                        }
                        if (abilityBySlotID._abilityName == "Count")
                        {
                            IReadOnlyDictionary<UnitStoredValueNames, int> readOnlyDictionary = value.StoredValues;
                            string extraContent = "";
                            if (readOnlyDictionary.TryGetValue((UnitStoredValueNames)544524, out var value3))
                            {
                                extraContent = self._tooltipData.ProcessStoredValue((UnitStoredValueNames)544524, value3);
                            }
                            StringPairData abilityLocData = abilityBySlotID.GetAbilityLocData();
                            header = abilityLocData.text;
                            content = abilityLocData.description;
                            self._tooltip.DelayShow(content, header, extraContent);
                            return;
                        }
                        if (abilityBySlotID._abilityName == "Wait")
                        {
                            IReadOnlyDictionary<UnitStoredValueNames, int> readOnlyDictionary = value.StoredValues;
                            string extraContent = "";
                            if (readOnlyDictionary.TryGetValue((UnitStoredValueNames)544525, out var value3))
                            {
                                extraContent = self._tooltipData.ProcessStoredValue((UnitStoredValueNames)544525, value3);
                            }
                            StringPairData abilityLocData = abilityBySlotID.GetAbilityLocData();
                            header = abilityLocData.text;
                            content = abilityLocData.description;
                            self._tooltip.DelayShow(content, header, extraContent);
                            return;
                        }
                        if (abilityBySlotID._abilityName == Abili.Nest.name)
                        {
                            StringPairData abilityLocData = abilityBySlotID.GetAbilityLocData();
                            header = abilityLocData.text;
                            content = "Apply 1 Constricted on the Left and Right party member positions. Reduce this enemy's Fleeting by 1 and inflict 2 Frail upon this enemy.";
                            self._tooltip.DelayShow(content, header, "");
                            return;
                        }
                        if (abilityBySlotID._abilityName == Abili.Patience.name)
                        {
                            StringPairData abilityLocData = abilityBySlotID.GetAbilityLocData();
                            header = abilityLocData.text;
                            content = "Move all party members with Terror closer to this enemy. If there are no party members with Terror, apply it to the party member farthest from this enemy.";
                            self._tooltip.DelayShow(content, header, "");
                            return;
                        }
                    }
                }
            }
            orig(self, timelineID);
            
        }
        public static void Setup()
        {
            IDetour hook = new Hook(typeof(CombatVisualizationController).GetMethod(nameof(CombatVisualizationController.ShowcaseTimelineTooltip), ~BindingFlags.Default), typeof(NamelessHandler).GetMethod(nameof(ShowcaseTimelineTooltip), ~BindingFlags.Default));
        }
    }
    public class Targetting_By_NamelessFile : BaseCombatTargettingSO
    {
        public BaseCombatTargettingSO source;
        public override bool AreTargetAllies => source.AreTargetAllies;
        public override bool AreTargetSlots => source.AreTargetSlots;
        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            if (NamelessHandler.FileExists) return source.GetTargets(slots, casterSlotID, isCasterCharacter);
            else return new TargetSlotInfo[0];
        }
        public static Targetting_By_NamelessFile Create(BaseCombatTargettingSO orig)
        {
            Targetting_By_NamelessFile ret = ScriptableObject.CreateInstance<Targetting_By_NamelessFile>();
            ret.source = orig;
            return ret;
        }
    }

    public static class NobodyMoveHandler
    {
        public static List<int> Chara;
        public static List<int> Enemy;
        public static void Clear() 
        {
            Chara.Clear();
            Enemy.Clear();
        }
        public static void NotifCheck(string notificationName, object sender, object args)
        {
            if (notificationName == TriggerCalls.OnMoved.ToString() && sender is IUnit unit)
            {
                if (unit.IsUnitCharacter) Chara.Add(unit.SlotID);
                else Enemy.Add(unit.SlotID);
            }
        }
        public static void Setup()
        {
            Chara = new List<int>();
            Enemy = new List<int>();
        }
    }
    public class Targetting_By_Moved : Targetting_ByUnit_Side
    {
        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            TargetSlotInfo[] source =  base.GetTargets(slots, casterSlotID, isCasterCharacter);
            List<TargetSlotInfo> ret = new List<TargetSlotInfo>();
            foreach (TargetSlotInfo target in source)
            {
                if (target.IsTargetCharacterSlot && NobodyMoveHandler.Chara.Contains(target.SlotID)) ret.Add(target);
                else if (!target.IsTargetCharacterSlot && NobodyMoveHandler.Enemy.Contains(target.SlotID)) ret.Add(target);
            }
            return ret.ToArray();
        }
        public static Targetting_By_Moved Create(bool getAlly)
        {
            Targetting_By_Moved ret = ScriptableObject.CreateInstance<Targetting_By_Moved>();
            ret.getAllUnitSlots = false;
            ret.getAllies = getAlly;
            return ret;
        }
    }

    public class CasterStoredValueSetEffect : EffectSO
    {
        [SerializeField]
        public UnitStoredValueNames _valueName = UnitStoredValueNames.PunchA;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = entryVariable;
            caster.SetStoredValue(_valueName, entryVariable);
            return true;
        }
    }

    public class ShortStompEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = entryVariable;
            if (caster.Size >= 5) return false;
            SwapToOneSideEffect left = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            left._swapRight = false;
            SwapToOneSideEffect right = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            right._swapRight = true;
            Effect LeftEffect = new Effect(left, 1, null, Slots.Self);
            Effect RightEffect = new Effect(right, 1, null, Slots.Self);
            EffectInfo[] lefting = ExtensionMethods.ToEffectInfoArray(new Effect[] { LeftEffect, LeftEffect, LeftEffect });
            EffectInfo[] righting = ExtensionMethods.ToEffectInfoArray(new Effect[] { RightEffect, RightEffect, RightEffect });
            if (caster.SlotID == 0) CombatManager.Instance.AddSubAction(new EffectAction(righting, caster));
            else if (caster.SlotID + caster.Size == 4 || UnityEngine.Random.Range(0, 100) < 50) CombatManager.Instance.AddSubAction(new EffectAction(lefting, caster));
            else CombatManager.Instance.AddSubAction(new EffectAction(righting, caster));
            return true;
        }
    }

    public class PainStarEffect : EffectSO
    {
        [SerializeField]
        public bool _fullyHeal = true;

        [SerializeField]
        public bool _maintainTimelineAbilities;

        [SerializeField]
        public bool _maintainMaxHealth = false;

        [SerializeField]
        public bool _currentToMaxHealth;

        public bool IsntSuperboss(EnemyCombat enemy)
        {
            if (enemy.Enemy._enemyName == "Strange Box")
                return false;
            if (enemy.Enemy._enemyName == "544517")
                return false;
            if (enemy.Enemy._enemyName == "544516")
                return false;
            if (enemy.Enemy._enemyName == "544515")
                return false;
            if (enemy.Enemy._enemyName == "544514")
                return false;
            if (enemy.Enemy._enemyName == "544513")
                return false;
            return true;
        }

        public bool Check(EnemyCombat enemy)
        {
            if (IsntSuperboss(enemy) && !enemy.Enemy._enemyName.Contains("Bronzo") && enemy.Enemy != LoadedAssetsHandler.GetEnemy("OsmanSinnoks_BOSS") && enemy.Enemy._enemyName != "Sepulchre" && (!(enemy.Enemy._enemyName.Contains("Fountain") && enemy.Enemy._enemyName.Contains("Youth"))))
            {
                return true;
            }
            return false;
        }

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (caster.IsUnitCharacter)
            {
                return false;
            }

            EnemySO _enemyTransformation = (caster as EnemyCombat).Enemy;
            List<EnemySO> enemies = new List<EnemySO>();
            foreach (EnemyCombat enemy in stats.EnemiesOnField.Values)
            {
                if (enemy.Enemy != (caster as EnemyCombat).Enemy && enemy.Size == 1 && !enemies.Contains(enemy.Enemy) && Check(enemy)) enemies.Add(enemy.Enemy);
            }
            if (enemies.Count > 0) _enemyTransformation = enemies[UnityEngine.Random.Range(0, enemies.Count)];

            return stats.TryTransformEnemy(caster.ID, _enemyTransformation, _fullyHeal, _maintainTimelineAbilities, _maintainMaxHealth, _currentToMaxHealth);
        }
    }

    public class WoodChipsEffect : EffectSO
    {
        public EnemySO[] enemies = new EnemySO[]
        {
            LoadedAssetsHandler.GetEnemy("HeavensGateRed_BOSS"),
            LoadedAssetsHandler.GetEnemy("HeavensGateBlue_BOSS"),
            LoadedAssetsHandler.GetEnemy("HeavensGateYellow_BOSS"),
            LoadedAssetsHandler.GetEnemy("HeavensGatePurple_BOSS")
        };
        
        public EnemySO enemy
        {
            get
            {
                return enemies[UnityEngine.Random.Range(0, enemies.Length)];
            }
        }

        public ManaColorSO[] pigments = new ManaColorSO[] { Pigments.Red, Pigments.Blue, Pigments.Yellow, Pigments.Purple };

        public ManaColorSO pigment
        {
            get
            {
                return pigments[UnityEngine.Random.Range(0, pigments.Length)];
            }
        }
        
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit && target.Unit.CurrentHealth <= 5)
                {
                    EnemySO thisGuy = enemy;
                    CombatManager.Instance.AddSubAction(new WoodChipsAction(thisGuy, -1, false, trySpawnAnyways: false, SpawnType.Basic, new AddManaToManaBarAction(thisGuy.healthColor, 1, caster.IsUnitCharacter, caster.ID)));
                    exitAmount++;
                }
            }
            return exitAmount > 0;
        }
    }
    public class WoodChipsAction : CombatAction
    {
        public int _preferredSlot;

        public EnemySO _enemy;

        public bool _givesExperience;

        public bool _trySpawnAnyways;

        public SpawnType _spawnType;

        public AddManaToManaBarAction pigment;

        public WoodChipsAction(EnemySO enemy, int preferredSlot, bool givesExperience, bool trySpawnAnyways, SpawnType spawnType, AddManaToManaBarAction Pigment)
        {
            _preferredSlot = preferredSlot;
            _givesExperience = givesExperience;
            _enemy = enemy;
            _trySpawnAnyways = trySpawnAnyways;
            _spawnType = spawnType;
            this.pigment = Pigment;
        }

        public override IEnumerator Execute(CombatStats stats)
        {
            int num;
            if (_preferredSlot >= 0)
            {
                num = stats.combatSlots.GetEnemyFitSlot(_preferredSlot, _enemy.size);
                if (num == -1 && _trySpawnAnyways)
                {
                    num = stats.GetRandomEnemySlot(_enemy.size);
                }
            }
            else
            {
                num = stats.GetRandomEnemySlot(_enemy.size);
            }

            if (num != -1)
            {
                stats.AddNewEnemy(_enemy, num, _givesExperience, _spawnType);
            }
            pigment.Execute(stats);
            yield return null;
        }
    }
    public class TargettingUnitsUnderHealth : Targetting_ByUnit_Side
    {
        public int boundaryInclusive;

        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            TargetSlotInfo[] source =  base.GetTargets(slots, casterSlotID, isCasterCharacter);
            List<TargetSlotInfo> ret = new List<TargetSlotInfo>();
            foreach (TargetSlotInfo target in source)
            {
                if (target.HasUnit && target.Unit.CurrentHealth <= boundaryInclusive)
                {
                    ret.Add(target);
                }
            }
            return ret.ToArray();
        }

        public static TargettingUnitsUnderHealth Create(int health, bool allies)
        {
            TargettingUnitsUnderHealth ret = ScriptableObject.CreateInstance<TargettingUnitsUnderHealth>();
            ret.getAllies = allies;
            ret.getAllUnitSlots = false;
            ret.boundaryInclusive = health;
            return ret;
        }
    }

    public class HasConfusionCondition : EffectConditionSO
    {
        public bool returnTrue;
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            return caster.ContainsPassiveAbility(PassiveAbilityTypes.Confusion) == returnTrue;
        }
        public static HasConfusionCondition Create(bool returntrue)
        {
            HasConfusionCondition ret = ScriptableObject.CreateInstance<HasConfusionCondition>();
            ret.returnTrue = returntrue;
            return ret;
        }
    }

    public static class FallImageryHandler
    {
        static IntentInfoDamage d;
        public static void Setup()
        {
            IDetour hook1 = new Hook(typeof(TimelineIntentListLayout).GetMethod(nameof(TimelineIntentListLayout.SetInformation), ~BindingFlags.Default), typeof(FallImageryHandler).GetMethod(nameof(SetInformation), ~BindingFlags.Default));
            IDetour hook2 = new Hook(typeof(TargetIntentListLayout).GetMethod(nameof(TargetIntentListLayout.AddInformation), ~BindingFlags.Default), typeof(FallImageryHandler).GetMethod(nameof(AddInformation), ~BindingFlags.Default));
            try
            {
                TrainHandler.Setup();
            }
            catch
            {
                Debug.LogError("TRAIN HANDLER FUCKING BROKE");
            }
        }

        public static void SetInformation(Action<TimelineIntentListLayout, Sprite[], Color[]> orig, TimelineIntentListLayout self, Sprite[] icons, Color[] colors)
        {
            if (colors.Contains(new Color(28f, 78f, 128f)))
            {
                if (self._intents.Count <= 0) self.GenerateNewIntent();
                for (int index = 0; index < self._intents.Count; ++index)
                {
                    if (index == 0)
                    {
                        self._intents[index].SetInformation(icons[index], colors[index]);
                        self._intents[index].SetActivation(true);
                        IntentLayoutAnimator grah = self._intents[index].gameObject.AddComponent<IntentLayoutAnimator>();
                        grah.animate = self._intents[index];
                        grah.icons = icons;
                        grah.colors = colors;
                        grah.IsActive = true;
                        grah.limit = 0.1f;
                        //Debug.Log("mhm");
                    }
                    else
                    {
                        self._intents[index].SetActivation(false);
                        //Debug.Log("uh uh.");
                    }
                }
            }
            else
            {
                orig(self, icons, colors);
                foreach (TimelineIntentLayout lay in self._intents)
                {
                    IntentLayoutAnimator[] array = lay.gameObject.GetComponents<IntentLayoutAnimator>();
                    foreach (IntentLayoutAnimator ain in array)
                    {
                        ain.enabled = false;
                        ain.IsActive = false;
                    }
                }
            }
        }
        public static void AddInformation(Action<TargetIntentListLayout, Sprite[], Color[]> orig, TargetIntentListLayout self, Sprite[] icons, Color[] colors)
        {
            if (colors.Contains(new Color(28f, 78f, 128f)))
            {
                if (self._unusedIntents.Count <= 0)
                    self.GenerateUnusedIntent();
                TargetIntentLayout targetIntentLayout = self._unusedIntents.Dequeue();
                targetIntentLayout.MoveToLast();
                targetIntentLayout.SetInformation(icons[0], colors[0]);
                targetIntentLayout.SetActivation(true);
                self._intentsInUse.Add(targetIntentLayout);
                foreach (IntentLayoutAnimator old in targetIntentLayout.gameObject.GetComponents<IntentLayoutAnimator>())
                {
                    old.IsActive = false;
                }
                IntentLayoutAnimator grah = targetIntentLayout.gameObject.AddComponent<IntentLayoutAnimator>();
                grah.mutilate = targetIntentLayout;
                grah.icons = icons;
                grah.colors = colors;
                grah.IsActive = true;
                grah.limit = 0.1f;
                //Debug.Log("TARGET INTENT ");
                //new IntentLayoutAnimator(targetIntentLayout, icons, colors);
            }
            else
            {
                orig(self, icons, colors);
                foreach (TargetIntentLayout lay in self._intentsInUse)
                {
                    IntentLayoutAnimator[] array = lay.gameObject.GetComponents<IntentLayoutAnimator>();
                    foreach (IntentLayoutAnimator ain in array)
                    {
                        ain.enabled = false;
                        ain.IsActive = false;
                    }
                }
            }
        }

        public static List<IntentLayoutAnimator> fullSet = new List<IntentLayoutAnimator>();
        public static void Clear()
        {
            foreach (IntentLayoutAnimator animator in fullSet)
            {
                if (animator.thread != null) animator.thread.Abort();
                animator.IsActive = false;
            }
            fullSet.Clear();
        }

        public class IntentLayoutAnimator : MonoBehaviour
        {
            public TimelineIntentLayout animate;
            public TargetIntentLayout mutilate;

            public Sprite[] icons;
            public Color[] colors;

            public Thread thread;
            /*
            public IntentLayoutAnimator(TimelineIntentLayout target, Sprite[] Icons, Color[] Colors)
            {
                if (DoDebugs.MiscInfo) Debug.Log("timeline");
                animate = target;
                icons = Icons;
                colors = Colors;
                Thread newThread = new Thread(Animate);
                newThread.Start();
                thread = newThread;
                fullSet.Add(this);
            }
            public IntentLayoutAnimator(TargetIntentLayout target, Sprite[] Icons, Color[] Colors)
            {
                if (DoDebugs.MiscInfo) Debug.Log("target");
                mutilate = target;
                icons = Icons;
                colors = Colors;
                Thread newThread = new Thread(Mutilate);
                newThread.Start();
                thread = newThread;
                fullSet.Add(this);
            }
            */
            int currentSprite = -1;
            public bool IsActive = true;
            public void Animate()
            {
                if (DoDebugs.MiscInfo) Debug.Log("timeline");
                while (animate != null && !animate.Equals(null) && animate.isActiveAndEnabled)
                {
                    try
                    { IsActive = true;
                        Thread.Sleep(100);
                        int cap = Math.Min(icons.Length, colors.Length);
                        int index = UnityEngine.Random.Range(0, cap);
                        while (colors[index] == new Color(28f, 78f, 128f) || index == currentSprite) index = UnityEngine.Random.Range(0, cap);
                        animate.SetInformation(icons[index], colors[index]);
                        currentSprite = index;
                    }
                    catch(Exception ex)
                    {
                        break;
                    }
                }
                fullSet.Remove(this);
                if (DoDebugs.MiscInfo) Debug.Log("timeline closed");
                IsActive = false;
            }
            public void Mutilate()
            {
                if (DoDebugs.MiscInfo) Debug.Log("target");
                while (mutilate != null && !mutilate.Equals(null) && mutilate.isActiveAndEnabled)
                {
                    try
                    {
                        IsActive = true;
                        Thread.Sleep(100);
                        int cap = Math.Min(icons.Length, colors.Length);
                        int index = UnityEngine.Random.Range(0, cap);
                        while (colors[index] == new Color(28f, 78f, 128f) || index == currentSprite) index = UnityEngine.Random.Range(0, cap);
                        mutilate.SetInformation(icons[index], colors[index]);
                        currentSprite = index;
                    }
                    catch (Exception ex)
                    {
                        break;
                    }
                }
                fullSet.Remove(this);
                if (DoDebugs.MiscInfo) Debug.Log("target closed");
                IsActive = false;
            }
            public float limit = 20f;
            public float time = 0f;
            public void Update()
            {
                //Debug.Log("Statr");
                if (!IsActive) return;
                //Debug.Log("Actiev");
                if (!RunFirstCheck || RedColor == null || PurpleColor == null || EnemyDamage == null || EnemyDamage.Length <= 0 || CharacterDamage == null || CharacterDamage.Length <= 0)
                {
                    CheckIsTrain(-1);
                    //Debug.Log("original trai check " + this);
                }
                try
                {
                    if (!fullSet.Contains(this))
                    {
                        fullSet.Add(this);
                        //Debug.Log("fullset addd " + fullSet.Count);
                        //Debug.Log(animate);
                        //Debug.Log(mutilate);
                    }
                }
                catch
                {
                    Debug.LogError("failed to add self to fullset");
                    Debug.LogError(this);
                }
                //if (mutilate != null && !mutilate.Equals(null) && mutilate.isActiveAndEnabled) { }
                //else if (animate != null && !animate.Equals(null) && animate.isActiveAndEnabled) { }
                //else { this.enabled = false; IsActive = false; }
                time += Time.deltaTime;
                if (time >= limit)
                {
                    try
                    {
                        Sprite[] icons = this.icons;
                        Color[] colors = this.colors;
                        if (ForceTrainColors)
                        {
                            if (HitAllies)
                            {
                                icons = EnemyDamage;
                                colors = new Color[icons.Length];
                                for (int i = 0; i < colors.Length; i++) colors[i] = RedColor;
                                //Debug.Log("enemy color");
                            }
                            else
                            {
                                icons = CharacterDamage;
                                colors = new Color[icons.Length];
                                for (int i = 0; i < colors.Length; i++) colors[i] = PurpleColor;
                                //Debug.Log("chara color");
                            }
                        }
                        time = 0f;
                        if (animate != null && !animate.Equals(null) && animate.isActiveAndEnabled)
                        {
                            int cap = Math.Min(icons.Length, colors.Length);
                            int index = UnityEngine.Random.Range(0, cap);
                            if (cap > 2 || (cap > 1 && ForceTrainColors))
                                while (colors[index] == new Color(28f, 78f, 128f) || index == currentSprite) index = UnityEngine.Random.Range(0, cap);
                            animate.SetInformation(icons[index], colors[index]);
                            currentSprite = index;
                            //Debug.Log("timeline");
                        }
                        if (mutilate != null && !mutilate.Equals(null) && mutilate.isActiveAndEnabled)
                        {
                            int cap = Math.Min(this.icons.Length, this.colors.Length);
                            int index = UnityEngine.Random.Range(0, cap);
                            if (cap > 2 || (cap > 1 && ForceTrainColors))
                                while (this.colors[index] == new Color(28f, 78f, 128f) || index == currentSprite) index = UnityEngine.Random.Range(0, cap);
                            mutilate.SetInformation(this.icons[index], this.colors[index]);
                            currentSprite = index;
                            //Debug.Log("target");
                        }
                    }
                    catch
                    {
                        Debug.LogError("intent icon sprite changer FUCKING BROKE");
                    }
                }
            }

            public bool ForceTrainColors;
            public bool HitAllies;
            public static Color RedColor;
            public static Color PurpleColor;
            public static Sprite[] EnemyDamage;
            public static Sprite[] CharacterDamage;
            public bool RunFirstCheck = false;
            public void CheckIsTrain(int numb)
            {
                RunFirstCheck = true;
                //Debug.Log("checking");
                try
                {
                    if (animate != null)
                    {
                        //Debug.Log(animate);
                        TrainHandler.TimelineIntentIDHolder yeah = animate.gameObject.GetComponent<TrainHandler.TimelineIntentIDHolder>();
                        if (yeah != null)
                        {
                            //Debug.Log("we got timeline ID " + yeah.ID);
                            int timeline = yeah.ID;
                            if (timeline < CombatManager.Instance._stats.combatUI._timelineSlotInfo.Count)
                            {
                                TimelineInfo boo = CombatManager.Instance._stats.combatUI._timelineSlotInfo[timeline];
                                if (CombatManager.Instance._stats.combatUI._enemiesInCombat.TryGetValue(boo.enemyID, out EnemyCombatUIInfo value))
                                {
                                    //Debug.Log("rea");
                                    foreach (EnemyCombat enemy in CombatManager.Instance._stats.EnemiesOnField.Values)
                                    {
                                        if (enemy.ID == value.ID)
                                        {
                                            //Debug.Log("found the enemy " + enemy.ID);
                                            ForceTrainColors = enemy.ContainsPassiveAbility(TrainHandler.Practical);
                                            HitAllies = numb > -1 ? numb == 0 : enemy.GetStoredValue(TrainHandler.HitParty) == 0;
                                            //Debug.Log("all good; timelineposition: " + yeah.ID + "; enemy's ID: " + value.ID + "; enemy slot: " + enemy.SlotID + "; is train: " + ForceTrainColors + "; hit enemies: " + HitAllies);
                                            //Debug.Log("force train " + ForceTrainColors);
                                            //Debug.Log("hit ally" + HitAllies);
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    ForceTrainColors = false;
                                    //Debug.Log("DIDNT get enemy");
                                    RunFirstCheck = true;
                                    //return;
                                }
                            }
                            else
                            {
                                //Debug.LogError("out of range!");
                                ForceTrainColors = false;
                                RunFirstCheck = true;
                            }
                        }
                        else
                        {
                            ForceTrainColors = false;
                            RunFirstCheck = true;
                            //Debug.Log("timeline intent id holder null");
                            //return;
                        }
                    }
                    else
                    {
                        ForceTrainColors = false;
                        RunFirstCheck = true;
                        //Debug.Log("animate null");
                        //return;
                    }
                }
                catch (Exception ex)
                {
                    ForceTrainColors = false;
                    Debug.LogError("train handler broke");
                    Debug.LogError(ex.ToString() + ex.Message + ex.StackTrace);
                }
                try
                {
                    if (RedColor == null || PurpleColor == null || EnemyDamage == null || EnemyDamage.Length <= 0 || CharacterDamage == null || CharacterDamage.Length <= 0)
                    {
                        IntentHandlerSO intents = CombatManager.Instance._stats.combatUI._intentHandler;
                        IntentInfoDamage one = intents._intentDB[IntentType.Damage_1_2] as IntentInfoDamage;
                        IntentInfoDamage three = intents._intentDB[IntentType.Damage_3_6] as IntentInfoDamage;
                        IntentInfoDamage seven = intents._intentDB[IntentType.Damage_7_10] as IntentInfoDamage;
                        IntentInfoDamage eleven = intents._intentDB[IntentType.Damage_11_15] as IntentInfoDamage;
                        IntentInfoDamage sixteen = intents._intentDB[IntentType.Damage_16_20] as IntentInfoDamage;
                        IntentInfoDamage twentyone = intents._intentDB[IntentType.Damage_21] as IntentInfoDamage;
                        RedColor = one.GetColor(false);
                        PurpleColor = one.GetColor(true);
                        EnemyDamage = new Sprite[]
                        {
                        one.GetSprite(false),
                        three.GetSprite(false),
                        seven.GetSprite(false),
                        eleven.GetSprite(false),
                        sixteen.GetSprite(false),
                        twentyone.GetSprite(false),
                        };
                        CharacterDamage = new Sprite[]
                        {
                        one.GetSprite(true),
                        three.GetSprite(true),
                        seven.GetSprite(true),
                        eleven.GetSprite(true),
                        sixteen.GetSprite(true),
                        twentyone.GetSprite(true),
                        };
                        //Debug.Log("GOT COLORS AND SHIT YEAHHH");
                    }
                }
                catch (Exception ex)
                {
                    ForceTrainColors = false;
                    Debug.LogError("get colors for train handler broke");
                    Debug.LogError(ex.ToString() + ex.Message + ex.StackTrace);
                }
                try
                {
                    if (HitAllies && (EnemyDamage == null || EnemyDamage.Length <= 0)) ForceTrainColors = false;
                    if (!HitAllies && (CharacterDamage == null || CharacterDamage.Length <= 0)) ForceTrainColors = false;
                }
                catch
                {
                    Debug.LogError("BACKUPS FUCKING BROKE!");
                    ForceTrainColors = false;
                }
                RunFirstCheck = true;
                //Debug.Log("force train colors " + ForceTrainColors);
                //Debug.Log("run first check " + RunFirstCheck);
            }
        }
    }
    public static class TrainHandler
    {
        public static PassiveAbilityTypes Practical => (PassiveAbilityTypes)7950742;
        public static UnitStoredValueNames HitParty => (UnitStoredValueNames)7950742;

        public static void UpdateSlotID(Action<TimelineSlotGroup, int> orig, TimelineSlotGroup self, int timelineSlotID)
        {
            TimelineIntentIDHolder yeah = self.intent.gameObject.GetComponent<TimelineIntentIDHolder>();
            if (yeah != null) yeah.ID = timelineSlotID;
            else
            {
                yeah = self.intent.gameObject.AddComponent<TimelineIntentIDHolder>();
                yeah.ID = timelineSlotID;
            }
            if (self.intent._intents.Count <= 0) self.intent.GenerateNewIntent();
            foreach (TimelineIntentLayout lay in self.intent._intents)
            {
                TimelineIntentIDHolder ee = lay.gameObject.GetComponent<TimelineIntentIDHolder>();
                if (ee != null) ee.ID = timelineSlotID;
                else
                {
                    ee = lay.gameObject.AddComponent<TimelineIntentIDHolder>();
                    ee.ID = timelineSlotID;
                }
                //if (lay.GetComponent<FallImageryHandler.IntentLayoutAnimator>() != null)
                //{
                    //lay.GetComponent<FallImageryHandler.IntentLayoutAnimator>().CheckIsTrain(-1);
                //}
            }
            orig(self, timelineSlotID);
        }
        public static void SetInformation(Action<TimelineSlotGroup, int, Sprite, Sprite[], Color[]> orig, TimelineSlotGroup self, int timelineSlotID, Sprite enemy, Sprite[] intents, Color[] intentColors)
        {
            TimelineIntentIDHolder yeah = self.intent.gameObject.GetComponent<TimelineIntentIDHolder>();
            if (yeah != null) yeah.ID = timelineSlotID;
            else
            {
                yeah = self.intent.gameObject.AddComponent<TimelineIntentIDHolder>();
                yeah.ID = timelineSlotID;
            }
            if (self.intent._intents.Count <= 0) self.intent.GenerateNewIntent();
            foreach (TimelineIntentLayout lay in self.intent._intents)
            {
                TimelineIntentIDHolder ee = lay.gameObject.GetComponent<TimelineIntentIDHolder>();
                if (ee != null) ee.ID = timelineSlotID;
                else
                {
                    ee = lay.gameObject.AddComponent<TimelineIntentIDHolder>();
                    ee.ID = timelineSlotID;
                }
            }
            //Debug.Log("WOWOWOWOW" + yeah + " numbah: " + timelineSlotID);
            orig(self, timelineSlotID, enemy, intents, intentColors);
        }
        public static IEnumerator PopulateTimeline(Func<TimelineZoneLayout, Sprite[], AbilitySO[], IEnumerator> orig, TimelineZoneLayout self, Sprite[] turnSprites, AbilitySO[] abilities)
        {
            FallImageryHandler.Clear();
            TrainTargetting.Flip();
            yield return orig(self, turnSprites, abilities);
        }
        public static void Setup()
        {
            IDetour hook1 = new Hook(typeof(TimelineSlotGroup).GetMethod(nameof(TimelineSlotGroup.SetInformation), ~BindingFlags.Default), typeof(TrainHandler).GetMethod(nameof(SetInformation), ~BindingFlags.Default));
            IDetour hook3 = new Hook(typeof(TimelineSlotGroup).GetMethod(nameof(TimelineSlotGroup.UpdateSlotID), ~BindingFlags.Default), typeof(TrainHandler).GetMethod(nameof(UpdateSlotID), ~BindingFlags.Default));
            IDetour hook2 = new Hook(typeof(TimelineZoneLayout).GetMethod(nameof(TimelineZoneLayout.PopulateTimeline), ~BindingFlags.Default), typeof(TrainHandler).GetMethod(nameof(PopulateTimeline), ~BindingFlags.Default));
        }
        public class TimelineIntentIDHolder : MonoBehaviour
        {
            public int ID;
        }
        public static void SwitchTrainTargetting(object sender)
        {
            try
            {
                foreach (EnemyCombat enemy in CombatManager.Instance._stats.EnemiesOnField.Values)
                {
                    if (enemy == sender) continue;
                    if (enemy.ContainsPassiveAbility(Practical) && UnityEngine.Random.Range(0, 100) < 75)
                    {
                        if (enemy.GetStoredValue(HitParty) > 0)
                        {
                            if (UnityEngine.Random.Range(0, 100) < 50)
                            {
                                enemy.SetStoredValue(HitParty, 0);
                                CombatManager.Instance.AddUIAction(new SetUnitAnimationParameterUIAction(enemy.ID, enemy.IsUnitCharacter, "party", false));
                                ChangeIntents(enemy, 0);
                            }
                        }
                        else
                        {
                            enemy.SetStoredValue(HitParty, 1);
                            CombatManager.Instance.AddUIAction(new SetUnitAnimationParameterUIAction(enemy.ID, enemy.IsUnitCharacter, "party", true));
                            ChangeIntents(enemy, 1);
                        }
                    }
                }
            }
            catch
            {
                Debug.LogError("probably not in combat - train handler");
            }
            try
            {
                TrainTargetting.Flip();
            }
            catch
            {
                Debug.LogError("train targetting flip fail");
            }
        }
        public static void ChangeIntents(EnemyCombat self, int num)
        {
            foreach (FallImageryHandler.IntentLayoutAnimator anim in FallImageryHandler.fullSet)
            {
                try
                {
                    if (anim != null && !anim.Equals(null) && anim.IsActive && anim.enabled)
                    {
                        if (anim.animate != null)
                        {
                            TrainHandler.TimelineIntentIDHolder yeah = anim.animate.gameObject.GetComponent<TrainHandler.TimelineIntentIDHolder>();
                            if (yeah != null)
                            {
                                int timeline = yeah.ID;
                                TimelineInfo boo = CombatManager.Instance._stats.combatUI._timelineSlotInfo[timeline];
                                if (CombatManager.Instance._stats.combatUI._enemiesInCombat.TryGetValue(boo.enemyID, out EnemyCombatUIInfo value))
                                {
                                    if (self.ID == value.ID)
                                    {
                                        CombatManager.Instance.AddUIAction(new TrainIntentsUpdateUIAction(anim, num));
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                catch
                {
                    Debug.LogError("i think the animatorinator is null");
                }
            }
            CheckAll();
        }
        public static void CheckAll()
        {
            try
            {
                CombatManager.Instance.AddRootAction(new SubActionAction(new UIActionAction(new TrainIntentsAllUpdateUIAction())));
            }
            catch
            {
                Debug.LogError("not in combat probs");
            }
        }
    }
    public class UIActionAction : CombatAction
    {
        public CombatAction run;
        public UIActionAction(CombatAction y)
        {
            run = y;
        }
        public override IEnumerator Execute(CombatStats stats)
        {
            CombatManager.Instance.AddUIAction(run);
            yield return null;
        }
    }
    public class SubActionAction : CombatAction
    {
        public CombatAction run;
        public SubActionAction(CombatAction y)
        {
            run = y;
        }
        public override IEnumerator Execute(CombatStats stats)
        {
            CombatManager.Instance.AddSubAction(run);
            yield return null;
        }
    }
    public class TrainIntentsUpdateUIAction : CombatAction
    {
        public FallImageryHandler.IntentLayoutAnimator Anim;
        public int Num;
        public TrainIntentsUpdateUIAction(FallImageryHandler.IntentLayoutAnimator anim, int num)
        {
            Anim = anim;
            Num = num;
        }
        public override IEnumerator Execute(CombatStats stats)
        {
            try
            {
                Anim.CheckIsTrain(Num);
            }
            catch
            {
                Debug.LogError("fialed tainr che");
            }
            yield return null;
        }
    }
    public class TrainIntentsAllUpdateUIAction : CombatAction
    {
        public override IEnumerator Execute(CombatStats stats)
        {
            try
            {
                foreach (FallImageryHandler.IntentLayoutAnimator anim in FallImageryHandler.fullSet)
                {
                    try
                    {
                        if (anim != null && !anim.Equals(null) && anim.IsActive && anim.enabled)
                        {
                            anim.CheckIsTrain(-1);
                        }
                    }
                    catch
                    {
                        Debug.LogError("one failed");
                    }
                } 
            }
            catch
            {
                Debug.LogError("fialed tainr che");
            }
            yield return null;
        }
    }
    public class CrashesYourGameEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            UnityEngine.Diagnostics.Utils.ForceCrash(~ForcedCrashCategory.Abort);
            return true;
        }
    }

    public class IsDieCondition : EffectConditionSO
    {
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            return caster.CurrentHealth == 0;
        }
    }

    public class TargettingByStatusEffect : BaseCombatTargettingSO
    {
        public BaseCombatTargettingSO origin;
        public override bool AreTargetAllies => origin.AreTargetAllies;
        public override bool AreTargetSlots => origin.AreTargetSlots;
        public bool HasStatus = true;
        public StatusEffectType Type = StatusEffectType.Cursed;
        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            TargetSlotInfo[] source = origin.GetTargets(slots, casterSlotID, isCasterCharacter);
            List<TargetSlotInfo> ret = new List<TargetSlotInfo>();
            foreach (TargetSlotInfo target in source)
            {
                if (target.HasUnit)
                {
                    if (HasStatus && target.Unit.ContainsStatusEffect(Type))
                    {
                        ret.Add(target);
                    }
                    else if (!HasStatus && !target.Unit.ContainsStatusEffect(Type))
                    {
                        ret.Add(target);
                    }
                }
            }
            return ret.ToArray();
        }
        public static TargettingByStatusEffect Create(BaseCombatTargettingSO gru, StatusEffectType t, bool hasit = true)
        {
            TargettingByStatusEffect ret = ScriptableObject.CreateInstance<TargettingByStatusEffect>();
            ret.origin = gru;
            ret.Type = t;
            ret.HasStatus = hasit;
            return ret;
        }
    }

    public class RootActionEffect : EffectSO
    {
        public Effect[] effects;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            EffectInfo[] info = ExtensionMethods.ToEffectInfoArray(effects);
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    CombatManager.Instance.AddRootAction(new EffectAction(info, target.Unit));
                    exitAmount++;
                }
            }
            return exitAmount > 0;
        }

        public static RootActionEffect Create(Effect[] e)
        {
            RootActionEffect ret = ScriptableObject.CreateInstance<RootActionEffect>();
            ret.effects = e;
            return ret;
        }
    }
    public class CasterRootActionEffect : EffectSO
    {
        public Effect[] effects;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            EffectInfo[] info = ExtensionMethods.ToEffectInfoArray(effects);
            exitAmount = 0;
            CombatManager.Instance.AddRootAction(new EffectAction(info, caster));
            return true;
        }

        public static CasterRootActionEffect Create(Effect[] e)
        {
            CasterRootActionEffect ret = ScriptableObject.CreateInstance<CasterRootActionEffect>();
            ret.effects = e;
            return ret;
        }
    }

    public class IsFrontTargetCondition : EffectConditionSO
    {
        public bool returnTrue = false;
        
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            TargetSlotInfo[] check = Slots.Front.GetTargets(CombatManager.Instance._stats.combatSlots, caster.SlotID, caster.IsUnitCharacter);
            foreach (TargetSlotInfo target in check)
            {
                if (target.HasUnit) return returnTrue;
            }
            return !returnTrue;
        }
    }

    public class TargettingUnitsEitherSideWithStatus : BaseCombatTargettingSO
    {
        public bool getAllies;

        public bool right;

        public bool ignoreDirectNextAllyOnly = true;

        public override bool AreTargetAllies => getAllies;

        public override bool AreTargetSlots => false;

        public StatusEffectType status;

        Targetting_ByUnit_Side source = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();

        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            List<TargetSlotInfo> targets = new List<TargetSlotInfo>();
            source.getAllies = getAllies;
            source.getAllUnitSlots = false;
            source.ignoreCastSlot = true;
            TargetSlotInfo[] chumby = source.GetTargets(slots, casterSlotID, isCasterCharacter);
            foreach (TargetSlotInfo target in chumby)
            {
                if (target.HasUnit && target.Unit.ContainsStatusEffect(status))
                {
                    if (right)
                    {
                        if (target.SlotID <= casterSlotID || !target.HasUnit) continue;
                        if (getAllies)
                        {
                            if (!ignoreDirectNextAllyOnly || target.SlotID != casterSlotID + 1)
                            {
                                targets.Add(target);
                            }
                        }
                        else
                        {
                            targets.Add(target);
                        }
                    }
                    else
                    {
                        if (target.SlotID >= casterSlotID || !target.HasUnit) continue;
                        if (getAllies)
                        {
                            if (!ignoreDirectNextAllyOnly || target.SlotID != casterSlotID - target.Unit.Size)
                            {
                                targets.Add(target);
                            }
                        }
                        else
                        {
                            targets.Add(target);
                        }
                    }
                }
            }
            if (!right) targets.Reverse();
            return targets.ToArray();
        }

        public static TargettingUnitsEitherSideWithStatus Create(StatusEffectType status, bool allies, bool right)
        {
            TargettingUnitsEitherSideWithStatus ret = ScriptableObject.CreateInstance<TargettingUnitsEitherSideWithStatus>();
            ret.status = status;
            ret.getAllies = allies;
            ret.right = right;
            return ret;
        }
    }

    public class SingeClawsEffect : EffectSO
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
            stats.slotStatusEffectDataBase.TryGetValue(SlotStatusEffectType.OnFire, out var value);
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                int DoFire = entryVariable;
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
                    DoFire -= damageInfo.damageAmount;
                }
                if (DoFire > 0)
                {
                    OnFire_SlotStatusEffect onFire_SlotStatusEffect = new OnFire_SlotStatusEffect(targetSlotInfo.SlotID, DoFire);
                    onFire_SlotStatusEffect.SetEffectInformation(value);
                    stats.combatSlots.ApplySlotStatusEffect(targetSlotInfo.SlotID, targetSlotInfo.IsTargetCharacterSlot, DoFire, onFire_SlotStatusEffect);
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

    public class RemoveAllFireEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i].IsTargetCharacterSlot)
                {
                    exitAmount += stats.combatSlots.CharacterSlots[targets[i].SlotID].TryRemoveSlotStatusEffect(SlotStatusEffectType.OnFire);
                }
                else
                {
                    exitAmount += stats.combatSlots.EnemySlots[targets[i].SlotID].TryRemoveSlotStatusEffect(SlotStatusEffectType.OnFire);
                }
            }

            return exitAmount > 0;
        }
    }

    public class RemoveAllShieldsEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i].IsTargetCharacterSlot)
                {
                    exitAmount += stats.combatSlots.CharacterSlots[targets[i].SlotID].TryRemoveSlotStatusEffect(SlotStatusEffectType.Shield);
                }
                else
                {
                    exitAmount += stats.combatSlots.EnemySlots[targets[i].SlotID].TryRemoveSlotStatusEffect(SlotStatusEffectType.Shield);
                }
            }

            return exitAmount > 0;
        }
    }

    public class LeftRightTargetting : Targetting_ByUnit_Side
    {
        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            TargetSlotInfo[] source = base.GetTargets(slots, casterSlotID, isCasterCharacter);
            List<TargetSlotInfo> ret = new List<TargetSlotInfo>();
            int leftMod = 1;
            int rightMod = 1;
            int casterSize = 1;
            if (!isCasterCharacter)
            {
                foreach (EnemyCombat enemy in CombatManager.Instance._stats.EnemiesOnField.Values)
                {
                    if (enemy.SlotID == casterSlotID) casterSize = enemy.Size;
                }
                foreach (EnemyCombat enemy in CombatManager.Instance._stats.EnemiesOnField.Values)
                {
                    if (enemy.SlotID + enemy.Size == casterSlotID) leftMod = enemy.Size;
                    if (enemy.SlotID == casterSlotID + casterSize) rightMod = enemy.Size;
                }
            }
            foreach (TargetSlotInfo target in source)
            {
                if (target.SlotID == casterSlotID - leftMod) ret.Add(target);
                else if (target.SlotID == casterSlotID + rightMod) ret.Add(target);
            }
            return ret.ToArray();
        }
        public static LeftRightTargetting Create(bool getAllies, bool areSlots)
        {
            LeftRightTargetting ret = ScriptableObject.CreateInstance<LeftRightTargetting>();
            ret.getAllies = getAllies;
            ret.getAllUnitSlots = areSlots;
            return ret;
        }
    }

    public class HasHealthColorCondition : EffectConditionSO
    {
        public bool characters;
        public ManaColorSO color;
        public bool all;

        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            CombatStats stats = CombatManager.Instance._stats;
            if (characters)
            {
                foreach (CharacterCombat chara in stats.CharactersOnField.Values)
                {
                    if (all && chara.HealthColor != color) return false;
                    if (!all && chara.HealthColor == color) return true;
                }
            }
            else
            {
                foreach (EnemyCombat enemy in stats.EnemiesOnField.Values)
                {
                    if (all && enemy.HealthColor != color) return false;
                    if (!all && enemy.HealthColor == color) return true;
                }
            }
            if (all) return true;
            else return false;
        }
        public static HasHealthColorCondition Create(ManaColorSO Color, bool getChara, bool ifAll = false)
        {
            HasHealthColorCondition ret = ScriptableObject.CreateInstance<HasHealthColorCondition>();
            ret.color = Color;
            ret.characters = getChara;
            ret.all = ifAll;
            return ret;
        }
    }

    public static class IllusionHandler
    {
        public static UnitStoredValueNames State = (UnitStoredValueNames)2729001;


        public static string AddStoredValueName1(
          Func<TooltipTextHandlerSO, UnitStoredValueNames, int, string> orig,
          TooltipTextHandlerSO self,
          UnitStoredValueNames storedValue,
          int value)
        {
            Color magenta = Color.magenta;
            string str1;
            if (storedValue == State)
            {
                if (value <= 0)
                {
                    str1 = "";
                }
                else
                {
                    if (value == 1)
                    {
                        string str2 = "Offense State";
                        string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(self._negativeSTColor) + ">";
                        string str4 = "</color>";
                        str1 = str3 + str2 + str4;
                    }
                    else if (value == 2)
                    {
                        string str2 = "Supportive State";
                        string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(self._positiveSTColor) + ">";
                        string str4 = "</color>";
                        str1 = str3 + str2 + str4;
                    }
                    else
                    {
                        str1 = "";
                    }
                }
            }
            else
                str1 = orig(self, storedValue, value);
            return str1;
        }

        public static bool set = false;
        public static void Setup()
        {
            if (set) return; set = true;
            IDetour salineVale = new Hook((MethodBase)typeof(TooltipTextHandlerSO).GetMethod(nameof(TooltipTextHandlerSO.ProcessStoredValue), ~BindingFlags.Default), typeof(IllusionHandler).GetMethod(nameof(AddStoredValueName1), ~BindingFlags.Default));
        }
    }
    public class SpawnEnemyCopySelfEffect : EffectSO
    {
        public bool givesExperience;

        [SerializeField]
        public SpawnType _spawnType = SpawnType.Basic;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (caster is EnemyCombat enemm)
            {
                EnemySO enemy = enemm.Enemy;
                for (int i = 0; i < entryVariable; i++)
                {
                    CombatManager.Instance.AddSubAction(new SpawnEnemyAction(enemy, -1, givesExperience, trySpawnAnyways: false, _spawnType));
                }
            }
            else return false;
            exitAmount = entryVariable;
            return true;
        }
    }
    public class RerollSwapCasterAbilitiesEffect : EffectSO
    {
        [Header("Abilities To Swap Data")]
        [SerializeField]
        public ExtraAbilityInfo[] _abilitiesToSwap;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            bool num = caster.SwapWithExtraAbilities(_abilitiesToSwap);
            if (num && !caster.IsUnitCharacter)
            {
                stats.timeline.TryReRollRandomEnemyTurns(caster as EnemyCombat, 99);
            }
            
            return num;
        }
    }

    public class CopyStatusOntoCasterEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            bool casterIncluded = false;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.Unit == caster) casterIncluded = true;
            }
            stats.statusEffectDataBase.TryGetValue(StatusEffectType.Spotlight, out var spot);
            bool ApplySpotlight = false;
            if (casterIncluded)
            {
                if (caster is IStatusEffector effector)
                {
                    List<IStatusEffect> statuses = new List<IStatusEffect>(effector.StatusEffects);
                    for (int i = 0; i < statuses.Count; i++)
                    {
                        IStatusEffect toCopy = statuses[i];
                        if (toCopy.EffectType == StatusEffectType.Spotlight)
                        {
                            ApplySpotlight = true;
                            continue;
                        }
                        ConstructorInfo[] constructors = toCopy.GetType().GetConstructors();
                        IStatusEffect letsGo = null;
                        foreach (ConstructorInfo build in constructors)
                        {
                            if (build.GetParameters().Length == 0)
                            {
                                letsGo = (IStatusEffect)Activator.CreateInstance(toCopy.GetType());
                            }
                            else if (build.GetParameters().Length == 1)
                            {
                                letsGo = (IStatusEffect)Activator.CreateInstance(toCopy.GetType(), 0);
                            }
                            else if (build.GetParameters().Length == 2)
                            {
                                letsGo = (IStatusEffect)Activator.CreateInstance(toCopy.GetType(), toCopy.StatusContent + (toCopy.Restrictor * 4), 0);
                            }
                        }
                        if (letsGo != null)
                        {
                            letsGo.SetEffectInformation(toCopy.EffectInfo);
                            bool hasNum = letsGo.DisplayText != "";
                            int amount = hasNum ? letsGo.StatusContent : 0;
                            if (caster.ApplyStatusEffect(letsGo, amount)) exitAmount += Math.Max(letsGo.StatusContent, 1);
                        }
                    }
                }
            }
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit && target.Unit != caster && target.Unit is IStatusEffector effector)
                {
                    List<IStatusEffect> statuses = new List<IStatusEffect>(effector.StatusEffects);
                    for (int i = 0; i < statuses.Count; i++)
                    {
                        IStatusEffect toCopy = statuses[i];
                        if (toCopy.EffectType == StatusEffectType.Spotlight)
                        {
                            ApplySpotlight = true;
                            continue;
                        }
                        ConstructorInfo[] constructors = toCopy.GetType().GetConstructors();
                        IStatusEffect letsGo = null;
                        foreach (ConstructorInfo build in constructors)
                        {
                            if (build.GetParameters().Length == 0)
                            {
                                letsGo = (IStatusEffect)Activator.CreateInstance(toCopy.GetType());
                            }
                            else if (build.GetParameters().Length == 1)
                            {
                                letsGo = (IStatusEffect)Activator.CreateInstance(toCopy.GetType(), 0);
                            }
                            else if (build.GetParameters().Length == 2)
                            {
                                letsGo = (IStatusEffect)Activator.CreateInstance(toCopy.GetType(), toCopy.StatusContent + (toCopy.Restrictor * 4), 0);
                            }
                        }
                        if (letsGo != null)
                        {
                            letsGo.SetEffectInformation(toCopy.EffectInfo);
                            bool hasNum = letsGo.DisplayText != "";
                            int amount = hasNum ? letsGo.StatusContent : 0;
                            if (caster.ApplyStatusEffect(letsGo, amount)) exitAmount += Math.Max(letsGo.StatusContent, 1);
                        }
                    }
                }
            }
            if (ApplySpotlight)
            {
                Spotlight_StatusEffect spotlight_StatusEffect = new Spotlight_StatusEffect();
                spotlight_StatusEffect.SetEffectInformation(spot);
                if (caster.ApplyStatusEffect(spotlight_StatusEffect, 0))
                {
                    exitAmount++;
                }
            }
            return exitAmount > 0;
        }
    }
    public class FakeOneFrailEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (entryVariable <= 0)
            {
                return false;
            }

            stats.statusEffectDataBase.TryGetValue(StatusEffectType.Frail, out var value);
            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i].HasUnit)
                {
                    int amount = entryVariable;
                    if (targets[i].Unit.ContainsStatusEffect(value.statusEffectType)) amount = 1;
                    Frail_StatusEffect frail_StatusEffect = new Frail_StatusEffect(amount);
                    frail_StatusEffect.SetEffectInformation(value);
                    if (targets[i].Unit.ApplyStatusEffect(frail_StatusEffect, 1))
                    {
                        exitAmount += amount;
                    }
                }
            }

            return exitAmount > 0;
        }
    }

    public class FireUpToPlusOneEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;

            stats.slotStatusEffectDataBase.TryGetValue(SlotStatusEffectType.OnFire, out var value);
            for (int i = 0; i < targets.Length; i++)
            {
                int amount = entryVariable;
                amount += UnityEngine.Random.Range(0, 2);
                if (amount <= 0) continue;
                OnFire_SlotStatusEffect onFire_SlotStatusEffect = new OnFire_SlotStatusEffect(targets[i].SlotID, amount);
                onFire_SlotStatusEffect.SetEffectInformation(value);
                if (stats.combatSlots.ApplySlotStatusEffect(targets[i].SlotID, targets[i].IsTargetCharacterSlot, amount, onFire_SlotStatusEffect))
                {
                    exitAmount += amount;
                }
            }

            return exitAmount > 0;
        }
    }

    public class FakeOneRupturedEffect : EffectSO
    {
        [SerializeField]
        public bool _justOneTarget;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (entryVariable <= 0)
            {
                return false;
            }

            stats.statusEffectDataBase.TryGetValue(StatusEffectType.Ruptured, out var value);
            if (_justOneTarget)
            {
                List<TargetSlotInfo> list = new List<TargetSlotInfo>(targets);
                for (int num = list.Count - 1; num >= 0; num--)
                {
                    if (!list[num].HasUnit)
                    {
                        list.RemoveAt(num);
                    }
                }

                if (list.Count > 0)
                {
                    int index = UnityEngine.Random.Range(0, list.Count);
                    int amount = entryVariable;
                    if (targets[index].Unit.ContainsStatusEffect(StatusEffectType.Ruptured)) amount = 1;
                    Ruptured_StatusEffect ruptured_StatusEffect = new Ruptured_StatusEffect(amount);
                    ruptured_StatusEffect.SetEffectInformation(value);
                    if (list[index].Unit.ApplyStatusEffect(ruptured_StatusEffect, 1))
                    {
                        exitAmount += amount;
                    }
                }
            }
            else
            {
                for (int i = 0; i < targets.Length; i++)
                {
                    if (targets[i].HasUnit)
                    {
                        int amount = entryVariable;
                        if (targets[i].Unit.ContainsStatusEffect(StatusEffectType.Ruptured)) amount = 1;
                        Ruptured_StatusEffect ruptured_StatusEffect = new Ruptured_StatusEffect(amount);
                        ruptured_StatusEffect.SetEffectInformation(value);
                        if (targets[i].Unit.ApplyStatusEffect(ruptured_StatusEffect, 1))
                        {
                            exitAmount += amount;
                        }
                    }
                }
            }

            return exitAmount > 0;
        }
    }

    public class DamageByMissingHealthEffect : EffectSO
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

            bool set = false;
            int temp = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    int missing = target.Unit.MaximumHealth - target.Unit.CurrentHealth;
                    if (!set)
                    {
                        temp = missing;
                        set = true;
                    }
                    else if (missing < temp) temp = missing;
                }
            }
            entryVariable *= temp;

            bool flag = false;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (targetSlotInfo.HasUnit)
                {
                    int targetSlotOffset = (areTargetSlots ? (targetSlotInfo.SlotID - targetSlotInfo.Unit.SlotID) : (-1));
                    int amount = Math.Max(0, entryVariable);
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
    public class EngravingsEffect : EffectSO
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

        public AnimationVisualsEffect Shank;
        public ShowEngravingsAttackInfoEffect Text;
        public PseudoEngravingsEffect Pseudo;

        public static bool Engraving = false;
        public static List<IUnit> Engravers = new List<IUnit>();

        public void RunSecondaryEngravings(CombatStats stats)
        {
            List<IUnit> killers = new List<IUnit>(Engravers);
            Engravers.Clear();
            foreach (IUnit caster in killers)
            {
                Text.PerformEffect(stats, caster, Slots.Self.GetTargets(stats.combatSlots, caster.SlotID, caster.IsUnitCharacter), Slots.Self.AreTargetSlots, 2, out int ex1);
                Shank.PerformEffect(stats, caster, Slots.Self.GetTargets(stats.combatSlots, caster.SlotID, caster.IsUnitCharacter), Slots.Self.AreTargetSlots, 2, out int ex2);
                Pseudo.PerformEffect(stats, caster, Slots.Sides.GetTargets(stats.combatSlots, caster.SlotID, caster.IsUnitCharacter), Slots.Sides.AreTargetSlots, 2, out int ex3);
            }
            if (Engravers.Count > 0) RunSecondaryEngravings(stats);
        }

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            if (_usePreviousExitValue)
            {
                entryVariable *= base.PreviousExitValue;
            }

            Engravers = new List<IUnit>();
            if (Text == null) Text = ScriptableObject.CreateInstance<ShowEngravingsAttackInfoEffect>();
            if (Shank == null) Shank = BasicEffects.GetVisuals("Salt/Claws", true, Slots.Sides);
            if (Pseudo == null) Pseudo = ScriptableObject.CreateInstance<PseudoEngravingsEffect>();

            exitAmount = 0;
            stats.statusEffectDataBase.TryGetValue(StatusEffectType.Focused, out var value);
            bool flag = false;
            int survived = 0;
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
                    Focused_StatusEffect focused_StatusEffect = new Focused_StatusEffect();
                    focused_StatusEffect.SetEffectInformation(value);
                    targetSlotInfo.Unit.ApplyStatusEffect(focused_StatusEffect, 0);

                    flag |= damageInfo.beenKilled;
                    exitAmount += damageInfo.damageAmount;

                    if (targetSlotInfo.Unit.CurrentHealth > 0 && damageInfo.damageAmount > 0)
                    {
                        Engravers.Add(targetSlotInfo.Unit);
                    }
                }
            }

            if (!_indirect && exitAmount > 0)
            {
                caster.DidApplyDamage(exitAmount);
            }

            RunSecondaryEngravings(stats);


            if (!_returnKillAsSuccess)
            {
                return exitAmount > 0;
            }

            
            return flag;
        }
    }
    public class ShowEngravingsAttackInfoEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            CombatManager.Instance.AddUIAction(new ShowAttackInformationUIAction(caster.ID, caster.IsUnitCharacter, "Blood Engravings"));
            return true;
        }
    }
    public class BeginEngravingEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            EngravingsEffect.Engraving = true;
            return true;
        }
    }
    public class PseudoEngravingsEffect : EffectSO
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
            stats.statusEffectDataBase.TryGetValue(StatusEffectType.Focused, out var value);
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
                    Focused_StatusEffect focused_StatusEffect = new Focused_StatusEffect();
                    focused_StatusEffect.SetEffectInformation(value);
                    targetSlotInfo.Unit.ApplyStatusEffect(focused_StatusEffect, 0);

                    flag |= damageInfo.beenKilled;
                    exitAmount += damageInfo.damageAmount;

                    if (targetSlotInfo.Unit.CurrentHealth > 0 && damageInfo.damageAmount > 0)
                    {
                        EngravingsEffect.Engravers.Add(targetSlotInfo.Unit);
                    }
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

    public class AllEnemyMaxHealthExitCollectEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (EnemyCombat enemy in stats.EnemiesOnField.Values)
            {
                exitAmount += enemy.CurrentHealth;
            }
            return true;
        }
    }

    public class CountAllStatusEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit && target.Unit != caster && target.Unit is IStatusEffector effector)
                {
                    List<IStatusEffect> statuses = new List<IStatusEffect>(effector.StatusEffects);
                    for (int i = 0; i < statuses.Count; i++)
                    {
                        IStatusEffect toCopy = statuses[i];
                        int amount = toCopy.StatusContent + (toCopy.Restrictor * 4);
                        bool hasNum = toCopy.DisplayText != "";
                        int final = hasNum ? toCopy.StatusContent : 0;
                        exitAmount += Math.Max(final, 1);
                    }
                }
            }
            return exitAmount > 0;
        }
    }

    public class AllTargetsTouchingFrontSingleSizeOnly : Targetting_ByUnit_Side
    {
        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            TargetSlotInfo[] source = base.GetTargets(slots, casterSlotID, isCasterCharacter);
            TargetSlotInfo[] connect = Slots.Front.GetTargets(slots, casterSlotID, isCasterCharacter);
            bool frontHas = connect[0].HasUnit;
            if (!frontHas) return connect;
            List<TargetSlotInfo> ret = new List<TargetSlotInfo>() { connect[0] };
            int start = connect[0].SlotID;
            //int min = start - 1;
            for (int min = start - 1; min >= 0; min--)
            {
                bool cont = false;
                foreach (TargetSlotInfo target in source)
                {
                    if (target.SlotID == min && target.HasUnit)
                    {
                        ret.Add(target);
                        cont = true;
                        break;
                    }
                }
                if (!cont) break;
            }
            for (int max = start + 1; max < 5; max++)
            {
                bool cont = false;
                foreach (TargetSlotInfo target in source)
                {
                    if (target.SlotID == max && target.HasUnit)
                    {
                        ret.Add(target);
                        cont = true;
                        break;
                    }
                }
                if (!cont) break;
            }
            return ret.ToArray();
        }
    }
    public class DivideUpDamageExitValueEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            List<IUnit> guys = new List<IUnit>();
            foreach (TargetSlotInfo target in targets) if (target.HasUnit) guys.Add(target.Unit);
            if (guys.Count > 0)
            {
                float num = base.PreviousExitValue;
                IUnit[] units = guys.ToArray();
                List<int> kill = new List<int>();
                while (guys.Count > 0 && num > 0f)
                {
                    int num2 = Mathf.CeilToInt(num / (float)guys.Count);
                    int index = UnityEngine.Random.Range(0, guys.Count);
                    IUnit unit = guys[index];
                    guys.RemoveAt(index);
                    kill.Add(num2);
                    num -= (float)num2;
                }
                for (int i = 0; i < units.Length && i < kill.Count; i++)
                {
                    int amount = caster.WillApplyDamage(kill[i], units[i]);
                    DamageInfo info = units[i].Damage(amount, caster, DeathType.Basic, -1, addHealthMana: true, directDamage: true, ignoresShield: false);
                    exitAmount += info.damageAmount;
                }
            }
            if (exitAmount > 0) caster.DidApplyDamage(exitAmount);
            return exitAmount > 0;
        }
    }

    public class DamageIfFailDeal1Effect : EffectSO
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
            try
            {
                if (_usePreviousExitValue)
                {
                    entryVariable *= base.PreviousExitValue;
                }

                exitAmount = 0;
                bool flag = false;
                foreach (TargetSlotInfo targetSlotInfo in targets)
                {
                    if (targetSlotInfo.HasUnit)
                    {
                        int targetSlotOffset = (areTargetSlots ? (targetSlotInfo.SlotID - targetSlotInfo.Unit.SlotID) : (-1));
                        int amount = entryVariable;
                        DamageInfo damageInfo;
                        CombatManager.Instance.AddUIAction(new TickFibonacciShowTextUIAction(targetSlotInfo.Unit.ID, targetSlotInfo.Unit.IsUnitCharacter, ""));
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
            catch (Exception g)
            {
                if (DoDebugs.MiscInfo)
                {
                    Debug.LogError("Merced big damage number mega failed");
                    Debug.LogError(g + g.StackTrace);
                    UnityEngine.Diagnostics.Utils.ForceCrash(~ForcedCrashCategory.Abort);
                }
            }
            exitAmount = 0;
            return false;
        }
    }
    public static class CountFibonacci
    {
        public static List<int> list = new List<int>() { 0, 1, 1 };
        public static int Get(int index)
        {
            if (index < list.Count) return list[index];
            else
            {
                for (int i = list.Count; i <= index; i++)
                {
                    int pick = 0;
                    pick += list[list.Count - 1];
                    pick += list[list.Count - 2];
                    list.Add(pick);
                }
                return list[index];
            }
        }
        public static string click = "";
        public static DamageType type = (DamageType)371001;
    }
    public class TickFibonacciShowTextUIAction : CombatAction
    {
        public int _id;

        public bool _isUnitCharacter;

        public string _attackName;

        public TickFibonacciShowTextUIAction(int id, bool isUnitCharacter, string attackName)
        {
            _id = id;
            _isUnitCharacter = isUnitCharacter;
            _attackName = attackName;
            CharacterCombat c;
        }

        public override IEnumerator Execute(CombatStats stats)
        {
            CountFibonacci.click = stats.audioController.uiSelect;
            if (stats.combatUI._charactersInCombat.TryGetValue(_id, out var value))
                for (int i = 0; i < 42; i++)
                {
                    Vector3 characterPosition = stats.combatUI._characterZone.GetCharacterPosition(value.FieldID);
                    stats.combatUI._popUpHandler3D.StartDamageShowcase(isFieldText: false, characterPosition, CountFibonacci.Get(i), CountFibonacci.type);
                    RuntimeManager.PlayOneShot(CountFibonacci.click, characterPosition);
                    for (int j = 0; j < 6; j++) yield return null;
                }
        }
    }
    public class HasSpaceCondition : EffectConditionSO
    {
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            return CombatManager.Instance._stats.CharactersOnField.Values.Count < 5;
        }
    }
    public class ReturnCurrentHealthEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = caster.CurrentHealth;
            return true;
        }
    }
    public class CopyAndSpawnCustomCharacterAnywhereLikeCasterEffect : EffectSO
    {
        [Header("Rank Data")]
        [CharacterRef]
        [SerializeField]
        public string _characterCopy = "";

        [SerializeField]
        public int _rank;

        [SerializeField]
        public NameAdditionLocID _nameAddition;

        [SerializeField]
        public bool _permanentSpawn;

        [SerializeField]
        public bool _usePreviousAsHealth;

        [SerializeField]
        public WearableStaticModifierSetterSO[] _extraModifiers;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            CharacterSO charcater = LoadedAssetsHandler.GetCharcater(_characterCopy);
            if (charcater == null || charcater.Equals(null))
            {
                return false;
            }

            int currentHealth = caster.CurrentHealth;
            charcater.GenerateAbilities(out var firstAbility, out var secondAbility);
            WearableStaticModifiers modifiers = new WearableStaticModifiers();
            HealthColorChange_Wearable_SMS yes = ScriptableObject.CreateInstance<HealthColorChange_Wearable_SMS>();
            yes._healthColor = caster.HealthColor;
            MaxHealthChange_Wearable_SMS ha = ScriptableObject.CreateInstance<MaxHealthChange_Wearable_SMS>();
            ha.maxHealthChange = caster.MaximumHealth - charcater.GetMaxHealth(_rank);
            WearableStaticModifierSetterSO[] extraModifiers = new WearableStaticModifierSetterSO[] { yes, ha };
            for (int i = 0; i < extraModifiers.Length; i++)
            {
                extraModifiers[i].OnAttachedToCharacter(modifiers, charcater, _rank);
            }

            string nameAdditionData = LocUtils.LocDB.GetNameAdditionData(_nameAddition);
            for (int j = 0; j < entryVariable; j++)
            {
                CombatManager.Instance.AddSubAction(new SpawnCharacterAction(charcater, -1, trySpawnAnyways: false, nameAdditionData, _permanentSpawn, _rank, firstAbility, secondAbility, currentHealth, modifiers));
            }

            exitAmount = entryVariable;
            return true;
        }
    }
    public class AbilitySelector_Indicator : AbilitySelector_ByRarity
    {
        [Header("Special Abilities")]
        [SerializeField]
        public string sense = Abili.TransSen.name;

        public override bool UsesRarity => true;
        static UnitStoredValueNames val => (UnitStoredValueNames)2828917;

        public override int GetNextAbilitySlotUsage(List<CombatAbility> abilities, IUnit unit)
        {
            if (!unit.ContainsPassiveAbility(PassiveAbilityTypes.Withering)) return base.GetNextAbilitySlotUsage(abilities, unit);
            List<CombatAbility> newlist = new List<CombatAbility>();
            for (int i = 0; i < abilities.Count; i++)
            {
                CombatAbility ability = abilities[i];
                if (ability.ability._abilityName == sense)
                {
                    unit.ForgetAbility(sense);
                }
                else newlist.Add(ability);
            }
            if (newlist.Count <= 0)
            {
                if (unit.GetStoredValue(val) > 30)
                {
                    unit.SetStoredValue(val, 0);
                    return -1;
                }
                if (unit is EnemyCombat enemy)
                {
                    enemy.UnforgetAbilities();
                    unit.SetStoredValue(val, unit.GetStoredValue(val) + 1);
                    List<CombatAbility> next = enemy.GetAvailableAbilities();
                    return GetNextAbilitySlotUsage(next, enemy);
                }
                else return -1;
            }
            unit.SetStoredValue(val, 0);
            return base.GetNextAbilitySlotUsage(newlist, unit);
        }
    }
    public class EmptyEnemySpaceNoWitheringEffectCondition : EffectConditionSO
    {
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            if (caster.ContainsPassiveAbility(PassiveAbilityTypes.Withering)) return false;
            foreach (CombatSlot slot in CombatManager.Instance._stats.combatSlots.EnemySlots) if (!slot.HasUnit) return true;
            return false;
        }
    }
    public class IsUnitEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets) if (target.HasUnit) exitAmount++;
            return exitAmount > 0;
        }
    }
    public class RemoveAllWaterEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i].IsTargetCharacterSlot)
                {
                    exitAmount += stats.combatSlots.CharacterSlots[targets[i].SlotID].TryRemoveSlotStatusEffect((SlotStatusEffectType)WaterInfo.Water);
                }
                else
                {
                    exitAmount += stats.combatSlots.EnemySlots[targets[i].SlotID].TryRemoveSlotStatusEffect((SlotStatusEffectType)WaterInfo.Water);
                }
            }

            return exitAmount > 0;
        }
    }
    public class ApplyWaterLastExitEffect : ApplyWaterSlotEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (base.PreviousExitValue <= 0) return false;
            return base.PerformEffect(stats, caster, targets, areTargetSlots, Math.Max(1, (int)Math.Floor(((float)base.PreviousExitValue) / 2)), out exitAmount);
        }
    }
    public class PlayHealthColorSoundUIAction : CombatAction
    {
        public override IEnumerator Execute(CombatStats stats)
        {
            stats.combatUI._characterZone._unitSoundsHandler.PlayHealthColorEvent();
            yield return null;
        }
    }
    public class PlayHealthColorSoundEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            CombatManager.Instance.AddUIAction(new PlayHealthColorSoundUIAction());
            return true;
        }
    }
    public class SpawnChildrenEffect : SpawnEnemyAnywhereEffect
    {
        public static UnitStoredValueNames value => (UnitStoredValueNames)2720067;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (!stats.InCombat) return false;
            for (int i = caster.GetStoredValue(value); i > 0; i -= 6)
            {
                if (i >= 6 && Check.EnemyExist("Children6_EN")) enemy = LoadedAssetsHandler.GetEnemy("Children6_EN");
                else if (Check.EnemyExist("Children" + i.ToString() + "_EN")) enemy = LoadedAssetsHandler.GetEnemy("Children" + i.ToString() + "_EN");
                else enemy = LoadedAssetsHandler.GetEnemy("SilverSuckle_EN");
                base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out int exi);
            }
            exitAmount = caster.GetStoredValue(value);
            caster.SetStoredValue(value, 0);
            return exitAmount > 0;
        }
    }
    public static class ParasiteEffection
    {
        public static ApplyParasiteEffect apply
        {
            get
            {
                ParasitePassiveAbility parasitePassiveAbility = ScriptableObject.CreateInstance<ParasitePassiveAbility>();
                parasitePassiveAbility.conditions = ((AddPassiveEffect)LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[5].effect)._passiveToAdd.conditions;
                parasitePassiveAbility._damagePercentage = ((ParasitePassiveAbility)((AddPassiveEffect)LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[5].effect)._passiveToAdd)._damagePercentage;
                parasitePassiveAbility.connectionEffects = ExtensionMethods.ToEffectInfoArray(new Effect[0]);
                CasterSetStoredValueEffect casterSetStoredValueEffect = ScriptableObject.CreateInstance<CasterSetStoredValueEffect>();
                casterSetStoredValueEffect._valueName = (UnitStoredValueNames)14;
                SpawnChildrenEffect sp = ScriptableObject.CreateInstance<SpawnChildrenEffect>();
                sp.enemy = Check.EnemyExist("Children1_EN") ? LoadedAssetsHandler.GetEnemy("Children1_EN") : LoadedAssetsHandler.GetEnemy("SilverSuckle_EN");
                sp._spawnType = SpawnType.Basic;
                parasitePassiveAbility.disconnectionEffects = ExtensionMethods.ToEffectInfoArray(new Effect[]
                {
                new Effect(casterSetStoredValueEffect, 0, null, Slots.Self, null),
                new Effect(sp, 1, null, Slots.Self)
                });
                parasitePassiveAbility.connectionImmediateEffect = ((ParasitePassiveAbility)((AddPassiveEffect)LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[5].effect)._passiveToAdd).connectionImmediateEffect;
                parasitePassiveAbility.disconnectionImmediateEffect = ((ParasitePassiveAbility)((AddPassiveEffect)LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[5].effect)._passiveToAdd).disconnectionImmediateEffect;
                parasitePassiveAbility.doesPassiveTriggerInformationPanel = ((AddPassiveEffect)LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[5].effect)._passiveToAdd.doesPassiveTriggerInformationPanel;
                DealRandomAmountDamageConvertToParasiteEffect dealRandomAmountDamageConvertToParasiteEffect = ScriptableObject.CreateInstance<DealRandomAmountDamageConvertToParasiteEffect>();
                dealRandomAmountDamageConvertToParasiteEffect._indirect = true;
                dealRandomAmountDamageConvertToParasiteEffect._minAmount = 1;
                dealRandomAmountDamageConvertToParasiteEffect._passiveToAdd = parasitePassiveAbility;
                parasitePassiveAbility.effects = ExtensionMethods.ToEffectInfoArray(new Effect[]
                {
                new Effect(dealRandomAmountDamageConvertToParasiteEffect, 1, null, Slots.Self, null)
                });
                parasitePassiveAbility.passiveIcon = ((AddPassiveEffect)LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[5].effect)._passiveToAdd.passiveIcon;
                parasitePassiveAbility.specialStoredValue = ((ParasitePassiveAbility)((AddPassiveEffect)LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[5].effect)._passiveToAdd).specialStoredValue;
                parasitePassiveAbility.type = (PassiveAbilityTypes)45;
                parasitePassiveAbility._characterDescription = "Increases the damage received by 5% per point of Parasite. Parasite will decrease by the original unmutliplied damage amount. Parasite will remove 0-1 health from this party member at the end of every turn and convert it into more Parasite.";
                parasitePassiveAbility._damagePercentage = ((ParasitePassiveAbility)((AddPassiveEffect)LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[5].effect)._passiveToAdd)._damagePercentage;
                parasitePassiveAbility._enemyDescription = "Increases the damage received by 5% per point of Parasite. Parasite will decrease by the original unmutliplied damage amount. Parasite will remove 0-1 health from this enemy at the end of every turn and convert it into more Parasite.";
                parasitePassiveAbility._isFriendly = false;
                parasitePassiveAbility._parasiteShield = ((ParasitePassiveAbility)((AddPassiveEffect)LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[5].effect)._passiveToAdd)._parasiteShield;
                parasitePassiveAbility._passiveName = "Parasitism";
                parasitePassiveAbility._secondTriggerOn = ((ParasitePassiveAbility)((AddPassiveEffect)LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[5].effect)._passiveToAdd)._secondTriggerOn;
                parasitePassiveAbility._thirdTriggerOn = ((ParasitePassiveAbility)((AddPassiveEffect)LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[5].effect)._passiveToAdd)._thirdTriggerOn;
                parasitePassiveAbility._triggerOn = ((AddPassiveEffect)LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[5].effect)._passiveToAdd._triggerOn;
                ApplyParasiteEffect applyParasiteEffect = ScriptableObject.CreateInstance<ApplyParasiteEffect>();
                applyParasiteEffect._passiveToAdd = parasitePassiveAbility;
                return applyParasiteEffect;
            }
        }
    }
    public class CasterSetStoredValueEffect : EffectSO
    {
        [SerializeField]
        public UnitStoredValueNames _valueName = (UnitStoredValueNames)2;

        public override bool PerformEffect(
          CombatStats stats,
          IUnit caster,
          TargetSlotInfo[] targets,
          bool areTargetSlots,
          int entryVariable,
          out int exitAmount)
        {
            exitAmount = 0;
            caster.SetStoredValue(this._valueName, entryVariable);
            return exitAmount > 0;
        }
    }
    public class DealRandomAmountDamageConvertToParasiteEffect : EffectSO
    {
        [SerializeField]
        public DeathType _deathType = (DeathType)1;
        [SerializeField]
        public bool _usePreviousExitValue;
        [SerializeField]
        public bool _ignoreShield;
        [SerializeField]
        public bool _indirect;
        [SerializeField]
        public bool _returnKillAsSuccess;
        [SerializeField]
        public int _minAmount = 0;
        [SerializeField]
        public BasePassiveAbilitySO _passiveToAdd = Passives.Parasitism;

        public override bool PerformEffect(
          CombatStats stats,
          IUnit caster,
          TargetSlotInfo[] targets,
          bool areTargetSlots,
          int entryVariable,
          out int exitAmount)
        {
            if (this._usePreviousExitValue)
                entryVariable *= this.PreviousExitValue;
            exitAmount = 0;
            bool flag = false;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    int num1 = UnityEngine.Random.Range(this._minAmount, entryVariable);
                    int num2 = areTargetSlots ? target.SlotID - target.Unit.SlotID : -1;
                    int num3 = num1;
                    DamageInfo damageInfo;
                    if (this._indirect)
                    {
                        damageInfo = target.Unit.Damage(num3, (IUnit)null, this._deathType, num2, false, false, true, (DamageType)0);
                    }
                    else
                    {
                        int num4 = caster.WillApplyDamage(num3, target.Unit);
                        damageInfo = target.Unit.Damage(num4, caster, this._deathType, num2, true, true, this._ignoreShield, (DamageType)0);
                    }
                    flag |= damageInfo.beenKilled;
                    exitAmount += damageInfo.damageAmount;
                    if (damageInfo.damageAmount > 0)
                    {
                        int damageAmount = damageInfo.damageAmount;
                        IUnit unit = target.Unit;
                        if (!unit.ContainsPassiveAbility((PassiveAbilityTypes)45))
                            unit.AddPassiveAbility(this._passiveToAdd);
                        int num5 = unit.GetStoredValue((UnitStoredValueNames)14) + damageAmount;
                        unit.SetStoredValue((UnitStoredValueNames)14, num5);
                    }
                }
            }
            if (!this._indirect && exitAmount > 0)
                caster.DidApplyDamage(exitAmount);
            return !this._returnKillAsSuccess ? exitAmount > 0 : flag;
        }
    }
    public class ApplyParasiteEffect : EffectSO
    {
        [SerializeField]
        public BasePassiveAbilitySO _passiveToAdd = Passives.Parasitism;

        public override bool PerformEffect(
          CombatStats stats,
          IUnit caster,
          TargetSlotInfo[] targets,
          bool areTargetSlots,
          int entryVariable,
          out int exitAmount)
        {
            exitAmount = 0;
            for (int index = 0; index < targets.Length; ++index)
            {
                if (targets[index].HasUnit)
                {
                    if (!targets[index].Unit.ContainsPassiveAbility((PassiveAbilityTypes)45))
                        targets[index].Unit.AddPassiveAbility(this._passiveToAdd);
                    int num = targets[index].Unit.GetStoredValue((UnitStoredValueNames)14) + entryVariable;
                    targets[index].Unit.SetStoredValue((UnitStoredValueNames)14, num);
                    targets[index].Unit.SetStoredValue(SpawnChildrenEffect.value, targets[index].Unit.GetStoredValue(SpawnChildrenEffect.value) + 1);
                    exitAmount += num;
                }
            }
            return exitAmount > 0;
        }
    }
    public static class ShockTherapyHandler
    {
        public static void TransformCharacterLowerLevel(this CharacterCombat self, CharacterSO character, bool fullyHeal, bool maintainMaxHealth, bool currentToMaxHealth)
        {
            self.RemoveAndDisconnectAllPassiveAbilities();
            self.Character = character;
            self.Name = self.Character.GetName();
            self.ClampedRank = self.Character.ClampRank(self.Rank + self.CharacterWearableModifiers.RankModifier - 1);
            self.CurrencyMultiplier = self.CharacterWearableModifiers.CurrencyMultiplierModifier;
            if (!maintainMaxHealth)
            {
                self.MaximumHealth = self.Character.GetMaxHealth(self.ClampedRank);
            }

            if (currentToMaxHealth)
            {
                self.MaximumHealth = Mathf.Max(self.CurrentHealth, 1);
            }

            self.MaximumHealth = Mathf.Max(1, self.CharacterWearableModifiers.MaximumHealthModifier + self.MaximumHealth);
            self.HealthColor = (self.CharacterWearableModifiers.HasHealthColorModifier ? self.CharacterWearableModifiers.HealthColorModifier : self.Character.healthColor);
            self.CurrentHealth = (fullyHeal ? self.MaximumHealth : Mathf.Min(self.CurrentHealth, self.MaximumHealth));
            self.SetUpDefaultAbilities(updateUI: true);
            self.UnitType = self.Character.unitType;
            self.Size = 1;
            self.DefaultPassiveAbilityInitialization();
        }
        public static bool TryTransformCharacterLowerLevel(this CombatStats self, int id, CharacterSO transformation, bool fullyHeal, bool maintainMaxHealth, bool currentToMaxHealth)
        {
            if (transformation == null || transformation.Equals(null))
            {
                return false;
            }

            if (!self.Characters.ContainsKey(id))
            {
                return false;
            }

            CharacterCombat characterCombat = self.Characters[id];
            if (!characterCombat.IsAlive)
            {
                return false;
            }

            characterCombat.TransformCharacterLowerLevel(transformation, fullyHeal, maintainMaxHealth, currentToMaxHealth);
            CombatManager.Instance.AddUIAction(new CharacterTransformUIAction(characterCombat, characterCombat.HealthColor, characterCombat.CurrentHealth, characterCombat.MaximumHealth));
            characterCombat.ConnectPassives();
            return true;
        }
    }
    public class ShockTherapyEffect : DamageEffect
    {
        public static UnitStoredValueNames HasTransformed => (UnitStoredValueNames)7207237;
        public static CharacterSO getRandom()
        {
            CharacterSO ret = new List<CharacterSO>(LoadedAssetsHandler.LoadedCharacters.Values).GetRandom();
            for (int i = 0; i < 144; i++)
            {
                if (ret == null || ret.Equals(null)) ret = new List<CharacterSO>(LoadedAssetsHandler.LoadedCharacters.Values).GetRandom();
                else break;
            }
            return ret;
        }
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit && target.Unit is CharacterCombat chara)
                {
                    if (chara.GetStoredValue(HasTransformed) > 0)
                    {
                        CharacterSO c = getRandom();
                        for (int i = 0; i < 144 && (!c.HasRankedData|| c.rankedData.Length < chara.Rank); i++) c = getRandom();
                        if (stats.TryTransformCharacterLowerLevel(chara.ID, c, false, false, false)) exitAmount++;
                        base.PerformEffect(stats, caster, target.SelfArray(), areTargetSlots, entryVariable, out int exi);
                    }
                    else 
                    {
                        CharacterSO c = getRandom();
                        for (int i = 0; i < 144 && (!c.HasRankedData || c.rankedData.Length <= chara.Rank); i++) c = getRandom();
                        if (stats.TryTransformCharacter(chara.ID, c, false, false, false)) exitAmount++;
                        chara.SetStoredValue(HasTransformed, 1);
                    }
                }
            }
            return exitAmount > 0;
        }
    }
    public static class ReplacementHandler
    {
        public static UnitStoredValueNames Value => (UnitStoredValueNames)2088994;
        public static void NotifCheck(string notificationName, object sender, object args)
        {
            if (notificationName == TriggerCalls.OnKill.ToString() && sender is IUnit unit)
            {
                unit.SetStoredValue(Value, unit.GetStoredValue(Value) + 1);
            }
        }
    }
    public class ReplacementDamageEffect : DamageEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            List<TargetSlotInfo> newTarg = new List<TargetSlotInfo>();
            foreach (TargetSlotInfo target in targets) if (target.HasUnit && target.Unit.GetStoredValue(ReplacementHandler.Value) > 0) newTarg.Add(target);
            return base.PerformEffect(stats, caster, newTarg.ToArray(), areTargetSlots, entryVariable, out exitAmount);
        }
    }
}
