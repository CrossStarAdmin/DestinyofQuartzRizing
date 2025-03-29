using System;
using Assets.FEScripts.Abstracts;
using Assets.FEScripts.Components.UI;
using TMPro;
using UnityEngine;

namespace Assets.FEScripts.Components.Elements.EnemyList
{
    public class EnemyListUI : AbstractComponentUI
    {
        private TextMeshProUGUI _titleText;
        private TextMeshProUGUI _detailText;
        private OriginButtonComponent _enemyDetailButton;

        protected override void InitObject()
        {
            _enemyDetailButton = transform.Find("").GetComponent<OriginButtonComponent>();
            _titleText = transform.Find("TitleText").GetComponent<TextMeshProUGUI>();
            _detailText = transform.Find("DetailText").GetComponent<TextMeshProUGUI>();
        }

        public override void SetActions(Action[] _actions)
        {
            _enemyDetailButton.InitOriginButtonComponent(
                _actions[0]
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
    }
}