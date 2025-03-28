using Assets.FEScripts.Abstracts;

namespace Assets.FEScripts.Components.EnemyList
{
    public class EnemyListManager : AbstractComponent<EnemyListUI>
    {
        public void InitializeElement(string _titleText, string _detailText)
        {
            _componentUI.SetTitleText(_titleText);
            _componentUI.SetDetailText(_detailText);
        }
    }
}