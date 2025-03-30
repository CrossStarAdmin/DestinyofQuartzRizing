using System;
using Assets.FEScripts.Abstracts;
using Assets.FEScripts.Scenes.Load.CanvasUI;
using UnityEngine;

namespace Assets.FEScripts.Scenes.Load
{
    public class LoadUI : AbstractUI
    {
        protected Canvas _loadCanvas;
        protected LoadCanvasUI _loadCanvasUI;
        public LoadCanvasUI loadCanvasUI
        {
            get { return _loadCanvasUI; }
        }

        protected override void InitCanvas()
        {
            _loadCanvas = GameObject.Find("LoadCanvas").GetComponent<Canvas>();
        }

        protected override void InitCanvasUI()
        {
            // CanvasUIの設定
            _loadCanvasUI = _loadCanvas.GetComponent<LoadCanvasUI>();
        }

        protected override void SetCanvasDisplay()
        {
            _loadCanvas.enabled = true;
        }
    }
}