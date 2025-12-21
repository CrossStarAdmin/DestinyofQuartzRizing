using System.Collections.Generic;
using Assets.FEScripts.Types;
using UnityEngine;

namespace Assets.FEScripts.Scenes.Battle
{
    public class BattleEntity : MonoBehaviour
    {
        // TODO: バトルに必要なエンティティデータを追加
        public CharacterType playerCharacter;
        public CharacterType enemyCharacter;

        // バトルステータス
        public int maxHP;
        public int maxMP;
        public int playerCurrentHP;
        public int playerCurrentMP;
        public int enemyCurrentHP;
        public int enemyCurrentMP;
        public int playerTension;
        public int enemyTension;
    }
}
