using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TempSetting
{
    [System.Serializable]
    public enum LanguageType
    {
        English = 0,
        Chinese = 1,
    }
    [System.Serializable]
    public struct LanguageSetting
    {
        public LanguageType TextLanguage;
    }

    [System.Serializable]
    public struct SoundSetting
    {
        public int MasterVolume;
        public int BGMVolume;
        public int SEVolume;
    }

    public class SettingDataA : SaveBaseClass<SettingDataA>
    {
        private LanguageSetting m_languageSetting = default;
        public LanguageSetting LanugageSetting => m_languageSetting;

        private SoundSetting m_soundSetting = default;
        public SoundSetting SoundSetting => m_soundSetting;

        private static System.Type _TypeOfLanguageType = typeof(LanguageType);
        public static System.Type TypeOfLanguageType => _TypeOfLanguageType;

        private static string _fileName = "SettingA";
        public string GetFileName() => SettingDataA._fileName;

        public SettingDataA()
        {

        }

        public SettingDataA(int volume, int language)
        {
            SetLanguage(language);
        }

        public void SetDataWa(int volume, int language)
        {
            SetLanguage(language);
        }

        public void DicChangeToModel(Dictionary<string, object> dic)
        {
            //m_volume = dic.ContainsKey("Volume") ? int.Parse(dic["Volume"].ToString()) : 50;
            SetLanguage(dic.ContainsKey("Language") ? int.Parse(dic["Language"].ToString()) : 0);
        }

        public Dictionary<string, object> ModelChangeToDic()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            //dic.Add("Volume", Volume);
            //dic.Add("Language", (int)Language);
            return dic;
        }

        public override string ToString()
        {
            return string.Empty;
            //return string.Format("Volume: {0} Language: {1} ", Volume, Language);
        }

        public static SaveBaseClass<SettingDataA> GetDefaultSetting()
        {
            SettingDataA result = new SettingDataA();
            result.m_languageSetting = new LanguageSetting();
            result.m_soundSetting = new SoundSetting();
            return result;
        }

        void SetLanguage(int language)
        {
            //if (0 > language || System.Enum.GetValues(TypeOfLanguageType).Length <= language)
            //    language = 0;
            //else
            //    m_language = (LanguageType)System.Enum.GetValues(TypeOfLanguageType).GetValue(language);
        }
    }
}