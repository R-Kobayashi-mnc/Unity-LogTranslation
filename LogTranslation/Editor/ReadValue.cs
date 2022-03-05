using System.IO;
using System.Text;
using UnityEditor;

public class ReadValue : ScriptableSingleton<ReadValue>
{
    // FileReadTest.txtファイルを読み込む
    static FileInfo fi = new FileInfo("LogTranslationSettingSave/SettingValue.dat");

    public static string ReadAuthKeyValue()
    {
        var result = "";
        using StreamReader sr = new StreamReader(fi.OpenRead(), Encoding.UTF8);
        string tmpLine;

        //「authKey:」行の「：」以降を代入する
        while (sr.Peek() > -1)
        {
            tmpLine = sr.ReadLine();

            if (tmpLine.Contains("authKey:"))
            {
                string[] tmpKey = tmpLine.Split();  //空白で区切る　
                result = tmpKey[3].Trim();  //空白削除 ※!注意!...先頭にも半角空白が２行含まれるため[3]に格納されている
            }
        }
        return result;
    }


    public static int ReadSelectLanguageValue()
    {
        var result = 0;
        using StreamReader sr = new StreamReader(fi.OpenRead(), Encoding.UTF8);
        string tmpLine;

        //「selectLanguage：」行の「：」以降を代入
        while (sr.Peek() > -1)
        {
            tmpLine = sr.ReadLine();

            if (tmpLine.Contains("selectLanguage:"))
            {
                string[] tmpLanguage = tmpLine.Split();
                result = int.Parse(tmpLanguage[3].Trim());
            }
        }
        return result;
    }
}
