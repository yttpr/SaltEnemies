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
    public static class CrowEncounters
    {
        public static void Add()
        {
            List<RandomEnemyGroup> list6 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_MusicMan_Medium_EnemyBundle"))._enemyBundles);
            if (SaltEnemies.trolling >= 67)
            {
                list6.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                {
                    "MusicMan_EN",
                    "MusicMan_EN",
                    "TheCrow_EN",
                    "TheCrow_EN"
                }
                });
            }
            list6.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "MusicMan_EN",
                    "MusicMan_EN",
                    "TheCrow_EN",
                    "MusicMan_EN"
                }
            });
            if (SaltEnemies.trolling > 50)
            {
                list6.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                {
                    "MusicMan_EN",
                    "MusicMan_EN",
                    "TheCrow_EN",
                    "Spoggle_Resonant_EN"
                }
                });
            }
            if (SaltEnemies.trolling < 50)
            {
                list6.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                {
                    "MusicMan_EN",
                    "MusicMan_EN",
                    "TheCrow_EN",
                    "JumbleGuts_Hollowing_EN"
                }
                });
            }
            list6.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "MusicMan_EN",
                    "MusicMan_EN",
                    "TheCrow_EN",
                    "SingingStone_EN"
                }
            });
            list6.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "MusicMan_EN",
                    "Enigma_EN",
                    "TheCrow_EN",
                    "Enigma_EN"
                }
            });
            list6.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "MusicMan_EN",
                    "Something_EN",
                    "TheCrow_EN"
                }
            });
            if (SaltEnemies.trolling == 24)
            {
                list6.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                {
                    "MusicMan_EN",
                    "TheCrow_EN",
                    "TheCrow_EN",
                    "TheCrow_EN"
                }
                });
            }
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_MusicMan_Medium_EnemyBundle"))._enemyBundles = list6.ToArray();
            List<RandomEnemyGroup> list7 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_MusicMan_Easy_EnemyBundle"))._enemyBundles);
            list7.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "MusicMan_EN",
                    "MusicMan_EN",
                    "TheCrow_EN"
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
                    "TheCrow_EN"
                }
            });
            if (SaltEnemies.trolling > 36 && SaltEnemies.trolling < 65)
            {
                list8.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                {
                    "Scrungie_EN",
                    "Scrungie_EN",
                    "TheCrow_EN",
                    "LostSheep_EN"
                }
                });
            }
            list8.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "Scrungie_EN",
                    "TheCrow_EN",
                    "MusicMan_EN",
                }
            });
            list8.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "Scrungie_EN",
                    "TheCrow_EN",
                    "JumbleGuts_Waning_EN",
                }
            });
            if (SaltEnemies.trolling < 27)
            {
                list8.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                {
                    "Scrungie_EN",
                    "TheCrow_EN",
                    "JumbleGuts_Hollowing_EN",
                }
                });
            }
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Scrungie_Medium_EnemyBundle"))._enemyBundles = list8.ToArray();
            List<RandomEnemyGroup> list9 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Conductor_Hard_EnemyBundle"))._enemyBundles);
            list9.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "TheCrow_EN",
                    "Conductor_EN",
                    "Scrungie_EN"
                }
            });
            if (SaltEnemies.trolling < 23 || SaltEnemies.trolling > 87)
            {
                list9.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                {
                    "TheCrow_EN",
                    "Conductor_EN",
                    "Spoggle_Resonant_EN"
                }
                });
            }
            if (SaltEnemies.trolling > 40)
            {
                list9.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                {
                    "TheCrow_EN",
                    "Conductor_EN",
                    "SilverSuckle_EN",
                    "SilverSuckle_EN"
                }
                });
            }
            list9.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "TheCrow_EN",
                    "Conductor_EN",
                    "MusicMan_EN"
                }
            });
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Conductor_Hard_EnemyBundle"))._enemyBundles = list9.ToArray();
            List<RandomEnemyGroup> list10 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Revola_Hard_EnemyBundle"))._enemyBundles);
            list10.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "Revola_EN",
                    "TheCrow_EN"
                }
            });
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Revola_Hard_EnemyBundle"))._enemyBundles = list10.ToArray();
            List<RandomEnemyGroup> list11 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_WrigglingSacrifice_Hard_EnemyBundle"))._enemyBundles);
            list11.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "WrigglingSacrifice_EN",
                    "TheCrow_EN",
                    "MusicMan_EN"
                }
            });
            if (SaltEnemies.trolling == 88)
            {
                list11.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                {
                    "WrigglingSacrifice_EN",
                    "TheCrow_EN",
                    "Spoggle_Writhing_EN"
                }
                });
            }
            list11.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "WrigglingSacrifice_EN",
                    "TheCrow_EN",
                    "SilverSuckle_EN"
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
                    "TheCrow_EN",
                    "SilverSuckle_EN"
                }
            });
            list12.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "Spoggle_Writhing_EN",
                    "Scrungie_EN",
                    "TheCrow_EN"
                }
            });
            if (SaltEnemies.trolling < 76)
            {
                list12.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                {
                    "Spoggle_Writhing_EN",
                    "Spoggle_Resonant_EN",
                    "TheCrow_EN"
                }
                });
            }
            if (SaltEnemies.trolling == 69)
            {
                list12.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                {
                    "Spoggle_Writhing_EN",
                    "Spoggle_Resonant_EN",
                    "Spoggle_Spitfire_EN",
                    "Spoggle_Ruminating_EN",
                    "TheCrow_EN"
                }
                });
            }
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Spoggle_Writhing_Medium_EnemyBundle"))._enemyBundles = list12.ToArray();
            List<RandomEnemyGroup> list88 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Zone02_Spoggle_Resonant_Medium_EnemyBundle"))._enemyBundles);
            if (SaltEnemies.trolling > 30 && SaltEnemies.trolling < 45)
            {
                list88.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                {
                    "Spoggle_Resonant_EN",
                    "Enigma_EN",
                    "TheCrow_EN",
                }
                });
            }
            list88.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "Spoggle_Resonant_EN",
                    "MusicMan_EN",
                    "TheCrow_EN"
                }
            });
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Zone02_Spoggle_Resonant_Medium_EnemyBundle"))._enemyBundles = list88.ToArray();
            List<RandomEnemyGroup> list14 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_JumbleGuts_Flummoxing_Medium_EnemyBundle"))._enemyBundles);
            if (SaltEnemies.trolling < 25)
            {
                list14.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                {
                    "TheCrow_EN",
                    "JumbleGuts_Flummoxing_EN",
                    "Enigma_EN"
                }
                });
            }
            list14.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "TheCrow_EN",
                    "JumbleGuts_Flummoxing_EN",
                    "JumbleGuts_Clotted_EN"
                }
            });
            if (SaltEnemies.trolling > 75)
            {
                list14.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                {
                    "TheCrow_EN",
                    "JumbleGuts_Flummoxing_EN",
                    "SingingStone_EN"
                }
                });
            }
            list14.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "TheCrow_EN",
                    "JumbleGuts_Flummoxing_EN",
                    "MusicMan_EN"
                }
            });
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_JumbleGuts_Flummoxing_Medium_EnemyBundle"))._enemyBundles = list14.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Orpheum Encounters Loaded!");
        }
    }
    public static class CrowEncountersTairPeep
    {
        public static void Add()
        {
            if (EnemyExist("SingingMountain_EN") && BundleRandom("Mountain"))
            {
                List<RandomEnemyGroup> list0 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Mountain"))._enemyBundles);
                list0.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "TheCrow_EN",
                    "SingingMountain_EN",
                    "MusicMan_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Mountain"))._enemyBundles = list0.ToArray();
            }
            if (EnemyExist("FamiliarSpoggle_EN") && BundleRandom("NSpoggleN"))
            {
                List<RandomEnemyGroup> list900 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("NSpoggleN"))._enemyBundles);
                list900.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "TheCrow_EN",
                    "FamiliarSpoggle_EN",
                    "MusicMan_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("NSpoggleN"))._enemyBundles = list900.ToArray();
            }
            if (EnemyExist("NakedGizo_EN"))
            {
                List<RandomEnemyGroup> list2 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_MusicMan_Medium_EnemyBundle"))._enemyBundles);
                list2.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "TheCrow_EN",
                    "NakedGizo_EN",
                    "MusicMan_EN",
                    "MusicMan_EN"
                    }
                });
                list2.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "TheCrow_EN",
                    "NakedGizo_EN",
                    "MusicMan_EN",
                    "SingingStone_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_MusicMan_Medium_EnemyBundle"))._enemyBundles = list2.ToArray();
            }
            if (EnemyExist("PerforatedSpoggle_EN") && BundleRandom("GSpoggleN"))
            { List<RandomEnemyGroup> list4 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("GSpoggleN"))._enemyBundles);
                list4.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "PerforatedSpoggle_EN",
                    "Spoggle_Ruminating_EN",
                    "TheCrow_EN",
                    "MusicMan_EN"
                    }
                });
                list4.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "PerforatedSpoggle_EN",
                    "Spoggle_Writhing_EN",
                    "TheCrow_EN"
                    }
                });
                if (SaltEnemies.trolling >= 10)
                {
                    list4.Add(new RandomEnemyGroup
                    {
                        _enemyNames = new string[]
                        {
                        "PerforatedSpoggle_EN",
                        "MusicMan_EN",
                        "TheCrow_EN",
                        "Spoggle_Resonant_EN"
                        }
                    });
                }
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("GSpoggleN"))._enemyBundles = list4.ToArray();
            }
            if (EnemyExist("DesiccatingJumbleguts_EN") && BundleRandom("GjumbleN"))
            {
                List<RandomEnemyGroup> list5 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("GjumbleN"))._enemyBundles);
                list5.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "DesiccatingJumbleguts_EN",
                    "TheCrow_EN",
                    "MusicMan_EN"
                    }
                });
                list5.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "DesiccatingJumbleguts_EN",
                    "TheCrow_EN",
                    "Something_EN"
                    }
                });
                if (SaltEnemies.trolling < 87 && SaltEnemies.trolling > 44)
                {
                    list5.Add(new RandomEnemyGroup
                    {
                        _enemyNames = new string[]
                    {
                    "TheCrow_EN",
                    "DesiccatingJumbleguts_EN",
                    "TheCrow_EN",
                    "WrigglingSacrifice_EN"
                    }
                    });
                }
                if (SaltEnemies.trolling > 34 && EnemyExist("Gizo_EN"))
                {
                    list5.Add(new RandomEnemyGroup
                    {
                        _enemyNames = new string[]
                    {
                    "TheCrow_EN",
                    "DesiccatingJumbleguts_EN",
                    "JumbleGuts_Flummoxing_EN",
                    "Derogatory_EN",
                    "Gizo_EN"
                    }
                    });
                }
                if (SaltEnemies.trolling == 75)
                {
                    list5.Add(new RandomEnemyGroup
                    {
                        _enemyNames = new string[]
                    {
                    "TheCrow_EN",
                    "DesiccatingJumbleguts_EN",
                    "JumbleGuts_Flummoxing_EN",
                    "JumbleGuts_Waning_EN",
                    "JumbleGuts_Clotted_EN"
                    }
                    });
                }
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("GjumbleN"))._enemyBundles = list5.ToArray();
            }
            if (EnemyExist("Gizo_EN") && BundleRandom("Sgizo2"))
            {
                List<RandomEnemyGroup> list6 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Sgizo2"))._enemyBundles);
                list6.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "Scrungie_EN",
                    "Gizo_EN",
                    "TheCrow_EN",
                    "SilverSuckle_EN"
                    }
                });
                list6.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "Gizo_EN",
                    "Spoggle_Writhing_EN",
                    "TheCrow_EN"
                    }
                });
                list6.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "Gizo_EN",
                    "MusicMan_EN",
                    "TheCrow_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Sgizo2"))._enemyBundles = list6.ToArray();
            }
            if (EnemyExist("Chapbull_EN") && BundleRandom("ChapBullHard"))
            {
                List<RandomEnemyGroup> list6 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("ChapBullHard"))._enemyBundles);
                list6.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "TheCrow_EN",
                    "Chapbull_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("ChapBullHard"))._enemyBundles = list6.ToArray();
            }
            if (EnemyExist("Ophanim_EN") && BundleRandom("OphanimHard"))
            {
                List<RandomEnemyGroup> list6 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("OphanimHard"))._enemyBundles);
                list6.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "TheCrow_EN",
                    "Ophanim_EN",
                    "Scrungie_EN",
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("OphanimHard"))._enemyBundles = list6.ToArray();
            }
        }
    }
    public static class CrowEncountersTaco
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
                    "TheCrow_EN"
                    }
                });
                if (SaltEnemies.trolling == 66)
                {
                    list1.Add(new RandomEnemyGroup
                    {
                        _enemyNames = new string[]
                    {
                    "TheFatman_EN",
                    "TheCrow_EN",
                    "TheCrow_EN"
                    }
                    });
                }
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("TheFatman_Hard_Miniboss"))._enemyBundles = list1.ToArray();
            }
        }
    }
    public static class CrowEncountersBoth
    {
        public static void Add()
        {
            if (MultiENExist("TheFatman_EN", "DesiccatingJumbleguts_EN") && BundleRandom("TheFatman_Hard_Miniboss"))
            {
                List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("TheFatman_Hard_Miniboss"))._enemyBundles);
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "TheFatman_EN",
                    "TheCrow_EN",
                    "DesiccatingJumbleguts_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("TheFatman_Hard_Miniboss"))._enemyBundles = list.ToArray();
            }
        }
    }
}

