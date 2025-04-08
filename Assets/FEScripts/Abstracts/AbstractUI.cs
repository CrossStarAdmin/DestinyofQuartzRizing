using System;
using Assets.FEScripts.Components.CanvasUI;
using UnityEngine;

namespace Assets.FEScripts.Abstracts
{
    public abstract class AbstractUI : MonoBehaviour
    {
        protected Canvas _headerCanvas, _fadeCanvas;
        protected HeaderCanvasUI _headerCanvasUI;
        public HeaderCanvasUI headerCanvasUI
        {
            get { return _headerCanvasUI; }
        }
        protected FadeCanvasUI _fadeCanvasUI;
        public FadeCanvasUI fadeCanvasUI
        {
            get { return _fadeCanvasUI; }
        }

        public void Awake()
        {
            InitCanvas();
            InitCanvasUI();
            SetCanvasDisplay();
        }
        /// <summary>
        /// 各Canvasを初期化する
        /// </summary>
        /// <returns></returns>
        protected virtual void InitCanvas()
        {
            if (GameObject.Find("HeaderCanvas") != null)
                _headerCanvas = GameObject.Find("HeaderCanvas").GetComponent<Canvas>();
            if (GameObject.Find("FadeCanvas") != null)
                _fadeCanvas = GameObject.Find("FadeCanvas").GetComponent<Canvas>();
        }

        /// <summary>
        /// 各CanvasUIを初期化する
        /// </summary>
        /// <returns></returns>
        protected virtual void InitCanvasUI()
        {
            if (_headerCanvas != null)
                _headerCanvasUI = _headerCanvas.GetComponent<HeaderCanvasUI>();
            if (_fadeCanvas != null)
                _fadeCanvasUI = _fadeCanvas.GetComponent<FadeCanvasUI>();
        }

        /// <summary>
        /// 各Canvasの初期表示を設定する
        /// </summary>
        /// <returns></returns>
        protected virtual void SetCanvasDisplay()
        {
            if (_headerCanvas != null)
                _headerCanvas.enabled = true;
            if (_fadeCanvas != null)
                _fadeCanvas.enabled = true;
        }
    }
}