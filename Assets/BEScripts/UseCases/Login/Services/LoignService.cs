using Assets.BEScripts.Infrastructures.Repositories;
using Cysharp.Threading.Tasks;

namespace Assets.BEScripts.UseCases.Login.Services
{
    public class LoginService
    {
        private readonly LoginRepository _loginRepository;

        public LoginService(
            LoginRepository loginRepository
        )
        {
            _loginRepository = loginRepository;
        }

        public async UniTask Execute()
        {
            await _loginRepository.LoginPlayFab();
        }
    }
}