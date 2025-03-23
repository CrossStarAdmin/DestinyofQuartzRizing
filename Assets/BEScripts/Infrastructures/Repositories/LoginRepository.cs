using Assets.BEScripts.Infrastructures.Models.PlayFab;
using Cysharp.Threading.Tasks;

namespace Assets.BEScripts.Infrastructures.Repositories
{
    public class LoginRepository
    {
        public LoginRepository()
        {
            PlayFabModel.InitializeLogin();
        }

        public async UniTask LoginPlayFab()
        {
            await PlayFabModel.login.LoginPlayFab();
        }
    }
}