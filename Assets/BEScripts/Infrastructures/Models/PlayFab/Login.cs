using Assets.BEScripts.Domains.Abstracts;
using PlayFab.ClientModels;
using Cysharp.Threading.Tasks;

namespace Assets.BEScripts.Infrastructures.Models.PlayFab
{
    public class Login : AbstractPlayFab
    {
        public Login()
        {
            PlayFabAuthService.OnLoginSuccess += LoginSuccessFunction;
            PlayFabAuthService.OnPlayFabError += FailedFunction;
        }

        public async UniTask LoginPlayFab()
        {
            await Function(
                () => PlayFabAuthService.Instance.Authenticate(Authtypes.Silent),
                "LoginPlayFab Success",
                "LoginPlayFab Failed"
            );
        }

        protected void LoginSuccessFunction(LoginResult _result)
        {
            SuccessFunction();
        }
    }
}