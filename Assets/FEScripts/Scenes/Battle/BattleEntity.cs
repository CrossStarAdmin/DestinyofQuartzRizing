using System.Collections.Generic;
using Assets.FEScripts.Types;
using UnityEngine;

namespace Assets.FEScripts.Scenes.Battle
{
    public class BattleEntity : MonoBehaviour
    {
        // キャラクター情報
        private CharacterType playerCharacter;
        private CharacterType enemyCharacter;
        
        // バトルステータス
        private int maxHP;
        private int maxMP;
        
        // ==================================================
        // Player関係のフィールド
        // ==================================================
        private int playerCurrentHP;
        private int playerCurrentMP;
        private int playerAvailableMP;
        private int playerTension;
        private bool isUsedTensionCard = false;
        private bool isUsedHolyCard = false;
        private bool isFinishedHolyCardChange = false;
        
        // ==================================================
        // Enemy関係のフィールド
        // ==================================================
        private int enemyCurrentHP;
        private int enemyCurrentMP;
        private int enemyAvailableMP;
        private int enemyTension;
        
        // ==================================================
        // プロパティ - キャラクター情報
        // ==================================================
        public CharacterType PlayerCharacter { get { return playerCharacter; } }
        public CharacterType EnemyCharacter { get { return enemyCharacter; } }
        
        // ==================================================
        // プロパティ - バトルステータス
        // ==================================================
        public int MaxHP { get { return maxHP; } }
        public int MaxMP { get { return maxMP; } }
        
        // ==================================================
        // プロパティ - Player関係
        // ==================================================
        public int PlayerCurrentHP { get { return playerCurrentHP; } }
        public int PlayerCurrentMP { get { return playerCurrentMP; } }
        public int PlayerAvailableMP { get { return playerAvailableMP; } }
        public int PlayerTension { get { return playerTension; } }
        public bool IsUsedTensionCard { get { return isUsedTensionCard; } }
        public bool IsUsedHolyCard { get { return isUsedHolyCard; } }
        public bool IsFinishedHolyCardChange { get { return isFinishedHolyCardChange; } }
        
        // ==================================================
        // プロパティ - Enemy関係
        // ==================================================
        public int EnemyCurrentHP { get { return enemyCurrentHP; } }
        public int EnemyCurrentMP { get { return enemyCurrentMP; } }
        public int EnemyAvailableMP { get { return enemyAvailableMP; } }
        public int EnemyTension { get { return enemyTension; } }

        // ==================================================
        // 初期化
        // ==================================================
        private void Start()
        {
            // キャラクター設定
            playerCharacter = Setting.selectedPlayerCharacter;
            enemyCharacter = Setting.selectedEnemyCharacter;
            
            // バトルステータス設定
            maxHP = Setting.initHP;
            maxMP = Setting.initMP;
            
            // Player初期化
            playerCurrentHP = Setting.initHP;
            playerCurrentMP = 0;
            playerAvailableMP = 0;
            playerTension = Setting.initFirstTension;
            
            // Enemy初期化
            enemyCurrentHP = Setting.initHP;
            enemyCurrentMP = 0;
            enemyAvailableMP = 0;
            enemyTension = Setting.initSecondTension;
        }

        // ==================================================
        // Player関係のメソッド - HP
        // ==================================================
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

        // ==================================================
        // Player関係のメソッド - MP
        // ==================================================
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

        // ==================================================
        // Player関係のメソッド - Tension
        // ==================================================
        public void IncrementPlayerTension()
        {
            if (playerTension > 3) return;
            playerTension += 1;
        }

        public void ResetPlayerTension()
        {
            playerTension = 0;
        }

        // ==================================================
        // Player関係のメソッド - Card
        // ==================================================
        public void UsedTensionCard()
        {
            isUsedTensionCard = true;
        }

        public void ResetUsedTensionCard()
        {
            isUsedTensionCard = false;
        }

        public void UsedHolyCard()
        {
            isUsedHolyCard = true;
        }

        public void FinishedHolyCardChange()
        {
            isFinishedHolyCardChange = true;
        }

        // ==================================================
        // Enemy関係のメソッド - Tension
        // ==================================================
        public void IncrementEnemyTension()
        {
            if (enemyTension > 3) return;
            enemyTension += 1;
        }
        public void ResetEnemyTension()
        {
            enemyTension = 0;
        }
    }
}
