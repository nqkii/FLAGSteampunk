using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
public class LocaleSelector : MonoBehaviour 
{
    private bool active = false;

    private void Start()
    {
        int saved = PlayerPrefs.GetInt("LocaleID", 0);
        ChangeLocale(saved);
    }

    public void ChangeLocale(int LocaleID)
    {
        if (active == true)
            return;
        PlayerPrefs.SetInt("LocaleID", LocaleID);
        StartCoroutine(SetLocale(LocaleID));
    }


    IEnumerator SetLocale(int _localeID)
    {
        active = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_localeID];
        active = false;
    }
}
