using System;
using System.Collections.Generic;
using Assets.BEScripts.Domains.Entities;
using Assets.BEScripts.Domains.Types.ModelParams;
using Assets.BEScripts.Infrastructures.Models.PlayFab;
using Cysharp.Threading.Tasks;
using PlayFab.ClientModels;

namespace Assets.BEScripts.Infrastructures.Repositories
{
    public class SubscriptionRepository
    {
        private SubscriptionModelType _model;

        public async UniTask Initialize()
        {
            // ストアの取得
            await PlayFabModel.catalogList.GetStoreItemsRequest(Setting.SUBSCRIPTION_STORE_KEY);
            // StoreとCatalogのデータを取得
            List<CatalogItem> catalogItems = PlayFabModel.catalogList.catalogItems.FindAll(catalogItem => catalogItem.ItemId == Setting.SUBSCRIPTION_CATALOG_KEY);
            List<StoreItem> storeItems = PlayFabModel.catalogList.storeItems;
            // Modelを作成する
            _model = new SubscriptionModelType
            {
                list = new SubscriptionListType[catalogItems.Count]
            };
            for (int i = 0; i < storeItems.Count; i++)
            {
                StoreItem storeItem = storeItems[i];
                CatalogItem catalogItem = catalogItems.Find(catalogItem => catalogItem.ItemId == storeItem.ItemId);
                SubscriptionListType subscriptionListType = new SubscriptionListType
                {
                    uid = "Subscription_" + i,
                    itemId = catalogItem.ItemId,
                    name = catalogItem.DisplayName,
                    description = catalogItem.Description,
                    price = catalogItem.VirtualCurrencyPrices["MO"],
                    campaignPrice = storeItem.VirtualCurrencyPrices["MO"]
                };
                _model.list[i] = subscriptionListType;
            }
        }

        public async UniTask<SubscriptionEntity[]> FindAll()
        {
            await Initialize();
            return Array.ConvertAll(_model.list, SubscriptionEntity.CreateFromModel);
        }
    }
}