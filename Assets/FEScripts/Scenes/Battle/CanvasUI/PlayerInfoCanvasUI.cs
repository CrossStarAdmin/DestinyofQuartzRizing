using System;
using Assets.FEScripts.Abstracts;
using Assets.FEScripts.Components.UI;
using Assets.FEScripts.Types;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.FEScripts.Scenes.Battle.CanvasUI
{
    public class PlayerInfoCanvasUI : AbstractCanvasUI
    {
        private Image characterImage;
        private TextMeshProUGUI hpText;
        private Slider hpSlider;
        private TensionComponent _tensionComponent;
        private OriginButtonComponent _hpReduceButton;
        private OriginButtonComponent _hpAddButton;

        private void Awake()
        {
            Canvas canvas = GameObject.Find("PlayerInfoCanvas").GetComponent<Canvas>();
            InitObject(canvas);
        }

        protected override void InitObject(Canvas _canvas)
        {
            // BaseのInitObjectを呼び出す
            base.InitObject(_canvas);
            // 各コンポーネントを取得
            characterImage = _component.transform.Find("CharacterImage").GetComponent<Image>();
            hpText = _component.transform.Find("HPElement/MainText").GetComponent<TextMeshProUGUI>();
            hpSlider = _component.transform.Find("HPSlider").GetComponent<Slider>();

            // TensionComponentの初期化
            Transform tensionElement = _component.transform.Find("TensionElement");
            _tensionComponent = tensionElement.gameObject.AddComponent<TensionComponent>();
            _tensionComponent.InitTensionComponent(tensionElement);

            // HP操作ボタンの初期化
            _hpReduceButton = _component.transform.Find("HPSlider/ReduceButton").GetComponent<OriginButtonComponent>();
            _hpAddButton = _component.transform.Find("HPSlider/AddButton").GetComponent<OriginButtonComponent>();
        }

        public override void SetActions(Action[] _actions)
        {
            // TODO: アクションの設定処理を実装
            _hpReduceButton.InitOriginButtonComponent(_actions[0]);
            _hpAddButton.InitOriginButtonComponent(_actions[1]);
        }

        private void SetCharacterImage(CharacterType characterType)
        {
            characterImage.sprite = Resources.Load<Sprite>("Images/Characters/Skelton/" + characterType.abbreviationName + ".skelton");
        }

        private void SetMaxHP(int maxHP)
        {
            hpSlider.maxValue = maxHP;
        }

        public void SetHP(int currentHP)
        {
            hpText.text = currentHP.ToString();
            hpSlider.value = currentHP;
        }

        public void Init(
            CharacterType characterType,
            int maxHP,
            int tensionLevel
        )
        {
            SetCharacterImage(characterType);
            SetMaxHP(maxHP);
            SetHP(maxHP);
            _tensionComponent.Initialize(tensionLevel, characterType.abbreviationName);
        }

        // プレイヤー情報を更新するメソッド
        public void UpdatePlayerInfo(string name, int currentHP, int maxHP)
        {
            // TODO: プレイヤー情報の表示更新処理を実装
        }
    }
}
