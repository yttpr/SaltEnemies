using BrutalAPI;
using System.Collections.Generic;
using Tools;
using static Hawthorne.Check;
using UnityEngine;
using EnemyPack.Effects;
using System;

namespace Hawthorne
{
    public static class MiriamSong
    {
        public static void Add(int sign)
        {
            if (!EnemyExist("Miriam_EN")) return;

            BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("MiriamWorld.png"));

            GardHard(sign);
        }
        public static void GardHard(int sign)
        {
            BrutalAPI.EnemyEncounter jarden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "MiriamMySweetChild",
                area = 2,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = 7,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/MiriamTheme",
                roarEvent = LoadedAssetsHandler.GetCharcater("Bimini_CH").damageSound,
                difficulty = EncounterDifficulty.Hard
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("Miriam_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=4},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=3},
                });
            if (EnemyExist("WindSong_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=3},
                });
                if (EnemyExist("Metatron_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Metatron_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=4},
                    new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=3},
                    });
                }
            }
            if (EnemyExist("Iconoclast_EN") && GreyScale && SaltEnemies.trolling == 84)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Iconoclast_EN", enemySlot=3},
                });
            }
            if (EnemyExist("EyePalm_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=4},
                });
                if (Supporting)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=4},
                    });
                }
                if (EnemyExist("EggKeeper_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("SterileBud_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("Skyloft_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("ScreamingHomunculus_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "ScreamingHomunculus_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=3},
                    });
                }
            }
            if (EnemyExist("Merced_EN") && GreyScale)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Unterling_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Unterling_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Unterling_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Unterling_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Unterling_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                });
                if (EnemyExist("Shua_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Unterling_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Shua_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=3},
                    });
                }
            }
            if (EnemyExist("TitteringPeon_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=4},
                });
                if (EnemyExist("ScreamingHomunculus_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "ScreamingHomunculus_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=3},
                    });
                }
                if (Flowering)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=3},
                    });
                }
            }
            if (EnemyExist("ScreamingHomunculus_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ScreamingHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ScreamingHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=3},
                });
            }
            if (EnemyExist("SterileBud_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=2},
                });
                if (EnemyExist("EggKeeper_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=2},
                    });
                }
                if (EnemyExist("Grandfather_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=3},
                    });
                }
            }
            if (MultiENExist("Metatron_EN", "EyePalm_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Metatron_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=3},
                });
            }
            if (EnemyExist("TheCrow_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                });
                if (GreyScale)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                    });
                }
            }
            if (EnemyExist("Hunter_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=3},
                });
                if (GreyScale)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                    });
                }
            }
            if (EnemyExist("Firebird_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=3},
                });
                if (GreyScale)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                    });
                }
            }
            if (MultiENExist("Freud_EN", "Shua_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Freud_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=2},
                });
            }
            if (Supporting)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=4},
                });
                if (EnemyExist("StalwartTortoise_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=4},
                    });
                }
            }
            if (EnemyExist("LittleAngel_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                });
            }
            if (EnemyExist("MortalSpoggle_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MortalSpoggle_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=4},
                });
            }
            if (EnemyExist("Satyr_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Satyr_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Satyr_EN", enemySlot=3},
                });
                if (EnemyExist("WindSong_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Satyr_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("EggKeeper_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Satyr_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=3},
                    });
                }
            }
            if (EnemyExist("MechanicalLens_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=3},
                });
                if (GreyScale)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=3},
                    });
                }
                if (Flowering)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "GreyFlower_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("EyePalm_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=3},
                    });
                }
            }
            if (GreyScale)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=3},
                });

                if (EnemyExist("Skyloft_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("WindSong_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("LivingSolvent_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("Merced_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Merced_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("GlassFigurine_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "GlassFigurine_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=3},
                    });
                }
            }
            if (Flowering)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=3},
                });
                if (GreyScale)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    });
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=4},
                    });
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=4},
                    });
                    if (EnemyExist("ClockTower_EN"))
                    {
                        fields.Add(new FieldEnemy[]
                        {
                        new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                        new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=1},
                        new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                        new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=3},
                        });
                    }
                }
                if (EnemyExist("RealisticTank_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=2},
                    });
                }
                if (EnemyExist("TripodFish_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("Shua_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Shua_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("Butterfly_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=3},
                    });
                }
            }
            if (EnemyExist("Sigil_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=3},
                });
                if (GreyScale)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=3},
                    });
                }
            }
            if (EnemyExist("MiniReaper_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=3},
                });
                if (EnemyExist("EggKeeper_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=3},
                    });
                }
            }
            if (EnemyExist("Damocles_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Damocles_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Damocles_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Skyloft_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=2},
                });
                if (EnemyExist("MiniReaper_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=3},
                    });
                }
            }
            if (EnemyExist("Nameless_EN") && GreyScale)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Nameless_EN", enemySlot=3},
                });
            }
            if (EnemyExist("TripodFish_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=3},
                });
                if (EnemyExist("SterileBud_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=3},
                    });
                }
            }
            if (EnemyExist("EggKeeper_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=4},
                }); 
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Romantic_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=4},
                });
                if (EnemyExist("ScreamingHomunculus_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "ScreamingHomunculus_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=3},
                    });
                }
            }
            jarden.variations = fields.ToArray();
            jarden.CheckEncounters();
            jarden.AddEncounter();
        }
    }
    public static class EyePalmGroup
    {
        public static void Add(int sign)
        {
            if (!EnemyExist("EyePalm_EN")) return;

            BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("EyePalmWorld.png"));

            orphMed(sign);
            GardMed(sign);
            GardEZ(sign);
        }

        public static int rarity
        {
            get
            {
                return UnityEngine.Random.Range(14, 19);
            }
        }

        public static void orphMed(int sign)
        {
            BrutalAPI.EnemyEncounter jarden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "MedamaudeOrpheum",
                area = 1,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = rarity/2,
                signType = (SignType)sign,
                musicEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone03_InHisImage_Medium_EnemyBundle")._musicEventReference,
                roarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone03_InHisImage_Medium_EnemyBundle")._roarReference.roarEvent,
                difficulty = EncounterDifficulty.Medium
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("EyePalm_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=4},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=4},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=4},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=4},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=2},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=4},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=2},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=4},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=4},
                });
            if (Gizos)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=2},
                new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "NakedGizo_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=2},
                new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=3},
                });
            }
            if (Chap)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=2},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=2},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Lyssa_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                new FieldEnemy(){enemyName ="SingingStone_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=2},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=3},
                });
            }
            if (Supporting)
            {
                if (Chap)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=3},
                    });
                }
                if (Gizos)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=2},
                    });
                }
                if (EnemyExist("Lyssa_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=2},
                    });
                }
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Skyloft_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=4},
                });
            }
            if (EnemyExist("WindSong_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=3},
                });
            }
            if (EnemyExist("OsseousClad_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                new FieldEnemy(){enemyName ="SilverSuckle_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=2},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=3},
                });
            }
            if (EnemyExist("ReflectedHound_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ReflectedHound_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Romantic_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=3},
                });
            }
            if (EnemyExist("FumeFactory_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "FumeFactory_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=3},
                });
            }
            for (int i = 0; i < 5; i++)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=2},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=3},
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
                encounterName = "MedamaudeGarden",
                area = 2,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = rarity,
                signType = (SignType)sign,
                musicEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone03_InHisImage_Medium_EnemyBundle")._musicEventReference,
                roarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone03_InHisImage_Medium_EnemyBundle")._roarReference.roarEvent,
                difficulty = EncounterDifficulty.Medium
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("EyePalm_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=4},
                });
            }
            for (int i = 0; i < 2; i++)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                    {
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=4},
                    });
                fields.Add(new FieldEnemy[]
                    {
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                    });
                fields.Add(new FieldEnemy[]
                    {
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=3},
                    });
                fields.Add(new FieldEnemy[]
                    {
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=4},
                    });
                fields.Add(new FieldEnemy[]
                    {
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=4},
                    });
                fields.Add(new FieldEnemy[]
                    {
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=4},
                    });
                if (EnemyExist("MiniReaper_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=3},
                    });
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=4},
                    });
                }
                if (EnemyExist("EggKeeper_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                    });
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=4},
                    });
                }
                if (Flowering)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = Flowers.GetRandom(), enemySlot=1},
                    new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                    });
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = Flowers.GetRandom(), enemySlot=1},
                    new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=4},
                    });
                }
                if (Supporting)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("Harbinger_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Harbinger_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=3},
                    });
                }
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=4},
                });
            if (EnemyExist("MechanicalLens_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=4},
                });
                if (EnemyExist("GlassFigurine_EN") && SaltEnemies.trolling == 62)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "GlassFigurine_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=4},
                    });
                }
            }
            if (EnemyExist("ScreamingHomunculus_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ScreamingHomunculus_EN", enemySlot=4},
                });
            }
            if (EnemyExist("SterileBud_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=4},
                });
            }
            if (EnemyExist("Unterling_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Unterling_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Unterling_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=4},
                });
            }
            if (EnemyExist("LittleAngel_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=4},
                });
            }
            if (EnemyExist("TitteringPeon_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=4},
                });
            }
            if (EnemyExist("WindSong_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                });
            }
            if (EnemyExist("LivingSolvent_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Sigil_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Damocles_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Damocles_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Shua_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Shua_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Grandfather_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Skyloft_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=3},
                });
            }
            if (EnemyExist("TripodFish_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                });
            }
            if (EnemyExist("InfernalDrummer_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "InfernalDrummer_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=2},
                });
            }
            if (EnemyExist("HowlingAvian_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "HowlingAvian_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Scuttlerunt_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Scuttlerunt_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Scuttlerunt_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Harbinger_EN"))
            {

                fields.Add(new FieldEnemy[]
                {
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Harbinger_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Harbinger_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=4},
                });
            }
            if (EnemyExist("Romantic_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Hunter_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=3},
                });
            }
            jarden.variations = fields.ToArray();
            jarden.CheckEncounters();
            jarden.AddEncounter();
        }
        public static void GardEZ(int sign)
        {
            BrutalAPI.EnemyEncounter jarden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "MedamaudeEZGarden",
                area = 2,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = rarity /2,
                signType = (SignType)sign,
                musicEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone03_InHisImage_Medium_EnemyBundle")._musicEventReference,
                roarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone03_InHisImage_Medium_EnemyBundle")._roarReference.roarEvent,
                difficulty = EncounterDifficulty.Easy
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("EyePalm_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=2},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                });
            if (EnemyExist("Skyloft_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=3},
                });
            }
            if (EnemyExist("DeadPixel_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=3},
                });
            }
            if (Flowering)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = Flowers.GetRandom(), enemySlot=0},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Sigil_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Shua_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=2},
                });
            }
            if (EnemyExist("LittleAngel_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Romantic_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=2},
                });
            }
            if (EnemyExist("EggKeeper_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=2},
                });
            }
            if (EnemyExist("WindSong_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=2},
                });
            }
            if (EnemyExist("LivingSolvent_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=2},
                });
            }
            if (EnemyExist("TitteringPeon_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Unterling_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Unterling_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Enigma_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Butterfly_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=3},
                });
            }
            jarden.variations = fields.ToArray();
            jarden.CheckEncounters();
            jarden.AddEncounter();
        }
    }
    public static class TankSong
    {
        public static void Add(int sign)
        {
            if (!EnemyExist("RealisticTank_EN")) return;

            BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("TankWorld.png"));

            orphHard(sign);
            gardHard(sign);
        }

        public static int rarity
        {
            get
            {
                return UnityEngine.Random.Range(18, 25);
            }
        }

        public static void orphHard(int sign)
        {
            if (!GreyScale) return;
            BrutalAPI.EnemyEncounter jarden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "TankOrpheum",
                area = 1,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = rarity,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/TankTheme",
                roarEvent = "event:/Hawthorne/Roar/TankRoar",
                difficulty = EncounterDifficulty.Hard
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("RealisticTank_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=3},
                });
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=3},
                    });
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=3},
                    });
                }
                if (Flowering)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=3},
                    });
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=3},
                    });
                }
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Skyloft_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=3},
                });
            }
            if (EnemyExist("LivingSolvent_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=3},
                });
            }
            for (int i = 0; i < 2; i++)
            {
                if (EnemyExist("WindSong_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("Sigil_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("Lyssa_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=3},
                    });
                }
                if (Supporting)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=3},
                    });
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=3},
                    });
                }
            }
            if (EnemyExist("RusticJumbleguts_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "RusticJumbleguts_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=3},
                });
            }
            if (Colophoning)
            {
                fields.Add(new FieldEnemy[]
                {
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = Colophon.GetRandom(), enemySlot=2},
                    new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = Colophon.GetRandom(), enemySlot=1},
                    new FieldEnemy(){enemyName = Colophon.GetRandom(), enemySlot=2},
                    new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Merced_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=3},
                });
            }
            if (EnemyExist("MechanicalLens_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Damocles_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Damocles_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Romantic_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Warbird_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=3},
                });
                if (EnemyExist("LittleBeak_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=3},
                    });
                }
            }
            if (EnemyExist("TheCrow_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=3},
                });
            }
            if (EnemyExist("FumeFactory_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "FumeFactory_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=3},
                });
            }
            jarden.variations = fields.ToArray();
            jarden.CheckEncounters();
            jarden.AddEncounter();
        }
        public static void gardHard(int sign)
        {
            if (!GreyScale) return;
            BrutalAPI.EnemyEncounter jarden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "TankGarden",
                area = 2,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = rarity,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/TankTheme",
                roarEvent = "event:/Hawthorne/Roar/TankRoar",
                difficulty = EncounterDifficulty.Hard
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("RedFlower_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=3},
                });
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (EnemyExist("WindSong_EN"))
                    {
                        fields.Add(new FieldEnemy[]
                        {
                        new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=0},
                        new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                        new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=2},
                        new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=3},
                        });
                    }
                    if (EnemyExist("Sigil_EN"))
                    {
                        fields.Add(new FieldEnemy[]
                        {
                        new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=0},
                        new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                        new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=2},
                        new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=3},
                        });
                    }
                }
                if (Flowering)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = Flowers.GetRandom(), enemySlot=1},
                    new FieldEnemy(){enemyName = Flowers.GetRandom(), enemySlot=2},
                    new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=3},
                    });
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = Flowers.GetRandom(), enemySlot=2},
                    new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=3},
                    });
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = Flowers.GetRandom(), enemySlot=2},
                    new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=3},
                    });
                }
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=3},
                });
                if (Supporting)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=3},
                    });
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("LivingSolvent_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=3},
                    });
                }
            }
            if (EnemyExist("Skyloft_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=3},
                });
            }
            for (int i = 0; i < 2; i++)
            {
                if (EnemyExist("Merced_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Merced_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=3},
                    });
                    if (Flowering)
                    {
                        fields.Add(new FieldEnemy[]
                        {
                        new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=0},
                        new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=1},
                        new FieldEnemy(){enemyName = "Merced_EN", enemySlot=2},
                        new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=3},
                        });
                    }
                }
                if (EnemyExist("MechanicalLens_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=3},
                    });
                    if (Flowering)
                    {
                        fields.Add(new FieldEnemy[]
                        {
                        new FieldEnemy(){enemyName = Flowers.GetRandom(), enemySlot=0},
                        new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=1},
                        new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=2},
                        new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=3},
                        });
                    }
                }
                if (EnemyExist("RusticJumbleguts_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                        new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=0},
                        new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                        new FieldEnemy(){enemyName = "RusticJumbleguts_EN", enemySlot=2},
                        new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("TheCrow_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                        new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=0},
                        new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                        new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=2},
                        new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("ClockTower_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                        new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=0},
                        new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=2},
                        new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("Grandfather_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                        new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=0},
                        new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                        new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                        new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("Butterfly_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                        new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=0},
                        new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                        new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                        new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=3},
                    });
                }
            }
            if (EnemyExist("MechanicalLens_EN") && Flowering)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=3},
                });
            }
            if (EnemyExist("RusticJumbleguts_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "RusticJumbleguts_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Shua_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=3},
                });
            }
            if (EnemyExist("GlassFigurine_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GlassFigurine_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=3},
                });
            }
            if (EnemyExist("StarGazer_EN") && SaltEnemies.silly == 76)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "StarGazer_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "StarGazer_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Damocles_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Damocles_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Damocles_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Romantic_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=3},
                });
            }
            if (BirdScale)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = GreyScaleSupport(true), enemySlot=1},
                new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=3},
                });
            }
            jarden.variations = fields.ToArray();
            jarden.CheckEncounters();
            jarden.AddEncounter();
        }
    }
    public static class SigilGroup
    {
        public static void Add(int sign)
        {
            if (!EnemyExist("Sigil_EN")) return;

            BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("SigilWorld.png"));

            orphMed(sign);
            gardMed(sign);
        }

        public static int rarity
        {
            get
            {
                return UnityEngine.Random.Range(20, 30);
            }
        }

        public static void orphMed(int sign)
        {
            if (!GreyScale) return;
            BrutalAPI.EnemyEncounter jarden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "SigilGorepheum",
                area = 1,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = rarity,
                signType = (SignType)sign,
                musicEvent = LoadedAssetsHandler.GetEnemyBundle("Zone02_Spoggle_Writhing_Medium_EnemyBundle")._musicEventReference,
                roarEvent = LoadedAssetsHandler.GetEnemy("Spoggle_Resonant_EN").deathSound,
                difficulty = EncounterDifficulty.Hard
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("Sigil_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=4},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=4},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=4},
                });
            if (Gizos)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "NakedGizo_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=2},
                });
            }
            if (Chap)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=3},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=2},
                });
            }
            if (EnemyExist("Lyssa_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=4},
                });
            }
            if (EnemyExist("OsseousClad_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=3},
                });
            }
            if (EnemyExist("Something_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(1), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=3},
                });
            }
            if (Supporting)
            {
                if (SaltEnemies.rando > 50)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=4},
                    });
                }
                else
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=4},
                    });
                }
                if (SaltEnemies.rando > 50)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=4},
                    });
                }
                else
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=4},
                    });
                }
                if (Gizos)
                {
                    if (SaltEnemies.rando > 50)
                    {
                        fields.Add(new FieldEnemy[]
                        {
                        new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                        new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=1},
                        new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=3},
                        new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=4},
                        });
                    }
                    else
                    {
                        fields.Add(new FieldEnemy[]
                        {
                        new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                        new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=1},
                        new FieldEnemy(){enemyName = "NakedGizo_EN", enemySlot=2},
                        new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=4},
                        });
                    }
                }
                if (Chap)
                {
                    if (SaltEnemies.rando > 50)
                    {
                        fields.Add(new FieldEnemy[]
                        {
                        new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                        new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=1},
                        new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=3},
                        new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=4},
                        });
                    }
                    else
                    {
                        fields.Add(new FieldEnemy[]
                        {
                        new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                        new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=1},
                        new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=2},
                        new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=3},
                        new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=4},
                        });
                    }
                }
                if (EnemyExist("Lyssa_EN"))
                {
                    if (SaltEnemies.rando > 50)
                    {
                        fields.Add(new FieldEnemy[]
                        {
                        new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                        new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=3},
                        new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=4},
                        });
                    }
                    else
                    {
                        fields.Add(new FieldEnemy[]
                        {
                        new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                        new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                        new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=2},
                        new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=4},
                        });
                    }
                }
                if (EnemyExist("OsseousClad_EN"))
                {
                    if (SaltEnemies.rando > 50)
                    {
                        fields.Add(new FieldEnemy[]
                        {
                        new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                        new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=3},
                        new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=1},
                        new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=4},
                        });
                    }
                    else
                    {
                        fields.Add(new FieldEnemy[]
                        {
                        new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                        new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=1},
                        new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=2},
                        new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=4},
                        });
                    }
                }
                fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = NoPixel.GetRandom(), enemySlot=1},
                    new FieldEnemy(){enemyName = BaseColor(true), enemySlot=2},
                    new FieldEnemy(){enemyName = BaseColor(true), enemySlot=4},
                    });
                fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = NoPixel.GetRandom(), enemySlot=1},
                    new FieldEnemy(){enemyName = BaseColor(false), enemySlot=2},
                    new FieldEnemy(){enemyName = BaseColor(false), enemySlot=4},
                    });
                if (Colophoning)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = NoPixel.GetRandom(), enemySlot=1},
                    new FieldEnemy(){enemyName = Colophon.GetRandom(), enemySlot=2},
                    new FieldEnemy(){enemyName = Colophon.GetRandom(), enemySlot=4},
                    });
                }
                if (Spligging)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = NoPixel.GetRandom(), enemySlot=1},
                    new FieldEnemy(){enemyName = Spligs.GetRandom(), enemySlot=2},
                    new FieldEnemy(){enemyName = Spligs.GetRandom(), enemySlot=4},
                    });
                }
                if (Flowering)
                {
                    if (SaltEnemies.rando > 50)
                    {
                        fields.Add(new FieldEnemy[]
                        {
                        new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                        new FieldEnemy(){enemyName = NoPixel.GetRandom(), enemySlot=1},
                        new FieldEnemy(){enemyName = NoPixel.GetRandom(), enemySlot=3},
                        new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=4},
                        });
                    }
                    else
                    {
                        fields.Add(new FieldEnemy[]
                        {
                        new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                        new FieldEnemy(){enemyName = NoPixel.GetRandom(), enemySlot=1},
                        new FieldEnemy(){enemyName = NoPixel.GetRandom(), enemySlot=2},
                        new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=4},
                        });
                    }
                }
                if (BowGutsing && BowSpogging)
                {
                    if (SaltEnemies.rando > 50)
                    {
                        fields.Add(new FieldEnemy[]
                        {
                        new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                        new FieldEnemy(){enemyName = NoPixel.GetRandom(), enemySlot=1},
                        new FieldEnemy(){enemyName = BowSpogs.GetRandom(), enemySlot=3},
                        new FieldEnemy(){enemyName = BowSpogs.GetRandom(), enemySlot=4},
                        });
                    }
                    else
                    {
                        fields.Add(new FieldEnemy[]
                        {
                        new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                        new FieldEnemy(){enemyName = NoPixel.GetRandom(), enemySlot=1},
                        new FieldEnemy(){enemyName = BowGuts.GetRandom(), enemySlot=2},
                        new FieldEnemy(){enemyName = BowGuts.GetRandom(), enemySlot=4},
                        });
                    }
                }
            }
            if (EnemyExist("FumeFactory_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomSupport(1), enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                new FieldEnemy(){enemyName = "FumeFactory_EN", enemySlot=3},
                });
            }
            for (int i = 0; i < 10; i++)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = GreyScaleRedSource(), enemySlot=1},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                });
                if (SaltEnemies.rando > 66)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = GreyScaleRedSource(), enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                    });
                }
                else
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = GreyScaleRedSource(), enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    });
                }
                if (SaltEnemies.rando > 66)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = GreyScaleRedSource(), enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = GreyScaleSupport(), enemySlot=4},
                    });
                }
                else
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = GreyScaleRedSource(), enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = GreyScaleSupport(), enemySlot=3},
                    });
                }
            }
            jarden.variations = fields.ToArray();
            jarden.CheckEncounters();
            jarden.AddEncounter();
        }
        public static void gardMed(int sign)
        {
            if (!GreyScale) return;
            BrutalAPI.EnemyEncounter jarden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "SigilJarden",
                area = 2,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = rarity,
                signType = (SignType)sign,
                musicEvent = LoadedAssetsHandler.GetEnemyBundle("Zone02_Spoggle_Writhing_Medium_EnemyBundle")._musicEventReference,
                roarEvent = LoadedAssetsHandler.GetEnemy("Spoggle_Resonant_EN").deathSound,
                difficulty = EncounterDifficulty.Hard
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("Sigil_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=4},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=2},
                });
            if (EnemyExist("ScreamingHomunculus_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ScreamingHomunculus_EN", enemySlot=3},
                });
            }
            if (EnemyExist("TitteringPeon_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=2},
                });
            }
            if (EnemyExist("SterileBud_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                });
            if (EnemyExist("MiniReaper_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=3},
                });
            }
            if (EnemyExist("EggKeeper_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Damocles_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Damocles_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Damocles_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Damocles_EN", enemySlot=3},
                });
            }
            if (EnemyExist("LittleAngel_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                });
                if (SaltEnemies.trolling == 72)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=3},
                    });
                }
            }
            if (EnemyExist("Metatron_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Metatron_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Harbinger_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Harbinger_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Harbinger_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Unterling_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Unterling_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Unterling_EN", enemySlot=2},
                });
            }
            if (EnemyExist("HowlingAvian_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "HowlingAvian_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Scuttlerunt_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Scuttlerunt_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Scuttlerunt_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Enigma_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Butterfly_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=4},
                });
            }
            if (EnemyExist("WindSong_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Skyloft_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=2},
                });
            }
            if (EnemyExist("LivingSolvent_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Grandfather_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Shua_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                });
            }
            if (EnemyExist("TripodFish_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                });
            }
            if (EnemyExist("TheCrow_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Hunter_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=3},
                });
            }
            if (Flowering)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Flowers.GetRandom(), enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Flowers.GetRandom(), enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Flowers.GetRandom(), enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=3},
                });
            }
            for (int i = 0; i < 20; i++)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = GreyScaleRedSource(true), enemySlot=1},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                new FieldEnemy(){enemyName = GreyScaleSupport(true), enemySlot=3},
                });
                if (SaltEnemies.rando > 33 && Flowering)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = GreyScaleRedSource(true), enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = Flowers.GetRandom(), enemySlot=4},
                    });
                }
                else if (Flowering)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = GreyScaleRedSource(true), enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = GreyScaleSupport(true), enemySlot=3},
                    new FieldEnemy(){enemyName = Flowers.GetRandom(), enemySlot=4},
                    });
                }
                if (SaltEnemies.rando > 66)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = GreyScaleRedSource(true), enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = GreyScaleSupport(true), enemySlot=4},
                    });
                }
                else
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = GreyScaleRedSource(true), enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = GreyScaleSupport(true), enemySlot=3},
                    new FieldEnemy(){enemyName = GreyScaleSupport(true), enemySlot=4},
                    });
                }
            }
            jarden.variations = fields.ToArray();
            jarden.CheckEncounters();
            jarden.AddEncounter();
        }
    }
    public static class ShieldPiercer
    {
        public static void ShowAbilityInfo(this AbilitySO abil)
        {
            Debug.Log(abil._abilityName);
            foreach (EffectInfo info in abil.effects)
            {
                Debug.Log(info.effect + " " + info.entryVariable);
            }
        }
        public static AbilitySO indulgence => LoadedAssetsHandler.GetEnemyAbility("Indulgence_A");
        static DamageEffect _ignore;
        public static DamageEffect Ignore
        {
            get
            {
                if (_ignore == null)
                { 
                    _ignore = ScriptableObject.CreateInstance<DamageEffect>();
                    _ignore._ignoreShield = true;
                }
                return _ignore;
            }
        }
        public static void ImagesPierce()
        {
            LoadedAssetsHandler.GetEnemy("InHisImage_EN").abilities[1].ability = Abili.Indluge.EnemyAbility().ability;
            LoadedAssetsHandler.GetEnemy("InHerImage_EN").abilities[1].ability = LoadedAssetsHandler.GetEnemy("InHisImage_EN").abilities[1].ability;
        }
        public static AbilitySO agony => LoadedAssetsHandler.GetEnemyAbility("BlissfulAgony_A");
        public static void ChoirsPierce()
        {
            LoadedAssetsHandler.GetEnemy("ChoirBoy_EN").abilities[1].ability = Abili.Agony.EnemyAbility().ability;
        }
        public static void ScreamingPierce()
        {
            if (!EnemyExist("ScreamingHomunculus_EN")) return;
            EnemySO enemy = LoadedAssetsHandler.GetEnemy("ScreamingHomunculus_EN");
            try
            {
                DamageWeakestEffect weakest = ScriptableObject.CreateInstance<DamageWeakestEffect>();
                weakest._ignoreShield = true;
                enemy.abilities[0].ability.effects[0].effect = weakest;
                enemy.abilities[0].ability._description = "Deal a Painful amount of Shield-ignoring damage to the enemy(s) with the lowest health.";
            }
            catch (Exception e)
            {
                if (DoDebugs.MiscInfo)
                {
                    Debug.LogError("screaming homunculus ability 1 shield pierce failure");
                    Debug.LogError(e.Message);
                    Debug.LogError(e.StackTrace);
                }
            }
            try
            {
                DamageStrongestEffect weakest = ScriptableObject.CreateInstance<DamageStrongestEffect>();
                weakest._ignoreShield = true;
                enemy.abilities[1].ability.effects[0].effect = weakest;
                enemy.abilities[1].ability._description = "Deal a Painful amount of Shield-ignoring damage to the enemy(s) with the highest health.";
            }
            catch (Exception e)
            {
                if (DoDebugs.MiscInfo)
                {
                    Debug.LogError("screaming homunculus ability 2 shield pierce failure");
                    Debug.LogError(e.Message);
                    Debug.LogError(e.StackTrace);
                }
            }

        }
        public static void FixNowak()
        {
            (LoadedAssetsHandler.GetCharcater("Nowak_CH").rankedData[0].rankAbilities[0].ability.effects[0].effect as DamageEffect)._ignoreShield = false;
        }
        public static void Setup()
        {
            ImagesPierce();
            ChoirsPierce();
            ScreamingPierce();
            FixNowak();
        }
    }
    public static class TortoiseSong
    {
        public static void Add(int sign)
        {
            if (!EnemyExist("StalwartTortoise_EN")) return;

            BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("TortoiseWorld.png"));

            orphHard(sign);
            gardHard(sign);
            ShieldPiercer.Setup();
        }

        public static int rarity
        {
            get
            {
                return UnityEngine.Random.Range(18, 25);
            }
        }

        public static void orphHard(int sign)
        {
            BrutalAPI.EnemyEncounter jarden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "TurtOprheeuhayfgelaygaely",
                area = 1,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = rarity,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/TortoiseSong",
                roarEvent = LoadedAssetsHandler.GetEnemyBundle("Zone01_Flarb_Hard_EnemyBundle")._roarReference.roarEvent,
                difficulty = EncounterDifficulty.Hard
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("StalwartTortoise_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            if (Gizos)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "NakedGizo_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "NakedGizo_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "NakedGizo_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            }
            if (Chap)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
                if (Supporting)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                    });
                }
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Lyssa_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            }
            if (EnemyExist("OsseousClad_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            }
            if (EnemyExist("EyePalm_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=3},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = BaseColor(true), enemySlot=0},
                new FieldEnemy(){enemyName = BaseColor(true), enemySlot=1},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = BaseColor(true), enemySlot=0},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=1},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = BaseColor(false), enemySlot=0},
                new FieldEnemy(){enemyName = BaseColor(false), enemySlot=1},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = BaseColor(false), enemySlot=0},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=1},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            if (Colophoning)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = Colophon.GetRandom(), enemySlot=0},
                new FieldEnemy(){enemyName = Colophon.GetRandom(), enemySlot=1},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                    {
                new FieldEnemy(){enemyName = Colophon.GetRandom(), enemySlot=0},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=1},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                    });
            }
            if (Spligging)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = Spligs.GetRandom(), enemySlot=0},
                new FieldEnemy(){enemyName = Spligs.GetRandom(), enemySlot=1},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                    {
                new FieldEnemy(){enemyName = Spligs.GetRandom(), enemySlot=0},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=1},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                    });
            }
            if (BowGutsing && BowSpogging)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = BowGuts.GetRandom(), enemySlot=0},
                new FieldEnemy(){enemyName = BowGuts.GetRandom(), enemySlot=1},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                    {
                new FieldEnemy(){enemyName = BowSpogs.GetRandom(), enemySlot=0},
                new FieldEnemy(){enemyName = BaseColor(false), enemySlot=1},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                    });
            }
            if (Flowering)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = Flowers.UpTo(2).GetRandom(), enemySlot=0},
                new FieldEnemy(){enemyName = Flowers.UpTo(2).GetRandom(), enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                    {
                new FieldEnemy(){enemyName = Flowers.UpTo(2).GetRandom(), enemySlot=0},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                    });
            }
            if (EnemyExist("Damocles_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Damocles_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(1, false, true), enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Damocles_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            }
            if (EnemyExist("ColossalSheo_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ColossalSheo_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomSupport(1, false, true), enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(1, false, true), enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Ophanim_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Ophanim_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
                if (EnemyExist("Seraphim_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Ophanim_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Seraphim_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                    });
                }
            }
            if (EnemyExist("TheCrow_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(1, false, true), enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Hunter_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(1, false, true), enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            }
            if (EnemyExist("FumeFactory_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "FumeFactory_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(1, false, true), enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "FumeFactory_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            }
            if (EnemyExist("LittleBeak_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(1, false, true), enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomSupport(1, false, true), enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Warbird_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(1, false, true), enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            }
            if (EnemyExist("TripodFish_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Freud_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Freud_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(1, false, true), enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Freud_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Something_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=1},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            }
            if (EnemyExist("MechanicalLens_EN") && SaltEnemies.silly > 75)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(1, false, true), enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            }
            if (EnemyExist("LivingSolvent_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=1},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
                if (Supporting)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                    });
                }
            }
            if (EnemyExist("Sigil_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            }
            if (EnemyExist("WindSong_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Shua_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Gordo_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Gordo_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Goliath_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Goliath_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            }
            if (EnemyExist("RealisticTank_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Romantic_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(1, false, true), enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
                if (Gizos)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "NakedGizo_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                    });
                }
            }
            jarden.variations = fields.ToArray();
            jarden.CheckEncounters();
            jarden.AddEncounter();
        }
        public static void gardHard(int sign)
        {
            BrutalAPI.EnemyEncounter jarden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "tortal_JAARRDEEENRRRAAAAGGHGHGHGHGH",
                area = 2,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = rarity,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/TortoiseSong",
                roarEvent = LoadedAssetsHandler.GetEnemyBundle("Zone01_Flarb_Hard_EnemyBundle")._roarReference.roarEvent,
                difficulty = EncounterDifficulty.Hard
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("StalwartTortoise_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            if (EnemyExist("SterileBud_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            }
            if (EnemyExist("ImpenetrableAngler_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ImpenetrableAngler_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Satyr_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Satyr_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Metatron_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Metatron_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            }
            if (EnemyExist("LittleAngel_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
                if (EnemyExist("Grandfather_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                    });
                }
            }
            if (EnemyExist("TitteringPeon_EN") && Flowering)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            }
            if (MultiENExist("ScreamingHomunculus_EN", "WindSong_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ScreamingHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Unterling_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Unterling_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            }
            if (EnemyExist("MiniReaper_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            }
            if (EnemyExist("EggKeeper_EN"))
            {
                if (EnemyExist("TitteringPeon_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                    });
                }
                else
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                    });
                }
            }
            if (EnemyExist("Harbinger_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Harbinger_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Harbinger_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            }
            if (MultiENExist("HowlingAvian_EN", "EggKeeper_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "HowlingAvian_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            }
            if (MultiENExist("HowlingAvian_EN", "TripodFish_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "HowlingAvian_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Iconoclast_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Iconoclast_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            }
            if (EnemyExist("RealisticTank_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Damocles_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Damocles_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            }
            if (EnemyExist("BlueFlower_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Enigma_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            }
            if (EnemyExist("ClockTower_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
                if (EnemyExist("Shua_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Shua_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                    });
                }
            }
            if (EnemyExist("Shua_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            }
            if (MultiENExist("Satyr_EN", "Sigil_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Satyr_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Scuttlerunt_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Scuttlerunt_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Scuttlerunt_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Romantic_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            }
            if (MultiENExist("Hunter_EN", "TheCrow_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            }
            if (MultiENExist("Romantic_EN", "Firebird_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            }
            jarden.variations = fields.ToArray();
            jarden.CheckEncounters();
            jarden.AddEncounter();
        }
    }
}
namespace EnemyPack.Effects
{
    public class DamageWeakestEffect : EffectSO
    {
        [SerializeField]
        public bool _directHeal = true;
        [SerializeField]
        public bool _checkCanHeal = true;
        public DeathType _deathType = DeathType.Basic;
        public bool _ignoreShield = false;
        public bool _returnKillAsSuccess;
        public bool _indirect = false;

        public override bool PerformEffect(
          CombatStats stats,
          IUnit caster,
          TargetSlotInfo[] targets,
          bool areTargetSlots,
          int entryVariable,
          out int exitAmount)
        {
            exitAmount = 0;
            bool flag = false;
            List<TargetSlotInfo> targetSlotInfoList = new List<TargetSlotInfo>();
            int num = -1;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit && target.Unit.IsAlive)
                {
                    if (num < 0)
                    {
                        targetSlotInfoList.Add(target);
                        num = target.Unit.CurrentHealth;
                    }
                    else if (target.Unit.CurrentHealth < num)
                    {
                        targetSlotInfoList.Clear();
                        targetSlotInfoList.Add(target);
                        num = target.Unit.CurrentHealth;
                    }
                    else if (target.Unit.CurrentHealth == num)
                        targetSlotInfoList.Add(target);
                }
            }
            foreach (TargetSlotInfo targetSlotInfo in targetSlotInfoList)
            {
                int targetSlotOffset = areTargetSlots ? targetSlotInfo.SlotID - targetSlotInfo.Unit.SlotID : -1;
                int amount1 = entryVariable;
                DamageInfo damageInfo;
                if (this._indirect)
                {
                    damageInfo = targetSlotInfo.Unit.Damage(amount1, (IUnit)null, this._deathType, targetSlotOffset, false, false, true);
                }
                else
                {
                    int amount2 = caster.WillApplyDamage(amount1, targetSlotInfo.Unit);
                    damageInfo = targetSlotInfo.Unit.Damage(amount2, caster, this._deathType, targetSlotOffset, ignoresShield: this._ignoreShield);
                }
                flag |= damageInfo.beenKilled;
                exitAmount += damageInfo.damageAmount;
            }
            if (!this._indirect && exitAmount > 0)
                caster.DidApplyDamage(exitAmount);
            return !this._returnKillAsSuccess ? exitAmount > 0 : flag;
        }
    }
    public class DamageStrongestEffect : EffectSO
    {
        [SerializeField]
        public bool _directHeal = true;
        [SerializeField]
        public bool _checkCanHeal = true;
        public DeathType _deathType = DeathType.Basic;
        public bool _ignoreShield = false;
        public bool _indirect = false;

        public override bool PerformEffect(
          CombatStats stats,
          IUnit caster,
          TargetSlotInfo[] targets,
          bool areTargetSlots,
          int entryVariable,
          out int exitAmount)
        {
            exitAmount = 0;
            List<TargetSlotInfo> targetSlotInfoList = new List<TargetSlotInfo>();
            int num = -1;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit && target.Unit.IsAlive)
                {
                    if (num < 0)
                    {
                        targetSlotInfoList.Add(target);
                        num = target.Unit.CurrentHealth;
                    }
                    else if (target.Unit.CurrentHealth > num)
                    {
                        targetSlotInfoList.Clear();
                        targetSlotInfoList.Add(target);
                        num = target.Unit.CurrentHealth;
                    }
                    else if (target.Unit.CurrentHealth == num)
                        targetSlotInfoList.Add(target);
                }
            }
            foreach (TargetSlotInfo targetSlotInfo in targetSlotInfoList)
            {
                int targetSlotOffset = areTargetSlots ? targetSlotInfo.SlotID - targetSlotInfo.Unit.SlotID : -1;
                int amount1 = entryVariable;
                DamageInfo damageInfo;
                if (this._indirect)
                {
                    damageInfo = targetSlotInfo.Unit.Damage(amount1, (IUnit)null, this._deathType, targetSlotOffset, false, false, true);
                }
                else
                {
                    int amount2 = caster.WillApplyDamage(amount1, targetSlotInfo.Unit);
                    damageInfo = targetSlotInfo.Unit.Damage(amount2, caster, this._deathType, targetSlotOffset, ignoresShield: this._ignoreShield);
                }
                exitAmount += damageInfo.damageAmount;
            }
            if (!this._indirect && exitAmount > 0)
                caster.DidApplyDamage(exitAmount);
            return exitAmount > 0;
        }
    }
}
