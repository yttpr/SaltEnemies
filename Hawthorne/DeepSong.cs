using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using static Hawthorne.Check;

namespace Hawthorne
{
    public static class DeepSong
    {
        public static void Add(int sign)
        {
            if (!EnemyExist("TheDeep_EN")) return;

            BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("DeepWorld.png"));

            GardHard(sign);
        }
        public static void GardHard(int sign)
        {
            BrutalAPI.EnemyEncounter jarden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "DeepEncounter",
                area = 2,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = UnityEngine.Random.Range(3, 10),
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/DeepSong",
                roarEvent = LoadedAssetsHandler.GetEnemyBundle("BOSS_Zone02_Ouroboros_EnemyBundle")._roarReference.roarEvent,
                difficulty = EncounterDifficulty.Hard
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("TheDeep_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheDeep_EN", enemySlot=1},
                });
            }
            jarden.variations = fields.ToArray();
            jarden.AddEncounter();
        }
    }
    public static class IllusionGroup
    {
        public static int rarity
        {
            get
            {
                int gap = UnityEngine.Random.Range(10, 21);
                if (SaltEnemies.trolling > 73) gap += UnityEngine.Random.Range(3, 9);
                if (SaltEnemies.silly < 43) gap -= UnityEngine.Random.Range(2, 6);
                if (SaltEnemies.rando == 58)
                {
                    float gop = gap;
                    gop *= 1.5f;
                    gap = (int)Math.Ceiling(gop);
                }
                return gap;
            }
        }

        public static void Add(int sign)
        {
            if (!MultiENExist("Illusion_EN", "FakeAngel_EN")) return;

            BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("IllusionPortal.png"));

            OrphMed(sign);
            OrphHard(sign);
            GardHard(sign);
        }
        public static void OrphMed(int sign)
        {
            BrutalAPI.EnemyEncounter orpheum = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "IllusionOrpheumMedium",
                area = 1,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = rarity / (UnityEngine.Random.Range(2, 4)),
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/GreyScaleTheme",
                roarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone03_ShiveringHomunculus_Medium_EnemyBundle")._roarReference.roarEvent,
                difficulty = EncounterDifficulty.Medium
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("Illusion_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=4},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                });
            if (EnemyExist("PerforatedSpoggle_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "PerforatedSpoggle_EN", enemySlot=3},
                });
            }
            if (EnemyExist("DesiccatingJumbleguts_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "DesiccatingJumbleguts_EN", enemySlot=3},
                });
            }
            if (Flowering)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Skyloft_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=3},
                });
            }
            if (EnemyExist("LivingSolvent_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Sigil_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Nameless_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Nameless_EN", enemySlot=3},
                });
            }
            if (Supporting)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                });
            }
            if (EnemyExist("Seraphim_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Seraphim_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Damocles_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Damocles_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Damocles_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Damocles_EN", enemySlot=3},
                });
            }
            if (EnemyExist("FumeFactory_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "FumeFactory_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                });
            }
            orpheum.variations = fields.ToArray();
            orpheum.AddEncounter();
        }
        public static void OrphHard(int sign)
        {
            BrutalAPI.EnemyEncounter orpheum = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "IllusionOrpheumHard",
                area = 1,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = rarity / 2,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/GreyScaleTheme",
                roarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone03_ShiveringHomunculus_Medium_EnemyBundle")._roarReference.roarEvent,
                difficulty = EncounterDifficulty.Hard
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            /*
            if (EnemyExist("Sigil_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=3},
                });
                orpheum.variations = fields.ToArray();
                orpheum.rarity = 9999;
                orpheum.AddEncounter();
                return;//DISABLE THIS
            }*/


            if (EnemyExist("Illusion_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                });
            if (EnemyExist("WindSong_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                });
            }
            if (EnemyExist("Grandfather_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                });
            }
            if (EnemyExist("LivingSolvent_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=2},
                });
            }
            if (EnemyExist("PerforatedSpoggle_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "PerforatedSpoggle_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                });
            }
            if (EnemyExist("DesiccatingJumbleguts_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "DesiccatingJumbleguts_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                });
            }
            if (Flowering)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                });
            }
            if (EnemyExist("Sigil_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=3},
                });
            }
            if (Supporting)
            {
                if (EnemyExist("WindSong_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=2},
                    });
                }
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                });
            }
            if (EnemyExist("Nameless_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Nameless_EN", enemySlot=4},
                });
            }
            if (EnemyExist("Skyloft_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                });
            }
            if (EnemyExist("Seraphim_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Seraphim_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                });
            }
            if (EnemyExist("TheCrow_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Hunter_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Warbird_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=3},
                });
            }
            if (EnemyExist("MechanicalLens_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                });
            }
            if (EnemyExist("Damocles_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Damocles_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                });
            }
            if (EnemyExist("Romantic_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                });
            }
            if (EnemyExist("FumeFactory_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = GreyScaleSupport(), enemySlot=1},
                new FieldEnemy(){enemyName = "FumeFactory_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                });
            }
            orpheum.variations = fields.ToArray();
            orpheum.AddEncounter();
        }
        public static void GardHard(int sign)
        {
            BrutalAPI.EnemyEncounter orpheum = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "IllusionGardenMed",
                area = 2,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = rarity,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/GreyScaleTheme",
                roarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone03_ShiveringHomunculus_Medium_EnemyBundle")._roarReference.roarEvent,
                difficulty = EncounterDifficulty.Medium
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("Illusion_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                });
            if (EnemyExist("WindSong_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Grandfather_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                });
            }
            if (EnemyExist("LivingSolvent_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=2},
                });
            }
            if (EnemyExist("MortalSpoggle_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MortalSpoggle_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MortalSpoggle_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                });
            }
            if (EnemyExist("RusticJumbleguts_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "RusticJumbleguts_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                });
            }
            if (Flowering)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = Flowers[UnityEngine.Random.Range(0, 5)], enemySlot=2},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = Flowers[UnityEngine.Random.Range(0, 5)], enemySlot=2},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=3},
                new FieldEnemy(){enemyName = Flowers[UnityEngine.Random.Range(0, 5)], enemySlot=4},
                });
            }
            if (EnemyExist("Sigil_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                }); fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                });
            }
            if (Supporting)
            {
                if (EnemyExist("WindSong_EN"))
                {
                    fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=4},
                });
                }
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                });
            }
            if (EnemyExist("Nameless_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Nameless_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Nameless_EN", enemySlot=4},
                });
            }
            if (EnemyExist("Skyloft_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                });
            }
            if (EnemyExist("Metatron_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Metatron_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                });
            }
            if (EnemyExist("TheCrow_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Hunter_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=3},
                });
            }
            if (EnemyExist("MechanicalLens_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                });
            }
            if (EnemyExist("StarGazer_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "StarGazer_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "StarGazer_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                });
            }
            if (EnemyExist("ClockTower_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Shua_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=2},
                });
            }
            if (EnemyExist("GlassFigurine_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "GlassFigurine_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                });
            }
            if (EnemyExist("Damocles_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Damocles_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Damocles_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                });
            }
            if (EnemyExist("MiniReaper_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Romantic_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                });
            }
            orpheum.variations = fields.ToArray();
            orpheum.CheckEncounters();
            orpheum.AddEncounter();
        }
    }
    public static class FlowerSong
    {
        public static int rarity
        {
            get
            {
                int gap = UnityEngine.Random.Range(8, 12);
                int mod = UnityEngine.Random.Range(0, 4);
                return gap + mod;
            }
        }

        public static void PurpleOrph(int sign)
        {
            if (!Flowering) return;
            BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("PurpleFlowerPortal.png"));
            BrutalAPI.EnemyEncounter orpheum = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "PurpleFlowerOrpheum",
                area = 1,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = rarity,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/FlowerSong",
                roarEvent = LoadedAssetsHandler.GetEnemyBundle("Zone02_MusicMan_Medium_EnemyBundle")._roarReference.roarEvent,
                difficulty = EncounterDifficulty.Medium
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            //Single
            if (EnemyExist("PurpleFlower_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=4},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
                });
            if (Gizos)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "NakedGizo_EN", enemySlot=2},
                });
            }
            if (Chap)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=3},
                });
            }
            if (Supporting)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                });
            }
            if (EnemyExist("WindSong_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Something_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Lyssa_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=3},
                });
            }
            if (EnemyExist("OsseousClad_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=3},
                });
            }
            if (EnemyExist("ReflectedHound_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ReflectedHound_EN", enemySlot=1},
                });
            }
            if (EnemyExist("Something_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Grandfather_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=3},
                });
            }
            if (EnemyExist("TheCrow_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Hunter_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
                });
            }
            if (EnemyExist("FumeFactory_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "FumeFactory_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                });
            }
            if (EnemyExist("Warbird_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                });
            }
            if (EnemyExist("LittleBeak_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(1), enemySlot=3},
                });
            }
            if (EnemyExist("Damocles_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Damocles_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=4},
                });
            }
            //Double
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=3},
                });
            if (Gizos)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=3},
                });
            }
            if (Chap)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=4},
                });
            }
            if (Supporting)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Lyssa_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=3},
                });
            }
            //Illusion
            if (MultiENExist("Illusion_EN", "FakeAngel_EN"))
            {
                //single
                if (EnemyExist("PurpleFlower_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                    });
                }
                fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                    });
                fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                    });
                fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                    });
                if (EnemyExist("WindSong_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                    });
                }
                if (EnemyExist("LivingSolvent_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=4},
                    });
                    if (EnemyExist("WindSong_EN") && SaltEnemies.trolling == 51)
                    {
                        fields.Add(new FieldEnemy[]
                        {
                        new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                        new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                        new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=2},
                        new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=4},
                        });
                    }
                }
                if (EnemyExist("TheCrow_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                    });
                }
                if (EnemyExist("Skyloft_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                    });
                }
                //double
                fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                    });
                fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                    });
            }
            orpheum.variations = fields.ToArray();
            orpheum.CheckEncounters();
            orpheum.AddEncounter();
        }
        public static void YellowOrph(int sign)
        {
            if (!Flowering) return;
            BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("YellowFlowerPortal.png"));
            BrutalAPI.EnemyEncounter orpheum = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "YellowFlowerOrpheum",
                area = 1,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = rarity,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/FlowerSong",
                roarEvent = LoadedAssetsHandler.GetEnemyBundle("Zone02_Spoggle_Resonant_Medium_EnemyBundle")._roarReference.roarEvent,
                difficulty = EncounterDifficulty.Medium
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            //Single
            if (EnemyExist("YellowFlower_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=4},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
                });
            if (Gizos)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "NakedGizo_EN", enemySlot=2},
                });
            }
            if (Chap)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=3},
                });
            }
            if (Supporting)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=3},
                });
            }
            if (EnemyExist("WindSong_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Something_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Lyssa_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=3},
                });
            }
            if (EnemyExist("OsseousClad_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=3},
                });
            }
            if (EnemyExist("ReflectedHound_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ReflectedHound_EN", enemySlot=1},
                });
            }
            if (EnemyExist("Grandfather_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=3},
                });
            }
            if (EnemyExist("TheCrow_EN"))
            {
                string b = "Scrungie_EN";
                if (Gizos) b = "Gizo_EN";
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=1},
                new FieldEnemy(){enemyName = b, enemySlot=2},
                });
            }
            if (EnemyExist("Hunter_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                });
            }
            if (EnemyExist("FumeFactory_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "FumeFactory_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                });
            }
            if (EnemyExist("Warbird_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                });
            }
            if (EnemyExist("LittleBeak_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(1), enemySlot=3},
                });
            }
            if (EnemyExist("Damocles_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Damocles_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=4},
                });
            }
            //Double
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=3},
                });
            if (Gizos)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=3},
                });
            }
            if (Chap)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=4},
                });
            }
            if (Supporting)
            {
                string g = "Scrungie_EN";
                if (Gizos) g = "Gizo_EN";
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = g, enemySlot=2},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Lyssa_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=3},
                });
            }
            //Illusion
            if (MultiENExist("Illusion_EN", "FakeAngel_EN"))
            {
                //single
                if (EnemyExist("YellowFlower_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                    });
                }
                fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                    });
                fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                    });
                fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                    });
                if (EnemyExist("WindSong_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                    });
                }
                if (EnemyExist("LivingSolvent_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=4},
                    });
                    if (EnemyExist("WindSong_EN") && SaltEnemies.trolling == 51)
                    {
                        fields.Add(new FieldEnemy[]
                        {
                        new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                        new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                        new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=2},
                        new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=4},
                        });
                    }
                }
                if (EnemyExist("TheCrow_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                    });
                }
                if (EnemyExist("Skyloft_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                    });
                }
                //double
                fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                    });
                fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                    });
            }
            orpheum.variations = fields.ToArray();
            orpheum.CheckEncounters();
            orpheum.AddEncounter();
        }
        public static void PurpleGard(int sign)
        {
            if (!Flowering) return;
            //BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("PurpleFlowerWorld.png"));
            BrutalAPI.EnemyEncounter orpheum = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "PurpleFlowerGarden",
                area = 2,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = rarity /2,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/FlowerSong",
                roarEvent = LoadedAssetsHandler.GetEnemyBundle("Zone02_MusicMan_Medium_EnemyBundle")._roarReference.roarEvent,
                difficulty = EncounterDifficulty.Medium
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            //Single
            if (EnemyExist("PurpleFlower_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=4},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=2},
                });
            if (Supporting)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                });
            }
            if (EnemyExist("EyePalm_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                });
                if (EnemyExist("Unterling_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Unterling_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=3},
                    });
                }
            }
            if (EnemyExist("Merced_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Shua_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=3},
                });
            }
            if (EnemyExist("WindSong_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Grandfather_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=3},
                });
            }
            if (EnemyExist("TheCrow_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Hunter_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=3},
                });
            }
            if (EnemyExist("TitteringPeon_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                });
            }
            if (EnemyExist("SterileBud_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=2},
                });
                if (EnemyExist("TripodFish_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=2},
                    });
                }
            }
            if (EnemyExist("ImpenetrableAngler_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ImpenetrableAngler_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=4},
                });
            }
            if (EnemyExist("ScreamingHomunculus_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ScreamingHomunculus_EN", enemySlot=3},
                });
            }
            if (EnemyExist("LittleAngel_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=2},
                });
            }
            if (EnemyExist("MiniReaper_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                });
            }
            if (EnemyExist("EggKeeper_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=3},
                });
            }
            if (EnemyExist("HowlingAvian_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "HowlingAvian_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "HowlingAvian_EN", enemySlot=2},
                });
            }
            if (EnemyExist("InfernalDrummer_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InfernalDrummer_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=2},
                });
            }
            //Double
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=3},
                });
            //other
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=3},
                });
            if (EnemyExist("SterileBud_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=3},
                });
            }
            if (EnemyExist("MiniReaper_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=3},
                });
            }
            //Illusion
            if (MultiENExist("Illusion_EN", "FakeAngel_EN"))
            {
                //single
                if (EnemyExist("PurpleFlower_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                    });
                }
                fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                    });
                fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                    });
                fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                    });
                if (EnemyExist("WindSong_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                    });
                }
                if (EnemyExist("LivingSolvent_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=4},
                    });
                    if (EnemyExist("WindSong_EN") && SaltEnemies.trolling == 51)
                    {
                        fields.Add(new FieldEnemy[]
                        {
                        new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                        new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                        new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=2},
                        new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=4},
                        });
                    }
                }
                if (EnemyExist("TheCrow_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                    });
                }
                if (EnemyExist("Skyloft_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                    });
                }
                if (EnemyExist("Romantic_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                    });
                }
                //double
                fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                    });
                fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                    });
                //other
                fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=4},
                    });
            }
            orpheum.variations = fields.ToArray();
            orpheum.CheckEncounters();
            orpheum.AddEncounter();
        }
        public static void YellowGard(int sign)
        {
            if (!Flowering) return;
            //BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("PurpleFlowerWorld.png"));
            BrutalAPI.EnemyEncounter orpheum = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "YellowFlowerGarden",
                area = 2,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = rarity /2,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/FlowerSong",
                roarEvent = LoadedAssetsHandler.GetEnemyBundle("Zone02_Spoggle_Resonant_Medium_EnemyBundle")._roarReference.roarEvent,
                difficulty = EncounterDifficulty.Medium
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            //Single
            if (EnemyExist("YellowFlower_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=4},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=2},
                });
            if (Supporting)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Butterfly_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                });
                if (EnemyExist("Unterling_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Unterling_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=3},
                    });
                }
            }
            if (EnemyExist("Skyloft_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Nameless_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Nameless_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=3},
                });
            }
            if (EnemyExist("WindSong_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Grandfather_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=3},
                });
            }
            if (EnemyExist("TripodFish_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Metatron_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Metatron_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=4},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Metatron_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=4},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=3},
                });
            }
            if (EnemyExist("SterileBud_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=2},
                });
                if (EnemyExist("MiniReaper_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=2},
                    });
                }
            }
            if (EnemyExist("Psychopomp_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Psychopomp_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=4},
                });
            }
            if (MultiENExist("ScreamingHomunculus_EN", "TitteringPeon_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ScreamingHomunculus_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Sigil_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=2},
                });
            }
            if (EnemyExist("LivingSolvent_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                });
            }
            if (EnemyExist("EggKeeper_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Harbinger_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Harbinger_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Harbinger_EN", enemySlot=2},
                });
            }
            if (EnemyExist("InfernalDrummer_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InfernalDrummer_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=2},
                });
            }
            //Double
            if (EnemyExist("SterileBud_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=3},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=3},
                });
            //other
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=3},
                });
            if (EnemyExist("SterileBud_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=3},
                });
            }
            if (EnemyExist("MiniReaper_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Satyr_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Satyr_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Satyr_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=3},
                });
            }
            //Illusion
            if (MultiENExist("Illusion_EN", "FakeAngel_EN"))
            {
                //single
                if (EnemyExist("YellowFlower_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                    });
                }
                fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                    });
                fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                    });
                fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                    });
                if (EnemyExist("WindSong_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                    });
                }
                if (EnemyExist("LivingSolvent_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=4},
                    });
                    if (EnemyExist("WindSong_EN") && SaltEnemies.trolling == 22)
                    {
                        fields.Add(new FieldEnemy[]
                        {
                        new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                        new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                        new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=2},
                        new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=4},
                        });
                    }
                }
                if (EnemyExist("ClockTower_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                    });
                }
                if (EnemyExist("Skyloft_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                    });
                }
                //double
                fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                    });
                fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                    });
                //other
                fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=4},
                    });
            }
            orpheum.variations = fields.ToArray();
            orpheum.CheckEncounters();
            orpheum.AddEncounter();
        }
        public static void YellowEasy(int sign)
        {
            if (!Flowering) return;
            //BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("PurpleFlowerWorld.png"));
            BrutalAPI.EnemyEncounter orpheum = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "YellowFlowerGardenEasy",
                area = 2,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = 2,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/FlowerSong",
                roarEvent = LoadedAssetsHandler.GetEnemyBundle("Zone02_Spoggle_Resonant_Medium_EnemyBundle")._roarReference.roarEvent,
                difficulty = EncounterDifficulty.Easy
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            //Single
            if (EnemyExist("YellowFlower_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                });
            }
            if (Flowering)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "GreyFlower_EN", enemySlot=4},
                });
            }
            orpheum.variations = fields.ToArray();
            orpheum.CheckEncounters();
            if (SaltEnemies.trolling < 55) return;
            if (SaltEnemies.silly < 13) return;
            orpheum.AddEncounter();
        }
        public static void BlueGard(int sign)
        {
            if (!Flowering) return;
            BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("BlueFlowerPortal.png"));
            BrutalAPI.EnemyEncounter orpheum = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "BLueFlowerGarden",
                area = 2,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = rarity,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/FlowerSong",
                roarEvent = LoadedAssetsHandler.GetEnemyBundle("Zone01_Mung_Easy_EnemyBundle")._roarReference.roarEvent,
                difficulty = EncounterDifficulty.Medium
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            //Single
            if (EnemyExist("BlueFlower_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=4},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=2},
                });
            if (Supporting)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                });
            }
            if (EnemyExist("EyePalm_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                });
                if (EnemyExist("Unterling_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Unterling_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=3},
                    });
                }
            }
            if (EnemyExist("Butterfly_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Shua_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                });
            }
            if (EnemyExist("WindSong_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Grandfather_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=3},
                });
            }
            if (EnemyExist("TheCrow_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Hunter_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=3},
                });
            }
            if (EnemyExist("TripodFish_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=2},
                });
            }
            if (EnemyExist("TitteringPeon_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                });
            }
            if (EnemyExist("SterileBud_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=2},
                });
                if (EnemyExist("EggKeeper_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=2},
                    });
                }
            }
            if (EnemyExist("EggKeeper_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=4},
                });
                if (EnemyExist("SterileBud_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=4},
                    });
                }
            }
            if (EnemyExist("ScreamingHomunculus_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ScreamingHomunculus_EN", enemySlot=3},
                });
            }
            if (EnemyExist("LittleAngel_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Metatron_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Metatron_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=3},
                });
            }
            if (EnemyExist("MiniReaper_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                });
            }
            //Double
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=3},
                });
            if (EnemyExist("MiniReaper_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=4},
                });
            }
            if (EnemyExist("EggKeeper_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=3},
                });
            }
            if (EnemyExist("EyePalm_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=4},
                });
            }
            if (EnemyExist("Satyr_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Satyr_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Satyr_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Damocles_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Damocles_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=4},
                });
            }
            if (EnemyExist("Romantic_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=4},
                });
            }
            //other
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=4},
                });
            if (EnemyExist("SterileBud_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=3},
                });
            }
            if (EnemyExist("MiniReaper_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=3},
                });
            }
            if (EnemyExist("EggKeeper_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=3},
                });
            }
            //Illusion
            if (MultiENExist("Illusion_EN", "FakeAngel_EN"))
            {
                //single
                if (EnemyExist("BlueFlower_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                    });
                }
                fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                    });
                fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                    });
                fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                    });
                if (EnemyExist("WindSong_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                    }); 
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                    });
                    if (EnemyExist("Nameless_EN"))
                    {
                        fields.Add(new FieldEnemy[]
                        {
                        new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                        new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                        new FieldEnemy(){enemyName = "Nameless_EN", enemySlot=3},
                        new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=2},
                        new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                        });
                    }
                }
                if (EnemyExist("LivingSolvent_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=4},
                    });
                    if (EnemyExist("WindSong_EN") && SaltEnemies.trolling == 22)
                    {
                        fields.Add(new FieldEnemy[]
                        {
                        new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                        new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                        new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=2},
                        new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=4},
                        });
                    }
                }
                if (EnemyExist("TheCrow_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                    });
                }
                if (EnemyExist("Skyloft_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                    });
                }
                if (EnemyExist("Sigil_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                    });
                }
                //other
                fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=4},
                    });
                fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                    });
                fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=4},
                    });
            }
            orpheum.variations = fields.ToArray();
            orpheum.CheckEncounters();
            orpheum.AddEncounter();
        }
        public static void RedGard(int sign)
        {
            if (!Flowering) return;
            BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("RedFlowerPortal.png"));
            BrutalAPI.EnemyEncounter orpheum = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "RedFlowerGarden",
                area = 2,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = rarity,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/FlowerSong",
                roarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone03_GigglingMinister_Medium_EnemyBundle")._roarReference.roarEvent,
                difficulty = EncounterDifficulty.Medium
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            //Single
            if (EnemyExist("RedFlower_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=4},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=2},
                });
            if (Supporting)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                });
            }
            if (EnemyExist("EyePalm_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                });
                if (EnemyExist("Unterling_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Unterling_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=3},
                    });
                }
            }
            if (EnemyExist("Butterfly_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Shua_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=2},
                });
            }
            if (EnemyExist("WindSong_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Grandfather_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=3},
                });
            }
            if (EnemyExist("TheCrow_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Hunter_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                });
            }
            if (EnemyExist("TripodFish_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=2},
                });
            }
            if (EnemyExist("TitteringPeon_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=2},
                });
            }
            if (EnemyExist("SterileBud_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=2},
                });
                if (EnemyExist("EggKeeper_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=2},
                    });
                }
            }
            if (EnemyExist("EggKeeper_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=4},
                });
                if (EnemyExist("SterileBud_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=4},
                    });
                }
            }
            if (EnemyExist("ScreamingHomunculus_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ScreamingHomunculus_EN", enemySlot=3},
                });
            }
            if (EnemyExist("LittleAngel_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Metatron_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Metatron_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                });
            }
            if (EnemyExist("MiniReaper_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=2},
                });
            }
            //Double
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=3},
                });
            if (EnemyExist("MiniReaper_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=4},
                });
            }
            if (EnemyExist("EggKeeper_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=3},
                });
            }
            if (EnemyExist("EyePalm_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=4},
                });
            }
            if (EnemyExist("Damocles_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Damocles_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=4},
                });
            }
            if (EnemyExist("Romantic_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=3},
                });
            }
            //other
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=4},
                });
            if (EnemyExist("SterileBud_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=3},
                });
            }
            if (EnemyExist("MiniReaper_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=3},
                });
            }
            if (EnemyExist("EggKeeper_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=3},
                });
            }
            //Illusion
            if (MultiENExist("Illusion_EN", "FakeAngel_EN"))
            {
                //single
                if (EnemyExist("RedFlower_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=4},
                    });
                }
                fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=4},
                    });
                fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                    });
                fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=4},
                    });
                if (EnemyExist("WindSong_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                    });
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                    });
                    if (EnemyExist("Nameless_EN"))
                    {
                        fields.Add(new FieldEnemy[]
                        {
                        new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=0},
                        new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                        new FieldEnemy(){enemyName = "Nameless_EN", enemySlot=3},
                        new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=2},
                        new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                        });
                    }
                }
                if (EnemyExist("LivingSolvent_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=4},
                    });
                    if (EnemyExist("WindSong_EN") && SaltEnemies.trolling == 74)
                    {
                        fields.Add(new FieldEnemy[]
                        {
                        new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=0},
                        new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                        new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=2},
                        new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=4},
                        });
                    }
                }
                if (EnemyExist("TheCrow_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=4},
                    });
                }
                if (EnemyExist("Skyloft_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=4},
                    });
                }
                if (EnemyExist("Sigil_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                    });
                }
                if (EnemyExist("Romantic_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                    });
                }
                //other
                fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=4},
                    });
                fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=4},
                    });
                fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=4},
                    });
            }
            orpheum.variations = fields.ToArray();
            orpheum.CheckEncounters();
            orpheum.AddEncounter();
        }
        public static void GreyGard(int sign)
        {
            if (!Flowering) return;
            BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("GreyFlowerPortal.png"));
            BrutalAPI.EnemyEncounter orpheum = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "GreyFlowerGarden",
                area = 2,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = rarity / 2,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/FlowerSong",
                roarEvent = LoadedAssetsHandler.GetEnemyBundle("Zone02_JumbleGuts_Hollowing_Medium_EnemyBundle")._roarReference.roarEvent,
                difficulty = EncounterDifficulty.Hard
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            //Single
            if (SaltEnemies.rando > 50)
            {
                if (EnemyExist("GreyFlower_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                new FieldEnemy(){enemyName = "GreyFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=4},
                    });
                }
                if (EnemyExist("ScreamingHomunculus_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                new FieldEnemy(){enemyName = "GreyFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ScreamingHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=4},
                    });
                }
                if (EnemyExist("TitteringPeon_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                new FieldEnemy(){enemyName = "GreyFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=4},
                    });
                }
                if (EnemyExist("GlassFigurine_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                new FieldEnemy(){enemyName = "GreyFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "GlassFigurine_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=2},
                    });
                }
                if (EnemyExist("Scuttlerunt_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                new FieldEnemy(){enemyName = "GreyFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Scuttlerunt_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Scuttlerunt_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Scuttlerunt_EN", enemySlot=3},
                    });
                }
                if (MultiENExist("WindSong_EN", "LivingSolvent_EN", "Grandfather_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                new FieldEnemy(){enemyName = "GreyFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=3},
                    });
                }
                if (MultiENExist("Shua_EN", "Merced_EN", "TheCrow_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                new FieldEnemy(){enemyName = "GreyFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("StarGazer_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "GreyFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "StarGazer_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "StarGazer_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "StarGazer_EN", enemySlot=3},
                    });
                }
            }
            else
            {
                if (MultiENExist("StalwartTortoise_EN", "ClockTower_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                new FieldEnemy(){enemyName = "GreyFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=3},
                    });
                }
                if (MultiENExist("MortalSpoggle_EN", "RusticJumbleguts_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                new FieldEnemy(){enemyName = "GreyFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MortalSpoggle_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "RusticJumbleguts_EN", enemySlot=2},
                    });
                }
                if (MultiENExist("FakeAngel_EN", "Illusion_EN"))
                {
                    if (EnemyExist("GreyFlower_EN"))
                    {
                        fields.Add(new FieldEnemy[]
                        {
                    new FieldEnemy(){enemyName = "GreyFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                        });
                    }
                    fields.Add(new FieldEnemy[]
                        {
                    new FieldEnemy(){enemyName = "GreyFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                        });
                    if (EnemyExist("WindSong_EN"))
                    {
                        fields.Add(new FieldEnemy[]
                        {
                    new FieldEnemy(){enemyName = "GreyFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                        });
                    }
                    if (EnemyExist("LivingSolvent_EN"))
                    {
                        fields.Add(new FieldEnemy[]
                        {
                    new FieldEnemy(){enemyName = "GreyFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                        });
                    }
                    if (EnemyExist("RealisticTank_EN"))
                    {
                        fields.Add(new FieldEnemy[]
                        {
                    new FieldEnemy(){enemyName = "GreyFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=3},
                        });
                    }
                }
                if (MultiENExist("FakeAngel_EN", "RealisticTank_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                new FieldEnemy(){enemyName = "GreyFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=2},
                    });
                }
                if (MultiENExist("Hunter_EN", "Firebird_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                new FieldEnemy(){enemyName = "GreyFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=2},
                    });
                }
                if (EnemyExist("Damocles_EN") && GreyScale)
                {
                    fields.Add(new FieldEnemy[]
                    {
                new FieldEnemy(){enemyName = "GreyFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Damocles_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                    });
                }
            }
            orpheum.variations = fields.ToArray();
            if (SaltEnemies.trolling < 15) return;
            if (SaltEnemies.silly > 88) return;
            orpheum.CheckEncounters();
            orpheum.AddEncounter();
        }
    }
}
