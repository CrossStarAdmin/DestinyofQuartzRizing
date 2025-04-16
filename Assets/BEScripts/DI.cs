using Assets.BEScripts.Infrastructures.Repositories;
using Assets.BEScripts.Presentations.Login.Controllers;
using Assets.BEScripts.Presentations.TitleData.Controllers;
using Assets.BEScripts.Presentations.UserData.Controllers;
using Assets.BEScripts.Presentations.Enemies.Controllers;
using Assets.BEScripts.UseCases.Enemies.Services;
using Assets.BEScripts.UseCases.Players.Services;
using Assets.BEScripts.Presentations.Players.Controllers;
using Assets.BEScripts.Presentations.Data.Controllers;
using Assets.BEScripts.Presentations.CatalogList;
using Assets.BEScripts.UseCases.Consumables.Services;
using Assets.BEScripts.UseCases.NoConsumables.Services;
using Assets.BEScripts.UseCases.Subscriptions.Services;
using Assets.BEScripts.Presentations.Consumables.Controllers;
using Assets.BEScripts.Presentations.NoConsumables.Controllers;
using Assets.BEScripts.Presentations.Subscriptions.Controllers;

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
        // Players
        public static GetPlayersService getPlayersService = new GetPlayersService(
            new PlayerRepository()
        );
        // Consumables
        public static GetConsumablesService getConsumablesService = new GetConsumablesService(
            new ConsumableRepository()
        );
        // NoConsumables
        public static GetNoConsumablesService getNoConsumableService = new GetNoConsumablesService(
            new NoConsumableRepository()
        );
        // Subscriptions
        public static GetSubscriptionsService getSubscriptionsService = new GetSubscriptionsService(
            new SubscriptionRepository()
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
        // CatalogList
        public static BringCatalogListController bringCatalogListController = new BringCatalogListController();
        // Data
        public static GetInitPlayerDataController getInitPlayerDataController = new GetInitPlayerDataController();
        // Enemies
        public static GetEnemiesController getEnemiesController = new GetEnemiesController(
            getEnemiesService
        );
        // Players
        public static GetPlayersController getPlayersController = new GetPlayersController(
            getPlayersService
        );
        // Consumables
        public static GetConsumablesController getConsumablesController = new GetConsumablesController(
            getConsumablesService
        );
        // NoConsumables
        public static GetNoConsumablesController getNoConsumablesController = new GetNoConsumablesController(
            getNoConsumableService
        );
        // Subscriptions
        public static GetSubscriptionsController getSubscriptionsController = new GetSubscriptionsController(
            getSubscriptionsService
        );
    }
}