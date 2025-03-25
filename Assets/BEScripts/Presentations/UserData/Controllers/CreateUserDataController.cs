using System.Collections.Generic;
using Assets.BEScripts.Infrastructures.Configs;
using Cysharp.Threading.Tasks;

namespace Assets.BEScripts.Presentations.UserData.Controllers
{
    public class CreateUserDataController
    {
        private readonly UserDataConfig _userDataConfig;
        public CreateUserDataController()
        {
            _userDataConfig = new UserDataConfig();
        }

        public async UniTask Execute(
            Dictionary<string, string> data
        )
        {
            await _userDataConfig.CreateUserData(data);
        }
    }
}