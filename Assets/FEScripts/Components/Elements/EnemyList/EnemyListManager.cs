using System;
using Assets.FEScripts.Abstracts;

namespace Assets.FEScripts.Components.Elements.EnemyList
{
    public class EnemyListManager : AbstractComponent<EnemyListUI>
    {
        public void InitializeElement(string _titleText, string _detailText)
        {
            _componentUI.SetTitleText(_titleText);
            _componentUI.SetDetailText(_detailText);
        }

        public void SetActions(Action[] _actions)
        {
            _componentUI.SetActions(_actions);
        }
    }
}