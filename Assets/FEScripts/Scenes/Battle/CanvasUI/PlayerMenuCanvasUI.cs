using System;
using Assets.FEScripts.Abstracts;
using Assets.FEScripts.Components.UI;
using UnityEngine;

namespace Assets.FEScripts.Scenes.Battle.CanvasUI
{
    public class PlayerMenuCanvasUI : AbstractCanvasUI
    {
        private OriginButtonComponent startTurnButton;
        private OriginButtonComponent diceButton;


        private void Awake()
        {
            Canvas canvas = GameObject.Find("PlayerMenuCanvas").GetComponent<Canvas>();
            InitObject(canvas);
        }

        protected override void InitObject(Canvas _canvas)
        {
            // BaseのInitObjectを呼び出す
            base.InitObject(_canvas);
            // 各コンポーネントを取得
            startTurnButton = _component.transform.Find("StartTurnButton").GetComponent<OriginButtonComponent>();
            diceButton = _component.transform.Find("DiceButton").GetComponent<OriginButtonComponent>();
        }

        public override void SetActions(Action[] _actions)
        {
            // TODO: 各メニューボタンのアクション設定処理を実装
            startTurnButton.InitOriginButtonComponent(_actions[0]);
            diceButton.InitOriginButtonComponent(_actions[1]);
        }
    }
}
