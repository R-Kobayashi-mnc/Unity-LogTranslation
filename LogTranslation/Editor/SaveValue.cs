using UnityEditor;
using UnityEngine;

// �A�g���r���[�g��t����
[FilePath("LogTranslationSettingSave/SettingValue.dat", FilePathAttribute.Location.ProjectFolder)]
public class SaveValue : ScriptableSingleton<SaveValue>
{
    [SerializeField] private string authKey;
    [SerializeField] private SelectLanguage.LANGUAGE selectLanguage;


    public void SaveAuthKeyAndSelectLanguage(string authKey, SelectLanguage.LANGUAGE selectLanguage)
    {
        this.authKey = authKey;
        this.selectLanguage = selectLanguage;
        //�ۑ�����
        Save(true);
    }
}