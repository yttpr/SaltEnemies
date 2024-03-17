using ES3Types;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using static Hawthorne.Check;

namespace Hawthorne
{
    public static class RainbowEncounters
    {
        public static void Add()
        {
            if (EnemyExist("AmphibiousSpoggle_EN") && BundleRandom("Amph"))
            {
                List<RandomEnemyGroup> amphList = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Amph"))._enemyBundles);
                amphList.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "AmphibiousSpoggle_EN",
                    "A'Flower'_EN",
                    "Spoggle_Ruminating_EN",
                    }
                });
                amphList.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "AmphibiousSpoggle_EN",
                    "DeadPixel_EN",
                    "DeadPixel_EN",
                    "Flarb_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Amph"))._enemyBundles = amphList.ToArray();
            }
            if (EnemyExist("AnnoyingJumbleGuts_EN") && BundleRandom("AnnoyingM"))
            {
                List<RandomEnemyGroup> annoyList = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("AnnoyingM"))._enemyBundles);
                annoyList.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "AnnoyingJumbleGuts_EN",
                    "A'Flower'_EN",
                    "MudLung_EN",
                    }
                });
                annoyList.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "AnnoyingJumbleGuts_EN",
                    "Flarb_EN",
                    "LostSheep_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("AnnoyingM"))._enemyBundles = annoyList.ToArray();
            }
            if (EnemyExist("ArtisticJumbleGuts_EN") && BundleRandom("ArtisticM"))
            {
                List<RandomEnemyGroup> artList = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("ArtisticM"))._enemyBundles);
                artList.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "ArtisticJumbleGuts_EN",
                    "MusicMan_EN",
                    "TheCrow_EN",
                    }
                });
                artList.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "ArtisticJumbleGuts_EN",
                    "Enigma_EN",
                    "Enigma_EN",
                    "JumbleGuts_Waning_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("ArtisticM"))._enemyBundles = artList.ToArray();
            }
            if (EnemyExist("BondedJumbleGuts_EN") && BundleRandom("BondedM"))
            {
                List<RandomEnemyGroup> polarBondsList = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("BondedM"))._enemyBundles);
                polarBondsList.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "BondedJumbleGuts_EN",
                    "FlaMinGoa_EN",
                    "MunglingMudLung_EN",
                    }
                });
                polarBondsList.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "BondedJumbleGuts_EN",
                    "DeadPixel_EN",
                    "DeadPixel_EN",
                    "JumbleGuts_Waning_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("BondedM"))._enemyBundles = polarBondsList.ToArray();
            }
            if (EnemyExist("EclipsedSpoggle_EN") && BundleRandom("EclipsedM"))
            {
                List<RandomEnemyGroup> eclipseThisList = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("EclipsedM"))._enemyBundles);
                eclipseThisList.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "EclipsedSpoggle_EN",
                    "DeadPixel_EN",
                    "DeadPixel_EN",
                    "Mung_EN"
                    }
                });
                eclipseThisList.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "EclipsedSpoggle_EN",
                    "LostSheep_EN",
                    "MudLung_EN",
                    "MudLung_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("EclipsedM"))._enemyBundles = eclipseThisList.ToArray();
            }
            if (EnemyExist("FoamingSpoggle_EN") && BundleRandom("FoamingM"))
            {
                List<RandomEnemyGroup> foamingAtTheMouthList = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("FoamingM"))._enemyBundles);
                foamingAtTheMouthList.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "FoamingSpoggle_EN",
                    "SilverSuckle_EN",
                    "SilverSuckle_EN",
                    "Enigma_EN",
                    }
                });
                foamingAtTheMouthList.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "FoamingSpoggle_EN",
                    "Freud_EN",
                    "LostSheep_EN",
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("FoamingM"))._enemyBundles = foamingAtTheMouthList.ToArray();
            }
            if (EnemyExist("IchtyosatedSpoggle_EN") && BundleRandom("IchtyosatedM"))
            {
                List<RandomEnemyGroup> fishedList = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("IchtyosatedM"))._enemyBundles);
                fishedList.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "IchtyosatedSpoggle_EN",
                    "A'Flower'_EN",
                    "Flarb_EN",
                    }
                });
                fishedList.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "IchtyosatedSpoggle_EN",
                    "A'Flower'_EN",
                    "Spoggle_Ruminating_EN",
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("IchtyosatedM"))._enemyBundles = fishedList.ToArray();
            }
            if (EnemyExist("MalignantJumbleGuts_EN") && BundleRandom("MalignantM"))
            {
                List<RandomEnemyGroup> malignancyList = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("MalignantM"))._enemyBundles);
                malignancyList.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "MalignantJumbleGuts_EN",
                    "JumbleGuts_Flummoxing_EN",
                    "Enigma_EN",
                    "SilverSuckle_EN"
                    }
                });
                malignancyList.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "MalignantJumbleGuts_EN",
                    "TheCrow_EN",
                    "WrigglingSacrifice_EN",
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("MalignantM"))._enemyBundles = malignancyList.ToArray();
            }
            if (EnemyExist("NecromanticSpoggle_EN") && BundleRandom("NecroM"))
            {
                List<RandomEnemyGroup> zombieList = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("NecroM"))._enemyBundles);
                zombieList.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "NecromanticSpoggle_EN",
                    "Spoggle_Resonant_EN",
                    "LostSheep_EN",
                    }
                });
                zombieList.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "NecromanticSpoggle_EN",
                    "Scrungie_EN",
                    "DeadPixel_EN",
                    "DeadPixel_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("NecroM"))._enemyBundles = zombieList.ToArray();
            }
            if (EnemyExist("ParasiticJumbleGuts_EN") && BundleRandom("ParasiticM"))
            {
                List<RandomEnemyGroup> longLiverList = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("ParasiticM"))._enemyBundles);
                longLiverList.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "ParasiticJumbleGuts_EN",
                    "JumbleGuts_Clotted_EN",
                    "LostSheep_EN",
                    "MunglingMudLung_EN"
                    }
                });
                longLiverList.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "ParasiticJumbleGuts_EN",
                    "FlaMinGoa_EN",
                    "A'Flower'_EN",
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("ParasiticM"))._enemyBundles = longLiverList.ToArray();
            }
            if (EnemyExist("PoolingSpoggle_EN") && BundleRandom("PoolingM"))
            {
                List<RandomEnemyGroup> cueBallList = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("PoolingM"))._enemyBundles);
                cueBallList.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "PoolingSpoggle_EN",
                    "Spoggle_Spitfire_EN",
                    "SingingStone_EN",
                    "Enigma_EN"
                    }
                });
                cueBallList.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "PoolingSpoggle_EN",
                    "TheCrow_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("PoolingM"))._enemyBundles = cueBallList.ToArray();
                if (DoDebugs.MiscInfo) Debug.Log("Jump in. it's nice and cool in here.");
            }
            if (EnemyExist("WaxingJumbleGuts_EN") && BundleRandom("WaxingM"))
            {
                List<RandomEnemyGroup> hylicsList = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("WaxingM"))._enemyBundles);
                hylicsList.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "WaxingJumbleGuts_EN",
                    "LostSheep_EN",
                    "MusicMan_EN",
                    "MusicMan_EN",
                    "JumbleGuts_Waning_EN"
                    }
                });
                hylicsList.Add(new RandomEnemyGroup
                {
                    _enemyNames = new string[]
                    {
                    "WaxingJumbleGuts_EN",
                    "TheCrow_EN",
                    "Enigma_EN"
                    }
                });
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("WaxingM"))._enemyBundles = hylicsList.ToArray();
            }
        }
    }
}
