using System;
using Assets.BEScripts;
using Assets.FEScripts.Abstracts;
using Assets.FEScripts.Scenes.Purchase;
using Assets.FEScripts.Types;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.FEScripts.Scenes.Purchase
{
    public class PurchaseManager : AbstractManager<PurchaseEntity, PurchaseUI>
    {
        protected override async UniTask InitEntity()
        {
            await base.InitEntity();
            entity.getConsumablesResponseType = await DI.getConsumablesController.Execute();
        }
        protected override void InitUI()
        {
            base.InitUI();
            // EnemyListManagerのデータとActionを設定する
            Action[] consumableListManagerActions = new Action[entity.consumableTypes.Length];
            for (int i = 0; i < entity.consumableTypes.Length; i++)
            {
                ConsumableType consumableType = entity.consumableTypes[i];
                consumableListManagerActions[i] = () => PurchaseItem(consumableType);
            }
            ui.menuCanvasUI.SetConsumableListManager(
                entity.consumableTypes,
                consumableListManagerActions
            );
        }

        protected override void InitEvent()
        {
            ui.headerCanvasUI.SetActions(
                new Action[] {
                    () => SceneManager.LoadScene("TitleScene"),
                    () => UnityEngine.Debug.Log("Question Button")
                }
            );
        }

        protected override async UniTask InitOriginProcess()
        {
            await UniTask.Delay(0);
        }

        protected void PurchaseItem(
            ConsumableType _consumableType
        )
        {
            Debug.Log("PurchaseItem: " + _consumableType.name);
        }
    }
}