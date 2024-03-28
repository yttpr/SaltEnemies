using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.Rendering;

namespace Hawthorne
{
    public static class CustomVisuals
    {
        public static Dictionary<string, AttackVisualsSO> Visuals;
        public static void Prepare()
        {
            Visuals = new Dictionary<string, AttackVisualsSO>();
        }
        public static void LoadVisuals(string name, AssetBundle bundle, string path, string sound, bool full = false)
        {
            try
            {
                AttackVisualsSO ret = ScriptableObject.CreateInstance<AttackVisualsSO>();
                ret.name = name;
                ret.animation = bundle.LoadAsset<AnimationClip>(path);
                ret.audioReference = sound;
                ret.isAnimationFullScreen = full;
                if (Visuals == null) Prepare();
                if (!Visuals.ContainsKey(name)) Visuals.Add(name, ret);
                else Debug.LogWarning("animation for " + name + " already exists!");
            }
            catch
            {
                Debug.LogError("visuals failed to load: " + name);
                Debug.LogError("asset path: " + path);
                Debug.LogError("audio path: " + sound);
            }
        }
        public static AttackVisualsSO GetVisuals(string name)
        {
            if (Visuals == null) Prepare();
            if (Visuals.TryGetValue(name, out AttackVisualsSO ret)) return ret;
            else Debug.LogWarning("missing animation for " + name);
            return null;
        }
        public static void Duplicate(string newname, string oldname, string audio)
        {
            try
            {
                AttackVisualsSO old = GetVisuals(oldname);
                if (old == null) return;
                AttackVisualsSO ret = ScriptableObject.CreateInstance<AttackVisualsSO>();
                ret.name = newname;
                ret.animation = old.animation;
                ret.audioReference = audio;
                ret.isAnimationFullScreen = old.isAnimationFullScreen;
                if (Visuals == null) Prepare();
                if (!Visuals.ContainsKey(newname)) Visuals.Add(newname, ret);
                else Debug.LogWarning("animation for " + newname + " already exists!");
            }
            catch
            {
                Debug.LogError("visuals failed to load: " + newname);
                Debug.LogError("failed to copy off: " + oldname);
            }
        }

        public static void Setup()
        {
            LoadVisuals("Salt/Static", SaltEnemies.assetBundle, "assets/pretty/StaticAnim.anim", "event:/Hawthorne/Attack/Static", true);
            LoadVisuals("Salt/Rose", SaltEnemies.assetBundle, "assets/pretty/FlowerAttackAnim.anim", "event:/Hawthorne/Attack/FlowerBell");
            LoadVisuals("Salt/Sprout", SaltEnemies.assetBundle, "assets/pretty/FlowerBoneBreak.anim", "event:/Hawthorne/Attack/FlowerBone");
            LoadVisuals("Salt/Cannon", SaltEnemies.assetBundle, "assets/pretty/CannonAnim.anim", "event:/Hawthorne/Attack/Cannon");
            LoadVisuals("Salt/Gaze", SaltEnemies.assetBundle, "assets/pretty/EyeScare.anim", "event:/Hawthorne/Attack/EyeScare");
            LoadVisuals("Salt/Decapitate", SaltEnemies.assetBundle, "assets/pretty/CutAnim.anim", "event:/Hawthorne/Attack/Decapitate");
            LoadVisuals("Salt/Class", SaltEnemies.assetBundle, "assets/pretty/ClassAnim.anim", "event:/Hawthorne/Attack/Class");
            LoadVisuals("Salt/Needle", SaltEnemies.assetBundle, "assets/pretty/NeedleAnim.anim", "event:/Hawthorne/Attack/Needle");
            LoadVisuals("Salt/Claws", SaltEnemies.assetBundle, "assets/pretty/ClawingAnim.anim", "event:/Hawthorne/Attack/Clawing");
            LoadVisuals("Salt/Stars", SaltEnemies.assetBundle, "assets/pretty/StarryAnim.anim", "event:/Hawthorne/Attack/PointGet");
            Duplicate("Salt/Skyloft/Stars", "Salt/Stars", "event:/Hawthorne/Hurt/BirdSound");
            LoadVisuals("Salt/Hung", SaltEnemies.assetBundle, "assets/pretty/HUNG.anim", "event:/Hawthorne/Attack/Noosed");
            LoadVisuals("Salt/Crush", SaltEnemies.assetBundle, "assets/Attack2/PressAnim.anim", "event:/Hawthorne/Attack2/Press");
            LoadVisuals("Salt/Ads", SaltEnemies.assetBundle, "assets/Attack2/Ads.anim", "event:/Hawthorne/Attack2/Popup");
            LoadVisuals("Salt/Door", SaltEnemies.assetBundle, "assets/Attack2/DoorAnim.anim", "event:/Hawthorne/Attack2/DoorSlam");
            LoadVisuals("Salt/Keyhole", SaltEnemies.assetBundle, "assets/Attack2/KeyholeAnim.anim", "event:/Hawthorne/Attack2/Blink");
            LoadVisuals("Salt/Notif", SaltEnemies.assetBundle, "assets/Attack2/AlertAnim.anim", "event:/Hawthorne/Attack2/Quest");
            LoadVisuals("Salt/Wheel", SaltEnemies.assetBundle, "assets/Attack2/Sail.anim", "event:/Hawthorne/Attack2/Wheel");

        }
    }
}
