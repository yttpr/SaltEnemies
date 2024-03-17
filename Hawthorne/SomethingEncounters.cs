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
    public static class SomethingEncounters
    {
        public static void Add()
        {
            List<RandomEnemyGroup> list6 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_MusicMan_Medium_EnemyBundle"))._enemyBundles);
            list6.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "MusicMan_EN",
                    "Something_EN"
                }
            });
            list6.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "MusicMan_EN",
                    "MusicMan_EN",
                    "Something_EN"
                }
            });
            list6.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "MusicMan_EN",
                    "MusicMan_EN",
                    "Something_EN",
                    "LostSheep_EN"
                }
            });
            list6.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "MusicMan_EN",
                    "SingingStone_EN",
                    "Something_EN",
                }
            });
            list6.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "MusicMan_EN",
                    "Something_EN",
                    "Derogatory_EN",
                    "Derogatory_EN"
                }
            });
            list6.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "MusicMan_EN",
                    "Something_EN",
                    "Enigma_EN",
                    "Enigma_EN"
                }
            });
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_MusicMan_Medium_EnemyBundle"))._enemyBundles = list6.ToArray();
            
            List<RandomEnemyGroup> list8 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Scrungie_Medium_EnemyBundle"))._enemyBundles);
            list8.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "Scrungie_EN",
                    "Something_EN",
                    "JumbleGuts_Waning_EN"
                }
            });
            list8.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "Scrungie_EN",
                    "Something_EN",
                    "SingingStone_EN",
                }
            });
            list8.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "Scrungie_EN",
                    "Something_EN",
                    "Scrungie_EN",
                    "Enigma_EN"
                }
            });
            list8.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "Scrungie_EN",
                    "Something_EN",
                    "Scrungie_EN",
                    "LostSheep_EN"
                }
            });
            list8.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "Scrungie_EN",
                    "Something_EN",
                    "JumbleGuts_Hollowing_EN",
                }
            });
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Scrungie_Medium_EnemyBundle"))._enemyBundles = list8.ToArray();
            List<RandomEnemyGroup> list9 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Conductor_Hard_EnemyBundle"))._enemyBundles);
            list9.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "Something_EN",
                    "Conductor_EN"
                }
            });
            list9.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "Something_EN",
                    "Conductor_EN",
                    "Scrungie_EN"
                }
            });
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Conductor_Hard_EnemyBundle"))._enemyBundles = list9.ToArray();
            List<RandomEnemyGroup> list10 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Revola_Hard_EnemyBundle"))._enemyBundles);
            list10.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "Revola_EN",
                    "Something_EN"
                }
            });
            list10.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "Revola_EN",
                    "Something_EN",
                    "JumbleGuts_Clotted_EN"
                }
            });
            list10.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "Revola_EN",
                    "Something_EN",
                    "SingingStone_EN"
                }
            });
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Revola_Hard_EnemyBundle"))._enemyBundles = list10.ToArray();
            List<RandomEnemyGroup> list11 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_WrigglingSacrifice_Hard_EnemyBundle"))._enemyBundles);
            list11.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "WrigglingSacrifice_EN",
                    "Something_EN",
                    "MusicMan_EN"
                }
            });
            list11.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "WrigglingSacrifice_EN",
                    "Something_EN",
                    "Spoggle_Spitfire_EN"
                }
            });
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_WrigglingSacrifice_Hard_EnemyBundle"))._enemyBundles = list11.ToArray();
            List<RandomEnemyGroup> list12 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Spoggle_Writhing_Medium_EnemyBundle"))._enemyBundles);
            list12.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "Spoggle_Writhing_EN",
                    "Spoggle_Ruminating_EN",
                    "Something_EN"
                }
            });
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Spoggle_Writhing_Medium_EnemyBundle"))._enemyBundles = list12.ToArray();
            List<RandomEnemyGroup> list13 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_JumbleGuts_Hollowing_Medium_EnemyBundle"))._enemyBundles);
            list13.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "Something_EN",
                    "JumbleGuts_Hollowing_EN",
                    "JumbleGuts_Clotted_EN"
                }
            });
            list13.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "Something_EN",
                    "JumbleGuts_Hollowing_EN",
                    "MusicMan_EN"
                }
            });
            list13.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "Something_EN",
                    "JumbleGuts_Hollowing_EN",
                    "Scrungie_EN"
                }
            });
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_JumbleGuts_Hollowing_Medium_EnemyBundle"))._enemyBundles = list13.ToArray();
            List<RandomEnemyGroup> list15 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Spoggle_Resonant_Medium_EnemyBundle"))._enemyBundles);
            list15.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "Something_EN",
                    "Spoggle_Resonant_EN",
                    "Spoggle_Spitfire_EN"
                }
            });
            list15.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "Something_EN",
                    "Spoggle_Resonant_EN",
                    "Scrungie_EN"
                }
            });
            list15.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "Something_EN",
                    "Spoggle_Resonant_EN",
                    "LostSheep_EN"
                }
            });
            if (SaltEnemies.trolling == 72)
            {
                list15.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                {
                    "Something_EN",
                    "Spoggle_Resonant_EN",
                    "Something_EN"
                }
                });
            }
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Spoggle_Resonant_Medium_EnemyBundle"))._enemyBundles = list15.ToArray();

            if (DoDebugs.GenInfo) Debug.Log("Orpheum Encounters Loaded!");
        }
    }
    public static class SomethingEncountersTairPeep
    {
        public static void Add()
        {
            if (EnemyExist("NakedGizo_EN"))
            {
                List<RandomEnemyGroup> list2 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_MusicMan_Medium_EnemyBundle"))._enemyBundles);
                list2.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "NakedGizo_EN",
                    "MusicMan_EN",
                    "Something_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_MusicMan_Medium_EnemyBundle"))._enemyBundles = list2.ToArray();
            }
            if (EnemyExist("Gizo_EN") && EnemyExist("NakedGizo_EN") && BundleRandom("Sgizo2"))
            {
                List<RandomEnemyGroup> list3 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Sgizo2"))._enemyBundles);
                list3.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "Gizo_EN",
                    "Something_EN",
                    "MusicMan_EN"
                    }
                });
                list3.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "Gizo_EN",
                    "Something_EN",
                    "Spoggle_Ruminating_EN"
                    }
                });
                list3.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "Gizo_EN",
                    "Something_EN",
                    "Enigma_EN",
                    "NakedGizo_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Sgizo2"))._enemyBundles = list3.ToArray();
            }
            if (EnemyExist("PerforatedSpoggle_EN") && BundleRandom("GSpoggleN"))
            {
                List<RandomEnemyGroup> list4 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("GSpoggleN"))._enemyBundles);
                list4.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "PerforatedSpoggle_EN",
                    "Spoggle_Writhing_EN",
                    "Something_EN"
                    }
                });
                list4.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "PerforatedSpoggle_EN",
                    "Scrungie_EN",
                    "Something_EN"
                    }
                });
                list4.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "PerforatedSpoggle_EN",
                    "LostSheep_EN",
                    "Something_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("GSpoggleN"))._enemyBundles = list4.ToArray();
            }
            if (EnemyExist("DesiccatingJumbleguts_EN") && BundleRandom("GjumbleN"))
            {
                List<RandomEnemyGroup> list0 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("GjumbleN"))._enemyBundles);
                list0.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "DesiccatingJumbleguts_EN",
                    "JumbleGuts_Hollowing_EN",
                    "Something_EN"
                    }
                });
                list0.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "DesiccatingJumbleguts_EN",
                    "MusicMan_EN",
                    "Something_EN"
                    }
                });
                list0.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "DesiccatingJumbleguts_EN",
                    "Conductor_EN",
                    "Something_EN"
                    }
                });
                list0.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "DesiccatingJumbleguts_EN",
                    "Enigma_EN",
                    "SingingStone_EN",
                    "Something_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("GjumbleN"))._enemyBundles = list0.ToArray();
                if (DoDebugs.MiscInfo) Debug.Log("GjumbleN random");
            }
            if (EnemyExist("Chapman_EN") && BundleRandom("ChapManMed"))
            {
                List<RandomEnemyGroup> list4 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("ChapManMed"))._enemyBundles);
                list4.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "Chapman_EN",
                    "Chapman_EN",
                    "Something_EN"
                    }
                });
                list4.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "Chapman_EN",
                    "Scrungie_EN",
                    "Something_EN",
                    "Chapman_EN"
                    }
                });
                list4.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "Chapman_EN",
                    "LostSheep_EN",
                    "Something_EN",
                    "Chapman_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("ChapManMed"))._enemyBundles = list4.ToArray();
            }
        }
    }
    public static class SomethingEncountersTaco
    {
        public static void Add()
        {
            if (EnemyExist("TheFatman_EN") && BundleRandom("TheFatman_Hard_Miniboss"))
            {
                List<RandomEnemyGroup> list1 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("TheFatman_Hard_Miniboss"))._enemyBundles);
                list1.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "TheFatman_EN",
                    "Something_EN",
                    "Derogatory_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("TheFatman_Hard_Miniboss"))._enemyBundles = list1.ToArray();
                if (DoDebugs.MiscInfo) Debug.Log("fat");
            }
        }
    }
    public static class SomethingEncountersBoth
    {
        public static void Add()
        {
            if (SaltEnemies.trolling > 33 && MultiENExist("TheFatman_EN", "NakedGizo_EN") && BundleRandom("TheFatman_Hard_Miniboss"))
            {
                List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("TheFatman_Hard_Miniboss"))._enemyBundles);
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "TheFatman_EN",
                    "NakedGizo_EN",
                    "Derogatory_EN",
                    "Derogatory_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("TheFatman_Hard_Miniboss"))._enemyBundles = list.ToArray();
            }
        }
    }
}

