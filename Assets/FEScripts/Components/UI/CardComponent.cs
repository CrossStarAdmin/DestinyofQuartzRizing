using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.FEScripts.Components.UI
{
    /// <summary>
    /// ドラッグ可能な聖水カードコンポーネント
    /// </summary>
    public class CardComponent : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private RectTransform _rectTransform;
        private Canvas _canvas;
        private CanvasGroup _canvasGroup;
        private Vector2 _originalPosition;
        private Transform _originalParent;
        private Action _event;
        private Vector2 _dragStartScreenPosition;
        private float _dragThreshold; // ドラッグ判定の距離しきい値（ピクセル）
        
        public void InitCardComponent(Action _action)
        {
            _rectTransform = GetComponent<RectTransform>();
            _canvas = GetComponentInParent<Canvas>();
            _dragThreshold = Setting.CARD_MOVE_DISTANCE;
            
            // CanvasGroupがなければ追加
            _canvasGroup = GetComponent<CanvasGroup>();
            if (_canvasGroup == null)
            {
                _canvasGroup = gameObject.AddComponent<CanvasGroup>();
            }
            // アクションの設定
            _event = _action;
        }

        /// <summary>
        /// ドラッグ開始時
        /// </summary>
        public void OnBeginDrag(PointerEventData eventData)
        {
            // 元の位置と親を記録
            _originalPosition = _rectTransform.anchoredPosition;
            _originalParent = transform.parent;
            // ドラッグ開始位置をスクリーン座標で記録
            _dragStartScreenPosition = eventData.position;
            // ドラッグ中は半透明にしてレイキャストをブロックしない
            _canvasGroup.alpha = 0.6f;
            _canvasGroup.blocksRaycasts = false;
            // 最前面に表示するため、一時的に親をCanvasに変更
            transform.SetParent(_canvas.transform, true);
        }

        /// <summary>
        /// ドラッグ中
        /// </summary>
        public void OnDrag(PointerEventData eventData)
        {
            // マウス位置に追従
            _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
        }

        /// <summary>
        /// ドラッグ終了時
        /// </summary>
        public void OnEndDrag(PointerEventData eventData)
        {
            // 透明度を元に戻す
            _canvasGroup.alpha = 1.0f;
            _canvasGroup.blocksRaycasts = true;
            // ドラッグ距離をスクリーン座標で計算
            float dragDistance = Vector2.Distance(_dragStartScreenPosition, eventData.position);
            // 一定距離以上ドラッグされた場合
            if (dragDistance >= _dragThreshold)
            {
                UnityEngine.Debug.Log("CardComponent: Event Start");
                // イベントを発火
                _event?.Invoke();
            }
            // 元の位置に戻す
            ReturnToOriginalPosition();
        }

        /// <summary>
        /// 元の位置に戻す
        /// </summary>
        private void ReturnToOriginalPosition()
        {
            // 親を元に戻す
            transform.SetParent(_originalParent, true);
            // 位置を元に戻す
            _rectTransform.anchoredPosition = _originalPosition;
        }

        /// <summary>
        /// カードを有効化/無効化
        /// </summary>
        public void SetCardEnabled(bool enabled)
        {
            _canvasGroup.interactable = enabled;
            _canvasGroup.alpha = enabled ? 1.0f : 0;
        }
    }
}
