using System;
using Assets.BEScripts;
using Assets.FEScripts.Abstracts;
using Assets.FEScripts.Scenes.Battle;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine.SceneManagement;

namespace Assets.FEScripts.Scene.Battle
{
    public class BattleManager : AbstractManager<BattleEntity, BattleUI>
    {
        protected override async UniTask InitEntity()
        {
            await base.InitEntity();
        }

        protected override void InitUI()
        {
            base.InitUI();
            // TODO: UI初期化処理
        }

        protected override void InitEvent()
        {
            // HeaderCanvasのアクション設定
            ui.headerCanvasUI.SetActions(
                new Action[] {
                    () => {
                        UnityEngine.Debug.Log("Back Button: Return to Menu");
                        SceneManager.LoadScene("MenuScene");
                    },
                    () => UnityEngine.Debug.Log("Question Button: Show Help")
                }
            );

            // PlayerMenuCanvasのアクション設定（StartTurnButton, DiceButton）
            ui.playerMenuCanvasUI.SetActions(
                new Action[] {
                    () => {
                        UnityEngine.Debug.Log("Start Turn Button: Player turn started");
                        // StartPlayerTurn();
                    },
                    () => {
                        UnityEngine.Debug.Log("Dice Button: Roll dice");
                        // RollDice();
                    }
                }
            );

            // DetailModalCanvasのアクション設定
            ui.detailModalCanvasUI.SetActions(
                new Action[] {
                    () => UnityEngine.Debug.Log("Modal Confirm Button"),
                    () => {
                        UnityEngine.Debug.Log("Modal Close Button");
                        // CloseDetailModal();
                    }
                }
            );

            // EnemyInfoCanvasのアクション設定（アクション不要）
            ui.enemyInfoCanvasUI.SetActions(new Action[] { });

            // PlayerInfoCanvasのアクション設定
            ui.playerInfoCanvasUI.SetActions(new Action[] {
                () => ReducePlayerHP(),
                () => AddPlayerHP(),
            });

            // PlayerMPCanvasのアクション設定（UpButton, DownButton）
            ui.playerMPCanvasUI.SetActions(
                new Action[] {
                    () => AddPlayerMP(),
                    () => ReducePlayerMP()
                }
            );
        }

        protected override async UniTask InitOriginProcess()
        {
            await UniTask.Delay(0);
            UnityEngine.Debug.Log("Battle Start: Initialize battle process");
            // 相手側の情報をUIに反映
            ui.enemyInfoCanvasUI.Init(
                entity.EnemyCharacter,
                entity.MaxHP,
                entity.EnemyTension
            );
            // 味方側の情報をUIに反映
            ui.playerInfoCanvasUI.Init(
                entity.PlayerCharacter,
                entity.MaxHP,
                entity.PlayerTension
            );
            // MPのリセット
            ui.playerMPCanvasUI.Init();
            ui.playerMPCanvasUI.UpdateMPDisplay(entity.PlayerAvailableMP, entity.PlayerCurrentMP);
        }

        private void AddPlayerHP()
        {
            entity.IncrementPlayerHP();
            ui.playerInfoCanvasUI.SetHP(entity.PlayerCurrentHP);
        }

        private void ReducePlayerHP()
        {
            entity.DecrementPlayerHP();
            ui.playerInfoCanvasUI.SetHP(entity.PlayerCurrentHP);
        }

        private void AddPlayerMP()
        {
            entity.IncrementPlayerMP();
            ui.playerMPCanvasUI.UpdateMPDisplay(entity.PlayerAvailableMP, entity.PlayerCurrentMP);
        }

        private void ReducePlayerMP()
        {
            entity.DecrementPlayerMP();
            ui.playerMPCanvasUI.UpdateMPDisplay(entity.PlayerAvailableMP, entity.PlayerCurrentMP);
        }

        // // バトルアクション関連メソッド
        // protected void StartPlayerTurn()
        // {
        //     UnityEngine.Debug.Log("Starting player turn");
        //     // TODO: プレイヤーターン開始処理の実装
        // }

        // protected void RollDice()
        // {
        //     UnityEngine.Debug.Log("Rolling dice");
        //     // TODO: ダイスロール処理の実装
        //     int diceResult = UnityEngine.Random.Range(1, 7);
        //     UnityEngine.Debug.Log($"Dice result: {diceResult}");
        // }

        // protected void CloseDetailModal()
        // {
        //     UnityEngine.Debug.Log("Closing detail modal");
        //     ui.DisplayDetailModalCanvas(false);
        // }
        //     else
        //     {
        //         UnityEngine.Debug.Log("Escape failed! Battle continues");
        //     }
        // }

        // protected void CloseDetailModal()
        // {
        //     UnityEngine.Debug.Log("Closing detail modal");
        //     ui.DisplayDetailModalCanvas(false);
        // }
    }
}