using System;
using Assets.FEScripts.Abstracts;
using Assets.FEScripts.Scenes.Battle.CanvasUI;
using UnityEngine;

namespace Assets.FEScripts.Scenes.Battle
{
    public class BattleUI : AbstractUI
    {
        protected Canvas _enemyInfoCanvas, _playerMPCanvas, _playerMenuCanvas, _playerInfoCanvas, _detailModalCanvas;
        
        protected EnemyInfoCanvasUI _enemyInfoCanvasUI;
        public EnemyInfoCanvasUI enemyInfoCanvasUI
        {
            get { return _enemyInfoCanvasUI; }
        }

        protected PlayerMPCanvasUI _playerMPCanvasUI;
        public PlayerMPCanvasUI playerMPCanvasUI
        {
            get { return _playerMPCanvasUI; }
        }

        protected PlayerMenuCanvasUI _playerMenuCanvasUI;
        public PlayerMenuCanvasUI playerMenuCanvasUI
        {
            get { return _playerMenuCanvasUI; }
        }

        protected PlayerInfoCanvasUI _playerInfoCanvasUI;
        public PlayerInfoCanvasUI playerInfoCanvasUI
        {
            get { return _playerInfoCanvasUI; }
        }

        protected DetailModalCanvasUI _detailModalCanvasUI;
        public DetailModalCanvasUI detailModalCanvasUI
        {
            get { return _detailModalCanvasUI; }
        }

        protected override void InitCanvas()
        {
            // BaseのInitCanvasを呼び出す（HeaderCanvasとFadeCanvasを初期化）
            base.InitCanvas();
            // 各Canvasを取得
            _enemyInfoCanvas = GameObject.Find("EnemyInfoCanvas").GetComponent<Canvas>();
            _playerMPCanvas = GameObject.Find("PlayerMPCanvas").GetComponent<Canvas>();
            _playerMenuCanvas = GameObject.Find("PlayerMenuCanvas").GetComponent<Canvas>();
            _playerInfoCanvas = GameObject.Find("PlayerInfoCanvas").GetComponent<Canvas>();
            _detailModalCanvas = GameObject.Find("DetailModalCanvas").GetComponent<Canvas>();
        }

        protected override void InitCanvasUI()
        {
            // BaseのInitCanvasUIを呼び出す（HeaderCanvasUIとFadeCanvasUIを初期化）
            base.InitCanvasUI();
            // CanvasUIの設定
            _enemyInfoCanvasUI = _enemyInfoCanvas.GetComponent<EnemyInfoCanvasUI>();
            _playerMPCanvasUI = _playerMPCanvas.GetComponent<PlayerMPCanvasUI>();
            _playerMenuCanvasUI = _playerMenuCanvas.GetComponent<PlayerMenuCanvasUI>();
            _playerInfoCanvasUI = _playerInfoCanvas.GetComponent<PlayerInfoCanvasUI>();
            _detailModalCanvasUI = _detailModalCanvas.GetComponent<DetailModalCanvasUI>();
        }

        protected override void SetCanvasDisplay()
        {
            // BaseのSetCanvasDisplayを呼び出す（HeaderCanvasとFadeCanvasを表示）
            base.SetCanvasDisplay();
            // 各Canvasの初期表示を設定
            _enemyInfoCanvas.enabled = true;
            _playerMPCanvas.enabled = true;
            _playerMenuCanvas.enabled = true;
            _playerInfoCanvas.enabled = true;
            _detailModalCanvas.enabled = false;
        }

        public void DisplayDetailModalCanvas(bool _isDisplay)
        {
            _detailModalCanvas.enabled = _isDisplay;
        }

        public void DisplayEnemyInfoCanvas(bool _isDisplay)
        {
            _enemyInfoCanvas.enabled = _isDisplay;
        }

        public void DisplayPlayerMPCanvas(bool _isDisplay)
        {
            _playerMPCanvas.enabled = _isDisplay;
        }

        public void DisplayPlayerMenuCanvas(bool _isDisplay)
        {
            _playerMenuCanvas.enabled = _isDisplay;
        }

        public void DisplayPlayerInfoCanvas(bool _isDisplay)
        {
            _playerInfoCanvas.enabled = _isDisplay;
        }
    }
}
