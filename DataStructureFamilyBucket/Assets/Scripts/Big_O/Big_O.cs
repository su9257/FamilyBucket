using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Big_O : MonoBehaviour
{

    void Start()
    {
        Test_0();
    }


    /// <summary>
    /// 常数阶
    /// </summary>
    public void Test_0()
    {
        int sum = 0;                           //执行一次
        int n = 100;                            //执行一次
        sum = (1 + n) * n / 2;            //执行一次
        Debug.Log($"时间复杂的为:常数阶O(1)");
    }

    /// <summary>
    /// 线性阶
    /// </summary>
    public void Test_1()
    {
        int length = 100;
        for (int i = 0; i < length; i++)
        {
            Debug.Log("执行1次");
        }

        Debug.Log($"时间复杂的为:线性阶O(n)");
    }

    /// <summary>
    /// 对数阶
    /// </summary>
    public void Test_2()
    {
        int n = 100;
        int result = 1;
        while (result < n)
        {
            result *= 2;    
        }
        Debug.Log($"时间复杂的为:对数阶O(logn)");
    }

    /// <summary>
    /// 平方阶
    /// </summary>
    public void Test_3()
    {
        int n = 100;
        for (int i = 0; i < n; i++)
        {
            for (int k = 0; k < n; k++)
            {

            }
        }
        Debug.Log($"时间复杂的为:平方阶O(n^2)");
    }

}
