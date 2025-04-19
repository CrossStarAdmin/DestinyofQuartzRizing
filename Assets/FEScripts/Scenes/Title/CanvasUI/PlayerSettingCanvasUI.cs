using System;
using Assets.FEScripts.Abstracts;
using Assets.FEScripts.Components.UI;
using TMPro;
using UnityEditor.iOS;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.FEScripts.Scenes.Title.CanvasUI
{
    public class PlayerSettingCanvasUI : AbstractCanvasUI
    {
        private GameObject _playerCountElement;
        private TextMeshProUGUI _playerCountText;
        private OriginButtonComponent _reduceButton;
        private OriginButtonComponent _addButton;

        private GameObject _playerNameFormElement;
        private RectTransform _contentRectTransform;
        private void Awake()
        {
            Canvas canvas = GameObject.Find("PlayerSettingCanvas").GetComponent<Canvas>();
            InitObject(canvas);
        }

        protected override void InitObject(Canvas _canvas)
        {
            base.InitObject(_canvas);
            // 各コンポーネントを取得
            _playerCountElement = _component.transform.Find("PlayerCountElement").gameObject;
            _playerCountText = _playerCountElement.transform.Find("ButtonElement/PlayerCountText").GetComponent<TextMeshProUGUI>();
            _reduceButton = _playerCountElement.transform.Find("ButtonElement/ReduceButton").GetComponent<OriginButtonComponent>();
            _addButton = _playerCountElement.transform.Find("ButtonElement/AddButton").GetComponent<OriginButtonComponent>();
            _playerNameFormElement = _component.transform.Find("PlayerNameFormElement").gameObject;
            _contentRectTransform = _playerNameFormElement.transform.Find("Viewport/Content").GetComponent<RectTransform>();
        }

        public override void SetActions(Action[] _actions)
        {
            // アクションのセット
            _reduceButton.InitOriginButtonComponent(_actions[0]);
            _addButton.InitOriginButtonComponent(_actions[1]);

        }

        public string GetPlayerName(int _index)
        {
            // プレイヤー名を取得
            GameObject playerNameForm = _contentRectTransform.GetChild(_index).gameObject;
            Text playerNameText = playerNameForm.transform.Find("Text").GetComponent<Text>();
            return playerNameText.text;
        }

        public void UpdatePlayerSetting(
            int _playerCount,
            string[] _playerNames
        )
        {
            // プレイヤー数の更新
            _playerCountText.text = _playerCount.ToString();
            // ボタンの表示を確認
            if (_playerCount <= Setting.MIN_PLAYER_COUNT)
                _reduceButton.gameObject.SetActive(false);
            else
                _reduceButton.gameObject.SetActive(true);
            if (_playerCount >= Setting.MAX_PLAYER_COUNT)
                _addButton.gameObject.SetActive(false);
            else
                _addButton.gameObject.SetActive(true);
            // RectTransformのサイズを更新
            _contentRectTransform.sizeDelta = new Vector2(_contentRectTransform.sizeDelta.x, _playerCount * 110 + 20);
            // フォームの数を更新
            for (int i = 0; i < _contentRectTransform.childCount; i++)
            {
                Destroy(_contentRectTransform.GetChild(i).gameObject);
            }
            for (int i = 0; i < _playerCount; i++)
            {
                GameObject playerInput = Resources.Load("Prefabs/UI/NameInputPrefab") as GameObject;
                InputField inputField = playerInput.GetComponent<InputField>();
                // プレイヤー名の初期値を設定
                inputField.text = _playerNames[i];
                // プレイヤー名のフォームを生成
                Instantiate(playerInput, _contentRectTransform);
            }
        }
    }
}