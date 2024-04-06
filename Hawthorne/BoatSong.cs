using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using static Hawthorne.Check;

namespace Hawthorne
{
    public static class BoatSong
    {
        public static void Add(int sign)
        {
            if (!EnemyExist("Arceles_EN")) return;

            BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("BoatWorld.png"));

            shoreEZ(sign);
            shoreMed(sign);
        }
        public static void shoreEZ(int sign)
        {
            BrutalAPI.EnemyEncounter jarden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "ARCELES",
                area = 0,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = UnityEngine.Random.Range(3, 7),
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/BoatSong",
                roarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone03_SkinningHomunculus_Medium_EnemyBundle")._roarReference.roarEvent,
                difficulty = EncounterDifficulty.Easy
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("Arceles_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Arceles_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Arceles_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Arceles_EN", enemySlot=2},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Arceles_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Mung_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Mung_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Arceles_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=1},
                new FieldEnemy(){enemyName = "Arceles_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Arceles_EN", enemySlot=0},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=1},
                new FieldEnemy(){enemyName = "Arceles_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Arceles_EN", enemySlot=0},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=1},
                new FieldEnemy(){enemyName = RandomShoreMidget(false), enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Arceles_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomSupport(0), enemySlot=1},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Arceles_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=2},
                });
            for (int i = 0; i < 5; i++)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Arceles_EN", enemySlot=0},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=2},
                });
            }
            jarden.variations = fields.ToArray();
            jarden.CheckEncounters();
            jarden.AddEncounter();
        }
        public static void shoreMed(int sign)
        {
            BrutalAPI.EnemyEncounter jarden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "noa",
                area = 0,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = UnityEngine.Random.Range(5, 11),
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/BoatSong",
                roarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone03_SkinningHomunculus_Medium_EnemyBundle")._roarReference.roarEvent,
                difficulty = EncounterDifficulty.Medium
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("Arceles_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Arceles_EN", enemySlot=0},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=1},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=2},
                });
            }
            if (EnemyExist("Arceles_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Arceles_EN", enemySlot=0},
                new FieldEnemy(){enemyName = ShoreSlop(true), enemySlot=1},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=2},
                });
            }
            for (int i = 0; i < 4; i++)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Arceles_EN", enemySlot=0},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=1},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Arceles_EN", enemySlot=0},
                new FieldEnemy(){enemyName = ShoreSlop(true), enemySlot=1},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Arceles_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=1},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Arceles_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Half ? RandomSupport(0) : RandomShoreMidget(false), enemySlot=1},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=2},
                });
            }
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "Arceles_EN", enemySlot=0},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=1},
                new FieldEnemy(){enemyName = ShoreSlop(Half), enemySlot=2},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=3},
            });
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "Arceles_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomSupport(0), enemySlot=1},
                new FieldEnemy(){enemyName = ShoreSlop(Half), enemySlot=2},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=3},
            });
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "Arceles_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomShoreMidget(false), enemySlot=1},
                new FieldEnemy(){enemyName = ShoreSlop(Half), enemySlot=2},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=3},
            });
            ResetColor();
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "Arceles_EN", enemySlot=0},
                new FieldEnemy(){enemyName = SmartColor(0, true), enemySlot=1},
                new FieldEnemy(){enemyName = SmartColor(0), enemySlot=2},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=3},
            });
            ResetColor();
            if (EnemyExist("Arceles_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Arceles_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomEncounters.Shore.RandomShoreWhore(), enemySlot=1},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=2},
                });
            }
            if (EnemyExist("Arceles_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Arceles_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomEncounters.Shore.RandomShoreWhore(), enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=2},
                });
            }
            if (EnemyExist("Arceles_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Arceles_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomEncounters.Shore.RandomShoreWhore(), enemySlot=1},
                new FieldEnemy(){enemyName = Half ? RandomShoreMidget(false) : RandomSupport(0), enemySlot=2},
                });
            }
            jarden.variations = fields.ToArray();
            jarden.CheckEncounters();
            jarden.AddEncounter();
        }
    }
    public static class StoplightSong
    {
        public static void Add(int sign)
        {
            if (!EnemyExist("Stoplight_EN")) return;

            BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("TrainWorld.png"));

            GardHard(sign);
        }
        public static void GardHard(int sign)
        {
            BrutalAPI.EnemyEncounter jarden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "FUCKINGTRAIN",
                area = 2,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = UnityEngine.Random.Range(15, 25),
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/StoplightSong",
                roarEvent = "event:/Hawthorne/Roar/ShuaRoar",
                difficulty = EncounterDifficulty.Hard
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("Stoplight_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Stoplight_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=3},
                });
            }
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "Stoplight_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
            });
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "Stoplight_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
            });
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "Stoplight_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
            });
            for (int i = 0; i < 6; i++)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Stoplight_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomEncounters.Garden.RandomChunk(), enemySlot=1},
                new FieldEnemy(){enemyName = RandomEncounters.Garden.RandomChunk(true), enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Stoplight_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomEncounters.Garden.RandomChunk(), enemySlot=1},
                new FieldEnemy(){enemyName = RandomEncounters.Garden.RandomChunk(true), enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(2, false, false), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Stoplight_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomEncounters.Garden.RandomChunk(), enemySlot=1},
                new FieldEnemy(){enemyName = RandomEncounters.Garden.RandomChunk(true), enemySlot=2},
                new FieldEnemy(){enemyName = RandomColor(2), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Stoplight_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomEncounters.Garden.RandomChunk(), enemySlot=1},
                new FieldEnemy(){enemyName = RandomEncounters.Garden.RandomWhore(), enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Stoplight_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomColor(2), enemySlot=1},
                new FieldEnemy(){enemyName = RandomEncounters.Garden.RandomWhore(), enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Stoplight_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomSupport(2, false, false), enemySlot=1},
                new FieldEnemy(){enemyName = RandomEncounters.Garden.RandomWhore(), enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Stoplight_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomEncounters.Garden.RandomWhore(), enemySlot=1},
                new FieldEnemy(){enemyName = RandomEncounters.Garden.RandomWhore(), enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Stoplight_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomEncounters.Garden.RandomChunk(), enemySlot=1},
                new FieldEnemy(){enemyName = RandomEncounters.Garden.RandomChunk(true), enemySlot=2},
                new FieldEnemy(){enemyName = RandomEncounters.Garden.RandomChunk(true), enemySlot=3},
                });
            }
            jarden.variations = fields.ToArray();
            jarden.CheckEncounters();
            jarden.AddEncounter();
        }
    }
}
