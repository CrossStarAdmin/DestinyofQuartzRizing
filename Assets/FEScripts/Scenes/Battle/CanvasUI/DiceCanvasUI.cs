using System;
using Assets.FEScripts.Abstracts;
using Assets.FEScripts.Components.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;

namespace Assets.FEScripts.Scenes.Battle.CanvasUI
{
    public class DiceCanvasUI : AbstractCanvasUI
    {
        // ==================================================
        // フィールド
        // ==================================================
        private OriginButtonComponent canvasButton;
        private DiceComponent _diceComponent;
        private TextMeshProUGUI _diceNumberText;

        // ==================================================
        // 初期化
        // ==================================================
        private void Awake()
        {
            Canvas canvas = GameObject.Find("DiceCanvas").GetComponent<Canvas>();
            InitObject(canvas);
        }

        protected override void InitObject(Canvas _canvas)
        {
            base.InitObject(_canvas);
            canvasButton = _component.GetComponent<OriginButtonComponent>();
            _diceComponent = _component.transform.Find("Dice").GetComponent<DiceComponent>();
            _diceNumberText = _component.transform.Find("DiceNumberText").GetComponent<TextMeshProUGUI>();
        }

        public override void SetActions(Action[] _actions)
        {
            canvasButton.InitOriginButtonComponent(_actions[0]);
        }

        // ==================================================
        // 公開メソッド
        // ==================================================
        public async UniTask RollDice()
        {
            int result = UnityEngine.Random.Range(1, 7);
            
            // アニメーション開始前にテキストをクリア
            _diceNumberText.text = "";
            
            // ダイスアニメーションを実行し、完了を待つ
            await _diceComponent.RollAnimation(result);
            
            // アニメーション完了後に結果を表示
            _diceNumberText.text = result.ToString();
            Debug.Log($"Dice result displayed: {result}");
        }
    }
}
