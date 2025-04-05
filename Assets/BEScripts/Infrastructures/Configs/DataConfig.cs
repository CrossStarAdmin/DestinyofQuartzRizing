using System;
using UnityEngine;

namespace Assets.BEScripts.Infrastructures.Configs
{
    public class DataConfig
    {
        private const string PLAYER_JSON_PATH = "UserDatas/Player";
        public string GetInitPlayerData()
        {
            // ResourcesからPlayer.jsonを読み込む
            TextAsset jsonAsset = Resources.Load<TextAsset>(PLAYER_JSON_PATH);
            if (jsonAsset == null)
                throw new Exception($"Player JSON file not found at path: {PLAYER_JSON_PATH}");
            // 取得したJSONを返す
            return jsonAsset.text;
        }
    }
}