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
    public static class SatyrEncounters
    {
        public static void Add()
        {
            BrutalAPI.EnemyEncounter enemyEncounter = new BrutalAPI.EnemyEncounter();
            enemyEncounter.encounterName = "Satyr_Hard";
            enemyEncounter.area = 2;
            enemyEncounter.randomPlacement = true;
            enemyEncounter.hardmodeEncounter = true;
            enemyEncounter.difficulty = EncounterDifficulty.Hard;
            enemyEncounter.rarity = 16;
            if (SaltEnemies.trolling == 49)
            {
                enemyEncounter.rarity = 19;
            }
            enemyEncounter.variations = new FieldEnemy[11][];
            enemyEncounter.signType = (SignType)4578;
            enemyEncounter.musicEvent = "event:/Hawthorne/NewerSatyrTheme";
            enemyEncounter.roarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone03_Sepulchre_Hard_EnemyBundle")._roarReference.roarEvent;
            enemyEncounter.variations[0] = new FieldEnemy[3];
            enemyEncounter.variations[0][0] = new FieldEnemy()
            {
                enemyName = "Satyr_EN",
                enemySlot = 2
            };
            enemyEncounter.variations[0][1] = new FieldEnemy()
            {
                enemyName = "ShiveringHomunculus_EN",
                enemySlot = 3
            };
            enemyEncounter.variations[0][2] = new FieldEnemy()
            {
                enemyName = "ShiveringHomunculus_EN",
                enemySlot = 4
            };
            enemyEncounter.variations[1] = new FieldEnemy[4];
            enemyEncounter.variations[1][0] = new FieldEnemy()
            {
                enemyName = "Satyr_EN",
                enemySlot = 0
            };
            enemyEncounter.variations[1][1] = new FieldEnemy()
            {
                enemyName = "InHerImage_EN",
                enemySlot = 1
            };
            enemyEncounter.variations[1][2] = new FieldEnemy()
            {
                enemyName = "InHisImage_EN",
                enemySlot = 2
            };
            enemyEncounter.variations[1][3] = new FieldEnemy()
            {
                enemyName = "Satyr_EN",
                enemySlot = 4
            };
            enemyEncounter.variations[2] = new FieldEnemy[3];
            enemyEncounter.variations[2][0] = new FieldEnemy()
            {
                enemyName = "Satyr_EN",
                enemySlot = 0
            };
            enemyEncounter.variations[2][1] = new FieldEnemy()
            {
                enemyName = "InHerImage_EN",
                enemySlot = 1
            };
            enemyEncounter.variations[2][2] = new FieldEnemy()
            {
                enemyName = "ChoirBoy_EN",
                enemySlot = 2
            };
            enemyEncounter.variations[3] = new FieldEnemy[4];
            enemyEncounter.variations[3][0] = new FieldEnemy()
            {
                enemyName = "Satyr_EN",
                enemySlot = 0
            };
            enemyEncounter.variations[3][1] = new FieldEnemy()
            {
                enemyName = "InHisImage_EN",
                enemySlot = 1
            };
            enemyEncounter.variations[3][2] = new FieldEnemy()
            {
                enemyName = "ChoirBoy_EN",
                enemySlot = 2
            };
            enemyEncounter.variations[3][3] = new FieldEnemy()
            {
                enemyName = "NextOfKin_EN",
                enemySlot = 3
            };
            enemyEncounter.variations[4] = new FieldEnemy[4];
            enemyEncounter.variations[4][0] = new FieldEnemy()
            {
                enemyName = "Satyr_EN",
                enemySlot = 0
            };
            enemyEncounter.variations[4][1] = new FieldEnemy()
            {
                enemyName = "InHerImage_EN",
                enemySlot = 1
            };
            enemyEncounter.variations[4][2] = new FieldEnemy()
            {
                enemyName = "InHerImage_EN",
                enemySlot = 2
            };
            enemyEncounter.variations[4][3] = new FieldEnemy()
            {
                enemyName = "NextOfKin_EN",
                enemySlot = 4
            };
            enemyEncounter.variations[5] = new FieldEnemy[4];
            enemyEncounter.variations[5][0] = new FieldEnemy()
            {
                enemyName = "Satyr_EN",
                enemySlot = 0
            };
            enemyEncounter.variations[5][1] = new FieldEnemy()
            {
                enemyName = "InHisImage_EN",
                enemySlot = 1
            };
            enemyEncounter.variations[5][2] = new FieldEnemy()
            {
                enemyName = "InHisImage_EN",
                enemySlot = 2
            };
            enemyEncounter.variations[5][3] = new FieldEnemy()
            {
                enemyName = "NextOfKin_EN",
                enemySlot = 4
            };
            enemyEncounter.variations[6] = new FieldEnemy[3];
            enemyEncounter.variations[6][0] = new FieldEnemy()
            {
                enemyName = "Satyr_EN",
                enemySlot = 0
            };
            enemyEncounter.variations[6][1] = new FieldEnemy()
            {
                enemyName = "Satyr_EN",
                enemySlot = 1
            };
            enemyEncounter.variations[6][2] = new FieldEnemy()
            {
                enemyName = "ChoirBoy_EN",
                enemySlot = 2
            };
            enemyEncounter.variations[7] = new FieldEnemy[3];
            enemyEncounter.variations[7][0] = new FieldEnemy()
            {
                enemyName = "Satyr_EN",
                enemySlot = 0
            };
            enemyEncounter.variations[7][1] = new FieldEnemy()
            {
                enemyName = "ChoirBoy_EN",
                enemySlot = 1
            };
            enemyEncounter.variations[7][2] = new FieldEnemy()
            {
                enemyName = "ChoirBoy_EN",
                enemySlot = 2
            };
            enemyEncounter.variations[8] = new FieldEnemy[3];
            enemyEncounter.variations[8][0] = new FieldEnemy()
            {
                enemyName = "Satyr_EN",
                enemySlot = 0
            };
            enemyEncounter.variations[8][1] = new FieldEnemy()
            {
                enemyName = "ChoirBoy_EN",
                enemySlot = 1
            };
            enemyEncounter.variations[8][2] = new FieldEnemy()
            {
                enemyName = "LittleAngel_EN",
                enemySlot = 2
            };
            enemyEncounter.variations[9] = new FieldEnemy[4];
            enemyEncounter.variations[9][0] = new FieldEnemy()
            {
                enemyName = "Satyr_EN",
                enemySlot = 0
            };
            enemyEncounter.variations[9][1] = new FieldEnemy()
            {
                enemyName = "InHisImage_EN",
                enemySlot = 1
            };
            enemyEncounter.variations[9][2] = new FieldEnemy()
            {
                enemyName = "LittleAngel_EN",
                enemySlot = 2
            };
            enemyEncounter.variations[9][3] = new FieldEnemy()
            {
                enemyName = "NextOfKin_EN",
                enemySlot = 4
            };
            enemyEncounter.variations[10] = new FieldEnemy[4];
            enemyEncounter.variations[10][0] = new FieldEnemy()
            {
                enemyName = "Satyr_EN",
                enemySlot = 0
            };
            enemyEncounter.variations[10][1] = new FieldEnemy()
            {
                enemyName = "InHisImage_EN",
                enemySlot = 1
            };
            enemyEncounter.variations[10][2] = new FieldEnemy()
            {
                enemyName = "InHisImage_EN",
                enemySlot = 2
            };
            enemyEncounter.variations[10][3] = new FieldEnemy()
            {
                enemyName = "GigglingMinister_EN",
                enemySlot = 4
            };
            BrutalAPI.BrutalAPI.AddSignType(enemyEncounter.signType, ResourceLoader.LoadSprite("Icon_Satyr", 64));
            enemyEncounter.AddEncounter();
            List<RandomEnemyGroup> list16 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_SkinningHomunculus_Hard_EnemyBundle"))._enemyBundles);
            list16.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "ShiveringHomunculus_EN",
                    "SkinningHomunculus_EN",
                    "Satyr_EN"
                }
            });
            list16.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "SkinningHomunculus_EN",
                    "Satyr_EN",
                    "GigglingMinister_EN"
                }
            });
            list16.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "ShiveringHomunculus_EN",
                    "SkinningHomunculus_EN",
                    "Satyr_EN"
                }
            });
            list16.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "Satyr_EN",
                    "SkinningHomunculus_EN",
                    "SkinningHomunculus_EN",
                    "LittleAngel_EN"
                }
            });
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_SkinningHomunculus_Hard_EnemyBundle"))._enemyBundles = list16.ToArray();
            List<RandomEnemyGroup> list5 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_GigglingMinister_Hard_EnemyBundle"))._enemyBundles);
            list5.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "NextOfKin_EN",
                    "NextOfKin_EN",
                    "GigglingMinister_EN",
                    "Satyr_EN",
                    "InHerImage_EN"
                }
            });
            list5.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "InHerImage_EN",
                    "InHisImage_EN",
                    "GigglingMinister_EN",
                    "Satyr_EN"
                }
            });
            list5.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "SkinningHomunculus_EN",
                    "GigglingMinister_EN",
                    "Satyr_EN"
                }
            });
            list5.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "Satyr_EN",
                    "InHerImage_EN",
                    "GigglingMinister_EN",
                    "LittleAngel_EN"
                }
            });
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_GigglingMinister_Hard_EnemyBundle"))._enemyBundles = list5.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Garden Encounters Loaded!");
        }
    }
    public static class SatyrEncountersTairPeep
    {
        public static void Add()
        {
            if (EnemyExist("ScreamingHomunculus_EN") && EnemyExist("TitteringPeon_EN"))
            {
                List<RandomEnemyGroup> list16 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_SkinningHomunculus_Hard_EnemyBundle"))._enemyBundles);
                list16.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "SkinningHomunculus_EN",
                    "ScreamingHomunculus_EN",
                    "Satyr_EN",
                    "LittleAngel_EN"
                    }
                });
                list16.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "SkinningHomunculus_EN",
                    "SkinningHomunculus_EN",
                    "Satyr_EN",
                    "TitteringPeon_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_SkinningHomunculus_Hard_EnemyBundle"))._enemyBundles = list16.ToArray();
            }
            if (MultiENExist("TitteringPeon_EN", "ScreamingHomunculus_EN", "Unterling_EN") && BundleRandom("Peonm"))
            {
                List<RandomEnemyGroup> list6 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Peonm"))._enemyBundles);
                list6.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "InHisImage_EN",
                    "InHerImage_EN",
                    "Satyr_EN",
                    "TitteringPeon_EN"
                    }
                });
                list6.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "InHisImage_EN",
                    "ScreamingHomunculus_EN",
                    "Satyr_EN",
                    "TitteringPeon_EN"
                    }
                });
                list6.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "Unterling_EN",
                    "ScreamingHomunculus_EN",
                    "Satyr_EN",
                    "TitteringPeon_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Peonm"))._enemyBundles = list6.ToArray();
            }
            if (MultiENExist("TitteringPeon_EN", "ScreamingHomunculus_EN"))
            {
                List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Satyr_Hard"))._enemyBundles);
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "ChoirBoy_EN",
                    "Satyr_EN",
                    "TitteringPeon_EN"
                    }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "ShiveringHomunculus_EN",
                    "ScreamingHomunculus_EN",
                    "Satyr_EN",
                    "ShiveringHomunculus_EN"
                    }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "ShiveringHomunculus_EN",
                    "ScreamingHomunculus_EN",
                    "Satyr_EN",
                    "LittleAngel_EN"
                    }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "NextOfKin_EN",
                    "ScreamingHomunculus_EN",
                    "Satyr_EN",
                    "NextOfKin_EN",
                    "NextOfKin_EN"
                    }
                });

                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Satyr_Hard"))._enemyBundles = list.ToArray();
            }
            if (EnemyExist("ImpenetrableAngler_EN") && EnemyExist("Unterling_EN") && BundleRandom("AnglerH"))
            {
                List<RandomEnemyGroup> list88 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("AnglerH"))._enemyBundles);
                list88.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "SkinningHomunculus_EN",
                    "Satyr_EN",
                    "ImpenetrableAngler_EN"
                    }
                });
                list88.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "InHisImage_EN",
                    "InHerImage_EN",
                    "Satyr_EN",
                    "ImpenetrableAngler_EN"
                    }
                });
                list88.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "Unterling_EN",
                    "Satyr_EN",
                    "ImpenetrableAngler_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("AnglerH"))._enemyBundles = list88.ToArray();
                if (DoDebugs.MiscInfo) Debug.Log("Angler Satyr Encounters");
            }
            if (EnemyExist("SterileBud_EN") && EnemyExist("Unterling_EN") && BundleRandom("SterileBudHard"))
            {
                List<RandomEnemyGroup> list89 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("SterileBudHard"))._enemyBundles);
                list89.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "SkinningHomunculus_EN",
                    "Satyr_EN",
                    "SterileBud_EN"
                    }
                });
                list89.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "Unterling_EN",
                    "Satyr_EN",
                    "SterileBud_EN",
                    "Unterling_EN"
                    }
                });
                list89.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "ChoirBoy_EN",
                    "Satyr_EN",
                    "SterileBud_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("SterileBudHard"))._enemyBundles = list89.ToArray();
            }
        }
    }
    public static class SatyrEncountersTaco
    {
        public static void Add()
        {

            if (EnemyExist("Iconoclast_EN") && BundleStatic("Iconoclast_Hard"))
            {
                List<SpecificEnemyGroup> list = new List<SpecificEnemyGroup>(((SpecificEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Iconoclast_Hard"))._enemyBundles);
                if (DoDebugs.MiscInfo) Debug.Log("started");

                list.Add(new SpecificEnemyGroup
                {
                    _enemyGroup = new SpecificEnemyInfo[]
                    {
                    new SpecificEnemyInfo
                    { enemyName = "Iconoclast_EN",
                    enemySlot = 0 },
                    new SpecificEnemyInfo
                    { enemyName = "LittleAngel_EN",
                    enemySlot = 2 },
                    new SpecificEnemyInfo
                    { enemyName = "Satyr_EN",
                    enemySlot = 3}
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
                    { enemyName = "Satyr_EN",
                    enemySlot = 1 },
                    new SpecificEnemyInfo
                    { enemyName = "SkinningHomunculus_EN",
                    enemySlot = 2}
                    }
                });
                if (SaltEnemies.trolling == 78)
                {
                    list.Add(new SpecificEnemyGroup
                    {
                        _enemyGroup = new SpecificEnemyInfo[]
                        {
                        new SpecificEnemyInfo
                        { enemyName = "Iconoclast_EN",
                        enemySlot = 0 },
                        new SpecificEnemyInfo
                        { enemyName = "Satyr_EN",
                        enemySlot = 4 },
                        new SpecificEnemyInfo
                        { enemyName = "Satyr_EN",
                        enemySlot = 3}
                        }
                    });
                }
                ((SpecificEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Iconoclast_Hard"))._enemyBundles = list.ToArray();
            }
            else if (EnemyExist("Iconoclast_EN") && BundleRandom("Iconoclast_Hard"))
            {
                List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Iconoclast_Hard"))._enemyBundles);
                Debug.Log("started");

                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Iconoclast_EN",
                        "LittleAngel_EN",
                        "Satyr_EN",
                    }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Iconoclast_EN",
                        "Satyr_EN",
                        "SkinningHomunculus_EN",
                    }
                });
                if (SaltEnemies.trolling == 78)
                {
                    list.Add(new RandomEnemyGroup
                    {
                        _enemyNames = new string[]
                        {
                            "Iconoclast_EN",
                            "Satyr_EN",
                            "Satyr_EN",
                        }
                    });
                }
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Iconoclast_Hard"))._enemyBundles = list.ToArray();
            }
        }
    }
    public static class SatyrEncountersBoth
    {
        public static void Add()
        {

            if (MultiENExist("Iconoclast_EN", "ScreamingHomunculus_EN") && BundleStatic("Iconoclast_Hard"))
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
                    { enemyName = "Satyr_EN",
                    enemySlot = 1 },
                    new SpecificEnemyInfo
                    { enemyName = "ScreamingHomunculus_EN",
                    enemySlot = 0}
                    }
                });
                ((SpecificEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Iconoclast_Hard"))._enemyBundles = list.ToArray();
            }
            else if (MultiENExist("Iconoclast_EN", "ScreamingHomunculus_EN") && BundleRandom("Iconoclast_Hard"))
            {
                List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Iconoclast_Hard"))._enemyBundles);

                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Iconoclast_EN",
                        "Satyr_EN",
                        "ScreamingHomunculus_EN",
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Iconoclast_Hard"))._enemyBundles = list.ToArray();
            }
        }
    }
}

