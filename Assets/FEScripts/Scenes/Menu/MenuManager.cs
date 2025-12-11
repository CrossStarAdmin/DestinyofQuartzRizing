using System;
using Assets.BEScripts;
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
        }
        protected override void InitUI()
        {
            base.InitUI();
            // EnemyListManagerのデータとActionを設定する
        }

        protected override void InitEvent()
        {
            ui.headerCanvasUI.SetActions(
                new Action[] {
                    () => SceneManager.LoadScene("TitleScene"),
                    () => UnityEngine.Debug.Log("Question Button")
                }
            );
            ui.selectCharacterCanvasUI.SetActions(
                new Action[] {
                    () => SelectedPlayerDropdown(),
                    () => SelectedEnemyDropdown()
                }
            );
            ui.buttonCanvasUI.SetActions(
                new Action[] {
                    () => UnityEngine.Debug.Log("Start Button Pressed")
                }
            );
            ui.detailModalCanvasUI.SetActions(
                new Action[] {
                    () => UnityEngine.Debug.Log("No Set"),
                    () => CloseDetailModal()
                }
            );
        }

        protected override async UniTask InitOriginProcess()
        {
            await UniTask.Delay(0);
            ui.displayCharacterCanvasUI.InitImages(
                Setting.selectedPlayerCharacter.abbreviationName,
                Setting.selectedEnemyCharacter.abbreviationName
            );
            ui.selectCharacterCanvasUI.InitDropdowns(
                entity.characterTypes
            );
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

        // ここにMenuManager固有のメソッドを追加
        public void SelectedPlayerDropdown()
        {
            int selectedIndex = ui.selectCharacterCanvasUI.GetSelectedPlayerCharacterIndex();
            Setting.selectedPlayerCharacter = entity.characterTypes[selectedIndex];
            string abbreviationName = entity.characterTypes[selectedIndex].abbreviationName;
            ui.displayCharacterCanvasUI.SetPlayerCharacterImage(abbreviationName);
        }

        public void SelectedEnemyDropdown()
        {
            int selectedIndex = ui.selectCharacterCanvasUI.GetSelectedEnemyCharacterIndex();
            Setting.selectedEnemyCharacter = entity.characterTypes[selectedIndex];
            string abbreviationName = entity.characterTypes[selectedIndex].abbreviationName;
            ui.displayCharacterCanvasUI.SetEnemyCharacterImage(abbreviationName);
        }
    }
}