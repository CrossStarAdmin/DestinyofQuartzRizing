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
            if (_actions.Length >= 1)
                upButton.InitOriginButtonComponent(_actions[0]);
            
            if (_actions.Length >= 2)
                downButton.InitOriginButtonComponent(_actions[1]);
        }
        
        /// <summary>
        /// MP表示を更新
        /// </summary>
        /// <param name="_availableMP">利用可能MP</param>
        /// <param name="_maxMP">最大MP</param>
        public void UpdateMPDisplay(int _availableMP, int _maxMP)
        {
            for (int i = 0; i < 10; i++)
            {
                if (i < _availableMP)
                {
                    // 利用中のMP（明るい青）
                    SetMPButton(i, "active");
                }
                else if (i < _maxMP)
                {
                    // 利用可能だが未使用のMP（黒）
                    SetMPButton(i, "inactive");
                }
                else
                {
                    // 利用不可能なMP（灰色）
                    SetMPButton(i, "disabled");
                }
            }
        }

        public void SetMPButton(int index, string status)
        {
            if (status == "active")
            {
                mpIcons[index].mpImage.color = Setting.GetColor("lightBlue", 255); // 明るい青
                mpIcons[index].outline.effectColor = Setting.GetColor("purple", 255); // 紫
                mpIcons[index].mpIconImage.color = Setting.GetColor("white", 70); // 白
            }
            if (status == "inactive")
            {
                mpIcons[index].mpImage.color = Setting.GetColor("darkRed", 255); // 黒
                mpIcons[index].outline.effectColor = Setting.GetColor("gray", 255); // 灰
                mpIcons[index].mpIconImage.color = Setting.GetColor("white", 30); // 白
            }
            if (status == "disabled")
            {
                mpIcons[index].mpImage.color = Setting.GetColor("gray", 255); // 灰
                mpIcons[index].outline.effectColor = Setting.GetColor("gray", 255); // 灰
                mpIcons[index].mpIconImage.color = Setting.GetColor("white", 10); // 白
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
        public void UpdatePlayerMP(int availableMP, int maxMP)
        {
            UpdateMPDisplay(availableMP, maxMP);
        }
    }
}
