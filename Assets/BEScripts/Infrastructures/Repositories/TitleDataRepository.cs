using Assets.BEScripts.Infrastructures.Models.PlayFab;
using Cysharp.Threading.Tasks;

namespace Assets.BEScripts.Infrastructures.Repositories
{
    public class TitleDataRepository
    {
        public TitleDataRepository()
        {
            PlayFabModel.InitializeTitleData();
        }

        public async UniTask GetAllTitleData()
        {
            await PlayFabModel.titleData.BringAllTitleDataRequest();
        }

        public async UniTask<string> GetTitleData(string key)
        {
            return await PlayFabModel.titleData.GetTitleData(key);
        }
    }
}