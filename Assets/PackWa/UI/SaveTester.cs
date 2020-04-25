using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTester : MonoBehaviour
{
    private static SaveTester _instance = null;
    public static SaveTester Instance => _instance;

    [SerializeField]
    UnityEngine.UI.Button m_resetButton = null;
    [SerializeField]
    UnityEngine.UI.Button m_loadButton = null;
    [SerializeField]
    UnityEngine.UI.Button m_saveButton = null;

    [SerializeField]
    TMPro.TextMeshProUGUI m_logTMP = null;

    [SerializeField]
    private SettingItem m_volumeItem = null;
    [SerializeField]
    private SettingDropDownItem m_languageDropDownItem = null;

    [SerializeField]
    SettingDataA m_data = null;

    public void ResetConfigs()
    {
        m_logTMP.SetText("ResetConfigs");
        m_data = new SettingDataA(0, 0);
        m_languageDropDownItem.SetData((int)m_data.Language);
        m_volumeItem.SetData(m_data.Volume);
    }

    public void LoadConfigs()
    {
        m_logTMP.SetText("LoadConfigs");
        SettingDataA data = LocalSaveManager.TempLoad<SettingDataA>();
        if (null == data)
            m_data = (SettingDataA)SettingDataA.GetDefaultSetting();
        else
            m_data = data;
        m_languageDropDownItem.SetData((int)m_data.Language);
        m_volumeItem.SetData(m_data.Volume);
    }

    public void SaveConfigs()
    {
        m_logTMP.SetText("SaveConfigs");
        m_data.SetDataWa(m_volumeItem.GetData(), m_languageDropDownItem.GetData());
        LocalSaveManager.TempSave<SettingDataA>(m_data);
    }

    public void ShowLog(in string log)
    {
        m_logTMP.SetText(log);
    }

    void Awake()
    {
        _instance = this;
        m_resetButton.onClick.AddListener(ResetConfigs);
        m_loadButton.onClick.AddListener(LoadConfigs);
        m_saveButton.onClick.AddListener(SaveConfigs);

        m_data = LocalSaveManager.TempLoad<SettingDataA>();
        if (null == m_data)
            m_data = (SettingDataA)SettingDataA.GetDefaultSetting();
        m_languageDropDownItem.SetUp("Language", SettingDataA.TypeOfLanguageType, (int)m_data.Language);
        m_volumeItem.SetUp("Volume", m_data.Volume);
    }

    void OnEnable()
    {
        this.enabled = false;
    }

    void OnDestroy()
    {
        m_resetButton.onClick.RemoveAllListeners();
        m_loadButton.onClick.RemoveAllListeners();
        m_saveButton.onClick.RemoveAllListeners();
        if (this == _instance)
            _instance = null;
    }

}
