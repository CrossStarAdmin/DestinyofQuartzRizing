using Assets.BEScripts.Infrastructures.Models.PlayFab;
using Cysharp.Threading.Tasks;

namespace Assets.BEScripts.Infrastructures.Repositories
{
    public class TitleDataRepository
    {
        public TitleDataRepository()
        {
            PlayFabController.InitializeTitleData();
        }

        public async UniTask GetAllTitleData()
        {
            await PlayFabController.titleData.BringAllTitleDataRequest();
        }

        public async UniTask<string> GetTitleData(string key)
        {
            return await PlayFabController.titleData.GetTitleData(key);
        }
    }
}