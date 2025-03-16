using Assets.BEScripts.Infrastructures.Repositories;
using Assets.BEScripts.Presentations.Controllers;
using Assets.BEScripts.UseCases.Services;

namespace Assets.BEScripts
{
    public static class DI
    {
        private static LoginService loginService = new LoginService(
            new LoginRepository()
        );

        public static LoginController loginController = new LoginController(
            loginService
        );
    }
}