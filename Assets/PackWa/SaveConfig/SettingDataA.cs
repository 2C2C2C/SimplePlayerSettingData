using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingDataA : SaveBaseClass<SettingDataA>
{
    public enum LanguageType
    {
        English = 0,
        Chinese = 1
    }
    private static System.Type _TypeOfLanguageType = typeof(LanguageType);
    public static System.Type TypeOfLanguageType => _TypeOfLanguageType;

    private static string _fileName = "SettingA";
    public string GetFileName() => SettingDataA._fileName;

    private int m_volume = 0;
    public int Volume => m_volume;
    private LanguageType m_language = default;
    public LanguageType Language => m_language;

    public SettingDataA()
    {
        m_volume = 80;
        m_language = 0;
    }

    public SettingDataA(int volume, int language)
    {
        m_volume = Mathf.Clamp(volume, 0, 100);
        SetLanguage(language);
    }

    public void SetDataWa(int volume, int language)
    {
        m_volume = volume;
        SetLanguage(language);
    }

    public void DicChangeToModel(Dictionary<string, object> dic)
    {
        m_volume = dic.ContainsKey("Volume") ? int.Parse(dic["Volume"].ToString()) : 50;
        SetLanguage(dic.ContainsKey("Language") ? int.Parse(dic["Language"].ToString()) : 0);
    }

    public Dictionary<string, object> ModelChangeToDic()
    {
        Dictionary<string, object> dic = new Dictionary<string, object>();
        dic.Add("Volume", Volume);
        dic.Add("Language", (int)Language);
        return dic;
    }

    public override string ToString()
    {
        return string.Format("Volume: {0} Language: {1} ", Volume, Language);
    }

    public static SaveBaseClass<SettingDataA> GetDefaultSetting()
    {
        return new SettingDataA(80, 0);
    }

    void SetLanguage(int language)
    {
        if (0 > language || System.Enum.GetValues(TypeOfLanguageType).Length <= language)
            language = 0;
        else
            m_language = (LanguageType)System.Enum.GetValues(TypeOfLanguageType).GetValue(language);
    }
}