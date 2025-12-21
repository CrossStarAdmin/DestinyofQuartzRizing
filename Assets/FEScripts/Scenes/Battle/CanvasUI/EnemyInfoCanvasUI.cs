using System;
using Assets.FEScripts.Abstracts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.FEScripts.Scenes.Battle.CanvasUI
{
    public class EnemyInfoCanvasUI : AbstractCanvasUI
    {
        private Image characterImage;
        private TextMeshProUGUI hpText;
        private TextMeshProUGUI mpText;
        private Slider hpSlider;
        private Image[] tensionImages;
        private Image skillImage;
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
            tensionImages = new Image[3];
            for (int i = 0; i < 3; i++)
            {
                tensionImages[i] = _component.transform.Find($"EnemyElement/TensionElement/Tension{i + 1}").GetComponent<Image>();
            }
            skillImage = _component.transform.Find("EnemyElement/TensionElement/TensionSkill/Icon").GetComponent<Image>();
        }

        public override void SetActions(Action[] _actions)
        {
            // TODO: アクションの設定処理を実装
        }

        private void SetCharacterImage()
        {
            characterImage.sprite = Resources.Load<Sprite>("Images/Characters/Skelton/" + Setting.selectedEnemyCharacter.abbreviationName);
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

        private void SetTension(int tensionLevel)
        {
            for (int i = 0; i < tensionImages.Length; i++)
            {
                tensionImages[i].color = (i < tensionLevel)
                    ? Setting.COLOR_LIST[0]  // 赤
                    : Setting.COLOR_LIST[4]; // 黒
            }
        }

        private void SetSkillImage()
        {
            skillImage.sprite = Resources.Load<Sprite>("Images/Skills/" + Setting.selectedEnemyCharacter.abbreviationName + "Skill");
        }

        private void Init()
        {
            SetCharacterImage();
            SetHP(Setting.initHP);
            SetMP(Setting.initMP);
            SetTension(Setting.initSecondTension);
            SetSkillImage();
        }

        // 敵情報を更新するメソッド
        public void UpdateEnemyInfo(string name, int currentHP, int maxHP, int currentMP, int maxMP)
        {
            // TODO: 敵情報の表示更新処理を実装
        }
    }
}
