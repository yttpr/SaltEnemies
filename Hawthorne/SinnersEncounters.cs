using System;
using System.Collections.Generic;
using System.Text;
using static Hawthorne.Check;

namespace Hawthorne
{
    public static class SinnersEncounters
    {
        public static void Add()
        {
            if (EnemyExist("InfernalDrummer_EN") && BundleRandom("DrummerHard"))
            {
                List<RandomEnemyGroup> drummerList = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("DrummerHard"))._enemyBundles);
                drummerList.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "InfernalDrummer_EN",
                    "SkinningHomunculus_EN",
                    "Satyr_EN",
                    }
                });
                drummerList.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "InfernalDrummer_EN",
                    "SkinningHomunculus_EN",
                    "NextOfKin_EN",
                    "LittleAngel_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("DrummerHard"))._enemyBundles = drummerList.ToArray();
            }
            if (EnemyExist("Harbinger_EN") && BundleRandom("HarbingerHard"))
            {
                List<RandomEnemyGroup> HarbingerList = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("HarbingerHard"))._enemyBundles);
                HarbingerList.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "Harbinger_EN",
                    "ChoirBoy_EN",
                    "MortalSpoggle_EN",
                    }
                });
                HarbingerList.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "Harbinger_EN",
                    "ShiveringHomunculus_EN",
                    "ShiveringHomunculus_EN",
                    "LittleAngel_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("HarbingerHard"))._enemyBundles = HarbingerList.ToArray();
            }
            if (EnemyExist("HowlingAvian_EN") && BundleRandom("AvianHard"))
            {
                List<RandomEnemyGroup> birdList = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("AvianHard"))._enemyBundles);
                birdList.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "HowlingAvian_EN",
                    "LittleAngel_EN",
                    "SkinningHomunculus_EN",
                    }
                });
                birdList.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "HowlingAvian_EN",
                    "InHerImage_EN",
                    "InHisImage_EN",
                    "Satyr_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("AvianHard"))._enemyBundles = birdList.ToArray();
            }
            if (EnemyExist("Scuttlerunt_EN") && BundleRandom("RuntHard"))
            {
                List<RandomEnemyGroup> runtlistT = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("RuntHard"))._enemyBundles);
                runtlistT.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "Scuttlerunt_EN",
                    "Scuttlerunt_EN",
                    "Satyr_EN",
                    }
                });
                runtlistT.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "Scuttlerunt_EN",
                    "Scuttlerunt_EN",
                    "MortalSpoggle_EN",
                    "SkinningHomunculus_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("RuntHard"))._enemyBundles = runtlistT.ToArray();
            }
            if (MultiENExist("Scuttlerunt_EN", "Harbinger_EN", "InfernalDrummer_EN"))
            {
                List<RandomEnemyGroup> list16 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_SkinningHomunculus_Hard_EnemyBundle"))._enemyBundles);
                list16.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "Scuttlerunt_EN",
                    "SkinningHomunculus_EN",
                    "Satyr_EN",
                    "Scuttlerunt_EN"
                    }
                });
                list16.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "SkinningHomunculus_EN",
                    "LittleAngel_EN",
                    "Harbinger_EN"
                    }
                });
                list16.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "InfernalDrummer_EN",
                    "SkinningHomunculus_EN",
                    "Satyr_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_SkinningHomunculus_Hard_EnemyBundle"))._enemyBundles = list16.ToArray();
            }
            if (MultiENExist("Harbinger_EN", "HowlingAvian_EN"))
            {
                List<RandomEnemyGroup> list5 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_GigglingMinister_Hard_EnemyBundle"))._enemyBundles);
                list5.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "Harbinger_EN",
                    "GigglingMinister_EN",
                    "Satyr_EN",
                    "Harbinger_EN"
                    }
                });
                list5.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "HowlingAvian_EN",
                    "GigglingMinister_EN",
                    "GigglingMinister_EN",
                    "LittleAngel_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_GigglingMinister_Hard_EnemyBundle"))._enemyBundles = list5.ToArray();
            }
            if (EnemyExist("Lurchin_EN") && BundleRandom("LurchinHard"))
            {
                List<RandomEnemyGroup> listt = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("LurchinHard"))._enemyBundles);
                listt.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "Lurchin_EN",
                    "A'Flower'_EN",
                    "Spoggle_Ruminating_EN"
                    }
                });
                listt.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "Lurchin_EN",
                    "DeadPixel_EN",
                    "DeadPixel_EN",
                    "FlaMinGoa_EN"
                    }
                });
                listt.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                   {
                    "Lurchin_EN",
                    "A'Flower'_EN",
                    "Flarb_EN"
                   }
                });
                listt.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                   {
                    "Lurchin_EN",
                    "FlaMinGoa_EN",
                    "FlaMinGoa_EN",
                    "LostSheep_EN"
                   }
                });
                listt.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "Lurchin_EN",
                    "A'Flower'_EN",
                    "Wringle_EN"
                    }
                });
                listt.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "Lurchin_EN",
                    "DeadPixel_EN",
                    "DeadPixel_EN",
                    "Flarblet_EN",
                    "Flarblet_EN"
                    }
                });
                listt.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "Lurchin_EN",
                    "A'Flower'_EN",
                    "MudLung_EN",
                    "MudLung_EN"
                    }
                });
                listt.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                   {
                    "Lurchin_EN",
                    "MunglingMudLung_EN",
                    "JumbleGuts_Waning_EN",
                    "LostSheep_EN"
                   }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("LurchinHard"))._enemyBundles = listt.ToArray();
            }
            if (EnemyExist("FesteringFaction_EN") && BundleRandom("FactionMedium"))
            {
                List<RandomEnemyGroup> runtlistT = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("FactionMedium"))._enemyBundles);
                runtlistT.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "FesteringFaction_EN",
                    "LostSheep_EN",
                    "MudLung_EN",
                    }
                });
                runtlistT.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "FesteringFaction_EN",
                    "DeadPixel_EN",
                    "DeadPixel_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("FactionMedium"))._enemyBundles = runtlistT.ToArray();
            }
            if (EnemyExist("Pacemaker_EN") && BundleRandom("PulserHard"))
            {
                List<RandomEnemyGroup> lsito = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("PulserHard"))._enemyBundles);
                lsito.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "Pacemaker_EN",
                    "LostSheep_EN",
                    "TheCrow_EN",
                    "Conductor_EN"
                    }
                });
                lsito.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "Pacemaker_EN",
                    "Spoggle_Resonant_EN",
                    "Something_EN",
                    "Enigma_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("PulserHard"))._enemyBundles = lsito.ToArray();
                List<RandomEnemyGroup> list5 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("DontTouchMe_Hard"))._enemyBundles);
                list5.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "Freud_EN",
                    "Pacemaker_EN",
                    "Enigma_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("DontTouchMe_Hard"))._enemyBundles = list5.ToArray();
            }
            if (EnemyExist("Goliath_EN") && BundleRandom("GoliathMusicManMed"))
            {
                List<RandomEnemyGroup> runtlistT = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("GoliathMusicManMed"))._enemyBundles);
                runtlistT.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "Goliath_EN",
                    "Enigma_EN",
                    "MusicMan_EN",
                    }
                });
                runtlistT.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "Goliath_EN",
                    "MusicMan_EN",
                    "TheCrow_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("GoliathMusicManMed"))._enemyBundles = runtlistT.ToArray();
                List<RandomEnemyGroup> list5 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("DontTouchMe_Hard"))._enemyBundles);
                list5.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "Freud_EN",
                    "Goliath_EN",
                    "SingingStone_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("DontTouchMe_Hard"))._enemyBundles = list5.ToArray();
            }
        }
    }
}
