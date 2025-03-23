using Assets.BEScripts.UseCases.Login.Services;
using Cysharp.Threading.Tasks;

namespace Assets.BEScripts.Presentations.Login.Controllers
{
    public class LoginController
    {
        private readonly LoginService _loginService;
        public LoginController(
            LoginService loginService
        )
        {
            _loginService = loginService;
        }

        public async UniTask Execute()
        {
            await _loginService.Execute();
        }
    }
}