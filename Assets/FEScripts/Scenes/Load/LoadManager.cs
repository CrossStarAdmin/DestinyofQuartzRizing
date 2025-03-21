using System;
using System.Collections.Generic;
using Assets.BEScripts;
using Assets.BEScripts.Presentations.Requests;
using Assets.BEScripts.Presentations.Responses;
using Assets.FEScripts.Abstracts;
using Assets.FEScripts.Scenes.Load;
using Cysharp.Threading.Tasks;

namespace Assets.FEScripts.Scene.Load
{
    public class LoadManager : AbstractManager<LoadEntity, LoadUI>
    {
        protected override async UniTask InitEntity()
        {
            await base.InitEntity();
            entity.maxStep = 5;
        }
        protected override void InitEvent()
        {

        }

        protected override async UniTask InitOriginProcess()
        {
            await LoadFunction();
        }

        protected async UniTask LoadFunction()
        {
            // Step1: ログイン処理の実行
            await DI.loginController.Execute();
            UpdateSlider();
            // Step2: TitleDataを取得
            await DI.bringTitleDataController.Execute();
            UpdateSlider();
            // Step3: UserDataを取得
            await DI.bringUserDataController.Execute();
            UpdateSlider();
            // Step4: ユーザーのバージョンを取得
            GetUserDataResponse response = await DI.getUserDataController.Execute(
                new GetUserDataRequest()
                {
                    key = "version"
                }
            );
            UpdateSlider();
            // Step5: バージョンの確認・ユーザーデータの更新
            await CreateUserData(response.data);
            UpdateSlider();
        }

        protected async UniTask CreateUserData(string version)
        {
            if (version == null)
            {
                // バージョンがない場合は新規作成
                await DI.createUserDataController.Execute(
                    new CreateUserDataRequest()
                    {
                        data = new Dictionary<string, string>()
                        {
                            { "version", "1" },
                            { "data", "{}"}
                        }
                    }
                );
            }
        }

        protected void UpdateSlider()
        {
            entity.AddStep();
            ui.loadCanvasUI.UpdateSlider(
                entity.percent
            );
        }
    }
}