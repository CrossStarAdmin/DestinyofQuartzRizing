using Assets.BEScripts.Infrastructures.Repositories;
using Assets.BEScripts.Presentations.Login.Controllers;
using Assets.BEScripts.Presentations.TitleData.Controllers;
using Assets.BEScripts.Presentations.UserData.Controllers;
using Assets.BEScripts.Presentations.Enemies.Controllers;
using Assets.BEScripts.UseCases.Enemies.Services;

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
        // Enemies
        public static GetEnemiesController getAllEnemyController = new GetEnemiesController(
            getEnemiesService
        );
    }
}