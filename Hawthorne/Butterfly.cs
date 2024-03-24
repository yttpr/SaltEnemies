using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Hawthorne
{
    public static class Butterfly
    {
        public static string ID = "Butterfly";
        public static void Add(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "Spectre Witch's Familiar",
                health = 20,
                size = 1,
                entityID = (EntityIDs)entity,
                healthColor = Pigments.Red,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/group4/"+ID+"/"+ID+ "_Enemy.prefab").AddComponent<MultiSpriteEnemyLayout>()
            };
            enemy.prefab._gibs = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/group4/"+ID+"/"+ID+"_Gibs.prefab").GetComponent<ParticleSystem>();
            enemy.prefab.SetDefaultParams();
            (enemy.prefab as MultiSpriteEnemyLayout).OtherRenderers = new SpriteRenderer[]
            {
                enemy.prefab._locator.transform.Find("Sprite").Find("Sprite").GetComponent<SpriteRenderer>(),
                enemy.prefab._locator.transform.Find("Sprite").Find("Sprite (1)").GetComponent<SpriteRenderer>(),
            };
            enemy.enemyID = "Butterfly_EN";
            enemy.combatSprite = ResourceLoader.LoadSprite(ID+"Icon.png", 32);
            enemy.overworldAliveSprite = ResourceLoader.LoadSprite(ID+"World.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.overworldDeadSprite = ResourceLoader.LoadSprite(ID+"Dead.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.hurtSound = "event:/Hawthorne/Boowomp";
            enemy.deathSound = "";
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            enemy.passives = new BasePassiveAbilitySO[]
            {
                Passi.Ethereal, //Passi.Tempered
            };
            enemy.abilities = new Ability[] { Abili.Dissolver, Abili.FadeOut, Abili.PhaseIn };
            enemy.exitEffects = new Effect[]
            {
                new Effect(ScriptableObject.CreateInstance<SpawnCasterGibsEffect>(), 1, null, Slots.Self, ScriptableObject.CreateInstance<IsDieCondition>())
            };
            enemy.AddEnemy();
        }
    }
    public static class Windle
    {
        public static string ID = "Windle";
        public static void Add1(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "Windle",
                health = 12,
                size = 1,
                entityID = (EntityIDs)entity,
                healthColor = Pigments.Purple,
                priority = 0,
                prefab = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/group4/" + ID + "/" + ID + "_Enemy.prefab").AddComponent<MultiSpriteEnemyLayout>()
            };
            enemy.prefab._gibs = Hawthorne.SaltEnemies.Group4.LoadAsset<GameObject>("assets/group4/" + ID + "/" + ID + "_Gibs.prefab").GetComponent<ParticleSystem>();
            enemy.prefab.SetDefaultParams();
            (enemy.prefab as MultiSpriteEnemyLayout).OtherRenderers = new SpriteRenderer[]
            {
                enemy.prefab._locator.transform.Find("Sprite").Find("Sprite").GetComponent<SpriteRenderer>(),
            };
            enemy.enemyID = "Windle1_EN";
            enemy.combatSprite = ResourceLoader.LoadSprite(ID + "Icon.png", 32);
            enemy.overworldAliveSprite = ResourceLoader.LoadSprite(ID + "World.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.overworldDeadSprite = ResourceLoader.LoadSprite(ID + "Dead.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.hurtSound = LoadedAssetsHandler.GetCharcater("Doll_CH").damageSound;
            enemy.deathSound = LoadedAssetsHandler.GetCharcater("Doll_CH").deathSound;
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            enemy.passives = new BasePassiveAbilitySO[]
            {
                
            };
            enemy.abilities = new Ability[] { Abili.Windle1 };
            enemy.unitType = UnitType.Fish;
            enemy.AddEnemy();
        }
        public static void Add2(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "Windle",
                health = 15,
                size = 1,
                entityID = (EntityIDs)entity,
                healthColor = Pigments.Purple,
                priority = 0,
                prefab = LoadedAssetsHandler.GetEnemy("Windle1_EN").enemyTemplate
            };
            enemy.enemyID = "Windle2_EN";
            enemy.combatSprite = ResourceLoader.LoadSprite(ID + "Icon.png", 32);
            enemy.overworldAliveSprite = ResourceLoader.LoadSprite(ID + "World.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.overworldDeadSprite = ResourceLoader.LoadSprite(ID + "Dead.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.hurtSound = LoadedAssetsHandler.GetCharcater("Doll_CH").damageSound;
            enemy.deathSound = LoadedAssetsHandler.GetCharcater("Doll_CH").deathSound;
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            enemy.passives = new BasePassiveAbilitySO[]
            {

            };
            enemy.abilities = new Ability[] { Abili.Windle2 };
            enemy.unitType = UnitType.Fish;
            enemy.AddEnemy();
        }
        public static void Add3(int entity)
        {
            Enemy enemy = new Enemy()
            {
                name = "Windle",
                health = 18,
                size = 1,
                entityID = (EntityIDs)entity,
                healthColor = Pigments.Purple,
                priority = 0,
                prefab = LoadedAssetsHandler.GetEnemy("Windle1_EN").enemyTemplate
            };
            enemy.enemyID = "Windle3_EN";
            enemy.combatSprite = ResourceLoader.LoadSprite(ID + "Icon.png", 32);
            enemy.overworldAliveSprite = ResourceLoader.LoadSprite(ID + "World.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.overworldDeadSprite = ResourceLoader.LoadSprite(ID + "Dead.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
            enemy.hurtSound = LoadedAssetsHandler.GetCharcater("Doll_CH").damageSound;
            enemy.deathSound = LoadedAssetsHandler.GetCharcater("Doll_CH").deathSound;
            enemy.abilitySelector = ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
            enemy.passives = new BasePassiveAbilitySO[]
            {

            };
            enemy.abilities = new Ability[] { Abili.Windle3 };
            enemy.unitType = UnitType.Fish;
            enemy.AddEnemy();
        }
        public static void AddFool()
        {
            Character windle = new Character();
            windle.name = "Windle";
            windle.entityID = (EntityIDs)6879453;
            windle.healthColor = Pigments.Purple;
            windle.usesAllAbilities = true;
            windle.usesBaseAbility = false;
            windle.passives = new BasePassiveAbilitySO[] { Passi.Automated, Passives.Withering };
            windle.levels = new CharacterRankedData[3];
            windle.frontSprite = ResourceLoader.LoadSprite("WindleFront.png");
            windle.backSprite = ResourceLoader.LoadSprite("WindleBack.png");
            windle.overworldSprite = ResourceLoader.LoadSprite("WindleWorld.png", 32, new Vector2(0.5f, 0.0f));
            windle.lockedSprite = ResourceLoader.LoadSprite("WindleWorld.png");
            windle.unlockedSprite = windle.lockedSprite;
            windle.walksInOverworld = true;
            windle.menuChar = false;
            windle.appearsInShops = false;
            windle.hurtSound = LoadedAssetsHandler.GetCharcater("Doll_CH").damageSound;
            windle.deathSound = LoadedAssetsHandler.GetCharcater("Doll_CH").deathSound;
            windle.dialogueSound = LoadedAssetsHandler.GetCharcater("Doll_CH").dxSound;
            Ability j0 = new Ability();
            j0.name = "Crappy Shod";
            ManaColorSO rp = Pigments.Gray;
            j0.cost = new ManaColorSO[] { rp, rp, rp, rp, rp, rp };
            j0.description = "Deal 2 damage to this party member.\nDeal 2 damage to the Opposing enemy.\nDeal 2 damage to the Left and Right party members.";
            j0.rarity = 5;
            j0.visuals = LoadedAssetsHandler.GetEnemyAbility("Wriggle_A").visuals;
            j0.animationTarget = MultiTargetting.Create(Slots.Front, Slots.SlotTarget(new int[] { -1, 0, 1 }, true));
            j0.effects = new Effect[3];
            j0.effects[0] = new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 2, IntentType.Damage_1_2, Slots.Self);
            j0.effects[1] = new Effect(j0.effects[0]._effect, 2, IntentType.Damage_1_2, Slots.Front);
            j0.effects[2] = new Effect(j0.effects[0]._effect, 2, IntentType.Damage_1_2, Slots.Sides);
            Ability j1 = j0.Duplicate();
            j1.name = "Scruffled Shod";
            j1.description = "Deal 2 damage to this party member.\nDeal 4 damage to the Opposing enemy.\nDeal 3 damage to the Left and Right party members.";
            j1.effects[1]._entryVariable = 4;
            j1.effects[1]._intent = IntentType.Damage_3_6;
            j1.effects[2]._entryVariable = 3;
            j1.effects[2]._intent = IntentType.Damage_3_6;
            Ability j2 = j1.Duplicate();
            j2.name = "Meaningless Shod";
            j2.description = "Deal 2 damage to this party member.\nDeal 6 damage to the Opposing enemy.\nDeal 4 damage to the Left and Right party members.";
            j2.effects[1]._entryVariable = 6;
            j2.effects[2]._entryVariable = 4;
            windle.AddLevel(12, new Ability[] { j0 }, 0);
            windle.AddLevel(15, new Ability[] { j1 }, 1);
            windle.AddLevel(18, new Ability[] { j2 }, 2);
            windle.AddCharacter();
            LoadedAssetsHandler.GetCharcater("Windle_CH").unitType = UnitType.Fish;
        }
        public static void Add(int entity)
        {
            Add1(entity);
            Add2(entity + 1000);
            Add3(entity + 2000);
            AddFool();
        }
    }
}
