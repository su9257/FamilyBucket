using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAwake : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("TestAwake");
    }
    void Start()
    {
        
    }

    public void TestInvoke()
    {
        Debug.Log("TestInvoke");
    }
}
