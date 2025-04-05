using System;
using Assets.BEScripts.Domains.Entities;
using Assets.BEScripts.Domains.Types.ModelParams;
using Assets.BEScripts.Infrastructures.Models.PlayFab;
using Cysharp.Threading.Tasks;
using Unity.Plastic.Newtonsoft.Json;

namespace Assets.BEScripts.Infrastructures.Repositories
{
    public class EnemyRepository
    {
        private EnemyModelType _model;
        private const string ENEMY_DATA_KEY = "Enemy";

        public async UniTask Initialize()
        {
            string data = await PlayFabModel.userData.GetUserData(ENEMY_DATA_KEY);
            // データが存在しない場合はエラー処理を吐き出す
            if (string.IsNullOrEmpty(data))
                throw new Exception($"Enemy data not found for key: {ENEMY_DATA_KEY}");
            // データが存在する場合はデシリアライズしてモデルを初期化
            _model = JsonConvert.DeserializeObject<EnemyModelType>(data);
        }

        public async UniTask<EnemyEntity[]> FindAll()
        {
            if (_model == null)
                await Initialize();
            return Array.ConvertAll(_model.list, EnemyEntity.CreateFromModel);
        }

        public async UniTask<EnemyEntity> FindByUid(string uid)
        {
            if (_model == null)
                await Initialize();
            EnemyListType modelParam = Array.Find(_model.list, _ => _.uid == uid);
            return modelParam != null ? EnemyEntity.CreateFromModel(modelParam) : null;
        }
    }
}