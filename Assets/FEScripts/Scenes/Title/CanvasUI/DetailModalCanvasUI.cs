using System;
using Assets.FEScripts.Abstracts;
using Assets.FEScripts.Components.Elements.Modal;
using Assets.FEScripts.Types;
using UnityEngine;

namespace Assets.FEScripts.Scenes.Title.CanvasUI
{
    public class DetailModalCanvasUI : AbstractCanvasUI
    {
        protected ModalManager _modalManager;
        private void Awake()
        {
            Canvas canvas = GameObject.Find("DetailModalCanvas").GetComponent<Canvas>();
            InitObject(canvas);
        }

        protected override void InitObject(Canvas _canvas)
        {
            // BaseのInitObjectを呼び出す
            base.InitObject(_canvas);
            // 各コンポーネントを取得
            _modalManager = _component.transform.Find("DetailModal").GetComponent<ModalManager>();
            // モーダルの初期設定
            _modalManager.InitializeVarietyButton(false);
        }

        public override void SetActions(Action[] _actions)
        {
            // ModalManagerのアクションをセット
            _modalManager.SetActions(_actions);
        }

        public void SetDetailModal(
            PlayerType _playerType
        )
        {
            _modalManager.InitializeElement(
                _playerType.name,
                "HP: " + _playerType.maxHp + "/MP: " + _playerType.maxMp + "\n" +
                "Attack: " + _playerType.attack + "\n" +
                "Defense: " + _playerType.defense + "\n" +
                "Speed: " + _playerType.speed
            );
        }
    }
}