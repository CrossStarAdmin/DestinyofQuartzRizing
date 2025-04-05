using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using Assets.FEScripts.Functions;
using DG.Tweening;

namespace Assets.FEScripts.Components.UI
{
    public class OriginButtonComponent : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
    {
        // Manager関係
        private Action _buttonAction;
        // private int soundEffectNumber;
        // UI関係
        private Image _backgroundImage;
        private Text _titleText;
        // SEの名前関係
        // private string[] soundEffectNames = {
        //     "Button1",
        //     "Button2",
        //     "Cancel1"
        // };

        public void InitOriginButtonComponent(Action _action, int _soundEffectNumber = -1)
        {
            _buttonAction = _action;
            // soundEffectNumber = _soundEffectNumber;
            _backgroundImage = GetComponentFunction.Execute<Image>("", gameObject);
            if (FindComponentFunction.Execute("Text", gameObject))
                _titleText = GetComponentFunction.Execute<Text>("Text", gameObject);
        }

        // 処理関係
        public void OnPointerClick(PointerEventData eventData)
        {
            // アクションの実行
            _buttonAction();
            // クリック時のSEを再生
            // if (soundEffectNumber != -1)
            //     AudioManager.Instance.PlaySE(soundEffectNames[soundEffectNumber]);
        }

        public void OnPointerDown(PointerEventData _eventData)
        {
            transform.DOScale(0.95f, 0.24f).SetEase(Ease.OutCubic);
        }

        public void OnPointerUp(PointerEventData _eventData)
        {
            transform.DOScale(1f, 0.24f).SetEase(Ease.OutCubic);
        }

        // UI関係
        public void SetBackgroundImage(Sprite _buttonBackgroundImage)
        {
            _backgroundImage.sprite = _buttonBackgroundImage;
        }

        public void SetText(string _buttonText)
        {
            _titleText.text = _buttonText;
        }
    }
}