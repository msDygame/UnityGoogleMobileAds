using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;
public class NewBehaviourScript : MonoBehaviour 
{
    protected BannerView bannerView;
    protected InterstitialAd interstitial;
    protected string sMessage = "" ;
    // Use this for initialization
	void Start () 
    {        
        
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnGUI()
    {
        if (GUI.Button(new Rect(10,10, 100, 30), "Show AdView")) { RequestBanner(); }
        if (GUI.Button(new Rect(10,100, 100, 30), "Load Interstidial")) { RequestInterstitial();  }
        if (GUI.Button(new Rect(10,200, 100, 30), "Show Interstidial")) { DisplayInterstidialAd(); }
        if (GUI.Button(new Rect(10,300,100, 30), "Quit")) { Application.Quit(); }
        if (GUI.Button(new Rect(10,400,300, 30), sMessage)) {  }
    }
    //
    void OnDestroy()
    {
        bannerView.Destroy();
        interstitial.Destroy();     
        sMessage = "OnDestroy";
    }
    //橫幅廣告請求
    public void RequestBanner()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/6300978111";
#elif UNITY_IPHONE
        string adUnitId = "INSERT_IOS_BANNER_AD_UNIT_ID_HERE";
#else
        string adUnitId = "unexpected_platform";
#endif
        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the banner with the request.
        bannerView.LoadAd(request);
        //
        sMessage = "OnRequestBanner";
    }
    //插頁廣告請求
    public void RequestInterstitial()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/6300978111";
#elif UNITY_IPHONE
        string adUnitId = "INSERT_IOS_INTERSTITIAL_AD_UNIT_ID_HERE";
#else
        string adUnitId = "unexpected_platform";
#endif
        // Initialize an InterstitialAd.
        interstitial = new InterstitialAd(adUnitId);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        interstitial.LoadAd(request);
        //
        sMessage = "RequestInterstitial";
    }
    //插頁廣告顯示
    public void DisplayInterstidialAd()
    {
        sMessage = "IsLoad Interstitial?";
        //20150424:always not load yet...why?
        if (interstitial.IsLoaded()) { interstitial.Show(); sMessage = "Show Interstitial"; }
    }
}
