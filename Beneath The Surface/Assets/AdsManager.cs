using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;


public class AdsManager : MonoBehaviour, IUnityAdsListener
{

#if UNITY_IOS
    private string gameId = "4426582";
#elif UNITY_ANDROID
    private string gameId = "4426583";
#endif
    void Start()
    {
        Advertisement.Initialize(gameId);
        Advertisement.AddListener(this);
    }
    public void PlayAd ()
    {
        if (Advertisement.IsReady("Interstitial_Android"))
        {
            Advertisement.Show("Interstitial_Android");
        }
        Debug.Log("AD"); 

    }
    public void PlayRewardedAD()
    {
        if (Advertisement.IsReady("Rewarded_Android"))
        {
            Advertisement.Show("Rewarded_Android");

        }
        else
        {
            Debug.Log("Rewarded Ad is not read !");
        }
    }
    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("ADS ARE READY");
    }
    public void OnUnityAdsDidError(string message)
    {
        Debug.Log("ERROR:" + message);
    }
    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("VIDEO STARTED");
    }
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (placementId == "Rewarded_Android" && showResult == ShowResult.Finished)
        {
            Debug.Log("Player should be rewarded");
        }
    }
    
}
