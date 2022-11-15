using UnityEngine;
using Agava.YandexGames;
using Lean.Localization;
using System.Collections;

public class LanguageChanger : MonoBehaviour
{
    [SerializeField] private LeanLocalization _leanLocalization;

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

        switch (YandexGamesSdk.Environment.i18n.lang)
        {
            case "en":
                _leanLocalization.SetCurrentLanguage("English");
                break;
            case "tr":
                _leanLocalization.SetCurrentLanguage("Turkish");
                break;
            case "ru":
                _leanLocalization.SetCurrentLanguage("Russian");
                break;
            default:
                _leanLocalization.SetCurrentLanguage("English");
                break;
        }
#if VK_GAMES
        _leanLocalization.SetCurrentLanguage("Russian");
#endif
    }
}