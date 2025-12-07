using System;
using System.Collections.Generic;
using Assets.BEScripts;
using Assets.FEScripts.Abstracts;
using Assets.FEScripts.Scenes.Load;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.FEScripts.Scene.Load
{
    public class LoadManager : AbstractManager<LoadEntity, LoadUI>
    {
        protected override async UniTask InitEntity()
        {
            await base.InitEntity();
            entity.maxStep = 1;
        }

        protected override void InitUI()
        {
            base.InitUI();
            ui.errorModalCanvasUI.InitializeModal();
        }

        protected override void InitEvent()
        {
            ui.errorModalCanvasUI.SetActions(new Action[] {
                    () =>
                    {
                        ui.errorModalCanvasUI.DisplayCanvas(false);
                        LoadFunction().Forget((e) => Debug.LogError(e));
                    },
                    () => Debug.Log("Close Button")
            });
        }

        protected override async UniTask InitOriginProcess()
        {
            await LoadFunction();
        }

        protected async UniTask LoadFunction()
        {
            try
            {
                while (entity.maxStep > entity.step)
                {
                    // Step1: ログイン処理の実行
                    if (entity.step == 0)
                        await DI.loginController.Execute();
                    // Step2: TitleDataの取得
                    // else if (entity.step == 1)
                    //     await DI.bringTitleDataController.Execute();
                    // // Step3: UserDataの取得
                    // else if (entity.step == 2)
                    //     await DI.bringUserDataController.Execute();
                    // // Step4: UserDataのバージョンの取得
                    // else if (entity.step == 3)
                    //     entity.version = await DI.getUserDataController.Execute("Version");
                    // // Step5: ユーザーデータの更新
                    // else if (entity.step == 4)
                    //     await CreateUserData(entity.version);
                    // // Step6: 購入情報の取得
                    // else if (entity.step == 5)
                    //     await DI.bringCatalogListController.Execute();
                    UpdateSlider();
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError(e.Message);
                ui.errorModalCanvasUI.DisplayCanvas(true);
            }
        }

        protected async UniTask CreateUserData(string version)
        {
            if (version == null)
            {
                // バージョンがない場合のデータを作成していく
                Dictionary<string, string> data = new Dictionary<string, string>();
                data.Add("Version", "1");
                data.Add("Player", DI.getInitPlayerDataController.Execute());
                await DI.createUserDataController.Execute(data);
                // データの作成が完了したら、もう一度ユーザーデータを取得する
                await DI.bringUserDataController.Execute();
            }
        }

        protected void UpdateSlider()
        {
            entity.AddStep();
            ui.loadCanvasUI.UpdateSlider(
                entity.percent
            );
        }

        protected override async UniTask FadeFunction()
        {
            if (ui.fadeCanvasUI != null)
            {
                await ui.fadeCanvasUI.FadeOut();
                SceneManager.LoadScene("TitleScene");
                return;
            }
            SceneManager.LoadScene("TitleScene");
            return;
        }
    }
}