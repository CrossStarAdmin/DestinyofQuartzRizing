using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using GoogleMobileAds;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;
using Assets.FEScripts;

public class GoogleAdmobManager : MonoBehaviour
{
    public static GoogleAdmobManager instance = null;

#if UNITY_ANDROID
    // 本番
    private string bannerAdUnitId = Setting.ANDROID_BANNER_AD_UNIT_ID;
    private string interstitialAdUnitId = Setting.ANDROID_INTERSTITIAL_AD_UNIT_ID;
    private string rewardAdUnitId = Setting.ANDROID_REWARD_AD_UNIT_ID;
    // テスト
    // private string bannerAdUnitId = "ca-app-pub-3940256099942544/2934735716";
    // private string interstitialAdUnitId = "ca-app-pub-3940256099942544/5135589807";
    // private string rewardAdUnitId = "ca-app-pub-3940256099942544/5224354917";
#elif UNITY_IPHONE
    // 本番
    private string bannerAdUnitId = Setting.IOS_BANNER_AD_UNIT_ID;
    private string interstitialAdUnitId = Setting.IOS_INTERSTITIAL_AD_UNIT_ID;
    private string rewardAdUnitId = Setting.IOS_REWARD_AD_UNIT_ID;
    // テスト
    // private string bannerAdUnitId = "ca-app-pub-3940256099942544/2934735716";
    // private string interstitialAdUnitId = "ca-app-pub-3940256099942544/5135589807";
    // private string rewardAdUnitId = "ca-app-pub-3940256099942544/5224354917";
#else
    private string bannerAdUnitId = "unexpected_platform";
    private string interstitialAdUnitId = "unexpected_platform";
    private string rewardAdUnitId = "unexpected_platform";
#endif

    private string moveScene;

    private BannerView _bannerView;
    private InterstitialAd _interstitialAd;
    private RewardedAd _rewardedAd;
    public UnityEvent onClosedInterstitialAdEvent = new UnityEvent();
    public UnityEvent onClosedRewardAdEvent = new UnityEvent();

    public void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void Start()
    {
        // MobileAdsSDKの初期化.
        MobileAds.Initialize((initStatus) =>
        {
            // バナー広告の初期化
            RequestBanner();
            // InterStitial広告の初期化
            RequestInterstitial();
            // Reward広告の初期化
            RequestReward();
        });
    }

    private void RequestBanner()
    {
        // すでに存在するbannerViewを破棄
        if (_bannerView != null)
        {
            _bannerView.Destroy();
            _bannerView = null;
        }
        // 320x50のバナー広告を作成する
        _bannerView = new BannerView(bannerAdUnitId, AdSize.Banner, AdPosition.Bottom);
        // 空のリクエストを作成する
        AdRequest request = new AdRequest();
        // リクエストを使用して広告を読み込む
        _bannerView.LoadAd(request);
    }

    public void RequestInterstitial()
    {
        // リセット処理
        if (_interstitialAd != null)
        {
            _interstitialAd.Destroy();
            _interstitialAd = null;
        }
        // 空のリクエストを作成する
        AdRequest request = new AdRequest();
        // インタースティシャル広告を読み込む
        InterstitialAd.Load(interstitialAdUnitId, request,
        (InterstitialAd ad, LoadAdError loadAdError) =>
        {
            if (loadAdError != null)
            {
                Debug.Log("Failed to load interstitial ad with error: " + loadAdError?.ToString());
                return;
            }
            else if (ad == null)
            {
                Debug.Log("Failed to load interstitial ad with error: " + loadAdError?.ToString());
                return;
            }
            ad.OnAdFullScreenContentOpened += () =>
            {
                HandleOnOpened();
            };
            ad.OnAdFullScreenContentClosed += () =>
            {
                HandleOnAdClosed();
            };
            ad.OnAdFullScreenContentFailed += (AdError error) =>
            {
                HandleOnAdClosed();
            };
            _interstitialAd = ad;
        });
    }

    public void RequestReward()
    {
        if (_rewardedAd != null)
        {
            _rewardedAd.Destroy();
            _rewardedAd = null;
        }

        var adRequest = new AdRequest();
        RewardedAd.Load(rewardAdUnitId, adRequest, (RewardedAd ad, LoadAdError error) =>
        {
            if (error != null || ad == null)
            {
                Debug.LogError("Rewarded ad failed to load an ad " +
                               "with error : " + error);
                return;
            }

            Debug.Log("Rewarded ad loaded with response : "
                      + ad.GetResponseInfo());

            _rewardedAd = ad;
        });
    }

    private void HandleOnOpened()
    {
    }

    private void HandleOnAdClosed()
    {
        this._interstitialAd.Destroy();
        this.RequestInterstitial();
        // 閉じた際の処理を実行
        onClosedInterstitialAdEvent.Invoke();
    }

    public void ShowInterstitialAd(string _moveScene)
    {
        moveScene = _moveScene;
        // AudioController.Instance.StopBGM();
        if (_interstitialAd != null && _interstitialAd.CanShowAd())
        {
            _interstitialAd.Show();
        }
        else
        {
            Debug.Log("Interstitial Ad not load");
            SceneManager.LoadScene(moveScene);
        }
    }

    public void ShowRewardAd()
    {
        if (_rewardedAd != null && _rewardedAd.CanShowAd())
        {
            _rewardedAd.Show((Reward reward) =>
            {
                // リワードの棄却
                _rewardedAd.Destroy();
                _rewardedAd = null;
                // リワードの取得
                RequestReward();
                // actionの実行
                onClosedRewardAdEvent.Invoke();
            });
        }
    }
}