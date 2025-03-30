using System;
using Assets.FEScripts.Abstracts;
using Assets.FEScripts.Components.UI;
using TMPro;
using UnityEngine;

namespace Assets.FEScripts.Components.CanvasUI
{
    public class HeaderCanvasUI : AbstractCanvasUI
    {
        protected OriginButtonComponent _backButton;
        protected OriginButtonComponent _questionButton;
        protected TextMeshProUGUI _titleText;

        private void Awake()
        {
            Canvas canvas = GameObject.Find("HeaderCanvas").GetComponent<Canvas>();
            InitObject(canvas);
        }

        protected override void InitObject(Canvas _canvas)
        {
            // BaseのInitObjectを呼び出す
            base.InitObject(_canvas);
            // 各コンポーネントを取得
            _backButton = _component.transform.Find("HeaderElement/BackButton").GetComponent<OriginButtonComponent>();
            _questionButton = _component.transform.Find("HeaderElement/QuestionButton").GetComponent<OriginButtonComponent>();
            _titleText = _component.transform.Find("HeaderElement/TitleText").GetComponent<TextMeshProUGUI>();
        }

        public override void SetActions(Action[] _actions)
        {
            // BackButtonのアクションをセット
            _backButton.InitOriginButtonComponent(
                _actions[0]
            );
            // QuestionButtonのアクションをセット
            _questionButton.InitOriginButtonComponent(
                _actions[1]
            );
        }

        public void SetTitleText(string title)
        {
            _titleText.text = title;
        }
    }
}