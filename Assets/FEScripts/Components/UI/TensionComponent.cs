using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.FEScripts.Components.UI
{
    public class TensionComponent : MonoBehaviour
    {
        private Image[] _tensionImages;
        private Image _skillImage;
        private OriginButtonComponent _skillButton;
        // private Outline _skillButtonOutline;

        /// <summary>
        /// テンションコンポーネントの初期化
        /// </summary>
        /// <param name="_tensionElement">TensionElementのTransform</param>
        public void InitTensionComponent(Transform _tensionElement)
        {
            _tensionImages = new Image[3];
            for (int i = 0; i < 3; i++)
            {
                _tensionImages[i] = _tensionElement.Find($"Tension{i + 1}").GetComponent<Image>();
            }
            _skillImage = _tensionElement.Find("TensionSkill/Icon").GetComponent<Image>();
            _skillButton = _tensionElement.Find("TensionSkill").GetComponent<OriginButtonComponent>();
            // _skillButtonOutline = _skillButton.GetComponent<Outline>();
        }

        /// <summary>
        /// スキルボタンのアクションを設定
        /// </summary>
        /// <param name="_action">アクション</param>
        public void SetSkillAction(Action _action)
        {
            _skillButton.InitOriginButtonComponent(_action);
        }

        /// <summary>
        /// テンションレベルを設定
        /// </summary>
        /// <param name="_tensionLevel">テンションレベル（0-3）</param>
        public void SetTension(int _tensionLevel)
        {
            for (int i = 0; i < _tensionImages.Length; i++)
            {
                _tensionImages[i].color = (i < _tensionLevel)
                    ? Setting.COLOR_LIST[0]  // 赤
                    : Setting.COLOR_LIST[4]; // 黒
            }
            // if (_tensionLevel >= 3)
            // {
            //     _skillButtonOutline.effectColor = Setting.GetColor("red", 255); // 赤
            // }
        }

        /// <summary>
        /// スキルアイコンを設定
        /// </summary>
        /// <param name="_characterAbbreviation">キャラクターの略称名</param>
        public void SetSkillImage(string _characterAbbreviation)
        {
            _skillImage.sprite = Resources.Load<Sprite>("Images/Skills/" + _characterAbbreviation + "Skill");
        }

        /// <summary>
        /// テンションとスキルを初期化
        /// </summary>
        /// <param name="_tensionLevel">初期テンションレベル</param>
        /// <param name="_characterAbbreviation">キャラクターの略称名</param>
        public void Initialize(int _tensionLevel, string _characterAbbreviation)
        {
            SetTension(_tensionLevel);
            SetSkillImage(_characterAbbreviation);
        }

        /// <summary>
        /// テンションを更新
        /// </summary>
        /// <param name="_tensionLevel">新しいテンションレベル</param>
        public void UpdateTension(int _tensionLevel)
        {
            SetTension(_tensionLevel);
        }
    }
}
