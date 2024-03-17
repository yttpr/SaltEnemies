using BrutalAPI;

namespace Hawthorne
{
    public static class DeadGodEncounter
    {
        public static void Add()
        {
            BrutalAPI.EnemyEncounter enemyEncounter = new BrutalAPI.EnemyEncounter();
            enemyEncounter.encounterName = "DeadGod_Hard_Miniboss";
            enemyEncounter.area = 1;
            enemyEncounter.randomPlacement = false;
            enemyEncounter.hardmodeEncounter = true;
            enemyEncounter.difficulty = EncounterDifficulty.Hard;
            enemyEncounter.rarity = 8;
            if (SaltEnemies.trolling > 77)
            {
                enemyEncounter.rarity = 4;
            }
            else if (SaltEnemies.trolling > 70)
            {
                enemyEncounter.rarity = 10;
            }
            else if (SaltEnemies.trolling == 66)
            {
                enemyEncounter.rarity = 15;
            }
            if (SaltEnemies.trolling < 11)
            {
                enemyEncounter.rarity = 2;
            }
            enemyEncounter.variations = new FieldEnemy[1][];
            enemyEncounter.signType = (SignType)6668;
            enemyEncounter.musicEvent = "event:/Hawthorne/DeadGodSong";
            enemyEncounter.roarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone03_ChoirBoy_Easy_EnemyBundle")._roarReference.roarEvent;
            enemyEncounter.variations[0] = new FieldEnemy[1];
            enemyEncounter.variations[0][0] = new FieldEnemy()
            {
                enemyName = "EmbersofaDeadGod_EN",
                enemySlot = 2
            };
            BrutalAPI.BrutalAPI.AddSignType(enemyEncounter.signType, ResourceLoader.LoadSprite("DeadGodIcon", 64));
            enemyEncounter.AddEncounter();
        }
    }
}