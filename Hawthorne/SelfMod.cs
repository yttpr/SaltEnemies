﻿using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using static Hawthorne.Check;

namespace Hawthorne
{
    public static class SaltMod
    {
        public static void TemplateRandom()
        {
            string bundle = "H_Zone03_SkinningHomunculus_Medium_EnemyBundle";
            string main = "SkinningHomunculus_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            if (EnemyExist("Satyr_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Satyr_EN",
                        main,
                        "ShiveringHomunculus_EN",
                    }
                });
            }
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void TemplateDouble()
        {
            string bundle = "Monck_Primary_Easy";
            string main = "Monck_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle)) return;
            List<SpecificEnemyGroup> list = new List<SpecificEnemyGroup>();
            if (EnemyExist("LostSheep_EN") && Half)
            {
                list.Add(new SpecificEnemyGroup
                {
                    _enemyGroup = new SpecificEnemyInfo[]
                    {
                        new SpecificEnemyInfo
                        {
                            enemyName = "LostSheep_EN",
                            enemySlot = 2,
                        },
                        new SpecificEnemyInfo
                        {
                            enemyName = main,
                            enemySlot = 0
                        },
                    }
                });
            }

            if (BundleStatic(bundle))
            {
                List<SpecificEnemyGroup> lost = new List<SpecificEnemyGroup>(((SpecificEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
                foreach (SpecificEnemyGroup group in list)
                {
                    lost.Add(group);
                }
                lost.CheckEncounters();
                ((SpecificEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = lost.ToArray();
                if (DoDebugs.GenInfo) Debug.Log("Modified static " + bundle);
            }
            else if (BundleRandom(bundle))
            {
                List<RandomEnemyGroup> lost = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
                foreach (RandomEnemyGroup group in list.ToRandomGroup())
                {
                    lost.Add(group);
                }
                lost.CheckEncounters();
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = lost.ToArray();
                if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
            }
        }

        public static void PixelShore()
        {
            string bundle = "Pixel_Shore";
            string main = "DeadPixel_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            if (EnemyExist("DeadPixel_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        main,
                        main,
                        "MudLung_EN",
                    }
                });
            }
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void PixelOrph()
        {
            string bundle = "Pixel_Orph";
            string main = "DeadPixel_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            if (EnemyExist("DeadPixel_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        main,
                        main,
                        "MusicMan_EN",
                        "MusicMan_EN"
                    }
                });
            }
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void EnigmaOrph()
        {
            string bundle = "Enigma_Orph";
            string main = "Enigma_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            if (EnemyExist("Enigma_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        main,
                        main,
                        "MusicMan_EN",
                        "MusicMan_EN"
                    }
                });
            }
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void AnglerMed()
        {
            string bundle = "AnglerfishShoreMed";
            string main = "A'Flower'_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            if (EnemyExist("MudLung_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "MudLung_EN",
                        main,
                        RandomColor(0),
                    }
                });
            }
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void AnglerHard()
        {
            string bundle = "AnglerfishShoreHard";
            string main = "A'Flower'_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            if (EnemyExist("A'Flower'_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        RandomEncounters.Shore.RandomShoreWhore(),
                        main,
                        RandomColor(0),
                    }
                });
            }
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void CameraShore()
        {
            string bundle = "Camera_Hard";
            string main = "MechanicalLens_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            if (EnemyExist("MechanicalLens_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        main,
                        main,
                        RandomEncounters.Shore.RandomShoreWhore(),
                        RandomEncounters.Shore.RandomShoreWhore()
                    }
                });
            }
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void CameraOrph()
        {
            string bundle = "CameraOrph";
            string main = "MechanicalLens_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            if (EnemyExist("FesteringMusicMan_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "FesteringMusicMan_EN",
                        main,
                        Half ? RandomSupport(1, false, false) : main,
                        Half ? RandomOrph : RandomColor(1)
                    }
                });
            }
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void CameraGard()
        {
            string bundle = "CameraGarden";
            string main = "MechanicalLens_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            if (EnemyExist("Evangelists_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        main,
                        main,
                        "GigglingMinister_EN",
                        "Evangelists_EN",
                        RandomSupport(2, false, false)
                    }
                });
            }
            if (EnemyExist("Indicator_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        main,
                        main,
                        Half ? "GigglingMinister_EN" : "SkinningHomunculus_EN",
                        "Indicator_EN",
                        "Indicator_EN"
                    }
                });
            }
            if (EnemyExist("Maw_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        main,
                        main,
                        "Maw_EN",
                        "InHisImage_EN",
                        "InHerImage_EN"
                    }
                });
            }
            if (EnemyExist("BlackStar_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        main,
                        main,
                        "BlackStar_EN",
                        "SkinningHomunculus_EN",
                    }
                });
            }
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void CrowOrphMed()
        {
            string bundle = "CrowOrpheumMed";
            string main = "TheCrow_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            if (EnemyExist("FesteringMusicMan_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "FesteringMusicMan_EN",
                        main,
                        RandomSupport(1)
                    }
                });
            }
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void CrowOrphHard()
        {
            string bundle = "CrowOrpheumHard";
            string main = "TheCrow_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            if (EnemyExist("FesteringMusicMan_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "FesteringMusicMan_EN",
                        main,
                        RandomSupport(1, false, false),
                        RandomOrph
                    }
                });
            }
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void CrowGard()
        {
            string bundle = "CrowGardenHard";
            string main = "TheCrow_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            if (EnemyExist("Evangelists_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "SkinningHomunculus_EN",
                        main,
                        "Evangelists_EN",
                        "ShiveringHomunculus_EN"
                    }
                });
            }
            if (EnemyExist("Windle3_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "GigglingMinister_EN",
                        main,
                        "Windle3_EN",
                    }
                });
            }
            if (EnemyExist("BlackStar_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "BlackStar_EN",
                        main,
                        "InHisImage_EN",
                        "InHerImage_EN"
                    }
                });
            }
            if (EnemyExist("Maw_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Maw_EN",
                        main,
                        "GigglingMinister_EN",
                    }
                });
            }
            if (EnemyExist("Indicator_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Indicator_EN",
                        main,
                        "InHisImage_EN",
                        "InHerImage_EN"
                    }
                });
            }
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void SatyrHard()
        {
            string bundle = "Satyr_Hard";
            string main = "Satyr_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            if (EnemyExist("Evangelists_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Evangelists_EN",
                        main,
                        "InHerImage_EN",
                        "InHerImage_EN"
                    }
                });
            }
            if (EnemyExist("BlackStar_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "BlackStar_EN",
                        main,
                        "InHerImage_EN",
                        "InHerImage_EN"
                    }
                });
            }
            if (EnemyExist("Indicator_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Indicator_EN",
                        main,
                        "InHerImage_EN",
                        "InHerImage_EN"
                    }
                });
            }
            if (EnemyExist("Maw_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Maw_EN",
                        main,
                        "SkinningHomunculus_EN",
                        "ShiveringHomunculus_EN"
                    }
                });
            }
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void UnmungShore()
        {
            string bundle = "UnMung_Hard";
            string main = "TeachaMantoFish_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            if (EnemyExist("Monck_EN") && Trolling(2))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Monck_EN",
                        main,
                    }
                });
            }
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void UnmungGard()
        {
            string bundle = "UnMungGarden";
            string main = "TeachaMantoFish_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            if (EnemyExist("Satyr_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Satyr_EN",
                        main,
                    }
                });
            }
            if (EnemyExist("Maw_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Maw_EN",
                        main,
                        "Maw_EN",
                    }
                });
            }
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void SomethingMed()
        {
            string bundle = "SomethingOrpheumMed";
            string main = "Something_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            if (EnemyExist("FesteringMusicMan_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "FesteringMusicMan_EN",
                        main,
                        RandomOrph,
                    }
                });
            }
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void SomethingHard()
        {
            string bundle = "SomethingOrpheumHard";
            string main = "Something_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            if (EnemyExist("FesteringMusicMan_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "FesteringMusicMan_EN",
                        main,
                        RandomOrph,
                        RandomSupport(1, false, false)
                    }
                });
            }
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void FreudOrph()
        {
            string bundle = "DontTouchMe_Hard";
            string main = "Freud_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            if (EnemyExist("FesteringMusicMan_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "FesteringMusicMan_EN",
                        main,
                        Half ? RandomColor(1) : RandomSupport(1, false, false),
                        RandomSupport(1, false, false)
                    }
                });
            }
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void FreudGard()
        {
            string bundle = "FreudMedium";
            string main = "Freud_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            if (EnemyExist("Evangelists_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "InHerImage_EN",
                        main,
                        "InHerImage_EN",
                        "Evangelists_EN"
                    }
                });
            }
            if (EnemyExist("BlackStar_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "BlackStar_EN",
                        main,
                        main,
                        "BlackStar_EN"
                    }
                });
            }
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void RusticHard()
        {
            string bundle = "Rust_Hard";
            string main = "RusticJumbleguts_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            if (EnemyExist("Evangelists_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "SkinningHomunculus_EN",
                        main,
                        "Evangelists_EN",
                        "ShiveringHomunculus_EN",
                    }
                });
            }
            if (EnemyExist("BlackStar_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "BlackStar_EN",
                        main,
                        "ChoirBoy_EN",
                        "ShiveringHomunculus_EN",
                    }
                });
            }
            if (EnemyExist("Indicator_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Indicator_EN",
                        main,
                        "GigglingMinister_EN",
                        "SkinningHomunculus_EN",
                    }
                });
            }
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void MortalHard()
        {
            string bundle = "Gospel_Hard";
            string main = "MortalSpoggle_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            if (EnemyExist("Evangelists_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Evangelists_EN",
                        main,
                        "GigglingMinister_EN",
                        "GigglingMinister_EN",
                    }
                });
            }
            if (EnemyExist("Maw_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Maw_EN",
                        main,
                        "SkinningHomunculus_EN",
                        "SkinningHomunculus_EN",
                    }
                });
            }
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void IllusionMed()
        {
            string bundle = "IllusionOrpheumMedium";
            string main = "Illusion_EN";
            string sub = "FakeAngel_EN";
            if (!MultiENExist(main, sub)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            /*if (EnemyExist("Satyr_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Satyr_EN",
                        main,
                        "ShiveringHomunculus_EN",
                    }
                });
            }*/
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void IllusionHard()
        {
            string bundle = "IllusionOrpheumHard";
            string main = "Illusion_EN";
            string sub = "FakeAngel_EN";
            if (!MultiENExist(main, sub)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            /*if (EnemyExist("Satyr_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Satyr_EN",
                        main,
                        "ShiveringHomunculus_EN",
                    }
                });
            }*/
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void IllusionGard()
        {
            string bundle = "IllusionGardenMed";
            string main = "Illusion_EN";
            string sub = "FakeAngel_EN";
            if (!MultiENExist(main, sub)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            if (EnemyExist("BlackStar_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "BlackStar_EN",
                        main,
                        GreyScaleRedSource(true),
                        main,
                        main
                    }
                });
            }
            if (EnemyExist("Indicator_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Indicator_EN",
                        GreyScaleSupport(true),
                        GreyScaleRedSource(true),
                        main,
                        main
                    }
                });
            }
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void PFlowerOrph()
        {
            string bundle = "PurpleFlowerOrpheum";
            string main = "PurpleFlower_EN";
            string sub = "YellowFlower_EN";
            if (!Flowering) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            if (EnemyExist("FesteringMusicMan_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "FesteringMusicMan_EN",
                        main,
                        sub
                    }
                });
            }
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void YFlowerOrph()
        {
            string bundle = "YellowFlowerOrpheum";
            string sub = "PurpleFlower_EN";
            string main = "YellowFlower_EN";
            if (!Flowering) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            if (EnemyExist("FesteringMusicMan_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "FesteringMusicMan_EN",
                        main,
                        sub
                    }
                });
            }
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void PFlowerGard()
        {
            string bundle = "PurpleFlowerGarden";
            string main = "PurpleFlower_EN";
            string sub = "YellowFlower_EN";
            if (!Flowering) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            if (EnemyExist("Evangelists_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Evangelists_EN",
                        main,
                        sub,
                        "GigglingMinister_EN"
                    }
                });
            }
            if (EnemyExist("BlackStar_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "BlackStar_EN",
                        main,
                        "InHerImage_EN",
                        "InHisImage_EN"
                    }
                });
            }
            if (EnemyExist("Indicator_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Indicator_EN",
                        main,
                        "InHerImage_EN",
                        "InHisImage_EN"
                    }
                });
            }
            if (MultiENExist("Indicator_EN", "BlackStar_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Indicator_EN",
                        main,
                        "SkinningHomunculus_EN",
                        "BlackStar_EN"
                    }
                });
            }
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void YFlowerGard()
        {
            string bundle = "YellowFlowerGarden";
            string sub = "PurpleFlower_EN";
            string main = "YellowFlower_EN";
            if (!Flowering) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            if (EnemyExist("Evangelists_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Evangelists_EN",
                        main,
                        sub,
                        "SkinningHomunculus_EN"
                    }
                });
            }
            if (EnemyExist("BlackStar_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "BlackStar_EN",
                        main,
                        "InHerImage_EN",
                        "InHisImage_EN"
                    }
                });
            }
            if (EnemyExist("Indicator_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Indicator_EN",
                        main,
                        "InHerImage_EN",
                        "InHisImage_EN"
                    }
                });
            }
            if (MultiENExist("Indicator_EN", "BlackStar_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Indicator_EN",
                        main,
                        "SkinningHomunculus_EN",
                        "BlackStar_EN"
                    }
                });
            }
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void YFlowerEZ()
        {
            string bundle = "YellowFlowerGardenEasy";
            string sub = "PurpleFlower_EN";
            string main = "YellowFlower_EN";
            if (!Flowering) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            /*if (EnemyExist("Evangelists_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Evangelists_EN",
                        main,
                        RandomOrph,
                        RandomSupport(1)
                    }
                });
            }*/
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void BFlowerGard()
        {
            string bundle = "BLueFlowerGarden";
            string sub = "RedFlower_EN";
            string main = "BlueFlower_EN";
            if (!Flowering) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            if (EnemyExist("Evangelists_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Evangelists_EN",
                        main,
                        sub,
                        "SkinningHomunculus_EN"
                    }
                });
            }
            if (EnemyExist("BlackStar_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "BlackStar_EN",
                        main,
                        "InHerImage_EN",
                        "InHisImage_EN"
                    }
                });
            }
            if (EnemyExist("Indicator_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Indicator_EN",
                        main,
                        sub,
                        "ChoirBoy_EN"
                    }
                });
            }
            if (MultiENExist("Indicator_EN", "BlackStar_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Indicator_EN",
                        main,
                        "SkinningHomunculus_EN",
                        "BlackStar_EN"
                    }
                });
            }
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void RFlowerGard()
        {
            string bundle = "RedFlowerGarden";
            string main = "RedFlower_EN";
            string sub = "BlueFlower_EN";
            if (!Flowering) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            if (EnemyExist("Evangelists_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Evangelists_EN",
                        main,
                        sub,
                        Flowers.Exclude(main).Exclude(sub).GetRandom()
                    }
                });
            }
            if (EnemyExist("BlackStar_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "BlackStar_EN",
                        main,
                        "InHerImage_EN",
                        "InHisImage_EN"
                    }
                });
            }
            if (EnemyExist("Indicator_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Indicator_EN",
                        main,
                        sub,
                        "SkinningHomunculus_EN"
                    }
                });
            }
            if (MultiENExist("Indicator_EN", "BlackStar_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Indicator_EN",
                        main,
                        "ChoirBoy_EN",
                        "BlackStar_EN"
                    }
                });
            }
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void GFlowerGard()
        {
            string bundle = "GreyFlowerGarden";
            string main = "GreyFlower_EN";
            if (!Flowering) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            if (EnemyExist("Evangelists_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Evangelists_EN",
                        main,
                        "InHisImage_EN",
                        "InHerImage_EN"
                    }
                });
            }
            if (EnemyExist("BlackStar_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "BlackStar_EN",
                        main,
                        "InHerImage_EN",
                        "InHerImage_EN",
                        "InHisImage_EN"
                    }
                });
            }
            if (EnemyExist("Indicator_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Indicator_EN",
                        main,
                        "ShiveringHomunculus_EN",
                        "SkinningHomunculus_EN"
                    }
                });
            }
            if (MultiENExist("Indicator_EN", "BlackStar_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Indicator_EN",
                        main,
                        "ChoirBoy_EN",
                        "GigglingMinister_EN",
                        "BlackStar_EN"
                    }
                });
            }
            if (EnemyExist("Maw_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Maw_EN",
                        main,
                        "GigglingMinister_EN",
                        "ChoirBoy_EN"
                    }
                });
            }
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void MiriamHard()
        {
            string bundle = "MiriamMySweetChild";
            string main = "Miriam_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            if (MultiENExist("Merced_EN", "Shua_EN", "Butterfly_EN") && Fifth)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Shua_EN",
                        main,
                        "Merced_EN",
                        "Butterfly_EN"
                    }
                });
            }
            if (MultiENExist("Evangelists_EN", "EyePalm_EN") && Fifth)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Evangelists_EN",
                        main,
                        "Evangelists_EN",
                        "EyePalm_EN"
                    }
                });
            }
            if (EnemyExist("BlackStar_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "BlackStar_EN",
                        main,
                        "BlackStar_EN",
                        "NextOfKin_EN"
                    }
                });
            }
            if (EnemyExist("Indicator_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Indicator_EN",
                        main,
                        RandomSupport(2, false, false),
                        "SkinningHomunculus_EN"
                    }
                });
            }
            if (EnemyExist("Maw_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Maw_EN",
                        main,
                        "GigglingMinister_EN",
                        "GigglingMinister_EN"
                    }
                });
            }
            if (MultiENExist("TitteringPeon_EN", "Indicator_EN") && Third)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Indicator_EN",
                        main,
                        "TitteringPeon_EN",
                        "SkinningHomunculus_EN"
                    }
                });
            }
            if (EnemyExist("Maw_EN") && Flowering && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Maw_EN",
                        main,
                        "RedFlower_EN",
                        "BlueFlower_EN"
                    }
                });
            }
            if (MultiENExist("BlackStar_EN", "Indicator_EN") && Third)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Indicator_EN",
                        main,
                        "BlackStar_EN",
                        "GigglingMinister_EN"
                    }
                });
            }
            if (MultiENExist("SterileBud_EN", "Indicator_EN") && Third)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Indicator_EN",
                        main,
                        "SterileBud_EN",
                        "ChoirBoy_EN"
                    }
                });
            }
            if (MultiENExist("BlackStar_EN", "Harbinger_EN") && Third)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Harbinger_EN",
                        main,
                        "BlackStar_EN",
                        "Harbinger_EN"
                    }
                });
            }
            if (MultiENExist("LivingSolvent_EN", "Indicator_EN") && Quarter)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Indicator_EN",
                        main,
                        "LivingSolvent_EN",
                        "Indicator_EN"
                    }
                });
            }
            if (MultiENExist("WindSong_EN", "Indicator_EN") && Quarter)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "WindSong_EN",
                        main,
                        "Indicator_EN",
                        "SkinningHomunculus_EN"
                    }
                });
            }
            if (MultiENExist("Maw_EN", "Shua_EN") && Quarter)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Maw_EN",
                        main,
                        "Shua_EN",
                        RandomColor(2)
                    }
                });
            }
            if (MultiENExist("BlackStar_EN", "EggKeeper_EN") && Quarter)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "EggKeeper_EN",
                        main,
                        "BlackStar_EN",
                        "SkinningHomunculus_EN"
                    }
                });
            }
            if (MultiENExist("BlackStar_EN", "MiniReaper_EN") && Quarter)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "MiniReaper_EN",
                        main,
                        "BlackStar_EN",
                        "SkinningHomunculus_EN"
                    }
                });
            }
            if (MultiENExist("BlackStar_EN", "EggKeeper_EN", "HowlingAvian_EN") && Fifth)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "EggKeeper_EN",
                        main,
                        "BlackStar_EN",
                        "HowlingAvian_EN"
                    }
                });
            }
            if (MultiENExist("BlackStar_EN", "Harbinger_EN", "WindSong_EN") && Quarter)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "WindSong_EN",
                        main,
                        "BlackStar_EN",
                        "Harbinger_EN"
                    }
                });
            }
            if (MultiENExist("Indicator_EN", "SterileBud_EN", "LivingSolvent_EN") && Fifth)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "SterileBud_EN",
                        main,
                        "Indicator_EN",
                        "LivingSolvent_EN"
                    }
                });
            }
            if (MultiENExist("Maw_EN", "MechanicalLens_EN") && Fifth)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Maw_EN",
                        main,
                        "MechanicalLens_EN",
                        "GigglingMinister_EN"
                    }
                });
            }
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void EyePalmOrph()
        {
            string bundle = "MedamaudeOrpheum";
            string main = "EyePalm_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            if (EnemyExist("FesteringMusicMan_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "FesteringMusicMan_EN",
                        main,
                        main,
                        main
                    }
                });
            }
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void EyePalmGard()
        {
            string bundle = "MedamaudeGarden";
            string main = "EyePalm_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            if (EnemyExist("EyePalm_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "SkinningHomunculus_EN",
                        main,
                        main,
                        main
                    }
                });
            }
            if (EnemyExist("Evangelists_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "ChoirBoy_EN",
                        "Evangelists_EN",
                        main,
                        main
                    }
                });
            }
            if (EnemyExist("BlackStar_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "BlackStar_EN",
                        "InHisImage_EN",
                        "InHerImage_EN",
                        main
                    }
                });
            }
            if (EnemyExist("Indicator_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Indicator_EN",
                        "InHisImage_EN",
                        "InHerImage_EN",
                        main
                    }
                });
            }
            if (MultiENExist("Indicator_EN, BlackStar_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Indicator_EN",
                        "BlackStar_EN",
                        "SkinningHomunculus_EN",
                        main
                    }
                });
            }
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void EyePalmEZ()
        {
            string bundle = "MedamaudeEZGarden";
            string main = "EyePalm_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            if (EnemyExist("EyePalm_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        main,
                        main,
                        main
                    }
                });
            }
            if (EnemyExist("BlackStar_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "BlackStar_EN",
                        main,
                        "InHerImage_EN",
                        main
                    }
                });
            }
            if (MultiENExist("Indicator_EN, BlackStar_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Indicator_EN",
                        "BlackStar_EN",
                        main,
                        main
                    }
                });
            }
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void TankOrph()
        {
            string bundle = "TankOrpheum";
            string main = "RealisticTank_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void TankGard()
        {
            string bundle = "TankGarden";
            string main = "RealisticTank_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            if (EnemyExist("Evangelists_EN") && GreyScale && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Evangelists_EN",
                        main,
                        "FakeAngel_EN",
                        "Illusion_EN"
                    }
                });
            }
            if (MultiENExist("Evangelists_EN", "WindSong_EN") && GreyScale && Quarter)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Evangelists_EN",
                        main,
                        "FakeAngel_EN",
                        "WindSong_EN"
                    }
                });
            }
            if (EnemyExist("BlackStar_EN") && GreyScale)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "BlackStar_EN",
                        main,
                        GreyScaleRedSource(true),
                        "Illusion_EN"
                    }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "BlackStar_EN",
                        main,
                        GreyScaleRedSource(true),
                        GreyScaleSupport(true)
                    }
                });
            }
            if (EnemyExist("Maw_EN") && GreyScale && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Maw_EN",
                        main,
                        GreyScaleRedSource(true),
                        "Illusion_EN"
                    }
                });
            }
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void SigilOrph()
        {
            string bundle = "SigilGorepheum";
            string main = "Sigil_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            if (EnemyExist("FesteringMusicMan_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "FesteringMusicMan_EN",
                        main,
                        Half ? RandomColor(1) : RandomOrph
                    }
                });
            }
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void SigilGard()
        {
            string bundle = "SigilJarden";
            string main = "Sigil_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            if (EnemyExist("EggKeeper_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "SkinningHomunculus_EN",
                        main,
                        "EggKeeper_EN",
                    }
                });
            }
            if (EnemyExist("Evangelists_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "SkinningHomunculus_EN",
                        main,
                        "Evangelists_EN",
                    }
                });
            }
            if (EnemyExist("BlackStar_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "BlackStar_EN",
                        main,
                        "InHisImage_EN",
                        "InHerImage_EN"
                    }
                });
            }
            if (EnemyExist("Indicator_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Indicator_EN",
                        main,
                        "InHisImage_EN",
                        "InHerImage_EN"
                    }
                });
            }
            if (MultiENExist("Indicator_EN", "BlackStar_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Indicator_EN",
                        main,
                        "BlackStar_EN",
                        "SkinningHomunculus_EN"
                    }
                });
            }
            if (MultiENExist("SterileBud_EN", "Indicator_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Indicator_EN",
                        main,
                        "SterileBud_EN",
                        "ChoirBoy_EN"
                    }
                });
            }
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void TortOrph()
        {
            string bundle = "TurtOprheeuhayfgelaygaely";
            string main = "StalwartTortoise_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            if (EnemyExist("FesteringMusicMan_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "FesteringMusicMan_EN",
                        main,
                        RandomOrph
                    }
                });
            }
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void TortGard()
        {
            string bundle = "tortal_JAARRDEEENRRRAAAAGGHGHGHGHGH";
            string main = "StalwartTortoise_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            if (EnemyExist("Evangelists_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Evangelists_EN",
                        main,
                        Half ? RandomSupport(2, false, false) : RandomColor(2),
                    }
                });
            }
            if (EnemyExist("Maw_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Maw_EN",
                        main,
                        Half ? RandomSupport(2, false, false) : RandomColor(2),
                    }
                });
            }
            if (EnemyExist("Maw_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Maw_EN",
                        main,
                        "GigglingMinister_EN",
                    }
                });
            }
            if (MultiENExist("Maw_EN", "BlackStar_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Maw_EN",
                        main,
                        "BlackStar_EN",
                        "BlackStar_EN"
                    }
                });
            }
            if (EnemyExist("BlackStar_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "BlackStar_EN",
                        main,
                        "InHisImage_EN",
                        "InHerImage_EN"
                    }
                });
            }
            if (MultiENExist("BlackStar_EN", "Indicator_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "BlackStar_EN",
                        main,
                        "Indicator_EN",
                        "ChoirBoy_EN"
                    }
                });
            }
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void ClockGard()
        {
            string bundle = "ITSTIME";
            string main = "ClockTower_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            if (EnemyExist("Evangelists_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Evangelists_EN",
                        main,
                        Half ? RandomSupport(2, false, false) : RandomColor(2),
                        RandomSupport(2, false, false)
                    }
                });
            }
            if (MultiENExist("Maw_EN", "Grandfather_EN") && Third)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Maw_EN",
                        main,
                        "Grandfather_EN",
                        RandomSupport(2, false, false)
                    }
                });
            }
            if (EnemyExist("Maw_EN") && Third)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Maw_EN",
                        main,
                        "SkinningHomunculus_EN",
                        RandomSupport(2, false, false)
                    }
                });
            }
            if (MultiENExist("Maw_EN", "BlackStar_EN") && Third)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Maw_EN",
                        main,
                        "GigglingMinister_EN",
                        "BlackStar_EN"
                    }
                });
            }
            if (MultiENExist("Maw_EN", "SterileBud_EN") && Third)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Maw_EN",
                        main,
                        "SterileBud_EN",
                        RandomColor(2)
                    }
                });
            }
            if (MultiENExist("Maw_EN", "Harbinger_EN") && Third)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Maw_EN",
                        main,
                        "Harbinger_EN",
                        "ChoirBoy_EN"
                    }
                });
            }
            if (EnemyExist("Indicator_EN") && Third)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Indicator_EN",
                        main,
                        "InHisImage_EN",
                        "InHerImage_EN",
                        RandomSupport(2, false, false)
                    }
                });
            }
            if (EnemyExist("Indicator_EN") && Third)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Indicator_EN",
                        main,
                        "SkinningHomunculus_EN",
                        "ShiveringHomunculus_EN",
                    }
                });
            }
            if (MultiENExist("Indicator_EN", "ScreamingHomunculus_EN") && Third)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Indicator_EN",
                        main,
                        "SkinningHomunculus_EN",
                        "ShiveringHomunculus_EN",
                        "ScreamingHomunculus_EN"
                    }
                });
            }
            if (MultiENExist("Indicator_EN", "TitteringPeon_EN") && Third)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Indicator_EN",
                        main,
                        "TitteringPeon_EN",
                        "SkinningHomunculus_EN",
                    }
                });
            }
            if (MultiENExist("Indicator_EN", "BlackStar_EN") && Third)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Indicator_EN",
                        main,
                        "BlackStar_EN",
                        "InHisImage_EN",
                        "InHisImage_EN"
                    }
                });
            }
            if (EnemyExist("Indicator_EN") && Third)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Indicator_EN",
                        main,
                        "ChoirBoy_EN",
                        "GigglingMinister_EN",
                    }
                });
            }
            if (MultiENExist("Indicator_EN", "Grandfather_EN") && Third)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Indicator_EN",
                        main,
                        "Grandfather_EN",
                        "SkinningHomunculus_EN",
                    }
                });
            }
            if (EnemyExist("BlackStar_EN") && Third)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "BlackStar_EN",
                        main,
                        "SkinningHomunculus_EN",
                        "ShiveringHomunculus_EN",
                    }
                });
            }
            if (EnemyExist("BlackStar_EN") && Third)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "BlackStar_EN",
                        main,
                        "InHisImage_EN",
                        "InHerImage_EN",
                        RandomSupport(2, false, false)
                    }
                });
            }
            if (MultiENExist("BlackStar_EN", "EggKeeper_EN") && Third)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "BlackStar_EN",
                        main,
                        "SkinningHomunculus_EN",
                        "ShiveringHomunculus_EN",
                        "EggKeeper_EN"
                    }
                });
            }
            if (MultiENExist("BlackStar_EN", "MiniReaper_EN") && Third)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "BlackStar_EN",
                        main,
                        "GigglingMinister_EN",
                        "ShiveringHomunculus_EN",
                        "MiniReaper_EN"
                    }
                });
            }
            if (MultiENExist("BlackStar_EN", "Damocles_EN") && Third)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "BlackStar_EN",
                        main,
                        "Damocles_EN",
                        "SkinningHomunculus_EN",
                    }
                });
            }
            if (MultiENExist("BlackStar_EN", "Enigma_EN") && Third)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "BlackStar_EN",
                        main,
                        "Enigma_EN",
                        "Enigma_EN",
                        "Enigma_EN"
                    }
                });
            }
            if (MultiENExist("BlackStar_EN", "Enigma_EN", "Unterling_EN") && Third)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "BlackStar_EN",
                        main,
                        "Enigma_EN",
                        "Unterling_EN",
                        "GigglingMinister_EN"
                    }
                });
            }
            if (MultiENExist("BlackStar_EN", "Grandfather_EN", "Romantic_EN") && Third)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "BlackStar_EN",
                        main,
                        "Grandfather_EN",
                        "Romantic_EN",
                        "SkinningHomunculus_EN"
                    }
                });
            }
            if (MultiENExist("BlackStar_EN", "Hunter_EN", "Romantic_EN") && Third)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "BlackStar_EN",
                        main,
                        "Hunter_EN",
                        "Romantic_EN",
                        "ShiveringHomunculus_EN"
                    }
                });
            }
            if (EnemyExist("Maw_EN") && GreyScale && Third)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Maw_EN",
                        main,
                        GreyScaleRedSource(true),
                        "Illusion_EN"
                    }
                });
            }
            if (EnemyExist("Maw_EN") && GreyScale && Third)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Maw_EN",
                        main,
                        GreyScaleRedSource(true),
                        "Illusion_EN",
                        GreyScaleSupport(true)
                    }
                });
            }
            if (EnemyExist("Maw_EN") && GreyScale && Third)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Maw_EN",
                        main,
                        GreyScaleRedSource(true),
                        GreyScaleSupport(true)
                    }
                });
            }
            if (EnemyExist("BlackStar_EN") && GreyScale && Third)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "BlackStar_EN",
                        main,
                        GreyScaleRedSource(true),
                        "Illusion_EN"
                    }
                });
            }
            if (EnemyExist("BlackStar_EN") && GreyScale && Third)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "BlackStar_EN",
                        main,
                        GreyScaleRedSource(true),
                        "Illusion_EN",
                        GreyScaleSupport(true)
                    }
                });
            }
            if (EnemyExist("BlackStar_EN") && GreyScale && Third)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "BlackStar_EN",
                        main,
                        GreyScaleRedSource(true),
                        GreyScaleSupport(true)
                    }
                });
            }
            if (MultiENExist("Indicator_EN", "WindSong_EN") && GreyScale && Third)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "BlackStar_EN",
                        main,
                        GreyScaleRedSource(true),
                        "Illusion_EN",
                        "WindSong_EN"
                    }
                });
            }
            if (MultiENExist("Indicator_EN", "LivingSolvent_EN") && GreyScale && Third)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "BlackStar_EN",
                        main,
                        "LivingSolvent_EN",
                        "Illusion_EN",
                        GreyScaleSupport(true)
                    }
                });
            }
            if (MultiENExist("Indicator_EN", "Grandfather_EN") && GreyScale && Third)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "BlackStar_EN",
                        main,
                        "Grandfather_EN",
                        "Illusion_EN",
                        "Illusion_EN"
                    }
                });
            }
            if (MultiENExist("Indicator_EN", "Romantic_EN") && GreyScale && Third)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "BlackStar_EN",
                        main,
                        GreyScaleRedSource(true),
                        "Illusion_EN",
                        "Romantic_EN"
                    }
                });
            }
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void TripodShore()
        {
            string bundle = "tripodfish_hardasfuck_shore";
            string main = "TripodFish_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            /*if (EnemyExist("Evangelists_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Evangelists_EN",
                        main,
                        Half ? RandomOrph : RandomColor(1),
                    }
                });
            }*/
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void TripodGard()
        {
            string bundle = "tripodfish_medium_garden";
            string main = "TripodFish_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            if (EnemyExist("Evangelists_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Evangelists_EN",
                        main,
                        "SkinningHomunculus_EN",
                        "ShiveringHomunculus_EN"
                    }
                });
            }
            if (EnemyExist("BlackStar_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "BlackStar_EN",
                        main,
                        "InHerImage_EN",
                        "InHisImage_EN"
                    }
                });
            }
            if (EnemyExist("BlackStar_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "BlackStar_EN",
                        main,
                        "SkinningHomunculus_EN",
                    }
                });
            }
            if (EnemyExist("Indicator_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Indicator_EN",
                        main,
                        "InHerImage_EN",
                        "InHisImage_EN"
                    }
                });
            }
            if (MultiENExist("BlackStar_EN", "MiniReaper_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "BlackStar_EN",
                        main,
                        "MiniReaper_EN",
                        "ShiveringHomunculus_EN"
                    }
                });
            }
            if (MultiENExist("BlackStar_EN", "SterileBud_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "BlackStar_EN",
                        main,
                        "SterileBud_EN",
                    }
                });
            }
            if (MultiENExist("BlackStar_EN", "Romantic_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "BlackStar_EN",
                        main,
                        "Romantic_EN",
                        "GigglingMinister_EN"
                    }
                });
            }
            if (MultiENExist("Indicator_EN", "Romantic_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Indicator_EN",
                        main,
                        "Romantic_EN",
                        "GigglingMinister_EN"
                    }
                });
            }
            if (MultiENExist("BlackStar_EN", "EggKeeper_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "BlackStar_EN",
                        main,
                        "EggKeeper_EN",
                        "GigglingMinister_EN"
                    }
                });
            }
            if (MultiENExist("Indicator_EN", "TitteringPeon_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Indicator_EN",
                        main,
                        "TitteringPeon_EN",
                        "SkinningHomunculus_EN"
                    }
                });
            }
            if (MultiENExist("BlackStar_EN", "Harbinger_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "BlackStar_EN",
                        main,
                        "Harbinger_EN",
                        "ChoirBoy_EN"
                    }
                });
            }
            if (EnemyExist("BlackStar_EN") && Flowering && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "BlackStar_EN",
                        main,
                        "RedFlower_EN",
                        "YellowFlower_EN"
                    }
                });
            }
            if (MultiENExist("Indicator_EN", "Grandfather_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Indicator_EN",
                        main,
                        "Grandfather_EN",
                        "GigglingMinister_EN"
                    }
                });
            }
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void RabieEZ()
        {
            string bundle = "rabieseasy";
            string main = "Lyssa_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            /*if (EnemyExist("Evangelists_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Evangelists_EN",
                        main,
                        Half ? RandomOrph : RandomColor(1),
                    }
                });
            }*/
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void RabieMed()
        {
            string bundle = "rabiesmedia";
            string main = "Lyssa_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void RabieHard()
        {
            string bundle = "rabiesRRAAAAGHHHHH";
            string main = "Lyssa_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            if (MultiENExist("FesteringMusicMan_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "FesteringMusicMan_EN",
                        main,
                        main,
                        RandomSupport(1, false, false)
                    }
                });
            }
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void ManicTwo()
        {
            string bundle = "ManicMenSecond";
            string main = "ManicMan_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            if (EnemyExist("FesteringMusicMan_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "FesteringMusicMan_EN",
                        main,
                        main,
                        main
                    }
                });
            }
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void SnakeGodHard()
        {
            string bundle = "thesnakegod";
            string main = "SnakeGod_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            if (EnemyExist("Evangelists_EN") && Flowering)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Evangelists_EN",
                        main,
                        "YellowFlower_EN",
                    }
                });
            }
            if (MultiENExist("Indicator_EN", "WindSong_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "WindSong_EN",
                        main,
                        "Indicator_EN",
                    }
                });
            }
            if (MultiENExist("BlackStar_EN", "MiniReaper_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "MiniReaper_EN",
                        main,
                        "BlackStar_EN",
                    }
                });
            }
            if (MultiENExist("Indicator_EN", "Romantic_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Romantic_EN",
                        main,
                        "Indicator_EN",
                    }
                });
            }
            if (MultiENExist("BlackStar_EN", "EggKeeper_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "EggKeeper_EN",
                        main,
                        "BlackStar_EN",
                    }
                });
            }
            if (MultiENExist("Indicator_EN", "ChoirBoy_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "ChoirBoy_EN",
                        main,
                        "Indicator_EN",
                    }
                });
            }
            if (MultiENExist("BlackStar_EN", "MechanicalLens_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "MechanicalLens_EN",
                        main,
                        "BlackStar_EN",
                    }
                });
            }
            if (MultiENExist("Indicator_EN", "Damocles_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Damocles_EN",
                        main,
                        "Indicator_EN",
                    }
                });
            }
            if (MultiENExist("BlackStar_EN", "Hunter_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Hunter_EN",
                        main,
                        "BlackStar_EN",
                    }
                });
            }
            if (MultiENExist("Indicator_EN", "Skyloft_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Skyloft_EN",
                        main,
                        "Indicator_EN",
                    }
                });
            }
            if (MultiENExist("BlackStar_EN", "Sigil_EN") && Flowering && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Sigil_EN",
                        main,
                        "BlackStar_EN",
                        "BlueFlower_EN"
                    }
                });
            }
            if (EnemyExist("Maw_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Maw_EN",
                        main,
                    }
                });
            }
            if (MultiENExist("Maw_EN", "BlackStar_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Maw_EN",
                        main,
                        "BlackStar_EN",
                    }
                });
            }
            if (MultiENExist("Maw_EN", "Romantic_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Maw_EN",
                        main,
                        "Romantic_EN",
                    }
                });
            }
            if (MultiENExist("Maw_EN", "WindSong_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Maw_EN",
                        main,
                        "WindSong_EN",
                    }
                });
            }
            if (EnemyExist("Windle3_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Windle3_EN",
                        main,
                    }
                });
            }
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void HuntOrphMed()
        {
            string bundle = "HunterOrphMed";
            string main = "Hunter_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            if (EnemyExist("FesteringMusicMan_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "FesteringMusicMan_EN",
                        main,
                        RandomSupport(1)
                    }
                });
            }
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void HuntOrphHard()
        {
            string bundle = "HunterOrpheumHard";
            string main = "Hunter_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            if (EnemyExist("FesteringMusicMan_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "FesteringMusicMan_EN",
                        main,
                        RandomSupport(1, false, false),
                        RandomOrph
                    }
                });
            }
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void HuntGard()
        {
            string bundle = "HunterGardenHard";
            string main = "Hunter_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            if (EnemyExist("Evangelists_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "SkinningHomunculus_EN",
                        main,
                        "Evangelists_EN",
                        "Evangelists_EN"
                    }
                });
            }
            if (EnemyExist("Windle3_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "SkinningHomunculus_EN",
                        main,
                        "Windle3_EN",
                    }
                });
            }
            if (EnemyExist("BlackStar_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "BlackStar_EN",
                        main,
                        "InHisImage_EN",
                        "InHerImage_EN"
                    }
                });
            }
            if (EnemyExist("Indicator_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Indicator_EN",
                        main,
                        "InHisImage_EN",
                        "InHerImage_EN"
                    }
                });
            }
            if (EnemyExist("Maw_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Maw_EN",
                        main,
                        "GigglingMinister_EN",
                    }
                });
            }
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void FirebirdMed()
        {
            string bundle = "PheonixMed";
            string main = "Firebird_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            if (EnemyExist("ScreamingHomunculus_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "ScreamingHomunculus_EN",
                        main,
                        "InHerImage_EN",
                        "InHerImage_EN"
                    }
                });
            }
            if (EnemyExist("Evangelists_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Evangelists_EN",
                        main,
                        "GigglingMinister_EN",
                        "ShiveringHomunculus_EN"
                    }
                });
            }
            if (EnemyExist("BlackStar_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "BlackStar_EN",
                        main,
                        "InHerImage_EN",
                        "InHisImage_EN"
                    }
                });
            }
            if (EnemyExist("Indicator_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Indicator_EN",
                        main,
                        "InHerImage_EN",
                        "InHisImage_EN"
                    }
                });
            }
            if (MultiENExist("Indicator_EN", "Romantic_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Indicator_EN",
                        main,
                        "Romantic_EN",
                        "Indicator_EN"
                    }
                });
            }
            if (MultiENExist("BlackStar_EN", "Grandfather_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "BlackStar_EN",
                        main,
                        "Grandfather_EN",
                        RandomColor(2)
                    }
                });
            }
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void FirebirdHard()
        {
            string bundle = "PheonixHard";
            string main = "Firebird_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            if (EnemyExist("ScreamingHomunculus_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "ScreamingHomunculus_EN",
                        main,
                        "ChoirBoy_EN",
                        "NextOfKin_EN"
                    }
                });
            }
            if (EnemyExist("Evangelists_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Evangelists_EN",
                        main,
                        "ChoirBoy_EN",
                        "SkinningHomunculus_EN"
                    }
                });
            }
            if (EnemyExist("BlackStar_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "BlackStar_EN",
                        main,
                        "ChoirBoy_EN",
                        "GigglingMinister_EN"
                    }
                });
            }
            if (EnemyExist("Indicator_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Indicator_EN",
                        main,
                        "ChoirBoy_EN",
                        "SkinningHomunculus_EN"
                    }
                });
            }
            if (MultiENExist("Indicator_EN", "SterileBud_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Indicator_EN",
                        main,
                        "ChoirBoy_EN",
                        "SterileBud_EN"
                    }
                });
            }
            if (MultiENExist("Indicator_EN", "BlackStar_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Indicator_EN",
                        main,
                        "BlackStar_EN",
                        "SkinningHomunculus_EN"
                    }
                });
            }
            if (MultiENExist("Indicator_EN", "Harbinger_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Indicator_EN",
                        main,
                        "ChoirBoy_EN",
                        "Harbinger_EN"
                    }
                });
            }
            if (MultiENExist("MiniReaper_EN", "BlackStar_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "MiniReaper_EN",
                        main,
                        "BlackStar_EN",
                        RandomColor(2)
                    }
                });
            }
            if (MultiENExist("WindSong_EN", "BlackStar_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "WindSong_EN",
                        main,
                        "BlackStar_EN",
                        "BlackStar_EN"
                    }
                });
            }
            if (MultiENExist("EggKeeper_EN", "BlackStar_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "EggKeeper_EN",
                        main,
                        "BlackStar_EN",
                        "GigglingMinister_EN"
                    }
                });
            }
            if (MultiENExist("Maw_EN", "BlackStar_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Maw_EN",
                        main,
                        "BlackStar_EN",
                        "ShiveringHomunculus_EN"
                    }
                });
            }
            if (EnemyExist("Maw_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Maw_EN",
                        main,
                        "ChoirBoy_EN",
                    }
                });
            }
            if (MultiENExist("Maw_EN", "Grandfather_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Maw_EN",
                        main,
                        "Grandfather_EN",
                    }
                });
            }
            if (MultiENExist("Maw_EN", "Romantic_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Maw_EN",
                        main,
                        "Romantic_EN",
                    }
                });
            }
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void BeakShore()
        {
            string bundle = "BeakShoreMed";
            string main = "LittleBeak_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            /*if (EnemyExist("Satyr_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Satyr_EN",
                        main,
                        "ShiveringHomunculus_EN",
                    }
                });
            }*/
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void BeakHard()
        {
            string bundle = "BeakShoreHard";
            string main = "LittleBeak_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            /*if (EnemyExist("Satyr_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Satyr_EN",
                        main,
                        "ShiveringHomunculus_EN",
                    }
                });
            }*/
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void BeakEZ()
        {
            string bundle = "BeakOrphEZPZ";
            string main = "LittleBeak_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            /*if (EnemyExist("Satyr_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Satyr_EN",
                        main,
                        "ShiveringHomunculus_EN",
                    }
                });
            }*/
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void BeakOrph()
        {
            string bundle = "BeakOrphMed";
            string main = "LittleBeak_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void WarShore()
        {
            string bundle = "WarHard";
            string main = "Warbird_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            if (EnemyExist("Windle1_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Windle1_EN",
                        main,
                        "MudLung_EN",
                        RandomEncounters.Shore.RandomShoreWhore()
                    }
                });
            }
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void WarOrph()
        {
            string bundle = "WarMed";
            string main = "Warbird_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            if (EnemyExist("FesteringMusicMan_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "FesteringMusicMan_EN",
                        main,
                        RandomSupport(1),
                        RandomSupport(1, false, false)
                    }
                });
            }
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void WindSongMed()
        {
            string bundle = "SongOfTheWindInTheOrpheum";
            string main = "WindSong_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            if (EnemyExist("FesteringMusicMan_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "FesteringMusicMan_EN",
                        main,
                        Half ? RandomOrph : RandomSupport(1, false, false)
                    }
                });
            }
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void SolventEZ()
        {
            string bundle = "YouShouldExplode...NOW";
            string main = "LivingSolvent_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void SkyloftShore()
        {
            string bundle = "SkyIsABedForMySleepButIDontCareItsGotStarsForNightstands";
            string main = "Skyloft_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            /*if (EnemyExist("ScreamingHomunculus_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "ScreamingHomunculus_EN",
                        main,
                        "ChoirBoy_EN",
                        "NextOfKin_EN"
                    }
                });
            }*/
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void ButterflyEZ()
        {
            string bundle = "SpectralWitchFamiliar";
            string main = "Butterfly_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            /*if (EnemyExist("ScreamingHomunculus_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "ScreamingHomunculus_EN",
                        main,
                        "ChoirBoy_EN",
                        "NextOfKin_EN"
                    }
                });
            }*/
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void GrandfatherGard()
        {
            string bundle = "GETMEOUTOFHERE";
            string main = "Grandfather_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            if (EnemyExist("Evangelists_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Evangelists_EN",
                        main,
                        "InHisImage_EN",
                        "InHisImage_EN"
                    }
                });
            }
            if (EnemyExist("BlackStar_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "BlackStar_EN",
                        main,
                        "ChoirBoy_EN",
                    }
                });
            }
            if (EnemyExist("BlackStar_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "BlackStar_EN",
                        main,
                        "InHerImage_EN",
                        "InHerImage_EN"
                    }
                });
            }
            if (EnemyExist("Indicator_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Indicator_EN",
                        main,
                        "InHisImage_EN",
                        "InHerImage_EN"
                    }
                });
            }
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void ReaperMed()
        {
            string bundle = "DIEDIEDIE";
            string main = "MiniReaper_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            if (EnemyExist("Evangelists_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Evangelists_EN",
                        main,
                        "InHerImage_EN",
                        "InHisImage_EN"
                    }
                });
            }
            if (EnemyExist("Windle3_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Windle3_EN",
                        main,
                        "InHerImage_EN",
                        "InHisImage_EN"
                    }
                });
            }
            if (EnemyExist("BlackStar_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "BlackStar_EN",
                        main,
                        "InHerImage_EN",
                        "InHisImage_EN"
                    }
                });
            }
            if (EnemyExist("Indicator_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Indicator_EN",
                        main,
                        "InHerImage_EN",
                        "InHisImage_EN"
                    }
                });
            }
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void ShuaEZ()
        {
            string bundle = "LeaveMeAlone";
            string main = "Shua_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            if (EnemyExist("Evangelists_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Evangelists_EN",
                        main,
                        "NextOfKin_EN",
                        "NextOfKin_EN"
                    }
                });
            }
            if (EnemyExist("BlackStar_EN"))
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "BlackStar_EN",
                        main,
                        "ShiveringHomunculus_EN",
                        "ShiveringHomunculus_EN"
                    }
                });
            }
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void BlackStarEZ()
        {
            string bundle = "BlameItOnTheBlackStar";
            string main = "BlackStar_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            /*if (EnemyExist("Satyr_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Satyr_EN",
                        main,
                        "ShiveringHomunculus_EN",
                    }
                });
            }*/
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void NerveEZ()
        {
            string bundle = "IndicatorEasy";
            string main = "Indicator_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            /*if (EnemyExist("Satyr_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Satyr_EN",
                        main,
                        "ShiveringHomunculus_EN",
                    }
                });
            }*/
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void NerveMed()
        {
            string bundle = "IndicatorMedium";
            string main = "Indicator_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            /*if (EnemyExist("Satyr_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Satyr_EN",
                        main,
                        "ShiveringHomunculus_EN",
                    }
                });
            }*/
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void MawGard()
        {
            string bundle = "STUPIDDOGIMBALLING";
            string main = "Maw_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            /*if (EnemyExist("Satyr_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Satyr_EN",
                        main,
                        "ShiveringHomunculus_EN",
                    }
                });
            }*/
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void IconoclastTwo()
        {
            string bundle = "Iconoclast_Hard";
            string main = "Iconoclast_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle)) return;
            List<SpecificEnemyGroup> list = new List<SpecificEnemyGroup>();
            /*if (EnemyExist("LostSheep_EN") && Half)
            {
                list.Add(new SpecificEnemyGroup
                {
                    _enemyGroup = new SpecificEnemyInfo[]
                    {
                        new SpecificEnemyInfo
                        {
                            enemyName = "LostSheep_EN",
                            enemySlot = 2,
                        },
                        new SpecificEnemyInfo
                        {
                            enemyName = main,
                            enemySlot = 0
                        },
                    }
                });
            }
            */
            if (BundleStatic(bundle))
            {
                List<SpecificEnemyGroup> lost = new List<SpecificEnemyGroup>(((SpecificEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
                foreach (SpecificEnemyGroup group in list)
                {
                    lost.Add(group);
                }
                lost.CheckEncounters();
                ((SpecificEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = lost.ToArray();
                if (DoDebugs.GenInfo) Debug.Log("Modified static " + bundle);
            }
            else if (BundleRandom(bundle))
            {
                List<RandomEnemyGroup> lost = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
                foreach (RandomEnemyGroup group in list.ToRandomGroup())
                {
                    lost.Add(group);
                }
                lost.CheckEncounters();
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = lost.ToArray();
                if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
            }
        }
        public static void ClioneShoreMed()
        {
            string bundle = "ClioneShoreMed";
            string main = "Clione_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            /*if (EnemyExist("Satyr_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Satyr_EN",
                        main,
                        "ShiveringHomunculus_EN",
                    }
                });
            }*/
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void ClioneShoreH()
        {
            string bundle = "ClioneShoreHard";
            string main = "Clione_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            /*if (EnemyExist("Satyr_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Satyr_EN",
                        main,
                        "ShiveringHomunculus_EN",
                    }
                });
            }*/
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
        public static void ClioneOrph()
        {
            string bundle = "ClioneOrphMed";
            string main = "Clione_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle) || !BundleRandom(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
            /*if (EnemyExist("Satyr_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        "Satyr_EN",
                        main,
                        "ShiveringHomunculus_EN",
                    }
                });
            }*/
            list.CheckEncounters();
            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = list.ToArray();
            if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
        }
    }
}
