using System;
using System.Threading.Tasks;
using Assets.BEScripts;
using Assets.BEScripts.Presentations.Controllers;
using Assets.FEScripts.Abstracts;
using Assets.FEScripts.Scenes.Load;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Assets.FEScripts.Scene.Load
{
    public class LoadManager : AbstractManager<LoadEntity, LoadUI>
    {
        protected override async UniTask InitEntity()
        {
            await base.InitEntity();
            // Entityの初期値を設定する
            entity.loadUniTasks = new UniTask[] {
                DI.loginController.Execute(),         // Step1; ログイン処理の実行
                DI.bringUserDataController.Execute()  // Step2: UserDataを取得
            };
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
            foreach (UniTask uniTask in entity.loadUniTasks)
            {
                await uniTask;
                UpdateSlider();
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