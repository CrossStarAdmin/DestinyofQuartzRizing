using System;
using Assets.FEScripts.Abstracts;
using Assets.FEScripts.Components.UI;
using Assets.FEScripts.Types;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

namespace Assets.FEScripts.Scenes.Battle.CanvasUI
{
    public class EnemyInfoCanvasUI : AbstractCanvasUI
    {
        // ==================================================
        // フィールド
        // ==================================================
        private Image characterImage;
        private TextMeshProUGUI hpText;
        private TextMeshProUGUI mpText;
        private Slider hpSlider;
        private TensionComponent _tensionComponent;

        // ==================================================
        // 初期化
        // ==================================================
        private void Awake()
        {
            Canvas canvas = GameObject.Find("EnemyInfoCanvas").GetComponent<Canvas>();
            InitObject(canvas);
        }

        protected override void InitObject(Canvas _canvas)
        {
            // BaseのInitObjectを呼び出す
            base.InitObject(_canvas);
            // 各コンポーネントを取得
            characterImage = _component.transform.Find("EnemyElement/CharacterImage").GetComponent<Image>();
            hpText = _component.transform.Find("EnemyElement/HPElement/MainText").GetComponent<TextMeshProUGUI>();
            mpText = _component.transform.Find("EnemyElement/MPElement/MainText").GetComponent<TextMeshProUGUI>();
            hpSlider = _component.transform.Find("EnemyElement/HPSlider").GetComponent<Slider>();
            
            // TensionComponentの初期化
            Transform tensionElement = _component.transform.Find("EnemyElement/TensionElement");
            _tensionComponent = tensionElement.gameObject.AddComponent<TensionComponent>();
            _tensionComponent.InitTensionComponent(tensionElement);
        }

        public override void SetActions(Action[] _actions)
        {
            // アクション不要（表示専用）
        }

        // ==================================================
        // 表示更新メソッド
        // ==================================================
        private void SetCharacterImage(CharacterType characterType)
        {
            characterImage.sprite = Resources.Load<Sprite>("Images/Characters/Skelton/" + characterType.abbreviationName + ".skelton");
        }

        private void SetMaxHP(int maxHP)
        {
            hpSlider.maxValue = maxHP;
        }

        private void SetHP(int currentHP)
        {
            hpText.text = currentHP.ToString();
            hpSlider.value = currentHP;
        }

        private void SetMP(int currentMP)
        {
            mpText.text = currentMP.ToString();
        }

        // ==================================================
        // 公開メソッド
        // ==================================================
        public void Init(
            CharacterType characterType,
            int maxHP,
            int tensionLevel
        )
        {
            SetCharacterImage(characterType);
            SetHP(maxHP);
            SetMP(0);
            _tensionComponent.Initialize(tensionLevel, characterType.abbreviationName);
        }

        // 敵情報を更新するメソッド
        public void UpdateEnemyInfo(string name, int currentHP, int maxHP, int currentMP, int maxMP)
        {
            // TODO: 敵情報の表示更新処理を実装
        }
    }
}
