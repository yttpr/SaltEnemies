using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hawthorne
{
    public static class CameraEncounters
    {
        public static void Add()
        {
            BrutalAPI.EnemyEncounter enemyEncounter = new BrutalAPI.EnemyEncounter();
            enemyEncounter.encounterName = "Camera_Hard";
            enemyEncounter.area = 0;
            enemyEncounter.randomPlacement = true;
            enemyEncounter.hardmodeEncounter = true;
            enemyEncounter.difficulty = EncounterDifficulty.Hard;
            enemyEncounter.rarity = 10;
            if (SaltEnemies.trolling <= 22)
            {
                enemyEncounter.rarity = 20;
            }
            enemyEncounter.variations = new FieldEnemy[15][];
            enemyEncounter.signType = (SignType)35788;
            enemyEncounter.musicEvent = "event:/Hawthorne/CameraSong";
            enemyEncounter.roarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone02_InnerChild_Hard_EnemyBundle")._roarReference.roarEvent;
            enemyEncounter.variations[0] = new FieldEnemy[3];
            enemyEncounter.variations[0][0] = new FieldEnemy()
            {
                enemyName = "MechanicalLens_EN",
                enemySlot = 2
            };
            enemyEncounter.variations[0][1] = new FieldEnemy()
            {
                enemyName = "FlaMinGoa_EN",
                enemySlot = 3
            };
            enemyEncounter.variations[0][2] = new FieldEnemy()
            {
                enemyName = "MudLung_EN",
                enemySlot = 4
            };
            enemyEncounter.variations[1] = new FieldEnemy[4];
            enemyEncounter.variations[1][0] = new FieldEnemy()
            {
                enemyName = "MechanicalLens_EN",
                enemySlot = 0
            };
            enemyEncounter.variations[1][1] = new FieldEnemy()
            {
                enemyName = "Mung_EN",
                enemySlot = 1
            };
            enemyEncounter.variations[1][2] = new FieldEnemy()
            {
                enemyName = "JumbleGuts_Waning_EN",
                enemySlot = 2
            };
            enemyEncounter.variations[1][3] = new FieldEnemy()
            {
                enemyName = "MunglingMudLung_EN",
                enemySlot = 4
            };
            enemyEncounter.variations[2] = new FieldEnemy[3];
            enemyEncounter.variations[2][0] = new FieldEnemy()
            {
                enemyName = "MechanicalLens_EN",
                enemySlot = 0
            };
            enemyEncounter.variations[2][1] = new FieldEnemy()
            {
                enemyName = "JumbleGuts_Clotted_EN",
                enemySlot = 1
            };
            enemyEncounter.variations[2][2] = new FieldEnemy()
            {
                enemyName = "Flarblet_EN",
                enemySlot = 2
            };
            enemyEncounter.variations[3] = new FieldEnemy[4];
            enemyEncounter.variations[3][0] = new FieldEnemy()
            {
                enemyName = "MechanicalLens_EN",
                enemySlot = 0
            };
            enemyEncounter.variations[3][1] = new FieldEnemy()
            {
                enemyName = "MudLung_EN",
                enemySlot = 1
            };
            enemyEncounter.variations[3][2] = new FieldEnemy()
            {
                enemyName = "MudLung_EN",
                enemySlot = 2
            };
            enemyEncounter.variations[3][3] = new FieldEnemy()
            {
                enemyName = "FlaMinGoa_EN",
                enemySlot = 3
            };
            enemyEncounter.variations[4] = new FieldEnemy[4];
            enemyEncounter.variations[4][0] = new FieldEnemy()
            {
                enemyName = "MechanicalLens_EN",
                enemySlot = 0
            };
            enemyEncounter.variations[4][1] = new FieldEnemy()
            {
                enemyName = "FlaMinGoa_EN",
                enemySlot = 1
            };
            enemyEncounter.variations[4][2] = new FieldEnemy()
            {
                enemyName = "Spoggle_Ruminating_EN",
                enemySlot = 2
            };
            enemyEncounter.variations[4][3] = new FieldEnemy()
            {
                enemyName = "Spoggle_Ruminating_EN",
                enemySlot = 4
            };
            enemyEncounter.variations[5] = new FieldEnemy[4];
            enemyEncounter.variations[5][0] = new FieldEnemy()
            {
                enemyName = "MechanicalLens_EN",
                enemySlot = 0
            };
            enemyEncounter.variations[5][1] = new FieldEnemy()
            {
                enemyName = "LostSheep_EN",
                enemySlot = 1
            };
            enemyEncounter.variations[5][2] = new FieldEnemy()
            {
                enemyName = "MudLung_EN",
                enemySlot = 2
            };
            enemyEncounter.variations[5][3] = new FieldEnemy()
            {
                enemyName = "Spoggle_Spitfire_EN",
                enemySlot = 4
            };
            enemyEncounter.variations[6] = new FieldEnemy[3];
            enemyEncounter.variations[6][0] = new FieldEnemy()
            {
                enemyName = "MechanicalLens_EN",
                enemySlot = 0
            };
            enemyEncounter.variations[6][1] = new FieldEnemy()
            {
                enemyName = "DeadPixel_EN",
                enemySlot = 1
            };
            enemyEncounter.variations[6][2] = new FieldEnemy()
            {
                enemyName = "DeadPixel_EN",
                enemySlot = 2
            };
            enemyEncounter.variations[7] = new FieldEnemy[3];
            enemyEncounter.variations[7][0] = new FieldEnemy()
            {
                enemyName = "MechanicalLens_EN",
                enemySlot = 0
            };
            enemyEncounter.variations[7][1] = new FieldEnemy()
            {
                enemyName = "MunglingMudLung_EN",
                enemySlot = 1
            };
            enemyEncounter.variations[7][2] = new FieldEnemy()
            {
                enemyName = "Wringle_EN",
                enemySlot = 2
            };
            enemyEncounter.variations[8] = new FieldEnemy[3];
            enemyEncounter.variations[8][0] = new FieldEnemy()
            {
                enemyName = "MechanicalLens_EN",
                enemySlot = 0
            };
            enemyEncounter.variations[8][1] = new FieldEnemy()
            {
                enemyName = "FlaMinGoa_EN",
                enemySlot = 1
            };
            enemyEncounter.variations[8][2] = new FieldEnemy()
            {
                enemyName = "Spoggle_Spitfire_EN",
                enemySlot = 2
            };
            enemyEncounter.variations[9] = new FieldEnemy[4];
            enemyEncounter.variations[9][0] = new FieldEnemy()
            {
                enemyName = "MechanicalLens_EN",
                enemySlot = 0
            };
            enemyEncounter.variations[9][1] = new FieldEnemy()
            {
                enemyName = "JumbleGuts_Clotted_EN",
                enemySlot = 1
            };
            enemyEncounter.variations[9][2] = new FieldEnemy()
            {
                enemyName = "JumbleGuts_Waning_EN",
                enemySlot = 2
            };
            enemyEncounter.variations[9][3] = new FieldEnemy()
            {
                enemyName = "FlaMinGoa_EN",
                enemySlot = 4
            };
            enemyEncounter.variations[10] = new FieldEnemy[4];
            enemyEncounter.variations[10][0] = new FieldEnemy()
            {
                enemyName = "MechanicalLens_EN",
                enemySlot = 0
            };
            enemyEncounter.variations[10][1] = new FieldEnemy()
            {
                enemyName = "MunglingMudLung_EN",
                enemySlot = 1
            };
            enemyEncounter.variations[10][2] = new FieldEnemy()
            {
                enemyName = "MechanicalLens_EN",
                enemySlot = 2
            };
            enemyEncounter.variations[10][3] = new FieldEnemy()
            {
                enemyName = "Spoggle_Ruminating_EN",
                enemySlot = 4
            };
            enemyEncounter.variations[11] = new FieldEnemy[4];
            enemyEncounter.variations[11][0] = new FieldEnemy()
            {
                enemyName = "MechanicalLens_EN",
                enemySlot = 0
            };
            enemyEncounter.variations[11][1] = new FieldEnemy()
            {
                enemyName = "Spoggle_Spitfire_EN",
                enemySlot = 1
            };
            enemyEncounter.variations[11][2] = new FieldEnemy()
            {
                enemyName = "MechanicalLens_EN",
                enemySlot = 2
            };
            enemyEncounter.variations[11][3] = new FieldEnemy()
            {
                enemyName = "Spoggle_Ruminating_EN",
                enemySlot = 4
            };
            enemyEncounter.variations[12] = new FieldEnemy[4];
            enemyEncounter.variations[12][0] = new FieldEnemy()
            {
                enemyName = "MechanicalLens_EN",
                enemySlot = 0
            };
            enemyEncounter.variations[12][1] = new FieldEnemy()
            {
                enemyName = "FlaMinGoa_EN",
                enemySlot = 1
            };
            enemyEncounter.variations[12][2] = new FieldEnemy()
            {
                enemyName = "MechanicalLens_EN",
                enemySlot = 2
            };
            enemyEncounter.variations[12][3] = new FieldEnemy()
            {
                enemyName = "Wringle_EN",
                enemySlot = 4
            };
            enemyEncounter.variations[13] = new FieldEnemy[4];
            enemyEncounter.variations[13][0] = new FieldEnemy()
            {
                enemyName = "MechanicalLens_EN",
                enemySlot = 0
            };
            enemyEncounter.variations[13][1] = new FieldEnemy()
            {
                enemyName = "MunglingMudLung_EN",
                enemySlot = 1
            };
            enemyEncounter.variations[13][2] = new FieldEnemy()
            {
                enemyName = "MechanicalLens_EN",
                enemySlot = 2
            };
            enemyEncounter.variations[13][3] = new FieldEnemy()
            {
                enemyName = "MunglingMudLung_EN",
                enemySlot = 4
            };
            enemyEncounter.variations[14] = new FieldEnemy[4];
            enemyEncounter.variations[14][0] = new FieldEnemy()
            {
                enemyName = "MechanicalLens_EN",
                enemySlot = 0
            };
            enemyEncounter.variations[14][1] = new FieldEnemy()
            {
                enemyName = "MechanicalLens_EN",
                enemySlot = 1
            };
            enemyEncounter.variations[14][2] = new FieldEnemy()
            {
                enemyName = "MechanicalLens_EN",
                enemySlot = 2
            };
            enemyEncounter.variations[14][3] = new FieldEnemy()
            {
                enemyName = "FlaMinGoa_EN",
                enemySlot = 4
            };
            BrutalAPI.BrutalAPI.AddSignType(enemyEncounter.signType, ResourceLoader.LoadSprite("DroneIcon", 64));
            enemyEncounter.AddEncounter();
        }
    }
}
