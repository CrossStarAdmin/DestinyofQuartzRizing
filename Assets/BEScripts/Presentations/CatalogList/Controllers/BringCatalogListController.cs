using Assets.BEScripts.Infrastructures.Configs;
using Cysharp.Threading.Tasks;

namespace Assets.BEScripts.Presentations.CatalogList
{
    public class BringCatalogListController
    {
        private readonly CatalogListConfig _catalogListConfig;
        public BringCatalogListController()
        {
            _catalogListConfig = new CatalogListConfig();
        }

        public async UniTask BringAllCatalogItems()
        {
            await _catalogListConfig.BringAllCatalogItems();
        }
    }
}