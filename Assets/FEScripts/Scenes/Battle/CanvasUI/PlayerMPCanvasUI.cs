using System;
using Assets.FEScripts.Abstracts;
using Assets.FEScripts.Components.UI;
using Codice.Client.Commands;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class mpIcon {
    public Image mpImage;
    public Outline outline;
    public Image mpIconImage;
}

namespace Assets.FEScripts.Scenes.Battle.CanvasUI
{
    public class PlayerMPCanvasUI : AbstractCanvasUI
    {
        private OriginButtonComponent upButton;
        private OriginButtonComponent downButton;
        private mpIcon[] mpIcons = new mpIcon[10];
        private void Awake()
        {
            Canvas canvas = GameObject.Find("PlayerMPCanvas").GetComponent<Canvas>();
            InitObject(canvas);
        }

        protected override void InitObject(Canvas _canvas)
        {
            // BaseのInitObjectを呼び出す
            base.InitObject(_canvas);
            // 各コンポーネントを取得
            upButton = _component.transform.Find("UpButton").GetComponent<OriginButtonComponent>();
            downButton = _component.transform.Find("DownButton").GetComponent<OriginButtonComponent>();
            for (int i = 0; i < 10; i++)
            {
                mpIcons[i] = new mpIcon();
                mpIcons[i].mpImage = _component.transform.Find("MPElement/ViewPorts").GetChild(9 - i).GetComponent<Image>();
                mpIcons[i].outline = mpIcons[i].mpImage.GetComponent<Outline>();
                mpIcons[i].mpIconImage = mpIcons[i].mpImage.transform.Find("Icon").GetComponent<Image>();
            }
        }

        public override void SetActions(Action[] _actions)
        {
            // TODO: アクションの設定処理を実装
        }

        public void SetMPButton(int index, string status)
        {
            if (status == "active")
            {
                mpIcons[index].mpImage.color = Setting.COLOR_LIST[2]; // 明るい青
                mpIcons[index].outline.effectColor = Setting.COLOR_LIST[3]; // 紫
            }
            if (status == "inactive")
            {
                mpIcons[index].mpImage.color = Setting.COLOR_LIST[4]; // 黒
                mpIcons[index].outline.effectColor = Setting.COLOR_LIST[6]; // 灰
            }
            if (status == "disabled")
            {
                mpIcons[index].mpImage.color = Setting.COLOR_LIST[6]; // 灰
                mpIcons[index].outline.effectColor = Setting.COLOR_LIST[6]; // 灰
            }
        }

        public void Init()
        {
            for (int i = 0; i < 10; i++)
            {
                SetMPButton(i, "disabled");
            }
        }

        // プレイヤーMPを更新するメソッド
        public void UpdatePlayerMP(int currentMP, int maxMP)
        {
            // TODO: MP表示の更新処理を実装
        }
    }
}
