using System;
using UnityEngine;

namespace Assets.FEScripts.Abstracts
{
    public abstract class AbstractUI : MonoBehaviour
    {
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
        protected abstract void InitCanvas();

        /// <summary>
        /// 各CanvasUIを初期化する
        /// </summary>
        /// <returns></returns>
        protected abstract void InitCanvasUI();

        /// <summary>
        /// 各Canvasの初期表示を設定する
        /// </summary>
        /// <returns></returns>
        protected abstract void SetCanvasDisplay();

        /// <summary>
        /// ButtonのActionを設定する
        /// </summary>
        public abstract void SetButtonActions(Action[] _actions);
    }
}