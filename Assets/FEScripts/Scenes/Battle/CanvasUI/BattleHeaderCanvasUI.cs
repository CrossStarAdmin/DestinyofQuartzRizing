using System;
using Assets.FEScripts.Abstracts;
using Assets.FEScripts.Components.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.FEScripts.Scenes.Battle.CanvasUI
{
    public class BattleHeaderCanvasUI : AbstractCanvasUI
    {
        private OriginButtonComponent _backButton;

        private void Awake()
        {
            Canvas canvas = GameObject.Find("HeaderCanvas").GetComponent<Canvas>();
            InitObject(canvas);
        }

        protected override void InitObject(Canvas _canvas)
        {
            base.InitObject(_canvas);
            _backButton = _component.transform.Find("BackButton").GetComponent<OriginButtonComponent>();
        }

        public override void SetActions(Action[] _actions)
        {
            _backButton.InitOriginButtonComponent(_actions[0]);
        }
    }
}