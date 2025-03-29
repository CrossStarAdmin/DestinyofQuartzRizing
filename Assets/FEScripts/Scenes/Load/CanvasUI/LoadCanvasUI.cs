using System;
using Assets.FEScripts.Abstracts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.FEScripts.Scenes.Load.CanvasUI
{
    public class LoadCanvasUI : AbstractCanvasUI
    {
        private Slider loadSlider;
        private TextMeshProUGUI loadText;

        private void Awake()
        {
            Canvas canvas = GameObject.Find("LoadCanvas").GetComponent<Canvas>();
            InitObject(canvas);
        }

        protected override void InitObject(Canvas _canvas)
        {
            // BaseのInitObjectを実行
            base.InitObject(_canvas);
            // 各コンポーネントを取得
            loadSlider = _component.transform.Find("LoadSlider").GetComponent<Slider>();
            loadText = _component.transform.Find("LoadSlider/Text").GetComponent<TextMeshProUGUI>();
            // 初期設定
            InitSlider();
        }

        public override void SetActions(Action[] _actions) { }

        public void InitSlider()
        {
            loadSlider.value = 0;
            loadText.text = "Loading...0%";
        }

        public void UpdateSlider(float _value)
        {
            loadSlider.value = _value;
            float percent = Mathf.Ceil(_value);
            loadText.text = $"Loading...{percent}%";
        }
    }
}