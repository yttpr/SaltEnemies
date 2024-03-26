using System;
using System.Collections.Generic;
using System.Text;
using BrutalAPI;
using UnityEngine;
using static Hawthorne.Check;

namespace Hawthorne
{
    public static class PixelSong
    {
        public static int rarity
        {
            get
            {
                if (SaltEnemies.trolling == 57) return 999;
                else return 10;
            }
        }

        public static void Add(int sign)
        {
            if (!EnemyExist("DeadPixel_EN")) return;
            BrutalAPI.EnemyEncounter farshore = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "Pixel_Shore",
                area = 0,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = rarity,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/DeadPixelTheme",
                roarEvent = "event:/Hawthorne/Roar/PixelRoar",
                difficulty = EncounterDifficulty.Easy
            };
            List<FieldEnemy[]> groups = new List<FieldEnemy[]>();
            groups.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
            });
            groups.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=2},
            });
            groups.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Mung_EN", enemySlot=3}
            });
            if (EnemyExist("Skyloft_EN") && SaltEnemies.silly == 37)
            {
                groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=3}
                });
            }
            groups.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "JumbleGuts_Clotted_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "JumbleGuts_Waning_EN", enemySlot=3}
            });
            groups.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "JumbleGuts_Waning_EN", enemySlot=3}
            });
            groups.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Spoggle_Ruminating_EN", enemySlot=3}
            });
            groups.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Keko_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Keko_EN", enemySlot=3}
            });
            if (EnemyExist("LostSheep_EN"))
            {
                groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=3}
                });
                groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "JumbleGuts_Waning_EN", enemySlot=3}
                });
                groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Spoggle_Spitfire_EN", enemySlot=3}
                });
            }
            groups.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=3}
            });
            groups.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Flarblet_EN", enemySlot=3}
            });
            if (EnemyExist("Flarbleft_EN"))
            {
                groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Flarbleft_EN", enemySlot=3}
                });
            }
            groups.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Spoggle_Spitfire_EN", enemySlot=3}
            });
            if (EnemyExist("LipBug_EN"))
            {
                groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "LipBug_EN", enemySlot=3}
                });
            }
            if (EnemyExist("Seraphim_EN") && SaltEnemies.trolling == 97)
            {
                groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Seraphim_EN", enemySlot=3}
                });
            }
            if (EnemyExist("BondedJumbleGuts_EN"))
            {
                groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "BondedJumbleGuts_EN", enemySlot=3}
                });
            }
            if (EnemyExist("EclipsedSpoggle_EN"))
            {
                groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "EclipsedSpoggle_EN", enemySlot=3}
                });
            }
            if (EnemyExist("ComposedColophon_EN"))
            {
                groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ComposedColophon_EN", enemySlot=3}
                });
                if (EnemyExist("DefeatedColophon_EN"))
                {
                    groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "DefeatedColophon_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ComposedColophon_EN", enemySlot=3}
                });
                }
            }
            if (EnemyExist("Teto_EN"))
            {
                groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Teto_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Teto_EN", enemySlot=3}
                });
            }
            if (EnemyExist("Monck_EN"))
            {
                groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Monck_EN", enemySlot=3}
                });
                groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "JumbleGuts_Clotted_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Monck_EN", enemySlot=3}
                });
            }
            if (EnemyExist("RougeBellowingSplugling_EN"))
            {
                groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "RougeBellowingSplugling_EN", enemySlot=3}
                });
                if (EnemyExist("RougeFesteringSplugling_EN"))
                {
                    groups.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                    new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "RougeFesteringSplugling_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "RougeBellowingSplugling_EN", enemySlot=3}
                    });
                    if (EnemyExist("RougeWailingSplugling_EN"))
                    {
                        groups.Add(new FieldEnemy[]
                        {
                        new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                        new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                        new FieldEnemy(){enemyName = "RougeFesteringSplugling_EN", enemySlot=2},
                        new FieldEnemy(){enemyName = "RougeBellowingSplugling_EN", enemySlot=3},
                        new FieldEnemy(){enemyName = "RougeWailingSplugling_EN", enemySlot = 4 },
                        });
                    }
                }
            }
            if (EnemyExist("RogueBellowingSplugling_EN"))
            {
                groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "RogueBellowingSplugling_EN", enemySlot=3}
                });
                if (EnemyExist("RogueFesteringSplugling_EN"))
                {
                    groups.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                    new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "RogueFesteringSplugling_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "RogueBellowingSplugling_EN", enemySlot=3}
                    });
                    if (EnemyExist("RogueWailingSplugling_EN"))
                    {
                        groups.Add(new FieldEnemy[]
                        {
                        new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                        new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                        new FieldEnemy(){enemyName = "RogueFesteringSplugling_EN", enemySlot=2},
                        new FieldEnemy(){enemyName = "RogueBellowingSplugling_EN", enemySlot=3},
                        new FieldEnemy(){enemyName = "RogueWailingSplugling_EN", enemySlot = 4 },
                        });
                    }
                }
            }
            if (EnemyExist("Lymphropod_EN") && SaltEnemies.silly > 67)
            {
                groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Lymphropod_EN", enemySlot=2},
                });
                groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Mung_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Lymphropod_EN", enemySlot=3}
                });
            }
            farshore.variations = groups.ToArray();
            BrutalAPI.BrutalAPI.AddSignType(farshore.signType, ResourceLoader.LoadSprite("PixelIcon"));
            farshore.AddEncounter();

            BrutalAPI.EnemyEncounter orpheum = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "Pixel_Orph",
                area = 1,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = rarity,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/DeadPixelTheme",
                roarEvent = "event:/Hawthorne/Roar/PixelRoar",
                difficulty = EncounterDifficulty.Easy
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
            });
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=3},
            });
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
            });
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=3},
            });
            if (EnemyExist("NakedGizo_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NakedGizo_EN", enemySlot=3},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "JumbleGuts_Waning_EN", enemySlot=3},
                });
            if (EnemyExist("ComposedColophon_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ComposedColophon_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot =4}
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Spoggle_Ruminating_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Spoggle_Spitfire_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "JumbleGuts_Waning_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "JumbleGuts_Clotted_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot = 4}
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot = 4}
                });
            if (EnemyExist("Enigma_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Spoggle_Spitfire_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=3},
                });
            }
            if (EnemyExist("AmphibiousSpoggle_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "AmphibiousSpoggle_EN", enemySlot=3},
                });
            }
            if (EnemyExist("RougeWeepingSplugling_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "RougeWeepingSplugling_EN", enemySlot=3}
                });
                if (EnemyExist("RougeWailingSplugling_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                    new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "RougeWailingSplugling_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "RougeWeepingSplugling_EN", enemySlot=3}
                    });
                    if (EnemyExist("RougeFesteringSplugling_EN"))
                    {
                        fields.Add(new FieldEnemy[]
                        {
                        new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                        new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                        new FieldEnemy(){enemyName = "RougeWailingSplugling_EN", enemySlot=2},
                        new FieldEnemy(){enemyName = "RougeWeepingSplugling_EN", enemySlot=3},
                        new FieldEnemy(){enemyName = "RougeFesteringSplugling_EN", enemySlot = 4 },
                        });
                    }
                }
            }
            if (EnemyExist("RogueWeepingSplugling_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "RogueWeepingSplugling_EN", enemySlot=3}
                });
                if (EnemyExist("RogueWailingSplugling_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                    new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "RogueWailingSplugling_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "RogueWeepingSplugling_EN", enemySlot=3}
                    });
                    if (EnemyExist("RogueFesteringSplugling_EN"))
                    {
                        fields.Add(new FieldEnemy[]
                        {
                        new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                        new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                        new FieldEnemy(){enemyName = "RogueWailingSplugling_EN", enemySlot=2},
                        new FieldEnemy(){enemyName = "RogueWeepingSplugling_EN", enemySlot=3},
                        new FieldEnemy(){enemyName = "RogueFesteringSplugling_EN", enemySlot = 4 },
                        });
                    }
                }
            }
            if (EnemyExist("Pacemaker_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Pacemaker_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=3},
                });
            }
            if (EnemyExist("LittleBeak_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=2},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=3},
                });
            orpheum.variations = fields.ToArray();
            orpheum.AddEncounter();

            BrutalAPI.EnemyEncounter garden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "Pixel_Jarden",
                area = 2,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = rarity,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/DeadPixelTheme",
                roarEvent = "event:/Hawthorne/Roar/PixelRoar",
                difficulty = EncounterDifficulty.Easy
            };
            List<FieldEnemy[]> battle = new List<FieldEnemy[]>();
            battle.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=3},
            });
            battle.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot =3},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot =4},
            });
            battle.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot =3},
            });
            battle.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot =3},
            });
            if (EnemyExist("Unterling_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Unterling_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot =3},
                });
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Unterling_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "Unterling_EN", enemySlot =3},
                });
            }
            if (EnemyExist("EyePalm_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot =3},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot =4},
                });
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot =3},
                });
                if (EnemyExist("LostSheep_EN"))
                {
                    battle.Add(new FieldEnemy[]
                    {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot =3},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot =4},
                    });
                }
            }
            if (EnemyExist("Shua_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot =3},
                });
            }
            if (EnemyExist("Skyloft_EN") && SaltEnemies.trolling < 44)
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot =3},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot =4},
                });
            }
            if (EnemyExist("StarGazer_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "StarGazer_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "StarGazer_EN", enemySlot =3},
                new FieldEnemy(){enemyName = "StarGazer_EN", enemySlot = 4}
                });
            }
            if (EnemyExist("TitteringPeon_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot =3},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot =4},
                });
            }
            if (EnemyExist("EggKeeper_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot =3},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot =4},
                });
            }
            if (EnemyExist("Sigil_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot =3},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot =4},
                });
            }
            if (EnemyExist("Butterfly_EN") && SaltEnemies.rando < 95)
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot =3},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot =4},
                });
            }
            if (EnemyExist("Enigma_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot =3},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot =4},
                });
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot =3},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot =4},
                });
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot =3},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot =4},
                });
            }
            if (EnemyExist("Nameless_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Nameless_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot =3},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot =4},
                });
            }
            battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot =3},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot =4},
                });
            if (EnemyExist("WindSong_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot =3},
                });
            }
            if (EnemyExist("LivingSolvent_EN") && SaltEnemies.silly > 38)
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot =2},
                });
            }
            if (SaltEnemies.rando == 29)
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot =2},
                });
            }
            if (EnemyExist("LittleAngel_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot =3},
                });
                if (EnemyExist("ScreamingHomunculus_EN"))
                {
                    battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot =3},
                new FieldEnemy(){enemyName = "ScreamingHomunculus_EN", enemySlot =4},
                });
                }
            }
            if (EnemyExist("MechanicalLens_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot =3},
                });
                if (EnemyExist("FakeAngel_EN"))
                {
                    battle.Add(new FieldEnemy[]
                    {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot =3},
                    });
                }
            }
            if (EnemyExist("FakeAngel_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot =3},
                });
                if (EnemyExist("Illusion_EN"))
                {
                    battle.Add(new FieldEnemy[]
                    {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot =3},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot = 4},
                    });
                }
            }
            if (EnemyExist("HowlingAvian_EN") && SaltEnemies.trolling == 57)
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "HowlingAvian_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot =3},
                });
                if (EnemyExist("Harbinger_EN"))
                {
                    battle.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                    new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "HowlingAvian_EN", enemySlot =2},
                    new FieldEnemy(){enemyName = "Harbinger_EN", enemySlot =3},
                    });
                }
            }
            if (EnemyExist("InfernalDrummer_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InfernalDrummer_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "InfernalDrummer_EN", enemySlot =3},
                });
            }
            if (EnemyExist("Harbinger_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Harbinger_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "Scuttlerunt_EN", enemySlot =3},
                new FieldEnemy(){enemyName = "Scuttlerunt_EN", enemySlot =4},
                });
            }
            if (EnemyExist("Damocles_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "Damocles_EN", enemySlot =3},
                new FieldEnemy(){enemyName = "Damocles_EN", enemySlot =4},
                });
            }
            //garden.variations = battle.ToArray();
            //garden.AddEncounter();
        }
    }
    public static class EnigmaSong
    {
        public static int rarity
        {
            get
            {
                if (SaltEnemies.trolling < 19) return 36;
                else return 10;
            }
        }

        public static void Add(int sign)
        {
            if (!EnemyExist("Enigma_EN")) return;
            
            BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("FalseTruthIcon"));

            BrutalAPI.EnemyEncounter orpheum = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "Enigma_Orph",
                area = 1,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = rarity,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/EnigmaTheme",
                roarEvent = LoadedAssetsHandler.GetEnemy("ChoirBoy_EN").damageSound,
                difficulty = EncounterDifficulty.Easy
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
            });
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
            });
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
            });
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=3},
            });
            if (EnemyExist("NakedGizo_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NakedGizo_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NakedGizo_EN", enemySlot=3},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "JumbleGuts_Clotted_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "JumbleGuts_Waning_EN", enemySlot=3},
                });
            if (EnemyExist("ComposedColophon_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ComposedColophon_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot =4}
                });
            }
            if (EnemyExist("DefeatedColophon_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "DefeatedColophon_EN", enemySlot =4}
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Spoggle_Ruminating_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Spoggle_Spitfire_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Spoggle_Ruminating_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Spoggle_Spitfire_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "JumbleGuts_Waning_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "JumbleGuts_Clotted_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot = 4}
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot = 4}
                });
            if (EnemyExist("DeadPixel_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Spoggle_Spitfire_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=3},
                });
            }
            if (EnemyExist("IchtyosatedSpoggle_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "IchtyosatedSpoggle_EN", enemySlot=3},
                });
            }
            if (EnemyExist("ArtisticJumbleGuts_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ArtisticJumbleGuts_EN", enemySlot=3},
                });
            }
            if (EnemyExist("RougeWeepingSplugling_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "RougeWeepingSplugling_EN", enemySlot=3}
                });
                if (EnemyExist("RougeBellowingSplugling_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                    new FieldEnemy(){enemyName = "RougeBellowingSplugling_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "RougeWeepingSplugling_EN", enemySlot=3}
                    });
                    if (EnemyExist("RougeFesteringSplugling_EN") && EnemyExist("RougeWailingSplugling_EN"))
                    {
                        fields.Add(new FieldEnemy[]
                        {
                        new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                        new FieldEnemy(){enemyName = "RougeWailingSplugling_EN", enemySlot=1},
                        new FieldEnemy(){enemyName = "RougeBellowingSplugling_EN", enemySlot=2},
                        new FieldEnemy(){enemyName = "RougeWeepingSplugling_EN", enemySlot=3},
                        new FieldEnemy(){enemyName = "RougeFesteringSplugling_EN", enemySlot = 4 },
                        });
                    }
                }
            }
            if (EnemyExist("RogueWeepingSplugling_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "RogueWeepingSplugling_EN", enemySlot=3}
                });
                if (EnemyExist("RogueBellowingSplugling_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                    new FieldEnemy(){enemyName = "RogueBellowingSplugling_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "RogueWeepingSplugling_EN", enemySlot=3}
                    });
                    if (EnemyExist("RogueFesteringSplugling_EN") && EnemyExist("RogueWailingSplugling_EN"))
                    {
                        fields.Add(new FieldEnemy[]
                        {
                        new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                        new FieldEnemy(){enemyName = "RogueWailingSplugling_EN", enemySlot=1},
                        new FieldEnemy(){enemyName = "RogueBellowingSplugling_EN", enemySlot=2},
                        new FieldEnemy(){enemyName = "RogueWeepingSplugling_EN", enemySlot=3},
                        new FieldEnemy(){enemyName = "RogueFesteringSplugling_EN", enemySlot = 4 },
                        });
                    }
                }
            }
            if (EnemyExist("Pacemaker_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Pacemaker_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=3},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=3},
                });
            if (EnemyExist("Nameless_EN") && SaltEnemies.silly < 63)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Nameless_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot =3},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot =4},
                });
            }
            if (EnemyExist("EyePalm_EN") && SaltEnemies.trolling == 64)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "Spoggle_Ruminating_EN", enemySlot = 4},
                });
            }
            if (EnemyExist("WindSong_EN") && SaltEnemies.silly > 39)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot =3},
                });
            }
            if (EnemyExist("LittleBeak_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=3},
                });
            }
            orpheum.variations = fields.ToArray();
            orpheum.AddEncounter();

            BrutalAPI.EnemyEncounter garden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "EnigmaGarden",
                area = 2,
                randomPlacement = true,
                hardmodeEncounter = true,
                signType = (SignType)sign,
                rarity = UnityEngine.Random.Range(5,15),
                musicEvent = "event:/Hawthorne/EnigmaTheme",
                roarEvent = LoadedAssetsHandler.GetEnemy("ChoirBoy_EN").damageSound,
                difficulty = EncounterDifficulty.Easy
            };
            List<FieldEnemy[]> battle = new List<FieldEnemy[]>();
            battle.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
            });
            battle.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=4},
            });
            battle.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot =2},
            });
            battle.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot =3},
            });
            battle.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot =3},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=4},
            });
            if (EnemyExist("Unterling_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Unterling_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Unterling_EN", enemySlot =2},
                });
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "Unterling_EN", enemySlot =3},
                });
            }
            if (EnemyExist("EyePalm_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot =3},
                });
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot =3},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot =4},
                });
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot =3},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot =4},
                });
                if (EnemyExist("LostSheep_EN"))
                {
                    battle.Add(new FieldEnemy[]
                    {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot =3},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot =4},
                    });
                }
            }
            if (EnemyExist("Shua_EN") && SaltEnemies.rando > 8)
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=3},
                });
                if (EnemyExist("WindSong_EN"))
                {
                    battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=3},
                });
                }
            }
            if (EnemyExist("Skyloft_EN") && SaltEnemies.rando > 46)
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot =3},
                });
            }
            if (EnemyExist("StarGazer_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "StarGazer_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot =3},
                new FieldEnemy(){enemyName = "StarGazer_EN", enemySlot = 4}
                });
            }
            if (EnemyExist("TitteringPeon_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot =3},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot =4},
                });
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot =3},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot =4},
                });
            }
            if (EnemyExist("EggKeeper_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot =3},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot =4},
                });
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 1},
                new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot =3},
                });
            }
            if (EnemyExist("Sigil_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot =3},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot =4},
                });
            }
            if (EnemyExist("Butterfly_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot =3},
                });
            }
            if (EnemyExist("DeadPixel_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot =3},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot =4},
                });
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot =3},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot =4},
                });
            }
            if (EnemyExist("Nameless_EN") && SaltEnemies.silly < 81)
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Nameless_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot =3},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot =4},
                });
            }
            battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot =3},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot =4},
                });
            if (EnemyExist("WindSong_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot =3},
                });
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot =3},
                });
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot =3},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot =4},
                });
                if (EnemyExist("EyePalm_EN"))
                {
                    battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot =3},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot =4},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot =1},
                });
                }
            }
            if (EnemyExist("LivingSolvent_EN") && SaltEnemies.trolling > 19)
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Grandfather_EN") && SaltEnemies.trolling < 72)
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 1},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 3},
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot =2},
                });
            }
            if (SaltEnemies.trolling <= 49)
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot =2},
                });
            }
            if (EnemyExist("LittleAngel_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot =2},
                });
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot =3},
                });
            }
            if (EnemyExist("FakeAngel_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot =3},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot =4},
                });
            }
            if (EnemyExist("FakeAngel_EN") && SaltEnemies.rando < 79)
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot =3},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=4},
                });
            }
            if (EnemyExist("HowlingAvian_EN") && SaltEnemies.trolling == 38)
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "HowlingAvian_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot =3},
                });
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "HowlingAvian_EN", enemySlot =2},
                });
            }
            if (EnemyExist("InfernalDrummer_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "InfernalDrummer_EN", enemySlot =3},
                });
            }
            if (EnemyExist("Harbinger_EN") && SaltEnemies.trolling == 19)
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Harbinger_EN", enemySlot =2},
                });
            }
            if (EnemyExist("Damocles_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Damocles_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "Damocles_EN", enemySlot =3},
                });
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Damocles_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot =3},
                });
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Damocles_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot =3},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot =4},
                });
            }
            //garden.variations = battle.ToArray();
            //garden.AddEncounter();
        }
    }
    public static class AnglerGroup
    {
        public static int rar
        {
            get
            {
                if (SaltEnemies.trolling > 67 && SaltEnemies.silly <= 45) return 23;
                else return UnityEngine.Random.Range(10, 16);
            }
        }
        public static int rarity => rar * 999;

        public static void Add(int sign)
        {
            if (!EnemyExist("A'Flower'_EN")) return;
            BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("AnglerIcon"));
            BrutalAPI.EnemyEncounter shore = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "AnglerfishShoreMed",
                area = 0,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = rarity,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/AnglerTheme",
                roarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Voboola_Hard_EnemyBundle")._roarReference.roarEvent,
                difficulty = EncounterDifficulty.Medium
            };
            List<FieldEnemy[]> groups = new List<FieldEnemy[]>();
            groups.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=2},
            });
            groups.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "FlaMinGoa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=2},
            });
            groups.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "MunglingMudLung_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=2},
            });
            groups.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Mung_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=2},
            });
            groups.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Flarblet_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=3},
            });
            if (EnemyExist("Flarbleft_EN"))
            {
                groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Flarbleft_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=3},
                });
            }
            groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Keko_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Keko_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Keko_EN", enemySlot=3},
                });
            groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Keko_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Keko_EN", enemySlot=3},
                });
            groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "JumbleGuts_Waning_EN", enemySlot=2},
                });
            groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "JumbleGuts_Clotted_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "JumbleGuts_Waning_EN", enemySlot=2},
                });
            groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Spoggle_Spitfire_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Spoggle_Ruminating_EN", enemySlot=2},
                });
            if (EnemyExist("DeadPixel_EN") && SaltEnemies.rando > 25)
            {
                groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=3},
                });
            }
            if (EnemyExist("LostSheep_EN"))
            {
                groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=3},
                });
                groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FlaMinGoa_EN", enemySlot=3},
                });
                groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Keko_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Keko_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Monck_EN"))
            {
                groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Monck_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Keko_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Keko_EN", enemySlot=3},
                });
            }
            if (EnemyExist("LipBug_EN"))
            {
                groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "LipBug_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=3},
                });
            }
            if (EnemyExist("DrySimian_EN") && SaltEnemies.trolling == 48)
            {
                groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DrySimian_EN", enemySlot=1},
                });
            }
            if (EnemyExist("ComposedColophon_EN") && SaltEnemies.trolling < 44)
            {
                groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "ComposedColophon_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ComposedColophon_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=3},
                });
                if (EnemyExist("DefeatedColophon_EN"))
                {
                    groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "ComposedColophon_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "DefeatedColophon_EN", enemySlot=2},
                });
                }
            }
            if (EnemyExist("Skyloft_EN") && SaltEnemies.rando > 90)
            {
                groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FlaMinGoa_EN", enemySlot = 2}
                });
            }
            if (EnemyExist("Teto_EN"))
            {
                groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Teto_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Teto_EN", enemySlot=2},
                });
            }
            groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Mung_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Mung_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Mung_EN", enemySlot=3},
                });
            if (EnemyExist("Lymphropod_EN") && SaltEnemies.rando < 30)
            {
                groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Lymphropod_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=3},
                });
            }
            if (EnemyExist("OsseousClad_EN") && SaltEnemies.silly == 66)
            {
                groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Lurchin_EN") && SaltEnemies.trolling < 89)
            {
                groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Lurchin_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Seraphim_EN") && SaltEnemies.silly < 69)
            {
                groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Seraphim_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "JumbleGuts_Clotted_EN", enemySlot=2},
                });
            }
            if (EnemyExist("AnnoyingJumbleGuts_EN"))
            {
                groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "AnnoyingJumbleGuts_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=2},
                });
            }
            if (EnemyExist("ParasiticJumbleGuts_EN"))
            {
                groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "ParasiticJumbleGuts_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Mung_EN", enemySlot=2},
                });
            }
            if (MultiENExist("AmphibiousSpoggle_EN", "IchtyosatedSpoggle_EN"))
            {
                groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "IchtyosatedSpoggle_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "AmphibiousSpoggle_EN", enemySlot=2},
                });
            }
            if (EnemyExist("RougeWailingSplugling_EN"))
            {
                groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "RougeWailingSplugling_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Keko_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Keko_EN", enemySlot=3},
                });
                if (EnemyExist("RougeFesteringSplugling_EN"))
                {
                    groups.Add(new FieldEnemy[]
                        {
                        new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                        new FieldEnemy(){enemyName = "RougeFesteringSplugling_EN", enemySlot=1},
                        new FieldEnemy(){enemyName = "RougeWailingSplugling_EN", enemySlot=2},
                        new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=3},
                        });
                    if (EnemyExist("RougeBellowingSplugling_EN"))
                    {
                        groups.Add(new FieldEnemy[]
                            {
                            new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                            new FieldEnemy(){enemyName = "RougeBellowingSplugling_EN", enemySlot=1},
                            new FieldEnemy(){enemyName = "RougeFesteringSplugling_EN", enemySlot=2},
                            new FieldEnemy(){enemyName = "RougeWailingSplugling_EN", enemySlot=3},
                            });
                    }
                }
            }
            if (EnemyExist("RogueWailingSplugling_EN"))
            {
                groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "RogueWailingSplugling_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Keko_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Keko_EN", enemySlot=3},
                });
                if (EnemyExist("RogueFesteringSplugling_EN"))
                {
                    groups.Add(new FieldEnemy[]
                        {
                        new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                        new FieldEnemy(){enemyName = "RogueFesteringSplugling_EN", enemySlot=1},
                        new FieldEnemy(){enemyName = "RogueWailingSplugling_EN", enemySlot=2},
                        new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=3},
                        });
                    if (EnemyExist("RogueBellowingSplugling_EN"))
                    {
                        groups.Add(new FieldEnemy[]
                            {
                            new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                            new FieldEnemy(){enemyName = "RogueBellowingSplugling_EN", enemySlot=1},
                            new FieldEnemy(){enemyName = "RogueFesteringSplugling_EN", enemySlot=2},
                            new FieldEnemy(){enemyName = "RogueWailingSplugling_EN", enemySlot=3},
                            });
                    }
                }
            }
            if (EnemyExist("LittleBeak_EN"))
            {
                groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Keko_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Keko_EN", enemySlot=3},
                });
                groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=3},
                });
                groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FlaMinGoa_EN", enemySlot=2},
                });
                groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MunglingMudLung_EN", enemySlot=2},
                });
                groups.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomShoreMidget(false), enemySlot=3},
                });
            }
            shore.variations = groups.ToArray();
            shore.CheckEncounters();
            shore.AddEncounter();

            BrutalAPI.EnemyEncounter hardjak = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "AnglerfishShoreHard",
                area = 0,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = rarity,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/AnglerTheme",
                roarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Voboola_Hard_EnemyBundle")._roarReference.roarEvent,
                difficulty = EncounterDifficulty.Hard
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MunglingMudLung_EN", enemySlot=3},
            });
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "FlaMinGoa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=3},
            });
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "MunglingMudLung_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "JumbleGuts_Waning_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=2},
            });
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Spoggle_Ruminating_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Spoggle_Spitfire_EN", enemySlot=3},
            });
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Flarblet_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MunglingMudLung_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=3},
            });
            if (EnemyExist("Flarbleft_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Flarbleft_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Spoggle_Ruminating_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=3},
                });
            }
            if (SaltEnemies.trolling >= 83 && SaltEnemies.silly <= 83)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Keko_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Keko_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Keko_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Wringle_EN", enemySlot=4},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Keko_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Keko_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "JumbleGuts_Waning_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=4},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "JumbleGuts_Waning_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "JumbleGuts_Waning_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "JumbleGuts_Clotted_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "JumbleGuts_Waning_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "FlaMinGoa_EN", enemySlot=3},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Spoggle_Spitfire_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Spoggle_Ruminating_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Keko_EN", enemySlot=3},
                });
            if (EnemyExist("DeadPixel_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=2},
                });
            }
            if (EnemyExist("MechanicalLens_EN") && (SaltEnemies.silly > 82 || SaltEnemies.trolling < 27))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=2},
                }); fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FlaMinGoa_EN", enemySlot=2},
                });
                if (EnemyExist("LittleBeak_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                    new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=2},
                    });
                }
            }
            if (EnemyExist("LostSheep_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FlaMinGoa_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Flarblet_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "FlaMinGoa_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Flarblet_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Keko_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Keko_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Keko_EN", enemySlot=4},
                });
            }
            if (MultiENExist("Monck_EN", "ComposedColophon_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Monck_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Monck_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ComposedColophon_EN", enemySlot=3},
                });
            }
            if (EnemyExist("LipBug_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "LipBug_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "LipBug_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MunglingMudLung_EN", enemySlot=3},
                });
            }
            if (EnemyExist("DrySimian_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DrySimian_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "JumbleGuts_Waning_EN", enemySlot=3},
                }); fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DrySimian_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Spoggle_Ruminating_EN", enemySlot=3},
                });
                if (EnemyExist("Sigil_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                    new FieldEnemy(){enemyName = "DrySimian_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("LittleBeak_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                    new FieldEnemy(){enemyName = "DrySimian_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=3},
                    });
                }
            }
            if (EnemyExist("ComposedColophon_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "ComposedColophon_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ComposedColophon_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=3},
                });
                if (EnemyExist("DefeatedColophon_EN"))
                {
                    fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "ComposedColophon_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ComposedColophon_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "DefeatedColophon_EN", enemySlot=2},
                });
                }
            }
            if (EnemyExist("Skyloft_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FlaMinGoa_EN", enemySlot = 2},
                new FieldEnemy(){enemyName = "MunglingMudLung_EN", enemySlot = 3}
                });
            }
            if (EnemyExist("Teto_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Teto_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Teto_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Teto_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "JumbleGuts_Waning_EN", enemySlot=4},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=3},
                });
            if (EnemyExist("Lymphropod_EN") && SaltEnemies.silly > 25)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Lymphropod_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Lymphropod_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=3},
                });
            }
            if (MultiENExist("OsseousClad_EN", "Lymphropod_EN") && SaltEnemies.trolling > 30)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Lymphropod_EN", enemySlot=1 },
                });
            }
            if (MultiENExist("OsseousClad_EN", "LittleBeak_EN") && SaltEnemies.silly < 66)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=1 },
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=3 },
                });
            }
            if (EnemyExist("Lurchin_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Lurchin_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FlaMinGoa_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Seraphim_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Seraphim_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "JumbleGuts_Clotted_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "JumbleGuts_Clotted_EN", enemySlot=2},
                });
            }
            if (EnemyExist("ParasiticJumbleGuts_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "ParasiticJumbleGuts_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "JumbleGuts_Waning_EN", enemySlot=2},
                });
            }
            if (EnemyExist("BondedJumbleGuts_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "BondedJumbleGuts_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "AnnoyingJumbleGuts_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "JumbleGuts_Waning_EN", enemySlot=3},
                });
            }
            if (MultiENExist("AmphibiousSpoggle_EN", "IchtyosatedSpoggle_EN", "Monck_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "IchtyosatedSpoggle_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "AmphibiousSpoggle_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Monck_EN", enemySlot=2},
                });
            }
            if (SaltEnemies.rando < 50)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Flarb_EN", enemySlot=1},
                });
            }
            if (SaltEnemies.trolling > 22 && SaltEnemies.trolling < 72)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Voboola_EN", enemySlot=1},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "FlaMinGoa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Wringle_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Flarblet_EN", enemySlot=3},
                });
            if (EnemyExist("Derogatory_EN") && SaltEnemies.silly <= 28)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Derogatory_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Derogatory_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Derogatory_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Derogatory_EN", enemySlot=4},
                });
            }
            if (EnemyExist("Sigil_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FlaMinGoa_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=3 },
                });
            }
            if (EnemyExist("FesteringFaction_EN") && SaltEnemies.trolling == 84)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "FesteringFaction_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MudLung_EN", enemySlot=3 },
                });
            }
            if (MultiENExist("FesteringFaction_EN", "LittleBeak_EN") && SaltEnemies.trolling == 86)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "FesteringFaction_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=3 },
                });
            }
            if (EnemyExist("BoulderBuddy_EN") && SaltEnemies.trolling == 5)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "BoulderBuddy_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "JumbleGuts_Waning_EN", enemySlot=3 },
                });
            }
            if (EnemyExist("ColossalSheo_EN") && SaltEnemies.trolling == 28)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "ColossalSheo_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Flarblet_EN", enemySlot=2 },
                new FieldEnemy(){enemyName = "Flarblet_EN", enemySlot=3 },
                });
            }
            if (EnemyExist("Unflarb_EN") && (SaltEnemies.trolling == 38 || SaltEnemies.silly == 66))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Unflarb_EN", enemySlot=1},
                });
            }
            if (EnemyExist("LostSheep_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=3},
                new FieldEnemy(){enemyName = "FlaMinGoa_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=1},
                new FieldEnemy(){enemyName = RandomShoreMidget(), enemySlot=2},
                new FieldEnemy(){enemyName = RandomShoreMidget(), enemySlot=3},
                new FieldEnemy(){enemyName = RandomShoreMidget(), enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "A'Flower'_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MunglingMudLung_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Flarb_EN", enemySlot=3},
                });
            }
            hardjak.variations = fields.ToArray();
            hardjak.CheckEncounters();
            hardjak.AddEncounter();

        }
    }
    public static class CameraSong
    {
        public static int rarity
        {
            get
            {
                return UnityEngine.Random.Range(8, 13);
            }
        }

        public static void Add(int sign)
        {
            if (!EnemyExist("MechanicalLens_EN")) return;

            //BrutalAPI.BrutalAPI.AddSignType((SignType)sign, ResourceLoader.LoadSprite("FalseTruthIcon"));

            BrutalAPI.EnemyEncounter orpheum = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "CameraOrph",
                area = 1,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = rarity,
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/CameraSong",
                roarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone02_InnerChild_Hard_EnemyBundle")._roarReference.roarEvent,
                difficulty = EncounterDifficulty.Hard
            };
            List<FieldEnemy[]> fields = new List<FieldEnemy[]>();
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=1},
            });
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
            });
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
            });
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
            });
            fields.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=4},
            });
            if (EnemyExist("NakedGizo_EN") && SaltEnemies.trolling == 29)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NakedGizo_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NakedGizo_EN", enemySlot=3},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "JumbleGuts_Clotted_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "JumbleGuts_Hollowing_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=4},
                });
            if (EnemyExist("DeadPixel_EN") && SaltEnemies.trolling < 78)
            {

                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=4},
                });
            }
            if (EnemyExist("ComposedColophon_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ComposedColophon_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ComposedColophon_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot =4}
                });
            }
            if (MultiENExist("DefeatedColophon_EN", "ComposedColophon_EN") && SaltEnemies.silly == 63)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ComposedColophon_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "DefeatedColophon_EN", enemySlot =4}
                });
            }
            if (MultiENExist("DefeatedColophon_EN", "ComposedColophon_EN", "MaladjustedColophon_EN", "DelightedColophon_EN") && SaltEnemies.silly == 22)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ComposedColophon_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MaladjustedColophon_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "DelightedColophon_EN", enemySlot =4},
                new FieldEnemy(){enemyName = "DefeatedColophon_EN", enemySlot =0}
                });
            }
            if (SaltEnemies.trolling == 91)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Spoggle_Spitfire_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Spoggle_Ruminating_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Spoggle_Writhing_EN", enemySlot =4},
                new FieldEnemy(){enemyName = "Spoggle_Resonant_EN", enemySlot =0}
                });
            }
            if (SaltEnemies.trolling == 17)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "JumbleGuts_Waning_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "JumbleGuts_Clotted_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "JumbleGuts_Hollowing_EN", enemySlot =4},
                new FieldEnemy(){enemyName = "JumbleGuts_Flummoxing_EN", enemySlot =0}
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Spoggle_Ruminating_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Spoggle_Writhing_EN", enemySlot =4},
                });
            if (EnemyExist("Enigma_EN") && SaltEnemies.rando > 38)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                    {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Spoggle_Ruminating_EN", enemySlot=3},
                    });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=3},
                });
            if (SaltEnemies.silly == 56)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot=4},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "JumbleGuts_Hollowing_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "JumbleGuts_Clotted_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot = 4}
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot = 4}
                });
            if (MultiENExist("IchtyosatedSpoggle_EN", "FoamingSpoggle_EN") && SaltEnemies.rando < 85)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "FoamingSpoggle_EN", enemySlot = 1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "IchtyosatedSpoggle_EN", enemySlot=3},
                });
            }
            if (MultiENExist("ArtisticJumbleGuts_EN", "MalignantJumbleGuts_EN") && SaltEnemies.trolling > 48)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "MalignantJumbleGuts_EN", enemySlot = 1},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ArtisticJumbleGuts_EN", enemySlot=3},
                });
            }
            if (MultiENExist("PoolingSpoggle_EN", "EclipsedSpoggle_EN") && SaltEnemies.silly < 67)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "EclipsedSpoggle_EN", enemySlot = 1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "PoolingSpoggle_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=4},
                });
            }
            if (MultiENExist("AnnoyingJumbleGuts_EN", "WaxingJumbleGuts_EN") && SaltEnemies.rando > 13)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "WaxingJumbleGuts_EN", enemySlot = 1},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "AnnoyingJumbleGuts_EN", enemySlot=3},
                });
            }
            if (EnemyExist("RougeWeepingSplugling_EN") && EnemyExist("RougeWailingSplugling_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "RougeWeepingSplugling_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "RougeWailingSplugling_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "RougeWeepingSplugling_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "RougeWailingSplugling_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "RougeWeepingSplugling_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "RougeWailingSplugling_EN", enemySlot=4},
                });
                if (MultiENExist("Gizo_EN", "NakedGizo_EN"))
                {
                    fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "NakedGizo_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "RougeWailingSplugling_EN", enemySlot=4},
                });
                }
                if (EnemyExist("LostSheep_EN"))
                {
                    fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "RougeWeepingSplugling_EN", enemySlot=3},
                });
                }
                if (EnemyExist("RougeBellowingSplugling_EN") && SaltEnemies.trolling > 12)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                    new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 1},
                    new FieldEnemy(){enemyName = "RougeBellowingSplugling_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "RougeWeepingSplugling_EN", enemySlot=3}
                    });
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                    new FieldEnemy(){enemyName = "RougeBellowingSplugling_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "RougeWailingSplugling_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=4},
                    });
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                    new FieldEnemy(){enemyName = "RougeBellowingSplugling_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=4},
                    });
                    if (EnemyExist("RougeFesteringSplugling_EN") && SaltEnemies.silly == 84)
                    {
                        fields.Add(new FieldEnemy[]
                        {
                        new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                        new FieldEnemy(){enemyName = "RougeWailingSplugling_EN", enemySlot=1},
                        new FieldEnemy(){enemyName = "RougeBellowingSplugling_EN", enemySlot=2},
                        new FieldEnemy(){enemyName = "RougeWeepingSplugling_EN", enemySlot=3},
                        new FieldEnemy(){enemyName = "RougeFesteringSplugling_EN", enemySlot = 4 },
                        });
                    }
                }
            }
            if (EnemyExist("RogueWeepingSplugling_EN") && EnemyExist("RogueWailingSplugling_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "RogueWeepingSplugling_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "RogueWailingSplugling_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "RogueWeepingSplugling_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "RogueWailingSplugling_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "RogueWeepingSplugling_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "RogueWailingSplugling_EN", enemySlot=4},
                });
                if (MultiENExist("Gizo_EN", "NakedGizo_EN"))
                {
                    fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "NakedGizo_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "RogueWailingSplugling_EN", enemySlot=4},
                });
                }
                if (EnemyExist("LostSheep_EN"))
                {
                    fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "RogueWeepingSplugling_EN", enemySlot=3},
                });
                }
                if (EnemyExist("RogueBellowingSplugling_EN") && SaltEnemies.trolling > 12)
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                    new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 1},
                    new FieldEnemy(){enemyName = "RogueBellowingSplugling_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "RogueWeepingSplugling_EN", enemySlot=3}
                    });
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                    new FieldEnemy(){enemyName = "RogueBellowingSplugling_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "RogueWailingSplugling_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=4},
                    });
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                    new FieldEnemy(){enemyName = "RogueBellowingSplugling_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=4},
                    });
                    if (EnemyExist("RogueFesteringSplugling_EN") && SaltEnemies.silly == 84)
                    {
                        fields.Add(new FieldEnemy[]
                        {
                        new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                        new FieldEnemy(){enemyName = "RogueWailingSplugling_EN", enemySlot=1},
                        new FieldEnemy(){enemyName = "RogueBellowingSplugling_EN", enemySlot=2},
                        new FieldEnemy(){enemyName = "RogueWeepingSplugling_EN", enemySlot=3},
                        new FieldEnemy(){enemyName = "RogueFesteringSplugling_EN", enemySlot = 4 },
                        });
                    }
                }
            }
            if (EnemyExist("Pacemaker_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Pacemaker_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=4},
                });
                if (EnemyExist("TheCrow_EN"))
                {
                    fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Pacemaker_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=3},
                });
                }
            }
            if (EnemyExist("Nameless_EN") && SaltEnemies.silly < 35)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Nameless_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot =3},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot =4},
                });
            }
            if (EnemyExist("EyePalm_EN") && SaltEnemies.trolling == 16)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot =3},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot = 4},
                });
            }
            if (EnemyExist("WindSong_EN") && SaltEnemies.rando < 84)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot =2},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot =3},
                });
            }
            if (EnemyExist("DesiccatingJumbleguts_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DesiccatingJumbleguts_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=3},
                });
            }
            if (EnemyExist("PerforatedSpoggle_EN") && SaltEnemies.trolling > 28)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "PerforatedSpoggle_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Spoggle_Writhing_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Spoggle_Ruminating_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Gizo_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Spoggle_Spitfire_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=3},
                });
                if (EnemyExist("Enigma_EN"))
                {
                    fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "JumbleGuts_Hollowing_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=3},
                });
                }
                if (MultiENExist("LostSheep_EN", "NakedGizo_EN"))
                {
                    fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "NakedGizo_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=3},
                });
                }
                if (EnemyExist("TheCrow_EN"))
                {
                    fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=3},
                });
                }
                if (SaltEnemies.silly < 47)
                {
                    fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=4},
                });
                }
            }
            if (EnemyExist("Chapman_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "JumbleGuts_Waning_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=3},
                });
                if (MultiENExist("Skyloft_EN", "LivingSolvent_EN") && SaltEnemies.trolling == 7)
                {
                    fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=4},
                });
                }
                if (EnemyExist("TheCrow_EN") && SaltEnemies.trolling <= 47)
                {
                    fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=3},
                });
                }
            }
            if (EnemyExist("Chapman_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=4},
                new FieldEnemy(){enemyName = "Spoggle_Writhing_EN", enemySlot=2},
                });
                if (EnemyExist("Enigma_EN"))
                {
                    fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=3},
                });
                }
                if (MultiENExist("LostSheep_EN", "WindSong_EN"))
                {
                    fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=4},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=3},
                });
                }
                if (EnemyExist("Freud_EN"))
                {
                    fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Freud_EN", enemySlot=3},
                });
                }
                if (EnemyExist("TripodFish_EN"))
                {
                    fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=3},
                });
                }
                if (SaltEnemies.silly < 38)
                {
                    fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Chapman_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=4},
                });
                }
            }
            if (EnemyExist("FamiliarSpoggle_EN") && SaltEnemies.trolling == 47)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FamiliarSpoggle_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Spoggle_Writhing_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=4},
                });
            }
            if (EnemyExist("Ophanim_EN") && SaltEnemies.trolling == 75)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Ophanim_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "JumbleGuts_Clotted_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=4},
                });
                if (MultiENExist("RealisticTank_EN", "FakeAngel_EN") && SaltEnemies.trolling == 62)
                {
                    fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Ophanim_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=4},
                });
                }
            }
            if (EnemyExist("Seraphim_EN") && SaltEnemies.trolling < 60)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Seraphim_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "JumbleGuts_Clotted_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Seraphim_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=4},
                });
                if (EnemyExist("Freud_EN") && SaltEnemies.silly == 63)
                {
                    fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Seraphim_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Freud_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=4},
                });
                }
                if (EnemyExist("Shua_EN") && SaltEnemies.silly == 58)
                {
                    fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Seraphim_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=4},
                });
                }
            }
            if (EnemyExist("Something_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "JumbleGuts_Flummoxing_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=3},
                });
            }
            if (EnemyExist("TheCrow_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=3},
                });
                if (EnemyExist("Lyssa_EN") && SaltEnemies.rando < 77)
                {
                    fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=3},
                });
                }
            }
            if (EnemyExist("Freud_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 1},
                new FieldEnemy(){enemyName = "Freud_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=4},
                });
                if (EnemyExist("TripodFish_EN") && SaltEnemies.silly > 33)
                {
                    fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Freud_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=4},
                });
                }
            }
            if (MultiENExist("Illusion_EN", "FakeAngel_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot = 1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=4},
                });
                if (EnemyExist("TheCrow_EN"))
                {
                    fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot = 1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=3},
                });
                }
            }
            if (MultiENExist("YellowFlower_EN", "PurpleFlower_EN"))
            {
                if (EnemyExist("FakeAngel_EN"))
                {
                    fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot = 1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=3},
                });
                }
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot = 1},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot = 1},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot = 1},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=4},
                });
                if (EnemyExist("Something_EN"))
                {
                    fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot = 1},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Something_EN", enemySlot=4},
                });
                }
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 1},
                new FieldEnemy(){enemyName = "Conductor_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 1},
                new FieldEnemy(){enemyName = "Revola_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "JumbleGuts_Hollowing_EN", enemySlot = 1},
                new FieldEnemy(){enemyName = "Revola_EN", enemySlot=2},
                });
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "WrigglingSacrifice_EN", enemySlot = 1},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=2},
                });
            if (EnemyExist("Skyloft_EN") && SaltEnemies.rando > 20)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "WrigglingSacrifice_EN", enemySlot = 1},
                new FieldEnemy(){enemyName = "WrigglingSacrifice_EN", enemySlot = 3},
                new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot = 1},
                new FieldEnemy(){enemyName = "JumbleGuts_Flummoxing_EN", enemySlot = 3},
                new FieldEnemy(){enemyName = "JumbleGuts_Hollowing_EN", enemySlot = 4},
                new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=2},
                });
            }
            fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot = 1},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot = 2},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot = 3},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot = 4},
                });
            if (MultiENExist("RealisticTank_EN", "FakeAngel_EN") && SaltEnemies.rando > 28)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot = 1},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot = 4},
                new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot = 4},
                new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=2},
                });
            }
            if (EnemyExist("StalwartTortoise_EN") && SaltEnemies.rando > 33)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 1},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=2},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "JumbleGuts_Waning_EN", enemySlot = 4},
                new FieldEnemy(){enemyName = "JumbleGuts_Hollowing_EN", enemySlot = 1},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=2},
                });
            }
            if (EnemyExist("Merced_EN") && SaltEnemies.trolling == 41)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot = 1},
                new FieldEnemy(){enemyName = "WrigglingSacrifice_EN", enemySlot = 3},
                });
            }
            if (EnemyExist("LostSheep_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "JumbleGuts_Hollowing_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "JumbleGuts_Waning_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Spoggle_Resonant_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Spoggle_Spitfire_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Spoggle_Resonant_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=4},
                });
                if (EnemyExist("WindSong_EN"))
                {
                    fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=4},
                });
                }
                if (EnemyExist("LivingSolvent_EN") && SaltEnemies.silly == 96)
                {
                    fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=4},
                });
                }
                if (EnemyExist("Merced_EN") && SaltEnemies.silly < 24)
                {
                    fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=4},
                });
                }
                if (EnemyExist("Gizo_EN"))
                {
                    fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "JumbleGuts_Waning_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=4},
                });
                }
                if (EnemyExist("Nameless_EN") && SaltEnemies.trolling == 45)
                {
                    fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Nameless_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=4},
                });
                }
                if (EnemyExist("DesiccatingJumbleguts_EN"))
                {
                    fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "DesiccatingJumbleguts_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=4},
                });
                }
                if (EnemyExist("RevoltingRevola_EN") && SaltEnemies.trolling > 77)
                {
                    fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "RevoltingRevola_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=4},
                });
                }
            }
            if (EnemyExist("Sigil_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Spoggle_Writhing_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Spoggle_Ruminating_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=4},
                });
            }
            if (EnemyExist("Butterfly_EN") && SaltEnemies.silly == 61)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=4},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=5},
                });
            }
            if (EnemyExist("Goliath_EN") && SaltEnemies.silly == 21 || SaltEnemies.trolling == 72)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Goliath_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Goliath_EN", enemySlot=3},
                });
            }
            if (EnemyExist("Gordo_EN") && SaltEnemies.silly == 20)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Gordo_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=4},
                });
                if (EnemyExist("Enigma_EN") && SaltEnemies.trolling <= 55)
                {
                    fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Gordo_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=4},
                });
                }
            }
            if (MultiENExist("DefeatedColophon_EN", "ComposedColophon_EN", "MaladjustedColophon_EN", "DelightedColophon_EN") && SaltEnemies.trolling >= 13)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ComposedColophon_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "DelightedColophon_EN", enemySlot =4},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot =0}
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ComposedColophon_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot =4},
                new FieldEnemy(){enemyName = "DefeatedColophon_EN", enemySlot =0}
                });
                if (SaltEnemies.trolling <= 89)
                {
                    fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "ComposedColophon_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "DelightedColophon_EN", enemySlot =4},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot =0}
                });
                    fields.Add(new FieldEnemy[]
                    {
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MaladjustedColophon_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "DelightedColophon_EN", enemySlot =4},
                    });
                }
            }
            if (EnemyExist("ReflectedHound_EN") && SaltEnemies.trolling <= 58)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ReflectedHound_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "JumbleGuts_Hollowing_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ReflectedHound_EN", enemySlot=3},
                });
            }
            if (EnemyExist("OsseousClad_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=4},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=1},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Spoggle_Ruminating_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Spoggle_Resonant_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "OsseousClad_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=4},
                });
            }
            if (EnemyExist("ColossalSheo_EN") && SaltEnemies.silly > 35)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "ColossalSheo_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "JumbleGuts_Waning_EN", enemySlot=4},
                });
                if (SaltEnemies.trolling == 74)
                {
                    fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "ColossalSheo_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=1},
                });
                }
            }
            if (EnemyExist("Lyssa_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Spoggle_Resonant_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=4},
                });
            }
            if (EnemyExist("GlassFigurine_EN") && SaltEnemies.trolling > 67)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "GlassFigurine_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=1},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "GlassFigurine_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "JumbleGuts_Clotted_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "JumbleGuts_Waning_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "GlassFigurine_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=4},
                });
            }
            if (SaltEnemies.trolling == 87)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot = 1},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot = 2},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot = 3},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 4},
                });
            }
            if (SaltEnemies.trolling == 78)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot = 1},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot = 2},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot = 3},
                new FieldEnemy(){enemyName = "ManicMan_EN", enemySlot = 4},
                });
            }
            if (EnemyExist("Damocles_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Damocles_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=4},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=1},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Damocles_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Spoggle_Writhing_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Spoggle_Resonant_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Damocles_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=4},
                });
            }
            if (EnemyExist("Romantic_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "Scrungie_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Romantic_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=3},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=4},
                });
            }
            if (EnemyExist("LittleBeak_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=3},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=3},
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=4},
                });
                if (EnemyExist("Seraphim_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                    new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Seraphim_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=4},
                    });
                }
                if (EnemyExist("Warbird_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                    new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Warbird_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "SilverSuckle_EN", enemySlot=4},
                    });
                }
                if (EnemyExist("TheCrow_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                    new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=4},
                    });
                }
                if (EnemyExist("WindSong_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                    new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=3},
                    });
                }
                if (EnemyExist("Enigma_EN"))
                {
                    fields.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                    new FieldEnemy(){enemyName = "LittleBeak_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=4},
                    });
                }
            }
            if (EnemyExist("Hunter_EN") && SaltEnemies.rando > 35)
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomOrph, enemySlot=3},
                new FieldEnemy(){enemyName = RandomColor(0), enemySlot=4},
                });
                if (SaltEnemies.trolling == 74)
                {
                    fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "Hunter_EN", enemySlot=2},
                new FieldEnemy(){enemyName = RandomSupport(1, false, false), enemySlot=3},
                new FieldEnemy(){enemyName = RandomSupport(1), enemySlot=1},
                });
                }
            }
            if (EnemyExist("FumeFactory_EN"))
            {
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "FumeFactory_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MusicMan_EN", enemySlot=4},
                });
                fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "FumeFactory_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SingingStone_EN", enemySlot=3},
                });
                if (EnemyExist("Gizo_EN") && SaltEnemies.rando < 77)
                {
                    fields.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot = 0},
                new FieldEnemy(){enemyName = "FumeFactory_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Gizo_EN", enemySlot=3},
                });
                }
            }
            orpheum.variations = fields.ToArray();
            orpheum.AddEncounter();

            //UnityEngine.Debug.LogError("IM MAKING THE REST OF THESE LATER FUCK OF");return;

            BrutalAPI.EnemyEncounter garden = new BrutalAPI.EnemyEncounter()
            {
                encounterName = "CameraGarden",
                area = 2,
                randomPlacement = true,
                hardmodeEncounter = true,
                rarity = (int)((float)rarity * 1.5f),
                signType = (SignType)sign,
                musicEvent = "event:/Hawthorne/CameraSong",
                roarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone02_InnerChild_Hard_EnemyBundle")._roarReference.roarEvent,
                difficulty = EncounterDifficulty.Hard
            };
            List<FieldEnemy[]> battle = new List<FieldEnemy[]>();
            battle.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=4},
            });
            battle.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=4},
            });
            battle.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=4},
            });
            battle.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=3},
            });
            battle.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=4},
            });
            battle.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=4},
            });
            battle.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=4},
            });
            battle.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=3},
            });
            battle.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
            });
            battle.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=4},
            });
            battle.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=4},
            });
            battle.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=2},
            });
            battle.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=3},
            });
            if (EnemyExist("TitteringPeon_EN"))
            {
                battle.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
            });
                if (EnemyExist("Shua_EN"))
                {
                    battle.Add(new FieldEnemy[]
                    {
                        new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                        new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=1},
                        new FieldEnemy(){enemyName = "Shua_EN", enemySlot=2},
                        new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=3},
                        new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=4},
                    });
                }
            }
            if (EnemyExist("ScreamingHomunculus_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                    new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "ScreamingHomunculus_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=3},
                });
                if (EnemyExist("GlassFigurine_EN") && SaltEnemies.trolling == 63)
                {
                    battle.Add(new FieldEnemy[]
                {
                    new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "ScreamingHomunculus_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "GlassFigurine_EN", enemySlot=4},
                });
                }
                if (EnemyExist("WindSong_EN") && SaltEnemies.silly > 33)
                {
                    battle.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "ScreamingHomunculus_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=3},
                    new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=4},
                    });
                }
            }
            if (EnemyExist("SterileBud_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=4},
                });
                if (EnemyExist("LostSheep_EN"))
                {
                    battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=4},
                });
                }
            }
            if (EnemyExist("ImpenetrableAngler_EN") && SaltEnemies.silly < 68)
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ImpenetrableAngler_EN", enemySlot=2},
                });
                if (EnemyExist("LittleAngel_EN"))
                {
                    battle.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ImpenetrableAngler_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=4},
            });
                }
            }
            if (EnemyExist("Metatron_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Metatron_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=4},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                });
                if (EnemyExist("EggKeeper_EN"))
                {
                    battle.Add(new FieldEnemy[]
            {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Metatron_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=4},
            });
                }
            }
            if (EnemyExist("Unterling_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Unterling_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Unterling_EN", enemySlot=2},
                });
                if (EnemyExist("RedFlower_EN"))
                {
                    battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Unterling_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=4},
                });
                }
            }
            if (EnemyExist("Psychopomp_EN") && SaltEnemies.trolling > 44 && SaltEnemies.trolling < 67)
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Psychopomp_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=3},
                });
                if (EnemyExist("EyePalm_EN") && SaltEnemies.silly == 59)
                {
                    battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Psychopomp_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=4},
                });
                }
            }
            if (EnemyExist("LostSheep_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=3},
                });
                if (EnemyExist("FakeAngel_EN"))
                {
                    battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LostSheep_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                });
                }
            }
            if (EnemyExist("DeadPixel_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=3},
                });
                if (EnemyExist("TheCrow_EN") && SaltEnemies.trolling == 25)
                {
                    battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "DeadPixel_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=4},
                });
                }
            }
            if (EnemyExist("LittleAngel_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=4},
                });
                if (MultiENExist("LivingSolvent_EN", "FakeAngel_EN") && SaltEnemies.silly == 15)
                {
                    battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4}
                });
                }
            }
            if (EnemyExist("Satyr_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Satyr_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=3},
                });
                if (EnemyExist("EggKeeper_EN"))
                {
                    battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Satyr_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=4},
                });
                }
            }
            if (EnemyExist("TheCrow_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=4},
                });
                if (EnemyExist("EyePalm_EN"))
                {
                    battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "TheCrow_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=4},
                });
                }
            }
            if (EnemyExist("Freud_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Freud_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=3},
                });
                if (EnemyExist("ClockTower_EN") && SaltEnemies.silly == 43)
                {
                    battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Freud_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=3},
                });
                }
            }
            if (EnemyExist("StarGazer_EN") && SaltEnemies.trolling == 94)
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "StarGazer_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "StarGazer_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "StarGazer_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "StarGazer_EN", enemySlot=4},
                });
            }
            if (EnemyExist("RusticJumbleguts_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "RusticJumbleguts_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=4},
                });
                if (EnemyExist("Skyloft_EN"))
                {
                    battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "RusticJumbleguts_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=4},
                });
                }
            }
            if (EnemyExist("MortalSpoggle_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MortalSpoggle_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=3},
                });
                if (EnemyExist("WindSong_EN") && SaltEnemies.silly > 13 && SaltEnemies.silly < 52)
                {
                    battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MortalSpoggle_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=4},
                });
                }
            }
            if (EnemyExist("FakeAngel_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=2},
                });
                if (EnemyExist("RealisticTank_EN"))
                {
                    battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=2},
                });
                }
            }
            if (MultiENExist("Illusion_EN", "FakeAngel_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=4},
                });
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Illusion_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=4},
                });
            }
            if (EnemyExist("RedFlower_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=4},
                });
                if (EnemyExist("SterileBud_EN"))
                {
                    battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SterileBud_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=3},
                });
                }
            }
            if (EnemyExist("BlueFlower_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=4},
                });
                if (EnemyExist("TripodFish_EN"))
                {
                    battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=4},
                });
                }
                if (EnemyExist("RedFlower_EN"))
                {
                    battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=4},
                });
                }
            }
            if (EnemyExist("YellowFlower_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=4},
                });
                if (EnemyExist("EggKeeper_EN"))
                {
                    battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=3},
                });
                }
                if (EnemyExist("Skyloft_EN"))
                {
                    battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=4},
                });
                }
            }
            if (EnemyExist("PurpleFlower_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=4},
                });
                if (EnemyExist("TitteringPeon_EN"))
                {
                    battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=3},
                });
                }
                if (EnemyExist("YellowFlower_EN"))
                {
                    battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=3},
                });
                }
                if (EnemyExist("Merced_EN"))
                {
                    battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=4},
                });
                }
            }
            if (EnemyExist("GreyFlower_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "GreyFlower_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=3},
                });
                if (EnemyExist("RealisticTank_EN") && SaltEnemies.silly > 66)
                {
                    battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "GreyFlower_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=2},
                });
                }
            }
            if (MultiENExist("RedFlower_EN", "BlueFlower_EN", "YellowFlower_EN", "PurpleFlower_EN") && SaltEnemies.trolling == 47)
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "YellowFlower_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=4},
                });
            }
            if (EnemyExist("LivingSolvent_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=3},
                });
                if (EnemyExist("MiniReaper_EN") && SaltEnemies.silly < 38)
                {
                    battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LivingSolvent_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=3},
                });
                }
            }
            if (EnemyExist("WindSong_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=3},
                });
                if (MultiENExist("BlueFlower_EN", "EggKeeper_EN"))
                {
                    battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "GigglingMinister_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=4},
                });
                }
            }
            if (EnemyExist("Sigil_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=4},
                });
                if (EnemyExist("Scuttlerunt_EN"))
                {
                    battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Sigil_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Scuttlerunt_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Scuttlerunt_EN", enemySlot=3},
                });
                }
            }
            if (EnemyExist("RealisticTank_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=4},
                });
                if (MultiENExist("MiniReaper_EN", "FakeAngel_EN"))
                {
                    battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=4},
                });
                }
            }
            if (EnemyExist("ClockTower_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=3},
                });
                if (EnemyExist("MiniReaper_EN") && SaltEnemies.silly == 56)
                {
                    battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ClockTower_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=3},
                });
                }
            }
            if (EnemyExist("StalwartTortoise_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=4},
                });
                if (EnemyExist("Unterling_EN"))
                {
                    battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Unterling_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Unterling_EN", enemySlot=4},
                });
                }
            }
            if (EnemyExist("Grandfather_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=4},
                });
                if (EnemyExist("EyePalm_EN"))
                {
                    battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=4},
                });
                }
                if (EnemyExist("RedFlower_EN"))
                {
                    battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "RedFlower_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=4},
                });
                }
            }
            if (EnemyExist("MiniReaper_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=4},
                });
                if (EnemyExist("LittleAngel_EN"))
                {
                    battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "MiniReaper_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=4},
                });
                }
            }
            if (EnemyExist("Skyloft_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=4},
                });
                if (EnemyExist("Lyssa_EN"))
                {
                    battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Skyloft_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=4},
                });
                }
            }
            if (EnemyExist("EyePalm_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=4},
                });
                if (EnemyExist("Metatron_EN"))
                {
                    battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Metatron_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "EyePalm_EN", enemySlot=4},
                });
                }
            }
            if (EnemyExist("Merced_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=3},
                });
                if (MultiENExist("PurpleFlower_EN", "TitteringPeon_EN"))
                {
                    battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "PurpleFlower_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=4},
                });
                }
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Merced_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=4},
                });
            }
            if (EnemyExist("Butterfly_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=4},
                });
                if (EnemyExist("Shua_EN"))
                {
                    battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Butterfly_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=4},
                });
                }
            }
            if (EnemyExist("Nameless_EN") && (SaltEnemies.trolling > 68 || SaltEnemies.trolling < 20))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Nameless_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "ChoirBoy_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=4},
                });
                if (EnemyExist("StalwartTortoise_EN"))
                {
                    battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Nameless_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "StalwartTortoise_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=4},
                });
                }
            }
            if (EnemyExist("TripodFish_EN") && SaltEnemies.rando != 36)
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=4},
                });
                if (MultiENExist("Enigma_EN", "BlueFlower_EN"))
                {
                    battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Enigma_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "BlueFlower_EN", enemySlot=4},
                });
                }
            }
            if (EnemyExist("Lyssa_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=4},
                });
                if (EnemyExist("TitteringPeon_EN"))
                {
                    battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "TitteringPeon_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=4},
                });
                }
                if (EnemyExist("Harbinger_EN"))
                {
                    battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Lyssa_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Harbinger_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=4},
                });
                }
            }
            if (EnemyExist("GlassFigurine_EN") && SaltEnemies.silly >= 50 && SaltEnemies.rando < 50)
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "GlassFigurine_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "ShiveringHomunculus_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=4},
                });
                if (MultiENExist("Unterling_EN", "EggKeeper_EN", "Shua_EN"))
                {
                    battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "GlassFigurine_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Unterling_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Shua_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=4},
                });
                }
            }
            if (EnemyExist("InfernalDrummer_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InfernalDrummer_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=4},
                });
                if (EnemyExist("LittleAngel_EN"))
                {
                    battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InfernalDrummer_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=3},
                });
                }
            }
            if (EnemyExist("Harbinger_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Harbinger_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=4},
                });
                if (EnemyExist("LittleAngel_EN"))
                {
                    battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Harbinger_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "LittleAngel_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=4},
                });
                }
            }
            if (EnemyExist("HowlingAvian_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "HowlingAvian_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=2},
                });
                if (EnemyExist("TripodFish_EN"))
                {
                    battle.Add(new FieldEnemy[]
                    {
                        new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                        new FieldEnemy(){enemyName = "HowlingAvian_EN", enemySlot=1},
                        new FieldEnemy(){enemyName = "TripodFish_EN", enemySlot=3},
                        new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=4},
                    });
                }
            }
            if (EnemyExist("Scuttlerunt_EN") && SaltEnemies.silly < 66)
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Scuttlerunt_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Scuttlerunt_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "NextOfKin_EN", enemySlot=3},
                });
                if (EnemyExist("Unterling_EN"))
                {
                    battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Scuttlerunt_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "Scuttlerunt_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "Unterling_EN", enemySlot=3},
                });
                }
            }
            if (EnemyExist("EggKeeper_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                });
                if (EnemyExist("WindSong_EN"))
                {
                    battle.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "WindSong_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=3},
                    });
                }
                if (MultiENExist("Grandfather_EN", "Psychopomp_EN") && SaltEnemies.trolling == 88)
                {
                    battle.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "EggKeeper_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "Grandfather_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "Psychopomp_EN", enemySlot=3},
                    });
                }
            }
            if (EnemyExist("Damocles_EN"))
            {
                battle.Add(new FieldEnemy[]
                {
                new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                new FieldEnemy(){enemyName = "Damocles_EN", enemySlot=1},
                new FieldEnemy(){enemyName = "InHisImage_EN", enemySlot=2},
                new FieldEnemy(){enemyName = "InHerImage_EN", enemySlot=3},
                });
                if (EnemyExist("ScreamingHomunculus_EN"))
                {
                    battle.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Damocles_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "ScreamingHomunculus_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "SkinningHomunculus_EN", enemySlot=3},
                    });
                }
                if (MultiENExist("RealisticTank_EN", "FakeAngel_EN"))
                {
                    battle.Add(new FieldEnemy[]
                    {
                    new FieldEnemy(){enemyName = "MechanicalLens_EN", enemySlot=0},
                    new FieldEnemy(){enemyName = "Damocles_EN", enemySlot=1},
                    new FieldEnemy(){enemyName = "FakeAngel_EN", enemySlot=2},
                    new FieldEnemy(){enemyName = "RealisticTank_EN", enemySlot=3},
                    });
                }
            }
            garden.variations = battle.ToArray();
            garden.AddEncounter();
        }
        public static void Modify()
        {
            if (!BundleExist("Camera_Hard") || !BundleRandom("Camera_Hard")) return;
            if (!EnemyExist("MechanicalLens_EN")) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Camera_Hard"))._enemyBundles);
            list.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "MechanicalLens_EN",
                    "MunglingMudLung_EN",
                    "MudLung_EN"
                }
            });
            if (EnemyExist("Monck_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "MechanicalLens_EN",
                        "MechanicalLens_EN",
                        "Monck_EN"
                    }
                });
            }
            if (EnemyExist("DrySimian_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "MechanicalLens_EN",
                        "MudLung_EN",
                        "DrySimian_EN"
                    }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "MechanicalLens_EN",
                        "JumbleGuts_Waning_EN",
                        "DrySimian_EN"
                    }
                });
            }
            if (EnemyExist("LittleBeak_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "MechanicalLens_EN",
                        "LittleBeak_EN",
                        "FlaMinGoa_EN"
                    }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "MechanicalLens_EN",
                        "MechanicalLens_EN",
                        "LittleBeak_EN"
                    }
                });
            }
            if (EnemyExist("Flarbleft_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "MechanicalLens_EN",
                        "JumbleGuts_Clotted_EN",
                        "Flarbleft_EN"
                    }
                });
            }
            if (EnemyExist("LipBug_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "MechanicalLens_EN",
                        "FlaMinGoa_EN",
                        "LipBug_EN"
                    }
                });
            }
            if (EnemyExist("Seraphim_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "MechanicalLens_EN",
                        "Keko_EN",
                        "Keko_EN",
                        "Seraphim_EN"
                    }
                });
            }
            if (EnemyExist("TripodFish_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "MechanicalLens_EN",
                        "MunglingMudLung_EN",
                        "TripodFish_EN"
                    }
                });
            }
            if (MultiENExist("A'Flower'_EN", "LipBug_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "MechanicalLens_EN",
                        "LipBug_EN",
                        "MudLung_EN",
                        "A'Flower'_EN"
                    }
                });
            }
            if (EnemyExist("Lyssa_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "MechanicalLens_EN",
                        "Lyssa_EN",
                        "JumbleGuts_Waning_EN",
                        "Wringle_EN"
                    }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "MechanicalLens_EN",
                        "Lyssa_EN",
                        "MudLung_EN",
                        "MudLung_EN"
                    }
                });
            }
            if (EnemyExist("Enigma_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "MechanicalLens_EN",
                        "Enigma_EN",
                        "Enigma_EN"
                    }
                });
            }
            if (MultiENExist("BondedJumbleGuts_EN", "AnnoyingJumbleGuts_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "MechanicalLens_EN",
                        "BondedJumbleGuts_EN",
                        "AnnoyingJumbleGuts_EN"
                    }
                });
            }
            if (EnemyExist("ParasiticJumbleGuts_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "MechanicalLens_EN",
                        "ParasiticJumbleGuts_EN",
                        "MunglingMudLung_EN"
                    }
                });
            }
            if (MultiENExist("AmphibiousSpoggle_EN", "IchtyosatedSpoggle_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "MechanicalLens_EN",
                        "IchtyosatedSpoggle_EN",
                        "AmphibiousSpoggle_EN"
                    }
                });
            }
            if (EnemyExist("EclipsedSpoggle_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "MechanicalLens_EN",
                        "EclipsedSpoggle_EN",
                        "FlaMinGoa_EN"
                    }
                });
            }
            if (EnemyExist("Lurchin_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "MechanicalLens_EN",
                        "MechanicalLens_EN",
                        "MunglingMudLung_EN",
                        "Lurchin_EN"
                    }
                });
            }
            if (EnemyExist("DefeatedColophon_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "DefeatedColophon_EN",
                        "MechanicalLens_EN",
                        "Flarb_EN"
                    }
                });
            }
            if (EnemyExist("ComposedColophon_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "MechanicalLens_EN",
                        "JumbleGuts_Clotted_EN",
                        "ComposedColophon_EN"
                    }
                });
            }
            if (EnemyExist("Teto_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "MechanicalLens_EN",
                        "Teto_EN",
                        "Teto_EN",
                        "Spoggle_Spitfire_EN"
                    }
                });
            }
            if (EnemyExist("OsseousClad_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "MechanicalLens_EN",
                        "MechanicalLens_EN",
                        "OsseousClad_EN",
                        "Spoggle_Ruminating_EN"
                    }
                });
            }
            if (EnemyExist("Lymphropod_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "MechanicalLens_EN",
                        "Lymphropod_EN",
                        "Lymphropod_EN"
                    }
                });
            }
            if (EnemyExist("RougeWailingSplugling_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "RougeWailingSplugling_EN",
                        "MechanicalLens_EN",
                        "MudLung_EN",
                        "MudLung_EN"
                    }
                });
            }
            if (EnemyExist("RougeBellowingSplugling_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "RougeBellowingSplugling_EN",
                        "MechanicalLens_EN",
                        "FlaMinGoa_EN"
                    }
                });
            }
            if (EnemyExist("RougeFesteringSplugling_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "RougeFesteringSplugling_EN",
                        "MechanicalLens_EN",
                        "MunglingMudLung_EN"
                    }
                });
            }
            if (EnemyExist("RougeWeepingSplugling_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "RougeWeepingSplugling_EN",
                        "MechanicalLens_EN",
                        "MudLung_EN",
                        "Flarblet_EN"
                    }
                });
            }
            if (EnemyExist("RogueWailingSplugling_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "RogueWailingSplugling_EN",
                        "MechanicalLens_EN",
                        "MudLung_EN",
                        "MudLung_EN"
                    }
                });
            }
            if (EnemyExist("RogueBellowingSplugling_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "RogueBellowingSplugling_EN",
                        "MechanicalLens_EN",
                        "FlaMinGoa_EN"
                    }
                });
            }
            if (EnemyExist("RogueFesteringSplugling_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "RogueFesteringSplugling_EN",
                        "MechanicalLens_EN",
                        "MunglingMudLung_EN"
                    }
                });
            }
            if (EnemyExist("RogueWeepingSplugling_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "RogueWeepingSplugling_EN",
                        "MechanicalLens_EN",
                        "MudLung_EN",
                        "Flarblet_EN"
                    }
                });
            }
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Camera_Hard"))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified camera shore");
        }
    }
    
}
