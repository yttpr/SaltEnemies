using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using static Hawthorne.Check;
using static Hawthorne.RandomEncounters;

namespace Hawthorne
{
    public static class ApparatusSong
    {
        public static void RedAdd(int sign)
        {
            if (!Botting) return;

            BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("RedBotWorld.png"));

            RedOrphEZ(sign);
            RedOrphMed(sign);
            RedOrphHard(sign);
            RedGardEZ(sign);
        }
        public static void RedOrphEZ(int sign)
        {
            BrutalAPI.EnemyEncounter jarden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "virile_easy",
                area = 1,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = UnityEngine.Random.Range(8, 12),
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/ApparatusSong",
                roarEvent = "event:/Hawthorne/Roar/TankRoar",
                difficulty = EncounterDifficulty.Easy
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("RedBot_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=4},
                });
            }
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "RedBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
            });
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "RedBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "YellowBot_EN", enemySlot=1},
            });
            for (int i = 0; i < 4; i++)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(1), enemySlot=3},
                });
            }
            jarden.variations = fields.ToArray();
            jarden.CheckEncounters();
            jarden.AddEncounter();
        }
        public static void RedOrphMed(int sign)
        {
            BrutalAPI.EnemyEncounter jarden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "virile_med",
                area = 1,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = UnityEngine.Random.Range(12, 18),
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/ApparatusSong",
                roarEvent = "event:/Hawthorne/Roar/TankRoar",
                difficulty = EncounterDifficulty.Medium
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("RedBot_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=4},
                });
            }
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "RedBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "YellowBot_EN", enemySlot=3},
            });
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "RedBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "YellowBot_EN", enemySlot=1},
                new FieldEnemy(){enemyName = OrphWhore(), enemySlot=2},
            });
            for (int i = 0; i < 5; i++)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=3},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=1},
                new FieldEnemy(){enemyName = OrphWhore(), enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=3},
                new FieldEnemy(){enemyName = "YellowBot_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=1},
                new FieldEnemy(){enemyName = OrphWhore(), enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=3},
                });
            }
            jarden.variations = fields.ToArray();
            jarden.CheckEncounters();
            jarden.AddEncounter();
        }
        public static void RedOrphHard(int sign)
        {
            BrutalAPI.EnemyEncounter jarden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "virile_waawaa",
                area = 1,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = UnityEngine.Random.Range(12, 18),
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/ApparatusSong",
                roarEvent = "event:/Hawthorne/Roar/TankRoar",
                difficulty = EncounterDifficulty.Hard
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("RedBot_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Conductor_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "YellowBot_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=4},
                });
            }
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "RedBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = OrphWhore(), enemySlot=1},
                new FieldEnemy(){enemyName = OrphWhore(), enemySlot=2},
                new FieldEnemy(){enemyName = "YellowBot_EN", enemySlot=3},
            });
            for (int i = 0; i < 5; i++)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = OrphWhore(), enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=3},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=1},
                new FieldEnemy(){enemyName = OrphWhore(), enemySlot=2},
                new FieldEnemy(){enemyName = "YellowBot_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = OrphWhore(), enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=3},
                new FieldEnemy(){enemyName = "YellowBot_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=1},
                new FieldEnemy(){enemyName = OrphWhore(), enemySlot=2},
                new FieldEnemy(){enemyName = OrphWhore(), enemySlot=3},
                });
            }
            jarden.variations = fields.ToArray();
            jarden.CheckEncounters();
            jarden.AddEncounter();
        }
        public static void RedGardEZ(int sign)
        {
            BrutalAPI.EnemyEncounter jarden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "virile_garden",
                area = 2,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = UnityEngine.Random.Range(8, 12),
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/ApparatusSong",
                roarEvent = "event:/Hawthorne/Roar/TankRoar",
                difficulty = EncounterDifficulty.Easy
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("RedBot_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "YellowBot_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=2},
                });
            }
            for (int i = 0; i < 4; i++)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Garden.RandomChunk(), enemySlot=1},
                new FieldEnemy(){enemyName = Garden.RandomChunk(false, true), enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Garden.RandomChunk(), enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(2, false, false), enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Garden.RandomChunk(), enemySlot=1},
                new FieldEnemy(){enemyName = Garden.RandomChunk(false, true), enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(2), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Garden.RandomChunk(), enemySlot=1},
                new FieldEnemy(){enemyName = "YellowBot_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomSupport(2, false, false), enemySlot=1},
                new FieldEnemy(){enemyName = "YellowBot_EN", enemySlot=2},
                });
            }
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "RedBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Either("BlueBot_EN", "PurpleBot_EN"), enemySlot=1},
                new FieldEnemy(){enemyName = "YellowBot_EN", enemySlot=2},
            });
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "RedBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Either(Garden.RandomChunk(), RandomSupport(2, false, false)), enemySlot=1},
                new FieldEnemy(){enemyName = Either("BlueBot_EN", "PurpleBot_EN"), enemySlot=2},
            });
            jarden.variations = fields.ToArray();
            jarden.CheckEncounters();
            jarden.AddEncounter();
        }
        public static void YellowAdd(int sign)
        {
            if (!Botting) return;

            BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("YellowBotWorld.png"));

            YellowOrphMed(sign);
            YellowOrphHard(sign);
            YellowGardEZ(sign);
            YellowGardMed(sign);

        }
        public static void YellowOrphMed(int sign)
        {
            BrutalAPI.EnemyEncounter jarden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "projecting_med",
                area = 1,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = UnityEngine.Random.Range(12, 18),
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/ApparatusSong",
                roarEvent = "event:/Hawthorne/Roar/TankRoar",
                difficulty = EncounterDifficulty.Medium
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("YellowBot_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=4},
                });
            }
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "RedBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "YellowBot_EN", enemySlot=3},
            });
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "RedBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "YellowBot_EN", enemySlot=1},
                new FieldEnemy(){enemyName = OrphWhore(), enemySlot=2},
            });
            for (int i = 0; i < 5; i++)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=3},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=1},
                new FieldEnemy(){enemyName = OrphWhore(), enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=3},
                new FieldEnemy(){enemyName = "YellowBot_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=1},
                new FieldEnemy(){enemyName = OrphWhore(), enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=3},
                });
            }
            jarden.variations = fields.ToArray();
            jarden.CheckEncounters();
            jarden.AddEncounter();
        }
        public static void YellowOrphHard(int sign)
        {
            BrutalAPI.EnemyEncounter jarden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "projecting_hard",
                area = 1,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = UnityEngine.Random.Range(12, 18),
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/ApparatusSong",
                roarEvent = "event:/Hawthorne/Roar/TankRoar",
                difficulty = EncounterDifficulty.Hard
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("YellowBot_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Conductor_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "YellowBot_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=4},
                });
            }
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "RedBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = OrphWhore(), enemySlot=1},
                new FieldEnemy(){enemyName = OrphWhore(), enemySlot=2},
                new FieldEnemy(){enemyName = "YellowBot_EN", enemySlot=3},
            });
            for (int i = 0; i < 5; i++)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = OrphWhore(), enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=3},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=1},
                new FieldEnemy(){enemyName = OrphWhore(), enemySlot=2},
                new FieldEnemy(){enemyName = "YellowBot_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = OrphWhore(), enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=3},
                new FieldEnemy(){enemyName = "YellowBot_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=1},
                new FieldEnemy(){enemyName = OrphWhore(), enemySlot=2},
                new FieldEnemy(){enemyName = OrphWhore(), enemySlot=3},
                });
            }
            jarden.variations = fields.ToArray();
            jarden.CheckEncounters();
            jarden.AddEncounter();
        }
        public static void YellowGardEZ(int sign)
        {
            BrutalAPI.EnemyEncounter jarden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "project_ez_garden",
                area = 2,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = UnityEngine.Random.Range(8, 12),
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/ApparatusSong",
                roarEvent = "event:/Hawthorne/Roar/TankRoar",
                difficulty = EncounterDifficulty.Easy
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("YellowBot_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "YellowBot_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=2},
                });
            }
            for (int i = 0; i < 4; i++)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Garden.RandomChunk(true), enemySlot=1},
                new FieldEnemy(){enemyName = Garden.RandomChunk(false, true), enemySlot=2},
                });
                bool H = Half;
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Garden.RandomChunk(H), enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(2, !H, false), enemySlot=2},
                });
                bool d = Half;
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Garden.RandomChunk(d), enemySlot=1},
                new FieldEnemy(){enemyName = Garden.RandomChunk(false, true), enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(2, !d), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Garden.RandomChunk(), enemySlot=1},
                new FieldEnemy(){enemyName = "YellowBot_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomSupport(2, false, false), enemySlot=1},
                new FieldEnemy(){enemyName = "YellowBot_EN", enemySlot=2},
                });
            }
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "RedBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Either("BlueBot_EN", "PurpleBot_EN"), enemySlot=1},
                new FieldEnemy(){enemyName = "YellowBot_EN", enemySlot=2},
            });
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "YellowBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Either(Garden.RandomChunk(true), RandomSupport(2, true, false)), enemySlot=1},
                new FieldEnemy(){enemyName = Either("BlueBot_EN", "PurpleBot_EN"), enemySlot=2},
            });
            jarden.variations = fields.ToArray();
            jarden.CheckEncounters();
            jarden.AddEncounter();
        }
        public static void YellowGardMed(int sign)
        {
            BrutalAPI.EnemyEncounter jarden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "project_med_garden",
                area = 2,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = UnityEngine.Random.Range(16, 24),
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/ApparatusSong",
                roarEvent = "event:/Hawthorne/Roar/TankRoar",
                difficulty = EncounterDifficulty.Medium
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("YellowBot_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "YellowBot_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=2},
                new FieldEnemy(){enemyName = Either("BlueBot_EN", "PurpleBot_EN"), enemySlot=2},
                });
            }
            for (int i = 0; i < 5; i++)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Garden.RandomChunk(), enemySlot=1},
                new FieldEnemy(){enemyName = Garden.RandomChunk(false, true), enemySlot=2},
                new FieldEnemy(){enemyName = Garden.RandomChunk(true), enemySlot=3},
                });
                bool H = Half;
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Garden.RandomChunk(H), enemySlot=1},
                new FieldEnemy(){enemyName = Garden.RandomWhore(!H), enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Garden.RandomChunk(), enemySlot=1},
                new FieldEnemy(){enemyName = Garden.RandomChunk(false, true), enemySlot=3},
                new FieldEnemy(){enemyName = RandomSupport(2, false, false), enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Garden.RandomChunk(), enemySlot=1},
                new FieldEnemy(){enemyName = Garden.RandomChunk(false, true), enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(2, false, false), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = Bots.UpTo(4).Exclude("YellowBot_EN").GetRandom(), enemySlot=0},
                new FieldEnemy(){enemyName = Garden.RandomWhore(true), enemySlot=1},
                new FieldEnemy(){enemyName = "YellowBot_EN", enemySlot=2},
                });
                bool b = Half;
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = Bots.Exclude("YellowBot_EN").GetRandom(), enemySlot=0},
                new FieldEnemy(){enemyName = RandomSupport(2, b, false), enemySlot=1},
                new FieldEnemy(){enemyName = Garden.RandomChunk(!b), enemySlot=3},
                new FieldEnemy(){enemyName = "YellowBot_EN", enemySlot=2},
                });
                bool d = Half;
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Garden.RandomWhore(d), enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(2, !d, false), enemySlot=2},
                });
            }
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "RedBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "PurpleBot_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "YellowBot_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "BlueBot_EN", enemySlot=3},
            });
            jarden.variations = fields.ToArray();
            jarden.CheckEncounters();
            jarden.AddEncounter();
        }
        public static void BlueAdd(int sign)
        {
            if (!Botting) return;

            BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("BlueBotWorld.png"));

            BlueGardEZ(sign);
            BlueGardMed(sign);
        }
        public static void BlueGardEZ(int sign)
        {
            BrutalAPI.EnemyEncounter jarden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "mirror_ez_garden",
                area = 2,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = UnityEngine.Random.Range(8, 12),
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/ApparatusSong",
                roarEvent = "event:/Hawthorne/Roar/TankRoar",
                difficulty = EncounterDifficulty.Easy
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("BlueBot_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "BlueBot_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=2},
                });
            }
            for (int i = 0; i < 4; i++)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "BlueBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Garden.RandomChunk(true), enemySlot=1},
                new FieldEnemy(){enemyName = Garden.RandomChunk(false, true), enemySlot=2},
                });
                bool H = Half;
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "BlueBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Garden.RandomChunk(H), enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(2, !H, false), enemySlot=2},
                });
                bool d = Half;
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "BlueBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Garden.RandomChunk(d), enemySlot=1},
                new FieldEnemy(){enemyName = Garden.RandomChunk(false, true), enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(2, !d), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Garden.RandomChunk(), enemySlot=1},
                new FieldEnemy(){enemyName = "BlueBot_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomSupport(2, false, false), enemySlot=1},
                new FieldEnemy(){enemyName = "BlueBot_EN", enemySlot=2},
                });
            }
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "RedBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Either("YellowBot_EN", "PurpleBot_EN"), enemySlot=1},
                new FieldEnemy(){enemyName = "BlueBot_EN", enemySlot=2},
            });
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "BlueBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Either(Garden.RandomChunk(true), RandomSupport(2, true, false)), enemySlot=1},
                new FieldEnemy(){enemyName = Either("YellowBot_EN", "PurpleBot_EN"), enemySlot=2},
            });
            jarden.variations = fields.ToArray();
            jarden.CheckEncounters();
            jarden.AddEncounter();
        }
        public static void BlueGardMed(int sign)
        {
            BrutalAPI.EnemyEncounter jarden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "mirror_med_garden",
                area = 2,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = UnityEngine.Random.Range(16, 24),
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/ApparatusSong",
                roarEvent = "event:/Hawthorne/Roar/TankRoar",
                difficulty = EncounterDifficulty.Medium
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("BlueBot_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "BlueBot_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                });
            }
            for (int i = 0; i < 5; i++)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "BlueBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Garden.RandomChunk(), enemySlot=1},
                new FieldEnemy(){enemyName = Garden.RandomChunk(false, true), enemySlot=2},
                new FieldEnemy(){enemyName = Garden.RandomChunk(true), enemySlot=3},
                });
                bool H = Half;
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "BlueBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Garden.RandomChunk(H), enemySlot=1},
                new FieldEnemy(){enemyName = Garden.RandomWhore(!H), enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "BlueBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Garden.RandomChunk(), enemySlot=1},
                new FieldEnemy(){enemyName = Garden.RandomChunk(false, true), enemySlot=3},
                new FieldEnemy(){enemyName = RandomSupport(2, false, false), enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "BlueBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Garden.RandomChunk(), enemySlot=1},
                new FieldEnemy(){enemyName = Garden.RandomChunk(false, true), enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(2, false, false), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = Bots.Exclude("BlueBot_EN").GetRandom(), enemySlot=0},
                new FieldEnemy(){enemyName = Garden.RandomWhore(true), enemySlot=1},
                new FieldEnemy(){enemyName = "BlueBot_EN", enemySlot=2},
                });
                bool b = Half;
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = Bots.Exclude("BlueBot_EN").GetRandom(), enemySlot=0},
                new FieldEnemy(){enemyName = RandomSupport(2, b, false), enemySlot=1},
                new FieldEnemy(){enemyName = Garden.RandomChunk(!b), enemySlot=3},
                new FieldEnemy(){enemyName = "BlueBot_EN", enemySlot=2},
                });
                bool d = Half;
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "BlueBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Garden.RandomWhore(d), enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(2, !d, false), enemySlot=2},
                });
            }
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "RedBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "PurpleBot_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "YellowBot_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "BlueBot_EN", enemySlot=3},
            });
            jarden.variations = fields.ToArray();
            jarden.CheckEncounters();
            jarden.AddEncounter();
        }
        public static void PurpleAdd(int sign)
        {
            if (!Botting) return;

            BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("PurpleBotWorld.png"));

            PurpleGardEZ(sign);
            PurpleGardMed(sign);

        }
        public static void PurpleGardEZ(int sign)
        {
            BrutalAPI.EnemyEncounter jarden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "magic_ez_garden",
                area = 2,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = UnityEngine.Random.Range(8, 12),
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/ApparatusSong",
                roarEvent = "event:/Hawthorne/Roar/TankRoar",
                difficulty = EncounterDifficulty.Easy
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("PurpleBot_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "PurpleBot_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=2},
                });
            }
            for (int i = 0; i < 4; i++)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Garden.RandomChunk(true), enemySlot=1},
                new FieldEnemy(){enemyName = Garden.RandomChunk(false, true), enemySlot=2},
                });
                bool H = Half;
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Garden.RandomChunk(H), enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(2, !H, false), enemySlot=2},
                });
                bool d = Half;
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Garden.RandomChunk(d), enemySlot=1},
                new FieldEnemy(){enemyName = Garden.RandomChunk(false, true), enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(2, !d), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Garden.RandomChunk(), enemySlot=1},
                new FieldEnemy(){enemyName = "PurpleBot_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomSupport(2, false, false), enemySlot=1},
                new FieldEnemy(){enemyName = "PurpleBot_EN", enemySlot=2},
                });
            }
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "RedBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Either("YellowBot_EN", "BlueBot_EN"), enemySlot=1},
                new FieldEnemy(){enemyName = "PurpleBot_EN", enemySlot=2},
            });
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "PurpleBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Either(Garden.RandomChunk(true), RandomSupport(2, true, false)), enemySlot=1},
                new FieldEnemy(){enemyName = Either("YellowBot_EN", "BlueBot_EN"), enemySlot=2},
            });
            jarden.variations = fields.ToArray();
            jarden.CheckEncounters();
            jarden.AddEncounter();
        }
        public static void PurpleGardMed(int sign)
        {
            BrutalAPI.EnemyEncounter jarden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "magic_med_garden",
                area = 2,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = UnityEngine.Random.Range(16, 24),
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/ApparatusSong",
                roarEvent = "event:/Hawthorne/Roar/TankRoar",
                difficulty = EncounterDifficulty.Medium
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("PurpleBot_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "PurpleBot_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=2},
                new FieldEnemy(){enemyName = Either("BlueBot_EN", "RedBot_EN"), enemySlot=2},
                });
            }
            for (int i = 0; i < 5; i++)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Garden.RandomChunk(), enemySlot=1},
                new FieldEnemy(){enemyName = Garden.RandomChunk(false, true), enemySlot=2},
                new FieldEnemy(){enemyName = Garden.RandomChunk(true), enemySlot=3},
                });
                bool H = Half;
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Garden.RandomChunk(H), enemySlot=1},
                new FieldEnemy(){enemyName = Garden.RandomWhore(!H), enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Garden.RandomChunk(), enemySlot=1},
                new FieldEnemy(){enemyName = Garden.RandomChunk(false, true), enemySlot=3},
                new FieldEnemy(){enemyName = RandomSupport(2, false, false), enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Garden.RandomChunk(), enemySlot=1},
                new FieldEnemy(){enemyName = Garden.RandomChunk(false, true), enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(2, false, false), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = Bots.Exclude("PurpleBot_EN").GetRandom(), enemySlot=0},
                new FieldEnemy(){enemyName = Garden.RandomWhore(true), enemySlot=1},
                new FieldEnemy(){enemyName = "PurpleBot_EN", enemySlot=2},
                });
                bool b = Half;
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = Bots.Exclude("PurpleBot_EN").GetRandom(), enemySlot=0},
                new FieldEnemy(){enemyName = RandomSupport(2, b, false), enemySlot=1},
                new FieldEnemy(){enemyName = Garden.RandomChunk(!b), enemySlot=3},
                new FieldEnemy(){enemyName = "PurpleBot_EN", enemySlot=2},
                });
                bool d = Half;
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "PurpleBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Garden.RandomWhore(d), enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(2, !d, false), enemySlot=2},
                });
            }
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "RedBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "PurpleBot_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "YellowBot_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "BlueBot_EN", enemySlot=3},
            });
            jarden.variations = fields.ToArray();
            jarden.CheckEncounters();
            jarden.AddEncounter();
        }
        public static void GreyAdd(int sign)
        {
            if (!Botting) return;

            BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("GreyBotWorld.png"));

            GreyGardMed(sign);
            GreyGardHard(sign);
        }
        public static void GreyGardMed(int sign)
        {
            BrutalAPI.EnemyEncounter jarden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "ANATOMYOFAGAMER_featuringpitbull",
                area = 2,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = UnityEngine.Random.Range(16, 24),
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/ApparatusSong",
                roarEvent = "event:/Hawthorne/Roar/TankRoar",
                difficulty = EncounterDifficulty.Medium
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("GreyBot_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "GreyBot_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=2},
                });
            }
            for (int i = 0; i < 5; i++)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "GreyBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Garden.RandomChunk(), enemySlot=1},
                new FieldEnemy(){enemyName = Garden.RandomChunk(false, true), enemySlot=2},
                new FieldEnemy(){enemyName = Garden.RandomChunk(true), enemySlot=3},
                });
                bool H = Half;
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "GreyBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Garden.RandomChunk(H), enemySlot=1},
                new FieldEnemy(){enemyName = Garden.RandomWhore(!H), enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "GreyBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Garden.RandomChunk(), enemySlot=1},
                new FieldEnemy(){enemyName = Garden.RandomChunk(false, true), enemySlot=3},
                new FieldEnemy(){enemyName = RandomSupport(2, false, false), enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "GreyBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Garden.RandomChunk(), enemySlot=1},
                new FieldEnemy(){enemyName = Garden.RandomChunk(false, true), enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(2, false, false), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = Bots.Exclude("GreyBot_EN").GetRandom(), enemySlot=0},
                new FieldEnemy(){enemyName = Garden.RandomWhore(true), enemySlot=1},
                new FieldEnemy(){enemyName = "GreyBot_EN", enemySlot=2},
                });
                bool b = Half;
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = Bots.Exclude("GreyBot_EN").GetRandom(), enemySlot=0},
                new FieldEnemy(){enemyName = RandomSupport(2, b, false), enemySlot=1},
                new FieldEnemy(){enemyName = Garden.RandomChunk(!b), enemySlot=3},
                new FieldEnemy(){enemyName = "GreyBot_EN", enemySlot=2},
                });
                bool d = Half;
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "GreyBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Garden.RandomWhore(d), enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(2, !d, false), enemySlot=2},
                });
            }
            if (Half)
            {
                fields.Add(new FieldEnemy[]
                    {
                        new FieldEnemy(){enemyName = "RedBot_EN", enemySlot=0},
                        new FieldEnemy(){enemyName = "GreyBot_EN", enemySlot=1},
                        new FieldEnemy(){enemyName = "YellowBot_EN", enemySlot=2},
                        new FieldEnemy(){enemyName = "BlueBot_EN", enemySlot=3},
                    });
            }
            else
            {
                if (Half)
                {
                    fields.Add(new FieldEnemy[]
                    {
                        new FieldEnemy(){enemyName = "RedBot_EN", enemySlot=0},
                        new FieldEnemy(){enemyName = "PurpleBot_EN", enemySlot=1},
                        new FieldEnemy(){enemyName = "GreyBot_EN", enemySlot=2},
                        new FieldEnemy(){enemyName = "BlueBot_EN", enemySlot=3},
                    });
                }
                else
                {
                    fields.Add(new FieldEnemy[]
                    {
                        new FieldEnemy(){enemyName = "RedBot_EN", enemySlot=0},
                        new FieldEnemy(){enemyName = "PurpleBot_EN", enemySlot=1},
                        new FieldEnemy(){enemyName = "YellowBot_EN", enemySlot=2},
                        new FieldEnemy(){enemyName = "GreyBot_EN", enemySlot=3},
                    });
                }
            }
            jarden.variations = fields.ToArray();
            jarden.CheckEncounters();
            jarden.AddEncounter();
        }
        public static void GreyGardHard(int sign)
        {
            BrutalAPI.EnemyEncounter jarden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "screamsatyouscreamsat_you",
                area = 2,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = UnityEngine.Random.Range(16, 24),
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/ApparatusSong",
                roarEvent = "event:/Hawthorne/Roar/TankRoar",
                difficulty = EncounterDifficulty.Hard
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("GreyBot_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "GreyBot_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=2},
                });
            }
            for (int i = 0; i < 5; i++)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "GreyBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Garden.RandomChunk(), enemySlot=1},
                new FieldEnemy(){enemyName = Garden.RandomChunk(false, true), enemySlot=2},
                new FieldEnemy(){enemyName = Garden.RandomChunk(true), enemySlot=3},
                new FieldEnemy(){enemyName = RandomSupport(2, false, false), enemySlot=4},
                });
                bool H = Half;
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "GreyBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Garden.RandomWhore(H), enemySlot=1},
                new FieldEnemy(){enemyName = Garden.RandomWhore(!H), enemySlot=2},
                });
                bool G = Half;
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "GreyBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Garden.RandomWhore(), enemySlot=1},
                new FieldEnemy(){enemyName = Garden.RandomChunk(G), enemySlot=3},
                new FieldEnemy(){enemyName = RandomSupport(2, !G, false), enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "GreyBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Garden.RandomWhore(), enemySlot=1},
                new FieldEnemy(){enemyName = Garden.RandomWhore(!G), enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(2, G, false), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = Bots.Exclude("GreyBot_EN").GetRandom(), enemySlot=0},
                new FieldEnemy(){enemyName = Garden.RandomWhore(true), enemySlot=1},
                new FieldEnemy(){enemyName = "GreyBot_EN", enemySlot=2},
                new FieldEnemy(){enemyName = Either(Garden.RandomChunk(), RandomSupport(2, false, false)), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = Bots.Exclude("GreyBot_EN").Exclude("RedBot_EN").GetRandom(), enemySlot=0},
                new FieldEnemy(){enemyName = Garden.RandomWhore(), enemySlot=1},
                new FieldEnemy(){enemyName = "RedBot_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "GreyBot_EN", enemySlot=2},
                });
                bool d = Half;
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "GreyBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Garden.RandomWhore(d), enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(2, !d, false), enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(2, false, false), enemySlot=2},
                });
            }
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "RedBot_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "GreyBot_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "YellowBot_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "BlueBot_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "PurpleBot_EN", enemySlot=4 },
            });
            jarden.variations = fields.ToArray();
            jarden.CheckEncounters();
            jarden.AddEncounter();
        }
    }
    public static class SunSong
    {
        public static void Add(int sign)
        {
            if (!EnemyExist("GlassedSun_EN")) return;

            BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("SunWorld.png"));

            GardHard(sign);
        }
        public static void GardHard(int sign)
        {
            BrutalAPI.EnemyEncounter jarden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "SUNSHINE",
                area = 2,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = UnityEngine.Random.Range(5, 12),
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/SunSong",
                roarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone02_JumbleGuts_Hollowing_Medium_EnemyBundle")._roarReference.roarEvent,
                difficulty = EncounterDifficulty.Hard
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("GlassedSun_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "GlassedSun_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GlassedSun_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "GlassedSun_EN", enemySlot=3},
                });
            }
            for (int i = 0; i < 3; i++)
            {
                fields.Add(new FieldEnemy[]
                {
                    new FieldEnemy(){enemyName = "GlassedSun_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = RandomColor(2), enemySlot=2},
                    new FieldEnemy(){enemyName = RandomColor(1), enemySlot=3},
                    new FieldEnemy(){enemyName = Either(RandomColor(2), RandomColor(1)), enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                    new FieldEnemy(){enemyName = "GlassedSun_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = Either(Either(RandomColor(2), RandomColor(1)), Either(Garden.RandomChunk(), Garden.RandomWhore())), enemySlot=2},
                    new FieldEnemy(){enemyName = Either(RandomSupport(2, false, false), RandomSupport(1, false, false)), enemySlot=3},
                    new FieldEnemy(){enemyName = Either(RandomSupport(2, false, false), RandomSupport(1, false, false)), enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                    new FieldEnemy(){enemyName = "GlassedSun_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = Either(Either(Garden.RandomChunk(), Shore.RandomShoreBigGuy()), Either(RandomOrph, OrphWhore())), enemySlot=2},
                    new FieldEnemy(){enemyName = Either(RandomOrph, OrphWhore()), enemySlot=3},
                    new FieldEnemy(){enemyName = Either(RandomSupport(2, false, false), RandomSupport(1, false, false)), enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                    new FieldEnemy(){enemyName = "GlassedSun_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = Either(Shore.RandomShoreTwoSizeBigGuy(), Garden.RandomTwoSizeFag()), enemySlot=2},
                    new FieldEnemy(){enemyName = Either(Either(RandomSupport(2, false, false), RandomSupport(1, false, false)), Either(GreyScaleSupport(Half), RandomSupport(0, false, false))), enemySlot=4},
                    new FieldEnemy(){enemyName = Either(RandomColor(1), RandomColor(2)), enemySlot=0},
                });
                fields.Add(new FieldEnemy[]
                {
                    new FieldEnemy(){enemyName = "GlassedSun_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "GlassedSun_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=3},
                    new FieldEnemy(){enemyName = Shore.RandomShoreWhore(), enemySlot=4},
                    new FieldEnemy(){enemyName = Shore.RandomShoreBigGuy(), enemySlot=0},
                });
                fields.Add(new FieldEnemy[]
                {
                    new FieldEnemy(){enemyName = "GlassedSun_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "GlassedSun_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = Garden.RandomWhore(), enemySlot=3},
                    new FieldEnemy(){enemyName = OrphWhore(), enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                    new FieldEnemy(){enemyName = "GlassedSun_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "GlassedSun_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = RandomSupport(0, false, false), enemySlot=3},
                    new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=4},
                    new FieldEnemy(){enemyName = RandomSupport(2, false, false), enemySlot=0},
                });
                if (GreyScale)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "GlassedSun_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = Either(RandomColor(1), RandomColor(2)), enemySlot=4},
                    new FieldEnemy(){enemyName = Either(RandomOrph, Garden.RandomChunk()), enemySlot=0},
                    });
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "GlassedSun_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = Either(RandomSupport(1, false,false), RandomSupport(2, false, false)), enemySlot=4},
                    new FieldEnemy(){enemyName = Either(OrphWhore(), Shore.RandomShoreWhore()), enemySlot=0},
                    });
                }
            }
            jarden.variations = fields.ToArray();
            jarden.AddEncounter();
        }
    }
}
