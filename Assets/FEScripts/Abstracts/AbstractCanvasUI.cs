using System;
using UnityEngine;

namespace Assets.FEScripts.Abstracts
{
    public abstract class AbstractCanvasUI : MonoBehaviour
    {
        protected Canvas _canvas;
        protected GameObject _component;

        protected virtual void InitObject(Canvas _canvas)
        {
            this._canvas = _canvas;
            this._component = _canvas.transform.Find("Wrapper/Component").gameObject;
        }

        protected abstract void SetActions(Action[] _actions);

        public void DisplayCanvas(bool _isDisplay)
        {
            _canvas.enabled = _isDisplay;
        }
    }
}