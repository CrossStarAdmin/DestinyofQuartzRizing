using Assets.BEScripts.Infrastructures.Repositories;
using Assets.BEScripts.Presentations.Controllers;
using Assets.BEScripts.UseCases.Services;

namespace Assets.BEScripts
{
    public static class DI
    {
        // --------------------------------------------------
        // Service
        // --------------------------------------------------
        // Login
        private static LoginService loginService = new LoginService(
            new LoginRepository()
        );
        // TitleData
        private static BringTitleDataService bringTitleDataService = new BringTitleDataService(
            new TitleDataRepository()
        );
        private static GetTitleDataService getTitleDataService = new GetTitleDataService(
            new TitleDataRepository()
        );
        // UserData
        private static BringUserDataService bringUserDataService = new BringUserDataService(
            new UserDataRepository()
        );
        private static GetUserDataService getUserDataService = new GetUserDataService(
            new UserDataRepository()
        );
        private static CreateUserDataService createUserDataService = new CreateUserDataService(
            new UserDataRepository()
        );

        // --------------------------------------------------
        // Controller
        // --------------------------------------------------
        // Login
        public static LoginController loginController = new LoginController(
            loginService
        );
        // TitleData
        public static BringTitleDataController bringTitleDataController = new BringTitleDataController(
            bringTitleDataService
        );
        public static GetTitleDataController getTitleDataController = new GetTitleDataController(
            getTitleDataService
        );
        // UserData
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