using UnityEngine;

namespace Assets.FEScripts.Abstracts
{
    public abstract class AbstractComponent<ComponentUI>
        : MonoBehaviour
        where ComponentUI : AbstractComponentUI
    {
        protected ComponentUI _componentUI;
        private void Awake()
        {
            _componentUI = GetComponent<ComponentUI>();
        }
    }
}