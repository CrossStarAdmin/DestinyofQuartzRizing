using Assets.BEScripts.Infrastructures.Configs;
using Cysharp.Threading.Tasks;

namespace Assets.BEScripts.Infrastructures.Middlewares.TitleData
{
    public class GetTitleDataController
    {
        private readonly TitleDataConfig _titleDataConfig;
        public GetTitleDataController()
        {
            _titleDataConfig = new TitleDataConfig();
        }

        public async UniTask<string> Execute(
            string key
        )
        {
            return await _titleDataConfig.GetTitleData(key);
        }
    }
}