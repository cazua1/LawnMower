using UnityEngine;
using Agava.YandexGames;
using System.Collections;

public class YandexSDK : MonoBehaviour
{
    private void Awake()
    {
        YandexGamesSdk.CallbackLogging = true;
    }

    private IEnumerator Start()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        yield break;
#endif

        yield return YandexGamesSdk.Initialize();
        ShowBannerAD();
    }

    public void ShowBannerAD()
    {
        InterstitialAd.Show();
    }
    
    public void ShowVidioAd()
    {
        VideoAd.Show();
    }
}
