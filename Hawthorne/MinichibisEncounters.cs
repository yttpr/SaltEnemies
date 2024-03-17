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
    public static class MinichibisEncounters
    {
        public static void Add()
        {
            if (!EnemyExist("EggKeeper_EN")) return;
            if (DoDebugs.MiscInfo) Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");

            if (BundleRandom("Choirboy Medium - Eggkeeper"))
            {
                List<RandomEnemyGroup> list5 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Choirboy Medium - Eggkeeper"))._enemyBundles);
                list5.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "EggKeeper_EN",
                    "ChoirBoy_EN",
                    "LittleAngel_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Choirboy Medium - Eggkeeper"))._enemyBundles = list5.ToArray();
            } 
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_InHisImage_Medium_EnemyBundle"))._enemyBundles = new List<RandomEnemyGroup>((IEnumerable<RandomEnemyGroup>)((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_InHisImage_Medium_EnemyBundle"))._enemyBundles)
            {
                new RandomEnemyGroup()
                {
                    _enemyNames = new string[4]
                    {
                    "EggKeeper_EN",
                    "InHerImage_EN",
                    "InHisImage_EN",
                    "Satyr_EN"
                    }
                },
                new RandomEnemyGroup()
                {
                    _enemyNames = new string[4]
                    {
                    "EggKeeper_EN",
                    "InHerImage_EN",
                    "InHisImage_EN",
                    "LittleAngel_EN"
                    }
                }
            }.ToArray();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_SkinningHomunculus_Hard_EnemyBundle"))._enemyBundles = new List<RandomEnemyGroup>((IEnumerable<RandomEnemyGroup>)((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_SkinningHomunculus_Hard_EnemyBundle"))._enemyBundles)
            {
                new RandomEnemyGroup()
                {
                    _enemyNames = new string[4]
                    {
                    "EggKeeper_EN",
                    "Satyr_EN",
                    "SkinningHomunculus_EN",
                    "SkinningHomunculus_EN"
                    }
                },
                new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "SkinningHomunculus_EN",
                    "EggKeeper_EN",
                    "LittleAngel_EN",
                    "EggKeeper_EN"
                    } 
                }
        }.ToArray();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Gospel_Hard"))._enemyBundles = new List<RandomEnemyGroup>((IEnumerable<RandomEnemyGroup>)((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Gospel_Hard"))._enemyBundles)
            {
                new RandomEnemyGroup()
                {
                    _enemyNames = new string[]
                    {
                    "EggKeeper_EN",
                    "MortalSpoggle_EN",
                    "SkinningHomunculus_EN"
                    }
                },
            }.ToArray();

            if (MultiENExist("TitteringPeon_EN", "ScreamingHomunculus_EN", "SterileBud_EN", "Unterling_EN"))
            {
                List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Satyr_Hard"))._enemyBundles);
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "EggKeeper_EN",
                    "Satyr_EN",
                    "SterileBud_EN"
                    }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "EggKeeper_EN",
                    "ScreamingHomunculus_EN",
                    "Satyr_EN",
                    "ShiveringHomunculus_EN"
                    }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "TitteringPeon_EN",
                    "ScreamingHomunculus_EN",
                    "Satyr_EN",
                    "EggKeeper_EN"
                    }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "SterileBud_EN",
                    "Unterling_EN",
                    "Satyr_EN",
                    "EggKeeper_EN",
                    "Unterling_EN"
                    }
                });

                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Satyr_Hard"))._enemyBundles = list.ToArray();
            }
            if (EnemyExist("ImpenetrableAngler_EN") && BundleRandom("AnglerH"))
            {
                List<RandomEnemyGroup> list88 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("AnglerH"))._enemyBundles);
                list88.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "EggKeeper_EN",
                    "LittleAngel_EN",
                    "ImpenetrableAngler_EN",
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
                    "EggKeeper_EN",
                    "LittleAngel_EN",
                    "SterileBud_EN",
                    "NextOfKin_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("SterileBudHard"))._enemyBundles = list89.ToArray();
            }
            if (EnemyExist("ImpenetrableAngler_EN") && BundleRandom("MetatronH"))
            {
                List<RandomEnemyGroup> list88 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("MetatronH"))._enemyBundles);
                list88.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "EggKeeper_EN",
                    "Satyr_EN",
                    "Metatron_EN",
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("MetatronH"))._enemyBundles = list88.ToArray();
            }
            if (MultiENExist("Harbinger_EN", "HowlingAvian_EN", "InfernalDrummer_EN"))
            {
                List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_InHerImage_Medium_EnemyBundle"))._enemyBundles);
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "InHerImage_EN",
                    "EggKeeper_EN",
                    "Harbinger_EN",
                    "LittleAngel_EN",
                    }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "InHerImage_EN",
                    "EggKeeper_EN",
                    "HowlingAvian_EN",
                    "LittleAngel_EN",
                    "NextOfKin_EN"
                    }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "InHerImage_EN",
                    "EggKeeper_EN",
                    "LittleAngel_EN",
                    "InHerImage_EN"
                    }
                });
                if (SaltEnemies.trolling == 33)
                {
                    list.Add(new RandomEnemyGroup
                    {
                        _enemyNames = new string[]
                    {
                    "InHerImage_EN",
                    "DeadPixel_EN",
                    "DeadPixel_EN",
                    "EggKeeper_EN",
                    "InfernalDrummer_EN"
                    }
                    });
                }
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "InHerImage_EN",
                    "EggKeeper_EN",
                    "LittleAngel_EN",
                    "InHisImage_EN",
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_InHerImage_Medium_EnemyBundle"))._enemyBundles = list.ToArray();

            }
        }
    }
}