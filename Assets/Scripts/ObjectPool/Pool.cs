using System.Collections;
using System.Collections.Generic;
using UnityEditor.iOS;
using UnityEngine;

/// <summary>
/// 缓存池模块
/// </summary>
public class Pool : BaseSingleton<Pool>
{
    // 缓存池容器
    public Dictionary<string, List<GameObject>> poolDic = new Dictionary<string, List<GameObject>>();

    /// <summary>
    /// 使用缓存对象
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public GameObject GetObj(string name)
    {
        GameObject obj = null;
        if (poolDic.ContainsKey(name) && poolDic[name].Count > 0)
        {
            obj = poolDic[name][0];
            poolDic[name].RemoveAt(0);
        }
        else
        {
            obj = GameObject.Instantiate(Resources.Load<GameObject>(name), GameObject.Find("Pool").transform);
            obj.name = name;
        }
        obj.SetActive(true);
        return obj;
    }

    /// <summary>
    /// 存放缓存对象
    /// </summary>
    /// <param name="name"></param>
    /// <param name="obj"></param>
    public void PushObj(string name, GameObject obj)
    {
        // 隐藏需要销毁的obj
        obj.SetActive(false);
        if (poolDic.ContainsKey(name))
        {
            poolDic[name].Add(obj);
        }
        else
        {
            poolDic.Add(name, new List<GameObject>(){obj});
        }
    }
}
