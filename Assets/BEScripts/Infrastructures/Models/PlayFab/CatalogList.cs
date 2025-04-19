using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using Assets.BEScripts.Domains.Abstracts;
using Assets.BEScripts;
using Cysharp.Threading.Tasks;
using System.Threading.Tasks;

namespace Assets.BackendScripts.Infrastructure.PlayFab.Contents
{
    public class CatalogList : AbstractPlayFab
    {
        // Catalog関係
        private List<CatalogItem> _catalogItems;
        public List<CatalogItem> catalogItems
        {
            get { return _catalogItems; }
        }
        // Store関係
        private string _storeId;
        private string _storeName;
        private string _storeDescription;
        private List<StoreItem> _storeItems;
        public string storeId
        {
            get { return _storeId; }
        }
        public string storeName
        {
            get { return _storeName; }
        }
        public string storeDescription
        {
            get { return _storeDescription; }
        }
        public List<StoreItem> storeItems
        {
            get { return _storeItems; }
        }

        // ----------------------------------------
        // カタログの取得
        // ----------------------------------------
        public async UniTask GetCatalogItemsRequest()
        {
            await Function(
                () =>
                {
                    var request = new GetCatalogItemsRequest()
                    {
                        CatalogVersion = Setting.CATALOG_VERSION_NAME
                    };
                    PlayFabClientAPI.GetCatalogItems(
                        request,
                        GetCatalogItemsSuccess,
                        GetCatalogItemsFailed
                    );
                },
                "GetCatalogItemsRequest Success",
                "GetCatalogItemsRequest Failed"
            );
        }
        public void GetCatalogItemsSuccess(GetCatalogItemsResult _result)
        {
            _catalogItems = _result.Catalog;
            SuccessFunction();
        }

        public void GetCatalogItemsFailed(PlayFabError _error)
        {
            FailedFunction(_error);
        }

        // ----------------------------------------
        // ストアの取得
        // ----------------------------------------
        public async Task GetStoreItemsRequest(string _storeId)
        {
            await Function(
                () =>
                {
                    var request = new GetStoreItemsRequest()
                    {
                        CatalogVersion = Setting.CATALOG_VERSION_NAME,
                        StoreId = _storeId
                    };
                    PlayFabClientAPI.GetStoreItems(
                        request,
                        GetStoreItemsSuccess,
                        GetStoreItemsFailed
                    );
                },
                "GetStoreItemsRequest Success",
                "GetStoreItemsRequest Failed"
            );
        }
        public void GetStoreItemsSuccess(GetStoreItemsResult _result)
        {
            _storeId = _result.StoreId;
            _storeName = _result.MarketingData.DisplayName;
            _storeDescription = _result.MarketingData.Description;
            _storeItems = _result.Store;
            SuccessFunction();
        }
        public void GetStoreItemsFailed(PlayFabError _error)
        {
            FailedFunction(_error);
        }

        // ----------------------------------------
        // アイテムの購入
        // ----------------------------------------
        public async Task PurchaseItemRequest(string _itemId, string _storeId, int _price)
        {
            await Function(
                () =>
                {
                    var request = new PurchaseItemRequest()
                    {
                        CatalogVersion = Setting.CATALOG_VERSION_NAME,
                        ItemId = _itemId,
                        StoreId = _storeId,
                        VirtualCurrency = Setting.VIRTUAL_CURRENCY_COIN_CODE,
                        Price = _price
                    };
                    PlayFabClientAPI.PurchaseItem(
                        request,
                        PurchaseItemSuccess,
                        PurchaseItemFailed
                    );
                },
                "PurchaseItemRequest Success",
                "PurchaseItemRequest Failed"
            );
        }
        public void PurchaseItemSuccess(PurchaseItemResult _result)
        {
            SuccessFunction();
        }
        public void PurchaseItemFailed(PlayFabError _error)
        {
            FailedFunction(_error);
        }
    }
}