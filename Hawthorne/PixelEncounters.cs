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
    public static class PixelEncounters
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
                    "DeadPixel_EN",
                    "DeadPixel_EN"
                }
            });
            //Debug.Log("first one");
            list.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "FlaMinGoa_EN",
                    "MudLung_EN",
                    "DeadPixel_EN",
                    "DeadPixel_EN"
                }
            });
            list.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "FlaMinGoa_EN",
                    "Wringle_EN",
                    "DeadPixel_EN",
                    "DeadPixel_EN"
                }
            });
            list.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "FlaMinGoa_EN",
                    "Wringle_EN",
                    "DeadPixel_EN",
                    "DeadPixel_EN",
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
                    "DeadPixel_EN",
                    "DeadPixel_EN",
                    "MudLung_EN"
                }
            });
            list1.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "MudLung_EN",
                    "DeadPixel_EN",
                    "DeadPixel_EN",
                    "MudLung_EN",
                    "LostSheep_EN"
                }
            });
            list1.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "Mung_EN",
                    "MudLung_EN",
                    "DeadPixel_EN",
                    "DeadPixel_EN"
                }
            });
            list1.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "Keko_EN",
                    "MudLung_EN",
                    "DeadPixel_EN",
                    "DeadPixel_EN"
                }
            });
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_MudLung_Medium_EnemyBundle"))._enemyBundles = list1.ToArray();
            //Debug.Log("mud lung med");
            List<RandomEnemyGroup> list2 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Voboola_Hard_EnemyBundle"))._enemyBundles);
            list2.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "DeadPixel_EN",
                    "Voboola_EN",
                    "DeadPixel_EN"
                }
            });
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Voboola_Hard_EnemyBundle"))._enemyBundles = list2.ToArray();
            //Debug.Log("voboola");
            List<RandomEnemyGroup> list3 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Spoggle_Spitfire_Medium_EnemyBundle"))._enemyBundles);
            list3.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "Spoggle_Ruminating_EN",
                    "Spoggle_Spitfire_EN",
                    "DeadPixel_EN",
                    "DeadPixel_EN"
                }
            });
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Spoggle_Spitfire_Medium_EnemyBundle"))._enemyBundles = list3.ToArray();
            //Debug.Log("spogg");
            List<RandomEnemyGroup> list5 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Flarb_Hard_EnemyBundle"))._enemyBundles);
            list5.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "Flarb_EN",
                    "DeadPixel_EN",
                    "DeadPixel_EN"
                }
            });
            list5.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "Flarb_EN",
                    "Flarblet_EN",
                    "DeadPixel_EN",
                    "DeadPixel_EN"
                }
            });
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Flarb_Hard_EnemyBundle"))._enemyBundles = list5.ToArray();
            //Debug.Log("flarb");
            List<RandomEnemyGroup> list6 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_JumbleGuts_Clotted_Medium_EnemyBundle"))._enemyBundles);
            list6.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "JumbleGuts_Clotted_EN",
                    "JumbleGuts_Waning_EN",
                    "DeadPixel_EN",
                    "DeadPixel_EN"
                }
            });
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_JumbleGuts_Clotted_Medium_EnemyBundle"))._enemyBundles = list6.ToArray();
            List<RandomEnemyGroup> list7 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_MunglingMudLung_Medium_EnemyBundle"))._enemyBundles);
            list7.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "DeadPixel_EN",
                    "MudLung_EN",
                    "MunglingMudLung_EN",
                    "DeadPixel_EN"
                }
            });
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_MunglingMudLung_Medium_EnemyBundle"))._enemyBundles = list7.ToArray();
            List<RandomEnemyGroup> list8 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Keko_Medium_EnemyBundle"))._enemyBundles);
            list8.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "DeadPixel_EN",
                    "Keko_EN",
                    "Keko_EN",
                    "DeadPixel_EN"
                }
            });
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Keko_Medium_EnemyBundle"))._enemyBundles = list8.ToArray();
            List<RandomEnemyGroup> list9 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Spoggle_Resonant_Medium_EnemyBundle"))._enemyBundles);
            list9.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "Spoggle_Resonant_EN",
                    "DeadPixel_EN"
                }
            });
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Spoggle_Resonant_Medium_EnemyBundle"))._enemyBundles = list9.ToArray();

            if (DoDebugs.GenInfo) Debug.Log("CNS Far Shore Encounters Set!");
        }
    }
    public static class PixelEncountersTairPeep
    {
        public static void Add()
        {
            if (EnemyExist("DrySimian_EN") && EnemyExist("LipBug_EN") && BundleExist("Simianh") && BundleRandom("Simianh"))
            {
                List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Simianh"))._enemyBundles);
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "DrySimian_EN",
                    "DeadPixel_EN",
                    "DeadPixel_EN",
                    "LipBug_EN"
                    }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "DrySimian_EN",
                    "DeadPixel_EN",
                    "DeadPixel_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Simianh"))._enemyBundles = list.ToArray();
            }
            if (EnemyExist("Unflarb_EN") && BundleExist("unflarb1") && BundleRandom("unflarb1"))
            {
                List<RandomEnemyGroup> list1 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("unflarb1"))._enemyBundles);
                list1.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "Unflarb_EN",
                    "DeadPixel_EN",
                    "DeadPixel_EN"
                    }
                });
                list1.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "Unflarb_EN",
                    "DeadPixel_EN",
                    "DeadPixel_EN",
                    "Flarblet_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("unflarb1"))._enemyBundles = list1.ToArray();
            }
            if (MultiENExist("Flarbleft_EN", "LipBug_EN", "Seraphim_EN"))
            {
                List<RandomEnemyGroup> list7 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_MunglingMudLung_Medium_EnemyBundle"))._enemyBundles);
                list7.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "DeadPixel_EN",
                    "Flarbleft_EN",
                    "MunglingMudLung_EN",
                    "DeadPixel_EN"
                    }
                });
                list7.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "DeadPixel_EN",
                    "LipBug_EN",
                    "MunglingMudLung_EN",
                    "DeadPixel_EN"
                    }
                });
                list7.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "DeadPixel_EN",
                    "Seraphim_EN",
                    "MunglingMudLung_EN",
                    "DeadPixel_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_MunglingMudLung_Medium_EnemyBundle"))._enemyBundles = list7.ToArray();

            }

            if (EnemyExist("Nephilim_EN") && BundleRandom("NephHardl"))
            {
                List<RandomEnemyGroup> list1 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("NephHardl"))._enemyBundles);
                list1.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "Nephilim_EN",
                    "DeadPixel_EN",
                    "DeadPixel_EN",
                    "Mung_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("NephHardl"))._enemyBundles = list1.ToArray();
                if (DoDebugs.MiscInfo) Debug.Log("pixeled nephilism");
            }
        }
    }
    public static class PixelEncountersTaco
    {
        public static void Add()
        {
            if (EnemyExist("Monck_EN") && BundleStatic("Monck_Primary_Medium"))
            {
                List<SpecificEnemyGroup> list = new List<SpecificEnemyGroup>(((SpecificEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Monck_Primary_Medium"))._enemyBundles);
                list.Add(new SpecificEnemyGroup
                {
                    _enemyGroup = new SpecificEnemyInfo[]
                    {
                    new SpecificEnemyInfo
                    { enemyName = "Monck_EN",
                    enemySlot = 4 },
                    new SpecificEnemyInfo
                    { enemyName = "DeadPixel_EN",
                    enemySlot = 2 },
                    new SpecificEnemyInfo
                    { enemyName = "DeadPixel_EN",
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
                    { enemyName = "DeadPixel_EN",
                    enemySlot = 2 },
                    new SpecificEnemyInfo
                    { enemyName = "DeadPixel_EN",
                    enemySlot = 1 },
                    new SpecificEnemyInfo
                    { enemyName = "JumbleGuts_Waning_EN",
                    enemySlot = 0 }
                    }
                });
                ((SpecificEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Monck_Primary_Medium"))._enemyBundles = list.ToArray();
            }
            else if (EnemyExist("Monck_EN") && BundleRandom("Monck_Primary_Medium"))
            {
                List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Monck_Primary_Medium"))._enemyBundles);
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Monck_EN",
                        "DeadPixel_EN",
                        "DeadPixel_EN",
                    }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Monck_EN",
                        "DeadPixel_EN",
                        "DeadPixel_EN",
                        "JumbleGuts_Waning_EN"
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
                    { enemyName = "FlaMinGoa_EN",
                    enemySlot = 3 },
                    new SpecificEnemyInfo
                    { enemyName = "DeadPixel_EN",
                    enemySlot = 0 },
                    new SpecificEnemyInfo
                    { enemyName = "DeadPixel_EN",
                    enemySlot = 4 }
                    }
                });
                list4.Add(new SpecificEnemyGroup
                {
                    _enemyGroup = new SpecificEnemyInfo[]
                    {
                    new SpecificEnemyInfo
                    { enemyName = "Disembodied_EN",
                    enemySlot = 1 },
                    new SpecificEnemyInfo
                    { enemyName = "JumbleGuts_Clotted_EN",
                    enemySlot = 0 },
                    new SpecificEnemyInfo
                    { enemyName = "DeadPixel_EN",
                    enemySlot = 3 },
                    new SpecificEnemyInfo
                    { enemyName = "DeadPixel_EN",
                    enemySlot = 2 }
                    }
                });
                ((SpecificEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Disembodied_Primary_Hard"))._enemyBundles = list4.ToArray();
            }
        }
    }
    public static class PixelEncountersBoth
    {
        public static void Add()
        {
            if (MultiENExist("Monck_EN", "DrySimian_EN") && BundleRandom("Simianh"))
            {
                List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Simianh"))._enemyBundles);
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "DrySimian_EN",
                    "Monck_EN",
                    "DeadPixel_EN",
                    "DeadPixel_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Simianh"))._enemyBundles = list.ToArray();
            }
            if (EnemyExist("Disembodied_EN") && EnemyExist("DrySimian_EN") && BundleStatic("Disembodied_Primary_Hard"))
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
                    { enemyName = "DeadPixel_EN",
                    enemySlot = 3 },
                    new SpecificEnemyInfo
                    { enemyName = "DeadPixel_EN",
                    enemySlot = 1 },
                    new SpecificEnemyInfo
                    { enemyName = "DrySimian_EN",
                    enemySlot = 0 }
                    }
                });
                ((SpecificEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Disembodied_Primary_Hard"))._enemyBundles = list4.ToArray();
            }
        }
    }
}

