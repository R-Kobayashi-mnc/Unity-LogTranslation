using System;
using UnityEditor;
using UnityEngine;


public class Menu : EditorWindow
{
    static string authKeytxt = "";  //�F�؃L�[
    static int selectLanguagetxt = default; //�I�������|��挾��

    //�^�u�K�w
    [MenuItem("LogTranslation/Setting")]
    //������
    static void Init()
    {
        UnityEditor.EditorWindow window = GetWindow(typeof(Menu));
        window.Show();
        //�ݒ�ۑ��t�@�C���̓ǂݍ���
        authKeytxt = ReadValue.ReadAuthKeyValue(); //�F�؃L�[�ǂݍ���
        selectLanguagetxt = ReadValue.ReadSelectLanguageValue(); //�|��挾��ǂݍ���
        //�ݒ肳�ꂽ�l�������l�ɂ���
        authKey = authKeytxt;
        la = (SelectLanguage.LANGUAGE)Enum.ToObject(typeof(SelectLanguage.LANGUAGE), selectLanguagetxt);
    }

    static string authKey;
    public static SelectLanguage.LANGUAGE la;

    void OnGUI()
    {
        GUILayout.Space(10);//�X�y�[�X
        GUILayout.Label("DeepL API�F�؃L�[ (Authentication key of DeepL API)");
        authKey = EditorGUILayout.TextField(authKey, GUILayout.Height(20));
        GUILayout.Space(10);
        GUILayout.Label("�|��挾�� (Translate to language)");
        la = (SelectLanguage.LANGUAGE)EditorGUILayout.EnumPopup(la);
        GUILayout.Space(30);

        //����{�^��
        if (GUILayout.Button("���� (Select)",GUILayout.Height(30))) {
            //�l�ۑ����\�b�h�̌Ăяo��
            SaveValue.instance.SaveAuthKeyAndSelectLanguage(authKey, la); 
        }
    }
}