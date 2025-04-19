using System;
using System.Diagnostics;
using Assets.FEScripts.Abstracts;
using Assets.FEScripts.Components.UI;
using TMPro;
using UnityEngine;

namespace Assets.FEScripts.Components.Elements.Modal
{
    public class ModalUI : AbstractComponentUI
    {
        private TextMeshProUGUI _titleText;
        private TextMeshProUGUI _detailText;
        private OriginButtonComponent _varietyButton;
        private TextMeshProUGUI _varietyButtonText;
        private OriginButtonComponent _closeButton;
        protected override void InitObject()
        {
            _varietyButton = transform.Find("VarietyButton").GetComponent<OriginButtonComponent>();
            _varietyButtonText = transform.transform.Find("VarietyButton/Text").GetComponent<TextMeshProUGUI>();
            _closeButton = transform.Find("CloseButton").GetComponent<OriginButtonComponent>();
            _titleText = transform.Find("TitleElement/Text").GetComponent<TextMeshProUGUI>();
            _detailText = transform.Find("DetailText").GetComponent<TextMeshProUGUI>();
        }

        public override void SetActions(Action[] _actions)
        {
            _varietyButton.InitOriginButtonComponent(
                _actions[0]
            );
            _closeButton.InitOriginButtonComponent(
                _actions[1]
            );
        }

        public void SetTitleText(string title)
        {
            _titleText.text = title;
        }

        public void SetDetailText(string detail)
        {
            _detailText.text = detail;
        }

        public void SetVarietyButtonText(string text)
        {
            _varietyButtonText.text = text;
        }

        public void DisplayVarietyButton(bool isDisplay)
        {
            _varietyButton.DisplayButton(isDisplay);
        }

        public void DisplayCloseButton(bool isDisplay)
        {
            _closeButton.DisplayButton(isDisplay);
        }
    }
}