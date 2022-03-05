using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;



public class LogTranslation : ScriptableSingleton<LogTranslation>
{
    private static string translationResult = ""; //�|�󌋉ʂ̊i�[
    private static Dictionary<string, string> logStrage = new Dictionary<string, string>(); //�|�󌳂̕��Ɩ|�󌋉ʂ̕��̈ꎞ�ۑ�

    public static string getTranslationResult() => translationResult; 
    public static void setLogStrage(string key,string value) => logStrage.Add(key,value);
    public static Dictionary<string,string> getLogStrage() => logStrage;

    /// <summary>
    /// ���O�̊��ɖ|�󂵂����Ƃ̂���낮�ł���̂��̏d���`�F�b�N���A�d�����Ă���Ζ|�󌋉ʂ�������
    /// </summary>
    public static bool LogOrverlappingCheck(string condition) {
        var isLogOverlap = false; //�d���t���O
        
        foreach (string key in logStrage.Keys)
        {
            if (key.Equals(condition))
            {
                //�d�������|�󌋉ʂ���
                translationResult = logStrage[key];  
                isLogOverlap = true;
                return isLogOverlap; //�d������(true)
            }
        }
        return isLogOverlap;  //�d������(false)
    }

    /// <summary>
    /// �|��
    /// </summary>
    public static async Task DeeplTranslate(string logMessage)
    {
        using (var httpClient = new HttpClient())
        {
            using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://api-free.deepl.com/v2/translate"))
            {
                var contentList = new List<string>();
                //�ݒ�t�@�C���̓ǂݍ���(�F�؃L�[�A�|��挾��)
                var authKeytxt = ReadValue.ReadAuthKeyValue(); //�F�؃L�[�ǂݍ���
                var selectLanguagetxt = ReadValue.ReadSelectLanguageValue(); //�|��挾��ǂݍ���
                //selectLanguagetxt�̐��l����|�󌾌�̕��������߂�
                var selectLanguageString = SelectLanguage.instance.LanguageString((SelectLanguage.LANGUAGE)Enum.ToObject(typeof(SelectLanguage.LANGUAGE), selectLanguagetxt));
                contentList.Add("auth_key=" + authKeytxt); //�F�؃L�[
                contentList.Add("text=" + logMessage); //�|�󌳂̕�
                contentList.Add("target_lang=" + selectLanguageString); //�|��挾��

                request.Content = new StringContent(string.Join("&", contentList));
                request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");

                //���ʂ��A���Ă���܂őҋ@
                var response = await httpClient.SendAsync(request);

                var resBodyStr = response.Content.ReadAsStringAsync().Result;
                JObject deserial = (JObject)JsonConvert.DeserializeObject(resBodyStr);

                //�|�󌋉ʂ̑��
                translationResult = deserial["translations"][0]["text"].ToString(); 
            }
        }
    }
}

