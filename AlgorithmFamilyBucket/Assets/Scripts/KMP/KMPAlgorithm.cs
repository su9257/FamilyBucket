using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KMPAlgorithm : MonoBehaviour
{
    public const string content = "BBC ABCDAB ABCDABCDABDE";
    public const string pattern = "ABCDABD";
    void Start()
    {
        var tempNextArray = KMPNext(pattern);

        string content = "";
        for (int i = 0; i < tempNextArray.Length; i++)
        {
            content += $"Index {i} 对应的值为：{tempNextArray[i]} \r\n";
        }

        Debug.Log(content);

        var findIndex = KMPSearch(KMPAlgorithm.content, KMPAlgorithm.pattern, tempNextArray);
        Debug.Log(findIndex);
    }

    public int[] KMPNext(string dest)
    {
        int[] next = new int[dest.Length];
        next[0] = 0;                                                        //字符串如果是一个的话 【不是字段，而是全字符串】
        int j = 0;                                                             //前缀索引
        for (int i = 1; i < dest.Length; i++)                  //后缀索引
        {

            while (j > 0 && dest[i] != dest[j])              //KMP核心【可以理解为公式】
            {
                j = next[j - 1];
            }
            if (dest[i] == dest[j])                                     //部分匹配值 +1
            {
                j++;
            }
            next[i] = j;                                                      /*如果匹配的情况下，前缀串和后缀串一直index差1，
                                                                                   * 且最大相同串的个数正好等于前缀inde【j】*/
        }
        return next;
    }


    public int KMPSearch(string content, string pattern, int[] nextArray)
    {
        int j = 0;                                                                //指向Pattern感觉
        for (int i = 0; i < content.Length; i++)
        {

            while (j > 0 && content[i] != pattern[j])              //KMP核心【可以理解为公式】
            {
                j = nextArray[j - 1];
            }

            if (content[i] == pattern[j])
            {
                j++;
            }

            if (j == pattern.Length)
            {
                return i - j + 1;      //i-(j-1)   因为起始索引为0
            }
        }
        return -1;
    }
}
