using System;
using System.Collections.Generic;
using System.Text;
using BrutalAPI;
using UnityEngine;
using static Hawthorne.Check;

namespace Hawthorne
{
    public static class BirdGroup
    {
        public static int rarity
        {
            get
            {
                int g = UnityEngine.Random.Range(6, 21);
                if (SaltEnemies.silly == 3) g *= 2;
                if (SaltEnemies.trolling == 44) g += 10;
                if (SaltEnemies.rando == 79) g += 1;
                return g;
            }
        }

        public static void Add(int sign)
        {
            if (!EnemyExist("TheCrow_EN")) return;

            BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("CrowIcon"));

            OrphMed(sign);
            OrphHard(sign);
            GardHard(sign);
        }
        public static void OrphMed(int sign)
        {
            BrutalAPI.EnemyEncounter orpheum = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "CrowOrpheumMed",
                area = 1,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = rarity / 2,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/CrowSong",
                roarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone03_GigglingMinister_Medium_EnemyBundle")._roarReference.roarEvent,
                difficulty = EncounterDifficulty.Medium
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("TheCrow_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=4},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "JumbleGuts_Flummoxing_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "JumbleGuts_Waning_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Spoggle_Ruminating_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Spoggle_Writhing_EN", enemySlot=4},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=3},
                });
            if (MultiENExist("Gizo_EN", "NakedGizo_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "NakedGizo_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                });
            }
            if (EnemyExist("LostSheep_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=4},
                });
            }
            if (EnemyExist("Enigma_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "JumbleGuts_Flummoxing_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "JumbleGuts_Clotted_EN", enemySlot=3},
                });
            }
            if (EnemyExist("DesiccatingJumbleguts_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "DesiccatingJumbleguts_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Chapman_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "JumbleGuts_Waning_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=3},
                });
            }
            if (EnemyExist("DeadPixel_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Spoggle_Spitfire_EN", enemySlot=3},
                });
            }
            if (MultiENExist("Enigma_EN", "YellowFlower_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=3},
                });
            }
            if (MultiENExist("DeadPixel_EN", "PurpleFlower_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Something_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=1},
                });
            }
            if (EnemyExist("LivingSolvent_EN") && SaltEnemies.trolling > 45 && SaltEnemies.trolling < 56)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=4},
                });
            }
            if (EnemyExist("WindSong_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                });
            }
            if (EnemyExist("FumeFactory_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "FumeFactory_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Sigil_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=4},
                });
            }
            if (EnemyExist("EyePalm_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "JumbleGuts_Clotted_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Lyssa_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
                });
            }
            if (MultiENExist("Illusion_EN", "FakeAngel_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                });
            }
            if (MultiENExist("BondedJumbleGuts_EN", "AnnoyingJumbleGuts_EN", "ParasiticJumbleGuts_EN", "MalignantJumbleGuts_EN", "ArtisticJumbleGuts_EN", "WaxingJumbleGuts_EN"))
            {
                if (SaltEnemies.trolling < 16)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "BondedJumbleGuts_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "JumbleGuts_Hollowing_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=3},
                    });
                }
                else if (SaltEnemies.trolling < 35)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "AnnoyingJumbleGuts_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=3},
                    });
                }
                else if (SaltEnemies.trolling < 45)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "MalignantJumbleGuts_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
                    });
                }
                else if (SaltEnemies.trolling < 62)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "ArtisticJumbleGuts_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                    });
                }
                else if (SaltEnemies.trolling < 78)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "WaxingJumbleGuts_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=2},
                    });
                }
                else if (EnemyExist("Gizo_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "ParasiticJumbleGuts_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=2},
                    });
                }
                else
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "ParasiticJumbleGuts_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
                    });
                }
            }
            if (MultiENExist("AmphibiousSpoggle_EN", "IchtyosatedSpoggle_EN", "EclipsedSpoggle_EN", "FoamingSpoggle_EN", "NecromanticSpoggle_EN", "PoolingSpoggle_EN"))
            {
                if (SaltEnemies.trolling < 16)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "AmphibiousSpoggle_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Spoggle_Ruminating_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=3},
                    });
                }
                else if (SaltEnemies.trolling < 35)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "IchtyosatedSpoggle_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=3},
                    });
                }
                else if (SaltEnemies.trolling < 45)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "EclipsedSpoggle_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
                    });
                }
                else if (SaltEnemies.trolling < 62)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "FoamingSpoggle_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=2},
                    });
                }
                else if (SaltEnemies.trolling < 78)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "NecromanticSpoggle_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                    });
                }
                else if (EnemyExist("Gizo_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "PoolingSpoggle_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=2},
                    });
                }
                else
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "PoolingSpoggle_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
                    });
                }
            }
            if (EnemyExist("Pacemaker_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Pacemaker_EN", enemySlot=3},
                });
            }
            if (MultiENExist("DefeatedColophon_EN", "ComposedColophon_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "DefeatedColophon_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ComposedColophon_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ComposedColophon_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "DefeatedColophon_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=4},
                });
                if (EnemyExist("Enigma_EN") && SaltEnemies.silly > 50)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "ComposedColophon_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "ComposedColophon_EN", enemySlot=4},
                    });
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "ComposedColophon_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "DefeatedColophon_EN", enemySlot=4},
                    });
                }
            }
            if (EnemyExist("ReflectedHound_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ReflectedHound_EN", enemySlot=1},
                });
            }
            if (EnemyExist("OsseousClad_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=3},
                });
            }
            if (EnemyExist("ColossalSheo_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ColossalSheo_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=3},
                });
            }
            if (MultiENExist("RougeWailingSplugling_EN", "RougeBellowingSplugling_EN", "RougeFesteringSplugling_EN", "RougeWeepingSplugling_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "RougeWailingSplugling_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "RougeBellowingSplugling_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "RougeFesteringSplugling_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "RougeWeepingSplugling_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "RougeBellowingSplugling_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=4},
                });
                if (EnemyExist("LostSheep_EN") && SaltEnemies.silly < 50)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "RougeFesteringSplugling_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "RougeWailingSplugling_EN", enemySlot=4},
                    });
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "RougeWeepingSplugling_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=4},
                    });
                }
            }
            if (MultiENExist("RogueWailingSplugling_EN", "RogueBellowingSplugling_EN", "RogueFesteringSplugling_EN", "RogueWeepingSplugling_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "RogueWailingSplugling_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "RogueBellowingSplugling_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "RogueFesteringSplugling_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "RogueWeepingSplugling_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "RogueBellowingSplugling_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=4},
                });
                if (EnemyExist("LostSheep_EN") && SaltEnemies.silly < 50)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "RogueFesteringSplugling_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "RogueWailingSplugling_EN", enemySlot=4},
                    });
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "RogueWeepingSplugling_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=4},
                    });
                }
            }
            if (EnemyExist("LittleBeak_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=2},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(1), enemySlot=3},
                });
            }
            if (EnemyExist("Warbird_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                });
            }
            if (EnemyExist("Hunter_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomRedColor(false, true, false), enemySlot=2},
                });
            }
            if (EnemyExist("FumeFactory_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "FumeFactory_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "FumeFactory_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomRedColor(false, true, false), enemySlot=2},
                });
            }
            if (BirdScale)
            {
                for (int i = 0; i < 4; i++)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=2},
                    });
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=2},
                    });
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=2},
                    });
                }
            }
            orpheum.variations = fields.ToArray();
            orpheum.AddEncounter();
        }
        public static void OrphHard(int sign)
        {
            BrutalAPI.EnemyEncounter orpheum = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "CrowOrpheumHard",
                area = 1,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = rarity,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/CrowSong",
                roarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone03_GigglingMinister_Medium_EnemyBundle")._roarReference.roarEvent,
                difficulty = EncounterDifficulty.Hard
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("TheCrow_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=4},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "WrigglingSacrifice_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                });
            if (EnemyExist("LostSheep_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Spoggle_Resonant_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Spoggle_Spitfire_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=4},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "JumbleGuts_Waning_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "JumbleGuts_Hollowing_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "JumbleGuts_Flummoxing_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                });
            if (Gizos)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Spoggle_Spitfire_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NakedGizo_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=4},
                });
            }
            if (Chap)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "JumbleGuts_Hollowing_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=4},
                });
            }
            if (EnemyExist("DesiccatingJumbleguts_EN") && Gizos)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "DesiccatingJumbleguts_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "NakedGizo_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=3},
                });
            }
            if (EnemyExist("PerforatedSpoggle_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "PerforatedSpoggle_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Spoggle_Writhing_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=4},
                });
            }
            if (EnemyExist("Ophanim_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Ophanim_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Spoggle_Spitfire_EN", enemySlot=4},
                });
                if (EnemyExist("Seraphim_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Ophanim_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Seraphim_EN", enemySlot=3},
                    });
                }
            }
            if (EnemyExist("Seraphim_EN") && SaltEnemies.trolling > 82)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Seraphim_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Spoggle_Spitfire_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=4},
                });
            }
            if (Supporting)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=4},
                });
                if (Gizos)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=4},
                    });
                }
                if (Chap)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=4},
                    });
                }
                if (Flowering && SaltEnemies.silly < 46)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=4},
                    });
                }
                if (EnemyExist("EyePalm_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=4},
                    });
                }
            }
            if (EnemyExist("Something_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                });
                if (Gizos && SaltEnemies.trolling == 37)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Something_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=2},
                    });
                }
            }
            if (MultiENExist("Freud_EN", "EyePalm_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Freud_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=3},
                });
                if (Supporting)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Freud_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=3},
                    });
                }
            }
            if (MultiENExist("Illusion_EN", "FakeAngel_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                });
            }
            if (Flowering && EnemyExist("Lyssa_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=3},
                });
            }
            if (Flowering && EnemyExist("Something_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=3},
                });
            }
            if (MultiENExist("RealisticTank_EN", "FakeAngel_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=3},
                });
            }
            if (EnemyExist("StalwartTortoise_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "WrigglingSacrifice_EN", enemySlot=4},
                });
            }
            if (EnemyExist("WindSong_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=4},
                });
                if (EnemyExist("EyePalm_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=4},
                    });
                }
            }
            if (EnemyExist("LivingSolvent_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "JumbleGuts_Hollowing_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=4},
                });
            }
            if (EnemyExist("Sigil_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=4},
                });
                if (Chap)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=4},
                    });
                }
                if (Gizos)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=3},
                    });
                }
                if (Supporting)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=4},
                    });
                }
                if (Colophoning)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = Colophon[3], enemySlot=2},
                    new FieldEnemy(){enemyName = Colophon[0], enemySlot=3},
                    new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=4},
                    });
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = Colophon[2], enemySlot=2},
                    new FieldEnemy(){enemyName = Colophon[1], enemySlot=3},
                    new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=4},
                    });
                }
                if (EnemyExist("OsseousClad_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "JumbleGuts_Waning_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=4},
                    });
                }
            }
            if (EnemyExist("Skyloft_EN") && SaltEnemies.trolling == 77)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=4},
                });
            }
            if (EnemyExist("EyePalm_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "JumbleGuts_Hollowing_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=4},
                });
            }
            if (EnemyExist("Merced_EN") && Flowering && SaltEnemies.silly > 75)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=4},
                });
            }
            if (EnemyExist("Shua_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Nameless_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Nameless_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "JumbleGuts_Clotted_EN", enemySlot=4},
                });
            }
            if (EnemyExist("Lyssa_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Spoggle_Ruminating_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "JumbleGuts_Hollowing_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=3},
                });
                if (EnemyExist("StalwartTortoise_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=4},
                    });
                }
                if (EnemyExist("RealisticTank_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=4},
                    });
                }
            }
            if (EnemyExist("GlassFigurine_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "GlassFigurine_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                });
                if (Gizos && SaltEnemies.silly == 27)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "GlassFigurine_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=2},
                    });
                }
            }
            if (BowGutsing)
            {
                if (SaltEnemies.rando > 78)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = BowGuts[0], enemySlot=1},
                    new FieldEnemy(){enemyName = BowGuts[4], enemySlot=2},
                    new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                    });
                }
                if (SaltEnemies.rando > 78)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = BowGuts[1], enemySlot=1},
                    new FieldEnemy(){enemyName = BowGuts[3], enemySlot=2},
                    new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                    });
                }
                if (SaltEnemies.rando > 78 && Gizos)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = BowGuts[5], enemySlot=1},
                    new FieldEnemy(){enemyName = BowGuts[2], enemySlot=2},
                    new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=3},
                    });
                }
                if (SaltEnemies.rando > 78 && EnemyExist("WindSong_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = BowGuts[1], enemySlot=1},
                    new FieldEnemy(){enemyName = BowGuts[3], enemySlot=2},
                    new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=4},
                    });
                }
                if (SaltEnemies.rando > 78 && EnemyExist("Lyssa_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = BowGuts[0], enemySlot=1},
                    new FieldEnemy(){enemyName = BowGuts[5], enemySlot=2},
                    new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=3},
                    });
                }
                if (SaltEnemies.rando > 78 && Chap)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = BowGuts[4], enemySlot=1},
                    new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=3},
                    });
                }
                if (SaltEnemies.rando > 78 && Supporting)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = BowGuts[2], enemySlot=1},
                    new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                    });
                }
                if (SaltEnemies.rando > 78)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = BowGuts[1], enemySlot=1},
                    new FieldEnemy(){enemyName = "JumbleGuts_Flummoxing_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                    });
                }
            }
            if (BowSpogging)
            {
                if (SaltEnemies.rando > 78)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = BowSpogs[0], enemySlot=1},
                    new FieldEnemy(){enemyName = BowSpogs[1], enemySlot=2},
                    new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                    });
                }
                if (SaltEnemies.rando > 78)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = BowSpogs[2], enemySlot=1},
                    new FieldEnemy(){enemyName = BowSpogs[3], enemySlot=2},
                    new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=3},
                    });
                }
                if (SaltEnemies.rando > 78 && EnemyExist("Something_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = BowSpogs[1], enemySlot=1},
                    new FieldEnemy(){enemyName = BowSpogs[5], enemySlot=2},
                    new FieldEnemy(){enemyName = "Something_EN", enemySlot=3},
                    });
                }
                if (SaltEnemies.rando > 78 && Gizos)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = BowSpogs[2], enemySlot=1},
                    new FieldEnemy(){enemyName = "Spoggle_Writhing_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "NakedGizo_EN", enemySlot=3},
                    });
                }
                if (SaltEnemies.rando > 78 && EnemyExist("Seraphim_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = BowSpogs[3], enemySlot=1},
                    new FieldEnemy(){enemyName = BowSpogs[1], enemySlot=2},
                    new FieldEnemy(){enemyName = "Seraphim_EN", enemySlot=3},
                    });
                }
                if (SaltEnemies.rando > 78 && EnemyExist("Illusion_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = BowSpogs[0], enemySlot=1},
                    new FieldEnemy(){enemyName = BowSpogs[3], enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                    });
                }
                if (SaltEnemies.rando > 78 && EnemyExist("Pacemaker_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = BowSpogs[5], enemySlot=1},
                    new FieldEnemy(){enemyName = BowSpogs[4], enemySlot=2},
                    new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                    });
                }
                if (SaltEnemies.rando > 78 && EnemyExist("EyePalm_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = BowSpogs[0], enemySlot=1},
                    new FieldEnemy(){enemyName = BowSpogs[2], enemySlot=2},
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=4},
                    });
                }
                if (SaltEnemies.rando > 78)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = BowSpogs[0], enemySlot=1},
                    new FieldEnemy(){enemyName = BowSpogs[4], enemySlot=2},
                    new FieldEnemy(){enemyName = "WrigglingSacrifice_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=4},
                    });
                }
            }
            if (EnemyExist("Goliath_EN") && SaltEnemies.trolling > 33)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Goliath_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "JumbleGuts_Hollowing_EN", enemySlot=3},
                });
                if (EnemyExist("RusticJumbleguts_EN") && SaltEnemies.silly < 66)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Goliath_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "RusticJumbleguts_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("OsseousClad_EN") && SaltEnemies.silly > 33)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Goliath_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=3},
                    });
                }
            }
            if (EnemyExist("ReflectedHound_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ReflectedHound_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=4},
                });
            }
            if (Colophoning)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Colophon[2], enemySlot=1},
                new FieldEnemy(){enemyName = Colophon[1], enemySlot=2},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=4},
                });
                if (SaltEnemies.trolling > 80)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = Colophon[3], enemySlot=1},
                    new FieldEnemy(){enemyName = Colophon[2], enemySlot=2},
                    new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                    });
                }
                if (Gizos)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = Colophon[1], enemySlot=1},
                    new FieldEnemy(){enemyName = Colophon[3], enemySlot=2},
                    new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=3},
                    });
                }
                if (Supporting)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = Colophon[0], enemySlot=1},
                    new FieldEnemy(){enemyName = Colophon[3], enemySlot=2},
                    new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("LivingSolvent_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = Colophon[0], enemySlot=1},
                    new FieldEnemy(){enemyName = Colophon[3], enemySlot=2},
                    new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("Gordo_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = Colophon[0], enemySlot=1},
                    new FieldEnemy(){enemyName = Colophon[1], enemySlot=2},
                    new FieldEnemy(){enemyName = "Gordo_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("Lyssa_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = Colophon[2], enemySlot=1},
                    new FieldEnemy(){enemyName = Colophon[1], enemySlot=2},
                    new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=3},
                    });
                }
            }
            if (EnemyExist("OsseousClad_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=4},
                });
                if (Chap)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=4},
                    });
                }
                if (SaltEnemies.trolling == 95 || SaltEnemies.trolling < 17)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Spoggle_Ruminating_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Spoggle_Resonant_EN", enemySlot=4},
                    });
                }
            }
            if (EnemyExist("ColossalSheo_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ColossalSheo_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Spoggle_Resonant_EN", enemySlot=4},
                });
            }
            if (Spligging)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Spligs[0], enemySlot=1},
                new FieldEnemy(){enemyName = Spligs[3], enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Spligs[1], enemySlot=1},
                new FieldEnemy(){enemyName = Spligs[2], enemySlot=2},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "WrigglingSacrifice_EN", enemySlot=4},
                });
                if (Gizos)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = Spligs[0], enemySlot=1},
                    new FieldEnemy(){enemyName = Spligs[2], enemySlot=2},
                    new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=3},
                    });
                }
                if (Chap)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = Spligs[1], enemySlot=1},
                    new FieldEnemy(){enemyName = Spligs[3], enemySlot=2},
                    new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=4},
                    });
                }
                if (Supporting)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = Spligs[2], enemySlot=1},
                    new FieldEnemy(){enemyName = Spligs[3], enemySlot=2},
                    new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=4},
                    });
                }
                if (EnemyExist("Grandfather_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = Spligs[1], enemySlot=1},
                    new FieldEnemy(){enemyName = Spligs[0], enemySlot=2},
                    new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("ReflectedHound_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = Spligs[2], enemySlot=1},
                    new FieldEnemy(){enemyName = Spligs[3], enemySlot=2},
                    new FieldEnemy(){enemyName = "ReflectedHound_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("Freud_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = Spligs[0], enemySlot=1},
                    new FieldEnemy(){enemyName = Spligs[2], enemySlot=2},
                    new FieldEnemy(){enemyName = "Freud_EN", enemySlot=3},
                    });
                }
            }
            if (EnemyExist("Romantic_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Spoggle_Writhing_EN", enemySlot=4},
                });
            }
            if (EnemyExist("LittleBeak_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=2},
                });
                string en = RandomOrph;
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=1},
                new FieldEnemy(){enemyName = en, enemySlot=2},
                new FieldEnemy(){enemyName = en, enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=3},
                });
            }
            if (EnemyExist("Warbird_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=3},
                });
            }
            if (EnemyExist("Hunter_EN"))
            {
                string en = RandomOrph;
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=1},
                new FieldEnemy(){enemyName = en, enemySlot=2},
                new FieldEnemy(){enemyName = en, enemySlot=3},
                new FieldEnemy(){enemyName = en, enemySlot=4},
                });
                if (EnemyExist("LivingSolvent_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("Ophanim_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Ophanim_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=4},
                    });
                }
            }
            if (BirdScale)
            {
                for (int i = 0; i < 4; i++)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=4},
                    });
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=4},
                    });
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=3},
                    });
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=4},
                    });
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=4},
                    });
                }
                fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=4},
                    });
            }
            if (EnemyExist("FumeFactory_EN"))
            {
                string en = RandomOrph;
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "FumeFactory_EN", enemySlot=1},
                new FieldEnemy(){enemyName = en, enemySlot=2},
                new FieldEnemy(){enemyName = en, enemySlot=3},
                new FieldEnemy(){enemyName = en, enemySlot=4},
                });
                if (EnemyExist("Shua_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Shua_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "FumeFactory_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("Seraphim_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "FumeFactory_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Seraphim_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=4},
                    });
                }
            }
            orpheum.variations = fields.ToArray();
            orpheum.AddEncounter();
        }
        public static void GardHard(int sign)
        {
            BrutalAPI.EnemyEncounter orpheum = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "CrowGardenHard",
                area = 2,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = rarity,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/CrowSong",
                roarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone03_GigglingMinister_Medium_EnemyBundle")._roarReference.roarEvent,
                difficulty = EncounterDifficulty.Hard
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("TheCrow_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=4},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=4},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=4},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=3},
                });
            if (EnemyExist("ScreamingHomunculus_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ScreamingHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ScreamingHomunculus_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ScreamingHomunculus_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=4},
                });
                if (EnemyExist("TitteringPeon_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "ScreamingHomunculus_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=4},
                    });
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "ScreamingHomunculus_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=4},
                    });
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "ScreamingHomunculus_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=4},
                    });
                    if (EnemyExist("GlassFigurine_EN") && SaltEnemies.trolling == 55)
                    {
                        fields.Add(new FieldEnemy[]
                        {
                        new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                        new FieldEnemy(){enemyName = "GlassFigurine_EN", enemySlot=2},
                        new FieldEnemy(){enemyName = "ScreamingHomunculus_EN", enemySlot=3},
                        new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=4},
                        });
                    }
                    if (EnemyExist("EggKeeper_EN"))
                    {
                        fields.Add(new FieldEnemy[]
                        {
                        new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                        new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=2},
                        new FieldEnemy(){enemyName = "ScreamingHomunculus_EN", enemySlot=3},
                        new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=4},
                        });
                    }
                    if (EnemyExist("MiniReaper_EN"))
                    {
                        fields.Add(new FieldEnemy[]
                        {
                        new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                        new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=2},
                        new FieldEnemy(){enemyName = "ScreamingHomunculus_EN", enemySlot=3},
                        new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=4},
                        });
                    }
                }
            }
            if (EnemyExist("Unterling_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Unterling_EN", enemySlot=3},
                });
                if (EnemyExist("WindSong_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Unterling_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("Grandfather_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Unterling_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("Satyr_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Satyr_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Unterling_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("EggKeeper_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Unterling_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=4},
                    });
                }
            }
            if (EnemyExist("SterileBud_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=3},
                });
                if (EnemyExist("LittleAngel_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=3},
                    });
                }
                if (Supporting)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("Harbinger_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Harbinger_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Harbinger_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("Metatron_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Metatron_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=4},
                    });
                }
            }
            if (EnemyExist("ImpenetrableAngler_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ImpenetrableAngler_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=4},
                });
                if (EnemyExist("EyePalm_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "ImpenetrableAngler_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=4},
                    });
                }
            }
            if (EnemyExist("Metatron_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Metatron_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=4},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=3},
                });
                if (EnemyExist("Butterfly_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Metatron_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=4},
                    new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("Freud_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Metatron_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Freud_EN", enemySlot=4},
                    new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                    });
                }
            }
            if (Supporting)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=3},
                });
            }
            if (EnemyExist("LittleAngel_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=3},
                });
                if (EnemyExist("Satyr_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Satyr_EN", enemySlot=4},
                    });
                }
                if (EnemyExist("MiniReaper_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=4},
                    });
                }
                if (MultiENExist("RealisticTank_EN", "EyePalm_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=4},
                    });
                }
                if (EnemyExist("Skyloft_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=4},
                    });
                }
                if (EnemyExist("Scuttlerunt_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Scuttlerunt_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Scuttlerunt_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("GlassFigurine_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "GlassFigurine_EN", enemySlot=4},
                    });
                }
                if (EnemyExist("EggKeeper_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=4},
                    });
                }
            }
            if (EnemyExist("Satyr_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Satyr_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Satyr_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=2},
                });
            }
            if (EnemyExist("RusticJumbleguts_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "RusticJumbleguts_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=3},
                });
            }
            if (EnemyExist("MortalSpoggle_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MortalSpoggle_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MortalSpoggle_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                });
            }
            if (MultiENExist("FakeAngel_EN", "Illusion_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                });
                if (EnemyExist("WindSong_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                    });
                }
            }
            if (Flowering)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=4},
                });
                if (MultiENExist("WindSong_EN", "TripodFish_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=4},
                    });
                }
                if (EnemyExist("Merced_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Merced_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=4},
                    });
                }
                if (EnemyExist("EggKeeper_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=4},
                    });
                }
                if (EnemyExist("EyePalm_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=4},
                    });
                }
                if (EnemyExist("HowlingAvian_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "HowlingAvian_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "HowlingAvian_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=4},
                    });
                }
                if (MultiENExist("Unterling_EN", "SterileBud_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Unterling_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=4},
                    });
                }
                if (MultiENExist("FakeAngel_EN", "Illusion_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                    });
                }
                if (EnemyExist("TitteringPeon_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=4},
                    });
                }
                if (Supporting)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=4},
                    });
                }
            }
            if (EnemyExist("LivingSolvent_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=2},
                });
            }
            if (EnemyExist("WindSong_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=4},
                });
                if (EnemyExist("EggKeeper_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("ScreamingHomunculus_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "ScreamingHomunculus_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("TitteringPeon_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("GlassFigurine_EN") && SaltEnemies.silly > 89)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "GlassFigurine_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=3},
                    });
                }
                if (MultiENExist("LittleAngel_EN", "RedFlower_EN") && SaltEnemies.trolling == 16)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=4},
                    });
                }
            }
            if (EnemyExist("Sigil_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=4},
                });
                if (EnemyExist("SterileBud_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=4},
                    });
                }
            }
            if (EnemyExist("RealisticTank_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=4},
                });
            }
            if (MultiENExist("ClockTower_EN", "FakeAngel_EN", "BlueFlower_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=3},
                });
            }
            if (EnemyExist("TheCrow_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Grandfather_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=3},
                });
                if (EnemyExist("InfernalDrummer_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "InfernalDrummer_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=3},
                    });
                }
            }
            if (EnemyExist("MiniReaper_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=4},
                });
                if (EnemyExist("ImpenetrableAngler_EN") && SaltEnemies.silly == 85)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "ImpenetrableAngler_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=4},
                    });
                }
            }
            if (EnemyExist("EyePalm_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=4},
                });
                if (EnemyExist("Unterling_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Unterling_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Unterling_EN", enemySlot=4},
                    });
                }
                if (EnemyExist("ScreamingHomunculus_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "ScreamingHomunculus_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "ScreamingHomunculus_EN", enemySlot=4},
                    });
                }
            }
            if (EnemyExist("Butterfly_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=4},
                });
                if (EnemyExist("TitteringPeon_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=4},
                    });
                }
                if (EnemyExist("StalwartTortoise_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=4},
                    });
                }
                if (EnemyExist("EggKeeper_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=4},
                    });
                }
            }
            if (EnemyExist("Shua_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Nameless_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Nameless_EN", enemySlot=4},
                });
                if (EnemyExist("Psychopomp_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Psychopomp_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Nameless_EN", enemySlot=4},
                    });
                }
            }
            if (EnemyExist("TripodFish_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=3},
                });
                if (EnemyExist("SterileBud_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("Skyloft_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=3},
                    });
                }
            }
            if (EnemyExist("InfernalDrummer_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InfernalDrummer_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InfernalDrummer_EN", enemySlot=3},
                });
                if (EnemyExist("WindSong_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "InfernalDrummer_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=3},
                    });
                }
            }
            if (EnemyExist("Harbinger_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Harbinger_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Harbinger_EN", enemySlot=4},
                });
            }
            if (EnemyExist("EggKeeper_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Damocles_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Damocles_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Damocles_EN", enemySlot=4},
                });
                if (EnemyExist("ImpenetrableAngler_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "ImpenetrableAngler_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Damocles_EN", enemySlot=4},
                    });
                }
            }
            if (EnemyExist("Romantic_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=4},
                });
                if (EnemyExist("ScreamingHomunculus_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "ScreamingHomunculus_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=4},
                    });
                }
            }
            if (EnemyExist("Firebird_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=2},
                });
                if (EnemyExist("ImpenetrableAngler_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "ImpenetrableAngler_EN", enemySlot=2},
                    });
                }
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(2), enemySlot=3},
                });
                if (EnemyExist("EggKeeper_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = RandomColor(2), enemySlot=3},
                    });
                }
                if (EnemyExist("MiniReaper_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = RandomColor(2), enemySlot=3},
                    });
                }
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                });
                if (EnemyExist("EyePalm_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=4},
                    });
                }
            }
            if (EnemyExist("Hunter_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=2},
                });
                if (EnemyExist("SterileBud_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=2},
                    });
                }
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(2, true, false), enemySlot=3},
                });
                if (EnemyExist("EggKeeper_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = RandomSupport(2, true, false), enemySlot=3},
                    });
                }
                if (EnemyExist("MiniReaper_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = RandomColor(2), enemySlot=3},
                    });
                }
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                });
                if (MultiENExist("MechanicalLens_EN", "LivingSolvent_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = RandomSupport(2, true), enemySlot=4},
                    });
                }
            }
            if (BirdScale)
            {
                for (int i = 0; i < 3; i++)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=2},
                    });
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=2},
                    });
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=2},
                    });
                }
            }
            orpheum.variations = fields.ToArray();
            orpheum.CheckEncounters();
            orpheum.AddEncounter();
        }
    }
    public static class SatyrSong
    {
        public static void Modify()
        {
            if (!BundleExist("Satyr_Hard") || !BundleRandom("Satyr_Hard")) return;
            if (!EnemyExist("Satyr_EN")) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Satyr_Hard"))._enemyBundles);
            if (EnemyExist("WindSong_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Satyr_EN",
                        "WindSong_EN",
                        "SkinningHomunculus_EN"
                    }
                });
            }
            if (EnemyExist("TripodFish_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Satyr_EN",
                        "TripodFish_EN",
                        "InHisImage_EN",
                        "InHerImage_EN"
                    }
                });
            }
            if (EnemyExist("Grandfather_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Satyr_EN",
                        "Grandfather_EN",
                        "GigglingMinister_EN",
                        "NextOfKin_EN"
                    }
                });
            }
            if (EnemyExist("EyePalm_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Satyr_EN",
                        "EyePalm_EN",
                        "EyePalm_EN",
                        "EyePalm_EN",
                        "EyePalm_EN"
                    }
                });
            }
            if (EnemyExist("MortalSpoggle_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Satyr_EN",
                        "MortalSpoggle_EN",
                        "SkinningHomunculus_EN",
                        "ShiveringHomunculus_EN",
                    }
                });
            }
            if (Flowering)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Satyr_EN",
                        "RedFlower_EN",
                        "InHisImage_EN",
                        "InHerImage_EN",
                        "NextOfKin_EN",
                    }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Satyr_EN",
                        "PurpleFlower_EN",
                        "GigglingMinister_EN",
                        "InHerImage_EN",
                    }
                });
                if (MultiENExist("WindSong_EN", "EggKeeper_EN"))
                {
                    list.Add(new RandomEnemyGroup
                    {
                        _enemyNames = new string[]
                    {
                        "Satyr_EN",
                        "RedFlower_EN",
                        "WindSong_EN",
                        "EggKeeper_EN",
                    }
                    });
                }
            }
            if (EnemyExist("EggKeeper_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Satyr_EN",
                        "EggKeeper_EN",
                        "SkinningHomunculus_EN",
                        "ShiveringHomunculus_EN"
                    }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Satyr_EN",
                        "EggKeeper_EN",
                        "InHisImage_EN",
                        "InHerImage_EN"
                    }
                });
            }
            if (EnemyExist("Damocles_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Satyr_EN",
                        "Damocles_EN",
                        "SkinningHomunculus_EN",
                    }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Satyr_EN",
                        "Damocles_EN",
                        "InHisImage_EN",
                        "InHerImage_EN"
                    }
                });
            }
            if (EnemyExist("Romantic_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Satyr_EN",
                        "Romantic_EN",
                        "InHisImage_EN",
                        "InHisImage_EN",
                    }
                });
                if (EnemyExist("MiniReaper_EN"))
                {
                    list.Add(new RandomEnemyGroup
                    {
                        _enemyNames = new string[]
                        {
                        "Satyr_EN",
                        "Romantic_EN",
                        "GigglingMinister_EN",
                        "MiniReaper_EN"
                        }
                    });
                }
            }
            if (EnemyExist("Hunter_EN"))
            {
                if (EnemyExist("WindSong_EN"))
                {
                    list.Add(new RandomEnemyGroup
                    {
                        _enemyNames = new string[]
                    {
                        "Satyr_EN",
                        "Hunter_EN",
                        "WindSong_EN",
                    }
                    });
                }
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Satyr_EN",
                        "Hunter_EN",
                        "InHisImage_EN",
                        "InHerImage_EN"
                    }
                });
            }
            if (EnemyExist("Firebird_EN"))
            {
                if (EnemyExist("LivingSolvent_EN"))
                {
                    list.Add(new RandomEnemyGroup
                    {
                        _enemyNames = new string[]
                    {
                        "Satyr_EN",
                        "Firebird_EN",
                        "LivingSolvent_EN",
                    }
                    });
                }
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Satyr_EN",
                        "Firebird_EN",
                        "SkinningHomunculus_EN",
                    }
                });
            }
            if (EnemyExist("TheCrow_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Satyr_EN",
                        "TheCrow_EN",
                        RandomColor(2),
                    }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Satyr_EN",
                        "TheCrow_EN",
                        "GigglingMinister_EN",
                    }
                });
            }
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Satyr_Hard"))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified Satyr Garden");
        }
    }
    public static class UnMungGroup
    {
        public static void Add(int sign)
        {
            if (!EnemyExist("TeachaMantoFish_EN")) return;

            //BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("CrowIcon"));

            GardHard(sign);
        }
        public static void GardHard(int sign)
        {
            BrutalAPI.EnemyEncounter jarden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "UnMungGarden",
                area = 2,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = 1,
                signType = (SignType)sign,
                musicEvent = LoadedAssetsHandler.GetEnemyBundle("Zone01_Mung_Easy_EnemyBundle")._musicEventReference,
                roarEvent = LoadedAssetsHandler.GetEnemyBundle("Zone01_Mung_Easy_EnemyBundle")._roarReference.roarEvent,
                difficulty = EncounterDifficulty.Hard
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("TeachaMantoFish_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TeachaMantoFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TeachaMantoFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                });
            if (EnemyExist("EggKeeper_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TeachaMantoFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Shua_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TeachaMantoFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=4},
                });
            }
            if (EnemyExist("Harbinger_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TeachaMantoFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Harbinger_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=2},
                });
            }
            if (EnemyExist("SterileBud_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TeachaMantoFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=2},
                });
            }
            if (EnemyExist("TitteringPeon_EN") && Flowering)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TeachaMantoFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=2},
                });
            }
            if (EnemyExist("MechanicalLens_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TeachaMantoFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=2},
                });
            }
            if (Supporting && EnemyExist("MiniReaper_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TeachaMantoFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=3},
                });
            }
            if (MultiENExist("Miriam_EN", "Merced_EN") && SaltEnemies.silly == 77)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TeachaMantoFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Miriam_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Damocles_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "TeachaMantoFish_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Damocles_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Damocles_EN", enemySlot=2},
                });
            }
            jarden.variations = fields.ToArray();
            jarden.AddEncounter();
        }
    }
    public static class SomethingSong
    {
        public static int rarity
        {
            get
            {
                return SaltEnemies.trolling == 74 ? 30 : 15;
            }
        }

        public static void Add(int sign)
        {
            if (!EnemyExist("Something_EN")) return;

            BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("SomethingIcon"));

            OrphMed(sign);
            OrphHard(sign);
        }
        public static void OrphMed(int sign)
        {
            BrutalAPI.EnemyEncounter orpheum = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "SomethingOrpheumMed",
                area = 1,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = rarity,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/SomethingTheme",
                roarEvent = LoadedAssetsHandler.GetEnemy("TaMaGoa_EN").damageSound,
                difficulty = EncounterDifficulty.Medium
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("Something_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "JumbleGuts_Clotted_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Derogatory_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Derogatory_EN", enemySlot=4},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "JumbleGuts_Hollowing_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "JumbleGuts_Waning_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Spoggle_Ruminating_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Spoggle_Resonant_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Spoggle_Ruminating_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                });
            if (Gizos)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=1},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "JumbleGuts_Waning_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Spoggle_Spitfire_EN", enemySlot=2},
                });
            }
            if (Chap)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=3},
                });
            }
            if (Supporting)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=3},
                });
                if (Gizos)
                {
                    fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "NakedGizo_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=3},
                });
                }
            }
            if (EnemyExist("PerforatedSpoggle_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "PerforatedSpoggle_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Spoggle_Writhing_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Seraphim_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Seraphim_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "JumbleGuts_Clotted_EN", enemySlot=2},
                });
                if (BowGutsing)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Seraphim_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = BowGuts[0], enemySlot=2},
                    });
                }
            }
            if (EnemyExist("TheCrow_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=1},
                });
            }
            if (Flowering)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=1},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                });
            }
            if (EnemyExist("FumeFactory_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "FumeFactory_EN", enemySlot=1},
                });
            }
            if (EnemyExist("Grandfather_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=1},
                });
            }
            if (EnemyExist("LivingSolvent_EN") && SaltEnemies.trolling == 78)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=1},
                });
            }
            if (EnemyExist("Sigil_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Skyloft_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=2},
                });
            }
            if (EnemyExist("EyePalm_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Merced_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=1},
                });
            }
            if (EnemyExist("Nameless_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Nameless_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Nameless_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Derogatory_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Derogatory_EN", enemySlot=4},
                });
            }
            if (EnemyExist("Lyssa_EN"))
            {
                if (SaltEnemies.trolling > 64 && SaltEnemies.trolling < 84)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=2},
                    });
                }
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Spoggle_Spitfire_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=2},
                });
            }
            if (BowGutsing)
            {
                if (SaltEnemies.silly > 50)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = BowGuts[0], enemySlot=1},
                    new FieldEnemy(){enemyName = BowGuts[2], enemySlot=2},
                    });
                }
                else
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = BowGuts[1], enemySlot=1},
                    new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
                    });
                }
            }
            if (BowSpogging)
            {
                if (SaltEnemies.trolling > 50)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = BowSpogs[0], enemySlot=1},
                    new FieldEnemy(){enemyName = BowSpogs[1], enemySlot=2},
                    });
                }
                else
                {
                    if (Gizos)
                    {
                        fields.Add(new FieldEnemy[]
                        {
                        new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                        new FieldEnemy(){enemyName = BowSpogs[2], enemySlot=1},
                        new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=2},
                        });
                    }
                    else
                    {
                        fields.Add(new FieldEnemy[]
                        {
                        new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                        new FieldEnemy(){enemyName = BowSpogs[2], enemySlot=1},
                        new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                        });
                    }
                }
            }
            if (Colophoning)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Colophon[0], enemySlot=1},
                new FieldEnemy(){enemyName = Colophon[1], enemySlot=2},
                }); 
                if (SaltEnemies.rando > 50)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = Colophon[2], enemySlot=1},
                    new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                    });
                }
                else
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = Colophon[3], enemySlot=1},
                    new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                    });
                }
            }
            if (EnemyExist("ReflectedHound_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ReflectedHound_EN", enemySlot=1},
                });
            }
            if (EnemyExist("OsseousClad_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "JumbleGuts_Hollowing_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Spoggle_Resonant_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=2},
                });
            }
            if (Spligging)
            {
                if (SaltEnemies.trolling > 25 && SaltEnemies.trolling < 75)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = Spligs[0], enemySlot=1},
                    new FieldEnemy(){enemyName = Spligs[1], enemySlot=2},
                    });
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = Spligs[2], enemySlot=1},
                    new FieldEnemy(){enemyName = Spligs[3], enemySlot=2},
                    });
                }
                else
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = Spligs[0], enemySlot=1},
                    new FieldEnemy(){enemyName = Spligs[2], enemySlot=2},
                    });
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = Spligs[1], enemySlot=1},
                    new FieldEnemy(){enemyName = Spligs[3], enemySlot=2},
                    });
                }
            }
            if (EnemyExist("Hunter_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=1},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=2},
                });
            }
            if (EnemyExist("TheCrow_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=1},
                });
                if (EnemyExist("Warbird_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=2},
                    });
                }
            }
            if (EnemyExist("Warbird_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                    });
            }
            if (EnemyExist("LittleBeak_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = RandomColor(1), enemySlot=2},
                    new FieldEnemy(){enemyName = RandomSupport(1), enemySlot=3},
                    });
            }
            orpheum.variations = fields.ToArray();
            orpheum.AddEncounter();
        }
        public static void OrphHard(int sign)
        {
            BrutalAPI.EnemyEncounter orpheum = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "SomethingOrpheumHard",
                area = 1,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = rarity - 5,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/SomethingTheme",
                roarEvent = LoadedAssetsHandler.GetEnemy("TaMaGoa_EN").damageSound,
                difficulty = EncounterDifficulty.Hard
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("Something_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "JumbleGuts_Waning_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "JumbleGuts_Hollowing_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Derogatory_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Derogatory_EN", enemySlot=4},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                });
            if (Gizos)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=2},
                });
                if (EnemyExist("Damocles_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Damocles_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "NakedGizo_EN", enemySlot=2},
                    });
                }
            }
            if (Chap)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Lyssa_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "JumbleGuts_Waning_EN", enemySlot=3},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Spoggle_Spitfire_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Spoggle_Resonant_EN", enemySlot=2},
                });
            if (Colophoning)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Colophon[1], enemySlot=1},
                new FieldEnemy(){enemyName = Colophon[2], enemySlot=2},
                });
            }
            if (Flowering)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                });
            }
            if (Supporting)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                });
            }
            if (EnemyExist("OsseousClad_EN") && Spligging)
            {
                if (SaltEnemies.silly > 25 && SaltEnemies.silly < 75)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = Spligs[0], enemySlot=1},
                    new FieldEnemy(){enemyName = Spligs[3], enemySlot=2},
                    new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=3},
                    });
                }
                else
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = Spligs[1], enemySlot=1},
                    new FieldEnemy(){enemyName = Spligs[2], enemySlot=2},
                    new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=3},
                    });
                }
            }
            if (EnemyExist("DesiccatingJumbleguts_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "DesiccatingJumbleguts_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "JumbleGuts_Waning_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Ophanim_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Ophanim_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=4},
                });
            }
            if (EnemyExist("FumeFactory_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "FumeFactory_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=3},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=4},
                });
            }
            if (EnemyExist("LivingSolvent_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
                });
            }
            if (EnemyExist("WindSong_EN") && Gizos)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=2},
                });
            }
            if (EnemyExist("RealisticTank_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Derogatory_EN", enemySlot=4},
                });
            }
            if (EnemyExist("StalwartTortoise_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "WrigglingSacrifice_EN", enemySlot=3},
                });
            }
            if (EnemyExist("EyePalm_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "JumbleGuts_Hollowing_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=3},
                });
            }
            if (BowGutsing)
            {
                if (SaltEnemies.rando > 50)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = BowGuts[3], enemySlot=1},
                    new FieldEnemy(){enemyName = BowGuts[4], enemySlot=2},
                    new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=3},
                    });
                }
                else
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = BowGuts[5], enemySlot=1},
                    new FieldEnemy(){enemyName = "JumbleGuts_Waning_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "WrigglingSacrifice_EN", enemySlot=3},
                    });
                }
            }
            if (BowSpogging)
            {
                if (SaltEnemies.rando > 50)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = BowSpogs[3], enemySlot=1},
                    new FieldEnemy(){enemyName = BowSpogs[5], enemySlot=2},
                    new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=3},
                    });
                }
                else
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = BowSpogs[4], enemySlot=1},
                    new FieldEnemy(){enemyName = "Spoggle_Ruminating_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "WrigglingSacrifice_EN", enemySlot=3},
                    });
                }
            }
            if (EnemyExist("Gordo_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Gordo_EN", enemySlot=1},
                });
            }
            if (EnemyExist("Goliath_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Goliath_EN", enemySlot=1},
                });
            }
            if (EnemyExist("ColossalSheo_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ColossalSheo_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=2},
                });
            }
            if (Spligging)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Spligs[UnityEngine.Random.Range(0, 4)], enemySlot=1},
                new FieldEnemy(){enemyName = Spligs[UnityEngine.Random.Range(0, 4)], enemySlot=2},
                new FieldEnemy(){enemyName = Spligs[UnityEngine.Random.Range(0, 4)], enemySlot=3},
                });
            }
            if (EnemyExist("Damocles_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Damocles_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Romantic_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=1},
                new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=2},
                });
            }
            if (MultiENExist("Hunter_EN", "TheCrow_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=1},
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=3},
                });
                string en = RandomOrph;
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = en, enemySlot=1},
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=2},
                new FieldEnemy(){enemyName = en, enemySlot=3},
                });
                if (Fifth)
                {
                    fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=3},
                });
                }
            }
            if (MultiENExist("LittleBeak_EN", "Warbird_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "JumbleGuts_Hollowing_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=1},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=3},
                new FieldEnemy(){enemyName = RandomSupport(1), enemySlot=4},
                });
                string en = RandomOrph;
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = en, enemySlot=1},
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=2},
                new FieldEnemy(){enemyName = en, enemySlot=3},
                });
                if (EnemyExist("Hunter_EN"))
                {
                    fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=3},
                });
                }
            }
            orpheum.variations = fields.ToArray();
            orpheum.AddEncounter();
        }
    }
    public static class FreudGroup
    {
        public static int rarity
        {
            get
            {
                return SaltEnemies.silly == 39 ? 8 : 5;
            }
        }
        public static void Modify()
        {
            if (!BundleExist("DontTouchMe_Hard") || !BundleRandom("DontTouchMe_Hard")) return;
            if (!EnemyExist("Freud_EN")) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("DontTouchMe_Hard"))._enemyBundles);
            if (EnemyExist("WindSong_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Freud_EN",
                        "WindSong_EN",
                        "MusicMan_EN"
                    }
                });
            }
            if (Gizos)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Freud_EN",
                        "Gizo_EN",
                        "NakedGizo_EN"
                    }
                });
            }
            if (Chap)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Freud_EN",
                        "Chapman_EN",
                        "Chapman_EN",
                        "Chapman_EN"
                    }
                });
            }
            if (EnemyExist("Ophanim_EN") && SaltEnemies.trolling > 67)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Freud_EN",
                        "Ophanim_EN",
                    }
                });
            }
            else if (EnemyExist("Seraphim_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Freud_EN",
                        "Seraphim_EN",
                        "Seraphim_EN",
                    }
                });
            }
            if (EnemyExist("RusticJumbleguts_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Freud_EN",
                        "RusticJumbleguts_EN",
                        "Scrungie_EN"
                    }
                });
            }
            if (MultiENExist("FakeAngel_EN", "Skyloft_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Freud_EN",
                        "FakeAngel_EN",
                        "FakeAngel_EN",
                        "FakeAngel_EN",
                        "Skyloft_EN",
                    }
                });
            }
            if (Flowering)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Freud_EN",
                        "YellowFlower_EN",
                        "MusicMan_EN"
                    }
                });
                if (Supporting)
                {
                    list.Add(new RandomEnemyGroup
                    {
                        _enemyNames = new string[]
                    {
                        "Freud_EN",
                        "YellowFlower_EN",
                        "Enigma_EN"
                    }
                    });
                }
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Freud_EN",
                        "PurpleFlower_EN",
                        "Scrungie_EN"
                    }
                });
            }
            if (EnemyExist("Sigil_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Freud_EN",
                        "Sigil_EN",
                        "MusicMan_EN",
                        "MusicMan_EN",
                    }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Freud_EN",
                        "Sigil_EN",
                        "Scrungie_EN",
                        "Scrungie_EN",
                    }
                });
                if (Gizos)
                {
                    list.Add(new RandomEnemyGroup
                    {
                        _enemyNames = new string[]
                    {
                        "Freud_EN",
                        "Sigil_EN",
                        "Gizo_EN",
                        "NakedGizo_EN",
                    }
                    });
                }
            }
            if (EnemyExist("FumeFactory_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Freud_EN",
                        "FumeFactory_EN",
                        "MusicMan_EN",
                        "MusicMan_EN",
                    }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Freud_EN",
                        "FumeFactory_EN",
                        "Scrungie_EN",
                        RandomColor(1),
                    }
                });
                if (Gizos)
                {
                    list.Add(new RandomEnemyGroup
                    {
                        _enemyNames = new string[]
                    {
                        "Freud_EN",
                        "FumeFactory_EN",
                        "Gizo_EN",
                        "NakedGizo_EN",
                    }
                    });
                }
            }
            if (EnemyExist("RealisticTank_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Freud_EN",
                        "RealisticTank_EN",
                    }
                });
            }
            if (MultiENExist("ClockTower_EN", "Shua_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Freud_EN",
                        "ClockTower_EN",
                        "Shua_EN"
                    }
                });
            }
            if (EnemyExist("Grandfather_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Freud_EN",
                        "Grandfather_EN",
                        "JumbleGuts_Hollowing_EN"
                    }
                });
            }
            if (EnemyExist("Merced_EN") && Colophoning)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Freud_EN",
                        "Merced_EN",
                        Colophon[2]
                    }
                });
            }
            if (EnemyExist("Nameless_EN") && SaltEnemies.trolling == 36)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Freud_EN",
                        "Nameless_EN",
                        "Nameless_EN"
                    }
                });
            }
            if (MultiENExist("Butterfly_EN", "OsseousClad_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Freud_EN",
                        "Butterfly_EN",
                        "OsseousClad_EN"
                    }
                });
            }
            if (EnemyExist("Lyssa_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Freud_EN",
                        "Lyssa_EN",
                        "Lyssa_EN",
                    }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Freud_EN",
                        "JumbleGuts_Waning_EN",
                        "JumbleGuts_Clotted_EN",
                        "Lyssa_EN",
                    }
                });
            }
            if (BowGutsing)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Freud_EN",
                        BowGuts[UnityEngine.Random.Range(0, 3)],
                        BowGuts[UnityEngine.Random.Range(0, 3)],
                    }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Freud_EN",
                        BowGuts[UnityEngine.Random.Range(0, 3)],
                        BowGuts[UnityEngine.Random.Range(0, 3)],
                        RandomOrph
                    }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Freud_EN",
                        BowGuts[UnityEngine.Random.Range(0, 3)],
                        BowGuts[UnityEngine.Random.Range(0, 6)],
                        RandomOrph
                    }
                });
            }
            if (BowSpogging)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Freud_EN",
                        BowSpogs[UnityEngine.Random.Range(0, 3)],
                        BowSpogs[UnityEngine.Random.Range(0, 3)],
                    }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Freud_EN",
                        BowSpogs[UnityEngine.Random.Range(0, 3)],
                        BowSpogs[UnityEngine.Random.Range(0, 3)],
                        RandomOrph
                    }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Freud_EN",
                        BowSpogs[UnityEngine.Random.Range(0, 3)],
                        BowSpogs[UnityEngine.Random.Range(0, 6)],
                        RandomOrph
                    }
                });
            }
            if (EnemyExist("Pacemaker_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Freud_EN",
                        "Pacemaker_EN",
                        "MusicMan_EN",
                        "MusicMan_EN"
                    }
                });
            }
            if (EnemyExist("Goliath_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Freud_EN",
                        "Goliath_EN",
                    }
                });
            }
            if (Colophoning)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Freud_EN",
                        Colophon[0],
                        Colophon[1],
                        Colophon[1],
                    }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Freud_EN",
                        Colophon[0],
                        Colophon[3],
                        RandomOrph
                    }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Freud_EN",
                        Colophon[1],
                        Colophon[3],
                        RandomOrph
                    }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Freud_EN",
                        Colophon[2],
                        Colophon[3],
                        RandomSupport(1, true, true)
                    }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Freud_EN",
                        Colophon[0],
                        Colophon[2],
                        RandomSupport(1, false, false)
                    }
                });
            }
            if (Spligging)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Freud_EN",
                        Spligs.GetRandom(),
                        Spligs.GetRandom(),
                        Spligs.GetRandom()
                    }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Freud_EN",
                        Spligs.GetRandom(),
                        Spligs.GetRandom(),
                        "MusicMan_EN"
                    }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Freud_EN",
                        Spligs.GetRandom(),
                        Spligs.GetRandom(),
                        "Scrungie_EN"
                    }
                });
                if (Gizos)
                {
                    list.Add(new RandomEnemyGroup
                    {
                        _enemyNames = new string[]
                        {
                        "Freud_EN",
                        Spligs.GetRandom(),
                        Spligs.GetRandom(),
                        "Gizo_EN"
                        }
                    });
                }
                if (EnemyExist("ColossalSheo_EN"))
                {
                    list.Add(new RandomEnemyGroup
                    {
                        _enemyNames = new string[]
                        {
                        "Freud_EN",
                        Spligs.GetRandom(),
                        Spligs.GetRandom(),
                        "ColossalSheo_EN"
                        }
                    });
                }
                if (EnemyExist("RealisticTank_EN"))
                {
                    list.Add(new RandomEnemyGroup
                    {
                        _enemyNames = new string[]
                        {
                        "Freud_EN",
                        Spligs.GetRandom(),
                        "RealisticTank_EN"
                        }
                    });
                }
            }
            if (EnemyExist("Romantic_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Freud_EN",
                        "Romantic_EN",
                        RandomColor(1),
                        RandomOrph
                    }
                });
            }
            if (EnemyExist("Hunter_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Freud_EN",
                        "Hunter_EN",
                        RandomOrph
                    }
                });
            }
            if (EnemyExist("LittleBeak_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Freud_EN",
                        "LittleBeak_EN",
                        RandomColor(1)
                    }
                });
            }
            if (EnemyExist("Warbird_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Freud_EN",
                        "Warbird_EN",
                        RandomOrph,
                        RandomSupport(1, false, false)
                    }
                });
            }
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("DontTouchMe_Hard"))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified DontTouchMe Orpheum");
        }
        public static void Add(int sign)
        {
            if (!EnemyExist("Freud_EN")) return;
            BrutalAPI.EnemyEncounter gard = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "FreudMedium",
                area = 2,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = rarity,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/DontTouchMeTheme",
                roarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone03_SkinningHomunculus_Medium_EnemyBundle")._roarReference.roarEvent,
                difficulty = EncounterDifficulty.Medium
            };
            List<FieldEnemy[]> groups = new List<FieldEnemy[]>();
            if (EnemyExist("Freud_EN"))
            {
                groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Freud_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Freud_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Freud_EN", enemySlot=2},
                });
            }
            if (EnemyExist("StarGazer_EN") && SaltEnemies.trolling == 2)
            {
                groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Freud_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "StarGazer_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "StarGazer_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "StarGazer_EN", enemySlot=3},
                });
            }
            if (EnemyExist("EggKeeper_EN"))
            {
                groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Freud_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Freud_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=2},
                });
            }
            if (EnemyExist("BlueFlower_EN"))
            {
                groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Freud_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Freud_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=2},
                });
            }
            if (EnemyExist("RealisticTank_EN"))
            {
                groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Freud_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Metatron_EN"))
            {
                groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Freud_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Freud_EN", enemySlot = 1},
                new FieldEnemy(){enemyName = "Metatron_EN", enemySlot=2},
                });
            }
            if (Flowering)
            {
                groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Freud_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = Flowers.GetRandom(), enemySlot=1},
                new FieldEnemy(){enemyName = Flowers.GetRandom(), enemySlot=2},
                });
            }
            if (EnemyExist("Damocles_EN"))
            {
                groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Freud_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Damocles_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Damocles_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Damocles_EN", enemySlot=3},
                });
            }
            groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Freud_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = RandomColor(2), enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(2, false, false), enemySlot=2},
                });
            if (MultiENExist("Firebird_EN", "TheCrow_EN"))
            {
                groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Freud_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=3},
                });
            }
            gard.variations = groups.ToArray();
            gard.CheckEncounters();
            gard.AddEncounter();
        }
    }
    public static class GreyGroup
    {
        public static void ModifyRust()
        {
            if (!BundleExist("Rust_Hard") || !BundleRandom("Rust_Hard")) return;
            if (!EnemyExist("RusticJumbleguts_EN")) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Rust_Hard"))._enemyBundles);
            if (EnemyExist("WindSong_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "RusticJumbleguts_EN",
                        "WindSong_EN",
                        "SkinningHomunculus_EN"
                    }
                });
            }
            if (EnemyExist("EggKeeper_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "RusticJumbleguts_EN",
                        "EggKeeper_EN",
                        "ChoirBoy_EN"
                    }
                });
            }
            if (EnemyExist("Unterling_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "RusticJumbleguts_EN",
                        "Unterling_EN",
                        "GigglingMinister_EN"
                    }
                });
            }
            if (EnemyExist("GlassFigurine_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "RusticJumbleguts_EN",
                        "GlassFigurine_EN",
                        "InHisImage_EN",
                        "InHisImage_EN"
                    }
                });
            }
            if (MultiENExist("FakeAngel_EN", "Illusion_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "RusticJumbleguts_EN",
                        "FakeAngel_EN",
                        "Illusion_EN",
                        "Illusion_EN",
                    }
                });
            }
            if (MultiENExist("FakeAngel_EN", "RealisticTank_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "RusticJumbleguts_EN",
                        "FakeAngel_EN",
                        "RealisticTank_EN",
                    }
                });
            }
            if (MultiENExist("Butterfly_EN", "MiniReaper_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "RusticJumbleguts_EN",
                        "Butterfly_EN",
                        "Butterfly_EN",
                        "MiniReaper_EN",
                    }
                });
            }
            if (EnemyExist("TitteringPeon_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "RusticJumbleguts_EN",
                        "TitteringPeon_EN",
                        "SkinningHomunculus_EN"
                    }
                });
            }
            if (EnemyExist("Damocles_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "RusticJumbleguts_EN",
                        "Damocles_EN",
                        "SkinningHomunculus_EN"
                    }
                });
            }
            if (MultiENExist("Romantic_EN", "Grandfather_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "RusticJumbleguts_EN",
                        "Grandfather_EN",
                        "Romantic_EN",
                        "Romantic_EN",
                    }
                });
            }
            if (MultiENExist("Hunter_EN", "Firebird_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "RusticJumbleguts_EN",
                        "Firebird_EN",
                        "Hunter_EN",
                    }
                });
            }
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Rust_Hard"))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified Rustic Jumble Guts Garden");
        }
        public static void ModifyStone()
        {
            if (!BundleExist("Gospel_Hard") || !BundleRandom("Gospel_Hard")) return;
            if (!EnemyExist("MortalSpoggle_EN")) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Gospel_Hard"))._enemyBundles);
            if (EnemyExist("WindSong_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "MortalSpoggle_EN",
                        "WindSong_EN",
                        "SkinningHomunculus_EN"
                    }
                });
            }
            if (EnemyExist("Unterling_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "MortalSpoggle_EN",
                        "Unterling_EN",
                        "Unterling_EN"
                    }
                });
            }
            if (EnemyExist("EggKeeper_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "MortalSpoggle_EN",
                        "GigglingMinister_EN",
                        "EggKeeper_EN"
                    }
                });
            }
            if (MultiENExist("ClockTower_EN", "FakeAngel_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "MortalSpoggle_EN",
                        "ClockTower_EN",
                        "FakeAngel_EN"
                    }
                });
            }
            if (MultiENExist("TripodFish_EN", "SterileBud_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "MortalSpoggle_EN",
                        "TripodFish_EN",
                        "SterileBud_EN"
                    }
                });
            }
            if (MultiENExist("FakeAngel_EN", "Illusion_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "MortalSpoggle_EN",
                        "FakeAngel_EN",
                        "Illusion_EN",
                        "Illusion_EN",
                    }
                });
            }
            if (EnemyExist("StalwartTortoise_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "MortalSpoggle_EN",
                        "StalwartTortoise_EN",
                        "ShiveringHomunculus_EN"
                    }
                });
            }
            if (EnemyExist("TheCrow_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "MortalSpoggle_EN",
                        "TheCrow_EN",
                        "InHerImage_EN",
                        "InHisImage_EN"
                    }
                });
            }
            if (MultiENExist("MiniReaper_EN", "FakeAngel_EN") && SaltEnemies.trolling == 86)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "MortalSpoggle_EN",
                        "MiniReaper_EN",
                        "MiniReaper_EN",
                        "FakeAngel_EN"
                    }
                });
            }
            if (EnemyExist("Psychopomp_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "MortalSpoggle_EN",
                        "Psychopomp_EN",
                        "ShiveringHomunculus_EN"
                    }
                });
            }
            if (MultiENExist("MechanicalLens_EN", "FakeAngel_EN", "GlassFigurine_EN") && SaltEnemies.trolling == 31)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "MortalSpoggle_EN",
                        "MechanicalLens_EN",
                        "GlassFigurine_EN",
                        "FakeAngel_EN"
                    }
                });
            }
            if (EnemyExist("Romantic_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "MortalSpoggle_EN",
                        "Romantic_EN",
                        "InHisImage_EN",
                        "InHerImage_EN"
                    }
                });
            }
            if (MultiENExist("Firebird_EN", "TheCrow_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "MortalSpoggle_EN",
                        "TheCrow_EN",
                        "Firebird_EN"
                    }
                });
            }
            list.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                    {
                        "MortalSpoggle_EN",
                        "NextOfKin_EN",
                        "NextOfKin_EN",
                        "NextOfKin_EN",
                        "NextOfKin_EN"
                    }
            });
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Gospel_Hard"))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified Mortal Spoggle Garden");
        }
    }
}
