using System.Collections.Generic;
using Assets.BEScripts.Infrastructures.Models.PlayFab;
using Cysharp.Threading.Tasks;

namespace Assets.BEScripts.Infrastructures.Repositories
{
    public class UserDataRepository
    {
        public UserDataRepository()
        {
            PlayFabModel.InitializeUserData();
        }

        public async UniTask GetAllUserData()
        {
            await PlayFabModel.userData.BringAllUserDataRequest();
        }

        public async UniTask<string> GetUserData(string key)
        {
            return await PlayFabModel.userData.GetUserData(key);
        }

        public async UniTask CreateUserData(Dictionary<string, string> data)
        {
            await PlayFabModel.userData.UpdateUserDataRequest(data);
        }
    }
}