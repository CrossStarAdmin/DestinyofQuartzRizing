using System;
using Assets.FEScripts.Abstracts;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.FEScripts.Scenes.Menu.CanvasUI
{
    public class DisplayCharacterCanvasUI : AbstractCanvasUI
    {
        private Image playerCharacterImage;
        private Image enemyCharacterImage;

        private void Awake()
        {
            Canvas canvas = GameObject.Find("DisplayCharacterCanvas").GetComponent<Canvas>();
            InitObject(canvas);
        }

        protected override void InitObject(Canvas _canvas)
        {
            // BaseのInitObjectを呼び出す
            base.InitObject(_canvas);
            // 各コンポーネントを取得
            playerCharacterImage = _component.transform.Find("PlayerCharacterImage").GetComponent<Image>();
            enemyCharacterImage = _component.transform.Find("EnemyCharacterImage").GetComponent<Image>();
        }

        public override void SetActions(Action[] _actions)
        {
            // TODO: アクションの設定処理を実装
        }

        public void InitImages(
            string _playerAbbreviationName,
            string _enemyAbbreviationName
        )
        {
            playerCharacterImage.sprite = Resources.Load<Sprite>("Images/Characters/" + _playerAbbreviationName);
            enemyCharacterImage.sprite = Resources.Load<Sprite>("Images/Characters/" + _enemyAbbreviationName);
        }

        public void SetPlayerCharacterImage(string _abbreviationName)
        {
            playerCharacterImage.sprite = Resources.Load<Sprite>("Images/Characters/" + _abbreviationName);
        }

        public void SetEnemyCharacterImage(string _abbreviationName)
        {
            enemyCharacterImage.sprite = Resources.Load<Sprite>("Images/Characters/" + _abbreviationName);
        }
    }
}
