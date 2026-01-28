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
        // ==================================================
        // フィールド
        // ==================================================
        private Image characterImage;
        private TextMeshProUGUI hpText;
        private Slider hpSlider;
        private TensionComponent _tensionComponent;
        private OriginButtonComponent _hpReduceButton;
        private OriginButtonComponent _hpAddButton;
        private CardComponent _tensionCardComponent;
        private CardComponent _holyCardComponent;

        // ==================================================
        // 初期化
        // ==================================================

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

            // カード関係の初期化
            _tensionCardComponent = _component.transform.Find("CardElement/TensionCardImage").GetComponent<CardComponent>();
            _holyCardComponent = _component.transform.Find("CardElement/HolyCardImage").GetComponent<CardComponent>();
        }

        public override void SetActions(Action[] _actions)
        {
            _hpReduceButton.InitOriginButtonComponent(_actions[0]);
            _hpAddButton.InitOriginButtonComponent(_actions[1]);
            _tensionCardComponent.InitCardComponent(_actions[2]);
            _holyCardComponent.InitCardComponent(_actions[3]);
            _tensionComponent.SetSkillAction(_actions[4]);
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

        public void SetHP(int currentHP)
        {
            hpText.text = currentHP.ToString();
            hpSlider.value = currentHP;
        }

        // ==================================================
        // 公開メソッド - 初期化
        // ==================================================
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

        // ==================================================
        // 公開メソッド - テンション・カード制御
        // ==================================================
        public void SetTension(int tensionLevel)
        {
            _tensionComponent.SetTension(tensionLevel);
        }

        ///<summary>
        /// テンションカードのドラッグ可否を設定
        ///</summary>
        /// <param name="_enabled">有効/無効</param>
        public void SetTensionCardEnabled(bool _enabled)
        {
            if (_tensionCardComponent != null)
            {
                _tensionCardComponent.SetCardEnabled(_enabled);
            }
        }

        /// <summary>
        /// 聖水カードのドラッグ可否を設定
        /// </summary>
        /// <param name="_enabled">有効/無効</param>
        public void SetHolyCardEnabled(bool _enabled)
        {
            if (_holyCardComponent != null)
            {
                _holyCardComponent.SetCardEnabled(_enabled);
            }
        }
    }
}
