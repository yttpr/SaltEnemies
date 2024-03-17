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
    public static class DontTouchMeEncounters
    {
        public static void Add()
        {
            BrutalAPI.EnemyEncounter enemyEncounter = new BrutalAPI.EnemyEncounter();
            enemyEncounter.encounterName = "DontTouchMe_Hard";
            enemyEncounter.area = 1;
            enemyEncounter.randomPlacement = true;
            enemyEncounter.hardmodeEncounter = true;
            enemyEncounter.difficulty = EncounterDifficulty.Hard;
            enemyEncounter.rarity = 12;
            if (SaltEnemies.trolling == 98)
            {
                enemyEncounter.rarity = 24;
            }
            enemyEncounter.variations = new FieldEnemy[1][];
            enemyEncounter.signType = (SignType)6329;
            enemyEncounter.musicEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone03_SkinningHomunculus_Medium_EnemyBundle")._musicEventReference;
            enemyEncounter.roarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone03_SkinningHomunculus_Medium_EnemyBundle")._roarReference.roarEvent;
            enemyEncounter.variations[0] = new FieldEnemy[3];
            enemyEncounter.variations[0][0] = new FieldEnemy()
            {
                enemyName = "Freud_EN",
                enemySlot = 2
            };
            enemyEncounter.variations[0][1] = new FieldEnemy()
            {
                enemyName = "MusicMan_EN",
                enemySlot = 3
            };
            enemyEncounter.variations[0][2] = new FieldEnemy()
            {
                enemyName = "MusicMan_EN",
                enemySlot = 4
            };

            //enemyEncounter.customEnvironment = "stringNameYUMMY";
            BrutalAPI.BrutalAPI.AddSignType(enemyEncounter.signType, ResourceLoader.LoadSprite("TouchIcon", 64));
            enemyEncounter.AddEncounter();
            //LoadedAssetsHandler.GetEnemyBundle("DontTouchMe_Hard")._bossType = (BossType)69420;

            List<RandomEnemyGroup> list5 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("DontTouchMe_Hard"))._enemyBundles);
            list5.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "Freud_EN",
                    "MusicMan_EN",
                    "MusicMan_EN",
                    "SilverSuckle_EN"
                }
            });
            list5.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "Freud_EN",
                    "MusicMan_EN",
                    "Scrungie_EN"
                }
            });
            list5.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "Freud_EN",
                    "MusicMan_EN",
                    "JumbleGuts_Flummoxing_EN",
                    "JumbleGuts_Hollowing_EN"
                }
            });
            list5.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
               {
                    "Freud_EN",
                    "MusicMan_EN",
                    "TheCrow_EN"
               }
            });
            list5.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
               {
                    "Freud_EN",
                    "MusicMan_EN",
                    "LostSheep_EN"
               }
            });
            list5.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
               {
                    "Freud_EN",
                    "Conductor_EN"
               }
            });
            list5.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
               {
                    "Freud_EN",
                    "Conductor_EN",
                    "MusicMan_EN"
               }
            });
            list5.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
               {
                    "Freud_EN",
                    "Conductor_EN",
                    "Spoggle_Ruminating_EN"
               }
            });
            list5.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
               {
                    "Freud_EN",
                    "Conductor_EN",
                    "LostSheep_EN"
               }
            });
            if (SaltEnemies.trolling == 46)
            {
                list5.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
               {
                    "Freud_EN",
                    "Conductor_EN",
                    "DeadPixel_EN",
                    "DeadPixel_EN"
               }
                });
            }
            list5.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
               {
                    "Freud_EN",
                    "Revola_EN"
               }
            });
            list5.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
               {
                    "Freud_EN",
                    "WrigglingSacrifice_EN",
                    "MusicMan_EN"
               }
            });
            list5.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
               {
                    "Freud_EN",
                    "WrigglingSacrifice_EN",
                    "Spoggle_Spitfire_EN"
               }
            });
            list5.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
               {
                    "Freud_EN",
                    "WrigglingSacrifice_EN",
                    "Something_EN"
               }
            });
            list5.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
               {
                    "Freud_EN",
                    "Spoggle_Resonant_EN",
                    "Spoggle_Ruminating_EN"
               }
            });
            list5.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
               {
                    "Freud_EN",
                    "Spoggle_Resonant_EN",
                    "Spoggle_Writhing_EN"
               }
            });
            list5.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
               {
                    "Freud_EN",
                    "Spoggle_Resonant_EN",
                    "Enigma_EN"
               }
            });
            list5.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
               {
                    "Freud_EN",
                    "JumbleGuts_Flummoxing_EN",
                    "JumbleGuts_Hollowing_EN"
               }
            });
            list5.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
               {
                    "Freud_EN",
                    "JumbleGuts_Flummoxing_EN",
                    "Scrungie_EN"
               }
            });
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("DontTouchMe_Hard"))._enemyBundles = list5.ToArray();
            
        }
    }
    public static class DontTouchMeEncountersTairPeep
    {
        public static void Add()
        {
            List<RandomEnemyGroup> list5 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("DontTouchMe_Hard"))._enemyBundles);
            if (EnemyExist("DesiccatingJumbleguts_EN"))
            {
                list5.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                {
                    "Freud_EN",
                    "DesiccatingJumbleguts_EN",
                    "JumbleGuts_Waning_EN"
                }
                });
                list5.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "Freud_EN",
                    "DesiccatingJumbleguts_EN",
                    "MusicMan_EN"
                    }
                });
                list5.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "Freud_EN",
                    "DesiccatingJumbleguts_EN",
                    "Enigma_EN"
                    }
                });
            }
            if (EnemyExist("PerforatedSpoggle_EN"))
            {
                list5.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                {
                    "Freud_EN",
                    "PerforatedSpoggle_EN",
                    "Enigma_EN"
                }
                });
                list5.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "Freud_EN",
                    "PerforatedSpoggle_EN",
                    "LostSheep_EN"
                    }
                });
            }
            if (EnemyExist("Gizo_EN"))
            {
                list5.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                {
                    "Freud_EN",
                    "Gizo_EN",
                    "MusicMan_EN"
                }
                });
                list5.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "Freud_EN",
                    "Gizo_EN",
                    "JumbleGuts_Hollowing_EN"
                    }
                });
                list5.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "Freud_EN",
                    "Gizo_EN",
                    "MusicMan_EN",
                    "MusicMan_EN"
                    }
                });
            }
            if (EnemyExist("NakedGizo_EN"))
            {
                list5.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                {
                    "Freud_EN",
                    "NakedGizo_EN",
                    "Spoggle_Ruminating_EN"
                }
                });
                list5.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "Freud_EN",
                    "NakedGizo_EN",
                    "Spoggle_Ruminating_EN",
                    "Enigma_EN"
                    }
                });
            }
            if (SaltEnemies.trolling == 28 && EnemyExist("SingingMountain_EN"))
            {
                list5.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                {
                    "Freud_EN",
                    "SingingMountain_EN",
                }
                });
            }
            if (SaltEnemies.silly >= 86 && EnemyExist("FamiliarSpoggle_EN"))
            {
                list5.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                {
                    "Freud_EN",
                    "SingingStone_EN",
                    "FamiliarSpoggle_EN"
                }
                });
            }
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("DontTouchMe_Hard"))._enemyBundles = list5.ToArray();

        }
    }
    public static class DontTouchMeEncountersTaco
    {
        public static void Add()
        {
            if (SaltEnemies.trolling == 57 && EnemyExist("TheFatman_EN") && BundleRandom("TheFatman_Hard_Miniboss"))
            {
                List<RandomEnemyGroup> list5 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("TheFatman_Hard_Miniboss"))._enemyBundles);
                list5.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "TheFatman_EN",
                    "Freud_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("TheFatman_Hard_Miniboss"))._enemyBundles = list5.ToArray();
            }
        }
    }
    public static class DontTouchMeEncountersBoth
    {
        public static void Add()
        {
            if (DoDebugs.GenInfo) Debug.Log("Orpheum Encounters Loaded!");
        }
    }
}

