using System;
using System.Collections.Generic;
using System.Text;
using static Hawthorne.Check;
using BrutalAPI;

namespace Hawthorne
{
    public static class HunterGroup
    {
        public static int rarity
        {
            get
            {
                int g = UnityEngine.Random.Range(6, 21);
                if (SaltEnemies.silly == 4) g *= 2;
                if (SaltEnemies.trolling == 72) g += 10;
                if (SaltEnemies.rando == 12) g += 1;
                return g;
            }
        }

        public static void Add(int sign)
        {
            if (!EnemyExist("Hunter_EN")) return;

            BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("HunterWorld.png"));

            OrphMed(sign);
            OrphHard(sign);
            GardHard(sign);
        }
        public static void OrphMed(int sign)
        {
            BrutalAPI.EnemyEncounter orpheum = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "HunterOrphMed",
                area = 1,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = rarity / 2,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/HunterSong",
                roarEvent = "event:/Hawthorne/Roar/HunterRoar",
                difficulty = EncounterDifficulty.Medium
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("Hunter_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=4},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "JumbleGuts_Flummoxing_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "JumbleGuts_Waning_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Spoggle_Ruminating_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Spoggle_Writhing_EN", enemySlot=4},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=3},
                });
            if (MultiENExist("Gizo_EN", "NakedGizo_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "NakedGizo_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                });
            }
            if (EnemyExist("LostSheep_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=4},
                });
            }
            if (EnemyExist("Enigma_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "JumbleGuts_Flummoxing_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "JumbleGuts_Clotted_EN", enemySlot=3},
                });
            }
            if (EnemyExist("DesiccatingJumbleguts_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "DesiccatingJumbleguts_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Chapman_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "JumbleGuts_Waning_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=3},
                });
            }
            if (EnemyExist("DeadPixel_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Spoggle_Spitfire_EN", enemySlot=3},
                });
            }
            if (MultiENExist("Enigma_EN", "YellowFlower_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=3},
                });
            }
            if (MultiENExist("DeadPixel_EN", "PurpleFlower_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Something_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=1},
                });
            }
            if (EnemyExist("LivingSolvent_EN") && SaltEnemies.trolling > 45 && SaltEnemies.trolling < 56)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=4},
                });
            }
            if (EnemyExist("WindSong_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Sigil_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "JumbleGuts_Clotted_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Lyssa_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
                });
            }
            if (MultiENExist("Illusion_EN", "FakeAngel_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "BondedJumbleGuts_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "JumbleGuts_Hollowing_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=3},
                    });
                }
                else if (SaltEnemies.trolling < 35)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "AnnoyingJumbleGuts_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=3},
                    });
                }
                else if (SaltEnemies.trolling < 45)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "MalignantJumbleGuts_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
                    });
                }
                else if (SaltEnemies.trolling < 62)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "ArtisticJumbleGuts_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                    });
                }
                else if (SaltEnemies.trolling < 78)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "WaxingJumbleGuts_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=2},
                    });
                }
                else if (EnemyExist("Gizo_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "ParasiticJumbleGuts_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=2},
                    });
                }
                else
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "AmphibiousSpoggle_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Spoggle_Ruminating_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=3},
                    });
                }
                else if (SaltEnemies.trolling < 35)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "IchtyosatedSpoggle_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=3},
                    });
                }
                else if (SaltEnemies.trolling < 45)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "EclipsedSpoggle_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
                    });
                }
                else if (SaltEnemies.trolling < 62)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "FoamingSpoggle_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=2},
                    });
                }
                else if (SaltEnemies.trolling < 78)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "NecromanticSpoggle_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                    });
                }
                else if (EnemyExist("Gizo_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "PoolingSpoggle_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=2},
                    });
                }
                else
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "PoolingSpoggle_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
                    });
                }
            }
            if (EnemyExist("Pacemaker_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Pacemaker_EN", enemySlot=3},
                });
            }
            if (MultiENExist("DefeatedColophon_EN", "ComposedColophon_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "DefeatedColophon_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ComposedColophon_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ComposedColophon_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "DefeatedColophon_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=4},
                });
                if (EnemyExist("Enigma_EN") && SaltEnemies.silly > 50)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "ComposedColophon_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "ComposedColophon_EN", enemySlot=4},
                    });
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ReflectedHound_EN", enemySlot=1},
                });
            }
            if (EnemyExist("OsseousClad_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=3},
                });
            }
            if (EnemyExist("ColossalSheo_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ColossalSheo_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=3},
                });
            }
            if (MultiENExist("RougeWailingSplugling_EN", "RougeBellowingSplugling_EN", "RougeFesteringSplugling_EN", "RougeWeepingSplugling_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "RougeWailingSplugling_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "RougeBellowingSplugling_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "RougeFesteringSplugling_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "RougeWeepingSplugling_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "RougeBellowingSplugling_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=4},
                });
                if (EnemyExist("LostSheep_EN") && SaltEnemies.silly < 50)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "RougeFesteringSplugling_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "RougeWailingSplugling_EN", enemySlot=4},
                    });
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "RogueWailingSplugling_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "RogueBellowingSplugling_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "RogueFesteringSplugling_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "RogueWeepingSplugling_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "RogueBellowingSplugling_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=4},
                });
                if (EnemyExist("LostSheep_EN") && SaltEnemies.silly < 50)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "RogueFesteringSplugling_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "RogueWailingSplugling_EN", enemySlot=4},
                    });
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=2},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(1), enemySlot=3},
                });
            }
            if (EnemyExist("Warbird_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                });
            }
            if (EnemyExist("TheCrow_EN"))
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
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=2},
                    });
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=2},
                    });
                }
            }
            if (EnemyExist("FumeFactory_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "FumeFactory_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "FumeFactory_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomRedColor(false, true, false), enemySlot=2},
                });
            }
            orpheum.variations = fields.ToArray();
            orpheum.AddEncounter();
        }
        public static void OrphHard(int sign)
        {
            BrutalAPI.EnemyEncounter orpheum = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "HunterOrpheumHard",
                area = 1,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = rarity,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/HunterSong",
                roarEvent = "event:/Hawthorne/Roar/HunterRoar",
                difficulty = EncounterDifficulty.Hard
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("Hunter_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=4},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "WrigglingSacrifice_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                });
            if (EnemyExist("LostSheep_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Spoggle_Resonant_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Spoggle_Spitfire_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=4},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "JumbleGuts_Waning_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "JumbleGuts_Hollowing_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "JumbleGuts_Flummoxing_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                });
            if (Gizos)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Spoggle_Spitfire_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NakedGizo_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=4},
                });
            }
            if (Chap)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "JumbleGuts_Hollowing_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=4},
                });
            }
            if (EnemyExist("DesiccatingJumbleguts_EN") && Gizos)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "DesiccatingJumbleguts_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "NakedGizo_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=3},
                });
            }
            if (EnemyExist("PerforatedSpoggle_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Ophanim_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Spoggle_Spitfire_EN", enemySlot=4},
                });
                if (EnemyExist("Seraphim_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Ophanim_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Seraphim_EN", enemySlot=3},
                    });
                }
            }
            if (EnemyExist("Seraphim_EN") && SaltEnemies.trolling > 82)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=4},
                });
                if (Gizos)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=4},
                    });
                }
                if (Chap)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                });
                if (Gizos && SaltEnemies.trolling == 37)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Something_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=2},
                    });
                }
            }
            if (MultiENExist("Freud_EN", "EyePalm_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Freud_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=3},
                });
                if (Supporting)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=3},
                });
            }
            if (Flowering && EnemyExist("Something_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=3},
                });
            }
            if (MultiENExist("RealisticTank_EN", "FakeAngel_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=3},
                });
            }
            if (EnemyExist("StalwartTortoise_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "WrigglingSacrifice_EN", enemySlot=4},
                });
            }
            if (EnemyExist("WindSong_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=4},
                });
                if (EnemyExist("EyePalm_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "JumbleGuts_Hollowing_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=4},
                });
            }
            if (EnemyExist("Sigil_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=4},
                });
                if (Chap)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=3},
                    });
                }
                if (Supporting)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = Colophon[3], enemySlot=2},
                    new FieldEnemy(){enemyName = Colophon[0], enemySlot=3},
                    new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=4},
                    });
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=4},
                });
            }
            if (EnemyExist("Shua_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Nameless_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Spoggle_Ruminating_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "JumbleGuts_Hollowing_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=3},
                });
                if (EnemyExist("StalwartTortoise_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=4},
                    });
                }
                if (EnemyExist("RealisticTank_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "GlassFigurine_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                });
                if (Gizos && SaltEnemies.silly == 27)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = BowGuts[0], enemySlot=1},
                    new FieldEnemy(){enemyName = BowGuts[4], enemySlot=2},
                    new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                    });
                }
                if (SaltEnemies.rando > 78)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = BowGuts[1], enemySlot=1},
                    new FieldEnemy(){enemyName = BowGuts[3], enemySlot=2},
                    new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                    });
                }
                if (SaltEnemies.rando > 78 && Gizos)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = BowGuts[5], enemySlot=1},
                    new FieldEnemy(){enemyName = BowGuts[2], enemySlot=2},
                    new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=3},
                    });
                }
                if (SaltEnemies.rando > 78 && EnemyExist("WindSong_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = BowGuts[0], enemySlot=1},
                    new FieldEnemy(){enemyName = BowGuts[5], enemySlot=2},
                    new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=3},
                    });
                }
                if (SaltEnemies.rando > 78 && Chap)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = BowGuts[4], enemySlot=1},
                    new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=3},
                    });
                }
                if (SaltEnemies.rando > 78 && Supporting)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = BowGuts[2], enemySlot=1},
                    new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                    });
                }
                if (SaltEnemies.rando > 78)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = BowSpogs[0], enemySlot=1},
                    new FieldEnemy(){enemyName = BowSpogs[1], enemySlot=2},
                    new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                    });
                }
                if (SaltEnemies.rando > 78)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = BowSpogs[2], enemySlot=1},
                    new FieldEnemy(){enemyName = BowSpogs[3], enemySlot=2},
                    new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=3},
                    });
                }
                if (SaltEnemies.rando > 78 && EnemyExist("Something_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = BowSpogs[1], enemySlot=1},
                    new FieldEnemy(){enemyName = BowSpogs[5], enemySlot=2},
                    new FieldEnemy(){enemyName = "Something_EN", enemySlot=3},
                    });
                }
                if (SaltEnemies.rando > 78 && Gizos)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = BowSpogs[2], enemySlot=1},
                    new FieldEnemy(){enemyName = "Spoggle_Writhing_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "NakedGizo_EN", enemySlot=3},
                    });
                }
                if (SaltEnemies.rando > 78 && EnemyExist("Seraphim_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = BowSpogs[3], enemySlot=1},
                    new FieldEnemy(){enemyName = BowSpogs[1], enemySlot=2},
                    new FieldEnemy(){enemyName = "Seraphim_EN", enemySlot=3},
                    });
                }
                if (SaltEnemies.rando > 78 && EnemyExist("Illusion_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = BowSpogs[5], enemySlot=1},
                    new FieldEnemy(){enemyName = BowSpogs[4], enemySlot=2},
                    new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                    });
                }
                if (SaltEnemies.rando > 78 && EnemyExist("EyePalm_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Goliath_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "JumbleGuts_Hollowing_EN", enemySlot=3},
                });
                if (EnemyExist("RusticJumbleguts_EN") && SaltEnemies.silly < 66)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Goliath_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "RusticJumbleguts_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("OsseousClad_EN") && SaltEnemies.silly > 33)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Goliath_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=3},
                    });
                }
            }
            if (EnemyExist("ReflectedHound_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ReflectedHound_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=4},
                });
            }
            if (Colophoning)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Colophon[2], enemySlot=1},
                new FieldEnemy(){enemyName = Colophon[1], enemySlot=2},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=4},
                });
                if (SaltEnemies.trolling > 80)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = Colophon[3], enemySlot=1},
                    new FieldEnemy(){enemyName = Colophon[2], enemySlot=2},
                    new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                    });
                }
                if (Gizos)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = Colophon[1], enemySlot=1},
                    new FieldEnemy(){enemyName = Colophon[3], enemySlot=2},
                    new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=3},
                    });
                }
                if (Supporting)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = Colophon[0], enemySlot=1},
                    new FieldEnemy(){enemyName = Colophon[3], enemySlot=2},
                    new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("LivingSolvent_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = Colophon[0], enemySlot=1},
                    new FieldEnemy(){enemyName = Colophon[3], enemySlot=2},
                    new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("Gordo_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = Colophon[0], enemySlot=1},
                    new FieldEnemy(){enemyName = Colophon[1], enemySlot=2},
                    new FieldEnemy(){enemyName = "Gordo_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("Lyssa_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=4},
                });
                if (Chap)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Spligs[0], enemySlot=1},
                new FieldEnemy(){enemyName = Spligs[3], enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Spligs[1], enemySlot=1},
                new FieldEnemy(){enemyName = Spligs[2], enemySlot=2},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "WrigglingSacrifice_EN", enemySlot=4},
                });
                if (Gizos)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = Spligs[0], enemySlot=1},
                    new FieldEnemy(){enemyName = Spligs[2], enemySlot=2},
                    new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=3},
                    });
                }
                if (Chap)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = Spligs[1], enemySlot=1},
                    new FieldEnemy(){enemyName = Spligs[0], enemySlot=2},
                    new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("ReflectedHound_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = Spligs[2], enemySlot=1},
                    new FieldEnemy(){enemyName = Spligs[3], enemySlot=2},
                    new FieldEnemy(){enemyName = "ReflectedHound_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("Freud_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=2},
                });
                string en = RandomOrph;
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=1},
                new FieldEnemy(){enemyName = en, enemySlot=2},
                new FieldEnemy(){enemyName = en, enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=3},
                });
            }
            if (EnemyExist("Warbird_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=3},
                });
            }
            if (EnemyExist("TheCrow_EN"))
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
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=4},
                    });
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=4},
                    });
                }
                fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                new FieldEnemy(){enemyName = "FumeFactory_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=1},
                new FieldEnemy(){enemyName = en, enemySlot=2},
                new FieldEnemy(){enemyName = en, enemySlot=3},
                new FieldEnemy(){enemyName = en, enemySlot=4},
                });
                if (EnemyExist("Grandfather_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "FumeFactory_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("StalwartTortoise_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "FumeFactory_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
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
                encounterName = "HunterGardenHard",
                area = 2,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = rarity,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/HunterSong",
                roarEvent = "event:/Hawthorne/Roar/HunterRoar",
                difficulty = EncounterDifficulty.Hard
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("Hunter_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=4},
                });
            }
            if (EnemyExist("FakeAngel_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=2},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=4},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=4},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=3},
                });
            if (EnemyExist("ScreamingHomunculus_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ScreamingHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ScreamingHomunculus_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ScreamingHomunculus_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=4},
                });
                if (EnemyExist("TitteringPeon_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "ScreamingHomunculus_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=4},
                    });
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "ScreamingHomunculus_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=4},
                    });
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "ScreamingHomunculus_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=4},
                    });
                    if (EnemyExist("GlassFigurine_EN") && SaltEnemies.trolling == 55)
                    {
                        fields.Add(new FieldEnemy[]
                        {
                        new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                        new FieldEnemy(){enemyName = "GlassFigurine_EN", enemySlot=2},
                        new FieldEnemy(){enemyName = "ScreamingHomunculus_EN", enemySlot=3},
                        new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=4},
                        });
                    }
                    if (EnemyExist("EggKeeper_EN"))
                    {
                        fields.Add(new FieldEnemy[]
                        {
                        new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                        new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=2},
                        new FieldEnemy(){enemyName = "ScreamingHomunculus_EN", enemySlot=3},
                        new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=4},
                        });
                    }
                    if (EnemyExist("MiniReaper_EN"))
                    {
                        fields.Add(new FieldEnemy[]
                        {
                        new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Unterling_EN", enemySlot=3},
                });
                if (EnemyExist("WindSong_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Unterling_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("Grandfather_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Unterling_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("Satyr_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Satyr_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Unterling_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("EggKeeper_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=3},
                });
                if (EnemyExist("LittleAngel_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=3},
                    });
                }
                if (Supporting)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("Harbinger_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Harbinger_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Harbinger_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("Metatron_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ImpenetrableAngler_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=4},
                });
                if (EnemyExist("EyePalm_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Metatron_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=4},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=3},
                });
                if (EnemyExist("Butterfly_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Metatron_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=4},
                    new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("Freud_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=3},
                });
            }
            if (EnemyExist("LittleAngel_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=3},
                });
                if (EnemyExist("Satyr_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=4},
                    });
                }
                if (MultiENExist("RealisticTank_EN", "EyePalm_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=4},
                    });
                }
                if (EnemyExist("Skyloft_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=4},
                    });
                }
                if (EnemyExist("Scuttlerunt_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Scuttlerunt_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Scuttlerunt_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("GlassFigurine_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Satyr_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Satyr_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=2},
                });
            }
            if (EnemyExist("RusticJumbleguts_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "RusticJumbleguts_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=3},
                });
            }
            if (EnemyExist("MortalSpoggle_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MortalSpoggle_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MortalSpoggle_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                });
            }
            if (MultiENExist("FakeAngel_EN", "Illusion_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                });
                if (EnemyExist("WindSong_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=4},
                });
                if (MultiENExist("WindSong_EN", "TripodFish_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=4},
                    });
                }
                if (EnemyExist("Merced_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=2},
                });
            }
            if (EnemyExist("WindSong_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=4},
                });
                if (EnemyExist("EggKeeper_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("ScreamingHomunculus_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "ScreamingHomunculus_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("TitteringPeon_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("GlassFigurine_EN") && SaltEnemies.silly > 89)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "GlassFigurine_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=3},
                    });
                }
                if (MultiENExist("LittleAngel_EN", "RedFlower_EN") && SaltEnemies.trolling == 16)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=4},
                });
                if (EnemyExist("SterileBud_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=4},
                });
            }
            if (MultiENExist("ClockTower_EN", "FakeAngel_EN", "BlueFlower_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Hunter_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Grandfather_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=3},
                });
                if (EnemyExist("InfernalDrummer_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=4},
                });
                if (EnemyExist("ImpenetrableAngler_EN") && SaltEnemies.silly == 85)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "ImpenetrableAngler_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=4},
                    });
                }
            }
            if (EnemyExist("EyePalm_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=4},
                });
                if (EnemyExist("Unterling_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=4},
                });
                if (EnemyExist("TitteringPeon_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=4},
                    });
                }
                if (EnemyExist("EggKeeper_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Nameless_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Nameless_EN", enemySlot=4},
                });
                if (EnemyExist("Psychopomp_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=3},
                });
                if (EnemyExist("SterileBud_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("Skyloft_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InfernalDrummer_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InfernalDrummer_EN", enemySlot=3},
                });
                if (EnemyExist("WindSong_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Harbinger_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Harbinger_EN", enemySlot=4},
                });
            }
            if (EnemyExist("EggKeeper_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Damocles_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Damocles_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Damocles_EN", enemySlot=4},
                });
                if (EnemyExist("ImpenetrableAngler_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "ImpenetrableAngler_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Damocles_EN", enemySlot=4},
                    });
                }
            }
            if (EnemyExist("Romantic_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=4},
                });
                if (EnemyExist("ScreamingHomunculus_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
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
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=2},
                });
                if (EnemyExist("ImpenetrableAngler_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "ImpenetrableAngler_EN", enemySlot=2},
                    });
                }
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(2), enemySlot=3},
                });
                if (EnemyExist("EggKeeper_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = RandomColor(2), enemySlot=3},
                    });
                }
                if (EnemyExist("MiniReaper_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = RandomColor(2), enemySlot=3},
                    });
                }
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                });
                if (EnemyExist("EyePalm_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=4},
                    });
                }
            }
            if (EnemyExist("TheCrow_EN"))
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
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=2},
                    });
                }
            }
            orpheum.variations = fields.ToArray();
            orpheum.CheckEncounters();
            orpheum.AddEncounter();
        }
    }
    public static class FirebirdGroup
    {
        public static int rarity
        {
            get
            {
                int g = UnityEngine.Random.Range(6, 21);
                if (SaltEnemies.silly == 73) g *= 2;
                if (SaltEnemies.trolling == 11) g += 10;
                if (SaltEnemies.rando == 86) g += 1;
                return g;
            }
        }

        public static void Add(int sign)
        {
            if (!EnemyExist("Firebird_EN")) return;

            BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("FirebirdWorld.png"));

            GardMed(sign);
            GardHard(sign);
        }
        public static void GardMed(int sign)
        {
            BrutalAPI.EnemyEncounter orpheum = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "PheonixMed",
                area = 2,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = rarity,
                signType = (SignType)sign,
                musicEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone03_ChoirBoy_Easy_EnemyBundle")._musicEventReference,
                roarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone03_GigglingMinister_Medium_EnemyBundle")._roarReference.roarEvent,
                difficulty = EncounterDifficulty.Medium
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("Firebird_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=4},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                });
            if (EnemyExist("MiniReaper_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=3},
                });
            }
            if (EnemyExist("EggKeeper_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Damocles_EN") && Half)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Damocles_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Damocles_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Romantic_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=3},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(2, false, false), enemySlot=3},
                });
            if (EnemyExist("Sigil_EN") && Half)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=3},
                });
            }
            if (EnemyExist("TheCrow_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Hunter_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Satyr_EN") && Quarter)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Satyr_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Satyr_EN", enemySlot=3},
                });
            }
            if (EnemyExist("LittleAngel_EN") && Third)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=3},
                });
            }
            if (EnemyExist("TitteringPeon_EN") && Third)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=3},
                });
            }
            for (int i = 0; i < 4; i++)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomColor(2), enemySlot=3},
                });
            }
            if (EnemyExist("Harbinger_EN") && Half)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Harbinger_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Harbinger_EN", enemySlot=3},
                });
            }
            if (EnemyExist("TripodFish_EN") && Quarter)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=3},
                });
            }
            if (EnemyExist("EyePalm_EN") && Half)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Enigma_EN") && Half)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=3},
                });
            }
            if (EnemyExist("MechanicalLens_EN") && Third)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=3},
                });
            }
            if (EnemyExist("HowlingAvian_EN") && Half)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "HowlingAvian_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "HowlingAvian_EN", enemySlot=3},
                });
            }
            if (EnemyExist("ScreamingHomunculus_EN") && Half)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ScreamingHomunculus_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ScreamingHomunculus_EN", enemySlot=3},
                });
            }
            orpheum.variations = fields.ToArray();
            orpheum.CheckEncounters();
            orpheum.AddEncounter();
        }
        public static void GardHard(int sign)
        {
            BrutalAPI.EnemyEncounter orpheum = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "PheonixHard",
                area = 2,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = rarity,
                signType = (SignType)sign,
                musicEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone03_ChoirBoy_Easy_EnemyBundle")._musicEventReference,
                roarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone03_GigglingMinister_Medium_EnemyBundle")._roarReference.roarEvent,
                difficulty = EncounterDifficulty.Hard
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("Firebird_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=4},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=2},
                });
            if (EnemyExist("Iconoclast_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Iconoclast_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=4},
                });
                if (EnemyExist("TripodFish_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Iconoclast_EN", enemySlot=2},
                    });
                }
            }
            if (EnemyExist("TitteringPeon_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=4},
                });
                if (MultiENExist("WindSong_EN", "Hunter_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=3},
                    });
                }
            }
            if (EnemyExist("ScreamingHomunculus_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ScreamingHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=4},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=3},
                new FieldEnemy(){enemyName = RandomColor(2, true), enemySlot=2},
                });
                if (EnemyExist("TitteringPeon_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "ScreamingHomunculus_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = RandomSupport(2, false, false), enemySlot=4},
                    });
                }
            }
            if (EnemyExist("SterileBud_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=4},
                });
                if (EnemyExist("EggKeeper_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=3},
                    });
                }
            }
            if (EnemyExist("ImpenetrableAngler_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ImpenetrableAngler_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=4},
                });
                if (EnemyExist("MiniReaper_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "ImpenetrableAngler_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=2},
                    });
                }
            }
            if (EnemyExist("Unterling_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Unterling_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=4},
                });
                if (MultiENExist("Grandfather_EN", "Shua_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Unterling_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Shua_EN", enemySlot=3},
                    });
                }
            }
            if (EnemyExist("Psychopomp_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Psychopomp_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=4},
                });
                if (EnemyExist("MechanicalLens_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Psychopomp_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=4},
                    });
                }
            }
            if (EnemyExist("Metatron_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Metatron_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=4},
                });
                if (EnemyExist("LittleAngel_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Metatron_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=4},
                    });
                }
            }
            if (EnemyExist("LostSheep_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=4},
                });
                if (MultiENExist("LivingSolvent_EN", "Skyloft_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=4},
                    });
                }
            }
            if (EnemyExist("Enigma_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=4},
                });
                if (EnemyExist("Romantic_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=3},
                    });
                }
            }
            if (EnemyExist("DeadPixel_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=4},
                });
                if (EnemyExist("SterileBud_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=4},
                    });
                }
            }
            if (EnemyExist("LittleAngel_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=4},
                });
                if (EnemyExist("ClockTower_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = RandomColor(2, true), enemySlot=3},
                    });
                }
            }
            if (EnemyExist("Satyr_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Satyr_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=4},
                });
                if (MultiENExist("EggKeeper_EN", "WindSong_EN", "Sigil_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Satyr_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=4},
                    });
                }
            }
            if (EnemyExist("TheCrow_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=4},
                });
                if (EnemyExist("Unterling_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Unterling_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Unterling_EN", enemySlot=3},
                    });
                }
            }
            if (EnemyExist("RusticJumbleguts_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "RusticJumbleguts_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=4},
                });
                if (MultiENExist("EyePalm_EN", "Romantic_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "RusticJumbleguts_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=4},
                    });
                }
            }
            if (EnemyExist("MortalSpoggle_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MortalSpoggle_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=4},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=2},
                });
                if (EnemyExist("Satyr_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Satyr_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "MortalSpoggle_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=4},
                    });
                }
            }
            if (EnemyExist("MechanicalLens_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=4},
                });
                if (MultiENExist("Romantic_EN", "Skyloft_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=4},
                    });
                }
            }
            if (GreyScale)
            {
                for (int i = 0; i < 4; i++)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = GreyScaleSupport(true), enemySlot=3},
                    new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                    });
                }
            }
            if (Flowering)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=4},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=3},
                new FieldEnemy(){enemyName = Flowers.GetRandom(), enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=4},
                new FieldEnemy(){enemyName = Flowers.GetRandom(), enemySlot=2},
                });
                if (EnemyExist("EggKeeper_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = Flowers.GetRandom(), enemySlot=4},
                    });
                }
                if (MultiENExist("MiniReaper_EN", "SterileBud_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = Flowers.GetRandom(), enemySlot=4},
                    });
                }
                if (MultiENExist("Merced_EN", "Grandfather_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Merced_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = Flowers.GetRandom(), enemySlot=4},
                    });
                }
                if (EnemyExist("TripodFish_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = Flowers.GetRandom(), enemySlot=4},
                    });
                }
                if (EnemyExist("Hunter_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = Flowers.GetRandom(), enemySlot=2},
                    new FieldEnemy(){enemyName = Flowers.GetRandom(), enemySlot=4},
                    });
                }
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomSupport(2, false, false), enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(2, false, false), enemySlot=4},
                new FieldEnemy(){enemyName = Flowers.GetRandom(), enemySlot=2},
                });
            }
            if (EnemyExist("LivingSolvent_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=4},
                });
                if (EnemyExist("ScreamingHomunculus_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "ScreamingHomunculus_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=3},
                    });
                }
            }
            if (EnemyExist("WindSong_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=4},
                });
                if (MultiENExist("Merced_EN", "Harbinger_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Merced_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Harbinger_EN", enemySlot=3},
                    });
                }
            }
            if (EnemyExist("Sigil_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=4},
                });
                if (MultiENExist("HowlingAvian_EN", "Unterling_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Unterling_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "HowlingAvian_EN", enemySlot=3},
                    });
                }
            }
            if (EnemyExist("RealisticTank_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=1},
                });
                if (Flowering)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = Flowers.GetRandom(), enemySlot=4},
                    });
                }
            }
            if (EnemyExist("ClockTower_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=4},
                });
                if (EnemyExist("Iconoclast_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Iconoclast_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=4},
                    });
                }
            }
            if (EnemyExist("StalwartTortoise_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=3},
                });
                if (EnemyExist("Unterling_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Unterling_EN", enemySlot=4},
                    new FieldEnemy(){enemyName = "Unterling_EN", enemySlot=3},
                    });
                }
            }
            if (EnemyExist("Grandfather_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=4},
                });
                if (MultiENExist("ScreamingHomunculus_EN", "TitteringPeon_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "ScreamingHomunculus_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=3},
                    });
                }
            }
            if (EnemyExist("MiniReaper_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=4},
                });
                if (MultiENExist("Romantic_EN", "InfernalDrummer_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "InfernalDrummer_EN", enemySlot=3},
                    });
                }
            }
            if (EnemyExist("Skyloft_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=4},
                });
                if (EnemyExist("MechanicalLens_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=4},
                    });
                }
            }
            if (EnemyExist("EyePalm_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=4},
                });
                if (EnemyExist("Romantic_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=4},
                    });
                }
            }
            if (EnemyExist("Merced_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=4},
                });
                if (MultiENExist("Harbinger_EN", "WindSong_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Merced_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Harbinger_EN", enemySlot=3},
                    });
                }
            }
            if (EnemyExist("Butterfly_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=4},
                });
                if (EnemyExist("Shua_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Shua_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=3},
                    });
                }
            }
            if (EnemyExist("Shua_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=4},
                });
                if (MultiENExist("Unterling_EN", "Hunter_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Shua_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Unterling_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=3},
                    });
                }
            }
            if (EnemyExist("Nameless_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Nameless_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=4},
                });
                if (MultiENExist("EggKeeper_EN", "Scuttlerunt_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Nameless_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Scuttlerunt_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Scuttlerunt_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=4},
                    });
                }
            }
            if (EnemyExist("TripodFish_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=4},
                });
                if (MultiENExist("SterileBud_EN", "Enigma_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=3},
                    });
                }
            }
            if (EnemyExist("GlassFigurine_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "GlassFigurine_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=4},
                });
                if (MultiENExist("Unterling_EN", "SterileBud_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "GlassFigurine_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Unterling_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=3},
                    });
                }
            }
            if (EnemyExist("Hunter_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=4},
                });
                if (MultiENExist("WindSong_EN", "ScreamingHomunculus_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "ScreamingHomunculus_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=3},
                    });
                }
            }
            if (EnemyExist("InfernalDrummer_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InfernalDrummer_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=4},
                });
                if (MultiENExist("LivingSolvent_EN", "EggKeeper_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "InfernalDrummer_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=3},
                    });
                }
            }
            if (EnemyExist("Harbinger_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Harbinger_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=3},
                });
                if (EnemyExist("Unterling_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Harbinger_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Unterling_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Harbinger_EN", enemySlot=3},
                    });
                }
            }
            if (EnemyExist("HowlingAvian_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "HowlingAvian_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=3},
                });
                if (EnemyExist("Hunter_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "HowlingAvian_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=2},
                    });
                }
            }
            if (EnemyExist("Scuttlerunt_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Scuttlerunt_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Scuttlerunt_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Scuttlerunt_EN", enemySlot=4},
                });
                if (EnemyExist("TitteringPeon_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Scuttlerunt_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Scuttlerunt_EN", enemySlot=3},
                    });
                }
            }
            if (EnemyExist("EggKeeper_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=4},
                });
                if (EnemyExist("ImpenetrableAngler_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "ImpenetrableAngler_EN", enemySlot=2},
                    });
                }
            }
            if (EnemyExist("Romantic_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=4},
                });
                if (EnemyExist("LittleAngel_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=2},
                    });
                }
            }
            if (BirdScale)
            {
                for (int i = 0; i < 10; i++)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Firebird_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=4},
                    });
                }
            }
            orpheum.variations = fields.ToArray();
            orpheum.CheckEncounters();
            orpheum.AddEncounter();
        }
    }
    public static class BeakGroup
    {
        public static int rarity
        {
            get
            {
                int g = UnityEngine.Random.Range(6, 21);
                if (SaltEnemies.silly == 12) g *= 2;
                if (SaltEnemies.trolling == 23) g += 10;
                if (SaltEnemies.rando == 34) g += 1;
                return g;
            }
        }

        public static void Add(int sign)
        {
            if (!EnemyExist("LittleBeak_EN")) return;

            BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("BeakWorld.png"));

            BeakShoreMed(sign);
            BeakShoreHard(sign);
            BeakOrphEZ(sign);
            BeakOrphMed(sign);
        }
        public static void BeakShoreMed(int sign)
        {
            BrutalAPI.EnemyEncounter orpheum = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "BeakShoreMed",
                area = 0,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = rarity,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/LittleBeakSong",
                roarEvent = LoadedAssetsHandler.GetEnemy("Kekastle_EN").deathSound,
                difficulty = EncounterDifficulty.Medium
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("LittleBeak_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=3},
                new FieldEnemy(){enemyName = RandomShoreMidget(), enemySlot=4},
                });
            }
            for (int i = 0; i < 3; i++)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RainBaseWeighted(false, false), enemySlot=1},
                new FieldEnemy(){enemyName = RainBaseWeighted(false, false), enemySlot=2},
                new FieldEnemy(){enemyName = RandomShoreMidget(), enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RainBaseWeighted(true, false), enemySlot=1},
                new FieldEnemy(){enemyName = RainBaseWeighted(true, false), enemySlot=2},
                new FieldEnemy(){enemyName = RandomShoreMidget(), enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=1},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=3},
                new FieldEnemy(){enemyName = RandomSupport(0, false, false), enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=1},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=3},
                new FieldEnemy(){enemyName = RandomShoreMidget(false), enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=3},
                new FieldEnemy(){enemyName = RandomShoreMidget(false), enemySlot=4},
                });
            }
            /*
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "FlaMinGoa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MunglingMudLung_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Keko_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Keko_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Keko_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=1},
                new FieldEnemy(){enemyName = "Keko_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Keko_EN", enemySlot=3},
                });
            if (EnemyExist("Monck_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Monck_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Seraphim_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Seraphim_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=2},
                });
            }
            if (EnemyExist("DeadPixel_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=3},
                });
            }
            if (EnemyExist("LostSheep_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=2},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=3},
                });
            }
            if (EnemyExist("A'Flower'_EN"))
            {

                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomShoreMidget(), enemySlot=2},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=3},
                });
            }
            */
            for (int i = 0; i < 20; i++)
            {
                fields.Add(RandomizeShore("LittleBeak_EN", Weight.Normal));
            }
            orpheum.variations = fields.ToArray();
            orpheum.CheckEncounters();
            orpheum.AddEncounter();
        }
        public static void BeakShoreHard(int sign)
        {
            BrutalAPI.EnemyEncounter orpheum = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "BeakShoreHard",
                area = 0,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = rarity,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/LittleBeakSong",
                roarEvent = LoadedAssetsHandler.GetEnemy("Kekastle_EN").deathSound,
                difficulty = EncounterDifficulty.Hard
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("LittleBeak_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=2},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=3},
                new FieldEnemy(){enemyName = RandomShoreMidget(), enemySlot=4},
                });
            }
            for (int i = 0; i < 5; i++)
            {
                fields.Add(RandomizeShore("LittleBeak_EN", Weight.Normal));
            }
            for (int i = 0; i < 25; i++)
            {
                fields.Add(RandomizeShore("LittleBeak_EN", Weight.Big));
            }
            orpheum.variations = fields.ToArray();
            orpheum.CheckEncounters();
            orpheum.AddEncounter();
        }
        public static void BeakOrphEZ(int sign)
        {
            BrutalAPI.EnemyEncounter orpheum = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "BeakOrphEZPZ",
                area = 1,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = rarity,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/LittleBeakSong",
                roarEvent = LoadedAssetsHandler.GetEnemy("Kekastle_EN").deathSound,
                difficulty = EncounterDifficulty.Easy
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("LittleBeak_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=4},
                });
            }
            for (int i = 0; i < 5; i++) fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                });
            for (int i = 0; i < 10; i++) fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=2},
                });
            for (int i = 0; i < 10; i++) fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=2},
                });
            if (Chap)
            {
                for (int i = 0; i < 10; i++) fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=2},
                });
                for (int i = 0; i < 10; i++) fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=2},
                });
            }
            if (BirdScale)
            {
                for (int i = 0; i < 10; i++) fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                });
            }
            if (EnemyExist("DeadPixel_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=3},
                });
            }
            if (EnemyExist("MechanicalLens_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Romantic_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=2},
                });
            }
            orpheum.variations = fields.ToArray();
            orpheum.CheckEncounters();
            orpheum.AddEncounter();
        }
        public static void BeakOrphMed(int sign)
        {
            BrutalAPI.EnemyEncounter orpheum = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "BeakOrphMed",
                area = 1,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = rarity,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/LittleBeakSong",
                roarEvent = LoadedAssetsHandler.GetEnemy("Kekastle_EN").deathSound,
                difficulty = EncounterDifficulty.Medium
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("LittleBeak_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=4},
                });
            }
            if (EnemyExist("Enigma_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=3},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=4},
                });
            }
            if (EnemyExist("Sigil_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=3},
                });
                ResetColor();
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=1},
                new FieldEnemy(){enemyName = SmartColor(1, true), enemySlot=2},
                new FieldEnemy(){enemyName = SmartColor(1), enemySlot=3},
                });
                ResetColor();
            }
            if (EnemyExist("OsseousClad_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=3},
                });
            }
            if (Chap)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=3},
                });
            }
            if (Spligging)
            {
                if (EnemyExist("TheCrow_EN")) fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Spligs.GetRandom(), enemySlot=1},
                new FieldEnemy(){enemyName = Spligs.GetRandom(), enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=3},
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=4},
                });
                if (EnemyExist("Hunter_EN")) fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Spligs.GetRandom(), enemySlot=1},
                new FieldEnemy(){enemyName = Spligs.GetRandom(), enemySlot=2},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=3},
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=4},
                });
                if (EnemyExist("FumeFactory_EN")) fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Spligs.GetRandom(), enemySlot=1},
                new FieldEnemy(){enemyName = Spligs.GetRandom(), enemySlot=2},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=3},
                new FieldEnemy(){enemyName = "FumeFactory_EN", enemySlot=4},
                });
                if (EnemyExist("ReflectedHound_EN")) fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Spligs.GetRandom(), enemySlot=1},
                new FieldEnemy(){enemyName = Spligs.GetRandom(), enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=3},
                new FieldEnemy(){enemyName = "ReflectedHound_EN", enemySlot=4},
                });
            }
            if (true)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RainBaseWeighted(true), enemySlot=1},
                new FieldEnemy(){enemyName = RainBaseWeighted(true), enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RainBaseWeighted(true), enemySlot=1},
                new FieldEnemy(){enemyName = RainBaseWeighted(true), enemySlot=2},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=3},
                });
            }
            if (true)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RainBaseWeighted(false), enemySlot=1},
                new FieldEnemy(){enemyName = RainBaseWeighted(false), enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RainBaseWeighted(false), enemySlot=1},
                new FieldEnemy(){enemyName = RainBaseWeighted(false), enemySlot=2},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=3},
                });
            }
            if (Colophoning)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Colophon.GetRandom(), enemySlot=1},
                new FieldEnemy(){enemyName = Colophon.GetRandom(), enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Colophon.GetRandom(), enemySlot=1},
                new FieldEnemy(){enemyName = Colophon.GetRandom(), enemySlot=2},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=3},
                });
            }
            if (Flowering)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=3},
                });
            }
            if (EnemyExist("Damocles_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Damocles_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=4},
                });
            }
            if (EnemyExist("Romantic_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=3},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=4},
                });
            }
            if (EnemyExist("Shua_EN"))
            {
                ResetColor();
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=2},
                new FieldEnemy(){enemyName = SmartColor(1, true), enemySlot=3},
                new FieldEnemy(){enemyName = SmartColor(1, true), enemySlot=4},
                });
                ResetColor();
            }
            if (EnemyExist("Nameless_EN"))
            {
                string en = RandomOrph;
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Nameless_EN", enemySlot=2},
                new FieldEnemy(){enemyName = en, enemySlot=3},
                new FieldEnemy(){enemyName = en, enemySlot=4},
                });
            }
            if (EnemyExist("ReflectedHound_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ReflectedHound_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ReflectedHound_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=3},
                });
            }
            if (EnemyExist("LittleBeak_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=3},
                });
            }
            if (EnemyExist("Seraphim_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Seraphim_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Seraphim_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Seraphim_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=3},
                });
            }
            if (EnemyExist("Something_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=3},
                });
            }
            if (EnemyExist("MechanicalLens_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Grandfather_EN"))
            {
                ResetColor();
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=2},
                new FieldEnemy(){enemyName = SmartColor(1, true), enemySlot=3},
                new FieldEnemy(){enemyName = SmartColor(1, true), enemySlot=4},
                });
                ResetColor();
            }
            if (EnemyExist("TheCrow_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=3},
                });
            }
            if (EnemyExist("Hunter_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=3},
                });
            }
            if (EnemyExist("FumeFactory_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "FumeFactory_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "FumeFactory_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=3},
                });
            }
            if (Gizos)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "NakedGizo_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=3},
                });
            }
            if (EnemyExist("WindSong_EN"))
            {
                ResetColor();
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=3},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=4},
                });
                ResetColor();
            }
            if (EnemyExist("LivingSolvent_EN"))
            {
                ResetColor();
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=3},
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=4},
                });
                ResetColor();
            }
            if (EnemyExist("Lyssa_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=3},
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
                });
            }
            orpheum.variations = fields.ToArray();
            orpheum.CheckEncounters();
            orpheum.AddEncounter();
        }
    }
    public static class WarbirdGroup
    {
        public static int rarity
        {
            get
            {
                int g = UnityEngine.Random.Range(6, 21);
                if (SaltEnemies.silly == 12) g *= 2;
                if (SaltEnemies.trolling == 23) g += 10;
                if (SaltEnemies.rando == 34) g += 1;
                return g;
            }
        }

        public static void Add(int sign)
        {
            if (!EnemyExist("Warbird_EN")) return;

            BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("ScarecrowWorld.png"));

            WarShoreHard(sign);
            WarMed(sign);
        }
        public static void WarShoreHard(int sign)
        {
            BrutalAPI.EnemyEncounter orpheum = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "WarHard",
                area = 0,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = rarity / UnityEngine.Random.Range(2, 4),
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/WarbirdTheme",
                roarEvent = "event:/Hawthorne/Roar/HunterRoar",
                difficulty = EncounterDifficulty.Hard
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("Warbird_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=2},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=3},
                new FieldEnemy(){enemyName = RandomShoreMidget(), enemySlot=4},
                });
            }
            for (int i = 0; i < 5; i++)
            {
                fields.Add(RandomizeShore("Warbird_EN", Weight.Normal));
            }
            for (int i = 0; i < 25; i++)
            {
                fields.Add(RandomizeShore("Warbird_EN", Weight.Big));
            }
            orpheum.variations = fields.ToArray();
            orpheum.CheckEncounters();
            orpheum.AddEncounter();
        }
        public static void WarMed(int sign)
        {
            BrutalAPI.EnemyEncounter orpheum = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "WarMed",
                area = 1,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = rarity / UnityEngine.Random.Range(2, 4),
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/WarbirdTheme",
                roarEvent = "event:/Hawthorne/Roar/HunterRoar",
                difficulty = EncounterDifficulty.Medium
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            if (EnemyExist("Warbird_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=4},
                });
            }
            if (EnemyExist("Enigma_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=3},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=4},
                });
            }
            if (EnemyExist("Sigil_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=3},
                });
                ResetColor();
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=1},
                new FieldEnemy(){enemyName = SmartColor(1, true, true), enemySlot=2},
                new FieldEnemy(){enemyName = SmartColor(1), enemySlot=3},
                });
                ResetColor();
            }
            if (EnemyExist("OsseousClad_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=3},
                });
            }
            if (Chap)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=3},
                });
            }
            if (Spligging)
            {
                if (EnemyExist("TheCrow_EN")) fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Spligs.GetRandom(), enemySlot=1},
                new FieldEnemy(){enemyName = Spligs.GetRandom(), enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=3},
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=4},
                });
                if (EnemyExist("Hunter_EN")) fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Spligs.GetRandom(), enemySlot=1},
                new FieldEnemy(){enemyName = Spligs.GetRandom(), enemySlot=2},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=3},
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=4},
                });
                if (EnemyExist("FumeFactory_EN")) fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Spligs.GetRandom(), enemySlot=1},
                new FieldEnemy(){enemyName = Spligs.GetRandom(), enemySlot=2},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=3},
                new FieldEnemy(){enemyName = "FumeFactory_EN", enemySlot=4},
                });
                if (EnemyExist("ReflectedHound_EN")) fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Spligs.GetRandom(), enemySlot=1},
                new FieldEnemy(){enemyName = Spligs.GetRandom(), enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=3},
                new FieldEnemy(){enemyName = "ReflectedHound_EN", enemySlot=4},
                });
            }
            if (true)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RainBaseWeighted(true), enemySlot=1},
                new FieldEnemy(){enemyName = RainBaseWeighted(true), enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(1, true, false), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RainBaseWeighted(true), enemySlot=1},
                new FieldEnemy(){enemyName = RainBaseWeighted(true), enemySlot=2},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=3},
                });
            }
            if (true)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RainBaseWeighted(false), enemySlot=1},
                new FieldEnemy(){enemyName = RandomRedColor(false), enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = RainBaseWeighted(false), enemySlot=1},
                new FieldEnemy(){enemyName = RainBaseWeighted(false), enemySlot=2},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=3},
                });
            }
            if (Colophoning)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Colophon.GetRandom(), enemySlot=1},
                new FieldEnemy(){enemyName = Colophon.GetRandom(), enemySlot=2},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = Colophon.GetRandom(), enemySlot=1},
                new FieldEnemy(){enemyName = Colophon.GetRandom(), enemySlot=2},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=3},
                });
            }
            if (Flowering)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=3},
                });
            }
            if (EnemyExist("Damocles_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Damocles_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=4},
                });
            }
            if (EnemyExist("Romantic_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=3},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=4},
                });
            }
            if (EnemyExist("Shua_EN"))
            {
                ResetColor();
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=2},
                new FieldEnemy(){enemyName = SmartColor(1, true), enemySlot=3},
                new FieldEnemy(){enemyName = SmartColor(1, true), enemySlot=4},
                });
                ResetColor();
            }
            if (EnemyExist("Nameless_EN"))
            {
                string en = RandomOrph;
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Nameless_EN", enemySlot=2},
                new FieldEnemy(){enemyName = en, enemySlot=3},
                new FieldEnemy(){enemyName = en, enemySlot=4},
                });
            }
            if (EnemyExist("ReflectedHound_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ReflectedHound_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ReflectedHound_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=3},
                });
            }
            if (EnemyExist("Warbird_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=3},
                });
            }
            if (EnemyExist("Seraphim_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Seraphim_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Seraphim_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Seraphim_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=3},
                });
            }
            if (EnemyExist("Something_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=3},
                });
            }
            if (EnemyExist("MechanicalLens_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Grandfather_EN"))
            {
                ResetColor();
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=2},
                new FieldEnemy(){enemyName = SmartColor(1, true), enemySlot=3},
                new FieldEnemy(){enemyName = SmartColor(1, true), enemySlot=4},
                });
                ResetColor();
            }
            if (EnemyExist("TheCrow_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=3},
                });
            }
            if (EnemyExist("Hunter_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=3},
                });
            }
            if (EnemyExist("FumeFactory_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "FumeFactory_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "FumeFactory_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=3},
                });
            }
            if (Gizos)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "NakedGizo_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=3},
                });
            }
            if (EnemyExist("WindSong_EN"))
            {
                ResetColor();
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=3},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=4},
                });
                ResetColor();
            }
            if (EnemyExist("LivingSolvent_EN"))
            {
                ResetColor();
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=3},
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=4},
                });
                ResetColor();
            }
            if (EnemyExist("Lyssa_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=3},
                });
            }
            if (EnemyExist("Warbird_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=3},
                });
            }
            if (EnemyExist("LittleBeak_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=2},
                new FieldEnemy(){enemyName = RandomColor(1), enemySlot=3},
                });
            }
            orpheum.variations = fields.ToArray();
            orpheum.CheckEncounters();
            orpheum.AddEncounter();
        }
    }
}
