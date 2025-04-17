using Assets.BEScripts.Infrastructures.Configs;
using Cysharp.Threading.Tasks;

namespace Assets.BEScripts.Infrastructures.Middlewares.UserData
{
    public class BringUserDataController
    {
        private readonly UserDataConfig _userDataConfig;

        public BringUserDataController()
        {
            _userDataConfig = new UserDataConfig();
        }

        public async UniTask Execute()
        {
            await _userDataConfig.BringAllUserData();
        }
    }
}