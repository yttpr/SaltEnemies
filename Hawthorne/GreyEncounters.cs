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
    public static class GreyEncounters
    {
        public static void Add()
        {
            BrutalAPI.EnemyEncounter enemyEncounter = new BrutalAPI.EnemyEncounter();
            enemyEncounter.encounterName = "Gospel_Hard";
            enemyEncounter.area = 2;
            enemyEncounter.randomPlacement = true;
            enemyEncounter.hardmodeEncounter = true;
            enemyEncounter.difficulty = EncounterDifficulty.Hard;
            enemyEncounter.rarity = 12;
            if (SaltEnemies.trolling >= 88)
            {
                enemyEncounter.rarity = 15;
            }
            enemyEncounter.variations = new FieldEnemy[11][];
            enemyEncounter.signType = (SignType)3587;
            enemyEncounter.musicEvent = LoadedAssetsHandler.GetEnemyBundle("Zone02_Spoggle_Writhing_Medium_EnemyBundle")._musicEventReference;
            enemyEncounter.roarEvent = LoadedAssetsHandler.GetEnemyBundle("Zone02_Spoggle_Writhing_Medium_EnemyBundle")._roarReference.roarEvent;
            enemyEncounter.variations[0] = new FieldEnemy[3];
            enemyEncounter.variations[0][0] = new FieldEnemy()
            {
                enemyName = "MortalSpoggle_EN",
                enemySlot = 2
            };
            enemyEncounter.variations[0][1] = new FieldEnemy()
            {
                enemyName = "ShiveringHomunculus_EN",
                enemySlot = 3
            };
            enemyEncounter.variations[0][2] = new FieldEnemy()
            {
                enemyName = "LittleAngel_EN",
                enemySlot = 4
            };
            enemyEncounter.variations[1] = new FieldEnemy[4];
            enemyEncounter.variations[1][0] = new FieldEnemy()
            {
                enemyName = "MortalSpoggle_EN",
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
                enemyName = "ShiveringHomunculus_EN",
                enemySlot = 4
            };
            enemyEncounter.variations[2] = new FieldEnemy[3];
            enemyEncounter.variations[2][0] = new FieldEnemy()
            {
                enemyName = "MortalSpoggle_EN",
                enemySlot = 0
            };
            enemyEncounter.variations[2][1] = new FieldEnemy()
            {
                enemyName = "ChoirBoy_EN",
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
                enemyName = "MortalSpoggle_EN",
                enemySlot = 0
            };
            enemyEncounter.variations[3][1] = new FieldEnemy()
            {
                enemyName = "NextOfKin_EN",
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
                enemyName = "MortalSpoggle_EN",
                enemySlot = 0
            };
            enemyEncounter.variations[4][1] = new FieldEnemy()
            {
                enemyName = "GigglingMinister_EN",
                enemySlot = 1
            };
            enemyEncounter.variations[4][2] = new FieldEnemy()
            {
                enemyName = "RusticJumbleguts_EN",
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
                enemyName = "MortalSpoggle_EN",
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
                enemyName = "InHisImage_EN",
                enemySlot = 4
            };
            enemyEncounter.variations[6] = new FieldEnemy[3];
            enemyEncounter.variations[6][0] = new FieldEnemy()
            {
                enemyName = "MortalSpoggle_EN",
                enemySlot = 0
            };
            enemyEncounter.variations[6][1] = new FieldEnemy()
            {
                enemyName = "ShiveringHomunculus_EN",
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
                enemyName = "MortalSpoggle_EN",
                enemySlot = 0
            };
            enemyEncounter.variations[7][1] = new FieldEnemy()
            {
                enemyName = "ChoirBoy_EN",
                enemySlot = 1
            };
            enemyEncounter.variations[7][2] = new FieldEnemy()
            {
                enemyName = "GigglingMinister_EN",
                enemySlot = 2
            };
            enemyEncounter.variations[8] = new FieldEnemy[3];
            enemyEncounter.variations[8][0] = new FieldEnemy()
            {
                enemyName = "MortalSpoggle_EN",
                enemySlot = 0
            };
            enemyEncounter.variations[8][1] = new FieldEnemy()
            {
                enemyName = "SkinningHomunculus_EN",
                enemySlot = 1
            };
            enemyEncounter.variations[8][2] = new FieldEnemy()
            {
                enemyName = "RusticJumbleguts_EN",
                enemySlot = 2
            };
            enemyEncounter.variations[9] = new FieldEnemy[4];
            enemyEncounter.variations[9][0] = new FieldEnemy()
            {
                enemyName = "MortalSpoggle_EN",
                enemySlot = 0
            };
            enemyEncounter.variations[9][1] = new FieldEnemy()
            {
                enemyName = "InHisImage_EN",
                enemySlot = 1
            };
            enemyEncounter.variations[9][2] = new FieldEnemy()
            {
                enemyName = "InHerImage_EN",
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
                enemyName = "MortalSpoggle_EN",
                enemySlot = 0
            };
            enemyEncounter.variations[10][1] = new FieldEnemy()
            {
                enemyName = "InHisImage_EN",
                enemySlot = 1
            };
            enemyEncounter.variations[10][2] = new FieldEnemy()
            {
                enemyName = "NextOfKin_EN",
                enemySlot = 2
            };
            enemyEncounter.variations[10][3] = new FieldEnemy()
            {
                enemyName = "GigglingMinister_EN",
                enemySlot = 4
            };
            BrutalAPI.BrutalAPI.AddSignType(enemyEncounter.signType, ResourceLoader.LoadSprite("GSpogIcon", 64));
            enemyEncounter.AddEncounter();
            List<RandomEnemyGroup> list16 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_SkinningHomunculus_Hard_EnemyBundle"))._enemyBundles);
            list16.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "ShiveringHomunculus_EN",
                    "SkinningHomunculus_EN",
                    "MortalSpoggle_EN"
                }
            });
            list16.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "NextOfKin_EN",
                    "SkinningHomunculus_EN",
                    "MortalSpoggle_EN"
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
                    "MortalSpoggle_EN"
                }
            });
            list5.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "InHerImage_EN",
                    "MortalSpoggle_EN",
                    "GigglingMinister_EN"
                }
            });
            list5.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "SkinningHomunculus_EN",
                    "GigglingMinister_EN",
                    "MortalSpoggle_EN"
                }
            });
            list5.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "MortalSpoggle_EN",
                    "GigglingMinister_EN",
                    "LittleAngel_EN"
                }
            });
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_GigglingMinister_Hard_EnemyBundle"))._enemyBundles = list5.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Garden Encounters Loaded!");
        }
    }
    public static class RustEncounters
    {
        public static void Add()
        {
            BrutalAPI.EnemyEncounter enemyEncounter = new BrutalAPI.EnemyEncounter();
            enemyEncounter.encounterName = "Rust_Hard";
            enemyEncounter.area = 2;
            enemyEncounter.randomPlacement = true;
            enemyEncounter.hardmodeEncounter = true;
            enemyEncounter.difficulty = EncounterDifficulty.Hard;
            enemyEncounter.rarity = 7;
            if (SaltEnemies.trolling >= 94)
            {
                enemyEncounter.rarity = 15;
            }
            enemyEncounter.variations = new FieldEnemy[5][];
            enemyEncounter.signType = (SignType)3597;
            enemyEncounter.musicEvent = LoadedAssetsHandler.GetEnemyBundle("Zone02_JumbleGuts_Flummoxing_Medium_EnemyBundle")._musicEventReference;
            enemyEncounter.roarEvent = LoadedAssetsHandler.GetEnemyBundle("Zone02_Spoggle_Resonant_Medium_EnemyBundle")._roarReference.roarEvent;
            enemyEncounter.variations[0] = new FieldEnemy[3];
            enemyEncounter.variations[0][0] = new FieldEnemy()
            {
                enemyName = "RusticJumbleguts_EN",
                enemySlot = 2
            };
            enemyEncounter.variations[0][1] = new FieldEnemy()
            {
                enemyName = "ShiveringHomunculus_EN",
                enemySlot = 3
            };
            enemyEncounter.variations[0][2] = new FieldEnemy()
            {
                enemyName = "SkinningHomunculus_EN",
                enemySlot = 4
            };
            enemyEncounter.variations[1] = new FieldEnemy[4];
            enemyEncounter.variations[1][0] = new FieldEnemy()
            {
                enemyName = "MortalSpoggle_EN",
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
                enemyName = "RusticJumbleguts_EN",
                enemySlot = 4
            };
            enemyEncounter.variations[2] = new FieldEnemy[3];
            enemyEncounter.variations[2][0] = new FieldEnemy()
            {
                enemyName = "RusticJumbleguts_EN",
                enemySlot = 0
            };
            enemyEncounter.variations[2][1] = new FieldEnemy()
            {
                enemyName = "ChoirBoy_EN",
                enemySlot = 1
            };
            enemyEncounter.variations[2][2] = new FieldEnemy()
            {
                enemyName = "NextOfKin_EN",
                enemySlot = 2
            };
            enemyEncounter.variations[3] = new FieldEnemy[4];
            enemyEncounter.variations[3][0] = new FieldEnemy()
            {
                enemyName = "RusticJumbleguts_EN",
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
                enemyName = "MortalSpoggle_EN",
                enemySlot = 0
            };
            enemyEncounter.variations[4][1] = new FieldEnemy()
            {
                enemyName = "GigglingMinister_EN",
                enemySlot = 1
            };
            enemyEncounter.variations[4][2] = new FieldEnemy()
            {
                enemyName = "RusticJumbleguts_EN",
                enemySlot = 2
            };
            enemyEncounter.variations[4][3] = new FieldEnemy()
            {
                enemyName = "ShiveringHomunculus_EN",
                enemySlot = 4
            };
            BrutalAPI.BrutalAPI.AddSignType(enemyEncounter.signType, ResourceLoader.LoadSprite("GJumbIcon", 64));
            enemyEncounter.AddEncounter();
        }
    }
    public static class GreyEncountersTairPeep
    {
        public static void Add()
        {
            if (MultiENExist("ScreamingHomunculus_EN", "TitteringPeon_EN"))
            {
                List<RandomEnemyGroup> list16 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_SkinningHomunculus_Hard_EnemyBundle"))._enemyBundles);
                list16.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "SkinningHomunculus_EN",
                    "ScreamingHomunculus_EN",
                    "MortalSpoggle_EN",
                    }
                });
                list16.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "SkinningHomunculus_EN",
                    "MortalSpoggle_EN",
                    "TitteringPeon_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_SkinningHomunculus_Hard_EnemyBundle"))._enemyBundles = list16.ToArray();
            }
            if (MultiENExist("ScreamingHomunculus_EN", "TitteringPeon_EN") && BundleRandom("Peonm"))
            {
                List<RandomEnemyGroup> list6 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Peonm"))._enemyBundles);
                list6.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "InHisImage_EN",
                    "MortalSpoggle_EN",
                    "TitteringPeon_EN"
                    }
                });
                list6.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "MortalSpoggle_EN",
                    "ScreamingHomunculus_EN",
                    "TitteringPeon_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Peonm"))._enemyBundles = list6.ToArray();
            }
            if (MultiENExist("Unterling_EN", "ScreamingHomunculus_EN"))
            {
                List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Gospel_Hard"))._enemyBundles);
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "MortalSpoggle_EN",
                    "Unterling_EN",
                    "RusticJumbleguts_EN"
                    }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "MortalSpoggle_EN",
                    "Unterling_EN"
                    }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "NextOfKin_EN",
                    "ScreamingHomunculus_EN",
                    "MortalSpoggle_EN",
                    "NextOfKin_EN",
                    "NextOfKin_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Gospel_Hard"))._enemyBundles = list.ToArray();
            }
            if (MultiENExist("Unterling_EN", "ImpenetrableAngler_EN") && BundleRandom("AnglerH"))
            {
                List<RandomEnemyGroup> list88 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("AnglerH"))._enemyBundles);
                list88.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "SkinningHomunculus_EN",
                    "MortalSpoggle_EN",
                    "ImpenetrableAngler_EN"
                    }
                });
                list88.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "MortalSpoggle_EN",
                    "ImpenetrableAngler_EN",
                    "Unterling_EN"
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
                    "MortalSpoggle_EN",
                    "SterileBud_EN"
                    }
                });
                list89.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "GigglingMinister_EN",
                    "MortalSpoggle_EN",
                    "SterileBud_EN"
                    }
                });
                list89.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "ChoirBoy_EN",
                    "MortalSpoggle_EN",
                    "SterileBud_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("SterileBudHard"))._enemyBundles = list89.ToArray();
            }
        }
    }
    public static class GreyEncountersTaco
    {
        public static void Add()
        {

            
        }
    }
    public static class GreyEncountersBoth
    {
        public static void Add()
        {

            
        }
    }
}

