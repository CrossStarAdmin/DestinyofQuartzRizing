using System;
using System.Threading.Tasks;
using Assets.BEScripts;
using Assets.FEScripts.Abstracts;
using Assets.FEScripts.Scenes.Title;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Assets.FEScripts.Scene.Title
{
    public class TitleManager : AbstractManager<TitleEntity, TitleUI>
    {
        protected override async UniTask InitEntity()
        {
            await base.InitEntity();
            // Entityの初期値を設定する
            // entity.getPlayersResponseType = await DI.getPlayersController.Execute();
        }
        protected override void InitUI()
        {
            base.InitUI();
            // Playerの初期値を設定する
            // ui.detailModalCanvasUI.SetDetailModal(
            //     entity.playerTypes[0]
            // );
        }

        protected override void InitEvent()
        {
            ui.titleHeaderCanvasUI.SetActions(new Action[] {
                () => SceneManager.LoadScene("PurchaseScene"),
                () => ui.detailModalCanvasUI.DisplayCanvas(true),
            });
            ui.playButtonCanvasUI.SetActions(new Action[] {
                () => StartGame(),
            });
            ui.detailModalCanvasUI.SetActions(new Action[] {
                () => UnityEngine.Debug.Log("Not Set"),
                () => ui.detailModalCanvasUI.DisplayCanvas(false)
            });
        }

        protected override async UniTask InitOriginProcess()
        {
            // await処理
            await Task.Delay(0);
        }

        protected void StartGame()
        {
            // ページ遷移
            SceneManager.LoadScene("MenuScene");
        }
    }
}