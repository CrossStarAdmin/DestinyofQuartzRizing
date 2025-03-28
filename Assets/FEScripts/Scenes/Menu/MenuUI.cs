using System;
using Assets.FEScripts.Abstracts;
using Assets.FEScripts.Scenes.Menu.CanvasUI;
using UnityEngine;

namespace Assets.FEScripts.Scenes.Menu
{
    public class MenuUI : AbstractUI
    {
        protected Canvas _menuCanvas;
        protected MenuCanvasUI _menuCanvasUI;
        public MenuCanvasUI menuCanvasUI
        {
            get { return _menuCanvasUI; }
        }

        protected override void InitCanvas()
        {
            _menuCanvas = GameObject.Find("MenuCanvas").GetComponent<Canvas>();
        }

        protected override void InitCanvasUI()
        {
            // CanvasUIの設定
            _menuCanvasUI = _menuCanvas.GetComponent<MenuCanvasUI>();
        }

        protected override void SetCanvasDisplay()
        {
            _menuCanvas.enabled = true;
        }

        protected override void SetButtonActions(Action[] _actions) { }
    }
}