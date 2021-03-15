using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T GetInstance()
    {
        if (_instance == null)
        {
            GameObject obj = new GameObject();
            obj.name = typeof(T).ToString();
            
            DontDestroyOnLoad(obj);
            _instance = obj.AddComponent<T>();
        }
        return _instance;
    }
}
