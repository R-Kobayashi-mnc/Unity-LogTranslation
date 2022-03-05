using UnityEditor;
using UnityEngine;

public class SelectLanguage : ScriptableSingleton<SelectLanguage>
{
    public enum LANGUAGE
    {
        Japanese = 0,
        Czech = 1,
        Danish = 2,
        German = 3,
        Greek = 4,
        English_British = 5,
        English_American = 6,
        Spanish = 7,
        Estonian = 8,
        Finnish = 9,
        French = 10,
        Hungarian = 11,
        Italian = 12,
        Bulgarian = 13,
        Lithuanian = 14,
        Latvian = 15,
        Dutch = 16,
        Polish = 17,
        Portuguese_Brazilian = 18,
        Portuguese_European = 19,
        Romanian = 20,
        Russian = 21,
        Slovak = 22,
        Slovenian = 23,
        Swedish = 24,
        Chinese = 25
    }


    public string LanguageString(LANGUAGE la)
    {
        var selectLanguage = "";

        switch (la)
        {
            case LANGUAGE.Japanese:
                selectLanguage = "JA";
                break;
            case LANGUAGE.Czech:
                selectLanguage = "CS";
                break;
            case LANGUAGE.Danish:
                selectLanguage = "DA";
                break;
            case LANGUAGE.German:
                selectLanguage = "DE";
                break;
            case LANGUAGE.Greek:
                selectLanguage = "EL";
                break;
            case LANGUAGE.English_British:
                selectLanguage = "EN-GB";
                break;
            case LANGUAGE.English_American:
                selectLanguage = "EN-US";
                break;
            case LANGUAGE.Spanish:
                selectLanguage = "ES";
                break;
            case LANGUAGE.Estonian:
                selectLanguage = "ET";
                break;
            case LANGUAGE.Finnish:
                selectLanguage = "FI";
                break;
            case LANGUAGE.French:
                selectLanguage = "FR";
                break;
            case LANGUAGE.Hungarian:
                selectLanguage = "HU";
                break;
            case LANGUAGE.Italian:
                selectLanguage = "IT";
                break;
            case LANGUAGE.Bulgarian:
                selectLanguage = "BG";
                break;
            case LANGUAGE.Lithuanian:
                selectLanguage = "LT";
                break;
            case LANGUAGE.Latvian:
                selectLanguage = "LV";
                break;
            case LANGUAGE.Dutch:
                selectLanguage = "NL";
                break;
            case LANGUAGE.Polish:
                selectLanguage = "PL";
                break;
            case LANGUAGE.Portuguese_Brazilian:
                selectLanguage = "PT-BR";
                break;
            case LANGUAGE.Portuguese_European:
                selectLanguage = "PT-PT";
                break;
            case LANGUAGE.Romanian:
                selectLanguage = "RO";
                break;
            case LANGUAGE.Russian:
                selectLanguage = "RU";
                break;
            case LANGUAGE.Slovak:
                selectLanguage = "SK";
                break;
            case LANGUAGE.Slovenian:
                selectLanguage = "SL";
                break;
            case LANGUAGE.Swedish:
                selectLanguage = "SV";
                break;
            case LANGUAGE.Chinese:
                selectLanguage = "ZH";
                break;
            default:
                Debug.LogError("Unrecognized Option");
                break;
        }
        return selectLanguage;
    }
}
