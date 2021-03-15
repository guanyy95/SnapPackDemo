using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayPush : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("Push", 1);
    }

    void Push()
    {
        Pool.GetInstance().PushObj(gameObject.name, gameObject);
    }
}
