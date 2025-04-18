using Assets.BEScripts.Infrastructures.Configs;
using Cysharp.Threading.Tasks;

namespace Assets.BEScripts.Infrastructures.Middlewares.TitleData
{
    public class BringTitleDataController
    {
        private readonly TitleDataConfig _titleDataConfig;

        public BringTitleDataController()
        {
            _titleDataConfig = new TitleDataConfig();
        }

        public async UniTask Execute()
        {
            await _titleDataConfig.BringAllTitleData();
        }
    }
}