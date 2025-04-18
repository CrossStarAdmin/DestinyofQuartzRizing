using System;
using Assets.FEScripts.Abstracts;
using Assets.FEScripts.Components.Elements.EnemyList;
using Assets.FEScripts.Types;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.FEScripts.Scenes.Purchase.CanvasUI
{
    public class MenuCanvasUI : AbstractCanvasUI
    {
        protected GameObject _menuContent;
        protected RectTransform _menuContentTransform;
        protected EnemyListManager[] _enemyListManagers;
        protected int _enemyListElementHeight = 300;
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

        public override void SetActions(Action[] _actions) { }

        public void SetConsumableListManager(
            ConsumableType[] _consumableTypes,
            Action[] _actions
        )
        {
            // EnemyTypeの個数分だけ、menuContentTransformの大きさを変更
            _menuContentTransform.sizeDelta = new Vector2(
                _menuContentTransform.sizeDelta.x,
                _consumableTypes.Length * _enemyListElementHeight
            );
            _enemyListManagers = new EnemyListManager[_consumableTypes.Length];
            for (int i = 0; i < _consumableTypes.Length; i++)
            {
                int index = i;
                GameObject listElementPrefabs = Resources.Load<GameObject>("Prefabs/Elements/ListElementPrefab");
                GameObject enemyList = Instantiate(listElementPrefabs, _menuContentTransform);
                _enemyListManagers[index] = enemyList.GetComponent<EnemyListManager>();
                _enemyListManagers[index].InitializeElement(
                    _consumableTypes[index].name,
                    _consumableTypes[index].campaignPrice.ToString() + " 円"
                );
                _enemyListManagers[index].SetActions(new Action[] { _actions[index] });
            }
        }

    }
}