using System;
using System.Collections.Generic;
using Assets.BEScripts;
using Assets.BEScripts.Presentations.Enemies.Controllers;
using Assets.FEScripts.Abstracts;
using Assets.FEScripts.Scenes.Menu;
using Assets.FEScripts.Types;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Assets.FEScripts.Scene.Menu
{
    public class MenuManager : AbstractManager<MenuEntity, MenuUI>
    {
        protected override async UniTask InitEntity()
        {
            await base.InitEntity();
            entity.getEnemiesResponseType = await DI.getEnemiesController.Execute();
        }
        protected override void InitUI()
        {
            base.InitUI();
            // EnemyListManagerのActionを設定する
            Action[] enemyListManagerActions = new Action[entity.enemyTypes.Length];
            for (int i = 0; i < entity.enemyTypes.Length; i++)
            {
                EnemyType enemyType = entity.enemyTypes[i];
                enemyListManagerActions[i] = () => DisplayDetailModal(enemyType);
            }

            ui.menuCanvasUI.SetEnemyListManager(
                entity.enemyTypes,
                enemyListManagerActions
            );
        }
        protected override void InitEvent()
        {
        }

        protected override async UniTask InitOriginProcess()
        {
            await UniTask.Delay(0);
        }

        protected void DisplayDetailModal(
            EnemyType _enemyType
        )
        {
            ui.DisplayDetailModalCanvas(true);
            ui.detailModalCanvasUI.SetDetailModal(_enemyType);
        }

        protected void CloseDetailModal()
        {
            ui.DisplayDetailModalCanvas(false);
        }
    }
}