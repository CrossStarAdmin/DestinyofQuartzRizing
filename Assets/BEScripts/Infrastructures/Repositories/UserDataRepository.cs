using Assets.BEScripts.Infrastructures.Models.PlayFab;
using Cysharp.Threading.Tasks;

namespace Assets.BEScripts.Infrastructures.Repositories
{
    public class UserDataRepository
    {
        public UserDataRepository()
        {
            PlayFabController.InitializeUserData();
        }

        public async UniTask GetAllUserData()
        {
            await PlayFabController.userData.BringAllUSerDataRequest();
        }
    }
}