﻿using BrutalAPI;
using JetBrains.Annotations;
using MonoMod.RuntimeDetour;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using THE_DEAD;
using UnityEngine;
using static Hawthorne.CustomIntentIconSystem;
using static UnityEngine.GraphicsBuffer;

namespace Hawthorne
{
    public static class Bbili
    {
        static Ability _windy;
        public static Ability Windy
        {
            get
            {
                if (_windy == null)
                {
                    _windy = new Ability()
                    {
                        name = "Windy Day",
                        description = "Move to the Left or Right. Inflict 2 Slip on the Left and Right enemy positions.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 2, IntentType.Swap_Sides, Slots.Self),
                            new Effect(ScriptableObject.CreateInstance<ApplySlipSlotEffect>(), 2, GetIntent("Slip"), Slots.Sides)
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Swirl"),
                        animationTarget = Slots.Self,
                    };
                }
                return _windy;
            }
        }
        static Ability _drift;
        public static Ability Drift
        {
            get
            {
                if (_drift == null)
                {
                    _drift = new Ability()
                    {
                        name = "Drift",
                        description = "Inflict 3 Slip on the Opposing party member position. Inflict 2 Ruptured on the Left and Right party members.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ApplySlipSlotEffect>(), 3, GetIntent("Slip"), Slots.Front),
                            new Effect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 2, IntentType.Status_Ruptured, Slots.LeftRight)
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Wheel"),
                        animationTarget = Slots.Front,
                    };
                }
                return _drift;
            }
        }
        static Ability _rush;
        public static Ability Rush
        {
            get
            {
                if (_rush == null)
                {
                    _rush = new Ability()
                    {
                        name = "Rush",
                        description = "Move to Right. Inflict 3 Left and 2 Ruptured on the Opposing party member, then move to the Left or Right.",
                        rarity = 3,
                        effects = new Effect[]
                        {
                            new Effect(BasicEffects.GoRight, 1, IntentType.Swap_Right, Slots.Self),
                            new Effect(BasicEffects.GetVisuals("Salt/Shatter", false, Slots.Front), 1, null, Slots.Front),
                            new Effect(ScriptableObject.CreateInstance<ApplyLeftEffect>(), 3, (IntentType)846738, Slots.Front),
                            new Effect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 2, IntentType.Status_Ruptured, Slots.Front),
                            new Effect(SubActionEffect.Create(new Effect[] { new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, null, Slots.Self) }), 1, IntentType.Swap_Sides, Slots.Self)
                        },
                        visuals = null,
                        animationTarget = Slots.Self,
                    };
                }
                return _rush;
            }
        }
        static Ability _check;
        public static Ability Check
        {
            get
            {
                if (_check == null)
                {
                    _check = new Ability()
                    {
                        name = "Check",
                        description = "If the Light phase is not green, shift the Light phase up by one.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(BasicEffects.GetVisuals("Salt/Notif", false, Slots.Self), 1, null, Slots.Self, ScriptableObject.CreateInstance<TrainCondition>()),
                            new Effect(ScriptableObject.CreateInstance<TrainEffect>(), 1, IntentType.Misc, Slots.Self, ScriptableObject.CreateInstance<TrainCondition>()),
                        },
                        visuals = null,
                        animationTarget = Slots.Self,
                    };
                }
                return _check;
            }
        }
        static Ability _back;
        public static Ability Back
        {
            get
            {
                if (_back == null)
                {
                    _back = new Ability()
                    {
                        name = "Back Up",
                        description = "If the Light phase is not green, shift the Light phase down by one.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(BasicEffects.GetVisuals("Salt/Rain", false, Slots.Self), 1, null, Slots.Self, ScriptableObject.CreateInstance<TrainCondition>()),
                            new Effect(ScriptableObject.CreateInstance<TrainEffect>(), -1, IntentType.Misc, Slots.Self, ScriptableObject.CreateInstance<TrainCondition>()),
                        },
                        visuals = null,
                        animationTarget = Slots.Self,
                    };
                }
                return _back;
            }
        }
        static Ability _petrify;
        public static Ability Petrify
        {
            get
            {
                if (_petrify == null)
                {
                    _petrify = new Ability()
                    {
                        name = "Petrify",
                        description = "Deal a Painful amount of damage to the Opposing party member. \nMove Left, and change the Right enemy's health color to this enemy's health color and inflict 1 Pimples on them.",
                        rarity = 8,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 4, IntentType.Damage_3_6, Slots.Front),
                            new Effect(BasicEffects.GoLeft, 1, IntentType.Swap_Left, Slots.Self),
                            new Effect(ScriptableObject.CreateInstance<ChangeTargetHealthColorCasterHealthColorEffect>(), 1, IntentType.Mana_Modify, Slots.SlotTarget(new int[]{1 }, true)),
                            new Effect(ScriptableObject.CreateInstance<ApplyPimplesEffect>(), 1, GetIntent("Pimples"), Slots.SlotTarget(new int[]{ 1 }, true))
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Cannon"),
                        animationTarget = Slots.Front,
                    };
                }
                return _petrify;
            }
        }
        static Ability _partition;
        public static Ability Partition
        {
            get
            {
                if (_partition == null)
                {
                    _partition = new Ability()
                    {
                        name = "Partition",
                        description = "Deal a Painful amount of damage to the Opposing party member. \nMove Right, and change the Left enemy's health color to this enemy's health color and inflict 1 Pimples on them.",
                        rarity = 8,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 4, IntentType.Damage_3_6, Slots.Front),
                            new Effect(BasicEffects.GoRight, 1, IntentType.Swap_Right, Slots.Self),
                            new Effect(ScriptableObject.CreateInstance<ChangeTargetHealthColorCasterHealthColorEffect>(), 1, IntentType.Mana_Modify, Slots.SlotTarget(new int[]{-1 }, true)),
                            new Effect(ScriptableObject.CreateInstance<ApplyPimplesEffect>(), 1, GetIntent("Pimples"), Slots.SlotTarget(new int[]{-1 }, true))
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Cannon"),
                        animationTarget = Slots.Front,
                    };
                }
                return _partition;
            }
        }
        static Ability _postular;
        public static Ability Postular
        {
            get
            {
                if (_postular == null)
                {
                    ApplyPimplesEffect rando = ScriptableObject.CreateInstance<ApplyPimplesEffect>();
                    rando._randomBetweenPrevious = true;
                    _postular = new Ability()
                    {
                        name = "Postular",
                        description = "Inflict 1-2 Pimple on all other enemies with this enemy's health color.",
                        rarity = 3,
                        priority = -20,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, null, TargettingBySameHealthColor.Create(true, false, true)),
                            new Effect(rando, 2, GetIntent("Pimples"), TargettingBySameHealthColor.Create(true, false, true)),
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Pop"),
                        animationTarget = TargettingBySameHealthColor.Create(true, false, true),
                    };
                }
                return _postular;
            }
        }
        static Ability _politics;
        public static Ability Politics
        {
            get
            {
                if (_politics == null)
                {
                    _politics = new Ability()
                    {
                        name = "Please the Politics",
                        description = "Inflict 1 Pimple on every party member.",
                        rarity = 3,
                        priority = 6,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ApplyPimplesEffect>(), 1, GetIntent("Pimples"), Targetting.AllEnemy),
                        },
                        visuals = LoadedAssetsHandler.GetCharacterAbility("Insult_1_A").visuals,
                        animationTarget = Targetting.AllEnemy,
                    };
                }
                return _politics;
            }
        }
        static Ability _portrait;
        public static Ability Portrait
        {
            get
            {
                if (_portrait == null)
                {
                    _portrait = new Ability()
                    {
                        name = "Please the Portrait",
                        description = "Inflict 3 Linked on all party members who used Blue pigment last turn.",
                        rarity = 5,
                        priority = 0,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ApplyLinkedEffect>(), 3, IntentType.Status_Linked, TargettingByUsedBlue.Create(false))
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Door"),
                        animationTarget = TargettingByUsedBlue.Create(false),
                    };
                }
                return _portrait;
            }
        }
        static Ability _point;
        public static Ability Point
        {
            get
            {
                if (_point == null)
                {
                    _point = new Ability()
                    {
                        name = "Please the Point",
                        description = "Apply 8 Shield to the Left and Right enemy positions. Move to the Left or Right.",
                        rarity = 8,
                        priority = 0,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 8, IntentType.Field_Shield, Slots.Sides),
                            new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, IntentType.Swap_Sides, Slots.Self)
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Keyhole"),
                        animationTarget = Slots.Self,
                    };
                }
                return _point;
            }
        }
        static Ability _plight;
        public static Ability Plight
        {
            get
            {
                if (_plight == null)
                {
                    _plight = new Ability()
                    {
                        name = "Please the Plight",
                        description = "Randomize all non-Purple pigment in the pigment tray into Purple. Randomize all Purple pigment into a random other color.",
                        rarity = 3,
                        priority = 0,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<RandomizeAllPurpleAndNonPurpleEffect>(), 1, IntentType.Mana_Randomize, Slots.Self)
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Shatter"),
                        animationTarget = Slots.Self,
                    };
                }
                return _plight;
            }
        }
        static Ability _pledge;
        public static Ability Pledge
        {
            get
            {
                if (_pledge == null)
                {
                    _pledge = new Ability()
                    {
                        name = "Please the Pledge",
                        description = "Apply 3 Haste to this enemy. \nApply 5 Shield to this enemy.",
                        rarity = 3,
                        priority = -3,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ApplyHasteEffect>(), 3, GetIntent("Haste"), Slots.Self),
                            new Effect(ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 5, IntentType.Field_Shield, Slots.Self),
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Cube"),
                        animationTarget = Slots.Self,
                    };
                }
                return _pledge;
            }
        }
        static Ability _temper;
        public static Ability Temper
        {
            get
            {
                if (_temper == null)
                {
                    ChangeMaxHealthEffect add = ScriptableObject.CreateInstance<ChangeMaxHealthEffect>();
                    add._increase = true;
                    _temper = new Ability()
                    {
                        name = "Temper the Glass",
                        description = "Randomize this enemy's health color. Increase this enemy's maximum health by 10 and heal it.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<RandomizeTargetHealthColorsNotSameEffect>(), 1, IntentType.Mana_Modify, Slots.Self),
                            new Effect(add, 10, IntentType.Other_MaxHealth, Slots.Self),
                            new Effect(ScriptableObject.CreateInstance<HealEffect>(), 10, IntentType.Heal_5_10, Slots.Self)
                            
                        },
                        visuals = LoadedAssetsHandler.GetCharacterAbility("Absolve_1_A").visuals,
                        animationTarget = Slots.Self,
                    };
                }
                return _temper;
            }
        }
        static Ability _scorchLeft;
        public static Ability ScorchLeft
        {
            get
            {
                if (_scorchLeft == null)
                {
                    CustomOpponentTargetting_BySlot_Index tar = ScriptableObject.CreateInstance<CustomOpponentTargetting_BySlot_Index>();
                    tar._frontOffsets = new int[1] { 0 };
                    tar._slotPointerDirections = new int[1];
                    _scorchLeft = new Ability()
                    {
                        name = "Scorch Left",
                        description = "Inflict 3 Fire on the Left Opposing party member position.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), 3, IntentType.Field_Fire, tar),

                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Scorch"),
                        animationTarget = tar,
                    };
                }
                return _scorchLeft;
            }
        }
        static Ability _scourgeRight;
        public static Ability ScourgeRight
        {
            get
            {
                if (_scourgeRight == null)
                {
                    CustomOpponentTargetting_BySlot_Index tar = ScriptableObject.CreateInstance<CustomOpponentTargetting_BySlot_Index>();
                    tar._frontOffsets = new int[1] { 1 };
                    tar._slotPointerDirections = new int[1];
                    _scourgeRight = new Ability()
                    {
                        name = "Scourge Right",
                        description = "Inflict 3 Fire on the Right Opposing party member position.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), 3, IntentType.Field_Fire, tar),

                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Scorch"),
                        animationTarget = tar,
                    };
                }
                return _scourgeRight;
            }
        }
        static Ability _phosphate;
        public static Ability Phosphate
        {
            get
            {
                if (_phosphate == null)
                {
                    _phosphate = new Ability()
                    {
                        name = "Phosphate Fumes",
                        description = "Deal a Little indirect damage to all party members.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(BasicEffects.Indirect, 1, IntentType.Damage_1_2, Targetting.AllEnemy)
                        },
                        visuals = LoadedAssetsHandler.GetCharacterAbility("OfDeath_1_A").visuals,
                        animationTarget = Targetting.AllEnemy,
                    };
                }
                return _phosphate;
            }
        }
        static Ability _norimimi;
        public static Ability Norimimi
        {
            get
            {
                if (_norimimi == null)
                {
                    RemovePassiveEffect r = ScriptableObject.CreateInstance<RemovePassiveEffect>();
                    r._passiveToRemove = Passi.DragonAwakeFake.type;
                    AddPassiveEffect a = ScriptableObject.CreateInstance<AddPassiveEffect>();
                    a._passiveToAdd = Passi.DragonAwakeReal;
                    new CustomIntentInfo("Sleepy", (IntentType)3737410, ResourceLoader.LoadSprite("AsleepDragonPassive.png"), IntentType.Misc);
                    _norimimi = new Ability()
                    {
                        name = "Norimimi",
                        description = "Inflict 1 Fire on all party member positions. Go to sleep at the end of the round.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), 1, IntentType.Field_Fire, Slots.SlotTarget(new int[]{-4, -3, -2, -1, 0, 1, 2, 3, 4}, false)),
                            new Effect(r, 1, GetIntent("Sleepy"), Slots.Self),
                            new Effect(a, 1, null, Slots.Self)

                        },
                        visuals = LoadedAssetsHandler.GetCharacterAbility("Insult_1_A").visuals,
                        animationTarget = Slots.Self,
                    };
                }
                return _norimimi;
            }
        }
        static Ability _sneeze;
        public static Ability Sneeze
        {
            get
            {
                if (_sneeze == null)
                {
                    _sneeze = new Ability()
                    {
                        name = "Sneeze",
                        description = "Inflict 1 Fire on the Opposing positions.",
                        rarity = 3,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), 1, IntentType.Field_Fire, Slots.Front)
                        },
                        visuals = LoadedAssetsHandler.GetEnemyAbility("Flood_A").visuals,
                        animationTarget = Slots.Front,
                    };
                }
                return _sneeze;
            }
        }
        static Ability _snore;
        public static Ability Snore
        {
            get
            {
                if (_snore == null)
                {
                    _snore = new Ability()
                    {
                        name = "Snore",
                        description = "Does nothing.",
                        rarity = 10,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<WasteTimeEffect>(), 1, null, null)
                        },
                        visuals = null,
                        animationTarget = Slots.Self,
                    };
                }
                return _snore;
            }
        }
        static Ability _drool;
        public static Ability Drool
        {
            get
            {
                if (_drool == null)
                {
                    _drool = new Ability()
                    {
                        name = "Drool",
                        description = "Inflict 3 Oil-Slicked on the Opposing party members.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ApplyOilSlickedEffect>(), 1, IntentType.Status_OilSlicked, Slots.Front)
                        },
                        visuals = LoadedAssetsHandler.GetCharacterAbility("Oil_1_A").visuals,
                        animationTarget = Slots.Front,
                    };
                }
                return _drool;
            }
        }
        static Ability _snort;
        public static Ability Snort
        {
            get
            {
                if (_snort == null)
                {
                    _snort = new Ability()
                    {
                        name = "Snort",
                        description = "This enemy might take a little indirect damage.",
                        rarity = 2,
                        effects = new Effect[]
                        {
                            new Effect(BasicEffects.GetVisuals("Scream_1_A", true, Slots.Self), 1, null, Slots.Self, Conditions.Chance(50)),
                            new Effect(BasicEffects.Indirect, 1, IntentType.Damage_1_2, Slots.Self, BasicEffects.DidThat(true)),
                            new Effect(ScriptableObject.CreateInstance<WasteTimeEffect>(), 1, null, Slots.Self, BasicEffects.DidThat(false, 2))
                        },
                        visuals = null,
                        animationTarget = Slots.Front,
                    };
                }
                return _snort;
            }
        }
        static Ability _mar;
        public static Ability Mar
        {
            get
            {
                if (_mar == null)
                {
                    _mar = new Ability()
                    {
                        name = "Mar",
                        description = "Deal a barely Painful amount of damage to the Left and Right party members. \nIf either attack misses, gain 1 Scar per missed attack.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<DamageScarIfMissEffect>(), 3, IntentType.Damage_3_6, Slots.LeftRight),
                            new Effect(BasicEffects.Empty, 1, IntentType.Status_Scars, Slots.Self)
                        },
                        visuals = LoadedAssetsHandler.GetEnemyAbility("Talons_A").visuals,
                        animationTarget = Slots.LeftRight,
                    };
                }
                return _mar;
            }
        }
        static Ability _torture;
        public static Ability Torture
        {
            get
            {
                if (_torture == null)
                {
                    _torture = new Ability()
                    {
                        name = "Torture",
                        description = "Deal a Little damage to this enemy twice. Consume 3 random pigment.",
                        rarity = 10,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 1, IntentType.Damage_1_2, Slots.Self),
                            new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 1, IntentType.Damage_1_2, Slots.Self),
                            new Effect(ScriptableObject.CreateInstance<ConsumeRandomManaEffect>(), 3, IntentType.Mana_Consume, Slots.Self)
                        },
                        visuals = LoadedAssetsHandler.GetCharacterAbility("Purify_1_A").visuals,
                        animationTarget = Slots.Self,
                    };
                }
                return _torture;
            }
        }
        static Ability _overbite;
        public static Ability Overbite
        {
            get
            {
                if (_overbite == null)
                {
                    _overbite = new Ability()
                    {
                        name = "Overbite",
                        description = "Deal a Barely Painful amount of damage to the Opposing party member. If damage is not dealt, deal it to this enemy instead.",
                        rarity = 12,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 3, IntentType.Damage_3_6, Slots.Front),
                            new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 3, IntentType.Damage_3_6, Slots.Self, BasicEffects.DidThat(false)),
                        },
                        visuals = LoadedAssetsHandler.GetEnemyAbility("Gnaw_A").visuals,
                        animationTarget = Slots.Front,
                    };
                }
                return _overbite;
            }
        }
        static Ability _sugar;
        public static Ability Sugar
        {
            get
            {
                if (_sugar == null)
                {
                    _sugar = new Ability()
                    {
                        name = "Shard of Sugar",
                        description = "Deal a Barely Painful amount of damage to this enemy. Increase Bone Spurs on this enemy by 2.",
                        rarity = 1,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 3, IntentType.Damage_3_6, Slots.Self),
                            new Effect(ScriptableObject.CreateInstance<ApplyBoneSpursByTwoCasterEffect>(), 2, IntentType.Misc, Slots.Self),
                        },
                        visuals = LoadedAssetsHandler.GetCharacterAbility("Absolve_1_A").visuals,
                        animationTarget = Slots.Self,
                    };
                }
                return _sugar;
            }
        }
        static Ability _nibble;
        public static Ability Nibble
        {
            get
            {
                if (_nibble == null)
                {
                    _nibble = new Ability()
                    {
                        name = "Nibble",
                        description = LoadedAssetsHandler.GetEnemyAbility("Nibble_A")._description,
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 1, IntentType.Damage_1_2, Slots.Front),
                        },
                        visuals = LoadedAssetsHandler.GetEnemyAbility("Nibble_A").visuals,
                        animationTarget = Slots.Front,
                    };
                }
                return _nibble;
            }
        }
        static Ability _colors;
        public static Ability Colors
        {
            get
            {
                if (_colors == null)
                {
                    _colors = new Ability()
                    {
                        name = "Remember Colors",
                        description = "Randomize all Resistances. Produce 2 of each color of primary Pigment. \nInflict 1 Scar on this enemy.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<RandomizeResistancesEffect>(), 1, (IntentType)3773404, Slots.Self),
                            new Effect(BasicEffects.GenPigment(Pigments.Red), 2, IntentType.Mana_Generate, Slots.Self),
                            new Effect(BasicEffects.GenPigment(Pigments.Blue), 2, null, Slots.Self),
                            new Effect(BasicEffects.GenPigment(Pigments.Yellow), 2, null, Slots.Self),
                            new Effect(BasicEffects.GenPigment(Pigments.Purple), 2, null, Slots.Self),
                            new Effect(ScriptableObject.CreateInstance<ApplyScarsEffect>(), 1, IntentType.Status_Scars, Slots.Self)
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Rose"),
                        animationTarget = Slots.Self,
                    };
                }
                return _colors;
            }
        }
        static Ability _holdHands;
        public static Ability HoldHands
        {
            get
            {
                if (_holdHands == null)
                {
                    GenericTargetting_BySlot_Index farthest = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
                    farthest.slotPointerDirections = new int[] { 0, 4 };
                    farthest.getAllies = false;
                    _holdHands = new Ability()
                    {
                        name = "Hold Hands",
                        description = "Remove 1 random Resistance.\nInflict 50 Pale and Curse the Leftmost and Rightmost party member grid positions.\nInflict 1 Scar on this enemy.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<RemoveRandomResistanceEffect>(), 1, (IntentType)3773404, Slots.Self),
                            new Effect(ScriptableObject.CreateInstance<ApplyPaleByTenEffect>(), 5, (IntentType)666888, farthest),
                            new Effect(ScriptableObject.CreateInstance<ApplyCursedEffect>(), 1, IntentType.Status_Cursed, farthest),
                            new Effect(ScriptableObject.CreateInstance<ApplyScarsEffect>(), 1, IntentType.Status_Scars, Slots.Self),
                        },
                        visuals = LoadedAssetsHandler.GetCharacterAbility("Weave_1_A").visuals,
                        animationTarget = farthest,
                    };
                }
                return _holdHands;
            }
        }
        static Ability _voice;
        public static Ability Voice
        {
            get
            {
                if (_voice == null)
                {
                    _voice = new Ability()
                    {
                        name = "Your Voice",
                        description = "Curse the Opposing party member and deal a Painful amount of damage to them. \nIf no damage was dealt, deal it to this enemy instead. \nInflict 1 Scar on this enemy.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ApplyCursedEffect>(), 1, IntentType.Status_Cursed, Slots.Front),
                            new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 5, IntentType.Damage_3_6, Slots.Front),
                            new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 5, IntentType.Damage_3_6, Slots.Self, BasicEffects.DidThat(false)),
                            new Effect(ScriptableObject.CreateInstance<ApplyScarsEffect>(), 1, IntentType.Status_Scars, Slots.Self)
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Whisper"),
                        animationTarget = Slots.Front,
                    };
                }
                return _voice;
            }
        }
        static Ability _onSight;
        public static Ability OnSight
        {
            get
            {
                if (_onSight == null)
                {
                    _onSight = new Ability()
                    {
                        name = "On Sight",
                        description = "If the Far Far Left or Far Far Right party members have either manually moved or used an ability last turn, deal an Agonizing amount of damage to them.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<OnSightEffect>(), 7, IntentType.Damage_7_10, Slots.SlotTarget(new int[]{-3, 3}, false)),
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Cannon"),
                        animationTarget = Slots.SlotTarget(new int[] { -3, 3 }, false),
                    };
                }
                return _onSight;
            }
        }
        static Ability _trackPrints;
        public static Ability TrackPrints
        {
            get
            {
                if (_trackPrints == null)
                {
                    _trackPrints = new Ability()
                    {
                        name = "Track the Prints",
                        description = "Apply 0-2 Slip to every party member position. \nMove Left or Right and gain another action.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<MaybeApplySlipUpToEntryEffect>(), 2, CustomIntentIconSystem.GetIntent("Slip"), Slots.SlotTarget(new int[]{-4, -3, -2, -1, 0, 1, 2, 3, 4}, false)),
                            new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, IntentType.Swap_Sides, Slots.Self),
                            new Effect(ScriptableObject.CreateInstance<AddTurnTargetToTimelineEffect>(), 1, IntentType.Misc, Slots.Self)
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Gaze"),
                        animationTarget = Slots.SlotTarget(new int[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 }, false),
                    };
                }
                return _trackPrints;
            }
        }
        static Ability _markThem;
        public static Ability MarkThem
        {
            get
            {
                if (_markThem == null)
                {
                    _markThem = new Ability()
                    {
                        name = "Mark Them",
                        description = "If the Far Far Left or Far Far Right party members are Frailed, deal an Agonizing amount of damage to them.\nInflict 3 Frail on the Far Left and Far Right party members.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<MarkThemEffect>(), 10, IntentType.Damage_7_10, Slots.SlotTarget(new int[]{-3, 3}, false)),
                            new Effect(ScriptableObject.CreateInstance<ApplyFrailEffect>(), 3, IntentType.Status_Frail, Slots.SlotTarget(new int[]{-2, 2}, false)),
                        },
                        visuals = LoadedAssetsHandler.GetEnemyAbility("Crush_A").visuals,
                        animationTarget = Slots.SlotTarget(new int[] { -3, 3 }, false),
                    };
                }
                return _markThem;
            }
        }
        static Ability _ringingNoise;
        public static Ability RingingNoise
        {
            get
            {
                if (_ringingNoise == null)
                {
                    _ringingNoise = new Ability()
                    {
                        name = "Ringing Noise",
                        description = "Apply 2 Slip on the Opposing position. \nDeal a Little damage to this enemy and inflict 1 Scar on it. \n50% chance to queue this ability again.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ApplySlipSlotEffect>(), 2, GetIntent("Slip"), Slots.Front),
                            new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 1, IntentType.Damage_1_2, Slots.Self),
                            new Effect(ScriptableObject.CreateInstance<ApplyScarsEffect>(), 1, IntentType.Status_Scars, Slots.Self),
                            new Effect(ScriptableObject.CreateInstance<RingingNoiseEffect>(), 1, IntentType.Misc, Slots.Self, Conditions.Chance(50))
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Class"),
                        animationTarget = Slots.Front,
                    };
                }
                return _ringingNoise;
            }
        }
        static Ability _bash;
        public static Ability Bash
        {
            get
            {
                if (_bash == null)
                {
                    _bash = new Ability()
                    {
                        name = "Bash",
                        description = "Deal a Painful amount of damage to the Opposing party member and move them Left or Right.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 5, IntentType.Damage_3_6, Slots.Front),
                            new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, IntentType.Swap_Sides, Slots.Front),
                        },
                        visuals = LoadedAssetsHandler.GetEnemyAbility("Bash_A").visuals,
                        animationTarget = Slots.Front,
                    };
                }
                return _bash;
            }
        }
        static Ability _stingingPain;
        public static Ability StingingPain
        {
            get
            {
                if (_stingingPain == null)
                {
                    _stingingPain = new Ability()
                    {
                        name = "Stinging Pain",
                        description = "Inflict 2 Ruptured on the Opposing party member.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 2, IntentType.Status_Ruptured, Slots.Front),
                        },
                        visuals = LoadedAssetsHandler.GetEnemyAbility("Wriggle_A").visuals,
                        animationTarget = Slots.Front,
                    };
                }
                return _stingingPain;
            }
        }
        static Ability _eyeFive;
        public static Ability EyeFive
        {
            get
            {
                if (_eyeFive == null)
                {
                    GenericTargetting_BySlot_Index target = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
                    target.getAllies = false;
                    target.slotPointerDirections = new int[] { 4 };
                    _eyeFive = new Ability()
                    {
                        name = "Slaughter One",
                        description = "Deal a Painful amount of damage to the Rightmost position. Gain 2 Power.",
                        rarity = 999999999,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 6, IntentType.Damage_3_6, target),
                            new Effect(ScriptableObject.CreateInstance<ApplyPowerEffect>(), 2, (IntentType)987895, Slots.Self),
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Decapitate"),
                        animationTarget = target,
                    };
                }
                return _eyeFive;
            }
        }
        static Ability _eyeFour;
        public static Ability EyeFour
        {
            get
            {
                if (_eyeFour == null)
                {
                    GenericTargetting_BySlot_Index target = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
                    target.getAllies = false;
                    target.slotPointerDirections = new int[] { 3 };
                    _eyeFour = new Ability()
                    {
                        name = "Slaughter Two",
                        description = "Deal a Painful amount of damage to the Center Right position. Gain 2 Power.",
                        rarity = 9999999,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 6, IntentType.Damage_3_6, target),
                            new Effect(ScriptableObject.CreateInstance<ApplyPowerEffect>(), 2, (IntentType)987895, Slots.Self),
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Decapitate"),
                        animationTarget = target,
                    };
                }
                return _eyeFour;
            }
        }
        static Ability _eyeThree;
        public static Ability EyeThree
        {
            get
            {
                if (_eyeThree == null)
                {
                    GenericTargetting_BySlot_Index target = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
                    target.getAllies = false;
                    target.slotPointerDirections = new int[] { 2 };
                    _eyeThree = new Ability()
                    {
                        name = "Slaughter Three",
                        description = "Deal a Painful amount of damage to the Central position. Gain 2 Power.",
                        rarity = 99999,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 6, IntentType.Damage_3_6, target),
                            new Effect(ScriptableObject.CreateInstance<ApplyPowerEffect>(), 2, (IntentType)987895, Slots.Self),
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Decapitate"),
                        animationTarget = target,
                    };
                }
                return _eyeThree;
            }
        }
        static Ability _eyeTwo;
        public static Ability EyeTwo
        {
            get
            {
                if (_eyeTwo == null)
                {
                    GenericTargetting_BySlot_Index target = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
                    target.getAllies = false;
                    target.slotPointerDirections = new int[] { 1 };
                    _eyeTwo = new Ability()
                    {
                        name = "Slaughter Four",
                        description = "Deal a Painful amount of damage to the Center Left position. Gain 2 Power.",
                        rarity = 999,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 6, IntentType.Damage_3_6, target),
                            new Effect(ScriptableObject.CreateInstance<ApplyPowerEffect>(), 2, (IntentType)987895, Slots.Self),
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Decapitate"),
                        animationTarget = target,
                    };
                }
                return _eyeTwo;
            }
        }
        static Ability _eyeOne;
        public static Ability EyeOne
        {
            get
            {
                if (_eyeOne == null)
                {
                    GenericTargetting_BySlot_Index target = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
                    target.getAllies = false;
                    target.slotPointerDirections = new int[] { 0 };
                    _eyeOne = new Ability()
                    {
                        name = "Slaughter Five",
                        description = "Deal a Painful amount of damage to the Leftmost position. Gain 2 Power.",
                        rarity = 9,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 6, IntentType.Damage_3_6, target),
                            new Effect(ScriptableObject.CreateInstance<ApplyPowerEffect>(), 2, (IntentType)987895, Slots.Self),
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Decapitate"),
                        animationTarget = target,
                    };
                }
                return _eyeOne;
            }
        }
        static Ability _weathering;
        public static Ability Weathering
        {
            get
            {
                if (_weathering == null)
                {
                    _weathering = new Ability()
                    {
                        name = "Weathering",
                        description = "Inflict 2 Scars on this enemy.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ApplyScarsEffect>(), 2, IntentType.Status_Scars, Slots.Self),
                        },
                        visuals = null,
                        animationTarget = Slots.Self,
                    };
                }
                return _weathering;
            }
        }
        static Ability _putrification;
        public static Ability Putrification
        {
            get
            {
                if (_putrification == null)
                {
                    _putrification = new Ability()
                    {
                        name = "Putrification",
                        description = "Move all Party Members away from this enemy.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(BasicEffects.GoRight, 1, IntentType.Swap_Right, Slots.SlotTarget(new int[]{4, 3, 2, 1}, false)),
                            new Effect(BasicEffects.GoLeft, 1, IntentType.Swap_Left, Slots.SlotTarget(new int[]{-4, -3, -2, -1}, false)),
                            new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, IntentType.Swap_Sides, Slots.Front),
                        },
                        visuals = LoadedAssetsHandler.GetEnemyAbility("Wriggle_A").visuals ,
                        animationTarget = Slots.Self,
                    };
                }
                return _putrification;
            }
        }
        static Ability _buriedUnder;
        public static Ability BuriedUnder
        {
            get
            {
                if (_buriedUnder == null)
                {
                    _buriedUnder = new Ability()
                    {
                        name = "Buried Under",
                        description = "Inflict 2 Mold on every position",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ApplyMoldSlotEffect>(), 2, GetIntent("Mold"), MultiTargetting.Create(Slots.SlotTarget(new int[]{-4, -3, -2, -1, 0, 1, 2, 3, 4}, false), Slots.SlotTarget(new int[]{-4, -3, -2, -1, 0, 1, 2, 3, 4}, true))),
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Claws"),
                        animationTarget = MultiTargetting.Create(Slots.SlotTarget(new int[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 }, false), Slots.SlotTarget(new int[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 }, true)),
                    };
                }
                return _buriedUnder;
            }
        }
        static Ability _frontCannon;
        public static Ability FrontCannon
        {
            get
            {
                if (_frontCannon == null)
                {
                    _frontCannon = new Ability()
                    {
                        name = "Frontal Cannon",
                        description = "Deal a Painful amount of damage to the Opposing party member.",
                        rarity = 100,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 6, IntentType.Damage_3_6, Slots.Front),
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Cannon"),
                        animationTarget = Slots.Front,
                    };
                }
                return _frontCannon;
            }
        }
        static Ability _farCannon;
        public static Ability FarCannon
        {
            get
            {
                if (_farCannon == null)
                {
                    _farCannon = new Ability()
                    {
                        name = "Far Cannon",
                        description = "Deal a Painful amount of damage to the Far Left and Far Right party members.",
                        rarity = 100,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 6, IntentType.Damage_3_6, Slots.SlotTarget(new int[]{-2, 2}, false)),
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Cannon"),
                        animationTarget = Slots.SlotTarget(new int[] { -2, 2 }, false),
                    };
                }
                return _farCannon;
            }
        }
        static Ability _wheelingHigh;
        public static Ability WheelingHigh
        {
            get
            {
                if (_wheelingHigh == null)
                {
                    _wheelingHigh = new Ability()
                    {
                        name = "Wheeling",
                        description = "Move to the Left or Right twice.",
                        rarity = 100,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, IntentType.Swap_Sides, Slots.Self),
                            new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, IntentType.Swap_Sides, Slots.Self),
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Wheel"),
                        animationTarget = Slots.Self,
                    };
                }
                return _wheelingHigh;
            }
        }
        static Ability _encampment;
        public static Ability Encampment
        {
            get
            {
                if (_encampment == null)
                {
                    _encampment = new Ability()
                    {
                        name = "Encampment",
                        description = "Apply 4 Shield to the Left or Right positions, then move Left or Right.",
                        rarity = 100,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 4, IntentType.Field_Shield, Slots.Sides),
                            new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, IntentType.Swap_Sides, Slots.Self),
                        },
                        visuals = LoadedAssetsHandler.GetCharacterAbility("Entrenched_1_A").visuals,
                        animationTarget = Slots.Self,
                    };
                }
                return _encampment;
            }
        }
        static Ability _grandBlast;
        public static Ability GrandBlast
        {
            get
            {
                if (_grandBlast == null)
                {
                    _grandBlast = new Ability()
                    {
                        name = "Grand Blast",
                        description = "Might deal a Deadly amount of damage to every party member.",
                        rarity = 1,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 0, null, Slots.SlotTarget(new int[]{-4, -3, -2, -1, 0, 1, 2, 3, 4}, false)),
                            new Effect(ScriptableObject.CreateInstance<RandomDamageBetweenPreviousAndEntryEffect>(), 12, IntentType.Damage_11_15, Slots.SlotTarget(new int[]{-4, -3, -2, -1, 0, 1, 2, 3, 4}, false)),
                        },
                        visuals = LoadedAssetsHandler.GetCharacterAbility("Clobber_1_A").visuals,
                        animationTarget = Slots.SlotTarget(new int[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 }, false),
                    };
                }
                return _grandBlast;
            }
        }
        static Ability _wheelingLow;
        public static Ability WheelingLow
        {
            get
            {
                if (_wheelingLow == null)
                {
                    _wheelingLow = new Ability()
                    {
                        name = "Wheeling",
                        description = "Move to the Left or Right twice.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, IntentType.Swap_Sides, Slots.Self),
                            new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, IntentType.Swap_Sides, Slots.Self),
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Wheel"),
                        animationTarget = Slots.Self,
                    };
                }
                return _wheelingLow;
            }
        }
        static Ability _laser;
        public static Ability Laser
        {
            get
            {
                if (_laser == null)
                {
                    _laser = new Ability()
                    {
                        name = "Laser",
                        description = "Deal an Agonizing amount of damage to the Opposing position.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 8, IntentType.Damage_7_10, Slots.Front),
                        },
                        visuals = LoadedAssetsHandler.GetEnemyAbility("Crescendo_A").visuals,
                        animationTarget = Slots.Front,
                    };
                }
                return _laser;
            }
        }
        static Ability _trappings;
        public static Ability Trappings
        {
            get
            {
                if (_trappings == null)
                {
                    _trappings = new Ability()
                    {
                        name = "Trappings",
                        description = "Move to the Left or Right and inflict 2 Constricted on the Opposing position.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, IntentType.Swap_Sides, Slots.Self),
                            new Effect(BasicEffects.GetVisuals("Salt/Cube", false, Slots.Front), 1, null, Slots.Front),
                            new Effect(ScriptableObject.CreateInstance<ApplyConstrictedSlotEffect>(), 2, IntentType.Field_Constricted, Slots.Front),
                        },
                        visuals = null,
                        animationTarget = Slots.Front,
                    };
                }
                return _trappings;
            }
        }
        static Ability _gatesHeaven;
        public static Ability GatesHeaven
        {
            get
            {
                if (_gatesHeaven == null)
                {
                    _gatesHeaven = new Ability()
                    {
                        name = "Gates of Heaven",
                        description = "Move in front of the nearest party member.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(CasterSubActionEffect.Create(new Effect[]
                            {
                                new Effect(ScriptableObject.CreateInstance<MoveToClosestTargetEffect>(), 1, IntentType.Swap_Sides, Slots.SlotTarget(new int[9] {-4, -3, -2, -1, 0, 1, 2, 3, 4}, false))
                            }), 1, IntentType.Swap_Sides, Slots.Self)
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Door"),
                        animationTarget = Slots.Self,
                    };
                }
                return _gatesHeaven;
            }
        }
        static Ability _circlesHell;
        public static Ability CirclesHell
        {
            get
            {
                if (_circlesHell == null)
                {
                    _circlesHell = new Ability()
                    {
                        name = "Circles of Hell",
                        description = "Inflict 50 Pale on the Opposing party member.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ApplyPaleEffect>(), 50, Intents.Pale, Slots.Front)
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Curse"),
                        animationTarget = Slots.Front,
                    };
                }
                return _circlesHell;
            }
        }
        static Ability _nailing;
        public static Ability Nailing
        {
            get
            {
                if (_nailing == null)
                {
                    _nailing = new Ability()
                    {
                        name = "Nailing",
                        description = "Deal an Agonizing amount of damage to the Oppoisng party member and inflict 2 Ruptured and 2 Constricted on them.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 10, IntentType.Damage_7_10, Slots.Front),
                            new Effect(ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 2, IntentType.Status_Ruptured, Slots.Front),
                            new Effect(ScriptableObject.CreateInstance<ApplyConstrictedSlotEffect>(), 2, IntentType.Field_Constricted, Slots.Front),
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Nailing"),
                        animationTarget = Slots.Front,
                    };
                }
                return _nailing;
            }
        }
        static Ability _gulp;
        public static Ability Gulp
        {
            get
            {
                if (_gulp == null)
                {
                    _gulp = new Ability()
                    {
                        name = "Gulp",
                        description = LoadedAssetsHandler.GetEnemyAbility("Gulp_A").GetAbilityLocData().description,
                        rarity = 5,
                        priority = -3,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ConsumeRandomManaEffect>(), 1, IntentType.Mana_Consume, Slots.Self),
                            new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, IntentType.Swap_Sides, Slots.Self),
                            new Effect(ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 2, IntentType.Field_Shield, Slots.Self),
                        },
                        visuals = LoadedAssetsHandler.GetEnemyAbility("Gulp_A").visuals,
                        animationTarget = Slots.Self,
                    };
                }
                return _gulp;
            }
        }
        static Ability _alarm;
        public static Ability Alarm
        {
            get
            {
                if (_alarm == null)
                {
                    _alarm = new Ability()
                    {
                        name = "Alarm",
                        description = "30% chance to spawn a random single tile Fish(?) enemy, doubles the chance if this is the only enemy in combat.\nIf this fails, give this enemy another action.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<SpawnFishEffect>(), 1, IntentType.Other_Spawn, Slots.Self, ScriptableObject.CreateInstance<AlarmCondition>()),
                            new Effect(ScriptableObject.CreateInstance<AddTurnTargetToTimelineEffect>(), 1, IntentType.Misc, Slots.Self, BasicEffects.DidThat(false)),
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Alarm"),
                        animationTarget = Slots.Self,
                    };
                }
                return _alarm;
            }
        }
        static Ability _coward;
        public static Ability Coward
        {
            get
            {
                if (_coward == null)
                {
                    IsFrontTargetCondition front = ScriptableObject.CreateInstance<IsFrontTargetCondition>();
                    front.returnTrue = true;
                    _coward = new Ability()
                    {
                        name = "Coward",
                        description = "If there is an Opposing party member, gain 10 Shield.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, null, Slots.Self, front),
                            new Effect(BasicEffects.GetVisuals("Weep_A", false, Slots.Self), 1, null, Slots.Self, BasicEffects.DidThat(true)),
                            new Effect(ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 10, IntentType.Field_Shield, Slots.Self, BasicEffects.DidThat(true, 2))
                        },
                        visuals = null,
                        animationTarget = Slots.Self,
                    };
                }
                return _coward;
            }
        }
        static Ability _opportunist;
        public static Ability Opportunist
        {
            get
            {
                if (_opportunist == null)
                {
                    IsFrontTargetCondition front = ScriptableObject.CreateInstance<IsFrontTargetCondition>();
                    front.returnTrue = true;
                    _opportunist = new Ability()
                    {
                        name = "Opportunist",
                        description = "If there is an Opposing party member, apply 5 Shield on the Left and Right enemy positions and move Left or Right..",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, null, Slots.Self, front),
                            new Effect(BasicEffects.GetVisuals("Salt/Notif", false, Slots.Self), 1, null, Slots.Self, BasicEffects.DidThat(true)),
                            new Effect(ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 5, IntentType.Field_Shield, Slots.Sides, BasicEffects.DidThat(true, 2)),
                            new Effect(CasterSubActionEffect.Create(new Effect[]
                            {
                                new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, null, Slots.Self),
                            }), 1, IntentType.Swap_Sides, Slots.Self, BasicEffects.DidThat(true, 3)),
                        },
                        visuals = null,
                        animationTarget = Slots.Self,
                    };
                }
                return _opportunist;
            }
        }
        static Ability _wobble;
        public static Ability Wobble
        {
            get
            {
                if (_wobble == null)
                {
                    _wobble = new Ability()
                    {
                        name = "Wobble",
                        description = "Move to the Left or Right.\nApply 5 Shield to this enemy's position.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, IntentType.Swap_Sides, Slots.Self),
                            new Effect(ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 5, IntentType.Field_Shield, Slots.Self),
                        },
                        visuals = LoadedAssetsHandler.GetEnemyAbility("Wriggle_A").visuals,
                        animationTarget = Slots.Self,
                    };
                }
                return _wobble;
            }
        }
        static Ability _obliterate;
        public static Ability Obliterate
        {
            get
            {
                if (_obliterate == null)
                {
                    _obliterate = new Ability()
                    {
                        name = "Obliterate",
                        description = "Deal this enemy's current health as damage to the Opposing party member and obliterate this enemy.",
                        rarity = 5,
                        effects = new Effect[]
                        {
                            new Effect(ScriptableObject.CreateInstance<DamageByCasterHealthEffect>(), 1, IntentType.Damage_16_20, Slots.Front),
                            new Effect(ScriptableObject.CreateInstance<DirectDeathEffect>(), 1, IntentType.Damage_Death, Slots.Self),
                        },
                        visuals = CustomVisuals.GetVisuals("Salt/Curse"),
                        animationTarget = Slots.Front,
                    };
                }
                return _obliterate;
            }
        }
    }
    public class TrainEffect : EffectSO
    {
        public static UnitStoredValueNames Value => (UnitStoredValueNames)3709472;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            int yeah = caster.GetStoredValue(Value);
            yeah += entryVariable;
            int run = 0;
            while (yeah < 0 || yeah > 2)
            {
                if (yeah > 2) yeah -= 3;
                if (yeah <0) yeah += 3;
                run++;
                if (run > 1000)
                {
                    yeah = 0;
                    break;
                }
            }
            caster.SetStoredValue(Value, yeah);
            CombatManager.Instance.AddUIAction(new AnimationParameterSetterIntUIAction(caster.ID, caster.IsUnitCharacter, "light", yeah));
            exitAmount = yeah;
            return true;
        }
    }
    public class AnimationParameterSetterIntUIAction : CombatAction
    {
        public int _id;

        public bool _isCharacter;

        public string _parameterName;

        public int _parameterValue;

        public AnimationParameterSetterIntUIAction(int id, bool isCharacter, string parameterName, int parameterValue)
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
                stats.combatUI.TrySetCharacterAnimatorParameterInt(_id, _parameterName, _parameterValue);
            }
            else
            {
                stats.combatUI.TrySetEnemyAnimatorParameterInt(_id, _parameterName, _parameterValue);
            }

            yield break;
        }
    }
    public static class TrainEXT
    {
        public static void TrySetCharacterAnimatorParameterInt(this CombatVisualizationController self, int id, string parameterName, int parameter)
        {
            if (self._charactersInCombat.TryGetValue(id, out var value))
            {
                self._characterZone._characters[value.FieldID].FieldEntity.CH_TrySetAnimatorParameterInt(parameterName, parameter);
            }
        }
        public static void TrySetEnemyAnimatorParameterInt(this CombatVisualizationController self, int id, string parameterName, int parameter)
        {
            if (self._enemiesInCombat.TryGetValue(id, out var value))
            {
                self._enemyZone._enemies[value.FieldID].FieldEntity.EN_TrySetAnimatorParameterInt(parameterName, parameter);
            }
        }

        public static void CH_TrySetAnimatorParameterInt(this CharacterInFieldLayout self, string parameterName, int parameter)
        {
            try
            {
                self._animator.SetInteger(parameterName, parameter);
            }
            catch
            {
                Debug.LogError("failed set int parameter");
            }
            return;
            AnimatorControllerParameter[] parameters = self._animator.parameters;
            foreach (AnimatorControllerParameter animatorControllerParameter in parameters)
            {
                if (animatorControllerParameter.name == parameterName)
                {
                    if (animatorControllerParameter.type == AnimatorControllerParameterType.Int)
                    {
                        self._animator.SetInteger(parameterName, parameter);
                    }

                    break;
                }
            }
        }
        public static void EN_TrySetAnimatorParameterInt(this EnemyInFieldLayout self, string parameterName, int parameter)
        {
            //Debug.Log(self._animator);
            //Debug.Log(self._animator.parameters);
            try
            {
                if (self._animator == null)
                {
                    Debug.LogError("ANIMATOR IS NULL");
                    self._animator = self.gameObject.GetComponent<Animator>();
                }
                //self._animator.SetInteger(parameterName, parameter);
                //return;
            }
            catch
            {
                //Debug.LogError("failed set int parameter");
            }
            //return;
            
            AnimatorControllerParameter[] parameters = self._animator.parameters;
            //Debug.Log("parameter count " + parameters.Length);
            foreach (AnimatorControllerParameter animatorControllerParameter in parameters)
            {
                //Debug.Log("PARAMETER: " + animatorControllerParameter.name + " " + animatorControllerParameter.type.ToString());
                if (animatorControllerParameter.name == parameterName)
                {
                    if (animatorControllerParameter.type == AnimatorControllerParameterType.Int)
                    {
                        self._animator.SetInteger(parameterName, parameter);
                    }

                    break;
                }
            }
        }
    }
    public class TrainCondition : EffectConditionSO
    {
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            return caster.GetStoredValue(TrainEffect.Value) != 2;
        }
    }
    public class SecondTrainCondition : EffectConditionSO
    {
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            return caster.GetStoredValue(TrainEffect.Value) == 2;
        }
    }

    public class TrainTargetting : BaseCombatTargettingSO
    {
        public BaseCombatTargettingSO source = Slots.SlotTarget(new int[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 }, true);
        public static Targetting_ByUnit_Side side;
        public bool GetAll;
        public bool flipple;
        public static void Flip()
        {
            foreach (TrainTargetting t in Resources.FindObjectsOfTypeAll<TrainTargetting>()) t.flipple = !t.flipple;
        }
        public override bool AreTargetAllies
        {
            get
            {
                if (source == null)
                {
                    return false;
                }
                return flipple? !source.AreTargetAllies : source.AreTargetAllies;
            }
        }
        public override bool AreTargetSlots
        {
            get
            {
                if (source == null) return false;
                return source.AreTargetSlots;
            }
        }
        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            if (side == null)
            {
                side = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
                side.getAllUnitSlots = false;
            }
            bool found = false;
            bool getparty = false;
            if (isCasterCharacter)
            {
                foreach (CharacterCombat chara in CombatManager.Instance._stats.CharactersOnField.Values)
                {
                    if (chara.SlotID == casterSlotID)
                    {
                        getparty = chara.GetStoredValue(TrainHandler.HitParty) > 0;
                        found = true;
                        //Debug.Log("FOUND US; found " + found + " || getparty " + getparty);
                        break;
                    }
                }
            }
            else
            {
                foreach (EnemyCombat enemy in CombatManager.Instance._stats.EnemiesOnField.Values)
                {
                    if (enemy.SlotID == casterSlotID)
                    {
                        getparty = enemy.GetStoredValue(TrainHandler.HitParty) > 0;
                        found = true;
//Debug.Log("FOUND US; found " + found + " || getparty " + getparty);
                        break;
                    }
                }
            }
            if (!found) return new TargetSlotInfo[0];
            if (GetAll)
            {
                if (getparty == isCasterCharacter)
                {
                    //Debug.Log("self");
                    source = Slots.SlotTarget(new int[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 }, true);
                    flipple = false;
                    return source.GetTargets(slots, casterSlotID, isCasterCharacter);
                }
                else
                {
                    //Debug.Log("front");
                    source = Slots.SlotTarget(new int[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 }, false);
                    flipple = false;
                    return source.GetTargets(slots, casterSlotID, isCasterCharacter);
                }
                //Debug.Log("all");
                source = side;
                side.getAllies = getparty == isCasterCharacter;
                return source.GetTargets(slots, casterSlotID, isCasterCharacter);
            }
            else
            {
                if (getparty == isCasterCharacter)
                {
                    //Debug.Log("self");
                    source = Slots.Self;
                    flipple = false;
                    return Slots.Self.GetTargets(slots, casterSlotID, isCasterCharacter);
                }
                else
                {
                    //Debug.Log("front");
                    source = Slots.Front;
                    flipple = false;
                    return Slots.Front.GetTargets(slots, casterSlotID, isCasterCharacter);
                }
            }
        }
        public static TrainTargetting Create(bool GetAll)
        {
            TrainTargetting ret = ScriptableObject.CreateInstance<TrainTargetting>();
            ret.GetAll = GetAll;
            return ret;
        }
    }
    public class SigilEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = entryVariable;
            CombatManager.Instance.AddUIAction(new AnimationParameterSetterIntUIAction(caster.ID, caster.IsUnitCharacter, "color", entryVariable));
            return true;
        }
    }
    public static class PigmentUsedCollector
    {
        public static List<ManaColorSO> lastUsed;
        public static int ID;
        public static List<int> UsedBlue;
        public static void UseAbility(Action<CharacterCombat, int, FilledManaCost[]> orig, CharacterCombat self, int abilityID, FilledManaCost[] filledCost)
        {
            if (lastUsed == null)
                lastUsed = new List<ManaColorSO>();
            lastUsed.Clear();
            ID = self.ID;
            foreach (FilledManaCost filledManaCost in filledCost)
                lastUsed.Add(filledManaCost.Mana);
            if (lastUsed.Contains(Pigments.Blue))
            {
                if (UsedBlue == null) UsedBlue = new List<int>();
                UsedBlue.Add(self.ID);
            }
            orig(self, abilityID, filledCost);
        }
        public static void FinalizeAbilityActions(Action<CharacterCombat> orig, CharacterCombat self)
        {
            orig(self);
            ID = -1;
            lastUsed.Clear();
        }
        public static void ClearBlueUsers()
        {
            if (UsedBlue == null) return;
            UsedBlue.Clear();
        }
        public static void Setup()
        {
            IDetour idetour1 = new Hook(typeof(CharacterCombat).GetMethod(nameof(CharacterCombat.UseAbility), ~BindingFlags.Default), typeof(PigmentUsedCollector).GetMethod(nameof(UseAbility), ~BindingFlags.Default));
            IDetour idetour2 = new Hook(typeof(CharacterCombat).GetMethod(nameof(CharacterCombat.FinalizeAbilityActions), ~BindingFlags.Default), typeof(PigmentUsedCollector).GetMethod(nameof(FinalizeAbilityActions), ~BindingFlags.Default));
        }
    }
    public class TargettingByUsedBlue : Targetting_ByUnit_Side
    {
        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            if (PigmentUsedCollector.UsedBlue == null) return new TargetSlotInfo[0];
            TargetSlotInfo[] source = base.GetTargets(slots, casterSlotID, isCasterCharacter);
            List<TargetSlotInfo> ret = new List<TargetSlotInfo>();
            foreach (TargetSlotInfo target in source)
            {
                if (target.HasUnit && PigmentUsedCollector.UsedBlue.Contains(target.Unit.ID)) ret.Add(target);
            }
            return ret.ToArray();
        }
        public static TargettingByUsedBlue Create(bool allies, bool allslots = false, bool ignorecast = false)
        {
            TargettingByUsedBlue ret = ScriptableObject.CreateInstance<TargettingByUsedBlue>();
            ret.getAllies = allies;
            ret.getAllUnitSlots = allslots;
            ret.ignoreCastSlot = ignorecast;
            return ret;
        }
    }
    public class TargettingBySameHealthColor : Targetting_ByUnit_Side
    {
        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            CombatSlot self = null;
            if (isCasterCharacter)
            {
                foreach (CombatSlot slot in slots.CharacterSlots) if (slot.SlotID == casterSlotID)
                    {
                        self = slot;
                        break;
                    }
            }
            else
            {
                foreach (CombatSlot slot in slots.EnemySlots) if (slot.SlotID == casterSlotID)
                    {
                        self = slot;
                        break;
                    }
            }
            if (self == null) return new TargetSlotInfo[0];
            if (!self.HasUnit) return new TargetSlotInfo[0];
            TargetSlotInfo[] source = base.GetTargets(slots, casterSlotID, isCasterCharacter);
            List<TargetSlotInfo> ret = new List<TargetSlotInfo>();
            foreach (TargetSlotInfo target in source)
            {
                if (target.HasUnit && target.Unit.HealthColor == self.Unit.HealthColor) ret.Add(target);
            }
            return ret.ToArray();
        }
        public static TargettingBySameHealthColor Create(bool allies, bool allslots = false, bool ignorecast = false)
        {
            TargettingBySameHealthColor ret = ScriptableObject.CreateInstance<TargettingBySameHealthColor>();
            ret.getAllies = allies;
            ret.getAllUnitSlots = allslots;
            ret.ignoreCastSlot = ignorecast;
            return ret;
        }
    }
    public class ChangeTargetHealthColorIgnorePureEffect : ChangeHealthColorEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            color = caster.HealthColor;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    bool pure = false;
                    BasePassiveAbilitySO yeah = null;
                    if (target.Unit is EnemyCombat enemy && enemy.TryGetPassiveAbility(PassiveAbilityTypes.Pure, out BasePassiveAbilitySO pas))
                    {
                        yeah = pas;
                    }
                    else if (target.Unit is CharacterCombat chara && chara.TryGetPassiveAbility(PassiveAbilityTypes.Pure, out BasePassiveAbilitySO pis))
                    {
                        yeah = pis;
                    }
                    if (target.Unit.TryRemovePassiveAbility(PassiveAbilityTypes.Pure)) pure = true;
                    if (base.PerformEffect(stats, caster, target.SelfArray(), areTargetSlots, entryVariable, out int exi)) exitAmount += exi;
                    if (pure)
                    {
                        if (yeah == null) target.Unit.AddPassiveAbility(Passives.Pure);
                        else target.Unit.AddPassiveAbility(yeah);
                    }
                }
            }
            return exitAmount > 0;
        }
    }
    public class ChangeTargetHealthColorCasterHealthColorEffect : ChangeHealthColorEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            color = caster.HealthColor;
            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
        }
    }
    public class RandomizeAllPurpleAndNonPurpleEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            ManaColorSO[] options = new ManaColorSO[] { Pigments.Red, Pigments.Blue, Pigments.Yellow };
            List<int> list = new List<int>();
            List<ManaColorSO> list2 = new List<ManaColorSO>();
            ManaBarSlot[] manaBarSlots = stats.MainManaBar.ManaBarSlots;
            foreach (ManaBarSlot manaBarSlot in manaBarSlots)
            {
                if (!manaBarSlot.IsEmpty && manaBarSlot.ManaColor == Pigments.Purple)
                {
                    int num = UnityEngine.Random.Range(0, options.Length);
                    manaBarSlot.SetMana(options[num]);
                    list.Add(manaBarSlot.SlotIndex);
                    list2.Add(options[num]);
                }
                else if (!manaBarSlot.IsEmpty && manaBarSlot.ManaColor != Pigments.Purple)
                {
                    manaBarSlot.SetMana(Pigments.Purple);
                    list.Add(manaBarSlot.SlotIndex);
                    list2.Add(Pigments.Purple);
                }
            }

            if (list.Count > 0)
            {
                CombatManager.Instance.AddUIAction(new ModifyManaSlotsUIAction(stats.MainManaBar.ID, list.ToArray(), list2.ToArray()));
            }
            exitAmount = list.Count;
            return exitAmount > 0;
        }
    }
    public class RandomizeTargetHealthColorsNotSameEffect : EffectSO
    {
        public List<ManaColorSO> options;
        bool ignorePure;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (options == null)
            {
                options = new List<ManaColorSO>() { Pigments.Red, Pigments.Blue, Pigments.Yellow, Pigments.Purple };
            }
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit && target.Unit.SlotID != caster.SlotID && target.Unit.HealthColor == caster.HealthColor)
                {
                    List<ManaColorSO> list = new List<ManaColorSO>(options);
                    if (list.Contains(target.Unit.HealthColor)) list.Remove(target.Unit.HealthColor);
                    bool pure = false;
                    BasePassiveAbilitySO yeah = null;
                    if (target.Unit is EnemyCombat enemy && enemy.TryGetPassiveAbility(PassiveAbilityTypes.Pure, out BasePassiveAbilitySO pas))
                    {
                        yeah = pas;
                    }
                    else if (target.Unit is CharacterCombat chara && chara.TryGetPassiveAbility(PassiveAbilityTypes.Pure, out BasePassiveAbilitySO pis))
                    {
                        yeah = pis;
                    }
                    if (ignorePure && target.Unit.TryRemovePassiveAbility(PassiveAbilityTypes.Pure)) pure = true;

                    if (target.Unit.ChangeHealthColor(list.GetRandom())) exitAmount++;
                    if (pure)
                    {
                        if (yeah == null) target.Unit.AddPassiveAbility(Passives.Pure);
                        else target.Unit.AddPassiveAbility(yeah);
                    }
                }
            }
            return exitAmount > 0;
        }
        public static RandomizeTargetHealthColorsNotSameEffect Create(bool ignorepure)
        {
            RandomizeTargetHealthColorsNotSameEffect ret = ScriptableObject.CreateInstance<RandomizeTargetHealthColorsNotSameEffect>();
            ret.ignorePure = ignorepure;
            ret.options = new List<ManaColorSO>() { Pigments.Red, Pigments.Blue, Pigments.Yellow, Pigments.Purple };
            return ret;
        }
    }
    public class SunColorEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (caster.HealthColor == Pigments.Red) exitAmount = 1;
            else if (caster.HealthColor == Pigments.Blue) exitAmount = 2;
            else if (caster.HealthColor == Pigments.Yellow) exitAmount = 3;
            else if (caster.HealthColor == Pigments.Purple) exitAmount = 4;
            else if (caster.HealthColor == Pigments.Gray) exitAmount = 5;
            CombatManager.Instance.AddUIAction(new AnimationParameterSetterIntUIAction(caster.ID, caster.IsUnitCharacter, "light", exitAmount));
            return exitAmount > 0;
        }
    }
    public class SunColorCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is BooleanReference && effector is IUnit unit)
            {
                CombatManager.Instance.AddPrioritySubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[] { new Effect(ScriptableObject.CreateInstance<SunColorEffect>(), 1, null, Slots.Self) }), unit));
                return false;
            }
            return true; 
        }
    }

    public class PowerByDamageCondition : EffectorConditionSO
    {
        public static Sprite sprite;
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (effector is IUnit unit && args is IntegerReference reference)
            {
                CombatStats stats = CombatManager.Instance._stats;
                if (sprite == null) sprite = ResourceLoader.LoadSprite("SweetTooth.png");
                CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(unit.ID, unit.IsUnitCharacter, "Sweet Tooth", sprite));
                StatusEffectInfoSO effectInfo;
                stats.statusEffectDataBase.TryGetValue((StatusEffectType)456789, out effectInfo);

                int amount = reference.value;
                IStatusEffect powerStatusEffect = new Power_StatusEffect(amount);


                IStatusEffector Seffector = unit as IStatusEffector;
                bool hasItAlready = false;
                int thisIndex = 999;
                for (int i = 0; i < Seffector.StatusEffects.Count; i++)
                {
                    if (Seffector.StatusEffects[i].EffectType == powerStatusEffect.EffectType)
                    {
                        thisIndex = i;
                        hasItAlready = true;
                    }
                }
                if (hasItAlready == true && powerStatusEffect.GetType() != Seffector.StatusEffects[thisIndex].GetType())
                {
                    ConstructorInfo[] constructors = Seffector.StatusEffects[thisIndex].GetType().GetConstructors();
                    foreach (ConstructorInfo constructor in constructors)
                    {
                        if (constructor.GetParameters().Length == 2)
                        {
                            powerStatusEffect = (IStatusEffect)Activator.CreateInstance(Seffector.StatusEffects[thisIndex].GetType(), amount, 0);
                        }
                    }
                }

                powerStatusEffect.SetEffectInformation(effectInfo);
                try
                {
                    unit.ApplyStatusEffect(powerStatusEffect, amount);
                }
                catch (Exception ex)
                {
                    CombatManager.Instance.AddUIAction(new ShowAttackInformationUIAction(unit.ID, unit.IsUnitCharacter, "so uh Power was attempted to be applied to this enemy (crystaline corpse eater hi) but it failed and wouldve softlocked normally. so erm. just pretend this didnt happen!"));
                    Debug.LogError(ex.ToString());
                    Debug.LogError(ex.Message + ex.StackTrace);
                }
            }
            return false;
        }
    }
    public class DamageScarIfMissEffect : ApplyScarsEffect
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

        public int IntendedTargets = 2;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            if (_usePreviousExitValue)
            {
                entryVariable *= base.PreviousExitValue;
            }

            for (int i = targets.Length; i < IntendedTargets; i++)
            {
                base.PerformEffect(stats, caster, Slots.Self.GetTargets(stats.combatSlots, caster.SlotID, caster.IsUnitCharacter), Slots.Self.AreTargetSlots, 1, out int exi);
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
                else
                {
                    base.PerformEffect(stats, caster, Slots.Self.GetTargets(stats.combatSlots, caster.SlotID, caster.IsUnitCharacter), Slots.Self.AreTargetSlots, 1, out int exi);
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
        public static DamageScarIfMissEffect Create(int targets)
        {
            DamageScarIfMissEffect ret = ScriptableObject.CreateInstance<DamageScarIfMissEffect>();
            ret.IntendedTargets = targets;
            return ret;
        }
    }
    public class SpawnEnemyWithPowerEffect : SpawnEnemyInSlotFromEntryStringNameEffect
    {
        public int Power;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (!Check.EnemyExist(en)) return false;
            EnemySO enemy = LoadedAssetsHandler.GetEnemy(en);
            for (int num = targets.Length - 1; num >= 0; num--)
            {
                int preferredSlot = entryVariable + targets[num].SlotID;
                CombatManager.Instance.AddSubAction(new CrystalDecayHandler.SpawnEnemyWithPowerAction(enemy, preferredSlot, givesExperience, trySpawnAnywhereIfFail, _spawnType, Power));
            }

            exitAmount = targets.Length;
            return true;
        }
        public static SpawnEnemyWithPowerEffect Create(string enemy, int power, bool anyways = false)
        {
            SpawnEnemyWithPowerEffect ret = ScriptableObject.CreateInstance<SpawnEnemyWithPowerEffect>();
            ret.en = enemy;
            ret.Power = power;
            ret.trySpawnAnywhereIfFail = anyways;
            return ret;
        }
    }
    public static class CrystalDecayHandler
    {
        public static bool AddNewEnemyWithPower(this CombatStats self, EnemySO enemy, int slot, bool givesExperience, SpawnType spawnType, int power)
        {
            int firstEmptyEnemyFieldID = self.GetFirstEmptyEnemyFieldID();
            if (firstEmptyEnemyFieldID == -1)
            {
                return false;
            }

            int count = self.Enemies.Count;
            EnemyCombat enemyCombat = new EnemyCombat(count, firstEmptyEnemyFieldID, enemy, givesExperience);
            self.Enemies.Add(count, enemyCombat);
            self.AddEnemyToField(count, firstEmptyEnemyFieldID);
            self.combatSlots.AddEnemyToSlot(enemyCombat, slot);
            self.timeline.AddEnemyToTimeline(enemyCombat);
            CombatManager.Instance.AddUIAction(new EnemySpawnUIAction(enemyCombat.ID, spawnType));
            enemyCombat.ConnectPassives();
            enemyCombat.InitializationEnd();
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[] { new Effect(ScriptableObject.CreateInstance<ApplyPowerEffect>(), power, null, Slots.Self) }), enemyCombat));
            return true;
        }
        public class SpawnEnemyWithPowerAction : CombatAction
        {
            public int _preferredSlot;

            public EnemySO _enemy;

            public bool _givesExperience;

            public bool _trySpawnAnyways;

            public SpawnType _spawnType;
            public int power;

            public SpawnEnemyWithPowerAction(EnemySO enemy, int preferredSlot, bool givesExperience, bool trySpawnAnyways, SpawnType spawnType, int power)
            {
                _preferredSlot = preferredSlot;
                _givesExperience = givesExperience;
                _enemy = enemy;
                _trySpawnAnyways = trySpawnAnyways;
                _spawnType = spawnType;
                this.power = power;
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
                    stats.AddNewEnemyWithPower(_enemy, num, _givesExperience, _spawnType, power);
                }

                yield return null;
            }
        }
    }
    public class ShowDecayInfoEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(caster.ID, caster.IsUnitCharacter, "Decay", Passives.Decay.passiveIcon));
            return true;
        }
    }
    public class CrystalDecayCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (effector is IUnit unit)
            {
                int amount = 0;
                foreach (IStatusEffect status in (unit as IStatusEffector).StatusEffects)
                {
                    if (status.EffectType == (StatusEffectType)456789) amount = status.StatusContent;
                }
                SpawnEnemyWithPowerEffect e = SpawnEnemyWithPowerEffect.Create("CandyStone_EN", amount, true);
                CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[] { new Effect(ScriptableObject.CreateInstance<ShowDecayInfoEffect>(), 1, null, Slots.Self), new Effect(e, 0, null, Slots.Self) }), unit));
                return false;
            }
            return true;
        }
    }
    public class ResistanceCondition : EffectorConditionSO
    {
        public static UnitStoredValueNames Red => (UnitStoredValueNames)272995;
        public static UnitStoredValueNames Blue => (UnitStoredValueNames)272996;
        public static UnitStoredValueNames Yellow => (UnitStoredValueNames)272997;
        public static UnitStoredValueNames Purple => (UnitStoredValueNames)272998;
        public static UnitStoredValueNames Grey => (UnitStoredValueNames)272999;
        public static Sprite sprite;
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (effector is IUnit unit && args is DamageReceivedValueChangeException e)
            {
                if (sprite == null) sprite = ResourceLoader.LoadSprite("ResistancePassive.png");
                if (!e.directDamage) return false;
                ManaColorSO[] has = unit.GetResistances();
                for (int i = 0; i < PigmentUsedCollector.lastUsed.Count; i++)
                {
                    if (has.Contains(PigmentUsedCollector.lastUsed[i]))
                    {
                        CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(unit.ID, unit.IsUnitCharacter, "Resistance", sprite));
                        e.AddModifier(new MultiplyIntValueModifier(false, 0));
                        return false;
                    }
                }
            }
            else if (effector is IUnit uni) return uni.GetResistances().Length <= 0;
            return false;
        }

    }
    public static class ResistanceHandler
    {
        public static UnitStoredValueNames Red => ResistanceCondition.Red;
        public static UnitStoredValueNames Blue => ResistanceCondition.Blue;
        public static UnitStoredValueNames Yellow => ResistanceCondition.Yellow;
        public static UnitStoredValueNames Purple => ResistanceCondition.Purple;
        public static UnitStoredValueNames Grey => ResistanceCondition.Grey;
        public static ManaColorSO[] GetResistances(this IUnit unit)
        {
            List<ManaColorSO> res = new List<ManaColorSO>();
            if (unit.GetStoredValue(Red) > 0) res.Add(Pigments.Red);
            if (unit.GetStoredValue(Blue) > 0) res.Add(Pigments.Blue);
            if (unit.GetStoredValue(Yellow) > 0) res.Add(Pigments.Yellow);
            if (unit.GetStoredValue(Purple) > 0) res.Add(Pigments.Purple);
            if (unit.GetStoredValue(Grey) > 0) res.Add(Pigments.Gray);
            return res.ToArray();
        }
        public static void SetAllResistances(this IUnit unit, ManaColorSO[] res)
        {
            if (res.Contains(Pigments.Red)) unit.SetStoredValue(Red, 1);
            else unit.SetStoredValue(Red, 0);
            if (res.Contains(Pigments.Blue)) unit.SetStoredValue(Blue, 1);
            else unit.SetStoredValue(Blue, 0);
            if (res.Contains(Pigments.Yellow)) unit.SetStoredValue(Yellow, 1);
            else unit.SetStoredValue(Yellow, 0);
            if (res.Contains(Pigments.Purple)) unit.SetStoredValue(Purple, 1);
            else unit.SetStoredValue(Purple, 0);
            if (res.Contains(Pigments.Gray)) unit.SetStoredValue(Grey, 1);
            else unit.SetStoredValue(Grey, 0);

        }
        public static void AddResistance(this IUnit unit, ManaColorSO res)
        {
            if (res == Pigments.Red) unit.SetStoredValue(Red, 1);
            if (res == Pigments.Blue) unit.SetStoredValue(Blue, 1);
            if (res == Pigments.Yellow) unit.SetStoredValue(Yellow, 1);
            if (res == Pigments.Purple) unit.SetStoredValue(Purple, 1);
            if (res == Pigments.Gray) unit.SetStoredValue(Grey, 1);
        }
        public static void RemoveResistance(this IUnit unit, ManaColorSO res)
        {
            if (res == Pigments.Red) unit.SetStoredValue(Red, 0);
            if (res == Pigments.Blue) unit.SetStoredValue(Blue, 0);
            if (res == Pigments.Yellow) unit.SetStoredValue(Yellow, 0);
            if (res == Pigments.Purple) unit.SetStoredValue(Purple, 0);
            if (res == Pigments.Gray) unit.SetStoredValue(Grey, 0);
        }
        public static ManaColorSO[] GenerateRandomResistances(this IUnit unit, int amount)
        {
            List<ManaColorSO> ret = new List<ManaColorSO>();
            List<ManaColorSO> orig = new List<ManaColorSO>() { Pigments.Red, Pigments.Blue, Pigments.Yellow, Pigments.Purple };
            if (amount >= 4)
            {
                amount = 3;
                ret.Add(Pigments.Gray);
            }
            List<ManaColorSO> has = new List<ManaColorSO>(unit.GetResistances());
            for (int i = 0; i < 4 - amount; i++)
            {
                if (has.Count > 0)
                {
                    ManaColorSO pick = has.GetRandom();
                    has.Remove(pick);
                    if (orig.Contains(pick)) orig.Remove(pick);
                }
            }
             for (int i = 0; i < amount; i++)
            {
                if (orig.Count > 0)
                {
                    ManaColorSO pick = orig.GetRandom();
                    orig.Remove(pick);
                    ret.Add(pick);
                }
            }
            return ret.ToArray();
        }
    }
    public class RandomizeResistancesEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            caster.SetAllResistances(caster.GenerateRandomResistances(caster.GetResistances().Length));
            return true;
        }
    }
    public class RemoveRandomResistanceEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (caster.GetResistances().Length <= 0) return false;
            caster.RemoveResistance(caster.GetResistances().GetRandom());
            return true;
        }
    }
    public class GainRandomResistancesEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            caster.SetAllResistances(caster.GenerateRandomResistances(entryVariable));
            return true;
        }
    }
    public class AddResistanceEffect : EffectSO
    {
        public ManaColorSO resistance;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            caster.AddResistance(resistance); 
            return true;
        }
        public static AddResistanceEffect Create(ManaColorSO mana)
        {
            AddResistanceEffect ret = ScriptableObject.CreateInstance<AddResistanceEffect>();
            ret.resistance = mana;
            return ret;
        }
    }
    public class PerformEffectWithConnectionPassiveAbility : Connection_PerformEffectPassiveAbility
    {
        public EffectInfo[] effects;
        public override void TriggerPassive(object sender, object args)
        {
            IUnit caster = sender as IUnit;
            CombatManager.Instance.AddSubAction(new EffectAction(effects, caster));
        }
    }
    public class AbilitySelector_Dragon : BaseAbilitySelectorSO
    {

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
            if (unit.GetStoredValue(UnitStoredValueNames.DemonCoreW) > 0)
            {
                return (name == "Phosphate Fumes" || name == "Chomp" || name == "Norimimi");
            }
            return false;
        }
    }
    public class ApplyBoneSpursByTwoCasterEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (!caster.ContainsPassiveAbility(PassiveAbilityTypes.BoneSpurs)) caster.AddPassiveAbility(LoadedAssetsHandler.GetCharcater("Fennec_CH").passiveAbilities[0]);
            else caster.SetStoredValue(UnitStoredValueNames.BoneSpursPA, caster.GetStoredValue(UnitStoredValueNames.BoneSpursPA) + 2);
            return true;
        }
    }
    public class DragonOnceCondition : EffectorConditionSO
    {
        public static UnitStoredValueNames Value => (UnitStoredValueNames)28299631;
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (effector is IUnit unit)
            {
                if (unit.GetStoredValue(Value) <= 0)
                {
                    unit.SetStoredValue(Value, 1);
                    return true;
                }
            }
            return false;
        }
    }
    public class SpawnEnemyFromAreaFromEntryEffect : SpawnEnemyInSlotFromEntryStringNameEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            for (int i = 0; i < 20; i++)
            {
                try
                {
                    switch (CombatManager.Instance._informationHolder.Run.CurrentZoneID)
                    {
                        case 0: en = SaltEnemies.Shore.GetRandom(); break;
                        case 1: en = SaltEnemies.Orpheum.GetRandom(); break;
                        case 2: en = SaltEnemies.Garden.GetRandom(); break;
                        default: en = Check.Third ? SaltEnemies.Shore.GetRandom() : Check.Either(SaltEnemies.Orpheum.GetRandom(), SaltEnemies.Garden.GetRandom()); break;
                    }
                    if (Check.EnemyExist(en)) break;
                }
                catch
                {
                    Debug.LogError("torture me not effect failed");
                    if (i > 10) return false;
                }
            }
            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
        }
    }
    public class IsntWitheringDeathCondition : EffectorConditionSO
    {
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (args is DeathReference reffe && reffe.witheringDeath == false) return true;
            return false;
        }
    }
    public class LobotomySongEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (changeMusic != null)
            {
                try { changeMusic.Abort(); } catch { UnityEngine.Debug.LogWarning("lobotomy song thread failed to shut down."); }
            }
            changeMusic = new System.Threading.Thread(GO);
            changeMusic.Start();
            return true;
        }

        public static System.Threading.Thread changeMusic;
        public static void GO()
        {
            int start = 0;
            if (CombatManager.Instance._stats.audioController.MusicCombatEvent.getParameterByName("Lobotomized", out float num) == FMOD.RESULT.OK) start = (int)num;
            //UnityEngine.Debug.Log("going: " + start);
            for (int i = start; i <= 100; i++)
            {
                CombatManager.Instance._stats.audioController.MusicCombatEvent.setParameterByName("Lobotomized", i);
                System.Threading.Thread.Sleep(50);
                //if (i > 95) UnityEngine.Debug.Log("we;re getting there properly");
            }
            //UnityEngine.Debug.Log("done");
        }
    }
    public class RemoveAllStatusEffectsByAmountEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i].HasUnit)
                {
                    if (targets[i].Unit is IStatusEffector effector)
                    {
                        exitAmount += effector.StatusEffects.Count;
                        targets[i].Unit.TryRemoveAllStatusEffects();
                    }
                   else  exitAmount += targets[i].Unit.TryRemoveAllStatusEffects();
                }
            }

            return exitAmount > 0;
        }
    }
    public class OnSightEffect : DamageEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            List<TargetSlotInfo> targeti = new List<TargetSlotInfo>();
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    if (target.Unit.HasManuallySwappedThisTurn || target.Unit.HasManuallyUsedAbilityThisTurn) targeti.Add(target);
                }
            }
            return base.PerformEffect(stats, caster, targeti.ToArray(), areTargetSlots, entryVariable, out exitAmount);
        }
    }
    public class MarkThemEffect : DamageEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            List<TargetSlotInfo> targeti = new List<TargetSlotInfo>();
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    if (target.Unit.ContainsStatusEffect(StatusEffectType.Frail)) targeti.Add(target);
                }
            }
            return base.PerformEffect(stats, caster, targeti.ToArray(), areTargetSlots, entryVariable, out exitAmount);
        }
    }
    public class MaybeApplySlipUpToEntryEffect : ApplySlipSlotEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach(TargetSlotInfo target in targets)
            {
                if (base.PerformEffect(stats, caster, target.SelfArray(), areTargetSlots, UnityEngine.Random.Range(0, entryVariable + 1), out int exi))
                {
                    exitAmount += exi;
                }
            }
            return exitAmount > 0;
        }
    }
    public class RingingNoiseEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (caster is EnemyCombat enemy)
            {
                stats.timeline.AddExtraEnemyTurns(new List<EnemyCombat>() { enemy }, new List<int>() { enemy.GetLastAbilityIDFromNameUsingAbilityName("Ringing Noise") });
            }
            return true;
        }
    }
    public class AbilitySelector_EvilEye : AbilitySelector_ByRarity
    {
        public static UnitStoredValueNames value => (UnitStoredValueNames)838313109;
        public override bool UsesRarity => false;

        public override int GetNextAbilitySlotUsage(List<CombatAbility> abilities, IUnit unit)
        {
            int ret = -1;
            if (unit is EnemyCombat enemy)
            {
                switch (enemy.GetStoredValue(value))
                {
                    case 0: 
                        ret = enemy.GetLastAbilityIDFromNameUsingAbilityName("Slaughter One");
                        enemy.SetStoredValue(value, 1);
                        break;
                    case 1:
                        ret = enemy.GetLastAbilityIDFromNameUsingAbilityName("Slaughter Two");
                        enemy.SetStoredValue(value, 2);
                        break; 
                    case 2:
                        ret = enemy.GetLastAbilityIDFromNameUsingAbilityName("Slaughter Three");
                        enemy.SetStoredValue(value, 3);
                        break;
                    case 3: 
                        ret = enemy.GetLastAbilityIDFromNameUsingAbilityName("Slaughter Four");
                        enemy.SetStoredValue(value, 4);
                        break;
                    case 4:
                        ret = enemy.GetLastAbilityIDFromNameUsingAbilityName("Slaughter Five");
                        enemy.SetStoredValue(value, 0);
                        break;
                }
            }
            if (ret >= 0) return ret;
            else return base.GetNextAbilitySlotUsage(abilities, unit);
        }

    }
    public static class FishPool
    {
        public static List<string> Fish;
        public static void Setup()
        {
            Fish = new List<string>();
            for (int i = 0; i < 2; i++) Fish.Add("Mung_EN");
            for (int i = 0; i < 20; i++) Fish.Add("MudLung_EN");
            for (int i = 0; i < 8; i++) Fish.Add("MunglingMudLung_EN");
            for (int i = 0; i < 8; i++) Fish.Add("FlaMinGoa_EN");
            for (int i = 0; i < 2; i++) Fish.Add("Goa_EN");
            for (int i = 0; i < 3; i++) Fish.Add("Mungie_EN");
            for (int i = 0; i < 2; i++) Fish.Add("Wringle_EN");
            for (int i = 0; i < 1; i++) Fish.Add("ManicHips_EN");
            for (int i = 0; i < 5; i++) Fish.Add("Spoggle_Spitfire_EN");
            if (Check.EnemyExist("Monck")) for (int i = 0; i < 5; i++) Fish.Add("Monck");
            if (Check.EnemyExist("Pinano_EN")) for (int i = 0; i < 8; i++) Fish.Add("Pinano_EN");
            if (Check.EnemyExist("Minana_EN")) for (int i = 0; i < 2; i++) Fish.Add("Minana_EN");
            if (Check.EnemyExist("A'Flower'_EN")) for (int i = 0; i < 5; i++) Fish.Add("Minana_EN");
            if (Check.EnemyExist("Windle1_EN")) for (int i = 0; i < 2; i++) Fish.Add("Windle1_EN");
            if (Check.EnemyExist("Sinker_EN")) for (int i = 0; i < 1; i++) Fish.Add("Sinker_EN");
            if (Check.EnemyExist("Lurchin_EN")) for (int i = 0; i < 5; i++)  Fish.Add("Lurchin_EN");
            if (Check.EnemyExist("Enno_EN")) for (int i = 0; i < 3; i++) Fish.Add("Enno_EN");
            if (Check.EnemyExist("Clione_EN")) for (int i = 0; i < 4; i++) Fish.Add("Clione_EN");
            if (Check.EnemyExist("Spitato_EN")) for (int i = 0; i < 1; i++) Fish.Add("Spitato_EN");
            if (Check.EnemyExist("TripodFish_EN")) for (int i = 0; i < 2; i++) Fish.Add("TripodFish_EN");
            if (Check.EnemyExist("TeachaMantoFish_EN")) for (int i = 0; i < 1; i++) Fish.Add("TeachaMantoFish_EN"); 
            if (Check.EnemyExist("IchtyosatedSpoggle_EN")) for (int i = 0; i < 5; i++) Fish.Add("IchtyosatedSpoggle_EN");
            if (Check.EnemyExist("LipBug_EN")) for (int i = 0; i < 4; i++) Fish.Add("LipBug_EN");
        }
    }
    public class SpawnFishEffect : SpawnEnemyByStringNameEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            if (FishPool.Fish == null) FishPool.Setup();
            enemyName = FishPool.Fish.GetRandom();
            return base.PerformEffect(stats, caster, targets, areTargetSlots, entryVariable, out exitAmount);
        }
    }
    public class HasEnemySpaceEffectCondition : EffectConditionSO
    {
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            foreach (CombatSlot slot in CombatManager.Instance._stats.combatSlots.EnemySlots) if (!slot.HasUnit) return true;
            return false;
        }
    }
    public class AlarmCondition : HasEnemySpaceEffectCondition
    {
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            int pass = 30;
            if (CombatManager.Instance._stats.EnemiesOnField.Count <= 1) pass *= 2;
            if (UnityEngine.Random.Range(0, 100) > pass) return false;
            return base.MeetCondition(caster, effects, currentIndex);
        }
    }
    public class DamageByCasterHealthEffect : DamageEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            return base.PerformEffect(stats, caster, targets, areTargetSlots, caster.CurrentHealth * entryVariable, out exitAmount);
        }
    }
}
