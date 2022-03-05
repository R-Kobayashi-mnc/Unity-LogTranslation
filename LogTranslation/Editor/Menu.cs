using System;
using UnityEditor;
using UnityEngine;


public class Menu : EditorWindow
{
    static string authKeytxt = "";  //認証キー
    static int selectLanguagetxt = default; //選択した翻訳先言語

    //タブ階層
    [MenuItem("LogTranslation/Setting")]
    //初期化
    static void Init()
    {
        UnityEditor.EditorWindow window = GetWindow(typeof(Menu));
        window.Show();
        //設定保存ファイルの読み込み
        authKeytxt = ReadValue.ReadAuthKeyValue(); //認証キー読み込み
        selectLanguagetxt = ReadValue.ReadSelectLanguageValue(); //翻訳先言語読み込み
        //設定された値を初期値にする
        authKey = authKeytxt;
        la = (SelectLanguage.LANGUAGE)Enum.ToObject(typeof(SelectLanguage.LANGUAGE), selectLanguagetxt);
    }

    static string authKey;
    public static SelectLanguage.LANGUAGE la;

    void OnGUI()
    {
        GUILayout.Space(10);//スペース
        GUILayout.Label("DeepL API認証キー (Authentication key of DeepL API)");
        authKey = EditorGUILayout.TextField(authKey, GUILayout.Height(20));
        GUILayout.Space(10);
        GUILayout.Label("翻訳先言語 (Translate to language)");
        la = (SelectLanguage.LANGUAGE)EditorGUILayout.EnumPopup(la);
        GUILayout.Space(30);

        //決定ボタン
        if (GUILayout.Button("決定 (Select)",GUILayout.Height(30))) {
            //値保存メソッドの呼び出し
            SaveValue.instance.SaveAuthKeyAndSelectLanguage(authKey, la); 
        }
    }
}