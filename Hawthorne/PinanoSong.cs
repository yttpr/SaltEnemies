using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using static Hawthorne.Check;

namespace Hawthorne
{
    public static class PinanoSong
    {
        public static void Add(int sign)
        {
            if (!EnemyExist("Pinano_EN")) return;

            BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("PinanoWorld.png"));

            shoreEZ(sign);
            shoreMed(sign);
            shoreHard(sign);
        }
        public static void shoreEZ(int sign)
        {
            BrutalAPI.EnemyEncounter store = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "PinanEZ",
                area = 0,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = 5,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/PinanoSong",
                roarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone01_MunglingMudLung_Medium_EnemyBundle")._roarReference.roarEvent,
                difficulty = EncounterDifficulty.Easy
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("LostSheep_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Pinano_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=4},
                });
            }
            for (int i = 0; i < 5; i++)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Pinano_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomShoreMidget(false), enemySlot=1},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Pinano_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomSupport(0, false, Half), enemySlot=1},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Pinano_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomShoreMidget(false), enemySlot=1},
                new FieldEnemy(){enemyName = Half ? RandomColor(0) : ShoreSlop(), enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Pinano_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomSupport(0), enemySlot=1},
                new FieldEnemy(){enemyName = Half ? RandomColor(0) : ShoreSlop(), enemySlot=2},
                });
            }
            store.variations = fields.ToArray();
            store.CheckEncounters();
            store.AddEncounter();
        }
        public static void shoreMed(int sign)
        {
            BrutalAPI.EnemyEncounter store = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "PinanoMed",
                area = 0,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = UnityEngine.Random.Range(10, 19),
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/PinanoSong",
                roarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone01_MunglingMudLung_Medium_EnemyBundle")._roarReference.roarEvent,
                difficulty = EncounterDifficulty.Medium
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("Pinano_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Pinano_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Mung_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Mung_EN", enemySlot=4},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Pinano_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomShoreMidget(false), enemySlot=1},
                new FieldEnemy(){enemyName = RandomShoreMidget(false), enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(0, false, false), enemySlot=3},
                });
            for (int i = 0; i < 3; i++)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Pinano_EN", enemySlot=0},
                new FieldEnemy(){enemyName = ShoreSlop(true), enemySlot=1},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Pinano_EN", enemySlot=0},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=1},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Pinano_EN", enemySlot=0},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=2},
                });
                ResetColor();
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Pinano_EN", enemySlot=0},
                new FieldEnemy(){enemyName = SmartColor(0, true), enemySlot=1},
                new FieldEnemy(){enemyName = SmartColor(0), enemySlot=2},
                });
                ResetColor();
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Pinano_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomEncounters.Shore.RandomShoreWhore(), enemySlot=1},
                });
            }
            for (int i = 0; i < 2; i++)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Pinano_EN", enemySlot=0},
                new FieldEnemy(){enemyName = ShoreSlop(true), enemySlot=1},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=2},
                new FieldEnemy(){enemyName = Half ? RandomShoreMidget(false) : RandomSupport(0, false, false), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Pinano_EN", enemySlot=0},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=1},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=2},
                new FieldEnemy(){enemyName = Half ? RandomShoreMidget(false) : RandomSupport(0, false, false), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Pinano_EN", enemySlot=0},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=2},
                new FieldEnemy(){enemyName = Half ? RandomShoreMidget(false) : RandomSupport(0, false, false), enemySlot=3},
                });
                ResetColor();
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Pinano_EN", enemySlot=0},
                new FieldEnemy(){enemyName = SmartColor(0, true), enemySlot=1},
                new FieldEnemy(){enemyName = SmartColor(0), enemySlot=2},
                new FieldEnemy(){enemyName = Half ? RandomShoreMidget(false) : RandomSupport(0, false, false), enemySlot=3},
                });
                ResetColor();
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Pinano_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomEncounters.Shore.RandomShoreWhore(), enemySlot=1},
                new FieldEnemy(){enemyName = Half ? RandomShoreMidget(false) : RandomSupport(0, false, false), enemySlot=3},
                });
            }
            store.variations = fields.ToArray();
            store.CheckEncounters();
            store.AddEncounter();
        }
        public static void shoreHard(int sign)
        {
            BrutalAPI.EnemyEncounter store = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "PinorHard",
                area = 0,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = UnityEngine.Random.Range(10, 19),
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/PinanoSong",
                roarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone01_MunglingMudLung_Medium_EnemyBundle")._roarReference.roarEvent,
                difficulty = EncounterDifficulty.Hard
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("Pinano_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Pinano_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Pinano_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=4},
                });
            }
            for (int i = 0; i < 3; i++)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Pinano_EN", enemySlot=0},
                new FieldEnemy(){enemyName = ShoreSlop(true), enemySlot=1},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=2},
                new FieldEnemy(){enemyName = RandomEncounters.Shore.RandomShoreWhore(), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Pinano_EN", enemySlot=0},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=1},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=2},
                new FieldEnemy(){enemyName = RandomEncounters.Shore.RandomShoreWhore(), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Pinano_EN", enemySlot=0},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=2},
                new FieldEnemy(){enemyName = RandomEncounters.Shore.RandomShoreWhore(), enemySlot=3},
                });
                ResetColor();
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Pinano_EN", enemySlot=0},
                new FieldEnemy(){enemyName = SmartColor(0, true), enemySlot=1},
                new FieldEnemy(){enemyName = SmartColor(0), enemySlot=2},
                new FieldEnemy(){enemyName = RandomEncounters.Shore.RandomShoreWhore(), enemySlot=3},
                });
                ResetColor();
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Pinano_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomEncounters.Shore.RandomShoreWhore(), enemySlot=1},
                new FieldEnemy(){enemyName = RandomEncounters.Shore.RandomShoreWhore(), enemySlot=3},
                });
            }
            for (int i = 0; i < 3; i++)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Pinano_EN", enemySlot=0},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(0, false, false), enemySlot=2},
                new FieldEnemy(){enemyName = RandomEncounters.Shore.RandomShoreWhore(), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Pinano_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomSupport(0, false, false), enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=2},
                new FieldEnemy(){enemyName = RandomEncounters.Shore.RandomShoreWhore(), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Pinano_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomEncounters.Shore.RandomShoreWhore(), enemySlot=1},
                new FieldEnemy(){enemyName = RandomShoreMidget(false), enemySlot=2},
                new FieldEnemy(){enemyName = RandomEncounters.Shore.RandomShoreWhore(), enemySlot=3},
                });
            }
            store.variations = fields.ToArray();
            store.CheckEncounters();
            store.AddEncounter();
        }
    }
    public static class MinanaSong
    {
        public static void Add(int sign)
        {
            if (!EnemyExist("Minana_EN")) return;

            BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("MinanaWorld.png"));

            shoreEZ(sign);
        }
        public static void shoreEZ(int sign)
        {
            BrutalAPI.EnemyEncounter store = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "mino",
                area = 0,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = 3,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/PinanoSong",
                roarEvent = LoadedAssetsHandler.GetEnemyBundle("Zone01_Mung_Easy_EnemyBundle")._roarReference.roarEvent,
                difficulty = EncounterDifficulty.Easy
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("Minana_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Minana_EN", enemySlot=0},
                });
            }
            if (EnemyExist("Minana_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Minana_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Minana_EN", enemySlot=1},
                });
            }
            if (EnemyExist("Minana_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Minana_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomSupport(0, false, false), enemySlot=1},
                });
            }
            store.variations = fields.ToArray();
            store.CheckEncounters();
            store.AddEncounter();
        }
    }
    public static class SpitatoSong
    {
        public static void Add(int sign)
        {
            if (!EnemyExist("Spitato_EN")) return;

            BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("SpitatoWorld.png"));

            GardEZ(sign);
            GardMed(sign);
        }
        public static void GardEZ(int sign)
        {
            BrutalAPI.EnemyEncounter jarden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "SpitEZ",
                area = 2,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = UnityEngine.Random.Range(0, 11),
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/PinanoSong",
                roarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone01_MunglingMudLung_Medium_EnemyBundle")._roarReference.roarEvent,
                difficulty = EncounterDifficulty.Easy
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("Spitato_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Spitato_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=4},
                });
            }
            for (int i = 0; i < 5; i++)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Spitato_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomSupport(2, false, false), enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(2, false, false), enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(2, false, false), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Spitato_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomSupport(2, false, false), enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(2, false, false), enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Spitato_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomEncounters.Garden.RandomChunk(), enemySlot=1},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Spitato_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomColor(2), enemySlot=1},
                });
            }
            jarden.variations = fields.ToArray();
            jarden.CheckEncounters();
            jarden.AddEncounter();
        }
        public static void GardMed(int sign)
        {
            BrutalAPI.EnemyEncounter jarden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "SpitMed",
                area = 2,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = UnityEngine.Random.Range(10, 21),
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/PinanoSong",
                roarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone01_MunglingMudLung_Medium_EnemyBundle")._roarReference.roarEvent,
                difficulty = EncounterDifficulty.Medium
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("Spitato_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Spitato_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=4},
                });
            }
            for (int i = 0; i < 5; i++)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Spitato_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomEncounters.Garden.RandomChunk(), enemySlot=1},
                new FieldEnemy(){enemyName = RandomEncounters.Garden.RandomChunk(false, true), enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(2, false, false), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Spitato_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomEncounters.Garden.RandomChunk(), enemySlot=1},
                new FieldEnemy(){enemyName = RandomEncounters.Garden.RandomChunk(false, true), enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Spitato_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomEncounters.Garden.RandomChunk(), enemySlot=1},
                new FieldEnemy(){enemyName = RandomEncounters.Garden.RandomChunk(false, true), enemySlot=2},
                new FieldEnemy(){enemyName = RandomEncounters.Garden.RandomChunk(), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Spitato_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomEncounters.Garden.RandomWhore(), enemySlot=1},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Spitato_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomEncounters.Garden.RandomWhore(), enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(2, false, false), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Spitato_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomEncounters.Garden.RandomWhore(), enemySlot=1},
                new FieldEnemy(){enemyName = RandomEncounters.Garden.RandomChunk(), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Spitato_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomEncounters.Garden.RandomWhore(), enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(2), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Spitato_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomEncounters.Garden.RandomChunk(), enemySlot=1},
                new FieldEnemy(){enemyName = RandomEncounters.Garden.RandomChunk(), enemySlot=2},
                new FieldEnemy(){enemyName = RandomColor(2), enemySlot=3},
                });
                ResetColor();
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Spitato_EN", enemySlot=0},
                new FieldEnemy(){enemyName = SmartColor(2, true), enemySlot=1},
                new FieldEnemy(){enemyName = SmartColor(2), enemySlot=3},
                new FieldEnemy(){enemyName = RandomEncounters.Garden.RandomChunk(), enemySlot=2},
                });
                ResetColor();
                ResetColor();
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Spitato_EN", enemySlot=0},
                new FieldEnemy(){enemyName = SmartColor(2, true), enemySlot=1},
                new FieldEnemy(){enemyName = SmartColor(2), enemySlot=3},
                new FieldEnemy(){enemyName = RandomSupport(2, false, false), enemySlot=2},
                });
                ResetColor();
            }
            jarden.variations = fields.ToArray();
            jarden.CheckEncounters();
            jarden.AddEncounter();
        }
    }
}
