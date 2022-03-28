using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class AdsManager : MonoBehaviour
{

    private BannerView bannerView;
    private InterstitialAd interstitial;

    void Start()
    {
        MobileAds.Initialize(initStatus => { });
        RequestBanner();
        RequestFullscreenAd();
    }

    private void RequestBanner()
    {
        string bannerId = "ca-app-pub-3940256099942544/6300978111";
        bannerView = new BannerView(bannerId, AdSize.Banner, AdPosition.Top);

        bannerView.OnAdLoaded += HandleOnAdLoaded;
        bannerView.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        bannerView.OnAdOpening += HandleOnAdOpened;
        bannerView.OnAdClosed += HandleOnAdClosed;

        AdRequest request = new AdRequest.Builder().Build();

        bannerView.LoadAd(request);
    }

    private void RequestFullscreenAd()
    {
        string bannerId = "ca-app-pub-3940256099942544/1033173712";
        interstitial = new InterstitialAd(bannerId);

        AdRequest request = new AdRequest.Builder().Build();
        interstitial.LoadAd(request);
    }

    public void ShowAd()
    {
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
        }
    }

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        
    }
}
