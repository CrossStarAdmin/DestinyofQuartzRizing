using System;
using System.Collections.Generic;
using Assets.BEScripts.Domains.Entities;
using Assets.BEScripts.Domains.Types.ModelParams;
using Assets.BEScripts.Infrastructures.Models.PlayFab;
using Cysharp.Threading.Tasks;
using PlayFab.ClientModels;

namespace Assets.BEScripts.Infrastructures.Repositories
{
    public class ConsumableRepository
    {
        private ConsumableModelType _model;
        private const string CONSUMABLE_CATALOG_KEY = "Consumable";
        private const string CONSUMABLE_STORE_KEY = "Consumable";

        public async UniTask Initialize()
        {
            // ストアの取得
            await PlayFabModel.catalogList.GetStoreItemsRequest(CONSUMABLE_STORE_KEY);
            // StoreとCatalogのデータを取得
            List<CatalogItem> catalogItems = PlayFabModel.catalogList.catalogItems.FindAll(catalogItem => catalogItem.ItemId == CONSUMABLE_CATALOG_KEY);
            List<StoreItem> storeItems = PlayFabModel.catalogList.storeItems;
            // Modelを作成する
            _model = new ConsumableModelType
            {
                list = new ConsumableListType[catalogItems.Count]
            };
            for (int i = 0; i < storeItems.Count; i++)
            {
                StoreItem storeItem = storeItems[i];
                CatalogItem catalogItem = catalogItems.Find(catalogItem => catalogItem.ItemId == storeItem.ItemId);
                ConsumableListType consumableListType = new ConsumableListType
                {
                    uid = "Consumable_" + i,
                    itemId = catalogItem.ItemId,
                    name = catalogItem.DisplayName,
                    description = catalogItem.Description,
                    jemCount = catalogItem.VirtualCurrencyPrices["JW"],
                    campaignJemCount = storeItem.VirtualCurrencyPrices["JW"],
                    price = catalogItem.VirtualCurrencyPrices["MO"],
                    campaignPrice = storeItem.VirtualCurrencyPrices["MO"]
                };
                _model.list[i] = consumableListType;
            }
        }

        public async UniTask<ConsumableEntity[]> FindAll()
        {
            await Initialize();
            return Array.ConvertAll(_model.list, ConsumableEntity.CreateFromModel);
        }
    }
}