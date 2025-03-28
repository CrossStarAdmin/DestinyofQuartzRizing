using System;
using Assets.FEScripts.Abstracts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.FEScripts.Scenes.Menu.CanvasUI
{
    public class MenuCanvasUI : AbstractCanvasUI
    {

        private void Awake()
        {
            Canvas canvas = GameObject.Find("MenuCanvas").GetComponent<Canvas>();
            InitObject(canvas);
        }

        protected override void InitObject(Canvas _canvas)
        {
            // BaseのInitObjectを実行
            base.InitObject(_canvas);
            // 各コンポーネントを取得
            // 初期設定
        }

        protected override void SetActions(Action[] _actions) { }

    }
}