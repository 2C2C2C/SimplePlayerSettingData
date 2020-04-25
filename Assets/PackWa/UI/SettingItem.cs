using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingItem : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI m_fieldNameTMP = null;
    [SerializeField]
    private TMPro.TMP_InputField m_input = null;
    private int m_value = 0;

    public void SetUp(in string fieldName, int value)
    {
        m_fieldNameTMP.text = fieldName;
        if (value < 0)
            m_value = 0;
        else
            m_value = value;
        m_input.text = m_value.ToString();
    }

    public void SetData(int value)
    {
        m_input.text = value.ToString();
    }

    private void OnTextValueChanged(string text)
    {
        if (!Int32.TryParse(text, out m_value))
        {
            m_value = 0;
        }
    }

    public int GetData()
    {
        return m_value;
    }

    private void Awake()
    {
        m_input.onValueChanged.AddListener(OnTextValueChanged);
    }

    private void OnDestroy()
    {
        m_input.onValueChanged.RemoveAllListeners();
    }

    void OnEnable()
    {
        this.enabled = false;
    }

}
