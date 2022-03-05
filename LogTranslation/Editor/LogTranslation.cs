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
    private static string translationResult = ""; //翻訳結果の格納
    private static Dictionary<string, string> logStrage = new Dictionary<string, string>(); //翻訳元の文と翻訳結果の文の一時保存

    public static string getTranslationResult() => translationResult; 
    public static void setLogStrage(string key,string value) => logStrage.Add(key,value);
    public static Dictionary<string,string> getLogStrage() => logStrage;

    /// <summary>
    /// ログの既に翻訳したことのあるろぐであるのかの重複チェックし、重複していれば翻訳結果を代入する
    /// </summary>
    public static bool LogOrverlappingCheck(string condition) {
        var isLogOverlap = false; //重複フラグ
        
        foreach (string key in logStrage.Keys)
        {
            if (key.Equals(condition))
            {
                //重複した翻訳結果を代入
                translationResult = logStrage[key];  
                isLogOverlap = true;
                return isLogOverlap; //重複あり(true)
            }
        }
        return isLogOverlap;  //重複無し(false)
    }

    /// <summary>
    /// 翻訳
    /// </summary>
    public static async Task DeeplTranslate(string logMessage)
    {
        using (var httpClient = new HttpClient())
        {
            using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://api-free.deepl.com/v2/translate"))
            {
                var contentList = new List<string>();
                //設定ファイルの読み込み(認証キー、翻訳先言語)
                var authKeytxt = ReadValue.ReadAuthKeyValue(); //認証キー読み込み
                var selectLanguagetxt = ReadValue.ReadSelectLanguageValue(); //翻訳先言語読み込み
                //selectLanguagetxtの数値から翻訳言語の文字を求める
                var selectLanguageString = SelectLanguage.instance.LanguageString((SelectLanguage.LANGUAGE)Enum.ToObject(typeof(SelectLanguage.LANGUAGE), selectLanguagetxt));
                contentList.Add("auth_key=" + authKeytxt); //認証キー
                contentList.Add("text=" + logMessage); //翻訳元の文
                contentList.Add("target_lang=" + selectLanguageString); //翻訳先言語

                request.Content = new StringContent(string.Join("&", contentList));
                request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");

                //結果が帰ってくるまで待機
                var response = await httpClient.SendAsync(request);

                var resBodyStr = response.Content.ReadAsStringAsync().Result;
                JObject deserial = (JObject)JsonConvert.DeserializeObject(resBodyStr);

                //翻訳結果の代入
                translationResult = deserial["translations"][0]["text"].ToString(); 
            }
        }
    }
}

