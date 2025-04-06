using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Assets.BEScripts;
using Assets.FEScripts.Abstracts;
using Assets.FEScripts.Scenes.Title;
using Assets.FEScripts.Types;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.FEScripts.Scene.Title
{
    public class TitleManager : AbstractManager<TitleEntity, TitleUI>
    {
        protected override async UniTask InitEntity()
        {
            await base.InitEntity();
            // Entityの初期値を設定する
            entity.getPlayersResponseType = await DI.getPlayersController.Execute();
        }
        protected override void InitUI()
        {
            base.InitUI();
            // Playerの初期値を設定する
            ui.detailModalCanvasUI.SetDetailModal(
                entity.playerTypes[0]
            );
        }

        protected override void InitEvent()
        {
            ui.titleHeaderCanvasUI.SetActions(new Action[] {
                () => ui.detailModalCanvasUI.DisplayCanvas(true),
            });
            ui.playerSettingCanvasUI.SetActions(new Action[] {
                () => UpdatePlayerCount(false),
                () => UpdatePlayerCount(true),
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
            // PlayerCountの初期値を設定する
            InitPlayerCount();
            // await処理
            await Task.Delay(0);
        }

        protected void InitPlayerCount()
        {
            // 起動時
            if (Setting.playerCount == 0 || Setting.playerNames == null)
            {
                entity.playerNames = new string[Setting.INIT_PLAYER_COUNT];
                for (int i = 0; i < Setting.INIT_PLAYER_COUNT; i++)
                {
                    entity.playerNames[i] = "Player" + (i + 1).ToString();
                }
                // プレイヤーの数を初期化する
                entity.playerCount = Setting.INIT_PLAYER_COUNT;
                // PlayerSettingCanvasを更新する
                ui.playerSettingCanvasUI.UpdatePlayerSetting(
                    entity.playerCount,
                    entity.playerNames
                );
            }
            // 起動後
            else
            {
                entity.playerNames = Setting.playerNames;
                for (int i = 0; i < Setting.playerCount; i++)
                {
                    entity.playerNames[i] = Setting.playerNames[i];
                }
                // プレイヤーの数を初期化する
                entity.playerCount = Setting.playerCount;
                // PlayerSettingCanvasを更新する
                ui.playerSettingCanvasUI.UpdatePlayerSetting(
                    entity.playerCount,
                    entity.playerNames
                );
            }
        }

        protected void UpdatePlayerCount(bool _isAdd)
        {
            // 現在のプレイヤーの名前を一旦取得する
            entity.playerNames = new string[entity.playerCount];
            for (int i = 0; i < entity.playerCount; i++)
            {
                entity.playerNames[i] = ui.playerSettingCanvasUI.GetPlayerName(i);
            }
            // プレイヤーの数を更新する
            if (_isAdd)
            {
                // プレイヤーの数を増やす
                entity.playerCount++;
                // entityのPlayerNamesをリサイズ
                entity.playerNames = entity.playerNames.Append("Player" + entity.playerCount.ToString()).ToArray();
            }
            else
            {
                // プレイヤーの数を減らす
                entity.playerCount--;
                // playerNamesから最後のデータを削除する
                entity.playerNames = entity.playerNames.Take(entity.playerCount).ToArray();
            }
            // SettingCanvasを更新
            ui.playerSettingCanvasUI.UpdatePlayerSetting(
                entity.playerCount,
                entity.playerNames
            );
        }

        protected void StartGame()
        {
            // プレイヤーの名前を取得する
            string[] playerNames = new string[entity.playerCount];
            for (int i = 0; i < entity.playerCount; i++)
            {
                playerNames[i] = ui.playerSettingCanvasUI.GetPlayerName(i);
            }
            // プレイヤーの名前を設定する
            entity.playerNames = playerNames;
            // プレイヤーの数を設定する
            Setting.playerCount = entity.playerCount;
            Setting.playerNames = playerNames;
            // ページ遷移
            SceneManager.LoadScene("MenuScene");
        }
    }
}