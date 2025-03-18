using System.Collections.Generic;
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

        public async UniTask<string> GetUserData(string key)
        {
            return await PlayFabController.userData.GetUserData(key);
        }

        public async UniTask CreateUserData(Dictionary<string, string> data)
        {
            await PlayFabController.userData.UpdateUserDataRequest(data);
        }
    }
}