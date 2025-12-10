using System;
using Assets.FEScripts.Abstracts;
using Assets.FEScripts.Scenes.Menu.CanvasUI;
using UnityEngine;

namespace Assets.FEScripts.Scenes.Menu
{
    public class MenuUI : AbstractUI
    {
        protected Canvas _menuCanvas, _detailModalCanvas;
        protected DetailModalCanvasUI _detailModalCanvasUI;
        public DetailModalCanvasUI detailModalCanvasUI
        {
            get { return _detailModalCanvasUI; }
        }

        protected override void InitCanvas()
        {
            // BaseのInitCanvasを呼び出す
            base.InitCanvas();
            // 各Canvasを取得
            _menuCanvas = GameObject.Find("MenuCanvas").GetComponent<Canvas>();
            _detailModalCanvas = GameObject.Find("DetailModalCanvas").GetComponent<Canvas>();
        }

        protected override void InitCanvasUI()
        {
            // BaseのInitCanvasUIを呼び出す
            base.InitCanvasUI();
            // CanvasUIの設定
            _detailModalCanvasUI = _detailModalCanvas.GetComponent<DetailModalCanvasUI>();
        }

        protected override void SetCanvasDisplay()
        {
            // BaseのSetCanvasDisplayを呼び出す
            base.SetCanvasDisplay();
            // 各Canvasの初期表示を設定
            _menuCanvas.enabled = true;
            _detailModalCanvas.enabled = false;
        }

        public void DisplayDetailModalCanvas(bool _isDisplay)
        {
            _detailModalCanvas.enabled = _isDisplay;
        }
    }
}