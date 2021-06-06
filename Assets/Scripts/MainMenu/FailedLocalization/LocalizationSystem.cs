using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationSystem : MonoBehaviour
{
    public enum Language { English, Chinese}

    public static Language language = Language.English;

    private static Dictionary<string, string> localizedEN;
    private static Dictionary<string, string> localizedCH;

    public static bool isInit;

    public static void Init()
    {
        CSVLoader csvLoader = new CSVLoader();
        csvLoader.LoadCSV();

        localizedEN = csvLoader.GetDictionaryValues("en");
        localizedCH = csvLoader.GetDictionaryValues("ch");

        isInit = true;
    }

    public static string GetLocalizedValue(string key)
    {
        if (!isInit) { Init(); }

        string value = key;

        switch (language)
        {
            case Language.English:
                localizedEN.TryGetValue(key, out value);
                break;
            case Language.Chinese:
                localizedCH.TryGetValue(key, out value);
                break;
        }

        return value;
    }

}
