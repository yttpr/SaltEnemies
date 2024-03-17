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
    public static class FlowerEncounters
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
                    "A'Flower'_EN"
                }
            });
            //Debug.Log("first one");
            list.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "FlaMinGoa_EN",
                    "MudLung_EN",
                    "A'Flower'_EN"
                }
            });
            if (SaltEnemies.trolling < 38)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                {
                    "FlaMinGoa_EN",
                    "Spoggle_Spitfire_EN",
                    "A'Flower'_EN",
                    "Spoggle_Ruminating_EN"
                }
                });
            }
            if (SaltEnemies.trolling > 12 && SaltEnemies.trolling < 66)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                {
                    "FlaMinGoa_EN",
                    "MudLung_EN",
                    "A'Flower'_EN",
                    "MudLung_EN"
                }
                });
            }
            list.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "FlaMinGoa_EN",
                    "Flarb_EN",
                    "A'Flower'_EN"
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
                    "A'Flower'_EN",
                    "MudLung_EN"
                }
            });
            list1.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "MudLung_EN",
                    "A'Flower'_EN",
                    "A'Flower'_EN"
                }
            });
            list1.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "MudLung_EN",
                    "A'Flower'_EN",
                }
            });
            if (SaltEnemies.trolling > 73)
            {
                list1.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                {
                    "MudLung_EN",
                    "A'Flower'_EN",
                    "MudLung_EN",
                    "Mung_EN"
                }
                });
            }
            list1.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "Mung_EN",
                    "A'Flower'_EN",
                    "MudLung_EN"
                }
            });
            if (SaltEnemies.trolling < 20)
            {
                list1.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                {
                    "MudLung_EN",
                    "A'Flower'_EN",
                    "MudLung_EN",
                    "MudLung_EN"
                }
                });
            }
            if (SaltEnemies.trolling > 85)
            {
                list1.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                {
                    "MunglingMudLung_EN",
                    "A'Flower'_EN",
                    "MudLung_EN"
                }
                });
            }
            list1.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "Mung_EN",
                    "A'Flower'_EN",
                    "MudLung_EN",
                    "LostSheep_EN"
                }
            });
            if (SaltEnemies.trolling < 40)
            {
                list1.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                {
                    "Wringle_EN",
                    "MudLung_EN",
                    "MudLung_EN",
                    "A'Flower'_EN"
                }
                });
            }
            list1.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "MudLung_EN",
                    "A'Flower'_EN",
                    "Spoggle_Spitfire_EN"
                }
            });
            if (SaltEnemies.trolling > 5 && SaltEnemies.trolling < 55)
            {
                list1.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                {
                    "MudLung_EN",
                    "A'Flower'_EN",
                    "JumbleGuts_Waning_EN"
                }
                });
            }
            if (SaltEnemies.trolling > 93)
            {
                list1.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                {
                    "MudLung_EN",
                    "A'Flower'_EN",
                    "Spoggle_Ruminating_EN"
                }
                });
            }
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_MudLung_Medium_EnemyBundle"))._enemyBundles = list1.ToArray();
            //Debug.Log("mud lung med");
            List<RandomEnemyGroup> list2 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Voboola_Hard_EnemyBundle"))._enemyBundles);
            list2.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "A'Flower'_EN",
                    "Voboola_EN"
                }
            });
            list2.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "A'Flower'_EN",
                    "Voboola_EN",
                    "MudLung_EN"
                }
            });
            if (SaltEnemies.trolling == 57)
            {
                list2.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                {
                    "A'Flower'_EN",
                    "Voboola_EN",
                    "Flarb_EN"
                }
                });
            }
            if (SaltEnemies.trolling > 55)
            {
                list2.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                {
                    "A'Flower'_EN",
                    "Voboola_EN",
                    "MunglingMudLung_EN"
                }
                });
            }
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Voboola_Hard_EnemyBundle"))._enemyBundles = list2.ToArray();
            //Debug.Log("voboola");
            List<RandomEnemyGroup> list3 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Spoggle_Spitfire_Medium_EnemyBundle"))._enemyBundles);
            if (SaltEnemies.trolling > 73)
            {
                list3.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                {
                    "Spoggle_Ruminating_EN",
                    "Spoggle_Spitfire_EN",
                    "A'Flower'_EN",
                }
                });
            }
            list3.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "MudLung_EN",
                    "Spoggle_Spitfire_EN",
                    "A'Flower'_EN",
                }
            });
            if (SaltEnemies.trolling > 48 && SaltEnemies.trolling < 77)
            {
                list3.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                {
                    "FlaMinGoa_EN",
                    "Spoggle_Spitfire_EN",
                    "A'Flower'_EN",
                }
                });
            }
            list3.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "Flarblet_EN",
                    "Spoggle_Spitfire_EN",
                    "A'Flower'_EN",
                }
            });
            list3.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "Spoggle_Spitfire_EN",
                    "A'Flower'_EN",
                    "DeadPixel_EN",
                    "DeadPixel_EN"
                }
            });
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Spoggle_Spitfire_Medium_EnemyBundle"))._enemyBundles = list3.ToArray();
            List<RandomEnemyGroup> list33 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Spoggle_Ruminating_Medium_EnemyBundle"))._enemyBundles);
            if (SaltEnemies.trolling < 11)
            {
                list33.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                {
                    "Spoggle_Ruminating_EN",
                    "Spoggle_Spitfire_EN",
                    "A'Flower'_EN",
                }
                });
            }
            list33.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "MudLung_EN",
                    "Spoggle_Ruminating_EN",
                    "A'Flower'_EN",
                }
            });
            list33.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "FlaMinGoa_EN",
                    "Spoggle_Ruminating_EN",
                    "A'Flower'_EN",
                }
            });
            if (SaltEnemies.trolling > 80)
            {
                list33.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                {
                    "Spoggle_Ruminating_EN",
                    "A'Flower'_EN",
                    "Keko_EN",
                    "Keko_EN"
                }
                });
            }
            list33.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "Spoggle_Ruminating_EN",
                    "A'Flower'_EN",
                    "Flarblet_EN"
                }
            });
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Spoggle_Ruminating_Medium_EnemyBundle"))._enemyBundles = list33.ToArray();
            //Debug.Log("spogg");
            List<RandomEnemyGroup> list6 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_JumbleGuts_Clotted_Medium_EnemyBundle"))._enemyBundles);
            list6.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "JumbleGuts_Clotted_EN",
                    "JumbleGuts_Waning_EN",
                    "A'Flower'_EN",
                }
            });
            if (SaltEnemies.trolling >= 35)
            {
                list6.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                {
                    "JumbleGuts_Clotted_EN",
                    "Flarblet_EN",
                    "Flarblet_EN",
                    "A'Flower'_EN",
                }
                });
            }
            if (SaltEnemies.trolling >= 65)
            {
                list6.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                {
                    "JumbleGuts_Clotted_EN",
                    "JumbleGuts_Waning_EN",
                    "JumbleGuts_Waning_EN",
                    "A'Flower'_EN",
                }
                });
            }
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_JumbleGuts_Clotted_Medium_EnemyBundle"))._enemyBundles = list6.ToArray();
            List<RandomEnemyGroup> list69 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_JumbleGuts_Waning_Medium_EnemyBundle"))._enemyBundles);
            list69.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "MudLung_EN",
                    "JumbleGuts_Waning_EN",
                    "A'Flower'_EN",
                }
            });
            list69.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "MunglingMudLung_EN",
                    "JumbleGuts_Waning_EN",
                    "A'Flower'_EN",
                }
            });
            list69.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "Mung_EN",
                    "MudLung_EN",
                    "JumbleGuts_Waning_EN",
                    "A'Flower'_EN",
                }
            });
            if (SaltEnemies.trolling > 49 && SaltEnemies.trolling < 89)
            {
                list69.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                {
                    "MudLung_EN",
                    "MudLung_EN",
                    "JumbleGuts_Waning_EN",
                    "A'Flower'_EN",
                }
                });
            }
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_JumbleGuts_Waning_Medium_EnemyBundle"))._enemyBundles = list69.ToArray();

            List<RandomEnemyGroup> list5 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Flarb_Hard_EnemyBundle"))._enemyBundles);
            list5.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "Flarb_EN",
                    "A'Flower'_EN",
                }
            });
            list5.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "Flarb_EN",
                    "Flarblet_EN",
                    "A'Flower'_EN",
                }
            });
            list5.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "Flarb_EN",
                    "MudLung_EN",
                    "A'Flower'_EN",
                }
            });
            if (SaltEnemies.trolling < 43)
            {
                list5.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                {
                    "Flarb_EN",
                    "JumbleGuts_Waning_EN",
                    "A'Flower'_EN",
                }
                });
            }
            if (SaltEnemies.trolling > 77)
            {
                list5.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                {
                    "Flarb_EN",
                    "Spoggle_Ruminating_EN",
                    "A'Flower'_EN",
                    "Flarblet_EN"
                }
                });
            }
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Flarb_Hard_EnemyBundle"))._enemyBundles = list5.ToArray();
            List<RandomEnemyGroup> list7 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_MunglingMudLung_Medium_EnemyBundle"))._enemyBundles);
            if (SaltEnemies.trolling > 25)
            {
                list7.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                {
                    "A'Flower'_EN",
                    "MudLung_EN",
                    "MunglingMudLung_EN",
                }
                });
            }
            list7.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "A'Flower'_EN",
                    "JumbleGuts_Waning_EN",
                    "MunglingMudLung_EN",
                }
            });
            list7.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "A'Flower'_EN",
                    "Spoggle_Spitfire_EN",
                    "MunglingMudLung_EN",
                }
            });
            list7.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "A'Flower'_EN",
                    "Spoggle_Ruminating_EN",
                    "MunglingMudLung_EN",
                }
            });
            if (SaltEnemies.trolling < 88 & SaltEnemies.trolling > 18)
            {
                list7.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                {
                    "A'Flower'_EN",
                    "FlaMinGoa_EN",
                    "MunglingMudLung_EN",
                }
                });
            }
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_MunglingMudLung_Medium_EnemyBundle"))._enemyBundles = list7.ToArray();
            List<RandomEnemyGroup> list8 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Keko_Medium_EnemyBundle"))._enemyBundles);
            list8.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "A'Flower'_EN",
                    "Keko_EN",
                    "Keko_EN",
                }
            });
            list8.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "A'Flower'_EN",
                    "Keko_EN",
                    "Keko_EN",
                    "Keko_EN"
                }
            });
            if (SaltEnemies.trolling < 60)
            {
                list8.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                {
                    "A'Flower'_EN",
                    "Keko_EN",
                    "Keko_EN",
                    "MudLung_EN"
                }
                });
            }
            if (SaltEnemies.trolling > 40)
            {
                list8.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                {
                    "A'Flower'_EN",
                    "Keko_EN",
                    "Keko_EN",
                    "Spoggle_Ruminating_EN"
                }
                });
            }
            list8.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "A'Flower'_EN",
                    "Keko_EN",
                    "Keko_EN",
                    "LostSheep_EN"
                }
            });
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Keko_Medium_EnemyBundle"))._enemyBundles = list8.ToArray();
            List<RandomEnemyGroup> list9 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Kekastle_Hard_EnemyBundle"))._enemyBundles);
            list9.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                    "Kekastle_EN",
                    "A'Flower'_EN"
                }
            });
            if (SaltEnemies.trolling < 90 && SaltEnemies.trolling > 10)
            {
                list9.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                {
                    "Kekastle_EN",
                    "A'Flower'_EN",
                    "LostSheep_EN"
                }
                });
            }
            if (SaltEnemies.trolling == 6)
            {
                list9.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                {
                    "Kekastle_EN",
                    "A'Flower'_EN",
                    "Flarb_EN"
                }
                });
            }
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Kekastle_Hard_EnemyBundle"))._enemyBundles = list9.ToArray();

            if (DoDebugs.GenInfo) Debug.Log("Flower Far Shore Encounters Set!");
        }
    }
    public static class FlowerEncountersTairPeep
    {
        public static void Add()
        {
            if (EnemyExist("DrySimian_EN") && BundleRandom("Simianh"))
            {
                List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Simianh"))._enemyBundles);
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "DrySimian_EN",
                    "A'Flower'_EN"
                    }
                });
                if (SaltEnemies.trolling > 44)
                {
                    list.Add(new RandomEnemyGroup
                    {
                        _enemyNames = new string[]
                    {
                    "DrySimian_EN",
                    "A'Flower'_EN",
                    "Wringle_EN"
                    }
                    });
                }
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Simianh"))._enemyBundles = list.ToArray();
            }
            if (MultiENExist("Unflarb_EN", "Flarbleft_EN") && BundleRandom("unflarb1"))
            {
                List<RandomEnemyGroup> list1 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("unflarb1"))._enemyBundles);
                list1.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "Unflarb_EN",
                    "A'Flower'_EN",
                    "Flarbleft_EN"
                    }
                });
                if (SaltEnemies.trolling < 76)
                {
                    list1.Add(new RandomEnemyGroup
                    {
                        _enemyNames = new string[]
                    {
                    "Unflarb_EN",
                    "A'Flower'_EN",
                    "MunglingMudLung_EN"
                    }
                    });
                }
                list1.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "Unflarb_EN",
                    "A'Flower'_EN",
                    "MudLung_EN"
                    }
                });
                if (SaltEnemies.trolling > 30)
                {
                    list1.Add(new RandomEnemyGroup
                    {
                        _enemyNames = new string[]
                    {
                    "Unflarb_EN",
                    "A'Flower'_EN",
                    "LostSheep_EN",
                    "Flarblet_EN"
                    }
                    });
                }
                if (SaltEnemies.trolling > 58 || SaltEnemies.trolling < 38)
                {
                    list1.Add(new RandomEnemyGroup
                    {
                        _enemyNames = new string[]
                    {
                    "Unflarb_EN",
                    "A'Flower'_EN",
                    "MudLung_EN",
                    "MudLung_EN"
                    }
                    });
                }
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("unflarb1"))._enemyBundles = list1.ToArray();
            }
            if (MultiENExist("Flarbleft_EN", "LipBug_EN"))
            {
                List<RandomEnemyGroup> list69 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_JumbleGuts_Waning_Medium_EnemyBundle"))._enemyBundles);
                if (SaltEnemies.trolling > 69)
                {
                    list69.Add(new RandomEnemyGroup
                    {
                        _enemyNames = new string[]
                    {
                    "MudLung_EN",
                    "JumbleGuts_Waning_EN",
                    "A'Flower'_EN",
                    "Flarbleft_EN"
                    }
                    });
                }
                list69.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "JumbleGuts_Waning_EN",
                    "A'Flower'_EN",
                    "LipBug_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_JumbleGuts_Waning_Medium_EnemyBundle"))._enemyBundles = list69.ToArray();
            }
            if (DoDebugs.GenInfo) Debug.Log("Far Shore Encounters Set!");


        }
    }
    public static class FlowerEncountersTaco
    {
        public static void Add()
        {
            if (EnemyExist("Monck_EN") && BundleStatic("Monck_Primary_Hard"))
            {
                List<SpecificEnemyGroup> list = new List<SpecificEnemyGroup>(((SpecificEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Monck_Primary_Hard"))._enemyBundles);
                list.Add(new SpecificEnemyGroup
                {
                    _enemyGroup = new SpecificEnemyInfo[]
                    {
                    new SpecificEnemyInfo
                    { enemyName = "Monck_EN",
                    enemySlot = 3 },
                    new SpecificEnemyInfo
                    { enemyName = "A'Flower'_EN",
                    enemySlot = 2 }
                    }
                });
                if (SaltEnemies.trolling < 77)
                {
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
                    { enemyName = "A'Flower'_EN",
                    enemySlot = 2 }
                    }
                    });
                }
                list.Add(new SpecificEnemyGroup
                {
                    _enemyGroup = new SpecificEnemyInfo[]
                    {
                    new SpecificEnemyInfo
                    { enemyName = "Monck_EN",
                    enemySlot = 4 },
                    new SpecificEnemyInfo
                    { enemyName = "MudLung_EN",
                    enemySlot = 3 },
                    new SpecificEnemyInfo
                    { enemyName = "A'Flower'_EN",
                    enemySlot = 2 }
                    }
                });
                list.Add(new SpecificEnemyGroup
                {
                    _enemyGroup = new SpecificEnemyInfo[]
                    {
                    new SpecificEnemyInfo
                    { enemyName = "Mung_EN",
                    enemySlot = 3 },
                    new SpecificEnemyInfo
                    { enemyName = "Monck_EN",
                    enemySlot = 0 },
                    new SpecificEnemyInfo
                    { enemyName = "A'Flower'_EN",
                    enemySlot = 1 }
                    }
                });
                ((SpecificEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Monck_Primary_Hard"))._enemyBundles = list.ToArray();
            }
            else if (EnemyExist("Monck_EN") && BundleRandom("Monck_Primary_Hard"))
            {
                List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Monck_Primary_Hard"))._enemyBundles);
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Monck_EN",
                        "A'Flower'_EN",
                    }
                });
                if (SaltEnemies.trolling < 77)
                {
                    list.Add(new RandomEnemyGroup
                    {
                        _enemyNames = new string[]
                        {
                            "Monck_EN",
                            "Monck_EN",
                            "A'Flower'_EN",
                        }
                    });
                }
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Monck_EN",
                        "MudLung_EN",
                        "A'Flower'_EN",
                    }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Mung_EN",
                        "Monck_EN",
                        "A'Flower'_EN",
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Monck_Primary_Hard"))._enemyBundles = list.ToArray();
            }
            if (EnemyExist("Disembodied_EN") && BundleStatic("Disembodied_Primary_Hard"))
            {
                List<SpecificEnemyGroup> list4 = new List<SpecificEnemyGroup>(((SpecificEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Disembodied_Primary_Hard"))._enemyBundles);
                if (SaltEnemies.trolling > 33 && SaltEnemies.trolling < 77)
                {
                    list4.Add(new SpecificEnemyGroup
                    {
                        _enemyGroup = new SpecificEnemyInfo[]
                    {
                    new SpecificEnemyInfo
                    { enemyName = "Disembodied_EN",
                    enemySlot = 1 },
                    new SpecificEnemyInfo
                    { enemyName = "A'Flower'_EN",
                    enemySlot = 0 },
                    new SpecificEnemyInfo
                    { enemyName = "Mung_EN",
                    enemySlot = 4 }
                    }
                    });
                }
                list4.Add(new SpecificEnemyGroup
                {
                    _enemyGroup = new SpecificEnemyInfo[]
                    {
                    new SpecificEnemyInfo
                    { enemyName = "Disembodied_EN",
                    enemySlot = 2 },
                    new SpecificEnemyInfo
                    { enemyName = "A'Flower'_EN",
                    enemySlot = 1 },
                    new SpecificEnemyInfo
                    { enemyName = "MudLung_EN",
                    enemySlot = 4 }
                    }
                });
                ((SpecificEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Disembodied_Primary_Hard"))._enemyBundles = list4.ToArray();
            }
            if (DoDebugs.GenInfo) Debug.Log("Far Shore Encounters Set1");
        }
    }
    public static class FlowerEncountersBoth
    {
        public static void Add()
        {
            if (MultiENExist("Monck_EN", "Flarbleft_EN") && BundleStatic("Monck_Primary_Medium"))
            {
                List<SpecificEnemyGroup> list = new List<SpecificEnemyGroup>(((SpecificEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Monck_Primary_Medium"))._enemyBundles);
                list.Add(new SpecificEnemyGroup
                {
                    _enemyGroup = new SpecificEnemyInfo[]
                    {
                    new SpecificEnemyInfo
                    { enemyName = "Monck_EN",
                    enemySlot = 3 },
                    new SpecificEnemyInfo
                    { enemyName = "A'Flower'_EN",
                    enemySlot = 2 },
                    new SpecificEnemyInfo
                    { enemyName = "Flarbleft_EN",
                    enemySlot = 0 }
                    }
                });
                ((SpecificEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Monck_Primary_Medium"))._enemyBundles = list.ToArray();
            }
            else if (MultiENExist("Monck_EN", "Flarbleft_EN") && BundleRandom("Monck_Primary_Medium"))
            {
                List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Monck_Primary_Medium"))._enemyBundles);
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Monck_EN",
                        "A'Flower'_EN",
                        "Flarbleft_EN",
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Monck_Primary_Medium"))._enemyBundles = list.ToArray();
            }
            if (MultiENExist("Flarbleft_EN", "Disembodied_EN") && BundleStatic("Disembodied_Primary_Hard"))
            {
                List<SpecificEnemyGroup> list4 = new List<SpecificEnemyGroup>(((SpecificEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Disembodied_Primary_Hard"))._enemyBundles);
                if (SaltEnemies.trolling > 46)
                {
                    list4.Add(new SpecificEnemyGroup
                    {
                        _enemyGroup = new SpecificEnemyInfo[]
                    {
                    new SpecificEnemyInfo
                    { enemyName = "Disembodied_EN",
                    enemySlot = 2 },
                    new SpecificEnemyInfo
                    { enemyName = "A'Flower'_EN",
                    enemySlot = 0 },
                    new SpecificEnemyInfo
                    { enemyName = "Flarbleft_EN",
                    enemySlot = 3 },
                    new SpecificEnemyInfo
                    { enemyName = "Flarbleft_EN",
                    enemySlot = 1 }
                    }
                    });
                }
                ((SpecificEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Disembodied_Primary_Hard"))._enemyBundles = list4.ToArray();
            }
            if (DoDebugs.GenInfo) Debug.Log("Far Shore Encounters Set!");
            if (DoDebugs.MiscInfo) Debug.Log("was i supposed to capitalize this");
        }
    }
}

