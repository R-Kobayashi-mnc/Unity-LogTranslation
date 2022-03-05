using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class LogCallBack : ScriptableSingleton<LogCallBack>
{
    static LogCallBack() {
        Application.logMessageReceivedThreaded += LogCallback;
    }

    /// <summary>
    /// ���O���擾����R�[���o�b�N
    /// </summary>
    /// <param name="condition">���b�Z�[�W</param>
    /// <param name="stackTrace">�R�[���X�^�b�N</param>
    /// <param name="type">���O�̎��</param>
    private static async void LogCallback(string condition, string stackTrace, LogType type)
    {
        // �ʏ탍�O�͖|��ΏۊO�Ƃ��A�����s�킸�ɕԂ�
        if (type == LogType.Log)
            return;

        //���O�̏d�����Ȃ����deeplAPI�Ŗ|�󂵁A�|�󌳕��Ɩ|�󌋉ʕ����i�[����
        if (!LogTranslation.LogOrverlappingCheck(condition))
        {
            //deeplAPI�|��Ăяo��
            await LogTranslation.DeeplTranslate(condition);  //�Ăяo����̃��\�b�h���I������܂őҋ@

            //���ɖ|�󌳂��i�[����Ă���ꍇ�͒ǉ����Ȃ�
            if (!LogTranslation.getLogStrage().ContainsKey(condition))
            {
                //�|�󌳕��Ɩ|�󌋉ʕ��̊i�[
                LogTranslation.setLogStrage(condition, LogTranslation.getTranslationResult());//LogTranslation.logStrage.Add(condition,LogTranslation.getTranslationResult());
            }
        }
        //�|�󌋉ʂ̕\��
        Debug.Log(LogTranslation.getTranslationResult());
    }
}
