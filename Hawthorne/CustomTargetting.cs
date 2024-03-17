using System;
using System.Collections.Generic;
using System.Text;

namespace Hawthorne
{
    public class TargettingClosestUnits : BaseCombatTargettingSO
    {
        public bool getAllies;

        public bool ignoreCastSlot = true;

        public override bool AreTargetAllies => getAllies;

        public override bool AreTargetSlots => true;

        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            List<TargetSlotInfo> targets = new List<TargetSlotInfo>();
            CombatSlot greaterest = null;
            CombatSlot lesserest = null;
            if ((isCasterCharacter && getAllies) || (!isCasterCharacter && !getAllies))
            {
                foreach (CombatSlot slot in slots.CharacterSlots)
                {
                    if ((slot.HasUnit && slot.SlotID > casterSlotID) && (!ignoreCastSlot || casterSlotID != slot.SlotID))
                    {
                        if (greaterest == null)
                        {
                            greaterest = slot;
                        }
                        else if (slot.SlotID < greaterest.SlotID)
                        {
                            greaterest = slot;
                        }
                    }
                    else if (slot.HasUnit && (slot.SlotID < casterSlotID) && (!ignoreCastSlot || casterSlotID != slot.SlotID))
                    {
                        if (lesserest == null)
                        {
                            lesserest = slot;
                        }
                        else if (slot.SlotID > lesserest.SlotID)
                        {
                            lesserest = slot;
                        }
                    }
                }
            }
            else
            {
                foreach (CombatSlot slot in slots.EnemySlots)
                {
                    if ((slot.HasUnit && slot.SlotID > casterSlotID) && (!ignoreCastSlot || casterSlotID != slot.SlotID))
                    {
                        if (greaterest == null)
                        {
                            greaterest = slot;
                        }
                        else if (slot.SlotID < greaterest.SlotID)
                        {
                            greaterest = slot;
                        }
                    }
                    else if (slot.HasUnit && (slot.SlotID < casterSlotID) && (!ignoreCastSlot || casterSlotID != slot.SlotID))
                    {
                        if (lesserest == null)
                        {
                            lesserest = slot;
                        }
                        else if (slot.SlotID > lesserest.SlotID)
                        {
                            lesserest = slot;
                        }
                    }
                }
            }
            if (greaterest != null)
            {
                targets.Add(greaterest.TargetSlotInformation);
            }
            if (lesserest != null)
            {
                targets.Add(lesserest.TargetSlotInformation);
            }
            return targets.ToArray();
        }
    }
    public class TargettingFarthestUnits : BaseCombatTargettingSO
    {
        public bool getAllies;

        public bool ignoreCastSlot = true;

        public override bool AreTargetAllies => getAllies;

        public override bool AreTargetSlots => true;

        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            List<TargetSlotInfo> targets = new List<TargetSlotInfo>();
            CombatSlot greaterest = null;
            CombatSlot lesserest = null;
            if ((isCasterCharacter && getAllies) || (!isCasterCharacter && !getAllies))
            {
                foreach (CombatSlot slot in slots.CharacterSlots)
                {
                    if ((slot.HasUnit && slot.SlotID > casterSlotID) && (!ignoreCastSlot || casterSlotID != slot.SlotID))
                    {
                        if (greaterest == null)
                        {
                            greaterest = slot;
                        }
                        else if (slot.SlotID > greaterest.SlotID)
                        {
                            greaterest = slot;
                        }
                    }
                    else if (slot.HasUnit && (slot.SlotID < casterSlotID) && (!ignoreCastSlot || casterSlotID != slot.SlotID))
                    {
                        if (lesserest == null)
                        {
                            lesserest = slot;
                        }
                        else if (slot.SlotID < lesserest.SlotID)
                        {
                            lesserest = slot;
                        }
                    }
                }
            }
            else
            {
                foreach (CombatSlot slot in slots.EnemySlots)
                {
                    if ((slot.HasUnit && slot.SlotID > casterSlotID) && (!ignoreCastSlot || casterSlotID != slot.SlotID))
                    {
                        if (greaterest == null)
                        {
                            greaterest = slot;
                        }
                        else if (slot.SlotID < greaterest.SlotID)
                        {
                            greaterest = slot;
                        }
                    }
                    else if (slot.HasUnit && (slot.SlotID < casterSlotID) && (!ignoreCastSlot || casterSlotID != slot.SlotID))
                    {
                        if (lesserest == null)
                        {
                            lesserest = slot;
                        }
                        else if (slot.SlotID > lesserest.SlotID)
                        {
                            lesserest = slot;
                        }
                    }
                }
            }
            if (greaterest != null)
            {
                targets.Add(greaterest.TargetSlotInformation);
            }
            if (lesserest != null)
            {
                targets.Add(lesserest.TargetSlotInformation);
            }
            return targets.ToArray();
        }
    }
    public class TargettingRandomUnit : BaseCombatTargettingSO
    {
        public bool getAllies;

        public bool ignoreCastSlot = false;

        public override bool AreTargetAllies => getAllies;

        public override bool AreTargetSlots => false;

        public static bool IsUnitAlreadyContained(List<TargetSlotInfo> targets, TargetSlotInfo target)
        {
            foreach (TargetSlotInfo targe in targets)
            {
                if (targe.Unit == target.Unit)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsCastSlot(int caster, TargetSlotInfo target)
        {
            if (!ignoreCastSlot) { return false; }
            else if (caster != target.SlotID) { return false; }
            else return true;
        }

        public static TargetSlotInfo LastRandom = null;

        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            List<TargetSlotInfo> targets = new List<TargetSlotInfo>();
            if ((getAllies && isCasterCharacter) || (!getAllies && !isCasterCharacter))
            {
                foreach (CombatSlot slot in slots.CharacterSlots)
                {
                    TargetSlotInfo targ = slot.TargetSlotInformation;
                    if (targ != null && targ.HasUnit && !IsUnitAlreadyContained(targets, targ) && !IsCastSlot(casterSlotID, targ))
                    {
                        targets.Add(targ);
                    }
                }
            }
            else
            {
                foreach (CombatSlot slot in slots.EnemySlots)
                {
                    TargetSlotInfo targ = slot.TargetSlotInformation;
                    if (targ != null && targ.HasUnit && !IsUnitAlreadyContained(targets, targ) && !IsCastSlot(casterSlotID, targ))
                    {
                        targets.Add(targ);
                    }
                }
            }
            if (targets.Count <= 0)
            {
                LastRandom = null;
                return new TargetSlotInfo[0];
            }
            TargetSlotInfo goy = targets[UnityEngine.Random.Range(0, targets.Count)];
            LastRandom = goy;
            return new TargetSlotInfo[] { goy };
        }
    }
    public class TargettingLastRandomUnit : BaseCombatTargettingSO
    {
        public bool IsTargetAlly(bool isCasterChara)
        {
            if (TargettingRandomUnit.LastRandom == null) return false;
            if (isCasterChara == TargettingRandomUnit.LastRandom.IsTargetCharacterSlot)
            {
                LastCheckedIsAlly = true;
                return true;
            }
            else
            {
                LastCheckedIsAlly = false;
                return false;
            }
        }

        public bool LastCheckedIsAlly = false;
        
        public override bool AreTargetAllies => LastCheckedIsAlly;

        public override bool AreTargetSlots => false;

        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            IsTargetAlly(isCasterCharacter);
            if (TargettingRandomUnit.LastRandom == null) return new TargetSlotInfo[0];
            return new TargetSlotInfo[] { TargettingRandomUnit.LastRandom };
        }
    }
    public class TargettingUnitsWithStatusEffectSide : BaseCombatTargettingSO
    {
        public bool getAllies;

        public bool ignoreCastSlot = false;

        public StatusEffectType targetStatus;

        public override bool AreTargetAllies => getAllies;

        public override bool AreTargetSlots => false;

        public static bool IsUnitAlreadyContained(List<TargetSlotInfo> targets, TargetSlotInfo target)
        {
            foreach (TargetSlotInfo targe in targets)
            {
                if (targe.Unit == target.Unit)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsCastSlot(int caster, TargetSlotInfo target)
        {
            if (!ignoreCastSlot) { return false; }
            else if (caster != target.SlotID) { return false; }
            else return true;
        }

        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            List<TargetSlotInfo> targets = new List<TargetSlotInfo>();
            if ((getAllies && isCasterCharacter) || (!getAllies && !isCasterCharacter))
            {
                foreach (CombatSlot slot in slots.CharacterSlots)
                {
                    TargetSlotInfo targ = slot.TargetSlotInformation;
                    if (targ != null && targ.HasUnit && !IsUnitAlreadyContained(targets, targ) && !IsCastSlot(casterSlotID, targ) && targ.Unit.ContainsStatusEffect(targetStatus))
                    {
                        targets.Add(targ);
                    }
                }
            }
            else
            {
                foreach (CombatSlot slot in slots.EnemySlots)
                {
                    TargetSlotInfo targ = slot.TargetSlotInformation;
                    if (targ != null && targ.HasUnit && !IsUnitAlreadyContained(targets, targ) && !IsCastSlot(casterSlotID, targ) && targ.Unit.ContainsStatusEffect(targetStatus))
                    {
                        targets.Add(targ);
                    }
                }
            }
            return targets.ToArray();
        }
    }
    public class TargettingUnitsWithStatusEffectAll : BaseCombatTargettingSO
    {
        public bool ignoreCastSlot = false;

        public StatusEffectType targetStatus;

        public override bool AreTargetAllies => false;

        public override bool AreTargetSlots => false;

        public static bool IsUnitAlreadyContained(List<TargetSlotInfo> targets, TargetSlotInfo target)
        {
            foreach (TargetSlotInfo targe in targets)
            {
                if (targe.Unit == target.Unit)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsCastSlot(int caster, TargetSlotInfo target)
        {
            if (!ignoreCastSlot) { return false; }
            else if (caster != target.SlotID) { return false; }
            else return true;
        }

        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            List<TargetSlotInfo> targets = new List<TargetSlotInfo>();
            foreach (CombatSlot slot in slots.CharacterSlots)
            {
                TargetSlotInfo targ = slot.TargetSlotInformation;
                if (targ != null && targ.HasUnit && !IsUnitAlreadyContained(targets, targ) && !IsCastSlot(casterSlotID, targ) && targ.Unit.ContainsStatusEffect(targetStatus))
                {
                    targets.Add(targ);
                }
            }
            foreach (CombatSlot slot in slots.EnemySlots)
            {
                TargetSlotInfo targ = slot.TargetSlotInformation;
                if (targ != null && targ.HasUnit && !IsUnitAlreadyContained(targets, targ) && !IsCastSlot(casterSlotID, targ) && targ.Unit.ContainsStatusEffect(targetStatus))
                {
                    targets.Add(targ);
                }
            }
            return targets.ToArray();
        }
    }
    public class TargettingAllUnits : BaseCombatTargettingSO
    {
        public bool ignoreCastSlot = false;

        public override bool AreTargetAllies => false;

        public override bool AreTargetSlots => false;

        public static bool IsUnitAlreadyContained(List<TargetSlotInfo> targets, TargetSlotInfo target)
        {
            foreach (TargetSlotInfo targe in targets)
            {
                if (targe.Unit == target.Unit)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsCastSlot(int caster, TargetSlotInfo target)
        {
            if (!ignoreCastSlot) { return false; }
            else if (caster != target.SlotID) { return false; }
            else return true;
        }

        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            List<TargetSlotInfo> targets = new List<TargetSlotInfo>();
            foreach (CombatSlot slot in slots.CharacterSlots)
            {
                TargetSlotInfo targ = slot.TargetSlotInformation;
                if (targ != null && targ.HasUnit && !IsUnitAlreadyContained(targets, targ) && !IsCastSlot(casterSlotID, targ))
                {
                    targets.Add(targ);
                }
            }
            foreach (CombatSlot slot in slots.EnemySlots)
            {
                TargetSlotInfo targ = slot.TargetSlotInformation;
                if (targ != null && targ.HasUnit && !IsUnitAlreadyContained(targets, targ) && !IsCastSlot(casterSlotID, targ))
                {
                    targets.Add(targ);
                }
            }
            return targets.ToArray();
        }
    }
    public class TargettingAllSlots : BaseCombatTargettingSO
    {
        public override bool AreTargetAllies => false;

        public override bool AreTargetSlots => false;

        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            List<TargetSlotInfo> targets = new List<TargetSlotInfo>();
            foreach (CombatSlot slot in slots.CharacterSlots)
            {
                TargetSlotInfo targ = slot.TargetSlotInformation;
                if (targ != null)
                {
                    targets.Add(targ);
                }
            }
            foreach (CombatSlot slot in slots.EnemySlots)
            {
                TargetSlotInfo targ = slot.TargetSlotInformation;
                if (targ != null)
                {
                    targets.Add(targ);
                }
            }
            return targets.ToArray();
        }
    }
    public class TargettingWeakestUnit : BaseCombatTargettingSO
    {
        public bool getAllies;

        public bool ignoreCastSlot = true;

        public override bool AreTargetAllies => getAllies;

        public override bool AreTargetSlots => false;

        public bool IsSelfAllowed(TargetSlotInfo target, int casterID)
        {
            if (!ignoreCastSlot) return true;
            else if (!getAllies) return true;
            else if (target.SlotID == casterID) return false;
            else return true;
        }

        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            TargetSlotInfo weakest = null;
            if ((getAllies && isCasterCharacter) || (!getAllies && !isCasterCharacter))
            {
                foreach (CombatSlot slot in slots.CharacterSlots)
                {
                    TargetSlotInfo targ = slot.TargetSlotInformation;
                    if (targ != null && targ.HasUnit && IsSelfAllowed(targ, casterSlotID))
                    {
                        if (weakest == null)
                        {
                            weakest = targ;
                        }
                        else if (weakest.Unit.CurrentHealth > targ.Unit.CurrentHealth)
                        {
                            weakest = targ;
                        }
                        else if (weakest.Unit.CurrentHealth == targ.Unit.CurrentHealth && UnityEngine.Random.Range(0, 100) < 50)
                        {
                            weakest = targ;
                        }
                    }
                }
            }
            else
            {
                foreach (CombatSlot slot in slots.EnemySlots)
                {
                    TargetSlotInfo targ = slot.TargetSlotInformation;
                    if (targ != null && targ.HasUnit && IsSelfAllowed(targ, casterSlotID))
                    {
                        if (weakest == null)
                        {
                            weakest = targ;
                        }
                        else if (weakest.Unit.CurrentHealth > targ.Unit.CurrentHealth)
                        {
                            weakest = targ;
                        }
                        else if (weakest.Unit.CurrentHealth == targ.Unit.CurrentHealth && UnityEngine.Random.Range(0, 100) < 50)
                        {
                            weakest = targ;
                        }
                    }
                }
            }
            if (weakest == null) return new TargetSlotInfo[0];
            return new TargetSlotInfo[] { weakest };
        }
    }
    public class TargettingWeakestNotLostSheep : BaseCombatTargettingSO
    {
        public bool getAllies;

        public bool ignoreCastSlot = true;

        public override bool AreTargetAllies => getAllies;

        public override bool AreTargetSlots => false;

        public bool IsSelfAllowed(TargetSlotInfo target, int casterID)
        {
            if (!ignoreCastSlot) return true;
            else if (!getAllies) return true;
            else if (target.SlotID == casterID) return false;
            else return true;
        }

        static EnemySO LostSheep;
        static bool LostSheepExist;
        static bool LostSheepChecked = false;
        public static bool IsLostSheep(TargetSlotInfo targ)
        {
            if (!LostSheepChecked) LostSheepExist = Check.EnemyExist("LostSheep_EN");
            if (!LostSheepExist) return false;
            if (LostSheep == null || LostSheep.Equals(null)) LostSheep = LoadedAssetsHandler.GetEnemy("LostSheep_EN");
            if (targ.HasUnit)
            {
                if (targ.Unit is EnemyCombat enemy)
                {
                    if (enemy.Enemy == LostSheep) return true;
                }
            }
            return false;
        }

        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            TargetSlotInfo weakest = null;
            if ((getAllies && isCasterCharacter) || (!getAllies && !isCasterCharacter))
            {
                foreach (CombatSlot slot in slots.CharacterSlots)
                {
                    TargetSlotInfo targ = slot.TargetSlotInformation;
                    if (targ != null && targ.HasUnit && IsSelfAllowed(targ, casterSlotID))
                    {
                        if (weakest == null)
                        {
                            weakest = targ;
                        }
                        else if (weakest.Unit.CurrentHealth > targ.Unit.CurrentHealth)
                        {
                            weakest = targ;
                        }
                        else if (weakest.Unit.CurrentHealth == targ.Unit.CurrentHealth && UnityEngine.Random.Range(0, 100) < 50)
                        {
                            weakest = targ;
                        }
                    }
                }
            }
            else
            {
                foreach (CombatSlot slot in slots.EnemySlots)
                {
                    TargetSlotInfo targ = slot.TargetSlotInformation;
                    if (targ != null && targ.HasUnit && IsSelfAllowed(targ, casterSlotID) && !IsLostSheep(targ))
                    {
                        if (weakest == null)
                        {
                            weakest = targ;
                        }
                        else if (weakest.Unit.CurrentHealth > targ.Unit.CurrentHealth)
                        {
                            weakest = targ;
                        }
                        else if (weakest.Unit.CurrentHealth == targ.Unit.CurrentHealth && UnityEngine.Random.Range(0, 100) < 50)
                        {
                            weakest = targ;
                        }
                    }
                }
            }
            if (weakest == null) return new TargetSlotInfo[0];
            return new TargetSlotInfo[] { weakest };
        }
    }
    public class TargettingClosestNotLostSheep : BaseCombatTargettingSO
    {
        public bool getAllies;

        public bool ignoreCastSlot = true;

        public override bool AreTargetAllies => getAllies;

        public override bool AreTargetSlots => false;

        static EnemySO LostSheep;
        static bool LostSheepExist;
        static bool LostSheepChecked = false;
        public static bool IsLostSheep(CombatSlot targ)
        {
            if (!LostSheepChecked) LostSheepExist = Check.EnemyExist("LostSheep_EN");
            if (!LostSheepExist) return false;
            if (LostSheep == null || LostSheep.Equals(null)) LostSheep = LoadedAssetsHandler.GetEnemy("LostSheep_EN");
            if (targ.HasUnit)
            {
                if (targ.Unit is EnemyCombat enemy)
                {
                    if (enemy.Enemy == LostSheep) return true;
                }
            }
            return false;
        }

        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            List<TargetSlotInfo> targets = new List<TargetSlotInfo>();
            CombatSlot greaterest = null;
            CombatSlot lesserest = null;
            if ((isCasterCharacter && getAllies) || (!isCasterCharacter && !getAllies))
            {
                foreach (CombatSlot slot in slots.CharacterSlots)
                {
                    if ((slot.HasUnit && slot.SlotID > casterSlotID) && (!ignoreCastSlot || casterSlotID != slot.SlotID))
                    {
                        if (greaterest == null)
                        {
                            greaterest = slot;
                        }
                        else if (slot.SlotID < greaterest.SlotID)
                        {
                            greaterest = slot;
                        }
                    }
                    else if (slot.HasUnit && (slot.SlotID < casterSlotID) && (!ignoreCastSlot || casterSlotID != slot.SlotID))
                    {
                        if (lesserest == null)
                        {
                            lesserest = slot;
                        }
                        else if (slot.SlotID > lesserest.SlotID)
                        {
                            lesserest = slot;
                        }
                    }
                }
            }
            else
            {
                foreach (CombatSlot slot in slots.EnemySlots)
                {
                    if ((slot.HasUnit && slot.SlotID > casterSlotID) && (!ignoreCastSlot || casterSlotID != slot.SlotID) && !IsLostSheep(slot))
                    {
                        if (greaterest == null)
                        {
                            greaterest = slot;
                        }
                        else if (slot.SlotID < greaterest.SlotID)
                        {
                            greaterest = slot;
                        }
                    }
                    else if (slot.HasUnit && (slot.SlotID < casterSlotID) && (!ignoreCastSlot || casterSlotID != slot.SlotID) && !IsLostSheep(slot))
                    {
                        if (lesserest == null)
                        {
                            lesserest = slot;
                        }
                        else if (slot.SlotID > lesserest.SlotID)
                        {
                            lesserest = slot;
                        }
                    }
                }
            }
            if (greaterest != null)
            {
                targets.Add(greaterest.TargetSlotInformation);
            }
            if (lesserest != null)
            {
                targets.Add(lesserest.TargetSlotInformation);
            }
            return targets.ToArray();
        }
    }
    public class UnitSideNotLostSheep : Targetting_ByUnit_Side
    {
        static EnemySO LostSheep;
        static bool LostSheepExist;
        static bool LostSheepChecked = false;
        public static bool IsLostSheep(TargetSlotInfo targ)
        {
            if (!LostSheepChecked) LostSheepExist = Check.EnemyExist("LostSheep_EN");
            if (!LostSheepExist) return false;
            if (LostSheep == null || LostSheep.Equals(null)) LostSheep = LoadedAssetsHandler.GetEnemy("LostSheep_EN");
            if (targ.HasUnit)
            {
                if (targ.Unit is EnemyCombat enemy)
                {
                    if (enemy.Enemy == LostSheep) return true;
                }
            }
            return false;
        }

        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            TargetSlotInfo[] source = base.GetTargets(slots, casterSlotID, isCasterCharacter);
            List<TargetSlotInfo> ret = new List<TargetSlotInfo>();
            foreach (TargetSlotInfo target in source)
            {
                if (!IsLostSheep(target)) ret.Add(target);
            }
            return ret.ToArray();
        }
    }
}
