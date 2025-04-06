using System;
using System.Diagnostics;
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
        }
        protected override void InitUI()
        {
            base.InitUI();
            // EnemyListManagerのデータとActionを設定する
            InitPlayerCount();
        }

        protected override void InitEvent()
        {
            ui.titleHeaderCanvasUI.SetActions(new Action[] {
                () => UnityEngine.Debug.Log("IconButton Clicked"),
            });
            ui.playerSettingCanvasUI.SetActions(new Action[] {
                () => UpdatePlayerCount(false),
                () => UpdatePlayerCount(true),
            });
            ui.playButtonCanvasUI.SetActions(new Action[] {
                () => SceneManager.LoadScene("MenuScene"),
            });
        }

        protected override async UniTask InitOriginProcess()
        {
            await Task.Delay(0);
        }

        protected void InitPlayerCount()
        {
            string[] playerName = new string[3];
            for (int i = 0; i < 3; i++)
            {
                playerName[i] = "Player" + (i + 1).ToString();
            }
            // プレイヤーの数を初期化する
            entity.playerCount = 3;
            // PlayerSettingCanvasを更新する
            ui.playerSettingCanvasUI.UpdatePlayerSetting(
                entity.playerCount,
                playerName
            );
        }

        protected void UpdatePlayerCount(bool _isAdd)
        {
            // 現在のプレイヤーの名前を一旦取得する
            string[] playerNames = new string[entity.playerCount];
            for (int i = 0; i < entity.playerCount; i++)
            {
                playerNames[i] = ui.playerSettingCanvasUI.GetPlayerName(i);
            }
            // プレイヤーの数を更新する
            if (_isAdd)
            {
                // プレイヤーの数を増やす
                entity.playerCount++;
                // playerNamesに新しく１つデータを追加する
                Array.Resize(ref playerNames, entity.playerCount);
                playerNames[entity.playerCount - 1] = "Player" + entity.playerCount.ToString();
            }
            else
            {
                // プレイヤーの数を減らす
                entity.playerCount--;
                // playerNamesから最後のデータを削除する
                Array.Resize(ref playerNames, entity.playerCount);
            }
            // SettingCanvasを更新
            ui.playerSettingCanvasUI.UpdatePlayerSetting(
                entity.playerCount,
                playerNames
            );
        }
    }
}