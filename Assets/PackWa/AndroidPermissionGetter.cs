using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidPermissionGetter : MonoBehaviour
{
    private string[] m_permissionStrs = new string[]
    {
        "android.permission.READ_PHONE_STATE",
        "android.permission.READ_EXTERNAL_STORAGE"
    };

    private void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            foreach (var str in m_permissionStrs)
                UnityEngine.Android.Permission.RequestUserPermission(str);
        }
        else
        {
            this.enabled = false;
            AndroidPermissionGetter.Destroy(this);
        }
    }
}
