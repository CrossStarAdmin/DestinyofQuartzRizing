using UnityEngine;

namespace Assets.FEScripts.Abstracts
{
    public abstract class AbstractComponentUI : MonoBehaviour
    {
        protected abstract void InitObject();
        protected abstract void SetActions();

        private void Awake()
        {
            InitObject();
            SetActions();
        }
    }
}