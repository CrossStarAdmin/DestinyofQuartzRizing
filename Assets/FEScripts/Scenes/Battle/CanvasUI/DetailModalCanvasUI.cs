using System;
using Assets.FEScripts.Abstracts;
using Assets.FEScripts.Components.Elements.Modal;
using UnityEngine;

namespace Assets.FEScripts.Scenes.Battle.CanvasUI
{
    public class DetailModalCanvasUI : AbstractCanvasUI
    {
        protected ModalManager _modalManager;
        
        private void Awake()
        {
            Canvas canvas = GameObject.Find("DetailModalCanvas").GetComponent<Canvas>();
            InitObject(canvas);
        }

        protected override void InitObject(Canvas _canvas)
        {
            // BaseのInitObjectを呼び出す
            base.InitObject(_canvas);
            // 各コンポーネントを取得
            _modalManager = _component.transform.Find("DetailModal").GetComponent<ModalManager>();
        }

        public override void SetActions(Action[] _actions)
        {
            // ModalManagerのアクションをセット
            _modalManager.SetActions(_actions);
        }

        public void SetDetailModal(string title, string description)
        {
            _modalManager.InitializeElement(title, description);
        }
    }
}
