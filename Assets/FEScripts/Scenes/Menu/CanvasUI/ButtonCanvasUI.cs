using System;
using Assets.FEScripts.Abstracts;
using Assets.FEScripts.Components.UI;
using UnityEngine;

namespace Assets.FEScripts.Scenes.Menu.CanvasUI
{
    public class ButtonCanvasUI : AbstractCanvasUI
    {
        private OriginButtonComponent _startButton;
        private void Awake()
        {
            Canvas canvas = GameObject.Find("ButtonCanvas").GetComponent<Canvas>();
            InitObject(canvas);
        }

        protected override void InitObject(Canvas _canvas)
        {
            // BaseのInitObjectを呼び出す
            base.InitObject(_canvas);
            // 各コンポーネントを取得
            _startButton = _component.transform.Find("Button").GetComponent<OriginButtonComponent>();
        }

        public override void SetActions(Action[] _actions)
        {
            // StartButtonのアクションをセット
            _startButton.InitOriginButtonComponent(_actions[0]);
        }
    }
}
