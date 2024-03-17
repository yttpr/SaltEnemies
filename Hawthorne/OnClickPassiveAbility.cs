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
using static UnityEngine.UI.CanvasScaler;
using static System.Net.Mime.MediaTypeNames;
using static UnityEngine.GraphicsBuffer;

namespace Hawthorne
{
    public class OnClickPassiveAbility : BasePassiveAbilitySO
    {
        [Header("Multiplier Data")]
        [SerializeField]
        private bool _temp = false;
        

        public override bool IsPassiveImmediate => true;

        public override bool DoesPassiveTrigger => true;

        


        public override void TriggerPassive(object sender, object args)
        {
            IUnit unit = sender as IUnit;
            if ((unit as EnemyCombat)._currentName != "Strange Box")
            {
                CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(unit.ID, unit.IsUnitCharacter, GetPassiveLocData().text, this.passiveIcon));
                Effect entering = new Effect(ScriptableObject.CreateInstance<AddTurnTargetToTimelineEffect>(), 1, new IntentType?(), Slots.Self);
                CombatManager.Instance.AddPrioritySubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { entering }), unit));
            }
            int numbahClicked = unit.GetStoredValue((UnitStoredValueNames)267850);
            numbahClicked++;
            unit.SetStoredValue((UnitStoredValueNames)267850, numbahClicked);

        }



        public override void OnPassiveConnected(IUnit unit)
        {
            Effect entering = new Effect(ScriptableObject.CreateInstance<TurnOnOnClickTriggerEffect>(), 1, new IntentType?(), Slots.Self);
            CombatManager.Instance.AddPriorityRootAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { entering }), unit));
        }

        public override void OnPassiveDisconnected(IUnit unit)
        {
            Effect exiting = new Effect(ScriptableObject.CreateInstance<TurnOffOnClickTriggerEffect>(), 1, new IntentType?(), Slots.Self);
            CombatManager.Instance.AddPriorityRootAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { exiting }), unit));
        }
    }
    public class TryTriggerOnClickEffect : EffectSO
    {
        [SerializeField]
        public PassiveAbilityTypes passiveType = (PassiveAbilityTypes)544522;
        [SerializeField]
        public int thisOne;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            //Debug.Log("effect going");
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                //Debug.Log("a target");
                if (targetSlotInfo.HasUnit && !(targetSlotInfo.Unit.IsUnitCharacter))
                {
                    //Debug.Log("enemy");
                    EnemyCombat enemyOnField = targetSlotInfo.Unit as EnemyCombat;
                    //Debug.Log(enemyOnField.Enemy._enemyName);
                    //Debug.Log(targetSlotInfo.Unit.ID);
                    //Debug.Log(enemyOnField.ID);
                    //Debug.Log(enemyOnField.FieldID);
                    /*Debug.Log(enemyOnField.Enemy._enemyName);
                    Debug.Log(enemyOnField.Enemy.enemyTemplate.EnemyID);*/
                    if (enemyOnField.ID == thisOne && targetSlotInfo.Unit.ContainsPassiveAbility(passiveType))
                    {
                        //Debug.Log("is clicked");
                        //CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(targetSlotInfo.Unit.ID, targetSlotInfo.Unit.IsUnitCharacter, "Don't Touch Me"));

                        CombatManager.Instance.PostNotification(((TriggerCalls)267850).ToString(), targetSlotInfo.Unit, null);
                    }
                }
            }
            exitAmount = 1;
            return true;
        }
    }
    public class FromUnitTryTriggerTimelineClickEffect : EffectSO
    {
        [SerializeField]
        public PassiveAbilityTypes passiveType = (PassiveAbilityTypes)544522;
        [SerializeField]
        public IUnit thisOne;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            //Debug.Log("effect going");
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                //Debug.Log("a target");
                if (targetSlotInfo.HasUnit && !(targetSlotInfo.Unit.IsUnitCharacter))
                {
                    //Debug.Log("enemy");
                    EnemyCombat enemyOnField = targetSlotInfo.Unit as EnemyCombat;
                    //Debug.Log(enemyOnField.Enemy._enemyName);
                    //Debug.Log(targetSlotInfo.Unit.ID);
                    //Debug.Log(enemyOnField.ID);
                    //Debug.Log(enemyOnField.FieldID);
                    /*Debug.Log(enemyOnField.Enemy._enemyName);
                    Debug.Log(enemyOnField.Enemy.enemyTemplate.EnemyID);*/
                    if (enemyOnField == thisOne && targetSlotInfo.Unit.ContainsPassiveAbility(passiveType))
                    {
                        //Debug.Log("is clicked");
                        //CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(targetSlotInfo.Unit.ID, targetSlotInfo.Unit.IsUnitCharacter, "Don't Touch Me"));

                        CombatManager.Instance.PostNotification(((TriggerCalls)267850).ToString(), targetSlotInfo.Unit, null);
                    }
                }
            }
            exitAmount = 1;
            return true;
        }
    }
    public class TurnOffOnClickTriggerEffect : EffectSO
    {
        [SerializeField]
        public PassiveAbilityTypes passiveType = (PassiveAbilityTypes)544522;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;

            if (caster.GetStoredValue((UnitStoredValueNames)267851) > 0)
            {
                SaltEnemies.inCombatClicking -= 1;
                caster.SetStoredValue((UnitStoredValueNames)267851, 0);
            }
            exitAmount = 1;
            return true;
        }
    }
    public class TurnOnOnClickTriggerEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (caster.GetStoredValue((UnitStoredValueNames)267851) == 0)
            {
                SaltEnemies.inCombatClicking += 1;
                caster.SetStoredValue((UnitStoredValueNames)267851, 1);
            }
            return true;
        }
    }
}
