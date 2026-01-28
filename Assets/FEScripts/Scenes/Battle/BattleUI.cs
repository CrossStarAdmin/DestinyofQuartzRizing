using System;
using Assets.FEScripts.Abstracts;
using Assets.FEScripts.Scenes.Battle.CanvasUI;
using UnityEngine;

namespace Assets.FEScripts.Scenes.Battle
{
    public class BattleUI : AbstractUI
    {
        // ==================================================
        // Canvas フィールド
        // ==================================================
        protected Canvas _battleHeaderCanvas;
        protected Canvas _enemyInfoCanvas;
        protected Canvas _playerInfoCanvas;
        protected Canvas _playerMPCanvas;
        protected Canvas _playerMenuCanvas;
        protected Canvas _diceCanvas;
        protected Canvas _detailModalCanvas;
        
        // ==================================================
        // CanvasUI フィールドとプロパティ - Header
        // ==================================================
        protected BattleHeaderCanvasUI _battleHeaderCanvasUI;
        public BattleHeaderCanvasUI battleHeaderCanvasUI { get { return _battleHeaderCanvasUI; } }

        // ==================================================
        // CanvasUI フィールドとプロパティ - Enemy
        // ==================================================
        protected EnemyInfoCanvasUI _enemyInfoCanvasUI;
        public EnemyInfoCanvasUI enemyInfoCanvasUI { get { return _enemyInfoCanvasUI; } }

        // ==================================================
        // CanvasUI フィールドとプロパティ - Player
        // ==================================================
        protected PlayerInfoCanvasUI _playerInfoCanvasUI;
        public PlayerInfoCanvasUI playerInfoCanvasUI { get { return _playerInfoCanvasUI; } }

        protected PlayerMPCanvasUI _playerMPCanvasUI;
        public PlayerMPCanvasUI playerMPCanvasUI { get { return _playerMPCanvasUI; } }

        protected PlayerMenuCanvasUI _playerMenuCanvasUI;
        public PlayerMenuCanvasUI playerMenuCanvasUI { get { return _playerMenuCanvasUI; } }

        // ==================================================
        // CanvasUI フィールドとプロパティ - Dice
        // ==================================================
        protected DiceCanvasUI _diceCanvasUI;
        public DiceCanvasUI diceCanvasUI { get { return _diceCanvasUI; } }

        // ==================================================
        // CanvasUI フィールドとプロパティ - Modal
        // ==================================================
        protected DetailModalCanvasUI _detailModalCanvasUI;
        public DetailModalCanvasUI detailModalCanvasUI { get { return _detailModalCanvasUI; } }

        // ==================================================
        // 初期化メソッド
        // ==================================================
        protected override void InitCanvas()
        {
            base.InitCanvas();
            
            // Header Canvas
            _battleHeaderCanvas = GameObject.Find("HeaderCanvas").GetComponent<Canvas>();
            
            // Enemy Canvas
            _enemyInfoCanvas = GameObject.Find("EnemyInfoCanvas").GetComponent<Canvas>();
            
            // Player Canvas
            _playerInfoCanvas = GameObject.Find("PlayerInfoCanvas").GetComponent<Canvas>();
            _playerMPCanvas = GameObject.Find("PlayerMPCanvas").GetComponent<Canvas>();
            _playerMenuCanvas = GameObject.Find("PlayerMenuCanvas").GetComponent<Canvas>();
            
            // Dice Canvas
            _diceCanvas = GameObject.Find("DiceCanvas").GetComponent<Canvas>();
            
            // Modal Canvas
            _detailModalCanvas = GameObject.Find("DetailModalCanvas").GetComponent<Canvas>();
        }

        protected override void InitCanvasUI()
        {
            base.InitCanvasUI();
            
            // Header CanvasUI
            _battleHeaderCanvasUI = _battleHeaderCanvas.GetComponent<BattleHeaderCanvasUI>();
            
            // Enemy CanvasUI
            _enemyInfoCanvasUI = _enemyInfoCanvas.GetComponent<EnemyInfoCanvasUI>();
            
            // Player CanvasUI
            _playerInfoCanvasUI = _playerInfoCanvas.GetComponent<PlayerInfoCanvasUI>();
            _playerMPCanvasUI = _playerMPCanvas.GetComponent<PlayerMPCanvasUI>();
            _playerMenuCanvasUI = _playerMenuCanvas.GetComponent<PlayerMenuCanvasUI>();
            
            // Dice CanvasUI
            _diceCanvasUI = _diceCanvas.GetComponent<DiceCanvasUI>();
            
            // Modal CanvasUI
            _detailModalCanvasUI = _detailModalCanvas.GetComponent<DetailModalCanvasUI>();
        }

        protected override void SetCanvasDisplay()
        {
            base.SetCanvasDisplay();
            
            // Header Canvas初期表示
            _battleHeaderCanvas.enabled = true;
            
            // Enemy Canvas初期表示
            _enemyInfoCanvas.enabled = true;
            
            // Player Canvas初期表示
            _playerInfoCanvas.enabled = true;
            _playerMPCanvas.enabled = true;
            _playerMenuCanvas.enabled = true;
            
            // Dice Canvas初期表示（非表示）
            _diceCanvas.gameObject.SetActive(false);
            
            // Modal Canvas初期表示（非表示）
            _detailModalCanvas.enabled = false;
        }

        // ==================================================
        // Canvas表示制御メソッド
        // ==================================================
        public void DisplayBattleHeaderCanvas(bool _isDisplay)
        {
            _battleHeaderCanvas.enabled = _isDisplay;
        }

        public void DisplayEnemyInfoCanvas(bool _isDisplay)
        {
            _enemyInfoCanvas.enabled = _isDisplay;
        }

        public void DisplayPlayerInfoCanvas(bool _isDisplay)
        {
            _playerInfoCanvas.enabled = _isDisplay;
        }

        public void DisplayPlayerMPCanvas(bool _isDisplay)
        {
            _playerMPCanvas.enabled = _isDisplay;
        }

        public void DisplayPlayerMenuCanvas(bool _isDisplay)
        {
            _playerMenuCanvas.enabled = _isDisplay;
        }

        public void DisplayDiceCanvas(bool _isDisplay)
        {
            _diceCanvas.gameObject.SetActive(_isDisplay);
        }

        public void DisplayDetailModalCanvas(bool _isDisplay)
        {
            _detailModalCanvas.enabled = _isDisplay;
        }
    }
}
