using System;
using System.Collections.Generic;
using Assets.BEScripts.Domains.Entities;
using Assets.BEScripts.Domains.Types.ModelParams;
using Assets.BEScripts.Infrastructures.Models.PlayFab;
using Cysharp.Threading.Tasks;
using PlayFab.ClientModels;

namespace Assets.BEScripts.Infrastructures.Repositories
{
    public class NoConsumableRepository
    {
        private NoConsumableModelType _model;

        public async UniTask Initialize()
        {
            // ストアの取得
            await PlayFabModel.catalogList.GetStoreItemsRequest(Setting.NO_CONSUMABLE_STORE_KEY);
            // StoreとCatalogのデータを取得
            List<CatalogItem> catalogItems = PlayFabModel.catalogList.catalogItems.FindAll(catalogItem => catalogItem.ItemId == Setting.NO_CONSUMABLE_CATALOG_KEY);
            List<StoreItem> storeItems = PlayFabModel.catalogList.storeItems;
            // Modelを作成する
            _model = new NoConsumableModelType
            {
                list = new NoConsumableListType[catalogItems.Count]
            };
            for (int i = 0; i < storeItems.Count; i++)
            {
                StoreItem storeItem = storeItems[i];
                CatalogItem catalogItem = catalogItems.Find(catalogItem => catalogItem.ItemId == storeItem.ItemId);
                NoConsumableListType noConsumableListType = new NoConsumableListType
                {
                    uid = "NoConsumable_" + i,
                    itemId = catalogItem.ItemId,
                    name = catalogItem.DisplayName,
                    description = catalogItem.Description,
                    jemCount = catalogItem.VirtualCurrencyPrices["JW"],
                    campaignJemCount = storeItem.VirtualCurrencyPrices["JW"]
                };
                _model.list[i] = noConsumableListType;
            }
        }

        public async UniTask<NoConsumableEntity[]> FindAll()
        {
            await Initialize();
            return Array.ConvertAll(_model.list, NoConsumableEntity.CreateFromModel);
        }
    }
}