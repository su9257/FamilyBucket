using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : SingletonMonoBehaviour<GameLoop>
{
    public Action OnUpdate;
    public Action OnLateUpdate;
    public Action OnFixedUpdate;

    private void Start()
    {
        //string stackInfo = new System.Diagnostics.StackTrace(true).ToString();
        //Debug.Log(stackInfo);
        
    }

    private void Update()
    {
        try
        {
            OnUpdate?.Invoke();
        }
        catch (Exception exception)
        {
            Debug.Log($"出现异常:{exception}   堆栈信息：{exception.StackTrace}");
            throw;
        }
    }

    private void LateUpdate()
    {
        try
        {
            OnLateUpdate?.Invoke();
        }
        catch (Exception exception)
        {
            string stackInfo = new System.Diagnostics.StackTrace().ToString();
            Debug.Log($"出现异常:{exception}   堆栈信息：{exception.StackTrace}");
            throw;
        }
    }

    private void FixedUpdate()
    {
        try
        {
            OnFixedUpdate?.Invoke();
        }
        catch (Exception exception)
        {
            string stackInfo = new System.Diagnostics.StackTrace().ToString();
            Debug.Log($"出现异常:{exception}   堆栈信息：{exception.StackTrace}");
            throw;
        }
    }

    private void OnDestroy()
    {

    }
}
