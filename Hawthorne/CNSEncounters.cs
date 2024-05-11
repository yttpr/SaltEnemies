using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using BepInEx;
using BepInEx.Bootstrap;
using BrutalAPI;
using UnityEngine;
using UnityEngine.UIElements;
using MonoMod.RuntimeDetour;
using JetBrains.Annotations;
using System.Text;
using System.Threading;
using System.Runtime.CompilerServices;
using Tools;
using UnityEngine.SceneManagement;
using System.Timers;
using UnityEngine.Diagnostics;
using UnityEngine.UI;
using System.Xml;
using System.Dynamic;
using static UnityEngine.UI.CanvasScaler;
using static Hawthorne.Check;

namespace Hawthorne
{
    public static class CNSEncounters
    {
        public static void Add()
        {
            //Debug.Log("1");
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_FlaMingGoa_Hard_EnemyBundle"))._enemyBundles);
            //Debug.Log("started");
            list.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "FlaMinGoa_EN",
                    "MunglingMudLung_EN",
                    "LostSheep_EN"
                }
            });
            //Debug.Log("first one");
            list.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "FlaMinGoa_EN",
                    "MudLung_EN",
                    "LostSheep_EN"
                }
            });
            //Debug.Log("second one");
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_FlaMingGoa_Hard_EnemyBundle"))._enemyBundles = list.ToArray();
            //Debug.Log("fla min goa hard");
            List<RandomEnemyGroup> list1 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_MudLung_Medium_EnemyBundle"))._enemyBundles);
            list1.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "MudLung_EN",
                    "Mung_EN",
                    "LostSheep_EN"
                }
            });
            list1.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "JumbleGuts_Waning_EN",
                    "MudLung_EN",
                    "LostSheep_EN"
                }
            });
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_MudLung_Medium_EnemyBundle"))._enemyBundles = list1.ToArray();
            //Debug.Log("mud lung med");
            List<RandomEnemyGroup> list2 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Voboola_Hard_EnemyBundle"))._enemyBundles);
            list2.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "Wringle_EN",
                    "Voboola_EN",
                    "LostSheep_EN"
                }
            });
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Voboola_Hard_EnemyBundle"))._enemyBundles = list2.ToArray();
            //Debug.Log("voboola");
            List<RandomEnemyGroup> list3 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Spoggle_Spitfire_Medium_EnemyBundle"))._enemyBundles);
            list3.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "Mung_EN",
                    "Spoggle_Spitfire_EN",
                    "LostSheep_EN"
                }
            });
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Spoggle_Spitfire_Medium_EnemyBundle"))._enemyBundles = list3.ToArray();
            //Debug.Log("spogg");
            List<RandomEnemyGroup> list4 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Zone01_Mung_Easy_EnemyBundle"))._enemyBundles);
            list4.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "Mung_EN",
                    "LostSheep_EN"
                }
            });
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Zone01_Mung_Easy_EnemyBundle"))._enemyBundles = list4.ToArray();
            //Debug.Log("MUNG");
            List<RandomEnemyGroup> list5 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Flarb_Hard_EnemyBundle"))._enemyBundles);
            list5.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "Flarb_EN",
                    "MunglingMudLung_EN",
                    "LostSheep_EN"
                }
            });
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Flarb_Hard_EnemyBundle"))._enemyBundles = list5.ToArray();
            //Debug.Log("flarb");
            if (DoDebugs.GenInfo) Debug.Log("CNS Far Shore Encounters Set!");
            List<RandomEnemyGroup> list6 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_MusicMan_Medium_EnemyBundle"))._enemyBundles);
            list6.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "MusicMan_EN",
                    "MusicMan_EN",
                    "MusicMan_EN",
                    "LostSheep_EN"
                }
            });
            list6.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "MusicMan_EN",
                    "MusicMan_EN",
                    "LostSheep_EN"
                }
            });
            list6.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "MusicMan_EN",
                    "MusicMan_EN",
                    "LostSheep_EN",
                    "SilverSuckle_EN"
                }
            });
            list6.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "MusicMan_EN",
                    "MusicMan_EN",
                    "LostSheep_EN",
                    "Scrungie_EN"
                }
            });
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_MusicMan_Medium_EnemyBundle"))._enemyBundles = list6.ToArray();
            List<RandomEnemyGroup> list7 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_MusicMan_Easy_EnemyBundle"))._enemyBundles);
            list7.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "MusicMan_EN",
                    "LostSheep_EN"
                }
            });
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_MusicMan_Easy_EnemyBundle"))._enemyBundles = list7.ToArray();
            List<RandomEnemyGroup> list8 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Scrungie_Medium_EnemyBundle"))._enemyBundles);
            list8.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "Scrungie_EN",
                    "Scrungie_EN",
                    "LostSheep_EN"
                }
            });
            list8.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "Scrungie_EN",
                    "JumbleGuts_Flummoxing_EN",
                    "LostSheep_EN"
                }
            });
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Scrungie_Medium_EnemyBundle"))._enemyBundles = list8.ToArray();
            List<RandomEnemyGroup> list9 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Conductor_Hard_EnemyBundle"))._enemyBundles);
            list9.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "LostSheep_EN",
                    "Conductor_EN",
                    "MusicMan_EN"
                }
            });
            list9.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "LostSheep_EN",
                    "Conductor_EN",
                    "SingingStone_EN"
                }
            });
            list9.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "LostSheep_EN",
                    "Conductor_EN",
                    "LostSheep_EN",
                    "LostSheep_EN",
                }
            });
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Conductor_Hard_EnemyBundle"))._enemyBundles = list9.ToArray();
            List<RandomEnemyGroup> list10 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Revola_Hard_EnemyBundle"))._enemyBundles);
            list10.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "Revola_EN",
                    "LostSheep_EN",
                    "SingingStone_EN"
                }
            });
            list10.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "Revola_EN",
                    "LostSheep_EN",
                    "JumbleGuts_Clotted_EN"
                }
            });
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Revola_Hard_EnemyBundle"))._enemyBundles = list10.ToArray();
            List<RandomEnemyGroup> list11 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_WrigglingSacrifice_Hard_EnemyBundle"))._enemyBundles);
            list11.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "WrigglingSacrifice_EN",
                    "LostSheep_EN",
                    "JumbleGuts_Flummoxing_EN"
                }
            });
            list11.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "WrigglingSacrifice_EN",
                    "LostSheep_EN",
                    "MusicMan_EN"
                }
            });
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_WrigglingSacrifice_Hard_EnemyBundle"))._enemyBundles = list11.ToArray();
            List<RandomEnemyGroup> list12 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Spoggle_Writhing_Medium_EnemyBundle"))._enemyBundles);
            list12.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "Spoggle_Writhing_EN",
                    "Spoggle_Spitfire_EN",
                    "LostSheep_EN"
                }
            });
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Spoggle_Writhing_Medium_EnemyBundle"))._enemyBundles = list12.ToArray();
            List<RandomEnemyGroup> list13 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_JumbleGuts_Hollowing_Medium_EnemyBundle"))._enemyBundles);
            list13.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "Spoggle_Ruminating_EN",
                    "JumbleGuts_Hollowing_EN",
                    "LostSheep_EN"
                }
            });
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_JumbleGuts_Hollowing_Medium_EnemyBundle"))._enemyBundles = list13.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Orpheum Encounters Loaded!");
        }
    }
    public static class CNSEncountersTairPeep
    {
        public static bool ran = false;
        public static void Add()
        {
            //if (ran) return; ran = true;
            if (Check.EnemyExist("DrySimian_EN") && Check.BundleExist("Simianh") && Check.BundleRandom("Simianh"))
            {
                List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Simianh"))._enemyBundles);
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "DrySimian_EN",
                    "MudLung_EN",
                    "LostSheep_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Simianh"))._enemyBundles = list.ToArray();
                if (DoDebugs.MiscInfo) Debug.Log("simian");
            }
            if (Check.MultiENExist("Unflarb_EN", "Flarbleft_EN", "LipBug_EN") && Check.BundleExist("unflarb1") && Check.BundleRandom("unflarb1"))
            {
                List<RandomEnemyGroup> list1 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("unflarb1"))._enemyBundles);
                list1.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "Unflarb_EN",
                    "Flarbleft_EN",
                    "LostSheep_EN"
                    }
                });
                list1.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "Unflarb_EN",
                    "LipBug_EN",
                    "LostSheep_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("unflarb1"))._enemyBundles = list1.ToArray();
                if (DoDebugs.MiscInfo) Debug.Log("unflab");
            }
            if (EnemyExist("Gizo_EN") && Check.BundleExist("Sgizo2") && BundleRandom("Sgizo2"))
            {
                List<RandomEnemyGroup> list3 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Sgizo2"))._enemyBundles);
                list3.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "Gizo_EN",
                    "MusicMan_EN",
                    "MusicMan_EN",
                    "LostSheep_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Sgizo2"))._enemyBundles = list3.ToArray();
                if (DoDebugs.MiscInfo) Debug.Log("gizo");
            }
            if (EnemyExist("SingingMountain_EN") && BundleExist("Mountain") && BundleRandom("Mountain"))
            {
                List<RandomEnemyGroup> list33 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Mountain"))._enemyBundles);
                list33.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "SingingMountain_EN",
                    "LostSheep_EN",
                    "Enigma_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Mountain"))._enemyBundles = list33.ToArray();
            }
            if (EnemyExist("PerforatedSpoggle_EN") && BundleExist("GSpoggleN") && BundleRandom("GSpoggleN"))
            {
                List<RandomEnemyGroup> list4 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("GSpoggleN"))._enemyBundles);
                list4.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "PerforatedSpoggle_EN",
                    "SilverSuckle_EN",
                    "Scrungie_EN",
                    "LostSheep_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("GSpoggleN"))._enemyBundles = list4.ToArray();
                if (DoDebugs.MiscInfo) Debug.Log("spog");
            }
            if (EnemyExist("LipBug_EN"))
            {
                List<RandomEnemyGroup> list122 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_MudLung_Medium_EnemyBundle"))._enemyBundles);
                list122.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "MudLung_EN",
                    "LipBug_EN",
                    "LostSheep_EN"
                    }
                });
                list122.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "JumbleGuts_Waning_EN",
                    "MudLung_EN",
                    "LostSheep_EN",
                    "LipBug_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_MudLung_Medium_EnemyBundle"))._enemyBundles = list122.ToArray();
            }
        }
    }
    public static class CNSEncountersTaco
    {
        public static void Add()
        {
            if (EnemyExist("Monck_EN") && BundleStatic("Monck_Primary_Medium"))
            {
                List<SpecificEnemyGroup> list = new List<SpecificEnemyGroup>(((SpecificEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Monck_Primary_Medium"))._enemyBundles);
                if (DoDebugs.MiscInfo) Debug.Log("started");
                list.Add(new SpecificEnemyGroup
                {
                    _enemyGroup = new SpecificEnemyInfo[]
                    {
                    new SpecificEnemyInfo
                    { enemyName = "Monck_EN",
                    enemySlot = 4 },
                    new SpecificEnemyInfo
                    { enemyName = "Monck_EN",
                    enemySlot = 0 },
                    new SpecificEnemyInfo
                    { enemyName = "LostSheep_EN",
                    enemySlot = 1 }
                    }
                });
                list.Add(new SpecificEnemyGroup
                {
                    _enemyGroup = new SpecificEnemyInfo[]
                    {
                    new SpecificEnemyInfo
                    { enemyName = "Monck_EN",
                    enemySlot = 4 },
                    new SpecificEnemyInfo
                    { enemyName = "MudLung_EN",
                    enemySlot = 0 },
                    new SpecificEnemyInfo
                    { enemyName = "LostSheep_EN",
                    enemySlot = 1 }
                    }
                });
                list.Add(new SpecificEnemyGroup
                {
                    _enemyGroup = new SpecificEnemyInfo[]
                    {
                    new SpecificEnemyInfo
                    { enemyName = "Monck_EN",
                    enemySlot = 4 },
                    new SpecificEnemyInfo
                    { enemyName = "MudLung_EN",
                    enemySlot = 0 },
                    new SpecificEnemyInfo
                    { enemyName = "Mung_EN",
                    enemySlot = 3 },
                    new SpecificEnemyInfo
                    { enemyName = "LostSheep_EN",
                    enemySlot = 2 }
                    }
                });
                list.Add(new SpecificEnemyGroup
                {
                    _enemyGroup = new SpecificEnemyInfo[]
                    {
                    new SpecificEnemyInfo
                    { enemyName = "Monck_EN",
                    enemySlot = 4 },
                    new SpecificEnemyInfo
                    { enemyName = "LostSheep_EN",
                    enemySlot = 3 },
                    new SpecificEnemyInfo
                    { enemyName = "Flarblet_EN",
                    enemySlot = 1 }
                    }
                });
                ((SpecificEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Monck_Primary_Medium"))._enemyBundles = list.ToArray();
            }
            else if (EnemyExist("Monck_EN") && BundleRandom("Monck_Primary_Medium"))
            {
                List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Monck_Primary_Medium"))._enemyBundles);
                if (DoDebugs.MiscInfo) Debug.Log("started");
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Monck_EN",
                        "Monck_EN",
                        "LostSheep_EN",
                    }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Monck_EN",
                        "MudLung_EN",
                        "LostSheep_EN",
                    }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Monck_EN",
                        "Monck_EN",
                        "LostSheep_EN",
                        "Mung_EN"
                    }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Monck_EN",
                        "Flarblet_EN",
                        "LostSheep_EN",
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Monck_Primary_Medium"))._enemyBundles = list.ToArray();
            }
            if (EnemyExist("Disembodied_EN") && BundleStatic("Disembodied_Primary_Hard"))
            {
                List<SpecificEnemyGroup> list4 = new List<SpecificEnemyGroup>(((SpecificEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Disembodied_Primary_Hard"))._enemyBundles);
                list4.Add(new SpecificEnemyGroup
                {
                    _enemyGroup = new SpecificEnemyInfo[]
                    {
                    new SpecificEnemyInfo
                    { enemyName = "Disembodied_EN",
                    enemySlot = 2 },
                    new SpecificEnemyInfo
                    { enemyName = "MudLung_EN",
                    enemySlot = 3 },
                    new SpecificEnemyInfo
                    { enemyName = "LostSheep_EN",
                    enemySlot = 1 }
                    }
                });
                list4.Add(new SpecificEnemyGroup
                {
                    _enemyGroup = new SpecificEnemyInfo[]
                    {
                    new SpecificEnemyInfo
                    { enemyName = "Disembodied_EN",
                    enemySlot = 4 },
                    new SpecificEnemyInfo
                    { enemyName = "MunglingMudLung_EN",
                    enemySlot = 3 },
                    new SpecificEnemyInfo
                    { enemyName = "LostSheep_EN",
                    enemySlot = 0 }
                    }
                });
                list4.Add(new SpecificEnemyGroup
                {
                    _enemyGroup = new SpecificEnemyInfo[]
                    {
                    new SpecificEnemyInfo
                    { enemyName = "Monck_EN",
                    enemySlot = 4 },
                    new SpecificEnemyInfo
                    { enemyName = "Disembodied_EN",
                    enemySlot = 2 },
                    new SpecificEnemyInfo
                    { enemyName = "LostSheep_EN",
                    enemySlot = 1 }
                    }
                });
                ((SpecificEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Disembodied_Primary_Hard"))._enemyBundles = list4.ToArray();
            }
            if (EnemyExist("TheFatman_EN") && BundleRandom("TheFatman_Hard_Miniboss"))
            {
                List<RandomEnemyGroup> list1 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("TheFatman_Hard_Miniboss"))._enemyBundles);
                list1.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "TheFatman_EN",
                    "LostSheep_EN",
                    "LostSheep_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("TheFatman_Hard_Miniboss"))._enemyBundles = list1.ToArray();
            }
        }
    }
    public static class CNSEncountersBoth
    {
        public static void Add()
        {
            if (MultiENExist("Unflarb_EN", "Monck_EN") && BundleRandom("unflarb1"))
            {
                List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("unflarb1"))._enemyBundles);
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "Unflarb_EN",
                    "Monck_EN",
                    "LostSheep_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("unflarb1"))._enemyBundles = list.ToArray();
            }
            if (EnemyExist("Disembodied_EN") && BundleStatic("Disembodied_Primary_Hard"))
            {
                List<SpecificEnemyGroup> list4 = new List<SpecificEnemyGroup>(((SpecificEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Disembodied_Primary_Hard"))._enemyBundles);
                list4.Add(new SpecificEnemyGroup
                {
                    _enemyGroup = new SpecificEnemyInfo[]
                    {
                    new SpecificEnemyInfo
                    { enemyName = "Disembodied_EN",
                    enemySlot = 2 },
                    new SpecificEnemyInfo
                    { enemyName = "Unflarb_EN",
                    enemySlot = 3 },
                    new SpecificEnemyInfo
                    { enemyName = "LostSheep_EN",
                    enemySlot = 1 }
                    }
                });
                ((SpecificEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Disembodied_Primary_Hard"))._enemyBundles = list4.ToArray();
            }
        }
    }
}

