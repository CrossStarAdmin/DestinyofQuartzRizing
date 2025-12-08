using System;
using Assets.FEScripts.Abstracts;
using Assets.FEScripts.Components.UI;
using UnityEngine;

namespace Assets.FEScripts.Scenes.Title.CanvasUI
{
    public class TitleHeaderCanvasUI : AbstractCanvasUI
    {
        private OriginButtonComponent _purchaseButton;
        private OriginButtonComponent _playerInfoButton;

        private void Awake()
        {
            Canvas canvas = GameObject.Find("TitleHeaderCanvas").GetComponent<Canvas>();
            InitObject(canvas);
        }

        protected override void InitObject(Canvas _canvas)
        {
            base.InitObject(_canvas);
            // 各コンポーネントを取得

            // _purchaseButton = _component.transform.Find("PurchaseButton").GetComponent<OriginButtonComponent>();
            // _playerInfoButton = _component.transform.Find("PlayerInfoButton").GetComponent<OriginButtonComponent>();
        }

        public override void SetActions(Action[] _actions)
        {
            // IconButtonのアクションをセット
            // _purchaseButton.InitOriginButtonComponent(_actions[0]);
            // _playerInfoButton.InitOriginButtonComponent(_actions[0]);
        }
    }
}