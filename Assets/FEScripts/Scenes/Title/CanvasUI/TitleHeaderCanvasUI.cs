using System;
using Assets.FEScripts.Abstracts;
using Assets.FEScripts.Components.UI;
using UnityEngine;

namespace Assets.FEScripts.Scenes.Title.CanvasUI
{
    public class TitleHeaderCanvasUI : AbstractCanvasUI
    {
        private OriginButtonComponent _iconButton;

        private void Awake()
        {
            Canvas canvas = GameObject.Find("TitleHeaderCanvas").GetComponent<Canvas>();
            InitObject(canvas);
        }

        protected override void InitObject(Canvas _canvas)
        {
            base.InitObject(_canvas);
            // 各コンポーネントを取得
            _iconButton = _component.transform.Find("IconButton").GetComponent<OriginButtonComponent>();
        }

        public override void SetActions(Action[] _actions)
        {
            // IconButtonのアクションをセット
            _iconButton.InitOriginButtonComponent(_actions[0]);
        }
    }
}