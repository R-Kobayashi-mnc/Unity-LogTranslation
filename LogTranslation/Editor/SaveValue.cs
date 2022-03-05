using UnityEditor;
using UnityEngine;

// アトリビュートを付ける
[FilePath("LogTranslationSettingSave/SettingValue.dat", FilePathAttribute.Location.ProjectFolder)]
public class SaveValue : ScriptableSingleton<SaveValue>
{
    [SerializeField] private string authKey;
    [SerializeField] private SelectLanguage.LANGUAGE selectLanguage;


    public void SaveAuthKeyAndSelectLanguage(string authKey, SelectLanguage.LANGUAGE selectLanguage)
    {
        this.authKey = authKey;
        this.selectLanguage = selectLanguage;
        //保存する
        Save(true);
    }
}