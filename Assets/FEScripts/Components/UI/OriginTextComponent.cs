using UnityEngine;
using Assets.FEScripts.Functions;
using TMPro;

namespace Assets.FEScripts.Components.UI
{
    public class OriginTextComponent : MonoBehaviour
    {
        // UI関係
        private TextMeshProUGUI _text;

        private void Start()
        {
            _text = GetComponentFunction.Execute<TextMeshProUGUI>("", gameObject);
        }

        public void SetText(string _textString)
        {
            _text.text = _textString;
        }
    }
}