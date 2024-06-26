﻿using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using static Hawthorne.RandomEncounters;
using static Hawthorne.Check;

namespace Hawthorne
{
    public static class MercedSong
    {
        public static void Add(int sign)
        {
            if (!EnemyExist("Merced_EN")) return;

            BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("MercedWorld.png"));

            GardHard(sign);
        }
        public static void GardHard(int sign)
        {
            BrutalAPI.EnemyEncounter jarden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "thepeopleofpaper",
                area = 2,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = UnityEngine.Random.Range(4, 6),
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/MercedSong",
                roarEvent = "event:/Hawthorne/Attack2/Rainy",
                difficulty = EncounterDifficulty.Hard
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("Merced_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=4},
                });
            }
            if (MultiENExist("ImpenetrableAngler_EN", "TitteringPeon_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ImpenetrableAngler_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=4},
                });
            }
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=4},
            });
            if (MultiENExist("Romantic_EN", "Skyloft_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=4},
                });
            }
            if (EnemyExist("Indicator_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Indicator_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=4},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=0},
                });
            }
            if (MultiENExist("EyePalm_EN", "Miriam_EN", "Shua_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=4},
                });
            }
            if (MultiENExist("Grandfather_EN", "Indicator_EN", "Skyloft_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Indicator_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=4},
                });
            }
            if (Flowering)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=4},
                });
            }
            if (Botting)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "RedBot_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "BlueBot_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "YellowBot_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "PurpleBot_EN", enemySlot=4},
                });
            }
            if (EnemyExist("Maw_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Maw_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=4},
                });
            }
            if (MultiENExist("FrowningChancellor_EN", "TitteringPeon_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FrowningChancellor_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=3},
                });
            }
            if (MultiENExist("MortalSpoggle_EN", "StarGazer_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MortalSpoggle_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "StarGazer_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "StarGazer_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "StarGazer_EN", enemySlot=4},
                });
            }
            if (EnemyExist("LittleAngel_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=4},
                });
            }
            if (EnemyExist("Maw_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Maw_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=4},
                });
            }
            if (MultiENExist("MiniReaper_EN", "BlackStar_EN", "EggKeeper_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "BlackStar_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "BlackStar_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=4},
                });
            }
            if (MultiENExist("Clione_EN", "TitteringPeon_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Clione_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=4},
                });
            }
            if (MultiENExist("FrowningChancellor_EN", "EggKeeper_EN", "YNL_EN", "LittleAngel_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FrowningChancellor_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "YNL_EN", enemySlot=4},
                });
            }
            if (EnemyExist("MechanicalLens_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=4},
                });
            }
            if (MultiENExist("FrowningChancellor_EN", "LivingSolvent_EN", "ScreamingHomunculus_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ScreamingHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FrowningChancellor_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=3},
                });
            }
            if (MultiENExist("WindSong_EN", "Indicator_EN", "Shua_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Indicator_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=4},
                });
            }
            if (MultiENExist("WindSong_EN", "MarbleMaw_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MarbleMaw_EN", enemySlot=2},
                new FieldEnemy(){enemyName = Garden.RandomWhore(true), enemySlot=3},
                new FieldEnemy(){enemyName = "MarbleMaw_EN", enemySlot=4},
                });
            }
            if (MultiENExist("PurpleFlower_EN", "TitteringPeon_EN", "MechanicalLens_EN", "LivingSolvent_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=4},
                });
            }
            if (EnemyExist("WindSong_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=4},
                });
            }
            if (EnemyExist("EggKeeper_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=4},
                });
            }
            if (MultiENExist("StalwartTortoise_EN", "TripodFish_EN", "MechanicalLens_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=4},
                });
            }
            if (MultiENExist("GlassFigurine_EN", "Damocles_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "GlassFigurine_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Damocles_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=3},
                new FieldEnemy(){enemyName = Garden.RandomWhore(), enemySlot=4},
                });
            }
            if (MultiENExist("Metatron_EN", "Grandfather_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Metatron_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=4},
                });
            }
            if (MultiENExist("Maw_EN", "YNL_EN", "Shua_EN", "Hunter_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "YNL_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Maw_EN", enemySlot=4},
                });
            }
            if (MultiENExist("Firebird_EN", "Clione_EN", "Children6_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Children6_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Clione_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=4},
                });
            }
            if (MultiENExist("Firebird_EN", "LivingSolvent_EN", "LittleAngel_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=4},
                });
            }
            if (EnemyExist("MiniReaper_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=2},
                new FieldEnemy(){enemyName = Garden.RandomWhore(true), enemySlot=3},
                new FieldEnemy(){enemyName = Garden.RandomWhore(), enemySlot=4},
                });
            }
            if (MultiENExist("FrowningChancellor_EN", "TheCrow_EN", "BlueFlower_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FrowningChancellor_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=3},
                new FieldEnemy(){enemyName = Garden.RandomWhore(), enemySlot=4},
                });
            }
            if (MultiENExist("Romantic_EN", "MortalSpoggle_EN", "ScreamingHomunculus_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MortalSpoggle_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "ScreamingHomunculus_EN", enemySlot=4},
                });
            }
            if (MultiENExist("RusticJumbleguts_EN", "Maw_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "RusticJumbleguts_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Maw_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=4},
                });
            }
            if (MultiENExist("RealisticTank_EN", "Children6_EN", "FakeAngel_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Children6_EN", enemySlot=4},
                });
            }
            jarden.variations = fields.ToArray();
            jarden.AddEncounter();
        }
    }
    public static class CrystalSong
    {
        public static int mod
        {
            get
            {
                //return 999;
                switch (DateTime.Now.Month)
                {
                    case 12: return 2;
                    case 11: return 1;
                    case 10: return 1;
                    case 1: return 1;
                    case 2: return 1;
                    case 3: return 1;
                    default: return 0;
                }
            }
        }
        public static void Add(int sign)
        {
            if (!EnemyExist("Crystal_EN")) return;

            BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("CrystalWorld.png"));

            OrphMed(sign);
            OrphHard(sign);
        }
        public static void OrphMed(int sign)
        {
            BrutalAPI.EnemyEncounter orph = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "ChristmasMed",
                area = 1,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = UnityEngine.Random.Range(10, 20) * mod,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/CrystalSong",
                roarEvent = "event:/Hawthorne/Noise/CrystalRoar",
                difficulty = EncounterDifficulty.Medium
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("Crystal_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Crystal_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=4},
                });
            }
            if (EnemyExist("BackupDancer_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Crystal_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "BackupDancer_EN", enemySlot=3},
                });
            }
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "Crystal_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
            });
            for (int i = 0; i < 3; i++)
            {
                string e = RandomOrph;
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Crystal_EN", enemySlot=1},
                new FieldEnemy(){enemyName = e, enemySlot=2},
                new FieldEnemy(){enemyName = Either(e, RandomOrph), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Crystal_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Crystal_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=3},
                });
                string b = RandomOrph;
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Crystal_EN", enemySlot=1},
                new FieldEnemy(){enemyName = b, enemySlot=2},
                new FieldEnemy(){enemyName = Either(b, RandomOrph), enemySlot=3},
                new FieldEnemy(){enemyName = Either(RandomSupport(1), "CandyStone_EN"), enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Crystal_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                new FieldEnemy(){enemyName = OrphWhore(), enemySlot=3},
                });
            }

            orph.variations = fields.ToArray();
            orph.AddEncounter();
        }
        public static void OrphHard(int sign)
        {
            BrutalAPI.EnemyEncounter orph = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "ChristmasHard",
                area = 1,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = UnityEngine.Random.Range(10, 15) * mod,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/CrystalSong",
                roarEvent = "event:/Hawthorne/Noise/CrystalRoar",
                difficulty = EncounterDifficulty.Hard
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("Crystal_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Crystal_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Crystal_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=4},
                });
            }
            if (EnemyExist("BackupDancer_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Crystal_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "BackupDancer_EN", enemySlot=4},
                });
            }
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "Crystal_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=4},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=5},
            });
            for (int i = 0; i < 3; i++)
            {
                string e = RandomOrph;
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Crystal_EN", enemySlot=1},
                new FieldEnemy(){enemyName = e, enemySlot=2},
                new FieldEnemy(){enemyName = Either(e, RandomOrph), enemySlot=3},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=4},
                });
                string r = RandomOrph;
                ResetColor();
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Crystal_EN", enemySlot=1},
                new FieldEnemy(){enemyName = r, enemySlot=2},
                new FieldEnemy(){enemyName = SmartColor(1, true), enemySlot=3},
                new FieldEnemy(){enemyName = Either(Either(r, RandomOrph), SmartColor(1)), enemySlot=4},
                });
                ResetColor();
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Crystal_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=3},
                new FieldEnemy(){enemyName = OrphWhore(), enemySlot=4},
                });
                string b = RandomOrph;
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Crystal_EN", enemySlot=1},
                new FieldEnemy(){enemyName = b, enemySlot=2},
                new FieldEnemy(){enemyName = Either(b, RandomOrph), enemySlot=3},
                new FieldEnemy(){enemyName = Either(b, RandomOrph), enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Crystal_EN", enemySlot=1},
                new FieldEnemy(){enemyName = OrphWhore(), enemySlot=2},
                new FieldEnemy(){enemyName = OrphWhore(), enemySlot=3},
                });
            }

            orph.variations = fields.ToArray();
            orph.AddEncounter();
        }
    }
    public static class DragonSong
    {
        public static void Add(int sign)
        {
            if (!EnemyExist("TheDragon_EN")) return;

            BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("DragonWorld.png"));

            OrphHard(sign);
        }
        public static void OrphHard(int sign)
        {
            BrutalAPI.EnemyEncounter orph = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "Rawr_XD",
                area = 1,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = UnityEngine.Random.Range(10, 20) * 1,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/DragonSong",
                roarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Flarb_Hard_EnemyBundle")._roarReference.roarEvent,
                difficulty = EncounterDifficulty.Hard
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("TheDragon_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheDragon_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                });
            }
            for (int i = 0; i < 3; i++)
            {
                string e = RandomOrph;
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheDragon_EN", enemySlot=0},
                new FieldEnemy(){enemyName = e, enemySlot=2},
                new FieldEnemy(){enemyName = Either(e, RandomOrph), enemySlot=3},
                });
                string r = RandomOrph;
                ResetColor();
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheDragon_EN", enemySlot=1},
                new FieldEnemy(){enemyName = SmartColor(1, true), enemySlot=3},
                new FieldEnemy(){enemyName = Either(Either(r, RandomOrph), SmartColor(1)), enemySlot=4},
                });
                ResetColor();
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheDragon_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=3},
                new FieldEnemy(){enemyName = OrphWhore(), enemySlot=4},
                });
                string b = RandomOrph;
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheDragon_EN", enemySlot=1},
                new FieldEnemy(){enemyName = b, enemySlot=2},
                new FieldEnemy(){enemyName = Either(RandomSupport(1, false, false), Either(b, RandomOrph)), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheDragon_EN", enemySlot=1},
                new FieldEnemy(){enemyName = OrphWhore(), enemySlot=2},
                });
            }
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "TheDragon_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=3},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=4},
            });

            orph.variations = fields.ToArray();
            orph.AddEncounter();
        }
    }
    public static class OdeSong
    {
        public static void Add(int sign)
        {
            if (!EnemyExist("OdetoHumanity_EN")) return;

            BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("VaseWorld.png"));

            GardenMed(sign);
        }
        public static void GardenMed(int sign)
        {
            BrutalAPI.EnemyEncounter orph = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "OldForestLord",
                area = 2,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = UnityEngine.Random.Range(10, 20) * 1,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/VaseSong",
                roarEvent = "event:/Hawthorne/Noise/Ominous",
                difficulty = EncounterDifficulty.Medium
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("OdetoHumanity_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "OdetoHumanity_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=3},
                });
            }
            for (int i = 0; i < 3; i++)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "OdetoHumanity_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Garden.RandomChunk(), enemySlot=2},
                new FieldEnemy(){enemyName = Garden.RandomChunk(false, true), enemySlot=3},
                });
                ResetColor();
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "OdetoHumanity_EN", enemySlot=1},
                new FieldEnemy(){enemyName = SmartColor(2, true), enemySlot=3},
                new FieldEnemy(){enemyName = Either(Garden.RandomWhore(), SmartColor(2)), enemySlot=4},
                });
                ResetColor();
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "OdetoHumanity_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(2, false, false), enemySlot=3},
                new FieldEnemy(){enemyName = Garden.RandomWhore(), enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "OdetoHumanity_EN", enemySlot=1},
                new FieldEnemy(){enemyName = Garden.RandomChunk(), enemySlot=2},
                new FieldEnemy(){enemyName = Either(RandomColor(2), RandomSupport(2, false, false)), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "OdetoHumanity_EN", enemySlot=1},
                new FieldEnemy(){enemyName = Garden.RandomWhore(), enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "OdetoHumanity_EN", enemySlot=1},
                new FieldEnemy(){enemyName = Garden.RandomChunk(), enemySlot=3},
                new FieldEnemy(){enemyName = Garden.RandomWhore(), enemySlot=4},
                });
            }
            orph.variations = fields.ToArray();
            orph.AddEncounter();
        }
    }
    public static class PaleSong
    {
        public static void Add(int sign)
        {
            if (!EnemyExist("LittleAngel_EN")) return;

            BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("Angel_Icon.png"));

            GardEZ(sign);
        }
        public static void GardEZ(int sign)
        {
            BrutalAPI.EnemyEncounter jarden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "LittleAngelEasy",
                area = 2,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = UnityEngine.Random.Range(8,12),
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/PaleSong",
                roarEvent = LoadedAssetsHandler.GetCharcater("Hans_CH").dxSound,
                difficulty = EncounterDifficulty.Easy
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("LittleAngel_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=3},
                });
            }
            for (int i = 0; i < 3; i++)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = Garden.RandomChunk(), enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(2, false, false), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(2, false, false), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = Garden.RandomChunk(), enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = Garden.RandomChunk(), enemySlot=2},
                new FieldEnemy(){enemyName = RandomColor(2), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(2), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(2), enemySlot=3},
                new FieldEnemy(){enemyName = RandomSupport(2, false, false), enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = Garden.RandomChunk(), enemySlot=2},
                new FieldEnemy(){enemyName = Garden.RandomChunk(false, true), enemySlot=3},
                });
                ResetColor();
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = SmartColor(2, true), enemySlot=2},
                new FieldEnemy(){enemyName = SmartColor(2), enemySlot=3},
                });
                ResetColor();
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(2, false, false), enemySlot=3},
                new FieldEnemy(){enemyName = RandomSupport(2, false, Half), enemySlot=4},
                });
            }
            jarden.variations = fields.ToArray();
            jarden.AddEncounter();
        }
    }
    public static class GlassSong
    {
        public static void Add(int sign)
        {
            if (!EnemyExist("GlassFigurine_EN")) return;

            BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("GlassIcon.png"));

            GardEZ(sign);
        }
        public static void GardEZ(int sign)
        {
            BrutalAPI.EnemyEncounter jarden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "howyoumoveaboutthescenehowyoutwisthowyouturn",
                area = 2,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = 2,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/GlassSong",
                roarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone02_JumbleGuts_Hollowing_Medium_EnemyBundle")._roarReference.roarEvent,
                difficulty = EncounterDifficulty.Easy
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("GlassFigurine_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "GlassFigurine_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=3},
                });
            }
            if (EnemyExist("GlassFigurine_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "GlassFigurine_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Merced_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "GlassFigurine_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=4},
                });
            }
            if (EnemyExist("TheCrow_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "GlassFigurine_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=2},
                });
            }
            if (EnemyExist("BlackStar_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "GlassFigurine_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "BlackStar_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "BlackStar_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Windle2_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "GlassFigurine_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Windle2_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                });
            }
            jarden.variations = fields.ToArray();
            jarden.AddEncounter();
        }
    }
    public static class WindleSong
    {
        public static void Add(int sign)
        {
            if (!EnemyExist("Windle1_EN")) return;

            BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("WindleWorld.png"));

            WindleEZ(sign);
            WindleMed(sign);
        }
        public static void WindleEZ(int sign)
        {
            BrutalAPI.EnemyEncounter jarden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "WindleEZ",
                area = 0,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = UnityEngine.Random.Range(3, 6),
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/WindleSong",
                roarEvent = LoadedAssetsHandler.GetCharcater("Doll_CH").deathSound,
                difficulty = EncounterDifficulty.Easy
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("Windle1_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Windle1_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=3},
                });
            }
            for (int i = 0; i < 3; i++)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Windle1_EN", enemySlot=1},
                new FieldEnemy(){enemyName = ShoreSlop(Half), enemySlot=2},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Windle1_EN", enemySlot=1},
                new FieldEnemy(){enemyName = Either(RandomSupport(0, false, false), RandomShoreMidget(false)), enemySlot=2},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Windle1_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=2},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Windle1_EN", enemySlot=1},
                new FieldEnemy(){enemyName = ShoreSlop(Half), enemySlot=2},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=3},
                new FieldEnemy(){enemyName = Either(RandomSupport(0), RandomShoreMidget(false)), enemySlot=4},
                });
            }
            jarden.variations = fields.ToArray();
            jarden.AddEncounter();
        }
        public static void WindleMed(int sign)
        {
            BrutalAPI.EnemyEncounter jarden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "WindleMed",
                area = 0,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = UnityEngine.Random.Range(3, 9),
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/WindleSong",
                roarEvent = LoadedAssetsHandler.GetCharcater("Doll_CH").deathSound,
                difficulty = EncounterDifficulty.Medium
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("Windle1_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Windle1_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=4},
                });
            }
            for (int i = 0; i < 3; i++)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Windle1_EN", enemySlot=1},
                new FieldEnemy(){enemyName = ShoreSlop(Half), enemySlot=2},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=3},
                new FieldEnemy(){enemyName = Either(RandomSupport(0, false, false), RandomColor(0)), enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Windle1_EN", enemySlot=1},
                new FieldEnemy(){enemyName = Either(RandomSupport(0), RandomShoreMidget(false)), enemySlot=2},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=3},
                new FieldEnemy(){enemyName = Shore.RandomShoreWhore(), enemySlot=4},
                });
                ResetColor();
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Windle1_EN", enemySlot=1},
                new FieldEnemy(){enemyName = SmartColor(0, true), enemySlot=2},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=3},
                new FieldEnemy(){enemyName = SmartColor(0), enemySlot=4},
                });
                ResetColor();
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Windle1_EN", enemySlot=1},
                new FieldEnemy(){enemyName = ShoreSlop(Half), enemySlot=2},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=3},
                new FieldEnemy(){enemyName = RandomSupport(0, false, false), enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Windle1_EN", enemySlot=1},
                new FieldEnemy(){enemyName = Shore.RandomShoreWhore(), enemySlot=2},
                new FieldEnemy(){enemyName = ShoreSlop(), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Windle1_EN", enemySlot=1},
                new FieldEnemy(){enemyName = Shore.RandomShoreWhore(), enemySlot=2},
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=3},
                });
            }
            jarden.variations = fields.ToArray();
            jarden.AddEncounter();
        }
    }
}
