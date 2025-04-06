using System;
using Assets.FEScripts.Abstracts;
using Assets.FEScripts.Components.UI;
using UnityEngine;

namespace Assets.FEScripts.Scenes.Title.CanvasUI
{
    public class PlayButtonCanvasUI : AbstractCanvasUI
    {
        private OriginButtonComponent _playButton;

        private void Awake()
        {
            Canvas canvas = GameObject.Find("PlayButtonCanvas").GetComponent<Canvas>();
            InitObject(canvas);
        }

        protected override void InitObject(Canvas _canvas)
        {
            base.InitObject(_canvas);
            // 各コンポーネントを取得
            _playButton = _component.transform.Find("PlayButton").GetComponent<OriginButtonComponent>();
        }

        public override void SetActions(Action[] _actions)
        {
            // PlayButtonのアクションをセット
            _playButton.InitOriginButtonComponent(_actions[0]);
        }
    }
}