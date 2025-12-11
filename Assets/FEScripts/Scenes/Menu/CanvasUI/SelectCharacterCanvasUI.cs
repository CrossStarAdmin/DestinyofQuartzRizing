using System;
using System.Collections.Generic;
using Assets.FEScripts.Abstracts;
using Assets.FEScripts.Types;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.FEScripts.Scenes.Menu.CanvasUI
{
    public class SelectCharacterCanvasUI : AbstractCanvasUI
    {
        private TMP_Dropdown playerCharacterDropdown;
        private TMP_Dropdown enemyCharacterDropdown;
        private void Awake()
        {
            Canvas canvas = GameObject.Find("SelectCharacterCanvas").GetComponent<Canvas>();
            InitObject(canvas);
        }

        protected override void InitObject(Canvas _canvas)
        {
            // BaseのInitObjectを呼び出す
            base.InitObject(_canvas);
            // 各コンポーネントを取得
            playerCharacterDropdown = _component.transform.Find("PlayerCharacterElement/Dropdown").GetComponent<TMP_Dropdown>();
            enemyCharacterDropdown = _component.transform.Find("EnemyCharacterElement/Dropdown").GetComponent<TMP_Dropdown>();
        }

        public override void SetActions(Action[] _actions)
        {
            // PlayerCharacterDropdownのアクションをセット
            playerCharacterDropdown.onValueChanged.AddListener(_ => _actions[0]() );
            // EnemyCharacterDropdownのアクションをセット
            enemyCharacterDropdown.onValueChanged.AddListener(_ => _actions[1]() );
        }

        public void InitDropdowns(
            List<CharacterType> _characterTypes
        )
        {
            // プレイヤーキャラクタードロップダウンの初期化
            playerCharacterDropdown.ClearOptions();
            List<string> playerOptions = new List<string>();
            foreach (var character in _characterTypes)
            {
                playerOptions.Add(character.characterName);
            }
            playerCharacterDropdown.AddOptions(playerOptions);

            // 敵キャラクタードロップダウンの初期化
            enemyCharacterDropdown.ClearOptions();
            List<string> enemyOptions = new List<string>();
            foreach (var character in _characterTypes)
            {
                enemyOptions.Add(character.characterName);
            }
            enemyCharacterDropdown.AddOptions(enemyOptions);
        }

        public int GetSelectedPlayerCharacterIndex()
        {
            return playerCharacterDropdown.value;
        }

        public int GetSelectedEnemyCharacterIndex()
        {
            return enemyCharacterDropdown.value;
        }
    }
}
