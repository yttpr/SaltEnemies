using BrutalAPI;
using ES3Types;
using System;
using System.Collections.Generic;
using System.Text;
using static Hawthorne.Check;
using static Hawthorne.RandomEncounters;

namespace Hawthorne
{
    public static class YellowAngelTheme
    {
        public static void Add(int sign)
        {
            if (!EnemyExist("YellowAngel_EN")) return;

            BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("HarpoonWorld.png"));

            OrphMed(sign);
            OrphHard(sign);
        }
        public static void OrphMed(int sign)
        {
            BrutalAPI.EnemyEncounter jarden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "WhoKilledThePorkChops",
                area = 1,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = UnityEngine.Random.Range(3, 15),
                signType = (SignType)sign,
                musicEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Scrungie_Medium_EnemyBundle")._musicEventReference,
                roarEvent = "event:/Hawthorne/Noisy/YA_Roar",
                difficulty = EncounterDifficulty.Medium
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("YellowAngel_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowAngel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                });
            }
            for (int i = 0; i < 3; i++)
            {
                string e = RandomOrph;
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowAngel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = e, enemySlot=2},
                new FieldEnemy(){enemyName = Either(e, RandomOrph), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowAngel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowAngel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=3},
                });
                string b = RandomOrph;
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowAngel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = b, enemySlot=2},
                new FieldEnemy(){enemyName = Either(b, RandomOrph), enemySlot=3},
                new FieldEnemy(){enemyName = RandomSupport(1), enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowAngel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                new FieldEnemy(){enemyName = OrphWhore(), enemySlot=3},
                });
            }
            jarden.variations = fields.ToArray();
            jarden.AddEncounter();
        }
        public static void OrphHard(int sign)
        {
            BrutalAPI.EnemyEncounter jarden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "HowMuchBananas",
                area = 1,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = UnityEngine.Random.Range(1, 12),
                signType = (SignType)sign,
                musicEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Scrungie_Medium_EnemyBundle")._musicEventReference,
                roarEvent = "event:/Hawthorne/Noisy/YA_Roar",
                difficulty = EncounterDifficulty.Hard
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("YellowAngel_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowAngel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=4},
                });
            }
            for (int i = 0; i < 3; i++)
            {
                string e = RandomOrph;
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowAngel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = e, enemySlot=2},
                new FieldEnemy(){enemyName = Either(e, RandomOrph), enemySlot=3},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=4},
                });
                string r = RandomOrph;
                ResetColor();
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowAngel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = r, enemySlot=2},
                new FieldEnemy(){enemyName = SmartColor(1, true), enemySlot=3},
                new FieldEnemy(){enemyName = Either(Either(r, RandomOrph), SmartColor(1)), enemySlot=4},
                });
                ResetColor();
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowAngel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=3},
                new FieldEnemy(){enemyName = OrphWhore(), enemySlot=4},
                });
                string b = RandomOrph;
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowAngel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = b, enemySlot=2},
                new FieldEnemy(){enemyName = Either(b, RandomOrph), enemySlot=3},
                new FieldEnemy(){enemyName = Either(b, RandomOrph), enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowAngel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = OrphWhore(), enemySlot=2},
                new FieldEnemy(){enemyName = OrphWhore(), enemySlot=3},
                });
            }
            jarden.variations = fields.ToArray();
            jarden.AddEncounter();
        }
    }
    public static class EvilEyeSong
    {
        public static void Add(int sign)
        {
            if (!EnemyExist("EvilEyeball_EN")) return;

            BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("EyeballWorld.png"));

            OrphMed(sign);
            OrphHard(sign);
        }
        public static void OrphMed(int sign)
        {
            BrutalAPI.EnemyEncounter jarden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "HateYou",
                area = 1,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = UnityEngine.Random.Range(5, 12),
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/EvilEyeTheme",
                roarEvent = "event:/Hawthorne/Noisy/Eye_Roar",
                difficulty = EncounterDifficulty.Medium
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("EvilEyeball_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EvilEyeball_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                });
            }
            for (int i = 0; i < 3; i++)
            {
                string e = RandomOrph;
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EvilEyeball_EN", enemySlot=1},
                new FieldEnemy(){enemyName = e, enemySlot=2},
                new FieldEnemy(){enemyName = Either(e, RandomOrph), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EvilEyeball_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EvilEyeball_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=3},
                });
                string b = RandomOrph;
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EvilEyeball_EN", enemySlot=1},
                new FieldEnemy(){enemyName = b, enemySlot=2},
                new FieldEnemy(){enemyName = Either(b, RandomOrph), enemySlot=3},
                new FieldEnemy(){enemyName = RandomSupport(1), enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EvilEyeball_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                new FieldEnemy(){enemyName = OrphWhore(), enemySlot=3},
                });
            }
            jarden.variations = fields.ToArray();
            jarden.AddEncounter();
        }
        public static void OrphHard(int sign)
        {
            BrutalAPI.EnemyEncounter jarden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "StillHateYou",
                area = 1,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = UnityEngine.Random.Range(3, 10),
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/EvilEyeTheme",
                roarEvent = "event:/Hawthorne/Noisy/Eye_Roar",
                difficulty = EncounterDifficulty.Hard
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("EvilEyeball_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EvilEyeball_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=4},
                });
            }
            for (int i = 0; i < 3; i++)
            {
                string e = RandomOrph;
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EvilEyeball_EN", enemySlot=1},
                new FieldEnemy(){enemyName = e, enemySlot=2},
                new FieldEnemy(){enemyName = Either(e, RandomOrph), enemySlot=3},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=4},
                });
                string r = RandomOrph;
                ResetColor();
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EvilEyeball_EN", enemySlot=1},
                new FieldEnemy(){enemyName = r, enemySlot=2},
                new FieldEnemy(){enemyName = SmartColor(1, true), enemySlot=3},
                new FieldEnemy(){enemyName = Either(Either(r, RandomOrph), SmartColor(1)), enemySlot=4},
                });
                ResetColor();
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EvilEyeball_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=3},
                new FieldEnemy(){enemyName = OrphWhore(), enemySlot=4},
                });
                string b = RandomOrph;
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EvilEyeball_EN", enemySlot=1},
                new FieldEnemy(){enemyName = b, enemySlot=2},
                new FieldEnemy(){enemyName = Either(b, RandomOrph), enemySlot=3},
                new FieldEnemy(){enemyName = Either(b, RandomOrph), enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EvilEyeball_EN", enemySlot=1},
                new FieldEnemy(){enemyName = OrphWhore(), enemySlot=2},
                new FieldEnemy(){enemyName = OrphWhore(), enemySlot=3},
                });
            }
            jarden.variations = fields.ToArray();
            jarden.AddEncounter();
        }
    }
    public static class GraveSong
    {
        public static int rarity
        {
            get
            {
                int g = UnityEngine.Random.Range(6, 21);
                if (SaltEnemies.silly == 24) g *= 2;
                if (SaltEnemies.trolling == 17) g += 10;
                if (SaltEnemies.rando == 94) g += 1;
                return g;
            }
        }

        public static void Add(int sign)
        {
            if (!EnemyExist("NobodyGrave_EN")) return;

            BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("GraveWorld.png"));

            ShoreEZ(sign);
            ShoreMed(sign);
            ShoreHard(sign);
        }
        public static void ShoreEZ(int sign)
        {
            BrutalAPI.EnemyEncounter orpheum = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "Grave_Easy",
                area = 0,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = rarity / 4,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/GraveTheme",
                roarEvent = LoadedAssetsHandler.GetCharcater("Gospel_CH").deathSound,
                difficulty = EncounterDifficulty.Easy
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("NobodyGrave_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "NobodyGrave_EN", enemySlot=2},
                new FieldEnemy(){enemyName = ShoreSlop(Half), enemySlot=3},
                new FieldEnemy(){enemyName = ShoreSlop(Half), enemySlot=4},
                });
            }
            for (int i = 0; i < 3; i++)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "NobodyGrave_EN", enemySlot=0},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=2},
                new FieldEnemy(){enemyName = RandomShoreMidget(), enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "NobodyGrave_EN", enemySlot=0},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=1},
                new FieldEnemy(){enemyName = SmartColor(0), enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "NobodyGrave_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=1},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "NobodyGrave_EN", enemySlot=0},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=3},
                });
            }
            for (int i = 0; i < 2; i++)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "NobodyGrave_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=1},
                new FieldEnemy(){enemyName = Either(RandomSupport(0), RandomShoreMidget(false)), enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "NobodyGrave_EN", enemySlot=0},
                new FieldEnemy(){enemyName = ShoreSlop(Half), enemySlot=1},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "NobodyGrave_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Either(RandomSupport(0), RandomShoreMidget(false)), enemySlot=4},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=3},
                });
            }
            orpheum.variations = fields.ToArray();
            orpheum.CheckEncounters();
            orpheum.AddEncounter();
        }
        public static void ShoreMed(int sign)
        {
            BrutalAPI.EnemyEncounter orpheum = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "Grave_Med",
                area = 0,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = rarity,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/GraveTheme",
                roarEvent = LoadedAssetsHandler.GetCharcater("Gospel_CH").deathSound,
                difficulty = EncounterDifficulty.Medium
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("NobodyGrave_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "NobodyGrave_EN", enemySlot=2},
                new FieldEnemy(){enemyName = Shore.RandomShoreWhore(), enemySlot=3},
                new FieldEnemy(){enemyName = RandomShoreMidget(false), enemySlot=4},
                });
            }
            for (int i = 0; i < 3; i++)
            {
                ResetColor();
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "NobodyGrave_EN", enemySlot=0},
                new FieldEnemy(){enemyName = SmartColor(0, true), enemySlot=1},
                new FieldEnemy(){enemyName = SmartColor(0), enemySlot=2},
                new FieldEnemy(){enemyName = RandomShoreMidget(), enemySlot=4},
                });
                ResetColor();
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "NobodyGrave_EN", enemySlot=0},
                new FieldEnemy(){enemyName = SmartColor(0, true), enemySlot=1},
                new FieldEnemy(){enemyName = SmartColor(0), enemySlot=2},
                });
                ResetColor();
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "NobodyGrave_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=1},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=3},
                new FieldEnemy(){enemyName = Either(RandomSupport(0, false, false), RandomShoreMidget(false)), enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "NobodyGrave_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=1},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "NobodyGrave_EN", enemySlot=0},
                new FieldEnemy(){enemyName = ShoreSlop(Half), enemySlot=1},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=3},
                new FieldEnemy(){enemyName = RandomShoreMidget(false), enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "NobodyGrave_EN", enemySlot=0},
                new FieldEnemy(){enemyName = ShoreSlop(Half), enemySlot=1},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=3},
                });
            }
            for (int i = 0; i < 20; i++)
            {
                fields.Add(RandomizeShore("NobodyGrave_EN", Weight.Normal));
            }
            orpheum.variations = fields.ToArray();
            orpheum.CheckEncounters();
            orpheum.AddEncounter();
        }
        public static void ShoreHard(int sign)
        {
            BrutalAPI.EnemyEncounter orpheum = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "Grave_Hard",
                area = 0,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = rarity / 2,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/GraveTheme",
                roarEvent = LoadedAssetsHandler.GetCharcater("Gospel_CH").deathSound,
                difficulty = EncounterDifficulty.Hard
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("NobodyGrave_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "NobodyGrave_EN", enemySlot=2},
                new FieldEnemy(){enemyName = Shore.RandomShoreWhore(), enemySlot=3},
                new FieldEnemy(){enemyName = Shore.RandomShoreWhore(), enemySlot=1},
                new FieldEnemy(){enemyName = RandomShoreMidget(false), enemySlot=4},
                });
            }
            for (int i = 0; i < 3; i++)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "NobodyGrave_EN", enemySlot=0},
                new FieldEnemy(){enemyName = SmartColor(0), enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(0, false, false), enemySlot=2},
                new FieldEnemy(){enemyName = Shore.RandomShoreWhore(), enemySlot=4},
                });
                ResetColor();
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "NobodyGrave_EN", enemySlot=0},
                new FieldEnemy(){enemyName = SmartColor(0, true), enemySlot=1},
                new FieldEnemy(){enemyName = SmartColor(0), enemySlot=2},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=4},
                });
                ResetColor();
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "NobodyGrave_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=1},
                new FieldEnemy(){enemyName = ShoreSlop(Half), enemySlot=3},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "NobodyGrave_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=1},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=3},
                new FieldEnemy(){enemyName = Shore.RandomShoreWhore(), enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "NobodyGrave_EN", enemySlot=0},
                new FieldEnemy(){enemyName = ShoreSlop(Half), enemySlot=1},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=3},
                new FieldEnemy(){enemyName = Shore.RandomShoreWhore(), enemySlot=4},
                });
            }
            for (int i = 0; i < 20; i++)
            {
                fields.Add(RandomizeShore("NobodyGrave_EN", Weight.Big));
            }
            orpheum.variations = fields.ToArray();
            orpheum.CheckEncounters();
            orpheum.AddEncounter();
        }
    }
    public static class EvilDogTheme
    {
        public static void Add(int sign)
        {
            if (!EnemyExist("EvilDog_EN")) return;

            BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("EvilDogWorld.png"));

            gardEZ(sign);
            gardMed(sign);
        }
        public static void gardEZ(int sign)
        {
            BrutalAPI.EnemyEncounter jarden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "thisdogSUCKS",
                area = 2,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = 10 * 1,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/LobotomyTheme",
                roarEvent = LoadedAssetsHandler.GetCharcater("LongLiver_CH").deathSound,
                difficulty = EncounterDifficulty.Easy
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("EvilDog_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EvilDog_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=4},
                });
            }
            if (EnemyExist("EvilDog_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EvilDog_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=3},
                });
            }
            if (EnemyExist("EyePalm_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EvilDog_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Enigma_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EvilDog_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=3},
                });
            }
            if (MultiENExist("DeadPixel_EN", "MechanicalLens_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EvilDog_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=3},
                });
            }
            if (EnemyExist("EggKeeper_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EvilDog_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Romantic_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EvilDog_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Grandfather_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EvilDog_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=2},
                });
            }
            if (MultiENExist("LittleAngel_EN", "SterileBud_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EvilDog_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Shua_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EvilDog_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(2, false, false), enemySlot=2},
                });
            }
            if (GreyScale)
            {
                for (int i = 0; i < 4; i++)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "EvilDog_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = GreyScaleRedSource(true), enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                    });
                }
            }
            jarden.variations = fields.ToArray();
            jarden.CheckEncounters();
            jarden.AddEncounter();
        }
        public static void gardMed(int sign)
        {
            BrutalAPI.EnemyEncounter jarden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "thisdogRULES",
                area = 2,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = 10 * 1,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/LobotomyTheme",
                roarEvent = LoadedAssetsHandler.GetCharcater("LongLiver_CH").deathSound,
                difficulty = EncounterDifficulty.Medium
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("EvilDog_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EvilDog_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=4},
                });
            }
            for (int i = 0; i < 5; i++)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EvilDog_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomEncounters.Garden.RandomChunk(), enemySlot=1},
                new FieldEnemy(){enemyName = RandomEncounters.Garden.RandomChunk(false, true), enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(2, false, false), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EvilDog_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomEncounters.Garden.RandomWhore(), enemySlot=1},
                new FieldEnemy(){enemyName = Half ? RandomSupport(2, false, false) : RandomColor(2), enemySlot=3},
                });
            }
            if (GreyScale)
            {

                for (int i = 0; i < 3; i++)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "EvilDog_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = GreyScaleRedSource(true), enemySlot=3},
                    new FieldEnemy(){enemyName = GreyScaleSupport(true), enemySlot=4},
                    });
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "EvilDog_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = GreyScaleSupport(true), enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = GreyScaleSupport(true), enemySlot=4},
                    });
                }
            }
            jarden.variations = fields.ToArray();
            jarden.CheckEncounters();
            jarden.AddEncounter();
        }
    }
    public static class UFOSong
    {
        public static int rarity
        {
            get
            {
                int g = UnityEngine.Random.Range(6, 21);
                if (SaltEnemies.silly == 53) g *= 2;
                if (SaltEnemies.trolling == 31) g += 10;
                if (SaltEnemies.rando == 88) g += 1;
                return g;
            }
        }

        public static void Add(int sign)
        {
            if (!EnemyExist("ToyUfo_EN")) return;

            BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("UFOWorld.png"));

            ShoreMed(sign);
            ShoreHard(sign);
        }
        public static void ShoreMed(int sign)
        {
            BrutalAPI.EnemyEncounter orpheum = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "SpacemenFromSpace",
                area = 0,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = rarity,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/UFOTheme",
                roarEvent = "event:/Hawthorne/Roar/PixelRoar",
                difficulty = EncounterDifficulty.Medium
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("ToyUfo_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ToyUfo_EN", enemySlot=2},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=3},
                new FieldEnemy(){enemyName = RandomShoreMidget(false), enemySlot=4},
                });
            }
            for (int i = 0; i < 3; i++)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ToyUfo_EN", enemySlot=0},
                new FieldEnemy(){enemyName = SmartColor(0), enemySlot=1},
                new FieldEnemy(){enemyName = RandomShoreMidget(), enemySlot=4},
                });
                ResetColor();
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ToyUfo_EN", enemySlot=0},
                new FieldEnemy(){enemyName = SmartColor(0, true), enemySlot=1},
                new FieldEnemy(){enemyName = SmartColor(0), enemySlot=2},
                });
                ResetColor();
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ToyUfo_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=1},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=3},
                new FieldEnemy(){enemyName = Either(RandomSupport(0, false, false), RandomShoreMidget(false)), enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ToyUfo_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=1},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ToyUfo_EN", enemySlot=0},
                new FieldEnemy(){enemyName = ShoreSlop(Half), enemySlot=1},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=3},
                new FieldEnemy(){enemyName = RandomShoreMidget(false), enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ToyUfo_EN", enemySlot=0},
                new FieldEnemy(){enemyName = ShoreSlop(Half), enemySlot=1},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=3},
                });
            }
            orpheum.variations = fields.ToArray();
            orpheum.CheckEncounters();
            orpheum.AddEncounter();
        }
        public static void ShoreHard(int sign)
        {
            BrutalAPI.EnemyEncounter orpheum = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "SpacemenFromWalmart",
                area = 0,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = rarity / 2,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/UFOTheme",
                roarEvent = "event:/Hawthorne/Roar/PixelRoar",
                difficulty = EncounterDifficulty.Hard
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("ToyUfo_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ToyUfo_EN", enemySlot=2},
                new FieldEnemy(){enemyName = Shore.RandomShoreWhore(), enemySlot=1},
                new FieldEnemy(){enemyName = RandomShoreMidget(false), enemySlot=4},
                });
            }
            for (int i = 0; i < 3; i++)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ToyUfo_EN", enemySlot=0},
                new FieldEnemy(){enemyName = SmartColor(0), enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(0, false, false), enemySlot=2},
                new FieldEnemy(){enemyName = Shore.RandomShoreWhore(), enemySlot=4},
                });
                ResetColor();
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ToyUfo_EN", enemySlot=0},
                new FieldEnemy(){enemyName = SmartColor(0, true), enemySlot=1},
                new FieldEnemy(){enemyName = SmartColor(0), enemySlot=2},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=4},
                });
                ResetColor();
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ToyUfo_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=1},
                new FieldEnemy(){enemyName = ShoreSlop(Half), enemySlot=3},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ToyUfo_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=1},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=3},
                new FieldEnemy(){enemyName = Shore.RandomShoreWhore(), enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ToyUfo_EN", enemySlot=0},
                new FieldEnemy(){enemyName = ShoreSlop(Half), enemySlot=1},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=3},
                new FieldEnemy(){enemyName = Shore.RandomShoreWhore(), enemySlot=4},
                });
            }
            orpheum.variations = fields.ToArray();
            orpheum.CheckEncounters();
            orpheum.AddEncounter();
        }
    }
    public static class SinkerSong
    {
        public static int rarity
        {
            get
            {
                int g = UnityEngine.Random.Range(6, 21);
                if (SaltEnemies.silly == 11) g *= 2;
                if (SaltEnemies.trolling == 26) g += 10;
                if (SaltEnemies.rando == 82) g += 1;
                return g;
            }
        }

        public static void Add(int sign)
        {
            if (!EnemyExist("Sinker_EN")) return;

            BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("SinkerWorld.png"));

            ShoreMed(sign);
            ShoreHard(sign);
        }
        public static void ShoreMed(int sign)
        {
            BrutalAPI.EnemyEncounter orpheum = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "MouthNails1",
                area = 0,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = rarity,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/SinkerTheme",
                roarEvent = "event:/Hawthorne/Attack3/Nailing",
                difficulty = EncounterDifficulty.Medium
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("Sinker_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sinker_EN", enemySlot=2},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=3},
                new FieldEnemy(){enemyName = RandomShoreMidget(false), enemySlot=4},
                });
            }
            for (int i = 0; i < 3; i++)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sinker_EN", enemySlot=0},
                new FieldEnemy(){enemyName = SmartColor(0), enemySlot=1},
                new FieldEnemy(){enemyName = RandomShoreMidget(), enemySlot=4},
                });
                ResetColor();
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sinker_EN", enemySlot=0},
                new FieldEnemy(){enemyName = SmartColor(0, true), enemySlot=1},
                new FieldEnemy(){enemyName = SmartColor(0), enemySlot=2},
                });
                ResetColor();
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sinker_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=1},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=3},
                new FieldEnemy(){enemyName = Either(RandomSupport(0, false, false), RandomShoreMidget(false)), enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sinker_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=1},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sinker_EN", enemySlot=0},
                new FieldEnemy(){enemyName = ShoreSlop(Half), enemySlot=1},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=3},
                new FieldEnemy(){enemyName = RandomShoreMidget(false), enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sinker_EN", enemySlot=0},
                new FieldEnemy(){enemyName = ShoreSlop(Half), enemySlot=1},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=3},
                });
            }
            orpheum.variations = fields.ToArray();
            orpheum.CheckEncounters();
            orpheum.AddEncounter();
        }
        public static void ShoreHard(int sign)
        {
            BrutalAPI.EnemyEncounter orpheum = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "SpacemenFromWalmart",
                area = 0,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = rarity / 2,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/SinkerTheme",
                roarEvent = "event:/Hawthorne/Attack3/Nailing",
                difficulty = EncounterDifficulty.Hard
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("Sinker_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sinker_EN", enemySlot=2},
                new FieldEnemy(){enemyName = Shore.RandomShoreWhore(), enemySlot=1},
                new FieldEnemy(){enemyName = RandomShoreMidget(false), enemySlot=4},
                });
            }
            for (int i = 0; i < 3; i++)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sinker_EN", enemySlot=0},
                new FieldEnemy(){enemyName = SmartColor(0), enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(0, false, false), enemySlot=2},
                new FieldEnemy(){enemyName = Shore.RandomShoreWhore(), enemySlot=4},
                });
                ResetColor();
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sinker_EN", enemySlot=0},
                new FieldEnemy(){enemyName = SmartColor(0, true), enemySlot=1},
                new FieldEnemy(){enemyName = SmartColor(0), enemySlot=2},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=4},
                });
                ResetColor();
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sinker_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=1},
                new FieldEnemy(){enemyName = ShoreSlop(Half), enemySlot=3},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sinker_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=1},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=3},
                new FieldEnemy(){enemyName = Shore.RandomShoreWhore(), enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sinker_EN", enemySlot=0},
                new FieldEnemy(){enemyName = ShoreSlop(Half), enemySlot=1},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=3},
                new FieldEnemy(){enemyName = Shore.RandomShoreWhore(), enemySlot=4},
                });
            }
            orpheum.variations = fields.ToArray();
            orpheum.CheckEncounters();
            orpheum.AddEncounter();
        }
    }
    public static class PersonalAngelSong
    {
        public static void Add(int sign)
        {
            if (!EnemyExist("PersonalAngel_EN")) return;

            BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("PersonalWorld.png"));

            GardHard(sign);
        }
        public static void GardHard(int sign)
        {
            BrutalAPI.EnemyEncounter jarden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "YourVeryOwn",
                area = 2,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = 8,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/PersonalAngelSong",
                roarEvent = "event:/Hawthorne/Noisy/PA_Roar",
                difficulty = EncounterDifficulty.Hard
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("PersonalAngel_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PersonalAngel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=4},
                });
            }
            for (int i = 0; i < 3; i++)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PersonalAngel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = Garden.RandomChunk(true), enemySlot=2},
                new FieldEnemy(){enemyName = Garden.RandomChunk(false, true), enemySlot=3},
                new FieldEnemy(){enemyName = RandomSupport(2, false, false), enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PersonalAngel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = Garden.RandomChunk(true), enemySlot=2},
                new FieldEnemy(){enemyName = Garden.RandomChunk(false, true), enemySlot=3},
                new FieldEnemy(){enemyName = RandomColor(2), enemySlot=4},
                });
                ResetColor();
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PersonalAngel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = SmartColor(2, true, true), enemySlot=2},
                new FieldEnemy(){enemyName = SmartColor(2), enemySlot=3},
                new FieldEnemy(){enemyName = RandomSupport(2, false, false), enemySlot=4},
                });
                ResetColor();
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PersonalAngel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = SmartColor(2, true, true), enemySlot=2},
                new FieldEnemy(){enemyName = SmartColor(2), enemySlot=3},
                new FieldEnemy(){enemyName = Garden.RandomChunk(), enemySlot=4},
                });
                ResetColor();
                bool a = Half;
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PersonalAngel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = Garden.RandomWhore(a), enemySlot=2},
                new FieldEnemy(){enemyName = Either(SmartColor(2, false, !a), Garden.RandomChunk(!a)), enemySlot=3},
                new FieldEnemy(){enemyName = RandomSupport(2, false, false), enemySlot=4},
                });
            }
            jarden.variations = fields.ToArray();
            jarden.AddEncounter();
        }
    }
}
