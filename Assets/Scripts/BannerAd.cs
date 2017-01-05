using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class BannerAd : MonoBehaviour {
    private void Start() {
#if UNITY_EDITOR
        string adUnitId = "ca-app-pub-6114059389710934/9474406605";
#elif UNITY_ANDROID
        string adUnitId = "ca-app-pub-6114059389710934/9474406605";
#elif UNITY_IPHONE
        string adUnitId = "INSERT_IOS_BANNER_AD_UNIT_ID_HERE";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Create a 320x50 banner at the top of the screen.
        BannerView bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().AddTestDevice(AdRequest.TestDeviceSimulator).Build();
        // Load the banner with the request.
        bannerView.LoadAd(request);
    }
}
