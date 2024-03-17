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
    public static class AngelEncounters
    {
        public static void Add()
        {
            List<RandomEnemyGroup> list15 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_SkinningHomunculus_Hard_EnemyBundle"))._enemyBundles);
            list15.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "SkinningHomunculus_EN",
                    "SkinningHomunculus_EN",
                    "LittleAngel_EN"
                }
            });
            list15.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "ChoirBoy_EN",
                    "SkinningHomunculus_EN",
                    "LittleAngel_EN"
                }
            });
            list15.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "ShiveringHomunculus_EN",
                    "SkinningHomunculus_EN",
                    "SkinningHomunculus_EN",
                    "LittleAngel_EN"
                }
            });
            list15.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "ShiveringHomunculus_EN",
                    "SkinningHomunculus_EN",
                    "LittleAngel_EN",
                    "LittleAngel_EN"
                }
            });
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_SkinningHomunculus_Hard_EnemyBundle"))._enemyBundles = list15.ToArray();
            List<RandomEnemyGroup> list16 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_SkinningHomunculus_Medium_EnemyBundle"))._enemyBundles);
            list16.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "ShiveringHomunculus_EN",
                    "SkinningHomunculus_EN",
                    "LittleAngel_EN"
                }
            });
            list16.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "SkinningHomunculus_EN",
                    "LittleAngel_EN"
                }
            });
            list16.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "ShiveringHomunculus_EN",
                    "ShiveringHomunculus_EN",
                    "SkinningHomunculus_EN",
                    "LittleAngel_EN"
                }
            });
            if (SaltEnemies.trolling == 42)
            {
                list16.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                {
                    "DeadPixel_EN",
                    "DeadPixel_EN",
                    "SkinningHomunculus_EN",
                    "LittleAngel_EN"
                }
                });
            }
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_SkinningHomunculus_Medium_EnemyBundle"))._enemyBundles = list16.ToArray();
            List<RandomEnemyGroup> list4 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_InHisImage_Medium_EnemyBundle"))._enemyBundles);
            list4.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "InHisImage_EN",
                    "InHisImage_EN",
                    "InHerImage_EN",
                    "LittleAngel_EN"
                }
            });
            list4.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "InHisImage_EN",
                    "ChoirBoy_EN",
                    "LittleAngel_EN",
                    "LittleAngel_EN"
                }
            });
            list4.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "InHisImage_EN",
                    "InHisImage_EN",
                    "LittleAngel_EN",
                    "LittleAngel_EN"
                }
            });
            list4.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "InHisImage_EN",
                    "NextOfKin_EN",
                    "InHerImage_EN",
                    "LittleAngel_EN"
                }
            });
            if (SaltEnemies.trolling == 45)
            {
                list4.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                {
                    "InHisImage_EN",
                    "DeadPixel_EN",
                    "DeadPixel_EN",
                    "InHerImage_EN",
                    "LittleAngel_EN"
                }
                });
            }
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_InHisImage_Medium_EnemyBundle"))._enemyBundles = list4.ToArray();
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_InHerImage_Medium_EnemyBundle"))._enemyBundles);
            list.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "InHisImage_EN",
                    "InHerImage_EN",
                    "InHerImage_EN",
                    "LittleAngel_EN"
                }
            });
            list.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "InHerImage_EN",
                    "InHerImage_EN",
                    "InHerImage_EN",
                    "LittleAngel_EN"
                }
            });
            list.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "NextOfKin_EN",
                    "NextOfKin_EN",
                    "InHerImage_EN",
                    "InHerImage_EN",
                    "LittleAngel_EN"
                }
            });
            list.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "ChoirBoy_EN",
                    "InHerImage_EN",
                    "LittleAngel_EN"
                }
            });
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_InHerImage_Medium_EnemyBundle"))._enemyBundles = list.ToArray();
            List<RandomEnemyGroup> list1 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_ChoirBoy_Easy_EnemyBundle"))._enemyBundles);
            list1.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "ChoirBoy_EN",
                    "ChoirBoy_EN",
                    "LittleAngel_EN"
                }
            });
            if (SaltEnemies.trolling == 44)
            {
                list1.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                {
                    "ChoirBoy_EN",
                    "DeadPixel_EN",
                    "DeadPixel_EN",
                    "LittleAngel_EN"
                }
                });
            }
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_ChoirBoy_Easy_EnemyBundle"))._enemyBundles = list1.ToArray();
            List<RandomEnemyGroup> list5 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_GigglingMinister_Hard_EnemyBundle"))._enemyBundles);
            list5.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "SkinningHomunculus_EN",
                    "GigglingMinister_EN",
                    "GigglingMinister_EN",
                    "LittleAngel_EN"
                }
            });
            list5.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "SkinningHomunculus_EN",
                    "GigglingMinister_EN",
                    "LittleAngel_EN",
                    "LittleAngel_EN"
                }
            });
            list5.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "InHerImage_EN",
                    "InHerImage_EN",
                    "GigglingMinister_EN",
                    "LittleAngel_EN"
                }
            });
            list5.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "ChoirBoy_EN",
                    "ChoirBoy_EN",
                    "GigglingMinister_EN",
                    "LittleAngel_EN"
                }
            });
            if (SaltEnemies.trolling == 43)
            {
                list5.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                {
                    "DeadPixel_EN",
                    "DeadPixel_EN",
                    "GigglingMinister_EN",
                    "LittleAngel_EN",
                    "Enigma_EN"
                }
                });
            }
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_GigglingMinister_Hard_EnemyBundle"))._enemyBundles = list5.ToArray();
            if (SaltEnemies.trolling == 41)
            {
                List<RandomEnemyGroup> list6 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_Sepulchre_Hard_EnemyBundle"))._enemyBundles);
                list6.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "Sepulchre_EN",
                    "DeadPixel_EN",
                    "DeadPixel_EN",
                    "DeadPixel_EN",
                    "LittleAngel_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_Sepulchre_Hard_EnemyBundle"))._enemyBundles = list6.ToArray();
            }
            if (DoDebugs.GenInfo) Debug.Log("Garden Encounters Loaded!");
        }
    }
    public static class AngelEncountersTairPeep
    {
        public static void Add()
        {
            if (EnemyExist("Psychopomp_EN") && EnemyExist("TitteringPeon_EN") && EnemyExist("ScreamingHomunculus_EN") && EnemyExist("Unterling_EN"))
            {
                List<RandomEnemyGroup> list4 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_SkinningHomunculus_Hard_EnemyBundle"))._enemyBundles);
                list4.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "SkinningHomunculus_EN",
                    "LittleAngel_EN",
                    "Psychopomp_EN"
                    }
                });
                list4.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "SkinningHomunculus_EN",
                    "SkinningHomunculus_EN",
                    "LittleAngel_EN",
                    "TitteringPeon_EN"
                    }
                });
                list4.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "ScreamingHomunculus_EN",
                    "SkinningHomunculus_EN",
                    "LittleAngel_EN",
                    "TitteringPeon_EN"
                    }
                });
                list4.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "ScreamingHomunculus_EN",
                    "SkinningHomunculus_EN",
                    "LittleAngel_EN",
                    "ShiveringHomunculus_EN"
                    }
                });
                list4.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "ScreamingHomunculus_EN",
                    "SkinningHomunculus_EN",
                    "LittleAngel_EN",
                    "Unterling_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_SkinningHomunculus_Hard_EnemyBundle"))._enemyBundles = list4.ToArray();
            }
            if (EnemyExist("Psychopomp_EN") && BundleExist("PompH") && BundleRandom("PompH"))
            {
                List<RandomEnemyGroup> list5 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("PompH"))._enemyBundles);
                list5.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "InHisImage_EN",
                    "InHisImage_EN",
                    "LittleAngel_EN",
                    "Psychopomp_EN"
                    }
                });
                list5.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "LittleAngel_EN",
                    "LittleAngel_EN",
                    "LittleAngel_EN",
                    "Psychopomp_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("PompH"))._enemyBundles = list5.ToArray();
            }
            if (MultiENExist("ImpenetrableAngler_EN", "Unterling_EN") && BundleExist("AnglerH") && BundleRandom("AnglerH"))
            {
                List<RandomEnemyGroup> list88 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("AnglerH"))._enemyBundles);
                list88.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "SkinningHomunculus_EN",
                    "LittleAngel_EN",
                    "ImpenetrableAngler_EN"
                    }
                });
                list88.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "NextOfKin_EN",
                    "LittleAngel_EN",
                    "ImpenetrableAngler_EN"
                    }
                });
                list88.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "Unterling_EN",
                    "LittleAngel_EN",
                    "ImpenetrableAngler_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("AnglerH"))._enemyBundles = list88.ToArray();
            }
            if (EnemyExist("SterileBud_EN") && BundleRandom("SterileBudHard"))
            {
                List<RandomEnemyGroup> list89 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("SterileBudHard"))._enemyBundles);
                list89.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "SkinningHomunculus_EN",
                    "LittleAngel_EN",
                    "SterileBud_EN"
                    }
                });
                list89.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "NextOfKin_EN",
                    "LittleAngel_EN",
                    "SterileBud_EN"
                    }
                });
                list89.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "ChoirBoy_EN",
                    "LittleAngel_EN",
                    "SterileBud_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("SterileBudHard"))._enemyBundles = list89.ToArray();
            }
            if (EnemyExist("TitteringPeon_EN") && BundleRandom("Peonm"))
            {
                List<RandomEnemyGroup> list6 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Peonm"))._enemyBundles);
                list6.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "InHisImage_EN",
                    "InHerImage_EN",
                    "LittleAngel_EN",
                    "TitteringPeon_EN"
                    }
                });
                list6.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "GigglingMinister_EN",
                    "TitteringPeon_EN",
                    "LittleAngel_EN",
                    "TitteringPeon_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Peonm"))._enemyBundles = list6.ToArray();
            }
            if (MultiENExist("TitteringPeon_EN", "ScreamingHomunculus_EN", "Unterling_EN"))
            {
                List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_InHerImage_Medium_EnemyBundle"))._enemyBundles);
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "InHerImage_EN",
                    "TitteringPeon_EN",
                    "TitteringPeon_EN",
                    "LittleAngel_EN",
                    "ScreamingHomunculus_EN"
                    }
                });
                if (SaltEnemies.trolling == 51)
                {
                    list.Add(new RandomEnemyGroup
                    {
                        _enemyNames = new string[]
                    {
                    "InHerImage_EN",
                    "DeadPixel_EN",
                    "DeadPixel_EN",
                    "TitteringPeon_EN",
                    "ScreamingHomunculus_EN"
                    }
                    });
                }
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "InHerImage_EN",
                    "Unterling_EN",
                    "LittleAngel_EN",
                    "InHisImage_EN",
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_InHerImage_Medium_EnemyBundle"))._enemyBundles = list.ToArray();

            }
        }
    }
    public static class AngelEncountersTaco
    {
        public static void Add()
        {
            if (EnemyExist("Iconoclast_EN") && BundleStatic("Iconoclast_Hard"))
            {
                List<SpecificEnemyGroup> list = new List<SpecificEnemyGroup>(((SpecificEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Iconoclast_Hard"))._enemyBundles);
                list.Add(new SpecificEnemyGroup
                {
                    _enemyGroup = new SpecificEnemyInfo[]
                    {
                    new SpecificEnemyInfo
                    { enemyName = "Iconoclast_EN",
                    enemySlot = 3 },
                    new SpecificEnemyInfo
                    { enemyName = "LittleAngel_EN",
                    enemySlot = 1 },
                    }
                });
                list.Add(new SpecificEnemyGroup
                {
                    _enemyGroup = new SpecificEnemyInfo[]
                    {
                    new SpecificEnemyInfo
                    { enemyName = "Iconoclast_EN",
                    enemySlot = 3 },
                    new SpecificEnemyInfo
                    { enemyName = "LittleAngel_EN",
                    enemySlot = 1 },
                    new SpecificEnemyInfo
                    { enemyName = "SkinningHomunculus_EN",
                    enemySlot = 0}
                    }
                });
                ((SpecificEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Iconoclast_Hard"))._enemyBundles = list.ToArray();
            }
            else if (EnemyExist("Iconoclast_EN") && BundleRandom("Iconoclast_Hard"))
            {
                List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Iconoclast_Hard"))._enemyBundles);
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Iconoclast_EN",
                        "LittleAngel_EN",
                    }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Iconoclast_EN",
                        "LittleAngel_EN",
                        "SkinningHomunculus_EN",
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Iconoclast_Hard"))._enemyBundles = list.ToArray();
            }
        }
    }
    public static class AngelEncountersBoth
    {
        public static void Add()
        {
            if (MultiENExist("Iconoclast_EN", "TitteringPeon_EN", "ScreamingHomunculus_EN") && BundleStatic("Iconoclast_Hard"))
            {
                List<SpecificEnemyGroup> list = new List<SpecificEnemyGroup>(((SpecificEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Iconoclast_Hard"))._enemyBundles);
                if (DoDebugs.MiscInfo) Debug.Log("started");
                if (SaltEnemies.trolling == 39)
                {
                    list.Add(new SpecificEnemyGroup
                    {
                        _enemyGroup = new SpecificEnemyInfo[]
                    {
                    new SpecificEnemyInfo
                    { enemyName = "Iconoclast_EN",
                    enemySlot = 3 },
                    new SpecificEnemyInfo
                    { enemyName = "LittleAngel_EN",
                    enemySlot = 2 },
                    new SpecificEnemyInfo
                    { enemyName = "TitteringPeon_EN",
                    enemySlot = 1}
                    }
                    });
                }
                list.Add(new SpecificEnemyGroup
                {
                    _enemyGroup = new SpecificEnemyInfo[]
                    {
                    new SpecificEnemyInfo
                    { enemyName = "Iconoclast_EN",
                    enemySlot = 3 },
                    new SpecificEnemyInfo
                    { enemyName = "LittleAngel_EN",
                    enemySlot = 1 },
                    new SpecificEnemyInfo
                    { enemyName = "ScreamingHomunculus_EN",
                    enemySlot = 2}
                    }
                });
                ((SpecificEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Iconoclast_Hard"))._enemyBundles = list.ToArray();
            }
            else if (MultiENExist("Iconoclast_EN", "TitteringPeon_EN", "ScreamingHomunculus_EN") && BundleRandom("Iconoclast_Hard"))
            {
                List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Iconoclast_Hard"))._enemyBundles);
                if (DoDebugs.MiscInfo) Debug.Log("started");
                if (SaltEnemies.trolling == 39)
                {
                    list.Add(new RandomEnemyGroup
                    {
                        _enemyNames = new string[]
                        {
                            "Iconoclast_EN",
                            "LittleAngel_EN",
                            "TitteringPeon_EN",
                        }
                    });
                }
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Iconoclast_EN",
                        "LittleAngel_EN",
                        "ScreamingHomunculus_EN",
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Iconoclast_Hard"))._enemyBundles = list.ToArray();
            }
        }
    }
}

