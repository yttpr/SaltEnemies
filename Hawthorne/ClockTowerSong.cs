using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using static Hawthorne.Check;

namespace Hawthorne
{
    public static class ClockTowerSong
    {
        public static void Add(int sign)
        {
            if (!EnemyExist("ClockTower_EN")) return;

            BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("ClockTowerPortal.png"));

            GardHard(sign);
        }

        public static int rarity
        {
            get
            {
                int ret = UnityEngine.Random.Range(5, 11);
                if (SaltEnemies.trolling == 63) ret += 5;
                ret *= SaltEnemies.silly;
                ret /= 30;
                ret *= 2;
                return ret;
            }
        }

        public static void GardHard(int sign)
        {
            BrutalAPI.EnemyEncounter jarden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "ITSTIME",
                area = 2,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = rarity,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/ClockTheme",
                roarEvent = LoadedAssetsHandler.GetCharcater("Doll_CH").deathSound,
                difficulty = EncounterDifficulty.Hard
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            //bosch sets +49 total
            //images set +10
            if (EnemyExist("ClockTower_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=4},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=4},
                });
            if (EnemyExist("TitteringPeon_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                });
            }
            if (EnemyExist("MiniReaper_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                });
            }
            if (EnemyExist("EggKeeper_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=4},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=4},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                });
            if (Flowering)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=4},
                });
            }
            if (EnemyExist("SterileBud_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Grandfather_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=3},
                });
            }
            //homunculi set +10
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=3},
                });
            if (EnemyExist("ScreamingHomunculus_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ScreamingHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=4},
                });
            }
            if (MultiENExist("ScreamingHomunculus_EN", "TitteringPeon_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ScreamingHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=3},
                });
            }
            if (EnemyExist("MiniReaper_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=4},
                });
            }
            if (EnemyExist("EggKeeper_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=4},
                });
            }
            if (EnemyExist("Damocles_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Damocles_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=4},
                });
            }
            if (EnemyExist("WindSong_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=4},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=2},
                });
            if (EnemyExist("Harbinger_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Harbinger_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Harbinger_EN", enemySlot=3},
                });
            }
            //minister set +8
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=4},
                });
            if (EnemyExist("Skyloft_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=3},
                });
            }
            if (EnemyExist("StalwartTortoise_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            }
            if (EnemyExist("ImpenetrableAngler_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ImpenetrableAngler_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Metatron_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Metatron_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Unterling_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Unterling_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Unterling_EN", enemySlot=4},
                });
            }
            if (EnemyExist("GlassFigurine_EN") && SaltEnemies.trolling == 78)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "GlassFigurine_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=4},
                });
            }
            //choir boy set +3
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=2},
                });
            if (Flowering)
            {

                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=3},
                });
            }
            if (MultiENExist("SterileBud_EN", "Sigil_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=3},
                });
            }
            //bud set +2
            if (EnemyExist("SterileBud_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                });
            }
            if (MultiENExist("SterileBud_EN", "LittleAngel_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=3},
                });
            }
            //satyr set +3
            if (EnemyExist("Satyr_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Satyr_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Satyr_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Satyr_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                });
            }
            if (MultiENExist("Satyr_EN", "WindSong_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Satyr_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=4},
                });
            }
            //eyepalm set +3
            if (EnemyExist("EyePalm_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=4},
                });
            }
            if (MultiENExist("EyePalm_EN", "MiniReaper_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=4},
                });
            }
            if (MultiENExist("EyePalm_EN", "EggKeeper_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=4},
                });
            }
            //iconoclast set +1
            if (EnemyExist("Iconoclast_EN") && SaltEnemies.trolling > 31)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Iconoclast_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=4},
                });
            }
            if (MultiENExist("Iconoclast_EN", "Shua_EN") && SaltEnemies.silly == 84)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Iconoclast_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=3},
                });
            }
            //angler set +3
            if (EnemyExist("ImpenetrableAngler_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ImpenetrableAngler_EN", enemySlot=3},
                });
            }
            if (MultiENExist("ImpenetrableAngler_EN", "Sigil_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ImpenetrableAngler_EN", enemySlot=3},
                });
            }
            if (MultiENExist("ImpenetrableAngler_EN", "LivingSolvent_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ImpenetrableAngler_EN", enemySlot=3},
                });
            }
            //tortoise set +3
            if (EnemyExist("StalwartTortoise_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            }
            if (MultiENExist("StalwartTortoise_EN", "EggKeeper_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            }
            if (MultiENExist("StalwartTortoise_EN", "Butterfly_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            }
            //gospel set +1
            if (EnemyExist("MortalSpoggle_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MortalSpoggle_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=3},
                });
            }
            //romantic +2
            if (EnemyExist("Romantic_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=4},
                });
            }
            //greyscale +50 total
            if (GreyScale)
            {
                //base greyscale +2
                if (EnemyExist("ClockTower_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                    });
                }
                fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    });
                //enigma set +2
                if (EnemyExist("Enigma_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=4},
                    });
                }
                if (EnemyExist("Enigma_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                    });
                }
                //dead pixel set +1
                if (EnemyExist("DeadPixel_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                    });
                }
                //bird set +3
                if (EnemyExist("TheCrow_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                    });
                }
                if (EnemyExist("Hunter_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                    });
                }
                if (EnemyExist("Firebird_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                    });
                }
                //rust set +1
                if (EnemyExist("RusticJumbleguts_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "RusticJumbleguts_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                    });
                }
                //camera set +3
                if (EnemyExist("MechanicalLens_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=4},
                    });
                }
                if (MultiENExist("MechanicalLens_EN", "Grandfather_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=4},
                    });
                }
                if (MultiENExist("MechanicalLens_EN", "WindSong_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                    });
                }
                //flower set +3
                if (Flowering)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=4},
                    });
                }
                if (Flowering && EnemyExist("RealisticTank_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=3},
                    });
                }
                if (Flowering && EnemyExist("Grandfather_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "GreyFlower_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                    });
                }
                //solvent set +2
                if (EnemyExist("LivingSolvent_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    });
                }
                if (MultiENExist("WindSong_EN", "LivingSolvent_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=2},
                    });
                }
                //wind song +4
                if (EnemyExist("WindSong_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                    });
                }
                if (MultiENExist("WindSong_EN", "Shua_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Shua_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                    });
                }
                if (MultiENExist("WindSong_EN", "Sigil_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                    });
                }
                if (EnemyExist("WindSong_EN") && Flowering)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                    });
                }
                //sigil +3
                if (EnemyExist("Sigil_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                    });
                }
                if (MultiENExist("Sigil_EN", "RealisticTank_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("Sigil_EN") && Flowering)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                    });
                }
                //tank +4
                if (EnemyExist("RealisticTank_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                    });
                }
                if (EnemyExist("RealisticTank_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=2},
                    });
                }
                if (MultiENExist("RealisticTank_EN", "Grandfather_EN") && Flowering)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=4},
                    });
                }
                if (EnemyExist("RealisticTank_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = GreyScaleRedSource(), enemySlot=1},
                    new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = GreyScaleSupport(), enemySlot=4},
                    });
                }
                //grandfather +2
                if (EnemyExist("Grandfather_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    });
                }
                if (MultiENExist("Grandfather_EN", "Enigma_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                    });
                }
                //skyoft +1
                if (EnemyExist("Skyloft_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                    });
                }
                //merced +4
                if (EnemyExist("Merced_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Merced_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                    });
                }
                if (MultiENExist("Merced_EN", "WindSong_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Merced_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                    });
                }
                if (MultiENExist("Merced_EN", "Shua_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Shua_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Merced_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                    });
                }
                if (MultiENExist("Merced_EN", "LivingSolvent_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Merced_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                    });
                }
                //butterfly +2
                if (EnemyExist("Butterfly_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                    });
                }
                if (EnemyExist("Butterfly_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=4},
                    });
                }
                //shua +3
                if (EnemyExist("Shua_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Shua_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                    });
                }
                if (MultiENExist("Shua_EN", "MechanicalLens_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Shua_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=4},
                    });
                }
                if (MultiENExist("Shua_EN", "DeadPixel_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Shua_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                    });
                }
                //nameless +1
                if (EnemyExist("Nameless_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Nameless_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                    });
                }
                //tripod +3
                if (EnemyExist("TripodFish_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                    });
                }
                if (EnemyExist("TripodFish_EN") && Flowering)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=4},
                    });
                }
                if (MultiENExist("TripodFish_EN", "TheCrow_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                    });
                }
                //glass +2
                if (MultiENExist("GlassFigurine_EN", "WindSong_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "GlassFigurine_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                    });
                }
                if (MultiENExist("GlassFigurine_EN", "LivingSolvent_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "GlassFigurine_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                    });
                }
                //romantic +1
                if (MultiENExist("Romantic_EN", "MechanicalLens_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=4},
                    });
                }
                //randomly generated +3
                fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = GreyScaleRedSource(), enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = GreyScaleSupport(), enemySlot=4},
                    });
                fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = GreyScaleRedSource(), enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = GreyScaleSupport(), enemySlot=4},
                    });
                fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = GreyScaleRedSource(), enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = GreyScaleSupport(), enemySlot=3},
                    new FieldEnemy(){enemyName = GreyScaleSupport(), enemySlot=4},
                    });
            }
            jarden.variations = fields.ToArray();
            jarden.CheckEncounters();
            jarden.AddEncounter();
        }
    }
    public static class TripodGroup
    {
        public static void Add(int sign)
        {
            if (!EnemyExist("TripodFish_EN")) return;

            BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("TripodWorld.png"));

            ShoreHardAsFuck(sign);
            GardMed(sign);
        }

        public static int rarity
        {
            get
            {
                int ret = UnityEngine.Random.Range(7, 12);
                if (SaltEnemies.trolling >= 21) ret += 5; else ret -= 3;
                if (SaltEnemies.silly > 78 || SaltEnemies.silly < 9) ret += 10; else ret -= 2;
                if (SaltEnemies.rando == 96) ret += 15; else ret -= 1;
                return ret;
            }
        }


        public static void ShoreHardAsFuck(int sign)
        {
            BrutalAPI.EnemyEncounter jarden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "tripodfish_hardasfuck_shore",
                area = 0,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = rarity / 2,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/NewTripodTheme",
                roarEvent = "event:/Hawthorne/Roar/ShuaRoar",
                difficulty = EncounterDifficulty.Hard
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("TripodFish_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Flarblet_EN", enemySlot=4},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "FlaMinGoa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MunglingMudLung_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Flarb_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MunglingMudLung_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Flarb_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FlaMinGoa_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Flarb_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FlaMinGoa_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Flarblet_EN", enemySlot=4},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Voboola_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Keko_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Keko_EN", enemySlot=4},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Voboola_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MunglingMudLung_EN", enemySlot=3},
                });
            if (EnemyExist("A'Flower'_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Voboola_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Spoggle_Ruminating_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Spoggle_Spitfire_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot=3},
                });
                if (Colophoning)
                {

                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = Colophon[1], enemySlot=1},
                    new FieldEnemy(){enemyName = "FlaMinGoa_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("Lymphropod_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Lymphropod_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Lymphropod_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot=3},
                    });
                }
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "JumbleGuts_Clotted_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "JumbleGuts_Clotted_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "JumbleGuts_Clotted_EN", enemySlot=3},
                });
            if (EnemyExist("Seraphim_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Seraphim_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Seraphim_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "JumbleGuts_Clotted_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Spoggle_Spitfire_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Seraphim_EN", enemySlot=3},
                });
            }
            if (Spligging)
            {

                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Flarb_EN", enemySlot=1},
                new FieldEnemy(){enemyName = Spligs.GetRandom(), enemySlot=3},
                new FieldEnemy(){enemyName = Spligs.GetRandom(), enemySlot=4},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MunglingMudLung_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MunglingMudLung_EN", enemySlot=3},
                });
            if (EnemyExist("DrySimian_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "DrySimian_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Spoggle_Spitfire_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "DrySimian_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Voboola_EN", enemySlot=2},
                });
                if (EnemyExist("Lurchin_EN"))
                {

                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "DrySimian_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Lurchin_EN", enemySlot=2},
                    });
                }
                if (EnemyExist("LipBug_EN"))
                {

                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "DrySimian_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "LipBug_EN", enemySlot=2},
                    });
                }
                if (EnemyExist("OsseousClad_EN"))
                {

                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "DrySimian_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=3},
                    });
                }
            }
            if (EnemyExist("Unflarb_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Unflarb_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "JumbleGuts_Waning_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Unflarb_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MunglingMudLung_EN", enemySlot=3},
                });
                if (EnemyExist("Flarbleft_EN"))
                {

                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Unflarb_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Flarbleft_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Flarbleft_EN", enemySlot=4},
                    });
                }
            }
            if (EnemyExist("Flarbleft_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Flarbleft_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Flarblet_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "FlaMinGoa_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Flarbleft_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Spoggle_Ruminating_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Voboola_EN", enemySlot=3},
                });
                if (Supporting)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Flarbleft_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Flarb_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=4},
                    });
                }
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "JumbleGuts_Waning_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FlaMinGoa_EN", enemySlot=3},
                });
            if (EnemyExist("LipBug_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LipBug_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=3},
                });
                if (EnemyExist("DrySimian_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "LipBug_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "DrySimian_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Spoggle_Spitfire_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("FesteringFaction_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "LipBug_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "FesteringFaction_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=3},
                    });
                }
                if (Supporting)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "LipBug_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=4},
                    });
                }
            }
            if (Spligging && EnemyExist("Unflarb_EN"))
            {

                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Unflarb_EN", enemySlot=1},
                new FieldEnemy(){enemyName = Spligs.GetRandom(), enemySlot=3},
                new FieldEnemy(){enemyName = Spligs.GetRandom(), enemySlot=4},
                });
            }
            if (Spligging && EnemyExist("OsseousClad_EN"))
            {

                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=3},
                new FieldEnemy(){enemyName = Spligs.GetRandom(), enemySlot=4},
                });
            }
            if (Spligging && EnemyExist("A'Flower'_EN"))
            {

                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MunglingMudLung_EN", enemySlot=3},
                new FieldEnemy(){enemyName = Spligs.GetRandom(), enemySlot=4},
                });
            }
            if (EnemyExist("Nephilim_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Nephilim_EN", enemySlot=1},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Nephilim_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "JumbleGuts_Waning_EN", enemySlot=2},
                });
                if (Colophoning)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Nephilim_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = Colophon.UpTo(2).GetRandom(), enemySlot=2},
                    new FieldEnemy(){enemyName = Colophon.UpTo(2).GetRandom(), enemySlot=4},
                    });
                }
                if (EnemyExist("Lurchin_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Nephilim_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Lurchin_EN", enemySlot=2},
                    });
                }
            }
            if (MultiENExist("A'Flower'_EN", "Lurchin_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lurchin_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot=3},
                });
            }
            if (MultiENExist("Lymphropod_EN", "Seraphim_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Seraphim_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Lymphropod_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Lymphropod_EN", enemySlot=3},
                });
            }
            if (BowSpogging && EnemyExist("OsseousClad_EN"))
            {

                for (int i = 0; i < 2; i++)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = BowSpogs.UpTo(3).GetRandom(), enemySlot=3},
                    new FieldEnemy(){enemyName = BowSpogs.UpTo(3).GetRandom(), enemySlot=4},
                    });
                }
            }
            if (BowSpogging && EnemyExist("LipBug_EN"))
            {

                for (int i = 0; i < UnityEngine.Random.Range(1, 3); i++)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "LipBug_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = BowSpogs[0], enemySlot=3},
                    new FieldEnemy(){enemyName = BowSpogs.UpTo(3).GetRandom(), enemySlot=4},
                    });
                }
            }
            if (BowGutsing && EnemyExist("Lurchin_EN"))
            {

                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lurchin_EN", enemySlot=1},
                new FieldEnemy(){enemyName = BowGuts.UpTo(3).GetRandom(), enemySlot=3},
                });
            }
            if (BowGutsing && Supporting)
            {

                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "JumbleGuts_Clotted_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=3},
                new FieldEnemy(){enemyName = BowGuts.UpTo(3).GetRandom(), enemySlot=4},
                });
            }
            if (EnemyExist("Monck_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MunglingMudLung_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Monck_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=2},
                new FieldEnemy(){enemyName = "Monck_EN", enemySlot=3},
                });
                if (Colophoning)
                {

                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = Colophon[1], enemySlot=1},
                    new FieldEnemy(){enemyName = "Monck_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = Colophon[0], enemySlot=3},
                    });
                }
                if (EnemyExist("ColossalSheo_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Monck_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "ColossalSheo_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Monck_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("FesteringFaction_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "FesteringFaction_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Monck_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("LipBug_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "FlaMinGoa_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "LipBug_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Monck_EN", enemySlot=3},
                    });
                }
            }
            if (MultiENExist("Monck_EN", "Flarbleft_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Flarbleft_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Monck_EN", enemySlot=3},
                });
            }
            if (MultiENExist("A'Flower'_EN", "Flarbleft_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Flarbleft_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Flarbleft_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot=3},
                });
            }
            if (BowSpogging)
            {

                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = BowSpogs[0], enemySlot=1},
                new FieldEnemy(){enemyName = BowSpogs.UpTo(3).GetRandom(), enemySlot=3},
                new FieldEnemy(){enemyName = BaseColor(false, false), enemySlot=4},
                });
            }
            if (EnemyExist("Teto_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Teto_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Teto_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Teto_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Teto_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Teto_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Flarb_EN", enemySlot=3},
                });
                if (Colophoning)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Teto_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = Colophon.UpTo(2).GetRandom(), enemySlot=2},
                    new FieldEnemy(){enemyName = "Teto_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = Colophon.UpTo(2).GetRandom(), enemySlot=4},
                    });
                }
                if (BowGutsing)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Teto_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = BowGuts.UpTo(3).GetRandom(), enemySlot=2},
                    new FieldEnemy(){enemyName = "Teto_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("Lymphropod_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Teto_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Teto_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Lymphropod_EN", enemySlot=3},
                    });
                }
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Flarb_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(0, false, false), enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "FlaMinGoa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(0, false, false), enemySlot=3},
                });
            if (EnemyExist("Disembodied_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Disembodied_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FlaMinGoa_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Disembodied_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RainBaseColor(true, false), enemySlot=2},
                new FieldEnemy(){enemyName = "JumbleGuts_Clotted_EN", enemySlot=3},
                });
                if (Spligging)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Disembodied_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = Spligs.GetRandom(), enemySlot=2},
                    new FieldEnemy(){enemyName = Spligs.GetRandom(), enemySlot=4},
                    });
                }
                if (EnemyExist("DrySimian_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "DrySimian_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Disembodied_EN", enemySlot=2},
                    });
                }
                if (EnemyExist("Unflarb_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Unflarb_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Disembodied_EN", enemySlot=3},
                    });
                }
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Voboola_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Disembodied_EN", enemySlot=3},
                });
            }
            if (MultiENExist("Disembodied_EN", "BoulderBuddy_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "BoulderBuddy_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Disembodied_EN", enemySlot=3},
                });
            }
            if (MultiENExist("Disembodied_EN", "Nephilim_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Nephilim_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Disembodied_EN", enemySlot=3},
                });
            }
            if (MultiENExist("Teto_EN", "Seraphim_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Teto_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Seraphim_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Teto_EN", enemySlot=3},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Keko_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Keko_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RainBaseColor(true, false), enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FlaMinGoa_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(0, false, false), enemySlot=3},
                });
            if (MultiENExist("Lymphropod_EN", "BoulderBuddy_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "BoulderBuddy_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Lymphropod_EN", enemySlot=3},
                });
            }
            if (EnemyExist("BoulderBuddy_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "BoulderBuddy_EN", enemySlot=1},
                });
                for (int i = 0; i < 2; i++)
                {

                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "BoulderBuddy_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = RandomColor(0), enemySlot=2},
                    });
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "BoulderBuddy_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = RandomSupport(0, false, false), enemySlot=2},
                    });
                }
            }
            if (MultiENExist("Disembodied_EN", "OsseousClad_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Disembodied_EN", enemySlot=3},
                });
            }
            if (EnemyExist("DrySimian_EN") && Spligging)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "DrySimian_EN", enemySlot=1},
                new FieldEnemy(){enemyName = Spligs.GetRandom(), enemySlot=2},
                new FieldEnemy(){enemyName = Spligs.GetRandom(), enemySlot=3},
                });
            }
            if (EnemyExist("OsseousClad_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=3},
                });
                if (EnemyExist("A'Flower'_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = RandomColor(0), enemySlot=3},
                    });
                }
                if (EnemyExist("Seraphim_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Seraphim_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = RandomSupport(0, false, false), enemySlot=3},
                    });
                }
            }
            if (EnemyExist("Lymphropod_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lymphropod_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Lymphropod_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lymphropod_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RainBaseColor(true, false), enemySlot=2},
                new FieldEnemy(){enemyName = RainBaseColor(true, false), enemySlot=3},
                });
                if (Supporting)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Lymphropod_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Lymphropod_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=4},
                    });
                }
                if (EnemyExist("Lurchin_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Lymphropod_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Lurchin_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=3},
                    });
                }
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lymphropod_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Flarb_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lymphropod_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Voboola_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Lurchin_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lurchin_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FlaMinGoa_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lurchin_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MunglingMudLung_EN", enemySlot=3},
                });
                if (EnemyExist("Monck_EN"))
                {

                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Monck_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Lurchin_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = RandomSupport(0, true, false), enemySlot=4},
                    });
                }
                if (EnemyExist("OsseousClad_EN"))
                {

                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Lurchin_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = RandomSupport(0, false, false), enemySlot=4},
                    });
                }
            }
            if (EnemyExist("FesteringFaction_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "FesteringFaction_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "FesteringFaction_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=3},
                });
                if (EnemyExist("OsseousClad_EN"))
                {

                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "FesteringFaction_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=4},
                    });
                }
            }
            if (EnemyExist("MechanicalLens_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MunglingMudLung_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(0, true), enemySlot=2},
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=3},
                });
                if (EnemyExist("OsseousClad_EN"))
                {

                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=4},
                    });
                }
                if (EnemyExist("Disembodied_EN"))
                {

                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Disembodied_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "JumbleGuts_Clotted_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=4},
                    });
                }
                if (EnemyExist("Lurchin_EN"))
                {

                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Lurchin_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "FlaMinGoa_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=4},
                    });
                }
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(0, false, false), enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(0, true, false), enemySlot=3},
                });
            if (EnemyExist("LittleBeak_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FlaMinGoa_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomShoreMidget(false), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=2},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Warbird_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Flarb_EN", enemySlot=2},
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
                encounterName = "tripodfish_medium_garden",
                area = 2,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = rarity,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/NewTripodTheme",
                roarEvent = "event:/Hawthorne/Roar/ShuaRoar",
                difficulty = EncounterDifficulty.Medium
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("TripodFish_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=4},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=1},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=2},
                });
            if (EnemyExist("MiniReaper_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                });
            }
            if (EnemyExist("EggKeeper_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Damocles_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Damocles_EN", enemySlot=2},
                });
            }
            if (EnemyExist("SterileBud_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=2},
                });
            }
            if (MultiENExist("SterileBud_EN", "Unterling_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Unterling_EN", enemySlot=2},
                });
            }
            if (EnemyExist("TitteringPeon_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=3},
                });
            }
            if (EnemyExist("ScreamingHomunculus_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "ScreamingHomunculus_EN", enemySlot=2},
                });
            }
            for (int i = 0; i < 2; i++) fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomColor(2), enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomColor(2), enemySlot=3},
                });
            if (EnemyExist("Satyr_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Satyr_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                });
            }
            if (EnemyExist("HowlingAvian_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "HowlingAvian_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Harbinger_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Harbinger_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Scuttlerunt_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Scuttlerunt_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Scuttlerunt_EN", enemySlot=2},
                });
            }
            if (EnemyExist("InfernalDrummer_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InfernalDrummer_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=3},
                });
            }
            if (EnemyExist("StalwartTortoise_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=1},
                });
            }
            if (EnemyExist("TheCrow_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Hunter_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Firebird_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=2},
                });
            }
            if (EnemyExist("LittleAngel_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=2},
                });
            }
            if (EnemyExist("GlassFigurine_EN") && SaltEnemies.trolling == 61)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "GlassFigurine_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=2},
                });
            }
            if (EnemyExist("WindSong_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=2},
                });
            }
            if (EnemyExist("LivingSolvent_EN") && SaltEnemies.silly < 61)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                });
            }
            if (EnemyExist("EyePalm_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Sigil_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                });
            }
            if (MultiENExist("Shua_EN", "Unterling_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Unterling_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=4},
                });
            }
            if (EnemyExist("Butterfly_EN") && SaltEnemies.trolling < 32)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=3},
                });
            }
            if (Flowering)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Flowers.GetRandom(), enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=4},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(2, false, false), enemySlot=2},
                });
            if (EnemyExist("Grandfather_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=2},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(2, true, false), enemySlot=2},
                });
            if (EnemyExist("Romantic_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=2},
                });
            }
            jarden.variations = fields.ToArray();
            jarden.CheckEncounters();
            jarden.AddEncounter();
        }
    }
    public static class RabiesGroup
    {
        public static void Add(int sign)
        {
            if (!EnemyExist("Lyssa_EN")) return;

            BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("RabiesWorld.png"));

            OrphEZ(sign);
            OrphMed(sign);
            OrphHard(sign);
        }

        public static void OrphEZ(int sign)
        {
            BrutalAPI.EnemyEncounter jarden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "rabieseasy",
                area = 1,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = 10,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/Redo/RabiesTheme",
                roarEvent = LoadedAssetsHandler.GetCharcater("Pearl_CH").deathSound,
                difficulty = EncounterDifficulty.Easy
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("Lyssa_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=4},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                });
            for (int i = 0; i < 3; i++)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=1},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=1},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(1), enemySlot=1},
                });
            }
            if (EnemyExist("DeadPixel_EN") && SaltEnemies.trolling > 87)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=2},
                });
            }
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
            });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Flowers.UpTo(2).GetRandom(), enemySlot=1},
                });
            if (EnemyExist("FakeAngel_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Nameless_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Nameless_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=2},
                });
            }
            jarden.variations = fields.ToArray();
            jarden.CheckEncounters();
            jarden.AddEncounter();
        }
        public static void OrphMed(int sign)
        {
            BrutalAPI.EnemyEncounter jarden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "rabiesmedia",
                area = 1,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = 15,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/Redo/RabiesTheme",
                roarEvent = LoadedAssetsHandler.GetCharcater("Pearl_CH").deathSound,
                difficulty = EncounterDifficulty.Medium
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("Lyssa_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=4},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=3},
                });
            if (Gizos)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=1},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "NakedGizo_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=1},
                new FieldEnemy(){enemyName = "NakedGizo_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "NakedGizo_EN", enemySlot=2},
                });
            }
            if (Chap)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(1), enemySlot=2},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=3},
                });
            }
            if (EnemyExist("Something_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=2},
                });
            }
            if (Supporting)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=3},
                });
            }
            if (EnemyExist("Seraphim_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Seraphim_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=1},
                new FieldEnemy(){enemyName = "Seraphim_EN", enemySlot=2},
                });
            }
            if (EnemyExist("TheCrow_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Hunter_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=1},
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=2},
                });
            }
            if (EnemyExist("LittleBeak_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=1},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=3},
                });
                if (Supporting)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=3},
                    });
                }
            }
            if (EnemyExist("Warbird_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=1},
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=3},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RainBaseWeighted(true), enemySlot=1},
                new FieldEnemy(){enemyName = RainBaseWeighted(true), enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RainBaseColor(false), enemySlot=1},
                new FieldEnemy(){enemyName = RainBaseWeighted(false), enemySlot=2},
                });
            if (EnemyExist("OsseousClad_EN"))
            if (EnemyExist("EyePalm_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=2},
                });
            }
            if (EnemyExist("Skyloft_EN") && SaltEnemies.trolling == 41)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=4},
                });
            }
            if (EnemyExist("LivingSolvent_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=2},
                });
            }
            if (EnemyExist("WindSong_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Sigil_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Grandfather_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=2},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=2},
                });
            if (EnemyExist("FumeFactory_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=1},
                new FieldEnemy(){enemyName = "FumeFactory_EN", enemySlot=2},
                });
            }
            jarden.variations = fields.ToArray();
            jarden.CheckEncounters();
            jarden.AddEncounter();
        }
        public static void OrphHard(int sign)
        {
            BrutalAPI.EnemyEncounter jarden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "rabiesRRAAAAGHHHHH",
                area = 1,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = 15,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/Redo/RabiesTheme",
                roarEvent = LoadedAssetsHandler.GetCharcater("Pearl_CH").deathSound,
                difficulty = EncounterDifficulty.Hard
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("Lyssa_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=4},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RainBaseColor(true), enemySlot=2},
                new FieldEnemy(){enemyName = RainBaseColor(true), enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RainBaseWeighted(false), enemySlot=2},
                new FieldEnemy(){enemyName = RainBaseWeighted(false), enemySlot=3},
                });
            if (Spligging)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = Spligs.GetRandom(), enemySlot=2},
                new FieldEnemy(){enemyName = Spligs.GetRandom(), enemySlot=3},
                });
            }
            if (Colophoning)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = Colophon.GetRandom(), enemySlot=2},
                new FieldEnemy(){enemyName = Colophon.GetRandom(), enemySlot=3},
                });
            }
            if (Flowering)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = Flowers.UpTo(2).GetRandom(), enemySlot=2},
                new FieldEnemy(){enemyName = Flowers.UpTo(2).GetRandom(), enemySlot=3},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=4},
                });
            }
            for (int i = 0; i < 2; i++)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=3},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "WrigglingSacrifice_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=3},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=4},
                });
            if (EnemyExist("Romantic_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=3},
                });
            }
            if (BirdScale)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=3},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=1},
                });
            }
            if (EnemyExist("FumeFactory_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FumeFactory_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=3},
                });
            }
            jarden.variations = fields.ToArray();
            jarden.CheckEncounters();
            jarden.AddEncounter();
        }
    }
    public static class LonelyFlummox
    {
        public static void Add()
        {
            BrutalAPI.EnemyEncounter jarden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "Lonely_Flummoxer",
                area = 2,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = 1,
                signType = SignType.JumbleGutsFlummoxing,
                musicEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone01_JumbleGuts_Flummoxing_Hard_EnemyBundle")._musicEventReference,
                roarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone01_JumbleGuts_Flummoxing_Hard_EnemyBundle")._roarReference.roarEvent,
                difficulty = EncounterDifficulty.Easy
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "JumbleGuts_Flummoxing_EN", enemySlot=0},
                });
            jarden.variations = fields.ToArray();
            jarden.CheckEncounters();
            if (Trolling(46))
                jarden.AddEncounter();
        }
    }
    public static class RedoManiskins
    {
        public static void Add()
        {
            BrutalAPI.EnemyEncounter warpheum = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "ManicMenSecond",
                area = 1,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = UnityEngine.Random.Range(3, 11),
                signType = SignType.ManicMan,
                musicEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone02_InnerChild_Hard_EnemyBundle")._musicEventReference,
                roarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone02_InnerChild_Hard_EnemyBundle")._roarReference.roarEvent,
                difficulty = EncounterDifficulty.Hard
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=4},
                });
            if (EnemyExist("WindSong_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=4},
                });
            }
            if (MultiENExist("Skyloft_EN", "LivingSolvent_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=4},
                });
            }
            if (EnemyExist("GlassFigurine_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "GlassFigurine_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=3},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=0},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=4},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = RainBaseWeighted(true), enemySlot=0},
                new FieldEnemy(){enemyName = RainBaseWeighted(true), enemySlot=1},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = RainBaseWeighted(false), enemySlot=0},
                new FieldEnemy(){enemyName = RainBaseWeighted(false), enemySlot=1},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=3},
                });
            if (Colophoning)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = Colophon.GetRandom(), enemySlot=0},
                new FieldEnemy(){enemyName = Colophon.GetRandom(), enemySlot=1},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=3},
                });
            }
            if (Spligging)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = Spligs.GetRandom(), enemySlot=0},
                new FieldEnemy(){enemyName = Spligs.GetRandom(), enemySlot=1},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=4},
                });
            }
            if (Flowering)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=4},
                });
            }
            if (EnemyExist("Romantic_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=4},
                });
            }
            if (EnemyExist("Grandfather_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=4},
                });
            }
            if (EnemyExist("Skyloft_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=4},
                });
            }
            if (EnemyExist("Romantic_EN") && Gizos)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "NakedGizo_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=3},
                });
            }
            if (EnemyExist("TheCrow_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=4},
                });
            }
            if (EnemyExist("Hunter_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=4},
                });
            }
            if (EnemyExist("LittleBeak_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=4},
                });
            }
            if (EnemyExist("Warbird_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=4},
                });
            }
            if (EnemyExist("Nameless_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Nameless_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=4},
                });
            }
            if (EnemyExist("Sigil_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RainBaseWeighted(false), enemySlot=1},
                new FieldEnemy(){enemyName = RainBaseWeighted(false), enemySlot=2},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=4},
                });
            }
            if (EnemyExist("Merced_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "WrigglingSacrifice_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=4},
                });
            }
            if (EnemyExist("Shua_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=1},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=4},
                });
            }
            if (EnemyExist("ReflectedHound_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ReflectedHound_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=4},
                });
            }
            if (EnemyExist("Enigma_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=4},
                });
            }
            if (EnemyExist("MechanicalLens_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=4},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=4},
                });
            if (EnemyExist("FumeFactory_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "FumeFactory_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "FumeFactory_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=4},
                });
            }
            warpheum.variations = fields.ToArray();
            warpheum.CheckEncounters();
            warpheum.AddEncounter();
            Two();
        }
        public static void Two()
        {
            BrutalAPI.EnemyEncounter warpheum = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "ManicMenThird",
                area = 1,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = UnityEngine.Random.Range(1, 9),
                signType = SignType.ManicMan,
                musicEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone02_InnerChild_Hard_EnemyBundle")._musicEventReference,
                roarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone02_InnerChild_Hard_EnemyBundle")._roarReference.roarEvent,
                difficulty = EncounterDifficulty.Hard
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=4},
                });
            if (Trolling(71))
            {

                fields.Add(new FieldEnemy[]
                    {
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=4},
                    });
            }
            warpheum.variations = fields.ToArray();
            warpheum.CheckEncounters();
            warpheum.AddEncounter();
        }
    }
    public static class SnakeGroup
    {
        public static void Add(int sign)
        {
            if (!EnemyExist("SnakeGod_EN")) return;

            BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("SnakeGodWorld.png"));

            GardHard(sign);
        }
        public static void GardHard(int sign)
        {
            BrutalAPI.EnemyEncounter jarden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "thesnakegod",
                area = 2,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = UnityEngine.Random.Range(1, 5),
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/SnakeGodTheme",
                roarEvent = "event:/Hawthorne/Die/XylophoneDie",
                difficulty = EncounterDifficulty.Hard
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("WindSong_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "SnakeGod_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Illusion_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "SnakeGod_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                });
            }
            if (Flowering)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "SnakeGod_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "SnakeGod_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "GreyFlower_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=4},
                });
            }
            if (EnemyExist("MechanicalLens_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "SnakeGod_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=4},
                });
            }
            if (MultiENExist("Romantic_EN", "Skyloft_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "SnakeGod_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=4},
                new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=0},
                });
            }
            if (MultiENExist("Damocles_EN", "WindSong_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "SnakeGod_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Damocles_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Damocles_EN", enemySlot=4},
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=0},
                });
            }
            if (MultiENExist("Illusion_EN", "Merced_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "SnakeGod_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                });
            }
            if (EnemyExist("MiniReaper_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "SnakeGod_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=3},
                });
            }
            if (EnemyExist("ClockTower_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "SnakeGod_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=3},
                });
            }
            if (EnemyExist("TripodFish_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "SnakeGod_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=3},
                });
            }
            if (MultiENExist("Illusion_EN", "Sigil_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "SnakeGod_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=4},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=0},
                });
            }
            if (EnemyExist("Metatron_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "SnakeGod_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Metatron_EN", enemySlot=3},
                });
            }
            if (EnemyExist("LittleAngel_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "SnakeGod_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=4},
                });
            }
            if (EnemyExist("Nameless_EN") && Half)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "SnakeGod_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Nameless_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Nameless_EN", enemySlot=4},
                });
            }
            if (EnemyExist("StarGazer_EN") && Half)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "SnakeGod_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "StarGazer_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "StarGazer_EN", enemySlot=4},
                });
            }
            if (EnemyExist("TheCrow_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "SnakeGod_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Hunter_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "SnakeGod_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=3},
                });
            }
            if (MultiENExist("EggKeeper_EN", "WindSong_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "SnakeGod_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=4},
                });
            }
            if (MultiENExist("EggKeeper_EN", "MiniReaper_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "SnakeGod_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=4},
                });
            }
            if (MultiENExist("EggKeeper_EN", "Romantic_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "SnakeGod_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=4},
                });
            }
            if (MultiENExist("WindSong_EN", "Romantic_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "SnakeGod_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=4},
                });
            }
            if (MultiENExist("TheCrow_EN", "MiniReaper_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "SnakeGod_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=4},
                });
            }
            if (MultiENExist("TripodFish_EN", "MechanicalLens_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "SnakeGod_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=4},
                });
            }
            if (MultiENExist("Sigil_EN", "MechanicalLens_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "SnakeGod_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=4},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                });
            }
            if (EnemyExist("GlassFigurine_EN") && Half)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "SnakeGod_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "GlassFigurine_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Damocles_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "SnakeGod_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Damocles_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Damocles_EN", enemySlot=4},
                new FieldEnemy(){enemyName = "Damocles_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Damocles_EN", enemySlot=1},
                });
            }
            jarden.variations = fields.ToArray();
            jarden.AddEncounter();
        }
    }
}
