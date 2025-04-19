using System.Collections.Generic;
using Assets.BEScripts.Domains.Abstracts;
using Cysharp.Threading.Tasks;
using PlayFab;
using PlayFab.ClientModels;

namespace Assets.BEScripts.Infrastructures.Models.PlayFab
{
    public class TitleData : AbstractPlayFab
    {
        private Dictionary<string, string> _titleDataRecord;
        public Dictionary<string, string> titleDataRecord
        {
            get { return _titleDataRecord; }
        }
        /// <summary>
        /// タイトルデータの情報を全て取得する
        /// </summary>
        /// <returns></returns>
        public async UniTask BringAllTitleDataRequest()
        {
            await Function(
                () =>
                {
                    var request = new GetTitleDataRequest();
                    PlayFabClientAPI.GetTitleData(
                        request,
                        BringAllTitleDataSuccess,
                        BringAllTitleDataFailed
                    );
                },
                "GetAllTitleDataRequest Success",
                "GetAllTitleDataRequest Failed"
            );
        }

        protected void BringAllTitleDataSuccess(GetTitleDataResult _result)
        {
            _titleDataRecord = _result.Data;
            SuccessFunction();
        }

        protected void BringAllTitleDataFailed(PlayFabError _error)
        {
            FailedFunction(_error);
        }

        /// <summary>
        /// 該当のユーザーデータを返す
        /// </summary>
        ///　<param name="_key"></param>
        /// <returns></returns>
        public async UniTask<string> GetTitleData(string _key)
        {
            await UniTask.Delay(0);
            if (_titleDataRecord.ContainsKey(_key))
                return _titleDataRecord[_key];
            return null;
        }
    }
}