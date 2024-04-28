using BrutalAPI;
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
}
