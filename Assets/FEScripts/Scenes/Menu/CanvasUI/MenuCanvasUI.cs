using System;
using Assets.FEScripts.Abstracts;
using Assets.FEScripts.Components.EnemyList;
using Assets.FEScripts.Types;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.FEScripts.Scenes.Menu.CanvasUI
{
    public class MenuCanvasUI : AbstractCanvasUI
    {
        protected GameObject _menuContent;
        protected RectTransform _menuContentTransform;
        protected EnemyListManager[] _enemyListManagers;
        private void Awake()
        {
            Canvas canvas = GameObject.Find("MenuCanvas").GetComponent<Canvas>();
            InitObject(canvas);
        }

        protected override void InitObject(Canvas _canvas)
        {
            // BaseのInitObjectを実行
            base.InitObject(_canvas);
            // 各コンポーネントを取得
            _menuContent = _component.transform.Find("ContentElement/Viewport/Content").gameObject;
            _menuContentTransform = _menuContent.transform.GetComponent<RectTransform>();
            // 初期設定
        }

        protected override void SetActions(Action[] _actions) { }

        public void SetEnemyListManager(
            EnemyType[] _enemyTypes
        )
        {
            // EnemyTypeの個数分だけ、menuContentTransformの大きさを変更
            _menuContentTransform.sizeDelta = new Vector2(
                _menuContentTransform.sizeDelta.x,
                _enemyTypes.Length * 300
            );
            _enemyListManagers = new EnemyListManager[_enemyTypes.Length];
            for (int i = 0; i < _enemyTypes.Length; i++)
            {
                int index = i;
                GameObject listElementPrefabs = Resources.Load<GameObject>("Prefabs/ListElementPrefab");
                GameObject enemyList = Instantiate(listElementPrefabs, _menuContentTransform);
                _enemyListManagers[index] = enemyList.GetComponent<EnemyListManager>();
                _enemyListManagers[index].InitializeElement(
                    _enemyTypes[index].uid,
                    _enemyTypes[index].attack + " / " + _enemyTypes[index].defense
                );
            }
        }

    }
}