using System;
using Assets.FEScripts.Abstracts;
using Assets.FEScripts.Scenes.Purchase.CanvasUI;
using UnityEngine;

namespace Assets.FEScripts.Scenes.Purchase
{
    public class PurchaseUI : AbstractUI
    {
        protected Canvas _menuCanvas;
        protected MenuCanvasUI _menuCanvasUI;
        public MenuCanvasUI menuCanvasUI
        {
            get { return _menuCanvasUI; }
        }

        protected override void InitCanvas()
        {
            // BaseのInitCanvasを呼び出す
            base.InitCanvas();
            // 各Canvasを取得
            _menuCanvas = GameObject.Find("MenuCanvas").GetComponent<Canvas>();
        }

        protected override void InitCanvasUI()
        {
            // BaseのInitCanvasUIを呼び出す
            base.InitCanvasUI();
            // CanvasUIの設定
            _menuCanvasUI = _menuCanvas.GetComponent<MenuCanvasUI>();
        }

        protected override void SetCanvasDisplay()
        {
            // BaseのSetCanvasDisplayを呼び出す
            base.SetCanvasDisplay();
            // 各Canvasの初期表示を設定
            _menuCanvas.enabled = true;
        }
    }
}