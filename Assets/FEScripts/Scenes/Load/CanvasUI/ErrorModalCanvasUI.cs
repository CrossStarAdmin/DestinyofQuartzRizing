using System;
using Assets.FEScripts.Abstracts;
using Assets.FEScripts.Components.Elements.Modal;
using UnityEngine;

namespace Assets.FEScripts.Scenes.Load.CanvasUI
{
    public class ErrorModalCanvasUI : AbstractCanvasUI
    {
        protected ModalManager _modalManager;

        private void Awake()
        {
            Canvas canvas = GameObject.Find("ErrorModalCanvas").GetComponent<Canvas>();
            InitObject(canvas);
        }

        protected override void InitObject(Canvas _canvas)
        {
            // BaseのInitObjectを呼び出す
            base.InitObject(_canvas);
            // 各コンポーネントを取得
            _modalManager = _component.transform.Find("ErrorModal").GetComponent<ModalManager>();
        }

        public override void SetActions(Action[] _actions)
        {
            // ModalManagerのアクションをセット
            _modalManager.SetActions(_actions);
        }

        public void InitializeModal()
        {
            // 初期設定
            _modalManager.InitializeVarietyButton(true, "RETRY");
            _modalManager.InitializeCloseButton(false);
        }
    }
}