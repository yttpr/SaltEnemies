using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using static Hawthorne.Check;
using System.Linq;

namespace Hawthorne
{
    public static class ColoEncounters
    {
        public static void Add()
        {
            if (MultiENExist("DelightedColophon_EN", "ComposedColophon_EN", "MaladjustedColophon_EN"))
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_MusicMan_Medium_EnemyBundle"))._enemyBundles = new List<RandomEnemyGroup>((IEnumerable<RandomEnemyGroup>)((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_MusicMan_Medium_EnemyBundle"))._enemyBundles)
                {
                  new RandomEnemyGroup()
                  {
                    _enemyNames = new string[]
                    {
                      "MusicMan_EN",
                      "TheCrow_EN",
                      "DelightedColophon_EN"
                    }
                  },
                  new RandomEnemyGroup()
                  {
                    _enemyNames = new string[]
                    {
                      "MusicMan_EN",
                      "TheCrow_EN",
                      "ComposedColophon_EN",
                      "MusicMan_EN"
                    }
                  },
                  new RandomEnemyGroup()
                  {
                    _enemyNames = new string[]
                    {
                      "MusicMan_EN",
                      "Enigma_EN",
                      "MaladjustedColophon_EN",
                      "MusicMan_EN"
                    }
                  }
                }.ToArray();
            if (EnemyExist("ComposedColophon_EN"))
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_MudLung_Medium_EnemyBundle"))._enemyBundles = new List<RandomEnemyGroup>((IEnumerable<RandomEnemyGroup>)((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_MudLung_Medium_EnemyBundle"))._enemyBundles)
                {
                  new RandomEnemyGroup()
                  {
                    _enemyNames = new string[]
                    {
                      "MudLung_EN",
                      "MudLung_EN",
                      "ComposedColophon_EN",
                      "LostSheep_EN"
                    }
                  }
                }.ToArray();
            if (EnemyExist("DefeatedColophon_EN"))
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_MunglingMudLung_Medium_EnemyBundle"))._enemyBundles = new List<RandomEnemyGroup>((IEnumerable<RandomEnemyGroup>)((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_MunglingMudLung_Medium_EnemyBundle"))._enemyBundles)
                {
                  new RandomEnemyGroup()
                  {
                    _enemyNames = new string[]
                    {
                      "MudLung_EN",
                      "MunglingMudLung_EN",
                      "DefeatedColophon_EN",
                      "LostSheep_EN"
                    }
                  }
                }.ToArray();
            if (DoDebugs.MiscInfo) Debug.Log("Count: " + ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_MunglingMudLung_Medium_EnemyBundle"))._enemyBundles.Count().ToString());
            if (EnemyExist("ComposedColophon_EN"))
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_FlaMingGoa_Hard_EnemyBundle"))._enemyBundles = new List<RandomEnemyGroup>((IEnumerable<RandomEnemyGroup>)((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_FlaMingGoa_Hard_EnemyBundle"))._enemyBundles)
                {
                  new RandomEnemyGroup()
                  {
                    _enemyNames = new string[]
                    {
                      "FlaMinGoa_EN",
                      "MunglingMudLung_EN",
                      "ComposedColophon_EN",
                      "A'Flower'_EN"
                    }
                  },
                  new RandomEnemyGroup()
                  {
                    _enemyNames = new string[]
                    {
                      "FlaMinGoa_EN",
                      "MunglingMudLung_EN",
                      "ComposedColophon_EN",
                      "DeadPixel_EN",
                      "DeadPixel_EN"
                    }
                  }
                }.ToArray();
            if (MultiENExist("ComposedColophon_EN", "DefeatedColophon_EN"))
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Flarb_Hard_EnemyBundle"))._enemyBundles = new List<RandomEnemyGroup>((IEnumerable<RandomEnemyGroup>)((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Flarb_Hard_EnemyBundle"))._enemyBundles)
                {
                  new RandomEnemyGroup()
                  {
                    _enemyNames = new string[]
                    {
                      "Flarb_EN",
                      "ComposedColophon_EN",
                      "ComposedColophon_EN",
                      "A'Flower'_EN"
                    }
                  },
                  new RandomEnemyGroup()
                  {
                    _enemyNames = new string[]
                    {
                      "Flarb_EN",
                      "DefeatedColophon_EN",
                      "DeadPixel_EN",
                      "DeadPixel_EN"
                    }
                  }
                }.ToArray();
            if (EnemyExist("ComposedColophon_EN"))
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Voboola_Hard_EnemyBundle"))._enemyBundles = new List<RandomEnemyGroup>((IEnumerable<RandomEnemyGroup>)((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Voboola_Hard_EnemyBundle"))._enemyBundles)
                {
                  new RandomEnemyGroup()
                  {
                    _enemyNames = new string[]
                    {
                      "Voboola_EN",
                      "ComposedColophon_EN",
                      "A'Flower'_EN"
                    }
                  },
                }.ToArray();
            if (EnemyExist("ComposedColophon_EN"))
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Zone01_Spoggle_Ruminating_Medium_EnemyBundle"))._enemyBundles = new List<RandomEnemyGroup>((IEnumerable<RandomEnemyGroup>)((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("Zone01_Spoggle_Ruminating_Medium_EnemyBundle"))._enemyBundles)
                {
                  new RandomEnemyGroup()
                  {
                    _enemyNames = new string[]
                    {
                      "Spoggle_Ruminating_EN",
                      "ComposedColophon_EN",
                      "A'Flower'_EN"
                    }
                  },
                }.ToArray();
            if (MultiENExist("DelightedColophon_EN", "ComposedColophon_EN"))
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Scrungie_Medium_EnemyBundle"))._enemyBundles = new List<RandomEnemyGroup>((IEnumerable<RandomEnemyGroup>)((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Scrungie_Medium_EnemyBundle"))._enemyBundles)
                {
                  new RandomEnemyGroup()
                  {
                    _enemyNames = new string[]
                    {
                      "Scrungie_EN",
                      "DelightedColophon_EN",
                      "Scrungie_EN",
                      "Enigma_EN"
                    }
                  },
                  new RandomEnemyGroup()
                  {
                    _enemyNames = new string[]
                    {
                      "Scrungie_EN",
                      "ComposedColophon_EN",
                      "Scrungie_EN",
                      "TheCrow_EN"
                    }
                  },
                }.ToArray();
            if (EnemyExist("DefeatedColophon_EN"))
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Conductor_Hard_EnemyBundle"))._enemyBundles = new List<RandomEnemyGroup>((IEnumerable<RandomEnemyGroup>)((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Conductor_Hard_EnemyBundle"))._enemyBundles)
                {
                  new RandomEnemyGroup()
                  {
                    _enemyNames = new string[]
                    {
                      "Conductor_EN",
                      "DefeatedColophon_EN",
                      "Enigma_EN",
                      "Enigma_EN"
                    }
                  },
                }.ToArray();
            if (MultiENExist("DelightedColophon_EN", "MaladjustedColophon_EN") && BundleRandom("DelighteddMedium"))
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("DelighteddMedium"))._enemyBundles = new List<RandomEnemyGroup>((IEnumerable<RandomEnemyGroup>)((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("DelighteddMedium"))._enemyBundles)
                {
                  new RandomEnemyGroup()
                  {
                    _enemyNames = new string[]
                    {
                      "DelightedColophon_EN",
                      "MaladjustedColophon_EN",
                      "Something_EN",
                      "Enigma_EN"
                    }
                  },
                }.ToArray();
            if (EnemyExist("MaladjustedColophon_EN") && BundleRandom("MaladjustedMedium"))
                ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("MaladjustedMedium"))._enemyBundles = new List<RandomEnemyGroup>((IEnumerable<RandomEnemyGroup>)((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("MaladjustedMedium"))._enemyBundles)
                {
                  new RandomEnemyGroup()
                  {
                    _enemyNames = new string[]
                    {
                      "MaladjustedColophon_EN",
                      "Something_EN",
                      "Derogatory_EN"
                    }
                  },
                }.ToArray();

        }
    }
}
