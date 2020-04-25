using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public partial interface SaveBaseClass<T>
{
    /// <summary>
    /// 得到文件名字
    /// </summary>
    /// <returns></returns>
    string GetFileName();

    /// 类 to 字典
    /// <summary>
    /// 类 to 字典
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    Dictionary<string, object> ModelChangeToDic();

    /// 字典 to 类
    /// <summary>
    /// 字典 to 类
    /// </summary>
    /// <param name="dic"></param>
    /// <returns></returns>
    void DicChangeToModel(Dictionary<string, object> dic);
}
