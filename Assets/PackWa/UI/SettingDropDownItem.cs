using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingDropDownItem : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI m_fieldNameTMP = null;
    [SerializeField]
    private TMPro.TMP_Dropdown m_dropdown = null;

    private System.Type m_valueType = null;

    /// <summary>
    /// -1 means non selection
    /// </summary>
    private int m_selectedIndex = 0;
    private List<string> m_itemNames = null;
    // private List<Sprite> m_itemicons = null;

    /// <summary>
    /// inputs should be int or enum
    /// -1 means non selection
    /// </summary>
    /// <param name="fieldName"></param>
    public void SetUp(in string fieldName, System.Type enumType, int selectIndex = 0)
    {
        InitItem();
        m_fieldNameTMP.text = fieldName;

        m_valueType = enumType;
        m_itemNames.AddRange(System.Enum.GetNames(m_valueType));
        m_dropdown.ClearOptions();
        m_dropdown.AddOptions(m_itemNames);
        
        if (selectIndex < 0)
            selectIndex = 0;
        SetData(selectIndex);
    }

    public void SetData(int value)
    {
        m_selectedIndex = value;
        m_dropdown.value = m_selectedIndex;
    }

    public int GetData()
    {
        m_selectedIndex = m_dropdown.value;
        return m_selectedIndex;
    }

    private void OnDropDownValueChanged(int value)
    {
        m_selectedIndex = value;
    }

    private void InitItem()
    {
        if (null == m_itemNames)
        {
            m_selectedIndex = 0;
            m_itemNames = new List<string>();
            m_dropdown.ClearOptions();
            m_dropdown.onValueChanged.RemoveAllListeners();
            m_dropdown.onValueChanged.AddListener(OnDropDownValueChanged);
        }
    }

    private void Awake()
    {
        InitItem();
    }

    private void OnDestroy()
    {
        m_dropdown.onValueChanged.RemoveAllListeners();
    }

    private void OnEnable()
    {
        this.enabled = false;
    }

}
