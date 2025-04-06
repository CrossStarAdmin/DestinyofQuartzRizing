using System;
using Assets.FEScripts.Abstracts;
using Assets.FEScripts.Scenes.Menu.CanvasUI;
using Assets.FEScripts.Scenes.Title.CanvasUI;
using UnityEngine;

namespace Assets.FEScripts.Scenes.Title
{
    public class TitleUI : AbstractUI
    {
        protected Canvas _titleHeaderCanvas, _titleCanvas, _playerSettingCanvas, _playButtonCanvas;
        protected TitleHeaderCanvasUI _titleHeaderCanvasUI;
        public TitleHeaderCanvasUI titleHeaderCanvasUI
        {
            get { return _titleHeaderCanvasUI; }
        }
        protected TitleCanvasUI _titleCanvasUI;
        public TitleCanvasUI titleCanvasUI
        {
            get { return _titleCanvasUI; }
        }
        protected PlayerSettingCanvasUI _playerSettingCanvasUI;
        public PlayerSettingCanvasUI playerSettingCanvasUI
        {
            get { return _playerSettingCanvasUI; }
        }
        protected PlayButtonCanvasUI _playButtonCanvasUI;
        public PlayButtonCanvasUI playButtonCanvasUI
        {
            get { return _playButtonCanvasUI; }
        }

        protected override void InitCanvas()
        {
            // BaseのInitCanvasを呼び出す
            base.InitCanvas();
            // 各Canvasを取得
            _titleHeaderCanvas = GameObject.Find("TitleHeaderCanvas").GetComponent<Canvas>();
            _titleCanvas = GameObject.Find("TitleCanvas").GetComponent<Canvas>();
            _playerSettingCanvas = GameObject.Find("PlayerSettingCanvas").GetComponent<Canvas>();
            _playButtonCanvas = GameObject.Find("PlayButtonCanvas").GetComponent<Canvas>();
        }

        protected override void InitCanvasUI()
        {
            // BaseのInitCanvasUIを呼び出す
            base.InitCanvasUI();
            // CanvasUIの設定
            _titleHeaderCanvasUI = _titleHeaderCanvas.GetComponent<TitleHeaderCanvasUI>();
            _titleCanvasUI = _titleCanvas.GetComponent<TitleCanvasUI>();
            _playerSettingCanvasUI = _playerSettingCanvas.GetComponent<PlayerSettingCanvasUI>();
            _playButtonCanvasUI = _playButtonCanvas.GetComponent<PlayButtonCanvasUI>();
        }

        protected override void SetCanvasDisplay()
        {
            // BaseのSetCanvasDisplayを呼び出す
            base.SetCanvasDisplay();
            // 各Canvasの初期表示を設定
            _titleHeaderCanvas.enabled = true;
            _titleCanvas.enabled = true;
            _playerSettingCanvas.enabled = true;
            _playButtonCanvas.enabled = true;
        }
    }
}