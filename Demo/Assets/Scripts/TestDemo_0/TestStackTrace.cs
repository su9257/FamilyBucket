using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStackTrace : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            var stackTrace = new System.Diagnostics.StackTrace(true);
            var frames = stackTrace.GetFrames();
            string stackInfo = stackTrace.ToString();
            Debug.Log(stackInfo);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            try
            {
                Method1();
            }
            catch (Exception e)
            {
                System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace();
                System.Diagnostics.StackTrace st1 = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
                Debug.LogFormat(" Stack trace for Main: {0}",
                   st1.ToString());
                Debug.LogFormat(st.ToString());
            }
        }

    }


    private static void Method1()
    {
        try
        {
            Method2(4);
        }
        catch (Exception e)
        {
            System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace();
            System.Diagnostics.StackTrace st1 = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
            Debug.Log(st.ToString());
            Debug.LogFormat(" Stack trace for Method1: {0}",st1.ToString());
            // 为下一帧构建堆栈跟踪。
            System.Diagnostics.StackTrace st2 = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(1, true));
            Debug.LogFormat(" Stack trace for next level frame: {0}",st2.ToString());
            throw e;
        }
    }

    private static void Method2(int count)
    {
        try
        {
            if (count < 5)
                throw new ArgumentException("count too large", "count");
        }
        catch (Exception e)
        {
            System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(true);
            System.Diagnostics.StackTrace st1 = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(2,true));
            Debug.Log(st.ToString());
            Debug.LogFormat(" Stack trace for Method2: {0}", st1.ToString());
            throw e;
        }
    }
}
