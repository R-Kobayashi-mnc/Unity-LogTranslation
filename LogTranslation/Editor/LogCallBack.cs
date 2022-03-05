using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class LogCallBack : ScriptableSingleton<LogCallBack>
{
    static LogCallBack() {
        Application.logMessageReceivedThreaded += LogCallback;
    }

    /// <summary>
    /// ログを取得するコールバック
    /// </summary>
    /// <param name="condition">メッセージ</param>
    /// <param name="stackTrace">コールスタック</param>
    /// <param name="type">ログの種類</param>
    private static async void LogCallback(string condition, string stackTrace, LogType type)
    {
        // 通常ログは翻訳対象外とし、何も行わずに返す
        if (type == LogType.Log)
            return;

        //ログの重複がなければdeeplAPIで翻訳し、翻訳元文と翻訳結果文を格納する
        if (!LogTranslation.LogOrverlappingCheck(condition))
        {
            //deeplAPI翻訳呼び出し
            await LogTranslation.DeeplTranslate(condition);  //呼び出し先のメソッドが終了するまで待機

            //既に翻訳元が格納されている場合は追加しない
            if (!LogTranslation.getLogStrage().ContainsKey(condition))
            {
                //翻訳元文と翻訳結果文の格納
                LogTranslation.setLogStrage(condition, LogTranslation.getTranslationResult());//LogTranslation.logStrage.Add(condition,LogTranslation.getTranslationResult());
            }
        }
        //翻訳結果の表示
        Debug.Log(LogTranslation.getTranslationResult());
    }
}
