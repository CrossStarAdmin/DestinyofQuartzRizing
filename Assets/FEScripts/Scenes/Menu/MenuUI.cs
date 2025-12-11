using System;
using Assets.FEScripts.Abstracts;
using Assets.FEScripts.Scenes.Menu.CanvasUI;
using UnityEngine;

namespace Assets.FEScripts.Scenes.Menu
{
    public class MenuUI : AbstractUI
    {
        protected Canvas _displayCharacterCanvas, _selectCharacterCanvas, _buttonCanvas, _detailModalCanvas;
        
        protected DisplayCharacterCanvasUI _displayCharacterCanvasUI;
        public DisplayCharacterCanvasUI displayCharacterCanvasUI
        {
            get { return _displayCharacterCanvasUI; }
        }

        protected SelectCharacterCanvasUI _selectCharacterCanvasUI;
        public SelectCharacterCanvasUI selectCharacterCanvasUI
        {
            get { return _selectCharacterCanvasUI; }
        }

        protected ButtonCanvasUI _buttonCanvasUI;
        public ButtonCanvasUI buttonCanvasUI
        {
            get { return _buttonCanvasUI; }
        }

        protected DetailModalCanvasUI _detailModalCanvasUI;
        public DetailModalCanvasUI detailModalCanvasUI
        {
            get { return _detailModalCanvasUI; }
        }

        protected override void InitCanvas()
        {
            // BaseのInitCanvasを呼び出す（HeaderCanvasとFadeCanvasを初期化）
            base.InitCanvas();
            // 各Canvasを取得
            _displayCharacterCanvas = GameObject.Find("DisplayCharacterCanvas").GetComponent<Canvas>();
            _selectCharacterCanvas = GameObject.Find("SelectCharacterCanvas").GetComponent<Canvas>();
            _buttonCanvas = GameObject.Find("ButtonCanvas").GetComponent<Canvas>();
            _detailModalCanvas = GameObject.Find("DetailModalCanvas").GetComponent<Canvas>();
        }

        protected override void InitCanvasUI()
        {
            // BaseのInitCanvasUIを呼び出す（HeaderCanvasUIとFadeCanvasUIを初期化）
            base.InitCanvasUI();
            // CanvasUIの設定
            _displayCharacterCanvasUI = _displayCharacterCanvas.GetComponent<DisplayCharacterCanvasUI>();
            _selectCharacterCanvasUI = _selectCharacterCanvas.GetComponent<SelectCharacterCanvasUI>();
            _buttonCanvasUI = _buttonCanvas.GetComponent<ButtonCanvasUI>();
            _detailModalCanvasUI = _detailModalCanvas.GetComponent<DetailModalCanvasUI>();
        }

        protected override void SetCanvasDisplay()
        {
            // BaseのSetCanvasDisplayを呼び出す（HeaderCanvasとFadeCanvasを表示）
            base.SetCanvasDisplay();
            // 各Canvasの初期表示を設定
            _displayCharacterCanvas.enabled = true;
            _selectCharacterCanvas.enabled = true;
            _buttonCanvas.enabled = true;
            _detailModalCanvas.enabled = false;
        }

        public void DisplayDetailModalCanvas(bool _isDisplay)
        {
            _detailModalCanvas.enabled = _isDisplay;
        }

        public void DisplayDisplayCharacterCanvas(bool _isDisplay)
        {
            _displayCharacterCanvas.enabled = _isDisplay;
        }

        public void DisplaySelectCharacterCanvas(bool _isDisplay)
        {
            _selectCharacterCanvas.enabled = _isDisplay;
        }

        public void DisplayButtonCanvas(bool _isDisplay)
        {
            _buttonCanvas.enabled = _isDisplay;
        }
    }
}