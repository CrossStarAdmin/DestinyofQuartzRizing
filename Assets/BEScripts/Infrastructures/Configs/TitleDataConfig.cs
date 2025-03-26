using System.Collections.Generic;
using Assets.BEScripts.Infrastructures.Models.PlayFab;
using Cysharp.Threading.Tasks;

namespace Assets.BEScripts.Infrastructures.Configs
{
    public class TitleDataConfig
    {
        public TitleDataConfig()
        {
            PlayFabModel.InitializeTitleData();
        }

        public async UniTask BringAllTitleData()
        {
            await PlayFabModel.titleData.BringAllTitleDataRequest();
        }

        public async UniTask<string> GetTitleData(string key)
        {
            return await PlayFabModel.titleData.GetTitleData(key);
        }
    }
}