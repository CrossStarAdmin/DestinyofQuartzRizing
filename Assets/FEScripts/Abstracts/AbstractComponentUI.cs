using System;
using UnityEngine;

namespace Assets.FEScripts.Abstracts
{
    public abstract class AbstractComponentUI : MonoBehaviour
    {
        protected abstract void InitObject();
        public abstract void SetActions(Action[] _actions);

        private void Awake()
        {
            InitObject();
        }
    }
}