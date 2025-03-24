using System;
using Assets.BEScripts.Domains.Entities;
using Assets.BEScripts.Domains.Types.Json;
using Assets.BEScripts.Infrastructures.Models.PlayFab;
using Cysharp.Threading.Tasks;
using Unity.Plastic.Newtonsoft.Json;

namespace Assets.BEScripts.Infrastructures.Repositories
{
    public class EnemyRepository
    {
        private EnemyModelType _model;

        public async UniTask Initialize()
        {
            string data = await PlayFabModel.titleData.GetTitleData("Enemy");
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
            return EnemyEntity.CreateFromModel(modelParam);
        }
    }
}