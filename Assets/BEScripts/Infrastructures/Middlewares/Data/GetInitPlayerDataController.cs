using Assets.BEScripts.Infrastructures.Configs;

namespace Assets.BEScripts.Infrastructures.Middlewares.Data
{
    public class GetInitPlayerDataController
    {
        private readonly DataConfig _dataConfig;

        public GetInitPlayerDataController()
        {
            _dataConfig = new DataConfig();
        }

        public string Execute()
        {
            // ResourcesからPlayer.jsonを読み込む
            string json = _dataConfig.GetInitPlayerData();
            // 取得したJSONを返す
            return json;
        }
    }
}