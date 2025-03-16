using System.Collections;
using System.Collections.Generic;
using Assets.BEScripts.Domains.Abstracts;
using PlayFab.ClientModels;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace Assets.BEScripts.Infrastructures.Models.PlayFab
{
    public class Login : AbstractPlayFab
    {
        public Login()
        {
            PlayFabAuthService.OnLoginSuccess += LoginSuccessFunction;
            PlayFabAuthService.OnPlayFabError += FailedFunction;
        }

        public async UniTask LoginPlayFab()
        {
            PlayFabAuthService.Instance.Authenticate(Authtypes.Silent);
            while (_isProcess)
            {
                await UniTask.Delay(500);
            }
            if (!_isSuccess)
            {
                throw new System.Exception("LoginPlayFab Failed");
            }
        }

        protected void LoginSuccessFunction(LoginResult _result)
        {
            SuccessFunction();
        }
    }
}