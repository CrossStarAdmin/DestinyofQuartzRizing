using Assets.BEScripts.Infrastructures.Models.PlayFab;
using Cysharp.Threading.Tasks;

namespace Assets.BEScripts.Infrastructures.Configs
{
    public class LoginConfig
    {
        public LoginConfig()
        {
            PlayFabModel.InitializeLogin();
        }

        public async UniTask LoginPlayFab()
        {
            await PlayFabModel.login.LoginPlayFab();
        }

        public async UniTask<string> GetPlayFabId()
        {
            string playFabId = PlayFabModel.GetPlayFabId();
            if (playFabId == null)
            {
                await LoginPlayFab();
                playFabId = PlayFabModel.GetPlayFabId();
            }
            return playFabId;
        }
    }
}