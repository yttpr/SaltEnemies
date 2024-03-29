using BrutalAPI;
using Hawthorne.NewFolder;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Hawthorne
{
    public static class Camera
    {
        public static void Add()
        {
            

            Enemy camera = new Enemy()
            {
                name = "Mechanical Lens",
                health = 1000,
                size = 1,
                entityID = (EntityIDs)544511,
                healthColor = Pigments.Gray,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/camera/Camera_Enemy.prefab").AddComponent<MultiSpriteEnemyLayout>()
            };
            camera.prefab._gibs = Hawthorne.SaltEnemies.assetBundle.LoadAsset<GameObject>("assets/camera/Camera_Gibs.prefab").GetComponent<ParticleSystem>();
            camera.prefab.SetDefaultParams();
            (camera.prefab as MultiSpriteEnemyLayout).OtherRenderers = new SpriteRenderer[]
            {
                camera.prefab._locator.transform.Find("Sprite").Find("Wings").GetComponent<SpriteRenderer>(),
            };
            camera.combatSprite = ResourceLoader.LoadSprite("DroneIconB", 32);
            camera.overworldAliveSprite = ResourceLoader.LoadSprite("DroneIcon", 32, new Vector2?(new Vector2(0.5f, 0.05f)));
            camera.overworldDeadSprite = ResourceLoader.LoadSprite("DroneDead", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            camera.hurtSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").damageSound;
            camera.deathSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").deathSound;
            camera.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            camera.passives = new BasePassiveAbilitySO[]
            {
                LoadedAssetsHandler.GetEnemy("Xiphactinus_EN").passiveAbilities[1]
            };


            

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
            Ability lens = new Ability();
            lens.name = "Lens Flash";
            lens.description = "Move towards the closest party member. Add one of the opposing party member's ability to this enemy's moveset and attempt to copy a random passive from them.";
            lens.rarity = 5;
            lens.effects = new Effect[3];
            lens.effects[0] = new Effect(ScriptableObject.CreateInstance<LensFlashEffect>(), 1, IntentType.Swap_Sides, Slots.Self);
            lens.effects[1] = new Effect(ScriptableObject.CreateInstance<ExitValueSetterEffect>(), 1, IntentType.Misc, Slots.Front, didThat);
            lens.effects[2] = new Effect(ScriptableObject.CreateInstance<StealRandomPassiveEffect>(), 1, null, Slots.Front, BasicEffects.DidThat(true, 2));
            //lens.effects[3] = new Effect(ScriptableObject.CreateInstance<PlayHealthColorSoundEffect>(), 1, null, Slots.Front);
            lens.visuals = null;
            lens.animationTarget = Slots.Self;

            Targetting_ByUnit_Side allAlly = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            allAlly.getAllUnitSlots = false;
            allAlly.getAllies = true;
            Ability picture = new Ability();
            picture.name = "Favorite Picture";
            picture.description = "Move towards the closest party member. \nCopy the max health and health color of the opposing party member. Attempt to copy their passives as well; does not copy more complex passives. \nIf successful, remove this ability from this enemy's ability pool.";
            picture.rarity = 999;
            picture.effects = new Effect[2];
            picture.effects[0] = new Effect(ScriptableObject.CreateInstance<FavoritePictureEffect>(), 1, IntentType.Swap_Sides, Slots.Self);
            picture.effects[1] = new Effect(ScriptableObject.CreateInstance<ExitValueSetterEffect>(), 1, IntentType.Misc, Slots.Front, didThat);
            picture.visuals = null;
            picture.animationTarget = Slots.Self;

            
            
            camera.passives[0] = UnityEngine.Object.Instantiate<BasePassiveAbilitySO>(camera.passives[0]);
            camera.passives[0]._passiveName = "Lens Flash";
            camera.passives[0]._enemyDescription = "Mechanical Lens will perforn an extra ability \"Lens Flash\" each turn.";
            ((ExtraAttackPassiveAbility)camera.passives[0])._extraAbility.ability = lens.EnemyAbility().ability;
            ((ExtraAttackPassiveAbility)camera.passives[0])._extraAbility.ability.name = "Lens Flash";

            camera.abilities = new Ability[] { picture };
            camera.AddEnemy();
        }
    }
}
