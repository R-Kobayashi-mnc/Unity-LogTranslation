using System.IO;
using System.Text;
using UnityEditor;

public class ReadValue : ScriptableSingleton<ReadValue>
{
    // FileReadTest.txt�t�@�C����ǂݍ���
    static FileInfo fi = new FileInfo("LogTranslationSettingSave/SettingValue.dat");

    public static string ReadAuthKeyValue()
    {
        var result = "";
        using StreamReader sr = new StreamReader(fi.OpenRead(), Encoding.UTF8);
        string tmpLine;

        //�uauthKey:�v�s�́u�F�v�ȍ~��������
        while (sr.Peek() > -1)
        {
            tmpLine = sr.ReadLine();

            if (tmpLine.Contains("authKey:"))
            {
                string[] tmpKey = tmpLine.Split();  //�󔒂ŋ�؂�@
                result = tmpKey[3].Trim();  //�󔒍폜 ��!����!...�擪�ɂ����p�󔒂��Q�s�܂܂�邽��[3]�Ɋi�[����Ă���
            }
        }
        return result;
    }


    public static int ReadSelectLanguageValue()
    {
        var result = 0;
        using StreamReader sr = new StreamReader(fi.OpenRead(), Encoding.UTF8);
        string tmpLine;

        //�uselectLanguage�F�v�s�́u�F�v�ȍ~����
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
