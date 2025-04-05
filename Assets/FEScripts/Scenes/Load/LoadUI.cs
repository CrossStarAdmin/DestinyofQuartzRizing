using System;
using Assets.FEScripts.Abstracts;
using Assets.FEScripts.Scenes.Load.CanvasUI;
using UnityEditor.PackageManager;
using UnityEngine;

namespace Assets.FEScripts.Scenes.Load
{
    public class LoadUI : AbstractUI
    {
        protected Canvas _loadCanvas, _errorModalCanvas;
        protected LoadCanvasUI _loadCanvasUI;
        public LoadCanvasUI loadCanvasUI
        {
            get { return _loadCanvasUI; }
        }
        protected ErrorModalCanvasUI _errorModalCanvasUI;
        public ErrorModalCanvasUI errorModalCanvasUI
        {
            get { return _errorModalCanvasUI; }
        }

        protected override void InitCanvas()
        {
            _loadCanvas = GameObject.Find("LoadCanvas").GetComponent<Canvas>();
            _errorModalCanvas = GameObject.Find("ErrorModalCanvas").GetComponent<Canvas>();
        }

        protected override void InitCanvasUI()
        {
            // CanvasUIの設定
            _loadCanvasUI = _loadCanvas.GetComponent<LoadCanvasUI>();
            _errorModalCanvasUI = _errorModalCanvas.GetComponent<ErrorModalCanvasUI>();
        }

        protected override void SetCanvasDisplay()
        {
            _loadCanvas.enabled = true;
            _errorModalCanvas.enabled = false;
        }
    }
}