using Assets.BEScripts.Infrastructures.Configs;
using Cysharp.Threading.Tasks;

namespace Assets.BEScripts.Infrastructures.Middlewares.Login
{
    public class LoginController
    {
        private readonly LoginConfig _loginConfig;
        public LoginController()
        {
            _loginConfig = new LoginConfig();
        }

        public async UniTask Execute()
        {
            await _loginConfig.LoginPlayFab();
        }
    }
}