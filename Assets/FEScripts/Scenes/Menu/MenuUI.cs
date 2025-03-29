using System;
using Assets.FEScripts.Abstracts;
using Assets.FEScripts.Scenes.Menu.CanvasUI;
using UnityEngine;

namespace Assets.FEScripts.Scenes.Menu
{
    public class MenuUI : AbstractUI
    {
        protected Canvas _menuCanvas, _detailModalCanvas;
        protected MenuCanvasUI _menuCanvasUI;
        public MenuCanvasUI menuCanvasUI
        {
            get { return _menuCanvasUI; }
        }
        protected DetailModalCanvasUI _detailModalCanvasUI;
        public DetailModalCanvasUI detailModalCanvasUI
        {
            get { return _detailModalCanvasUI; }
        }

        protected override void InitCanvas()
        {
            _menuCanvas = GameObject.Find("MenuCanvas").GetComponent<Canvas>();
            _detailModalCanvas = GameObject.Find("DetailModalCanvas").GetComponent<Canvas>();
        }

        protected override void InitCanvasUI()
        {
            // CanvasUIの設定
            _menuCanvasUI = _menuCanvas.GetComponent<MenuCanvasUI>();
            _detailModalCanvasUI = _detailModalCanvas.GetComponent<DetailModalCanvasUI>();
        }

        protected override void SetCanvasDisplay()
        {
            _menuCanvas.enabled = true;
            _detailModalCanvas.enabled = false;
        }

        public override void SetButtonActions(Action[] _actions) { }

        public void DisplayDetailModalCanvas(bool _isDisplay)
        {
            _detailModalCanvas.enabled = _isDisplay;
        }
    }
}