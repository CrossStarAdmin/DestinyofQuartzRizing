using System.Collections.Generic;
using Assets.BEScripts.Domains.Abstracts;
using Cysharp.Threading.Tasks;
using PlayFab;
using PlayFab.ClientModels;

namespace Assets.BEScripts.Infrastructures.Models.PlayFab
{
    public class UserData : AbstractPlayFab
    {
        private Dictionary<string, UserDataRecord> _userDataRecord;
        public Dictionary<string, UserDataRecord> userDataRecord
        {
            get { return _userDataRecord; }
        }

        /// <summary>
        /// ユーザーデータの情報を全て取得する
        /// </summary>
        /// <returns></returns>
        public async UniTask BringAllUSerDataRequest()
        {
            await Function(
                () =>
                {
                    var request = new GetUserDataRequest()
                    {
                        PlayFabId = PlayFabAuthService.PlayFabId
                    };
                    PlayFabClientAPI.GetUserData(
                        request,
                        BringAllUserDataSuccess,
                        BringAllUserDataFailed
                    );
                },
                "GetAllUSerDataRequest Success",
                "GetAllUSerDataRequest Failed"
            );
        }

        protected void BringAllUserDataSuccess(GetUserDataResult _result)
        {
            _userDataRecord = _result.Data;
            SuccessFunction();
        }

        protected void BringAllUserDataFailed(PlayFabError _error)
        {
            FailedFunction(_error);
        }

        /// <summary>
        /// 該当のユーザーデータを返す
        /// </summary>
        ///　<param name="_key"></param>
        /// <returns></returns>
        public async UniTask<string> GetUserData(string _key)
        {
            await UniTask.Delay(0);
            if (_userDataRecord.ContainsKey(_key))
                return _userDataRecord[_key].Value;
            return null;
        }

        /// <summary>
        /// ユーザー情報を更新する
        /// </summary>
        /// <param name="_dictionary"></param>
        /// <returns></returns>
        public async UniTask UpdateUserDataRequest(Dictionary<string, string> _dictionary)
        {
            await Function(
                () =>
                {
                    var request = new UpdateUserDataRequest
                    {
                        Data = _dictionary
                    };
                    PlayFabClientAPI.UpdateUserData(
                        request,
                        UpdateUserDataSuccess,
                        UpdateUserDataFailed
                    );
                },
                "UpdateUserDataRequest Success",
                "UpdateUserDataRequest Failed"
            );
        }

        protected void UpdateUserDataSuccess(UpdateUserDataResult _result)
        {
            BringAllUSerDataRequest().Forget();
        }

        protected void UpdateUserDataFailed(PlayFabError _error)
        {
            FailedFunction(_error);
        }
    }
}