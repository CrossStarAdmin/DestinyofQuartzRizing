using System;
using System.Threading.Tasks;
using Assets.FEScripts.Abstracts;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Assets.FEScripts.Components.CanvasUI
{
    public class FadeCanvasUI : AbstractCanvasUI
    {
        private void Awake()
        {
            Canvas canvas = GameObject.Find("FadeCanvas").GetComponent<Canvas>();
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

        public async UniTask FadeIn()
        {
            // ページを開いたときの最初の処理
            await Task.Delay(1000); // 1秒待機
            // FadeCanvasを非表示にする
            DisplayCanvas(false);
        }

        public async UniTask FadeOut()
        {
            // FadeCanvasを表示する
            DisplayCanvas(true);
            // ページを閉じるときの処理
            await Task.Delay(1000); // 1秒待機
        }
    }
}