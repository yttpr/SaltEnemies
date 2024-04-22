using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using static Hawthorne.Check;
using static Hawthorne.RandomEncounters;

namespace Hawthorne
{
    public static class ModTwo
    {
        public static void TemplateRandom()
        {
            string bundle = "H_Zone03_SkinningHomunculus_Medium_EnemyBundle";
            string main = "SkinningHomunculus_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>();
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
            if (BundleRandom(bundle))
            {
                List<RandomEnemyGroup> yad = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
                foreach (RandomEnemyGroup g in list) yad.Add(g);
                yad.CheckEncounters();
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = yad.ToArray();
                if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
            }
            else if (BundleStatic(bundle))
            {
                List<SpecificEnemyGroup> yod = new List<SpecificEnemyGroup>(((SpecificEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
                foreach (SpecificEnemyGroup g in list.ToSpecificGroup()) yod.Add(g);
                yod.CheckEncounters();
                ((SpecificEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = yod.ToArray();
                if (DoDebugs.GenInfo) Debug.Log("Modified static " + bundle);
            }
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


        public static void NosestoneTemplateMed(string bundle, string main)
        {
            if (!Nosing) return;
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>();
            for (int i = 0; i < 3; i++)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        main,
                        Either("InHerImage_EN", "InHisImage_EN"),
                        Either("InHerImage_EN", "InHisImage_EN"),
                        RandomSupport(2, false, false),
                    }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        main,
                        Garden.RandomChunk(true),
                        Garden.RandomChunk(false, true),
                        RandomSupport(2, false, false),
                    }
                });
                bool a = Half;
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        main,
                        Garden.RandomChunk(a),
                        RandomSupport(2, !a, false),
                        RandomSupport(2, false, false),
                    }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        main,
                        Garden.RandomChunk(true),
                        Garden.RandomChunk(false, true),
                    }
                });
                bool b = Half;
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        main,
                        Garden.RandomChunk(b),
                        Garden.RandomWhore(!b),
                    }
                });
                bool c = Half;
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        main,
                        Garden.RandomWhore(c),
                        RandomSupport(2, !c, false)
                    }
                });
            }
            list.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                        main,
                        Either(Garden.RandomChunk(), RandomSupport(2, false, false)),
                        Garden.RandomTwoSizeFag()
                }
            });
            if (EnemyExist("DeadPixel_EN") && Half)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        main,
                        Either(Garden.RandomChunk(), Garden.RandomWhore()),
                        "DeadPixel_EN",
                        "DeadPixel_EN"
                    }
                });
            }
            if (BundleRandom(bundle))
            {
                List<RandomEnemyGroup> yad = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
                foreach (RandomEnemyGroup g in list) yad.Add(g);
                yad.CheckEncounters();
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = yad.ToArray();
                if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
            }
            else if (BundleStatic(bundle))
            {
                List<SpecificEnemyGroup> yod = new List<SpecificEnemyGroup>(((SpecificEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
                foreach (SpecificEnemyGroup g in list.ToSpecificGroup()) yod.Add(g);
                yod.CheckEncounters();
                ((SpecificEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = yod.ToArray();
                if (DoDebugs.GenInfo) Debug.Log("Modified static " + bundle);
            }
        }
        public static void NosestoneTemplateHard(string bundle, string main)
        {
            if (!Nosing) return;
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>();
            for (int i = 0; i < 3; i++)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        main,
                        Garden.RandomChunk(true),
                        Garden.RandomWhore(),
                        Either(RandomSupport(2, false, false), Noses.Exclude(main).GetRandom())
                    }
                });
                bool a = Half;
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        main,
                        Garden.RandomChunk(a),
                        RandomSupport(2, !a, false),
                        Noses.Exclude(main).GetRandom()
                    }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        main,
                        Garden.RandomChunk(true),
                        Garden.RandomChunk(false, true),
                        Either(Garden.RandomChunk(), RandomSupport(2, false, false))
                    }
                });
                bool b = Half;
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        main,
                        Garden.RandomChunk(b),
                        Garden.RandomChunk(false, true),
                        Garden.RandomWhore(!b),
                    }
                });
                bool c = Half;
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        main,
                        Garden.RandomWhore(c),
                        Garden.RandomWhore(),
                        RandomSupport(2, !c, false)
                    }
                });
            }
            list.Add(new RandomEnemyGroup
            {
                _enemyNames = new string[]
                {
                        main,
                        Garden.RandomChunk(),
                        Either(Garden.RandomChunk(false, true), RandomSupport(2, false, false)),
                        Garden.RandomTwoSizeFag()
                }
            });
            if (BundleRandom(bundle))
            {
                List<RandomEnemyGroup> yad = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
                foreach (RandomEnemyGroup g in list) yad.Add(g);
                yad.CheckEncounters();
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = yad.ToArray();
                if (DoDebugs.GenInfo) Debug.Log("Modified random " + bundle);
            }
            else if (BundleStatic(bundle))
            {
                List<SpecificEnemyGroup> yod = new List<SpecificEnemyGroup>(((SpecificEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles);
                foreach (SpecificEnemyGroup g in list.ToSpecificGroup()) yod.Add(g);
                yod.CheckEncounters();
                ((SpecificEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle(bundle))._enemyBundles = yod.ToArray();
                if (DoDebugs.GenInfo) Debug.Log("Modified static " + bundle);
            }
        }
    }
}
