using DG.Tweening;
using MonoMod.RuntimeDetour;
using System;
using System.Reflection;
using TMPro;
using UnityEngine;
using Hawthorne;

namespace PYMN4
{
    public static class Acid
    {
        //EXPLANATION
        //feel free to change the number of acid to any number you want. 
        //also feel free to change the name and the description
        //make sure to change the string name of the sprite in the resourceloader line
        //write "Acid.Add();" in your awake function
        //to make an effect that applies it, write:
        //"new Effect(ScriptableObject.CreateInstance<ApplyAcidEffect>(), 1, (IntentType)Acid.acid, Slots.Front)"
        //well, change the targetting and entryvariable, but that's basically it.
        //also change the namespace of this .cs file.
        public static int acid = 65821;//the ID number
        public static string name = "Acid";//the name
        public static string description = "Deal 3 indirect damage to this unit upon performing an ability. Decrease Acid by 1 at the end of each turn.";//the description
        public static Sprite acidSprite = ResourceLoader.LoadSprite("Acid.png", 32);//the sprite. make sure you put a proper sprite here to replace the string name
        public static IntentInfo acidIntent = new IntentInfoBasic();
        public static void AddAcidIntent(Action<IntentHandlerSO> orig, IntentHandlerSO self)
        {
            orig(self);
            acidIntent._type = (IntentType)acid;
            acidIntent._sprite = acidSprite;
            acidIntent._color = Color.white;
            acidIntent._sound = self._intentDB[IntentType.Status_Ruptured]._sound;
            IntentInfo intentInfo;
            self._intentDB.TryGetValue((IntentType)acid, out intentInfo);
            if (intentInfo == null)
                self._intentDB.Add((IntentType)acid, (IntentInfo)acidIntent);
        }
        public static StatusEffectInfoSO acidInfo = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
        public static void AddAcidStatusEffect(Action<CombatManager> orig, CombatManager self)
        {
            orig(self);
            acidInfo.name = name;
            acidInfo.icon = acidSprite;
            acidInfo._statusName = name;
            acidInfo.statusEffectType = (StatusEffectType)acid;
            acidInfo._description = description;
            acidInfo._applied_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Ruptured].AppliedSoundEvent;
            acidInfo._updated_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Ruptured].UpdatedSoundEvent;
            acidInfo._removed_SE_Event = self._stats.statusEffectDataBase[StatusEffectType.Ruptured].RemovedSoundEvent;
            StatusEffectInfoSO effectInfo;
            self._stats.statusEffectDataBase.TryGetValue((StatusEffectType)acid, out effectInfo);
            if (effectInfo == null)
                self._stats.statusEffectDataBase.Add((StatusEffectType)acid, acidInfo);
        }
        public static Sequence DamageTypeSetter(Func<DamageTextOptions, CombatText, string, int, Sequence> orig, DamageTextOptions self, CombatText textHolder, string text, int type)
        {
            if (type == acid)
            {
                Color32 acidColor = new Color32(81, 209, 81, 255);
                Color32 darkAcidColor = new Color32(46, 155, 46, 255);
                TMP_ColorGradient colorGradientPreset = ScriptableObject.CreateInstance<TMP_ColorGradient>();
                colorGradientPreset.bottomLeft = acidColor;
                colorGradientPreset.bottomRight = darkAcidColor;
                colorGradientPreset.topLeft = darkAcidColor;
                colorGradientPreset.topRight = acidColor;
                TextMeshPro text2 = textHolder.Text;
                text2.text = text;
                text2.colorGradientPreset = colorGradientPreset;
                Transform transform = textHolder.transform;
                Sequence sequence = DOTween.Sequence();
                Tween tween = TweenSettingsExtensions.SetEase<Sequence>(ShortcutExtensions.DOLocalJump(transform, transform.position, self._jumpForce * textHolder.Scale, 1, self._jumpTime, false), (Ease)1);
                TweenSettingsExtensions.Append(sequence, tween);
                return sequence;
            }
            else
            {
                return orig(self, textHolder, text, type);
            }
        }
        public static string CustomDamageSound(Func<UnitSoundHandlerSO, DamageType, string> orig, UnitSoundHandlerSO self, DamageType damageType)
        {
            //Debug.Log("in");
            if (damageType == (DamageType)acid)
            {
                //Debug.Log("finding sound");
                return self._rupturedDmgEvent;
            }
            else
            {
                return orig(self, damageType);
            }
        }
        public static void Add()
        {
            IDetour addDamageTypeHook = (IDetour)new Hook((MethodBase)typeof(DamageTextOptions).GetMethod("PrepareTextOptions", ~BindingFlags.Default), typeof(Acid).GetMethod(nameof(DamageTypeSetter), ~BindingFlags.Default));
            IDetour addDamageSoundHook = (IDetour)new Hook((MethodBase)typeof(UnitSoundHandlerSO).GetMethod("TryGetDamageEventName", ~BindingFlags.Default), typeof(Acid).GetMethod(nameof(CustomDamageSound), ~BindingFlags.Default));
            IDetour addPowerIDetour = (IDetour)new Hook((MethodBase)typeof(CombatManager).GetMethod("InitializeCombat", ~BindingFlags.Default), typeof(Acid).GetMethod(nameof(AddAcidStatusEffect), ~BindingFlags.Default));
            IDetour addPowerIntentIDetour = (IDetour)new Hook((MethodBase)typeof(IntentHandlerSO).GetMethod("Initialize", ~BindingFlags.Default), typeof(Acid).GetMethod(nameof(AddAcidIntent), ~BindingFlags.Default));
        }
    }
    public class Acid_StatusEffect : IStatusEffect, ITriggerEffect<IStatusEffector>
    {
        public const int _acidDamage = 3;

        public int StatusContent => Duration;

        public int Restrictor { get; set; }

        public bool CanBeRemoved => Restrictor <= 0;

        public bool IsPositive => false;

        public string DisplayText
        {
            get
            {
                string text = "";
                if (Duration > 0)
                {
                    text += Duration;
                }

                if (Restrictor > 0)
                {
                    text = text + "(" + Restrictor + ")";
                }

                return text;
            }
        }

        public int Duration { get; set; }

        public StatusEffectType EffectType => (StatusEffectType)Acid.acid;

        public StatusEffectInfoSO EffectInfo { get; set; }

        public bool CanReduceDuration
        {
            get
            {
                BooleanReference booleanReference = new BooleanReference(entryValue: true);
                CombatManager.Instance.ProcessImmediateAction(new CheckHasStatusFieldReductionBlockIAction(booleanReference));
                return !booleanReference.value;
            }
        }

        public void SetEffectInformation(StatusEffectInfoSO effectInfo)
        {
            EffectInfo = effectInfo;
        }

        public Acid_StatusEffect(int duration, int restrictors = 0)
        {
            Duration = duration;
            Restrictor = restrictors;
        }

        public bool AddContent(IStatusEffect content)
        {
            Duration += content.StatusContent;
            Restrictor += content.Restrictor;
            return true;
        }

        public bool TryAddContent(int amount)
        {
            if (Duration <= 0)
            {
                return false;
            }

            Duration += amount;
            return true;
        }

        public int JustRemoveAllContent()
        {
            int duration = Duration;
            Duration = 0;
            return duration;
        }

        public void OnTriggerAttached(IStatusEffector caller)
        {
            CombatManager.Instance.AddObserver(OnStatusTriggered, TriggerCalls.OnAbilityUsed.ToString(), caller);
            CombatManager.Instance.AddObserver(OnStatusTick, TriggerCalls.OnTurnFinished.ToString(), caller);
        }

        public void OnTriggerDettached(IStatusEffector caller)
        {
            CombatManager.Instance.RemoveObserver(OnStatusTriggered, TriggerCalls.OnAbilityUsed.ToString(), caller);
            CombatManager.Instance.RemoveObserver(OnStatusTick, TriggerCalls.OnTurnFinished.ToString(), caller);
        }

        public void OnSubActionTrigger(object sender, object args, bool stateCheck)
        {
            (sender as IUnit).Damage(_acidDamage, null, DeathType.None, -1, addHealthMana: false, directDamage: false, ignoresShield: true, (DamageType)Acid.acid);
        }

        public void OnStatusTriggered(object sender, object args)
        {
            CombatManager.Instance.AddSubAction(new PerformStatusEffectAction(this, sender, args, stateCheck: false));
        }

        public void OnStatusTick(object sender, object args)
        {
            ReduceDuration(sender as IStatusEffector);
        }

        public void ReduceDuration(IStatusEffector effector)
        {
            if (CanReduceDuration)
            {
                int duration = Duration;
                Duration = Mathf.Max(0, Duration - 1);
                if (!TryRemoveStatusEffect(effector) && duration != Duration)
                {
                    effector.StatusEffectValuesChanged(EffectType, Duration - duration);
                }
            }
        }

        public void DettachRestrictor(IStatusEffector effector)
        {
            Restrictor--;
            if (!TryRemoveStatusEffect(effector))
            {
                effector.StatusEffectValuesChanged(EffectType, 0);
            }
        }

        public bool TryRemoveStatusEffect(IStatusEffector effector)
        {
            if (Duration <= 0 && CanBeRemoved)
            {
                effector.RemoveStatusEffect(EffectType);
                return true;
            }

            return false;
        }
    }
    public class ApplyAcidEffect : EffectSO
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
            if (entryVariable <= 0)
                return false;

            StatusEffectInfoSO effectInfo;
            stats.statusEffectDataBase.TryGetValue((StatusEffectType)Acid.acid, out effectInfo);


            for (int index = 0; index < targets.Length; ++index)
            {
                if (targets[index].HasUnit)
                {
                    int amount = this._randomBetweenPrevious ? UnityEngine.Random.Range(this.PreviousExitValue, entryVariable + 1) : entryVariable;
                    Acid_StatusEffect statusEffect = new Acid_StatusEffect(amount);

                    statusEffect.SetEffectInformation(effectInfo);
                    if (targets[index].Unit.ApplyStatusEffect((IStatusEffect)statusEffect, amount))
                        exitAmount += amount;
                }
            }

            return exitAmount > 0;
        }
    }
}
