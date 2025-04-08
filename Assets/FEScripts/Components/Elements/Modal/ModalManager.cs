using System;
using System.Diagnostics;
using Assets.FEScripts.Abstracts;
using UnityEngine;

namespace Assets.FEScripts.Components.Elements.Modal
{
    public class ModalManager : AbstractComponent<ModalUI>
    {
        public void InitializeElement(
            string _titleText,
            string _detailText
        )
        {
            _componentUI.SetTitleText(_titleText);
            _componentUI.SetDetailText(_detailText);
        }

        public void InitializeVarietyButton(
            bool _isDisplay,
            string _varietyButtonText = "Variety"
        )
        {
            _componentUI.DisplayVarietyButton(_isDisplay);
            if (_isDisplay)
            {
                _componentUI.SetVarietyButtonText(_varietyButtonText);
            }
        }

        public void InitializeCloseButton(
            bool _isDisplay
        )
        {
            _componentUI.DisplayCloseButton(_isDisplay);
        }

        public void SetActions(Action[] _actions)
        {
            _componentUI.SetActions(_actions);
        }
    }
}