using Assets.BEScripts.Infrastructures.Models.PlayFab;
using Cysharp.Threading.Tasks;

namespace Assets.BEScripts.Infrastructures.Repositories
{
    public class LoginRepository
    {
        public LoginRepository()
        {
            PlayFabController.InitializeLogin();
        }

        public async UniTask LoginPlayFab()
        {
            await PlayFabController.login.LoginPlayFab();
        }
    }
}