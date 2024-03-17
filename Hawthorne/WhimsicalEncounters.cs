using System;
using System.Collections.Generic;
using System.Text;
using static Hawthorne.Check;

namespace Hawthorne
{
    public static class WhimsicalEncounters
    {
        public static void Add()
        {
            if (EnemyExist("OsseousClad_EN") && BundleRandom("CladMediumFarShour"))
            {
                List<RandomEnemyGroup> list13 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("CladMediumFarShour"))._enemyBundles);
                list13.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "OsseousClad_EN",
                    "A'Flower'_EN",
                    }
                });
                list13.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "OsseousClad_EN",
                    "DeadPixel_EN",
                    "DeadPixel_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("CladMediumFarShour"))._enemyBundles = list13.ToArray();
            }
            if (EnemyExist("OsseousClad_EN") && EnemyExist("Lymphropod_EN") && BundleRandom("CladHardFarShour"))
            {
                List<RandomEnemyGroup> list13 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("CladHardFarShour"))._enemyBundles);
                list13.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "OsseousClad_EN",
                    "A'Flower'_EN",
                    "Lymphropod_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("CladHardFarShour"))._enemyBundles = list13.ToArray();
            }
            if (MultiENExist("RougeWailingSplugling_EN", "RougeBellowingSplugling_EN", "RougeFesteringSplugling_EN", "RougeWeepingSplugling_EN"))
            {
                List<RandomEnemyGroup> list13 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_FlaMingGoa_Hard_EnemyBundle"))._enemyBundles);
                if (SaltEnemies.silly < 50)
                {
                    list13.Add(new RandomEnemyGroup
                    {
                        _enemyNames = new string[]
                    {
                    "FlaMinGoa_EN",
                    "DeadPixel_EN",
                    "DeadPixel_EN",
                    "RougeWailingSplugling_EN",
                    "RougeFesteringSplugling_EN"
                    }
                    });
                    list13.Add(new RandomEnemyGroup
                    {
                        _enemyNames = new string[]
                        {
                    "FlaMinGoa_EN",
                    "A'Flower'_EN",
                    "RougeBellowingSplugling_EN",
                    "RougeWeepingSplugling_EN"
                        }
                    });
                    list13.Add(new RandomEnemyGroup
                    {
                        _enemyNames = new string[]
                        {
                    "FlaMinGoa_EN",
                    "A'Flower'_EN",
                    "Wringle_EN",
                    "RougeWailingSplugling_EN"
                        }
                    });
                    list13.Add(new RandomEnemyGroup
                    {
                        _enemyNames = new string[]
                        {
                    "FlaMinGoa_EN",
                    "A'Flower'_EN",
                    "MudLung_EN",
                    "RougeBellowingSplugling_EN"
                        }
                    });
                }
                else
                {
                    list13.Add(new RandomEnemyGroup
                    {
                        _enemyNames = new string[]
                    {
                    "FlaMinGoa_EN",
                    "DeadPixel_EN",
                    "DeadPixel_EN",
                    "RougeWailingSplugling_EN",
                    "RougeBellowingSplugling_EN"
                    }
                    });
                    list13.Add(new RandomEnemyGroup
                    {
                        _enemyNames = new string[]
                        {
                    "FlaMinGoa_EN",
                    "DeadPixel_EN",
                    "DeadPixel_EN",
                    "RougeFesteringSplugling_EN",
                    "RougeWailingSplugling_EN"
                        }
                    });
                    list13.Add(new RandomEnemyGroup
                    {
                        _enemyNames = new string[]
                        {
                    "FlaMinGoa_EN",
                    "A'Flower'_EN",
                    "MunglingMudLung_EN",
                    "RougeWeepingSplugling_EN"
                        }
                    });
                    list13.Add(new RandomEnemyGroup
                    {
                        _enemyNames = new string[]
                        {
                    "FlaMinGoa_EN",
                    "LostSheep_EN",
                    "MudLung_EN",
                    "RougeBellowingSplugling_EN",
                    "RougeFesteringSplugling_EN"
                        }
                    });
                }
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_FlaMingGoa_Hard_EnemyBundle"))._enemyBundles = list13.ToArray();
            }
            if (MultiENExist("RogueWailingSplugling_EN", "RogueBellowingSplugling_EN", "RogueFesteringSplugling_EN", "RogueWeepingSplugling_EN"))
            {
                List<RandomEnemyGroup> list13 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_FlaMingGoa_Hard_EnemyBundle"))._enemyBundles);
                if (SaltEnemies.silly < 50)
                {
                    list13.Add(new RandomEnemyGroup
                    {
                        _enemyNames = new string[]
                    {
                    "FlaMinGoa_EN",
                    "DeadPixel_EN",
                    "DeadPixel_EN",
                    "RogueWailingSplugling_EN",
                    "RogueFesteringSplugling_EN"
                    }
                    });
                    list13.Add(new RandomEnemyGroup
                    {
                        _enemyNames = new string[]
                        {
                    "FlaMinGoa_EN",
                    "A'Flower'_EN",
                    "RogueBellowingSplugling_EN",
                    "RogueWeepingSplugling_EN"
                        }
                    });
                    list13.Add(new RandomEnemyGroup
                    {
                        _enemyNames = new string[]
                        {
                    "FlaMinGoa_EN",
                    "A'Flower'_EN",
                    "Wringle_EN",
                    "RogueWailingSplugling_EN"
                        }
                    });
                    list13.Add(new RandomEnemyGroup
                    {
                        _enemyNames = new string[]
                        {
                    "FlaMinGoa_EN",
                    "A'Flower'_EN",
                    "MudLung_EN",
                    "RogueBellowingSplugling_EN"
                        }
                    });
                }
                else
                {
                    list13.Add(new RandomEnemyGroup
                    {
                        _enemyNames = new string[]
                    {
                    "FlaMinGoa_EN",
                    "DeadPixel_EN",
                    "DeadPixel_EN",
                    "RogueWailingSplugling_EN",
                    "RogueBellowingSplugling_EN"
                    }
                    });
                    list13.Add(new RandomEnemyGroup
                    {
                        _enemyNames = new string[]
                        {
                    "FlaMinGoa_EN",
                    "DeadPixel_EN",
                    "DeadPixel_EN",
                    "RogueFesteringSplugling_EN",
                    "RogueWailingSplugling_EN"
                        }
                    });
                    list13.Add(new RandomEnemyGroup
                    {
                        _enemyNames = new string[]
                        {
                    "FlaMinGoa_EN",
                    "A'Flower'_EN",
                    "MunglingMudLung_EN",
                    "RogueWeepingSplugling_EN"
                        }
                    });
                    list13.Add(new RandomEnemyGroup
                    {
                        _enemyNames = new string[]
                        {
                    "FlaMinGoa_EN",
                    "LostSheep_EN",
                    "MudLung_EN",
                    "RogueBellowingSplugling_EN",
                    "RogueFesteringSplugling_EN"
                        }
                    });
                }
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_FlaMingGoa_Hard_EnemyBundle"))._enemyBundles = list13.ToArray();
            }
            if (MultiENExist("Lymphropod_EN", "OsseousClad_EN", "RougeBellowingSplugling_EN"))
            {
                List<RandomEnemyGroup> list1 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_MudLung_Medium_EnemyBundle"))._enemyBundles);
                list1.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "MudLung_EN",
                    "OsseousClad_EN",
                    "LostSheep_EN"
                    }
                });
                list1.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "MudLung_EN",
                    "MudLung_EN",
                    "LostSheep_EN",
                    "RougeBellowingSplugling_EN"
                    }
                });
                list1.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "JumbleGuts_Clotted_EN",
                    "MudLung_EN",
                    "LostSheep_EN",
                    "Lymphropod_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_MudLung_Medium_EnemyBundle"))._enemyBundles = list1.ToArray();
            }
            if (MultiENExist("Lymphropod_EN", "OsseousClad_EN", "RogueBellowingSplugling_EN"))
            {
                List<RandomEnemyGroup> list1 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_MudLung_Medium_EnemyBundle"))._enemyBundles);
                list1.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "MudLung_EN",
                    "OsseousClad_EN",
                    "LostSheep_EN"
                    }
                });
                list1.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "MudLung_EN",
                    "MudLung_EN",
                    "LostSheep_EN",
                    "RogueBellowingSplugling_EN"
                    }
                });
                list1.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "JumbleGuts_Clotted_EN",
                    "MudLung_EN",
                    "LostSheep_EN",
                    "Lymphropod_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_MudLung_Medium_EnemyBundle"))._enemyBundles = list1.ToArray();
            }
            if (MultiENExist("Lymphropod_EN", "RougeWeepingSplugling_EN"))
            {
                List<RandomEnemyGroup> list3 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Spoggle_Spitfire_Medium_EnemyBundle"))._enemyBundles);
                list3.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "Lymphropod_EN",
                    "Spoggle_Spitfire_EN",
                    "LostSheep_EN"
                    }
                });
                list3.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "RougeWeepingSplugling_EN",
                    "Spoggle_Spitfire_EN",
                    "LostSheep_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Spoggle_Spitfire_Medium_EnemyBundle"))._enemyBundles = list3.ToArray();
            }
            if (MultiENExist("Lymphropod_EN", "RogueWeepingSplugling_EN"))
            {
                List<RandomEnemyGroup> list3 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Spoggle_Spitfire_Medium_EnemyBundle"))._enemyBundles);
                list3.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "Lymphropod_EN",
                    "Spoggle_Spitfire_EN",
                    "LostSheep_EN"
                    }
                });
                list3.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "RogueWeepingSplugling_EN",
                    "Spoggle_Spitfire_EN",
                    "LostSheep_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Spoggle_Spitfire_Medium_EnemyBundle"))._enemyBundles = list3.ToArray();
            }
            if (MultiENExist("ColossalSheo_EN", "Lymphropod_EN", "OsseousClad_EN"))
            {
                List<RandomEnemyGroup> list5 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Flarb_Hard_EnemyBundle"))._enemyBundles);
                list5.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "Flarb_EN",
                    "ColossalSheo_EN",
                    "LostSheep_EN",
                    "Flarblet_EN"
                    }
                });
                list5.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "Flarb_EN",
                    "Lymphropod_EN",
                    "A'Flower'_EN",
                    "Lymphropod_EN"
                    }
                });
                list5.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "Flarb_EN",
                    "OsseousClad_EN",
                    "A'Flower'_EN",
                    "LostSheep_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Flarb_Hard_EnemyBundle"))._enemyBundles = list5.ToArray();
            }
            if (EnemyExist("Lymphropod_EN") && BundleRandom("BugMeduimFarShore"))
            {
                List<RandomEnemyGroup> list3 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("BugMeduimFarShore"))._enemyBundles);
                list3.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "Lymphropod_EN",
                    "Spoggle_Spitfire_EN",
                    "LostSheep_EN"
                    }
                });
                list3.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "Lymphropod_EN",
                    "Lymphropod_EN",
                    "DeadPixel_EN",
                    "DeadPixel_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("BugMeduimFarShore"))._enemyBundles = list3.ToArray();
            }
            if (EnemyExist("ColossalSheo_EN") && BundleRandom("BigBirdOrpheum"))
            {
                List<RandomEnemyGroup> list3 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("BigBirdOrpheum"))._enemyBundles);
                list3.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "ColossalSheo_EN",
                    "Spoggle_Spitfire_EN",
                    "Enigma_EN"
                    }
                });
                if (EnemyExist("NakedGizo_EN"))
                {
                    list3.Add(new RandomEnemyGroup
                    {
                        _enemyNames = new string[]
                    {
                    "ColossalSheo_EN",
                    "NakedGizo_EN",
                    "Something_EN"
                    }
                    });
                }
                list3.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "ColossalSheo_EN",
                    "MusicMan_EN",
                    "MusicMan_EN",
                    "TheCrow_EN"
                    }
                });
                if (SaltEnemies.trolling == 74)
                {
                    list3.Add(new RandomEnemyGroup
                    {
                        _enemyNames = new string[]
                    {
                    "ColossalSheo_EN",
                    "SilverSuckle_EN",
                    "SilverSuckle_EN",
                    "Freud_EN"
                    }
                    });
                }
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("BigBirdOrpheum"))._enemyBundles = list3.ToArray();
            }
            if (EnemyExist("OsseousClad_EN") && BundleRandom("CladHardOprheum"))
            {
                List<RandomEnemyGroup> list3 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("CladHardOprheum"))._enemyBundles);
                list3.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "OsseousClad_EN",
                    "Spoggle_Writhing_EN",
                    "Enigma_EN"
                    }
                });
                list3.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "OsseousClad_EN",
                    "TheCrow_EN",
                    "Scrungie_EN",
                    "Scrungie_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("CladHardOprheum"))._enemyBundles = list3.ToArray();
            }
            if (MultiENExist("RougeWailingSplugling_EN", "RougeBellowingSplugling_EN", "RougeFesteringSplugling_EN", "RougeWeepingSplugling_EN"))
            {
                List<RandomEnemyGroup> list6 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_MusicMan_Medium_EnemyBundle"))._enemyBundles);
                list6.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "MusicMan_EN",
                    "RougeWailingSplugling_EN",
                    "Enigma_EN",
                    "MusicMan_EN"
                    }
                });
                list6.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "MusicMan_EN",
                    "MusicMan_EN",
                    "LostSheep_EN",
                    "RougeBellowingSplugling_EN"
                    }
                });
                list6.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "MusicMan_EN",
                    "RougeFesteringSplugling_EN",
                    "Enigma_EN",
                    }
                });
                list6.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "RougeWeepingSplugling_EN",
                    "MusicMan_EN",
                    "Enigma_EN",
                    "Scrungie_EN",
                    "SilverSuckle_EN"
                    }
                });
                list6.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "MusicMan_EN",
                    "RougeWailingSplugling_EN",
                    "Enigma_EN",
                    "RougeFesteringSplugling_EN"
                    }
                });
                list6.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "MusicMan_EN",
                    "RougeBellowingSplugling_EN",
                    "LostSheep_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_MusicMan_Medium_EnemyBundle"))._enemyBundles = list6.ToArray();
                List<RandomEnemyGroup> list7 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_MusicMan_Easy_EnemyBundle"))._enemyBundles);
                list7.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "MusicMan_EN",
                    "LostSheep_EN",
                    "RougeBellowingSplugling_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_MusicMan_Easy_EnemyBundle"))._enemyBundles = list7.ToArray();
            }
            if (MultiENExist("RogueWailingSplugling_EN", "RogueBellowingSplugling_EN", "RogueFesteringSplugling_EN", "RogueWeepingSplugling_EN"))
            {
                List<RandomEnemyGroup> list6 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_MusicMan_Medium_EnemyBundle"))._enemyBundles);
                list6.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "MusicMan_EN",
                    "RogueWailingSplugling_EN",
                    "Enigma_EN",
                    "MusicMan_EN"
                    }
                });
                list6.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "MusicMan_EN",
                    "MusicMan_EN",
                    "LostSheep_EN",
                    "RogueBellowingSplugling_EN"
                    }
                });
                list6.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "MusicMan_EN",
                    "RogueFesteringSplugling_EN",
                    "Enigma_EN",
                    }
                });
                list6.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "RogueWeepingSplugling_EN",
                    "MusicMan_EN",
                    "Enigma_EN",
                    "Scrungie_EN",
                    "SilverSuckle_EN"
                    }
                });
                list6.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "MusicMan_EN",
                    "RogueWailingSplugling_EN",
                    "Enigma_EN",
                    "RogueFesteringSplugling_EN"
                    }
                });
                list6.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "MusicMan_EN",
                    "RogueBellowingSplugling_EN",
                    "LostSheep_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_MusicMan_Medium_EnemyBundle"))._enemyBundles = list6.ToArray();
                List<RandomEnemyGroup> list7 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_MusicMan_Easy_EnemyBundle"))._enemyBundles);
                list7.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "MusicMan_EN",
                    "LostSheep_EN",
                    "RogueBellowingSplugling_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_MusicMan_Easy_EnemyBundle"))._enemyBundles = list7.ToArray();
            }
            if (EnemyExist("OsseousClad_EN"))
            {
                List<RandomEnemyGroup> list8 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Scrungie_Medium_EnemyBundle"))._enemyBundles);
                list8.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "Scrungie_EN",
                    "OsseousClad_EN",
                    "Enigma_EN",
                    "Enigma_EN"
                    }
                });
                list8.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "Scrungie_EN",
                    "Scrungie_EN",
                    "TheCrow_EN",
                    "OsseousClad_EN",
                    "LostSheep_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Scrungie_Medium_EnemyBundle"))._enemyBundles = list8.ToArray();
                List<RandomEnemyGroup> list9 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Conductor_Hard_EnemyBundle"))._enemyBundles);
                list9.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "Enigma_EN",
                    "Conductor_EN",
                    "OsseousClad_EN"
                    }
                });
                list9.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "TheCrow_EN",
                    "Conductor_EN",
                    "OsseousClad_EN",
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Conductor_Hard_EnemyBundle"))._enemyBundles = list9.ToArray();
            }
        }
    }
}
