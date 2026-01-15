using System;
using Assets.BEScripts;
using Assets.FEScripts.Abstracts;
using Assets.FEScripts.Scenes.Battle;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.FEScripts.Scene.Battle
{
    public class BattleManager : AbstractManager<BattleEntity, BattleUI>
    {
        // ==================================================
        // 初期化メソッド
        // ==================================================
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

            // EnemyInfoCanvasのアクション設定（アクション不要）
            ui.enemyInfoCanvasUI.SetActions(new Action[] { });

            // PlayerInfoCanvasのアクション設定
            ui.playerInfoCanvasUI.SetActions(new Action[] {
                () => ReducePlayerHP(),
                () => AddPlayerHP(),
                () => UseTensionCard(),
                () => UseHolyCard(),
                () => SkillButtonAction()
            });

            // PlayerMPCanvasのアクション設定（UpButton, DownButton）
            ui.playerMPCanvasUI.SetActions(
                new Action[] {
                    () => AddPlayerMP(),
                    () => ReducePlayerMP(),
                    () => AddPlayerAvailableMP(),
                    () => ReducePlayerAvailableMP()
                }
            );

            // PlayerMenuCanvasのアクション設定（StartTurnButton, DiceButton）
            ui.playerMenuCanvasUI.SetActions(
                new Action[] {
                    () => {
                        UnityEngine.Debug.Log("Start Turn Button: Player turn started");
                        TurnStart();
                    },
                    () => {
                        UnityEngine.Debug.Log("Dice Button: Roll dice");
                        RollDice();
                    }
                }
            );

            // DiceCanvasのアクション設定
            ui.diceCanvasUI.SetActions(new Action[] {
                () => ui.DisplayDiceCanvas(false)
            });

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
            // MPのリセット
            ui.playerMPCanvasUI.Init();
            ui.playerMPCanvasUI.UpdateMPDisplay(entity.PlayerAvailableMP, entity.PlayerCurrentMP);
            ui.playerMPCanvasUI.SetMPText(entity.PlayerCurrentMP, entity.PlayerAvailableMP);

            // カードの設定
            ui.playerInfoCanvasUI.SetTensionCardEnabled(false);
            ui.playerInfoCanvasUI.SetHolyCardEnabled(false);
        }

        // ==================================================
        // ターン管理
        // ==================================================
        private void TurnStart()
        {
            // テンションが3以下ならば、テンションカードを有効化
            entity.ResetUsedTensionCard();
            if (entity.PlayerTension < 3)
            {
                ui.playerInfoCanvasUI.SetTensionCardEnabled(true);
            }
            // 聖水を利用してた場合、MPを減らす
            if (entity.IsUsedHolyCard && !entity.IsFinishedHolyCardChange)
            {
                entity.DecrementPlayerMP();
                entity.FinishedHolyCardChange();
            }
            // まだ利用してない場合は聖水カードを有効化
            if (!entity.IsUsedHolyCard)
            {
                ui.playerInfoCanvasUI.SetHolyCardEnabled(true);
            }
            // MPを+1する
            entity.IncrementPlayerMP();
            // AvailableMPを全て回復
            entity.RecoverPlayerAvailableMP();
            // UIを更新
            ui.playerMPCanvasUI.UpdateMPDisplay(entity.PlayerAvailableMP, entity.PlayerCurrentMP);
            ui.playerMPCanvasUI.SetMPText(entity.PlayerCurrentMP, entity.PlayerAvailableMP);
        }

        // ==================================================
        // カード使用
        // ==================================================
        private void UseTensionCard()
        {
            UnityEngine.Debug.Log("TensionCard: Card used!");
            // 利用可能MPが0の場合は何もしない
            if (entity.PlayerAvailableMP == 0) return;
            // テンションを１つ増加
            entity.IncrementPlayerTension();
            // MPを1つ減少
            entity.DecrementPlayerAvailableMP();
            // UIを更新
            ui.playerMPCanvasUI.UpdateMPDisplay(entity.PlayerAvailableMP, entity.PlayerCurrentMP);
            ui.playerMPCanvasUI.SetMPText(entity.PlayerCurrentMP, entity.PlayerAvailableMP);
            ui.playerInfoCanvasUI.SetTension(entity.PlayerTension);
            // カードを無効化
            entity.UsedTensionCard();
            ui.playerInfoCanvasUI.SetTensionCardEnabled(false);
        }

        private void UseHolyCard()
        {
            UnityEngine.Debug.Log("HolyCard: Card used!");
            // 最大MPを1増加
            entity.IncrementPlayerMP();
            // 利用できるMPも1増加
            entity.IncrementPlayerAvailableMP();
            // UIを更新
            ui.playerMPCanvasUI.UpdateMPDisplay(entity.PlayerAvailableMP, entity.PlayerCurrentMP);
            ui.playerMPCanvasUI.SetMPText(entity.PlayerCurrentMP, entity.PlayerAvailableMP);
            // カードを無効化
            ui.playerInfoCanvasUI.SetHolyCardEnabled(false);
            // HolyCard使用フラグを立てる
            entity.UsedHolyCard();
        }

        // ==================================================
        // スキル関連
        // ==================================================
        public void SkillButtonAction()
        {
            if (entity.PlayerTension < 3) return;
            entity.ResetPlayerTension();
            ui.playerInfoCanvasUI.SetTension(entity.PlayerTension);
            // テンションカードを復活
            if (entity.IsUsedTensionCard == false)
            {
                ui.playerInfoCanvasUI.SetTensionCardEnabled(true);
            }
        }

        // ==================================================
        // Player HP操作
        // ==================================================
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

        // ==================================================
        // Player MP操作
        // ==================================================
        private void AddPlayerMP()
        {
            entity.IncrementPlayerMP();
            ui.playerMPCanvasUI.UpdateMPDisplay(entity.PlayerAvailableMP, entity.PlayerCurrentMP);
            ui.playerMPCanvasUI.SetMPText(entity.PlayerCurrentMP, entity.PlayerAvailableMP);
        }

        private void ReducePlayerMP()
        {
            entity.DecrementPlayerMP();
            ui.playerMPCanvasUI.UpdateMPDisplay(entity.PlayerAvailableMP, entity.PlayerCurrentMP);
            ui.playerMPCanvasUI.SetMPText(entity.PlayerCurrentMP, entity.PlayerAvailableMP);
        }

        private void AddPlayerAvailableMP()
        {
            entity.IncrementPlayerAvailableMP();
            ui.playerMPCanvasUI.UpdateMPDisplay(entity.PlayerAvailableMP, entity.PlayerCurrentMP);
            ui.playerMPCanvasUI.SetMPText(entity.PlayerCurrentMP, entity.PlayerAvailableMP);
        }

        private void ReducePlayerAvailableMP()
        {
            entity.DecrementPlayerAvailableMP();
            ui.playerMPCanvasUI.UpdateMPDisplay(entity.PlayerAvailableMP, entity.PlayerCurrentMP);
            ui.playerMPCanvasUI.SetMPText(entity.PlayerCurrentMP, entity.PlayerAvailableMP);
        }

        private async void RollDice()
        {
            UnityEngine.Debug.Log("Rolling dice");
            ui.DisplayDiceCanvas(true);
            await ui.diceCanvasUI.RollDice();
        }

        // ==================================================
        // コメントアウト済み（未実装）
        // ==================================================

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