using Assets.BEScripts.Infrastructures.Repositories;
using Assets.BEScripts.Presentations.Controllers;
using Assets.BEScripts.UseCases.Services;

namespace Assets.BEScripts
{
    public static class DI
    {
        // Service
        private static LoginService loginService = new LoginService(
            new LoginRepository()
        );
        private static BringUserDataService bringUserDataService = new BringUserDataService(
            new UserDataRepository()
        );
        private static GetUserDataService getUserDataService = new GetUserDataService(
            new UserDataRepository()
        );
        private static CreateUserDataService createUserDataService = new CreateUserDataService(
            new UserDataRepository()
        );

        // Controller
        public static LoginController loginController = new LoginController(
            loginService
        );
        public static BringUserDataController bringUserDataController = new BringUserDataController(
            bringUserDataService
        );
        public static GetUserDataController getUserDataController = new GetUserDataController(
            getUserDataService
        );
        public static CreateUserDataController createUserDataController = new CreateUserDataController(
            createUserDataService
        );
    }
}