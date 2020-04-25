using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHelper : MonoBehaviour
{

    void Awake()
    {
#if UNITY_STANDALONE
        Destroy(this.gameObject);
#endif
    }

    [ContextMenu("delete setting file A")]
    public void DeleteSettingA()
    {
        LocalSaveManager.TempDelete<SettingDataA>();
    }

}
