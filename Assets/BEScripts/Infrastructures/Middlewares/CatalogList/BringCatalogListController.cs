using Assets.BEScripts.Infrastructures.Configs;
using Cysharp.Threading.Tasks;

namespace Assets.BEScripts.Infrastructures.Middlewares.CatalogList
{
    public class BringCatalogListController
    {
        private readonly CatalogListConfig _catalogListConfig;
        public BringCatalogListController()
        {
            _catalogListConfig = new CatalogListConfig();
        }

        public async UniTask Execute()
        {
            await _catalogListConfig.BringAllCatalogItems();
        }
    }
}