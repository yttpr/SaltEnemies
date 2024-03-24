using System;
using System.Collections;
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

namespace Hawthorne.gay
{
    public static class gopel
    {
        public static void Add()
        {
            OnPissPassiveAbility permaDS = ScriptableObject.CreateInstance<OnPissPassiveAbility>();
            permaDS._passiveName = "Substitute";
            permaDS.passiveIcon = ResourceLoader.LoadSprite("SacrificeIcon", 32);
            permaDS.type = (PassiveAbilityTypes)544519;
            permaDS._enemyDescription = "Permanently applies Divine Sacrifice to this enemy.";
            permaDS._characterDescription = "placeholder description";
            permaDS.doesPassiveTriggerInformationPanel = false;
            permaDS._triggerOn = new TriggerCalls[1] { TriggerCalls.Count };


            Enemy gopel = new Enemy()
            {
                name = "Mortal Spoggle",
                health = 38,
                size = 1,
                entityID = (EntityIDs)544519,
                healthColor = Pigments.Gray,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/greyShit/GreySpog_Enemy.prefab").AddComponent<MultiSpriteEnemyLayout>()
            };
            gopel.prefab._gibs = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/greyShit/GreySpog_Gibs.prefab").GetComponent<ParticleSystem>();
            gopel.prefab.SetDefaultParams();
            (gopel.prefab as MultiSpriteEnemyLayout).OtherRenderers = new SpriteRenderer[]
            {
                gopel.prefab._locator.transform.Find("Sprite").Find("body").Find("body").GetComponent<SpriteRenderer>(),
            };
            gopel.combatSprite = ResourceLoader.LoadSprite("GSpogIconB", 32);
            gopel.overworldAliveSprite = ResourceLoader.LoadSprite("GSpogIcon", 32, new Vector2?(new Vector2(0.5f, 0.05f)));
            gopel.overworldDeadSprite = ResourceLoader.LoadSprite("GSpogDead", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            gopel.hurtSound = LoadedAssetsHandler.GetCharcater("Gospel_CH").damageSound;
            gopel.deathSound = LoadedAssetsHandler.GetCharcater("Gospel_CH").deathSound;
            gopel.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            gopel.passives = new BasePassiveAbilitySO[]
            {
                Passives.Pure, Passives.Skittish, Passives.Absorb, permaDS, Passives.Forgetful
            };



            Targetting_ByUnit_Side allAlly = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            allAlly.getAllUnitSlots = false;
            allAlly.getAllies = true;
            Targetting_ByUnit_Side allEnemy = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            allEnemy.getAllUnitSlots = false;
            allEnemy.getAllies = false;
            PreviousEffectCondition didntThat = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            didntThat.wasSuccessful = false;
            PreviousEffectCondition didThat = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            didThat.wasSuccessful = true;
            AnimationVisualsEffect homonDomin = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            homonDomin._visuals = LoadedAssetsHandler.GetEnemyAbility("Domination_A").visuals;
            homonDomin._animationTarget = Slots.Front;
            AnimationVisualsEffect talons = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            talons._visuals = LoadedAssetsHandler.GetEnemyAbility("Talons_A").visuals;
            talons._animationTarget = Slots.Front;

            CasterStoredValueChangeEffect infestationUp = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
            infestationUp._minimumValue = 0;
            infestationUp._increase = true;
            infestationUp._valueName = UnitStoredValueNames.InfestationPA;

            ConsumeRandomButColorManaEffect notGrey = ScriptableObject.CreateInstance<ConsumeRandomButColorManaEffect>();
            notGrey._exceptionManas = new ManaColorSO[1] { Pigments.Gray };

            Ability sipppo = new Ability();
            sipppo.name = "Siphon";
            sipppo.description = "This enemy consumes 3 pigment not of this enemy's health color.";
            sipppo.rarity = 5;
            sipppo.effects = new Effect[1];
            sipppo.effects[0] = new Effect(notGrey, 3, IntentType.Mana_Consume, Slots.Self);
            sipppo.visuals = LoadedAssetsHandler.GetEnemyAbility("Siphon_A").visuals;
            sipppo.animationTarget = Slots.Self;

            AddPassiveEffect leakIt = ScriptableObject.CreateInstance<AddPassiveEffect>();
            leakIt._passiveToAdd = Passives.Leaky;

            Ability gigoo = new Ability();
            gigoo.name = "Gnaw";
            gigoo.description = "Deal 4 damage to the left and right party members. Consume 2 pigment not of this enemy's health color.";
            gigoo.rarity = 5;
            gigoo.effects = new Effect[2];
            gigoo.effects[0] = new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 4, IntentType.Damage_3_6, Slots.LeftRight);
            gigoo.effects[1] = new Effect(notGrey, 2, IntentType.Mana_Consume, Slots.Self);
            gigoo.visuals = LoadedAssetsHandler.GetEnemyAbility("Gnaw_A").visuals;
            gigoo.animationTarget = Slots.LeftRight;



            Ability dust = new Ability();
            dust.name = "Not Long for This World";
            dust.description = "Apply 3 Divine Protection to the enemies with the lowest health. Apply 2 Divine Protection to the enemies with the second lowest health. Apply 1 Divine Protection to the enemies with the third lowest health.";
            dust.rarity = 8;
            dust.effects = new Effect[1];
            dust.effects[0] = new Effect(ScriptableObject.CreateInstance<DPLowestThreeEffect>(), 1, IntentType.Status_DivineProtection, allAlly);
            dust.visuals = LoadedAssetsHandler.GetEnemyAbility("MinorKey_A").visuals;
            dust.animationTarget = allAlly;


            gopel.abilities = new Ability[3] { sipppo, gigoo, dust };
            gopel.AddEnemy();
        }
    }
    public class DPLowestThreeEffect : EffectSO
    {
            public override bool PerformEffect(
            CombatStats stats,
            IUnit caster,
            TargetSlotInfo[] targets,
            bool areTargetSlots,
            int entryVariable,
            out int exitAmount)
        {
            exitAmount = 0;
            List<TargetSlotInfo> targetSlotInfoList = new List<TargetSlotInfo>();
            int num = -1;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit && target.Unit.IsAlive && target.Unit != caster)
                {
                    if (num < 0)
                    {
                        targetSlotInfoList.Add(target);
                        num = target.Unit.CurrentHealth;
                    }
                    else if (target.Unit.CurrentHealth < num)
                    {
                        targetSlotInfoList.Clear();
                        targetSlotInfoList.Add(target);
                        num = target.Unit.CurrentHealth;
                    }
                    else if (target.Unit.CurrentHealth == num)
                        targetSlotInfoList.Add(target);
                }
            }

            List<TargetSlotInfo> targetSlotInfoListAgain = new List<TargetSlotInfo>();
            int numbah = -1;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit && target.Unit.IsAlive && target.Unit != caster)
                {
                    if (numbah < 0)
                    {
                        if (target.Unit.CurrentHealth > num)
                        {
                            targetSlotInfoListAgain.Add(target);
                            numbah = target.Unit.CurrentHealth;
                        }
                    }
                    else if (target.Unit.CurrentHealth < numbah)
                    {
                        if (target.Unit.CurrentHealth > num)
                        {
                            targetSlotInfoListAgain.Clear();
                            targetSlotInfoListAgain.Add(target);
                            numbah = target.Unit.CurrentHealth;
                        }
                    }
                    else if (target.Unit.CurrentHealth == numbah)
                        if (target.Unit.CurrentHealth > num)
                        {
                            targetSlotInfoListAgain.Add(target);
                        }
                }
            }

            List<TargetSlotInfo> targetSlotInfoList3 = new List<TargetSlotInfo>();
            int numbaj = -1;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit && target.Unit.IsAlive && target.Unit != caster)
                {
                    if (numbaj < 0)
                    {
                        if (target.Unit.CurrentHealth > numbah)
                        {
                            targetSlotInfoList3.Add(target);
                            numbaj = target.Unit.CurrentHealth;
                        }
                    }
                    else if (target.Unit.CurrentHealth < numbaj)
                    {
                        if (target.Unit.CurrentHealth > numbah)
                        {
                            targetSlotInfoList3.Clear();
                            targetSlotInfoList3.Add(target);
                            numbah = target.Unit.CurrentHealth;
                        }
                    }
                    else if (target.Unit.CurrentHealth == numbaj)
                        if (target.Unit.CurrentHealth > numbah)
                        {
                            targetSlotInfoList3.Add(target);
                        }
                }
            }


            foreach (TargetSlotInfo target in targetSlotInfoList)
            {
                GenericTargetting_BySlot_Index slotTarget = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
                slotTarget.slotPointerDirections = new int[1] { target.Unit.SlotID };
                slotTarget.getAllies = !(target.Unit.IsUnitCharacter);
                Effect entering = new Effect(ScriptableObject.CreateInstance<ApplyDivineProtectionEffect>(), 3, new IntentType?(), slotTarget);
                CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { entering }), caster));
            }
            foreach (TargetSlotInfo target in targetSlotInfoListAgain)
            {
                GenericTargetting_BySlot_Index slotTarget = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
                slotTarget.slotPointerDirections = new int[1] { target.Unit.SlotID };
                slotTarget.getAllies = !(target.Unit.IsUnitCharacter);
                Effect entering = new Effect(ScriptableObject.CreateInstance<ApplyDivineProtectionEffect>(), 2, new IntentType?(), slotTarget);
                CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { entering }), caster));
            }
            foreach (TargetSlotInfo target in targetSlotInfoList3)
            {
                GenericTargetting_BySlot_Index slotTarget = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
                slotTarget.slotPointerDirections = new int[1] { target.Unit.SlotID };
                slotTarget.getAllies = !(target.Unit.IsUnitCharacter);
                Effect entering = new Effect(ScriptableObject.CreateInstance<ApplyDivineProtectionEffect>(), 1, new IntentType?(), slotTarget);
                CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { entering }), caster));
            }

            return exitAmount > 0;
        }
    }
    public class OnPissPassiveAbility : BasePassiveAbilitySO
    {
        [Header("Multiplier Data")]
        [SerializeField]
        private bool _temp = false;


        public override bool IsPassiveImmediate => true;

        public override bool DoesPassiveTrigger => true;




        public override void TriggerPassive(object sender, object args)
        {
            Debug.Log("NOTHING!!!!!!!!!!!!!!");

        }



        public override void OnPassiveConnected(IUnit unit)
        {
            Effect entering = new Effect(ScriptableObject.CreateInstance<ApplyPermaDivineSacrificeEffect>(), 1, null, Slots.Self);
            CombatManager.Instance.AddPrioritySubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { entering }), unit));
        }

        public override void OnPassiveDisconnected(IUnit unit)
        {
        }
    }
}
