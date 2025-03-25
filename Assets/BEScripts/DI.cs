using Assets.BEScripts.Presentations.Login.Controllers;
using Assets.BEScripts.Presentations.TitleData.Controllers;
using Assets.BEScripts.Presentations.UserData.Controllers;

namespace Assets.BEScripts
{
    public static class DI
    {
        // --------------------------------------------------
        // Service
        // --------------------------------------------------


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
    }
}