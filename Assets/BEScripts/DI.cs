using Assets.BEScripts.Infrastructures.Repositories;
using Assets.BEScripts.Presentations.Login.Controllers;
using Assets.BEScripts.Presentations.TitleData.Controllers;
using Assets.BEScripts.Presentations.UserData.Controllers;
using Assets.BEScripts.Presentations.Enemies.Controllers;
using Assets.BEScripts.UseCases.Enemies.Services;
using Assets.BEScripts.UseCases.Players.Services;
using Assets.BEScripts.Presentations.Players.Controllers;
using Assets.BEScripts.Presentations.Data.Controllers;

namespace Assets.BEScripts
{
    public static class DI
    {
        // --------------------------------------------------
        // Service
        // --------------------------------------------------
        // Enemies
        public static GetEnemiesService getEnemiesService = new GetEnemiesService(
            new EnemyRepository()
        );

        // --------------------------------------------------
        // Controller
        // --------------------------------------------------
        // Login
        public static LoginController loginController = new LoginController();
        // TitleData
        public static BringTitleDataController bringTitleDataController = new BringTitleDataController();
        public static GetTitleDataController getTitleDataController = new GetTitleDataController();
        // UserData
        public static BringUserDataController bringUserDataController = new BringUserDataController();
        public static GetUserDataController getUserDataController = new GetUserDataController();
        public static CreateUserDataController createUserDataController = new CreateUserDataController();
        // Data
        public static GetInitPlayerDataController getInitPlayerDataController = new GetInitPlayerDataController();
        // Enemies
        public static GetEnemiesController getEnemiesController = new GetEnemiesController(
            getEnemiesService
        );
    }
}