using System;
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
using System.Collections;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using JetBrains.Annotations;
using static UnityEngine.UI.CanvasScaler;
using static UnityEngine.EventSystems.EventTrigger;
using System.Threading;
using UnityEngine.EventSystems;
using System.Runtime.CompilerServices;

namespace Hawthorne
{
    public static class Hooks
    {
        public static void Add()
        {
            HideHealthBarsPassive.Add();
            MainMenuException.Add();
            PixelateSpritesHook.Add();
            PixelateIconsHook.Add();
            DamageTypeHook.Add();
            HideDamageValuesHook.Add();
            TimerAbominationPassiveHook.Add();
            AttackSlotsErrorHook.Add();
        }
    }
    
    public static class HideHealthBarsPassive
    {
        public static int inCombat = 0;
        public static int hideCH_RealHP = 0;
        public static int hideEN_RealHP = 0;
        public static int hideCH_MaxHP = 0;
        public static int hideEN_MaxHP = 0;
        public static int hideCH_BarFill = 0;
        public static int hideEN_BarFill = 0;
        public static void SetHPInformation(Action<CombatHealthBarLayout, ManaColorSO, int, int, HealthBarType> orig, CombatHealthBarLayout HP_Bar, ManaColorSO health, int current, int max, HealthBarType barType)
        {
            if (inCombat <= 0)
            {
                orig(HP_Bar, health, current, max, barType);
                return;
            }
            else if (inCombat > 0)
            {
                orig(HP_Bar, health, current, max, barType);

                if ((hideCH_BarFill > 0 && barType != HealthBarType.Basic) || (hideEN_BarFill > 0 && barType == HealthBarType.Basic))
                {
                    HP_Bar._unitHealth.fillAmount = (float)max / (float)max;
                }
                if ((hideCH_RealHP > 0 && barType != HealthBarType.Basic) || (hideEN_RealHP > 0 && barType == HealthBarType.Basic))
                {
                    HP_Bar._unitCurrentHealthText.text = "??";
                }
                if ((hideCH_MaxHP > 0 && barType != HealthBarType.Basic) || (hideEN_MaxHP > 0 && barType == HealthBarType.Basic))
                {
                    HP_Bar._unitMaxHealthText.text = "??";
                }
                return;
            }
            else
            {
                orig(HP_Bar, health, current, max, barType);
                return;
            }
        }
        public static void Add()
        {
            IDetour addHideHealthIDetour = (IDetour)new Hook((MethodBase)typeof(CombatHealthBarLayout).GetMethod("SetInformation", ~BindingFlags.Default), typeof(HideHealthBarsPassive).GetMethod("SetHPInformation", ~BindingFlags.Default));

        }
        public static void ExamplePassive()
        {
            PerformDoubleEffectPassiveAbility hideHP = ScriptableObject.CreateInstance<PerformDoubleEffectPassiveAbility>();
            hideHP._passiveName = "Placeholder name";
            hideHP.passiveIcon = ResourceLoader.LoadSprite("placeholder sprite", 32);
            hideHP.type = (PassiveAbilityTypes)544522;
            hideHP._enemyDescription = "placeholder description.";
            hideHP._characterDescription = "placeholder description";
            hideHP.doesPassiveTriggerInformationPanel = false;
            hideHP.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1] { new Effect(ScriptableObject.CreateInstance<UnhideCharacterHealthBarsEffect>(), 1, new IntentType?(), Slots.Self) });
            hideHP._triggerOn = new TriggerCalls[2] { TriggerCalls.OnDeath, TriggerCalls.OnCombatEnd };
            hideHP._secondDoesPerformPopUp = false;
            hideHP._secondEffects = ExtensionMethods.ToEffectInfoArray(new Effect[1] { new Effect(ScriptableObject.CreateInstance<HideCharacterHealthBarsEffect>(), 1, new IntentType?(), Slots.Self) });
            hideHP._secondTriggerOn = new TriggerCalls[2] { TriggerCalls.OnCombatStart, TriggerCalls.OnTurnStart };

        }
    }
    public class HideCharacterHealthBarsEffect : EffectSO
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

            if (caster.GetStoredValue((UnitStoredValueNames)255357) < 1)
            {
                HideHealthBarsPassive.inCombat += 1;
                HideHealthBarsPassive.hideCH_RealHP += 1;
                HideHealthBarsPassive.hideCH_BarFill += 1;
                caster.SetStoredValue((UnitStoredValueNames)255357, 1);
                exitAmount += 1;
            }

            return exitAmount > 0;
        }
    }
    public class UnhideCharacterHealthBarsEffect : EffectSO
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

            if (caster.GetStoredValue((UnitStoredValueNames)255357) > 0)
            {
                HideHealthBarsPassive.inCombat -= 1;
                HideHealthBarsPassive.hideCH_RealHP -= 1;
                HideHealthBarsPassive.hideCH_BarFill -= 1;
                caster.SetStoredValue((UnitStoredValueNames)255357, 0);
                exitAmount += 1;
            }

            return exitAmount > 0;
        }
    }

    public static class MainMenuException
    {
        public static void OnMainMenu(Action<PauseUIHandler> orig, PauseUIHandler self)
        {
            HideHealthBarsPassive.inCombat = 0;
            HideHealthBarsPassive.hideCH_RealHP = 0;
            HideHealthBarsPassive.hideEN_RealHP = 0;
            HideHealthBarsPassive.hideCH_MaxHP = 0;
            HideHealthBarsPassive.hideEN_MaxHP = 0;
            HideHealthBarsPassive.hideCH_BarFill = 0;
            HideHealthBarsPassive.hideEN_BarFill = 0;
            HideDamageValuesHook.HideDamage = 0;
            HideDamageValuesHook.HideHeal = 0;
            PixelateSpritesHook.CH_PPU = 1;
            PixelateIconsHook.A_PPU = 1;
            SaltEnemies.inCombat = false;
            SaltEnemies.inCombatClicking = 0;
            orig(self);
        }
        public static void Add()
        {
            IDetour addMainMenuExceptionIDetour = (IDetour)new Hook((MethodBase)typeof(PauseUIHandler).GetMethod("OnMainMenuPressed", ~BindingFlags.Default), typeof(MainMenuException).GetMethod("OnMainMenu", ~BindingFlags.Default));

        }
    }

    public static class PixelateSpritesHook
    {
        //public static int pixelation = 1;
        public static float CH_PPU = 1f;
        public static void TransformCharacterSprite(Action<CharacterInFieldLayout, Sprite, Sprite, RuntimeAnimatorController> orig, CharacterInFieldLayout fieldLayout, Sprite frontSprite, Sprite backSprite, RuntimeAnimatorController character)
        {
            /*if (CH_PPU > 1)
            {
                Debug.Log("we're in");
                Debug.Log(CH_PPU);
                Sprite newFront = Sprite.Create(frontSprite.texture, new Rect(frontSprite.rect.x, frontSprite.rect.y, frontSprite.rect.width, frontSprite.rect.height), new Vector2(0.5f, 0.5f), PixelateSpritesHook.CH_PPU);
                Sprite newBack = Sprite.Create(backSprite.texture, new Rect(backSprite.rect.x, backSprite.rect.y, backSprite.rect.width, backSprite.rect.height), new Vector2(0.5f, 0.5f), PixelateSpritesHook.CH_PPU);
                fieldLayout._obliterationMaterialInstance.SetFloat("_PixelateSize", CH_PPU);
                //orig(fieldLayout, newFront, newBack, character);
                orig(fieldLayout, frontSprite, backSprite, character);
                return;
            }*/
            Texture2D PixelateImage(Texture2D image)
            {
                float colorMod = Math.Min(CH_PPU, 64) / 400;
                if (colorMod < 0.2f)
                    colorMod = 0f;
                else if (colorMod < 0.3f)
                    colorMod = 0.1f;
                else if (colorMod < 0.4f)
                    colorMod = 0.2f;
                else if (colorMod < 0.5f)
                    colorMod = 0.3f;
                else if (colorMod < 0.6f)
                    colorMod = 0.5f;
                else if (colorMod > 0.9f)
                    colorMod = 1.1f;
                else if (colorMod > 0.8f)
                    colorMod = 1f;
                else if (colorMod > 0.7f)
                    colorMod = 0.8f;
                else if (colorMod > 0.6f)
                    colorMod = 0.7f;
                colorMod += 1f;
                var bitmap = new Texture2D(image.width, image.height);
                for (var yy = 0; yy < image.height; yy += (int)CH_PPU)
                {
                    for (var xx = 0; xx < image.width; xx += (int)CH_PPU)
                    {
                        int yVal = Math.Min((int)CH_PPU, image.height - yy);
                        int xVal = Math.Min((int)CH_PPU, image.height - xx);
                        UnityEngine.Color[] cellColors = image.GetPixels(xx, yy, xVal, yVal);

                        float averageRed = 0f;
                        float averageGreen = 0f;
                        float averageBlue = 0f;
                        float averageA = 0f;
                        int reduction = 0;
                        int outlineCount = 0;
                        List<int> outlineList = new List<int>();
                        for (int i = 0; i < cellColors.Length; i++)
                        {
                            UnityEngine.Color color = cellColors[i];
                            bool darkColor = false;
                            if (color.r < 0.2f && color.g < 0.2f && color.b < 0.2f)
                            {
                                darkColor = true;
                            }
                            if (color.a > 0.3f && (darkColor == false || CH_PPU < 16))
                            {
                                averageRed += color.r;
                                averageGreen += color.g;
                                averageBlue += color.b;
                                averageA += 1f;
                            }
                            else if (darkColor)
                            {
                                outlineList.Add(i);
                                outlineCount++;
                            }
                            else { reduction++; }
                        }
                        bool allFalse = true;
                        if (reduction + outlineCount == cellColors.Length && allFalse)
                        {
                            int[] Outlines = outlineList.ToArray();
                            for (int k = 0; k < Outlines.Length; k++)
                            {
                                UnityEngine.Color color = cellColors[Outlines[k]];
                                if (color.a != 0)
                                {
                                    averageRed += color.r;
                                    averageGreen += color.g;
                                    averageBlue += color.b;
                                    averageA += color.a;
                                }
                            }
                        }
                        else
                        {
                            reduction += outlineCount;
                        }
                        int cutOut = cellColors.Length - reduction;
                        averageRed *= colorMod;
                        averageGreen *= colorMod;
                        averageBlue *= colorMod;
                        averageRed /= cutOut;
                        averageGreen /= cutOut;
                        averageBlue /= cutOut;
                        averageA /= cutOut;
                        UnityEngine.Color averageColor = new UnityEngine.Color(averageRed, averageGreen, averageBlue, averageA);

                        for (int i = 0; i < cellColors.Length; i++)
                        {
                            cellColors[i] = averageColor;
                        }
                        bitmap.SetPixels(xx, yy, xVal, yVal, cellColors);
                        bitmap.Apply();
                    }
                }
                return bitmap;
            }
            Texture2D GetTexture(CharacterInFieldLayout fieldLayout, Sprite sprite)
            {
                CharacterCombat FOOL = CombatManager.Instance._stats.TryGetCharacterOnField(fieldLayout.CharacterID);
                if (!(sprite.texture.isReadable))
                {
                    foreach (CharacterSO chara in SaltEnemies.BaseChara)
                    {
                        if (FOOL.Character == chara)
                        {
                            return SlicedBaseTexture(sprite);
                        }
                    }
                }
                return sprite.texture;
            }
            Texture2D SlicedBaseTexture(Sprite sprite)
            {
                Texture2D baseTex = ResourceLoader.LoadTexture("BrutalOrchestraCharacters-sheet");
                Rect rect = sprite.rect;
                Texture2D slicedTex = new Texture2D((int)rect.width, (int)rect.height);
                slicedTex.filterMode = baseTex.filterMode;

                slicedTex.SetPixels(0, 0, (int)rect.width, (int)rect.height, baseTex.GetPixels((int)rect.x, (int)rect.y, (int)rect.width, (int)rect.height));
                slicedTex.Apply();

                return slicedTex;
            }
            if (CH_PPU > 1)
            {
                Texture2D frontTex = PixelateImage(GetTexture(fieldLayout, frontSprite));
                Texture2D backTex = PixelateImage(GetTexture(fieldLayout, backSprite));
                Sprite newFront = Sprite.Create(frontTex, new Rect(0, 0, frontSprite.rect.width, frontSprite.rect.height), new Vector2(0.5f, 0.5f), 1);
                Sprite newBack = Sprite.Create(backTex, new Rect(0, 0, backSprite.rect.width, backSprite.rect.height), new Vector2(0.5f, 0.5f), 1);
                orig(fieldLayout, newFront, newBack, character);
                fieldLayout.SetCharacterSprite();
                return;
            }
            else
            {
                orig(fieldLayout, frontSprite, backSprite, character);
                return;
            }

        }

        public static void SetCharacterSprites(Action<CharacterInFieldLayout, Sprite, Sprite> orig, CharacterInFieldLayout fieldLayout, Sprite frontSprite, Sprite backSprite)
        {
            Texture2D PixelateImage(Texture2D image)
            {
                float colorMod = Math.Max(CH_PPU, 64) / 400;
                if (colorMod < 0.2f)
                    colorMod = 0f;
                else if (colorMod < 0.3f)
                    colorMod = 0.1f;
                else if (colorMod < 0.4f)
                    colorMod = 0.2f;
                else if (colorMod < 0.5f)
                    colorMod = 0.3f;
                else if (colorMod < 0.6f)
                    colorMod = 0.5f;
                else if (colorMod > 0.9f)
                    colorMod = 1.1f;
                else if (colorMod > 0.8f)
                    colorMod = 1f;
                else if (colorMod > 0.7f)
                    colorMod = 0.8f;
                else if (colorMod > 0.6f)
                    colorMod = 0.7f;
                colorMod += 1f;
                var bitmap = new Texture2D(image.width, image.height);
                for (var yy = 0; yy < image.height; yy += (int)CH_PPU)
                {
                    for (var xx = 0; xx < image.width; xx += (int)CH_PPU)
                    {
                        int yVal = Math.Min((int)CH_PPU, image.height - yy);
                        int xVal = Math.Min((int)CH_PPU, image.height - xx);
                        UnityEngine.Color[] cellColors = image.GetPixels(xx, yy, xVal, yVal);

                        float averageRed = 0f;
                        float averageGreen = 0f;
                        float averageBlue = 0f;
                        float averageA = 0f;
                        int reduction = 0;
                        int outlineCount = 0;
                        List<int> outlineList = new List<int>();
                        for (int i = 0; i < cellColors.Length; i++)
                        {
                            UnityEngine.Color color = cellColors[i];
                            if (color.a > 0.3f && !(color.r < 0.2f && color.g < 0.2f && color.b < 0.2f))
                            {
                                averageRed += color.r;
                                averageGreen += color.g;
                                averageBlue += color.b;
                                averageA += 1f;
                            }
                            else if (color.r < 0.2f && color.g < 0.2f && color.b < 0.2f)
                            {
                                outlineList.Add(i);
                                outlineCount++;
                            }
                            else { reduction++; }
                        }
                        bool allFalse = true;
                        if (reduction + outlineCount == cellColors.Length && allFalse)
                        {
                            int[] Outlines = outlineList.ToArray();
                            for (int k = 0; k < Outlines.Length; k++)
                            {
                                UnityEngine.Color color = cellColors[Outlines[k]];
                                if (color.a != 0)
                                {
                                    averageRed += color.r;
                                    averageGreen += color.g;
                                    averageBlue += color.b;
                                    averageA += color.a;
                                }
                            }
                        }
                        else
                        {
                            reduction += outlineCount;
                        }
                        int cutOut = cellColors.Length - reduction;
                        averageRed *= colorMod;
                        averageGreen *= colorMod;
                        averageBlue *= colorMod;
                        averageRed /= cutOut;
                        averageGreen /= cutOut;
                        averageBlue /= cutOut;
                        averageA /= cutOut;
                        UnityEngine.Color averageColor = new UnityEngine.Color(averageRed, averageGreen, averageBlue, averageA);

                        for (int i = 0; i < cellColors.Length; i++)
                        {
                            cellColors[i] = averageColor;
                        }
                        bitmap.SetPixels(xx, yy, xVal, yVal, cellColors);
                        bitmap.Apply();
                    }
                }
                return bitmap;
            }
            Texture2D GetTexture(CharacterInFieldLayout fieldLayout, Sprite sprite)
            {
                CharacterCombat FOOL = CombatManager.Instance._stats.TryGetCharacterOnField(fieldLayout.CharacterID);
                if (!(sprite.texture.isReadable))
                {
                    foreach (CharacterSO chara in SaltEnemies.BaseChara)
                    {
                        if (FOOL.Character == chara)
                        {
                            return SlicedBaseTexture(sprite);
                        }
                    }
                }
                return sprite.texture;
            }
            Texture2D SlicedBaseTexture(Sprite sprite)
            {
                Texture2D baseTex = ResourceLoader.LoadTexture("BrutalOrchestraCharacters-sheet");
                Rect rect = sprite.rect;
                Texture2D slicedTex = new Texture2D((int)rect.width, (int)rect.height);
                slicedTex.filterMode = baseTex.filterMode;

                slicedTex.SetPixels(0, 0, (int)rect.width, (int)rect.height, baseTex.GetPixels((int)rect.x, (int)rect.y, (int)rect.width, (int)rect.height));
                slicedTex.Apply();

                return slicedTex;
            }
            if (CH_PPU > 1)
            {
                Texture2D frontTex = PixelateImage(GetTexture(fieldLayout, frontSprite));
                Texture2D backTex = PixelateImage(GetTexture(fieldLayout, backSprite));
                Sprite newFront = Sprite.Create(frontTex, new Rect(0, 0, frontSprite.rect.width, frontSprite.rect.height), new Vector2(0.5f, 0.5f), 1);
                Sprite newBack = Sprite.Create(backTex, new Rect(0, 0, backSprite.rect.width, backSprite.rect.height), new Vector2(0.5f, 0.5f), 1);
                orig(fieldLayout, newFront, newBack);
                fieldLayout.SetCharacterSprite();
                return;
            }
            else
            {
                orig(fieldLayout, frontSprite, backSprite);
                return;
            }
        }
        public static void Add()
        {
            IDetour addPixelateSpritesTransformIDetour = (IDetour)new Hook((MethodBase)typeof(CharacterInFieldLayout).GetMethod("TransformCharacter", ~BindingFlags.Default), typeof(PixelateSpritesHook).GetMethod("TransformCharacterSprite", ~BindingFlags.Default));
            if (DoDebugs.GenInfo) Debug.Log("First hook");
            IDetour addPixelateSpritesINewSpritesDetour = (IDetour)new Hook((MethodBase)typeof(CharacterInFieldLayout).GetMethod("SetCharacterSprites", ~BindingFlags.Default), typeof(PixelateSpritesHook).GetMethod("SetCharacterSprites", ~BindingFlags.Default));
            if (DoDebugs.GenInfo) Debug.Log("Second hook");
        }
    }
    public class PixelateSpritesEffect : EffectSO
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


            PixelateSpritesHook.CH_PPU += 1;
            Targetting_ByUnit_Side allAlly = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            allAlly.getAllies = caster.IsUnitCharacter;
            allAlly.getAllUnitSlots = false;
            Effect pixelate = new Effect(ScriptableObject.CreateInstance<PixelateTargetSpriteEffect>(), 1, new IntentType?(), allAlly);
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { pixelate }), caster));
            exitAmount = (int)PixelateSpritesHook.CH_PPU;

            return exitAmount > 0;
        }
    }
    public class PixelateTargetSpriteEffect : EffectSO
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

            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    if (target.Unit is CharacterCombat characater)
                    {
                        if (true)
                        {
                            Sprite frontSprite = CombatManager.Instance._stats.combatUI._characterZone._characters[characater.FieldID].FieldEntity.CharacterSprite;
                            Sprite backSprite = CombatManager.Instance._stats.combatUI._characterZone._characters[characater.FieldID].FieldEntity.CharacterBackSprite;
                            CombatManager.Instance._stats.combatUI._characterZone._characters[characater.FieldID].FieldEntity.SetCharacterSprites(frontSprite, backSprite);


                            /*
                            bool pixelatedYet = false;
                            foreach (CharacterSO vanillaChar in BrutalAPI.BrutalAPI.vanillaChars)
                            {
                                if (vanillaChar == characater.Character)
                                {
                                    CharacterInFieldLayout thisLayout = CombatManager.Instance._stats.combatUI._characterZone._characters[characater.FieldID].FieldEntity;
                                    thisLayout._obliterationMaterialInstance.SetFloat("_PixelateSize", 128f);
                                    thisLayout._renderer.material = thisLayout._obliterationMaterialInstance;
                                    pixelatedYet = true;
                                    //return true;
                                }
                            }
                            if (pixelatedYet == false) 
                            { 
                                CharacterInFieldLayout thisLayoutModded = CombatManager.Instance._stats.combatUI._characterZone._characters[characater.FieldID].FieldEntity;
                                thisLayoutModded._obliterationMaterialInstance.SetFloat("_PixelateSize", 12f);
                                thisLayoutModded._renderer.material = thisLayoutModded._obliterationMaterialInstance; 
                            }
                            */
                        }
                    }
                }
            }


            exitAmount = (int)PixelateSpritesHook.CH_PPU;

            return exitAmount > 0;
        }
    }

    public static class DamageTypeHook
    {
        public static Sequence DamageTypeSetter(Func<DamageTextOptions, CombatText, string, int, Sequence> orig, DamageTextOptions self, CombatText textHolder, string text, int type)
        {
            //Debug.Log("iin");
            if (type == 888666)
            {
                //Debug.Log("finding color");
                TMP_ColorGradient colorGradientPreset = null;
                UnityEngine.Color32 paleColor = new UnityEngine.Color32(63, 205, 189, 255);
                colorGradientPreset = ScriptableObject.CreateInstance<TMP_ColorGradient>();
                colorGradientPreset.bottomLeft = paleColor;
                colorGradientPreset.bottomRight = paleColor;
                colorGradientPreset.topLeft = paleColor;
                colorGradientPreset.topRight = paleColor;
                TextMeshPro text2 = textHolder.Text;
                text2.text = text;
                text2.colorGradientPreset = colorGradientPreset;
                Transform transform = textHolder.transform;
                Sequence sequence = DOTween.Sequence();
                Tween tween = TweenSettingsExtensions.SetEase<Sequence>(ShortcutExtensions.DOLocalJump(transform, transform.position, self._jumpForce * textHolder.Scale, 1, self._jumpTime, false), (Ease)1);
                TweenSettingsExtensions.Append(sequence, tween);
                return sequence;
            }
            else if (type == 888667)
            {
                //Debug.Log("finding color");
                TMP_ColorGradient colorGradientPreset = null;
                UnityEngine.Color32 doomColor = new UnityEngine.Color32(0, 0, 0, 255);
                colorGradientPreset = ScriptableObject.CreateInstance<TMP_ColorGradient>();
                colorGradientPreset.bottomLeft = doomColor;
                colorGradientPreset.bottomRight = doomColor;
                colorGradientPreset.topLeft = doomColor;
                colorGradientPreset.topRight = doomColor;
                TextMeshPro text2 = textHolder.Text;
                text2.text = text;
                text2.colorGradientPreset = colorGradientPreset;
                Transform transform = textHolder.transform;
                Sequence sequence = DOTween.Sequence();
                Tween tween = TweenSettingsExtensions.SetEase<Sequence>(ShortcutExtensions.DOLocalJump(transform, transform.position, self._jumpForce * textHolder.Scale, 1, self._jumpTime, false), (Ease)1);
                TweenSettingsExtensions.Append(sequence, tween);
                return sequence;
            }
            else if (type == RootsInfo.Roots)
            {
                //Debug.Log("finding color");
                TMP_ColorGradient colorGradientPreset = null;
                UnityEngine.Color32 doomColor = new UnityEngine.Color32(70, 172, 0, 255);
                colorGradientPreset = ScriptableObject.CreateInstance<TMP_ColorGradient>();
                colorGradientPreset.bottomLeft = doomColor;
                colorGradientPreset.bottomRight = doomColor;
                colorGradientPreset.topLeft = doomColor;
                colorGradientPreset.topRight = doomColor;
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
            if (damageType == (DamageType)888666)
            {
                //Debug.Log("finding sound");
                return self._linkedEvent;
            }
            else if (damageType == (DamageType)888667)
            {
                //Debug.Log("finding sound");
                return self._deadlyDmgEvent;
            }
            else if (damageType == (DamageType)RootsInfo.Roots)
            {
                //Debug.Log("finding sound");
                return self._rupturedDmgEvent;
            }
            else if (damageType == CountFibonacci.type)
            {
                return CountFibonacci.click;
            }
            else
            {
                return orig(self, damageType);
            }
        }

        public static Sequence HealTypeSetter(Func<HealTextOptions, CombatText, string, int, Sequence> orig, HealTextOptions self, CombatText textHolder, string text, int type)
        {
            //Debug.Log("iin");
            if (type == 544512)
            {
                //Debug.Log("finding color");
                TMP_ColorGradient colorGradientPreset = null;
                UnityEngine.Color32 purbColor = new UnityEngine.Color32(136, 0, 255, 255);
                colorGradientPreset = ScriptableObject.CreateInstance<TMP_ColorGradient>();
                colorGradientPreset.bottomLeft = purbColor;
                colorGradientPreset.bottomRight = purbColor;
                colorGradientPreset.topLeft = purbColor;
                colorGradientPreset.topRight = purbColor;
                TextMeshPro text2 = textHolder.Text;
                text2.text = text;
                text2.colorGradientPreset = colorGradientPreset;
                Transform transform = textHolder.transform;
                Sequence sequence = DOTween.Sequence();
                Tween t = transform.DOLocalMove(transform.localPosition + transform.up * self._healYEnd * textHolder.Scale, self._moveTime).SetEase(Ease.Linear);
                sequence.Append(t);
                return sequence;
            }
            else
            {
                return orig(self, textHolder, text, type);
            }
        }
        public static string CustomHealSound(Func<UnitSoundHandlerSO, HealType, string> orig, UnitSoundHandlerSO self, HealType healType)
        {
            //Debug.Log("in");
            if (healType == (HealType)544512)
            {
                //Debug.Log("finding sound");
                return self._linkedEvent;
            }
            else
            {
                return orig(self, healType);
            }
        }



        public static void Add()
        {
            IDetour addDamageTypeHook = (IDetour)new Hook((MethodBase)typeof(DamageTextOptions).GetMethod("PrepareTextOptions", ~BindingFlags.Default), typeof(DamageTypeHook).GetMethod("DamageTypeSetter", ~BindingFlags.Default));
            IDetour addDamageSoundHook = (IDetour)new Hook((MethodBase)typeof(UnitSoundHandlerSO).GetMethod("TryGetDamageEventName", ~BindingFlags.Default), typeof(DamageTypeHook).GetMethod("CustomDamageSound", ~BindingFlags.Default));
            IDetour addHealTypeHook = (IDetour)new Hook((MethodBase)typeof(HealTextOptions).GetMethod("PrepareTextOptions", ~BindingFlags.Default), typeof(DamageTypeHook).GetMethod("HealTypeSetter", ~BindingFlags.Default));
            IDetour addHealSoundHook = (IDetour)new Hook((MethodBase)typeof(UnitSoundHandlerSO).GetMethod("TryGetHealEventName", ~BindingFlags.Default), typeof(DamageTypeHook).GetMethod("CustomHealSound", ~BindingFlags.Default));

        }
    }
    public static class PixelateIconsHook
    {
        //public static int pixelation = 1;
        public static float A_PPU = 1f;
        public static void SetAbilitySpriteCharacter(Action<AttackListLayout, List<AbilitySO>> orig, AttackListLayout self, List<AbilitySO> attacks)
        {
            Texture2D PixelateImage(Texture2D image, float CH_PPU)
            {
                float colorMod = Math.Min(CH_PPU, 64) / 400;
                if (colorMod < 0.2f)
                    colorMod = 0f;
                else if (colorMod < 0.3f)
                    colorMod = 0.1f;
                else if (colorMod < 0.4f)
                    colorMod = 0.2f;
                else if (colorMod < 0.5f)
                    colorMod = 0.3f;
                else if (colorMod < 0.6f)
                    colorMod = 0.5f;
                else if (colorMod > 0.9f)
                    colorMod = 1.1f;
                else if (colorMod > 0.8f)
                    colorMod = 1f;
                else if (colorMod > 0.7f)
                    colorMod = 0.8f;
                else if (colorMod > 0.6f)
                    colorMod = 0.7f;
                colorMod += 1f;
                var bitmap = new Texture2D(image.width, image.height);
                for (var yy = 0; yy < image.height; yy += (int)CH_PPU)
                {
                    for (var xx = 0; xx < image.width; xx += (int)CH_PPU)
                    {
                        int yVal = Math.Min((int)CH_PPU, image.height - yy);
                        int xVal = Math.Min((int)CH_PPU, image.width - xx);
                        UnityEngine.Color[] cellColors = image.GetPixels(xx, yy, xVal, yVal);

                        float averageRed = 0f;
                        float averageGreen = 0f;
                        float averageBlue = 0f;
                        float averageA = 0f;
                        int reduction = 0;
                        int outlineCount = 0;
                        List<int> outlineList = new List<int>();
                        for (int i = 0; i < cellColors.Length; i++)
                        {
                            UnityEngine.Color color = cellColors[i];
                            bool darkColor = false;
                            if (color.r < 0.2f && color.g < 0.2f && color.b < 0.2f)
                            {
                                darkColor = true;
                            }
                            if (color.a > 0.3f && (darkColor == false || CH_PPU < 16))
                            {
                                averageRed += color.r;
                                averageGreen += color.g;
                                averageBlue += color.b;
                                averageA += 1f;
                            }
                            else if (darkColor)
                            {
                                outlineList.Add(i);
                                outlineCount++;
                            }
                            else { reduction++; }
                        }
                        bool allFalse = true;
                        if (reduction + outlineCount == cellColors.Length && allFalse)
                        {
                            int[] Outlines = outlineList.ToArray();
                            for (int k = 0; k < Outlines.Length; k++)
                            {
                                UnityEngine.Color color = cellColors[Outlines[k]];
                                if (color.a != 0)
                                {
                                    averageRed += color.r;
                                    averageGreen += color.g;
                                    averageBlue += color.b;
                                    averageA += color.a;
                                }
                            }
                        }
                        else
                        {
                            reduction += outlineCount;
                        }
                        int cutOut = cellColors.Length - reduction;
                        averageRed *= colorMod;
                        averageGreen *= colorMod;
                        averageBlue *= colorMod;
                        averageRed /= cutOut;
                        averageGreen /= cutOut;
                        averageBlue /= cutOut;
                        averageA /= cutOut;
                        UnityEngine.Color averageColor = new UnityEngine.Color(averageRed, averageGreen, averageBlue, averageA);

                        for (int i = 0; i < cellColors.Length; i++)
                        {
                            cellColors[i] = averageColor;
                        }
                        bitmap.SetPixels(xx, yy, xVal, yVal, cellColors);
                        bitmap.Apply();
                    }
                }
                return bitmap;
            }
            Texture2D GetTexture(Sprite sprite)
            {
                //CharacterCombat FOOL = CombatManager.Instance._stats.TryGetCharacterOnField(fieldLayout.CharacterID);
                if (!(sprite.texture.isReadable))
                {
                    //foreach (CharacterSO chara in PrayerFool.BaseChara)
                    //{
                    //if (FOOL.Character == chara)
                    //{
                    return SlicedBaseTexture(sprite);
                    //}
                    //}
                }
                return sprite.texture;
            }
            Texture2D SlicedBaseTexture(Sprite sprite)
            {
                Texture2D baseTex = ResourceLoader.LoadTexture("AttackIcons");
                Rect rect = sprite.rect;
                Texture2D slicedTex = new Texture2D((int)rect.width, (int)rect.height);
                slicedTex.filterMode = baseTex.filterMode;

                slicedTex.SetPixels(0, 0, (int)rect.width, (int)rect.height, baseTex.GetPixels((int)rect.x, (int)rect.y, (int)rect.width, (int)rect.height));
                slicedTex.Apply();

                return slicedTex;
            }
            if (A_PPU > 1)
            {
                List<AbilitySO> newAttacks = new List<AbilitySO>();
                foreach (AbilitySO ability in attacks)
                {
                    AbilitySO newAbility = ability;
                    Sprite oldSprite = ability.abilitySprite;
                    Texture2D newTex = PixelateImage(GetTexture(oldSprite), A_PPU);
                    Sprite newSprite = Sprite.Create(newTex, new Rect(0, 0, oldSprite.rect.width, oldSprite.rect.height), new Vector2(0.5f, 0.5f), oldSprite.pixelsPerUnit);
                    newAbility.abilitySprite = newSprite;
                    newAttacks.Add(newAbility);

                }
                orig(self, newAttacks);
                return;
            }
            else
            {
                orig(self, attacks);
                return;
            }
        }
        public static void SetAbilitySpriteEnemy(Action<AttackListLayout, List<AbilitySO>, List<List<int>>> orig, AttackListLayout self, List<AbilitySO> attacks, List<List<int>> timelineSlots)
        {
            Texture2D PixelateImage(Texture2D image, float CH_PPU)
            {
                float colorMod = Math.Min(CH_PPU, 64) / 400;
                if (colorMod < 0.2f)
                    colorMod = 0f;
                else if (colorMod < 0.3f)
                    colorMod = 0.1f;
                else if (colorMod < 0.4f)
                    colorMod = 0.2f;
                else if (colorMod < 0.5f)
                    colorMod = 0.3f;
                else if (colorMod < 0.6f)
                    colorMod = 0.5f;
                else if (colorMod > 0.9f)
                    colorMod = 1.1f;
                else if (colorMod > 0.8f)
                    colorMod = 1f;
                else if (colorMod > 0.7f)
                    colorMod = 0.8f;
                else if (colorMod > 0.6f)
                    colorMod = 0.7f;
                colorMod += 1f;
                var bitmap = new Texture2D(image.width, image.height);
                for (var yy = 0; yy < image.height; yy += (int)CH_PPU)
                {
                    for (var xx = 0; xx < image.width; xx += (int)CH_PPU)
                    {
                        int yVal = Math.Min((int)CH_PPU, image.height - yy);
                        int xVal = Math.Min((int)CH_PPU, image.height - xx);
                        UnityEngine.Color[] cellColors = image.GetPixels(xx, yy, xVal, yVal);

                        float averageRed = 0f;
                        float averageGreen = 0f;
                        float averageBlue = 0f;
                        float averageA = 0f;
                        int reduction = 0;
                        int outlineCount = 0;
                        List<int> outlineList = new List<int>();
                        for (int i = 0; i < cellColors.Length; i++)
                        {
                            UnityEngine.Color color = cellColors[i];
                            bool darkColor = false;
                            if (color.r < 0.2f && color.g < 0.2f && color.b < 0.2f)
                            {
                                darkColor = true;
                            }
                            if (color.a > 0.3f && (darkColor == false || CH_PPU < 16))
                            {
                                averageRed += color.r;
                                averageGreen += color.g;
                                averageBlue += color.b;
                                averageA += 1f;
                            }
                            else if (darkColor)
                            {
                                outlineList.Add(i);
                                outlineCount++;
                            }
                            else { reduction++; }
                        }
                        bool allFalse = true;
                        if (reduction + outlineCount == cellColors.Length && allFalse)
                        {
                            int[] Outlines = outlineList.ToArray();
                            for (int k = 0; k < Outlines.Length; k++)
                            {
                                UnityEngine.Color color = cellColors[Outlines[k]];
                                if (color.a != 0)
                                {
                                    averageRed += color.r;
                                    averageGreen += color.g;
                                    averageBlue += color.b;
                                    averageA += color.a;
                                }
                            }
                        }
                        else
                        {
                            reduction += outlineCount;
                        }
                        int cutOut = cellColors.Length - reduction;
                        averageRed *= colorMod;
                        averageGreen *= colorMod;
                        averageBlue *= colorMod;
                        averageRed /= cutOut;
                        averageGreen /= cutOut;
                        averageBlue /= cutOut;
                        averageA /= cutOut;
                        UnityEngine.Color averageColor = new UnityEngine.Color(averageRed, averageGreen, averageBlue, averageA);

                        for (int i = 0; i < cellColors.Length; i++)
                        {
                            cellColors[i] = averageColor;
                        }
                        bitmap.SetPixels(xx, yy, xVal, yVal, cellColors);
                        bitmap.Apply();
                    }
                }
                return bitmap;
            }
            Texture2D GetTexture(Sprite sprite)
            {
                //CharacterCombat FOOL = CombatManager.Instance._stats.TryGetCharacterOnField(fieldLayout.CharacterID);
                if (!(sprite.texture.isReadable))
                {
                    //foreach (CharacterSO chara in PrayerFool.BaseChara)
                    //{
                    //if (FOOL.Character == chara)
                    //{
                    return SlicedBaseTexture(sprite);
                    //}
                    //}
                }
                return sprite.texture;
            }
            Texture2D SlicedBaseTexture(Sprite sprite)
            {
                Texture2D baseTex = ResourceLoader.LoadTexture("AttackIcons");
                Rect rect = sprite.rect;
                Texture2D slicedTex = new Texture2D((int)rect.width, (int)rect.height);
                slicedTex.filterMode = baseTex.filterMode;

                slicedTex.SetPixels(0, 0, (int)rect.width, (int)rect.height, baseTex.GetPixels((int)rect.x, (int)rect.y, (int)rect.width, (int)rect.height));
                slicedTex.Apply();

                return slicedTex;
            }
            if (A_PPU > 1)
            {
                List<AbilitySO> newAttacks = new List<AbilitySO>();
                foreach (AbilitySO ability in attacks)
                {
                    AbilitySO newAbility = ability;
                    Sprite oldSprite = ability.abilitySprite;
                    Texture2D newTex = PixelateImage(GetTexture(oldSprite), A_PPU);
                    Sprite newSprite = Sprite.Create(newTex, new Rect(0, 0, oldSprite.rect.width, oldSprite.rect.height), new Vector2(0.5f, 0.5f), oldSprite.pixelsPerUnit);
                    newAbility.abilitySprite = newSprite;
                    newAttacks.Add(newAbility);

                }
                orig(self, newAttacks, timelineSlots);
                return;
            }
            else
            {
                orig(self, attacks, timelineSlots);
                return;
            }
        }

        public static void Add()
        {


            MethodInfo[] methodsList = typeof(AttackListLayout).GetMethods();
            MethodInfo firstMethod;
            MethodInfo secondMethod;
            foreach (MethodInfo method in methodsList)
            {
                if (method.Name == "SetInformation")
                {
                    if (method.GetParameters().Length == 1)
                    {
                        firstMethod = method;
                        if (DoDebugs.MiscInfo) Debug.Log("first method");
                        IDetour addPixelateIconsFoolIDetour = (IDetour)new Hook((MethodBase)firstMethod, typeof(PixelateIconsHook).GetMethod("SetAbilitySpriteCharacter", ~BindingFlags.Default));
                        if (DoDebugs.MiscInfo) Debug.Log("first hook");
                    }
                    if (method.GetParameters().Length == 2)
                    {
                        secondMethod = method;
                        if (DoDebugs.MiscInfo) Debug.Log("second method");
                        IDetour addPixelateIconsEnemyIDetour = (IDetour)new Hook((MethodBase)secondMethod, typeof(PixelateIconsHook).GetMethod("SetAbilitySpriteEnemy", ~BindingFlags.Default));
                        if (DoDebugs.MiscInfo) Debug.Log("second hook");
                    }
                }
            }
            if (DoDebugs.GenInfo) Debug.Log("hooks set");

        }
    }
    public class ChangeAbilityIconsEffect : EffectSO
    {
        [SerializeField]
        public bool _justOneTarget;
        [SerializeField]
        public bool _randomBetweenPrevious;
        Texture2D PixelateImage(Texture2D image, float CH_PPU)
        {
            float colorMod = Math.Min(CH_PPU, 64) / 400;
            if (colorMod < 0.2f)
                colorMod = 0f;
            else if (colorMod < 0.3f)
                colorMod = 0.1f;
            else if (colorMod < 0.4f)
                colorMod = 0.2f;
            else if (colorMod < 0.5f)
                colorMod = 0.3f;
            else if (colorMod < 0.6f)
                colorMod = 0.5f;
            else if (colorMod > 0.9f)
                colorMod = 1.1f;
            else if (colorMod > 0.8f)
                colorMod = 1f;
            else if (colorMod > 0.7f)
                colorMod = 0.8f;
            else if (colorMod > 0.6f)
                colorMod = 0.7f;
            colorMod += 1f;
            var bitmap = new Texture2D(image.width, image.height);
            for (var yy = 0; yy < image.height; yy += (int)CH_PPU)
            {
                for (var xx = 0; xx < image.width; xx += (int)CH_PPU)
                {
                    int yVal = Math.Min((int)CH_PPU, image.height - yy);
                    int xVal = Math.Min((int)CH_PPU, image.height - xx);
                    UnityEngine.Color[] cellColors = image.GetPixels(xx, yy, xVal, yVal);

                    float averageRed = 0f;
                    float averageGreen = 0f;
                    float averageBlue = 0f;
                    float averageA = 0f;
                    int reduction = 0;
                    int outlineCount = 0;
                    List<int> outlineList = new List<int>();
                    for (int i = 0; i < cellColors.Length; i++)
                    {
                        UnityEngine.Color color = cellColors[i];
                        bool darkColor = false;
                        if (color.r < 0.2f && color.g < 0.2f && color.b < 0.2f)
                        {
                            darkColor = true;
                        }
                        if (color.a > 0.3f && (darkColor == false || CH_PPU < 16))
                        {
                            averageRed += color.r;
                            averageGreen += color.g;
                            averageBlue += color.b;
                            averageA += 1f;
                        }
                        else if (darkColor)
                        {
                            outlineList.Add(i);
                            outlineCount++;
                        }
                        else { reduction++; }
                    }
                    bool allFalse = true;
                    if (reduction + outlineCount == cellColors.Length && allFalse)
                    {
                        int[] Outlines = outlineList.ToArray();
                        for (int k = 0; k < Outlines.Length; k++)
                        {
                            UnityEngine.Color color = cellColors[Outlines[k]];
                            if (color.a != 0)
                            {
                                averageRed += color.r;
                                averageGreen += color.g;
                                averageBlue += color.b;
                                averageA += color.a;
                            }
                        }
                    }
                    else
                    {
                        reduction += outlineCount;
                    }
                    int cutOut = cellColors.Length - reduction;
                    averageRed *= colorMod;
                    averageGreen *= colorMod;
                    averageBlue *= colorMod;
                    averageRed /= cutOut;
                    averageGreen /= cutOut;
                    averageBlue /= cutOut;
                    averageA /= cutOut;
                    UnityEngine.Color averageColor = new UnityEngine.Color(averageRed, averageGreen, averageBlue, averageA);

                    for (int i = 0; i < cellColors.Length; i++)
                    {
                        cellColors[i] = averageColor;
                    }
                    bitmap.SetPixels(xx, yy, xVal, yVal, cellColors);
                    bitmap.Apply();
                }
            }
            return bitmap;
        }
        Texture2D GetTexture(Sprite sprite)
        {
            Texture2D ret = sprite.texture;
            //CharacterCombat FOOL = CombatManager.Instance._stats.TryGetCharacterOnField(fieldLayout.CharacterID);
            if (!(sprite.texture.isReadable))
            {
                //foreach (CharacterSO chara in PrayerFool.BaseChara)
                //{
                //if (FOOL.Character == chara)
                //{
                ret = SlicedBaseTexture(sprite);
                //}
                //}
            }
            try
            {
                ret.GetPixels(0, 0, 1, 1);
            }
            catch
            {
                Debug.LogError("failed getpixels!");
                RenderTexture temp = RenderTexture.GetTemporary(sprite.texture.width, sprite.texture.height, 0, RenderTextureFormat.Default, RenderTextureReadWrite.Linear);
                Graphics.Blit(sprite.texture, temp);
                RenderTexture previous = RenderTexture.active;
                Texture2D newer = new Texture2D(sprite.texture.width, sprite.texture.height);
                newer.ReadPixels(new Rect(0, 0, temp.width, temp.height), 0, 0);
                newer.Apply();
                RenderTexture.active = previous;
                ret = newer;
            }
            return ret;
        }
        Texture2D SlicedBaseTexture(Sprite sprite)
        {
            Texture2D baseTex = ResourceLoader.LoadTexture("AttackIcons");
            Rect rect = sprite.rect;
            Texture2D slicedTex = new Texture2D((int)rect.width, (int)rect.height);
            slicedTex.filterMode = baseTex.filterMode;

            slicedTex.SetPixels(0, 0, (int)rect.width, (int)rect.height, baseTex.GetPixels((int)rect.x, (int)rect.y, (int)rect.width, (int)rect.height));
            slicedTex.Apply();

            return slicedTex;
        }
        public override bool PerformEffect(
            CombatStats stats,
            IUnit caster,
            TargetSlotInfo[] targets,
            bool areTargetSlots,
            int entryVariable,
            out int exitAmount)
        {
            exitAmount = 0;
            PixelateIconsHook.A_PPU += 1;
            float gap = PixelateIconsHook.A_PPU;
            //gap -= 1;
            if (gap <= 1.0f)
            {
                return false;
            }
            Image[] array = Resources.FindObjectsOfTypeAll<Image>();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].name == "AttackImage")
                {
                    try
                    {
                        Sprite oldSprite = array[i].sprite;
                        Texture2D newTex = PixelateImage(GetTexture(oldSprite), gap);
                        Sprite newSprite = Sprite.Create(newTex, new Rect(0, 0, oldSprite.rect.width, oldSprite.rect.height), new Vector2(0.5f, 0.5f), oldSprite.pixelsPerUnit);
                        array[i].sprite = newSprite;
                        exitAmount++;
                    }
                    catch (Exception ex)
                    {
                        Debug.LogError("pixelating image MEGA FAILED");
                        Debug.LogError(ex.ToString() + ex.Message + ex.StackTrace);
                    }
                }
            }


            return exitAmount > 0;
        }
    }
    public static class RealScreen
    {
        public static int realWidth = 0;
        public static int realHeight = 0;
        public static bool realIsFullscreen = false;
        public static int realRefreshRate = 0;
        public static int audioBitRate = 0;
        public static bool realWasSet = false;
        public static bool isCrushed = false;
        public static bool isDoubleCrushed = false;
        public static bool isTripleCrushed = false;
        public static void Set()
        {
            if (!realWasSet)
            { realWidth = Screen.width; realHeight = Screen.height; realIsFullscreen = Screen.fullScreen; realWasSet = true; }

        }
        public static void AudioRate()
        {
            //audioBitRate = AudioSettings.outputSampleRate;
        }
    }
    public class MurderScreenResolutionEffect : EffectSO
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
            if (!RealScreen.isCrushed)
            {
                RealScreen.Set();
                Screen.SetResolution(RealScreen.realWidth / 3, RealScreen.realHeight / 3, true, 6);
                RealScreen.isCrushed = true;
                //RealScreen.AudioRate();
                //AudioSettings.outputSampleRate = 5;
            }
            else if (!RealScreen.isDoubleCrushed)
            {
                Screen.SetResolution(RealScreen.realWidth / 5, RealScreen.realHeight / 5, true, 2);
                RealScreen.isDoubleCrushed = true;
            }
            else if (!RealScreen.isTripleCrushed)
            {
                Screen.SetResolution(RealScreen.realWidth / 8, RealScreen.realHeight / 8, true, 1);
                RealScreen.isTripleCrushed = true;
            }
            else
            {
                Screen.SetResolution(RealScreen.realWidth / 11, RealScreen.realHeight / 11, false, 1);
                Thread.Sleep(100);
                Screen.SetResolution(RealScreen.realWidth / 11, RealScreen.realHeight / 11, true, 1);
            }

            return exitAmount > 0;
        }
    }
    public class UnMurderScreenResolutionEffect : EffectSO
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

            if (RealScreen.isCrushed)
            {
                Screen.SetResolution(RealScreen.realWidth, RealScreen.realHeight, RealScreen.realIsFullscreen, RealScreen.realRefreshRate);
                //AudioSettings.outputSampleRate = RealScreen.audioBitRate;
                RealScreen.isCrushed = false;
                RealScreen.isDoubleCrushed = false;
                RealScreen.isTripleCrushed = false;
            }
            return exitAmount > 0;
        }
    }
    public static class HideDamageValuesHook
    {
        public static int HideDamage = 0;
        public static int HideHeal = 0;
        public static string hidden(bool isIt)
        {
            if (UnityEngine.Random.Range(0, 100) < 60 || isIt)
            {
                int picking = UnityEngine.Random.Range(0, 19);
                switch (picking)
                {
                    case 0:
                        return "##";
                    case 1:
                        return "@%";
                    case 2:
                        return "!?";
                    case 3:
                        return "&%";
                    case 4:
                        return "!!";
                    case 5:
                        return "@$";
                    case 6:
                        return "#7%";
                    case 7:
                        return "Q!*?";
                    case 8:
                        return ">0#>*";
                    case 9:
                        return "~";
                    case 10:
                        return "99";
                    case 11:
                        return "THE";
                    case 12:
                        return "$4.52";
                    case 13:
                        return "@PH<";
                    case 14:
                        return "www.www";
                    case 15:
                        return "!*&y3JU.?<6*~`h3D[(^P?'";
                    case 16:
                        return "<<<<";
                    case 17:
                        return "&&";
                    case 18:
                        return "{[(";
                    case 19:
                        return "\"\"";
                }
                return "why";
            }
            else
            {
                return "??";
            }
        }

        public static void HideDamageShowcase(Action<PopUpHandler3D, bool, Vector3, int, DamageType> orig, PopUpHandler3D self, bool isFieldText, Vector3 position, int amount, DamageType type)
        {
            if (HideDamage > 0)
            {
                List<CombatText> idleList;
                CombatText currentText = self.GetIdleText(isFieldText, out idleList);
                currentText.transform.position = position;
                TweenSettingsExtensions.OnComplete<Sequence>(self._damageTextOptions.PrepareTextOptions(currentText, hidden(type == (DamageType)888666 || type == (DamageType)888667), (int)type), delegate ()
                {
                    self.FinalizeTextShowcase(currentText, idleList);
                });
                currentText.gameObject.SetActive(true);
            }
            else
            {
                orig(self, isFieldText, position, amount, type);
            }
        }
        public static void HideShieldShowcase(Action<PopUpHandler3D, bool, Vector3, int> orig, PopUpHandler3D self, bool isFieldText, Vector3 position, int amount)
        {
            if (HideDamage > 0)
            {
                List<CombatText> idleList;
                CombatText currentText = self.GetIdleText(isFieldText, out idleList);
                currentText.transform.position = position;
                TweenSettingsExtensions.OnComplete<Sequence>(self._shieldTextOptions.PrepareTextOptions(currentText, hidden(false), 0), delegate ()
                {
                    self.FinalizeTextShowcase(currentText, idleList);
                });
                currentText.gameObject.SetActive(true);
            }
            else
            {
                orig(self, isFieldText, position, amount);
            }
        }
        public static void HideParasiteShowcase(Action<PopUpHandler3D, bool, Vector3, int> orig, PopUpHandler3D self, bool isFieldText, Vector3 position, int amount)
        {
            if (HideDamage > 0)
            {
                List<CombatText> idleList;
                CombatText currentText = self.GetIdleText(isFieldText, out idleList);
                currentText.transform.position = position;
                TweenSettingsExtensions.OnComplete<Sequence>(self._parasiteTextOptions.PrepareTextOptions(currentText, hidden(false), 0), delegate ()
                {
                    self.FinalizeTextShowcase(currentText, idleList);
                });
                currentText.gameObject.SetActive(true);
            }
            else
            {
                orig(self, isFieldText, position, amount);
            }
        }
        public static void HideHealShowcase(Action<PopUpHandler3D, bool, Vector3, int, HealType> orig, PopUpHandler3D self, bool isFieldText, Vector3 position, int amount, HealType type)
        {
            if (HideHeal > 0)
            {
                List<CombatText> idleList;
                CombatText currentText = self.GetIdleText(isFieldText, out idleList);
                currentText.transform.position = position;
                TweenSettingsExtensions.OnComplete<Sequence>(self._healTextOptions.PrepareTextOptions(currentText, hidden(false), (int)type), delegate ()
                {
                    self.FinalizeTextShowcase(currentText, idleList);
                });
                currentText.gameObject.SetActive(true);
            }
            else
            {
                orig(self, isFieldText, position, amount, type);
            }
        }

        public static void Add()
        {
            IDetour HideDamageIDetour = (IDetour)new Hook((MethodBase)typeof(PopUpHandler3D).GetMethod("StartDamageShowcase", ~BindingFlags.Default), typeof(HideDamageValuesHook).GetMethod("HideDamageShowcase", ~BindingFlags.Default));
            IDetour HideShieldIDetour = (IDetour)new Hook((MethodBase)typeof(PopUpHandler3D).GetMethod("StartShieldShowcase", ~BindingFlags.Default), typeof(HideDamageValuesHook).GetMethod("HideShieldShowcase", ~BindingFlags.Default));
            IDetour HideLLIDetour = (IDetour)new Hook((MethodBase)typeof(PopUpHandler3D).GetMethod("StartParasiteShowcase", ~BindingFlags.Default), typeof(HideDamageValuesHook).GetMethod("HideParasiteShowcase", ~BindingFlags.Default));
            IDetour HideHealIDetour = (IDetour)new Hook((MethodBase)typeof(PopUpHandler3D).GetMethod("StartHealShowcase", ~BindingFlags.Default), typeof(HideDamageValuesHook).GetMethod("HideHealShowcase", ~BindingFlags.Default));

        }
    }
    public class HideDamageEffect : EffectSO
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

            if (caster.GetStoredValue((UnitStoredValueNames)255358) < 1)
            {
                HideDamageValuesHook.HideDamage += 1;
                caster.SetStoredValue((UnitStoredValueNames)255358, 1);
                exitAmount += 1;
            }

            return exitAmount > 0;
        }
    }
    public class UnhideDamageEffect : EffectSO
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

            if (caster.GetStoredValue((UnitStoredValueNames)255358) > 0)
            {
                HideDamageValuesHook.HideDamage -= 1;
                caster.SetStoredValue((UnitStoredValueNames)255358, 0);
                exitAmount += 1;
            }

            return exitAmount > 0;
        }
    }
    public class HideHealEffect : EffectSO
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

            if (caster.GetStoredValue((UnitStoredValueNames)255359) < 1)
            {
                HideDamageValuesHook.HideHeal += 1;
                caster.SetStoredValue((UnitStoredValueNames)255359, 1);
                exitAmount += 1;
            }

            return exitAmount > 0;
        }
    }
    public class UnhideHealEffect : EffectSO
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

            if (caster.GetStoredValue((UnitStoredValueNames)255359) > 0)
            {
                HideDamageValuesHook.HideHeal -= 1;
                caster.SetStoredValue((UnitStoredValueNames)255359, 0);
                exitAmount += 1;
            }

            return exitAmount > 0;

        }
    }

    public class TimeAbominationPassiveAbility : BasePassiveAbilitySO
    {
        [SerializeField]
        private int _floorVal = 0;

        [SerializeField]
        public int seconds = 6;

        public override bool IsPassiveImmediate => true;

        public override bool DoesPassiveTrigger => true;

        public Thread timerThread = null;

        public static void AddTurnsThread(object obj)
        {
            //Debug.Log("started");
            if (obj is IUnit unit)
            {
                while (!unit.Equals(null) && unit.IsAlive)
                {
                    int amountOfTime = 50 * unit.GetStoredValue((UnitStoredValueNames)20051511);
                    for (int i = 0; i < amountOfTime; i++)
                    {
                        Thread.Sleep(20);
                    }

                    if (unit is EnemyCombat enemyOnField && unit.ContainsPassiveAbility((PassiveAbilityTypes)77696))
                    {
                        CombatManager.Instance._stats.timeline.TryAddNewExtraEnemyTurns((ITurn)enemyOnField, 1);
                        Debug.Log("turn added");
                    }

                }
            }
        }

        public override void TriggerPassive(object sender, object args)
        {
            if (timerThread != null)
            {
                timerThread.Abort();
            }
            IUnit unit = sender as IUnit;
            timerThread = new Thread(new ParameterizedThreadStart(AddTurnsThread));
            timerThread.Start(unit);


        }

        public override void OnPassiveConnected(IUnit unit)
        {
            unit.SetStoredValue((UnitStoredValueNames)20051511, seconds);
            //Debug.Log("timer abom passive");
            TimerAbominationPassiveHook.inCombat += 1;
            timerThread = new Thread(new ParameterizedThreadStart(AddTurnsThread));
            timerThread.Start(unit);
            //Debug.Log("thread thing");
        }

        public override void OnPassiveDisconnected(IUnit unit)
        {
            TimerAbominationPassiveHook.inCombat -= 1;
        }
    }
    public static class TimerAbominationPassiveHook
    {
        public static int inCombat = 0;
        
        public static void ForOnPointerExit(Action<EnemyInFieldLayout, PointerEventData> orig, EnemyInFieldLayout self, PointerEventData eventData)
        {
            if (inCombat > 0)
            {
                //Debug.Log("exit");
                EnemyCombat enemy = CombatManager.Instance._stats.TryGetEnemyOnField(self.EnemyID);
                if (enemy == (object)null)
                {
                    return;
                }
                if (enemy.ContainsPassiveAbility((PassiveAbilityTypes)77696))
                {
                    CombatManager.Instance.PostNotification(((TriggerCalls)77696).ToString(), enemy as IUnit, null);
                }
            }
            orig(self, eventData);
        }
        public static void ForOnPointerEnter(Action<EnemyInFieldLayout, PointerEventData> orig, EnemyInFieldLayout self, PointerEventData eventData)
        {
            if (inCombat > 0)
            {
                //Debug.Log("enter");
                EnemyCombat enemy = CombatManager.Instance._stats.TryGetEnemyOnField(self.EnemyID);
                if (enemy == (object)null)
                {
                    return;
                }
                if (enemy.ContainsPassiveAbility((PassiveAbilityTypes)77696))
                {
                    foreach (BasePassiveAbilitySO passive in enemy._passiveAbilities)
                    {
                        if (passive is TimeAbominationPassiveAbility timerAbom)
                        {
                            if (timerAbom.timerThread != null)
                            {
                                timerAbom.timerThread.Abort();
                            }
                        }
                    }
                }
            }
            orig(self, eventData);
        }
        public static void Add()
        {
            IDetour OnEnterIDetour = (IDetour)new Hook((MethodBase)typeof(EnemyInFieldLayout).GetMethod("OnPointerEnter", ~BindingFlags.Default), typeof(TimerAbominationPassiveHook).GetMethod("ForOnPointerEnter", ~BindingFlags.Default));
            IDetour OnExitIDetour = (IDetour)new Hook((MethodBase)typeof(EnemyInFieldLayout).GetMethod("OnPointerExit", ~BindingFlags.Default), typeof(TimerAbominationPassiveHook).GetMethod("ForOnPointerExit", ~BindingFlags.Default));

        }
    }
    public class IntegerSetterBasedOnStoredValuePassiveAbility : BasePassiveAbilitySO
    {
        [Header("IntegerSetter Data")]
        [SerializeField]
        public bool _isItAdditive = true;
        [SerializeField]
        public int integerValue;

        public UnitStoredValueNames storeVal = (UnitStoredValueNames)77697;

        public override bool IsPassiveImmediate => true;

        public override bool DoesPassiveTrigger => true;

        public Thread timerThread = null;

        public override void TriggerPassive(object sender, object args)
        {
            if (!(args is IntegerReference integerReference))
                return;
            if (this._isItAdditive)
                integerReference.value += (sender as IUnit).GetStoredValue(storeVal);
            else
                integerReference.value = this.integerValue;
        }
        public static void AddTurnsPerTurnThread(object obj)
        {
            if (obj is IUnit unit)
            {
                while (!unit.Equals(null) && unit.IsAlive)
                {
                    for (int i = 0; i < 600; i++)
                    {
                        Thread.Sleep(100);
                    }
                    if (!unit.Equals(null) && unit.IsAlive)
                    {
                        if (unit is EnemyCombat enemyOnField && unit.ContainsPassiveAbility((PassiveAbilityTypes)77697))
                        {
                            unit.SetStoredValue((UnitStoredValueNames)77697, unit.GetStoredValue((UnitStoredValueNames)77697) + 1);
                        }
                    }

                }
            }
        }
        public override void OnPassiveConnected(IUnit unit)
        {
            timerThread = new Thread(new ParameterizedThreadStart(AddTurnsPerTurnThread));
            timerThread.Start(unit);
        }

        public override void OnPassiveDisconnected(IUnit unit)
        {
            if (timerThread != null)
            {
                timerThread.Abort();
            }
        }
    }
    public class GainFuckingAbilitiesPassiveAbility : BasePassiveAbilitySO
    {
        [SerializeField]
        private int _floorVal = 0;

        public override bool IsPassiveImmediate => true;

        public override bool DoesPassiveTrigger => true;

        public Thread timerThread = null;

        public static void AddTurnsThread(object obj)
        {
            if (obj is IUnit unit)
            {
                while (!unit.Equals(null) && unit.IsAlive)
                {
                    for (int i = 0; i < 300; i++)
                    {
                        Thread.Sleep(1000);
                    }
                    if (!unit.Equals(null) && unit.IsAlive)
                    {
                        if (unit is EnemyCombat enemyOnField && unit.ContainsPassiveAbility((PassiveAbilityTypes)77698))
                        {
                            CombatManager.Instance._stats.timeline.TryAddNewExtraEnemyTurns((ITurn)enemyOnField, 1);
                        }
                    }

                }
            }
        }

        public override void TriggerPassive(object sender, object args)
        {

        }
        public override void OnPassiveConnected(IUnit unit)
        {
            timerThread = new Thread(new ParameterizedThreadStart(AddTurnsThread));
            timerThread.Start(unit);
        }

        public override void OnPassiveDisconnected(IUnit unit)
        {
            if (timerThread != null)
            {
                timerThread.Abort();
            }
        }
    }
    public class MurderPeopleOnPausePassiveAbility : BasePassiveAbilitySO
    {
        public override bool IsPassiveImmediate => true;

        public override bool DoesPassiveTrigger => true;

        public override void TriggerPassive(object sender, object args)
        {

        }
        public override void OnPassiveConnected(IUnit unit)
        {
            CombatManager.Instance.AddObserver(OnPauseTriggered, Tools.Utils.pauseTriggerNtf.ToString());
            
            PauseUIHandler handler = GameObject.FindObjectOfType<PauseUIHandler>(true);
            Transform buttonsZone = handler.transform.GetChild(1).GetChild(1).GetChild(0);
            Transform mainMenuTransform = buttonsZone.GetChild(3);
            Transform exitGameTransform = buttonsZone.GetChild(4);
            Button mainMenuButton = mainMenuTransform.GetComponent<Button>();
            Button exitGameButton = exitGameTransform.GetComponent<Button>();
            //mainMenuButton.onClick.AddListener(delegate () { killThreads(); });
            //exitGameButton.onClick.AddListener(delegate () { killThreads(); });

            

        }
        public void OnPauseTriggered(object sender, object args)
        {
            BooleanReference reference = args as BooleanReference;
            if (reference == null)
                return;
            //Here you add any check you want, reference.value contains if the game is paused (true) or not (false)
            if (reference.value == true)
            {
                Targetting_ByUnit_Side allAlly = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
                allAlly.getAllies = true;
                allAlly.getAllUnitSlots = false;
                Effect PaleIt = new Effect(ScriptableObject.CreateInstance<PaleRandomTargetEffect>(), 25, null, allAlly);
                //CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction((sender as IPassiveEffector).ID, (sender as IPassiveEffector).IsUnitCharacter, GetPassiveLocData().text));
                CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { PaleIt }), CombatManager.Instance._stats.CharactersOnField.First().Value));
            }
        }
        public override void OnPassiveDisconnected(IUnit unit)
        {
            CombatManager.Instance.RemoveObserver(OnPauseTriggered, Tools.Utils.pauseTriggerNtf.ToString());
        }
    }
    public class PaleRandomTargetEffect : EffectSO
    {
        [SerializeField]
        public bool _usePreviousExitValue;
        [SerializeField]
        public bool _ignoreShield;
        [SerializeField]
        public bool _indirect;
        public int _scars;

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
            List<TargetSlotInfo> targetSlotInfoList = new List<TargetSlotInfo>();
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                    targetSlotInfoList.Add(target);
            }
            if (targetSlotInfoList.Count <= 0)
                return false;
            int index = UnityEngine.Random.Range(0, targetSlotInfoList.Count);
            TargetSlotInfo targetSlotInfo = targetSlotInfoList[index];

            Effect PaleIt = new Effect(ScriptableObject.CreateInstance<ApplyPaleEffect>(), 25, null, Slots.Self);
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { PaleIt }), targetSlotInfo.Unit));


            return exitAmount > 0;
        }
    }
    public class SwitchUnStitchedAndInvertedOnPausePassiveAbility : BasePassiveAbilitySO
    {
        public override bool IsPassiveImmediate => true;

        public override bool DoesPassiveTrigger => true;

        public override void TriggerPassive(object sender, object args)
        {
            Debug.Log("WHAT");
        }
        public override void OnPassiveConnected(IUnit unit)
        {
            CombatManager.Instance.AddObserver(OnPauseTriggered, Tools.Utils.pauseTriggerNtf.ToString());
            
            PauseUIHandler handler = GameObject.FindObjectOfType<PauseUIHandler>(true);
            Transform buttonsZone = handler.transform.GetChild(1).GetChild(1).GetChild(0);
            Transform mainMenuTransform = buttonsZone.GetChild(3);
            Transform exitGameTransform = buttonsZone.GetChild(4);
            Button mainMenuButton = mainMenuTransform.GetComponent<Button>();
            Button exitGameButton = exitGameTransform.GetComponent<Button>();
            //mainMenuButton.onClick.AddListener(delegate () { killThreads(); });
            //exitGameButton.onClick.AddListener(delegate () { killThreads(); });

            

        }
        public void OnPauseTriggered(object sender, object args)
        {
            BooleanReference reference = args as BooleanReference;
            if (reference == null)
                return;
            //Here you add any check you want, reference.value contains if the game is paused (true) or not (false)
            if (reference.value == true)
            {
                Targetting_ByUnit_Side allEnemy = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
                allEnemy.getAllies = false;
                allEnemy.getAllUnitSlots = false;
                Targetting_ByUnit_Side allAlly = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
                allAlly.getAllies = true;
                allAlly.getAllUnitSlots = false;
                Effect allies = new Effect(ScriptableObject.CreateInstance<SwitchUnStitchedAndInvertedEffect>(), 25, null, allAlly);
                Effect enemies = new Effect(ScriptableObject.CreateInstance<SwitchUnStitchedAndInvertedEffect>(), 25, null, allEnemy);
                //CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction((sender as IPassiveEffector).ID, (sender as IPassiveEffector).IsUnitCharacter, GetPassiveLocData().text));
                CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[2] { allies, enemies }), CombatManager.Instance._stats.CharactersOnField.First().Value));
            }
        }
        public override void OnPassiveDisconnected(IUnit unit)
        {
            CombatManager.Instance.RemoveObserver(OnPauseTriggered, Tools.Utils.pauseTriggerNtf.ToString());
        }
    }
    public class SwitchUnStitchedAndInvertedEffect : EffectSO
    {
        [SerializeField]
        public bool _usePreviousExitValue;
        [SerializeField]
        public bool _ignoreShield;
        [SerializeField]
        public bool _indirect;
        public int _scars;

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
            
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit)
                {
                    bool hasFirst = false;
                    bool hasSecond = false;
                    if (target.Unit.ContainsStatusEffect((StatusEffectType)846749))
                    {
                        hasFirst = true;
                        
                    }
                    if (target.Unit.ContainsStatusEffect((StatusEffectType)846748))
                    {
                        hasSecond = true;
                        
                    }
                    if (hasFirst)
                    {
                        GenericTargetting_BySlot_Index thisGuy = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
                        thisGuy.getAllies = target.Unit.IsUnitCharacter;
                        thisGuy.slotPointerDirections = new int[] { target.Unit.SlotID };
                        Effect applyIt = new Effect(ScriptableObject.CreateInstance<ApplyUnStitchedEffect>(), 1, null, thisGuy);
                        RemoveStatusEffectEffect removeThis = ScriptableObject.CreateInstance<RemoveStatusEffectEffect>();
                        removeThis._statusToRemove = (StatusEffectType)846749;
                        Effect removeIt = new Effect(removeThis, 1, null, thisGuy);
                        CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[2] { removeIt, applyIt }), CombatManager.Instance._stats.CharactersOnField.First().Value));
                        exitAmount++;
                    }
                    if (hasSecond)
                    {
                        GenericTargetting_BySlot_Index thisGuy = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
                        thisGuy.getAllies = target.Unit.IsUnitCharacter;
                        thisGuy.slotPointerDirections = new int[] { target.Unit.SlotID };
                        Effect applyIt = new Effect(ScriptableObject.CreateInstance<ApplyInvertedEffect>(), 30, null, thisGuy);
                        RemoveStatusEffectEffect removeThis = ScriptableObject.CreateInstance<RemoveStatusEffectEffect>();
                        removeThis._statusToRemove = (StatusEffectType)846748;
                        Effect removeIt = new Effect(removeThis, 1, null, thisGuy);
                        CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[2] { removeIt, applyIt }), CombatManager.Instance._stats.CharactersOnField.First().Value));
                        exitAmount++;
                    }
                }
            }

            

            
            return exitAmount > 0;
        }
    }

    public class CleanItUpEffect : EffectSO
    {
        [SerializeField]
        public bool _usePreviousExitValue;
        [SerializeField]
        public bool _ignoreShield;
        [SerializeField]
        public bool _indirect;
        public int _scars;

        public override bool PerformEffect(
          CombatStats stats,
          IUnit caster,
          TargetSlotInfo[] targets,
          bool areTargetSlots,
          int entryVariable,
          out int exitAmount)
        {
            HideHealthBarsPassive.inCombat = 0;
            HideHealthBarsPassive.hideCH_RealHP = 0;
            HideHealthBarsPassive.hideEN_RealHP = 0;
            HideHealthBarsPassive.hideCH_MaxHP = 0;
            HideHealthBarsPassive.hideEN_MaxHP = 0;
            HideHealthBarsPassive.hideCH_BarFill = 0;
            HideHealthBarsPassive.hideEN_BarFill = 0;
            HideDamageValuesHook.HideDamage = 0;
            HideDamageValuesHook.HideHeal = 0;
            PixelateSpritesHook.CH_PPU = 1;
            PixelateIconsHook.A_PPU = 1;
            SaltEnemies.inCombat = false;
            SaltEnemies.inCombatClicking = 0;
            exitAmount = 1;
            return exitAmount > 0;
        }
    }

    public static class AttackSlotsErrorHook
    {
        public static void selectThisMove(Action<AttackListLayout, int, bool> orig, AttackListLayout self, int attackID, bool playSound)
        {
            if (self.CurrentAttackSelected >= self._attackSlots.Length)
            {
                Debug.Log("ITS FUCKED");
                return;
            }
            if (attackID >= self._attackSlots.Length)
            {
                Debug.Log("ITS FUCKED");
                return;
            }
            orig(self, attackID, playSound);
        }
        public static void Add()
        {
            IDetour HOOKAAA = (IDetour)new Hook((MethodBase)typeof(AttackListLayout).GetMethod("SelectAttack", ~BindingFlags.Default), typeof(AttackSlotsErrorHook).GetMethod("selectThisMove", ~BindingFlags.Default));
        }
    }
}
