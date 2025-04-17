using System;
using System.Collections.Generic;
using Assets.BEScripts.Domains.Entities;
using Assets.BEScripts.Domains.Types.ModelParams;
using Assets.BEScripts.Infrastructures.Models.PlayFab;
using Cysharp.Threading.Tasks;
using Unity.Plastic.Newtonsoft.Json;

namespace Assets.BEScripts.Infrastructures.Repositories
{
    public class PlayerRepository
    {
        private PlayerModelType _model;

        public async UniTask Initialize()
        {
            string data = await PlayFabModel.userData.GetUserData(Setting.PLAYER_DATA_KEY);
            if (string.IsNullOrEmpty(data))
            {
                // データが存在しない場合は新規作成
                _model = new PlayerModelType
                {
                    list = new PlayerListType[0] // 空の配列で初期化
                };
            }
            else
            {
                // データが存在する場合はデシリアライズしてモデルを初期化
                _model = JsonConvert.DeserializeObject<PlayerModelType>(data);
            }
        }

        public async UniTask<PlayerEntity[]> FindAll()
        {
            if (_model == null)
                await Initialize();
            return Array.ConvertAll(_model.list, PlayerEntity.CreateFromModel);
        }

        public async UniTask<PlayerEntity> FindByUid(string uid)
        {
            if (_model == null)
                await Initialize();
            PlayerListType modelParam = Array.Find(_model.list, _ => _.uid == uid);
            return modelParam != null ? PlayerEntity.CreateFromModel(modelParam) : null;
        }

        public async UniTask Save(PlayerEntity player)
        {
            if (_model == null)
                await Initialize();

            // 既存のプレイヤーを探す
            int index = Array.FindIndex(_model.list, _ => _.uid == player.uid);

            // 既存プレイヤー存在しない場合はエラー
            if (index < 0)
                throw new Exception($"Player with UID {player.uid} not found.");

            // 新しいプレイヤーデータを作成
            var playerData = new PlayerListType
            {
                uid = _model.list[index].uid,
                name = _model.list[index].name,
                nameId = _model.list[index].nameId,
                maxHp = player.maxHp,
                maxMp = player.maxMp,
                attack = player.attack,
                defense = player.defense,
                speed = player.speed
            };

            // 既存のプレイヤーを更新
            _model.list[index] = playerData;

            // PlayFabに保存
            string jsonData = JsonConvert.SerializeObject(_model);
            await PlayFabModel.userData.UpdateUserDataRequest(new Dictionary<string, string>
            {
                { Setting.PLAYER_DATA_KEY, jsonData }
            });
        }
    }
}