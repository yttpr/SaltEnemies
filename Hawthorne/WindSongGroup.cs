using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using static Hawthorne.Check;
using static Hawthorne.RandomEncounters;

namespace Hawthorne
{
    public static class WindSongGroup
    {
        public static void Add(int sign)
        {
            if (!EnemyExist("WindSong_EN")) return;

            BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("WindSongWorld.png"));

            OrphMed(sign);
        }
        public static void OrphMed(int sign)
        {
            BrutalAPI.EnemyEncounter jarden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "SongOfTheWindInTheOrpheum",
                area = 1,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = 10,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/WindSongTheme",
                roarEvent = "event:/Hawthorne/HissingNoise",
                difficulty = EncounterDifficulty.Medium
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("WindSong_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=4},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Conductor_EN", enemySlot=1},
                });
            if (EnemyExist("WindSong_EN"))
            {
                string en = RandomOrph;
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=0},
                new FieldEnemy(){enemyName = en, enemySlot=1},
                new FieldEnemy(){enemyName = en, enemySlot=2},
                });
            }
            if (EnemyExist("WindSong_EN"))
            {
                for (int i = 0; i < 3; i++)
                {
                    ResetColor();
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = RandomOrph, enemySlot=1},
                    new FieldEnemy(){enemyName = SmartColor(1, true), enemySlot=2},
                    new FieldEnemy(){enemyName = SmartColor(1), enemySlot=3},
                    });
                    ResetColor();
                }
            }
            if (EnemyExist("Warbird_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=1},
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=2},
                });
            }
            if (EnemyExist("FumeFactory_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=1},
                new FieldEnemy(){enemyName = "FumeFactory_EN", enemySlot=2},
                });
            }
            if (EnemyExist("LivingSolvent_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=1},
                new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Romantic_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=1},
                new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Seraphim_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=1},
                new FieldEnemy(){enemyName = "Seraphim_EN", enemySlot=2},
                });
            }
            if (EnemyExist("MechanicalLens_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=1},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=3},
                });
            }
            if (GreyScale)
            {
                for (int i = 0; i < 5; i++)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    });
                }
            }
            if (BirdScale)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=2},
                });
            }
            jarden.variations = fields.ToArray();
            jarden.CheckEncounters();
            jarden.AddEncounter();
        }
    }
    public static class SolventGroup
    {
        public static void Add(int sign)
        {
            if (!EnemyExist("LivingSolvent_EN")) return;

            BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("SolventPortal.png"));

            OrphEZ(sign);
        }
        public static void OrphEZ(int sign)
        {
            BrutalAPI.EnemyEncounter jarden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "YouShouldExplode...NOW",
                area = 1,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = UnityEngine.Random.Range(5, 11),
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/SolventTheme",
                roarEvent = LoadedAssetsHandler.GetEnemy("WrigglingSacrifice_EN").damageSound,
                difficulty = EncounterDifficulty.Easy
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("LivingSolvent_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=1},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=4},
                });
            }
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=2},
            });
            if (GreyScale)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                });
            }
            if (EnemyExist("WindSong_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RainBaseWeighted(true, false), enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RainBaseWeighted(false, false), enemySlot=2},
                });
            }
            if (EnemyExist("Enigma_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=4},
                });
            }
            if (EnemyExist("Skyloft_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                });
            }
            if (EnemyExist("LostSheep_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=4},
                });
            }
            for (int i = 0; i < 3; i++)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=2},
                });
            }
            jarden.variations = fields.ToArray();
            jarden.CheckEncounters();
            jarden.AddEncounter();
        }
    }
    public static class SkyloftGroup
    {
        public static void Add(int sign)
        {
            if (!EnemyExist("Skyloft_EN")) return;

            BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("SkyloftPortal.png"));

            SHoreMed(sign);
        }
        public static void SHoreMed(int sign)
        {
            BrutalAPI.EnemyEncounter jarden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "SkyIsABedForMySleepButIDontCareItsGotStarsForNightstands",
                area = 0,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = UnityEngine.Random.Range(4, 9),
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/SkyloftSong",
                roarEvent = LoadedAssetsHandler.GetCharcater("Mordrake_CH").dxSound,
                difficulty = EncounterDifficulty.Medium
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("Skyloft_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=4},
                });
            }
            if (EnemyExist("LittleBeak_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MunglingMudLung_EN", enemySlot=4},
                });
            }
            if (EnemyExist("LittleBeak_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FlaMinGoa_EN", enemySlot=4},
                });
            }
            if (EnemyExist("A'Flower'_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MunglingMudLung_EN", enemySlot=4},
                });
            }
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomShoreMidget(), enemySlot=1},
                new FieldEnemy(){enemyName = RandomShoreMidget(), enemySlot=2},
                new FieldEnemy(){enemyName = "FlaMinGoa_EN", enemySlot=4},
            });
            if (EnemyExist("Lurchin_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lurchin_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=4},
                });
            }
            for (int i = 0; i < 3; i++)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=1},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=4},
                });
            }
            jarden.variations = fields.ToArray();
            jarden.CheckEncounters();
            jarden.AddEncounter();
        }
    }
    public static class ButterflyGroup
    {
        public static void Add(int sign)
        {
            if (!EnemyExist("Butterfly_EN")) return;

            BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("ButterflyWorld.png"));

            gardEZ(sign);
        }
        public static void gardEZ(int sign)
        {
            BrutalAPI.EnemyEncounter jarden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "SpectralWitchFamiliar",
                area = 2,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = UnityEngine.Random.Range(2, 5),
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/ButterflyTheme",
                roarEvent = "",
                difficulty = EncounterDifficulty.Easy
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("Butterfly_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=4},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=3},
                });
            if (EnemyExist("Romantic_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=4},
                });
            }
            if (EnemyExist("Skyloft_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=4},
                });
            }
            if (EnemyExist("EggKeeper_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=4},
                });
            }
            if (EnemyExist("LittleAngel_EN"))
            {
                string e = "ChoirBoy_EN"; if (EnemyExist("Romantic_EN")) e = "Romantic_EN";
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=2},
                new FieldEnemy(){enemyName = e, enemySlot=3},
                new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=4},
                });
            }
            if (MultiENExist("Merced_EN", "WindSong_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=4},
                });
            }
            if (MultiENExist("DeadPixel_EN", "MortalSpoggle_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MortalSpoggle_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=4},
                });
            }
            if (Flowering)
            {
                string ao = Flowers.GetRandom();
                string ai = Flowers.Exclude(ao).GetRandom();
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=2},
                new FieldEnemy(){enemyName = ao, enemySlot=3},
                new FieldEnemy(){enemyName = ai, enemySlot=4},
                });
            }
            if (EnemyExist("Unterling_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Unterling_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Unterling_EN", enemySlot=4},
                });
            }
            jarden.variations = fields.ToArray();
            jarden.CheckEncounters();
            jarden.AddEncounter();
        }
    }
    public static class GrandfatherGroup
    {
        public static void Add(int sign)
        {
            if (!EnemyExist("Grandfather_EN")) return;

            BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("CoffinWorld.png"));

            GardMed(sign);
        }
        public static void GardMed(int sign)
        {
            BrutalAPI.EnemyEncounter jarden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "GETMEOUTOFHERE",
                area = 2,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = 8,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/NewCoffinTheme",
                roarEvent = LoadedAssetsHandler.GetEnemy("Visage_MyOwn_EN").deathSound,
                difficulty = EncounterDifficulty.Medium
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("Grandfather_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=4},
                });
            }
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
            });
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=3},
            });
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=3},
            });
            if (EnemyExist("WindSong_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=3},
                });
            }
            if (EnemyExist("LivingSolvent_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=3},
                });
            }
            if (EnemyExist("MiniReaper_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Skyloft_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=2},
                });
            }
            if (EnemyExist("EggKeeper_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Romantic_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Damocles_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Damocles_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                });
            }
            if (EnemyExist("ScreamingHomunculus_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ScreamingHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                });
            }
            if (EnemyExist("TitteringPeon_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                });
            }
            if (EnemyExist("TheCrow_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Hunter_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Shua_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Sigil_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=3},
                });
            }
            if (EnemyExist("EyePalm_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=3},
                });
            }
            if (EnemyExist("LittleAngel_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=2},
                });
            }
            if (Flowering)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=3},
                });
            }
            if (EnemyExist("MortalSpoggle_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MortalSpoggle_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                });
            }
            if (EnemyExist("SterileBud_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Unterling_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Unterling_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=2},
                });
            }
            jarden.variations = fields.ToArray();
            jarden.CheckEncounters();
            jarden.AddEncounter();
        }
    }
    public static class ReaperGroup
    {
        public static void Add(int sign)
        {
            if (!EnemyExist("MiniReaper_EN")) return;

            BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("ReaperWorld.png"));

            GardMed(sign);
        }
        public static void GardMed(int sign)
        {
            BrutalAPI.EnemyEncounter jarden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "DIEDIEDIE",
                area = 2,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = 5,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/ReaperTheme",
                roarEvent = LoadedAssetsHandler.GetEnemyAbility("FlayTheFlesh_A").visuals.audioReference,
                difficulty = EncounterDifficulty.Medium
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("MiniReaper_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=4},
                });
            }
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
            });
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=3},
            });
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=3},
            });
            if (EnemyExist("WindSong_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=3},
                });
            }
            if (EnemyExist("LivingSolvent_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Grandfather_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Skyloft_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                });
            }
            if (EnemyExist("EggKeeper_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Romantic_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Damocles_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Damocles_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                });
            }
            if (EnemyExist("ScreamingHomunculus_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ScreamingHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                });
            }
            if (EnemyExist("TitteringPeon_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                });
            }
            if (EnemyExist("TheCrow_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Hunter_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Shua_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Sigil_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=3},
                });
            }
            if (EnemyExist("EyePalm_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=3},
                });
            }
            if (EnemyExist("LittleAngel_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                });
            }
            if (Flowering)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=3},
                });
            }
            if (EnemyExist("MortalSpoggle_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MortalSpoggle_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                });
            }
            if (EnemyExist("SterileBud_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Unterling_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Unterling_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=2},
                });
            }
            jarden.variations = fields.ToArray();
            jarden.CheckEncounters();
            jarden.AddEncounter();
        }
    }
    public static class ShuaGroup
    {
        public static void Add(int sign)
        {
            if (!EnemyExist("Shua_EN")) return;

            BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("ShuaWorld.png"));

            gardEZ(sign);
            GardMed(sign);
        }
        public static void gardEZ(int sign)
        {
            BrutalAPI.EnemyEncounter jarden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "LeaveMeAlone",
                area = 2,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = 4,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/NewerShuaTheme",
                roarEvent = "event:/Hawthorne/Attack3/Censored",
                difficulty = EncounterDifficulty.Easy
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("Shua_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=4},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                });
            if (EnemyExist("EyePalm_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Enigma_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Merced_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Butterfly_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=3},
                });
            }
            if (EnemyExist("DeadPixel_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                });
            }
            if (Flowering)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=2},
                new FieldEnemy(){enemyName = Flowers.GetRandom(), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=1},
                new FieldEnemy(){enemyName = Flowers.GetRandom(), enemySlot=3},
                });
            }
            if (EnemyExist("WindSong_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                });
            }
            if (EnemyExist("LivingSolvent_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                });
            }
            if (EnemyExist("EggKeeper_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                });
            }
            if (EnemyExist("MiniReaper_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Skyloft_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Romantic_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                });
            }
            if (EnemyExist("TitteringPeon_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Unterling_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Unterling_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Unterling_EN", enemySlot=2},
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
                encounterName = "CensoredForYourViewingPleasure",
                area = 2,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = UnityEngine.Random.Range(8, 14),
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/NewerShuaTheme",
                roarEvent = "event:/Hawthorne/Attack3/Censored",
                difficulty = EncounterDifficulty.Medium
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("Shua_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=4},
                });
            }
            for (int i = 0; i < 3; i++)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Garden.RandomChunk(), enemySlot=1},
                new FieldEnemy(){enemyName = Garden.RandomChunk(false, Half), enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(2, false, false), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Garden.RandomChunk(), enemySlot=1},
                new FieldEnemy(){enemyName = Garden.RandomChunk(false, true), enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Garden.RandomChunk(), enemySlot=1},
                new FieldEnemy(){enemyName = Garden.RandomChunk(false, Half), enemySlot=2},
                new FieldEnemy(){enemyName = RandomColor(2), enemySlot=3},
                });
                ResetColor();
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=0},
                new FieldEnemy(){enemyName = SmartColor(2, true), enemySlot=1},
                new FieldEnemy(){enemyName = SmartColor(2), enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(2, false, false), enemySlot=3},
                });
                ResetColor();
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=0},
                new FieldEnemy(){enemyName = SmartColor(2, true), enemySlot=1},
                new FieldEnemy(){enemyName = SmartColor(2), enemySlot=2},
                });
                ResetColor();
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Garden.RandomChunk(), enemySlot=1},
                new FieldEnemy(){enemyName = Garden.RandomWhore(), enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomColor(2), enemySlot=1},
                new FieldEnemy(){enemyName = Garden.RandomWhore(), enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomSupport(2, false, false), enemySlot=1},
                new FieldEnemy(){enemyName = Garden.RandomWhore(), enemySlot=2},
                });
            }
            jarden.variations = fields.ToArray();
            jarden.CheckEncounters();
            jarden.AddEncounter();
        }
    }
}
