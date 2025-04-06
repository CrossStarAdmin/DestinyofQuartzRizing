using System;
using Assets.FEScripts.Abstracts;
using UnityEngine;

namespace Assets.FEScripts.Scenes.Title.CanvasUI
{
    public class TitleCanvasUI : AbstractCanvasUI
    {
        private void Awake()
        {
            Canvas canvas = GameObject.Find("TitleCanvas").GetComponent<Canvas>();
            InitObject(canvas);
        }

        protected override void InitObject(Canvas _canvas)
        {
            base.InitObject(_canvas);
            // 各コンポーネントを取得
        }

        public override void SetActions(Action[] _actions)
        {
            // アクションのセット
        }
    }
}