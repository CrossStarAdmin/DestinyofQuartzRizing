using System.Collections.Generic;
using Assets.FEScripts.Types;
using UnityEngine;

namespace Assets.FEScripts.Scenes.Battle
{
    public class BattleEntity : MonoBehaviour
    {
        private CharacterType playerCharacter;
        private CharacterType enemyCharacter;
        public CharacterType PlayerCharacter {
            get { return playerCharacter; }
        }
        public CharacterType EnemyCharacter {
            get { return enemyCharacter; }
        }
        // バトルステータス
        private int maxHP;
        private int maxMP;
        public int MaxHP {
            get { return maxHP; }
        }
        public int MaxMP {
            get { return maxMP; }
        }
        // Player関係
        private int playerCurrentHP;
        private int playerCurrentMP;
        private int playerAvailableMP;
        private int playerTension;
        public int PlayerCurrentHP {
            get { return playerCurrentHP; }
        }
        public int PlayerCurrentMP {
            get { return playerCurrentMP; }
        }
        public int PlayerAvailableMP {
            get { return playerAvailableMP; }
        }
        public int PlayerTension {
            get { return playerTension; }
        }

        // Enemy関係
        private int enemyCurrentHP;
        private int enemyCurrentMP;
        private int enemyAvailableMP;
        private int enemyTension;
        public int EnemyCurrentHP {
            get { return enemyCurrentHP; }
        }
        public int EnemyCurrentMP {
            get { return enemyCurrentMP; }
        }
        public int EnemyAvailableMP {
            get { return enemyAvailableMP; }
        }
        public int EnemyTension {
            get { return enemyTension; }
        }

        private void Start()
        {
            playerCharacter = Setting.selectedPlayerCharacter;
            enemyCharacter = Setting.selectedEnemyCharacter;
            maxHP = Setting.initHP;
            maxMP = Setting.initMP;
            playerCurrentHP = Setting.initHP;
            playerCurrentMP = 0;
            playerAvailableMP = 0;
            playerTension = Setting.initFirstTension;

            enemyCurrentHP = Setting.initHP;
            enemyCurrentMP = 0;
            enemyAvailableMP = 0;
            enemyTension = Setting.initSecondTension;
        }

        public void IncrementPlayerHP()
        {
            if (playerCurrentHP >= maxHP) return;
            playerCurrentHP += 1;
        }

        public void DecrementPlayerHP()
        {
            if (playerCurrentHP <= 0) return;
            playerCurrentHP -= 1;
        }

        public void IncrementPlayerMP()
        {
            if (playerCurrentMP >= maxMP) return;
            playerCurrentMP += 1;
        }

        public void DecrementPlayerMP()
        {
            if (playerCurrentMP <= 0) return;
            playerCurrentMP -= 1;
        }

        public void IncrementPlayerAvailableMP()
        {
            if (playerAvailableMP >= playerCurrentMP) return;
            playerAvailableMP += 1;
        }

        public void DecrementPlayerAvailableMP()
        {
            if (playerAvailableMP <= 0) return;
            playerAvailableMP -= 1;
        }
        public void RecoverPlayerAvailableMP()
        {
            playerAvailableMP = playerCurrentMP;
        }
    }
}
