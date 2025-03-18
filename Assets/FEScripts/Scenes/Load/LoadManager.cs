using System;
using Assets.BEScripts;
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
            entity.maxStep = 2;
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
            // Step2: UserDataを取得
            await DI.bringUserDataController.Execute();
            UpdateSlider();
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