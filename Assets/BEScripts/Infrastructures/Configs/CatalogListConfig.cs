using Assets.BEScripts.Infrastructures.Models.PlayFab;
using Cysharp.Threading.Tasks;

namespace Assets.BEScripts.Infrastructures.Configs
{
    public class CatalogListConfig
    {
        public CatalogListConfig()
        {
            PlayFabModel.InitializeCatalogList();
        }

        public async UniTask BringAllCatalogItems()
        {
            await PlayFabModel.catalogList.GetCatalogItemsRequest();
        }
    }
}