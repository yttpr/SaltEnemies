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
        public static void DancerEZ()
        {
            string bundle = "cha cha real smooth";
            string main = "BackupDancer_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>();
            for (int i = 0; i < 3; i++)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        RandomOrph,
                        main,
                        "MusicMan_EN",
                    }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        RandomColor(1),
                        main,
                        "MusicMan_EN",
                    }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        RandomColor(1),
                        "MusicMan_EN",
                        main,
                        RandomSupport(1, false, false),
                    }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        RandomOrph,
                        main,
                        RandomOrph,
                    }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        RandomOrph,
                        main,
                        RandomColor(1),
                    }
                });
            }
            for (int i = 0; i < 20; i++)
            {
                list.Add(Orpheum.GuyGroup(main, 0, false));
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
        public static void DancerMed()
        {
            string bundle = "im so full of tumors yum";
            string main = "BackupDancer_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>();
            for (int i = 0; i < 3; i++)
            {
                string c = RandomOrph;
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        c,
                        main,
                        Either(c, RandomOrph),
                    }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        RandomColor(1),
                        main,
                        RandomOrph,
                    }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        RandomColor(1),
                        RandomOrph,
                        main,
                        RandomSupport(1, false, false),
                    }
                });
                string b = RandomOrph;
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        b,
                        main,
                        Either(b, RandomOrph),
                        RandomColor(1)
                    }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        RandomOrph,
                        main,
                        RandomColor(1),
                        RandomSupport(1, false, false)
                    }
                });
                string a = RandomOrph;
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        a,
                        main,
                        Either(a, RandomOrph),
                        RandomSupport(1, false, false)
                    }
                });
            }
            for (int i = 0; i < 20; i++)
            {
                list.Add(Orpheum.GuyGroup(main, 1, false));
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
        public static void DancerHard()
        {
            string bundle = "in the orpheum, straight up jorkin it";
            string main = "BackupDancer_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle)) return;
            foreach (EnemyEncounter e in ((ZoneBGDataBaseSO)LoadedAssetsHandler.GetZoneDB("ZoneDB_Hard_02"))._hardEnemyBundleSelector._enemyEncounters)
            {
                if (e._bundleName == bundle)
                {
                    if (e.Priority > 20) e._priority /= 2;

                    break;
                }
            }
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>();
            for (int i = 0; i < 3; i++)
            {
                string a = RandomOrph;
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        a,
                        Either(a, RandomOrph),
                        main,
                        Either(a, RandomOrph),
                        RandomSupport(1, false, false)
                    }
                });
                string b = RandomOrph;
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        RandomColor(1),
                        main,
                        b,
                        Either(b, RandomOrph),
                        RandomSupport(1, false, false)
                    }
                });
                ResetColor();
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        SmartColor(1, true),
                        RandomOrph,
                        main,
                        SmartColor(1),
                        RandomSupport(1, false, false),
                    }
                });
                ResetColor();
                string c = RandomOrph;
                ResetColor();
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        c,
                        main,
                        Either(c, RandomOrph),
                        SmartColor(1, true),
                        SmartColor(1)
                    }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        main,
                        OrphWhore(),
                        Either(Either(RandomOrph, RandomColor(1)), RandomSupport(1, false, false))
                    }
                });
            }
            for (int i = 0; i < 20; i++)
            {
                list.Add(Orpheum.GuyGroup(main, 2, false));
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
        public static void MooneEZ()
        {
            string bundle = "MooneEncountersEasy";
            string main = "Moone_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle)) return;
            foreach (EnemyEncounter e in ((ZoneBGDataBaseSO)LoadedAssetsHandler.GetZoneDB("ZoneDB_Hard_02"))._easyEnemyBundleSelector._enemyEncounters)
            {
                if (e._bundleName == bundle)
                {
                    if (e.Priority > 30) e._priority /= 2;

                    break;
                }
            }
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>();
            for (int i = 0; i < 3; i++)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        Either(RandomOrph, RandomColor(0)),
                        main,
                        main,
                    }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        RandomColor(1),
                        main,
                        main,
                    }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        Either(RandomOrph, RandomColor(0)),
                        main,
                        main,
                        RandomSupport(1, false, false),
                    }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        main,
                        main,
                        RandomOrph
                    }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        RandomOrph,
                        main,
                        RandomColor(1),
                    }
                });
            }
            for (int i = 0; i < 20; i++)
            {
                list.Add(Orpheum.GuyGroup(main, 0, Half));
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
        public static void MooneMed()
        {
            string bundle = "MooneEncountersMedium";
            string main = "Moone_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle)) return;
            foreach (EnemyEncounter e in ((ZoneBGDataBaseSO)LoadedAssetsHandler.GetZoneDB("ZoneDB_Hard_02"))._mediumEnemyBundleSelector._enemyEncounters)
            {
                if (e._bundleName == bundle)
                {
                    if (e.Priority > 30) e._priority /= 2;

                    break;
                }
            }
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>();
            for (int i = 0; i < 3; i++)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        Either(RandomOrph, RandomColor(1)),
                        main,
                        main,
                        RandomSupport(1)
                    }
                });
                ResetColor();
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        SmartColor(1, true),
                        SmartColor(1),
                        main,
                        main,
                    }
                });
                ResetColor();
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        Either(RandomOrph, RandomColor(1)),
                        main,
                        main,
                        RandomSupport(1, false, false),
                    }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        main,
                        main,
                        main,
                        Either(RandomOrph, RandomColor(1))
                    }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        Either(RandomSupport(1, false, false), RandomOrph),
                        main,
                        main,
                        RandomColor(1),
                    }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        main,
                        main,
                        OrphWhore(),
                    }
                });
            }
            for (int i = 0; i < 20; i++)
            {
                list.Add(Orpheum.GuyGroup(main, 0, true));
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
        public static void BaitMed()
        {
            string bundle = "Low Quality Bait";
            string main = "DryBait_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>();
            for (int i = 0; i < 3; i++)
            {
                list.Add(new RandomEnemyGroup()
                {
                    _enemyNames = new string[]
                    {
                        main,
                        ShoreSlop(Half),
                        ShoreSlop(),
                    }
                });
                list.Add(new RandomEnemyGroup()
                {
                    _enemyNames = new string[]
                    {
                        main,
                        RandomColor(0),
                        ShoreSlop(),
                    }
                });
                list.Add(new RandomEnemyGroup()
                {
                    _enemyNames = new string[]
                    {
                        main,
                        ShoreSlop(Half),
                        ShoreSlop(),
                        Either(RandomShoreMidget(false), RandomSupport(0))
                    }
                });
                list.Add(new RandomEnemyGroup()
                {
                    _enemyNames = new string[]
                    {
                        main,
                        RandomColor(0),
                        ShoreSlop(),
                        Either(RandomShoreMidget(false), RandomSupport(0))
                    }
                });
                list.Add(new RandomEnemyGroup()
                {
                    _enemyNames = new string[]
                    {
                        main,
                        Shore.RandomShoreWhore(),
                        ShoreSlop(),
                    }
                });
                list.Add(new RandomEnemyGroup()
                {
                    _enemyNames = new string[]
                    {
                        main,
                        Shore.RandomShoreWhore(),
                        Either(RandomShoreMidget(false), RandomSupport(0))
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
        public static void BaitHard()
        {
            string bundle = "High Quality Bait";
            string main = "DryBait_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle)) return;
            foreach (EnemyEncounter e in ((ZoneBGDataBaseSO)LoadedAssetsHandler.GetZoneDB("ZoneDB_Hard_01"))._hardEnemyBundleSelector._enemyEncounters)
            {
                if (e._bundleName == bundle)
                {
                    if (e.Priority > 20) e._priority -= 6;

                    break;
                }
            }
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>();
            for (int i = 0; i < 3; i++)
            {
                list.Add(new RandomEnemyGroup()
                {
                    _enemyNames = new string[]
                    {
                        main,
                        ShoreSlop(Half),
                        ShoreSlop(),
                        Either(RandomColor(0), ShoreSlop())
                    }
                });
                ResetColor();
                list.Add(new RandomEnemyGroup()
                {
                    _enemyNames = new string[]
                    {
                        main,
                        SmartColor(0),
                        ShoreSlop(),
                        Either(SmartColor(0), ShoreSlop())
                    }
                });
                ResetColor();
                list.Add(new RandomEnemyGroup()
                {
                    _enemyNames = new string[]
                    {
                        main,
                        ShoreSlop(Half),
                        Shore.RandomShoreWhore(),
                        Either(RandomShoreMidget(false), RandomSupport(0))
                    }
                });
                list.Add(new RandomEnemyGroup()
                {
                    _enemyNames = new string[]
                    {
                        main,
                        RandomColor(0),
                        Shore.RandomShoreWhore(),
                        Either(RandomShoreMidget(false), RandomSupport(0))
                    }
                });
                list.Add(new RandomEnemyGroup()
                {
                    _enemyNames = new string[]
                    {
                        main,
                        Shore.RandomShoreWhore(),
                        ShoreSlop(),
                        Either(RandomColor(0), ShoreSlop())
                    }
                });
                list.Add(new RandomEnemyGroup()
                {
                    _enemyNames = new string[]
                    {
                        main,
                        Shore.RandomShoreWhore(),
                        Either(RandomShoreMidget(false), RandomSupport(0)),
                        Either(RandomColor(0), ShoreSlop())
                    }
                });
                list.Add(new RandomEnemyGroup()
                {
                    _enemyNames = new string[]
                    {
                        main,
                        Shore.RandomShoreWhore(),
                        Shore.RandomShoreWhore(),
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
        public static void EnnoEZ()
        {
            string bundle = "woah, lil' guy";
            string main = "Enno_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>();
            for (int i = 0; i < 3; i++)
            {
                list.Add(new RandomEnemyGroup()
                {
                    _enemyNames = new string[]
                    {
                        main,
                        ShoreSlop(),
                    }
                });
                list.Add(new RandomEnemyGroup()
                {
                    _enemyNames = new string[]
                    {
                        main,
                        RandomRedColor(false, true, false, false)
                    }
                });
                list.Add(new RandomEnemyGroup()
                {
                    _enemyNames = new string[]
                    {
                        main,
                        ShoreSlop(),
                        Either(RandomShoreMidget(false), RandomSupport(0))
                    }
                });
                list.Add(new RandomEnemyGroup()
                {
                    _enemyNames = new string[]
                    {
                        main,
                        Either(Shore.RandomShoreWhore(), ShoreSlop())
                    }
                });
                list.Add(new RandomEnemyGroup()
                {
                    _enemyNames = new string[]
                    {
                        main,
                        Either(RandomShoreMidget(false), RandomSupport(0))
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
        public static void EnnoMed()
        {
            string bundle = "get stabbed, idiot";
            string main = "Enno_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>();
            for (int i = 0; i < 3; i++)
            {
                list.Add(new RandomEnemyGroup()
                {
                    _enemyNames = new string[]
                    {
                        main,
                        ShoreSlop(Half),
                        ShoreSlop(),
                    }
                });
                list.Add(new RandomEnemyGroup()
                {
                    _enemyNames = new string[]
                    {
                        main,
                        RandomColor(0),
                        ShoreSlop(),
                    }
                });
                list.Add(new RandomEnemyGroup()
                {
                    _enemyNames = new string[]
                    {
                        main,
                        ShoreSlop(Half),
                        ShoreSlop(),
                        Either(RandomShoreMidget(false), RandomSupport(0))
                    }
                });
                list.Add(new RandomEnemyGroup()
                {
                    _enemyNames = new string[]
                    {
                        main,
                        RandomColor(0),
                        ShoreSlop(),
                        Either(RandomShoreMidget(false), RandomSupport(0))
                    }
                });
                list.Add(new RandomEnemyGroup()
                {
                    _enemyNames = new string[]
                    {
                        main,
                        Shore.RandomShoreWhore(),
                        ShoreSlop(),
                    }
                });
                list.Add(new RandomEnemyGroup()
                {
                    _enemyNames = new string[]
                    {
                        main,
                        Shore.RandomShoreWhore(),
                        Either(RandomShoreMidget(false), RandomSupport(0))
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
        public static void EnnoHard()
        {
            string bundle = "you cannot eat them";
            string main = "Enno_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>();
            for (int i = 0; i < 3; i++)
            {
                list.Add(new RandomEnemyGroup()
                {
                    _enemyNames = new string[]
                    {
                        main,
                        ShoreSlop(Half),
                        ShoreSlop(),
                        ShoreSlop()
                    }
                });
                ResetColor();
                list.Add(new RandomEnemyGroup()
                {
                    _enemyNames = new string[]
                    {
                        main,
                        SmartColor(0, true),
                        SmartColor(0),
                        ShoreSlop(),
                    }
                });
                ResetColor();
                list.Add(new RandomEnemyGroup()
                {
                    _enemyNames = new string[]
                    {
                        main,
                        ShoreSlop(Half),
                        Shore.RandomShoreWhore(),
                        ShoreSlop(),
                    }
                });
                list.Add(new RandomEnemyGroup()
                {
                    _enemyNames = new string[]
                    {
                        main,
                        Shore.RandomShoreWhore(),
                        ShoreSlop(),
                    }
                });
                list.Add(new RandomEnemyGroup()
                {
                    _enemyNames = new string[]
                    {
                        main,
                        Shore.RandomShoreWhore(),
                        ShoreSlop(),
                        RandomShoreMidget(false),
                    }
                });
                list.Add(new RandomEnemyGroup()
                {
                    _enemyNames = new string[]
                    {
                        main,
                        Shore.RandomShoreWhore(),
                        Either(RandomShoreMidget(false), RandomSupport(0, false, Half))
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
        public static void CupMed()
        {
            string bundle = "pray";
            string main = "God'sChalice_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>();
            for (int i = 0; i < 2; i++)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        RandomSupport(2, false, false),
                        main,
                        RandomEncounters.Garden.RandomChunk(),
                        RandomEncounters.Garden.RandomChunk(false, true)
                    }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                        {
                        RandomColor(2),
                        main,
                        RandomEncounters.Garden.RandomChunk(),
                        RandomEncounters.Garden.RandomChunk(false, true)
                        }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                        {
                        Half ? (Third ? RandomColor(2) : RandomSupport(2, false, false)) : RandomSupport(2),
                        main,
                        RandomEncounters.Garden.RandomWhore(),
                        }
                });
                ResetColor();
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        SmartColor(2, true),
                        main,
                        SmartColor(2)
                    }
                });
                ResetColor();
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
        public static void CupHard()
        {
            string bundle = "I would tell you to pray, but it's way too late for that now";
            string main = "God'sChalice_EN";
            if (!EnemyExist(main)) return;
            if (!BundleExist(bundle)) return;
            List<RandomEnemyGroup> list = new List<RandomEnemyGroup>();
            for (int i = 0; i < 3; i++)
            {
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        Half ? RandomSupport(2, false, false) : RandomEncounters.Garden.RandomWhore(),
                        main,
                        RandomEncounters.Garden.RandomChunk(),
                        RandomEncounters.Garden.RandomChunk(false, true)
                    }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                        {
                        RandomColor(2),
                        main,
                        RandomEncounters.Garden.RandomChunk(),
                        RandomEncounters.Garden.RandomChunk(false, true),
                        RandomSupport(2)
                        }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                        {
                        RandomSupport(2, false, false),
                        main,
                        RandomEncounters.Garden.RandomWhore(),
                        Half ? RandomEncounters.Garden.RandomChunk() : RandomSupport(2, false, false)
                        }
                });
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                        {
                        RandomColor(2),
                        main,
                        RandomEncounters.Garden.RandomWhore(),
                        Half ? RandomEncounters.Garden.RandomChunk() : RandomSupport(2, false, false)
                        }
                });
                if (Half)
                {
                    list.Add(new RandomEnemyGroup
                    {
                        _enemyNames = new string[]
                            {
                        RandomSupport(2),
                        main,
                        RandomEncounters.Garden.RandomWhore(),
                        RandomEncounters.Garden.RandomWhore()
                            }
                    });
                }
                else
                {
                    list.Add(new RandomEnemyGroup
                    {
                        _enemyNames = new string[]
                            {
                        main,
                        RandomEncounters.Garden.RandomWhore(),
                        RandomEncounters.Garden.RandomWhore()
                            }
                    });
                }
                ResetColor();
                list.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                        SmartColor(2, true),
                        main,
                        SmartColor(2),
                        RandomSupport(2, false, false)
                    }
                });
                ResetColor();
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
    }
}
