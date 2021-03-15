using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{ 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Pool.GetInstance().GetObj("Test/Cube");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Pool.GetInstance().GetObj("Test/Sphere");
        }
    }
}
