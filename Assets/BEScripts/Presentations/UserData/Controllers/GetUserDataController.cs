using Assets.BEScripts.Infrastructures.Configs;
using Cysharp.Threading.Tasks;

namespace Assets.BEScripts.Presentations.UserData.Controllers
{
    public class GetUserDataController
    {
        private readonly UserDataConfig _userDataConfig;
        public GetUserDataController()
        {
            _userDataConfig = new UserDataConfig();
        }

        public async UniTask<string> Execute(
            string key
        )
        {
            return await _userDataConfig.GetUserData(key);
        }
    }
}