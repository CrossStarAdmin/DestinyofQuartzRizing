using Assets.FEScripts.Abstracts;
using TMPro;
using UnityEngine;

namespace Assets.FEScripts.Components.EnemyList
{
    public class EnemyListUI : AbstractComponentUI
    {
        private TextMeshProUGUI _titleText;
        private TextMeshProUGUI _detailText;

        protected override void InitObject()
        {
            // これが指定されてるコンポーんねんとを親として取得
            _titleText = transform.Find("TitleText").GetComponent<TextMeshProUGUI>();
            _detailText = transform.Find("DetailText").GetComponent<TextMeshProUGUI>();
        }

        protected override void SetActions()
        {
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